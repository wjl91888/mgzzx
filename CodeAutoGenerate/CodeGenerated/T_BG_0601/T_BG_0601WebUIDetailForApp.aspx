<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BG_0601WebUIDetail.aspx.cs" Inherits="App.T_BG_0601WebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    公共信息
</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>


<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
<div id="AppDetailPage">
    <asp:Repeater ID="rptDetail" runat="server">
        <ItemTemplate>
            <div class="page-header">
                <h4>
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)%></h4>
            </div>
    
            <div id="BTContainer" runat="server" class="row">
                <div id="BTCaption" runat="server" class="fontbold col-xs-3 paddingleft0">标题</div>
                <div id="BTContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)%>
                
                </div>
            </div>
        
            <div id="FBLMContainer" runat="server" class="row">
                <div id="FBLMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布栏目</div>
                <div id="FBLMContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM")%>
        
                </div>
            </div>
        
            <div id="FBBMContainer" runat="server" class="row">
                <div id="FBBMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布部门</div>
                <div id="FBBMContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "FBBM_T_BM_DWXX_DWMC")%>
        
                </div>
            </div>
        
            <div id="XXTPDZContainer" runat="server" class="row">
                <div id="XXTPDZCaption" runat="server" class="fontbold col-xs-12 paddingleft0">信息图片</div>
                <div id="XXTPDZContent" runat="server" class="col-xs-12">
        
                    <%# DataBinder.Eval(Container.DataItem, "XXTPDZ") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "XXTPDZ") + "' />"%>
                
                </div>
            </div>
        
            <div id="XXNRContainer" runat="server" class="row">
                <div id="XXNRCaption" runat="server" class="fontbold col-xs-12 paddingleft0">信息内容</div>
                <div id="XXNRContent" runat="server" class="col-xs-12">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XXNR"), null)%>
                
                </div>
            </div>
        
            <div id="FJXZDZContainer" runat="server" class="row">
                <div id="FJXZDZCaption" runat="server" class="fontbold col-xs-12 paddingleft0">附件</div>
                <div id="FJXZDZContent" runat="server" class="col-xs-12">
        
                    <control:FilesList ID="FJXZDZ" runat="server" CssClass="input" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "FJXZDZ")%>'></control:FilesList>
                
                </div>
            </div>
        
            <div id="FBRJGHContainer" runat="server" class="row">
                <div id="FBRJGHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布人</div>
                <div id="FBRJGHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "FBRJGH_T_PM_UserInfo_UserNickName")%>
        
                </div>
            </div>
        
            <div id="FBSJRQContainer" runat="server" class="row">
                <div id="FBSJRQCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布时间</div>
                <div id="FBSJRQContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), "yy-MM-dd")%>
                
                </div>
            </div>
        
            <div id="FBIPContainer" runat="server" class="row">
                <div id="FBIPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">发布IP</div>
                <div id="FBIPContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBIP"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="修改" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


