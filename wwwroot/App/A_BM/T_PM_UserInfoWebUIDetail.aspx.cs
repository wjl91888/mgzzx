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
                            UserIDControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var SubjectIDControl = item.FindControl("SubjectIDContainer");
                        if (SubjectIDControl != null) 
                            SubjectIDControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var UserNickNameControl = item.FindControl("UserNickNameContainer");
                        if (UserNickNameControl != null) 
                            UserNickNameControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var XBControl = item.FindControl("XBContainer");
                        if (XBControl != null) 
                            XBControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var SJHControl = item.FindControl("SJHContainer");
                        if (SJHControl != null) 
                            SJHControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var BGDHControl = item.FindControl("BGDHContainer");
                        if (BGDHControl != null) 
                            BGDHControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var JTDHControl = item.FindControl("JTDHContainer");
                        if (JTDHControl != null) 
                            JTDHControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var EmailControl = item.FindControl("EmailContainer");
                        if (EmailControl != null) 
                            EmailControl.Visible = true;
                    }
                    if(CustomPermission == TXL_PURVIEW_ID)
                    {
                        var QQHControl = item.FindControl("QQHContainer");
                        if (QQHControl != null) 
                            QQHControl.Visible = true;
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

