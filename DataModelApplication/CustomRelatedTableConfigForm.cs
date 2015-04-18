using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.Common;
using System.Data.SqlClient;
using System.Xml;
using System.Xml.Xsl;

namespace DataModelApplication
{
    public partial class CustomRelatedTableConfigForm : Form
    {
        public DataTable CustomRelatedTableConfig { get; set; }

        public DataSet TempCustomDisplayFieldConfig { get; set; }

        public DataTable CustomDisplayFieldConfig { get; set; }

        public object[] FieldName { get; set; }

        public string ConnectionString { get; set; }

        public bool SaveFlag { get; set; }

        public CustomRelatedTableConfigForm()
        {
            SaveFlag = false;
            CustomDisplayFieldConfig = new DataTable();
            TempCustomDisplayFieldConfig = new DataSet();
            CustomRelatedTableConfig = new DataTable();
            InitializeComponent();
            this.IsDataBind.ValueType = System.Type.GetType("System.Boolean");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            SaveFlag = false;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFlag = true;
            // 保存
            // 处理相关表基本信息
            CustomRelatedTableConfig = new DataTable();
            this.IsDataBind.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatch.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddBatchTemplate.ValueType = System.Type.GetType("System.Boolean");
            this.IsLeftButtonMenu.ValueType = System.Type.GetType("System.Boolean");
            this.IsShowPDFRelatedTableRemark.ValueType = System.Type.GetType("System.Boolean");
            this.IsShowPDFSeparateLine.ValueType = System.Type.GetType("System.Boolean");
            this.Sort.ValueType = System.Type.GetType("System.Boolean");
            foreach (DataGridViewColumn dgvcTemp in dgvCustomRelatedTableConfig.Columns)
            {
                if (dgvcTemp.ValueType == null)
                {
                    CustomRelatedTableConfig.Columns.Add(dgvcTemp.Name);
                }
                else
                {
                    CustomRelatedTableConfig.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                }
            }

            foreach (DataGridViewRow dgvrTemp in dgvCustomRelatedTableConfig.Rows)
            {
                DataRow drTemp = CustomRelatedTableConfig.NewRow();
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
                CustomRelatedTableConfig.Rows.Add(drTemp);
            }
            // 处理相关表显示字段基本信息
            Boolean boolAddColumns = false;
            foreach (DataTable dtRelatedTable in TempCustomDisplayFieldConfig.Tables)
            {
                if (boolAddColumns == false)
                {
                    boolAddColumns = true;
                    CustomDisplayFieldConfig = new DataTable();
                    foreach (DataColumn dcTemp in dtRelatedTable.Columns)
                    {
                        CustomDisplayFieldConfig.Columns.Add(dcTemp.ColumnName, dcTemp.DataType);
                    }
                }
                foreach (DataRow drRelatedTable in dtRelatedTable.Rows)
                {
                    DataRow drTemp = CustomDisplayFieldConfig.NewRow();
                    drTemp.ItemArray = drRelatedTable.ItemArray;
                    CustomDisplayFieldConfig.Rows.Add(drTemp);
                }
            }
            this.Close();
        }

        private void CustomRelatedTableConfigForm_Load(object sender, EventArgs e)
        {
            dgvCustomRelatedTableConfig.AutoGenerateColumns = false;
            dgvCustomRelatedTableConfig.DataSource = CustomRelatedTableConfig;
            dgvCustomRelatedTableConfig.Columns["SerialNumber"].DataPropertyName = "SerialNumber";
            dgvCustomRelatedTableConfig.Columns["RelatedInfoName"].DataPropertyName = "RelatedInfoName";
            dgvCustomRelatedTableConfig.Columns["RelatedTableType"].DataPropertyName = "RelatedTableType";
            dgvCustomRelatedTableConfig.Columns["RelatedTableOwner"].DataPropertyName = "RelatedTableOwner";
            dgvCustomRelatedTableConfig.Columns["RelatedTableName"].DataPropertyName = "RelatedTableName";
            dgvCustomRelatedTableConfig.Columns["TableWithField"].DataPropertyName = "TableWithField";
            dgvCustomRelatedTableConfig.Columns["RelatedTableWithField"].DataPropertyName = "RelatedTableWithField";
            dgvCustomRelatedTableConfig.Columns["IsDataBind"].DataPropertyName = "IsDataBind";
            dgvCustomRelatedTableConfig.Columns["RelatedTableDisplayField"].DataPropertyName = "RelatedTableDisplayField";
            dgvCustomRelatedTableConfig.Columns["IsAddBatch"].DataPropertyName = "IsAddBatch";
            dgvCustomRelatedTableConfig.Columns["IsAddBatchTemplate"].DataPropertyName = "IsAddBatchTemplate";
            dgvCustomRelatedTableConfig.Columns["AddBatchTemplateTableName"].DataPropertyName = "AddBatchTemplateTableName";
            dgvCustomRelatedTableConfig.Columns["MainTemplateField"].DataPropertyName = "MainTemplateField";
            dgvCustomRelatedTableConfig.Columns["TemplateMainField"].DataPropertyName = "TemplateMainField";
            dgvCustomRelatedTableConfig.Columns["IsLeftButtonMenu"].DataPropertyName = "IsLeftButtonMenu";
            dgvCustomRelatedTableConfig.Columns["IsShowPDFRelatedTableRemark"].DataPropertyName = "IsShowPDFRelatedTableRemark";
            dgvCustomRelatedTableConfig.Columns["IsShowPDFSeparateLine"].DataPropertyName = "IsShowPDFSeparateLine";
            dgvCustomRelatedTableConfig.Columns["Sort"].DataPropertyName = "Sort";
            dgvCustomRelatedTableConfig.Columns["SortField"].DataPropertyName = "SortField";

            RelatedTableDisplayField.UseColumnTextForButtonValue = true;
            RelatedTableType.Items.AddRange(new object[] { "1_to_n", "1_to_1", "CustomAdd" });
            TableWithField.Items.AddRange(FieldName);
            MainTemplateField.Items.AddRange(FieldName);
            // 处理传入的相关表显示字段信息
            TempCustomDisplayFieldConfig = new DataSet();
            string strTempRelatedTableName = "NoRelatedTable";
            string strTempTableWithField = "NoTableWithField";
            foreach (DataRow drDisplayField in CustomDisplayFieldConfig.Rows)
            {
                DataRow drTemp;
                if (strTempRelatedTableName == (string)drDisplayField["RelatedTableName"] && strTempTableWithField == (string)drDisplayField["TableWithField"])
                {
                    drTemp = TempCustomDisplayFieldConfig.Tables[strTempTableWithField + "_" + strTempRelatedTableName + "DisplayField"].NewRow();
                    drTemp.ItemArray = drDisplayField.ItemArray;
                    TempCustomDisplayFieldConfig.Tables[strTempTableWithField + "_" + strTempRelatedTableName + "DisplayField"].Rows.Add(drTemp);
                }
                else
                {
                    strTempRelatedTableName = (string)drDisplayField["RelatedTableName"];
                    strTempTableWithField = (string)drDisplayField["TableWithField"];
                    TempCustomDisplayFieldConfig.Tables.Add(strTempTableWithField + "_" + strTempRelatedTableName + "DisplayField");
                    foreach(DataColumn dcDisplayField in CustomDisplayFieldConfig.Columns)
                    {
                        TempCustomDisplayFieldConfig.Tables[strTempTableWithField + "_" + strTempRelatedTableName + "DisplayField"].Columns.Add(dcDisplayField.ColumnName, dcDisplayField.DataType);
                    }
                    drTemp = TempCustomDisplayFieldConfig.Tables[strTempTableWithField + "_" + strTempRelatedTableName + "DisplayField"].NewRow();
                    drTemp.ItemArray = drDisplayField.ItemArray;
                    TempCustomDisplayFieldConfig.Tables[strTempTableWithField + "_" + strTempRelatedTableName + "DisplayField"].Rows.Add(drTemp);
                }

            }
        }

        private void dgvCustomRelatedTableConfig_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                // 处理相关表显示字段
                string strSerialNumber = string.Empty;
                string strRelatedInfoName = string.Empty;
                string strRelatedTableType = string.Empty;
                string strRelatedTableOwner = string.Empty;
                string strRelatedTableName = string.Empty;
                string strTableWithField = string.Empty;
                string strRelatedTableWithField = string.Empty;
                if (dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["SerialNumber"].Value != DBNull.Value
                    && dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedInfoName"].Value != DBNull.Value
                    && dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableType"].Value != DBNull.Value
                    && dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableOwner"].Value != DBNull.Value
                    && dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableName"].Value != DBNull.Value
                    && dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["TableWithField"].Value != DBNull.Value
                    && dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableWithField"].Value != DBNull.Value
                    )
                {
                    strSerialNumber = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["SerialNumber"].Value);
                    strRelatedInfoName = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedInfoName"].Value);
                    strRelatedTableType = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableType"].Value);
                    strRelatedTableOwner = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableOwner"].Value);
                    strRelatedTableName = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableName"].Value);
                    strTableWithField = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["TableWithField"].Value);
                    strRelatedTableWithField = (string)(dgvCustomRelatedTableConfig.Rows[e.RowIndex].Cells["RelatedTableWithField"].Value);

                    // 打开配置相关表显示字段窗口
                    if (dgvCustomRelatedTableConfig.Columns[e.ColumnIndex].Name == "RelatedTableDisplayField")
                    {
                        // 创建自定义操作配置窗口
                        CustomDisplayFieldConfigForm CustomDisplayFieldConfigForm = new CustomDisplayFieldConfigForm();
                        // 将自定义操作配置信息传入自定义操作配置窗口
                        if (TempCustomDisplayFieldConfig.Tables[strTableWithField + "_" + strRelatedTableName + "DisplayField"] == null)
                        {
                            CustomDisplayFieldConfigForm.CustomDisplayFieldConfig = new DataTable();
                            CustomDisplayFieldConfigForm.CustomDisplayFieldConfig = GetFields
                                (
                                this.ConnectionString,
                                "Table",
                                strRelatedTableName,
                                strSerialNumber,
                                strRelatedInfoName,
                                strRelatedTableType,
                                strRelatedTableOwner,
                                strRelatedTableName,
                                strTableWithField,
                                strRelatedTableWithField
                                );
                            CustomDisplayFieldConfigForm.CustomDisplayFieldConfig.TableName = strTableWithField + "_" + strRelatedTableName + "DisplayField";
                        }
                        else
                        {
                            CustomDisplayFieldConfigForm.CustomDisplayFieldConfig = TempCustomDisplayFieldConfig.Tables[strTableWithField + "_" + strRelatedTableName + "DisplayField"].Copy();
                            CustomDisplayFieldConfigForm.CustomDisplayFieldConfig.TableName = strTableWithField + "_" + strRelatedTableName + "DisplayField";
                        }
                        // 打开自定义操作配置窗口
                        CustomDisplayFieldConfigForm.ShowDialog(this);
                        if (CustomDisplayFieldConfigForm.SaveFlag == true)
                        {
                            // 将自定义操作配置信息传出自定义操作配置窗口
                            if (TempCustomDisplayFieldConfig.Tables[strTableWithField + "_" + strRelatedTableName + "DisplayField"] != null)
                            {
                                TempCustomDisplayFieldConfig.Tables.Remove(strTableWithField + "_" + strRelatedTableName + "DisplayField");
                            }
                            CustomDisplayFieldConfigForm.CustomDisplayFieldConfig.TableName = strTableWithField + "_" + strRelatedTableName + "DisplayField";
                            TempCustomDisplayFieldConfig.Tables.Add(CustomDisplayFieldConfigForm.CustomDisplayFieldConfig);
                            // 将对应相关表的显示字段
                        }
                    }
                }
                else if (dgvCustomRelatedTableConfig.Columns[e.ColumnIndex].Name == "RelatedTableDisplayField")
                {
                    MessageBox.Show("请将相关表基础信息填写完整。");
                }
            }
        }

        private DataTable GetFields
            (
            string strConnectionString,
            string strDatabaseObjectType,
            string strDatabaseObjectName,
            string strSerialNumber,
            string strRelatedInfoName,
            string strRelatedTableType,
            string strRelatedTableOwner,
            string strRelatedTableName,
            string strTableWithField,
            string strRelatedTableWithField
            )
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter();
            StringBuilder sbSqlText = new StringBuilder(string.Empty);
            DataTable dtReturn = new DataTable();
            string strDatabaseName = string.Empty;
            try
            {
                dbConnection.ConnectionString = strConnectionString;
                dbConnection.Open();
                strDatabaseName = dbConnection.Database;
                dbCommand.Connection = dbConnection;
                dbCommand.CommandType = CommandType.Text;

                string strSqlVersion;
                sbSqlText.Append("SELECT @@VERSION");
                dbCommand.CommandText = sbSqlText.ToString();
                strSqlVersion = (string)dbCommand.ExecuteScalar();
                if (strSqlVersion.IndexOf("SQL Server 2008") >= 0 || strSqlVersion.IndexOf("SQL Server 2005") >= 0)
                {
                    sbSqlText = new StringBuilder(string.Empty);
                    sbSqlText.Append("SELECT A.[name] AS [DisplayFieldName], C.[name] AS [DataTypeName], A.[length] AS [DataSize],");
                    sbSqlText.Append(" '" + strSerialNumber + "' AS [SerialNumber],");
                    sbSqlText.Append(" '" + strRelatedInfoName + "' AS [RelatedInfoName],");
                    sbSqlText.Append(" '" + strRelatedTableType + "' AS [RelatedTableType],");
                    sbSqlText.Append(" '" + strRelatedTableOwner + "' AS [RelatedTableOwner],");
                    sbSqlText.Append(" '" + strRelatedTableName + "' AS [RelatedTableName],");
                    sbSqlText.Append(" '" + strTableWithField + "' AS [TableWithField],");
                    sbSqlText.Append(" '" + strRelatedTableWithField + "' AS [RelatedTableWithField],");
                    sbSqlText.Append(" A.[isoutparam] AS [IsOutParameter], CAST(A.[isnullable] AS bit) AS [IsNull], ");
                    sbSqlText.Append(" D.[text] AS [DefaultValue], A.[typestat],");
                    sbSqlText.Append(" E.[value] AS [DisplayName],");
                    sbSqlText.Append(" A.[colid] AS [OrderID],");
                    sbSqlText.Append(" CAST(CASE WHEN F.[keyno] > 0 THEN 1 ELSE 0 END AS bit) AS [IsPrimaryKey]");
                    sbSqlText.Append(" FROM [" + strDatabaseName + "].[dbo].[syscolumns] AS A");
                    sbSqlText.Append(" INNER JOIN [" + strDatabaseName + "].[dbo].[sysobjects] AS B");
                    sbSqlText.Append(" ON A.[id] = B.[id] AND B.[name] = '" + strDatabaseObjectName + "'");
                    sbSqlText.Append(" INNER JOIN [" + strDatabaseName + "].[dbo].[systypes] AS C");
                    sbSqlText.Append(" ON A.[xtype] = C.[xtype] AND C.[name] <> 'sysname' AND C.[status] < 3 ");
                    sbSqlText.Append(" LEFT JOIN [" + strDatabaseName + "].[dbo].[syscomments] AS D");
                    sbSqlText.Append(" ON A.[cdefault] = D.[id]");
                    sbSqlText.Append(" LEFT JOIN [" + strDatabaseName + "].[sys].[extended_properties] AS E");
                    sbSqlText.Append(" ON A.[id] = E.[major_id] AND A.[colid] = E.[minor_id]");
                    sbSqlText.Append(" LEFT JOIN ");
                    sbSqlText.Append("(");
                    sbSqlText.Append("	SELECT CC.[id], CC.[keyno], CC.[colid]");
                    sbSqlText.Append("	 FROM [" + strDatabaseName + "].[dbo].[sysobjects] AS AA");
                    sbSqlText.Append("	 INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexes] AS BB");
                    sbSqlText.Append("	 ON AA.[parent_obj] = BB.[id] AND AA.[name] = BB.[name] AND AA.[xtype] = 'PK'");
                    sbSqlText.Append("	 INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexkeys] AS CC");
                    sbSqlText.Append("	 ON BB.[id] = CC.[id] AND BB.[indid] = CC.[indid]");
                    sbSqlText.Append(") AS F");
                    sbSqlText.Append(" ON A.[id] = F.[id] AND A.[colid] = F.[colid]");
                    sbSqlText.Append(" ORDER BY A.[colid] ASC");
                }
                else if (strSqlVersion.IndexOf("SQL Server 2000") >= 0)
                {
                    sbSqlText = new StringBuilder(string.Empty);
                    sbSqlText.Append("SELECT A.[name] AS [DisplayFieldName], C.[name] AS [DataTypeName], A.[length] AS [DataSize],");
                    sbSqlText.Append(" '" + strSerialNumber + "' AS [SerialNumber],");
                    sbSqlText.Append(" '" + strRelatedInfoName + "' AS [RelatedInfoName],");
                    sbSqlText.Append(" '" + strRelatedTableType + "' AS [RelatedTableType],");
                    sbSqlText.Append(" '" + strRelatedTableOwner + "' AS [RelatedTableOwner],");
                    sbSqlText.Append(" '" + strRelatedTableName + "' AS [RelatedTableName],");
                    sbSqlText.Append(" '" + strTableWithField + "' AS [TableWithField],");
                    sbSqlText.Append(" '" + strRelatedTableWithField + "' AS [RelatedTableWithField],");
                    sbSqlText.Append(" A.[isoutparam] AS [IsOutParameter], CAST(A.[isnullable] AS bit) AS [IsNull], ");
                    sbSqlText.Append(" D.[text] AS [DefaultValue], A.[typestat],");
                    sbSqlText.Append(" E.[value] AS [DisplayName],");
                    sbSqlText.Append(" A.[colid] AS [OrderID],");
                    sbSqlText.Append(" CAST(CASE WHEN F.[keyno] > 0 THEN 1 ELSE 0 END AS bit) AS [IsPrimaryKey]");
                    sbSqlText.Append(" FROM [" + strDatabaseName + "].[dbo].[syscolumns] AS A");
                    sbSqlText.Append(" INNER JOIN [" + strDatabaseName + "].[dbo].[sysobjects] AS B");
                    sbSqlText.Append(" ON A.[id] = B.[id] AND B.[name] = '" + strDatabaseObjectName + "'");
                    sbSqlText.Append(" INNER JOIN [" + strDatabaseName + "].[dbo].[systypes] AS C");
                    sbSqlText.Append(" ON A.[xtype] = C.[xtype] AND C.[name] <> 'sysname' AND C.[status] < 3 ");
                    sbSqlText.Append(" LEFT JOIN [" + strDatabaseName + "].[dbo].[syscomments] AS D");
                    sbSqlText.Append(" ON A.[cdefault] = D.[id]");
                    sbSqlText.Append(" LEFT JOIN [" + strDatabaseName + "].[dbo].[sysproperties] AS E");
                    sbSqlText.Append(" ON A.[id] = E.[id] AND A.[colid] = E.[smallid]");
                    sbSqlText.Append(" LEFT JOIN ");
                    sbSqlText.Append("(");
                    sbSqlText.Append("	SELECT CC.[id], CC.[keyno], CC.[colid]");
                    sbSqlText.Append("	 FROM [" + strDatabaseName + "].[dbo].[sysobjects] AS AA");
                    sbSqlText.Append("	 INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexes] AS BB");
                    sbSqlText.Append("	 ON AA.[parent_obj] = BB.[id] AND AA.[name] = BB.[name] AND AA.[xtype] = 'PK'");
                    sbSqlText.Append("	 INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexkeys] AS CC");
                    sbSqlText.Append("	 ON BB.[id] = CC.[id] AND BB.[indid] = CC.[indid]");
                    sbSqlText.Append(") AS F");
                    sbSqlText.Append(" ON A.[id] = F.[id] AND A.[colid] = F.[colid]");
                    sbSqlText.Append(" ORDER BY A.[colid] ASC");
                }
                dbCommand.CommandText = sbSqlText.ToString();
                dbDataAdapter.SelectCommand = dbCommand;
                dbDataAdapter.Fill(dtReturn);
                return dtReturn;
            }
            finally
            {
                dbConnection.Close();
            }
        }

    }
}