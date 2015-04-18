namespace DataModelApplication
{
    partial class EditCustomProperty
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvCustomProperty = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbCustomProperty = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveCustomProperty = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomProperty)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvCustomProperty
            // 
            this.dgvCustomProperty.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCustomProperty.Location = new System.Drawing.Point(0, 0);
            this.dgvCustomProperty.Name = "dgvCustomProperty";
            this.dgvCustomProperty.RowTemplate.Height = 23;
            this.dgvCustomProperty.Size = new System.Drawing.Size(431, 308);
            this.dgvCustomProperty.TabIndex = 0;
            this.dgvCustomProperty.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCustomProperty_CellEndEdit);
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
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnCancel);
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveCustomProperty);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(594, 350);
            this.splitContainer1.SplitterDistance = 308;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.lbCustomProperty);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvCustomProperty);
            this.splitContainer2.Size = new System.Drawing.Size(594, 308);
            this.splitContainer2.SplitterDistance = 159;
            this.splitContainer2.TabIndex = 1;
            // 
            // lbCustomProperty
            // 
            this.lbCustomProperty.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbCustomProperty.FormattingEnabled = true;
            this.lbCustomProperty.ItemHeight = 12;
            this.lbCustomProperty.Location = new System.Drawing.Point(0, 0);
            this.lbCustomProperty.Name = "lbCustomProperty";
            this.lbCustomProperty.Size = new System.Drawing.Size(159, 304);
            this.lbCustomProperty.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(305, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(104, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSaveCustomProperty
            // 
            this.btnSaveCustomProperty.Location = new System.Drawing.Point(167, 7);
            this.btnSaveCustomProperty.Name = "btnSaveCustomProperty";
            this.btnSaveCustomProperty.Size = new System.Drawing.Size(104, 23);
            this.btnSaveCustomProperty.TabIndex = 0;
            this.btnSaveCustomProperty.Text = "保存";
            this.btnSaveCustomProperty.UseVisualStyleBackColor = true;
            this.btnSaveCustomProperty.Click += new System.EventHandler(this.btnSaveCustomProperty_Click);
            // 
            // EditCustomProperty
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 350);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "EditCustomProperty";
            this.Text = "编辑自定义属性文件";
            this.Load += new System.EventHandler(this.EditCustomProperty_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomProperty)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCustomProperty;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveCustomProperty;
        private System.Windows.Forms.ListBox lbCustomProperty;
    }
}