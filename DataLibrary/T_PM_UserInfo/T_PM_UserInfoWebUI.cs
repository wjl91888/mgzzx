/****************************************************** 
FileName:T_PM_UserInfoWebUI.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using RICH.Common.Utilities;

namespace RICH.Common.BM.T_PM_UserInfo
{
    //=========================================================================
    //  ClassName : T_PM_UserInfoWebUI
    /// <summary>
    /// T_PM_UserInfo的扩展逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_PM_UserInfoWebUI : T_PM_UserInfoWebUIBase
    {
        public string WEBUI_MYADD_FILENAME { get { return "T_PM_UserInfoWebUIMyAdd.aspx"; } }
        public string WEBUI_MYADD_ACCESS_PURVIEW_ID { get { return "ZJ21"; } }

        public static void SendValidateMail(string email, string username, string domain, string vcode)
        {
            if (!email.IsValidEmail())
            {
                throw new ArgumentException("无效的Email地址'{0}'".FormatInvariantCulture(email));
            }
            var parameters = new Dictionary<string, string>();
            parameters.Add(ConstantsManager.UserNameParamName, username);
            parameters.Add(ConstantsManager.DomainParamName, domain);
            parameters.Add(ConstantsManager.VCodeParamName, vcode);
            var emailNotification = new SystemNotification(ConstantsManager.ValidateUserEmailContentName, ConstantsManager.EmailContentXmlPath, parameters) { To = new string[] { email } };
            emailNotification.SendNotification(false);
        }

        public static void SendChangePasswordMail(string email, string username, string domain, string vcode)
        {
            if (!email.IsValidEmail())
            {
                throw new ArgumentException("无效的Email地址'{0}'".FormatInvariantCulture(email));
            }
            var parameters = new Dictionary<string, string>();
            parameters.Add(ConstantsManager.UserNameParamName, username);
            parameters.Add(ConstantsManager.DomainParamName, domain);
            parameters.Add(ConstantsManager.VCodeParamName, vcode);
            var emailNotification = new SystemNotification(ConstantsManager.ChangePasswordEmailContentName, ConstantsManager.EmailContentXmlPath, parameters) { To = new string[] { email } };
            emailNotification.SendNotification(false);
        }
    }
}
  
