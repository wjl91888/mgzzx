using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataModelApplication
{
    public partial class CustomOperateConfigForm : Form
    {
        private DataTable dsCustomOperateConfig = new DataTable();
        public DataTable CustomOperateConfig
        {
            set 
            {
                dsCustomOperateConfig = value;
            }
            get
            {
                return dsCustomOperateConfig;
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
        public CustomOperateConfigForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFlag = false;
                this.Close();
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFlag = true;
                CustomOperateConfig = new DataTable();
                foreach (DataGridViewColumn dgvcTemp in dgvCustomOperateConfig.Columns)
                {
                    if (dgvcTemp.ValueType == null)
                    {
                        CustomOperateConfig.Columns.Add(dgvcTemp.Name);
                    }
                    else
                    {
                        CustomOperateConfig.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                    }
                }
                foreach (DataGridViewRow dgvrTemp in dgvCustomOperateConfig.Rows)
                {
                    DataRow drTemp = CustomOperateConfig.NewRow();
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
                    CustomOperateConfig.Rows.Add(drTemp);
                }
                this.Close();

            }
            catch (Exception)
            {
                
                throw;
            }
        }

        private void CustomOperateConfigForm_Load(object sender, EventArgs e)
        {
            try
            {
                dgvCustomOperateConfig.AutoGenerateColumns = false;
                dgvCustomOperateConfig.DataSource = dsCustomOperateConfig;
                dgvCustomOperateConfig.Columns["CustomOperateName"].DataPropertyName = "CustomOperateName";
                dgvCustomOperateConfig.Columns["CustomOperateFile"].DataPropertyName = "CustomOperateFile";
                dgvCustomOperateConfig.Columns["CustomOperateParamOne"].DataPropertyName = "CustomOperateParamOne";
                dgvCustomOperateConfig.Columns["CustomOperateParamTwo"].DataPropertyName = "CustomOperateParamTwo";
                dgvCustomOperateConfig.Columns["CustomOperateParamThree"].DataPropertyName = "CustomOperateParamThree";

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}