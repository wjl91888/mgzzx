/****************************************************** 
FileName:T_BG_0601WebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class T_BG_0601WebUIAdd : RICH.Common.BM.T_BG_0601.T_BG_0601WebUI
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
    XXNR.ImageGalleryPath = "~/Media/Image/FreeTextBox/" + Session[RICH.Common.ConstantsManager.SESSION_USER_ID] + "/";

            // 界面控件状态
            if(ViewMode || EditMode || CopyMode)
            {
                // 读取要修改记录详细资料
                appData = new T_BG_0601ApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // 控件赋值
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
                    // 初始化传入参数
    
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
                
                    // 初始化默认值
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
        /// 初始化数据绑定
        /// </summary>
        //=====================================================================
        protected void InitalizeDataBind()
        {
    
            // 初始化发布栏目(FBLM)下拉列表
              FBLM.DataSource = GetDataSource_FBLM();
            FBLM.DataTextField = "LMM";
            FBLM.DataValueField = "LMH";
                  FBLM.DataBind();
            
            // 初始化发布部门(FBBM)下拉列表
              FBBM.DataSource = GetDataSource_FBBM();
            FBBM.DataTextField = "DWMC";
            FBBM.DataValueField = "DWBH";
                  FBBM.DataBind();
            FBBM.Items.Insert(0, new ListItem("请选择发布部门", ""));
                  
            // 初始化信息类型(XXLX)下拉列表
              XXLX.DataSource = GetDataSource_XXLX();
            XXLX.DataTextField = "MC";
            XXLX.DataValueField = "DM";
                  XXLX.DataBind();
            
            // 初始化信息状态(XXZT)下拉列表
              XXZT.DataSource = GetDataSource_XXZT();
            XXZT.DataTextField = "MC";
            XXZT.DataValueField = "DM";
                  XXZT.DataBind();
            XXZT.Items.Insert(0, new ListItem("请选择信息状态", ""));
                  
            // 初始化是否置顶(IsTop)下拉列表
              IsTop.DataSource = GetDataSource_IsTop();
            IsTop.DataTextField = "MC";
            IsTop.DataValueField = "DM";
                  IsTop.DataBind();
            IsTop.Items.Insert(0, new ListItem("请选择是否置顶", ""));
                  
            // 初始化推荐(IsBest)下拉列表
              IsBest.DataSource = GetDataSource_IsBest();
            IsBest.DataTextField = "MC";
            IsBest.DataValueField = "DM";
                  IsBest.DataBind();
            IsBest.Items.Insert(0, new ListItem("请选择推荐", ""));
                  
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
                
            // 自动生成编号
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
        /// 得到修改用户输入参数操作
        /// </summary>
        //=====================================================================
        protected override Boolean GetModifyInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数
            appData = RICH.Common.BM.T_BG_0601.T_BG_0601BusinessEntity.GetDataByObjectID(base.ObjectID);
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
          FBH.Enabled = false;
                    FBRJGH.Enabled = false;
                    FBSJRQ.Enabled = false;
                    FBIP.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          FBHContainer.Visible = false;
          XXZTContainer.Visible = false;
          FBRJGHContainer.Visible = false;
          FBSJRQContainer.Visible = false;
          FBIPContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          FBHContainer.Visible = false;
          BTContainer.Visible = false;
          BTContainer.Visible = true;
          FBLMContainer.Visible = false;
          FBLMContainer.Visible = true;
          FBBMContainer.Visible = false;
          FBBMContainer.Visible = true;
          XXLXContainer.Visible = false;
          XXLXContainer.Visible = true;
          XXTPDZContainer.Visible = false;
          XXTPDZContainer.Visible = true;
          XXNRContainer.Visible = false;
          XXNRContainer.Visible = true;
          FJXZDZContainer.Visible = false;
          FJXZDZContainer.Visible = true;
          XXZTContainer.Visible = false;
          IsTopContainer.Visible = false;
          IsTopContainer.Visible = true;
          TopSortContainer.Visible = false;
          TopSortContainer.Visible = true;
          IsBestContainer.Visible = false;
          IsBestContainer.Visible = true;
          FBRJGHContainer.Visible = false;
          FBSJRQContainer.Visible = false;
          FBIPContainer.Visible = false;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          FBH.Enabled = false;
                    FBHContainer.Visible = false;
          BT.Enabled = false;
                    FBLM.Enabled = false;
                    FBBM.Enabled = false;
                    XXLX.Enabled = false;
                    XXLXContainer.Visible = false;
          XXTPDZ.ReadOnly = true;
                    XXNR.ReadOnly = true;
                    FJXZDZ.ReadOnly = true;
                    XXZT.Enabled = false;
                    XXZTContainer.Visible = false;
          IsTop.Enabled = false;
                    IsTopContainer.Visible = false;
          TopSort.Enabled = false;
                    TopSortContainer.Visible = false;
          IsBest.Enabled = false;
                    IsBestContainer.Visible = false;
          FBRJGH.Enabled = false;
                    FBSJRQ.Enabled = false;
                    FBIP.Enabled = false;
                    
                }
        
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBHContainer.Visible = false;
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
                    XXZTContainer.Visible = false;
                  }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    IsTopContainer.Visible = false;
                  }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    TopSortContainer.Visible = false;
                  }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    IsBestContainer.Visible = false;
                  }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBRJGHContainer.Visible = false;
                  }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBRJGH.Enabled = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBIPContainer.Visible = false;
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
}

