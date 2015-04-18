using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataModelApplication
{
    public partial class CustomConditionConfigForm : Form
    {
        private DataTable dsCustomConditionConfig = new DataTable();
        public DataTable CustomConditionConfig
        {
            set 
            {
                dsCustomConditionConfig = value;
            }
            get
            {
                return dsCustomConditionConfig;
            }
            
        }

        private object[] objTemplateDir;
        public object[] TemplateDir
        {
            set
            {
                objTemplateDir = value;
            }
            get
            {
                return objTemplateDir;
            }

        }

        private object[] objFieldName;
        public object[] FieldName
        {
            set
            {
                objFieldName = value;
            }
            get
            {
                return objFieldName;
            }

        }

        private bool boolSaveFlag = false;
        public bool SaveFlag
        {
            set
            {
                boolSaveFlag = value;
            }
            get
            {
                return boolSaveFlag;
            }
        }
        public CustomConditionConfigForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveFlag = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFlag = true;
            CustomConditionConfig = new DataTable();
            foreach (DataGridViewColumn dgvcTemp in dgvCustomConditionConfig.Columns)
            {
                if (dgvcTemp.ValueType == null)
                {
                    CustomConditionConfig.Columns.Add(dgvcTemp.Name);
                }
                else
                {
                    CustomConditionConfig.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                }
            }
            foreach (DataGridViewRow dgvrTemp in dgvCustomConditionConfig.Rows)
            {
                DataRow drTemp = CustomConditionConfig.NewRow();
                foreach (DataGridViewCell dgvcTemp in dgvrTemp.Cells)
                {
                    if (dgvcTemp.Value == null)
                    {
                        drTemp[dgvcTemp.ColumnIndex] = DBNull.Value;
                    }
                    else
                    {
                        drTemp[dgvcTemp.ColumnIndex] = dgvcTemp.Value;
                    }
                }
                CustomConditionConfig.Rows.Add(drTemp);
            }
            this.Close();
        }

        private void CustomConditionConfigForm_Load(object sender, EventArgs e)
        {
            dgvCustomConditionConfig.AutoGenerateColumns = false;
            dgvCustomConditionConfig.DataSource = dsCustomConditionConfig;
            dgvCustomConditionConfig.Columns["CustomConditionTemplate"].DataPropertyName = "CustomConditionTemplate";
            dgvCustomConditionConfig.Columns["CustomConditionType"].DataPropertyName = "CustomConditionType";
            dgvCustomConditionConfig.Columns["CustomConditionFieldName"].DataPropertyName = "CustomConditionFieldName";
            dgvCustomConditionConfig.Columns["CustomConditionValue"].DataPropertyName = "CustomConditionValue";

            CustomConditionTemplate.Items.AddRange(TemplateDir);
            CustomConditionType.Items.AddRange(new object[] { "View", "List", "Add", "Lock", "Modify", "Delete", "Hidden" });
            // CustomConditionFieldName.Items.AddRange(FieldName);
        }
    }
}