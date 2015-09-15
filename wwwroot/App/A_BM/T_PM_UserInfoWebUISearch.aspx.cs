/****************************************************** 
FileName:T_PM_UserInfoWebUISearchForApp.aspx.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI;
using RICH.Common;
using RICH.Common.Utilities;
using RICH.Common.Base.WebUI;
using RICH.Common.BM.T_PM_UserInfo;
using Telerik.Web.UI;

namespace App
{
    public partial class T_PM_UserInfoWebUISearch : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Initalize();
                InitFilterData();
            }
            CurrentAjaxManager.AjaxRequest += AjaxManager_AjaxRequest;
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            DetailPage = true;
            // 数据查询
            appData = new T_PM_UserInfoApplicationData();
            QueryRecord();
            rptList.DataSource = appData.ResultSet;
            rptList.DataBind();
            ViewState["RecordCount"] = appData.RecordCount;
            ViewState["CurrentPage"] = appData.CurrentPage;
            ViewState["PageSize"] = appData.PageSize;
            ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
            InitPageInfo();
        }

        protected void InitFilterData()
        {
            var dataSourceCollection = new List<Pair<string, List<Triples<string, string, string>>>>();
    
            dataSourceCollection.Add(new Pair<string, List<Triples<string, string, string>>>("部门", GetList_SubjectID_AdvanceSearch()));
                    
            NavList.DataSource = dataSourceCollection;
        }

        protected void AjaxManager_AjaxRequest(object sender, AjaxRequestEventArgs e)
        {
            switch (e.Argument)
            {
                case "Refresh":
                    Initalize();
                    break;
                default:
                    break;
            }
        }

        protected override Boolean GetQueryInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // 验证输入参数

            validateData = ValidateUserLoginName(Request["UserLoginName"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserLoginName = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSubjectIDBatch(Request["SubjectID"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SubjectIDBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateSubjectID(Request["SubjectID"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                        appData.SubjectID = null;
                        appData.SubjectIDBatch = GetSubItem_SubjectID(validateData.Value.ToString()) + "," + validateData.Value.ToString();
                }
            }
        
            validateData = ValidateUserNickName(Request["UserNickName"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.UserNickName = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            if (!string.IsNullOrWhiteSpace(Request["SearchKeywords"]))
            {
                appData.UserNickName = Convert.ToString(Request["SearchKeywords"]);
            }

            if (!DataValidateManager.ValidateIsNull(ViewState["QueryType"]))
            {
                if (!DataValidateManager.ValidateStringFormat(ViewState["QueryType"].ToString()))
                {
                    appData.QueryType = "AND";
                }
                else
                {
                    appData.QueryType = ViewState["QueryType"].ToString();
                }
            }
            else
            {
                appData.SortField = "AND";
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["Sort"]))
            {
                if (!DataValidateManager.ValidateBooleanFormat(ViewState["Sort"].ToString()))
                {
                    appData.Sort = DEFAULT_SORT;
                }
                else
                {
                    appData.Sort = Convert.ToBoolean(ViewState["Sort"].ToString());
                }
            }
            else
            {
                appData.Sort = DEFAULT_SORT;
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["SortField"]))
            {
                if (!DataValidateManager.ValidateStringFormat(ViewState["SortField"].ToString()))
                {
                    appData.SortField = DEFAULT_SORT_FIELD;
                }
                else
                {
                    appData.SortField = ViewState["SortField"].ToString();
                }
            }
            else
            {
                appData.SortField = DEFAULT_SORT_FIELD;
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["PageSize"]))
            {
                if (!DataValidateManager.ValidateNumberFormat(ViewState["PageSize"].ToString()))
                {
                    appData.PageSize = DEFAULT_PAGE_SIZE;
                }
                else
                {
                    appData.PageSize = Convert.ToInt32(ViewState["PageSize"].ToString());
                }
            }
            else
            {
                appData.PageSize = DEFAULT_PAGE_SIZE;
            }
            if (!DataValidateManager.ValidateIsNull(ViewState["CurrentPage"]))
            {
                if (!DataValidateManager.ValidateNumberFormat(ViewState["CurrentPage"].ToString()))
                {
                    appData.CurrentPage = DEFAULT_CURRENT_PAGE;
                }
                else
                {
                    appData.CurrentPage = Convert.ToInt32(ViewState["CurrentPage"].ToString());
                }
            }
            else
            {
                appData.CurrentPage = DEFAULT_CURRENT_PAGE;
            }

            return boolReturn;
        }
    }
}

