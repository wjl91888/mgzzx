using System;
using System.Web.UI;
using RICH.Common;
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
            }
            CurrentAjaxManager.AjaxRequest += AjaxManager_AjaxRequest;
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {

            DetailPage = true;
            // Êý¾Ý²éÑ¯
            appData = new T_BG_0601ApplicationData();
            if (ViewState["CurrentPage"] == null)
            {
                appData.CurrentPage = 1;
            }
            else
            {
                appData.CurrentPage = (int)ViewState["CurrentPage"];
            }
            appData.PageSize = 20;
            QueryRecord();
            //appData.FBLM = (string) Request.QueryString["FBLM"];
            //appData.FBBM = (string)Request.QueryString["FBBM"];
            //appData.FBRJGH = (string)Request.QueryString["FBRJGH"];
            rptList.DataSource = appData.ResultSet;
            rptList.DataBind();
            ViewState["RecordCount"] = appData.RecordCount;
            ViewState["CurrentPage"] = appData.CurrentPage;
            ViewState["PageSize"] = appData.PageSize;
            ViewState["PageCount"] = FunctionManager.RoundInt(((int)ViewState["RecordCount"] / (float)(int)ViewState["PageSize"]));
            InitPageInfo();
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
    }
}

