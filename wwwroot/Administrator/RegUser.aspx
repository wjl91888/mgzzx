<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation="false"
    AutoEventWireup="true" CodeFile="RegUser.aspx.cs" Inherits="RegUser" %>

<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder"
    runat="server">
    用户注册</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
        
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_PM_UserInfo" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_PM_UserInfo" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="addpage" LoadingPanelID="ralpT_PM_UserInfo" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_PM_UserInfo" runat="server" Skin="Vista">
    </telerik:RadAjaxLoadingPanel>
    <center>
        <div id="addpage" runat="server" class="addpage" style="width:450px;">
            <div class="title">
                <div class="bar">
                    <div class="lefttitle">
                        用户注册
                    </div>
                </div>
            </div>
            <div class="main">
                <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                <div class="content" id="ObjectID_Area" runat="server">
                    <div class="field">
                        <div class="fieldname">
                        </div>
                        <div class="redstar">
                        </div>
                    </div>
                    <div class="fieldinput">
                        <div>
                            <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                        </div>
                        <div class="fieldnote" id="ObjectID_Note" runat="server">
                        </div>
                    </div>
                </div>
                <div class="content" id="UserID_Area" runat="server">
                    <div class="field">
                        <div class="fieldname">
                            用户编号
                        </div>
                        <div class="redstar">
                            *</div>
                    </div>
                    <div class="fieldinput">
                        <div>
                            <asp:TextBox ID="UserID" runat="server" CssClass="input"></asp:TextBox>
                        </div>
                        <div class="fieldnote" id="UserID_Note" runat="server">
                        </div>
                    </div>
                </div>
                <div class="content" id="UserLoginName_Area" runat="server" style="width:100%;">
                    <div class="field">
                        <div class="fieldname">
                            登录名
                        </div>
                        <div class="redstar">
                            *</div>
                    </div>
                    <div class="fieldinput">
                        <div>
                            <asp:TextBox ID="UserLoginName" runat="server" CssClass="input" Width="200"></asp:TextBox>
                        </div>
                        <div class="fieldnote" id="UserLoginName_Note" runat="server" style="display:inline-block;">
                        请输入有效的Email作为登录用户名，请正确填写，注册后不可更改。
                        </div>
                    </div>
                </div>
                <div class="clearboth">
                </div>
                <div class="content" id="Password_Area" runat="server" style="width:100%;">
                    <div class="field">
                        <div class="fieldname">
                            登录密码
                        </div>
                        <div class="redstar">
                            *</div>
                    </div>
                    <div class="fieldinput">
                        <div>
                            <asp:TextBox ID="Password" runat="server" CssClass="input" Width="200"></asp:TextBox>
                            <br />
                            请再次输入：<br />
                            <asp:TextBox ID="PasswordConfirm" runat="server" CssClass="input" Width="200"></asp:TextBox>
                        </div>
                        <div class="fieldnote" id="Password_Note" runat="server">
                        </div>
                    </div>
                </div>
                <div class="clearboth">
                </div>
                <div class="content" id="UserNickName_Area" runat="server" style="width:100%;">
                    <div class="field">
                        <div class="fieldname">
                            姓名
                        </div>
                        <div class="redstar">
                            *</div>
                    </div>
                    <div class="fieldinput">
                        <div>
                            <asp:TextBox ID="UserNickName" runat="server" CssClass="input" Width="200"></asp:TextBox>
                        </div>
                        <div class="fieldnote" id="UserNickName_Note" runat="server" style="display:inline-block;">
                        请正确填写，注册后不可更改。
                        </div>
                    </div>
                </div>
                <div class="content" id="SubjectID_Area" runat="server" style="width:100%;">
                    <div class="field">
                        <div class="fieldname">
                            所属单位
                        </div>
                        <div class="redstar">
                            *</div>
                    </div>
                    <div class="fieldinput">
                        <div>
                            <asp:DropDownList ID="SubjectID" runat="server" CssClass="input" Width="200">
                            </asp:DropDownList>
                        </div>
                        <div class="fieldnote" id="SubjectID_Note" runat="server" style="display:inline-block;">
                        请正确填写，注册后不可更改，如是高校用户找不到所在学校，<br />请先联系管理员。
                        </div>
                    </div>
                </div>
            </div>
            <div class="clearboth">
            </div>
            <div class="operation">
                <center>
                    <table>
                        <tr>
                            <td>
                                <asp:Button Text="提交" ID="btnAddConfirm" runat="server" CssClass="button"
                                    OnClick="btnSave_Click"/>
                            </td>
                            <td>
                            </td>
                            <td>
                                <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                            </td>
                        </tr>
                    </table>
                </center>
            </div>
        </div>
    </center>
</asp:Content>
