namespace DataModelApplication
{
    partial class CustomOperateConfigForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCustomOperateConfig = new System.Windows.Forms.DataGridView();
            this.CustomOperateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateParamOne = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateParamTwo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomOperateParamThree = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomOperateConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 6);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomOperateConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(602, 207);
            this.splitContainer1.SplitterDistance = 160;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvCustomOperateConfig
            // 
            this.dgvCustomOperateConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomOperateConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomOperateName,
            this.CustomOperateFile,
            this.CustomOperateParamOne,
            this.CustomOperateParamTwo,
            this.CustomOperateParamThree});
            this.dgvCustomOperateConfig.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomOperateConfig.Name = "dgvCustomOperateConfig";
            this.dgvCustomOperateConfig.RowTemplate.Height = 23;
            this.dgvCustomOperateConfig.Size = new System.Drawing.Size(595, 152);
            this.dgvCustomOperateConfig.TabIndex = 1;
            // 
            // CustomOperateName
            // 
            this.CustomOperateName.Frozen = true;
            this.CustomOperateName.HeaderText = "操作名称";
            this.CustomOperateName.Name = "CustomOperateName";
            // 
            // CustomOperateFile
            // 
            this.CustomOperateFile.HeaderText = "操作链接文件";
            this.CustomOperateFile.Name = "CustomOperateFile";
            this.CustomOperateFile.Width = 150;
            // 
            // CustomOperateParamOne
            // 
            this.CustomOperateParamOne.HeaderText = "传入参数一";
            this.CustomOperateParamOne.Name = "CustomOperateParamOne";
            // 
            // CustomOperateParamTwo
            // 
            this.CustomOperateParamTwo.HeaderText = "传入参数二";
            this.CustomOperateParamTwo.Name = "CustomOperateParamTwo";
            // 
            // CustomOperateParamThree
            // 
            this.CustomOperateParamThree.HeaderText = "传入参数三";
            this.CustomOperateParamThree.Name = "CustomOperateParamThree";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(341, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomOperateConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 216);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomOperateConfigForm";
            this.Text = "配置自定义操作";
            this.Load += new System.EventHandler(this.CustomOperateConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomOperateConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateParamOne;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateParamTwo;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomOperateParamThree;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCustomOperateConfig;

    }
}