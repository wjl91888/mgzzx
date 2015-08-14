<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIDetail.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIDetail.aspx.cs" Inherits="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIDetail" %>]]>
<![CDATA[<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[详情</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">]]>
<![CDATA[    <style type="text/css">]]>
<![CDATA[    .print .detailtitle {font-size:26px; padding-top:10px; padding-bottom:15px;}]]>
<![CDATA[    .print .detailtable{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}]]>
<![CDATA[    .print .detailtable_10{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:10px;}]]>
<![CDATA[    .print .detailtable_12{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}]]>
<![CDATA[    .print .detailtable_14{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:14px;}]]>
<![CDATA[    .print .detailtable_16{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:16px;}]]>
<![CDATA[    .print .detailtable_18{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:18px;}]]>
<![CDATA[    .print .fieldname{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white; font-weight:bold; height:25px; line-height:18px;text-align:center;}]]>
<![CDATA[    .print .fieldinput{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white;text-align:center; height:25px; line-height:18px;}]]>
<![CDATA[    .prln { page-break-before: always; page-break-after: always;}]]>
<![CDATA[    </style>]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">]]>
<![CDATA[        <center>]]>
<![CDATA[                <div id="detailpage" runat="server" class="detailpage">]]>
<![CDATA[                    <div id="nonprintarea">]]>
<![CDATA[                        <div class="title">]]>
<![CDATA[                            <div class="bar">]]>
<![CDATA[                                <div class="lefttitle">]]>
<![CDATA[                                    ]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[]]>
<![CDATA[                                </div>]]>
<![CDATA[                            </div>]]>
<![CDATA[                        </div>]]>
<![CDATA[                        <asp:Literal ID="MessageBox" runat="server"></asp:Literal>]]>
<![CDATA[                        <div class="operation">]]>
<![CDATA[                        <div style="display:none;">]]>
<![CDATA[                    导出PDF页面设置：大小<asp:DropDownList ID="ddlPrintPageSize" runat="server" Visible = "false"></asp:DropDownList>]]>
<![CDATA[                    版面<asp:DropDownList ID="ddlPrintPageOrientation" runat="server" Visible = "false"></asp:DropDownList>]]>
<![CDATA[                    <asp:DropDownList runat="server" ID="ddlExportFileFormat" Visible="false"><asp:ListItem Text="PDF文件(.PDF)" Value="pdf"></asp:ListItem></asp:DropDownList>]]>
<![CDATA[                    上边距<asp:TextBox ID="txtMarginTop" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>]]>
<![CDATA[                    右边距<asp:TextBox ID="txtMarginRight" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>]]>
<![CDATA[                    下边距<asp:TextBox ID="txtMarginBottom" runat="server" Width="20" Text="50" ></asp:TextBox>]]>
<![CDATA[                    左边距<asp:TextBox ID="txtMarginLeft" runat="server" Width="20" Text="50" Visible="false"></asp:TextBox>]]>
<![CDATA[                    <br />]]>
<![CDATA[                        </div>]]>
<![CDATA[                    <input type="button" id ="btnEditItem" runat ="server" value="修改" class="button" />]]>
<xsl:if test="/NewDataSet/CopyItem = 'true'">
<![CDATA[                    <input type="button" id ="btnCopyItem" runat ="server" value="复制" class="button" />]]>
</xsl:if>
<xsl:if test="/NewDataSet/ExportToDocumentTemplate = 'true'">
<![CDATA[                    <asp:Button runat="server" ID="btnExportToDocumentTemplate" Text="Word打印" CssClass="button" OnClientClick="return ExportToFileConfirmDialog();" OnClick="btnExportToDocumentTemplate_Click" />]]>
</xsl:if>
<xsl:if test="/NewDataSet/ExportToPDF = 'true'">
<![CDATA[                    <asp:Button runat="server" ID="btnExportToFile" Text="PDF打印" CssClass="button" OnClientClick="return ExportToFileConfirmDialog();" OnClick="btnExportAllToFile_Click" />]]>
</xsl:if>
<![CDATA[                    <input id="btnPrintPage" runat="server" type="button" value="打印本页" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button" />]]>
<![CDATA[                    <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />]]>
<![CDATA[                        </div>]]>
<![CDATA[                    </div>]]>
<![CDATA[                    <div ID="ControlContainer" runat="server" class="print">]]>
<![CDATA[                        <asp:GridView ID="gvPrint" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="0" onrowdatabound="gvPrint_RowDataBound">]]>
<![CDATA[                            <Columns>]]>
<![CDATA[                                <asp:TemplateField>]]>
<![CDATA[                                    <ItemStyle HorizontalAlign="Center" />]]>
<![CDATA[                                    <HeaderStyle CssClass="detailtitle" HorizontalAlign="Center" />]]>
<![CDATA[                                    <HeaderTemplate>]]>
<![CDATA[                                        ]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[]]>
<![CDATA[                                    </HeaderTemplate>]]>
<![CDATA[                                    <ItemTemplate>]]>
<![CDATA[                                        <!-- 主表信息 -->]]>
<![CDATA[                                        <div id="divmain" runat="server"></div>]]>
<![CDATA[                                        <div id="divvaluearea" runat="server" style = "display:none;">]]>
                                    <xsl:for-each select="/NewDataSet/RecordInfo">
                                      <xsl:if test="IsShowDetail = 'true'">
<![CDATA[                                            <div id = "]]><xsl:value-of select="FieldName"/><![CDATA[" runat = "server" >]]>
                                        <xsl:if test="IsDataBind = 'true'">
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/><![CDATA[") + Convert.ToChar(38).ToString() +"nbsp;"%>]]>
                                        </xsl:if>
                                        <xsl:if test="IsDataBind = 'false'">
                                            <xsl:choose>
                                                <xsl:when test="ControlTypeName = 'FilesList'">
<![CDATA[                               <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?a=d"+ AndChar +"file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[")) + "' target='_blank'>]]><![CDATA[下载</a>"%>]]>
<![CDATA[                               <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[")) + "' target='_blank'>]]><![CDATA[预览</a>"%>]]>
                                                </xsl:when>
                                                <xsl:when test="DBType = 'Image'">
<![CDATA[                                    <img width="130" height="160" src='<%# "]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=" + DataBinder.Eval(Container.DataItem, "ObjectID") + AndChar + "ImageField=]]><xsl:value-of select="FieldName"/><![CDATA["%>'  />]]>
                                                </xsl:when>
                                                <xsl:otherwise>
<![CDATA[                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA["), ]]><xsl:value-of select="DisplayFormatString"/><![CDATA[) + Convert.ToChar(38).ToString() +"nbsp;"%>]]>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </xsl:if>
<![CDATA[                                           </div>]]>
                                      </xsl:if>
                                    </xsl:for-each>
                                    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                      <xsl:if test="RelatedTableType = '1_to_1'">
                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                            <div  id = "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat = "server" >]]>
                                            <xsl:choose>
                                                <xsl:when test="IsBindData = 'true'">
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                </xsl:when>
                                                <xsl:otherwise>
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                </xsl:otherwise>
                                            </xsl:choose>
<![CDATA[                                           </div>]]>                                                  
                                          </xsl:if>
                                      </xsl:if>
                                    </xsl:for-each>
<![CDATA[                                        </div>]]>
<![CDATA[                                        <!-- 一对多相关表信息 -->]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '1'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_1" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '1'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '1'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '1'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '1'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '1'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '1'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '2'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_2" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '2'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '2'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '2'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '2'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '2'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '2'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '3'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_3" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '3'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '3'">
<![CDATA[                                               <td style="display:none;"></td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '3'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '3'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '3'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '3'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '4'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_4" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '4'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '4'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '4'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '4'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '4'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '4'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '5'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_5" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '5'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '5'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '5'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '5'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '5'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '5'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '6'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_6" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '6'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '6'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '6'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '6'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '6'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '6'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '7'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_7" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '7'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '7'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '7'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '7'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '7'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '7'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '8'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_8" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '8'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '8'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '8'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '8'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '8'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '8'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '9'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_9" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '9'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '9'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '9'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '9'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '9'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '9'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>

                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '10'">
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[开始 -->]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
<![CDATA[                                           <td class="fieldname">]]>
<![CDATA[                                               <b>]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</b>]]>
<![CDATA[                                           </td>]]>
<![CDATA[                                           </tr>]]>
<![CDATA[                                        </table>]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        <div id = "relatedtable_10" runat = "server" style = "display:none;">]]>
<![CDATA[                                        <table class="detailtable" cellspacing="0" cellpadding="0" border="1" bordercolor="black" width="615">]]>
<![CDATA[                                           <tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '10'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldname">]]>
                                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '10'">
<![CDATA[                                               <td style="display:none;"></td>]]>

                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
<![CDATA[                                           </tr>]]>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '10'">
<![CDATA[                                        <asp:Repeater runat="server"]]>
<![CDATA[                                        ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA["]]>
<![CDATA[                                        DataSource='<%# Get]]><xsl:value-of select="RelatedTableName"/><![CDATA[(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/><![CDATA["))%>' onprerender="rptRelatedTable_PreRender">]]>
<![CDATA[                                            <ItemTemplate>]]>
<![CDATA[                                           <tr id="row" runat="server">]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '10'">
                                                          <xsl:if test="IsDisplay = 'true'">
<![CDATA[                                               <td class="fieldinput"  id = "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server">]]>
<![CDATA[                                               <div style="width:100%;text-align:]]><xsl:value-of select="TextAlign"/><![CDATA[;">]]>
                                                        <xsl:choose>
                                                            <xsl:when test="IsBindData = 'true'">
<![CDATA[                                                  <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataTableName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                            </xsl:when>
                                                            <xsl:otherwise>
<![CDATA[                                                 <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                            </xsl:otherwise>
                                                        </xsl:choose>
<![CDATA[                                               </div>]]>
<![CDATA[                                               </td>]]>
                                                          </xsl:if>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
                                            <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                <xsl:if test="RelatedTableType = '1_to_n'">
                                                  <xsl:if test="SerialNumber = '10'">
<![CDATA[                                               <td style="display:none;">]]>
<![CDATA[                                    <div style="display:none;"><input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' /></div>]]>
<![CDATA[                                    <!-- 这里用来定义需要显示的右键菜单 -->]]>
<![CDATA[                                    <div id="itemMenu" style="display: none;" runat="server">]]>
<![CDATA[                                        <table width="100%" bgcolor="#cccccc" style="border: 1px solid black;font-size: 12px;" cellspacing="0">]]>
<![CDATA[                                            <tr>]]>
<![CDATA[                                                <td style="cursor: default; border:0px solid black;height:24px;" onclick="parent.OpenWindow(']]><xsl:value-of select="RelatedTableName"/><![CDATA[WebUIDetail.aspx?ObjectID=<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>&RelatedTableName=]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[',770,600,window);">]]>
<![CDATA[                                                    查看]]>
<![CDATA[                                               </td>]]>
<![CDATA[                                            </tr>]]>
<![CDATA[                                        </table>]]>
<![CDATA[                                    </div>]]>
<![CDATA[                                    <!-- 右键菜单结束-->]]>
<![CDATA[                                               </td>]]>
                                                  </xsl:if>
                                                </xsl:if>
                                            </xsl:for-each>
                                                <xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
                                                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
                                                  <xsl:if test="RelatedTableType = '1_to_n'">
                                                      <xsl:if test="SerialNumber = '10'">
<![CDATA[                                           </tr>]]>
<![CDATA[                                            </ItemTemplate>]]>
<![CDATA[                                        </asp:Repeater>]]>
<![CDATA[                                        <!-- 相关表]]><xsl:value-of select="RelatedInfoName"/><![CDATA[结束 -->]]>
                                                      </xsl:if>
                                                  </xsl:if>
                                                </xsl:for-each>
<![CDATA[                                        </table>]]>
<![CDATA[                                        </div>]]>
<![CDATA[                                    </ItemTemplate>]]>
<![CDATA[                                </asp:TemplateField>]]>
<![CDATA[                            </Columns>]]>
<![CDATA[                        </asp:GridView>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </div>]]>
<![CDATA[        </center>]]>
<![CDATA[</asp:Content>]]>
</xsl:template>
</xsl:stylesheet>