using System;
using System.Data;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.BM.T_BG_0601;
using Telerik.Web.UI;

namespace App
{
    public partial class T_BG_0601WebUIDetail : RICH.Common.BM.T_BG_0601.T_BG_0601WebUI
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
            appData = new T_BG_0601ApplicationData();
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
                    strMessageParam[1] = "公共信息";
                    strMessageParam[2] = drTemp["BT"].ToString();
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
        
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var FBHControl = item.FindControl("FBHContainer");
                        if (FBHControl != null) 
                        {
                            FBHControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var XXZTControl = item.FindControl("XXZTContainer");
                        if (XXZTControl != null) 
                        {
                            XXZTControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var IsTopControl = item.FindControl("IsTopContainer");
                        if (IsTopControl != null) 
                        {
                            IsTopControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var TopSortControl = item.FindControl("TopSortContainer");
                        if (TopSortControl != null) 
                        {
                            TopSortControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var IsBestControl = item.FindControl("IsBestContainer");
                        if (IsBestControl != null) 
                        {
                            IsBestControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var FBRJGHControl = item.FindControl("FBRJGHContainer");
                        if (FBRJGHControl != null) 
                        {
                            FBRJGHControl.Visible = false;
                        }
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                        var FBIPControl = item.FindControl("FBIPContainer");
                        if (FBIPControl != null) 
                        {
                            FBIPControl.Visible = false;
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

