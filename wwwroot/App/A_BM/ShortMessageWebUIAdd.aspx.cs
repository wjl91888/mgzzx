/****************************************************** 
FileName:ShortMessageWebUIAddForApp.aspx.cs
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

namespace App
{
    public partial class ShortMessageWebUIAdd : RICH.Common.BM.ShortMessage.ShortMessageWebUI
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
            appData = RICH.Common.BM.ShortMessage.ShortMessageBusinessEntity.GetDataByObjectID(base.ObjectID);
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

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          DXXBT.Enabled = false;
                    DXXLXContainer.Visible = false;
          DXXNR.ReadOnly = true;
                    DXXFJ.ReadOnly = true;
                    FSSJContainer.Visible = false;
          FSRContainer.Visible = false;
          FSBMContainer.Visible = false;
          FSIPContainer.Visible = false;
          JSR.ReadOnly = true;
                    SFCKContainer.Visible = false;
          CKSJContainer.Visible = false;
          
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          DXXLXContainer.Visible = false;
          FSSJContainer.Visible = false;
          FSRContainer.Visible = false;
          FSBMContainer.Visible = false;
          FSIPContainer.Visible = false;
          SFCKContainer.Visible = false;
          CKSJContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          DXXBTContainer.Visible = false;
          DXXBTContainer.Visible = true;
          DXXLXContainer.Visible = false;
          DXXNRContainer.Visible = false;
          DXXNRContainer.Visible = true;
          DXXFJContainer.Visible = false;
          DXXFJContainer.Visible = true;
          FSSJContainer.Visible = false;
          FSRContainer.Visible = false;
          FSBMContainer.Visible = false;
          FSIPContainer.Visible = false;
          JSRContainer.Visible = false;
          JSRContainer.Visible = true;
          SFCKContainer.Visible = false;
          CKSJContainer.Visible = false;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          DXXBT.Enabled = false;
                    DXXLX.Enabled = false;
                    DXXLXContainer.Visible = false;
          DXXNR.ReadOnly = true;
                    DXXFJ.ReadOnly = true;
                    FSSJ.Enabled = false;
                    FSR.Enabled = false;
                    FSBM.Enabled = false;
                    FSIP.Enabled = false;
                    FSIPContainer.Visible = false;
          JSR.ReadOnly = true;
                    SFCK.Enabled = false;
                    SFCKContainer.Visible = false;
          CKSJ.Enabled = false;
                    CKSJContainer.Visible = false;
          
                }
        
                    if(CustomPermission == SJX_PURVIEW_ID)
                    {
                    SFCKContainer.Visible = false;
                  }
                    if(CustomPermission == FJX_PURVIEW_ID)
                    {
                    FSRContainer.Visible = false;
                  }
                    if(CustomPermission == FJX_PURVIEW_ID)
                    {
                    FSBMContainer.Visible = false;
                  }
                    if(CustomPermission == FJX_PURVIEW_ID)
                    {
                    SFCKContainer.Visible = false;
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
}

