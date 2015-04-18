/****************************************************** 
FileName:T_BM_DWXXWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_BM_DWXX;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_BM_DWXXWebUIDetail : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
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
        appData = new T_BM_DWXXApplicationData();
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
                strMessageParam[1] = "��λ��Ϣ";
                strMessageParam[2] = drTemp["DWMC"].ToString();
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
        appData = new T_BM_DWXXApplicationData();
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
            
            intColumn += 1 + 1;
            intColumn += 1 + 1;
            intColumn += 1 + 1;
            // �������
            int intLength = 0;
    
            intLength = 4;
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
            
                    // ��ʾ��λ��ű���
                    TableCell tcDWBHTitle = new TableCell();
                    tcDWBHTitle.Text = "��λ���";
                    tcDWBHTitle.ColumnSpan = 1;
                    tcDWBHTitle.RowSpan = 1;
                    tcDWBHTitle.CssClass = "fieldname";
                    tcDWBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDWBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcDWBHTitle);
                    
                    // ��ʾ��λ���ֵ
                    TableCell tcDWBHContent = new TableCell();
                      
                    tcDWBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DWBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DWBH")).InnerHtml = "";
                    tcDWBHContent.ColumnSpan = 1;
                    tcDWBHContent.RowSpan = 1;
                    tcDWBHContent.CssClass = "fieldinput";
                    tcDWBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcDWBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcDWBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcDWBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDWBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcDWBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcDWBHContent);
              
                    // ��ʾ��λ���Ʊ���
                    TableCell tcDWMCTitle = new TableCell();
                    tcDWMCTitle.Text = "��λ����";
                    tcDWMCTitle.ColumnSpan = 1;
                    tcDWMCTitle.RowSpan = 1;
                    tcDWMCTitle.CssClass = "fieldname";
                    tcDWMCTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDWMCTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcDWMCTitle);
                    
                    // ��ʾ��λ����ֵ
                    TableCell tcDWMCContent = new TableCell();
                      
                    tcDWMCContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DWMC")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DWMC")).InnerHtml = "";
                    tcDWMCContent.ColumnSpan = 1;
                    tcDWMCContent.RowSpan = 1;
                    tcDWMCContent.CssClass = "fieldinput";
                    tcDWMCContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcDWMCContent.Style.Add("border-top", "1px black solid");
                        
                    tcDWMCContent.Style.Add("border-left", "1px black solid");
                        
                    tcDWMCContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDWMCContent.Style.Add("border-right", "1px black solid");
                        
                    tcDWMCContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcDWMCContent);
              
                    // ��ʾ�ϼ���λ����
                    TableCell tcSJDWBHTitle = new TableCell();
                    tcSJDWBHTitle.Text = "�ϼ���λ";
                    tcSJDWBHTitle.ColumnSpan = 1;
                    tcSJDWBHTitle.RowSpan = 1;
                    tcSJDWBHTitle.CssClass = "fieldname";
                    tcSJDWBHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSJDWBHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcSJDWBHTitle);
                    
                    // ��ʾ�ϼ���λֵ
                    TableCell tcSJDWBHContent = new TableCell();
                      
                    tcSJDWBHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJDWBH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJDWBH")).InnerHtml = "";
                    tcSJDWBHContent.ColumnSpan = 1;
                    tcSJDWBHContent.RowSpan = 1;
                    tcSJDWBHContent.CssClass = "fieldinput";
                    tcSJDWBHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcSJDWBHContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJDWBHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcSJDWBHContent);
              
                    // ��ʾ��ַ����
                    TableCell tcDZTitle = new TableCell();
                    tcDZTitle.Text = "��ַ";
                    tcDZTitle.ColumnSpan = 1;
                    tcDZTitle.RowSpan = 1;
                    tcDZTitle.CssClass = "fieldname";
                    tcDZTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDZTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcDZTitle);
                    
                    // ��ʾ��ֵַ
                    TableCell tcDZContent = new TableCell();
                      
                    tcDZContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DZ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DZ")).InnerHtml = "";
                    tcDZContent.ColumnSpan = 3;
                    tcDZContent.RowSpan = 1;
                    tcDZContent.CssClass = "fieldinput";
                    tcDZContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcDZContent.Style.Add("border-top", "1px black solid");
                        
                    tcDZContent.Style.Add("border-left", "1px black solid");
                        
                    tcDZContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDZContent.Style.Add("border-right", "1px black solid");
                        
                    tcDZContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcDZContent);
              
                    // ��ʾ�ʱ����
                    TableCell tcYBTitle = new TableCell();
                    tcYBTitle.Text = "�ʱ�";
                    tcYBTitle.ColumnSpan = 1;
                    tcYBTitle.RowSpan = 1;
                    tcYBTitle.CssClass = "fieldname";
                    tcYBTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcYBTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcYBTitle);
                    
                    // ��ʾ�ʱ�ֵ
                    TableCell tcYBContent = new TableCell();
                      
                    tcYBContent.Text = ((HtmlContainerControl)hcTemp.FindControl("YB")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("YB")).InnerHtml = "";
                    tcYBContent.ColumnSpan = 1;
                    tcYBContent.RowSpan = 1;
                    tcYBContent.CssClass = "fieldinput";
                    tcYBContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcYBContent.Style.Add("border-top", "1px black solid");
                        
                    tcYBContent.Style.Add("border-left", "1px black solid");
                        
                    tcYBContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcYBContent.Style.Add("border-right", "1px black solid");
                        
                    tcYBContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcYBContent);
              
                    // ��ʾ��ϵ���ű���
                    TableCell tcLXBMTitle = new TableCell();
                    tcLXBMTitle.Text = "��ϵ����";
                    tcLXBMTitle.ColumnSpan = 1;
                    tcLXBMTitle.RowSpan = 1;
                    tcLXBMTitle.CssClass = "fieldname";
                    tcLXBMTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXBMTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcLXBMTitle);
                    
                    // ��ʾ��ϵ����ֵ
                    TableCell tcLXBMContent = new TableCell();
                      
                    tcLXBMContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LXBM")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LXBM")).InnerHtml = "";
                    tcLXBMContent.ColumnSpan = 1;
                    tcLXBMContent.RowSpan = 1;
                    tcLXBMContent.CssClass = "fieldinput";
                    tcLXBMContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLXBMContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXBMContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXBMContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXBMContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXBMContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcLXBMContent);
              
                    // ��ʾ��ϵ�绰����
                    TableCell tcLXDHTitle = new TableCell();
                    tcLXDHTitle.Text = "��ϵ�绰";
                    tcLXDHTitle.ColumnSpan = 1;
                    tcLXDHTitle.RowSpan = 1;
                    tcLXDHTitle.CssClass = "fieldname";
                    tcLXDHTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXDHTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcLXDHTitle);
                    
                    // ��ʾ��ϵ�绰ֵ
                    TableCell tcLXDHContent = new TableCell();
                      
                    tcLXDHContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LXDH")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LXDH")).InnerHtml = "";
                    tcLXDHContent.ColumnSpan = 1;
                    tcLXDHContent.RowSpan = 1;
                    tcLXDHContent.CssClass = "fieldinput";
                    tcLXDHContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcLXDHContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXDHContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXDHContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXDHContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXDHContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcLXDHContent);
              
                    // ��ʾEmail����
                    TableCell tcEmailTitle = new TableCell();
                    tcEmailTitle.Text = "Email";
                    tcEmailTitle.ColumnSpan = 1;
                    tcEmailTitle.RowSpan = 1;
                    tcEmailTitle.CssClass = "fieldname";
                    tcEmailTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcEmailTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcEmailTitle);
                    
                    // ��ʾEmailֵ
                    TableCell tcEmailContent = new TableCell();
                      
                    tcEmailContent.Text = ((HtmlContainerControl)hcTemp.FindControl("Email")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("Email")).InnerHtml = "";
                    tcEmailContent.ColumnSpan = 1;
                    tcEmailContent.RowSpan = 1;
                    tcEmailContent.CssClass = "fieldinput";
                    tcEmailContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcEmailContent.Style.Add("border-top", "1px black solid");
                        
                    tcEmailContent.Style.Add("border-left", "1px black solid");
                        
                    tcEmailContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcEmailContent.Style.Add("border-right", "1px black solid");
                        
                    tcEmailContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcEmailContent);
              
                    // ��ʾ��ϵ�˱���
                    TableCell tcLXRTitle = new TableCell();
                    tcLXRTitle.Text = "��ϵ��";
                    tcLXRTitle.ColumnSpan = 1;
                    tcLXRTitle.RowSpan = 1;
                    tcLXRTitle.CssClass = "fieldname";
                    tcLXRTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcLXRTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcLXRTitle);
                    
                    // ��ʾ��ϵ��ֵ
                    TableCell tcLXRContent = new TableCell();
                      
                    tcLXRContent.Text = ((HtmlContainerControl)hcTemp.FindControl("LXR")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("LXR")).InnerHtml = "";
                    tcLXRContent.ColumnSpan = 2;
                    tcLXRContent.RowSpan = 1;
                    tcLXRContent.CssClass = "fieldinput";
                    tcLXRContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 2 / intColumn));
                        
                    tcLXRContent.Style.Add("border-top", "1px black solid");
                        
                    tcLXRContent.Style.Add("border-left", "1px black solid");
                        
                    tcLXRContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcLXRContent.Style.Add("border-right", "1px black solid");
                        
                    tcLXRContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcLXRContent);
              
                    // ��ʾ�ֻ�����
                    TableCell tcSJTitle = new TableCell();
                    tcSJTitle.Text = "�ֻ�";
                    tcSJTitle.ColumnSpan = 1;
                    tcSJTitle.RowSpan = 1;
                    tcSJTitle.CssClass = "fieldname";
                    tcSJTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcSJTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcSJTitle);
                    
                    // ��ʾ�ֻ�ֵ
                    TableCell tcSJContent = new TableCell();
                      
                    tcSJContent.Text = ((HtmlContainerControl)hcTemp.FindControl("SJ")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("SJ")).InnerHtml = "";
                    tcSJContent.ColumnSpan = 2;
                    tcSJContent.RowSpan = 1;
                    tcSJContent.CssClass = "fieldinput";
                    tcSJContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 2 / intColumn));
                        
                    tcSJContent.Style.Add("border-top", "1px black solid");
                        
                    tcSJContent.Style.Add("border-left", "1px black solid");
                        
                    tcSJContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcSJContent.Style.Add("border-right", "1px black solid");
                        
                    tcSJContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcSJContent);
              
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
        
        intColumn += 1 + 1;
        intColumn += 1 + 1;
        intColumn += 1 + 1;
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // �����ͷ��Ϣ
        Cell cellTitle = new Cell(new Paragraph("��λ��Ϣ", font19B));
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

