using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace DataModelApplication
{
    public partial class CustomPermissionConfigForm : Form
    {
        public CustomPermissionConfigForm()
        {
            SaveFlag = false;
            CustomPermissionConfig = new DataTable();
            TempCustomPermissionFieldConfig = new DataSet();
            InitializeComponent();
        }

        public DataSet TempCustomPermissionFieldConfig { get; set; }

        public DataTable CustomPermissionFieldConfig { get; set; }

        public DataTable CustomPermissionConfig { get; set; }

        public object[] TemplateDir { get; set; }

        public object[] FieldName { get; set; }

        public bool SaveFlag { get; set; }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveFlag = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFlag = true;
            CustomPermissionConfig = new DataTable();
            foreach (DataGridViewColumn dgvcTemp in dgvCustomPermissionConfig.Columns)
            {
                if (dgvcTemp.ValueType == null)
                {
                    CustomPermissionConfig.Columns.Add(dgvcTemp.Name);
                }
                else
                {
                    CustomPermissionConfig.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                }
            }
            foreach (DataGridViewRow dgvrTemp in dgvCustomPermissionConfig.Rows)
            {
                DataRow drTemp = CustomPermissionConfig.NewRow();
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
                CustomPermissionConfig.Rows.Add(drTemp);
            }
            // 处理权限字段基本信息
            Boolean boolAddColumns = false;
            foreach (DataTable dtRelatedTable in TempCustomPermissionFieldConfig.Tables)
            {
                if (boolAddColumns == false)
                {
                    boolAddColumns = true;
                    CustomPermissionFieldConfig = new DataTable();
                    foreach (DataColumn dcTemp in dtRelatedTable.Columns)
                    {
                        CustomPermissionFieldConfig.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
                    }
                }
                foreach (DataRow drRelatedTable in dtRelatedTable.Rows)
                {
                    DataRow drTemp = CustomPermissionFieldConfig.NewRow();
                    drTemp.ItemArray = drRelatedTable.ItemArray;
                    CustomPermissionFieldConfig.Rows.Add(drTemp);
                }
            }
            this.Close();
        }

        private void CustomPermissionConfigForm_Load(object sender, EventArgs e)
        {
            dgvCustomPermissionConfig.AutoGenerateColumns = false;
            dgvCustomPermissionConfig.DataSource = CustomPermissionConfig;
            dgvCustomPermissionConfig.Columns["CustomPermissionTemplate"].DataPropertyName = "CustomPermissionTemplate";
            dgvCustomPermissionConfig.Columns["CustomPermissionType"].DataPropertyName = "CustomPermissionType";
            dgvCustomPermissionConfig.Columns["CustomPermissionID"].DataPropertyName = "CustomPermissionID";
            dgvCustomPermissionConfig.Columns["CustomPermissionName"].DataPropertyName = "CustomPermissionName";
            dgvCustomPermissionConfig.Columns["CustomPermissionRemark"].DataPropertyName = "CustomPermissionRemark";

            CustomPermissionTemplate.Items.AddRange(TemplateDir);
            CustomPermissionType.Items.AddRange(new object[] { "SearchPage", "AddPage", "DetailPage", "StatisticPage" });

            // 处理传入的权限字段信息
            TempCustomPermissionFieldConfig = new DataSet();
            string strCustomPermissionName = "NoCustomPermissionName";
            foreach (DataRow drPermissionField in CustomPermissionFieldConfig.Rows)
            {
                DataRow drTemp;
                if (strCustomPermissionName == (string)drPermissionField["CustomPermissionName"])
                {
                    drTemp = TempCustomPermissionFieldConfig.Tables[strCustomPermissionName].NewRow();
                    drTemp.ItemArray = drPermissionField.ItemArray;
                    TempCustomPermissionFieldConfig.Tables[strCustomPermissionName].Rows.Add(drTemp);
                }
                else
                {
                    strCustomPermissionName = (string)drPermissionField["CustomPermissionName"];
                    TempCustomPermissionFieldConfig.Tables.Add(strCustomPermissionName);
                    foreach (DataColumn dcDisplayField in CustomPermissionFieldConfig.Columns)
                    {
                        TempCustomPermissionFieldConfig.Tables[strCustomPermissionName].Columns.Add(dcDisplayField.ColumnName, dcDisplayField.DataType);
                    }
                    drTemp = TempCustomPermissionFieldConfig.Tables[strCustomPermissionName].NewRow();
                    drTemp.ItemArray = drPermissionField.ItemArray;
                    TempCustomPermissionFieldConfig.Tables[strCustomPermissionName].Rows.Add(drTemp);
                }

            }

        }

        private void dgvCustomPermissionConfig_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                string strCustomPermissionTemplate = string.Empty;
                string strCustomPermissionType = string.Empty;
                string strCustomPermissionID = string.Empty;
                string strCustomPermissionName = string.Empty;
                string strCustomPermissionRemark = string.Empty;
                if (dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionName"].Value != DBNull.Value
                    || dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionType"].Value != DBNull.Value
                    || dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionID"].Value != DBNull.Value
                    || dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionName"].Value != DBNull.Value
                    || dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionRemark"].Value != DBNull.Value
                    )
                {
                    strCustomPermissionTemplate = (string)(dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionTemplate"].Value);
                    strCustomPermissionType = (string)(dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionType"].Value);
                    strCustomPermissionID = (string)(dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionID"].Value);
                    strCustomPermissionName = (string)(dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionName"].Value);
                    strCustomPermissionRemark = (string)(dgvCustomPermissionConfig.Rows[e.RowIndex].Cells["CustomPermissionRemark"].Value);
                    // 打开配置相关表显示字段窗口
                    if (dgvCustomPermissionConfig.Columns[e.ColumnIndex].Name == "HideFields")
                    {
                        // 创建自定义操作配置窗口
                        CustomPermissionFieldsConfigForm CustomPermissionFieldsConfigForm = new CustomPermissionFieldsConfigForm();
                        // 将自定义操作配置信息传入自定义操作配置窗口
                        if (TempCustomPermissionFieldConfig.Tables[strCustomPermissionName] == null)
                        {
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig = new DataTable();
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Columns.Add("CustomPermissionTemplate");
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Columns.Add("CustomPermissionType");
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Columns.Add("CustomPermissionID");
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Columns.Add("CustomPermissionName");
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Columns.Add("CustomPermissionRemark");
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Columns.Add("FieldName");
                            foreach (var fieldName in FieldName)
                            {
                                CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.Rows.Add(strCustomPermissionTemplate, strCustomPermissionType, strCustomPermissionID, strCustomPermissionName, strCustomPermissionRemark, fieldName);
                            }
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.TableName = strCustomPermissionName;
                        }
                        else
                        {
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig = TempCustomPermissionFieldConfig.Tables[strCustomPermissionName].Copy();
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.TableName = strCustomPermissionName;
                        }
                        // 打开自定义操作配置窗口
                        CustomPermissionFieldsConfigForm.ShowDialog(this);
                        if (CustomPermissionFieldsConfigForm.SaveFlag == true)
                        {
                            // 将自定义操作配置信息传出自定义操作配置窗口
                            if (TempCustomPermissionFieldConfig.Tables[strCustomPermissionName] != null)
                            {
                                TempCustomPermissionFieldConfig.Tables.Remove(strCustomPermissionName);
                            }
                            CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig.TableName = strCustomPermissionName;
                            TempCustomPermissionFieldConfig.Tables.Add(CustomPermissionFieldsConfigForm.CustomPermissionFieldsConfig);
                            // 将对应相关表的显示字段
                        }
                    }
                }
                else if (dgvCustomPermissionConfig.Columns[e.ColumnIndex].Name == "HideFields")
                {
                    MessageBox.Show("请将相关表基础信息填写完整。");
                }
            }
        }
    }
}
