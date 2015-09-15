/****************************************************** 
FileName:T_BM_DWXXWebUISearchForApp.aspx.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI;
using RICH.Common;
using RICH.Common.Utilities;
using RICH.Common.Base.WebUI;
using RICH.Common.BM.T_BM_DWXX;
using Telerik.Web.UI;

namespace App
{
    public partial class T_BM_DWXXWebUISearch : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
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
            appData = new T_BM_DWXXApplicationData();
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

            if (!string.IsNullOrWhiteSpace(Request["SearchKeywords"]))
            {
                appData.DWMC = Convert.ToString(Request["SearchKeywords"]);
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

