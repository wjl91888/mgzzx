/****************************************************** 
FileName:T_BG_0601WebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BG_0601;

public partial class T_BG_0601WebUIAdd : RICH.Common.BM.T_BG_0601.T_BG_0601WebUI
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
XXNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_BG_0601ApplicationData
                          {
                              ObjectID = base.ObjectID,
                              OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                          };
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    FBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBH"]); 
                    BT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BT"]); 
                    FBLM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBLM"]); 
                    FBBM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBBM"]); 
                    XXLX.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["XXLX"]); 
                    XXTPDZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XXTPDZ"]); 
                    XXNR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XXNR"]); 
                    FJXZDZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FJXZDZ"]); 
                    XXZT.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["XXZT"]); 
                    IsTop.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["IsTop"]); 
                    TopSort.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["TopSort"]); 
                    IsBest.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["IsBest"]); 
                    FBRJGH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBRJGH"]); 
                    FBSJRQ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBSJRQ"]); 
                    FBIP.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBIP"]); 
                    
            }
        }
            if (AddMode)
            {
                // ��ʼ���������

                if (!DataValidateManager.ValidateIsNull(Request.QueryString["FBLM"]))
                {
                    FBLM.SelectedValue = GetValue(Request.QueryString["FBLM"]); 
                    FBLM.Enabled = false;
                }
            
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["FBBM"]))
                {
                    FBBM.SelectedValue = GetValue(Request.QueryString["FBBM"]); 
                    FBBM.Enabled = false;
                }
            
                // ��ʼ��Ĭ��ֵ
FBBM.SelectedValue = CurrentUserInfo.SubjectID; 

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

        // ��ʼ��������Ŀ(FBLM)�����б�
          FBLM.DataSource = GetDataSource_FBLM();
        FBLM.DataTextField = "LMM";
        FBLM.DataValueField = "LMH";
              FBLM.DataBind();
        
        // ��ʼ����������(FBBM)�����б�
          FBBM.DataSource = GetDataSource_FBBM();
        FBBM.DataTextField = "DWMC";
        FBBM.DataValueField = "DWBH";
              FBBM.DataBind();
        FBBM.Items.Insert(0, new ListItem("��ѡ�񷢲�����", ""));
              
        // ��ʼ����Ϣ����(XXLX)�����б�
          XXLX.DataSource = GetDataSource_XXLX();
        XXLX.DataTextField = "MC";
        XXLX.DataValueField = "DM";
              XXLX.DataBind();
        
        // ��ʼ����Ϣ״̬(XXZT)�����б�
          XXZT.DataSource = GetDataSource_XXZT();
        XXZT.DataTextField = "MC";
        XXZT.DataValueField = "DM";
              XXZT.DataBind();
        XXZT.Items.Insert(0, new ListItem("��ѡ����Ϣ״̬", ""));
              
        // ��ʼ���Ƿ��ö�(IsTop)�����б�
          IsTop.DataSource = GetDataSource_IsTop();
        IsTop.DataTextField = "MC";
        IsTop.DataValueField = "DM";
              IsTop.DataBind();
        IsTop.Items.Insert(0, new ListItem("��ѡ���Ƿ��ö�", ""));
              
        // ��ʼ���Ƽ�(IsBest)�����б�
          IsBest.DataSource = GetDataSource_IsBest();
        IsBest.DataTextField = "MC";
        IsBest.DataValueField = "DM";
              IsBest.DataBind();
        IsBest.Items.Insert(0, new ListItem("��ѡ���Ƽ�", ""));
              
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

        validateData = ValidateBT(BT.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.BT = Convert.ToString(validateData.Value.ToString());
            }
            BT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBLM(FBLM.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.FBLM = Convert.ToString(validateData.Value.ToString());
            }
            FBLM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBLM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBBM(FBBM.SelectedValue, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.FBBM = Convert.ToString(validateData.Value.ToString());
            }
            FBBM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBBM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXLX(XXLX.SelectedValue, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.XXLX = Convert.ToString(validateData.Value.ToString());
            }
            XXLX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXLX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (XXTPDZ.Upload())
        {
            appData.XXTPDZ = XXTPDZ.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + XXTPDZ.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateXXNR(XXNR.Text, false, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.XXNR = Convert.ToString(validateData.Value.ToString());
            }
            XXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (FJXZDZ.Upload())
        {
            appData.FJXZDZ = FJXZDZ.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + FJXZDZ.Message + "</font>";
            boolReturn = false;
        }
        
        appData.XXZT = "02";
            
        validateData = ValidateIsTop(IsTop.SelectedValue, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.IsTop = Convert.ToString(validateData.Value.ToString());
            }
            IsTop.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            IsTop.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateTopSort(TopSort.Text, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.TopSort = Convert.ToInt32(validateData.Value.ToString());
            }
            TopSort.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            TopSort.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateIsBest(IsBest.SelectedValue, true, false);
        if (validateData.Result)
        {                
            if (!validateData.IsNull)
            {
                appData.IsBest = Convert.ToString(validateData.Value.ToString());
            }
            IsBest.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            IsBest.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        appData.FBRJGH = (string)Session[ConstantsManager.SESSION_USER_ID];
            
        appData.FBSJRQ = DateTime.Now;
            
        appData.FBIP = (string)Request.ServerVariables["REMOTE_ADDR"];
            
        // �Զ����ɱ��
T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
            = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
        appData.FBH = instanceT_BG_0601ApplicationLogic.AutoGenerateFBH(appData);
                
        appData.XXZT = "02";

        appData.FBRJGH = (string)Session[ConstantsManager.SESSION_USER_ID];

        appData.FBSJRQ = DateTime.Now;

        appData.FBIP = (string)Request.ServerVariables["REMOTE_ADDR"];

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
        appData = RICH.Common.BM.T_BG_0601.T_BG_0601BusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateFBH(FBH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FBH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.FBH = null;
            }
            FBH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBT(BT.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BT = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.BT = null;
            }
            BT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBLM(FBLM.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FBLM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.FBLM = null;
            }
            FBLM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBLM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBBM(FBBM.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FBBM = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.FBBM = null;
            }
            FBBM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBBM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXLX(XXLX.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXLX = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.XXLX = null;
            }
            XXLX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXLX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (XXTPDZ.Upload())
        {
            appData.XXTPDZ = XXTPDZ.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + XXTPDZ.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateXXNR(XXNR.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXNR = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.XXNR = null;
            }
            XXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        if (FJXZDZ.Upload())
        {
            appData.FJXZDZ = FJXZDZ.Text;
        }
        else
        {
            MessageContent += @"<font color=""red"">" + FJXZDZ.Message + "</font>";
            boolReturn = false;
        }
        
        validateData = ValidateXXZT(XXZT.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXZT = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.XXZT = null;
            }
            XXZT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXZT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateIsTop(IsTop.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.IsTop = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.IsTop = null;
            }
            IsTop.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            IsTop.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateTopSort(TopSort.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.TopSort = Convert.ToInt32(validateData.Value.ToString());
            }
            TopSort.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            TopSort.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateIsBest(IsBest.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.IsBest = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.IsBest = null;
            }
            IsBest.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            IsBest.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBRJGH(FBRJGH.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FBRJGH = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.FBRJGH = null;
            }
            FBRJGH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBRJGH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBSJRQ(FBSJRQ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FBSJRQ = Convert.ToDateTime(validateData.Value.ToString());
            }
            FBSJRQ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBSJRQ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFBIP(FBIP.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FBIP = Convert.ToString(validateData.Value.ToString());
            }
                        
            else
            {
                appData.FBIP = null;
            }
            FBIP.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBIP.BackColor = System.Drawing.Color.YellowGreen;
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
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BG_0601", dt, true, true);
        T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BG_0601ApplicationData();

            appData.FBH = instanceT_BG_0601ApplicationLogic.AutoGenerateFBH(appData);
                
            int i = 0;

            appData = instanceT_BG_0601ApplicationLogic.Add(appData);
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
            var appDatas = T_BG_0601ApplicationData.GetDataFromDataFile<T_BG_0601ApplicationData>(InfoFromDoc.Text, true, true, recordStartLine: T_BG_0601Contants.ImportDataSetStartLineNum);
            T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
            totalCount = appDatas.Count;
            foreach (var app in appDatas)
            {
    
                app.FBH = instanceT_BG_0601ApplicationLogic.AutoGenerateFBH(app);
                    
                if(!BT.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.BT =  Convert.ToString(BT.Text);
                }
    
                string strFBLM = GetValue(new RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogicBase().GetValueByFixCondition("LMM", app.FBLM, "LMH"));
                if (!DataValidateManager.ValidateIsNull(strFBLM))app.FBLM = strFBLM;
                if(!FBLM.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.FBLM =  Convert.ToString(FBLM.SelectedValue);
                }
    
                string strFBBM = GetValue(new RICH.Common.BM.T_BM_DWXX.T_BM_DWXXApplicationLogicBase().GetValueByFixCondition("DWMC", app.FBBM, "DWBH"));
                if (!DataValidateManager.ValidateIsNull(strFBBM))app.FBBM = strFBBM;
                if(!FBBM.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.FBBM =  Convert.ToString(FBBM.SelectedValue);
                }
    
                string strXXLX = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.XXLX, "DM"));
                if (!DataValidateManager.ValidateIsNull(strXXLX))app.XXLX = strXXLX;
                if(!XXLX.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.XXLX =  Convert.ToString(XXLX.SelectedValue);
                }
    
                if(!XXTPDZ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.XXTPDZ =  Convert.ToString(XXTPDZ.Text);
                }
    
                if(!XXNR.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.XXNR =  Convert.ToString(XXNR.Text);
                }
    
                if(!FJXZDZ.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.FJXZDZ =  Convert.ToString(FJXZDZ.Text);
                }
    
                app.XXZT = "02";
                string strXXZT = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.XXZT, "DM"));
                if (!DataValidateManager.ValidateIsNull(strXXZT))app.XXZT = strXXZT;
                string strIsTop = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.IsTop, "DM"));
                if (!DataValidateManager.ValidateIsNull(strIsTop))app.IsTop = strIsTop;
                if(!IsTop.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.IsTop =  Convert.ToString(IsTop.SelectedValue);
                }
    
                if(!TopSort.Text.IsHtmlNullOrWiteSpace()) 
                {
                    app.TopSort =  Convert.ToInt32(TopSort.Text);
                }
    
                string strIsBest = GetValue(new RICH.Common.BM.Dictionary.DictionaryApplicationLogicBase().GetValueByFixCondition("MC", app.IsBest, "DM"));
                if (!DataValidateManager.ValidateIsNull(strIsBest))app.IsBest = strIsBest;
                if(!IsBest.SelectedValue.IsHtmlNullOrWiteSpace()) 
                {
                    app.IsBest =  Convert.ToString(IsBest.SelectedValue);
                }
    
                app.FBRJGH = (string)Session[ConstantsManager.SESSION_USER_ID];
                string strFBRJGH = GetValue(new RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoApplicationLogicBase().GetValueByFixCondition("UserNickName", app.FBRJGH, "UserID"));
                if (!DataValidateManager.ValidateIsNull(strFBRJGH))app.FBRJGH = strFBRJGH;
                app.FBSJRQ = DateTime.Now;
                app.FBIP = (string)Request.ServerVariables["REMOTE_ADDR"];
                instanceT_BG_0601ApplicationLogic.Add(app);
                if (app.ResultCode == RICH.Common.Base.ApplicationData.ApplicationDataBase.ResultState.Succeed)
                {
                    importCount++;
                }
                else
                {
                    app.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
                    instanceT_BG_0601ApplicationLogic.Modify(app);
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
      FBH.Enabled = false;
                FBRJGH.Enabled = false;
                FBSJRQ.Enabled = false;
                FBIP.Enabled = false;
                
            }
            else if(AddMode || CopyMode)
            {
    ObjectID_Area.Visible = false;
      FBH_Area.Visible = false;
      XXZT_Area.Visible = false;
      FBRJGH_Area.Visible = false;
      FBSJRQ_Area.Visible = false;
      FBIP_Area.Visible = false;
      
            }
            if(ImportDSMode)
            {
    ObjectID_Area.Visible = false;
      FBH_Area.Visible = false;
      BT_Area.Visible = false;
      BT_Area.Visible = true;
      FBLM_Area.Visible = false;
      FBLM_Area.Visible = true;
      FBBM_Area.Visible = false;
      FBBM_Area.Visible = true;
      XXLX_Area.Visible = false;
      XXLX_Area.Visible = true;
      XXTPDZ_Area.Visible = false;
      XXTPDZ_Area.Visible = true;
      XXNR_Area.Visible = false;
      XXNR_Area.Visible = true;
      FJXZDZ_Area.Visible = false;
      FJXZDZ_Area.Visible = true;
      XXZT_Area.Visible = false;
      IsTop_Area.Visible = false;
      IsTop_Area.Visible = true;
      TopSort_Area.Visible = false;
      TopSort_Area.Visible = true;
      IsBest_Area.Visible = false;
      IsBest_Area.Visible = true;
      FBRJGH_Area.Visible = false;
      FBSJRQ_Area.Visible = false;
      FBIP_Area.Visible = false;
      
            }
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      FBH.Enabled = false;
                FBH_Area.Visible = false;
      BT.Enabled = false;
                FBLM.Enabled = false;
                FBBM.Enabled = false;
                XXLX.Enabled = false;
                XXLX_Area.Visible = false;
      XXTPDZ.ReadOnly = true;
                XXNR.ReadOnly = true;
                FJXZDZ.ReadOnly = true;
                XXZT.Enabled = false;
                XXZT_Area.Visible = false;
      IsTop.Enabled = false;
                IsTop_Area.Visible = false;
      TopSort.Enabled = false;
                TopSort_Area.Visible = false;
      IsBest.Enabled = false;
                IsBest_Area.Visible = false;
      FBRJGH.Enabled = false;
                FBSJRQ.Enabled = false;
                FBIP.Enabled = false;
                
            }
    
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                FBH_Area.Visible = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                FBLM.Enabled = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                FBBM.Enabled = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                XXZT_Area.Visible = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                IsTop_Area.Visible = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                TopSort_Area.Visible = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                IsBest_Area.Visible = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                FBRJGH_Area.Visible = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                FBRJGH.Enabled = false;
                }
                if(CustomPermission == WFBD_PURVIEW_ID)
                {
                FBIP_Area.Visible = false;
                }
        }
    }
    
    protected override string GetObjectID()
    {
                appData = new T_BG_0601ApplicationData();
    
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

