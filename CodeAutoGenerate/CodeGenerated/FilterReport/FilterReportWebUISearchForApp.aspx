
<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="FilterReportWebUISearch.aspx.cs" Inherits="App.FilterReportWebUISearch" %>
<%@ Import Namespace="RICH.Common" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="Nav" Src="~/Control/PageNavControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server"></asp:Content><asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
    <control:Nav ID="NavList" runat="server"></control:Nav>
</asp:Content>
<asp:Content ID="MainContainer" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">


    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">
        <script language="javascript" type="text/javascript">
            function EditorWindowClose(sender, eventArgs) {
                RefreshGrid();
            }
            function RefreshGrid() {
                $find("<%= CurrentAjaxManager.ClientID %>").ajaxRequest("Refresh");
            }
            $(document).ready(function () {
                $(".needrefresh").on("change", function () { RefreshGrid(); });
                $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });
            });
        </script>
    </telerik:RadCodeBlock>


    <telerik:RadAjaxManagerProxy ID="ramFilterReport" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="radAjaxManager">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpFilterReport" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>


<asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <div class="list-group" style="margin:0 0 5px 0;">
                <div class="list-group-item">
                    <a href='<%# "FilterReportWebUIDetail.aspx?p={0}{1}ObjectID={2}".FormatInvariantCulture(this.Page.Request["p"], AndChar ,GetValue(DataBinder.Eval(Container.DataItem, "ObjectID"), null))%>'><h4 class="list-group-item-heading">
                        <%# GetValue(DataBinder.Eval(Container.DataItem, "BGMC"), null)%></h4></a>
    

                    <div style="clear: both;margin:0;padding:0;">
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
</asp:Content>


<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnFirstPage" runat="server" Text="|<" OnClick="btnFirstPage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnPrePage" runat="server" Text="<" OnClick="btnPrePage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnNextPage" runat="server" Text=">" OnClick="btnNextPage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnLastPage" runat="server" Text=">|" OnClick="btnLastPage_Click" class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-4 col-xs-4 text-center" style="padding-right: 0px !important; padding-left: 0px !important; padding-top: 12px;">
            <telerik:RadComboBox ID="ddlPageCount" Width="105" Font-Size="10" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged">
            </telerik:RadComboBox>
        </li>
    </ul>
</asp:Content>


