/****************************************************** 
FileName:T_BM_DWXXWebUIAddForApp.aspx.cs
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
using RICH.Common.BM.T_BM_DWXX;

namespace App
{
    public partial class T_BM_DWXXWebUIAdd : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
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
                appData = new T_BM_DWXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // 控件赋值
                if (appData.RecordCount > 0)
                {
    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                        DWBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DWBH"]); 
                        DWMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DWMC"]); 
                        SJDWBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJDWBH"]); 
                        DZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DZ"]); 
                        YB.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YB"]); 
                        LXBM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXBM"]); 
                        LXDH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXDH"]); 
                        Email.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["Email"]); 
                        LXR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXR"]); 
                        SJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJ"]); 
                        
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
    
            // 初始化上级单位(SJDWBH)下拉列表
              SJDWBH.DataSource = GetDataSource_SJDWBH();
            SJDWBH.DataTextField = "DWMC";
            SJDWBH.DataValueField = "DWBH";
                  SJDWBH.DataBind();
            SJDWBH.Items.Insert(0, new ListItem("请选择上级单位", ""));
                  
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
    
            validateData = ValidateDWMC(DWMC.Text, false, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.DWMC = Convert.ToString(validateData.Value.ToString());
                }
                DWMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DWMC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
                }
                SJDWBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJDWBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateDZ(DZ.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.DZ = Convert.ToString(validateData.Value.ToString());
                }
                DZ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DZ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateYB(YB.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.YB = Convert.ToString(validateData.Value.ToString());
                }
                YB.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                YB.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXBM(LXBM.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.LXBM = Convert.ToString(validateData.Value.ToString());
                }
                LXBM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXBM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXDH(LXDH.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.LXDH = Convert.ToString(validateData.Value.ToString());
                }
                LXDH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXDH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateEmail(Email.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.Email = Convert.ToString(validateData.Value.ToString());
                }
                Email.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                Email.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXR(LXR.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.LXR = Convert.ToString(validateData.Value.ToString());
                }
                LXR.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXR.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJ(SJ.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.SJ = Convert.ToString(validateData.Value.ToString());
                }
                SJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            // 自动生成编号
    T_BM_DWXXApplicationLogic instanceT_BM_DWXXApplicationLogic
                = (T_BM_DWXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_DWXXApplicationLogic));
            appData.DWBH = instanceT_BM_DWXXApplicationLogic.AutoGenerateDWBH(appData);
                    
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
            appData = RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity.GetDataByObjectID(base.ObjectID);
  appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
  
            validateData = ValidateDWBH(DWBH.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DWBH = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DWBH = null;
                }
                DWBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DWBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateDWMC(DWMC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DWMC = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DWMC = null;
                }
                DWMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DWMC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.SJDWBH = null;
                }
                SJDWBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJDWBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateDZ(DZ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DZ = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DZ = null;
                }
                DZ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DZ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateYB(YB.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YB = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.YB = null;
                }
                YB.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                YB.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXBM(LXBM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXBM = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LXBM = null;
                }
                LXBM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXBM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXDH(LXDH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXDH = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LXDH = null;
                }
                LXDH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXDH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateEmail(Email.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.Email = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.Email = null;
                }
                Email.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                Email.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXR(LXR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXR = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LXR = null;
                }
                LXR.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXR.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJ(SJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJ = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.SJ = null;
                }
                SJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJ.BackColor = System.Drawing.Color.YellowGreen;
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
          DWBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          DWBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          DWBHContainer.Visible = false;
          DWMCContainer.Visible = false;
          DWMCContainer.Visible = true;
          SJDWBHContainer.Visible = false;
          SJDWBHContainer.Visible = true;
          DZContainer.Visible = false;
          DZContainer.Visible = true;
          YBContainer.Visible = false;
          YBContainer.Visible = true;
          LXBMContainer.Visible = false;
          LXBMContainer.Visible = true;
          LXDHContainer.Visible = false;
          LXDHContainer.Visible = true;
          EmailContainer.Visible = false;
          EmailContainer.Visible = true;
          LXRContainer.Visible = false;
          LXRContainer.Visible = true;
          SJContainer.Visible = false;
          SJContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          DWBH.Enabled = false;
                    DWMC.Enabled = false;
                    SJDWBH.Enabled = false;
                    DZ.Enabled = false;
                    YB.Enabled = false;
                    LXBM.Enabled = false;
                    LXDH.Enabled = false;
                    Email.Enabled = false;
                    LXR.Enabled = false;
                    SJ.Enabled = false;
                    
                }
        
            }
        }
    
        protected override string GetObjectID()
        {
                    appData = new T_BM_DWXXApplicationData();
        
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

