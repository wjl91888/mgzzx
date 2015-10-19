<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_BM_DWXXWebUIDetail.aspx.cs" Inherits="App.T_BM_DWXXWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    单位信息
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWMC"), null)%></h4>
            </div>
    
            <div id="DWBHContainer" runat="server" class="row">
                <div id="DWBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">单位编号</div>
                <div id="DWBHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWBH"), null)%>
                
                </div>
            </div>
        
            <div id="DWMCContainer" runat="server" class="row">
                <div id="DWMCCaption" runat="server" class="fontbold col-xs-3 paddingleft0">单位名称</div>
                <div id="DWMCContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWMC"), null)%>
                
                </div>
            </div>
        
            <div id="SJDWBHContainer" runat="server" class="row">
                <div id="SJDWBHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">上级单位</div>
                <div id="SJDWBHContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SJDWBH_T_BM_DWXX_DWMC")%>
        
                </div>
            </div>
        
            <div id="DZContainer" runat="server" class="row">
                <div id="DZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">地址</div>
                <div id="DZContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DZ"), null)%>
                
                </div>
            </div>
        
            <div id="YBContainer" runat="server" class="row">
                <div id="YBCaption" runat="server" class="fontbold col-xs-3 paddingleft0">邮编</div>
                <div id="YBContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YB"), null)%>
                
                </div>
            </div>
        
            <div id="LXBMContainer" runat="server" class="row">
                <div id="LXBMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">联系部门</div>
                <div id="LXBMContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXBM"), null)%>
                
                </div>
            </div>
        
            <div id="LXDHContainer" runat="server" class="row">
                <div id="LXDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">联系电话</div>
                <div id="LXDHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXDH"), null)%>
                
                </div>
            </div>
        
            <div id="EmailContainer" runat="server" class="row">
                <div id="EmailCaption" runat="server" class="fontbold col-xs-3 paddingleft0">Email</div>
                <div id="EmailContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "Email"), null)%>
                
                </div>
            </div>
        
            <div id="LXRContainer" runat="server" class="row">
                <div id="LXRCaption" runat="server" class="fontbold col-xs-3 paddingleft0">联系人</div>
                <div id="LXRContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXR"), null)%>
                
                </div>
            </div>
        
            <div id="SJContainer" runat="server" class="row">
                <div id="SJCaption" runat="server" class="fontbold col-xs-3 paddingleft0">手机</div>
                <div id="SJContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SJ"), null)%>
                
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


