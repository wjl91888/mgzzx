using System;
using System.Data;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.BM.T_PM_UserInfo;
using Telerik.Web.UI;

namespace App
{
    public partial class T_PM_UserInfoWebUIDetail : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initalize();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // 读取记录详细资料
            appData = new T_PM_UserInfoApplicationData();
            appData.ObjectID = ObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
            QueryRecord();
            Header.DataBind();
            rptDetail.DataSource = appData.ResultSet;
            rptDetail.DataBind();

            if (!IsPostBack)
            {
                foreach (DataRow drTemp in appData.ResultSet.Tables[0].Rows)
                {
                    //记录日志开始
                    string strLogTypeID = "A10";
                    strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                    strMessageParam[1] = "用户信息";
                    strMessageParam[2] = drTemp["UserNickName"].ToString();
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                    RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                    //记录日志结束
                }
            }
        }

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                foreach (RepeaterItem item in rptDetail.Items)
                {
        
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var UserIDControl = item.FindControl("UserIDContainer");
                        if (UserIDControl != null) 
                        {
                            UserIDControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var UserLoginNameControl = item.FindControl("UserLoginNameContainer");
                        if (UserLoginNameControl != null) 
                        {
                            UserLoginNameControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var UserGroupIDControl = item.FindControl("UserGroupIDContainer");
                        if (UserGroupIDControl != null) 
                        {
                            UserGroupIDControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var SFZHControl = item.FindControl("SFZHContainer");
                        if (SFZHControl != null) 
                        {
                            SFZHControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var LoginTimeControl = item.FindControl("LoginTimeContainer");
                        if (LoginTimeControl != null) 
                        {
                            LoginTimeControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var LastLoginIPControl = item.FindControl("LastLoginIPContainer");
                        if (LastLoginIPControl != null) 
                        {
                            LastLoginIPControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var LastLoginDateControl = item.FindControl("LastLoginDateContainer");
                        if (LastLoginDateControl != null) 
                        {
                            LastLoginDateControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var LoginTimesControl = item.FindControl("LoginTimesContainer");
                        if (LoginTimesControl != null) 
                        {
                            LoginTimesControl.Visible = false;
                        }
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var UserStatusControl = item.FindControl("UserStatusContainer");
                        if (UserStatusControl != null) 
                        {
                            UserStatusControl.Visible = false;
                        }
                    }
                }
            }
            else
            {
                rptDetail.Visible = false;
            }
        }
    }
}

