/****************************************************** 
FileName:DictionaryWebUIAdd.aspx.cs
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
using RICH.Common.BM.Dictionary;

public partial class DictionaryWebUIAdd : RICH.Common.BM.Dictionary.DictionaryWebUI
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
        // ����SESSION��ֵ
        Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + WEBUI_ADD_FILENAME;
        if (EditMode)
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_MODIFY_ACCESS_PURVIEW_ID;
        }
        else if (ViewMode)
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_DETAIL_ACCESS_PURVIEW_ID;
        }
        else if (AddMode)
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = WEBUI_ADD_ACCESS_PURVIEW_ID;
        }
        else
        {
            Session[ConstantsManager.SESSION_CURRENT_PURVIEW] = NO_ACCESS_PURVIEW_ID;
        }
        MessageContent = string.Empty;
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
            // ��ʼ���Զ��������ֶ�
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


        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new DictionaryApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    DM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DM"]); 
                    LX.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["LX"]); 
                    MC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["MC"]); 
                    LXCoupled();
                SJDM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJDM"]); 
                    SM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SM"]); 
                    
            }
        }
            if (AddMode)
            {
                // ��ʼ���������

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["LX"]))
                {
                    LX.SelectedValue = GetValue(Request.QueryString["LX"]); 
                    LX.Enabled = false;
                }
            LXCoupled();
      
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["SJDM"]))
                {
                    SJDM.SelectedValue = GetValue(Request.QueryString["SJDM"]); 
                    SJDM.Enabled = false;
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

        // ��ʼ������(LX)�����б�
          LX.DataSource = GetDataSource_LX();
        LX.DataTextField = "MC";
        LX.DataValueField = "DM";
              LX.DataBind();
        
        // ��ʼ���ϼ�����(SJDM)�����б�
        SJDM.DataTextField = "MC";
        SJDM.DataValueField = "DM";
        LXCoupled();
    
    }

    //=====================================================================
    //  FunctionName : GetAddInputParameter
    /// <summary>
    /// �õ������û������������
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������

        validateData = ValidateDM(DM.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DM = Convert.ToString(validateData.Value.ToString());
                DM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            DM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateLX(LX.SelectedValue, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.LX = Convert.ToString(validateData.Value.ToString());
                LX_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            LX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateMC(MC.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.MC = Convert.ToString(validateData.Value.ToString());
                MC_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            MC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            MC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SJDM = Convert.ToString(validateData.Value.ToString());
                SJDM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            SJDM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJDM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSM(SM.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SM = Convert.ToString(validateData.Value.ToString());
                SM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            SM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // �Զ����ɱ��

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
        appData = RICH.Common.BM.Dictionary.DictionaryBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateDM(DM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DM = Convert.ToString(validateData.Value.ToString());
                DM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.DM = null;
            }
            DM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateLX(LX.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.LX = Convert.ToString(validateData.Value.ToString());
                LX_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.LX = null;
            }
            LX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            LX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateMC(MC.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.MC = Convert.ToString(validateData.Value.ToString());
                MC_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.MC = null;
            }
            MC.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            MC.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSJDM(SJDM.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SJDM = Convert.ToString(validateData.Value.ToString());
                SJDM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.SJDM = null;
            }
            SJDM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SJDM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSM(SM.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SM = Convert.ToString(validateData.Value.ToString());
                SM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.SM = null;
            }
            SM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SM.BackColor = System.Drawing.Color.YellowGreen;
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

        // ������������
        LX.AutoPostBack = true;
        LX.SelectedIndexChanged += new System.EventHandler(this.LX_SelectedIndexChanged);
  
    }


    //=====================================================================
    //  FunctionName : LX_SelectedIndexChanged
    /// <summary>
    /// ���͵�SelectedIndexChanged�¼�
    /// </summary>
    //=====================================================================
    protected void LX_SelectedIndexChanged(object sender, EventArgs e)
    {
        LXCoupled();
    }

    //=====================================================================
    //  FunctionName : LXCoupled()
    /// <summary>
    /// ���͵�������������
    /// </summary>
    //=====================================================================
    protected void LXCoupled()
    {
        if (!DataValidateManager.ValidateIsNull(LX.SelectedValue))
        {
            SJDM.DataSource = GetDataSource_SJDM("LX", LX.SelectedValue);
            SJDM.DataBind();
            if (!(SJDM.Items.Count > 0))
            {
                SJDM.Items.Insert(0, new ListItem("��", ""));
            }
            
            else
            {
                SJDM.Items.Insert(0, new ListItem("��ѡ��", ""));    
            }
            
        }
        else
        {
            SJDM.Items.Clear();
            SJDM.Items.Insert(0, new ListItem("����ѡ������", ""));
        }
    }
  
    //=====================================================================
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// ��ʼ���Զ�������
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // ����������ر���Ϣ

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// ��ʼ����������ģ��
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
    /// ��ر���������
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
	  DM.Enabled = false;
                LX.Enabled = false;
                
			}
			else if(AddMode || CopyMode)
			{
	ObjectID_Area.Visible = false;
	  
			}
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      DM.Enabled = false;
                LX.Enabled = false;
                MC.Enabled = false;
                SJDM.Enabled = false;
                SM.Enabled = false;
                
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
