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
                // ��ʼ��������
                InitalizeDataBind();
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
                // ȫ�ֳ�ʼ��
                Initalize();
            }
            else
            {
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // ��ʼ������
    

            // ����ؼ�״̬
            if(ViewMode || EditMode || CopyMode)
            {
                // ��ȡҪ�޸ļ�¼��ϸ����
                appData = new FilterReportApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // �ؼ���ֵ
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
                    // ��ʼ���������
    
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
    
            // ��ʼ���û����(UserID)�����б�
              UserID.DataSource = GetDataSource_UserID();
            UserID.DataTextField = "UserLoginName";
            UserID.DataValueField = "UserID";
                  UserID.DataBind();
            
            // ��ʼ��������(GXBG)�����б�
              GXBG.DataSource = GetDataSource_GXBG();
            GXBG.DataTextField = "MC";
            GXBG.DataValueField = "DM";
                  GXBG.DataBind();
            
            // ��ʼ��ϵͳ����(XTBG)�����б�
              XTBG.DataSource = GetDataSource_XTBG();
            XTBG.DataTextField = "MC";
            XTBG.DataValueField = "DM";
                  XTBG.DataBind();
            
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
                        
            // �Զ����ɱ��
    
            appData.UserID = (string)Session[ConstantsManager.SESSION_USER_ID];
    
            appData.BGCJSJ = DateTime.Now;
    
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
        /// ��ʼ����������
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

