<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_PM_UserInfoWebUIAdd.aspx.cs" Inherits="T_PM_UserInfoWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">用户信息编辑</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
    <script type="text/javascript">
        function OpenEditor() {
       window.location='T_PM_UserInfoWebUIAdd.aspx?a=e<%=AndChar%>ObjectID=<%=ObjectID.Text%>';
        }
        function OpenCopyEditor() {
            window.location = 'T_PM_UserInfoWebUIAdd.aspx?a=c<%=AndChar%>ObjectID=<%=ObjectID.Text%>';
        }
    </script>
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
              <div id="AddFromDoc" runat="server">
                <div class="title">
                  <div class="bar">
                    <div class="lefttitle">
                      用户信息导入
                    </div>
                  </div>
                </div>
                <div class="main">
                  <div class="content" id="InfoFromDoc_Area" runat="server">
                    <div class="field">
                      <div class="fieldname">
                        导入文件
                      </div>
                      <div class="redstar">*</div>
                    </div>
                    <div class="fieldinput">
                      <asp:TextBox ID="InfoFromDoc" runat="server" CssClass="input"></asp:TextBox>
                    </div>
                    <div class="fieldnote" id="InfoFromDoc_Note" runat="server">
                    </div>
                  </div>
                </div>
                <div class="operation">
                  <center>
                    <table>
                      <tr>
                        <td>
                          <asp:Button Text="导入数据" ID="btnInfoFromDS" runat="server" CssClass="button" OnClick="btnInfoFromDS_Click" />
                          <asp:Button Text="导入文件" ID="btnInfoFromDoc" runat="server" CssClass="button" OnClick="btnInfoFromDoc_Click" />
                          <asp:Button Text="批量导入" ID="btnInfoFromDocBatch" runat="server" CssClass="button" OnClick="btnInfoFromDocBatch_Click" Visible="false" />
                          <asp:Button Text="取消" ID="btnInfoFromDocCancel" runat="server" CssClass="button" OnClick="btnInfoFromDocCancel_Click" />
                          <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                        </td>
                      </tr>
                    </table>
                  </center>
                </div>
              </div>
            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            用户信息 
                        </div>
                    </div>
                </div>
                <div class="operation">
                    <center>
                        <table>
                            <tr>
                                <td>
                    <input type="button" id ="btnEditItem" runat ="server" value="修改" onclick="OpenEditor();" class="button" />
                                </td>
                                <td>

                                </td>
                                <td>
                                    <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />
                                </td>
                                <td>

                                </td>
                                <td>
                                    <input type="reset" id="btnReset" runat="server"  value="重新填写" class="button"  Visible = "false"/>
                                </td>
                                <td>
                                   <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />
                                </td>
                            </tr>
                        </table>
                    </center>
                </div>
                </div>
                <div class="main">
                     <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                     <div  id= "ControlContainer" runat="server">

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
  
                     <div class="content" id="XB_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          性别
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="XB" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="XB_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SFZH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          身份证号
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SFZH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SFZH_Note" runat="server">
                                      
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
  
                     <div class="content" id="MZ_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          民族
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="MZ" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="MZ_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SJH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          手机
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SJH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SJH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="ZZMM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          政治面貌
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="ZZMM" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="ZZMM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="BGDH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          办公电话
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="BGDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="BGDH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="Password_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          密码
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="Password" runat="server" CssClass="input"></asp:TextBox>
                             请再次输入：
                             <asp:TextBox ID="PasswordConfirm" runat="server" CssClass="input"></asp:TextBox> 不需修改请留空
                                                 
                         </div><div class="fieldnote" id="Password_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="JTDH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          家庭电话
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="JTDH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="JTDH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="Email_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          Email
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="Email" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="Email_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="UserStatus_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          用户状态
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:DropDownList ID="UserStatus" runat="server" CssClass="input"></asp:DropDownList>
                                                 
                         </div><div class="fieldnote" id="UserStatus_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="QQH_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          QQ
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="QQH" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="QQH_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="vcode_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          验证码
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="vcode" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="vcode_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="LoginTime_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          登录时间
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
                                          登录IP
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
                                          上次时间
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

                </div>
                </div>
            </div>
        </center>
</asp:Content>

