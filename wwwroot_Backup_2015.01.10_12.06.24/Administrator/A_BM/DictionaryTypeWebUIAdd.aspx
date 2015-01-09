<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="DictionaryTypeWebUIAdd.aspx.cs" Inherits="DictionaryTypeWebUIAdd" %>
<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">�ֵ����ͱ༭</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
    <style type="text/css">

    </style>
    <script type="text/javascript">
        function OpenEditor() {
       window.location='DictionaryTypeWebUIAdd.aspx?a=e<%=AndChar%>ObjectID=<%=ObjectID.Text%>';
        }
        function OpenCopyEditor() {
            window.location = 'DictionaryTypeWebUIAdd.aspx?a=c<%=AndChar%>ObjectID=<%=ObjectID.Text%>';
        }
    </script>
</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadScriptManager ID="rsmDictionaryType" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramDictionaryType" runat="server">
        <AjaxSettings>
  
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpDictionaryType" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>

            <div id="addpage" runat="server" class="addpage">
                <div class="toptoolsbar">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            �ֵ����� 
                        </div>
                    </div>
                </div>
                <div class="operation">
                    <center>
                        <table>
                            <tr>
                                <td>
                    <input type="button" id ="btnEditItem" runat ="server" value="�޸�" onclick="OpenEditor();" class="button" />
                                </td>
                                <td>

                                </td>
                                <td>
                                    <asp:Button Text="����" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />
                                </td>
                                <td>

                                </td>
                                <td>
                                    <input type="reset" id="btnReset" runat="server"  value="������д" class="button"  Visible = "false"/>
                                </td>
                                <td>
                                   <input type="button" value="�رմ���" onclick="CloseWindow();" class="button" />
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
  
                     <div class="content" id="DM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ���ʹ���
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="DM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="DM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="MC_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ��������
                             </div>
                             <div class="redstar">*</div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="MC" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="MC_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                     <div class="content" id="SM_Area" runat="server">
                         <div class="field">
                             <div class="fieldname">
                                          ˵��
                             </div>
                             <div class="redstar"></div>
                         </div>
                         <div class="fieldinput"><div>
                                
                             <asp:TextBox ID="SM" runat="server" CssClass="input"></asp:TextBox>
                                                 
                         </div><div class="fieldnote" id="SM_Note" runat="server">
                                      
                         </div>
                         </div>
                     </div>
  
                <div class="clearboth"></div>
                <telerik:RadTabStrip ID="DictionaryTypeTabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="DictionaryTypeMultiPage" >
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
                <telerik:RadMultiPage CssClass="tab_table" ID="DictionaryTypeMultiPage" runat="server" SelectedIndex="0">
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
