using System;
using System.Data;
using RICH.Common;
using RICH.Common.BM.T_BM_GZXX;
using Telerik.Web.UI;

namespace App
{
    public partial class T_BM_GZXXWebUIDetail : RICH.Common.BM.T_BM_GZXX.T_BM_GZXXWebUI
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
            appData = new T_BM_GZXXApplicationData();
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
                    strMessageParam[2] = drTemp["XM"].ToString();
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
        
                    if(CustomPermission == WDGZ_PURVIEW_ID)
                    {
                    TJSJCaption.Visible = false;
                    TJSJContent.Visible = false;
                    }
            }
        }
    }
}

