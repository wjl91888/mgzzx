namespace DataModelApplication
{
    partial class GenerateCodeForm
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
            this.lbTemplateList = new System.Windows.Forms.ListBox();
            this.gbTemplateList = new System.Windows.Forms.GroupBox();
            this.btnGenerateCode = new System.Windows.Forms.Button();
            this.btnSelectTemplateDir = new System.Windows.Forms.Button();
            this.txtCodeView = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnCopyToBoard = new System.Windows.Forms.Button();
            this.gbTableInfo = new System.Windows.Forms.GroupBox();
            this.lblCurrentTemplatePath = new System.Windows.Forms.Label();
            this.lblTableConfigFilePath = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gbTemplateList.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbTableInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbTemplateList
            // 
            this.lbTemplateList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbTemplateList.FormattingEnabled = true;
            this.lbTemplateList.ItemHeight = 12;
            this.lbTemplateList.Location = new System.Drawing.Point(9, 20);
            this.lbTemplateList.Name = "lbTemplateList";
            this.lbTemplateList.Size = new System.Drawing.Size(204, 184);
            this.lbTemplateList.TabIndex = 0;
            this.lbTemplateList.SelectedIndexChanged += new System.EventHandler(this.lbTemplateList_SelectedIndexChanged);
            // 
            // gbTemplateList
            // 
            this.gbTemplateList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.gbTemplateList.Controls.Add(this.btnGenerateCode);
            this.gbTemplateList.Controls.Add(this.btnSelectTemplateDir);
            this.gbTemplateList.Controls.Add(this.lbTemplateList);
            this.gbTemplateList.Location = new System.Drawing.Point(3, 76);
            this.gbTemplateList.Name = "gbTemplateList";
            this.gbTemplateList.Size = new System.Drawing.Size(222, 239);
            this.gbTemplateList.TabIndex = 1;
            this.gbTemplateList.TabStop = false;
            this.gbTemplateList.Text = "模版列表";
            // 
            // btnGenerateCode
            // 
            this.btnGenerateCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerateCode.Location = new System.Drawing.Point(138, 209);
            this.btnGenerateCode.Name = "btnGenerateCode";
            this.btnGenerateCode.Size = new System.Drawing.Size(75, 23);
            this.btnGenerateCode.TabIndex = 2;
            this.btnGenerateCode.Text = "生成代码";
            this.btnGenerateCode.UseVisualStyleBackColor = true;
            this.btnGenerateCode.Click += new System.EventHandler(this.btnGenerateCode_Click);
            // 
            // btnSelectTemplateDir
            // 
            this.btnSelectTemplateDir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectTemplateDir.Location = new System.Drawing.Point(56, 209);
            this.btnSelectTemplateDir.Name = "btnSelectTemplateDir";
            this.btnSelectTemplateDir.Size = new System.Drawing.Size(75, 23);
            this.btnSelectTemplateDir.TabIndex = 1;
            this.btnSelectTemplateDir.Text = "选择目录";
            this.btnSelectTemplateDir.UseVisualStyleBackColor = true;
            this.btnSelectTemplateDir.Click += new System.EventHandler(this.btnSelectTemplateDir_Click);
            // 
            // txtCodeView
            // 
            this.txtCodeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCodeView.Location = new System.Drawing.Point(6, 20);
            this.txtCodeView.Multiline = true;
            this.txtCodeView.Name = "txtCodeView";
            this.txtCodeView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtCodeView.Size = new System.Drawing.Size(316, 184);
            this.txtCodeView.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnCopyToBoard);
            this.groupBox2.Controls.Add(this.txtCodeView);
            this.groupBox2.Location = new System.Drawing.Point(231, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(328, 239);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "模版内容";
            // 
            // btnCopyToBoard
            // 
            this.btnCopyToBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopyToBoard.Location = new System.Drawing.Point(247, 209);
            this.btnCopyToBoard.Name = "btnCopyToBoard";
            this.btnCopyToBoard.Size = new System.Drawing.Size(75, 23);
            this.btnCopyToBoard.TabIndex = 3;
            this.btnCopyToBoard.Text = "到剪切板";
            this.btnCopyToBoard.UseVisualStyleBackColor = true;
            this.btnCopyToBoard.Click += new System.EventHandler(this.btnCopyToBoard_Click);
            // 
            // gbTableInfo
            // 
            this.gbTableInfo.Controls.Add(this.lblCurrentTemplatePath);
            this.gbTableInfo.Controls.Add(this.lblTableConfigFilePath);
            this.gbTableInfo.Controls.Add(this.label2);
            this.gbTableInfo.Controls.Add(this.label1);
            this.gbTableInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbTableInfo.Location = new System.Drawing.Point(3, 3);
            this.gbTableInfo.Name = "gbTableInfo";
            this.gbTableInfo.Size = new System.Drawing.Size(556, 67);
            this.gbTableInfo.TabIndex = 4;
            this.gbTableInfo.TabStop = false;
            this.gbTableInfo.Text = "数据源信息";
            this.gbTableInfo.Enter += new System.EventHandler(this.gbTableInfo_Enter);
            // 
            // lblCurrentTemplatePath
            // 
            this.lblCurrentTemplatePath.AutoSize = true;
            this.lblCurrentTemplatePath.Location = new System.Drawing.Point(119, 43);
            this.lblCurrentTemplatePath.Name = "lblCurrentTemplatePath";
            this.lblCurrentTemplatePath.Size = new System.Drawing.Size(41, 12);
            this.lblCurrentTemplatePath.TabIndex = 3;
            this.lblCurrentTemplatePath.Text = "label4";
            // 
            // lblTableConfigFilePath
            // 
            this.lblTableConfigFilePath.AutoSize = true;
            this.lblTableConfigFilePath.Location = new System.Drawing.Point(119, 20);
            this.lblTableConfigFilePath.Name = "lblTableConfigFilePath";
            this.lblTableConfigFilePath.Size = new System.Drawing.Size(41, 12);
            this.lblTableConfigFilePath.TabIndex = 2;
            this.lblTableConfigFilePath.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "当前模版路径：";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "数据配置文件路径：";
            // 
            // GenerateCodeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(562, 320);
            this.Controls.Add(this.gbTableInfo);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbTemplateList);
            this.Name = "GenerateCodeForm";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "GenerateCodeForm";
            this.Load += new System.EventHandler(this.GenerateCodeForm_Load);
            this.gbTemplateList.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbTableInfo.ResumeLayout(false);
            this.gbTableInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbTemplateList;
        private System.Windows.Forms.GroupBox gbTemplateList;
        private System.Windows.Forms.Button btnGenerateCode;
        private System.Windows.Forms.Button btnSelectTemplateDir;
        private System.Windows.Forms.TextBox txtCodeView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnCopyToBoard;
        private System.Windows.Forms.GroupBox gbTableInfo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCurrentTemplatePath;
        private System.Windows.Forms.Label lblTableConfigFilePath;
    }
}