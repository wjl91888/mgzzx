/****************************************************** 
FileName:T_PM_UserGroupInfoWebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.T_PM_UserGroupInfo;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class T_PM_UserGroupInfoWebUIDetail : RICH.Common.BM.T_PM_UserGroupInfo.T_PM_UserGroupInfoWebUI
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
    /// 重载初始化函数
    /// </summary>
    //=====================================================================
   protected override void Initalize()
    {
        // 界面初始化
        // 初始化打印页面大小
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A4", "A4"));
        ddlPrintPageSize.Items.Add(new System.Web.UI.WebControls.ListItem("A3", "A3"));
        // 初始化打印页面方向大小
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("竖向", "portrait"));
        ddlPrintPageOrientation.Items.Add(new System.Web.UI.WebControls.ListItem("横向", "landscape"));

        // 读取记录详细资料
        appData = new T_PM_UserGroupInfoApplicationData();
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
                //记录日志开始
                string strLogTypeID = "A10";
                strMessageParam[0] = (string)Session[ConstantsManager.SESSION_USER_LOGIN_NAME];
                strMessageParam[1] = "用户组信息";
                strMessageParam[2] = drTemp["UserGroupName"].ToString();
                string strLogContent = MessageManager.GetMessageInfo(MessageManager.LOG_MSGID_0012, strMessageParam);
                RICH.Common.LM.LogLibrary.LogWrite(strLogTypeID, strLogContent, null, drTemp["ObjectID"].ToString(), null);
                //记录日志结束
            }
        }
    }

    //=====================================================================
    //  FunctionName : ExportToFile
    /// <summary>
    /// 重载ExportToFile
    /// </summary>
    //=====================================================================
    protected override void ExportToFile()
    {
        appData = new T_PM_UserGroupInfoApplicationData();
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
            // 生成详情表并设置属性
            System.Web.UI.WebControls.Table tDetailView = new System.Web.UI.WebControls.Table();
            tDetailView.CssClass = "detailtable";
            tDetailView.CellPadding = 0;
            tDetailView.CellSpacing = 0;
            tDetailView.BorderColor = System.Drawing.Color.Black;
            tDetailView.BorderWidth = 0;
            tDetailView.Width = 615;
            // 获得列数
            int intColumn = 0;
            
            intColumn += 1 + 1;
            intColumn += 1 + 1;
            // 获得行数
            int intLength = 0;
    
            intLength = 5;
            intLength++;
            // 生成行
            for (int i = 0; i < intLength; i++)
            {
                TableRow trTemp = new TableRow();
                tDetailView.Rows.Add(trTemp);
            }
            // 得到值区域控件
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                hcTemp = tcTemp.FindControl("divvaluearea");
                if (hcTemp != null)
                {
                    // 生成表格
                    // 生成主表表格
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
            
                    // 显示用户组编号标题
                    TableCell tcUserGroupIDTitle = new TableCell();
                    tcUserGroupIDTitle.Text = "用户组编号";
                    tcUserGroupIDTitle.ColumnSpan = 1;
                    tcUserGroupIDTitle.RowSpan = 1;
                    tcUserGroupIDTitle.CssClass = "fieldname";
                    tcUserGroupIDTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserGroupIDTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcUserGroupIDTitle);
                    
                    // 显示用户组编号值
                    TableCell tcUserGroupIDContent = new TableCell();
                      
                    tcUserGroupIDContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserGroupID")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserGroupID")).InnerHtml = "";
                    tcUserGroupIDContent.ColumnSpan = 1;
                    tcUserGroupIDContent.RowSpan = 1;
                    tcUserGroupIDContent.CssClass = "fieldinput";
                    tcUserGroupIDContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcUserGroupIDContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserGroupIDContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcUserGroupIDContent);
              
                    // 显示用户组名称标题
                    TableCell tcUserGroupNameTitle = new TableCell();
                    tcUserGroupNameTitle.Text = "用户组名称";
                    tcUserGroupNameTitle.ColumnSpan = 1;
                    tcUserGroupNameTitle.RowSpan = 1;
                    tcUserGroupNameTitle.CssClass = "fieldname";
                    tcUserGroupNameTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserGroupNameTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[1].Cells.Add(tcUserGroupNameTitle);
                    
                    // 显示用户组名称值
                    TableCell tcUserGroupNameContent = new TableCell();
                      
                    tcUserGroupNameContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserGroupName")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserGroupName")).InnerHtml = "";
                    tcUserGroupNameContent.ColumnSpan = 1;
                    tcUserGroupNameContent.RowSpan = 1;
                    tcUserGroupNameContent.CssClass = "fieldinput";
                    tcUserGroupNameContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                        
                    tcUserGroupNameContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserGroupNameContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserGroupNameContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserGroupNameContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserGroupNameContent.Style.Add("text-align", "center");
                    tDetailView.Rows[1].Cells.Add(tcUserGroupNameContent);
              
                    // 显示内容标题
                    TableCell tcUserGroupContentTitle = new TableCell();
                    tcUserGroupContentTitle.Text = "内容";
                    tcUserGroupContentTitle.ColumnSpan = 1;
                    tcUserGroupContentTitle.RowSpan = 1;
                    tcUserGroupContentTitle.CssClass = "fieldname";
                    tcUserGroupContentTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserGroupContentTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[2].Cells.Add(tcUserGroupContentTitle);
                    
                    // 显示内容值
                    TableCell tcUserGroupContentContent = new TableCell();
                      
                    tcUserGroupContentContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserGroupContent")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserGroupContent")).InnerHtml = "";
                    tcUserGroupContentContent.ColumnSpan = 3;
                    tcUserGroupContentContent.RowSpan = 1;
                    tcUserGroupContentContent.CssClass = "fieldinput";
                    tcUserGroupContentContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcUserGroupContentContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserGroupContentContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserGroupContentContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserGroupContentContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserGroupContentContent.Style.Add("text-align", "center");
                    tDetailView.Rows[2].Cells.Add(tcUserGroupContentContent);
              
                    // 显示备注标题
                    TableCell tcUserGroupRemarkTitle = new TableCell();
                    tcUserGroupRemarkTitle.Text = "备注";
                    tcUserGroupRemarkTitle.ColumnSpan = 1;
                    tcUserGroupRemarkTitle.RowSpan = 1;
                    tcUserGroupRemarkTitle.CssClass = "fieldname";
                    tcUserGroupRemarkTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUserGroupRemarkTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[3].Cells.Add(tcUserGroupRemarkTitle);
                    
                    // 显示备注值
                    TableCell tcUserGroupRemarkContent = new TableCell();
                      
                    tcUserGroupRemarkContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UserGroupRemark")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UserGroupRemark")).InnerHtml = "";
                    tcUserGroupRemarkContent.ColumnSpan = 3;
                    tcUserGroupRemarkContent.RowSpan = 1;
                    tcUserGroupRemarkContent.CssClass = "fieldinput";
                    tcUserGroupRemarkContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcUserGroupRemarkContent.Style.Add("border-top", "1px black solid");
                        
                    tcUserGroupRemarkContent.Style.Add("border-left", "1px black solid");
                        
                    tcUserGroupRemarkContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUserGroupRemarkContent.Style.Add("border-right", "1px black solid");
                        
                    tcUserGroupRemarkContent.Style.Add("text-align", "center");
                    tDetailView.Rows[3].Cells.Add(tcUserGroupRemarkContent);
              
                    // 显示系统默认页标题
                    TableCell tcDefaultPageTitle = new TableCell();
                    tcDefaultPageTitle.Text = "系统默认页";
                    tcDefaultPageTitle.ColumnSpan = 1;
                    tcDefaultPageTitle.RowSpan = 1;
                    tcDefaultPageTitle.CssClass = "fieldname";
                    tcDefaultPageTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcDefaultPageTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[4].Cells.Add(tcDefaultPageTitle);
                    
                    // 显示系统默认页值
                    TableCell tcDefaultPageContent = new TableCell();
                      
                    tcDefaultPageContent.Text = ((HtmlContainerControl)hcTemp.FindControl("DefaultPage")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("DefaultPage")).InnerHtml = "";
                    tcDefaultPageContent.ColumnSpan = 3;
                    tcDefaultPageContent.RowSpan = 1;
                    tcDefaultPageContent.CssClass = "fieldinput";
                    tcDefaultPageContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcDefaultPageContent.Style.Add("border-top", "1px black solid");
                        
                    tcDefaultPageContent.Style.Add("border-left", "1px black solid");
                        
                    tcDefaultPageContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcDefaultPageContent.Style.Add("border-right", "1px black solid");
                        
                    tcDefaultPageContent.Style.Add("text-align", "center");
                    tDetailView.Rows[4].Cells.Add(tcDefaultPageContent);
              
                    // 显示更新时间标题
                    TableCell tcUpdateDateTitle = new TableCell();
                    tcUpdateDateTitle.Text = "更新时间";
                    tcUpdateDateTitle.ColumnSpan = 1;
                    tcUpdateDateTitle.RowSpan = 1;
                    tcUpdateDateTitle.CssClass = "fieldname";
                    tcUpdateDateTitle.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 1 / intColumn));
                    tcUpdateDateTitle.Style.Add("border", "1px black solid");
                    tDetailView.Rows[5].Cells.Add(tcUpdateDateTitle);
                    
                    // 显示更新时间值
                    TableCell tcUpdateDateContent = new TableCell();
                      
                    tcUpdateDateContent.Text = ((HtmlContainerControl)hcTemp.FindControl("UpdateDate")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("UpdateDate")).InnerHtml = "";
                    tcUpdateDateContent.ColumnSpan = 3;
                    tcUpdateDateContent.RowSpan = 1;
                    tcUpdateDateContent.CssClass = "fieldinput";
                    tcUpdateDateContent.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * 3 / intColumn));
                        
                    tcUpdateDateContent.Style.Add("border-top", "1px black solid");
                        
                    tcUpdateDateContent.Style.Add("border-left", "1px black solid");
                        
                    tcUpdateDateContent.Style.Add("border-bottom", "1px black solid");
                        
                    tcUpdateDateContent.Style.Add("border-right", "1px black solid");
                        
                    tcUpdateDateContent.Style.Add("text-align", "center");
                    tDetailView.Rows[5].Cells.Add(tcUpdateDateContent);
              
                    // 生成一对一相关表表格
            
                    break;
                }
            }
            foreach (TableCell tcTemp in e.Row.Cells)
            {
                // 设置主表信息
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
        // 创建空白PDF文档
        Document pdfDoc = new Document(rect, marginLeft, marginRight, marginTop, marginBottom);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        // 添加主表及一对一相关表信息
        pdfDoc.Add(GenerateMainTable(dsMainTable));
        // 添加一对多相关表信息
    
        pdfDoc.Close();
        return pdfDoc;
    }
    private iTextSharp.text.Table GenerateMainTable(DataSet dsMainTable)
    {
        // 生成表格
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
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("用户组信息", font19B));
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
        // 定义分割线
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
                // 生成主表表格
            
                // 显示用户组编号标题
                
                iTextSharp.text.Cell cellUserGroupIDTitle = new Cell(new Paragraph("用户组编号", font11B));
                cellUserGroupIDTitle.BorderWidth = 0.5F;
                cellUserGroupIDTitle.HorizontalAlignment = 1;
                    
                cellUserGroupIDTitle.Rowspan = 1;
                cellUserGroupIDTitle.Colspan = 1;
                cellUserGroupIDTitle.Width = 100 / intColumn;
                cellUserGroupIDTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellUserGroupIDTitle);
                
                // 显示用户组编号值
                
                iTextSharp.text.Cell cellUserGroupIDContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["UserGroupID"], null)), font10));
                        
                cellUserGroupIDContent.Rowspan = 1;
                cellUserGroupIDContent.Colspan = 1;
                cellUserGroupIDContent.Width = 100 / intColumn;
                cellUserGroupIDContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellUserGroupIDContent.HorizontalAlignment = 1;
                cellUserGroupIDContent.BorderWidthTop = 0.5F;
                        
                cellUserGroupIDContent.BorderWidthLeft = 0.5F;
                        
                cellUserGroupIDContent.BorderWidthBottom = 0.5F;
                        
                cellUserGroupIDContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellUserGroupIDContent);
                
                // 显示用户组名称标题
                
                iTextSharp.text.Cell cellUserGroupNameTitle = new Cell(new Paragraph("用户组名称", font11B));
                cellUserGroupNameTitle.BorderWidth = 0.5F;
                cellUserGroupNameTitle.HorizontalAlignment = 1;
                    
                cellUserGroupNameTitle.Rowspan = 1;
                cellUserGroupNameTitle.Colspan = 1;
                cellUserGroupNameTitle.Width = 100 / intColumn;
                cellUserGroupNameTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellUserGroupNameTitle);
                
                // 显示用户组名称值
                
                iTextSharp.text.Cell cellUserGroupNameContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["UserGroupName"], null)), font10));
                        
                cellUserGroupNameContent.Rowspan = 1;
                cellUserGroupNameContent.Colspan = 1;
                cellUserGroupNameContent.Width = 100 / intColumn;
                cellUserGroupNameContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellUserGroupNameContent.HorizontalAlignment = 1;
                cellUserGroupNameContent.BorderWidthTop = 0.5F;
                        
                cellUserGroupNameContent.BorderWidthLeft = 0.5F;
                        
                cellUserGroupNameContent.BorderWidthBottom = 0.5F;
                        
                cellUserGroupNameContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellUserGroupNameContent);
                
                // 显示内容标题
                
                iTextSharp.text.Cell cellUserGroupContentTitle = new Cell(new Paragraph("内容", font11B));
                cellUserGroupContentTitle.BorderWidth = 0.5F;
                cellUserGroupContentTitle.HorizontalAlignment = 1;
                    
                cellUserGroupContentTitle.Rowspan = 1;
                cellUserGroupContentTitle.Colspan = 1;
                cellUserGroupContentTitle.Width = 100 / intColumn;
                cellUserGroupContentTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellUserGroupContentTitle);
                
                // 显示内容值
                
                iTextSharp.text.Cell cellUserGroupContentContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["UserGroupContent"], null)), font10));
                        
                cellUserGroupContentContent.Rowspan = 1;
                cellUserGroupContentContent.Colspan = 3;
                cellUserGroupContentContent.Width = 100 / intColumn;
                cellUserGroupContentContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellUserGroupContentContent.HorizontalAlignment = 1;
                cellUserGroupContentContent.BorderWidthTop = 0.5F;
                        
                cellUserGroupContentContent.BorderWidthLeft = 0.5F;
                        
                cellUserGroupContentContent.BorderWidthBottom = 0.5F;
                        
                cellUserGroupContentContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellUserGroupContentContent);
                
                // 显示备注标题
                
                iTextSharp.text.Cell cellUserGroupRemarkTitle = new Cell(new Paragraph("备注", font11B));
                cellUserGroupRemarkTitle.BorderWidth = 0.5F;
                cellUserGroupRemarkTitle.HorizontalAlignment = 1;
                    
                cellUserGroupRemarkTitle.Rowspan = 1;
                cellUserGroupRemarkTitle.Colspan = 1;
                cellUserGroupRemarkTitle.Width = 100 / intColumn;
                cellUserGroupRemarkTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellUserGroupRemarkTitle);
                
                // 显示备注值
                
                iTextSharp.text.Cell cellUserGroupRemarkContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["UserGroupRemark"], null)), font10));
                        
                cellUserGroupRemarkContent.Rowspan = 1;
                cellUserGroupRemarkContent.Colspan = 3;
                cellUserGroupRemarkContent.Width = 100 / intColumn;
                cellUserGroupRemarkContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellUserGroupRemarkContent.HorizontalAlignment = 1;
                cellUserGroupRemarkContent.BorderWidthTop = 0.5F;
                        
                cellUserGroupRemarkContent.BorderWidthLeft = 0.5F;
                        
                cellUserGroupRemarkContent.BorderWidthBottom = 0.5F;
                        
                cellUserGroupRemarkContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellUserGroupRemarkContent);
                
                // 显示系统默认页标题
                
                iTextSharp.text.Cell cellDefaultPageTitle = new Cell(new Paragraph("系统默认页", font11B));
                cellDefaultPageTitle.BorderWidth = 0.5F;
                cellDefaultPageTitle.HorizontalAlignment = 1;
                    
                cellDefaultPageTitle.Rowspan = 1;
                cellDefaultPageTitle.Colspan = 1;
                cellDefaultPageTitle.Width = 100 / intColumn;
                cellDefaultPageTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellDefaultPageTitle);
                
                // 显示系统默认页值
                
                iTextSharp.text.Cell cellDefaultPageContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["DefaultPage"], null)), font10));
                        
                cellDefaultPageContent.Rowspan = 1;
                cellDefaultPageContent.Colspan = 3;
                cellDefaultPageContent.Width = 100 / intColumn;
                cellDefaultPageContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellDefaultPageContent.HorizontalAlignment = 1;
                cellDefaultPageContent.BorderWidthTop = 0.5F;
                        
                cellDefaultPageContent.BorderWidthLeft = 0.5F;
                        
                cellDefaultPageContent.BorderWidthBottom = 0.5F;
                        
                cellDefaultPageContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellDefaultPageContent);
                
                // 显示更新时间标题
                
                iTextSharp.text.Cell cellUpdateDateTitle = new Cell(new Paragraph("更新时间", font11B));
                cellUpdateDateTitle.BorderWidth = 0.5F;
                cellUpdateDateTitle.HorizontalAlignment = 1;
                    
                cellUpdateDateTitle.Rowspan = 1;
                cellUpdateDateTitle.Colspan = 1;
                cellUpdateDateTitle.Width = 100 / intColumn;
                cellUpdateDateTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cellUpdateDateTitle);
                
                // 显示更新时间值
                
                iTextSharp.text.Cell cellUpdateDateContent = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["UpdateDate"], null)), font10));
                        
                cellUpdateDateContent.Rowspan = 1;
                cellUpdateDateContent.Colspan = 3;
                cellUpdateDateContent.Width = 100 / intColumn;
                cellUpdateDateContent.VerticalAlignment = Cell.ALIGN_MIDDLE;
                
                cellUpdateDateContent.HorizontalAlignment = 1;
                cellUpdateDateContent.BorderWidthTop = 0.5F;
                        
                cellUpdateDateContent.BorderWidthLeft = 0.5F;
                        
                cellUpdateDateContent.BorderWidthBottom = 0.5F;
                        
                cellUpdateDateContent.BorderWidthRight = 0.5F;
                        
                itbOutput.AddCell(cellUpdateDateContent);
                
                // 生成一对一相关表表格
            
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            
            }
        }
        return itbOutput;
    }    

    private iTextSharp.text.Table GenerateRelatedTable(DataSet dsMainTable, string strRelatedTableName, string strRelatedInfoName)
    {
        DataSet dsRelatedTable = new DataSet();
        // 生成表格
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
                // 加入表头信息
                Cell cellTitle = new Cell(new Paragraph(strRelatedInfoName, font11B));
                
                cellTitle.BorderWidth = 0.5F;
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // 加入相关表字段名称
                
                // 加入相关表数据
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
    /// 相关表排序分类处理
    /// </summary>
    //=====================================================================
    protected void rptRelatedTable_PreRender(object sender, EventArgs e)
    {
        Repeater rptTemp = (Repeater)sender;

    }

}

