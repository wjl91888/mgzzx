<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_PM_UserGroupInfoWebUIDetail.aspx.cs" Inherits="App.T_PM_UserGroupInfoWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    �û�����Ϣ
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupName"), null)%></h4>
            </div>
    
            <div id="UserGroupIDContainer" runat="server" class="row">
                <div id="UserGroupIDCaption" runat="server" class="fontbold col-xs- paddingleft0">�û�����</div>
                <div id="UserGroupIDContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupID"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupNameContainer" runat="server" class="row">
                <div id="UserGroupNameCaption" runat="server" class="fontbold col-xs- paddingleft0">�û�������</div>
                <div id="UserGroupNameContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupName"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupContentContainer" runat="server" class="row">
                <div id="UserGroupContentCaption" runat="server" class="fontbold col-xs- paddingleft0">����</div>
                <div id="UserGroupContentContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupContent"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupRemarkContainer" runat="server" class="row">
                <div id="UserGroupRemarkCaption" runat="server" class="fontbold col-xs- paddingleft0">��ע</div>
                <div id="UserGroupRemarkContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserGroupRemark"), null)%>
                
                </div>
            </div>
        
            <div id="DefaultPageContainer" runat="server" class="row">
                <div id="DefaultPageCaption" runat="server" class="fontbold col-xs- paddingleft0">ϵͳĬ��ҳ</div>
                <div id="DefaultPageContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DefaultPage"), null)%>
                
                </div>
            </div>
        
            <div id="UpdateDateContainer" runat="server" class="row">
                <div id="UpdateDateCaption" runat="server" class="fontbold col-xs- paddingleft0">����ʱ��</div>
                <div id="UpdateDateContent" runat="server" class="col-xs-">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UpdateDate"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>


