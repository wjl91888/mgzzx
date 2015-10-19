/****************************************************** 
FileName:FilterReportWebUIAddForApp.aspx.cs
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
using RICH.Common.BM.FilterReport;

namespace App
{
    public partial class FilterReportWebUIAdd : RICH.Common.BM.FilterReport.FilterReportWebUI
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
                appData = new FilterReportApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // 控件赋值
                if (appData.RecordCount > 0)
                {
    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                        BGMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGMC"]); 
                        UserID.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["UserID"]); 
                        BGLX.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGLX"]); 
                        GXBG.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["GXBG"]); 
                        XTBG.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["XTBG"]); 
                        BGCXTJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGCXTJ"]); 
                        BGCJSJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["BGCJSJ"]); 
                        
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
    
            // 初始化用户编号(UserID)下拉列表
              UserID.DataSource = GetDataSource_UserID();
            UserID.DataTextField = "UserLoginName";
            UserID.DataValueField = "UserID";
                  UserID.DataBind();
            
            // 初始化共享报告(GXBG)下拉列表
              GXBG.DataSource = GetDataSource_GXBG();
            GXBG.DataTextField = "MC";
            GXBG.DataValueField = "DM";
                  GXBG.DataBind();
            
            // 初始化系统报告(XTBG)下拉列表
              XTBG.DataSource = GetDataSource_XTBG();
            XTBG.DataTextField = "MC";
            XTBG.DataValueField = "DM";
                  XTBG.DataBind();
            
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
    
            validateData = ValidateBGMC(BGMC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGMC = Convert.ToString(validateData.Value.ToString());
                }
                BGMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGMC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateBGLX(BGLX.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGLX = Convert.ToString(validateData.Value.ToString());
                }
                BGLX.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGLX.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateGXBG(GXBG.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.GXBG = Convert.ToString(validateData.Value.ToString());
                }
                GXBG.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                GXBG.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateXTBG(XTBG.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XTBG = Convert.ToString(validateData.Value.ToString());
                }
                XTBG.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                XTBG.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            validateData = ValidateBGCXTJ(BGCXTJ.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGCXTJ = Convert.ToString(validateData.Value.ToString());
                }
                BGCXTJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGCXTJ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                        
            // 自动生成编号
    
            appData.UserID = (string)Session[ConstantsManager.SESSION_USER_ID];
    
            appData.BGCJSJ = DateTime.Now;
    
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
            appData = RICH.Common.BM.FilterReport.FilterReportBusinessEntity.GetDataByObjectID(base.ObjectID);
  appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
  
            validateData = ValidateBGMC(BGMC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGMC = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.BGMC = null;
                }
                BGMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGMC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateUserID(UserID.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserID = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.UserID = null;
                }
                UserID.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                UserID.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateBGLX(BGLX.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGLX = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.BGLX = null;
                }
                BGLX.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGLX.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateGXBG(GXBG.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.GXBG = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.GXBG = null;
                }
                GXBG.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                GXBG.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateXTBG(XTBG.SelectedValue, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XTBG = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.XTBG = null;
                }
                XTBG.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                XTBG.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateBGCXTJ(BGCXTJ.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGCXTJ = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.BGCXTJ = null;
                }
                BGCXTJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGCXTJ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateBGCJSJ(BGCJSJ.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BGCJSJ = Convert.ToDateTime(validateData.Value.ToString());
                }
                BGCJSJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                BGCJSJ.BackColor = System.Drawing.Color.YellowGreen;
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
          UserID.Enabled = false;
                    BGLX.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          UserIDContainer.Visible = false;
          BGCJSJContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          BGMCContainer.Visible = false;
          BGMCContainer.Visible = true;
          UserIDContainer.Visible = false;
          BGLXContainer.Visible = false;
          BGLXContainer.Visible = true;
          GXBGContainer.Visible = false;
          GXBGContainer.Visible = true;
          XTBGContainer.Visible = false;
          XTBGContainer.Visible = true;
          BGCXTJContainer.Visible = false;
          BGCXTJContainer.Visible = true;
          BGCJSJContainer.Visible = false;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          BGMC.Enabled = false;
                    UserID.Enabled = false;
                    BGLX.Enabled = false;
                    GXBG.Enabled = false;
                    XTBG.Enabled = false;
                    BGCXTJ.EditMode=false;
                    BGCJSJ.Enabled = false;
                    
                }
        
            }
        }
    
        protected override string GetObjectID()
        {
                    appData = new FilterReportApplicationData();
        
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

