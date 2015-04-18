namespace DataModelApplication
{
    partial class CustomPermissionConfigForm
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
            this.dgvCustomPermissionConfig = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.CustomPermissionTemplate = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomPermissionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.CustomPermissionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPermissionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPermissionRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HideFields = new System.Windows.Forms.DataGridViewButtonColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomPermissionConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(1, 1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomPermissionConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(634, 466);
            this.splitContainer1.SplitterDistance = 406;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvCustomPermissionConfig
            // 
            this.dgvCustomPermissionConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomPermissionConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomPermissionTemplate,
            this.CustomPermissionType,
            this.CustomPermissionID,
            this.CustomPermissionName,
            this.CustomPermissionRemark,
            this.HideFields});
            this.dgvCustomPermissionConfig.Location = new System.Drawing.Point(4, 5);
            this.dgvCustomPermissionConfig.Name = "dgvCustomPermissionConfig";
            this.dgvCustomPermissionConfig.RowTemplate.Height = 23;
            this.dgvCustomPermissionConfig.Size = new System.Drawing.Size(623, 398);
            this.dgvCustomPermissionConfig.TabIndex = 1;
            this.dgvCustomPermissionConfig.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomPermissionConfig_CellClick);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(344, 13);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(173, 13);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomPermissionTemplate
            // 
            this.CustomPermissionTemplate.HeaderText = "使用模版文件";
            this.CustomPermissionTemplate.Name = "CustomPermissionTemplate";
            this.CustomPermissionTemplate.Width = 180;
            // 
            // CustomPermissionType
            // 
            this.CustomPermissionType.HeaderText = "类型";
            this.CustomPermissionType.Name = "CustomPermissionType";
            // 
            // CustomPermissionID
            // 
            this.CustomPermissionID.HeaderText = "权限编号";
            this.CustomPermissionID.Name = "CustomPermissionID";
            this.CustomPermissionID.Width = 80;
            // 
            // CustomPermissionName
            // 
            this.CustomPermissionName.HeaderText = "权限名称";
            this.CustomPermissionName.Name = "CustomPermissionName";
            this.CustomPermissionName.Width = 80;
            // 
            // CustomPermissionRemark
            // 
            this.CustomPermissionRemark.HeaderText = "权限说明";
            this.CustomPermissionRemark.Name = "CustomPermissionRemark";
            this.CustomPermissionRemark.Width = 80;
            // 
            // HideFields
            // 
            this.HideFields.HeaderText = "设置列";
            this.HideFields.Name = "HideFields";
            this.HideFields.Width = 60;
            // 
            // CustomPermissionConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 470);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomPermissionConfigForm";
            this.Text = "CustomPermissionConfigForm";
            this.Load += new System.EventHandler(this.CustomPermissionConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomPermissionConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCustomPermissionConfig;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomPermissionTemplate;
        private System.Windows.Forms.DataGridViewComboBoxColumn CustomPermissionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionRemark;
        private System.Windows.Forms.DataGridViewButtonColumn HideFields;
    }
}