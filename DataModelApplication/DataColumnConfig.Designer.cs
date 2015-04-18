namespace DataModelApplication
{
    partial class DataColumnConfig
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
            System.Windows.Forms.DataGridView dataGridView1;
            this.btnSaveDataColumn = new System.Windows.Forms.Button();
            this.btnResetDataColumn = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnControlType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnContent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFormatString = new System.Windows.Forms.DataGridViewTextBoxColumn();
            dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnType,
            this.ColumnControlType,
            this.ColumnContent,
            this.ColumnFormatString});
            dataGridView1.Location = new System.Drawing.Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 23;
            dataGridView1.Size = new System.Drawing.Size(563, 269);
            dataGridView1.TabIndex = 0;
            // 
            // btnSaveDataColumn
            // 
            this.btnSaveDataColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveDataColumn.Location = new System.Drawing.Point(419, 287);
            this.btnSaveDataColumn.Name = "btnSaveDataColumn";
            this.btnSaveDataColumn.Size = new System.Drawing.Size(75, 23);
            this.btnSaveDataColumn.TabIndex = 1;
            this.btnSaveDataColumn.Text = "保存配置";
            this.btnSaveDataColumn.UseVisualStyleBackColor = true;
            // 
            // btnResetDataColumn
            // 
            this.btnResetDataColumn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetDataColumn.Location = new System.Drawing.Point(500, 287);
            this.btnResetDataColumn.Name = "btnResetDataColumn";
            this.btnResetDataColumn.Size = new System.Drawing.Size(75, 23);
            this.btnResetDataColumn.TabIndex = 2;
            this.btnResetDataColumn.Text = "重置";
            this.btnResetDataColumn.UseVisualStyleBackColor = true;
            // 
            // ColumnName
            // 
            this.ColumnName.HeaderText = "列名称";
            this.ColumnName.Name = "ColumnName";
            // 
            // ColumnType
            // 
            this.ColumnType.HeaderText = "列类型";
            this.ColumnType.Name = "ColumnType";
            // 
            // ColumnControlType
            // 
            this.ColumnControlType.HeaderText = "列控件类型";
            this.ColumnControlType.Name = "ColumnControlType";
            // 
            // ColumnContent
            // 
            this.ColumnContent.HeaderText = "列内容";
            this.ColumnContent.Name = "ColumnContent";
            // 
            // ColumnFormatString
            // 
            this.ColumnFormatString.HeaderText = "格式化字符串";
            this.ColumnFormatString.Name = "ColumnFormatString";
            this.ColumnFormatString.Width = 120;
            // 
            // DataColumnConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(587, 319);
            this.Controls.Add(this.btnResetDataColumn);
            this.Controls.Add(this.btnSaveDataColumn);
            this.Controls.Add(dataGridView1);
            this.Name = "DataColumnConfig";
            this.Text = "DataColumnConfig";
            ((System.ComponentModel.ISupportInitialize)(dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSaveDataColumn;
        private System.Windows.Forms.Button btnResetDataColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnControlType;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnContent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFormatString;
    }
}