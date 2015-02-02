using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.PM;
using RICH.Common.Base.WebUI;

public partial class APMUserGroupPurviewManage : WebUIBase
{
    /// <summary>
    /// ��ǰҳ������·��
    /// </summary>
    public override string CURRENT_PATH 
    {
        get { return "Administrator/A_BM"; }
    }

    /// <summary>
    /// ��ǰ����ҳ������
    /// </summary>
    private const string CURRENT_PAGE = "APMUserGroupPurviewManage.aspx";

    /// <summary>
    /// ���������תҳ������
    /// </summary>
    private const string REDIRECT_PAGE = "APMUserGroupList.aspx";

    /// <summary>
    /// ��ǰ����ҳ��Ȩ�ޱ��
    /// </summary>
    private const string CURRENT_PAGE_ACCESS_PURVIEW_ID = "APM16";

    #region ��ǰҳ���������
    /// <summary>
    /// �������HashTable
    /// </summary>
    private Hashtable htInputParameter;

    /// <summary>
    /// �������HashTable
    /// </summary>
    private Hashtable htOutputParameter;

    /// <summary>
    /// ������ȡ���ز�ѯ���������Ϊ�������ݵ������DataSet
    /// </summary>
    private DataSet dsRecordInfo;

    /// <summary>
    /// �����洢��Ϣ��Ϣ
    /// </summary>
    private string strMessageInfo = string.Empty;

    /// <summary>
    /// �����洢��Ϣ��Ϣ�Ĳ���
    /// </summary>
    private string[] strMessageParam = { string.Empty, string.Empty, string.Empty, string.Empty };
    #endregion
    public override string TableName
    {
        get { return null; }
    }

    public override string PurviewPrefix
    {
        get { return null; }
    }

    public override string FilterReportType
    {
        get { return null; }
    }

    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            //����SESSION��ֵ
            Session[ConstantsManager.SESSION_CURRENT_PAGE] = CURRENT_PATH + "/" + CURRENT_PAGE;
            CurrentAccessPermission = CURRENT_PAGE_ACCESS_PURVIEW_ID;

            if (Request.QueryString["UserGroupID"] != null
                && Request.QueryString["UserGroupID"] != ""
                && Request.QueryString["UserGroupID"] != string.Empty)
            {
                lblUserGroupID.Text = Request.QueryString["UserGroupID"];
                InitialControl();
            }
        }
        InitialPage();
        base.Page_Load(sender, e);
    }

    private void InitialControl()
    {
        rblPurviewPRI.Items.Add(new ListItem("ȫ��Ȩ��", "0"));
        rblPurviewPRI.Items.Add(new ListItem("�����̨Ȩ��", "1"));
        rblPurviewPRI.Items.Add(new ListItem("�û�ǰ̨Ȩ��", "2"));
        rblPurviewPRI.SelectedValue = "0";
    }
    private void InitialPage()
    {
        //����Ȩ����������ʱ����
        string strPurviewTypeName;
        int intCount;
        int i;
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserGroupID", lblUserGroupID.Text);

        UserGroupLibrary instanceUserGroupLibrary = new UserGroupLibrary();
        htOutputParameter = instanceUserGroupLibrary.SelectRecordInfo(htInputParameter);
        dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];

        lblUserGroupName.Text = dsRecordInfo.Tables[0].Rows[0]["UserGroupName"].ToString();
        lblUserGroupID.Text = dsRecordInfo.Tables[0].Rows[0]["UserGroupID"].ToString();
        lblUserGroupContent.Text = dsRecordInfo.Tables[0].Rows[0]["UserGroupContent"].ToString();

        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserGroupID", lblUserGroupID.Text);
        htInputParameter.Add("PurviewPRI", int.Parse(rblPurviewPRI.SelectedValue));
        UserGroupPurviewLibrary instanceUserGroupPurviewLibrary = new UserGroupPurviewLibrary();
        htOutputParameter = instanceUserGroupPurviewLibrary.GetUserGroupPurviewInfo(htInputParameter);
        dsRecordInfo = (DataSet)htOutputParameter[ConstantsManager.QUERY_DATASET_NAME];
        strPurviewTypeName = "";
        for (i = 0; i < dsRecordInfo.Tables[0].Rows.Count; i++)
        {
            TableRow trTemp = new TableRow();
            intCount = i;
            for (int j = i; j < intCount + 4 && j < dsRecordInfo.Tables[0].Rows.Count; j++)
            {
                i = j;
                if (dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString() != strPurviewTypeName)
                {
                    TableRow trTempTitle = new TableRow();
                    TableCell tcTempTitle = new TableCell();
                    Label lblTemp = new Label();
                    lblTemp.Text = dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString();
                    tcTempTitle.Controls.Add(lblTemp);
                    tcTempTitle.ColumnSpan = 4;
                    tcTempTitle.CssClass = "xingmu";
                    trTempTitle.Cells.Add(tcTempTitle);
                    tbPurviewInfo.Rows.Add(trTemp);
                    tbPurviewInfo.Rows.Add(trTempTitle);
                    strPurviewTypeName = dsRecordInfo.Tables[0].Rows[i]["PurviewTypeName"].ToString();
                    trTemp = new TableRow();
                }
                TableCell tcTemp = new TableCell();
                CheckBox chkTemp = new CheckBox();
                chkTemp.ID = dsRecordInfo.Tables[0].Rows[i]["PurviewID"].ToString();
                chkTemp.Text = dsRecordInfo.Tables[0].Rows[i]["PurviewName"].ToString();
                if (DataValidateManager.ValidateIsNull(dsRecordInfo.Tables[0].Rows[i]["IsPageMenu"]) == false)
                {
                    if ((bool)dsRecordInfo.Tables[0].Rows[i]["IsPageMenu"] == true)
                    {
                        chkTemp.Text = chkTemp.Text + "(�˵���)";
                    }
                }
                chkTemp.InputAttributes.Add("value", dsRecordInfo.Tables[0].Rows[i]["PurviewID"].ToString());
                if (dsRecordInfo.Tables[0].Rows[i]["UserGroupID"] == DBNull.Value
                    || dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() == ""
                    || dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() == string.Empty)
                {
                    chkTemp.Checked = false;
                }
                else if (dsRecordInfo.Tables[0].Rows[i]["UserGroupID"] != DBNull.Value
                         && dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() != ""
                         && dsRecordInfo.Tables[0].Rows[i]["UserGroupID"].ToString() != string.Empty)
                {
                    chkTemp.Checked = true;
                }
                tcTemp.Controls.Add(chkTemp);
                tcTemp.CssClass = "hback";
                trTemp.Cells.Add(tcTemp);
            }
            tbPurviewInfo.Rows.Add(trTemp);
        }
    }

    protected void btnSetPurview_Click(object sender, EventArgs e)
    {
        string strPurview, strDeletePurview;
        CheckBox chkTemp = new CheckBox();
        strPurview = "";
        strDeletePurview = "";
        foreach (TableRow trTemp in FindControl("tbPurviewInfo").Controls)
        {
            foreach (TableCell tcTemp in trTemp.Controls)
            {
                foreach (Object ctlTemp in tcTemp.Controls)
                {
                    if (ctlTemp.GetType().ToString() == typeof(CheckBox).ToString())
                    {
                        chkTemp = (CheckBox)ctlTemp;
                        if (chkTemp.Checked == true)
                        {
                            strPurview = strPurview + "," + chkTemp.ID.ToString();
                        }
                        else
                        {
                            strDeletePurview = strDeletePurview + "," + chkTemp.ID.ToString();
                        }
                    }
                }
            }
        }
        htInputParameter = new Hashtable();
        dsRecordInfo = new DataSet();
        htInputParameter.Add(ConstantsManager.QUERY_DATASET_NAME, dsRecordInfo);
        htInputParameter.Add(ConstantsManager.MESSAGE_ID, "");
        htInputParameter.Add("UserGroupID", lblUserGroupID.Text);
        htInputParameter.Add("UserGroupPurview", strPurview);
        htInputParameter.Add("UserGroupDeletePurview", strDeletePurview);
        UserGroupPurviewLibrary instanceUserGroupPurviewLibrary = new UserGroupPurviewLibrary();
        instanceUserGroupPurviewLibrary.SetUserGroupPurviewInfo(htInputParameter);

        //�Գɹ���Ϣ���д���
        strMessageParam[0] = "�û���Ȩ��";
        strMessageParam[1] = "�޸�";
        strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0015, strMessageParam, strMessageInfo);
        //MessageContent = strMessageInfo;
        Session[ConstantsManager.SESSION_REDIRECT_PAGE] = CURRENT_PATH + "/" + REDIRECT_PAGE;

        //��¼��־��ʼ
        string strLogTypeID = "A02";
        strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
        strMessageParam[1] = "�û���Ȩ��";
        strMessageParam[2] = lblUserGroupID.Text;
        strMessageParam[3] = "�޸�";
        string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0003, strMessageParam);
        LogLibrary.LogWrite(strLogTypeID, strLogContent, (string)htInputParameter["ObjectID"], null, null);
        //��¼��־����

        //�ɹ���ҳ����ת
        Response.Redirect(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Administrator/A_BM/APMUserGroupList.aspx");
        Response.End();
    }


    protected void rblPurviewPRI_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
