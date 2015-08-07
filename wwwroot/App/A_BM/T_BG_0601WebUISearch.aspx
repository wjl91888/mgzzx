<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0601WebUISearch.aspx.cs"
    Inherits="App.T_BG_0601WebUISearch" %>

<%@ Register TagPrefix="control" TagName="Nav" Src="~/Control/PageNavControl.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder"
    runat="server">
</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
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
    <telerik:RadAjaxManagerProxy ID="ramT_BG_0601" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="rptList" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="PageInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BG_0601" runat="server" Skin="Vista">
    </telerik:RadAjaxLoadingPanel>
    <asp:Repeater ID="rptList" runat="server">
        <ItemTemplate>
            <div class="list-group">
                <a href='T_BG_0601WebUIDetail.aspx?ObjectID=<%# GetValue(DataBinder.Eval(Container.DataItem, "ObjectID"), null)%>' class="list-group-item">
                    <h4 class="list-group-item-heading">
                        <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)%></h4>
                    <h6 class="col-sm-4 col-xs-4">
                        <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM")%></h6>
                    <h6 class="col-sm-4 col-xs-4">
                        <%# DataBinder.Eval(Container.DataItem, "FBBM_T_BM_DWXX_DWMC")%></h6>
                    <h6 class="col-sm-4 col-xs-4 text-right">
                        <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), "yy-MM-dd")%></h6>
                    <div style="clear: both;"></div>
                </a>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
<asp:Content ID="NavContainer" ContentPlaceHolderID="NavContainerPlaceHolder" runat="server">
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnFirstPage" runat="server" Text="|<" OnClick="btnFirstPage_Click"
                class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnPrePage" runat="server" Text="<" OnClick="btnPrePage_Click" class="btn btn-default navbar-btn"
                data-toggle="collapse" /></li>
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnNextPage" runat="server" Text=">" OnClick="btnNextPage_Click"
                class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-2 col-xs-2 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <asp:Button ID="btnLastPage" runat="server" Text=">|" OnClick="btnLastPage_Click"
                class="btn btn-default navbar-btn" data-toggle="collapse" /></li>
        <li class="col-sm-4 col-xs-4 text-center" style="padding-right: 0px !important; padding-left: 0px !important;
            padding-top: 12px;">
            <telerik:RadComboBox ID="ddlPageCount" Width="105" Font-Size="10" runat="server"
                AutoPostBack="true" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged">
            </telerik:RadComboBox>
        </li>
    </ul>
    <control:Nav ID="NavList" runat="server"></control:Nav>
</asp:Content>
