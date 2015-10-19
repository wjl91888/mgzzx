<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_PM_UserInfoWebUIDetail.aspx.cs" Inherits="App.T_PM_UserInfoWebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    �û���Ϣ
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
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserNickName"), null)%></h4>
            </div>
    
            <div id="UserIDContainer" runat="server" class="row">
                <div id="UserIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û����</div>
                <div id="UserIDContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserID"), null)%>
                
                </div>
            </div>
        
            <div id="UserLoginNameContainer" runat="server" class="row">
                <div id="UserLoginNameCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û���</div>
                <div id="UserLoginNameContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserLoginName"), null)%>
                
                </div>
            </div>
        
            <div id="UserGroupIDContainer" runat="server" class="row">
                <div id="UserGroupIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û���</div>
                <div id="UserGroupIDContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "UserGroupID_T_PM_UserGroupInfo_UserGroupName")%>
        
                </div>
            </div>
        
            <div id="SubjectIDContainer" runat="server" class="row">
                <div id="SubjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">������λ</div>
                <div id="SubjectIDContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "SubjectID_T_BM_DWXX_DWMC")%>
        
                </div>
            </div>
        
            <div id="UserNickNameContainer" runat="server" class="row">
                <div id="UserNickNameCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="UserNickNameContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "UserNickName"), null)%>
                
                </div>
            </div>
        
            <div id="XBContainer" runat="server" class="row">
                <div id="XBCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�Ա�</div>
                <div id="XBContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "XB_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="MZContainer" runat="server" class="row">
                <div id="MZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="MZContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "MZ_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="ZZMMContainer" runat="server" class="row">
                <div id="ZZMMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">������ò</div>
                <div id="ZZMMContent" runat="server" class="col-xs-9">
        
                    <%# DataBinder.Eval(Container.DataItem, "ZZMM_Dictionary_MC")%>
        
                </div>
            </div>
        
            <div id="SFZHContainer" runat="server" class="row">
                <div id="SFZHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">���֤��</div>
                <div id="SFZHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFZH"), null)%>
                
                </div>
            </div>
        
            <div id="SJHContainer" runat="server" class="row">
                <div id="SJHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ֻ�</div>
                <div id="SJHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SJH"), null)%>
                
                </div>
            </div>
        
            <div id="BGDHContainer" runat="server" class="row">
                <div id="BGDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�칫�绰</div>
                <div id="BGDHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGDH"), null)%>
                
                </div>
            </div>
        
            <div id="JTDHContainer" runat="server" class="row">
                <div id="JTDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ͥ�绰</div>
                <div id="JTDHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JTDH"), null)%>
                
                </div>
            </div>
        
            <div id="EmailContainer" runat="server" class="row">
                <div id="EmailCaption" runat="server" class="fontbold col-xs-3 paddingleft0">Email</div>
                <div id="EmailContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "Email"), null)%>
                
                </div>
            </div>
        
            <div id="QQHContainer" runat="server" class="row">
                <div id="QQHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">QQ</div>
                <div id="QQHContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QQH"), null)%>
                
                </div>
            </div>
        
            <div id="LoginTimeContainer" runat="server" class="row">
                <div id="LoginTimeCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼ʱ��</div>
                <div id="LoginTimeContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LoginTime"), "yy-MM-dd HH:mm:ss")%>
                
                </div>
            </div>
        
            <div id="LastLoginIPContainer" runat="server" class="row">
                <div id="LastLoginIPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼IP</div>
                <div id="LastLoginIPContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LastLoginIP"), null)%>
                
                </div>
            </div>
        
            <div id="LastLoginDateContainer" runat="server" class="row">
                <div id="LastLoginDateCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ϴ�ʱ��</div>
                <div id="LastLoginDateContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LastLoginDate"), "yy-MM-dd HH:mm:ss")%>
                
                </div>
            </div>
        
            <div id="LoginTimesContainer" runat="server" class="row">
                <div id="LoginTimesCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼����</div>
                <div id="LoginTimesContent" runat="server" class="col-xs-9">
        
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LoginTimes"), null)%>
                
                </div>
            </div>
        

        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="�޸�" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>


