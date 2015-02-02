/****************************************************** 
FileName:T_BM_GZXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_GZXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_GZXXWebUIDetail : RICH.Common.BM.T_BM_GZXX.T_BM_GZXXWebUI
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
            Initalize();
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
        // �����ʼ��
        // ��ʼ����ӡҳ���С
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A4", "A4"));
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A3", "A3"));
        // ��ʼ����ӡҳ�淽���С
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("����", "portrait"));
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("����", "landscape"));

        // ��ȡ��¼��ϸ����
        appData = new T_BM_GZXXApplicationData();
        appData.ObjectID = ObjectID;
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        QueryRecord();
        Header.DataBind();
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();

        if (IsPostBack != true)
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

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// ����ExportToFile
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new T_BM_GZXXApplicationData();
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        appData.ObjectID = base.ObjectID;
        QueryRecord();
        gvPrint.Visible = true;
        gvPrint.DataSource = appData.ResultSet;
        gvPrint.DataBind();
        switch (ddlExportFileFormat.SelectedValue.ToLower())
        {
            case "xls":
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
            case "doc":
                FileLibrary.ExportToWordFile(gvPrint, "Result");
                break;
            case "pdf":
                string pageSize = ddlPrintPageSize.SelectedValue;
                bool boolOrientation = ddlPrintPageOrientation.SelectedValue == "landscape" ? true : false;
                float marginTop = DataValidateManager.ValidateNumberFormat(txtMarginTop.Text) == true ? Convert.ToSingle(txtMarginTop.Text) : 50;
                float marginRight = DataValidateManager.ValidateNumberFormat(txtMarginRight.Text) == true ? Convert.ToSingle(txtMarginRight.Text) : 50;
                float marginBottom = DataValidateManager.ValidateNumberFormat(txtMarginBottom.Text) == true ? Convert.ToSingle(txtMarginBottom.Text) : 50;
                float marginLeft = DataValidateManager.ValidateNumberFormat(txtMarginLeft.Text) == true ? Convert.ToSingle(txtMarginLeft.Text) : 50;
                ExportToPDFFile(appData.ResultSet, "Result", pageSize, boolOrientation, marginTop, marginRight, marginBottom, marginLeft);
                break;
            default:
                FileLibrary.ExportToExcelFile(gvPrint, "Result");
                break;
        }
        gvPrint.Visible = false;
    }

    protected void gvPrint_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            Control hcTemp;
            // �����������������
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // �������
            int intColumn = 0;
            
            intColumn += 4 + 12;
            intColumn += 4 + 4;
            // �������
            int intLength = 0;
    
            intLength = 14;
            intLength++;
            // ������
            for (int i = 0; i < intLength; i++)
            {
                TableRow trTemp = new TableRow();
                tDetailView.Rows.Add(trTemp);
            }
            // �õ�ֵ����ؼ�
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                hcTemp = tcTemp.FindControl("divvaluearea");
                if (hcTemp != null)
                {
                    // ���ɱ��
                    // ����������
                    for (int i = intColumn; i > 0; i--)
                    {
                        TableCell tcBlank = new TableCell();
                        tcBlank.ColumnSpan = 1;
                        tcBlank.RowSpan = 1;
                        tcBlank.Height = 0;
                        tcBlank.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        tcBlank.Style.Add("height", "0");
                        tDetailView.Rows[0].Cells.Add(tcBlank);
                    }
                    tDetailView.Rows[0].Height = 0;
            
                    // ��ʾ��������
                    TableCell tcXMTitle = new TableCell();
                    tcXMTitle.Text = "����";
                    tcXMTitle.ColumnSpan = 4;
                    tcXMTitle.RowSpan = 1;
                    tcXMTitle.CssClass = "fieldname";
                    tcXMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcXMTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcXMContent = new TableCell();
                      
                    tcXMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XM")).InnerHtml = "";
                    tcXMContent.ColumnSpan = 12;
                    tcXMContent.RowSpan = 1;
                    tcXMContent.CssClass = "fieldinput";
                    tcXMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcXMContent.Style.Add("border-top", "1px black solid");
                        
                    tcXMContent.Style.Add("border-left", "1px black solid");
                        
                    tcXMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXMContent.Style.Add("border-right", "1px black solid");
                        
                    tcXMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcXMContent);
              
                    // ��ʾ�Ա����
                    TableCell tcXBTitle = new TableCell();
                    tcXBTitle.Text = "�Ա�";
                    tcXBTitle.ColumnSpan = 4;
                    tcXBTitle.RowSpan = 1;
                    tcXBTitle.CssClass = "fieldname";
                    tcXBTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXBTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcXBTitle);
                    
                    // ��ʾ�Ա�ֵ
                    TableCell tcXBContent = new TableCell();
                      
                    tcXBContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XB")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XB")).InnerHtml = "";
                    tcXBContent.ColumnSpan = 4;
                    tcXBContent.RowSpan = 1;
                    tcXBContent.CssClass = "fieldinput";
                    tcXBContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXBContent.Style.Add("border-top", "1px black solid");
                        
                    tcXBContent.Style.Add("border-left", "1px black solid");
                        
                    tcXBContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXBContent.Style.Add("border-right", "1px black solid");
                        
                    tcXBContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcXBContent);
              
                    // ��ʾ���֤�ű���
                    TableCell tcSFZHTitle = new TableCell();
                    tcSFZHTitle.Text = "���֤��";
                    tcSFZHTitle.ColumnSpan = 4;
                    tcSFZHTitle.RowSpan = 1;
                    tcSFZHTitle.CssClass = "fieldname";
                    tcSFZHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSFZHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcSFZHTitle);
                    
                    // ��ʾ���֤��ֵ
                    TableCell tcSFZHContent = new TableCell();
                      
                    tcSFZHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFZH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFZH")).InnerHtml = "";
                    tcSFZHContent.ColumnSpan = 12;
                    tcSFZHContent.RowSpan = 1;
                    tcSFZHContent.CssClass = "fieldinput";
                    tcSFZHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 12 / intColumn));
                        
                    tcSFZHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFZHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFZHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcSFZHContent);
              
                    // ��ʾ���ڱ���
                    TableCell tcFFGZNYTitle = new TableCell();
                    tcFFGZNYTitle.Text = "����";
                    tcFFGZNYTitle.ColumnSpan = 4;
                    tcFFGZNYTitle.RowSpan = 1;
                    tcFFGZNYTitle.CssClass = "fieldname";
                    tcFFGZNYTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFFGZNYTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcFFGZNYTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcFFGZNYContent = new TableCell();
                      
                    tcFFGZNYContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FFGZNY")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FFGZNY")).InnerHtml = "";
                    tcFFGZNYContent.ColumnSpan = 4;
                    tcFFGZNYContent.RowSpan = 1;
                    tcFFGZNYContent.CssClass = "fieldinput";
                    tcFFGZNYContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFFGZNYContent.Style.Add("border-top", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("border-left", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("border-right", "1px black solid");
                        
                    tcFFGZNYContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcFFGZNYContent);
              
                    // ��ʾ�������ʱ���
                    TableCell tcJCGZTitle = new TableCell();
                    tcJCGZTitle.Text = "��������";
                    tcJCGZTitle.ColumnSpan = 4;
                    tcJCGZTitle.RowSpan = 1;
                    tcJCGZTitle.CssClass = "fieldname";
                    tcJCGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJCGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcJCGZTitle);
                    
                    // ��ʾ��������ֵ
                    TableCell tcJCGZContent = new TableCell();
                      
                    tcJCGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JCGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JCGZ")).InnerHtml = "";
                    tcJCGZContent.ColumnSpan = 4;
                    tcJCGZContent.RowSpan = 1;
                    tcJCGZContent.CssClass = "fieldinput";
                    tcJCGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJCGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJCGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJCGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJCGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJCGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[3].Cells.Add(tcJCGZContent);
              
                    // ��ʾ�����ȼ����ʱ���
                    TableCell tcJSDJGZTitle = new TableCell();
                    tcJSDJGZTitle.Text = "�����ȼ�����";
                    tcJSDJGZTitle.ColumnSpan = 4;
                    tcJSDJGZTitle.RowSpan = 1;
                    tcJSDJGZTitle.CssClass = "fieldname";
                    tcJSDJGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJSDJGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcJSDJGZTitle);
                    
                    // ��ʾ�����ȼ�����ֵ
                    TableCell tcJSDJGZContent = new TableCell();
                      
                    tcJSDJGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JSDJGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JSDJGZ")).InnerHtml = "";
                    tcJSDJGZContent.ColumnSpan = 4;
                    tcJSDJGZContent.RowSpan = 1;
                    tcJSDJGZContent.CssClass = "fieldinput";
                    tcJSDJGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJSDJGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJSDJGZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcJSDJGZContent);
              
                    // ��ʾְ���ʱ���
                    TableCell tcZWGZTitle = new TableCell();
                    tcZWGZTitle.Text = "ְ����";
                    tcZWGZTitle.ColumnSpan = 4;
                    tcZWGZTitle.RowSpan = 1;
                    tcZWGZTitle.CssClass = "fieldname";
                    tcZWGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcZWGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcZWGZTitle);
                    
                    // ��ʾְ����ֵ
                    TableCell tcZWGZContent = new TableCell();
                      
                    tcZWGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZWGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZWGZ")).InnerHtml = "";
                    tcZWGZContent.ColumnSpan = 4;
                    tcZWGZContent.RowSpan = 1;
                    tcZWGZContent.CssClass = "fieldinput";
                    tcZWGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcZWGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcZWGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcZWGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZWGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcZWGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[3].Cells.Add(tcZWGZContent);
              
                    // ��ʾ�����ʱ���
                    TableCell tcJBGZTitle = new TableCell();
                    tcJBGZTitle.Text = "������";
                    tcJBGZTitle.ColumnSpan = 4;
                    tcJBGZTitle.RowSpan = 1;
                    tcJBGZTitle.CssClass = "fieldname";
                    tcJBGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJBGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJBGZTitle);
                    
                    // ��ʾ������ֵ
                    TableCell tcJBGZContent = new TableCell();
                      
                    tcJBGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JBGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JBGZ")).InnerHtml = "";
                    tcJBGZContent.ColumnSpan = 4;
                    tcJBGZContent.RowSpan = 1;
                    tcJBGZContent.CssClass = "fieldinput";
                    tcJBGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJBGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJBGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJBGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJBGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJBGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[4].Cells.Add(tcJBGZContent);
              
                    // ��ʾ��������������
                    TableCell tcJKDQJTTitle = new TableCell();
                    tcJKDQJTTitle.Text = "����������";
                    tcJKDQJTTitle.ColumnSpan = 4;
                    tcJKDQJTTitle.RowSpan = 1;
                    tcJKDQJTTitle.CssClass = "fieldname";
                    tcJKDQJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJKDQJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJKDQJTTitle);
                    
                    // ��ʾ����������ֵ
                    TableCell tcJKDQJTContent = new TableCell();
                      
                    tcJKDQJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JKDQJT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JKDQJT")).InnerHtml = "";
                    tcJKDQJTContent.ColumnSpan = 4;
                    tcJKDQJTContent.RowSpan = 1;
                    tcJKDQJTContent.CssClass = "fieldinput";
                    tcJKDQJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJKDQJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcJKDQJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[4].Cells.Add(tcJKDQJTContent);
              
                    // ��ʾ����ظڽ�������
                    TableCell tcJKTSGWJTTitle = new TableCell();
                    tcJKTSGWJTTitle.Text = "����ظڽ���";
                    tcJKTSGWJTTitle.ColumnSpan = 4;
                    tcJKTSGWJTTitle.RowSpan = 1;
                    tcJKTSGWJTTitle.CssClass = "fieldname";
                    tcJKTSGWJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJKTSGWJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcJKTSGWJTTitle);
                    
                    // ��ʾ����ظڽ���ֵ
                    TableCell tcJKTSGWJTContent = new TableCell();
                      
                    tcJKTSGWJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JKTSGWJT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JKTSGWJT")).InnerHtml = "";
                    tcJKTSGWJTContent.ColumnSpan = 4;
                    tcJKTSGWJTContent.RowSpan = 1;
                    tcJKTSGWJTContent.CssClass = "fieldinput";
                    tcJKTSGWJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJKTSGWJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcJKTSGWJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[4].Cells.Add(tcJKTSGWJTContent);
              
                    // ��ʾ���乤�ʱ���
                    TableCell tcGLGZTitle = new TableCell();
                    tcGLGZTitle.Text = "���乤��";
                    tcGLGZTitle.ColumnSpan = 4;
                    tcGLGZTitle.RowSpan = 1;
                    tcGLGZTitle.CssClass = "fieldname";
                    tcGLGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcGLGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcGLGZTitle);
                    
                    // ��ʾ���乤��ֵ
                    TableCell tcGLGZContent = new TableCell();
                      
                    tcGLGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("GLGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("GLGZ")).InnerHtml = "";
                    tcGLGZContent.ColumnSpan = 4;
                    tcGLGZContent.RowSpan = 1;
                    tcGLGZContent.CssClass = "fieldinput";
                    tcGLGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcGLGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcGLGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcGLGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcGLGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcGLGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[5].Cells.Add(tcGLGZContent);
              
                    // ��ʾн�����ʱ���
                    TableCell tcXJGZTitle = new TableCell();
                    tcXJGZTitle.Text = "н������";
                    tcXJGZTitle.ColumnSpan = 4;
                    tcXJGZTitle.RowSpan = 1;
                    tcXJGZTitle.CssClass = "fieldname";
                    tcXJGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcXJGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcXJGZTitle);
                    
                    // ��ʾн������ֵ
                    TableCell tcXJGZContent = new TableCell();
                      
                    tcXJGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("XJGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("XJGZ")).InnerHtml = "";
                    tcXJGZContent.ColumnSpan = 4;
                    tcXJGZContent.RowSpan = 1;
                    tcXJGZContent.CssClass = "fieldinput";
                    tcXJGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcXJGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcXJGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcXJGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcXJGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcXJGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[5].Cells.Add(tcXJGZContent);
              
                    // ��ʾ10%��߲��ֱ���
                    TableCell tcTGBFTitle = new TableCell();
                    tcTGBFTitle.Text = "10%��߲���";
                    tcTGBFTitle.ColumnSpan = 4;
                    tcTGBFTitle.RowSpan = 1;
                    tcTGBFTitle.CssClass = "fieldname";
                    tcTGBFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcTGBFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcTGBFTitle);
                    
                    // ��ʾ10%��߲���ֵ
                    TableCell tcTGBFContent = new TableCell();
                      
                    tcTGBFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("TGBF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("TGBF")).InnerHtml = "";
                    tcTGBFContent.ColumnSpan = 4;
                    tcTGBFContent.RowSpan = 1;
                    tcTGBFContent.CssClass = "fieldinput";
                    tcTGBFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcTGBFContent.Style.Add("border-top", "1px black solid");
                        
                    tcTGBFContent.Style.Add("border-left", "1px black solid");
                        
                    tcTGBFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcTGBFContent.Style.Add("border-right", "1px black solid");
                        
                    tcTGBFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[5].Cells.Add(tcTGBFContent);
              
                    // ��ʾ�绰�ѱ���
                    TableCell tcDHFTitle = new TableCell();
                    tcDHFTitle.Text = "�绰��";
                    tcDHFTitle.ColumnSpan = 4;
                    tcDHFTitle.RowSpan = 1;
                    tcDHFTitle.CssClass = "fieldname";
                    tcDHFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDHFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcDHFTitle);
                    
                    // ��ʾ�绰��ֵ
                    TableCell tcDHFContent = new TableCell();
                      
                    tcDHFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DHF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DHF")).InnerHtml = "";
                    tcDHFContent.ColumnSpan = 4;
                    tcDHFContent.RowSpan = 1;
                    tcDHFContent.CssClass = "fieldinput";
                    tcDHFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcDHFContent.Style.Add("border-top", "1px black solid");
                        
                    tcDHFContent.Style.Add("border-left", "1px black solid");
                        
                    tcDHFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDHFContent.Style.Add("border-right", "1px black solid");
                        
                    tcDHFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[6].Cells.Add(tcDHFContent);
              
                    // ��ʾ������Ů�ѱ���
                    TableCell tcDSZNFTitle = new TableCell();
                    tcDSZNFTitle.Text = "������Ů��";
                    tcDSZNFTitle.ColumnSpan = 4;
                    tcDSZNFTitle.RowSpan = 1;
                    tcDSZNFTitle.CssClass = "fieldname";
                    tcDSZNFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDSZNFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcDSZNFTitle);
                    
                    // ��ʾ������Ů��ֵ
                    TableCell tcDSZNFContent = new TableCell();
                      
                    tcDSZNFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DSZNF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DSZNF")).InnerHtml = "";
                    tcDSZNFContent.ColumnSpan = 4;
                    tcDSZNFContent.RowSpan = 1;
                    tcDSZNFContent.CssClass = "fieldinput";
                    tcDSZNFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcDSZNFContent.Style.Add("border-top", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("border-left", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("border-right", "1px black solid");
                        
                    tcDSZNFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[6].Cells.Add(tcDSZNFContent);
              
                    // ��ʾ��Ů�����ѱ���
                    TableCell tcFNWSHLFTitle = new TableCell();
                    tcFNWSHLFTitle.Text = "��Ů������";
                    tcFNWSHLFTitle.ColumnSpan = 4;
                    tcFNWSHLFTitle.RowSpan = 1;
                    tcFNWSHLFTitle.CssClass = "fieldname";
                    tcFNWSHLFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcFNWSHLFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[6].Cells.Add(tcFNWSHLFTitle);
                    
                    // ��ʾ��Ů������ֵ
                    TableCell tcFNWSHLFContent = new TableCell();
                      
                    tcFNWSHLFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("FNWSHLF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("FNWSHLF")).InnerHtml = "";
                    tcFNWSHLFContent.ColumnSpan = 4;
                    tcFNWSHLFContent.RowSpan = 1;
                    tcFNWSHLFContent.CssClass = "fieldinput";
                    tcFNWSHLFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcFNWSHLFContent.Style.Add("border-top", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("border-left", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("border-right", "1px black solid");
                        
                    tcFNWSHLFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[6].Cells.Add(tcFNWSHLFContent);
              
                    // ��ʾ����ѱ���
                    TableCell tcHLFTitle = new TableCell();
                    tcHLFTitle.Text = "�����";
                    tcHLFTitle.ColumnSpan = 4;
                    tcHLFTitle.RowSpan = 1;
                    tcHLFTitle.CssClass = "fieldname";
                    tcHLFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcHLFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcHLFTitle);
                    
                    // ��ʾ�����ֵ
                    TableCell tcHLFContent = new TableCell();
                      
                    tcHLFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("HLF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("HLF")).InnerHtml = "";
                    tcHLFContent.ColumnSpan = 4;
                    tcHLFContent.RowSpan = 1;
                    tcHLFContent.CssClass = "fieldinput";
                    tcHLFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcHLFContent.Style.Add("border-top", "1px black solid");
                        
                    tcHLFContent.Style.Add("border-left", "1px black solid");
                        
                    tcHLFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcHLFContent.Style.Add("border-right", "1px black solid");
                        
                    tcHLFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[7].Cells.Add(tcHLFContent);
              
                    // ��ʾȡů��������
                    TableCell tcJJTitle = new TableCell();
                    tcJJTitle.Text = "ȡů����";
                    tcJJTitle.ColumnSpan = 4;
                    tcJJTitle.RowSpan = 1;
                    tcJJTitle.CssClass = "fieldname";
                    tcJJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcJJTitle);
                    
                    // ��ʾȡů����ֵ
                    TableCell tcJJContent = new TableCell();
                      
                    tcJJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JJ")).InnerHtml = "";
                    tcJJContent.ColumnSpan = 4;
                    tcJJContent.RowSpan = 1;
                    tcJJContent.CssClass = "fieldinput";
                    tcJJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJJContent.Style.Add("border-top", "1px black solid");
                        
                    tcJJContent.Style.Add("border-left", "1px black solid");
                        
                    tcJJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJJContent.Style.Add("border-right", "1px black solid");
                        
                    tcJJContent.Style.Add("text-align", "right");
                    tDetailView.Rows[7].Cells.Add(tcJJContent);
              
                    // ��ʾ��ͨ�ѱ���
                    TableCell tcJTFTitle = new TableCell();
                    tcJTFTitle.Text = "��ͨ��";
                    tcJTFTitle.ColumnSpan = 4;
                    tcJTFTitle.RowSpan = 1;
                    tcJTFTitle.CssClass = "fieldname";
                    tcJTFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJTFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[7].Cells.Add(tcJTFTitle);
                    
                    // ��ʾ��ͨ��ֵ
                    TableCell tcJTFContent = new TableCell();
                      
                    tcJTFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JTF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JTF")).InnerHtml = "";
                    tcJTFContent.ColumnSpan = 4;
                    tcJTFContent.RowSpan = 1;
                    tcJTFContent.CssClass = "fieldinput";
                    tcJTFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJTFContent.Style.Add("border-top", "1px black solid");
                        
                    tcJTFContent.Style.Add("border-left", "1px black solid");
                        
                    tcJTFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJTFContent.Style.Add("border-right", "1px black solid");
                        
                    tcJTFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[7].Cells.Add(tcJTFContent);
              
                    // ��ʾ�̻��乤�ʱ���
                    TableCell tcJHLGZTitle = new TableCell();
                    tcJHLGZTitle.Text = "�̻��乤��";
                    tcJHLGZTitle.ColumnSpan = 4;
                    tcJHLGZTitle.RowSpan = 1;
                    tcJHLGZTitle.CssClass = "fieldname";
                    tcJHLGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJHLGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcJHLGZTitle);
                    
                    // ��ʾ�̻��乤��ֵ
                    TableCell tcJHLGZContent = new TableCell();
                      
                    tcJHLGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JHLGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JHLGZ")).InnerHtml = "";
                    tcJHLGZContent.ColumnSpan = 4;
                    tcJHLGZContent.RowSpan = 1;
                    tcJHLGZContent.CssClass = "fieldinput";
                    tcJHLGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJHLGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcJHLGZContent.Style.Add("text-align", "right");
                    tDetailView.Rows[8].Cells.Add(tcJHLGZContent);
              
                    // ��ʾ��������
                    TableCell tcJTTitle = new TableCell();
                    tcJTTitle.Text = "����";
                    tcJTTitle.ColumnSpan = 4;
                    tcJTTitle.RowSpan = 1;
                    tcJTTitle.CssClass = "fieldname";
                    tcJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcJTTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcJTContent = new TableCell();
                      
                    tcJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("JT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("JT")).InnerHtml = "";
                    tcJTContent.ColumnSpan = 4;
                    tcJTContent.RowSpan = 1;
                    tcJTContent.CssClass = "fieldinput";
                    tcJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[8].Cells.Add(tcJTContent);
              
                    // ��ʾ��������
                    TableCell tcBFTitle = new TableCell();
                    tcBFTitle.Text = "����";
                    tcBFTitle.ColumnSpan = 4;
                    tcBFTitle.RowSpan = 1;
                    tcBFTitle.CssClass = "fieldname";
                    tcBFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcBFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[8].Cells.Add(tcBFTitle);
                    
                    // ��ʾ����ֵ
                    TableCell tcBFContent = new TableCell();
                      
                    tcBFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("BF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("BF")).InnerHtml = "";
                    tcBFContent.ColumnSpan = 4;
                    tcBFContent.RowSpan = 1;
                    tcBFContent.CssClass = "fieldinput";
                    tcBFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcBFContent.Style.Add("border-top", "1px black solid");
                        
                    tcBFContent.Style.Add("border-left", "1px black solid");
                        
                    tcBFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcBFContent.Style.Add("border-right", "1px black solid");
                        
                    tcBFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[8].Cells.Add(tcBFContent);
              
                    // ��ʾ������������
                    TableCell tcQTBTTitle = new TableCell();
                    tcQTBTTitle.Text = "��������";
                    tcQTBTTitle.ColumnSpan = 4;
                    tcQTBTTitle.RowSpan = 1;
                    tcQTBTTitle.CssClass = "fieldname";
                    tcQTBTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcQTBTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcQTBTTitle);
                    
                    // ��ʾ��������ֵ
                    TableCell tcQTBTContent = new TableCell();
                      
                    tcQTBTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("QTBT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("QTBT")).InnerHtml = "";
                    tcQTBTContent.ColumnSpan = 4;
                    tcQTBTContent.RowSpan = 1;
                    tcQTBTContent.CssClass = "fieldinput";
                    tcQTBTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcQTBTContent.Style.Add("border-top", "1px black solid");
                        
                    tcQTBTContent.Style.Add("border-left", "1px black solid");
                        
                    tcQTBTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcQTBTContent.Style.Add("border-right", "1px black solid");
                        
                    tcQTBTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[9].Cells.Add(tcQTBTContent);
              
                    // ��ʾ�ط��Խ�������
                    TableCell tcDFXJTTitle = new TableCell();
                    tcDFXJTTitle.Text = "�ط��Խ���";
                    tcDFXJTTitle.ColumnSpan = 4;
                    tcDFXJTTitle.RowSpan = 1;
                    tcDFXJTTitle.CssClass = "fieldname";
                    tcDFXJTTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcDFXJTTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcDFXJTTitle);
                    
                    // ��ʾ�ط��Խ���ֵ
                    TableCell tcDFXJTContent = new TableCell();
                      
                    tcDFXJTContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DFXJT")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DFXJT")).InnerHtml = "";
                    tcDFXJTContent.ColumnSpan = 4;
                    tcDFXJTContent.RowSpan = 1;
                    tcDFXJTContent.CssClass = "fieldinput";
                    tcDFXJTContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcDFXJTContent.Style.Add("border-top", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("border-left", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("border-right", "1px black solid");
                        
                    tcDFXJTContent.Style.Add("text-align", "right");
                    tDetailView.Rows[9].Cells.Add(tcDFXJTContent);
              
                    // ��ʾӦ�������
                    TableCell tcYFXTitle = new TableCell();
                    tcYFXTitle.Text = "Ӧ����";
                    tcYFXTitle.ColumnSpan = 4;
                    tcYFXTitle.RowSpan = 1;
                    tcYFXTitle.CssClass = "fieldname";
                    tcYFXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYFXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[9].Cells.Add(tcYFXTitle);
                    
                    // ��ʾӦ����ֵ
                    TableCell tcYFXContent = new TableCell();
                      
                    tcYFXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YFX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YFX")).InnerHtml = "";
                    tcYFXContent.ColumnSpan = 4;
                    tcYFXContent.RowSpan = 1;
                    tcYFXContent.CssClass = "fieldinput";
                    tcYFXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYFXContent.Style.Add("border-top", "1px black solid");
                        
                    tcYFXContent.Style.Add("border-left", "1px black solid");
                        
                    tcYFXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYFXContent.Style.Add("border-right", "1px black solid");
                        
                    tcYFXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[9].Cells.Add(tcYFXContent);
              
                    // ��ʾ�����ۿ����
                    TableCell tcQTKKTitle = new TableCell();
                    tcQTKKTitle.Text = "�����ۿ�";
                    tcQTKKTitle.ColumnSpan = 4;
                    tcQTKKTitle.RowSpan = 1;
                    tcQTKKTitle.CssClass = "fieldname";
                    tcQTKKTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcQTKKTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[10].Cells.Add(tcQTKKTitle);
                    
                    // ��ʾ�����ۿ�ֵ
                    TableCell tcQTKKContent = new TableCell();
                      
                    tcQTKKContent.Text = ((HtmlContainerControl)hcTemp.FindControl("QTKK")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("QTKK")).InnerHtml = "";
                    tcQTKKContent.ColumnSpan = 4;
                    tcQTKKContent.RowSpan = 1;
                    tcQTKKContent.CssClass = "fieldinput";
                    tcQTKKContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcQTKKContent.Style.Add("border-top", "1px black solid");
                        
                    tcQTKKContent.Style.Add("border-left", "1px black solid");
                        
                    tcQTKKContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcQTKKContent.Style.Add("border-right", "1px black solid");
                        
                    tcQTKKContent.Style.Add("text-align", "right");
                    tDetailView.Rows[10].Cells.Add(tcQTKKContent);
              
                    // ��ʾʧҵ���ձ���
                    TableCell tcSYBXTitle = new TableCell();
                    tcSYBXTitle.Text = "ʧҵ����";
                    tcSYBXTitle.ColumnSpan = 4;
                    tcSYBXTitle.RowSpan = 1;
                    tcSYBXTitle.CssClass = "fieldname";
                    tcSYBXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSYBXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[10].Cells.Add(tcSYBXTitle);
                    
                    // ��ʾʧҵ����ֵ
                    TableCell tcSYBXContent = new TableCell();
                      
                    tcSYBXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SYBX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SYBX")).InnerHtml = "";
                    tcSYBXContent.ColumnSpan = 4;
                    tcSYBXContent.RowSpan = 1;
                    tcSYBXContent.CssClass = "fieldinput";
                    tcSYBXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSYBXContent.Style.Add("border-top", "1px black solid");
                        
                    tcSYBXContent.Style.Add("border-left", "1px black solid");
                        
                    tcSYBXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSYBXContent.Style.Add("border-right", "1px black solid");
                        
                    tcSYBXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[10].Cells.Add(tcSYBXContent);
              
                    // ��ʾˮ��ů���ѱ���
                    TableCell tcSDNQFTitle = new TableCell();
                    tcSDNQFTitle.Text = "ˮ��ů����";
                    tcSDNQFTitle.ColumnSpan = 4;
                    tcSDNQFTitle.RowSpan = 1;
                    tcSDNQFTitle.CssClass = "fieldname";
                    tcSDNQFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSDNQFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[10].Cells.Add(tcSDNQFTitle);
                    
                    // ��ʾˮ��ů����ֵ
                    TableCell tcSDNQFContent = new TableCell();
                      
                    tcSDNQFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SDNQF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SDNQF")).InnerHtml = "";
                    tcSDNQFContent.ColumnSpan = 4;
                    tcSDNQFContent.RowSpan = 1;
                    tcSDNQFContent.CssClass = "fieldinput";
                    tcSDNQFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSDNQFContent.Style.Add("border-top", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("border-left", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("border-right", "1px black solid");
                        
                    tcSDNQFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[10].Cells.Add(tcSDNQFContent);
              
                    // ��ʾ����˰����
                    TableCell tcSDSTitle = new TableCell();
                    tcSDSTitle.Text = "����˰";
                    tcSDSTitle.ColumnSpan = 4;
                    tcSDSTitle.RowSpan = 1;
                    tcSDSTitle.CssClass = "fieldname";
                    tcSDSTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSDSTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[11].Cells.Add(tcSDSTitle);
                    
                    // ��ʾ����˰ֵ
                    TableCell tcSDSContent = new TableCell();
                      
                    tcSDSContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SDS")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SDS")).InnerHtml = "";
                    tcSDSContent.ColumnSpan = 4;
                    tcSDSContent.RowSpan = 1;
                    tcSDSContent.CssClass = "fieldinput";
                    tcSDSContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcSDSContent.Style.Add("border-top", "1px black solid");
                        
                    tcSDSContent.Style.Add("border-left", "1px black solid");
                        
                    tcSDSContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSDSContent.Style.Add("border-right", "1px black solid");
                        
                    tcSDSContent.Style.Add("text-align", "right");
                    tDetailView.Rows[11].Cells.Add(tcSDSContent);
              
                    // ��ʾ���ϱ��ձ���
                    TableCell tcYLBXTitle = new TableCell();
                    tcYLBXTitle.Text = "���ϱ���";
                    tcYLBXTitle.ColumnSpan = 4;
                    tcYLBXTitle.RowSpan = 1;
                    tcYLBXTitle.CssClass = "fieldname";
                    tcYLBXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYLBXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[11].Cells.Add(tcYLBXTitle);
                    
                    // ��ʾ���ϱ���ֵ
                    TableCell tcYLBXContent = new TableCell();
                      
                    tcYLBXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YLBX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YLBX")).InnerHtml = "";
                    tcYLBXContent.ColumnSpan = 4;
                    tcYLBXContent.RowSpan = 1;
                    tcYLBXContent.CssClass = "fieldinput";
                    tcYLBXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYLBXContent.Style.Add("border-top", "1px black solid");
                        
                    tcYLBXContent.Style.Add("border-left", "1px black solid");
                        
                    tcYLBXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYLBXContent.Style.Add("border-right", "1px black solid");
                        
                    tcYLBXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[11].Cells.Add(tcYLBXContent);
              
                    // ��ʾҽ�Ʊ��ձ���
                    TableCell tcYLIBXTitle = new TableCell();
                    tcYLIBXTitle.Text = "ҽ�Ʊ���";
                    tcYLIBXTitle.ColumnSpan = 4;
                    tcYLIBXTitle.RowSpan = 1;
                    tcYLIBXTitle.CssClass = "fieldname";
                    tcYLIBXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYLIBXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[11].Cells.Add(tcYLIBXTitle);
                    
                    // ��ʾҽ�Ʊ���ֵ
                    TableCell tcYLIBXContent = new TableCell();
                      
                    tcYLIBXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YLIBX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YLIBX")).InnerHtml = "";
                    tcYLIBXContent.ColumnSpan = 4;
                    tcYLIBXContent.RowSpan = 1;
                    tcYLIBXContent.CssClass = "fieldinput";
                    tcYLIBXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYLIBXContent.Style.Add("border-top", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("border-left", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("border-right", "1px black solid");
                        
                    tcYLIBXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[11].Cells.Add(tcYLIBXContent);
              
                    // ��ʾ��������ѱ���
                    TableCell tcYSSHFTitle = new TableCell();
                    tcYSSHFTitle.Text = "���������";
                    tcYSSHFTitle.ColumnSpan = 4;
                    tcYSSHFTitle.RowSpan = 1;
                    tcYSSHFTitle.CssClass = "fieldname";
                    tcYSSHFTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcYSSHFTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[12].Cells.Add(tcYSSHFTitle);
                    
                    // ��ʾ���������ֵ
                    TableCell tcYSSHFContent = new TableCell();
                      
                    tcYSSHFContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YSSHF")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YSSHF")).InnerHtml = "";
                    tcYSSHFContent.ColumnSpan = 4;
                    tcYSSHFContent.RowSpan = 1;
                    tcYSSHFContent.CssClass = "fieldinput";
                    tcYSSHFContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcYSSHFContent.Style.Add("border-top", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("border-left", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("border-right", "1px black solid");
                        
                    tcYSSHFContent.Style.Add("text-align", "right");
                    tDetailView.Rows[12].Cells.Add(tcYSSHFContent);
              
                    // ��ʾס�����������
                    TableCell tcZFGJJTitle = new TableCell();
                    tcZFGJJTitle.Text = "ס��������";
                    tcZFGJJTitle.ColumnSpan = 4;
                    tcZFGJJTitle.RowSpan = 1;
                    tcZFGJJTitle.CssClass = "fieldname";
                    tcZFGJJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcZFGJJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[12].Cells.Add(tcZFGJJTitle);
                    
                    // ��ʾס��������ֵ
                    TableCell tcZFGJJContent = new TableCell();
                      
                    tcZFGJJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("ZFGJJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("ZFGJJ")).InnerHtml = "";
                    tcZFGJJContent.ColumnSpan = 4;
                    tcZFGJJContent.RowSpan = 1;
                    tcZFGJJContent.CssClass = "fieldinput";
                    tcZFGJJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcZFGJJContent.Style.Add("border-top", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("border-left", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("border-right", "1px black solid");
                        
                    tcZFGJJContent.Style.Add("text-align", "right");
                    tDetailView.Rows[12].Cells.Add(tcZFGJJContent);
              
                    // ��ʾ�۷������
                    TableCell tcKFXTitle = new TableCell();
                    tcKFXTitle.Text = "�۷���";
                    tcKFXTitle.ColumnSpan = 4;
                    tcKFXTitle.RowSpan = 1;
                    tcKFXTitle.CssClass = "fieldname";
                    tcKFXTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcKFXTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[12].Cells.Add(tcKFXTitle);
                    
                    // ��ʾ�۷���ֵ
                    TableCell tcKFXContent = new TableCell();
                      
                    tcKFXContent.Text = ((HtmlContainerControl)hcTemp.FindControl("KFX")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("KFX")).InnerHtml = "";
                    tcKFXContent.ColumnSpan = 4;
                    tcKFXContent.RowSpan = 1;
                    tcKFXContent.CssClass = "fieldinput";
                    tcKFXContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                        
                    tcKFXContent.Style.Add("border-top", "1px black solid");
                        
                    tcKFXContent.Style.Add("border-left", "1px black solid");
                        
                    tcKFXContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcKFXContent.Style.Add("border-right", "1px black solid");
                        
                    tcKFXContent.Style.Add("text-align", "right");
                    tDetailView.Rows[12].Cells.Add(tcKFXContent);
              
                    // ��ʾʵ�����ʱ���
                    TableCell tcSFGZTitle = new TableCell();
                    tcSFGZTitle.Text = "ʵ������";
                    tcSFGZTitle.ColumnSpan = 4;
                    tcSFGZTitle.RowSpan = 1;
                    tcSFGZTitle.CssClass = "fieldname";
                    tcSFGZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcSFGZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[13].Cells.Add(tcSFGZTitle);
                    
                    // ��ʾʵ������ֵ
                    TableCell tcSFGZContent = new TableCell();
                      
                    tcSFGZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SFGZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SFGZ")).InnerHtml = "";
                    tcSFGZContent.ColumnSpan = 20;
                    tcSFGZContent.RowSpan = 1;
                    tcSFGZContent.CssClass = "fieldinput";
                    tcSFGZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcSFGZContent.Style.Add("border-top", "1px black solid");
                        
                    tcSFGZContent.Style.Add("border-left", "1px black solid");
                        
                    tcSFGZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSFGZContent.Style.Add("border-right", "1px black solid");
                        
                    tcSFGZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[13].Cells.Add(tcSFGZContent);
              
                    // ��ʾ˵������
                    TableCell tcGZKKSMTitle = new TableCell();
                    tcGZKKSMTitle.Text = "˵��";
                    tcGZKKSMTitle.ColumnSpan = 4;
                    tcGZKKSMTitle.RowSpan = 1;
                    tcGZKKSMTitle.CssClass = "fieldname";
                    tcGZKKSMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 4 / intColumn));
                    tcGZKKSMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[14].Cells.Add(tcGZKKSMTitle);
                    
                    // ��ʾ˵��ֵ
                    TableCell tcGZKKSMContent = new TableCell();
                      
                    tcGZKKSMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("GZKKSM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("GZKKSM")).InnerHtml = "";
                    tcGZKKSMContent.ColumnSpan = 20;
                    tcGZKKSMContent.RowSpan = 1;
                    tcGZKKSMContent.CssClass = "fieldinput";
                    tcGZKKSMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 20 / intColumn));
                        
                    tcGZKKSMContent.Style.Add("border-top", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("border-left", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("border-right", "1px black solid");
                        
                    tcGZKKSMContent.Style.Add("text-align", "left");
                    tDetailView.Rows[14].Cells.Add(tcGZKKSMContent);
              
                    // ����һ��һ��ر���
            
                    break;
                }
            }
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                // ����������Ϣ
                hcTemp = tcTemp.FindControl("divmain");
                if (hcTemp != null)
                {
                    hcTemp.Controls.Add(tDetailView);
                }
    
            }
        }
    }

    protected void ExportToPDFFile(DataSet dsMainTable,
        string filename,
        string pageSize,
        bool boolOrientation,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft
        )
    {
        Response.ContentType = "application/pdf";
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".pdf");
        Response.Charset = "GB2312";
        Response.ContentEncoding = System.Text.Encoding.UTF7;
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = GeneratePDFDocument(dsMainTable, pageSize, boolOrientation, marginTop, marginRight, marginBottom, marginLeft);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        Response.Write(pdfDoc);
        Response.End();
    }

    private iTextSharp.text.Document GeneratePDFDocument(DataSet dsMainTable,
        string pageSize,
        bool boolOrientation,
        float marginTop,
        float marginRight,
        float marginBottom,
        float marginLeft
        )
    {
        Rectangle rect;
        switch (pageSize)
        {
            case "A0":
                rect = new Rectangle(boolOrientation == true ? PageSize.A0.Rotate() : PageSize.A0);
                break;
            case "A1":
                rect = new Rectangle(boolOrientation == true ? PageSize.A1.Rotate() : PageSize.A1);
                break;
            case "A2":
                rect = new Rectangle(boolOrientation == true ? PageSize.A2.Rotate() : PageSize.A2);
                break;
            case "A3":
                rect = new Rectangle(boolOrientation == true ? PageSize.A3.Rotate() : PageSize.A3);
                break;
            case "A4":
                rect = new Rectangle(boolOrientation == true ? PageSize.A4.Rotate() : PageSize.A4);
                break;
            default:
                rect = new Rectangle(boolOrientation == true ? PageSize.A4.Rotate() : PageSize.A4);
                break;
        }
        // �����հ�PDF�ĵ�
        Document pdfDoc = new Document(rect, marginLeft, marginRight, marginTop, marginBottom);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        // �������һ��һ��ر���Ϣ
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // ���һ�Զ���ر���Ϣ
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // ���ɱ��
        BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font22B = new Font(bfChinese, 22, iTextSharp.text.Font.BOLD);
        Font font22 = new Font(bfChinese, 22);
        Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        Font font20 = new Font(bfChinese, 20);
        Font font19B = new Font(bfChinese, 19, iTextSharp.text.Font.BOLD);
        Font font19 = new Font(bfChinese, 19);
        Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        Font font14 = new Font(bfChinese, 14);
        Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        Font font13 = new Font(bfChinese, 13);
        Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        Font font12 = new Font(bfChinese, 12);
        Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        Font font11 = new Font(bfChinese, 11);
        Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        Font font10 = new Font(bfChinese, 10);
        Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        Font font9 = new Font(bfChinese, 9);
        Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        Font font8 = new Font(bfChinese, 8);
        int intColumn = 0;
        
        intColumn += 4 + 12;
        intColumn += 4 + 4;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // �����ͷ��Ϣ
        Cell cellTitle = new Cell(new Paragraph("������Ϣ", font19B));
        cellTitle.BorderWidth = 0;
        cellTitle.HorizontalAlignment = 1;
        cellTitle.VerticalAlignment = 1;
        cellTitle.Colspan = intColumn;
        itbOutput.AddCell(cellTitle);
          
        Cell cellTitleSpace = new Cell(new Paragraph(" ", font20B));
        cellTitleSpace.BorderWidth = 0;
        cellTitleSpace.HorizontalAlignment = 1;
        cellTitleSpace.VerticalAlignment = 1;
        cellTitleSpace.Colspan = intColumn;
        itbOutput.AddCell(cellTitleSpace);
        itbOutput.AddCell(cellTitleSpace);
        // ����ָ���
        Cell cellBorder = new Cell(new Paragraph("", font10B));
        cellBorder.BorderWidth = 0;
        cellBorder.BorderWidthBottom = 1;
        cellBorder.HorizontalAlignment = 1;
        cellBorder.VerticalAlignment = 1;
        cellBorder.Colspan = intColumn;
        if (dsMainTable.Tables.Count > 0)
        {
            foreach (DataRow drTemp in dsMainTable.Tables[0].Rows)
            {
                // ����������
            
                // ����һ��һ��ر���
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // ���ɱ��
        BaseFont bfChinese = BaseFont.CreateFont("C:\\WINDOWS\\Fonts\\simsun.ttc,1", BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
        Font font20B = new Font(bfChinese, 20, iTextSharp.text.Font.BOLD);
        Font font20 = new Font(bfChinese, 20);
        Font font14B = new Font(bfChinese, 14, iTextSharp.text.Font.BOLD);
        Font font14 = new Font(bfChinese, 14);
        Font font13B = new Font(bfChinese, 13, iTextSharp.text.Font.BOLD);
        Font font13 = new Font(bfChinese, 13);
        Font font12B = new Font(bfChinese, 12, iTextSharp.text.Font.BOLD);
        Font font12 = new Font(bfChinese, 12);
        Font font11B = new Font(bfChinese, 11, iTextSharp.text.Font.BOLD);
        Font font11 = new Font(bfChinese, 11);
        Font font10B = new Font(bfChinese, 10, iTextSharp.text.Font.BOLD);
        Font font10 = new Font(bfChinese, 10);
        Font font9B = new Font(bfChinese, 9, iTextSharp.text.Font.BOLD);
        Font font9 = new Font(bfChinese, 9);
        Font font8B = new Font(bfChinese, 8, iTextSharp.text.Font.BOLD);
        Font font8 = new Font(bfChinese, 8);
        int intColumn = 0;
        
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        if (dsMainTable.Tables.Count > 0)
        {
            if (dsMainTable.Tables[0].Rows.Count > 0)
            {
                // �����ͷ��Ϣ
                Cell cellTitle = new Cell(new Paragraph(strRelatedInfoName, font11B));
                
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // ������ر��ֶ�����
                
                // ������ر�����
                if (dsRelatedTable.Tables.Count > 0)
                {
                    string strTempValue = string.Empty;
                    foreach (DataRow drTemp in dsRelatedTable.Tables[0].Rows)
                    {
                    
                    }
                }
            }
        }
        return itbOutput;
    }

    //=====================================================================
    //  FunctionName : rptRelatedTable_PreRender
    /// <summary>
    /// ��ر�������ദ��
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        Repeater rptTemp = (Repeater)sender;

    }

}

