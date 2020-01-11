namespace SQLCloneToGo
{
    partial class frmClone
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmClone));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.listOutput = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.btnGo = new System.Windows.Forms.Button();
            this.txtSrcDB = new System.Windows.Forms.TextBox();
            this.txtTargetDB = new System.Windows.Forms.TextBox();
            this.linkMain = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressMain = new System.Windows.Forms.ToolStripProgressBar();
            this.lblFail = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblSuccess = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblVersion = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtServerSrc = new System.Windows.Forms.TextBox();
            this.txtServerTarget = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.chkVerbose = new System.Windows.Forms.CheckBox();
            this.chkLastVersion = new System.Windows.Forms.CheckBox();
            this.txtDbVersion = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Source : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Target :";
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(62, 5);
            this.txtSource.Name = "txtSource";
            this.txtSource.ReadOnly = true;
            this.txtSource.Size = new System.Drawing.Size(340, 20);
            this.txtSource.TabIndex = 2;
            this.txtSource.Text = "Data Source=.\\ZOMOROD;Initial Catalog=zomorod722-1;Integrated Security=True;";
            this.txtSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(62, 31);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.ReadOnly = true;
            this.txtTarget.Size = new System.Drawing.Size(340, 20);
            this.txtTarget.TabIndex = 3;
            this.txtTarget.Text = "Data Source=.\\ZOMOROD;Initial Catalog=zomorod722-1;Integrated Security=True;";
            this.txtTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output :";
            // 
            // listOutput
            // 
            this.listOutput.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listOutput.FormattingEnabled = true;
            this.listOutput.HorizontalScrollbar = true;
            this.listOutput.Location = new System.Drawing.Point(62, 83);
            this.listOutput.Name = "listOutput";
            this.listOutput.Size = new System.Drawing.Size(708, 303);
            this.listOutput.TabIndex = 2;
            this.listOutput.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listOutput_DrawItem);
            this.listOutput.DoubleClick += new System.EventHandler(this.listOutput_DoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnBackup);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Location = new System.Drawing.Point(56, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 78);
            this.panel1.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = global::SQLCloneToGo.Properties.Resources.logout;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(6, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(117, 72);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnClear
            // 
            this.btnClear.BackgroundImage = global::SQLCloneToGo.Properties.Resources.browser_2;
            this.btnClear.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(474, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 72);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Cle&ar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackgroundImage = global::SQLCloneToGo.Properties.Resources.cloud_computing;
            this.btnBackup.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBackup.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBackup.Location = new System.Drawing.Point(351, 4);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(117, 72);
            this.btnBackup.TabIndex = 9;
            this.btnBackup.Text = "Backup";
            this.btnBackup.UseVisualStyleBackColor = true;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // btnGo
            // 
            this.btnGo.BackgroundImage = global::SQLCloneToGo.Properties.Resources.sync_1;
            this.btnGo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGo.Location = new System.Drawing.Point(597, 3);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(117, 72);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "&Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // txtSrcDB
            // 
            this.txtSrcDB.Location = new System.Drawing.Point(584, 5);
            this.txtSrcDB.Name = "txtSrcDB";
            this.txtSrcDB.Size = new System.Drawing.Size(162, 20);
            this.txtSrcDB.TabIndex = 0;
            this.txtSrcDB.Text = "4651";
            this.txtSrcDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSrcDB.TextChanged += new System.EventHandler(this.txtSrcDB_TextChanged);
            // 
            // txtTargetDB
            // 
            this.txtTargetDB.Location = new System.Drawing.Point(584, 31);
            this.txtTargetDB.Name = "txtTargetDB";
            this.txtTargetDB.Size = new System.Drawing.Size(162, 20);
            this.txtTargetDB.TabIndex = 1;
            this.txtTargetDB.Text = "zomorod722-1";
            this.txtTargetDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetDB.TextChanged += new System.EventHandler(this.txtTargetDB_TextChanged);
            // 
            // linkMain
            // 
            this.linkMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkMain.AutoSize = true;
            this.linkMain.Location = new System.Drawing.Point(413, 483);
            this.linkMain.Name = "linkMain";
            this.linkMain.Size = new System.Drawing.Size(67, 13);
            this.linkMain.TabIndex = 5;
            this.linkMain.TabStop = true;
            this.linkMain.Text = "AliJenadeleh";
            this.linkMain.Click += new System.EventHandler(this.linkMain_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressMain,
            this.lblFail,
            this.lblSuccess,
            this.lblVersion});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(775, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // progressMain
            // 
            this.progressMain.Margin = new System.Windows.Forms.Padding(62, 3, 1, 3);
            this.progressMain.Name = "progressMain";
            this.progressMain.Size = new System.Drawing.Size(100, 16);
            // 
            // lblFail
            // 
            this.lblFail.ForeColor = System.Drawing.Color.Red;
            this.lblFail.Name = "lblFail";
            this.lblFail.Size = new System.Drawing.Size(40, 17);
            this.lblFail.Text = "Fail : 0";
            // 
            // lblSuccess
            // 
            this.lblSuccess.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.lblSuccess.Name = "lblSuccess";
            this.lblSuccess.Size = new System.Drawing.Size(63, 17);
            this.lblSuccess.Text = "Success : 0";
            // 
            // lblVersion
            // 
            this.lblVersion.ForeColor = System.Drawing.Color.Olive;
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(69, 17);
            this.lblVersion.Text = "Version : 0.1";
            // 
            // txtServerSrc
            // 
            this.txtServerSrc.Location = new System.Drawing.Point(408, 5);
            this.txtServerSrc.Name = "txtServerSrc";
            this.txtServerSrc.Size = new System.Drawing.Size(151, 20);
            this.txtServerSrc.TabIndex = 7;
            this.txtServerSrc.Text = "ZOMOROD";
            this.txtServerSrc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServerSrc.TextChanged += new System.EventHandler(this.txtServerSrc_TextChanged);
            // 
            // txtServerTarget
            // 
            this.txtServerTarget.Location = new System.Drawing.Point(408, 31);
            this.txtServerTarget.Name = "txtServerTarget";
            this.txtServerTarget.Size = new System.Drawing.Size(151, 20);
            this.txtServerTarget.TabIndex = 8;
            this.txtServerTarget.Text = "ZOMOROD";
            this.txtServerTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtServerTarget.TextChanged += new System.EventHandler(this.txtServerTarget_TextChanged);
            // 
            // button2
            // 
            this.button2.BackgroundImage = global::SQLCloneToGo.Properties.Resources._015_check;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(560, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 22);
            this.button2.TabIndex = 11;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.BackgroundImage = global::SQLCloneToGo.Properties.Resources._015_check;
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(559, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(21, 22);
            this.button1.TabIndex = 10;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackgroundImage = global::SQLCloneToGo.Properties.Resources._015_check;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(748, 4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(21, 22);
            this.button3.TabIndex = 12;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackgroundImage = global::SQLCloneToGo.Properties.Resources._015_check;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(748, 30);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(21, 22);
            this.button4.TabIndex = 13;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // chkVerbose
            // 
            this.chkVerbose.AutoSize = true;
            this.chkVerbose.Location = new System.Drawing.Point(62, 60);
            this.chkVerbose.Name = "chkVerbose";
            this.chkVerbose.Size = new System.Drawing.Size(65, 17);
            this.chkVerbose.TabIndex = 14;
            this.chkVerbose.Text = "Verbose";
            this.chkVerbose.UseVisualStyleBackColor = true;
            // 
            // chkLastVersion
            // 
            this.chkLastVersion.AutoSize = true;
            this.chkLastVersion.Location = new System.Drawing.Point(148, 60);
            this.chkLastVersion.Name = "chkLastVersion";
            this.chkLastVersion.Size = new System.Drawing.Size(117, 17);
            this.chkLastVersion.TabIndex = 15;
            this.chkLastVersion.Text = "Set DB Lastversion";
            this.chkLastVersion.UseVisualStyleBackColor = true;
            this.chkLastVersion.CheckedChanged += new System.EventHandler(this.chkLastVersion_CheckedChanged);
            // 
            // txtDbVersion
            // 
            this.txtDbVersion.Enabled = false;
            this.txtDbVersion.Location = new System.Drawing.Point(265, 59);
            this.txtDbVersion.Name = "txtDbVersion";
            this.txtDbVersion.Size = new System.Drawing.Size(91, 20);
            this.txtDbVersion.TabIndex = 16;
            this.txtDbVersion.Text = "7.22";
            this.txtDbVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDbVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDbVersion_KeyPress);
            // 
            // frmClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(775, 499);
            this.Controls.Add(this.txtDbVersion);
            this.Controls.Add(this.chkLastVersion);
            this.Controls.Add(this.chkVerbose);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtServerTarget);
            this.Controls.Add(this.txtServerSrc);
            this.Controls.Add(this.linkMain);
            this.Controls.Add(this.txtTargetDB);
            this.Controls.Add(this.txtSrcDB);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.listOutput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmClone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Clone to Go";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClone_FormClosing);
            this.Load += new System.EventHandler(this.frmClone_Load);
            this.panel1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox listOutput;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.TextBox txtSrcDB;
        private System.Windows.Forms.TextBox txtTargetDB;
        private System.Windows.Forms.LinkLabel linkMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressMain;
        private System.Windows.Forms.ToolStripStatusLabel lblFail;
        private System.Windows.Forms.ToolStripStatusLabel lblSuccess;
        private System.Windows.Forms.TextBox txtServerSrc;
        private System.Windows.Forms.TextBox txtServerTarget;
        private System.Windows.Forms.ToolStripStatusLabel lblVersion;
        private System.Windows.Forms.Button btnBackup;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox chkVerbose;
        private System.Windows.Forms.CheckBox chkLastVersion;
        private System.Windows.Forms.TextBox txtDbVersion;
    }
}

