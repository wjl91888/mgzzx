/****************************************************** 
FileName:T_BG_0601WebUISearchForApp.aspx.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Web.UI;
using RICH.Common;
using RICH.Common.Utilities;
using RICH.Common.Base.WebUI;
using RICH.Common.BM.T_BG_0601;
using Telerik.Web.UI;

namespace App
{
    public partial class T_BG_0601WebUISearch : RICH.Common.BM.T_BG_0601.T_BG_0601WebUI
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
            appData = new T_BG_0601ApplicationData();
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
    
            dataSourceCollection.Add(new Pair<string, List<Triples<string, string, string>>>("栏目", GetList_FBLM_AdvanceSearch()));
                    
            dataSourceCollection.Add(new Pair<string, List<Triples<string, string, string>>>("部门", GetList_FBBM_AdvanceSearch()));
                    
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

            validateData = ValidateBT(Request["BT"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.BT = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBLMBatch(Request["FBLM"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBLMBatch = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBLM(Request["FBLM"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                        appData.FBLM = null;
                        appData.FBLMBatch = GetSubItem_FBLM(validateData.Value.ToString()) + "," + validateData.Value.ToString();
                }
            }
        
            validateData = ValidateFBBM(Request["FBBM"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.FBBM = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            validateData = ValidateFBBM(Request["FBBM"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                        appData.FBBM = null;
                        appData.FBBMBatch = GetSubItem_FBBM(validateData.Value.ToString()) + "," + validateData.Value.ToString();
                }
            }
        
            validateData = ValidateXXNR(Request["XXNR"], true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.XXNR = Convert.ToString(validateData.Value.ToString());
                }
            }
      
            if (!string.IsNullOrWhiteSpace(Request["SearchKeywords"]))
            {
                appData.BT = Convert.ToString(Request["SearchKeywords"]);
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

            if(CustomPermission == WFBD_PURVIEW_ID)
            {
                appData.FBRJGH = CurrentUserInfo.UserID;
            }
        
            return boolReturn;
        }
    }
}

