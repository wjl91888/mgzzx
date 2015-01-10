/****************************************************** 
FileName:ShortMessageWebUIAdd.aspx.cs
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
using RICH.Common.BM.ShortMessage;

public partial class ShortMessageWebUIAdd : RICH.Common.BM.ShortMessage.ShortMessageWebUI
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
            // ��ʼ��������
            InitalizeDataBind();
            // ��ʼ����ϰ�����
            InitalizeCoupledDataSource();
            // ȫ�ֳ�ʼ��
            Initalize();
            // ��ʼ���Զ�������ֶ�
            InitalizeCustomAdd();
            // ��ر����
            InitalizeRelatedTableAdd();
        }
        else
        {
            // ��ʼ����ϰ�����
            InitalizeCoupledDataSource();
        }
        base.Page_Load(sender, e);
        CheckPermission();
    }

    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// ���س�ʼ������
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {
        // ��ʼ������
DXXNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";DXXFJ.Attributes.Add("onclick", "uploadfile(this);");

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new ShortMessageApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    DXXBT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXBT"]); 
                    DXXLX.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXLX"]); 
                    DXXNR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXNR"]); 
                    DXXFJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DXXFJ"]); 
                    FSSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSSJ"]); 
                    FSR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSR"]); 
                    FSBM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSBM"]); 
                    FSIP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FSIP"]); 
                    JSR.SelectedValues = GetValue(appData.ResultSet.Tables[0].Rows[0]["JSR"]); 
                    SFCK.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFCK"]); 
                    CKSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["CKSJ"]); 
                    
            }
        }
            if (AddMode)
            {
                // ��ʼ���������

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["JSR"]))
                {
                    JSR.SelectedValues = GetValue(Request.QueryString["JSR"]); 
                    JSR.Enabled = false;
                }
            
                // ��ʼ��Ĭ��ֵ

            }

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

        // ��ʼ��������(JSR)�����б�
          JSR.DataSource = RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoBusinessEntity.GetTreeData_T_PM_UserInfo_SubjectID("UserID", "UserNickName",  null, "null", null);
        JSR.DataFieldID = "ID";
        JSR.DataFieldParentID = "ParentID";
        JSR.DataTextField = "Name";
        JSR.DataValueField = "ID";
        JSR.CheckBoxes = true;
        JSR.CheckChildNodes = true;
              JSR.DataBind();
        
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

        validateData = ValidateDXXBT(DXXBT.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DXXBT = Convert.ToString(validateData.Value.ToString());
                DXXBT_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            DXXBT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXBT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDXXNR(DXXNR.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DXXNR = Convert.ToString(validateData.Value.ToString());
                DXXNR_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            DXXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDXXFJ(DXXFJ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DXXFJ = Convert.ToString(validateData.Value.ToString());
                DXXFJ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            DXXFJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXFJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJSR(JSR.SelectedValues, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JSR = Convert.ToString(validateData.Value.ToString());
                JSR_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            JSR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // �Զ����ɱ��

        appData.DXXLX = "01";

        appData.FSSJ = DateTime.Now;

        appData.FSR = (string)Session[ConstantsManager.SESSION_USER_ID];

        appData.FSBM = (string)Session[ConstantsManager.SESSION_SSDW_ID];

        appData.FSIP = (string)Request.ServerVariables["REMOTE_ADDR"];

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
        appData = RICH.Common.BM.ShortMessage.ShortMessageBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateDXXBT(DXXBT.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXBT = Convert.ToString(validateData.Value.ToString());
                DXXBT_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.DXXBT = null;
            }
            DXXBT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXBT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDXXNR(DXXNR.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXNR = Convert.ToString(validateData.Value.ToString());
                DXXNR_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.DXXNR = null;
            }
            DXXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDXXFJ(DXXFJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXFJ = Convert.ToString(validateData.Value.ToString());
                DXXFJ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.DXXFJ = null;
            }
            DXXFJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXFJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJSR(JSR.SelectedValues, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JSR = Convert.ToString(validateData.Value.ToString());
                JSR_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.JSR = null;
            }
            JSR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
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

    }


    //=====================================================================
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// ��ʼ���Զ������
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // ���������ر���Ϣ

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// ��ʼ���������ģ��
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {

    }



    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// ��ر�������ദ��
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        string strSortClassify = string.Empty;
        GridView rptTemp = (GridView)sender;

    }

    //=====================================================================
    //  FunctionName : RelatedTableAddBatch()
    /// <summary>
    /// ��ر��������
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {

    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// ��ر������޸�
    /// </summary>
    //=====================================================================
    protected override void RelatedTableModifyBatch()
    {

    }



    public void CheckPermission()
    {
        if (AccessPermission)
        {
			if(EditMode)
			{
	ObjectID_Area.Visible = false;
	  DXXBT.Enabled = false;
                DXXLX_Area.Visible = false;
	  DXXNR.ReadOnly = true;
			    DXXFJ.Enabled = false;
                FSSJ_Area.Visible = false;
	  FSR_Area.Visible = false;
	  FSBM_Area.Visible = false;
	  FSIP_Area.Visible = false;
	  JSR.ReadOnly = true;
			    SFCK_Area.Visible = false;
	  CKSJ_Area.Visible = false;
	  
			}
			else if(AddMode || CopyMode)
			{
	ObjectID_Area.Visible = false;
	  DXXLX_Area.Visible = false;
	  FSSJ_Area.Visible = false;
	  FSR_Area.Visible = false;
	  FSBM_Area.Visible = false;
	  FSIP_Area.Visible = false;
	  SFCK_Area.Visible = false;
	  CKSJ_Area.Visible = false;
	  
			}
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      DXXBT.Enabled = false;
                DXXLX.Enabled = false;
                DXXLX_Area.Visible = false;
      DXXNR.ReadOnly = true;
                DXXFJ.Enabled = false;
                FSSJ.Enabled = false;
                FSR.Enabled = false;
                FSBM.Enabled = false;
                FSIP.Enabled = false;
                FSIP_Area.Visible = false;
      JSR.ReadOnly = true;
                JSR_Area.Visible = false;
      SFCK.Enabled = false;
                SFCK_Area.Visible = false;
      CKSJ.Enabled = false;
                CKSJ_Area.Visible = false;
      
      btnAddConfirm.Visible = false;
      btnReset.Visible = false;
    
            }
            else
            {
      btnEditItem.Visible = false;
    
            }
        }
        else
        {
            ControlContainer.Visible = false;
            btnAddConfirm.Visible = false;
            btnReset.Visible = false;
        
        }
    }
}

