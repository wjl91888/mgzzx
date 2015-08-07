<%@ Application Language="C#" %>
<%@ Import Namespace="RICH.Common" %>
<%@ Import Namespace="RICH.Common.BM.T_PM_UserInfo" %>
<%@ Import Namespace="RICH.Common.LM" %>
<script runat="server">
    void Application_Start(object sender, EventArgs e) 
    {
        // Code that runs on application startup
        //Application.Add("CheckOnlineUserTime", DateTime.Now);

    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  Code that runs on application shutdown

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // Code that runs when an unhandled error occurs
        Exception objErr = Server.GetLastError().GetBaseException();
        if (objErr.Source == "FreeTextBox")
        {
            Response.Redirect(Request.Url.ToString());
        }
        else
        {
            string error = "Message: " + objErr.Message + "\r\n";
            error += "StackTrace: " + objErr.StackTrace;
            //Server.ClearError();
            //��¼��־��ʼ
            string strLogTypeID = "SYSTEM_ERROR ";
            string strLogContent = error;
            LogLibrary.LogWrite(strLogTypeID, strLogContent, null, null, null);
            //��¼��־����
        }
    }

    void Session_Start(object sender, EventArgs e) 
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e) 
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.
        // ɾ���û�������Ϣ��ʼ
//        RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationData appData = new RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationData();
//        RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationLogic instanceT_PM_UserOnlineInfoApplicationLogic
//= (RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationLogic)Activator.CreateInstance(typeof(RICH.Common.BM.T_PM_UserOnlineInfo.T_PM_UserOnlineInfoApplicationLogic));
//        appData.UserID = (string)Session.Contents[ConstantsManager.SESSION_USER_ID];
//        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.PK;
//        instanceT_PM_UserOnlineInfoApplicationLogic.Delete(appData);
        // ɾ���û�������Ϣ����
    }
       
</script>
