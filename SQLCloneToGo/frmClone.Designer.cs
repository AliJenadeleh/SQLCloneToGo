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
            this.btnGo = new System.Windows.Forms.Button();
            this.txtSrcDB = new System.Windows.Forms.TextBox();
            this.txtTargetDB = new System.Windows.Forms.TextBox();
            this.linkMain = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel1.SuspendLayout();
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
            this.txtSource.Size = new System.Drawing.Size(524, 20);
            this.txtSource.TabIndex = 2;
            this.txtSource.Text = "Data Source=.\\ZOMOROD;Initial Catalog=zomorod722-1;Integrated Security=True;";
            this.txtSource.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtTarget
            // 
            this.txtTarget.Location = new System.Drawing.Point(62, 31);
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.ReadOnly = true;
            this.txtTarget.Size = new System.Drawing.Size(524, 20);
            this.txtTarget.TabIndex = 3;
            this.txtTarget.Text = "Data Source=.\\ZOMOROD;Initial Catalog=zomorod722-1;Integrated Security=True;";
            this.txtTarget.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 57);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Output :";
            // 
            // listOutput
            // 
            this.listOutput.FormattingEnabled = true;
            this.listOutput.Location = new System.Drawing.Point(62, 57);
            this.listOutput.Name = "listOutput";
            this.listOutput.Size = new System.Drawing.Size(708, 329);
            this.listOutput.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.btnGo);
            this.panel1.Location = new System.Drawing.Point(56, 392);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(725, 78);
            this.panel1.TabIndex = 3;
            // 
            // btnClose
            // 
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
            this.btnClear.Location = new System.Drawing.Point(461, 3);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(117, 72);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Cle&ar";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnGo
            // 
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
            this.txtSrcDB.Location = new System.Drawing.Point(592, 5);
            this.txtSrcDB.Name = "txtSrcDB";
            this.txtSrcDB.Size = new System.Drawing.Size(178, 20);
            this.txtSrcDB.TabIndex = 0;
            this.txtSrcDB.Text = "4651";
            this.txtSrcDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSrcDB.TextChanged += new System.EventHandler(this.txtSrcDB_TextChanged);
            // 
            // txtTargetDB
            // 
            this.txtTargetDB.Location = new System.Drawing.Point(592, 31);
            this.txtTargetDB.Name = "txtTargetDB";
            this.txtTargetDB.Size = new System.Drawing.Size(178, 20);
            this.txtTargetDB.TabIndex = 1;
            this.txtTargetDB.Text = "zomorod722-1";
            this.txtTargetDB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTargetDB.TextChanged += new System.EventHandler(this.txtTargetDB_TextChanged);
            // 
            // linkMain
            // 
            this.linkMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.linkMain.AutoSize = true;
            this.linkMain.Location = new System.Drawing.Point(3, 482);
            this.linkMain.Name = "linkMain";
            this.linkMain.Size = new System.Drawing.Size(67, 13);
            this.linkMain.TabIndex = 5;
            this.linkMain.TabStop = true;
            this.linkMain.Text = "AliJenadeleh";
            this.linkMain.Click += new System.EventHandler(this.linkMain_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(775, 22);
            this.statusStrip1.TabIndex = 6;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // frmClone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 499);
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
            this.MinimizeBox = false;
            this.Name = "frmClone";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SQL Clone to Go";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmClone_FormClosing);
            this.Load += new System.EventHandler(this.frmClone_Load);
            this.panel1.ResumeLayout(false);
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
    }
}

