<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUISearch.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0601WebUISearch.aspx.cs" Inherits="App.T_BG_0601WebUISearch" %>]]>
<![CDATA[<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>]]>
<![CDATA[<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="Nav" Src="~/Control/PageNavControl.ascx" %>]]>
<![CDATA[<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">]]>
<![CDATA[    <control:Nav ID="NavList" runat="server"></control:Nav>]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="MainContainer" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">]]>
<![CDATA[    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">]]>
<![CDATA[        <script language="javascript" type="text/javascript">]]>
<![CDATA[            function EditorWindowClose(sender, eventArgs) {]]>
<![CDATA[                RefreshGrid();]]>
<![CDATA[            }]]>
<![CDATA[            function RefreshGrid() {]]>
<![CDATA[                $find("<%= CurrentAjaxManager.ClientID %>").ajaxRequest("Refresh");]]>
<![CDATA[            }]]>
<![CDATA[            $(document).ready(function () {]]>
<![CDATA[                $(".needrefresh").on("change", function () { RefreshGrid(); });]]>
<![CDATA[                $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });]]>
<![CDATA[            });]]>
<![CDATA[        </script>]]>
<![CDATA[    </telerik:RadCodeBlock>]]>
<![CDATA[    <telerik:RadAjaxManagerProxy ID="ramT_BG_0601" runat="server">]]>
<![CDATA[        <AjaxSettings>]]>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="btnFirstPage">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="btnPrePage">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="btnNextPage">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="btnLastPage">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="ddlPageCount">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="radAjaxManager">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
<![CDATA[        </AjaxSettings>]]>
<![CDATA[    </telerik:RadAjaxManagerProxy>]]>
<![CDATA[    <telerik:RadAjaxLoadingPanel ID="ralpT_BG_0601" runat="server" Skin="Vista">]]>
<![CDATA[    </telerik:RadAjaxLoadingPanel>]]>
<![CDATA[    <asp:Repeater ID="rptList" runat="server">]]>
<![CDATA[        <ItemTemplate>]]>
<![CDATA[            <div class="list-group" style="margin:0 0 5px 0;">]]>
<![CDATA[                <a href='T_BG_0601WebUIDetail.aspx?ObjectID=<%# GetValue(DataBinder.Eval(Container.DataItem, "ObjectID"), null)%>' class="list-group-item">]]>
<![CDATA[                    <h4 class="list-group-item-heading">]]>
<![CDATA[                        <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)%></h4>]]>
<![CDATA[                    <h6 class="col-sm-4 col-xs-4" style="margin:0;">]]>
<![CDATA[                        <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM")%></h6>]]>
<![CDATA[                    <h6 class="col-sm-4 col-xs-4" style="margin:0;">]]>
<![CDATA[                        <%# DataBinder.Eval(Container.DataItem, "FBBM_T_BM_DWXX_DWMC")%></h6>]]>
<![CDATA[                    <h6 class="col-sm-4 col-xs-4 text-right" style="margin:0;">]]>
<![CDATA[                        <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), "yy-MM-dd")%></h6>]]>
<![CDATA[                    <div style="clear: both;margin:0;padding:0;">]]>
<![CDATA[                    </div>]]>
<![CDATA[                </a>]]>
<![CDATA[            </div>]]>
<![CDATA[        </ItemTemplate>]]>
<![CDATA[    </asp:Repeater>]]>
<![CDATA[    <script>]]>
<![CDATA[        Sys.Application.add_load(function () {]]>
<![CDATA[            $('body,html').animate({ scrollTop: 0 }, 10);]]>
<![CDATA[        });]]>
<![CDATA[    </script>]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">]]>
<![CDATA[    <ul id="PageInfo" runat="server" class="nav  navbar-default">]]>
<![CDATA[        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">]]>
<![CDATA[            <asp:Button ID="btnFirstPage" runat="server" Text="|<" OnClick="btnFirstPage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>]]>
<![CDATA[        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">]]>
<![CDATA[            <asp:Button ID="btnPrePage" runat="server" Text="<" OnClick="btnPrePage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>]]>
<![CDATA[        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">]]>
<![CDATA[            <asp:Button ID="btnNextPage" runat="server" Text=">" OnClick="btnNextPage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>]]>
<![CDATA[        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">]]>
<![CDATA[            <asp:Button ID="btnLastPage" runat="server" Text=">|" OnClick="btnLastPage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>]]>
<![CDATA[        <li class="col-sm-4 col-xs-4 text-center" style="padding-right: 0px !important; padding-left: 0px !important; padding-top: 12px;">]]>
<![CDATA[            <telerik:RadComboBox ID="ddlPageCount" Width="105" Font-Size="10" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged">]]>
<![CDATA[            </telerik:RadComboBox>]]>
<![CDATA[        </li>]]>
<![CDATA[    </ul>]]>
<![CDATA[</asp:Content>]]>
</xsl:template>
</xsl:stylesheet>