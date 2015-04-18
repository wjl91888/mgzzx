namespace DataModelApplication
{
    partial class CustomRelatedTableConfigForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvCustomRelatedTableConfig = new System.Windows.Forms.DataGridView();
            this.SerialNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedTableType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelatedTableOwner = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RelatedTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TableWithField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.RelatedTableWithField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsDataBind = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Sort = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SortField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsLeftButtonMenu = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAddBatch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsAddBatchTemplate = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.AddBatchTemplateTableName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MainTemplateField = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.TemplateMainField = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsShowPDFRelatedTableRemark = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsShowPDFSeparateLine = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.RelatedTableDisplayField = new System.Windows.Forms.DataGridViewButtonColumn();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomRelatedTableConfig)).BeginInit();
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
            this.splitContainer1.Panel1.Controls.Add(this.dgvCustomRelatedTableConfig);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClose);
            this.splitContainer1.Panel2.Controls.Add(this.btnSave);
            this.splitContainer1.Size = new System.Drawing.Size(826, 372);
            this.splitContainer1.SplitterDistance = 318;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvCustomRelatedTableConfig
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomRelatedTableConfig.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCustomRelatedTableConfig.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomRelatedTableConfig.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SerialNumber,
            this.RelatedInfoName,
            this.RelatedTableType,
            this.RelatedTableOwner,
            this.RelatedTableName,
            this.TableWithField,
            this.RelatedTableWithField,
            this.IsDataBind,
            this.Sort,
            this.SortField,
            this.IsLeftButtonMenu,
            this.IsAddBatch,
            this.IsAddBatchTemplate,
            this.AddBatchTemplateTableName,
            this.MainTemplateField,
            this.TemplateMainField,
            this.IsShowPDFRelatedTableRemark,
            this.IsShowPDFSeparateLine,
            this.RelatedTableDisplayField});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvCustomRelatedTableConfig.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvCustomRelatedTableConfig.Location = new System.Drawing.Point(3, 3);
            this.dgvCustomRelatedTableConfig.Name = "dgvCustomRelatedTableConfig";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("SimSun", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCustomRelatedTableConfig.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvCustomRelatedTableConfig.RowTemplate.Height = 23;
            this.dgvCustomRelatedTableConfig.Size = new System.Drawing.Size(815, 304);
            this.dgvCustomRelatedTableConfig.TabIndex = 1;
            this.dgvCustomRelatedTableConfig.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomRelatedTableConfig_CellClick);
            // 
            // SerialNumber
            // 
            this.SerialNumber.HeaderText = "序号";
            this.SerialNumber.Name = "SerialNumber";
            this.SerialNumber.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SerialNumber.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.SerialNumber.Width = 40;
            // 
            // RelatedInfoName
            // 
            this.RelatedInfoName.HeaderText = "相关信息名称";
            this.RelatedInfoName.Name = "RelatedInfoName";
            this.RelatedInfoName.Width = 110;
            // 
            // RelatedTableType
            // 
            this.RelatedTableType.HeaderText = "类型";
            this.RelatedTableType.Name = "RelatedTableType";
            this.RelatedTableType.Width = 80;
            // 
            // RelatedTableOwner
            // 
            this.RelatedTableOwner.HeaderText = "相关表Owner";
            this.RelatedTableOwner.Name = "RelatedTableOwner";
            // 
            // RelatedTableName
            // 
            this.RelatedTableName.HeaderText = "相关表名称";
            this.RelatedTableName.Name = "RelatedTableName";
            // 
            // TableWithField
            // 
            this.TableWithField.HeaderText = "主表关联字段";
            this.TableWithField.Name = "TableWithField";
            this.TableWithField.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TableWithField.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.TableWithField.Width = 110;
            // 
            // RelatedTableWithField
            // 
            this.RelatedTableWithField.HeaderText = "对应字段";
            this.RelatedTableWithField.Name = "RelatedTableWithField";
            // 
            // IsDataBind
            // 
            this.IsDataBind.HeaderText = "已绑定";
            this.IsDataBind.Name = "IsDataBind";
            this.IsDataBind.Width = 50;
            // 
            // Sort
            // 
            this.Sort.HeaderText = "升序";
            this.Sort.Name = "Sort";
            this.Sort.Width = 60;
            // 
            // SortField
            // 
            this.SortField.HeaderText = "排序字段";
            this.SortField.Name = "SortField";
            this.SortField.Width = 80;
            // 
            // IsLeftButtonMenu
            // 
            this.IsLeftButtonMenu.HeaderText = "右键菜单";
            this.IsLeftButtonMenu.Name = "IsLeftButtonMenu";
            this.IsLeftButtonMenu.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsLeftButtonMenu.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // IsAddBatch
            // 
            this.IsAddBatch.HeaderText = "批量添加";
            this.IsAddBatch.Name = "IsAddBatch";
            // 
            // IsAddBatchTemplate
            // 
            this.IsAddBatchTemplate.HeaderText = "使用添加模板";
            this.IsAddBatchTemplate.Name = "IsAddBatchTemplate";
            this.IsAddBatchTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsAddBatchTemplate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // AddBatchTemplateTableName
            // 
            this.AddBatchTemplateTableName.HeaderText = "添加模板表名";
            this.AddBatchTemplateTableName.Name = "AddBatchTemplateTableName";
            // 
            // MainTemplateField
            // 
            this.MainTemplateField.HeaderText = "主模关联字段";
            this.MainTemplateField.Name = "MainTemplateField";
            // 
            // TemplateMainField
            // 
            this.TemplateMainField.HeaderText = "模主对应字段";
            this.TemplateMainField.Name = "TemplateMainField";
            // 
            // IsShowPDFRelatedTableRemark
            // 
            this.IsShowPDFRelatedTableRemark.HeaderText = "PDF显示表说明";
            this.IsShowPDFRelatedTableRemark.Name = "IsShowPDFRelatedTableRemark";
            // 
            // IsShowPDFSeparateLine
            // 
            this.IsShowPDFSeparateLine.HeaderText = "显示分割线";
            this.IsShowPDFSeparateLine.Name = "IsShowPDFSeparateLine";
            // 
            // RelatedTableDisplayField
            // 
            this.RelatedTableDisplayField.HeaderText = "显示字段";
            this.RelatedTableDisplayField.Name = "RelatedTableDisplayField";
            this.RelatedTableDisplayField.Text = "设置";
            this.RelatedTableDisplayField.Width = 80;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(426, 11);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 25);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(271, 11);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CustomRelatedTableConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 372);
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CustomRelatedTableConfigForm";
            this.Text = "配置自定义相关表";
            this.Load += new System.EventHandler(this.CustomRelatedTableConfigForm_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomRelatedTableConfig)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DataGridView dgvCustomRelatedTableConfig;
        private System.Windows.Forms.DataGridViewTextBoxColumn SerialNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedInfoName;
        private System.Windows.Forms.DataGridViewComboBoxColumn RelatedTableType;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTableOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTableName;
        private System.Windows.Forms.DataGridViewComboBoxColumn TableWithField;
        private System.Windows.Forms.DataGridViewTextBoxColumn RelatedTableWithField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsDataBind;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Sort;
        private System.Windows.Forms.DataGridViewTextBoxColumn SortField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsLeftButtonMenu;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddBatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsAddBatchTemplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn AddBatchTemplateTableName;
        private System.Windows.Forms.DataGridViewComboBoxColumn MainTemplateField;
        private System.Windows.Forms.DataGridViewTextBoxColumn TemplateMainField;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsShowPDFRelatedTableRemark;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsShowPDFSeparateLine;
        private System.Windows.Forms.DataGridViewButtonColumn RelatedTableDisplayField;

    }
}