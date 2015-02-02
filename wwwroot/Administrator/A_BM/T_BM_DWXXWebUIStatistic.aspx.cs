/****************************************************** 
FileName:T_BM_DWXXWebUISearch.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_DWXX;

public partial class T_BM_DWXXWebUIStatistic : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
{
    protected override void Page_Init(object sender, EventArgs e)
    {
        base.Page_Init(sender, e);
    }

    //=====================================================================
    //  FunctionName : Page_Load
    /// <summary>
    /// Page_Load
    /// </summary>
    //=====================================================================
    protected override void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack != true)
        {
            InitalizeDataBind();
            InitalizeCoupledDataSource();
            // ��ʼ������

            // ����ؼ�״̬

            if (false

            )
            {
                statisticpage.Style.Add("display", "none");
                statisticresultpage.Visible = true;
                Initalize();
            }
            else
            {
                statisticpage.Visible = true;
                statisticresultpage.Visible = false;
            }
        }
        else
        {
            InitalizeCoupledDataSource();
        }
        base.Page_Load(sender, e);
    }


    //=====================================================================
    //  FunctionName : Initalize
    /// <summary>
    /// ���س�ʼ������
    /// </summary>
    //=====================================================================
    protected override void Initalize()
    {      
        // ������Ϣ����
        lblCaption.Text = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        // ����ͳ��
        appData = new T_BM_DWXXApplicationData();
        CountRecord();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
    }

    //=====================================================================
    //  FunctionName : InitalizeDataBind
    /// <summary>
    /// ��ʼ�����ݰ�
    /// </summary>
    //=====================================================================
    protected void InitalizeDataBind()
    {

        // һ��һ��ر�

    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ���ص������ļ�����
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new T_BM_DWXXApplicationData();
        CountRecord();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        // ������Ϣ����
        gvPrint.Caption = GetTableCaption();
        gvPrint.CaptionAlign = TableCaptionAlign.Left;
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFileWithoutControl(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFileWithoutControl(gvPrint, "Result");
                break;
            default:
                FileLibrary.ExportToExcelFileWithoutControl(gvPrint, "Result");
                break;
        }
    }

    #region �ؼ��¼�
    //=====================================================================
    //  FunctionName : btnShowStatistic_Click
    /// <summary>
    /// ��ʾͳ���������水ť�ؼ�Click�¼�
    /// </summary>
    //=====================================================================
    protected void btnShowStatistic_Click(object sender, EventArgs e)
    {
        statisticpage.Style.Add("display", "block");
        statisticresultpage.Visible = false;
    }

    //=====================================================================
    //  FunctionName : btnStatistic_Click
    /// <summary>
    /// ͳ�ƽ����ť�ؼ�Click�¼�
    /// </summary>
    //=====================================================================
    protected void btnStatistic_Click(object sender, EventArgs e)
    {
        statisticpage.Style.Add("display", "none");
        statisticresultpage.Visible = true;
        ViewState.Clear();
        Initalize();
    }
    #endregion


    //=====================================================================
    //  FunctionName : InitalizeCoupledDataSource
    /// <summary>
    /// ��ʼ����������
    /// </summary>
    //=====================================================================
    protected void InitalizeCoupledDataSource()
    {

    }




    //=====================================================================
    //  FunctionName : GetCountInputParameter
    /// <summary>
    /// �õ�ͳ�Ƽ�¼���û��������������ͨ��Request����
    /// </summary>
    //=====================================================================
    protected override Boolean GetCountInputParameter()
    {
        Boolean boolReturn = true;
        ValidateData validateData = new ValidateData();
        // ��֤�������


        if (!DataValidateManager.ValidateIsNull(CountField.SelectedValue))
        {
            if (!DataValidateManager.ValidateStringLengthRange(CountField.SelectedValue.ToString(), 1, 50))
            {
                  strMessageParam[0] = "ͳ�Ʒ�ʽ";
                  strMessageParam[1] = "1";
                  strMessageParam[2] = "50";
                  strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0004, strMessageParam, strMessageInfo);
                  boolReturn = false;
            }
            else
            {
                appData.CountField = CountField.SelectedValue.ToString();
            }
        }
        else
        {
              strMessageParam[0] = "ͳ�Ʒ�ʽ";
              strMessageInfo = MessageManager.GetMessageInfo(MessageManager.HINT_MSGID_0002, strMessageParam, strMessageInfo);
              boolReturn = false;
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
                appData.SortField = "RecordID";
            }
            else
            {
                appData.SortField = ViewState["SortField"].ToString();
            }
        }
        else
        {
            appData.SortField = "RecordID";
        }
        return boolReturn;
    }

    //=====================================================================
    //  FunctionName : GetTableCaption
    /// <summary>
    /// �õ���Ϣ����
    /// </summary>
    //=====================================================================
    private string GetTableCaption()
    {
        System.Text.StringBuilder sbCaption = new System.Text.StringBuilder(string.Empty);
            sbCaption.Append(@"<div class=""caption"">");
        sbCaption.Append(@"��λ��Ϣͳ�ƣ�"+CountField.SelectedItem.Text+"��");
            sbCaption.Append(@"</div>");
            sbCaption.Append(@"<div class=""captionnote"">");
            sbCaption.Append(@"ͳ���������£�");
        // ����

        // һ��һ��ر�

            sbCaption.Append("</div>");
        return sbCaption.ToString();
    }
}

