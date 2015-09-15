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
            appData = new DictionaryApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
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
    /// �õ�����û������������
    /// </summary>
    //=====================================================================
    protected override Boolean GetAddInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������

        validateData = ValidateDM(DM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DM = Convert.ToString(validateData.Value.ToString());
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
    /// ���͵�����������
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

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "Dictionary", dt, true, true);
        DictionaryApplicationLogic instanceDictionaryApplicationLogic = (DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new DictionaryApplicationData();

            int i = 0;

            appData = instanceDictionaryApplicationLogic.Add(appData);
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

        return dt;
    }

    protected void btnInfoFromDS_Click(object sender, EventArgs e)
    {
        int totalCount = 0;
        int importCount = 0;
        int updateCount = 0;
        try
        {
            var appDatas = DictionaryApplicationData.GetDataFromDataFile<DictionaryApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: DictionaryContants.ImportDataSetStartLineNum);
            DictionaryApplicationLogic instanceDictionaryApplicationLogic = (DictionaryApplicationLogic)CreateApplicationLogicInstance(typeof(DictionaryApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                if(!DM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DM =  Convert.ToString(DM.Text);
                }
    
                string strLX = GetValue(new RICH.Common.BM.DictionaryType.DictionaryTypeApplicationLogicBase().GetValueByFixCondition("MC", app.LX, "DM"));
                if (!DataValidateManager.ValidateIsNull(strLX))app.LX = strLX;
                if(!LX.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.LX =  Convert.ToString(LX.SelectedValue);
                }
    
                if(!MC.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.MC =  Convert.ToString(MC.Text);
                }
    
                string strSJDM = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.SJDM, "DM"));
                if (!DataValidateManager.ValidateIsNull(strSJDM))app.SJDM = strSJDM;
                if(!SJDM.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.SJDM =  Convert.ToString(SJDM.SelectedValue);
                }
    
                if(!SM.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.SM =  Convert.ToString(SM.Text);
                }
    
                instanceDictionaryApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceDictionaryApplicationLogic.Modify(app);
                    if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                    {
                        updateCount++;
                    }
                }
            }
            MessageContent += @"<font color=""green"">��{0}�����ݣ���������{1}������������{2}����</font>".FormatInvariantCulture(totalCount, importCount, updateCount);
        }
        catch (Exception ex)
        {
            MessageContent += @"<font color=""red"">�������ݹ��̳���{0}<br/>��{1}�����ݣ��ѵ�������{2}�����Ѹ�������{3}����</font>".FormatInvariantCulture(ex.Message, totalCount, importCount, updateCount);
        }
    }

    protected override void CheckPermission()
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
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      DM_Area.Visible = false;
      DM_Area.Visible = true;
      LX_Area.Visible = false;
      LX_Area.Visible = true;
      MC_Area.Visible = false;
      MC_Area.Visible = true;
      SJDM_Area.Visible = false;
      SJDM_Area.Visible = true;
      SM_Area.Visible = false;
      SM_Area.Visible = true;
      
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
                
            }
    
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new DictionaryApplicationData();
    
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

