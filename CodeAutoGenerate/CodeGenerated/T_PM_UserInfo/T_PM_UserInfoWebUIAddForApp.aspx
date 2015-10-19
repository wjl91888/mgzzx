<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="T_PM_UserInfoWebUIAdd.aspx.cs" Inherits="App.T_PM_UserInfoWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">�û���Ϣ�༭</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
    <telerik:RadAjaxManagerProxy ID="ramT_PM_UserInfo" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ramT_PM_UserInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>

        </AjaxSettings>
    </telerik:RadAjaxManagerProxy>
    <telerik:RadAjaxLoadingPanel ID="ralpT_PM_UserInfo" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <div id="AppAddPage" runat="server">
            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

            <div id="ObjectIDContainer" runat="server" class="row">
                <div id="ObjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0"></div>
                <div id="ObjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserIDContainer" runat="server" class="row">
                <div id="UserIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û����</div>
                <div id="UserIDContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="UserID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserLoginNameContainer" runat="server" class="row">
                <div id="UserLoginNameCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û���</div>
                <div id="UserLoginNameContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="UserLoginName" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserGroupIDContainer" runat="server" class="row">
                <div id="UserGroupIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û���</div>
                <div id="UserGroupIDContent" runat="server" class="col-xs-9">
                                
                             <RICH:CheckBoxListEx ID="UserGroupID" runat="server" CssClass="input"></RICH:CheckBoxListEx>
                                                 
                </div>
            </div>
  
            <div id="SubjectIDContainer" runat="server" class="row">
                <div id="SubjectIDCaption" runat="server" class="fontbold col-xs-3 paddingleft0">������λ</div>
                <div id="SubjectIDContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="SubjectID" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="XBContainer" runat="server" class="row">
                <div id="XBCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�Ա�</div>
                <div id="XBContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="XB" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="SFZHContainer" runat="server" class="row">
                <div id="SFZHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">���֤��</div>
                <div id="SFZHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SFZH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserNickNameContainer" runat="server" class="row">
                <div id="UserNickNameCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="UserNickNameContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="UserNickName" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="MZContainer" runat="server" class="row">
                <div id="MZCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="MZContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="MZ" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="SJHContainer" runat="server" class="row">
                <div id="SJHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ֻ�</div>
                <div id="SJHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="SJH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="ZZMMContainer" runat="server" class="row">
                <div id="ZZMMCaption" runat="server" class="fontbold col-xs-3 paddingleft0">������ò</div>
                <div id="ZZMMContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="ZZMM" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="BGDHContainer" runat="server" class="row">
                <div id="BGDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�칫�绰</div>
                <div id="BGDHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="BGDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="PasswordContainer" runat="server" class="row">
                <div id="PasswordCaption" runat="server" class="fontbold col-xs-3 paddingleft0">����</div>
                <div id="PasswordContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="Password" runat="server" CssClass="input"></asp:TextBox>
                             ���ٴ����룺
                             <asp:TextBox ID="PasswordConfirm" runat="server" CssClass="input"></asp:TextBox> �����޸�������
                                                 
                </div>
            </div>
  
            <div id="JTDHContainer" runat="server" class="row">
                <div id="JTDHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��ͥ�绰</div>
                <div id="JTDHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="JTDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="EmailContainer" runat="server" class="row">
                <div id="EmailCaption" runat="server" class="fontbold col-xs-3 paddingleft0">Email</div>
                <div id="EmailContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="Email" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="UserStatusContainer" runat="server" class="row">
                <div id="UserStatusCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�û�״̬</div>
                <div id="UserStatusContent" runat="server" class="col-xs-9">
                                
                             <asp:DropDownList ID="UserStatus" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                </div>
            </div>
  
            <div id="QQHContainer" runat="server" class="row">
                <div id="QQHCaption" runat="server" class="fontbold col-xs-3 paddingleft0">QQ</div>
                <div id="QQHContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="QQH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="vcodeContainer" runat="server" class="row">
                <div id="vcodeCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��֤��</div>
                <div id="vcodeContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="vcode" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="lcodeContainer" runat="server" class="row">
                <div id="lcodeCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼��</div>
                <div id="lcodeContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="lcode" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LoginTimeContainer" runat="server" class="row">
                <div id="LoginTimeCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼ʱ��</div>
                <div id="LoginTimeContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LoginTime" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LastLoginIPContainer" runat="server" class="row">
                <div id="LastLoginIPCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼IP</div>
                <div id="LastLoginIPContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LastLoginIP" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LastLoginDateContainer" runat="server" class="row">
                <div id="LastLoginDateCaption" runat="server" class="fontbold col-xs-3 paddingleft0">�ϴ�ʱ��</div>
                <div id="LastLoginDateContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LastLoginDate" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
            <div id="LoginTimesContainer" runat="server" class="row">
                <div id="LoginTimesCaption" runat="server" class="fontbold col-xs-3 paddingleft0">��¼����</div>
                <div id="LoginTimesContent" runat="server" class="col-xs-9">
                                
                             <asp:TextBox ID="LoginTimes" runat="server" CssClass="input"></asp:TextBox>
                                                 
                </div>
            </div>
  
        </div>
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
  <ul id="PageInfo" runat="server" class="nav  navbar-default">
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
      <asp:Button Text="����" ID="btnAddConfirm" runat="server" CssClass="btn btn-default navbar-btn" OnClick="btnSave_Click" />
    </li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
  </ul>
</asp:Content>

