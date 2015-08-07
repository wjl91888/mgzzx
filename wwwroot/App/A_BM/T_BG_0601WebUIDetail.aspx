<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master"
    EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0601WebUIDetail.aspx.cs"
    Inherits="App.T_BG_0601WebUIDetail" %>

<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder"
    runat="server">
    公共信息详情</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
<div id="AppDetailPage">
    <asp:Repeater ID="rptDetail" runat="server">
        <ItemTemplate>
            <div class="page-header">
                <h4>
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)%></h4>
            </div>
            <div class="fontbold col-xs-4 col-sm-3 paddingleft0">
                发布栏目
            </div>
            <div class="col-xs-8 col-sm-3">
                <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM")%>
            </div>
            <div class="fontbold col-xs-4 col-sm-3 paddingleft0">
                发布单位
            </div>
            <div class="col-xs-8 col-sm-3">
                <%# DataBinder.Eval(Container.DataItem, "FBBM_T_BM_DWXX_DWMC")%>
            </div>
            <div class="fontbold col-xs-12 col-sm-12 paddingleft0">
                信息图片
            </div>
            <div class="col-xs-12 col-sm-12">
                <%# DataBinder.Eval(Container.DataItem, "XXTPDZ") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "XXTPDZ") + "' />"%>
            </div>
            <div class="fontbold col-xs-12 col-sm-12 paddingleft0">
                信息内容
            </div>
            <div class="col-xs-12 col-sm-12">
                <%# GetValue(DataBinder.Eval(Container.DataItem, "XXNR"), null)%>
            </div>
            <div class="fontbold col-xs-12 col-sm-12 paddingleft0">
                附件
            </div>
            <div class="col-xs-12 col-sm-12">
                <control:FilesList ID="FJXZDZ" runat="server" CssClass="input" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "FJXZDZ")%>'>
                </control:FilesList>
            </div>
            <div class="fontbold col-xs-4 col-sm-3 paddingleft0">
                发布人
            </div>
            <div class="col-xs-8 col-sm-3">
                <%# DataBinder.Eval(Container.DataItem, "FBRJGH_T_PM_UserInfo_UserNickName")%>
            </div>
            <div class="fontbold col-xs-4 col-sm-3 paddingleft0">
                发布时间
            </div>
            <div class="col-xs-8 col-sm-3">
                <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), "yy-MM-dd")%>
            </div>
            <div class="fontbold col-xs-4 col-sm-3 paddingleft0">
                IP地址
            </div>
            <div class="col-xs-8 col-sm-3">
                <%# GetValue(DataBinder.Eval(Container.DataItem, "FBIP"), null)%>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="NavContainer" ContentPlaceHolderID="NavContainerPlaceHolder" runat="server">
</asp:Content>

