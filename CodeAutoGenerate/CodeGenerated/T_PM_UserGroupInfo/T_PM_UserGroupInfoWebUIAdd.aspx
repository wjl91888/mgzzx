<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="T_PM_UserGroupInfoWebUIAdd.aspx.cs" Inherits="T_PM_UserGroupInfoWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">�û�����Ϣ�༭</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">
    table.<%=UserGroupContent.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_UserGroupContent_DesignBox { background-color: #ffffff !important;}    table.<%=UserGroupRemark.ClientID%>_OuterTable { background-color: #ffffff; }    .ctl00_MainContentPlaceHolder_UserGroupRemark_DesignBox { background-color: #ffffff !important;}
    </style>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmT_PM_UserGroupInfo" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_PM_UserGroupInfo" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_PM_UserGroupInfo" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            �û�����Ϣ 
                        </div>
                    </div>
                </div>
                <div class="operation">
                    <center>
                        <asp:Button Text="��������" ID="btnInfoFromDS" runat="server" CssClass="button" OnClick="btnInfoFromDS_Click" />
                        <asp:Button Text="Word����" ID="btnInfoFromDoc" runat="server" CssClass="button" OnClick="btnInfoFromDoc_Click" />
                        <asp:Button Text="����Word����" ID="btnInfoFromDocBatch" runat="server" CssClass="button" OnClick="btnInfoFromDocBatch_Click" Visible="false" />
                        <asp:Button Text="ȡ��" ID="btnInfoFromDocCancel" runat="server" CssClass="button" OnClick="btnInfoFromDocCancel_Click" />
                        <input type="button" id ="btnEditItem" runat ="server" value="�޸�" class="button" />

                        <asp:Button Text="����" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />

                        <input type="button" value="�رմ���" onclick="CloseWindow();" class="button" />
                    </center>
                </div>
                </div>
                <div class="main">
                     <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                     <div  id= "ImportControlContainer" runat="server">
                     <div class="content clearboth" id="InfoFromDoc_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">�����ļ�</div><div class="redstar">*</div>
                         </div>
                         <div class="fieldinput">
                                 <asp:TextBox ID="InfoFromDoc" runat="server" CssClass="input widthfull"></asp:TextBox>
                         </div>
                         <div class="fieldnote" id="InfoFromDoc_Note" runat="server"></div>
                     </div>
                     </div>
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
  
                     <div class="content" id="UserGroupID_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          �û�����
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="UserGroupID" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="UserGroupID_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="UserGroupName_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          �û�������
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="UserGroupName" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="UserGroupName_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="UserGroupContent_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ����
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <FTB:FreeTextBox ID="UserGroupContent" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                         </div><div class="fieldnote" id="UserGroupContent_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="UserGroupRemark_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ��ע
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <FTB:FreeTextBox ID="UserGroupRemark" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></FTB:FreeTextBox>
                                                 
                         </div><div class="fieldnote" id="UserGroupRemark_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content clearboth" id="DefaultPage_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ϵͳĬ��ҳ
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="DefaultPage" runat="server" CssClass="input widthfull"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="DefaultPage_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="UpdateDate_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ����ʱ��
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="UpdateDate" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="UpdateDate_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="T_PM_UserGroupInfoTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="T_PM_UserGroupInfoMultiPage" >
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
                <telerik:RadMultiPage CssClass="tab_table" ID="T_PM_UserGroupInfoMultiPage" runat="server" SelectedIndex="0">
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
                <!-- ��ر��������� -->

                </div>
                </div>
            </div>
        </center>
</asp:Content>
