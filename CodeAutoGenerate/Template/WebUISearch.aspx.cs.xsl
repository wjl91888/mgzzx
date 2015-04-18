<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUISearch.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using Telerik.Web.UI;
using RICH.Common;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;
using RICH.Common.BM.FilterReport;
using RICH.Common.Utilities;

public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUISearch : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
{
    #region 定义GridView列索引
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsList"/>
  <xsl:if test="IsList = 'true'">
    static int int<xsl:value-of select="FieldName"/>ColumnIndex;</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
    static int int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex;</xsl:if></xsl:if>
</xsl:for-each>
    #endregion

    protected override void Page_Init(object sender, EventArgs e)
    {
        
        base.Page_Init(sender, e);
    }
    
    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            InitalizeColumnIndex();
            SetMoreSearchItemDisplay(false);
            InitalizeDataBind();
            InitalizeCoupledDataSource();
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsRelatedOperateParam = 'true'">
<xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsRangeSearch = 'true'">
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = (string)Request.QueryString["<xsl:value-of select="FieldName"/>"]; 
            <xsl:value-of select="FieldName"/>Begin.<xsl:value-of select="ControlTypeValueSuffix"/> = (string)Request.QueryString["<xsl:value-of select="FieldName"/>Begin"]; 
            <xsl:value-of select="FieldName"/>End.<xsl:value-of select="ControlTypeValueSuffix"/> = (string)Request.QueryString["<xsl:value-of select="FieldName"/>End"];               
      </xsl:when>
      <xsl:when test="ControlType = 'RICH多选框'">
        <xsl:if test="IsMoreItemSearch = 'true'">
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = (string)Request.QueryString["<xsl:value-of select="FieldName"/>"];
        </xsl:if>
        <xsl:if test="IsMoreItemSearch = 'false'">
            <xsl:value-of select="FieldName"/>.SelectedValue = (string)Request.QueryString["<xsl:value-of select="FieldName"/>"];
        </xsl:if>
      </xsl:when>
      <xsl:otherwise>
        <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsCoupledNext = 'true'">
            <xsl:value-of select="CoupledDataSourcePrevious"/>Coupled();</xsl:if></xsl:if>
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = (string)Request.QueryString["<xsl:value-of select="FieldName"/>"];
      </xsl:otherwise>
    </xsl:choose>
</xsl:if>
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
<xsl:if test="IsAdvanceSearch = 'true'">
<xsl:if test="IsBindData = 'true'">
    <xsl:choose>
      <xsl:when test="IsRangeSearch = 'true'">
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>"]; 
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.SelectedValue = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin"]; 
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.SelectedValue = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End"];               
      </xsl:when>
      <xsl:when test="IsMoreItemSearch = 'true'">
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>"]; 
      </xsl:when>
      <xsl:otherwise>
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>"]; 
      </xsl:otherwise>
    </xsl:choose>
</xsl:if>
<xsl:if test="IsBindData = 'false'">
    <xsl:choose>
      <xsl:when test="IsRangeSearch = 'true'">
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>"]; 
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin"]; 
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End"];               
      </xsl:when>
      <xsl:otherwise>
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text = (string)Request.QueryString["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>"]; 
      </xsl:otherwise>
    </xsl:choose>
</xsl:if>
</xsl:if>
</xsl:for-each>
            btnAdvanceSearch_Click(sender, e);
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        gvPrint.Visible = false;
        ram<xsl:value-of select="/NewDataSet/TableName"/>.AjaxRequest += AjaxManager_AjaxRequest;
        base.Page_Load(sender, e);
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
    <xsl:if test="/NewDataSet/WebDetailPage = 'true'">
        DetailPage = true;</xsl:if>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsList"/>
  <xsl:if test="IsList = 'true'">
            gvList.Columns[int<xsl:value-of select="FieldName"/>ColumnIndex].Visible = chkShow<xsl:value-of select="FieldName"/>.Checked;</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
            gvList.Columns[int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex].Visible = chkShow<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Checked;</xsl:if></xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:if test="ControlType = '时间日期输入'">
        <xsl:value-of select="FieldName"/>.Attributes.Add("onclick", "setday(this);");
      <xsl:if test="IsRangeSearch = 'true'">
        <xsl:value-of select="FieldName"/>Begin.Attributes.Add("onclick", "setday(this);");
        <xsl:value-of select="FieldName"/>End.Attributes.Add("onclick", "setday(this);");
      </xsl:if>
    </xsl:if>
    <xsl:if test="ControlType = 'RICH多选框'">
      <xsl:if test="IsAllOneRow = 'false'">
        <xsl:if test="IsMoreItemSearch = 'true'">
          <xsl:value-of select="FieldName"/>.RepeatColumns = 1;
        </xsl:if>
      </xsl:if>
      <xsl:if test="IsAllOneRow = 'true'">
        <xsl:if test="IsMoreItemSearch = 'true'">
          <xsl:value-of select="FieldName"/>.RepeatColumns = 1;
        </xsl:if>
      </xsl:if>
    </xsl:if>
    <xsl:if test="ControlType = '下拉列表框'">
        <xsl:if test="IsMoreItemSearch = 'true'">
          <xsl:value-of select="FieldName"/>.RepeatColumns = 1;
        </xsl:if>
    </xsl:if>
</xsl:if>
</xsl:for-each>

<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUseSuggest = 'true'">
<xsl:if test="IsAdvanceSearch = 'true'">
        <xsl:value-of select="FieldName"/>.Attributes.Add("onclick", "openLayer(document.getElementById('<xsl:value-of select="FieldName"/>'), '<xsl:value-of select="UseSuggestFilePath"/>');");
        <xsl:value-of select="FieldName"/>.Attributes.Add("onpropertychange", "openLayer(document.getElementById('<xsl:value-of select="FieldName"/>'), '<xsl:value-of select="UseSuggestFilePath"/>');");
</xsl:if>
</xsl:if>
</xsl:for-each>
        // 数据查询
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        QueryRecord();
        gvList.DataSource = appData.ResultSet;
        gvList.DataBind();
        ViewState["RecordCount"] = appData.RecordCount;
        ViewState["CurrentPage"] = appData.CurrentPage;
        ViewState["PageSize"] = appData.PageSize;
        ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
        InitPageInfo();
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 设定更多查询项显示状态
    /// </summary>
    //=====================================================================
    protected override void SetMoreSearchItemDisplay(bool isDisplay = false)
    {
        btnShowAdvanceSearchItem.Visible = !isDisplay;
        btnShowSimpleSearchItem.Visible = isDisplay;
        ShowField_Area.Visible = isDisplay;
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAdvanceSearch = 'true'">
      <xsl:if test="IsSearch = 'false'">
        <xsl:value-of select="FieldName"/>_Area.Visible = isDisplay;
      </xsl:if>
    </xsl:if>
</xsl:for-each>
    }
    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
            // 查询报告列表
            FilterReportDataBind((string)Session[ConstantsManager.SESSION_USER_ID], FilterReportList);

            // 主表
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAdvanceSearch = 'true'">
      <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsCoupledNext = 'false'">
            <xsl:choose>
                <xsl:when test="ControlTypeName = 'TextBox'">

                </xsl:when>
                <xsl:otherwise>
            // 初始化<xsl:value-of select="FieldRemark"/>(<xsl:value-of select="FieldName"/>)下拉列表
          <xsl:choose>
              <xsl:when test="ControlType = 'ComboTreeView'">
			<xsl:value-of select="FieldName"/>.DataSource = RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>BusinessEntity.GetTreeData_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="TreeParentNode"/>("<xsl:value-of select="DataBindValueField"/>", "<xsl:value-of select="DataBindTextField"/>",  <xsl:value-of select="TreeParentNodeValue"/>, "<xsl:value-of select="DataBindCondition"/>", <xsl:value-of select="DataBindConditionValue"/>);
			<xsl:value-of select="FieldName"/>.DataFieldID = "ID";
			<xsl:value-of select="FieldName"/>.DataFieldParentID = "ParentID";
			<xsl:value-of select="FieldName"/>.DataTextField = "Name";
			<xsl:value-of select="FieldName"/>.DataValueField = "ID";
			<xsl:value-of select="FieldName"/>.CheckBoxes = true;
			<xsl:value-of select="FieldName"/>.CheckChildNodes = true;
              </xsl:when>
              <xsl:otherwise>
            <xsl:value-of select="FieldName"/>.DataSource = GetDataSource_<xsl:value-of select="FieldName"/>_AdvanceSearch();
            <xsl:value-of select="FieldName"/>.DataTextField = "<xsl:value-of select="DataBindTextField"/>";
            <xsl:value-of select="FieldName"/>.DataValueField = "<xsl:value-of select="DataBindValueField"/>";
              </xsl:otherwise>
          </xsl:choose>
            <xsl:value-of select="FieldName"/>.DataBind();
                  <xsl:choose>
				  <xsl:when test="ControlType = 'ComboTreeView'">
				  </xsl:when>
                    <xsl:when test="IsMoreItemSearch = 'true'">
            <xsl:value-of select="FieldName"/>.RepeatColumns = 1;
                    </xsl:when>
                    <xsl:otherwise>
            <xsl:value-of select="FieldName"/>.Items.Insert(0, new ListItem("选择<xsl:value-of select="FieldRemark"/>", ""));
                    </xsl:otherwise>
                  </xsl:choose>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:if>
        <xsl:if test="IsRangeSearch = 'true'">
            <xsl:choose>
                <xsl:when test="ControlTypeName = 'TextBox'">

                </xsl:when>
                <xsl:otherwise>
            // 初始化<xsl:value-of select="FieldRemark"/>开始值(<xsl:value-of select="FieldName"/>Begin)下拉列表
            <xsl:value-of select="FieldName"/>Begin.DataSource = GetDataSource_<xsl:value-of select="FieldName"/>_AdvanceSearch();
            <xsl:value-of select="FieldName"/>Begin.DataTextField = "<xsl:value-of select="DataBindTextField"/>";
            <xsl:value-of select="FieldName"/>Begin.DataValueField = "<xsl:value-of select="DataBindValueField"/>";
            <xsl:value-of select="FieldName"/>Begin.DataBind();
            <xsl:value-of select="FieldName"/>Begin.Items.Insert(0, new ListItem("选择<xsl:value-of select="FieldRemark"/>开始值", ""));
            // 初始化<xsl:value-of select="FieldRemark"/>结束值(<xsl:value-of select="FieldName"/>End)下拉列表
            <xsl:value-of select="FieldName"/>End.DataSource = GetDataSource_<xsl:value-of select="FieldName"/>_AdvanceSearch();
            <xsl:value-of select="FieldName"/>End.DataTextField = "<xsl:value-of select="DataBindTextField"/>";
            <xsl:value-of select="FieldName"/>End.DataValueField = "<xsl:value-of select="DataBindValueField"/>";
            <xsl:value-of select="FieldName"/>End.DataBind();
            <xsl:value-of select="FieldName"/>End.Items.Insert(0, new ListItem("选择<xsl:value-of select="FieldRemark"/>结束值", ""));
                </xsl:otherwise>
            </xsl:choose>        
        </xsl:if>
        <xsl:if test="IsCoupledNext = 'true'">
            // 初始化<xsl:value-of select="FieldRemark"/>(<xsl:value-of select="FieldName"/>)下拉列表
            <xsl:value-of select="FieldName"/>.DataTextField = "<xsl:value-of select="DataBindTextField"/>";
            <xsl:value-of select="FieldName"/>.DataValueField = "<xsl:value-of select="DataBindValueField"/>";
            <xsl:value-of select="CoupledDataSourcePrevious"/>Coupled();
        </xsl:if>
      </xsl:if>
    </xsl:if>
</xsl:for-each>
            // 一对一相关表
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsAdvanceSearch = 'true'">
      <xsl:if test="IsBindData = 'true'">
            // 初始化<xsl:value-of select="DisplayName"/>(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>)下拉列表
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.DataSource = GetDataSource_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_AdvanceSearch();
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.DataTextField = "<xsl:value-of select="BindDataFieldName"/>";
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.DataValueField = "<xsl:value-of select="BindDataRelativeFieldName"/>";
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.DataBind();
          <xsl:choose>
            <xsl:when test="IsMoreItemSearch = 'true'">
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.RepeatColumns = 2;
            </xsl:when>
            <xsl:otherwise>
            <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Items.Insert(0, new ListItem("选择<xsl:value-of select="DisplayName"/>", ""));
            </xsl:otherwise>
          </xsl:choose>
          <xsl:if test="IsRangeSearch = 'true'">
             // 初始化<xsl:value-of select="DisplayName"/>开始值(<xsl:value-of select="DisplayFieldName"/>Begin)下拉列表
             <xsl:value-of select="DisplayFieldName"/>Begin.DataSource = GetDataSource_<xsl:value-of select="DisplayFieldName"/>_AdvanceSearch();
             <xsl:value-of select="DisplayFieldName"/>Begin.DataTextField = "<xsl:value-of select="BindDataFieldName"/>";
             <xsl:value-of select="DisplayFieldName"/>Begin.DataValueField = "<xsl:value-of select="BindDataRelativeFieldName"/>";
             <xsl:value-of select="DisplayFieldName"/>Begin.DataBind();
             <xsl:value-of select="DisplayFieldName"/>Begin.Items.Insert(0, new ListItem("选择<xsl:value-of select="DisplayName"/>开始值", ""));
             // 初始化<xsl:value-of select="DisplayName"/>结束值(<xsl:value-of select="DisplayFieldName"/>End)下拉列表
             <xsl:value-of select="DisplayFieldName"/>End.DataSource = GetDataSource_<xsl:value-of select="DisplayFieldName"/>_AdvanceSearch();
             <xsl:value-of select="DisplayFieldName"/>End.DataTextField = "<xsl:value-of select="BindDataFieldName"/>";
             <xsl:value-of select="DisplayFieldName"/>End.DataValueField = "<xsl:value-of select="BindDataRelativeFieldName"/>";
             <xsl:value-of select="DisplayFieldName"/>End.DataBind();
             <xsl:value-of select="DisplayFieldName"/>End.Items.Insert(0, new ListItem("选择<xsl:value-of select="DisplayName"/>结束值", ""));
          </xsl:if>
      </xsl:if>
    </xsl:if>
</xsl:for-each>
    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载导出到文件函数
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        CustomColumnIndex();
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsList"/>
  <xsl:if test="IsList = 'true'">
        gvPrint.Columns[int<xsl:value-of select="FieldName"/>ColumnIndex - 1].Visible = chkShow<xsl:value-of select="FieldName"/>.Checked;</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
        gvPrint.Columns[int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex - 1].Visible = chkShow<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Checked;</xsl:if></xsl:if>
</xsl:for-each>
        // 创建信息标题
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    #region 控件事件
    //=====================================================================
    //  FunctionName : AjaxManager_AjaxRequest
    /// <summary>
    /// Ajax Request事件
    /// </summary>
    //=====================================================================
    protected void AjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        switch (e.Argument)
        {
            case "Refresh":
                Initalize();
                break;
            default:
                break;
        }
    }
    
    //=====================================================================
    //  FunctionName : InitalizeColumnIndex
    /// <summary>
    /// 初始化列索引
    /// </summary>
    //=====================================================================
    private void InitalizeColumnIndex()
    {
            int intNext = 0;
            // 初始化主表显示列序号
        <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:sort data-type="text" order="descending" select="IsList"/>
          <xsl:if test="IsList = 'true'">
            int<xsl:value-of select="FieldName"/>ColumnIndex = <xsl:value-of select="position()" />;
            txt<xsl:value-of select="FieldName"/>ColumnIndex.Text = int<xsl:value-of select="FieldName"/>ColumnIndex.ToString();
            intNext = <xsl:value-of select="position()"/>;</xsl:if>
        </xsl:for-each>
            // 初始化一对一对应表显示列序号
        <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
          <xsl:sort data-type="text" order="ascending" select="RelatedTableType"/>
          <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
          <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
          <xsl:if test="RelatedTableType = '1_to_1'">
            <xsl:if test="IsDisplay = 'true'">
            int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex = intNext + <xsl:value-of select="position()"/>;
            txt<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex.Text = int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex.ToString();</xsl:if></xsl:if>
        </xsl:for-each>
    }

    //=====================================================================
    //  FunctionName : CustomColumnIndex
    /// <summary>
    /// 自定义显示列位置
    /// </summary>
    //=====================================================================
    protected override void CustomColumnIndex()
    {
            DataControlFieldCollection dcListColunms = new DataControlFieldCollection();
            dcListColunms = gvList.Columns.CloneFields();
            DataControlFieldCollection dcPrintColunms = new DataControlFieldCollection();
            dcPrintColunms = gvPrint.Columns.CloneFields();
            int intTempColumnIndex = 0;
            // 主表显示列位置改变
        <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:sort data-type="text" order="descending" select="IsList"/>
          <xsl:if test="IsList = 'true'">
            intTempColumnIndex = Convert.ToInt32(txt<xsl:value-of select="FieldName"/>ColumnIndex.Text);
            if(intTempColumnIndex != int<xsl:value-of select="FieldName"/>ColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[int<xsl:value-of select="FieldName"/>ColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[int<xsl:value-of select="FieldName"/>ColumnIndex - 1]);
                int<xsl:value-of select="FieldName"/>ColumnIndex = intTempColumnIndex;
            }</xsl:if>
        </xsl:for-each>
            // 一对一对应表显示列改变
        <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
          <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
          <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
          <xsl:if test="RelatedTableType = '1_to_1'">
            <xsl:if test="IsDisplay = 'true'">
            intTempColumnIndex = Convert.ToInt32(txt<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex.Text);
            if(intTempColumnIndex != int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex)
            {
                gvList.Columns.RemoveAt(intTempColumnIndex);
                gvList.Columns.Insert(intTempColumnIndex, dcListColunms[int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex]);
                gvPrint.Columns.RemoveAt(intTempColumnIndex - 1);
                gvPrint.Columns.Insert(intTempColumnIndex - 1, dcPrintColunms[int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex - 1]);
                int<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>ColumnIndex = intTempColumnIndex;
            }</xsl:if></xsl:if>
        </xsl:for-each>
    }

    protected override void FilterReportList_SelectedIndexChanged(object sender, EventArgs e)
    {
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        FilterReportName.Text = string.Empty;
        if (FilterReportList.SelectedIndex > 0)
        {
            FilterReportApplicationData filterReportApplicationData = FilterReportBusinessEntity.GetDataByObjectID(FilterReportList.SelectedValue);
            <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData obj = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            appData = JsonHelper.JsonToObject(filterReportApplicationData.BGCXTJ, appData) as <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData;
            FilterReportName.Text = filterReportApplicationData.BGMC;
        }
        if (appData != null)
        {
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsAdvanceSearch"/>
  <xsl:sort data-type="text" order="descending" select="IsSearch"/>
  <xsl:sort data-type="number" order="ascending" select="OrderID"/>
  <xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsBatchSearch = 'true'">
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.<xsl:value-of select="FieldName"/>Batch); 
      </xsl:when>
      <xsl:when test="IsMoreItemSearch = 'true'">
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.<xsl:value-of select="FieldName"/>Batch); 
      </xsl:when>
      <xsl:when test="IsRangeSearch = 'true'">
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.<xsl:value-of select="FieldName"/>Begin); 
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.<xsl:value-of select="FieldName"/>End); 
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.<xsl:value-of select="FieldName"/>); 
      </xsl:when>
      <xsl:when test="DBType = 'Image'">
      </xsl:when>
      <xsl:when test="ControlType = 'RICH多选框'">
            <xsl:value-of select="FieldName"/>.SelectedValue = GetValue(appData.<xsl:value-of select="FieldName"/>Batch); 
      </xsl:when>
      <xsl:otherwise>
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.<xsl:value-of select="FieldName"/>); 
      </xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>
        }
        Initalize();
    }

    protected override void btnSaveFilterReport_Click(object sender, EventArgs e)
    {
        if (FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            return;
        }
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        GetQueryInputParameter();
        FilterReportApplicationLogic filterReportApplicationLogic = (FilterReportApplicationLogic)CreateApplicationLogicInstance(typeof(FilterReportApplicationLogic));
        FilterReportApplicationData filterReportApplicationData = new FilterReportApplicationData()
        {
            BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
            UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
            BGLX = FilterReportType,
            GXBG = "0",
            XTBG = "0",
            BGCXTJ = JsonHelper.ObjectToJson(appData),
            BGCJSJ = DateTime.Now,
        };
        FilterReportApplicationData filterReportQueryApplicationData;
        if (!FilterReportName.Text.IsHtmlNullOrWiteSpace())
        {
            filterReportQueryApplicationData = new FilterReportApplicationData()
            {
                BGMC = FilterReportName.Text.TrimIfNotNullOrWhiteSpace(),
                UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                BGLX = FilterReportType,
                XTBG = "0",
                CurrentPage = 1,
                PageSize = 1000,
            };
            filterReportQueryApplicationData = filterReportApplicationLogic.Query(filterReportQueryApplicationData);
            if (filterReportQueryApplicationData.ResultSet.Tables.Count > 0)
            {
                foreach (DataRow item in filterReportQueryApplicationData.ResultSet.Tables[0].Rows)
                {
                    filterReportApplicationLogic.Delete(new FilterReportApplicationData() { ObjectID = GetValue(item["ObjectID"]), OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID });
                }
            }
        }
        filterReportApplicationLogic.Add(filterReportApplicationData);
        FilterReportDataBind((string) Session[ConstantsManager.SESSION_USER_ID], FilterReportList);
        FilterReportList.Items.FindByText(FilterReportName.Text.TrimIfNotNullOrWhiteSpace()).Selected = true;
    }

    #endregion

    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// 初始化联动设置
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsCoupled = 'true'">
  <xsl:if test="IsDataBind = 'true'">
  <xsl:if test="IsAdvanceSearch = 'true'">
        // <xsl:value-of select="FieldRemark"/>联动设置
        <xsl:value-of select="FieldName"/>.AutoPostBack = true;
        <xsl:value-of select="FieldName"/>.SelectedIndexChanged += new System.EventHandler(this.<xsl:value-of select="FieldName"/>_SelectedIndexChanged);
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
    }

<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsCoupled = 'true'">
  <xsl:if test="IsDataBind = 'true'">
  <xsl:if test="IsAdvanceSearch = 'true'">
    //=====================================================================
    //  FunctionName : <xsl:value-of select="FieldName"/>_SelectedIndexChanged
    /// <summary>
    /// <xsl:value-of select="FieldRemark"/>的SelectedIndexChanged事件
    /// </summary>
    //=====================================================================
    protected void <xsl:value-of select="FieldName"/>_SelectedIndexChanged(object sender, EventArgs e)
    {
        <xsl:value-of select="FieldName"/>Coupled();
    }

    //=====================================================================
    //  FunctionName : <xsl:value-of select="FieldName"/>Coupled()
    /// <summary>
    /// <xsl:value-of select="FieldRemark"/>的联动处理方法
    /// </summary>
    //=====================================================================
    protected void <xsl:value-of select="FieldName"/>Coupled()
    {
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.SelectedValue))
        {
            <xsl:value-of select="CoupledDataSource"/>.DataSource = GetDataSource_<xsl:value-of select="CoupledDataSource"/>("<xsl:value-of select="CoupledDataSourceCondtion"/>", <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, true);
            <xsl:value-of select="CoupledDataSource"/>.DataBind();
            if (!(<xsl:value-of select="CoupledDataSource"/>.Items.Count > 0))
            {
                <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("无", ""));
            }
            else
            {
                <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("选择", ""));
            }
        }
        else
        {
            <xsl:value-of select="CoupledDataSource"/>.Items.Clear();
            <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("请先选择<xsl:value-of select="FieldRemark"/>", ""));
        }
        <xsl:value-of select="CoupledDataSource"/>.Attributes.Add("onchange", "RefreshGrid()");
        Initalize();
    }
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>

    //=====================================================================
    //  FunctionName : GetQueryInputParameter
    /// <summary>
    /// 得到查询用户输入参数操作（通过Request对象）
    /// </summary>
    //=====================================================================
    protected override Boolean GetQueryInputParameter()
    {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsBatchSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>Batch(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>Batch = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:when>
      <xsl:when test="IsMoreItemSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>Batch(<xsl:value-of select="FieldName"/>.SelectedValues, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>Batch = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:when>
      <xsl:when test="IsRangeSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>Begin(<xsl:value-of select="FieldName"/>Begin.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>Begin = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
            validateData = Validate<xsl:value-of select="FieldName"/>End(<xsl:value-of select="FieldName"/>End.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/>End = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
            <xsl:if test="IsApproximateSearch = 'true'">
            if(!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>))
            {
                appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>);
            }
            </xsl:if>
            <xsl:if test="IsApproximateSearch = 'false'">
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
            </xsl:if>
      </xsl:when>
      <xsl:when test="DBType = 'Image'">
      </xsl:when>
      <xsl:when test="ControlType = 'RICH多选框'">
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:when>
      <xsl:otherwise>
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
                }
            }
      </xsl:otherwise>
    </xsl:choose>
        <xsl:if test="IsSubItemSearch = 'true'">
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    if (chkShowSubItem<xsl:value-of select="FieldName"/>.Checked)
                    {
                        appData.<xsl:value-of select="FieldName"/> = null;
                        appData.<xsl:value-of select="FieldName"/>Batch = GetSubItem_<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.SelectedValue) + "," + <xsl:value-of select="FieldName"/>.SelectedValue;
                    }
                }
            }
        </xsl:if>
  </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsMoreItemSearch = 'true'">
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues) == false)
      {
        appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues;
      }
      </xsl:when>
      <xsl:when test="IsBindData = 'true'">
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue) == false)
      {
        appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue;
      }
      </xsl:when>
      <xsl:when test="IsRangeSearch = 'true'">
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text) == false)
      {
        appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text;
      }
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text) == false)
      {
        appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text;
      }
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text) == false)
      {
        appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text;
      }
      </xsl:when>
      <xsl:otherwise>
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text) == false)
      {
        appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text;
      }
      </xsl:otherwise>
    </xsl:choose>
        <xsl:if test="IsSubItemSearch = 'true'">
      if (DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text) == false)
      {
                if (chkShowSubItem<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Checked)
                {
                    appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> = null;
                    appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch = GetSubItem_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue) + "," + <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue;
                }
            }
        </xsl:if>
    </xsl:if>
</xsl:for-each>

      if (!DataValidateManager.ValidateIsNull(ViewState["QueryType"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["QueryType"].ToString()))
        {
          appData.QueryType = "AND";
        }
        else
        {
          appData.QueryType = ViewState["QueryType"].ToString();
        }
      }
      else
      {
        appData.SortField = "AND";
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["Sort"]))
      {
        if (!DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()))
        {
          appData.Sort = DEFAULT_SORT;
        }
        else
        {
          appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
        }
      }
      else
      {
        appData.Sort = DEFAULT_SORT;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["SortField"]))
      {
        if (!DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()))
        {
          appData.SortField = DEFAULT_SORT_FIELD;
        }
        else
        {
          appData.SortField = ViewState["SortField"].ToString();
        }
      }
      else
      {
        appData.SortField = DEFAULT_SORT_FIELD;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["PageSize"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["PageSize"].ToString()))
        {
          appData.PageSize = DEFAULT_PAGE_SIZE;
        }
        else
        {
          appData.PageSize = Convert.ToInt32(ViewState["PageSize"].ToString());
        }
      }
      else
      {
        appData.PageSize = DEFAULT_PAGE_SIZE;
      }
      if (!DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]))
      {
        if (!DataValidateManager.ValidateNumberFormat(ViewState["CurrentPage"].ToString()))
        {
          appData.CurrentPage = DEFAULT_CURRENT_PAGE;
        }
        else
        {
          appData.CurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
        }
      }
      else
      {
        appData.CurrentPage = DEFAULT_CURRENT_PAGE;
      }
<xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
    <xsl:if test="CustomPermissionType = 'SearchPage'">
        <xsl:if test="Condition = 'true'">
        if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
        {
            appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="ConditionValue"/>;
        }
        </xsl:if></xsl:if>
</xsl:for-each>

      return boolReturn;                
    }

    //=====================================================================
    //  FunctionName : GetTableCaption
    /// <summary>
    /// 得到信息标题
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
            System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
<![CDATA[            sbCaption.Append(@"<div class=""caption"">");]]>
            sbCaption.Append(@"<xsl:value-of select="/NewDataSet/TableRemark"/>列表");
<![CDATA[            sbCaption.Append(@"</div>");]]>
<![CDATA[            sbCaption.Append(@"<div class=""captionnote"">");]]>
<![CDATA[            sbCaption.Append(@"查询条件如下：");]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsMoreItemSearch = 'true'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.SelectedValues))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>：");
                sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="DataBindValueField"/>", <xsl:value-of select="FieldName"/>.SelectedValues, "<xsl:value-of select="DataBindTextField"/>"));
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:when test="IsRangeSearch = 'true'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>：");
                sbCaption.Append(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>Begin.<xsl:value-of select="ControlTypeValueSuffix"/>))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>开始值：");
                sbCaption.Append(<xsl:value-of select="FieldName"/>Begin.<xsl:value-of select="ControlTypeValueSuffix"/>);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>End.<xsl:value-of select="ControlTypeValueSuffix"/>))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>结束值：");
                sbCaption.Append(<xsl:value-of select="FieldName"/>End.<xsl:value-of select="ControlTypeValueSuffix"/>);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:when test="ControlType = 'RICH多选框'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.SelectedValue))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>：");
                sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="DataBindValueField"/>", <xsl:value-of select="FieldName"/>.SelectedValue, "<xsl:value-of select="DataBindTextField"/>"));
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:when test="IsDataBind = 'true'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>：");
                sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="DataBindValueField"/>", <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, "<xsl:value-of select="DataBindTextField"/>"));
                <xsl:if test="IsSubItemSearch = 'true'">
                if (chkShowSubItem<xsl:value-of select="FieldName"/>.Checked)
                {
                    sbCaption.Append("的子（下级）项信息");
                }
                </xsl:if>
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:when test="DBType = 'Image'">
      </xsl:when>
      <xsl:otherwise>
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="FieldRemark"/>：");
                sbCaption.Append(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:otherwise>
    </xsl:choose>
    </xsl:if>
</xsl:for-each>
            // 一对一相关表
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsAdvanceSearch = 'true'">
    <xsl:choose>
      <xsl:when test="IsMoreItemSearch = 'true'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="DisplayName"/>：");
                sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="BindDataRelativeFieldName"/>", <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues, "<xsl:value-of select="BindDataFieldName"/>"));
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:when test="IsRangeSearch = 'true'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="DisplayName"/>：");
                sbCaption.Append(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="DisplayName"/>开始值：");
                sbCaption.Append(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="DisplayName"/>结束值：");
                sbCaption.Append(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:when test="IsBindData = 'true'">
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="DisplayName"/>：");
                sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="BindDataRelativeFieldName"/>", <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue, "<xsl:value-of select="BindDataFieldName"/>"));
                <xsl:if test="IsSubItemSearch = 'true'">
                if (chkShowSubItem<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Checked)
                {
                    sbCaption.Append("的子（下级）项信息");
                }
                </xsl:if>
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:when>
      <xsl:otherwise>
            if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text))
            {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
                sbCaption.Append("<xsl:value-of select="DisplayName"/>：");
                sbCaption.Append(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text);
<![CDATA[               sbCaption.Append(@"</div>");]]>
            }</xsl:otherwise>
    </xsl:choose>
    </xsl:if>
</xsl:for-each>
<![CDATA[            sbCaption.Append("</div>");]]>
            return sbCaption.ToString();
    }
    
    protected override void CheckPermission()
    {
        if(AccessPermission)
        {
<xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
    <xsl:if test="CustomPermissionTemplate = $FileName">
    <xsl:if test="CustomPermissionType = 'SearchPage'">
        <xsl:if test="Hidden = 'true'">
            if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
            {
            gvList.Columns[int<xsl:value-of select="FieldName"/>ColumnIndex].Visible = 
            chkShow<xsl:value-of select="FieldName"/>_Area.Visible =
            chkShow<xsl:value-of select="FieldName"/>.Checked =
            chkShow<xsl:value-of select="FieldName"/>.Enabled = false;
            }</xsl:if>
        <xsl:if test="NoSearch = 'true'">
            if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
            {
            <xsl:value-of select="FieldName"/>_Area.Visible = false;
            }</xsl:if>
    </xsl:if>
    </xsl:if>
</xsl:for-each>
        }
    }

    protected override void SetCurrentAccessPermission()
    {
<xsl:for-each select="/NewDataSet/CustomPermissionConfig">
        <xsl:if test="CustomPermissionTemplate = $FileName">
        <xsl:if test="CustomPermissionType">
        if (CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
        {
            CurrentAccessPermission = <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID;
        }
        </xsl:if>
        </xsl:if>
</xsl:for-each>
        base.SetCurrentAccessPermission();
    }
}
</xsl:template>
</xsl:stylesheet>