using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;
using RICH.Common;
using RICH.Common.BM.T_PM_PurviewInfo;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.PM;
using Telerik.Web.UI;

namespace RICH.Common.Base.WebUI
{
    public partial class WebUIBase
    {
        private T_PM_UserInfoApplicationData currentUserInfo = null;

        public virtual bool NeedLogin
        {
            get { return true; }
        }

        public bool AddMode
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["a"]))
                {
                    return Request.QueryString["a"].Equals("a", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }
        public bool EditMode
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["a"]))
                {
                    return Request.QueryString["a"].Equals("e", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }
        public bool CopyMode
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["a"]))
                {
                    return Request.QueryString["a"].Equals("c", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }
        public bool ViewMode
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["a"]))
                {
                    return Request.QueryString["a"].Equals("v", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }
        public bool ImportDocMode
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["a"]))
                {
                    return Request.QueryString["a"].Equals("doc", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }
        public bool ImportDSMode
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["a"]))
                {
                    return Request.QueryString["a"].Equals("ds", StringComparison.OrdinalIgnoreCase);
                }
                return false;
            }
        }
        public string CustomPermission
        {
            get
            {
                if (!DataValidateManager.ValidateIsNull(Request.QueryString["p"]))
                {
                    return Request.QueryString["p"];
                }
                return string.Empty;
            }
        }

        private bool? detailAccessPermission = null;
        public bool DetailAccessPermission 
        {
            get
            {
                if (detailAccessPermission == null)
                {
                    detailAccessPermission = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetWebUIDetailAccessPurviewID());
                }
                return (bool) detailAccessPermission;
            }
        }

        private bool? modifyAccessPermission = null;
        public bool ModifyAccessPermission
        {
            get
            {
                if (modifyAccessPermission == null)
                {
                    modifyAccessPermission = SystemValidateLibrary.ValidateUserPurview(currentUserInfo.UserID, currentUserInfo.UserGroupID, GetWebUIModifyAccessPurviewID());
                }
                return (bool)modifyAccessPermission;
            }
        }
        public bool AccessPermission { get; set; }
        public string CurrentAccessPermission { get; set; }
        public bool DetailPage { get; set; }
        private string pageHeaderTitle = null;
        public string PageHeaderTitle
        {
            get
            {
                if (pageHeaderTitle.IsHtmlNullOrWiteSpace())
                {
                    var app = RICH.Common.BM.T_PM_PurviewInfo.T_PM_PurviewInfoBusinessEntity.GetDataByKey(new T_PM_PurviewInfoApplicationData() { PurviewID = GetWebUISearchAccessPurviewID() });
                    if (app != null)
                    {
                        pageHeaderTitle = app.PurviewName;
                    }
                }
                return pageHeaderTitle;
            }
        }
        public string ObjectID
        {
            get
            {
                if (DataValidateManager.ValidateUniqueIdentifierFormat(Request.QueryString["ObjectID"]))
                {
                    return Request.QueryString["ObjectID"];
                }
                else if(EditMode)
                {
                    return GetObjectID();
                }
                return string.Empty;
            }
        }
        public T_PM_UserInfoApplicationData CurrentUserInfo
        {
            get
            {
                if (currentUserInfo == null)
                {
                    if (!ValidateUserIsLogined())
                    {
                        // 未登录处理
                        Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Administrator/Login.aspx");
                    }
                    currentUserInfo = T_PM_UserInfoBusinessEntity.GetDataByKey(new T_PM_UserInfoApplicationData()
                    {
                        UserID = (string)Session[ConstantsManager.SESSION_USER_ID],
                    });
                    
                }
                return currentUserInfo;
            }
        }
        public virtual MasterPage BaseMaster
        {
            get
            {
                return this.Page.Master as MasterPage;
            }
        }

        public virtual Control MainContentPlaceHolder
        {
            get
            {
                if (BaseMaster != null)
                {
                    return BaseMaster.FindControl("MainContentPlaceHolder") as Control;
                }
                return null;
            }
        }

        public virtual Control MainContainerPlaceHolder
        {
            get
            {
                if (BaseMaster != null)
                {
                    return BaseMaster.FindControl("MainContainerPlaceHolder") as Control;
                }
                return null;
            }
        }

        public virtual Control PageNavContainerPlaceHolder
        {
            get
            {
                if (BaseMaster != null)
                {
                    return BaseMaster.FindControl("PageNavContainerPlaceHolder") as Control;
                }
                return null;
            }
        }

        public virtual RadAjaxManager CurrentAjaxManager
        {
            get
            {
                return RadAjaxManager.GetCurrent(this.Page);
            }
        }

        public string DomainUrl
        {
            get
            {
                return "{0}://{1}".FormatInvariantCulture(Request.Url.Scheme, Request.Url.Authority);
            }
        }

        public static string MessageContent { get; set; }
        public string CurrentPageFileName
        {
            get
            {
                return Path.GetFileName(Request.PhysicalPath);
            }
        }

        public string CurrentUrl
        {
            get
            {
                return Request.Url.AbsoluteUri;
            }
        }

        public string CurrentUrlWithoutQueryString
        {
            get
            {
                return "{0}://{1}{2}".FormatInvariantCulture(Request.Url.Scheme, Request.Url.Authority, Request.Url.AbsolutePath); 
            }
        }

        /// <summary>
        /// 输入参数HashTable
        /// </summary>
        private Hashtable htInputParameter = new Hashtable();

        /// <summary>
        /// 输出参数HashTable
        /// </summary>
        private Hashtable htOutputParameter = new Hashtable();

        /// <summary>
        /// 用来存储消息信息
        /// </summary>
        private string strMessageInfo = string.Empty;

        /// <summary>
        /// 用来存储消息信息的参数
        /// </summary>
        private string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };

    }
}
