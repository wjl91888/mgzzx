<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_BG_0601WebUIStatistic.aspx.cs" Inherits="T_BG_0601WebUIStatistic" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">公共信息统计</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    .print .detailtitle {width: 615px;font-size:12px; padding-top:10px; padding-bottom:15px; text-align:left;}
    .print .detailtable{width: 615px;border-top:1px black solid;border-left:1px black solid;border-right:0px black solid;border-bottom:0px black solid;vertical-align:middle; font-size:12px;}
    .print .fieldname{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white; font-weight:bold; height:25px; line-height:18px;text-align:center;}
    .print .fieldinput{padding-left:1px;padding-top:3px;padding-bottom:3px;border-right:1px black solid;border-bottom:1px black solid;border-top:0px black solid;border-left:0px black solid;background-color:white;text-align:center; height:25px; line-height:18px;}
    .prln { page-break-before: always; page-break-after: always;}
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_BG_0601" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BG_0601" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BG_0601" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <div id="statisticpage" runat="server" class="statisticpage">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            公共信息统计
                        </div>
                    </div>
                </div>
                <div class="main">
                    <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                    <div class="block">
                        <ul>
                            <li>统计方式</li>
                        </ul>
                    </div>
                    <div class="content">
                        <div class="field">
                            <div class="fieldname">
                                统计方式
                            </div>
                            <div class="redstar">
                            </div>
                        </div>
                        <div class="fieldinput">
                                <asp:DropDownList runat="server" ID="CountField" CssClass="input">

                                </asp:DropDownList>
                        </div>
                        <div id="Div1" class="fieldnote">
                        </div>
                    </div>

                </div>
                <div class="operation">
                    <center>
                        <asp:Button Text="统计结果" ID="btnStatistic" runat="server" CssClass="button" OnClick="btnStatistic_Click" />
                        <asp:Button Text="重新填写" ID="btnReset" runat="server" CssClass="button" OnClick="btnReset_Click" />
                        <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                    </center>
                </div>
            </div>
            <div id="statisticresultpage" runat="server" class="statisticresultpage">
                <div id="nonprintarea">
                    <div class="title">
                        <div class="bar">
                            <div class="lefttitle">
                                公共信息统计结果
                            </div>
                        </div>
                        <div class="operation">
                    <asp:Button ID="btnShowStatistic" runat="server" Text="统计条件" CssClass="button" OnClick="btnShowStatistic_Click"/>
                            <asp:DropDownList runat="server" ID="ddlExportFileFormat">
                                <asp:ListItem Text="选择导出文件类型" Value="xls"></asp:ListItem>
                                <asp:ListItem Text="EXCEL文件(.xls)" Value="xls"></asp:ListItem>
                                <asp:ListItem Text="WORD文件(.doc)" Value="doc"></asp:ListItem>
                            </asp:DropDownList>
                            <asp:Button runat="server" ID="btnExportToFile" Text="导出数据" CssClass="button1" OnClientClick="return ExportToFileConfirmDialog();" OnClick="btnExportAllToFile_Click" />
                            <input type="button" value="打印本页" onclick="nonprintarea.style.display = 'none'; window.print();nonprintarea.style.display = 'block';" class="button1" />
                            <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button1" />
                        </div>
                    </div>
                </div>
                <div class="print">
                    <div class="detailtitle">
<![CDATA[                    <asp:Label ID="lblCaption" runat="server" ></asp:Label>
                    </div>
                    <div class="clearboth"></div>
                    <asp:GridView ID="gvPrint" ShowFooter="true" runat="server" AutoGenerateColumns="False" CellSpacing="0" CellPadding="0" HorizontalAlign="Center" BorderWidth="1" CssClass="detailtable" OnRowDataBound="gvList_RowDataBound">
                        <Columns>
                        <asp:TemplateField HeaderText="编号" Visible = "true">
                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                            <HeaderTemplate>
                                编号<asp:LinkButton ID="btnSortRecordID" runat="server" CommandArgument="RecordID" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "RecordID")%>
                            </ItemTemplate>
                            <FooterTemplate>
                            </FooterTemplate>
                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="名称" Visible = "true">
                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                            <HeaderTemplate>
                                名称<asp:LinkButton ID="btnSortRecordName" runat="server" CommandArgument="RecordName" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "RecordName")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                合计
                            </FooterTemplate>
                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="数量" Visible = "true">
                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                            <HeaderTemplate>
                                数量<asp:LinkButton ID="btnSortRecordCount" runat="server" CommandArgument="RecordCount" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>                                  
                            <%# DataBinder.Eval(Container.DataItem, "RecordCount")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                <%# appData.RecordCount%>
                            </FooterTemplate>
                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="百分比（%）" Visible = "true">
                            <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                            <HeaderStyle CssClass="fieldname" HorizontalAlign="Center" />
                            <HeaderTemplate>
                                百分比（%）<asp:LinkButton ID="btnSortRecordPercent" runat="server" CommandArgument="RecordPercent" CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <%# DataBinder.Eval(Container.DataItem, "RecordPercent")%>
                            </ItemTemplate>
                            <FooterTemplate>
                                100
                            </FooterTemplate>
                            <FooterStyle CssClass="fieldname" HorizontalAlign="Center" />
                        </asp:TemplateField>

                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </center>
</asp:Content>

