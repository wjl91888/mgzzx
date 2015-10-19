using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Resources;
using System.Reflection;
using System.Xml;
using System.Xml.Xsl;
using Microsoft.Data.ConnectionUI;
using DataModelApplication.Common;

namespace DataModelApplication
{
    public partial class DataModelForm : Form
    {
        private DataTable dsCustomOperateConfig = new DataTable();
        private DataTable dsCustomConditionConfig = new DataTable();
        private DataTable dsCustomPermissionConfig = new DataTable();
        private DataTable dsCustomRelatedTableConfig = new DataTable();
        private DataTable dsCustomDisplayFieldConfig = new DataTable();
        private DataTable dsCustomPermissionFieldConfig = new DataTable();
        private DataSet dsTempCustomDisplayFieldConfig = new DataSet();
        private DataSet dsTempCustomPermissionFieldConfig = new DataSet();
        private XmlDocument xmlDocument = new XmlDocument();
        private XmlDocument xmlDocumentDataDict = new XmlDocument();
        private string FileName = "CustomProperty.xml";
        private string DataDictFileName = "CustomPropertyDataDict.xml";
        private string TemplatePath = "Template";
        private string ConfigPath = "\\Config";
        private string CodeGeneratedPath = "CodeGenerated";
        private string ProjectPath = "..\\..\\..";

        public DataModelForm()
        {
            InitializeComponent();
            txtTemplateFilePath.Text = TemplatePath;
            txtCodeFilePath.Text = CodeGeneratedPath;
            txtProjectPath.Text = ProjectPath;
            this.IsUse.ValueType = System.Type.GetType("System.Boolean");
            this.IsPrimaryKey.ValueType = System.Type.GetType("System.Boolean");
            this.IsNull.ValueType = System.Type.GetType("System.Boolean");
            this.IsFixed.ValueType = System.Type.GetType("System.Boolean");
            this.IsUpdateFixed.ValueType = System.Type.GetType("System.Boolean");
            this.IsString.ValueType = System.Type.GetType("System.Boolean");

            this.IsSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsAdd.ValueType = System.Type.GetType("System.Boolean");
            this.IsAdvanceSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsList.ValueType = System.Type.GetType("System.Boolean");
            this.IsModify.ValueType = System.Type.GetType("System.Boolean");
            this.IsApproximateSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsNonModifiable.ValueType = System.Type.GetType("System.Boolean");
            this.IsStatisticalCondition.ValueType = System.Type.GetType("System.Boolean");
            this.IsStatisticalData.ValueType = System.Type.GetType("System.Boolean");
            this.IsListSort.ValueType = System.Type.GetType("System.Boolean");
            this.IsDataBind.ValueType = System.Type.GetType("System.Boolean");
            this.IsShowDetail.ValueType = System.Type.GetType("System.Boolean");
            this.IsDataDict.ValueType = System.Type.GetType("System.Boolean");
            this.IsRelatedOperateParam.ValueType = System.Type.GetType("System.Boolean");
            this.IsSuggestItem.ValueType = System.Type.GetType("System.Boolean");
            this.IsUseSuggest.ValueType = System.Type.GetType("System.Boolean");
            this.IsUseSuggestSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsAJAXExist.ValueType = System.Type.GetType("System.Boolean");
            this.IsCoupled.ValueType = System.Type.GetType("System.Boolean");
            this.IsCoupledNext.ValueType = System.Type.GetType("System.Boolean");
            this.IsTreeStyle.ValueType = System.Type.GetType("System.Boolean");
            this.IsRangeSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsMoreItemSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsBatchSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsCustomAdd.ValueType = System.Type.GetType("System.Boolean");
            this.IsSubItemSearch.ValueType = System.Type.GetType("System.Boolean");
            this.IsMoreItemDisplay.ValueType = System.Type.GetType("System.Boolean");
            this.IsRestrictedViewCondition.ValueType = System.Type.GetType("System.Boolean");
            this.IsRestrictedViewSubItem.ValueType = System.Type.GetType("System.Boolean");
            this.IsSum.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTree.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParent.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParentLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsDispose.ValueType = System.Type.GetType("System.Boolean");
            this.IsDisposeReverse.ValueType = System.Type.GetType("System.Boolean");
            this.IsDisposeOtherTable.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeRelatedParentIndependent.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeNoParent.ValueType = System.Type.GetType("System.Boolean");
            this.IsComboTreeParentLink.ValueType = System.Type.GetType("System.Boolean");
            this.IsAllOneRow.ValueType = System.Type.GetType("System.Boolean");
            this.IsAddDefaultValue.ValueType = System.Type.GetType("System.Boolean");
            this.IsPDFShow.ValueType = System.Type.GetType("System.Boolean");
            this.IsPDFNextSeparateLine.ValueType = System.Type.GetType("System.Boolean");
            this.IsHideTitle.ValueType = System.Type.GetType("System.Boolean");
            this.IsFromDoc.ValueType = System.Type.GetType("System.Boolean");
            this.OnlyDisplayUsedNode.ValueType = System.Type.GetType("System.Boolean");
            this.IsDefaultList.ValueType = System.Type.GetType("System.Boolean");
            this.IsUseTab.ValueType = System.Type.GetType("System.Boolean");
            this.IsNoBorderTop.ValueType = System.Type.GetType("System.Boolean");
            this.IsNoBorderLeft.ValueType = System.Type.GetType("System.Boolean");
            this.IsNoBorderBottom.ValueType = System.Type.GetType("System.Boolean");
            this.IsNoBorderRight.ValueType = System.Type.GetType("System.Boolean");
            this.PrefixMatch.ValueType = System.Type.GetType("System.Boolean");
            this.IsFromDataSet.ValueType = System.Type.GetType("System.Boolean");
            this.MutilInsertField.ValueType = System.Type.GetType("System.Boolean");
            this.MutilInsertCondition.ValueType = System.Type.GetType("System.Boolean");
            this.IsAppList.ValueType = System.Type.GetType("System.Boolean");
            this.IsAppFilter.ValueType = System.Type.GetType("System.Boolean");
            this.IsAppDetail.ValueType = System.Type.GetType("System.Boolean");

            this.dgvColumn.ScrollBars = ScrollBars.Both;
        }

        private void DataModelForm_Load(object sender, EventArgs e)
        {
            test();
            dgvColumn.AutoGenerateColumns = false;
            btnLoadTableConfig.Enabled = true;
            rbTable.Checked = true;
            if (lbDatabaseObject.Items.Count > 0)
            {
                btnAutoGenerateCode.Enabled = true;
                btnGenerateCode.Enabled = true;
                btnSaveTableConfig.Enabled = true;
            }
            else
            {
                btnAutoGenerateCode.Enabled = false;
                btnGenerateCode.Enabled = false;
                btnSaveTableConfig.Enabled = false;
            }
            if (chkAutoGenerateIncludeDateTime.Checked)
            {
                chkAutoGenerateDay.Enabled = true;
                chkAutoGenerateHour.Enabled = true;
                chkAutoGenerateMinute.Enabled = true;
                chkAutoGenerateMonth.Enabled = true;
                chkAutoGenerateMSecond.Enabled = true;
                chkAutoGenerateSecond.Enabled = true;
                chkAutoGenerateYear.Enabled = true;
            }
            else
            {
                chkAutoGenerateDay.Enabled = false;
                chkAutoGenerateHour.Enabled = false;
                chkAutoGenerateMinute.Enabled = false;
                chkAutoGenerateMonth.Enabled = false;
                chkAutoGenerateMSecond.Enabled = false;
                chkAutoGenerateSecond.Enabled = false;
                chkAutoGenerateYear.Enabled = false;
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (ValidateConnection(txtConnectionString.Text) == true)
            {
                if (rbTable.Checked == true)
                {
                    lbDatabaseObject.DataSource = GetDatabaseObject(txtConnectionString.Text, "Table");
                    if (lbDatabaseObject.Items.Count > 0)
                    {
                        lbDatabaseObject.DisplayMember = "name";
                        lbDatabaseObject.ValueMember = "name";
                    }
                }
                else if (rbView.Checked == true)
                {
                    lbDatabaseObject.DataSource = GetDatabaseObject(txtConnectionString.Text, "View");
                    if (lbDatabaseObject.Items.Count > 0)
                    {
                        lbDatabaseObject.DisplayMember = "name";
                        lbDatabaseObject.ValueMember = "name";
                    }
                }
                else if (rbProcedure.Checked == true)
                {
                    lbDatabaseObject.DataSource = GetDatabaseObject(txtConnectionString.Text, "StoreProcedure");
                    if (lbDatabaseObject.Items.Count > 0)
                    {
                        lbDatabaseObject.DisplayMember = "Name";
                        lbDatabaseObject.ValueMember = "Name";
                    }
                }
                else
                {
                    MessageBox.Show("请选择要列表数据库对象。");
                }
                if (lbDatabaseObject.Items.Count > 0)
                {
                    btnAutoGenerateCode.Enabled = true;
                    btnGenerateCode.Enabled = true;
                    btnSaveTableConfig.Enabled = true;
                }
                else
                {
                    btnAutoGenerateCode.Enabled = false;
                    btnGenerateCode.Enabled = false;
                    btnSaveTableConfig.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("连接失败，请检查输入连接字符串。");
            }
        }


        private void lbDatabaseObject_SelectedValueChanged(object sender, EventArgs e)
        {
            if (ValidateConnection(txtConnectionString.Text) == true)
            {
                // 初始化界面元素
                dsCustomOperateConfig = new DataTable();
                dsCustomConditionConfig = new DataTable();
                dsCustomPermissionConfig = new DataTable();
                dsCustomPermissionFieldConfig = new DataTable();
                dsCustomRelatedTableConfig = new DataTable();
                dsCustomDisplayFieldConfig = new DataTable();
                if (rbTable.Checked == true)
                {
                    dgvColumn.DataSource = GetColumnInfo(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                    dgvColumn.Columns["FieldName"].DataPropertyName = "Name";
                    dgvColumn.Columns["IsNull"].DataPropertyName = "IsNull";
                    dgvColumn.Columns["DBType"].DataPropertyName = "DataTypeName";
                    dgvColumn.Columns["DataSize"].DataPropertyName = "DataSize";
                    dgvColumn.Columns["DefaultValue"].DataPropertyName = "DefaultValue";
                    dgvColumn.Columns["FieldRemark"].DataPropertyName = "FieldRemark";
                    dgvColumn.Columns["IsPrimaryKey"].DataPropertyName = "IsPrimaryKey";
                    dgvColumn.Columns["OrderID"].DataPropertyName = "OrderID";

                    dgvColumn.Columns["IsUse"].DataPropertyName = "IsUse";
                    dgvColumn.Columns["IsAdd"].DataPropertyName = "IsAdd";
                    dgvColumn.Columns["IsModify"].DataPropertyName = "IsModify";
                    dgvColumn.Columns["IsList"].DataPropertyName = "IsList";
                    dgvColumn.Columns["IsSearch"].DataPropertyName = "IsSearch";
                    dgvColumn.Columns["IsShowDetail"].DataPropertyName = "IsShowDetail";
                    dgvColumn.Columns["ControlType"].DataPropertyName = "ControlType";
                    dgvColumn.Columns["DataValidateType"].DataPropertyName = "DataValidateType";
                    dgvColumn.Columns["DataValidateParameterOne"].DataPropertyName = "DataValidateParameterOne";
                    dgvColumn.Columns["DataValidateParameterTwo"].DataPropertyName = "DataValidateParameterTwo";
                    dgvColumn.Columns["TextAlign"].DataPropertyName = "TextAlign";
                    dgvColumn.Columns["DisplayFormatString"].DataPropertyName = "DisplayFormatString";
                    dgvColumn.Columns["AppListColumn"].DataPropertyName = "AppListColumn";
                    dgvColumn.Columns["AppDetailCaptionColumn"].DataPropertyName = "AppDetailCaptionColumn";
                    dgvColumn.Columns["AppDetailContentColumn"].DataPropertyName = "AppDetailContentColumn";
                    if (CommonFileLibrary.IsExistFile(Directory.GetCurrentDirectory() + ConfigPath + @"\" + lbDatabaseObject.SelectedValue + "Config" + ".xml"))
                    {
                        try
                        {
                            LoadConfigFile(Directory.GetCurrentDirectory() + ConfigPath + @"\" + lbDatabaseObject.SelectedValue + "Config" + ".xml");
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("读取文件结构错误！");

                        }
                    }
                    else
                    {
                        txtTableRemark.Text = lbDatabaseObject.SelectedValue.ToString();
                    }
                }
                else if (rbView.Checked == true)
                {
                    dgvColumn.DataSource = GetColumnInfo(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                    dgvColumn.Columns["FieldName"].DataPropertyName = "Name";
                    dgvColumn.Columns["IsNull"].DataPropertyName = "IsNull";
                    dgvColumn.Columns["DBType"].DataPropertyName = "DataTypeName";
                    dgvColumn.Columns["DataSize"].DataPropertyName = "DataSize";
                    dgvColumn.Columns["DefaultValue"].DataPropertyName = "DefaultValue";
                    dgvColumn.Columns["FieldRemark"].DataPropertyName = "FieldRemark";
                    dgvColumn.Columns["IsPrimaryKey"].DataPropertyName = "IsPrimaryKey";
                    dgvColumn.Columns["OrderID"].DataPropertyName = "OrderID";

                    dgvColumn.Columns["IsUse"].DataPropertyName = "IsUse";
                    dgvColumn.Columns["IsAdd"].DataPropertyName = "IsAdd";
                    dgvColumn.Columns["IsModify"].DataPropertyName = "IsModify";
                    dgvColumn.Columns["IsList"].DataPropertyName = "IsList";
                    dgvColumn.Columns["IsSearch"].DataPropertyName = "IsSearch";
                    dgvColumn.Columns["IsShowDetail"].DataPropertyName = "IsShowDetail";
                    dgvColumn.Columns["ControlType"].DataPropertyName = "ControlType";
                    dgvColumn.Columns["DataValidateType"].DataPropertyName = "DataValidateType";
                    dgvColumn.Columns["DataValidateParameterOne"].DataPropertyName = "DataValidateParameterOne";
                    dgvColumn.Columns["DataValidateParameterTwo"].DataPropertyName = "DataValidateParameterTwo";
                    dgvColumn.Columns["TextAlign"].DataPropertyName = "TextAlign";
                    dgvColumn.Columns["DisplayFormatString"].DataPropertyName = "DisplayFormatString";
                    if (CommonFileLibrary.IsExistFile(Directory.GetCurrentDirectory() + ConfigPath + @"\" + lbDatabaseObject.SelectedValue + "Config" + ".xml") == true)
                    {
                        try
                        {
                            LoadConfigFile(Directory.GetCurrentDirectory() + ConfigPath + @"\" + lbDatabaseObject.SelectedValue + "Config" + ".xml");
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("读取文件结构错误！");

                        }
                    }
                    else
                    {
                        txtTableRemark.Text = lbDatabaseObject.SelectedValue.ToString();
                    }
                }
                else if (rbProcedure.Checked)
                {

                }
                else
                {
                    MessageBox.Show("请选择要列表数据库对象。");
                }

            }
            else
            {
                MessageBox.Show("连接失败，请检查输入连接字符串。");
            }
        }

        private bool ValidateConnection(string strConnectionString)
        {
            bool boolReturn;
            SqlConnection dbConnection = new SqlConnection();
            try
            {
                dbConnection.ConnectionString = strConnectionString;
                dbConnection.Open();
                boolReturn = true;
            }
            catch (Exception)
            {
                boolReturn = false;
            }
            finally
            {
                dbConnection.Close();
            }
            return boolReturn;
        }

        private DataTable GetDatabaseObject(string strConnectionString, string strDatabaseObjectType)
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter();
            StringBuilder sbSqlText = new StringBuilder(string.Empty);
            DataTable dtReturn = new DataTable();
            string strDatabaseName = string.Empty;
            switch (strDatabaseObjectType)
            {
                case "Table":
                    strDatabaseObjectType = "U";
                    break;
                case "View":
                    strDatabaseObjectType = "V";
                    break;
                case "StoreProcedure":
                    strDatabaseObjectType = "P";
                    break;
            }
            try
            {
                dbConnection.ConnectionString = strConnectionString;
                dbConnection.Open();
                strDatabaseName = dbConnection.Database;

                sbSqlText.Append("SELECT [name] AS [Name]");
                sbSqlText.Append(" FROM [" + strDatabaseName + "].[dbo].[sysobjects]");
                sbSqlText.Append(" WHERE [xtype] = '" + strDatabaseObjectType + "' AND [status] >= 0");
                sbSqlText.Append(" ORDER BY [name]");
                dbCommand.Connection = dbConnection;
                dbCommand.CommandType = CommandType.Text;
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

        private DataTable GetColumnInfo(string strConnectionString, string strDatabaseObjectType, string strDatabaseObjectName, string strNameSpace)
        {
            SqlConnection dbConnection = new SqlConnection();
            try
            {
                SqlCommand dbCommand = new SqlCommand();
                SqlDataAdapter dbDataAdapter = new SqlDataAdapter();
                StringBuilder sbSqlText = new StringBuilder(string.Empty);
                DataTable dtReturn = new DataTable();
                string strDatabaseName = string.Empty;
                StringBuilder strReturn = new StringBuilder(string.Empty);
                string strSqlVersion;
                dbConnection.ConnectionString = strConnectionString;
                dbConnection.Open();
                strDatabaseName = dbConnection.Database;
                dbCommand.Connection = dbConnection;
                dbCommand.CommandType = CommandType.Text;

                sbSqlText.Append("SELECT @@VERSION");
                dbCommand.CommandText = sbSqlText.ToString();
                strSqlVersion = (string)dbCommand.ExecuteScalar();
                if (strSqlVersion.IndexOf("SQL Server 2008") >= 0 || strSqlVersion.IndexOf("SQL Server 2005") >= 0)
                {
                    sbSqlText = new StringBuilder(string.Empty);
                    sbSqlText.Append("SELECT");
                    sbSqlText.Append(" A.[name] AS [Name],");
                    sbSqlText.Append(" C.[name] AS [DataTypeName],");
                    sbSqlText.Append(" (CASE WHEN A.[length]=-1 THEN 4000 ELSE A.[length] END) AS [DataSize],");
                    sbSqlText.Append(" A.[isoutparam] AS [IsOutParameter],");
                    sbSqlText.Append(" CAST(A.[isnullable] AS bit) AS [IsNull], ");
                    sbSqlText.Append(" D.[text] AS [DefaultValue], A.[typestat],");
                    sbSqlText.Append(" E.[value] AS [FieldRemark],");
                    sbSqlText.Append(" A.[colid] AS [OrderID],");
                    sbSqlText.Append(" 'Center' AS [TextAlign],");
                    sbSqlText.Append(" CAST(1 AS bit) AS [IsUse],");
                    sbSqlText.Append(" CAST(1 AS bit) AS [IsIsPDFShow],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsAdd],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsModify],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsList],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsSearch],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsShowDetail],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN 'HTML编辑器' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN 'HTML编辑器' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN '时间日期输入' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN '时间日期输入' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN '图片保存到数据库' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [ControlType],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN 'ObjectID格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN '字符串格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN '字符串格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN '时间格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN '时间格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN '数据库图片大小验证' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [DataValidateType],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN 'null' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [DataValidateParameterOne],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN CAST(A.[length]/2 AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN CAST(A.[length] AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN CAST(A.[length] AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN CAST(A.[length]/2 AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN 'null' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [DataValidateParameterTwo],");
                    sbSqlText.Append(" 'null' AS [DisplayFormatString],");
                    sbSqlText.Append(" '4' AS [AppListColumn],");
                    sbSqlText.Append(" '3' AS [AppDetailCaptionColumn],");
                    sbSqlText.Append(" '9' AS [AppDetailContentColumn],");
                    sbSqlText.Append(" '3' AS [AppAddCaptionColumn],");
                    sbSqlText.Append(" '9' AS [AppAddContentColumn],");
                    sbSqlText.Append(" CAST(CASE WHEN F.[keyno] > 0 THEN 1 ELSE 0 END AS bit) AS [IsPrimaryKey]");
                    sbSqlText.Append(" FROM [" + strDatabaseName + "].[dbo].[syscolumns] AS A");
                    sbSqlText.Append(" INNER JOIN [" + strDatabaseName + "].[dbo].[sysobjects] AS B");
                    sbSqlText.Append(" ON A.[id] = B.[id] AND B.[name] = '" + strDatabaseObjectName + "'");
                    sbSqlText.Append(" INNER JOIN [" + strDatabaseName + "].[dbo].[systypes] AS C");
                    sbSqlText.Append(" ON A.[xusertype] = C.[xusertype] AND C.[name] <> 'sysname' AND C.[status] < 3 AND C.[uid] = 4");
                    sbSqlText.Append(" LEFT JOIN [" + strDatabaseName + "].[dbo].[syscomments] AS D");
                    sbSqlText.Append(" ON A.[cdefault] = D.[id]");
                    sbSqlText.Append(" LEFT JOIN [" + strDatabaseName + "].[sys].[extended_properties] AS E");
                    sbSqlText.Append(" ON A.[id] = E.[major_id] AND A.[colid] = E.[minor_id]");
                    sbSqlText.Append(" LEFT JOIN ");
                    sbSqlText.Append("(");
                    sbSqlText.Append("  SELECT CC.[id], CC.[keyno], CC.[colid]");
                    sbSqlText.Append("  FROM [" + strDatabaseName + "].[dbo].[sysobjects] AS AA");
                    sbSqlText.Append("  INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexes] AS BB");
                    sbSqlText.Append("  ON AA.[parent_obj] = BB.[id] AND AA.[name] = BB.[name] AND AA.[xtype] = 'PK'");
                    sbSqlText.Append("  INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexkeys] AS CC");
                    sbSqlText.Append("  ON BB.[id] = CC.[id] AND BB.[indid] = CC.[indid]");
                    sbSqlText.Append(") AS F");
                    sbSqlText.Append(" ON A.[id] = F.[id] AND A.[colid] = F.[colid]");
                    sbSqlText.Append(" ORDER BY A.[colid] ASC");
                }
                else if (strSqlVersion.IndexOf("SQL Server 2000") >= 0)
                {
                    sbSqlText = new StringBuilder(string.Empty);
                    sbSqlText.Append("SELECT");
                    sbSqlText.Append(" A.[name] AS [Name],");
                    sbSqlText.Append(" C.[name] AS [DataTypeName],");
                    sbSqlText.Append(" A.[length] AS [DataSize],");
                    sbSqlText.Append(" A.[isoutparam] AS [IsOutParameter],");
                    sbSqlText.Append(" CAST(A.[isnullable] AS bit) AS [IsNull], ");
                    sbSqlText.Append(" D.[text] AS [DefaultValue], A.[typestat],");
                    sbSqlText.Append(" E.[value] AS [FieldRemark],");
                    sbSqlText.Append(" A.[colid] AS [OrderID],");
                    sbSqlText.Append(" 'Center' AS [TextAlign],");
                    sbSqlText.Append(" CAST(1 AS bit) AS [IsUse],");
                    sbSqlText.Append(" CAST(1 AS bit) AS [IsIsPDFShow],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsAdd],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsModify],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsList],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsSearch],");
                    sbSqlText.Append(" CAST(CASE WHEN A.[Name] <> '' AND E.[value] IS NOT NULL THEN 1 ELSE 0 END AS bit) AS [IsShowDetail],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN 'HTML编辑器' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN 'HTML编辑器' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN '时间日期输入' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN '时间日期输入' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN '单行文本框' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN '图片保存到数据库' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [ControlType],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN 'ObjectID格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN '字符串格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN '字符串格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN '字符串长度范围验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN '时间格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN '时间格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN '数字格式验证' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN '数据库图片大小验证' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [DataValidateType],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN '1' ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN 'null' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [DataValidateParameterOne],");
                    sbSqlText.Append(" CASE ");
                    sbSqlText.Append(" WHEN C.[name] = 'uniqueidentifier' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nvarchar' THEN CAST(A.[length]/2 AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'char' THEN CAST(A.[length] AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'varchar' THEN CAST(A.[length] AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'text' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'ntext' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'nchar' THEN CAST(A.[length]/2 AS varchar) ");
                    sbSqlText.Append(" WHEN C.[name] = 'datetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smalldatetime' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'tinyint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'smallint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'int' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'bigint' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'real' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'money' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'float' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'decimal' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'numeric' THEN 'null' ");
                    sbSqlText.Append(" WHEN C.[name] = 'image' THEN 'null' ");
                    sbSqlText.Append(" END ");
                    sbSqlText.Append(" AS [DataValidateParameterTwo],");
                    sbSqlText.Append(" 'null' AS [DisplayFormatString],");
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
                    sbSqlText.Append("  SELECT CC.[id], CC.[keyno], CC.[colid]");
                    sbSqlText.Append("  FROM [" + strDatabaseName + "].[dbo].[sysobjects] AS AA");
                    sbSqlText.Append("  INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexes] AS BB");
                    sbSqlText.Append("  ON AA.[parent_obj] = BB.[id] AND AA.[name] = BB.[name] AND AA.[xtype] = 'PK'");
                    sbSqlText.Append("  INNER JOIN [" + strDatabaseName + "].[dbo].[sysindexkeys] AS CC");
                    sbSqlText.Append("  ON BB.[id] = CC.[id] AND BB.[indid] = CC.[indid]");
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

        private void btnSaveTableConfig_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow dgvrTemp in dgvColumn.Rows)
                {
                    if (dgvrTemp.Cells["ControlType"].Value == DBNull.Value)
                    {
                        dgvrTemp.Cells["SPDataSize"].Value =
                            GetDataSize(
                            (string)dgvrTemp.Cells["DBType"].Value,
                            (object)dgvrTemp.Cells["DataSize"].Value);
                        dgvrTemp.Cells["SPDefaultValue"].Value = GetDefaultValue((object)dgvrTemp.Cells["DefaultValue"].Value);
                        dgvrTemp.Cells["SPSelectDataType"].Value =
                            GetDataTypeSelect(
                            (string)dgvrTemp.Cells["DBType"].Value,
                            (object)dgvrTemp.Cells["DataSize"].Value);
                        dgvrTemp.Cells["SPUpdateDataType"].Value =
                            GetDataTypeUpdate(
                            (string)dgvrTemp.Cells["DBType"].Value,
                            (object)dgvrTemp.Cells["DataSize"].Value);
                        dgvrTemp.Cells["FieldType"].Value = GetCSharpDataTypeString((string)dgvrTemp.Cells["DBType"].Value);
                        dgvrTemp.Cells["DataValidateMethod"].Value =
                            GetDataValidateTypeMethod(
                            (string)dgvrTemp.Cells["DataValidateType"].Value,
                            (string)dgvrTemp.Cells["FieldName"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterOne"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterTwo"].Value);
                        dgvrTemp.Cells["DataValidateMethodByViewState"].Value =
                            GetDataValidateTypeMethodByViewState(
                            (string)dgvrTemp.Cells["DataValidateType"].Value,
                            (string)dgvrTemp.Cells["FieldName"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterOne"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterTwo"].Value);
                        dgvrTemp.Cells["DataValidateFaildMessage"].Value = GetDataValidateTypeMessage((string)dgvrTemp.Cells["DataValidateType"].Value);
                        dgvrTemp.Cells["IsString"].Value = ValidateDataTypeIsString((string)dgvrTemp.Cells["DBType"].Value);
                        dgvrTemp.Cells["DBType"].Value =
    GetDBDataTypeString((string)dgvrTemp.Cells["DBType"].Value);

                    }
                    else if (dgvrTemp.Cells["ControlType"].Value != DBNull.Value)
                    {
                        dgvrTemp.Cells["SPDataSize"].Value =
                            GetDataSize(
                            (string)dgvrTemp.Cells["DBType"].Value,
                            (object)dgvrTemp.Cells["DataSize"].Value);
                        dgvrTemp.Cells["SPDefaultValue"].Value = GetDefaultValue((object)dgvrTemp.Cells["DefaultValue"].Value);
                        dgvrTemp.Cells["SPSelectDataType"].Value =
                            GetDataTypeSelect(
                            (string)dgvrTemp.Cells["DBType"].Value,
                            (object)dgvrTemp.Cells["DataSize"].Value);
                        dgvrTemp.Cells["SPUpdateDataType"].Value =
                            GetDataTypeUpdate(
                            (string)dgvrTemp.Cells["DBType"].Value,
                            (object)dgvrTemp.Cells["DataSize"].Value);
                        dgvrTemp.Cells["FieldType"].Value = GetCSharpDataTypeString((string)dgvrTemp.Cells["DBType"].Value);
                        dgvrTemp.Cells["IsString"].Value = ValidateDataTypeIsString((string)dgvrTemp.Cells["DBType"].Value);
                        dgvrTemp.Cells["ControlTypeName"].Value = GetControlTypeName((string)dgvrTemp.Cells["ControlType"].Value);
                        dgvrTemp.Cells["ControlTypePrefix"].Value = GetControlTypePrefix((string)dgvrTemp.Cells["ControlType"].Value);
                        dgvrTemp.Cells["ControlTypeValueSuffix"].Value = GetControlTypeValueSuffix((string)dgvrTemp.Cells["ControlType"].Value);
                        dgvrTemp.Cells["DataValidateMethod"].Value =
                            GetDataValidateTypeMethod(
                            (string)dgvrTemp.Cells["DataValidateType"].Value,
                            (string)dgvrTemp.Cells["FieldName"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterOne"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterTwo"].Value);
                        dgvrTemp.Cells["DataValidateMethodByViewState"].Value =
                            GetDataValidateTypeMethodByViewState(
                            (string)dgvrTemp.Cells["DataValidateType"].Value,
                            (string)dgvrTemp.Cells["FieldName"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterOne"].Value,
                            (object)dgvrTemp.Cells["DataValidateParameterTwo"].Value);
                        dgvrTemp.Cells["DataValidateFaildMessage"].Value = GetDataValidateTypeMessage((string)dgvrTemp.Cells["DataValidateType"].Value);
                        dgvrTemp.Cells["DBType"].Value =
                            GetDBDataTypeString((string)dgvrTemp.Cells["DBType"].Value);
                    }
                }
                saveTableConfigFileDialog.FileName = lbDatabaseObject.SelectedValue + "Config" + ".xml";
                saveTableConfigFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + ConfigPath;
                saveTableConfigFileDialog.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("保存文件错误！");
            }
        }

        private void saveTableConfigFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            SaveConfigFile(saveTableConfigFileDialog.FileName);
        }

        private void btnLoadTableConfig_Click(object sender, EventArgs e)
        {
            try
            {
                openTableConfigFileDialog.FileName = lbDatabaseObject.SelectedValue + "Config" + ".xml";
                openTableConfigFileDialog.InitialDirectory = Directory.GetCurrentDirectory() + ConfigPath;
                openTableConfigFileDialog.ShowDialog();
            }
            catch (Exception)
            {
                MessageBox.Show("读取文件结构错误！");
            }

        }

        private void openTableConfigFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            LoadConfigFile(openTableConfigFileDialog.FileName);
        }

        private string GetControlTypeName(string strControlType)
        {
            string strReturn = string.Empty;
            switch (strControlType)
            {
                case "单行文本框":
                    strReturn = "TextBox";
                    break;
                case "多行文本框":
                    strReturn = "FreeTextBox";
                    break;
                case "密码框":
                    strReturn = "TextBox";
                    break;
                case "HTML编辑器":
                    strReturn = "FreeTextBox";
                    break;
                case "下拉列表框":
                    strReturn = "DropDownList";
                    break;
                case "单选框":
                    strReturn = "RadioButtonList";
                    break;
                case "多选框":
                    strReturn = "CheckBoxList";
                    break;
                case "RICH多选框":
                    strReturn = "CheckBoxListEx";
                    break;
                case "单个单选框":
                    strReturn = "RadioButton";
                    break;
                case "单个多选框":
                    strReturn = "CheckBox";
                    break;
                case "文本标签":
                    strReturn = "Label";
                    break;
                case "文件上传":
                case "图片上传":
                    strReturn = "FilesList";
                    break;
                case "时间输入":
                    strReturn = "TextBox";
                    break;
                case "时间日期输入":
                    strReturn = "TextBox";
                    break;
                case "图片保存到数据库":
                    strReturn = "FileUpload";
                    break;
                case "GridDataBind":
                    strReturn = "GridDataBind";
                    break;
                case "ComboTreeView":
                    strReturn = "ComboTreeView";
                    break;
                case "RadTextBox":
                    strReturn = "RadTextBox";
                    break;
                case "RadMaskedTextBox":
                    strReturn = "RadMaskedTextBox";
                    break;
                case "RadDateInput":
                    strReturn = "RadDateInput";
                    break;
                case "RadNumericTextBox":
                    strReturn = "RadNumericTextBox";
                    break;
                case "RadDatePicker":
                    strReturn = "RadDatePicker";
                    break;
                case "RadMonthYearPicker":
                    strReturn = "RadMonthYearPicker";
                    break;
                case "RadDateTimePicker":
                    strReturn = "RadDateTimePicker";
                    break;
            }
            return strReturn;
        }

        private string GetControlTypePrefix(string strControlType)
        {
            string strReturn = string.Empty;
            switch (strControlType)
            {
                case "RICH多选框":
                    strReturn = "RICH";
                    break;
                case "多行文本框":
                case "HTML编辑器":
                    strReturn = "FTB";
                    break;
                case "单行文本框":
                case "密码框":
                case "下拉列表框":
                case "单选框":
                case "多选框":
                case "单个单选框":
                case "单个多选框":
                case "文本标签":
                case "时间输入":
                case "时间日期输入":
                case "图片保存到数据库":
                    strReturn = "asp";
                    break;
                case "文件上传":
                case "图片上传":
                case "GridDataBind":
                case "ComboTreeView":
                    strReturn = "control";
                    break;
                case "RadTextBox":
                case "RadMaskedTextBox":
                case "RadDateInput":
                case "RadNumericTextBox":
                case "RadDatePicker":
                case "RadMonthYearPicker":
                case "RadDateTimePicker":
                    strReturn = "telerik";
                    break;
            }
            return strReturn;
        }

        private string GetControlTypeValueSuffix(string strControlType)
        {
            string strReturn = string.Empty;
            switch (strControlType)
            {
                case "单行文本框":
                case "多行文本框":
                case "密码框":
                case "HTML编辑器":
                case "文本标签":
                case "文件上传":
                case "图片上传":
                case "时间输入":
                case "时间日期输入":
                case "GridDataBind":
                case "RadTextBox":
                case "RadMaskedTextBox":
                case "RadDateInput":
                    strReturn = "Text";
                    break;
                case "下拉列表框":
                case "单选框":
                case "多选框":
                    strReturn = "SelectedValue";
                    break;
                case "RICH多选框":
                case "ComboTreeView":
                    strReturn = "SelectedValues";
                    break;
                case "单个单选框":
                case "单个多选框":
                    strReturn = "Checked";
                    break;
                case "RadNumericTextBox":
                    strReturn = "Value";
                    break;
                case "RadDatePicker":
                case "RadMonthYearPicker":
                case "RadDateTimePicker":
                    strReturn = "SelectedDate";
                    break;
            }
            return strReturn;
        }

        private string GetDataValidateTypeMethod(
            string strDataValidateType,
            string strFieldName,
            object strDataValidateParameterOne,
            object strDataValidateParameterTwo)
        {
            string strReturn = string.Empty;
            switch (strDataValidateType)
            {
                case "空验证":
                    //strReturn = "ValidateIsNull(htInputParameter[\""+strFieldName+"\"])";
                    //strReturn = "ValidateIsNull(appData."+strFieldName+".ToString())";
                    //strReturn = "ValidateIsNull(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateIsNull";
                    break;
                case "字符串格式验证":
                    //strReturn = "ValidateStringFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateStringFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateStringFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateStringFormat";
                    break;
                case "字符串长度验证":
                    //strReturn = "ValidateStringLength(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ")";
                    //strReturn = "ValidateStringLength(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ")";
                    //strReturn = "ValidateStringLength(Request[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ")";
                    strReturn = "ValidateStringLength";
                    break;
                case "字符串长度范围验证":
                    //strReturn = "ValidateStringLengthRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateStringLengthRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateStringLengthRange(Request[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateStringLengthRange";
                    break;
                case "数字格式验证":
                    //strReturn = "ValidateNumberFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateNumberFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateNumberFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateNumberFormat";
                    break;
                case "数字长度验证":
                    //strReturn = "ValidateNumberLength(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ")";
                    //strReturn = "ValidateNumberLength(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ")";
                    //strReturn = "ValidateNumberLength(Request[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ")";
                    strReturn = "ValidateNumberLength";
                    break;
                case "数字长度范围验证":
                    //strReturn = "ValidateNumberLengthRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateNumberLengthRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateNumberLengthRange(Request[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateNumberLengthRange";
                    break;
                case "数字范围验证":
                    //strReturn = "ValidateNumberRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateNumberRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateNumberRange(Request[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateNumberRange";
                    break;
                case "时间格式验证":
                    //strReturn = "ValidateDateFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateDateFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateDateFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateDateFormat";
                    break;
                case "时间范围验证":
                    //strReturn = "ValidateDateRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateDateRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateDateRange(Request[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateDateRange";
                    break;
                case "布尔值格式验证":
                    //strReturn = "ValidateBooleanFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateBooleanFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateBooleanFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateBooleanFormat";
                    break;
                case "Email格式验证":
                    //strReturn = "ValidateEmailFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateEmailFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateEmailFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateEmailFormat";
                    break;
                case "ObjectID格式验证":
                    //strReturn = "ValidateUniqueIdentifierFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUniqueIdentifierFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateUniqueIdentifierFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateUniqueIdentifierFormat";
                    break;
                case "电话号码格式验证":
                    //strReturn = "ValidateTelFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateTelFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateTelFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateTelFormat";
                    break;
                case "文件名格式验证":
                    //strReturn = "ValidateFileNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateFileNameFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateFileNameFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateFileNameFormat";
                    break;
                case "用户名格式验证":
                    //strReturn = "ValidateUserNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUserNameFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateUserNameFormat(Request[\"" + strFieldName + "\"].ToString())";
                    strReturn = "ValidateUserNameFormat";
                    break;
                case "RICH多选框验证":
                    //strReturn = "ValidateUserNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUserNameFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateStringFormat(Request[\"" + strFieldName + "Value\"].ToString())";
                    strReturn = "ValidateStringFormat";
                    break;
                case "数据库图片大小验证":
                    //strReturn = "ValidateUserNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUserNameFormat(appData." + strFieldName + ".ToString())";
                    //strReturn = "ValidateStringFormat(Request[\"" + strFieldName + "Value\"].ToString())";
                    strReturn = "ValidateImageSize";
                    break;

            }
            return strReturn;
        }

        private string GetDataValidateTypeMethodByViewState(
            string strDataValidateType,
            string strFieldName,
            object strDataValidateParameterOne,
            object strDataValidateParameterTwo)
        {
            string strReturn = string.Empty;
            switch (strDataValidateType)
            {
                case "空验证":
                    //strReturn = "ValidateIsNull(htInputParameter[\""+strFieldName+"\"])";
                    //strReturn = "ValidateIsNull(appData."+strFieldName+".ToString())";
                    strReturn = "ValidateIsNull(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "字符串格式验证":
                    //strReturn = "ValidateStringFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateStringFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateStringFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "字符串长度验证":
                    //strReturn = "ValidateStringLength(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ")";
                    //strReturn = "ValidateStringLength(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ")";
                    strReturn = "ValidateStringLength(ViewState[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ")";
                    break;
                case "字符串长度范围验证":
                    //strReturn = "ValidateStringLengthRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateStringLengthRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateStringLengthRange(ViewState[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    break;
                case "数字格式验证":
                    //strReturn = "ValidateNumberFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateNumberFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateNumberFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "数字长度验证":
                    //strReturn = "ValidateNumberLength(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ")";
                    //strReturn = "ValidateNumberLength(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ")";
                    strReturn = "ValidateNumberLength(ViewState[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ")";
                    break;
                case "数字长度范围验证":
                    //strReturn = "ValidateNumberLengthRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateNumberLengthRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateNumberLengthRange(ViewState[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    break;
                case "数字范围验证":
                    //strReturn = "ValidateNumberRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateNumberRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateNumberRange(ViewState[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    break;
                case "时间格式验证":
                    //strReturn = "ValidateDateFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateDateFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateDateFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "时间范围验证":
                    //strReturn = "ValidateDateRange(htInputParameter[\"" + strFieldName + "\"], " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    //strReturn = "ValidateDateRange(appData." + strFieldName + ".ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    strReturn = "ValidateDateRange(ViewState[\"" + strFieldName + "\"].ToString(), " + strDataValidateParameterOne + ", " + strDataValidateParameterTwo + ")";
                    break;
                case "布尔值格式验证":
                    //strReturn = "ValidateBooleanFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateBooleanFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateBooleanFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "Email格式验证":
                    //strReturn = "ValidateEmailFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateEmailFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateEmailFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "ObjectID格式验证":
                    //strReturn = "ValidateUniqueIdentifierFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUniqueIdentifierFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateUniqueIdentifierFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "电话号码格式验证":
                    //strReturn = "ValidateTelFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateTelFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateTelFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "文件名格式验证":
                    //strReturn = "ValidateFileNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateFileNameFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateFileNameFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "用户名格式验证":
                    //strReturn = "ValidateUserNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUserNameFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateUserNameFormat(ViewState[\"" + strFieldName + "\"].ToString())";
                    break;
                case "RICH多选框验证":
                    //strReturn = "ValidateUserNameFormat(htInputParameter[\"" + strFieldName + "\"])";
                    //strReturn = "ValidateUserNameFormat(appData." + strFieldName + ".ToString())";
                    strReturn = "ValidateStringFormat(ViewState[\"" + strFieldName + "Value\"].ToString())";
                    break;
                case "数据库图片大小验证":
                    strReturn = "";
                    break;
            }
            return strReturn;
        }

        private string GetDataValidateTypeMessage(string strDataValidateType)
        {
            string strReturn = string.Empty;
            switch (strDataValidateType)
            {
                case "空验证":
                    strReturn = "HINT_MSGID_0002";
                    break;
                case "字符串格式验证":
                    strReturn = "ERR_MSGID_0023";
                    break;
                case "字符串长度验证":
                    strReturn = "ERR_MSGID_0023";
                    break;
                case "字符串长度范围验证":
                    strReturn = "HINT_MSGID_0004";
                    break;
                case "数字格式验证":
                    strReturn = "HINT_MSGID_0003";
                    break;
                case "数字长度验证":
                    strReturn = "HINT_MSGID_0009";
                    break;
                case "数字长度范围验证":
                    strReturn = "HINT_MSGID_0004";
                    break;
                case "数字范围验证":
                    strReturn = "HINT_MSGID_0008";
                    break;
                case "时间格式验证":
                    strReturn = "HINT_MSGID_0005";
                    break;
                case "时间范围验证":
                    strReturn = "HINT_MSGID_0007";
                    break;
                case "布尔值格式验证":
                    strReturn = "HINT_MSGID_0006";
                    break;
                case "Email格式验证":
                    strReturn = "ERR_MSGID_0023";
                    break;
                case "ObjectID格式验证":
                    strReturn = "HINT_MSGID_0012";
                    break;
                case "电话号码格式验证":
                    strReturn = "HINT_MSGID_0013";
                    break;
                case "文件名格式验证":
                    strReturn = "ERR_MSGID_0023";
                    break;
                case "用户名格式验证":
                    strReturn = "HINT_MSGID_0010";
                    break;
                case "数据库图片大小验证":
                    strReturn = "HINT_MSGID_0018";
                    break;
            }
            return strReturn;
        }

        private string GetCSharpDataTypeString(string strDataTypeName)
        {
            string strReturn;
            switch (strDataTypeName.ToLower())
            {
                case "char":
                case "varchar":
                case "text":
                case "ntext":
                case "nchar":
                case "nvarchar":
                    strReturn = "String";
                    break;
                case "datetime":
                case "smalldatetime":
                    strReturn = "DateTime";
                    break;
                case "tinyint":
                    strReturn = "Byte";
                    break;
                case "smallint":
                    strReturn = "Int16";
                    break;
                case "int":
                    strReturn = "Int32";
                    break;
                case "bigint":
                    strReturn = "Int64";
                    break;
                case "real":
                    strReturn = "Single";
                    break;
                case "money":
                    strReturn = "Money";
                    break;
                case "float":
                    strReturn = "Double";
                    break;
                case "decimal":
                case "numeric":
                    strReturn = "Decimal";
                    break;
                case "bit":
                    strReturn = "Boolean";
                    break;
                case "uniqueidentifier":
                    strReturn = "String";
                    break;
                case "timestamp":
                    strReturn = "Object";
                    break;
                case "image":
                case "binary":
                case "varbinary":
                    strReturn = "Byte[]";
                    break;
                case "sysname":
                    strReturn = "String";
                    break;
                case "sql_variant":
                    strReturn = "Object";
                    break;
                default:
                    strReturn = "String";
                    break;
            }
            return strReturn;
        }

        private string GetDBDataTypeString(string strDataTypeName)
        {
            string strReturn = string.Empty;
            switch (strDataTypeName.ToLower())
            {
                case "image":
                    strReturn = "Image";
                    break;
                case "binary":
                    strReturn = "Binary";
                    break;
                case "xml":
                    strReturn = "Xml";
                    break;
                case "char":
                    strReturn = "Char";
                    break;
                case "varchar":
                    strReturn = "VarChar";
                    break;
                case "text":
                    strReturn = "Text";
                    break;
                case "ntext":
                    strReturn = "NText";
                    break;
                case "nchar":
                    strReturn = "NChar";
                    break;
                case "nvarchar":
                    strReturn = "NVarChar";
                    break;
                case "datetime":
                    strReturn = "DateTime";
                    break;
                case "smalldatetime":
                    strReturn = "SmallDateTime";
                    break;
                case "tinyint":
                    strReturn = "TinyInt";
                    break;
                case "smallint":
                    strReturn = "SmallInt";
                    break;
                case "int":
                    strReturn = "Int";
                    break;
                case "bigint":
                    strReturn = "BigInt";
                    break;
                case "real":
                    strReturn = "Real";
                    break;
                case "money":
                    strReturn = "Money";
                    break;
                case "smallmoney":
                    strReturn = "SmallMoney";
                    break;
                case "float":
                    strReturn = "Float";
                    break;
                case "decimal":
                case "numeric":
                    strReturn = "Decimal";
                    break;
                case "bit":
                    strReturn = "Bit";
                    break;
                case "uniqueidentifier":
                    strReturn = "UniqueIdentifier";
                    break;
                case "timestamp":
                    strReturn = "Timestamp";
                    break;
                case "udt":
                    strReturn = "Udt";
                    break;
                case "variant":
                    strReturn = "Variant";
                    break;
                default:
                    strReturn = strDataTypeName;
                    break;
            }
            return strReturn;
        }

        private bool ValidateDataTypeIsString(string strDataTypeName)
        {
            bool boolReturn;
            switch (strDataTypeName.ToLower())
            {
                case "char":
                case "varchar":
                case "text":
                case "ntext":
                case "nchar":
                case "nvarchar":
                case "uniqueidentifier":
                    boolReturn = true;
                    break;
                default:
                    boolReturn = false;
                    break;
            }
            return boolReturn;
        }

        private string GetDataSize(string strDataTypeName, object intDataSize)
        {
            string strReturn;
            switch (strDataTypeName.ToLower())
            {
                case "char":
                case "varchar":
                    strReturn = "(" + intDataSize.ToString() + ")";
                    break;
                case "nchar":
                case "nvarchar":
                    strReturn = "(" + ((int)intDataSize / 2).ToString() + ")";
                    break;
                default:
                    strReturn = "";
                    break;
            }
            return strReturn;
        }

        private string GetDataTypeSelect(string strDataTypeName, object intDataSize)
        {
            string strReturn;
            switch (strDataTypeName.ToLower())
            {
                case "char":
                    strReturn = strDataTypeName + "(" + intDataSize.ToString() + ")";
                    break;
                case "varchar":
                    strReturn = strDataTypeName + "(" + intDataSize.ToString() + ")";
                    break;
                case "text":
                    strReturn = "varchar" + "(50)";
                    break;
                case "ntext":
                    strReturn = "nvarchar" + "(100)";
                    break;
                case "nchar":
                    strReturn = strDataTypeName + "(" + ((int)intDataSize / 2).ToString() + ")";
                    break;
                case "nvarchar":
                    strReturn = strDataTypeName + "(" + ((int)intDataSize / 2).ToString() + ")";
                    break;
                case "uniqueidentifier":
                    strReturn = "nvarchar" + "(50)";
                    break;
                default:
                    strReturn = strDataTypeName;
                    break;
            }
            return strReturn;
        }

        private string GetDataTypeUpdate(string strDataTypeName, object intDataSize)
        {
            string strReturn;
            switch (strDataTypeName.ToLower())
            {
                case "char":
                    strReturn = strDataTypeName + "(" + intDataSize.ToString() + ")";
                    break;
                case "varchar":
                    strReturn = strDataTypeName + "(" + intDataSize.ToString() + ")";
                    break;
                case "nchar":
                    strReturn = strDataTypeName + "(" + ((int)intDataSize / 2).ToString() + ")";
                    break;
                case "nvarchar":
                    strReturn = strDataTypeName + "(" + ((int)intDataSize / 2).ToString() + ")";
                    break;
                case "uniqueidentifier":
                    strReturn = "nvarchar" + "(50)";
                    break;
                default:
                    strReturn = strDataTypeName;
                    break;
            }
            return strReturn;
        }

        private string GetDefaultValue(Object strDefaultValue)
        {
            string strReturn;
            if (strDefaultValue == DBNull.Value)
            {
                strReturn = "NULL";
            }
            else if ((string)strDefaultValue == null)
            {
                strReturn = "NULL";
            }
            else if ((string)strDefaultValue == "")
            {
                strReturn = "NULL";
            }
            else
            {
                strReturn = RemoveOuterSymbol((string)strDefaultValue);
            }
            return strReturn;
        }

        private string RemoveOuterSymbol(string strSource)
        {
            string strReturn;
            strReturn = strSource.Substring(1, strSource.Length - 2);
            return strReturn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GenerateCodeForm generateCodeForm = new GenerateCodeForm(lbDatabaseObject.SelectedValue + "Config" + ".xml");
            generateCodeForm.ShowDialog(this);
        }

        private void OpenConnectionDialog()
        {
            DataConnectionDialog dialog = new DataConnectionDialog();

            //添加数据源列表，可以向窗口中添加自己程序所需要的数据源类型
            dialog.DataSources.Add(DataSource.SqlDataSource);
            dialog.DataSources.Add(DataSource.OdbcDataSource);

            dialog.SelectedDataSource = DataSource.SqlDataSource;
            dialog.SelectedDataProvider = DataProvider.SqlDataProvider;

            //只能够通过DataConnectionDialog类的静态方法Show出对话框
            //不同使用dialog.Show()或dialog.ShowDialog()来呈现对话框

            dialog.ConnectionString = txtConnectionString.Text;
            if (DataConnectionDialog.Show(dialog, this) == DialogResult.OK)
            {
                txtConnectionString.Text = dialog.ConnectionString;
            }
        }

        private void btnConnectionConfig_Click(object sender, EventArgs e)
        {
            OpenConnectionDialog();
        }

        private void btnSelectCodeFilePath_Click(object sender, EventArgs e)
        {
            DataModelApplication.Common.FolderDialog folderDialog = new DataModelApplication.Common.FolderDialog();
            folderDialog.DisplayDialog("选择生成代码文件保存路径");
            if (Directory.Exists(folderDialog.Path) == true)
            {
                txtCodeFilePath.Text = folderDialog.Path;
            }
        }

        private void btnSelectTemplateFilePath_Click(object sender, EventArgs e)
        {
            DataModelApplication.Common.FolderDialog folderDialog = new DataModelApplication.Common.FolderDialog();
            folderDialog.DisplayDialog("选择代码模版所在路径");
            if (Directory.Exists(folderDialog.Path) == true)
            {
                txtTemplateFilePath.Text = folderDialog.Path;
                GetTemplateList(txtTemplateFilePath.Text);
            }
        }

        private void GetTemplateList(string strFilePath)
        {
            if (Directory.Exists(strFilePath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(strFilePath);
                lbTemplateList.Items.Clear();
                foreach (FileInfo fileInfo in directoryInfo.GetFiles("*.xsl"))
                {
                    lbTemplateList.Items.Add(fileInfo.FullName.Substring(fileInfo.FullName.LastIndexOf("\\") + 1));
                }

                for (int i = 0; i < lbTemplateList.Items.Count; i++)
                {
                    lbTemplateList.SelectedIndex = i;
                }
            }
            else
            {
                MessageBox.Show("指定模版路径不存在。");
            }
        }

        private void btnListTemplate_Click(object sender, EventArgs e)
        {
            GetTemplateList(txtTemplateFilePath.Text);
        }

        private void btnAutoGenerateCode_Click(object sender, EventArgs e)
        {
            string strTemplateFileName = string.Empty;
            string strTableName = string.Empty;
            DateTime datetimeBeginGenerate = new DateTime();
            DateTime datetimeEndGenerate = new DateTime();
            try
            {
                // 打开代码文件生成过程记录窗口
                LogDialogBox logDialogBox = new LogDialogBox();
                logDialogBox.Show(this);
                // 进度信息
                int intAllItem = lbDatabaseObject.SelectedItems.Count * lbTemplateList.SelectedItems.Count;
                float floatCount = 0;
                float floatRate = 0;
                datetimeBeginGenerate = DateTime.Now;
                logDialogBox.txtAutoGenerateLog.AppendText("生成开始时间：" + datetimeBeginGenerate.ToString() + "\r\n");
                logDialogBox.txtAutoGenerateLog.Update();
                logDialogBox.txtAutoGenerateLog.ScrollToCaret();
                foreach (object objSelectedTable in lbDatabaseObject.SelectedItems)
                {
                    // 保存生成表名
                    strTableName = ((System.Data.DataRowView)(objSelectedTable)).Row[0].ToString();
                    logDialogBox.txtAutoGenerateLog.AppendText("-------------------------------------------------\r\n");
                    logDialogBox.txtAutoGenerateLog.AppendText(strTableName + "表的代码文件生成开始。\r\n");
                    logDialogBox.txtAutoGenerateLog.Update();
                    logDialogBox.txtAutoGenerateLog.ScrollToCaret();
                    Common.XMLFileLibrary xmlFileLibrary = new DataModelApplication.Common.XMLFileLibrary();
                    xmlFileLibrary.FileName = Directory.GetCurrentDirectory() + ConfigPath + @"\" + strTableName + "Config" + ".xml";
                    // 创建Xsl实例
                    XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
                    // 创建XmlDocment类的实例
                    XmlDocument xmlDocument = new XmlDocument();
                    // 把指定文件读入内存
                    xmlDocument.Load(xmlFileLibrary.FileName);
                    // 创建代码文件目录
                    CommonFileLibrary.CreateDirectory(xmlFileLibrary.ReadXMLNode("/NewDataSet/CodeFilePath") + @"\" + (string)strTableName);
                    // 遍历选择代码模版文件
                    foreach (object objSelectedItem in lbTemplateList.SelectedItems)
                    {
                        // 计算进度信息
                        floatCount++;
                        floatRate = floatCount / intAllItem;
                        // 保存代码模版文件名
                        strTemplateFileName = objSelectedItem.ToString();
                        string strFileContent = string.Empty;
                        strFileContent = DataModelApplication.Common.XMLFileLibrary.ToSourceCode(
                                xmlFileLibrary.ReadXMLNode("/NewDataSet/TemplateFilePath") + "\\" + strTemplateFileName
                                , xmlDocument.InnerXml);

                        // 保存到文件
                        CommonFileLibrary.CreateFile(xmlFileLibrary.ReadXMLNode("/NewDataSet/CodeFilePath") + @"\" + strTableName + @"\"
                            , strTableName + CommonFileLibrary.GetFileName(strTemplateFileName)
                            , strFileContent);
                        //MessageBox.Show(objSelectedItem.ToString());
                        logDialogBox.Update();
                        logDialogBox.txtAutoGenerateLog.AppendText(strTableName + CommonFileLibrary.GetFileName(strTemplateFileName) + "文件生成完毕。完成" + Convert.ToInt16(floatRate * 100) + "%\r\n");
                        logDialogBox.txtAutoGenerateLog.Update();
                        logDialogBox.txtAutoGenerateLog.ScrollToCaret();
                    }
                    logDialogBox.txtAutoGenerateLog.AppendText(strTableName + "表的代码文件生成结束。\r\n");
                    logDialogBox.txtAutoGenerateLog.AppendText("-------------------------------------------------\r\n");
                    logDialogBox.txtAutoGenerateLog.AppendText("\r\n");
                    logDialogBox.txtAutoGenerateLog.Update();
                    logDialogBox.txtAutoGenerateLog.ScrollToCaret();
                }
                datetimeEndGenerate = DateTime.Now;
                logDialogBox.txtAutoGenerateLog.AppendText("生成结束时间：" + datetimeEndGenerate.ToString() + "\r\n");
                logDialogBox.txtAutoGenerateLog.AppendText("总共花费时间：" + ((TimeSpan)(datetimeEndGenerate - datetimeBeginGenerate)).TotalSeconds.ToString() + "秒\r\n");
                logDialogBox.txtAutoGenerateLog.AppendText("总共生成" + Convert.ToInt32(floatCount).ToString() + "个代码文件。\r\n");
                logDialogBox.txtAutoGenerateLog.Update();
                logDialogBox.txtAutoGenerateLog.ScrollToCaret();
                logDialogBox.txtAutoGenerateLog.AppendText("全部代码生成完毕，请到相应目录下查看。\r\n");
                logDialogBox.txtAutoGenerateLog.Update();
                logDialogBox.txtAutoGenerateLog.ScrollToCaret();
            }
            catch (Exception ex)
            {

                MessageBox.Show("请检查模版文件" + strTemplateFileName + "格式是否正确。\r\n 错误如下：\r\n" + ex.InnerException);
            }
        }

        private void btnCustomOperateConfig_Click(object sender, EventArgs e)
        {
            // 创建自定义操作配置窗口
            CustomOperateConfigForm customOperateConfigForm = new CustomOperateConfigForm();
            // 将自定义操作配置信息传入自定义操作配置窗口
            customOperateConfigForm.CustomOperateConfig = dsCustomOperateConfig;
            // 打开自定义操作配置窗口
            customOperateConfigForm.ShowDialog(this);
            if (customOperateConfigForm.SaveFlag == true)
            {
                // 将自定义操作配置信息传出自定义操作配置窗口
                dsCustomOperateConfig = customOperateConfigForm.CustomOperateConfig;
            }
        }

        private void SaveConfigFile(string strConfigFileName)
        {
            Common.CommonFileLibrary commonFileLibrary = new Common.CommonFileLibrary();
            commonFileLibrary.FileName = strConfigFileName;
            commonFileLibrary.XmlDataTable.TableName = "RecordInfo";
            commonFileLibrary.XmlDataGridView = dgvColumn;
            //commonFileLibrary.SaveDataTableToXml();
            commonFileLibrary.ConvertDataGridViewToDataTable();
                
            // 保存自定义操作配置信息到配置文件中    
            commonFileLibrary.XmlDataTable.TableName = "RecordInfo";
            dsCustomOperateConfig.TableName = "CustomOperateConfig";
            commonFileLibrary.XmlDataSet.Tables.Add(commonFileLibrary.XmlDataTable.Copy());
            commonFileLibrary.XmlDataSet.Tables.Add(dsCustomOperateConfig.Copy());

            dsCustomConditionConfig.TableName = "CustomConditionConfig";
            commonFileLibrary.XmlDataSet.Tables.Add(dsCustomConditionConfig.Copy());
            commonFileLibrary.SaveDataSetToXml();

            dsCustomPermissionConfig.TableName = "CustomPermissionConfig";
            commonFileLibrary.XmlDataSet.Tables.Add(dsCustomPermissionConfig.Copy());
            commonFileLibrary.SaveDataSetToXml();

            dsCustomRelatedTableConfig.TableName = "CustomRelatedTableConfig";
            commonFileLibrary.XmlDataSet.Tables.Add(dsCustomRelatedTableConfig.Copy());
            commonFileLibrary.SaveDataSetToXml();

            dsCustomDisplayFieldConfig.TableName = "CustomDisplayFieldConfig";
            commonFileLibrary.XmlDataSet.Tables.Add(dsCustomDisplayFieldConfig.Copy());
            commonFileLibrary.SaveDataSetToXml();

            dsCustomPermissionFieldConfig.TableName = "CustomPermissionFieldConfig";
            commonFileLibrary.XmlDataSet.Tables.Add(dsCustomPermissionFieldConfig.Copy());
            commonFileLibrary.SaveDataSetToXml();
            //在XML文件中插入一些配置信息
            SqlConnection dbConnection = new SqlConnection();
            dbConnection.ConnectionString = txtConnectionString.Text;
            dbConnection.Open();
            Common.XMLFileLibrary xmlFileLibrary = new DataModelApplication.Common.XMLFileLibrary();
            xmlFileLibrary.FileName = saveTableConfigFileDialog.FileName;
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "DataBaseName", dbConnection.Database);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "TableName", (string)lbDatabaseObject.SelectedValue);
                
            // 2009.09.14添加开始
            // 读取数据库OWNER
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "TableOnwer", GetTableOwner(txtConnectionString.Text, (string)lbDatabaseObject.SelectedValue));
            // 2009.09.14添加结束
                
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "NameSpace", txtNameSpace.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "TableRemark", txtTableRemark.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "PurviewPrefix", txtPurviewPrefix.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "TemplateFilePath", txtTemplateFilePath.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ProjectPath", txtProjectPath.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "CodeFilePath", txtCodeFilePath.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ConnectionString", txtConnectionString.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateField", txtAutoGenerateField.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateNumberLength", txtAutoGenerateNumberLength.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGeneratePrefix", txtAutoGeneratePrefix.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AllowAutoGenerateID", chkAllowAutoGenerateID.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateDay", chkAutoGenerateDay.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateHour", chkAutoGenerateHour.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateMinute", chkAutoGenerateMinute.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateMonth", chkAutoGenerateMonth.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateMSecond", chkAutoGenerateMSecond.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateSecond", chkAutoGenerateSecond.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateYear", chkAutoGenerateYear.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateOrder", chkAutoGenerateOrder.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "AutoGenerateIncludeDateTime", chkAutoGenerateIncludeDateTime.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "Sort", chkSort.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "SortField", txtSortField.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "TitleField", txtTitleField.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "NoTableBorder", chkNoTableBorder.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ExistPDFPageHeader", chkExistPDFPageHeader.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ExistPDFPageFooter", chkExistPDFPageFooter.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ExistPDFTableTitle", chkExistPDFTableTitle.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "PDFPageHeader", txtPDFPageHeader.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "PDFPageFooter", txtPDFPageFooter.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "PDFTableTitle", txtPDFTableTitle.Text);

            xmlFileLibrary.CreateXMLNode("/NewDataSet", "IsPDFCustomTitle", chkIsPDFCustomTitle.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "PDFCustomTitleReadField", txtPDFCustomTitleReadField.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "PDFCustomTitle", txtPDFCustomTitle.Text);

            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ImportFromDoc", chkImportFromDoc.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ImportFromDataSet", chkImportFromDataSet.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ImportDataSetStartLineNum", txtImportDataSetStartLineNum.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ExportToDocumentTemplate", chkExportToDocumentTemplate.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "ExportToPDF", chkExportToPDF.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "CopyItem", chkCopyItem.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "WebDetailPage", chkWebDetailPage.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "UseFilterReport", chkUseFilterReport.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet", "MutilInsert", chkMutilInsert.Checked.ToString().ToLower());

            xmlFileLibrary.CreateXMLNode("/NewDataSet", "GetValue", "");
            xmlFileLibrary.CreateXMLNode("/NewDataSet/GetValue", "GetValueTextField", txtGetValueTextField.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet/GetValue", "GetValueValueField", txtGetValueValueField.Text);
            xmlFileLibrary.CreateXMLNode("/NewDataSet/GetValue", "GetValue", chkGetValue.Checked.ToString().ToLower());
            xmlFileLibrary.CreateXMLNode("/NewDataSet/GetValue", "GetValueByKey", chkGetValueByKey.Checked.ToString().ToLower());
            if (rbTable.Checked == true)
            {
                xmlFileLibrary.CreateXMLNode("/NewDataSet", "ConnectionType", "Table");
            }
            else if (rbView.Checked == true)
            {
                xmlFileLibrary.CreateXMLNode("/NewDataSet", "ConnectionType", "View");
            }
            else if (rbProcedure.Checked == true)
            {
                xmlFileLibrary.CreateXMLNode("/NewDataSet", "ConnectionType", "Procedure");
            }
            dbConnection.Close();
        }

        // 得到数据库表OWNER
        private string GetTableOwner(string strConnectionString, string strTableName)
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter();
            StringBuilder sbSqlText = new StringBuilder(string.Empty);
            DataTable dtReturn = new DataTable();
            string strDatabaseName = string.Empty;
            StringBuilder strReturn = new StringBuilder(string.Empty);
            try
            {
                dbConnection.ConnectionString = strConnectionString;
                dbConnection.Open();
                strDatabaseName = dbConnection.Database;

                sbSqlText.Append("SELECT su.name AS TableOwner FROM");
                sbSqlText.Append(" sysobjects so JOIN sysusers su");
                sbSqlText.Append(" ON so.uid = su.uid");
                sbSqlText.Append(" WHERE so.name LIKE '" + strTableName + "'");
                // sbSqlText.Append(" AND xtype='U'");
                dbCommand.Connection = dbConnection;
                dbCommand.CommandType = CommandType.Text;
                dbCommand.CommandText = sbSqlText.ToString();
                dbDataAdapter.SelectCommand = dbCommand;
                dbDataAdapter.Fill(dtReturn);
                strReturn.Append(dtReturn.Rows[0]["TableOwner"]);
                return strReturn.ToString();
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private void LoadConfigFile(string strConfigFileName)
        {
            // 读取单个变量
            Common.XMLFileLibrary xmlFileLibrary = new DataModelApplication.Common.XMLFileLibrary();
            xmlFileLibrary.FileName = strConfigFileName;
            txtNameSpace.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/NameSpace");
            txtTableRemark.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/TableRemark");
            txtPurviewPrefix.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/PurviewPrefix");
            txtTemplateFilePath.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/TemplateFilePath");
            txtProjectPath.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/ProjectPath");
            txtCodeFilePath.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/CodeFilePath");
            txtConnectionString.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/ConnectionString");
            txtAutoGenerateField.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateField");
            txtAutoGenerateNumberLength.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateNumberLength");
            txtAutoGeneratePrefix.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGeneratePrefix");
            chkAllowAutoGenerateID.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AllowAutoGenerateID") == "true" ? "true" : "false");
            chkAutoGenerateDay.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateDay") == "true" ? "true" : "false");
            chkAutoGenerateHour.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateHour") == "true" ? "true" : "false");
            chkAutoGenerateMinute.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateMinute") == "true" ? "true" : "false");
            chkAutoGenerateMonth.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateMonth") == "true" ? "true" : "false");
            chkAutoGenerateMSecond.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateMSecond") == "true" ? "true" : "false");
            chkAutoGenerateSecond.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateSecond") == "true" ? "true" : "false");
            chkAutoGenerateYear.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateYear") == "true" ? "true" : "false");
            chkAutoGenerateOrder.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateOrder") == "true" ? "true" : "false");
            chkAutoGenerateIncludeDateTime.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/AutoGenerateIncludeDateTime") == "true" ? "true" : "false");
            chkSort.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/Sort") == "true" ? "true" : "false");

            chkNoTableBorder.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/NoTableBorder") == "true" ? "true" : "false");
            chkExistPDFPageHeader.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ExistPDFPageHeader") == "true" ? "true" : "false");
            chkExistPDFPageFooter.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ExistPDFPageFooter") == "true" ? "true" : "false");
            chkExistPDFTableTitle.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ExistPDFTableTitle") == "true" ? "true" : "false");
            txtPDFPageHeader.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/PDFPageHeader");
            txtPDFPageFooter.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/PDFPageFooter");
            txtPDFTableTitle.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/PDFTableTitle");

            chkIsPDFCustomTitle.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/IsPDFCustomTitle") == "true" ? "true" : "false");
            txtPDFCustomTitleReadField.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/PDFCustomTitleReadField");
            txtPDFCustomTitle.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/PDFCustomTitle");

            chkImportFromDoc.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ImportFromDoc") == "true" ? "true" : "false");
            chkImportFromDataSet.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ImportFromDataSet") == "true" ? "true" : "false");
            txtImportDataSetStartLineNum.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/ImportDataSetStartLineNum");
            chkExportToDocumentTemplate.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ExportToDocumentTemplate") == "true" ? "true" : "false");
            chkExportToPDF.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/ExportToPDF") == "true" ? "true" : "false");
            chkCopyItem.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/CopyItem") == "true" ? "true" : "false");
            chkWebDetailPage.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/WebDetailPage") == "true" ? "true" : "false");
            chkUseFilterReport.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/UseFilterReport") == "true" ? "true" : "false");
            chkMutilInsert.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/MutilInsert") == "true" ? "true" : "false");

            txtSortField.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/SortField");
            txtTitleField.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/TitleField");

            txtGetValueTextField.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/GetValue/GetValueTextField");
            txtGetValueValueField.Text = xmlFileLibrary.ReadXMLNode("/NewDataSet/GetValue/GetValueValueField");
            chkGetValue.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/GetValue/GetValue") == "true" ? "true" : "false");
            chkGetValueByKey.Checked = Convert.ToBoolean(xmlFileLibrary.ReadXMLNode("/NewDataSet/GetValue/GetValueByKey") == "true" ? "true" : "false");

            switch (xmlFileLibrary.ReadXMLNode("/NewDataSet/ConnectionType"))
            {
                case "Table":
                    rbTable.Checked = true;
                    break;
                case "View":
                    rbView.Checked = true;
                    break;
                case "Procedure":
                    rbProcedure.Checked = true;
                    break;
                default:
                    rbTable.Checked = true;
                    break;
            }

            if (ValidateConnection(txtConnectionString.Text) == true)
            {
                if (rbTable.Checked == true)
                {
                    bool boolIsTableOpen = false;
                    foreach (object objItem in lbDatabaseObject.Items)
                    {
                        if (((System.Data.DataRowView)(objItem)).Row[0].ToString() == xmlFileLibrary.ReadXMLNode("/NewDataSet/TableName"))
                        {
                            boolIsTableOpen = true;
                            break;
                        }
                    }
                    if (boolIsTableOpen == false)
                    {
                        lbDatabaseObject.DataSource = GetDatabaseObject(txtConnectionString.Text, "Table");
                    }
                    if (lbDatabaseObject.Items.Count > 0)
                    {
                        lbDatabaseObject.DisplayMember = "name";
                        lbDatabaseObject.ValueMember = "name";
                        lbDatabaseObject.SelectedValue = xmlFileLibrary.ReadXMLNode("/NewDataSet/TableName");
                    }
                    dgvColumn.DataSource = GetColumnInfo(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                    dgvColumn.Columns["FieldName"].DataPropertyName = "Name";
                    dgvColumn.Columns["IsNull"].DataPropertyName = "IsNull";
                    dgvColumn.Columns["DBType"].DataPropertyName = "DataTypeName";
                    dgvColumn.Columns["DataSize"].DataPropertyName = "DataSize";
                    dgvColumn.Columns["DefaultValue"].DataPropertyName = "DefaultValue";
                    dgvColumn.Columns["FieldRemark"].DataPropertyName = "FieldRemark";
                    dgvColumn.Columns["IsPrimaryKey"].DataPropertyName = "IsPrimaryKey";
                    dgvColumn.Columns["OrderID"].DataPropertyName = "OrderID";
                    dgvColumn.Columns["IsUse"].DataPropertyName = "IsUse";
                    dgvColumn.Columns["IsAdd"].DataPropertyName = "IsAdd";
                    dgvColumn.Columns["IsModify"].DataPropertyName = "IsModify";
                    dgvColumn.Columns["IsList"].DataPropertyName = "IsList";
                    dgvColumn.Columns["IsSearch"].DataPropertyName = "IsSearch";
                    dgvColumn.Columns["IsShowDetail"].DataPropertyName = "IsShowDetail";
                    dgvColumn.Columns["ControlType"].DataPropertyName = "ControlType";
                    dgvColumn.Columns["DataValidateType"].DataPropertyName = "DataValidateType";
                    dgvColumn.Columns["DataValidateParameterOne"].DataPropertyName = "DataValidateParameterOne";
                    dgvColumn.Columns["DataValidateParameterTwo"].DataPropertyName = "DataValidateParameterTwo";
                    dgvColumn.Columns["TextAlign"].DataPropertyName = "TextAlign";
                    dgvColumn.Columns["DisplayFormatString"].DataPropertyName = "DisplayFormatString";
                    // 从配置文件中读取自定义操作配置信息
                    Common.CommonFileLibrary commonFileLibrary = new Common.CommonFileLibrary();
                    commonFileLibrary.FileName = strConfigFileName;
                    commonFileLibrary.XmlDataTable.TableName = "RecordInfo";
                    commonFileLibrary.XmlDataGridView = dgvColumn;
                    commonFileLibrary.LoadXmlToDataSet();
                    try
                    {
                        dsCustomOperateConfig = commonFileLibrary.XmlDataSet.Tables["CustomOperateConfig"].Copy();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        dsCustomConditionConfig = commonFileLibrary.XmlDataSet.Tables["CustomConditionConfig"].Copy();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        dsCustomPermissionConfig = commonFileLibrary.XmlDataSet.Tables["CustomPermissionConfig"].Copy();
                    }
                    catch (Exception)
                    {

                    }

                    try
                    {
                        dsCustomRelatedTableConfig = commonFileLibrary.XmlDataSet.Tables["CustomRelatedTableConfig"].Copy();
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        dsCustomDisplayFieldConfig = commonFileLibrary.XmlDataSet.Tables["CustomDisplayFieldConfig"].Copy();
                    }
                    catch (Exception)
                    {

                    }
                    try
                    {
                        dsCustomPermissionFieldConfig = commonFileLibrary.XmlDataSet.Tables["CustomPermissionFieldConfig"].Copy();
                    }
                    catch (Exception)
                    {

                    }
                    commonFileLibrary.XmlDataTable.TableName = "RecordInfo";
                    commonFileLibrary.XmlDataGridView = dgvColumn;
                    commonFileLibrary.LoadXmlToDataTable();
                    dgvColumn = commonFileLibrary.XmlDataGridView;
                }
                else if (rbView.Checked == true)
                {
                    bool boolIsTableOpen = false;
                    foreach (object objItem in lbDatabaseObject.Items)
                    {
                        if (((System.Data.DataRowView)(objItem)).Row[0].ToString() == xmlFileLibrary.ReadXMLNode("/NewDataSet/TableName"))
                        {
                            boolIsTableOpen = true;
                            break;
                        }
                    }
                    if (boolIsTableOpen == false)
                    {
                        lbDatabaseObject.DataSource = GetDatabaseObject(txtConnectionString.Text, "View");
                    }
                    if (lbDatabaseObject.Items.Count > 0)
                    {
                        lbDatabaseObject.DisplayMember = "name";
                        lbDatabaseObject.ValueMember = "name";
                        lbDatabaseObject.SelectedValue = xmlFileLibrary.ReadXMLNode("/NewDataSet/TableName");
                    }
                    dgvColumn.DataSource = GetColumnInfo(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                    dgvColumn.Columns["FieldName"].DataPropertyName = "Name";
                    dgvColumn.Columns["IsNull"].DataPropertyName = "IsNull";
                    dgvColumn.Columns["DBType"].DataPropertyName = "DataTypeName";
                    dgvColumn.Columns["DataSize"].DataPropertyName = "DataSize";
                    dgvColumn.Columns["DefaultValue"].DataPropertyName = "DefaultValue";
                    dgvColumn.Columns["FieldRemark"].DataPropertyName = "FieldRemark";
                    dgvColumn.Columns["IsPrimaryKey"].DataPropertyName = "IsPrimaryKey";
                    dgvColumn.Columns["OrderID"].DataPropertyName = "OrderID";
                    dgvColumn.Columns["IsUse"].DataPropertyName = "IsUse";
                    dgvColumn.Columns["IsAdd"].DataPropertyName = "IsAdd";
                    dgvColumn.Columns["IsModify"].DataPropertyName = "IsModify";
                    dgvColumn.Columns["IsList"].DataPropertyName = "IsList";
                    dgvColumn.Columns["IsSearch"].DataPropertyName = "IsSearch";
                    dgvColumn.Columns["IsShowDetail"].DataPropertyName = "IsShowDetail";
                    dgvColumn.Columns["ControlType"].DataPropertyName = "ControlType";
                    dgvColumn.Columns["DataValidateType"].DataPropertyName = "DataValidateType";
                    dgvColumn.Columns["DataValidateParameterOne"].DataPropertyName = "DataValidateParameterOne";
                    dgvColumn.Columns["DataValidateParameterTwo"].DataPropertyName = "DataValidateParameterTwo";
                    dgvColumn.Columns["TextAlign"].DataPropertyName = "TextAlign";
                    dgvColumn.Columns["DisplayFormatString"].DataPropertyName = "DisplayFormatString";
                    Common.CommonFileLibrary commonFileLibrary = new Common.CommonFileLibrary();
                    commonFileLibrary.FileName = strConfigFileName;
                    commonFileLibrary.XmlDataTable.TableName = "RecordInfo";
                    commonFileLibrary.XmlDataGridView = dgvColumn;
                    commonFileLibrary.LoadXmlToDataTable();
                    dgvColumn = commonFileLibrary.XmlDataGridView;

                }
                else if (rbProcedure.Checked)
                {

                }
                else
                {
                    MessageBox.Show("请选择要列表数据库对象。");
                }

                foreach (DataGridViewRow dgvrTemp in dgvColumn.Rows)
                {
                    if (dgvrTemp.Cells["DataValidateParameterOne"].Value == DBNull.Value || dgvrTemp.Cells["DataValidateParameterOne"].Value == null || dgvrTemp.Cells["DataValidateParameterOne"].Value.ToString() == "")
                    {
                        dgvrTemp.Cells["DataValidateParameterOne"].Value = "null";
                    }
                    if (dgvrTemp.Cells["DataValidateParameterTwo"].Value == DBNull.Value || dgvrTemp.Cells["DataValidateParameterTwo"].Value == null || dgvrTemp.Cells["DataValidateParameterTwo"].Value.ToString() == "")
                    {
                        dgvrTemp.Cells["DataValidateParameterTwo"].Value = "null";
                    }

                }

                if (lbDatabaseObject.Items.Count > 0)
                {
                    btnAutoGenerateCode.Enabled = true;
                    btnGenerateCode.Enabled = true;
                    btnSaveTableConfig.Enabled = true;
                }
                else
                {
                    btnAutoGenerateCode.Enabled = false;
                    btnGenerateCode.Enabled = false;
                    btnSaveTableConfig.Enabled = false;
                }

                if (chkAutoGenerateIncludeDateTime.Checked == true)
                {
                    chkAutoGenerateDay.Enabled = true;
                    chkAutoGenerateHour.Enabled = true;
                    chkAutoGenerateMinute.Enabled = true;
                    chkAutoGenerateMonth.Enabled = true;
                    chkAutoGenerateMSecond.Enabled = true;
                    chkAutoGenerateSecond.Enabled = true;
                    chkAutoGenerateYear.Enabled = true;
                }
                else
                {
                    chkAutoGenerateDay.Enabled = false;
                    chkAutoGenerateHour.Enabled = false;
                    chkAutoGenerateMinute.Enabled = false;
                    chkAutoGenerateMonth.Enabled = false;
                    chkAutoGenerateMSecond.Enabled = false;
                    chkAutoGenerateSecond.Enabled = false;
                    chkAutoGenerateYear.Enabled = false;
                }
            }
            else
            {
                MessageBox.Show("连接失败，请检查输入连接字符串。");
            }
        }

        private void btnCustomConditionConfig_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建自定义操作配置窗口
                CustomConditionConfigForm CustomConditionConfigForm = new CustomConditionConfigForm();
                // 将自定义操作配置信息传入自定义操作配置窗口
                CustomConditionConfigForm.CustomConditionConfig = dsCustomConditionConfig;
                CustomConditionConfigForm.TemplateDir = new object[lbTemplateList.Items.Count];
                GetTemplateList(txtTemplateFilePath.Text);
                lbTemplateList.Items.CopyTo(CustomConditionConfigForm.TemplateDir, 0);
                CustomConditionConfigForm.FieldName = GetFieldName(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                // 打开自定义操作配置窗口
                CustomConditionConfigForm.ShowDialog(this);
                if (CustomConditionConfigForm.SaveFlag == true)
                {
                    // 将自定义操作配置信息传出自定义操作配置窗口
                    dsCustomConditionConfig = CustomConditionConfigForm.CustomConditionConfig;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("读取信息错误，请检查操作步骤。");
            }
        }


        private object[] GetFieldName(string strConnectionString, string strDatabaseObjectType, string strDatabaseObjectName, string strNameSpace)
        {
            SqlConnection dbConnection = new SqlConnection();
            SqlCommand dbCommand = new SqlCommand();
            SqlDataAdapter dbDataAdapter = new SqlDataAdapter();
            StringBuilder sbSqlText = new StringBuilder(string.Empty);
            DataTable dtReturn = new DataTable();
            string strDatabaseName = string.Empty;
            StringBuilder strReturn = new StringBuilder(string.Empty);

            object[] objReturn;
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
                    sbSqlText.Append("SELECT A.[name] AS [Name], C.[name] AS [DataTypeName], A.[length] AS [DataSize],");
                    sbSqlText.Append(" A.[isoutparam] AS [IsOutParameter], CAST(A.[isnullable] AS bit) AS [IsNull], ");
                    sbSqlText.Append(" D.[text] AS [DefaultValue], A.[typestat],");
                    sbSqlText.Append(" E.[value] AS [FieldRemark],");
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
                    sbSqlText.Append("SELECT A.[name] AS [Name], C.[name] AS [DataTypeName], A.[length] AS [DataSize],");
                    sbSqlText.Append(" A.[isoutparam] AS [IsOutParameter], CAST(A.[isnullable] AS bit) AS [IsNull], ");
                    sbSqlText.Append(" D.[text] AS [DefaultValue], A.[typestat],");
                    sbSqlText.Append(" E.[value] AS [FieldRemark],");
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
                objReturn = new object[dtReturn.Rows.Count];
                for (int i = 0; i < dtReturn.Rows.Count; i++)
                {
                    objReturn[i] = dtReturn.Rows[i]["Name"];
                }
                return objReturn;
            }
            finally
            {
                dbConnection.Close();
            }
        }

        private TreeNode[] GetFileStruct(string strFilePath)
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(strFilePath);
            TreeNode[] node = new TreeNode[directoryInfo.GetDirectories().Length + directoryInfo.GetFiles().Length];
            int i = 0;
            foreach (DirectoryInfo fileInfo in directoryInfo.GetDirectories())
            {
                node[i] = new TreeNode();
                node[i].Text = fileInfo.FullName.Substring(fileInfo.FullName.LastIndexOf("\\") + 1);
                node[i].ImageIndex = 1;
                node[i].SelectedImageIndex = 2;
                node[i].Nodes.AddRange(GetFileStruct(fileInfo.FullName));
                i++;
            }
            foreach (FileInfo fileInfo in directoryInfo.GetFiles())
            {
                node[i] = new TreeNode();
                node[i].Text = fileInfo.FullName.Substring(fileInfo.FullName.LastIndexOf("\\") + 1);
                node[i].ImageIndex = 0;
                node[i].SelectedImageIndex = 0;
                i++;
            }
            return node;
        }


        public void test()
        {
            // 初始化目录树
            tvProject.Nodes.AddRange(GetFileStruct(Directory.GetCurrentDirectory()));

            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataModelForm));
            // tvProject.ImageList = new ImageList();
            // tvProject.ImageList.Images.Add((Icon)resources.GetObject("Default Icon"));
            // tvProject.ImageList.Images.Add((Icon)resources.GetObject("Open Folder"));
            // tvProject.ImageList.Images.Add((Icon)resources.GetObject("Closed Folder"));

            // 属性控件
            propGrid.SelectedObject = new XMLFileLibrary();


            dgvTest.Columns.Clear();
            // 创建XmlDocment类的实例
            xmlDocument = new XmlDocument();
            xmlDocumentDataDict = new XmlDocument();
            // 把指定文件读入内存
            xmlDocument.Load(FileName);
            xmlDocumentDataDict.Load(DataDictFileName);
            // 设置读取XML文件起点
            XmlNode xmlBeginNode = xmlDocument.SelectSingleNode("/Properties/Property");

            XmlNodeList xmlNodeList = xmlDocument.SelectNodes("/Properties/Property");
            foreach (XmlNode node in xmlNodeList)
            {
                DataGridViewColumn dataGridViewColumn;
                switch (node.Attributes["ShowType"].Value)
                {
                    case "TextBox":
                        dataGridViewColumn = new DataGridViewTextBoxColumn();
                        break;
                    case "CheckBox":
                        dataGridViewColumn = new DataGridViewCheckBoxColumn();
                        dataGridViewColumn.ValueType = System.Type.GetType("System.Boolean");
                        break;
                    case "ComboBox":
                        dataGridViewColumn = new DataGridViewComboBoxColumn();
                        if (Convert.ToBoolean(node.Attributes["DataBind"].Value) == true)
                        {
                            XmlNodeList xmlNodeListDataDict = xmlDocumentDataDict.SelectNodes("/DataDicts/DataDict");
                            foreach (XmlNode nodeDataDict in xmlNodeListDataDict)
                            {
                                if (node.Attributes["DataSource"].Value == nodeDataDict.Attributes["Name"].Value)
                                {
                                    foreach (XmlNode nodeDataDictData in nodeDataDict.ChildNodes)
                                    {
                                        if ("Data" == nodeDataDictData.Name)
                                        {
                                            ((DataGridViewComboBoxColumn)dataGridViewColumn).Items.Add(nodeDataDictData.Attributes["Name"].Value);
                                        }
                                    }
                                }
                            }
                        }
                        break;
                    default:
                        dataGridViewColumn = new DataGridViewTextBoxColumn();
                        break;
                }
                if (Convert.ToBoolean(node.Attributes["ReadOnly"].Value) == true)
                {
                    dataGridViewColumn.ReadOnly = true;
                }
                else if (Convert.ToBoolean(node.Attributes["ReadOnly"].Value) == false)
                {
                    dataGridViewColumn.ReadOnly = false;
                }
                if (Convert.ToBoolean(node.Attributes["Frozen"].Value) == true)
                {
                    dataGridViewColumn.Frozen = true;
                }
                else if (Convert.ToBoolean(node.Attributes["Frozen"].Value) == false)
                {
                    dataGridViewColumn.Frozen = false;
                }
                if (Convert.ToBoolean(node.Attributes["Visible"].Value) == true)
                {
                    dataGridViewColumn.Visible = true;
                }
                else if (Convert.ToBoolean(node.Attributes["Visible"].Value) == false)
                {
                    dataGridViewColumn.Visible = false;
                }
                dataGridViewColumn.Name = node.Attributes["Name"].Value;
                dataGridViewColumn.HeaderText = node.Attributes["Remark"].Value;
                dgvTest.Columns.Add(dataGridViewColumn);
            }
        }

        private void menuButtonItem10_Activate(object sender, EventArgs e)
        {
            EditCustomProperty editCustomProperty = new EditCustomProperty();
            editCustomProperty.ShowDialog(this);
        }

        private void menuButtonItem11_Activate(object sender, EventArgs e)
        {
            EditDataDict editDataDict = new EditDataDict();
            editDataDict.ShowDialog(this);
        }

        private void dockControl9_Closing(object sender, CancelEventArgs e)
        {

        }

        private void menuButtonItem12_Activate(object sender, EventArgs e)
        {
            test();
        }

        private void btnCustomRelatedTableConfig_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建自定义操作配置窗口
                CustomRelatedTableConfigForm CustomRelatedTableConfigForm = new CustomRelatedTableConfigForm();
                // 将自定义操作配置信息传入自定义操作配置窗口
                CustomRelatedTableConfigForm.CustomRelatedTableConfig = dsCustomRelatedTableConfig;
                CustomRelatedTableConfigForm.CustomDisplayFieldConfig = dsCustomDisplayFieldConfig;
                CustomRelatedTableConfigForm.TempCustomDisplayFieldConfig = dsTempCustomDisplayFieldConfig;
                CustomRelatedTableConfigForm.ConnectionString = txtConnectionString.Text;
                CustomRelatedTableConfigForm.FieldName = GetFieldName(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                // 打开自定义操作配置窗口
                CustomRelatedTableConfigForm.ShowDialog(this);
                if (CustomRelatedTableConfigForm.SaveFlag == true)
                {
                    // 将自定义操作配置信息传出自定义操作配置窗口
                    dsCustomRelatedTableConfig = CustomRelatedTableConfigForm.CustomRelatedTableConfig;
                    dsCustomDisplayFieldConfig = CustomRelatedTableConfigForm.CustomDisplayFieldConfig;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("读取信息错误，请检查操作步骤。");
            }
        }

        private void buttonItem6_Activate(object sender, EventArgs e)
        {
            DataModelApplication.Common.FolderDialog folderDialog = new DataModelApplication.Common.FolderDialog();
            folderDialog.DisplayDialog("选择工程所在路径");
            if (Directory.Exists(folderDialog.Path) == true)
            {
                txtProjectPath.Text = folderDialog.Path;
            }
        }

        private void btnCustomPermissionConfig_Click(object sender, EventArgs e)
        {
            try
            {
                // 创建自定义操作配置窗口
                CustomPermissionConfigForm CustomPermissionConfigForm = new CustomPermissionConfigForm();
                // 将自定义操作配置信息传入自定义操作配置窗口
                CustomPermissionConfigForm.CustomPermissionConfig = dsCustomPermissionConfig;
                CustomPermissionConfigForm.CustomPermissionFieldConfig = dsCustomPermissionFieldConfig;
                CustomPermissionConfigForm.TempCustomPermissionFieldConfig = dsTempCustomPermissionFieldConfig;
                CustomPermissionConfigForm.TemplateDir = new object[lbTemplateList.Items.Count];
                GetTemplateList(txtTemplateFilePath.Text);
                lbTemplateList.Items.CopyTo(CustomPermissionConfigForm.TemplateDir, 0);
                CustomPermissionConfigForm.FieldName = GetFieldName(txtConnectionString.Text, "Table", lbDatabaseObject.SelectedValue.ToString(), txtNameSpace.Text);
                // 打开自定义操作配置窗口
                CustomPermissionConfigForm.ShowDialog(this);
                if (CustomPermissionConfigForm.SaveFlag == true)
                {
                    // 将自定义操作配置信息传出自定义操作配置窗口
                    dsCustomPermissionConfig = CustomPermissionConfigForm.CustomPermissionConfig;
                    dsCustomPermissionFieldConfig = CustomPermissionConfigForm.CustomPermissionFieldConfig;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("读取信息错误，请检查操作步骤。");
            }
        }
    }
}
