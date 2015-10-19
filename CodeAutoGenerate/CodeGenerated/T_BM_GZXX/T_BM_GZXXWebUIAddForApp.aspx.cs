/****************************************************** 
FileName:T_BM_GZXXWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BM_GZXXWebUIAdd : RICH.Common.BM.T_BM_GZXX.T_BM_GZXXWebUI
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
                // 初始化绑定数据
                InitalizeDataBind();
                // 初始化耦合绑定数据
                InitalizeCoupledDataSource();
                // 全局初始化
                Initalize();
            }
            else
            {
                // 初始化耦合绑定数据
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // 初始化界面
    

            // 界面控件状态
            if(ViewMode || EditMode || CopyMode)
            {
                // 读取要修改记录详细资料
                appData = new T_BM_GZXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
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
                        TJSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["TJSJ"]); 
                        
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
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XM = Convert.ToString(validateData.Value.ToString());
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
    
            appData.TJSJ = DateTime.Now;
    
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
            appData = RICH.Common.BM.T_BM_GZXX.T_BM_GZXXBusinessEntity.GetDataByObjectID(base.ObjectID);
  appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
  
            validateData = ValidateXM(XM.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XM = Convert.ToString(validateData.Value.ToString());
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
                    
            validateData = ValidateTJSJ(TJSJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.TJSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
                TJSJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                TJSJ.BackColor = System.Drawing.Color.YellowGreen;
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

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          XM.Enabled = false;
                    XB.Enabled = false;
                    SFZH.Enabled = false;
                    FFGZNY.Enabled = false;
                    TJSJ.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          TJSJContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          XMContainer.Visible = false;
          XBContainer.Visible = false;
          SFZHContainer.Visible = false;
          FFGZNYContainer.Visible = false;
          FFGZNYContainer.Visible = true;
          JCGZContainer.Visible = false;
          JSDJGZContainer.Visible = false;
          ZWGZContainer.Visible = false;
          JBGZContainer.Visible = false;
          JKDQJTContainer.Visible = false;
          JKTSGWJTContainer.Visible = false;
          GLGZContainer.Visible = false;
          XJGZContainer.Visible = false;
          TGBFContainer.Visible = false;
          DHFContainer.Visible = false;
          DSZNFContainer.Visible = false;
          FNWSHLFContainer.Visible = false;
          HLFContainer.Visible = false;
          JJContainer.Visible = false;
          JTFContainer.Visible = false;
          JHLGZContainer.Visible = false;
          JTContainer.Visible = false;
          BFContainer.Visible = false;
          QTBTContainer.Visible = false;
          DFXJTContainer.Visible = false;
          YFXContainer.Visible = false;
          QTKKContainer.Visible = false;
          SYBXContainer.Visible = false;
          SDNQFContainer.Visible = false;
          SDSContainer.Visible = false;
          YLBXContainer.Visible = false;
          YLIBXContainer.Visible = false;
          YSSHFContainer.Visible = false;
          ZFGJJContainer.Visible = false;
          KFXContainer.Visible = false;
          SFGZContainer.Visible = false;
          GZKKSMContainer.Visible = false;
          GZKKSMContainer.Visible = true;
          TJSJContainer.Visible = false;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
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
                    TJSJ.Enabled = false;
                    TJSJContainer.Visible = false;
          
                }
        
                    if(CustomPermission == WDGZ_PURVIEW_ID)
                    {
                    TJSJContainer.Visible = false;
                  }
            }
        }
    
        protected override string GetObjectID()
        {
                    appData = new T_BM_GZXXApplicationData();
        
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

