<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIStatistic.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;

public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUIStatistic : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
{
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
            InitalizeDataBind();
            InitalizeCoupledDataSource();
            // 初始化界面
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsStatisticalCondition = 'true'">
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
              <xsl:value-of select="FieldName"/>.RepeatColumns = 3;
            </xsl:if>
          </xsl:if>
          <xsl:if test="IsAllOneRow = 'true'">
            <xsl:if test="IsMoreItemSearch = 'true'">
              <xsl:value-of select="FieldName"/>.RepeatColumns = 3;
            </xsl:if>
          </xsl:if>
        </xsl:if>
        <xsl:if test="ControlType = '下拉列表框'">
          <xsl:if test="IsMoreItemSearch = 'true'">
            <xsl:value-of select="FieldName"/>.RepeatColumns = 3;
          </xsl:if>
        </xsl:if>
    </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsUseSuggest = 'true'">
        <xsl:if test="IsStatisticalCondition = 'true'">
            <xsl:value-of select="FieldName"/>.Attributes.Add("onclick", "openLayer(document.getElementById('<xsl:value-of select="FieldName"/>'), '<xsl:value-of select="UseSuggestFilePath"/>');");
            <xsl:value-of select="FieldName"/>.Attributes.Add("onpropertychange", "openLayer(document.getElementById('<xsl:value-of select="FieldName"/>'), '<xsl:value-of select="UseSuggestFilePath"/>');");
        </xsl:if>
    </xsl:if>
</xsl:for-each>
            // 界面控件状态
<xsl:for-each select="/NewDataSet/CustomConditionConfig">
    <xsl:if test="CustomConditionTemplate = $FileName">
        <xsl:if test="CustomConditionType = 'Hidden'">
              <xsl:value-of select="CustomConditionFieldName"/>.Visible = false;
        </xsl:if>
    </xsl:if>
</xsl:for-each>
            if (false
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsStatisticalData = 'true'">
                || (string)Request.QueryString["CountField"] == "<xsl:value-of select="FieldName"/>"
</xsl:if>
</xsl:for-each>
            )
            {
                statisticpage.Style.Add("display", "none");
                statisticresultpage.Visible = true;
                Initalize();
            }
            else
            {
                statisticpage.Visible = true;
                statisticresultpage.Visible = false;
            }
        }
        else
        {
            InitalizeCoupledDataSource();
        }
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
        // 创建信息标题
        lblCaption.Text = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        // 数据统计
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        CountRecord();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
    }

    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:sort data-type="text" order="descending" select="IsStatisticalCondition"/>
<xsl:if test="IsStatisticalCondition = 'true'">
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
        <xsl:value-of select="FieldName"/>.RepeatColumns = 3;
                </xsl:when>
                <xsl:otherwise>
                  <xsl:choose>
                      <xsl:when test="ControlType = 'RICH多选框'">
                        <xsl:if test="IsMoreItemSearch = 'false'">
        <xsl:value-of select="FieldName"/>.Items.Insert(0, new ListItem("请选择<xsl:value-of select="FieldRemark"/>", ""));
                        </xsl:if>
                      </xsl:when>
                      <xsl:otherwise>
        <xsl:value-of select="FieldName"/>.Items.Insert(0, new ListItem("请选择<xsl:value-of select="FieldRemark"/>", ""));
                      </xsl:otherwise>
                  </xsl:choose>
                </xsl:otherwise>
              </xsl:choose>
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
        <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.RepeatColumns = 1;
        </xsl:when>
        <xsl:otherwise>
        <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Items.Insert(0, new ListItem("请选择<xsl:value-of select="DisplayName"/>", ""));
        </xsl:otherwise>
      </xsl:choose>
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
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        CountRecord();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        // 创建信息标题
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFileWithoutControl(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFileWithoutControl(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFileWithoutControl(gvPrint, "Result");
                break;
        }
    }

    #region 控件事件
    //=====================================================================
    //  FunctionName : btnShowStatistic_Click
    /// <summary>
    /// 显示统计条件界面按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnShowStatistic_Click(object sender, EventArgs e)
    {
        statisticpage.Style.Add("display", "block");
        statisticresultpage.Visible = false;
    }

    //=====================================================================
    //  FunctionName : btnStatistic_Click
    /// <summary>
    /// 统计结果按钮控件Click事件
    /// </summary>
    //=====================================================================
    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        statisticpage.Style.Add("display", "none");
        statisticresultpage.Visible = true;
        ViewState.Clear();
        Initalize();
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
  <xsl:if test="IsStatisticalCondition = 'true'">
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
  <xsl:if test="IsStatisticalCondition = 'true'">
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
                <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("请选择", ""));				
			}
        }
        else
        {
            <xsl:value-of select="CoupledDataSource"/>.Items.Clear();
            <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("请先选择<xsl:value-of select="FieldRemark"/>", ""));
        }
    }
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>


    //=====================================================================
    //  FunctionName : GetCountInputParameter
    /// <summary>
    /// 得到统计记录数用户输入参数操作（通过Request对象）
    /// </summary>
    //=====================================================================
    protected override Boolean GetCountInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsStatisticalCondition = 'true'">
<xsl:choose>
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
        validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
            }
        }
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
        if (chkShowSubItem<xsl:value-of select="FieldName"/>.Checked)
        {
            appData.<xsl:value-of select="FieldName"/> = null;
            appData.<xsl:value-of select="FieldName"/>Batch = GetSubItem_<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.SelectedValue);
        }
    </xsl:if>
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
<xsl:if test="IsAdvanceSearch = 'true'">
      <xsl:choose>
        <xsl:when test="IsMoreItemSearch = 'true'">
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues))
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValues;
        }
        </xsl:when>
        <xsl:when test="IsBindData = 'true'">
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue))
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue;
        }
        </xsl:when>
        <xsl:when test="IsRangeSearch = 'true'">
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text))
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text;
        }
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text))
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin.Text;
        }
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text))
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End.Text;
        }
        </xsl:when>
        <xsl:otherwise>
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text))
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> = <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Text;
        }
        </xsl:otherwise>
      </xsl:choose>
    <xsl:if test="IsSubItemSearch = 'true'">
        if (chkShowSubItem<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.Checked)
        {
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> = null;
            appData.<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch = GetSubItem_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>(<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>.SelectedValue);
        }
    </xsl:if>
</xsl:if>
</xsl:for-each>

        if (!DataValidateManager.ValidateIsNull(CountField.SelectedValue))
        {
            if (!DataValidateManager.ValidateStringLengthRange(CountField.SelectedValue.ToString(), 1, 50))
            {
                  strMessageParam[0] = "统计方式";
                  strMessageParam[1] = "1";
                  strMessageParam[2] = "50";
                  strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                  boolReturn = false;
            }
            else
            {
                appData.CountField = CountField.SelectedValue.ToString();
            }
        }
        else
        {
              strMessageParam[0] = "统计方式";
              strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, strMessageParam, strMessageInfo);
              boolReturn = false;
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
                appData.SortField = "RecordID";
            }
            else
            {
                appData.SortField = ViewState["SortField"].ToString();
            }
        }
        else
        {
            appData.SortField = "RecordID";
        }
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
        sbCaption.Append(@"<xsl:value-of select="/NewDataSet/TableRemark"/>统计（"+CountField.SelectedItem.Text+"）");
<![CDATA[            sbCaption.Append(@"</div>");]]>
<![CDATA[            sbCaption.Append(@"<div class=""captionnote"">");]]>
<![CDATA[            sbCaption.Append(@"统计条件如下：");]]>
        // 主表
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsStatisticalCondition = 'true'">
<xsl:choose>
  <xsl:when test="IsMoreItemSearch = 'true'">
        if (!DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.SelectedValues))
        {
<![CDATA[               sbCaption.Append(@"<div style=""margin-right:10px"">");]]>
            sbCaption.Append("<xsl:value-of select="FieldRemark"/>：");
            sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="DataBindValueField"/>", <xsl:value-of select="FieldName"/>.SelectedValues, "<xsl:value-of select="DataBindTextField"/>", "<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>"));
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
            sbCaption.Append(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="DataBindValueField"/>", <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, "<xsl:value-of select="DataBindTextField"/>", "<xsl:value-of select="DataBindCondition"/>", "<xsl:value-of select="DataBindConditionValue"/>"));
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
}
</xsl:template>
</xsl:stylesheet>
