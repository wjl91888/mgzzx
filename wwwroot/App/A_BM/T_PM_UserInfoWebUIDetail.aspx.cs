using System;
using System.Data;
using RICH.Common;
using RICH.Common.BM.T_PM_UserInfo;
using Telerik.Web.UI;

namespace App
{
    public partial class T_PM_UserInfoWebUIDetail : RICH.Common.BM.T_PM_UserInfo.T_PM_UserInfoWebUI
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
            appData = new T_PM_UserInfoApplicationData();
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
                    strMessageParam[1] = "�û���Ϣ";
                    strMessageParam[2] = drTemp["UserNickName"].ToString();
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
        
            }
        }
    }
}

