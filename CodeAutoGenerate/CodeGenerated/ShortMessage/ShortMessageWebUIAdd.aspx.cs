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
DXXNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new ShortMessageApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
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
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DXXBT = Convert.ToString(validateData.Value.ToString());
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
            }
            DXXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DXXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        if (DXXFJ.Upload())
        {
            appData.DXXFJ = DXXFJ.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + DXXFJ.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateJSR(JSR.SelectedValues, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JSR = Convert.ToString(validateData.Value.ToString());
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
                
        if (DXXFJ.Upload())
        {
            appData.DXXFJ = DXXFJ.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + DXXFJ.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateJSR(JSR.SelectedValues, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JSR = Convert.ToString(validateData.Value.ToString());
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

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "ShortMessage", dt, true, true);
        ShortMessageApplicationLogic instanceShortMessageApplicationLogic = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new ShortMessageApplicationData();

            int i = 0;

            appData = instanceShortMessageApplicationLogic.Add(appData);
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
            var appDatas = ShortMessageApplicationData.GetDataFromDataFile<ShortMessageApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: ShortMessageContants.ImportDataSetStartLineNum);
            ShortMessageApplicationLogic instanceShortMessageApplicationLogic = (ShortMessageApplicationLogic)CreateApplicationLogicInstance(typeof(ShortMessageApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                if(!DXXBT.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DXXBT =  Convert.ToString(DXXBT.Text);
                }
    
                app.DXXLX = "01";
                if(!DXXNR.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DXXNR =  Convert.ToString(DXXNR.Text);
                }
    
                if(!DXXFJ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.DXXFJ =  Convert.ToString(DXXFJ.Text);
                }
    
                app.FSSJ = DateTime.Now;
                app.FSR = (string)Session[ConstantsManager.SESSION_USER_ID];
                string strFSR = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.FSR, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strFSR))app.FSR = strFSR;
                app.FSBM = (string)Session[ConstantsManager.SESSION_SSDW_ID];
                string strFSBM = GetValue(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogicBase().GetValueByFixCondition("DWMC", app.FSBM, "DWBH"));
                if (!DataValidateManager.ValidateIsNull(strFSBM))app.FSBM = strFSBM;
                app.FSIP = (string)Request.ServerVariables["REMOTE_ADDR"];
                string strJSR = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.JSR, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strJSR))app.JSR = strJSR;
                if(!JSR.SelectedValues.IsHtmlNullOrWiteSpace()) 
                {
                    app.JSR =  Convert.ToString(JSR.SelectedValues);
                }
    
                instanceShortMessageApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceShortMessageApplicationLogic.Modify(app);
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
      DXXBT.Enabled = false;
                DXXLX_Area.Visible = false;
      DXXNR.ReadOnly = true;
                DXXFJ.ReadOnly = true;
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
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      DXXBT_Area.Visible = false;
      DXXBT_Area.Visible = true;
      DXXLX_Area.Visible = false;
      DXXNR_Area.Visible = false;
      DXXNR_Area.Visible = true;
      DXXFJ_Area.Visible = false;
      DXXFJ_Area.Visible = true;
      FSSJ_Area.Visible = false;
      FSR_Area.Visible = false;
      FSBM_Area.Visible = false;
      FSIP_Area.Visible = false;
      JSR_Area.Visible = false;
      JSR_Area.Visible = true;
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
                DXXFJ.ReadOnly = true;
                FSSJ.Enabled = false;
                FSR.Enabled = false;
                FSBM.Enabled = false;
                FSIP.Enabled = false;
                FSIP_Area.Visible = false;
      JSR.ReadOnly = true;
                SFCK.Enabled = false;
                SFCK_Area.Visible = false;
      CKSJ.Enabled = false;
                CKSJ_Area.Visible = false;
      
            }
    
                if(CustomPermission == SJX_PURVIEW_ID)
                {
                SFCK_Area.Visible = false;
                }
                if(CustomPermission == FJX_PURVIEW_ID)
                {
                FSR_Area.Visible = false;
                }
                if(CustomPermission == FJX_PURVIEW_ID)
                {
                FSBM_Area.Visible = false;
                }
                if(CustomPermission == FJX_PURVIEW_ID)
                {
                SFCK_Area.Visible = false;
                }
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new ShortMessageApplicationData();
    
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

