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
XXTPDZ.Attributes.Add("onclick", "UplaodImageFile(this);");XXNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";FJXZDZ.Attributes.Add("onclick", "uploadfile(this);");

        // ����ؼ�״̬

        if(ViewMode || EditMode || CopyMode)
        {
            // ��ȡҪ�޸ļ�¼��ϸ����
            appData = new T_BG_0601ApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // �ؼ���ֵ
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    FBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBH"]); 
                    BT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BT"]); 
                    FBLM.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["FBLM"]); 
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

        // ��ʼ��������Ŀ(FBLM)�����б�
          FBLM.DataSource = GetDataSource_FBLM();
        FBLM.DataTextField = "LMM";
        FBLM.DataValueField = "LMH";
              FBLM.DataBind();
        
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.BT = Convert.ToString(validateData.Value.ToString());
                BT_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.FBLM = Convert.ToString(validateData.Value.ToString());
                FBLM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            FBLM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FBLM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXLX(XXLX.SelectedValue, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.XXLX = Convert.ToString(validateData.Value.ToString());
                XXLX_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            XXLX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXLX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXTPDZ(XXTPDZ.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.XXTPDZ = Convert.ToString(validateData.Value.ToString());
                XXTPDZ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            XXTPDZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXTPDZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXNR(XXNR.Text, false, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.XXNR = Convert.ToString(validateData.Value.ToString());
                XXNR_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            XXNR.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXNR.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFJXZDZ(FJXZDZ.Text, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.FJXZDZ = Convert.ToString(validateData.Value.ToString());
                FJXZDZ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
            FJXZDZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FJXZDZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        appData.XXZT = "02";
            
        validateData = ValidateIsTop(IsTop.SelectedValue, true, false);
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.IsTop = Convert.ToString(validateData.Value.ToString());
                IsTop_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.TopSort = Convert.ToInt32(validateData.Value.ToString());
                TopSort_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
        if (validateData.Result==true)
        {                
            if (validateData.IsNull==false)
            {
                appData.IsBest = Convert.ToString(validateData.Value.ToString());
                IsBest_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                FBH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                BT_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                FBLM_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                
        validateData = ValidateXXLX(XXLX.SelectedValue, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXLX = Convert.ToString(validateData.Value.ToString());
                XXLX_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                
        validateData = ValidateXXTPDZ(XXTPDZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXTPDZ = Convert.ToString(validateData.Value.ToString());
                XXTPDZ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.XXTPDZ = null;
            }
            XXTPDZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XXTPDZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXNR(XXNR.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXNR = Convert.ToString(validateData.Value.ToString());
                XXNR_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                
        validateData = ValidateFJXZDZ(FJXZDZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FJXZDZ = Convert.ToString(validateData.Value.ToString());
                FJXZDZ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
            }
                        
            else
            {
                appData.FJXZDZ = null;
            }
            FJXZDZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FJXZDZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXXZT(XXZT.SelectedValue, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XXZT = Convert.ToString(validateData.Value.ToString());
                XXZT_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                IsTop_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                TopSort_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                IsBest_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                FBRJGH_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                FBSJRQ_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
                FBIP_Note.InnerHtml = @"<font color=""gray"">������ȷ��</font>";
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
        AddFromDoc.Visible = false;
        addpage.Visible = true;
    }
    protected void btnImportFromDoc_Click(object sender, EventArgs e)
    {
        AddFromDoc.Visible = true;
        addpage.Visible = false;
    }
    protected void btnInfoFromDocCancel_Click(object sender, EventArgs e)
    {
        AddFromDoc.Visible = false;
        addpage.Visible = true;
    }
    private DataTable GetTemplateColumn(DataTable dt)
    {

        return dt;
    }

    protected void btnInfoFromDS_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWord(InfoFromDoc.Text, dt, true);
        if (dt.Rows.Count > 0)
        {
            int i = 0;

        }
        AddFromDoc.Visible = false;
        addpage.Visible = true;
    }

    public void CheckPermission()
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
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      FBH.Enabled = false;
                FBH_Area.Visible = false;
      BT.Enabled = false;
                FBLM.Enabled = false;
                XXLX.Enabled = false;
                XXTPDZ.Enabled = false;
                XXNR.ReadOnly = true;
                FJXZDZ.Enabled = false;
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

