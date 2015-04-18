namespace DataModelApplication
{
    partial class EditDataDict
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
            this.dgvDataDict = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.lbDataDict = new System.Windows.Forms.ListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveDataDict = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDict)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDataDict
            // 
            this.dgvDataDict.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataDict.Location = new System.Drawing.Point(0, 0);
            this.dgvDataDict.Name = "dgvDataDict";
            this.dgvDataDict.RowTemplate.Height = 23;
            this.dgvDataDict.Size = new System.Drawing.Size(424, 315);
            this.dgvDataDict.TabIndex = 0;
            this.dgvDataDict.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDataDict_CellEndEdit);
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
            this.splitContainer1.Panel2.Controls.Add(this.btnSaveDataDict);
            this.splitContainer1.Panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer1_Panel2_Paint);
            this.splitContainer1.Size = new System.Drawing.Size(584, 358);
            this.splitContainer1.SplitterDistance = 315;
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
            this.splitContainer2.Panel1.Controls.Add(this.lbDataDict);
            this.splitContainer2.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitContainer2_Panel1_Paint);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.dgvDataDict);
            this.splitContainer2.Size = new System.Drawing.Size(584, 315);
            this.splitContainer2.SplitterDistance = 156;
            this.splitContainer2.TabIndex = 1;
            // 
            // lbDataDict
            // 
            this.lbDataDict.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbDataDict.FormattingEnabled = true;
            this.lbDataDict.ItemHeight = 12;
            this.lbDataDict.Location = new System.Drawing.Point(0, 0);
            this.lbDataDict.Name = "lbDataDict";
            this.lbDataDict.Size = new System.Drawing.Size(156, 304);
            this.lbDataDict.TabIndex = 0;
            this.lbDataDict.SelectedIndexChanged += new System.EventHandler(this.lbDataDict_SelectedIndexChanged);
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
            // btnSaveDataDict
            // 
            this.btnSaveDataDict.Location = new System.Drawing.Point(167, 7);
            this.btnSaveDataDict.Name = "btnSaveDataDict";
            this.btnSaveDataDict.Size = new System.Drawing.Size(104, 23);
            this.btnSaveDataDict.TabIndex = 0;
            this.btnSaveDataDict.Text = "保存";
            this.btnSaveDataDict.UseVisualStyleBackColor = true;
            this.btnSaveDataDict.Click += new System.EventHandler(this.btnSaveDataDict_Click);
            // 
            // EditDataDict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 358);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "EditDataDict";
            this.Text = "编辑数据字典";
            this.Load += new System.EventHandler(this.EditDataDict_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDict)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataDict;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSaveDataDict;
        private System.Windows.Forms.ListBox lbDataDict;
    }
}