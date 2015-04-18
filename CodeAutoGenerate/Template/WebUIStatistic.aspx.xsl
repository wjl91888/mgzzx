<?xml version="1.0" encoding="GB2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIStatistic.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIStatistic.aspx.cs" Inherits="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIStatistic" %>]]>
<![CDATA[<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>]]>
<![CDATA[<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>]]>
<![CDATA[<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[统计</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .print .detailtitle {width: 615px;font-size:12px; padding-top:10px; padding-bottom:15px; text-align:left;}
    .print .detailtable{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}
    .print .fieldname{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white; font-weight:bold; height:25px; line-height:18px;text-align:center;}
    .print .fieldinput{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white;text-align:center; height:25px; line-height:18px;}
    .prln { page-break-before: always; page-break-after: always;}
    </style>
</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">]]>
<![CDATA[    <telerik:RadScriptManager ID="rsm]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">]]>
<![CDATA[    </telerik:RadScriptManager>]]>
<![CDATA[    <telerik:RadAjaxManager ID="ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">]]>
<![CDATA[        <AjaxSettings>]]>
  <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsStatisticalCondition = 'true'">
      <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsCoupledNext = 'true'">
<![CDATA[            <telerik:AjaxSetting AjaxControlID="]]><xsl:value-of select="CoupledDataSourcePrevious"/><![CDATA[">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="]]><xsl:value-of select="FieldName"/><![CDATA[" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
        </xsl:if>
      </xsl:if>
    </xsl:if>
</xsl:for-each>
<![CDATA[        </AjaxSettings>]]>
<![CDATA[    </telerik:RadAjaxManager>]]>
<![CDATA[    <telerik:RadAjaxLoadingPanel ID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>]]>
<![CDATA[        <center>]]>
<![CDATA[            <div id="statisticpage" runat="server" class="statisticpage">]]>
<![CDATA[                <div class="title">]]>
<![CDATA[                    <div class="bar">]]>
<![CDATA[                        <div class="lefttitle">]]>
<![CDATA[                            ]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[统计]]>
<![CDATA[                        </div>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </div>]]>
<![CDATA[                <div class="main">]]>
<![CDATA[                    <asp:Literal ID="MessageBox" runat="server"></asp:Literal>]]>
<![CDATA[                    <div class="block">]]>
<![CDATA[                        <ul>]]>
<![CDATA[                            <li>统计方式</li>]]>
<![CDATA[                        </ul>]]>
<![CDATA[                    </div>]]>
<![CDATA[                    <div class="content">]]>
<![CDATA[                        <div class="field">]]>
<![CDATA[                            <div class="fieldname">]]>
<![CDATA[                                统计方式]]>
<![CDATA[                            </div>]]>
<![CDATA[                            <div class="redstar">]]>
<![CDATA[                            </div>]]>
<![CDATA[                        </div>]]>
<![CDATA[                        <div class="fieldinput">]]>
<![CDATA[                                <asp:DropDownList runat="server" ID="CountField" CssClass="input">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsStatisticalData = 'true'">
<![CDATA[                                    <asp:ListItem Text="]]><xsl:value-of select="FieldRemark"/><![CDATA[" Value="]]><xsl:value-of select="FieldName"/><![CDATA["></asp:ListItem>]]>
    </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:if test="IsStatisticalData = 'true'">
<![CDATA[                                    <asp:ListItem Text="]]><xsl:value-of select="DisplayName"/><![CDATA[" Value="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA["></asp:ListItem>]]>
    </xsl:if>
</xsl:for-each>
<![CDATA[                                </asp:DropDownList>]]>
<![CDATA[                        </div>]]>
<![CDATA[                        <div id="Div1" class="fieldnote">]]>
<![CDATA[                        </div>]]>
<![CDATA[                    </div>]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:sort data-type="text" order="descending" select="IsStatisticalCondition"/>
    <xsl:if test="IsStatisticalCondition = 'true'">
        <xsl:if test="position() = 1">
<![CDATA[                    <div class="block">]]>
<![CDATA[                        <ul>]]>
<![CDATA[                            <li>统计条件</li>]]>
<![CDATA[                        </ul>]]>
<![CDATA[                    </div>]]>
        </xsl:if>
<![CDATA[                       <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><xsl:choose><xsl:when test="ControlTypeName = 'FreeTextBox'"></xsl:when><xsl:when test="ControlTypeName = 'ComboTreeView'"></xsl:when><xsl:when test="ControlType = '单行文本框'"></xsl:when><xsl:when test="ControlTypeName = 'CheckBoxListEx'"></xsl:when><xsl:otherwise><![CDATA[ clearboth]]></xsl:otherwise></xsl:choose></xsl:if><xsl:if test="IsRangeSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><xsl:if test="IsMoreItemSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><xsl:if test="IsSubItemSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                           <div class="field">]]>
<![CDATA[                               <div class="fieldname">]]>
                                            <xsl:value-of select="FieldRemark"/>
<![CDATA[                               </div>]]>
<![CDATA[                               <div class="redstar"> </div>]]>
<![CDATA[                           </div>]]>
<![CDATA[                           <div class="fieldinput">]]>
                                <xsl:choose>
                                  <xsl:when test="ControlTypeName = 'FreeTextBox'">
<![CDATA[                             <asp:TextBox ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:TextBox>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlTypeName = 'ComboTreeView'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlTypeName = 'CheckBoxListEx'">
                                      <xsl:choose>
                                        <xsl:when test="IsMoreItemSearch = 'true'">
<![CDATA[                             <RICH:CheckBoxListEx ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh widthfull"></RICH:CheckBoxListEx>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <asp:DropDownList ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></asp:DropDownList>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>               
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
                                      <xsl:choose>
                                        <xsl:when test="IsRangeSearch = 'true'">
<![CDATA[                             <div><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
<![CDATA[                             <B>设定查询值范围</B><B>>=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[Begin" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" runat="server" CssClass="input" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>并且<B><=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[End" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" runat="server" CssClass="input" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[></div>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>
                                  </xsl:when>
                                  <xsl:otherwise>
                                      <xsl:choose>
                                        <xsl:when test="IsMoreItemSearch = 'true'">
<![CDATA[                             <RICH:CheckBoxListEx ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input widthfull"></RICH:CheckBoxListEx>]]>
                                        </xsl:when>
                                        <xsl:when test="IsRangeSearch = 'true'">
<![CDATA[                             <div><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
<![CDATA[                             <B>设定查询值范围</B><B>>=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[Begin" runat="server" CssClass="input" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>并且<B><=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[End" runat="server" CssClass="input" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[></div>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>
                                  </xsl:otherwise>
                                </xsl:choose>
                                <xsl:if test="IsSubItemSearch = 'true'">
<![CDATA[                                   <asp:CheckBox ID="chkShowSubItem]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Text = "包含子（下级）项目信息" />]]>
                                </xsl:if>
<![CDATA[                           </div>]]>
<![CDATA[                           <div id = "]]><xsl:value-of select="FieldName"/><![CDATA[_note" class="fieldnote">]]>
                                <xsl:if test="IsApproximateSearch = 'true'">
<![CDATA[                               此字段可以进行模糊搜索。]]>
                                </xsl:if>
<![CDATA[                       </div>]]>
<![CDATA[                   </div>]]>
    </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsAdvanceSearch = 'true'">
<![CDATA[                       <div class="content">]]>
<![CDATA[                           <div class="field">]]>
<![CDATA[                               <div class="fieldname">]]>
                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                               </div>]]>
<![CDATA[                               <div class="fieldcheck">]]>
<![CDATA[                               </div>]]>
<![CDATA[                               <div class="redstar"> </div>]]>
<![CDATA[                           </div>]]>
<![CDATA[                           <div class="fieldinput">]]>
                                      <xsl:choose>
                                        <xsl:when test="IsMoreItemSearch = 'true'">
<![CDATA[                             <RICH:CheckBoxListEx ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input"></RICH:CheckBoxListEx>]]>
                                        </xsl:when>
                                        <xsl:when test="IsBindData = 'true'">
<![CDATA[                             <asp:DropDownList ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input"></asp:DropDownList>]]>
                                        </xsl:when>
                                        <xsl:when test="IsRangeSearch = 'true'">
<![CDATA[                             <div><asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input"></asp:TextBox></div>]]>
<![CDATA[                             <div><B>设定查询值范围</B><br /><B>>=</B><asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[Begin" runat="server" CssClass="input" Width = "96"></asp:TextBox>并且<B><=</B><asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[End" runat="server" CssClass="input" Width = "96"></asp:TextBox></div>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input"></asp:TextBox>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>
                                      <xsl:if test="IsSubItemSearch = 'true'">
<![CDATA[                             <div>]]>
<![CDATA[                                   <asp:CheckBox ID="chkShowSubItem]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" Text = "包含子（下级）项目信息" />]]>
<![CDATA[                             </div>]]>
                                      </xsl:if>
<![CDATA[                           </div>]]>
<![CDATA[                           <div id = "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[_note" class="fieldnote">]]>
<![CDATA[                       </div>]]>
<![CDATA[                   </div>]]>
    </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                </div>]]>
<![CDATA[                <div class="operation">]]>
<![CDATA[                    <center>]]>
<![CDATA[                        <asp:Button Text="统计结果" ID="btnStatistic" runat="server" CssClass="button" OnClick="btnStatistic_Click" />]]>
<![CDATA[                        <asp:Button Text="重新填写" ID="btnReset" runat="server" CssClass="button" OnClick="btnReset_Click" />]]>
<![CDATA[                        <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />]]>
<![CDATA[                    </center>]]>
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
<![CDATA[            <div id="statisticresultpage" runat="server" class="statisticresultpage">]]>
<![CDATA[                <div id="nonprintarea">]]>
<![CDATA[                    <div class="title">]]>
<![CDATA[                        <div class="bar">]]>
<![CDATA[                            <div class="lefttitle">]]>
<![CDATA[                                ]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[统计结果]]>
<![CDATA[                            </div>]]>
<![CDATA[                        </div>]]>
<![CDATA[                        <div class="operation">]]>
<![CDATA[                    <asp:Button ID="btnShowStatistic" runat="server" Text="统计条件" CssClass="button" OnClick="btnShowStatistic_Click"/>]]>
<![CDATA[                            <asp:DropDownList runat="server" ID="ddlExportFileFormat">]]>
<![CDATA[                                <asp:ListItem Text="选择导出文件类型" Value="xls"></asp:ListItem>]]>
<![CDATA[                                <asp:ListItem Text="EXCEL文件(.xls)" Value="xls"></asp:ListItem>]]>
<![CDATA[                                <asp:ListItem Text="WORD文件(.doc)" Value="doc"></asp:ListItem>]]>
<![CDATA[                            </asp:DropDownList>]]>
<![CDATA[                            <asp:Button runat="server" ID="btnExportToFile" Text="导出数据" CssClass="button1" OnClientClick="return ExportToFileConfirmDialog();" OnClick="btnExportAllToFile_Click" />]]>
<![CDATA[                            <input type="button" value="打印本页" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button1" />]]>
<![CDATA[                            <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button1" />]]>
<![CDATA[                        </div>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </div>]]>
<![CDATA[                <div class="print">]]>
<![CDATA[                    <div class="detailtitle">
<![CDATA[                    <asp:Label ID="lblCaption" runat="server" ></asp:Label>]]>
<![CDATA[                    </div>]]>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    <asp:GridView ID="gvPrint" ShowFooter="true" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="1" CssClass="detailtable" OnRowDataBound="gvList_RowDataBound">]]>
<![CDATA[                        <Columns>]]>
<![CDATA[                        <asp:TemplateField HeaderText="编号" Visible = "true">]]>
<![CDATA[                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderTemplate>]]>
<![CDATA[                                编号<asp:LinkButton ID="btnSortRecordID" runat="server" CommandArgument="RecordID" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>]]>
<![CDATA[                            </HeaderTemplate>]]>
<![CDATA[                            <ItemTemplate>]]>
<![CDATA[                                <%# DataBinder.Eval(Container.DataItem, "RecordID")%>]]>
<![CDATA[                            </ItemTemplate>]]>
<![CDATA[                            <FooterTemplate>]]>
<![CDATA[                            </FooterTemplate>]]>
<![CDATA[                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                        </asp:TemplateField>]]>
<![CDATA[                        <asp:TemplateField HeaderText="名称" Visible = "true">]]>
<![CDATA[                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderTemplate>]]>
<![CDATA[                                名称<asp:LinkButton ID="btnSortRecordName" runat="server" CommandArgument="RecordName" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>]]>
<![CDATA[                            </HeaderTemplate>]]>
<![CDATA[                            <ItemTemplate>]]>
<![CDATA[                                <%# DataBinder.Eval(Container.DataItem, "RecordName")%>]]>
<![CDATA[                            </ItemTemplate>]]>
<![CDATA[                            <FooterTemplate>]]>
<![CDATA[                                合计]]>
<![CDATA[                            </FooterTemplate>]]>
<![CDATA[                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                        </asp:TemplateField>]]>
<![CDATA[                        <asp:TemplateField HeaderText="数量" Visible = "true">]]>
<![CDATA[                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderTemplate>]]>
<![CDATA[                                数量<asp:LinkButton ID="btnSortRecordCount" runat="server" CommandArgument="RecordCount" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>]]>
<![CDATA[                            </HeaderTemplate>]]>
<![CDATA[                            <ItemTemplate>]]>                                  
<![CDATA[                            <%# DataBinder.Eval(Container.DataItem, "RecordCount")%>]]>
<![CDATA[                            </ItemTemplate>]]>
<![CDATA[                            <FooterTemplate>]]>
<![CDATA[                                <%# appData.RecordCount%>]]>
<![CDATA[                            </FooterTemplate>]]>
<![CDATA[                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                        </asp:TemplateField>]]>
<![CDATA[                        <asp:TemplateField HeaderText="百分比（%）" Visible = "true">]]>
<![CDATA[                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderTemplate>]]>
<![CDATA[                                百分比（%）<asp:LinkButton ID="btnSortRecordPercent" runat="server" CommandArgument="RecordPercent" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>]]>
<![CDATA[                            </HeaderTemplate>]]>
<![CDATA[                            <ItemTemplate>]]>
<![CDATA[                                <%# DataBinder.Eval(Container.DataItem, "RecordPercent")%>]]>
<![CDATA[                            </ItemTemplate>]]>
<![CDATA[                            <FooterTemplate>]]>
<![CDATA[                                100]]>
<![CDATA[                            </FooterTemplate>]]>
<![CDATA[                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                        </asp:TemplateField>]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsSum = 'true'">
<![CDATA[                        <asp:TemplateField HeaderText="]]><xsl:value-of select="FieldRemark"/><![CDATA[" Visible = "true">]]>
<![CDATA[                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                            <HeaderTemplate>]]>
<![CDATA[                                ]]><xsl:value-of select="FieldRemark"/><![CDATA[<asp:LinkButton ID="btnSort]]><xsl:value-of select="FieldName"/><![CDATA[Sum" runat="server" CommandArgument="]]><xsl:value-of select="FieldName"/><![CDATA[Sum" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>]]>
<![CDATA[                            </HeaderTemplate>]]>
<![CDATA[                            <ItemTemplate>]]>                                  
<![CDATA[                            <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[Sum")%>]]>
<![CDATA[                            </ItemTemplate>]]>
<![CDATA[                            <FooterTemplate>]]>
<![CDATA[                             ]]>
<![CDATA[                            </FooterTemplate>]]>
<![CDATA[                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />]]>
<![CDATA[                        </asp:TemplateField>]]>
    </xsl:if>
</xsl:for-each>
<![CDATA[                        </Columns>]]>
<![CDATA[                    </asp:GridView>]]>
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
<![CDATA[        </center>]]>
<![CDATA[</asp:Content>]]>
</xsl:template>
</xsl:stylesheet>