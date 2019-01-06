namespace HyperGTS
{
    partial class Form_HyperGTS
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_HyperGTS));
            this.BGW_DNS = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.CB_RANDOMIZE = new System.Windows.Forms.CheckBox();
            this.RB_GTS_SendFolder = new System.Windows.Forms.RadioButton();
            this.RB_GTS_SendOne = new System.Windows.Forms.RadioButton();
            this.LL_GTS_clearLog = new System.Windows.Forms.LinkLabel();
            this.BT_GTS = new System.Windows.Forms.Button();
            this.LA_GTS_Status = new System.Windows.Forms.Label();
            this.LB_GTS_Log = new System.Windows.Forms.ListBox();
            this.BT_GTS_SendPKMN = new System.Windows.Forms.Button();
            this.TB_GTS_SendPKMN = new System.Windows.Forms.TextBox();
            this.CB_GTS_SendPKMN = new System.Windows.Forms.CheckBox();
            this.OFD_SendPKMN = new System.Windows.Forms.OpenFileDialog();
            this.BGW_GTS = new System.ComponentModel.BackgroundWorker();
            this.LL_Help = new System.Windows.Forms.LinkLabel();
            this.FBD_GTS_SendFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // BGW_DNS
            // 
            this.BGW_DNS.WorkerReportsProgress = true;
            this.BGW_DNS.WorkerSupportsCancellation = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.CB_RANDOMIZE);
            this.groupBox2.Controls.Add(this.RB_GTS_SendFolder);
            this.groupBox2.Controls.Add(this.RB_GTS_SendOne);
            this.groupBox2.Controls.Add(this.LL_GTS_clearLog);
            this.groupBox2.Controls.Add(this.BT_GTS);
            this.groupBox2.Controls.Add(this.LA_GTS_Status);
            this.groupBox2.Controls.Add(this.LB_GTS_Log);
            this.groupBox2.Controls.Add(this.BT_GTS_SendPKMN);
            this.groupBox2.Controls.Add(this.TB_GTS_SendPKMN);
            this.groupBox2.Controls.Add(this.CB_GTS_SendPKMN);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(913, 468);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Fake GTS";
            // 
            // CB_RANDOMIZE
            // 
            this.CB_RANDOMIZE.AutoSize = true;
            this.CB_RANDOMIZE.Location = new System.Drawing.Point(6, 58);
            this.CB_RANDOMIZE.Name = "CB_RANDOMIZE";
            this.CB_RANDOMIZE.Size = new System.Drawing.Size(157, 17);
            this.CB_RANDOMIZE.TabIndex = 10;
            this.CB_RANDOMIZE.Text = "Randomize (Directory Only!)";
            this.CB_RANDOMIZE.UseVisualStyleBackColor = true;
            // 
            // RB_GTS_SendFolder
            // 
            this.RB_GTS_SendFolder.AutoSize = true;
            this.RB_GTS_SendFolder.Enabled = false;
            this.RB_GTS_SendFolder.Location = new System.Drawing.Point(190, 14);
            this.RB_GTS_SendFolder.Name = "RB_GTS_SendFolder";
            this.RB_GTS_SendFolder.Size = new System.Drawing.Size(90, 17);
            this.RB_GTS_SendFolder.TabIndex = 9;
            this.RB_GTS_SendFolder.Text = "all from folder:";
            this.RB_GTS_SendFolder.UseVisualStyleBackColor = true;
            this.RB_GTS_SendFolder.CheckedChanged += new System.EventHandler(this.RB_GTS_SendFolder_CheckedChanged);
            // 
            // RB_GTS_SendOne
            // 
            this.RB_GTS_SendOne.AutoSize = true;
            this.RB_GTS_SendOne.Checked = true;
            this.RB_GTS_SendOne.Enabled = false;
            this.RB_GTS_SendOne.Location = new System.Drawing.Point(115, 14);
            this.RB_GTS_SendOne.Name = "RB_GTS_SendOne";
            this.RB_GTS_SendOne.Size = new System.Drawing.Size(69, 17);
            this.RB_GTS_SendOne.TabIndex = 8;
            this.RB_GTS_SendOne.TabStop = true;
            this.RB_GTS_SendOne.Text = "one .pkm";
            this.RB_GTS_SendOne.UseVisualStyleBackColor = true;
            this.RB_GTS_SendOne.CheckedChanged += new System.EventHandler(this.RB_GTS_SendOne_CheckedChanged);
            // 
            // LL_GTS_clearLog
            // 
            this.LL_GTS_clearLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LL_GTS_clearLog.AutoSize = true;
            this.LL_GTS_clearLog.Location = new System.Drawing.Point(860, 135);
            this.LL_GTS_clearLog.Name = "LL_GTS_clearLog";
            this.LL_GTS_clearLog.Size = new System.Drawing.Size(47, 13);
            this.LL_GTS_clearLog.TabIndex = 6;
            this.LL_GTS_clearLog.TabStop = true;
            this.LL_GTS_clearLog.Text = "clear log";
            this.LL_GTS_clearLog.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_GTS_clearLog_LinkClicked);
            // 
            // BT_GTS
            // 
            this.BT_GTS.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_GTS.Location = new System.Drawing.Point(6, 105);
            this.BT_GTS.Name = "BT_GTS";
            this.BT_GTS.Size = new System.Drawing.Size(905, 23);
            this.BT_GTS.TabIndex = 6;
            this.BT_GTS.Text = "START GTS";
            this.BT_GTS.UseVisualStyleBackColor = true;
            this.BT_GTS.Click += new System.EventHandler(this.button1_Click);
            // 
            // LA_GTS_Status
            // 
            this.LA_GTS_Status.AutoSize = true;
            this.LA_GTS_Status.BackColor = System.Drawing.Color.Red;
            this.LA_GTS_Status.Location = new System.Drawing.Point(6, 135);
            this.LA_GTS_Status.Name = "LA_GTS_Status";
            this.LA_GTS_Status.Size = new System.Drawing.Size(70, 13);
            this.LA_GTS_Status.TabIndex = 4;
            this.LA_GTS_Status.Text = "GTS stopped";
            // 
            // LB_GTS_Log
            // 
            this.LB_GTS_Log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.LB_GTS_Log.FormattingEnabled = true;
            this.LB_GTS_Log.HorizontalScrollbar = true;
            this.LB_GTS_Log.Location = new System.Drawing.Point(6, 152);
            this.LB_GTS_Log.Name = "LB_GTS_Log";
            this.LB_GTS_Log.Size = new System.Drawing.Size(905, 303);
            this.LB_GTS_Log.TabIndex = 5;
            // 
            // BT_GTS_SendPKMN
            // 
            this.BT_GTS_SendPKMN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BT_GTS_SendPKMN.Enabled = false;
            this.BT_GTS_SendPKMN.Location = new System.Drawing.Point(882, 30);
            this.BT_GTS_SendPKMN.Name = "BT_GTS_SendPKMN";
            this.BT_GTS_SendPKMN.Size = new System.Drawing.Size(27, 23);
            this.BT_GTS_SendPKMN.TabIndex = 2;
            this.BT_GTS_SendPKMN.Text = "...";
            this.BT_GTS_SendPKMN.UseVisualStyleBackColor = true;
            this.BT_GTS_SendPKMN.Click += new System.EventHandler(this.BT_GTS_SendPKMN_Click);
            // 
            // TB_GTS_SendPKMN
            // 
            this.TB_GTS_SendPKMN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_GTS_SendPKMN.Enabled = false;
            this.TB_GTS_SendPKMN.Location = new System.Drawing.Point(6, 32);
            this.TB_GTS_SendPKMN.Name = "TB_GTS_SendPKMN";
            this.TB_GTS_SendPKMN.Size = new System.Drawing.Size(872, 20);
            this.TB_GTS_SendPKMN.TabIndex = 1;
            // 
            // CB_GTS_SendPKMN
            // 
            this.CB_GTS_SendPKMN.AutoSize = true;
            this.CB_GTS_SendPKMN.Checked = true;
            this.CB_GTS_SendPKMN.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CB_GTS_SendPKMN.Location = new System.Drawing.Point(6, 15);
            this.CB_GTS_SendPKMN.Name = "CB_GTS_SendPKMN";
            this.CB_GTS_SendPKMN.Size = new System.Drawing.Size(102, 17);
            this.CB_GTS_SendPKMN.TabIndex = 0;
            this.CB_GTS_SendPKMN.Text = "Send Pokemon:";
            this.CB_GTS_SendPKMN.UseVisualStyleBackColor = true;
            this.CB_GTS_SendPKMN.CheckedChanged += new System.EventHandler(this.CB_GTS_SendPKMN_CheckedChanged);
            // 
            // OFD_SendPKMN
            // 
            this.OFD_SendPKMN.DefaultExt = "pkm";
            this.OFD_SendPKMN.FileName = "pkm.pkm";
            this.OFD_SendPKMN.Filter = ".pkm Files|*.pkm";
            this.OFD_SendPKMN.SupportMultiDottedExtensions = true;
            // 
            // BGW_GTS
            // 
            this.BGW_GTS.WorkerReportsProgress = true;
            this.BGW_GTS.WorkerSupportsCancellation = true;
            this.BGW_GTS.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGW_GTS_DoWork);
            this.BGW_GTS.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGW_GTS_ProgressChanged);
            this.BGW_GTS.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGW_GTS_RunWorkerCompleted);
            // 
            // LL_Help
            // 
            this.LL_Help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LL_Help.Location = new System.Drawing.Point(872, 451);
            this.LL_Help.Name = "LL_Help";
            this.LL_Help.Size = new System.Drawing.Size(31, 23);
            this.LL_Help.TabIndex = 3;
            this.LL_Help.TabStop = true;
            this.LL_Help.Text = "Help";
            this.LL_Help.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.LL_Help.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LL_Help_LinkClicked);
            // 
            // FBD_GTS_SendFolder
            // 
            this.FBD_GTS_SendFolder.Description = "Select the Folder where the .pkm are in:";
            this.FBD_GTS_SendFolder.ShowNewFolderButton = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 89);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(688, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "HyperGTS by Madaruwode. Modified by Shiny Jirachi. Based on Fake GTS server v0.2 " +
                "(M@T) / sendpkm.py (LordLandon), fake_gts.py (Eevee)";
            // 
            // Form_HyperGTS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 468);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.LL_Help);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_HyperGTS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HyperGTS v1.02. Edited by: Shiny Jirachi";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.ComponentModel.BackgroundWorker BGW_DNS;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BT_GTS_SendPKMN;
        private System.Windows.Forms.TextBox TB_GTS_SendPKMN;
        private System.Windows.Forms.CheckBox CB_GTS_SendPKMN;
        private System.Windows.Forms.LinkLabel LL_GTS_clearLog;
        private System.Windows.Forms.Button BT_GTS;
        private System.Windows.Forms.Label LA_GTS_Status;
        private System.Windows.Forms.ListBox LB_GTS_Log;
        private System.Windows.Forms.OpenFileDialog OFD_SendPKMN;
        private System.ComponentModel.BackgroundWorker BGW_GTS;
        private System.Windows.Forms.LinkLabel LL_Help;
        private System.Windows.Forms.RadioButton RB_GTS_SendOne;
        private System.Windows.Forms.RadioButton RB_GTS_SendFolder;
        private System.Windows.Forms.FolderBrowserDialog FBD_GTS_SendFolder;
        private System.Windows.Forms.CheckBox CB_RANDOMIZE;
        private System.Windows.Forms.Label label1;
    }
}

