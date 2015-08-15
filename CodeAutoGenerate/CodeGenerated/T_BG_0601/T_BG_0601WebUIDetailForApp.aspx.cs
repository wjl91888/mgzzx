using System;
using System.Data;
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
            // ��ȡ��¼��ϸ����
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
                    //��¼��־��ʼ
                    string strLogTypeID = "A10";
                    strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                    strMessageParam[1] = "������Ϣ";
                    strMessageParam[2] = drTemp["BT"].ToString();
                    string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                    RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                    //��¼��־����
                }
            }
        }

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
        
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBHCaption.Visible = false;
                    FBHContent.Visible = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    XXZTCaption.Visible = false;
                    XXZTContent.Visible = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    IsTopCaption.Visible = false;
                    IsTopContent.Visible = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    TopSortCaption.Visible = false;
                    TopSortContent.Visible = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    IsBestCaption.Visible = false;
                    IsBestContent.Visible = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBRJGHCaption.Visible = false;
                    FBRJGHContent.Visible = false;
                    }
                    if(CustomPermission == WFBD_PURVIEW_ID)
                    {
                    FBIPCaption.Visible = false;
                    FBIPContent.Visible = false;
                    }
            }
        }
    }
}

