<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIAdd.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx.cs
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
using RICH.Common.LM;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;

public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
{
    //=====================================================================
    //  FunctionName : OnPreInit
    /// <summary>
    /// OnPreInit
    /// </summary>
    //=====================================================================
    protected override void OnPreInit(EventArgs e)
    {
        base.OnPreInit(e);
  <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsAddBatchField = 'true'">
        <xsl:if test="IsAddBatchOnlyDisplay = 'true'">
        TemplateField tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/> = new TemplateField();
        tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>.HeaderTemplate = new CustomTemplateField("<xsl:value-of select="DisplayName"/>");
            <xsl:if test="IsFromTemplateTable = 'true'">
        tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>.ItemTemplate = new CustomTemplateField("<xsl:value-of select="DisplayFieldName"/>", "<xsl:value-of select="FromTableField"/>");
            </xsl:if>
            <xsl:if test="IsAddBatchModify = 'true'">
                <xsl:if test="IsBindData = 'false'">
        tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>.ItemTemplate = new CustomTemplateField("<xsl:value-of select="DisplayFieldName"/>", CustomTemplateField.TemplateFieldControlType.TextBox, "<xsl:value-of select="FromTableField"/>");
                </xsl:if>
            </xsl:if>
        tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>.HeaderStyle.CssClass = "fieldname";
        tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>.ItemStyle.CssClass = "fieldinput";
            <xsl:if test="IsAddBatchVisible = 'false'">
        tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>.Visible = false;
            </xsl:if>
        rpt<xsl:value-of select="RelatedTableName"/>.Columns.Add(tf<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="TableWithField"/>_<xsl:value-of select="DisplayFieldName"/>);
        </xsl:if>
    </xsl:if>
  </xsl:for-each>
  <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
        <xsl:value-of select="MainTemplateField"/>.AutoPostBack = true;
        <xsl:value-of select="MainTemplateField"/>.SelectedIndexChanged += new EventHandler(this.<xsl:value-of select="MainTemplateField"/>_SelectedIndexChanged);
        </xsl:if>
    </xsl:if>
  </xsl:for-each>
    }

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
            // 初始化绑定数据
            InitalizeDataBind();
            // 初始化耦合绑定数据
            InitalizeCoupledDataSource();
            // 全局初始化
            Initalize();
            // 初始化自定义添加字段
            InitalizeCustomAdd();
            // 相关表相关
            InitalizeRelatedTableAdd();
        }
        else
        {
            // 初始化耦合绑定数据
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
        // 初始化界面
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="ControlType = '时间日期输入'">
    <xsl:if test="IsAdd = 'true'">
        <xsl:value-of select="FieldName"/>.Attributes.Add("onclick", "setday(this);");</xsl:if></xsl:if>
<xsl:if test="ControlType = 'RICH多选框'">
    <xsl:if test="IsAdd = 'true'">
      <xsl:if test="IsAllOneRow = 'false'">
        <xsl:value-of select="FieldName"/>.RepeatColumns = 1;</xsl:if>
      <xsl:if test="IsAllOneRow = 'true'">
        <xsl:value-of select="FieldName"/>.RepeatColumns = 3;</xsl:if>
    </xsl:if></xsl:if>
<xsl:if test="ControlType = '密码框'">
    <xsl:if test="IsAdd = 'true'">
        <xsl:value-of select="FieldName"/>.TextMode = TextBoxMode.Password;
        <xsl:value-of select="FieldName"/>Confirm.TextMode = TextBoxMode.Password;</xsl:if></xsl:if>
<xsl:if test="ControlTypeName = 'FreeTextBox'">
    <xsl:if test="IsAdd = 'true'">
        <xsl:value-of select="FieldName"/>.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";</xsl:if></xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUseSuggest = 'true'">
        <xsl:value-of select="FieldName"/>.Attributes.Add("onclick", "openLayer(document.getElementById('<xsl:value-of select="FieldName"/>'), '<xsl:value-of select="UseSuggestFilePath"/>');");
        <xsl:value-of select="FieldName"/>.Attributes.Add("onpropertychange", "openLayer(document.getElementById('<xsl:value-of select="FieldName"/>'), '<xsl:value-of select="UseSuggestFilePath"/>');");
</xsl:if>
<xsl:if test="IsAJAXExist = 'true'">
        if(!EditMode)
        {
            <xsl:value-of select="FieldName"/>.Attributes.Add("onblur", "CallServer('01$$$<xsl:value-of select="FieldName"/>$$$'+ this.value, '<xsl:value-of select="FieldName"/>_Note')");
        }
</xsl:if>
</xsl:for-each>

        // 界面控件状态
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsUseTab"/>
  <xsl:if test="IsUse = 'true'">
    <xsl:if test="IsUseTab = 'true'">
      <xsl:if test="position() = 1">
        <xsl:value-of select="/NewDataSet/TableName"/>TabStrip.Visible = true;
      </xsl:if>
        <xsl:value-of select="/NewDataSet/TableName"/>TabStrip.FindTabByValue("<xsl:value-of select="TabIndex"/>").Text = "<xsl:value-of select="TabName"/>";
        <xsl:value-of select="/NewDataSet/TableName"/>TabStrip.FindTabByValue("<xsl:value-of select="TabIndex"/>").Visible = true;
        PageView<xsl:value-of select="TabIndex"/>.Visible = true;
    </xsl:if>
  </xsl:if>
</xsl:for-each>
        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:choose>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
            <xsl:if test="IsDataBind = 'true'">
                <xsl:if test="IsCoupledNext = 'true'">
                <xsl:value-of select="CoupledDataSourcePrevious"/>Coupled();
                </xsl:if>
            </xsl:if>
            <xsl:if test="IsUse= 'true'">
                <xsl:choose>
                    <xsl:when test="ControlType = '密码框'">
                    </xsl:when>
                    <xsl:otherwise>
                <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>"]); 
                    </xsl:otherwise>
                </xsl:choose>
            </xsl:if>
        </xsl:otherwise>
    </xsl:choose>
</xsl:for-each>
            }
        }
            if (AddMode)
            {
                // 初始化传入参数
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsRelatedOperateParam = 'true'">
    <xsl:if test="IsDataBind = 'true'">
      <xsl:if test="IsCoupledNext = 'true'">
                <xsl:value-of select="CoupledDataSourcePrevious"/>Coupled();
      </xsl:if>
    </xsl:if>
    <xsl:if test="IsAdd = 'true'">
        <xsl:choose>
            <xsl:when test="DBType = 'Image'">
            </xsl:when>
            <xsl:otherwise>
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["<xsl:value-of select="FieldName"/>"]))
                {
                    <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = GetValue(Request.QueryString["<xsl:value-of select="FieldName"/>"]); 
                    <xsl:value-of select="FieldName"/>.Enabled = false;
                }
            </xsl:otherwise>
        </xsl:choose>
    </xsl:if>
</xsl:if>
</xsl:for-each>
                // 初始化默认值
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsAddDefaultValue = 'true'">
                <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = <xsl:value-of select="AddDefaultValue"/>; 
</xsl:if>
</xsl:for-each>
            }
<xsl:for-each select="/NewDataSet/CustomConditionConfig">
<xsl:if test="CustomConditionTemplate = $FileName">
    <xsl:if test="CustomConditionType = 'Hidden'">
        <xsl:value-of select="CustomConditionFieldName"/>_Area.Visible = false;
    </xsl:if>
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomConditionConfig">
<xsl:if test="CustomConditionTemplate = $FileName">
    <xsl:if test="CustomConditionType = 'Lock'">
        <xsl:value-of select="CustomConditionFieldName"/>.Enabled = false;
        <xsl:value-of select="CustomConditionFieldName"/>.SelectedValue = <xsl:value-of select="CustomConditionValue"/>;
    </xsl:if>
</xsl:if>
</xsl:for-each>
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (EditMode)
        {
            btnModifyConfirm_Click(sender, e);
        }
        else if(CopyMode || AddMode)
        {
            btnAddConfirm_Click(sender, e);
        }
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
        <xsl:value-of select="FieldName"/>.DataSource = GetDataSource_<xsl:value-of select="FieldName"/>();
        <xsl:value-of select="FieldName"/>.DataTextField = "<xsl:value-of select="DataBindTextField"/>";
        <xsl:value-of select="FieldName"/>.DataValueField = "<xsl:value-of select="DataBindValueField"/>";
              </xsl:otherwise>
          </xsl:choose>
        <xsl:value-of select="FieldName"/>.DataBind();
        <xsl:if test="IsNull = 'true'">
          <xsl:choose>
              <xsl:when test="ControlType = 'RICH多选框'">
              </xsl:when>
              <xsl:otherwise>
        <xsl:value-of select="FieldName"/>.Items.Insert(0, new ListItem("请选择<xsl:value-of select="FieldRemark"/>", ""));
              </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
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
</xsl:for-each>
    }

    //=====================================================================
    //  FunctionName : GetAddInputParameter
    /// <summary>
    /// 得到添加用户输入参数操作
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUse = 'true'">
<xsl:if test="/NewDataSet/AllowAutoGenerateID = 'true'">
    <xsl:choose>
        <xsl:when test="ControlTypeName = 'FilesList'">
        if (<xsl:value-of select="FieldName"/>.Upload())
        {
		    appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>;
        }
        else
        {
            MessageContent += @"<![CDATA[<font color=""red"">" + ]]><xsl:value-of select="FieldName"/><![CDATA[.Message + "</font>]]>";
            boolReturn = false;
        }
        </xsl:when>
        <xsl:when test="ControlType = '密码框'">
            <xsl:if test="IsAdd = 'true'">
        if (<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> == <xsl:value-of select="FieldName"/>Confirm.<xsl:value-of select="ControlTypeValueSuffix"/>)
        {
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, <xsl:value-of select="IsNull"/>, <xsl:value-of select="IsAJAXExist"/>);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = RICH.Common.SecurityManager.MD5(Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString()), 32);
                }
                <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
                boolReturn = validateData.Result;
            }
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            <xsl:value-of select="FieldName"/>Confirm.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">两次输入不一致，请重新输入。</font>]]>";
            boolReturn = false;
        }
            </xsl:if>
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        // 图像数据处理
            <xsl:if test="IsAdd = 'true'">
        appData.<xsl:value-of select="FieldName"/> = GetImageData(<xsl:value-of select="FieldName"/>);
        validateData = Validate<xsl:value-of select="FieldName"/>(appData.<xsl:value-of select="FieldName"/>, <xsl:value-of select="IsNull"/>, false);
        if (validateData.Result)
        {                
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
            boolReturn = validateData.Result;
        }
            </xsl:if>
        </xsl:when>
        <xsl:when test="FieldName = /NewDataSet/AutoGenerateField">
        </xsl:when>
        <xsl:otherwise>
            <xsl:if test="IsFixed = 'true'">
        appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="FixedValue"/>;
            </xsl:if>
            <xsl:if test="IsFixed = 'false'">
                <xsl:if test="IsAdd = 'true'">
        validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, <xsl:value-of select="IsNull"/>, <xsl:value-of select="IsAJAXExist"/>);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
            }
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
            boolReturn = validateData.Result;
        }
                </xsl:if>
            </xsl:if>
        </xsl:otherwise>
    </xsl:choose>   
  </xsl:if>
  <xsl:if test="/NewDataSet/AllowAutoGenerateID = 'false'">
        <xsl:choose>
        <xsl:when test="ControlTypeName = 'FilesList'">
        if (<xsl:value-of select="FieldName"/>.Upload())
        {
		    appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>;
        }
        else
        {
            MessageContent += @"<![CDATA[<font color=""red"">" + ]]><xsl:value-of select="FieldName"/><![CDATA[.Message + "</font>]]>";
            boolReturn = false;
        }
        </xsl:when>
            <xsl:when test="ControlType = '密码框'">
                <xsl:if test="IsAdd = 'true'">
        if (<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> == <xsl:value-of select="FieldName"/>Confirm.<xsl:value-of select="ControlTypeValueSuffix"/>)
        {
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, <xsl:value-of select="IsNull"/>, <xsl:value-of select="IsAJAXExist"/>);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = RICH.Common.SecurityManager.MD5(Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString()), 32);
                }
                <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
                boolReturn = validateData.Result;
            }
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            <xsl:value-of select="FieldName"/>Confirm.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">两次输入不一致，请重新输入。</font>]]>";
            boolReturn = false;
        }
                </xsl:if>
            </xsl:when>
            <xsl:when test="DBType = 'Image'">
        // 图像数据处理
                <xsl:if test="IsAdd = 'true'">
        if (<xsl:value-of select="FieldName"/>.HasFile)
        {
            appData.<xsl:value-of select="FieldName"/> = GetImageData(<xsl:value-of select="FieldName"/>);
            validateData = Validate<xsl:value-of select="FieldName"/>(appData.<xsl:value-of select="FieldName"/>, <xsl:value-of select="IsNull"/>, false);
        }
        else if(CopyMode)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appDataTemp = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            appDataTemp.ObjectID = base.ObjectID;
            appDataTemp.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            appDataTemp = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic().Query(appDataTemp);
            if (appDataTemp.RecordCount > 0)
            {
                if (!DataValidateManager.ValidateIsNull(appDataTemp.ResultSet.Tables[0].Rows[0]["XP"]))
                {
                    appData.<xsl:value-of select="FieldName"/> = (Byte[])appDataTemp.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>"];
                }
            }
        }
        validateData = Validate<xsl:value-of select="FieldName"/>(appData.<xsl:value-of select="FieldName"/>, <xsl:value-of select="IsNull"/>, false);
        if (validateData.Result)
        {                
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
            boolReturn = validateData.Result;
        }
                </xsl:if>
            </xsl:when>
            <xsl:otherwise>
                <xsl:if test="IsFixed = 'false'">
                    <xsl:if test="IsAdd = 'true'">
        validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, <xsl:value-of select="IsNull"/>, <xsl:value-of select="IsAJAXExist"/>);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
            }
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
            boolReturn = validateData.Result;
        }
                    </xsl:if>
                </xsl:if>
            </xsl:otherwise>
        </xsl:choose>
  </xsl:if>
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomConditionConfig">
<xsl:if test="CustomConditionTemplate = $FileName">
    <xsl:if test="CustomConditionType = 'Add'">
        appData.<xsl:value-of select="CustomConditionFieldName"/> = <xsl:value-of select="CustomConditionValue"/>;
    </xsl:if>
</xsl:if>
</xsl:for-each>
        // 自动生成编号
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUse = 'true'">
<xsl:if test="/NewDataSet/AllowAutoGenerateID = 'true'">
        <xsl:if test="FieldName = /NewDataSet/AutoGenerateField">
            <xsl:if test="IsFixed = 'false'">
                <xsl:if test="FieldName = /NewDataSet/AutoGenerateField">
        <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic
            = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
        appData.<xsl:value-of select="FieldName"/> = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.AutoGenerate<xsl:value-of select="/NewDataSet/AutoGenerateField"/>(appData);
                </xsl:if>
            </xsl:if>
        </xsl:if>  
</xsl:if>
<xsl:if test="IsFixed = 'true'">
        appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="FixedValue"/>;
</xsl:if>
</xsl:if>
</xsl:for-each>
        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetModifyInputParameter
    /// <summary>
    /// 得到修改用户输入参数操作
    /// </summary>
    //=====================================================================
    protected override Boolean GetModifyInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // 验证输入参数
        appData = RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUse = 'true'">
<xsl:if test="IsAJAXExist = 'false'">
  <xsl:choose>
        <xsl:when test="ControlTypeName = 'FilesList'">
        if (<xsl:value-of select="FieldName"/>.Upload())
        {
		    appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>;
        }
        else
        {
            MessageContent += @"<![CDATA[<font color=""red"">" + ]]><xsl:value-of select="FieldName"/><![CDATA[.Message + "</font>]]>";
            boolReturn = false;
        }
        </xsl:when>
      <xsl:when test="DBType = 'Image'">
        // 图像数据处理
        <xsl:if test="IsModify = 'true'">
        if(DataValidateManager.ValidateIsNull(<xsl:value-of select="FieldName"/>.FileName)==false)
        {
            appData.<xsl:value-of select="FieldName"/> = GetImageData(<xsl:value-of select="FieldName"/>);
            validateData = Validate<xsl:value-of select="FieldName"/>(appData.<xsl:value-of select="FieldName"/>, <xsl:value-of select="IsNull"/>, false);
        }
        if (validateData.Result)
        {                
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
            boolReturn = validateData.Result;
        }
        </xsl:if>
      </xsl:when>
      <xsl:when test="ControlType = '密码框'">
        <xsl:if test="IsModify = 'true'">
        if (<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> == <xsl:value-of select="FieldName"/>Confirm.<xsl:value-of select="ControlTypeValueSuffix"/>)
        {
            validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.<xsl:value-of select="FieldName"/> = RICH.Common.SecurityManager.MD5(Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString()), 32);
                }
                <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
                boolReturn = validateData.Result;
            }
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            <xsl:value-of select="FieldName"/>Confirm.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">两次输入不一致，请重新输入。</font>]]>";
            boolReturn = false;
        }
        </xsl:if>
      </xsl:when>
      <xsl:otherwise>
              <xsl:if test="IsUpdateFixed = 'false'">
                <xsl:if test="IsModify = 'true'">
        validateData = Validate<xsl:value-of select="FieldName"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>, <xsl:value-of select="IsNull"/>, <xsl:value-of select="IsAJAXExist"/>);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.<xsl:value-of select="FieldName"/> = Convert.To<xsl:value-of select="FieldType"/>(validateData.Value.ToString());
            }
            <xsl:if test="IsString = 'true'">            
            else
            {
                appData.<xsl:value-of select="FieldName"/> = null;
            }
            </xsl:if>
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            <xsl:value-of select="FieldName"/>.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<![CDATA[<font color=""red"">" + validateData.Message + "</font>]]>";
            boolReturn = validateData.Result;
        }
                </xsl:if>
            </xsl:if>
      </xsl:otherwise>
  </xsl:choose>
</xsl:if>
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUse = 'true'">
<xsl:if test="IsUpdateFixed = 'true'">
        appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="UpdateFixedValue"/>;
</xsl:if>
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomConditionConfig">
<xsl:if test="CustomConditionTemplate = $FileName">
    <xsl:if test="CustomConditionType = 'Modify'">
        appData.<xsl:value-of select="CustomConditionFieldName"/> = <xsl:value-of select="CustomConditionValue"/>;
    </xsl:if>
</xsl:if>
</xsl:for-each>
        return boolReturn;
    }

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
        <xsl:if test="IsAdd = 'true'">
        // <xsl:value-of select="FieldRemark"/>联动设置
        <xsl:value-of select="FieldName"/>.AutoPostBack = true;
        <xsl:value-of select="FieldName"/>.SelectedIndexChanged += new System.EventHandler(this.<xsl:value-of select="FieldName"/>_SelectedIndexChanged);
  </xsl:if></xsl:if></xsl:if>
</xsl:for-each>
    }

<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsCoupled = 'true'">
    <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsAdd = 'true'">
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
            <xsl:value-of select="CoupledDataSource"/>.DataSource = GetDataSource_<xsl:value-of select="CoupledDataSource"/>("<xsl:value-of select="CoupledDataSourceCondtion"/>", <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>);
            <xsl:value-of select="CoupledDataSource"/>.DataBind();
            if (!(<xsl:value-of select="CoupledDataSource"/>.Items.Count > 0))
            {
                <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("无", ""));
            }
            <xsl:if test="IsNull = 'false'">
            else
            {
                <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("请选择", ""));    
            }
            </xsl:if>
        }
        else
        {
            <xsl:value-of select="CoupledDataSource"/>.Items.Clear();
            <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("请先选择<xsl:value-of select="FieldRemark"/>", ""));
        }
    }
  </xsl:if></xsl:if></xsl:if>
</xsl:for-each>
    //=====================================================================
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// 初始化自定义添加
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // 定制添加相关表信息
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsCustomAdd = 'true'">
        if (DataValidateManager.ValidateIsNull(Request.QueryString["<xsl:value-of select="CustomAddRelatedField"/>"]) == false)
        {
            <xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = (string)new RICH.Common.BM.<xsl:value-of select="CustomAddTableName"/>.<xsl:value-of select="CustomAddTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="CustomAddValueField"/>", GetValue(Request.QueryString["<xsl:value-of select="CustomAddRelatedField"/>"]), "<xsl:value-of select="CustomAddTextValue"/>");
            <xsl:value-of select="FieldName"/>.Enabled = false;
        }
</xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
<xsl:if test="IsCustomAdd = 'true'">
    <xsl:if test="IsBindData = 'true'">
        if ((string)Request.QueryString["RelatedTableName"] == "<xsl:value-of select="RelatedTableName"/>")
        {
            if (DataValidateManager.ValidateIsNull(Request.QueryString["<xsl:value-of select="TableWithField"/>"]) == false)
            {
                <xsl:value-of select="CustomAddWithField"/>.SelectedValue = (string)new RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="RelatedTableWithField"/>", GetValue(Request.QueryString["<xsl:value-of select="TableWithField"/>"]), "<xsl:value-of select="DisplayFieldName"/>");
                <xsl:value-of select="CustomAddWithField"/>.Enabled = false;
            }
        }
    </xsl:if>
    <xsl:if test="IsBindData = 'false'">
        if ((string)Request.QueryString["RelatedTableName"] == "<xsl:value-of select="RelatedTableName"/>")
        {
            if (DataValidateManager.ValidateIsNull(Request.QueryString["<xsl:value-of select="TableWithField"/>"]) == false)
            {
                <xsl:value-of select="CustomAddWithField"/>.Text = (string)new RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>BusinessEntity().GetValueByFixCondition("<xsl:value-of select="RelatedTableWithField"/>", GetValue(Request.QueryString["<xsl:value-of select="TableWithField"/>"]), "<xsl:value-of select="DisplayFieldName"/>");
                <xsl:value-of select="CustomAddWithField"/>.Enabled = false;
            }
        }
    </xsl:if>
</xsl:if>
</xsl:for-each>
    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// 初始化批量添加模板
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
<xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
<xsl:if test="IsAddBatch = 'true'">
    <xsl:if test="IsAddBatchTemplate = 'true'">
        // <xsl:value-of select="RelatedInfoName"/>批量添加模板(<xsl:value-of select="AddBatchTemplateTableName"/>)
        rpt<xsl:value-of select="RelatedTableName"/>.DataSource = Get<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="AddBatchTemplateTableName"/>(<xsl:value-of select="MainTemplateField"/>.SelectedValue);
        rpt<xsl:value-of select="RelatedTableName"/>.DataBind();
    </xsl:if>
</xsl:if>
</xsl:for-each>
    }

<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
    //=====================================================================
    //  FunctionName : <xsl:value-of select="MainTemplateField"/>_SelectedIndexChanged
    /// <summary>
    /// <xsl:value-of select="RelatedInfoName"/>批量添加模板联动事件
    /// </summary>
    //=====================================================================
    protected void <xsl:value-of select="MainTemplateField"/>_SelectedIndexChanged(object sender, EventArgs e)
    {
        // <xsl:value-of select="RelatedInfoName"/>批量添加模板(<xsl:value-of select="AddBatchTemplateTableName"/>)
        rpt<xsl:value-of select="RelatedTableName"/>.DataSource = Get<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="AddBatchTemplateTableName"/>(<xsl:value-of select="MainTemplateField"/>.SelectedValue);
        rpt<xsl:value-of select="RelatedTableName"/>.DataBind();
    }
        </xsl:if>
    </xsl:if>
</xsl:for-each>

    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// 相关表排序分类处理
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        string strSortClassify = string.Empty;
        GridView rptTemp = (GridView)sender;
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsAddBatchField = 'true'">
        <xsl:if test="IsSortClassify = 'true'">
        if (rptTemp.ID == "rpt<xsl:value-of select="RelatedTableName"/>")
        {
            foreach (GridViewRow gvr in rptTemp.Rows)
            {
                if (strSortClassify != ((Label)gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].FindControl("<xsl:value-of select="DisplayFieldName"/>")).Text)
                {
                    strSortClassify = ((Label)gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].FindControl("<xsl:value-of select="DisplayFieldName"/>")).Text;
                    Literal litTemp = new Literal();
                    litTemp.Text = (string)(new RICH.Common.BM.<xsl:value-of select="BindDataTableName"/>.<xsl:value-of select="BindDataTableName"/>BusinessEntity()).GetValueByFixCondition("<xsl:value-of select="BindDataRelativeFieldName"/>", strSortClassify, "<xsl:value-of select="BindDataFieldName"/>");
                    gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].Controls.Add(litTemp);
                    gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].Style.Add("border-bottom", "0px solid black");
                }
                else
                {
                    ((Label)gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].FindControl("<xsl:value-of select="DisplayFieldName"/>")).Visible = false;
                    gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].Style.Add("border-bottom", "0px solid black");
                    gvr.Cells[<xsl:value-of select="AddBatchDisplaySort"/>].Style.Add("border-top", "0px solid black");
                }
            }
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>
    }

    //=====================================================================
    //  FunctionName : RelatedTableAddBatch()
    /// <summary>
    /// 相关表批量添加
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
        <xsl:value-of select="RelatedTableName"/>AddBatch(rpt<xsl:value-of select="RelatedTableName"/>);
        </xsl:if>
    </xsl:if>
</xsl:for-each>
    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// 相关表批量修改
    /// </summary>
    //=====================================================================
    protected override void RelatedTableModifyBatch()
    {
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
        <xsl:value-of select="RelatedTableName"/>ModifyBatch(rpt<xsl:value-of select="RelatedTableName"/>);
        </xsl:if>
    </xsl:if>
</xsl:for-each>
    }

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "<xsl:value-of select="/NewDataSet/TableName"/>", dt, true, true);
        <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
<xsl:for-each select="/NewDataSet/RecordInfo">
<xsl:if test="IsUse = 'true'">
<xsl:if test="/NewDataSet/AllowAutoGenerateID = 'true'">
        <xsl:if test="FieldName = /NewDataSet/AutoGenerateField">
            <xsl:if test="IsFixed = 'false'">
                <xsl:if test="FieldName = /NewDataSet/AutoGenerateField">
            appData.<xsl:value-of select="FieldName"/> = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.AutoGenerate<xsl:value-of select="/NewDataSet/AutoGenerateField"/>(appData);
                </xsl:if>
            </xsl:if>
        </xsl:if>
</xsl:if>
</xsl:if>
</xsl:for-each>
            int i = 0;
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsFromDoc = 'true'">
<![CDATA[            ]]>appData.<xsl:value-of select="FieldName"/><![CDATA[ = dr.ItemArray[i].ToString().Replace("\r", "<br/>");]]>
            i++;</xsl:if>
</xsl:for-each>
            appData = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Add(appData);
        }
    }
    protected void btnInfoFromDoc_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWord(InfoFromDoc.Text, dt, true);
        if (dt.Rows.Count > 0)
        {
            int i = 0;
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsFromDoc = 'true'">
      <xsl:if test="IsDataBind = 'false'">
<![CDATA[            ]]><xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/><![CDATA[ = dt.Rows[0].ItemArray[i].ToString().Replace("\r", "<br/>");]]>
<![CDATA[            ]]>i++;</xsl:if>
      <xsl:if test="IsDataBind = 'true'">
<![CDATA[            ]]>string str<xsl:value-of select="FieldName"/> = GetValue(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogicBase().GetValueByFixCondition("<xsl:value-of select="DataBindTextField"/>", dt.Rows[0].ItemArray[i], "<xsl:value-of select="DataBindValueField"/>"));
<![CDATA[            ]]>if (!DataValidateManager.ValidateIsNull(str<xsl:value-of select="FieldName"/>))<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/> = str<xsl:value-of select="FieldName"/>;
<![CDATA[            ]]>i++;</xsl:if>
    </xsl:if>
</xsl:for-each>
        }
        ImportControlContainer.Visible = false;
        ControlContainer.Visible = true;
    }
    protected void btnImportFromDoc_Click(object sender, EventArgs e)
    {
        ImportControlContainer.Visible = true;
        ControlContainer.Visible = false;
    }
    protected void btnInfoFromDocCancel_Click(object sender, EventArgs e)
    {
        ImportControlContainer.Visible = false;
        ControlContainer.Visible = true;
    }
    private DataTable GetTemplateColumn(DataTable dt)
    {
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsFromDoc = 'true'">
        dt.Columns.Add("<xsl:value-of select="DocTable"/>_<xsl:value-of select="DocRow"/>_<xsl:value-of select="DocCell"/>");
    </xsl:if>
</xsl:for-each>
        return dt;
    }

    protected void btnInfoFromDS_Click(object sender, EventArgs e)
    {
        int totalCount = 0;
        int importCount = 0;
        int updateCount = 0;
        try
        {
<![CDATA[            var appDatas = ]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData.GetDataFromDataFile<]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[ApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: ]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[Contants.ImportDataSetStartLineNum);]]>
            <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic = (<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic)CreateApplicationLogicInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsUse = 'true'">
    <xsl:if test="/NewDataSet/AllowAutoGenerateID = 'true'"><xsl:if test="FieldName = /NewDataSet/AutoGenerateField"><xsl:if test="IsFixed = 'false'"><xsl:if test="FieldName = /NewDataSet/AutoGenerateField">
                app.<xsl:value-of select="FieldName"/> = instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.AutoGenerate<xsl:value-of select="/NewDataSet/AutoGenerateField"/>(app);
                    </xsl:if></xsl:if></xsl:if></xsl:if>
    <xsl:if test="IsFixed = 'true'">
                app.<xsl:value-of select="FieldName"/> = <xsl:value-of select="FixedValue"/>;</xsl:if>
    <xsl:if test="IsFromDataSet = 'false'"><xsl:if test="IsDataBind = 'true'">
                string str<xsl:value-of select="FieldName"/> = GetValue(new RICH.Common.BM.<xsl:value-of select="DataBindTableName"/>.<xsl:value-of select="DataBindTableName"/>ApplicationLogicBase().GetValueByFixCondition("<xsl:value-of select="DataBindTextField"/>", app.<xsl:value-of select="FieldName"/>, "<xsl:value-of select="DataBindValueField"/>"));
                if (!DataValidateManager.ValidateIsNull(str<xsl:value-of select="FieldName"/>))app.<xsl:value-of select="FieldName"/> = str<xsl:value-of select="FieldName"/>;</xsl:if>
    </xsl:if></xsl:if>
    <xsl:if test="IsAdd = 'true'"><xsl:if test="IsFromDataSet = 'false'">
                if(!<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>.IsHtmlNullOrWiteSpace()) 
                {
                    app.<xsl:value-of select="FieldName"/> =  Convert.To<xsl:value-of select="FieldType"/>(<xsl:value-of select="FieldName"/>.<xsl:value-of select="ControlTypeValueSuffix"/>);
                }
    </xsl:if></xsl:if>
    </xsl:for-each>
                instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instance<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
<![CDATA[            MessageContent += @"<font color=""green"">共{0}条数据，导入数据{1}条，更新数据{2}条。</font>".FormatInvariantCulture(totalCount, importCount, updateCount);]]>
        }
        catch (Exception ex)
        {
<![CDATA[            MessageContent += @"<font color=""red"">导入数据过程出错：{0}<br/>共{1}条数据，已导入数据{2}条，已更新数据{3}条。</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);]]>
        }
    }

    protected override void CheckPermission()
    {
        if (AccessPermission)
        {
            if(EditMode)
            {
    <xsl:for-each select="/NewDataSet/CustomConditionConfig">
    <xsl:if test="CustomConditionTemplate = $FileName">
        <xsl:if test="CustomConditionType = 'Modify'">
              <xsl:value-of select="CustomConditionFieldName"/>_Area.Visible = false;
        </xsl:if>
    </xsl:if>
    </xsl:for-each>
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
      <xsl:if test="IsModify = 'true'">
        <xsl:if test="IsNonModifiable = 'true'">
            <xsl:choose>
                <xsl:when test="ControlTypeName = 'DropDownList'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'RadioButtonList'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'CheckBoxList'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'CheckBoxListEx'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'RadioButton'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'CheckBox'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'TextBox'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'Label'">
                </xsl:when>
                <xsl:when test="ControlType = 'GridDataBind'">
                <xsl:value-of select="FieldName"/>.EditMode=false;
                </xsl:when>
                <xsl:otherwise>
                <xsl:value-of select="FieldName"/>.ReadOnly = true;
                </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:if>
      <xsl:if test="IsModify = 'false'">
                <xsl:value-of select="FieldName"/>_Area.Visible = false;
      </xsl:if>
      </xsl:if>
    </xsl:for-each>
            }
            else if(AddMode || CopyMode)
            {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
      <xsl:if test="IsAdd = 'false'">
                <xsl:value-of select="FieldName"/>_Area.Visible = false;
      </xsl:if>
      </xsl:if>
    </xsl:for-each>
    <xsl:for-each select="/NewDataSet/CustomConditionConfig">
    <xsl:if test="CustomConditionTemplate = $FileName">
        <xsl:if test="CustomConditionType = 'Add'">
                <xsl:value-of select="CustomConditionFieldName"/>_Area.Visible = false;
        </xsl:if>
    </xsl:if>
    </xsl:for-each>
            }
            if(ImportDSMode)
            {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsUse = 'true'">
                <xsl:value-of select="FieldName"/>_Area.Visible = false;
      </xsl:if>
      <xsl:if test="IsUse = 'true'"><xsl:if test="IsAdd = 'true'"><xsl:if test="IsFromDataSet = 'false'">
                <xsl:value-of select="FieldName"/>_Area.Visible = true;
      </xsl:if></xsl:if></xsl:if>
    </xsl:for-each>
            }
            if (ViewMode)
            {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:sort data-type="number" order="ascending" select="OrderID"/>
      <xsl:if test="IsUse = 'true'">
            <xsl:choose>
                <xsl:when test="ControlTypeName = 'DropDownList'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'RadioButtonList'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'CheckBoxList'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'CheckBoxListEx'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'RadioButton'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'CheckBox'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'TextBox'">
                <xsl:value-of select="FieldName"/>.Enabled = false;
                </xsl:when>
                <xsl:when test="ControlTypeName = 'Label'">
                </xsl:when>
                <xsl:when test="ControlType = 'GridDataBind'">
                <xsl:value-of select="FieldName"/>.EditMode=false;
                </xsl:when>
                <xsl:otherwise>
                <xsl:value-of select="FieldName"/>.ReadOnly = true;
                </xsl:otherwise>
            </xsl:choose>
      <xsl:if test="IsShowDetail = 'false'">
                <xsl:value-of select="FieldName"/>_Area.Visible = false;
      </xsl:if>
      </xsl:if>
    </xsl:for-each>
            }
	<xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
		<xsl:if test="CustomPermissionType = 'SearchPage'">
			<xsl:if test="Hidden = 'true'">
				if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
				{
                <xsl:value-of select="FieldName"/>_Area.Visible = false;
				}</xsl:if>
			<xsl:if test="View = 'true'">
				if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
				{
                <xsl:value-of select="FieldName"/>.Enabled = false;
				}</xsl:if>
		</xsl:if>
		<xsl:if test="CustomPermissionType = 'AddPage'">
			<xsl:if test="Hidden = 'true'">
				if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
				{
                <xsl:value-of select="FieldName"/>_Area.Visible = false;
				}</xsl:if>
			<xsl:if test="View = 'true'">
				if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
				{
                <xsl:value-of select="FieldName"/>.Enabled = false;
				}</xsl:if>
		</xsl:if>
	</xsl:for-each>
        }
    }
    
    protected override string GetObjectID()
    {
		        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
	<xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
		<xsl:if test="CustomPermissionType = 'AddPage'">
			<xsl:if test="Condition = 'true'">
				if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
				{
                    appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="ConditionValue"/>;
				}</xsl:if>
		</xsl:if>
	</xsl:for-each>
                appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ALL;
                appData.PageSize = 1;
                appData.CurrentPage = 1;
                QueryRecord();
                if (appData.RecordCount == 1)
                {
                    return GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]);
                }
                else
                {
                    return string.Empty;
                }
    }
}
</xsl:template>
</xsl:stylesheet>
