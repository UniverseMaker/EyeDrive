using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
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
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(txtServer.Text == "" || txtID.Text == "" || txtPW.Text == "")
            {
                MessageBox.Show("서버, 아이디, 암호를 입력해주세요");
                return;
            }
            if(txtMount.Text == "" || txtMount.Text.IndexOf("\\") != -1)
            {
                MessageBox.Show("마운트 정보가 잘못되었습니다");
                return;
            }
            if(th != null)
            {
                MessageBox.Show("연결을 먼저 해제하세요");
                return;
            }

            lblStatus.Text = "Connecting...";
            Application.DoEvents();

            string pw = cmdExecute("rclone.exe obscure " + txtPW.Text);
            label2.Text = "ID && Password (" + pw + ")";

            string opt = " :webdav:/ "+txtMount.Text+" --webdav-url="+txtServer.Text+ " --webdav-user="+txtID.Text+" --webdav-pass="+pw+" --vfs-cache-mode=full --webdav-vendor=other";
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
            lblStatus.Text = "Disconnecting...";
            Application.DoEvents();

            process_con.StandardInput.Close();

            int kcc = 0;
            Process[] pname = Process.GetProcessesByName("rclone");
            while (pname.Length > 0)
            {
                kcc++;
                process_con.StandardInput.Close();
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
    }
}
