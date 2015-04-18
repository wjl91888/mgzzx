namespace DataModelApplication
{
    partial class CustomPermissionFieldsConfigForm
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
            this.dgvCustomDisplayFieldConfig = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.CustomPermissionTemplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPermissionType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPermissionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPermissionName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomPermissionRemark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FieldName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hidden = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.View = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.NoSearch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Condition = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ConditionValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomDisplayFieldConfig)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomDisplayFieldConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(600, 392);
            this.splitContainer1.SplitterDistance = 345;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvCustomDisplayFieldConfig
            // 
            this.dgvCustomDisplayFieldConfig.AllowUserToAddRows = false;
            this.dgvCustomDisplayFieldConfig.AllowUserToDeleteRows = false;
            this.dgvCustomDisplayFieldConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomDisplayFieldConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CustomPermissionTemplate,
            this.CustomPermissionType,
            this.CustomPermissionID,
            this.CustomPermissionName,
            this.CustomPermissionRemark,
            this.FieldName,
            this.Hidden,
            this.View,
            this.NoSearch,
            this.Condition,
            this.ConditionValue});
            this.dgvCustomDisplayFieldConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomDisplayFieldConfig.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomDisplayFieldConfig.Name = "dgvCustomDisplayFieldConfig";
            this.dgvCustomDisplayFieldConfig.RowTemplate.Height = 23;
            this.dgvCustomDisplayFieldConfig.Size = new System.Drawing.Size(600, 345);
            this.dgvCustomDisplayFieldConfig.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(365, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(226, 9);
            this.btnSave.Name = "btnSave";
            this.btnSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomPermissionTemplate
            // 
            this.CustomPermissionTemplate.Frozen = true;
            this.CustomPermissionTemplate.HeaderText = "Column1";
            this.CustomPermissionTemplate.Name = "CustomPermissionTemplate";
            this.CustomPermissionTemplate.Visible = false;
            // 
            // CustomPermissionType
            // 
            this.CustomPermissionType.Frozen = true;
            this.CustomPermissionType.HeaderText = "Column1";
            this.CustomPermissionType.Name = "CustomPermissionType";
            this.CustomPermissionType.Visible = false;
            // 
            // CustomPermissionID
            // 
            this.CustomPermissionID.Frozen = true;
            this.CustomPermissionID.HeaderText = "Column1";
            this.CustomPermissionID.Name = "CustomPermissionID";
            this.CustomPermissionID.Visible = false;
            // 
            // CustomPermissionName
            // 
            this.CustomPermissionName.Frozen = true;
            this.CustomPermissionName.HeaderText = "Column1";
            this.CustomPermissionName.Name = "CustomPermissionName";
            this.CustomPermissionName.Visible = false;
            // 
            // CustomPermissionRemark
            // 
            this.CustomPermissionRemark.Frozen = true;
            this.CustomPermissionRemark.HeaderText = "Column1";
            this.CustomPermissionRemark.Name = "CustomPermissionRemark";
            this.CustomPermissionRemark.Visible = false;
            // 
            // FieldName
            // 
            this.FieldName.Frozen = true;
            this.FieldName.HeaderText = "字段名称";
            this.FieldName.Name = "FieldName";
            this.FieldName.ReadOnly = true;
            this.FieldName.Width = 150;
            // 
            // Hidden
            // 
            this.Hidden.Frozen = true;
            this.Hidden.HeaderText = "隐藏";
            this.Hidden.Name = "Hidden";
            this.Hidden.Width = 60;
            // 
            // View
            // 
            this.View.Frozen = true;
            this.View.HeaderText = "仅可见";
            this.View.Name = "View";
            this.View.Width = 60;
            // 
            // NoSearch
            // 
            this.NoSearch.Frozen = true;
            this.NoSearch.HeaderText = "不可查";
            this.NoSearch.Name = "NoSearch";
            this.NoSearch.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.NoSearch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.NoSearch.Width = 70;
            // 
            // Condition
            // 
            this.Condition.Frozen = true;
            this.Condition.HeaderText = "条件";
            this.Condition.Name = "Condition";
            this.Condition.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Condition.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Condition.Width = 60;
            // 
            // ConditionValue
            // 
            this.ConditionValue.Frozen = true;
            this.ConditionValue.HeaderText = "条件值";
            this.ConditionValue.Name = "ConditionValue";
            this.ConditionValue.Width = 120;
            // 
            // CustomPermissionFieldsConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 392);
            this.Controls.Add(this.splitContainer1);
            this.Name = "CustomPermissionFieldsConfigForm";
            this.Text = "CustomPermissionFieldsConfig";
            this.Load += new System.EventHandler(this.CustomPermissionFieldsConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomDisplayFieldConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvCustomDisplayFieldConfig;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionName;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomPermissionRemark;
        private System.Windows.Forms.DataGridViewTextBoxColumn FieldName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Hidden;
        private System.Windows.Forms.DataGridViewCheckBoxColumn View;
        private System.Windows.Forms.DataGridViewCheckBoxColumn NoSearch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Condition;
        private System.Windows.Forms.DataGridViewTextBoxColumn ConditionValue;
    }
}