/****************************************************** 
FileName:T_BM_GZXXWebUIAdd.aspx.cs
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
using RICH.Common.BM.T_BM_GZXX;

public partial class T_BM_GZXXWebUIAdd : RICH.Common.BM.T_BM_GZXX.T_BM_GZXXWebUI
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
        CheckPermission();
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


        // 界面控件状态

        if(ViewMode || EditMode || CopyMode)
        {
            // 读取要修改记录详细资料
            appData = new T_BM_GZXXApplicationData();
            appData.ObjectID = base.ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            // 控件赋值
            if (appData.RecordCount > 0)
            {
ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                    XM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XM"]); 
                    XB.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XB"]); 
                    SFZH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFZH"]); 
                    FFGZNY.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FFGZNY"]); 
                    JCGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JCGZ"]); 
                    JSDJGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JSDJGZ"]); 
                    ZWGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ZWGZ"]); 
                    JBGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JBGZ"]); 
                    JKDQJT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JKDQJT"]); 
                    JKTSGWJT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JKTSGWJT"]); 
                    GLGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["GLGZ"]); 
                    XJGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["XJGZ"]); 
                    TGBF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["TGBF"]); 
                    DHF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DHF"]); 
                    DSZNF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DSZNF"]); 
                    FNWSHLF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["FNWSHLF"]); 
                    HLF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["HLF"]); 
                    JJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JJ"]); 
                    JTF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JTF"]); 
                    JHLGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JHLGZ"]); 
                    JT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["JT"]); 
                    BF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BF"]); 
                    QTBT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["QTBT"]); 
                    DFXJT.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DFXJT"]); 
                    YFX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YFX"]); 
                    QTKK.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["QTKK"]); 
                    SYBX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SYBX"]); 
                    SDNQF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SDNQF"]); 
                    SDS.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SDS"]); 
                    YLBX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YLBX"]); 
                    YLIBX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YLIBX"]); 
                    YSSHF.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YSSHF"]); 
                    ZFGJJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ZFGJJ"]); 
                    KFX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["KFX"]); 
                    SFGZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SFGZ"]); 
                    GZKKSM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["GZKKSM"]); 
                    
            }
        }
            if (AddMode)
            {
                // 初始化传入参数

                // 初始化默认值

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
    /// 初始化数据绑定
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

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

        validateData = ValidateXM(XM.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.XM = Convert.ToString(validateData.Value.ToString());
                XM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            XM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateXB(XB.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.XB = Convert.ToString(validateData.Value.ToString());
                XB_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            XB.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XB.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSFZH(SFZH.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SFZH = Convert.ToString(validateData.Value.ToString());
                SFZH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SFZH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFZH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateFFGZNY(FFGZNY.Text, false, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.FFGZNY = Convert.ToString(validateData.Value.ToString());
                FFGZNY_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            FFGZNY.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FFGZNY.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJCGZ(JCGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JCGZ = Convert.ToDouble(validateData.Value.ToString());
                JCGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JCGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JCGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJSDJGZ(JSDJGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JSDJGZ = Convert.ToDouble(validateData.Value.ToString());
                JSDJGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JSDJGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSDJGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateZWGZ(ZWGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.ZWGZ = Convert.ToDouble(validateData.Value.ToString());
                ZWGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            ZWGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZWGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJBGZ(JBGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JBGZ = Convert.ToDouble(validateData.Value.ToString());
                JBGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JBGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JBGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJKDQJT(JKDQJT.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JKDQJT = Convert.ToDouble(validateData.Value.ToString());
                JKDQJT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JKDQJT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JKDQJT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJKTSGWJT(JKTSGWJT.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JKTSGWJT = Convert.ToDouble(validateData.Value.ToString());
                JKTSGWJT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JKTSGWJT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JKTSGWJT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateGLGZ(GLGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.GLGZ = Convert.ToDouble(validateData.Value.ToString());
                GLGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            GLGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            GLGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateXJGZ(XJGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.XJGZ = Convert.ToDouble(validateData.Value.ToString());
                XJGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            XJGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XJGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateTGBF(TGBF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.TGBF = Convert.ToDouble(validateData.Value.ToString());
                TGBF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            TGBF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            TGBF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDHF(DHF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DHF = Convert.ToDouble(validateData.Value.ToString());
                DHF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DHF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DHF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDSZNF(DSZNF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DSZNF = Convert.ToDouble(validateData.Value.ToString());
                DSZNF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DSZNF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DSZNF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateFNWSHLF(FNWSHLF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.FNWSHLF = Convert.ToDouble(validateData.Value.ToString());
                FNWSHLF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            FNWSHLF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FNWSHLF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateHLF(HLF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.HLF = Convert.ToDouble(validateData.Value.ToString());
                HLF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            HLF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HLF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJJ(JJ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JJ = Convert.ToDouble(validateData.Value.ToString());
                JJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJTF(JTF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JTF = Convert.ToDouble(validateData.Value.ToString());
                JTF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JTF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JTF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJHLGZ(JHLGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JHLGZ = Convert.ToDouble(validateData.Value.ToString());
                JHLGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JHLGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JHLGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateJT(JT.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.JT = Convert.ToDouble(validateData.Value.ToString());
                JT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateBF(BF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.BF = Convert.ToDouble(validateData.Value.ToString());
                BF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            BF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateQTBT(QTBT.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.QTBT = Convert.ToDouble(validateData.Value.ToString());
                QTBT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            QTBT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            QTBT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateDFXJT(DFXJT.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.DFXJT = Convert.ToDouble(validateData.Value.ToString());
                DFXJT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DFXJT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DFXJT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateYFX(YFX.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.YFX = Convert.ToDouble(validateData.Value.ToString());
                YFX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YFX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YFX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateQTKK(QTKK.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.QTKK = Convert.ToDouble(validateData.Value.ToString());
                QTKK_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            QTKK.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            QTKK.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSYBX(SYBX.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SYBX = Convert.ToDouble(validateData.Value.ToString());
                SYBX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SYBX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SYBX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSDNQF(SDNQF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SDNQF = Convert.ToDouble(validateData.Value.ToString());
                SDNQF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SDNQF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SDNQF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSDS(SDS.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SDS = Convert.ToDouble(validateData.Value.ToString());
                SDS_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SDS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SDS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateYLBX(YLBX.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.YLBX = Convert.ToDouble(validateData.Value.ToString());
                YLBX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YLBX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YLBX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateYLIBX(YLIBX.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.YLIBX = Convert.ToDouble(validateData.Value.ToString());
                YLIBX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YLIBX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YLIBX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateYSSHF(YSSHF.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.YSSHF = Convert.ToDouble(validateData.Value.ToString());
                YSSHF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YSSHF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YSSHF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateZFGJJ(ZFGJJ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.ZFGJJ = Convert.ToDouble(validateData.Value.ToString());
                ZFGJJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            ZFGJJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZFGJJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateKFX(KFX.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.KFX = Convert.ToDouble(validateData.Value.ToString());
                KFX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            KFX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KFX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateSFGZ(SFGZ.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.SFGZ = Convert.ToDouble(validateData.Value.ToString());
                SFGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SFGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        validateData = ValidateGZKKSM(GZKKSM.Text, true, false);
        if (validateData.Result==true)
        {
            if (validateData.IsNull==false)
            {
                appData.GZKKSM = Convert.ToString(validateData.Value.ToString());
                GZKKSM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            GZKKSM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            GZKKSM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                    
        // 自动生成编号

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
        appData = RICH.Common.BM.T_BM_GZXX.T_BM_GZXXBusinessEntity.GetDataByObjectID(ObjectID.Text);
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

        validateData = ValidateXM(XM.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XM = Convert.ToString(validateData.Value.ToString());
                XM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.XM = null;
            }
            XM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXB(XB.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XB = Convert.ToString(validateData.Value.ToString());
                XB_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.XB = null;
            }
            XB.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XB.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFZH(SFZH.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SFZH = Convert.ToString(validateData.Value.ToString());
                SFZH_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.SFZH = null;
            }
            SFZH.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFZH.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFFGZNY(FFGZNY.Text, false, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FFGZNY = Convert.ToString(validateData.Value.ToString());
                FFGZNY_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.FFGZNY = null;
            }
            FFGZNY.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FFGZNY.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJCGZ(JCGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JCGZ = Convert.ToDouble(validateData.Value.ToString());
                JCGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JCGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JCGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJSDJGZ(JSDJGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JSDJGZ = Convert.ToDouble(validateData.Value.ToString());
                JSDJGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JSDJGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JSDJGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZWGZ(ZWGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.ZWGZ = Convert.ToDouble(validateData.Value.ToString());
                ZWGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            ZWGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZWGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJBGZ(JBGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JBGZ = Convert.ToDouble(validateData.Value.ToString());
                JBGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JBGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JBGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJKDQJT(JKDQJT.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JKDQJT = Convert.ToDouble(validateData.Value.ToString());
                JKDQJT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JKDQJT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JKDQJT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJKTSGWJT(JKTSGWJT.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JKTSGWJT = Convert.ToDouble(validateData.Value.ToString());
                JKTSGWJT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JKTSGWJT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JKTSGWJT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateGLGZ(GLGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.GLGZ = Convert.ToDouble(validateData.Value.ToString());
                GLGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            GLGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            GLGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateXJGZ(XJGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.XJGZ = Convert.ToDouble(validateData.Value.ToString());
                XJGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            XJGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            XJGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateTGBF(TGBF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.TGBF = Convert.ToDouble(validateData.Value.ToString());
                TGBF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            TGBF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            TGBF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDHF(DHF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DHF = Convert.ToDouble(validateData.Value.ToString());
                DHF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DHF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DHF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDSZNF(DSZNF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DSZNF = Convert.ToDouble(validateData.Value.ToString());
                DSZNF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DSZNF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DSZNF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateFNWSHLF(FNWSHLF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.FNWSHLF = Convert.ToDouble(validateData.Value.ToString());
                FNWSHLF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            FNWSHLF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            FNWSHLF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateHLF(HLF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.HLF = Convert.ToDouble(validateData.Value.ToString());
                HLF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            HLF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            HLF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJJ(JJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JJ = Convert.ToDouble(validateData.Value.ToString());
                JJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJTF(JTF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JTF = Convert.ToDouble(validateData.Value.ToString());
                JTF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JTF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JTF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJHLGZ(JHLGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JHLGZ = Convert.ToDouble(validateData.Value.ToString());
                JHLGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JHLGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JHLGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateJT(JT.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.JT = Convert.ToDouble(validateData.Value.ToString());
                JT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            JT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            JT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateBF(BF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.BF = Convert.ToDouble(validateData.Value.ToString());
                BF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            BF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            BF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateQTBT(QTBT.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.QTBT = Convert.ToDouble(validateData.Value.ToString());
                QTBT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            QTBT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            QTBT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateDFXJT(DFXJT.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.DFXJT = Convert.ToDouble(validateData.Value.ToString());
                DFXJT_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            DFXJT.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            DFXJT.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYFX(YFX.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YFX = Convert.ToDouble(validateData.Value.ToString());
                YFX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YFX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YFX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateQTKK(QTKK.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.QTKK = Convert.ToDouble(validateData.Value.ToString());
                QTKK_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            QTKK.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            QTKK.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSYBX(SYBX.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SYBX = Convert.ToDouble(validateData.Value.ToString());
                SYBX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SYBX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SYBX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSDNQF(SDNQF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SDNQF = Convert.ToDouble(validateData.Value.ToString());
                SDNQF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SDNQF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SDNQF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSDS(SDS.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SDS = Convert.ToDouble(validateData.Value.ToString());
                SDS_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SDS.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SDS.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYLBX(YLBX.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YLBX = Convert.ToDouble(validateData.Value.ToString());
                YLBX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YLBX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YLBX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYLIBX(YLIBX.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YLIBX = Convert.ToDouble(validateData.Value.ToString());
                YLIBX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YLIBX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YLIBX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateYSSHF(YSSHF.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.YSSHF = Convert.ToDouble(validateData.Value.ToString());
                YSSHF_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            YSSHF.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            YSSHF.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateZFGJJ(ZFGJJ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.ZFGJJ = Convert.ToDouble(validateData.Value.ToString());
                ZFGJJ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            ZFGJJ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            ZFGJJ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateKFX(KFX.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.KFX = Convert.ToDouble(validateData.Value.ToString());
                KFX_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            KFX.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            KFX.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateSFGZ(SFGZ.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.SFGZ = Convert.ToDouble(validateData.Value.ToString());
                SFGZ_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
            SFGZ.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            SFGZ.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
        validateData = ValidateGZKKSM(GZKKSM.Text, true, false);
        if (validateData.Result)
        {
            if (!validateData.IsNull)
            {
                appData.GZKKSM = Convert.ToString(validateData.Value.ToString());
                GZKKSM_Note.InnerHtml = @"<font color=""gray"">输入正确。</font>";
            }
                        
            else
            {
                appData.GZKKSM = null;
            }
            GZKKSM.BackColor = System.Drawing.Color.Empty;
        }
        else
        {
            GZKKSM.BackColor = System.Drawing.Color.YellowGreen;
            MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
            boolReturn = validateData.Result;
        }
                
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

    }


    //=====================================================================
    //  FunctionName : InitalizeCustomAdd
    /// <summary>
    /// 初始化自定义添加
    /// </summary>
    //=====================================================================
    protected void InitalizeCustomAdd()
    {
        // 定制添加相关表信息

    }

    //=====================================================================
    //  FunctionName : InitalizeRelatedTableAdd
    /// <summary>
    /// 初始化批量添加模板
    /// </summary>
    //=====================================================================
    private void InitalizeRelatedTableAdd()
    {

    }



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

    }

    //=====================================================================
    //  FunctionName : RelatedTableAddBatch()
    /// <summary>
    /// 相关表批量添加
    /// </summary>
    //=====================================================================
    protected override void RelatedTableAddBatch()
    {

    }
    //=====================================================================
    //  FunctionName : RelatedTableModifyBatch()
    /// <summary>
    /// 相关表批量修改
    /// </summary>
    //=====================================================================
    protected override void RelatedTableModifyBatch()
    {

    }

    protected void btnInfoFromDocBatch_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = GetTemplateColumn(dt);
        dt = FileLibrary.GetDataFromWordBatch(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/" + ConstantsManager.UPLOAD_DOC_DIR + "/" + "T_BM_GZXX", dt, true, true);
        T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
        foreach (DataRow dr in dt.Rows)
        {
            appData = new T_BM_GZXXApplicationData();

            int i = 0;

            appData = instanceT_BM_GZXXApplicationLogic.Add(appData);
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
        dt = FileLibrary.GetDataFromDataFile(InfoFromDoc.Text, true);
        var appDatas = T_BM_GZXXApplicationData.GetCollectionFromDataTable(dt);
        T_BM_GZXXApplicationLogic instanceT_BM_GZXXApplicationLogic = (T_BM_GZXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_GZXXApplicationLogic));
        foreach (var app in appDatas)
        {

            instanceT_BM_GZXXApplicationLogic.Add(app);
        }
    }

    public void CheckPermission()
    {
        if (AccessPermission)
        {
			if(EditMode)
			{
	ObjectID_Area.Visible = false;
	  XM.Enabled = false;
                XB.Enabled = false;
                SFZH.Enabled = false;
                FFGZNY.Enabled = false;
                
			}
			else if(AddMode || CopyMode)
			{
	ObjectID_Area.Visible = false;
	  
			}
            if (ViewMode)
            {
    ObjectID.Enabled = false;
                ObjectID_Area.Visible = false;
      XM.Enabled = false;
                XB.Enabled = false;
                SFZH.Enabled = false;
                FFGZNY.Enabled = false;
                JCGZ.Enabled = false;
                JSDJGZ.Enabled = false;
                ZWGZ.Enabled = false;
                JBGZ.Enabled = false;
                JKDQJT.Enabled = false;
                JKTSGWJT.Enabled = false;
                GLGZ.Enabled = false;
                XJGZ.Enabled = false;
                TGBF.Enabled = false;
                DHF.Enabled = false;
                DSZNF.Enabled = false;
                FNWSHLF.Enabled = false;
                HLF.Enabled = false;
                JJ.Enabled = false;
                JTF.Enabled = false;
                JHLGZ.Enabled = false;
                JT.Enabled = false;
                BF.Enabled = false;
                QTBT.Enabled = false;
                DFXJT.Enabled = false;
                YFX.Enabled = false;
                QTKK.Enabled = false;
                SYBX.Enabled = false;
                SDNQF.Enabled = false;
                SDS.Enabled = false;
                YLBX.Enabled = false;
                YLIBX.Enabled = false;
                YSSHF.Enabled = false;
                ZFGJJ.Enabled = false;
                KFX.Enabled = false;
                SFGZ.Enabled = false;
                GZKKSM.Enabled = false;
                
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

