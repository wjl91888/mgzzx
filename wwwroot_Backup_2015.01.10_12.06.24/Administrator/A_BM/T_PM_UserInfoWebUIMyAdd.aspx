<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_PM_UserInfoWebUIMyAdd.aspx.cs" Inherits="T_PM_UserInfoWebUIMyAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">用户信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_PM_UserInfo" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_PM_UserInfo" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_PM_UserInfo" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>

            <div id="addpage" runat="server" class="addpage">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            用户信息 
                        </div>
                    </div>
                </div>
                <div class="main">
                     <asp:Literal ID="MessageBox" runat="server"></asp:Literal>

                     <div class="content" id="ObjectID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="ObjectID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="ObjectID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="UserID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          用户编号
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="UserID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="UserID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="UserLoginName_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          用户名
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="UserLoginName" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="UserLoginName_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="UserGroupID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          用户组
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <RICH:CheckBoxListEx ID="UserGroupID" runat="server" CssClass="input"></RICH:CheckBoxListEx>
                                                 
                         </div><div class="fieldnote" id="UserGroupID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SubjectID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          所属单位
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="SubjectID" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="SubjectID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="UserNickName_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          姓名
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="UserNickName" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="UserNickName_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="Password_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          密码
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="Password" runat="server" CssClass="input"></asp:TextBox>
                             <br />请再次输入：<br />
                             <asp:TextBox ID="PasswordConfirm" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="Password_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="LoginTime_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          本次登录时间
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="LoginTime" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="LoginTime_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="LastLoginIP_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          上次登陆IP
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="LastLoginIP" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="LastLoginIP_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="LastLoginDate_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          上次登录时间
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="LastLoginDate" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="LastLoginDate_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="LoginTimes_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          登录次数
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="LoginTimes" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="LoginTimes_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                </div>
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="T_PM_UserInfoTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="T_PM_UserInfoMultiPage" >
                    <Tabs>
                        <telerik:RadTab Visible="false" runat = "server" Value="1" PageViewID="PageView1"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="2" PageViewID="PageView2"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="3" PageViewID="PageView3"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="4" PageViewID="PageView4"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="5" PageViewID="PageView5"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="6" PageViewID="PageView6"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="7" PageViewID="PageView7"></telerik:RadTab>
                        <telerik:RadTab Visible="false" runat = "server" Value="8" PageViewID="PageView8"></telerik:RadTab>
                    </Tabs>
                </telerik:RadTabStrip>
                <telerik:RadMultiPage CssClass="tab_table" ID="T_PM_UserInfoMultiPage" runat="server" SelectedIndex="0">
                    <telerik:RadPageView ID="PageView1" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView2" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView3" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView4" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView5" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView6" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView7" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                    <telerik:RadPageView ID="PageView8" Visible="false" runat="server">

                    <div class="clearboth"></div>
                    </telerik:RadPageView>
                </telerik:RadMultiPage>
                <!-- 相关表批量添加 -->

                <div class="operation">
                    <center>
                        <table>
                            <tr>
                                <td>
                                    <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />
                                </td>
                                <td>

                                </td>
                                <td>
                                    <input type="reset" value="重新填写" class="button" />
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

