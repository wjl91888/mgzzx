namespace DataModelApplication
{
    partial class CustomConditionConfigForm
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
            this.dgvCustomConditionConfig = new System.Windows.Forms.DataGridView();
            this.CustomConditionTemplate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomConditionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomConditionFieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomConditionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomConditionConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 7);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomConditionConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(602, 224);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvCustomConditionConfig
            // 
            this.dgvCustomConditionConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomConditionConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomConditionTemplate,
            this.CustomConditionType,
            this.CustomConditionFieldName,
            this.CustomConditionValue});
            this.dgvCustomConditionConfig.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomConditionConfig.Name = "dgvCustomConditionConfig";
            this.dgvCustomConditionConfig.RowTemplate.Height = 23;
            this.dgvCustomConditionConfig.Size = new System.Drawing.Size(595, 165);
            this.dgvCustomConditionConfig.TabIndex = 1;
            // 
            // CustomConditionTemplate
            // 
            this.CustomConditionTemplate.HeaderText = "使用模版文件";
            this.CustomConditionTemplate.Name = "CustomConditionTemplate";
            this.CustomConditionTemplate.Width = 200;
            // 
            // CustomConditionType
            // 
            this.CustomConditionType.HeaderText = "条件类型";
            this.CustomConditionType.Name = "CustomConditionType";
            // 
            // CustomConditionFieldName
            // 
            this.CustomConditionFieldName.HeaderText = "条件字段";
            this.CustomConditionFieldName.Name = "CustomConditionFieldName";
            this.CustomConditionFieldName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // CustomConditionValue
            // 
            this.CustomConditionValue.HeaderText = "条件值";
            this.CustomConditionValue.Name = "CustomConditionValue";
            this.CustomConditionValue.Width = 150;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(341, 12);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(170, 12);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomConditionConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 234);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomConditionConfigForm";
            this.Text = "配置自定义条件";
            this.Load += new System.EventHandler(this.CustomConditionConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomConditionConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCustomConditionConfig;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomConditionTemplate;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomConditionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomConditionFieldName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomConditionValue;

    }
}