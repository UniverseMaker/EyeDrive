namespace EyeDrive
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.txtServer = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.btnForcedDisconnect = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.chkVfsCacheOff = new System.Windows.Forms.ToolStripMenuItem();
            this.chkVfsCacheMinimal = new System.Windows.Forms.ToolStripMenuItem();
            this.chkVfsCacheWrites = new System.Windows.Forms.ToolStripMenuItem();
            this.chkVfsCacheFull = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtPW = new System.Windows.Forms.TextBox();
            this.chkDebug = new System.Windows.Forms.CheckBox();
            this.chkWindowsRW = new System.Windows.Forms.CheckBox();
            this.txtCache = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkCMDHide = new System.Windows.Forms.CheckBox();
            this.txtMount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.timerAutosave = new System.Windows.Forms.Timer(this.components);
            this.chkAutoSave = new System.Windows.Forms.CheckBox();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.chkDirectShowDebug = new System.Windows.Forms.CheckBox();
            this.chkCMDRun = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Server";
            // 
            // txtServer
            // 
            this.txtServer.Location = new System.Drawing.Point(15, 60);
            this.txtServer.Name = "txtServer";
            this.txtServer.Size = new System.Drawing.Size(366, 28);
            this.txtServer.TabIndex = 1;
            this.txtServer.Text = "https://.synology.com:5006";
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnConnect,
            this.btnDisconnect,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(393, 33);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnConnect
            // 
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 32);
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnForcedDisconnect});
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(118, 32);
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnForcedDisconnect
            // 
            this.btnForcedDisconnect.Name = "btnForcedDisconnect";
            this.btnForcedDisconnect.Size = new System.Drawing.Size(266, 34);
            this.btnForcedDisconnect.Text = "Forced Disconnect";
            this.btnForcedDisconnect.Click += new System.EventHandler(this.btnForcedDisconnect_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chkVfsCacheOff,
            this.chkVfsCacheMinimal,
            this.chkVfsCacheWrites,
            this.chkVfsCacheFull});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(92, 32);
            this.toolStripMenuItem1.Text = "Options";
            // 
            // chkVfsCacheOff
            // 
            this.chkVfsCacheOff.CheckOnClick = true;
            this.chkVfsCacheOff.Name = "chkVfsCacheOff";
            this.chkVfsCacheOff.Size = new System.Drawing.Size(273, 34);
            this.chkVfsCacheOff.Text = "VFS Cache: Off";
            this.chkVfsCacheOff.CheckedChanged += new System.EventHandler(this.chkVfsCacheOff_CheckedChanged);
            // 
            // chkVfsCacheMinimal
            // 
            this.chkVfsCacheMinimal.CheckOnClick = true;
            this.chkVfsCacheMinimal.Name = "chkVfsCacheMinimal";
            this.chkVfsCacheMinimal.Size = new System.Drawing.Size(273, 34);
            this.chkVfsCacheMinimal.Text = "VFS Cache: Minimal";
            this.chkVfsCacheMinimal.CheckedChanged += new System.EventHandler(this.chkVfsCacheMinimal_CheckedChanged);
            // 
            // chkVfsCacheWrites
            // 
            this.chkVfsCacheWrites.CheckOnClick = true;
            this.chkVfsCacheWrites.Name = "chkVfsCacheWrites";
            this.chkVfsCacheWrites.Size = new System.Drawing.Size(273, 34);
            this.chkVfsCacheWrites.Text = "VFS Cache: Writes";
            this.chkVfsCacheWrites.CheckedChanged += new System.EventHandler(this.chkVfsCacheWrites_CheckedChanged);
            // 
            // chkVfsCacheFull
            // 
            this.chkVfsCacheFull.Checked = true;
            this.chkVfsCacheFull.CheckOnClick = true;
            this.chkVfsCacheFull.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVfsCacheFull.Name = "chkVfsCacheFull";
            this.chkVfsCacheFull.Size = new System.Drawing.Size(273, 34);
            this.chkVfsCacheFull.Text = "VFS Cache: Full";
            this.chkVfsCacheFull.CheckedChanged += new System.EventHandler(this.chkVfsCacheFull_CheckedChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus,
            this.lblStatus2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(393, 32);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(179, 25);
            this.lblStatus.Text = "Wait for Connection.";
            // 
            // lblStatus2
            // 
            this.lblStatus2.Name = "lblStatus2";
            this.lblStatus2.Size = new System.Drawing.Size(166, 25);
            this.lblStatus2.Text = "| P-Watcher Ready.";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(15, 117);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(177, 28);
            this.txtID.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(128, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID && Password";
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(198, 117);
            this.txtPW.Name = "txtPW";
            this.txtPW.PasswordChar = '#';
            this.txtPW.Size = new System.Drawing.Size(183, 28);
            this.txtPW.TabIndex = 6;
            // 
            // chkDebug
            // 
            this.chkDebug.AutoSize = true;
            this.chkDebug.Location = new System.Drawing.Point(15, 208);
            this.chkDebug.Name = "chkDebug";
            this.chkDebug.Size = new System.Drawing.Size(127, 22);
            this.chkDebug.TabIndex = 7;
            this.chkDebug.Text = "Debug(Log)";
            this.chkDebug.UseVisualStyleBackColor = true;
            // 
            // chkWindowsRW
            // 
            this.chkWindowsRW.AutoSize = true;
            this.chkWindowsRW.Checked = true;
            this.chkWindowsRW.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWindowsRW.Location = new System.Drawing.Point(148, 208);
            this.chkWindowsRW.Name = "chkWindowsRW";
            this.chkWindowsRW.Size = new System.Drawing.Size(94, 22);
            this.chkWindowsRW.TabIndex = 8;
            this.chkWindowsRW.Text = "Win RW";
            this.chkWindowsRW.UseVisualStyleBackColor = true;
            // 
            // txtCache
            // 
            this.txtCache.Location = new System.Drawing.Point(15, 174);
            this.txtCache.Name = "txtCache";
            this.txtCache.Size = new System.Drawing.Size(213, 28);
            this.txtCache.TabIndex = 10;
            this.txtCache.Text = "Z:\\Cache";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "Cache";
            // 
            // chkCMDHide
            // 
            this.chkCMDHide.AutoSize = true;
            this.chkCMDHide.Checked = true;
            this.chkCMDHide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCMDHide.Location = new System.Drawing.Point(248, 208);
            this.chkCMDHide.Name = "chkCMDHide";
            this.chkCMDHide.Size = new System.Drawing.Size(112, 22);
            this.chkCMDHide.TabIndex = 11;
            this.chkCMDHide.Text = "Hide CMD";
            this.chkCMDHide.UseVisualStyleBackColor = true;
            // 
            // txtMount
            // 
            this.txtMount.Location = new System.Drawing.Point(234, 174);
            this.txtMount.Name = "txtMount";
            this.txtMount.Size = new System.Drawing.Size(147, 28);
            this.txtMount.TabIndex = 13;
            this.txtMount.Text = "Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(231, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 18);
            this.label4.TabIndex = 12;
            this.label4.Text = "Mount";
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // timerAutosave
            // 
            this.timerAutosave.Interval = 3000;
            // 
            // chkAutoSave
            // 
            this.chkAutoSave.AutoSize = true;
            this.chkAutoSave.Location = new System.Drawing.Point(15, 236);
            this.chkAutoSave.Name = "chkAutoSave";
            this.chkAutoSave.Size = new System.Drawing.Size(385, 22);
            this.chkAutoSave.TabIndex = 14;
            this.chkAutoSave.Text = "AutoSave (Save Info When Press Connect)";
            this.chkAutoSave.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Location = new System.Drawing.Point(15, 264);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(366, 28);
            this.txtResult.TabIndex = 15;
            // 
            // chkDirectShowDebug
            // 
            this.chkDirectShowDebug.AutoSize = true;
            this.chkDirectShowDebug.Checked = true;
            this.chkDirectShowDebug.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkDirectShowDebug.Location = new System.Drawing.Point(15, 298);
            this.chkDirectShowDebug.Name = "chkDirectShowDebug";
            this.chkDirectShowDebug.Size = new System.Drawing.Size(119, 22);
            this.chkDirectShowDebug.TabIndex = 16;
            this.chkDirectShowDebug.Text = "D.S.Debug";
            this.chkDirectShowDebug.UseVisualStyleBackColor = true;
            // 
            // chkCMDRun
            // 
            this.chkCMDRun.AutoSize = true;
            this.chkCMDRun.Checked = true;
            this.chkCMDRun.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCMDRun.Location = new System.Drawing.Point(148, 298);
            this.chkCMDRun.Name = "chkCMDRun";
            this.chkCMDRun.Size = new System.Drawing.Size(161, 22);
            this.chkCMDRun.TabIndex = 17;
            this.chkCMDRun.Text = "CMD Run Mode";
            this.chkCMDRun.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 361);
            this.Controls.Add(this.chkCMDRun);
            this.Controls.Add(this.chkDirectShowDebug);
            this.Controls.Add(this.txtResult);
            this.Controls.Add(this.chkAutoSave);
            this.Controls.Add(this.txtMount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkCMDHide);
            this.Controls.Add(this.txtCache);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkWindowsRW);
            this.Controls.Add(this.chkDebug);
            this.Controls.Add(this.txtPW);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtServer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Eyedrive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtServer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPW;
        private System.Windows.Forms.CheckBox chkDebug;
        private System.Windows.Forms.CheckBox chkWindowsRW;
        private System.Windows.Forms.TextBox txtCache;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripMenuItem btnConnect;
        private System.Windows.Forms.CheckBox chkCMDHide;
        private System.Windows.Forms.TextBox txtMount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem btnDisconnect;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem chkVfsCacheOff;
        private System.Windows.Forms.ToolStripMenuItem chkVfsCacheMinimal;
        private System.Windows.Forms.ToolStripMenuItem chkVfsCacheWrites;
        private System.Windows.Forms.ToolStripMenuItem chkVfsCacheFull;
        private System.Windows.Forms.ToolStripMenuItem btnForcedDisconnect;
        private System.Windows.Forms.Timer timerAutosave;
        private System.Windows.Forms.CheckBox chkAutoSave;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.CheckBox chkDirectShowDebug;
        private System.Windows.Forms.CheckBox chkCMDRun;
    }
}

