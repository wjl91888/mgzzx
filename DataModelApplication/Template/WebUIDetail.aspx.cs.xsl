<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIDetail.aspx.cs.xsl'"/>
<xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Text;

public partial class <xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail : RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>WebUI
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
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
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
                strMessageParam[1] = "<xsl:value-of select="/NewDataSet/TableRemark"/>";
                strMessageParam[2] = drTemp["<xsl:value-of select="/NewDataSet/TitleField"/>"].ToString();
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
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
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
            <xsl:for-each select="/NewDataSet/RecordInfo">
              <xsl:if test="IsShowDetail = 'true'">
                  <xsl:if test="ContentRow = '1'">
            intColumn += <xsl:value-of select="TitleColumnSpan"/> + <xsl:value-of select="ContentColumnSpan"/>;</xsl:if></xsl:if>
            </xsl:for-each>
            // 获得行数
            int intLength = 0;
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:sort data-type="number" order="descending" select="ContentRow"/>
          <xsl:if test="position() = '1'">
            intLength = <xsl:value-of select="ContentRow"/>;</xsl:if>
    </xsl:for-each>
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
      <xsl:sort data-type="number" order="descending" select="ContentRow"/>
      <xsl:if test="RelatedTableType = '1_to_1'">
          <xsl:if test="IsDisplay = 'true'">
            <xsl:if test="position() = '1'">
            if (<xsl:value-of select="ContentRow"/> > intLength)
            {
                intLength = <xsl:value-of select="ContentRow"/>;
            }</xsl:if></xsl:if></xsl:if>
    </xsl:for-each>
            intLength++;
            // 生成行
            for (int i = 0; i <![CDATA[<]]> intLength; i++)
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
            <xsl:for-each select="/NewDataSet/RecordInfo">
              <xsl:sort data-type="number" order="ascending" select="ContentRow"/>
              <xsl:sort data-type="number" order="ascending" select="ContentColumn"/>
              <xsl:if test="IsShowDetail = 'true'">
                    <xsl:if test="IsHideTitle = 'false'">
                    // 显示<xsl:value-of select="FieldRemark"/>标题
                    TableCell tc<xsl:value-of select="FieldName"/>Title = new TableCell();
                    tc<xsl:value-of select="FieldName"/>Title.Text = "<xsl:value-of select="FieldRemark"/>";
                    tc<xsl:value-of select="FieldName"/>Title.ColumnSpan = <xsl:value-of select="TitleColumnSpan"/>;
                    tc<xsl:value-of select="FieldName"/>Title.RowSpan = <xsl:value-of select="TitleRowSpan"/>;
                    tc<xsl:value-of select="FieldName"/>Title.CssClass = "fieldname";
                    tc<xsl:value-of select="FieldName"/>Title.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * <xsl:value-of select="TitleColumnSpan"/> / intColumn));
                    tc<xsl:value-of select="FieldName"/>Title.Style.Add("border", "1px black solid");
                    tDetailView.Rows[<xsl:value-of select="TitleRow"/>].Cells.Add(tc<xsl:value-of select="FieldName"/>Title);
                    </xsl:if>
                    // 显示<xsl:value-of select="FieldRemark"/>值
                    TableCell tc<xsl:value-of select="FieldName"/>Content = new TableCell();
                      <xsl:choose>
                        <xsl:when test="ControlType = 'GridDataBind'">
                    tc<xsl:value-of select="FieldName"/>Content.Controls.Add(
                            GenerateHtmlTable(
                            "<xsl:value-of select="GridHeadText"/>",
                            ((HtmlContainerControl)hcTemp.FindControl("<xsl:value-of select="FieldName"/>")).InnerText,
                            true,
                            true,
                            null, "fieldname", "fieldinput",
                            null,
                            "<xsl:value-of select="GridColumnWidth"/>"
                            )
                        );
                    ((HtmlContainerControl)hcTemp.FindControl("<xsl:value-of select="FieldName"/>")).InnerHtml = "";
                    tc<xsl:value-of select="FieldName"/>Content.ColumnSpan = <xsl:value-of select="ContentColumnSpan"/>;
                    tc<xsl:value-of select="FieldName"/>Content.RowSpan = <xsl:value-of select="ContentRowSpan"/>;
                    tc<xsl:value-of select="FieldName"/>Content.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * <xsl:value-of select="ContentColumnSpan"/> / intColumn));
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border", "1px black solid");
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("padding", "0px !important");
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("text-align", "left");
                        </xsl:when>
                        <xsl:otherwise>
                    tc<xsl:value-of select="FieldName"/>Content.Text = ((HtmlContainerControl)hcTemp.FindControl("<xsl:value-of select="FieldName"/>")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("<xsl:value-of select="FieldName"/>")).InnerHtml = "";
                    tc<xsl:value-of select="FieldName"/>Content.ColumnSpan = <xsl:value-of select="ContentColumnSpan"/>;
                    tc<xsl:value-of select="FieldName"/>Content.RowSpan = <xsl:value-of select="ContentRowSpan"/>;
                    tc<xsl:value-of select="FieldName"/>Content.CssClass = "fieldinput";
                    tc<xsl:value-of select="FieldName"/>Content.Width = Unit.Pixel(FunctionManager.RoundInt(tDetailView.Width.Value * <xsl:value-of select="ContentColumnSpan"/> / intColumn));
                        <xsl:if test="IsNoBorderTop = 'false'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-top", "1px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderTop = 'true'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-top", "0px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderLeft = 'false'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-left", "1px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderLeft = 'true'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-left", "0px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderBottom = 'false'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-bottom", "1px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderBottom = 'true'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-bottom", "0px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderRight = 'false'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-right", "1px black solid");
                        </xsl:if>
                        <xsl:if test="IsNoBorderRight = 'true'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("border-right", "0px black solid");
                        </xsl:if>

                    <xsl:choose>
                        <xsl:when test="TextAlign = 'Left'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("text-align", "left");</xsl:when>
                        <xsl:when test="TextAlign = 'Right'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("text-align", "right");</xsl:when>
                        <xsl:when test="TextAlign = 'Center'">
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("text-align", "center");</xsl:when>
                        <xsl:otherwise>
                    tc<xsl:value-of select="FieldName"/>Content.Style.Add("text-align", "center");</xsl:otherwise>
                    </xsl:choose>
                        </xsl:otherwise>
                      </xsl:choose>
                    tDetailView.Rows[<xsl:value-of select="ContentRow"/>].Cells.Add(tc<xsl:value-of select="FieldName"/>Content);
              </xsl:if>
            </xsl:for-each>
                    // 生成一对一相关表表格
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
              <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
              <xsl:if test="RelatedTableType = '1_to_1'">
                  <xsl:if test="IsDisplay = 'true'">
                    // 显示<xsl:value-of select="DisplayName"/>标题及值
                    TableCell tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title = new TableCell();
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Text = "<xsl:value-of select="DisplayName"/>";
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.ColumnSpan = <xsl:value-of select="TitleColumnSpan"/>;
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.RowSpan = <xsl:value-of select="TitleRowSpan"/>;
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.CssClass = "fieldname";
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Style.Add("border", "1px black solid");
                    tDetailView.Rows[<xsl:value-of select="TitleRow"/>].Cells.Add(tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title);
                    TableCell tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content = new TableCell();
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Text = ((HtmlContainerControl)hcTemp.FindControl("<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>")).InnerHtml;
                    ((HtmlContainerControl)hcTemp.FindControl("<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>")).InnerHtml = "";
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.ColumnSpan = <xsl:value-of select="ContentColumnSpan"/>;
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.RowSpan = <xsl:value-of select="ContentRowSpan"/>;
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.CssClass = "fieldinput";
                    <xsl:choose>
                        <xsl:when test="TextAlign = 'Left'">
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Style.Add("text-align", "left");</xsl:when>
                        <xsl:when test="TextAlign = 'Right'">
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Style.Add("text-align", "right");</xsl:when>
                        <xsl:when test="TextAlign = 'Center'">
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Style.Add("text-align", "center");</xsl:when>
                        <xsl:otherwise>
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Style.Add("text-align", "center");</xsl:otherwise>
                    </xsl:choose>
                    tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Style.Add("border", "1px black solid");
                    tDetailView.Rows[<xsl:value-of select="ContentRow"/>].Cells.Add(tc<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content);
                  </xsl:if>
              </xsl:if>
            </xsl:for-each>
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
    <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_n'">
                // 显示<xsl:value-of select="RelatedInfoName"/>数据
                hcTemp = tcTemp.FindControl("relatedtable_<xsl:value-of select="SerialNumber"/>");
                if (hcTemp != null)
                {
                    ((HtmlControl)hcTemp).Style["display"] = "block";
                }
      </xsl:if>
    </xsl:for-each>
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
    <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_n'">
        // <xsl:value-of select="RelatedInfoName"/>一对多相关表
        pdfDoc.Add(GenerateRelatedTable(dsMainTable, "<xsl:value-of select="RelatedTableName"/>", "<xsl:value-of select="RelatedInfoName"/>"));
      </xsl:if>
    </xsl:for-each>
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
        <xsl:for-each select="/NewDataSet/RecordInfo">
          <xsl:if test="IsShowDetail = 'true'">
              <xsl:if test="ContentRow = '1'">
        intColumn += <xsl:value-of select="TitleColumnSpan"/> + <xsl:value-of select="ContentColumnSpan"/>;</xsl:if></xsl:if>
        </xsl:for-each>
        iTextSharp.text.Table itbOutput = new iTextSharp.text.Table(intColumn);
        itbOutput.BorderWidth = 0;
        itbOutput.Cellpadding = 2;
        itbOutput.Cellspacing = 0;
        itbOutput.Width = 100;
        <xsl:if test="/NewDataSet/ExistPDFTableTitle = 'true'">
        // 加入自定义表头
        Cell cellCustomTableTitle = new Cell(new Paragraph("<xsl:value-of select="/NewDataSet/PDFTableTitle"/>", font22B));
        cellCustomTableTitle.BorderWidth = 0;
        cellCustomTableTitle.HorizontalAlignment = 1;
        cellCustomTableTitle.VerticalAlignment = 1;
        cellCustomTableTitle.Colspan = intColumn;
        itbOutput.AddCell(cellCustomTableTitle);
        </xsl:if>
        <xsl:if test="/NewDataSet/IsPDFCustomTitle = 'true'">
        // 加入自定义表标题
        if (dsMainTable.Tables.Count > 0)
        {
            if (dsMainTable.Tables[0].Rows.Count > 0)
            {
                Cell cellCustomTitle = new Cell(new Paragraph(GetValue(dsMainTable.Tables[0].Rows[0]["<xsl:value-of select="/NewDataSet/PDFCustomTitleReadField"/>"]) + "<xsl:value-of select="/NewDataSet/PDFCustomTitle"/>", font19B));
                cellCustomTitle.BorderWidth = 0;
                cellCustomTitle.HorizontalAlignment = 1;
                cellCustomTitle.VerticalAlignment = 1;
                cellCustomTitle.Colspan = intColumn;
                itbOutput.AddCell(cellCustomTitle);
            }
        }
        </xsl:if>
        <xsl:if test="/NewDataSet/ExistPDFTableTitle = 'false'">
          <xsl:if test="/NewDataSet/IsPDFCustomTitle = 'false'">
        // 加入表头信息
        Cell cellTitle = new Cell(new Paragraph("<xsl:value-of select="/NewDataSet/TableRemark"/>", font19B));
        cellTitle.BorderWidth = 0;
        cellTitle.HorizontalAlignment = 1;
        cellTitle.VerticalAlignment = 1;
        cellTitle.Colspan = intColumn;
        itbOutput.AddCell(cellTitle);
          </xsl:if>
        </xsl:if>
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
            <xsl:for-each select="/NewDataSet/RecordInfo">
              <xsl:sort data-type="number" order="ascending" select="ContentRow"/>
              <xsl:sort data-type="number" order="ascending" select="ContentColumn"/>
              <xsl:if test="IsPDFShow = 'true'">
                <xsl:choose>
                  <xsl:when test="ControlType = 'GridDataBind'">
                // 显示<xsl:value-of select="FieldRemark"/>标题及值
                itbOutput = PDF.GenerateCellToTable(
                    itbOutput,
                    "<xsl:value-of select="FieldRemark"/>", "<xsl:value-of select="TitleColumnSpan"/>", !<xsl:value-of select="IsHideTitle"/>,
                    "<xsl:value-of select="GridHeadText"/>",
                    FunctionManager.RemoveTags(GetValue(drTemp["<xsl:value-of select="FieldName"/>"], null)),
                    "<xsl:value-of select="CellColSpan"/>",
                    !<xsl:value-of select="/NewDataSet/NoTableBorder = 'true'"/>
                    );
                  </xsl:when>
                  <xsl:otherwise>
                <xsl:if test="IsHideTitle = 'false'">
                // 显示<xsl:value-of select="FieldRemark"/>标题
                <xsl:choose>
                    <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Title = new Cell(new Paragraph("<xsl:value-of select="FieldRemark"/>：", font11B));
                cell<xsl:value-of select="FieldName"/>Title.BorderWidth = 0;
                cell<xsl:value-of select="FieldName"/>Title.HorizontalAlignment = 0;
                    </xsl:when>
                    <xsl:otherwise>
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Title = new Cell(new Paragraph("<xsl:value-of select="FieldRemark"/>", font11B));
                cell<xsl:value-of select="FieldName"/>Title.BorderWidth = 0.5F;
                cell<xsl:value-of select="FieldName"/>Title.HorizontalAlignment = 1;
                    </xsl:otherwise>
                </xsl:choose>
                cell<xsl:value-of select="FieldName"/>Title.Rowspan = <xsl:value-of select="TitleRowSpan"/>;
                cell<xsl:value-of select="FieldName"/>Title.Colspan = <xsl:value-of select="TitleColumnSpan"/>;
                cell<xsl:value-of select="FieldName"/>Title.Width = 100 / intColumn;
                cell<xsl:value-of select="FieldName"/>Title.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cell<xsl:value-of select="FieldName"/>Title);
                </xsl:if>
                // 显示<xsl:value-of select="FieldRemark"/>值
                <xsl:if test="IsDataBind = 'true'">
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Content = new Cell(new Paragraph(GetValue(drTemp["<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>"]), font10));</xsl:if>
                <xsl:if test="IsDataBind = 'false'">
                    <xsl:choose>
                        <xsl:when test="ControlType = '文件上传'">
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Content = new Cell(new Paragraph(GetValue(drTemp["<xsl:value-of select="FieldName"/>"]), font10));
                        </xsl:when>
                        <xsl:when test="ControlType = '图片上传'">
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Content = new Cell(new Paragraph(GetValue(drTemp["<xsl:value-of select="FieldName"/>"]), font10));
                        </xsl:when>
                        <xsl:when test="DBType = 'Image'">
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Content = new Cell();
                if (!DataValidateManager.ValidateIsDBNull(drTemp["<xsl:value-of select="FieldName"/>"]))
                {
                    if (((Byte[])drTemp["<xsl:value-of select="FieldName"/>"]).Length > 0)
                    {
                        iTextSharp.text.Image img<xsl:value-of select="FieldName"/> = iTextSharp.text.Image.GetInstance((Byte[])drTemp["<xsl:value-of select="FieldName"/>"]);
                        img<xsl:value-of select="FieldName"/>.ScaleToFit(100, 200);
                        cell<xsl:value-of select="FieldName"/>Content.AddElement(img<xsl:value-of select="FieldName"/>);
                    }
                }
                        </xsl:when>
                        <xsl:otherwise>
                iTextSharp.text.Cell cell<xsl:value-of select="FieldName"/>Content = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["<xsl:value-of select="FieldName"/>"], <xsl:value-of select="DisplayFormatString"/>)), font10));
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:if>
                cell<xsl:value-of select="FieldName"/>Content.Rowspan = <xsl:value-of select="ContentRowSpan"/>;
                cell<xsl:value-of select="FieldName"/>Content.Colspan = <xsl:value-of select="ContentColumnSpan"/>;
                cell<xsl:value-of select="FieldName"/>Content.Width = 100 / intColumn;
                cell<xsl:value-of select="FieldName"/>Content.VerticalAlignment = Cell.ALIGN_MIDDLE;
                <xsl:choose>
                    <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                cell<xsl:value-of select="FieldName"/>Content.HorizontalAlignment = 0;
                cell<xsl:value-of select="FieldName"/>Content.BorderWidth = 0;</xsl:when>
                    <xsl:otherwise>
                        <xsl:choose>
                            <xsl:when test="TextAlign = 'Left'">
                cell<xsl:value-of select="FieldName"/>Content.HorizontalAlignment = 0;</xsl:when>
                            <xsl:when test="TextAlign = 'Right'">
                cell<xsl:value-of select="FieldName"/>Content.HorizontalAlignment = 2;</xsl:when>
                            <xsl:when test="TextAlign = 'Center'">
                cell<xsl:value-of select="FieldName"/>Content.HorizontalAlignment = 1;</xsl:when>
                            <xsl:otherwise>
                cell<xsl:value-of select="FieldName"/>Content.HorizontalAlignment = 1;</xsl:otherwise>
                        </xsl:choose>
                        <xsl:if test="IsNoBorderTop = 'false'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthTop = 0.5F;
                        </xsl:if>
                        <xsl:if test="IsNoBorderTop = 'true'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthTop = 0;
                        </xsl:if>
                        <xsl:if test="IsNoBorderLeft = 'false'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthLeft = 0.5F;
                        </xsl:if>
                        <xsl:if test="IsNoBorderLeft = 'true'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthLeft = 0;
                        </xsl:if>
                        <xsl:if test="IsNoBorderBottom = 'false'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthBottom = 0.5F;
                        </xsl:if>
                        <xsl:if test="IsNoBorderBottom = 'true'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthBottom = 0;
                        </xsl:if>
                        <xsl:if test="IsNoBorderRight = 'false'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthRight = 0.5F;
                        </xsl:if>
                        <xsl:if test="IsNoBorderRight = 'true'">
                cell<xsl:value-of select="FieldName"/>Content.BorderWidthRight = 0;
                        </xsl:if>
                    </xsl:otherwise>
                </xsl:choose>
                itbOutput.AddCell(cell<xsl:value-of select="FieldName"/>Content);
                <xsl:if test="/NewDataSet/NoTableBorder = 'true'">
                  <xsl:if test="IsPDFNextSeparateLine = 'true'">
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellBorder);
                  </xsl:if>
                </xsl:if>
                  </xsl:otherwise>
                </xsl:choose>
              </xsl:if>
            </xsl:for-each>
                // 生成一对一相关表表格
            <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
              <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
              <xsl:if test="RelatedTableType = '1_to_1'">
                <xsl:if test="IsDisplay = 'true'">
                // 显示<xsl:value-of select="DisplayName"/>标题
                <xsl:choose>
                    <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title = new Cell(new Paragraph("<xsl:value-of select="DisplayName"/>：", font11B));
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.BorderWidth = 0;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.HorizontalAlignment = 0;
                    </xsl:when>
                    <xsl:otherwise>
                iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title = new Cell(new Paragraph("<xsl:value-of select="DisplayName"/>", font11B));
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.BorderWidth = 0.5F;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.HorizontalAlignment = 1;
                    </xsl:otherwise>
                </xsl:choose>
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Rowspan = <xsl:value-of select="TitleRowSpan"/>;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Colspan = <xsl:value-of select="TitleColumnSpan"/>;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Width = 100 / intColumn;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.VerticalAlignment = Cell.ALIGN_MIDDLE;
                itbOutput.AddCell(cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title);
                // 显示<xsl:value-of select="DisplayName"/>值
                <xsl:if test="IsBindData = 'true'">
                iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content = new Cell(new Paragraph(GetValue(drTemp["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>"]), font10));</xsl:if>
                <xsl:if test="IsBindData = 'false'">
                iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content = new Cell(new Paragraph(FunctionManager.RemoveTags(GetValue(drTemp["<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>"])), font10));</xsl:if>
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Rowspan = <xsl:value-of select="ContentRowSpan"/>;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Colspan = <xsl:value-of select="ContentColumnSpan"/>;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Width = 100 / intColumn;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.VerticalAlignment = Cell.ALIGN_MIDDLE;
                <xsl:choose>
                    <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 0;
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.BorderWidth = 0;</xsl:when>
                    <xsl:otherwise>
                        <xsl:choose>
                            <xsl:when test="TextAlign = 'Left'">
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 0;</xsl:when>
                            <xsl:when test="TextAlign = 'Right'">
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 2;</xsl:when>
                            <xsl:when test="TextAlign = 'Center'">
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 1;</xsl:when>
                            <xsl:otherwise>
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 1;</xsl:otherwise>
                        </xsl:choose>
                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.BorderWidth = 0.5F;</xsl:otherwise>
                </xsl:choose>
                itbOutput.AddCell(cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content);
                </xsl:if></xsl:if>
            </xsl:for-each>
                itbOutput.AddCell(cellTitleSpace);
                itbOutput.AddCell(cellTitleSpace);
            <xsl:if test="/NewDataSet/NoTableBorder = 'true'">
                itbOutput.AddCell(cellBorder);
            </xsl:if>
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
        <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
          <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
          <xsl:sort data-type="number" order="ascending" select="ContentRow"/>
          <xsl:sort data-type="number" order="ascending" select="ContentColumn"/>
          <xsl:if test="RelatedTableType = '1_to_n'">
            <xsl:if test="IsDisplay = 'true'">
        if ("<xsl:value-of select="RelatedTableName"/>" == strRelatedTableName)
        {
              <xsl:if test="ContentRow = '1'">
            intColumn += <xsl:value-of select="TitleColumnSpan"/>;</xsl:if>
        }</xsl:if></xsl:if>
        </xsl:for-each>
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
                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                  <xsl:if test="RelatedTableType = '1_to_n'">
                if ("<xsl:value-of select="RelatedTableName"/>" == strRelatedTableName)
                {
                    dsRelatedTable = Get<xsl:value-of select="RelatedTableName"/>(dsMainTable.Tables[0].Rows[0]["<xsl:value-of select="TableWithField"/>"]);
                  <xsl:if test="IsShowPDFRelatedTableRemark = 'false'">
                      cellTitle = new Cell(new Paragraph("", font11B));
                  </xsl:if>
                }</xsl:if>
                </xsl:for-each>
                <xsl:choose>
                    <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                cellTitle.BorderWidth = 0;</xsl:when>
                    <xsl:otherwise>
                cellTitle.BorderWidth = 0.5F;</xsl:otherwise>
                </xsl:choose>
                cellTitle.HorizontalAlignment = 1;
                cellTitle.VerticalAlignment = Cell.ALIGN_MIDDLE;
                cellTitle.Colspan = intColumn;
                itbOutput.AddCell(cellTitle);
                // 加入相关表字段名称
                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                  <xsl:sort data-type="number" order="ascending" select="ContentRow"/>
                  <xsl:sort data-type="number" order="ascending" select="ContentColumn"/>
                  <xsl:if test="RelatedTableType = '1_to_n'">
                      <xsl:if test="IsDisplay = 'true'">
                if ("<xsl:value-of select="RelatedTableName"/>" == strRelatedTableName)
                {
                    iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title = new Cell(new Paragraph("<xsl:value-of select="DisplayName"/>", font11B));
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Rowspan = <xsl:value-of select="TitleRowSpan"/>;
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Colspan = <xsl:value-of select="TitleColumnSpan"/>;
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.Width = 100 / intColumn;
                    <xsl:choose>
                        <xsl:when test="TextAlign = 'Left'">
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.HorizontalAlignment = 0;</xsl:when>
                        <xsl:when test="TextAlign = 'Right'">
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.HorizontalAlignment = 2;</xsl:when>
                        <xsl:when test="TextAlign = 'Center'">
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.HorizontalAlignment = 1;</xsl:when>
                        <xsl:otherwise>
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.HorizontalAlignment = 1;</xsl:otherwise>
                    </xsl:choose>
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.VerticalAlignment = Cell.ALIGN_MIDDLE;
                    <xsl:choose>
                        <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.BorderWidth = 0;</xsl:when>
                        <xsl:otherwise>
                    cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title.BorderWidth = 0.5F;</xsl:otherwise>
                    </xsl:choose>
                    itbOutput.AddCell(cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Title);                      
                }</xsl:if></xsl:if>
                </xsl:for-each>
                // 加入相关表数据
                if (dsRelatedTable.Tables.Count > 0)
                {
                    string strTempValue = string.Empty;
                    foreach (DataRow drTemp in dsRelatedTable.Tables[0].Rows)
                    {
                    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                      <xsl:sort data-type="number" order="ascending" select="ContentRow"/>
                      <xsl:sort data-type="number" order="ascending" select="ContentColumn"/>
                      <xsl:if test="RelatedTableType = '1_to_n'">
                          <xsl:if test="IsDisplay = 'true'">
                        if ("<xsl:value-of select="RelatedTableName"/>" == strRelatedTableName)
                        {
                            <xsl:if test="IsBindData = 'true'">
                            iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content = new Cell(new Paragraph(GetValue(drTemp["<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/>"]), font10));
                            </xsl:if>
                            <xsl:if test="IsBindData = 'false'">
                            iTextSharp.text.Cell cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content = new Cell(new Paragraph(GetValue(drTemp["<xsl:value-of select="DisplayFieldName"/>"]), font10));
                            </xsl:if>
                            <xsl:if test="IsSortClassify = 'true'">
                            if (strTempValue == GetValue(drTemp["<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/>"]))
                            {
                                cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content = new Cell("");
                            }
                            else
                            {
                                strTempValue = GetValue(drTemp["<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/>"]);
                            }
                            </xsl:if>
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Rowspan = <xsl:value-of select="TitleRowSpan"/>;
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Colspan = <xsl:value-of select="TitleColumnSpan"/>;
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.Width = 100 / intColumn;
                            <xsl:choose>
                                <xsl:when test="TextAlign = 'Left'">
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 0;</xsl:when>
                                <xsl:when test="TextAlign = 'Right'">
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 2;</xsl:when>
                                <xsl:when test="TextAlign = 'Center'">
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 1;</xsl:when>
                                <xsl:otherwise>
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.HorizontalAlignment = 1;</xsl:otherwise>
                            </xsl:choose>
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.VerticalAlignment = Cell.ALIGN_MIDDLE;
                            <xsl:choose>
                                <xsl:when test="/NewDataSet/NoTableBorder = 'true'">
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.BorderWidth = 0;</xsl:when>
                                <xsl:otherwise>
                            cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content.BorderWidth = 0.5F;</xsl:otherwise>
                            </xsl:choose>
                            itbOutput.AddCell(cell<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Content);                     
                        }</xsl:if></xsl:if>
                    </xsl:for-each>
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
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsDisplay = 'true'">
        <xsl:if test="IsSortClassify = 'true'">
        if (rptTemp.ID == "rpt<xsl:value-of select="RelatedTableName"/>")
        {
            string strSortClassify = string.Empty;
            foreach (RepeaterItem gvr in rptTemp.Items)
            {
                if (gvr.ItemType == ListItemType.Item || gvr.ItemType == ListItemType.AlternatingItem)
                {
                    if (strSortClassify != ((HtmlContainerControl)gvr.FindControl("<xsl:value-of select="DisplayFieldName"/>")).InnerText)
                    {
                        strSortClassify = ((HtmlContainerControl)gvr.FindControl("<xsl:value-of select="DisplayFieldName"/>")).InnerText;
                    }
                    else
                    {
                        ((HtmlContainerControl)gvr.FindControl("<xsl:value-of select="DisplayFieldName"/>")).InnerHtml = Convert.ToChar(38).ToString() +"nbsp;";
                    }                    
                }
            }
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_n'">
        if (rptTemp.ID == "rpt<xsl:value-of select="RelatedTableName"/>")
        {
            foreach (RepeaterItem gvr in rptTemp.Items)
            {
                if (gvr.ItemType == ListItemType.Item || gvr.ItemType == ListItemType.AlternatingItem)
                {
                    string strItemMenu = string.Empty;
                    string strObjectID = string.Empty;
                    HtmlTableRow htrTemp;
                    htrTemp = (HtmlTableRow)gvr.FindControl("row");
                    strObjectID = ((HtmlInputHidden)gvr.FindControl("ObjectID")).Value;
                    strItemMenu = ((HtmlContainerControl)gvr.FindControl("itemMenu")).ClientID;
                    htrTemp.Attributes.Add("onmouseover", "overColor(this);");
                    htrTemp.Attributes.Add("onmouseout", "outColor(this);");
                    htrTemp.Attributes.Add("ondblclick", "OpenWindow('<xsl:value-of select="RelatedTableName"/>WebUIDetail.aspx?ObjectID=" + strObjectID + "',770,600,window);return false;");
                    htrTemp.Attributes.Add("oncontextmenu", "showMenu('" + strItemMenu + "');");
                }
            }
        }
  </xsl:if>
</xsl:for-each>
    }
<xsl:if test="/NewDataSet/ExportToDocumentTemplate = 'true'">
    protected void btnExportToDocumentTemplate_Click(object sender, EventArgs e)
    {
        appData = new <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
        appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
        QueryRecord();
        if (!(appData.RecordCount > 0))
        {
            return;
        }
        StringBuilder content = new StringBuilder(FileLibrary.GetTextFileContent(MapPath(ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + @"\DocumentTemplate\<xsl:value-of select="/NewDataSet/TableName"/>Template.xml")));
        if (!DataValidateManager.ValidateIsNull(content))
        {
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:sort data-type="number" order="descending" select="ContentRow"/>
            <xsl:if test="IsDataBind = 'true'">
            content.Replace("$<xsl:value-of select="FieldName"/>$", GetValue(appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>"]));
            </xsl:if>
            <xsl:if test="IsDataBind = 'false'">
                    <xsl:choose>
                        <xsl:when test="ControlType = 'GridDataBind'">
            DataTable dt<xsl:value-of select="FieldName"/> = GenerateDataTable(
                            "<xsl:value-of select="GridColumnName"/>",
                            GetValue(appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>"])
                );
<![CDATA[            for (int i = 0; i < ]]><xsl:value-of select="MaxRowCount"/><![CDATA[; i++)]]>
<![CDATA[            {]]>
<![CDATA[                for (int j = 0; j < dt]]><xsl:value-of select="FieldName"/><![CDATA[.Columns.Count; j++)]]>
<![CDATA[                {]]>
<![CDATA[                    if (i < dt]]><xsl:value-of select="FieldName"/><![CDATA[.Rows.Count)]]>
                    {
                        content.Replace("$<xsl:value-of select="FieldName"/>_{0}_{1}$".FormatInvariantCulture(i, dt<xsl:value-of select="FieldName"/>.Columns[j].ColumnName), GetValue(dt<xsl:value-of select="FieldName"/>.Rows[i][j]));
                    }
                    else
                    {
                        content.Replace("$<xsl:value-of select="FieldName"/>_{0}_{1}$".FormatInvariantCulture(i, dt<xsl:value-of select="FieldName"/>.Columns[j].ColumnName), string.Empty);
                    }
                }
            }
                        </xsl:when>
                        <xsl:when test="ControlType = '文件上传'">

                        </xsl:when>
                        <xsl:when test="ControlType = '图片上传'">

                        </xsl:when>
                        <xsl:when test="DBType = 'Image'">
            if (DataValidateManager.ValidateIsNull(appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>"]))
            {
                content.Replace("$<xsl:value-of select="FieldName"/>$", @"/9j/4AAQSkZJRgABAgAAZABkAAD/7AARRHVja3kAAQAEAAAAPAAA/+4ADkFkb2JlAGTAAAAAAf/bAIQABgQEBAUEBgUFBgkGBQYJCwgGBggLDAoKCwoKDBAMDAwMDAwQDA4PEA8ODBMTFBQTExwbGxscHx8fHx8fHx8fHwEHBwcNDA0YEBAYGhURFRofHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8fHx8f/8AAEQgAAQABAwERAAIRAQMRAf/EAEoAAQAAAAAAAAAAAAAAAAAAAAgBAQAAAAAAAAAAAAAAAAAAAAAQAQAAAAAAAAAAAAAAAAAAAAARAQAAAAAAAAAAAAAAAAAAAAD/2gAMAwEAAhEDEQA/AFSD/9m=");
            }
            else
            {
                content.Replace("$<xsl:value-of select="FieldName"/>$", Convert.ToBase64String((Byte[])appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>"]));
            }
                        </xsl:when>
                        <xsl:otherwise>
            content.Replace("$<xsl:value-of select="FieldName"/>$", FunctionManager.RemoveTagsToWordTemplate(GetValue(appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="FieldName"/>"], <xsl:value-of select="DisplayFormatString"/>)));
                        </xsl:otherwise>
                    </xsl:choose>
                </xsl:if>
    </xsl:for-each>
            FileLibrary.DownloadTextFile(GetValue(appData.ResultSet.Tables[0].Rows[0]["<xsl:value-of select="/NewDataSet/TitleField"/>"]), "xml", content.ToString());
        }
    }
</xsl:if>
}
</xsl:template>
</xsl:stylesheet>
