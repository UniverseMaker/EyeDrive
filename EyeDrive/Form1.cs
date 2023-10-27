using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EyeDrive
{
    public partial class Form1 : Form
    {
        System.Threading.Thread th = null;
        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            LoadSave();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtServer.Text == "" || txtID.Text == "" || txtPW.Text == "")
            {
                MessageBox.Show("Please Insert Server, ID, Password Informations.");
                return;
            }
            if (txtMount.Text == "" || txtMount.Text.IndexOf("\\") != -1)
            {
                MessageBox.Show("Mount Prefix Name Information Wrong. (ex. Y:)");
                return;
            }
            if ((new FileInfo("C:\\Program Files (x86)\\WinFsp\\bin\\launcher-x64.exe")).Exists == false)
            {
                MessageBox.Show("Please Install WinFSP Software!");
                return;
            }
            if (th != null)
            {
                MessageBox.Show("Connection Detected. Please Disconnect First.");
                return;
            }
            try
            {
                if ((new DirectoryInfo(txtCache.Text)).Exists == false)
                    txtCache.Text = "";
            }
            catch (Exception ex) { txtCache.Text = ""; }
            AutoSave();

            lblStatus.Text = "Connecting...";
            Application.DoEvents();

            string pw = cmdExecute("rclone.exe obscure " + txtPW.Text);
            label2.Text = "ID && Password (" + pw + ")";

            string vfscache = "full";
            if (chkVfsCacheOff.Checked)
                vfscache = "off";
            else if (chkVfsCacheMinimal.Checked)
                vfscache = "minimal";
            else if (chkVfsCacheWrites.Checked)
                vfscache = "writes";
            else if (chkVfsCacheFull.Checked)
                vfscache = "full";

            string opt = " :webdav:/ " + txtMount.Text + " --webdav-url=" + txtServer.Text + " --webdav-user=" + txtID.Text + " --webdav-pass=" + pw + " --vfs-cache-mode=" + vfscache + " --webdav-vendor=other";
            if (txtCache.Text != "")
                opt += " --cache-dir=" + txtCache.Text;
            if (chkDebug.Checked)
                opt += " --log-file log.txt --log-level=DEBUG";
            if (chkWindowsRW.Checked)
                opt += " -o FileSecurity=\"D:P(A;;FA;;;WD)\"";

            //th = new System.Threading.Thread(() => connectWebDav(opt, chkCMDHide.Checked));
            connectWebDav(opt, chkCMDHide.Checked);
            timer.Enabled = true;

            lblStatus.Text = "Connected.";

            Application.DoEvents();
        }

        public void enableSystem()
        {
            txtServer.Enabled = true;
            txtID.Enabled = true;
            txtPW.Enabled = true;
            txtMount.Enabled = true;
            txtCache.Enabled = true;
            chkDebug.Enabled = true;
            chkWindowsRW.Enabled = true;
            chkCMDHide.Enabled = true;
        }

        public void disableSystem()
        {
            txtServer.Enabled = false;
            txtID.Enabled = false;
            txtPW.Enabled = false;
            txtMount.Enabled = false;
            txtCache.Enabled = false;
            chkDebug.Enabled = false;
            chkWindowsRW.Enabled = false;
            chkCMDHide.Enabled = false;
        }

        public string cmdExecute(string data, bool hide = true)
        {
            ProcessStartInfo cmd = new ProcessStartInfo();
            Process process = new Process();
            cmd.FileName = @"cmd";
            if (hide == true)
            {
                cmd.WindowStyle = ProcessWindowStyle.Hidden;             // cmd창이 숨겨지도록 하기
                cmd.CreateNoWindow = true;                               // cmd창을 띄우지 안도록 하기
            }
            else
            {
                cmd.WindowStyle = ProcessWindowStyle.Normal;             // cmd창이 숨겨지도록 하기
                cmd.CreateNoWindow = false;                               // cmd창을 띄우지 안도록 하기
            }

            cmd.UseShellExecute = false;
            cmd.RedirectStandardOutput = true;
            cmd.RedirectStandardInput = true;
            cmd.RedirectStandardError = true;

            process.EnableRaisingEvents = false;
            process.StartInfo = cmd;
            process.Start();
            process.StandardInput.Write(data + Environment.NewLine);
            process.StandardInput.Close();

            string result = process.StandardOutput.ReadToEnd();
            string prs = "";
            string src = "";
            foreach (string line in System.Text.RegularExpressions.Regex.Split(result, "\r\n"))
            {
                if (line.IndexOf(data) != -1)
                    src = line.Replace(data, "");

                if (src != "" && line.IndexOf(data) == -1 && line.IndexOf(src) == -1 && line != "")
                    prs += line.Replace("\r", "").Replace("\n", "");

                if (src != "" && line.IndexOf(data) == -1 && line.IndexOf(src) != -1 && line != "")
                    break;
            }

            process.WaitForExit();
            process.Close();

            return prs;
        }

        ProcessStartInfo cmd_con = null;
        Process process_con = null;
        bool discon = false;
        public void connectWebDav(string opt, bool hide)
        {
            cmd_con = new ProcessStartInfo();
            process_con = new Process();

            cmd_con.FileName = @"cmd";
            if (hide == true)
            {
                cmd_con.WindowStyle = ProcessWindowStyle.Hidden;             // cmd창이 숨겨지도록 하기
                cmd_con.CreateNoWindow = true;                               // cmd창을 띄우지 안도록 하기
            }
            else
            {
                cmd_con.WindowStyle = ProcessWindowStyle.Normal;             // cmd창이 숨겨지도록 하기
                cmd_con.CreateNoWindow = false;                               // cmd창을 띄우지 안도록 하기
            }

            cmd_con.UseShellExecute = false;
            cmd_con.RedirectStandardOutput = true;
            cmd_con.RedirectStandardInput = true;
            cmd_con.RedirectStandardError = true;

            process_con.EnableRaisingEvents = false;
            process_con.StartInfo = cmd_con;
            process_con.Start();
            process_con.StandardInput.Write("rclone.exe mount" + opt + Environment.NewLine);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Process[] pname = Process.GetProcessesByName("rclone");
            if (pname.Length > 0)
                lblStatus2.Text = "P-Detect " + pname.Length.ToString();
            else
                lblStatus2.Text = "P-Watcher Ready.";

            Application.DoEvents();
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Disconnecting...";
                Application.DoEvents();

                try
                {
                    process_con.StandardInput.Close();
                }
                catch { }

                int kcc = 0;
                Process[] pname = Process.GetProcessesByName("rclone");
                while (pname.Length > 0)
                {
                    kcc++;
                    try
                    {
                        process_con.StandardInput.Close();
                    }
                    catch { }
                    pname = Process.GetProcessesByName("rclone");
                    System.Threading.Thread.Sleep(0);

                    if (kcc > 50)
                    {
                        foreach (Process p in pname)
                        {
                            p.Kill();
                            System.Threading.Thread.Sleep(0);
                        }

                        break;
                    }
                }

                cmd_con = null;
                process_con = null;

                lblStatus.Text = "Disconnected.";
                Application.DoEvents();
            }
            catch
            {
                lblStatus.Text = "Err.";
                Application.DoEvents();
            }
        }

        private void chkVfsCacheOff_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVfsCacheOff.Checked)
            {
                chkVfsCacheFull.Checked = false;
                chkVfsCacheMinimal.Checked = false;
                chkVfsCacheWrites.Checked = false;
            }
        }

        private void chkVfsCacheMinimal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVfsCacheMinimal.Checked)
            {
                chkVfsCacheFull.Checked = false;
                chkVfsCacheOff.Checked = false;
                chkVfsCacheWrites.Checked = false;
            }
        }

        private void chkVfsCacheWrites_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVfsCacheWrites.Checked)
            {
                chkVfsCacheFull.Checked = false;
                chkVfsCacheMinimal.Checked = false;
                chkVfsCacheOff.Checked = false;
            }
        }

        private void chkVfsCacheFull_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVfsCacheFull.Checked)
            {
                chkVfsCacheOff.Checked = false;
                chkVfsCacheMinimal.Checked = false;
                chkVfsCacheWrites.Checked = false;
            }
        }

        private void btnForcedDisconnect_Click(object sender, EventArgs e)
        {
            try
            {
                lblStatus.Text = "Disconnecting...";
                Application.DoEvents();

                int kcc = 0;
                Process[] pname = Process.GetProcessesByName("rclone");
                while (pname.Length > 0)
                {
                    kcc++;
                    pname = Process.GetProcessesByName("rclone");
                    System.Threading.Thread.Sleep(0);

                    if (kcc > 50)
                    {
                        foreach (Process p in pname)
                        {
                            p.Kill();
                            System.Threading.Thread.Sleep(0);
                        }

                        break;
                    }
                }

                cmd_con = null;
                process_con = null;

                lblStatus.Text = "Disconnected.";
                Application.DoEvents();
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Err.";
                Application.DoEvents();
            }
        }

        public void AutoSave()
        {
            if (chkAutoSave.Checked)
            {
                string data = "";
                data += "Server/_/" + txtServer.Text + "\r\n";
                data += "ID/_/" + txtID.Text + "\r\n";
                data += "Password/_/" + txtPW.Text + "\r\n";
                data += "MountLoc/_/" + txtMount.Text + "\r\n";
                data += "CacheLoc/_/" + txtCache.Text + "\r\n";

                data += "AutoSave/_/" + chkAutoSave.Checked.ToString() + "\r\n";
                data += "Debug/_/" + chkDebug.Checked.ToString() + "\r\n";
                data += "WinRW/_/" + chkWindowsRW.Checked.ToString() + "\r\n";
                data += "HideCMD/_/" + chkCMDHide.Checked.ToString() + "\r\n";

                data += "VFS-Off/_/" + chkVfsCacheOff.Checked.ToString() + "\r\n";
                data += "VFS-Minimal/_/" + chkVfsCacheMinimal.Checked.ToString() + "\r\n";
                data += "VFS-Writes/_/" + chkVfsCacheWrites.Checked.ToString() + "\r\n";
                data += "VFS-Full/_/" + chkVfsCacheFull.Checked.ToString() + "\r\n";

                using (StreamWriter outputFile = new StreamWriter(Application.StartupPath + "\\config.cfg", false))
                {
                    outputFile.Write(data);
                }
            }
        }

        public void LoadSave()
        {
            try
            {
                Dictionary<string, string> configs = new Dictionary<string, string>();
                string data = File.ReadAllText(Application.StartupPath + "\\config.cfg");
                string[] datasplit = System.Text.RegularExpressions.Regex.Split(data, "\r\n");
                for (int i = 0; i < datasplit.Length; i++)
                {
                    try
                    {
                        string[] split2 = System.Text.RegularExpressions.Regex.Split(datasplit[i], "/_/");
                        configs.Add(split2[0], split2[1]);
                    }
                    catch (Exception ex) { }
                }

                txtServer.Text = configs["Server"];
                txtID.Text = configs["ID"];
                txtPW.Text = configs["Password"];
                txtMount.Text = configs["MountLoc"];
                txtCache.Text = configs["CacheLoc"];
                chkAutoSave.Checked = Convert.ToBoolean(configs["AutoSave"]);
                chkDebug.Checked = Convert.ToBoolean(configs["Debug"]);
                chkWindowsRW.Checked = Convert.ToBoolean(configs["WinRW"]);
                chkCMDHide.Checked = Convert.ToBoolean(configs["HideCMD"]);
                chkVfsCacheOff.Checked = Convert.ToBoolean(configs["VFS-Off"]);
                chkVfsCacheMinimal.Checked = Convert.ToBoolean(configs["VFS-Minimal"]);
                chkVfsCacheWrites.Checked = Convert.ToBoolean(configs["VFS-Writes"]);
                chkVfsCacheFull.Checked = Convert.ToBoolean(configs["VFS-Full"]);
            }
            catch
            {

            }
        }
    }
}
