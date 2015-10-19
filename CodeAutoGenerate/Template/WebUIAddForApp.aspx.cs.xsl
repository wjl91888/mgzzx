<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIAddForApp.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {
                // ��ʼ��������
                InitalizeDataBind();
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
                // ȫ�ֳ�ʼ��
                Initalize();
            }
            else
            {
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // ��ʼ������
    <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="ControlType = 'ʱ����������'">
        <xsl:if test="IsAdd = 'true'">
            <xsl:value-of select="FieldName"/>.Attributes.Add("onclick", "setday(this);");</xsl:if></xsl:if>
    <xsl:if test="ControlType = 'RICH��ѡ��'">
        <xsl:if test="IsAdd = 'true'">
            <xsl:value-of select="FieldName"/>.RepeatColumns = 1;</xsl:if>
        </xsl:if>
    <xsl:if test="ControlType = '�����'">
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

            // ����ؼ�״̬
            if(ViewMode || EditMode || CopyMode)
            {
                // ��ȡҪ�޸ļ�¼��ϸ����
                appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // �ؼ���ֵ
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
                        <xsl:when test="ControlType = '�����'">
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
                    // ��ʼ���������
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
                    // ��ʼ��Ĭ��ֵ
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
        /// ��ʼ�����ݰ�
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
            // ��ʼ��<xsl:value-of select="FieldRemark"/>(<xsl:value-of select="FieldName"/>)�����б�
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
                  <xsl:when test="ControlType = 'RICH��ѡ��'">
                  </xsl:when>
                  <xsl:otherwise>
            <xsl:value-of select="FieldName"/>.Items.Insert(0, new ListItem("��ѡ��<xsl:value-of select="FieldRemark"/>", ""));
                  </xsl:otherwise>
              </xsl:choose>
            </xsl:if>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:if>
        <xsl:if test="IsCoupledNext = 'true'">
            // ��ʼ��<xsl:value-of select="FieldRemark"/>(<xsl:value-of select="FieldName"/>)�����б�
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
        /// �õ�����û������������
        /// </summary>
        //=====================================================================
        protected override Boolean GetAddInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // ��֤�������
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
            <xsl:when test="ControlType = '�����'">
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
                MessageContent += @"<![CDATA[<font color=""red"">�������벻һ�£����������롣</font>]]>";
                boolReturn = false;
            }
                </xsl:if>
            </xsl:when>
            <xsl:when test="DBType = 'Image'">
            // ͼ�����ݴ���
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
                <xsl:when test="ControlType = '�����'">
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
                MessageContent += @"<![CDATA[<font color=""red"">�������벻һ�£����������롣</font>]]>";
                boolReturn = false;
            }
                    </xsl:if>
                </xsl:when>
                <xsl:when test="DBType = 'Image'">
            // ͼ�����ݴ���
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
            // �Զ����ɱ��
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
        /// �õ��޸��û������������
        /// </summary>
        //=====================================================================
        protected override Boolean GetModifyInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // ��֤�������
            appData = RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.GetDataByObjectID(base.ObjectID);
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
            // ͼ�����ݴ���
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
          <xsl:when test="ControlType = '�����'">
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
                MessageContent += @"<![CDATA[<font color=""red"">�������벻һ�£����������롣</font>]]>";
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
        /// ��ʼ����������
        /// </summary>
        //=====================================================================
        protected void InitalizeCoupledDataSource()
        {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:if test="IsCoupled = 'true'">
        <xsl:if test="IsDataBind = 'true'">
            <xsl:if test="IsAdd = 'true'">
            // <xsl:value-of select="FieldRemark"/>��������
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
        /// <xsl:value-of select="FieldRemark"/>��SelectedIndexChanged�¼�
        /// </summary>
        //=====================================================================
        protected void <xsl:value-of select="FieldName"/>_SelectedIndexChanged(object sender, EventArgs e)
        {
            <xsl:value-of select="FieldName"/>Coupled();
        }

        //=====================================================================
        //  FunctionName : <xsl:value-of select="FieldName"/>Coupled()
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/>������������
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
                    <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("��", ""));
                }
                <xsl:if test="IsNull = 'false'">
                else
                {
                    <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("��ѡ��", ""));    
                }
                </xsl:if>
            }
            else
            {
                <xsl:value-of select="CoupledDataSource"/>.Items.Clear();
                <xsl:value-of select="CoupledDataSource"/>.Items.Insert(0, new ListItem("����ѡ��<xsl:value-of select="FieldRemark"/>", ""));
            }
        }
      </xsl:if></xsl:if></xsl:if>
    </xsl:for-each>

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        <xsl:for-each select="/NewDataSet/CustomConditionConfig">
        <xsl:if test="CustomConditionTemplate = $FileName">
            <xsl:if test="CustomConditionType = 'Modify'">
                  <xsl:value-of select="CustomConditionFieldName"/>Container.Visible = false;
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
                    <xsl:value-of select="FieldName"/>Container.Visible = false;
          </xsl:if>
          </xsl:if>
        </xsl:for-each>
                }
                else if(AddMode || CopyMode)
                {
        <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:if test="IsUse = 'true'">
          <xsl:if test="IsAdd = 'false'">
                    <xsl:value-of select="FieldName"/>Container.Visible = false;
          </xsl:if>
          </xsl:if>
        </xsl:for-each>
        <xsl:for-each select="/NewDataSet/CustomConditionConfig">
        <xsl:if test="CustomConditionTemplate = $FileName">
            <xsl:if test="CustomConditionType = 'Add'">
                    <xsl:value-of select="CustomConditionFieldName"/>Container.Visible = false;
            </xsl:if>
        </xsl:if>
        </xsl:for-each>
                }
                if(ImportDSMode)
                {
        <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:if test="IsUse = 'true'">
                    <xsl:value-of select="FieldName"/>Container.Visible = false;
          </xsl:if>
          <xsl:if test="IsUse = 'true'"><xsl:if test="IsAdd = 'true'"><xsl:if test="IsFromDataSet = 'false'">
                    <xsl:value-of select="FieldName"/>Container.Visible = true;
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
                    <xsl:value-of select="FieldName"/>Container.Visible = false;
          </xsl:if>
          </xsl:if>
        </xsl:for-each>
                }
        <xsl:for-each select="/NewDataSet/CustomPermissionFieldConfig">
            <xsl:if test="CustomPermissionType = 'SearchPage'">
                <xsl:if test="Hidden = 'true'">
                    if(CustomPermission == <xsl:value-of select="CustomPermissionName"/>_PURVIEW_ID)
                    {
                    <xsl:value-of select="FieldName"/>Container.Visible = false;
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
                    <xsl:value-of select="FieldName"/>Container.Visible = false;
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
}
</xsl:template>
</xsl:stylesheet>
