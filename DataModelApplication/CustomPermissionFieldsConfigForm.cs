using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataModelApplication
{
    public partial class CustomPermissionFieldsConfigForm : Form
    {
        public DataTable CustomPermissionFieldsConfig { get; set; }

        public DataTable Fields { get; set; }

        public bool SaveFlag { get; set; }

        public CustomPermissionFieldsConfigForm()
        {
            SaveFlag = false;
            CustomPermissionFieldsConfig = new DataTable();
            InitializeComponent();
            this.Hidden.ValueType = System.Type.GetType("System.Boolean");
            this.View.ValueType = System.Type.GetType("System.Boolean");
            this.NoSearch.ValueType = System.Type.GetType("System.Boolean");
            this.Condition.ValueType = System.Type.GetType("System.Boolean");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveFlag = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFlag = true;
            CustomPermissionFieldsConfig = new DataTable();
            this.Hidden.ValueType = System.Type.GetType("System.Boolean");
            this.View.ValueType = System.Type.GetType("System.Boolean");
            this.NoSearch.ValueType = System.Type.GetType("System.Boolean");
            this.Condition.ValueType = System.Type.GetType("System.Boolean");
            foreach (DataGridViewColumn dgvcTemp in dgvCustomDisplayFieldConfig.Columns)
            {
                if (dgvcTemp.ValueType == null)
                {
                    CustomPermissionFieldsConfig.Columns.Add(dgvcTemp.Name);
                }
                else
                {
                    CustomPermissionFieldsConfig.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                }
            }
            foreach (DataGridViewRow dgvrTemp in dgvCustomDisplayFieldConfig.Rows)
            {
                DataRow drTemp = CustomPermissionFieldsConfig.NewRow();
                foreach (DataGridViewCell dgvcTemp in dgvrTemp.Cells)
                {
                    if (dgvcTemp.Value == null)
                    {
                        if (dgvcTemp.ValueType == System.Type.GetType("System.Boolean"))
                        {
                            drTemp[dgvcTemp.ColumnIndex] = "false";
                        }
                        else
                        {
                            drTemp[dgvcTemp.ColumnIndex] = DBNull.Value;
                        }
                    }
                    else
                    {
                        drTemp[dgvcTemp.ColumnIndex] = dgvcTemp.Value;
                    }
                }
                CustomPermissionFieldsConfig.Rows.Add(drTemp);
            }
            this.Close();
        }

        private void CustomPermissionFieldsConfigForm_Load(object sender, EventArgs e)
        {
            dgvCustomDisplayFieldConfig.AutoGenerateColumns = false;
            dgvCustomDisplayFieldConfig.DataSource = CustomPermissionFieldsConfig;
            dgvCustomDisplayFieldConfig.Columns["CustomPermissionTemplate"].DataPropertyName = "CustomPermissionTemplate";
            dgvCustomDisplayFieldConfig.Columns["CustomPermissionType"].DataPropertyName = "CustomPermissionType";
            dgvCustomDisplayFieldConfig.Columns["CustomPermissionID"].DataPropertyName = "CustomPermissionID";
            dgvCustomDisplayFieldConfig.Columns["CustomPermissionName"].DataPropertyName = "CustomPermissionName";
            dgvCustomDisplayFieldConfig.Columns["CustomPermissionRemark"].DataPropertyName = "CustomPermissionRemark";
            dgvCustomDisplayFieldConfig.Columns["FieldName"].DataPropertyName = "FieldName";
            dgvCustomDisplayFieldConfig.Columns["Hidden"].DataPropertyName = "Hidden";
            dgvCustomDisplayFieldConfig.Columns["View"].DataPropertyName = "View";
            dgvCustomDisplayFieldConfig.Columns["NoSearch"].DataPropertyName = "NoSearch";
            dgvCustomDisplayFieldConfig.Columns["Condition"].DataPropertyName = "Condition";
            dgvCustomDisplayFieldConfig.Columns["ConditionValue"].DataPropertyName = "ConditionValue";
        }
    }
}
