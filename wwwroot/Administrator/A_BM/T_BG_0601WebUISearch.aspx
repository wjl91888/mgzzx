<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" validateRequest="false" AutoEventWireup="true" CodeFile="T_BG_0601WebUISearch.aspx.cs" Inherits="T_BG_0601WebUISearch" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">������Ϣ��ѯ</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">
    <script language="javascript" type="text/javascript">
    function EditorWindowClose(sender, eventArgs) {
        RefreshGrid();
    }
    function RefreshGrid() {
        $find("<%= ramT_BG_0601.ClientID %>").ajaxRequest("Refresh");
    }
    $(document).ready(function () {
        $(".needrefresh").on("change", function () { RefreshGrid(); });
        $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });
    });
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadScriptManager ID="rsmT_BG_0601" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BG_0601" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOperate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageSize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ramT_BG_0601">
                <UpdatedControls>
  
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
  
            <telerik:AjaxSetting AjaxControlID="btnAdvanceSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                </UpdatedControls>
            </telerik:AjaxSetting>    
            <telerik:AjaxSetting AjaxControlID="btnShowAdvanceSearchItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>    
            <telerik:AjaxSetting AjaxControlID="btnShowSimpleSearchItem">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnSaveFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="FilterReportList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BG_0601" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BG_0601" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
        <center>
            <table border="0" cellpadding="0" cellspacing="0" width="100%">
            <tr>
                <td valign="top" id="tddivtree">
                <div id="divtree" class="width240">
            <div id="advancesearchpage" runat="server" class="advancesearchpage">
                <div id="FilterReportContainer" runat="server" Visible="false">
                <div class="main">
                    <div class="block">
                        <ul>
                            <li>��ѯ����</li>
                        </ul>
                    </div>
                    <div class="content" id="FilterReportList_Area" runat="server">
                        <div class="field">
                            <div class="fieldname">�����б�</div>
                        </div>
                        <div class="fieldinput">
                            <asp:DropDownList ID="FilterReportList" runat="server" DataTextField="BGMC" CssClass="input" DataValueField="ObjectID" 
                            OnSelectedIndexChanged="FilterReportList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="content" id="FilterReportName_Area" runat="server">
                        <div class="field">
                            <div class="fieldname">��������</div>
                        </div>
                        <div class="fieldinput">
                            <asp:TextBox ID="FilterReportName" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="input needrefresh"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="operation alignright width100per" id="FilterReport" runat="server" >
                    <asp:Button Text="ɾ��" ID="btnDeleteFilterReport" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="button floatright" OnClick="btnDeleteFilterReport_Click" />
                    <asp:Button Text="����" ID="btnSaveFilterReport" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="button floatright" OnClick="btnSaveFilterReport_Click" />
                    <asp:Button Text="���" ID="btnReset" runat="server" CssClass="button floatright" OnClick="btnReset_Click" />
                    <div class="clearboth"></div>
                </div>
                </div>
                <div class="main">
                    <div class="block">
                        <ul>
                            <li>��ѯ����</li>
                        </ul>
                    </div>

                       <div class="content" id="BT_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ����
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="BT" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content clearboth clearboth" id="FBLM_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ������Ŀ
                               </div>
                           </div>
                           <div class="fieldinput clearboth">
                                
                             <RICH:CheckBoxListEx ID="FBLM" runat="server" CssClass="input needrefresh"></RICH:CheckBoxListEx>
                                        
                           </div>
                           <div class="fieldinput alignright width100per">
                                   <asp:CheckBox ID="chkShowSubItemFBLM" runat="server" Text = "�����ӣ��¼���" Checked="true" CssClass="needrefresh" />
                                      
                           </div>
                       </div>
  
                       <div class="content clearboth" id="FBBM_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ��������
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="FBBM" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                           <div class="fieldinput alignright width100per">
                                   <asp:CheckBox ID="chkShowSubItemFBBM" runat="server" Text = "�����ӣ��¼���" Checked="true" CssClass="needrefresh" />
                                      
                           </div>
                       </div>
  
                       <div class="content" id="XXNR_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ��Ϣ����
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="XXNR" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                  
                           </div>
                       </div>
  
                       <div class="content clearboth" id="FBSJRQ_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ����ʱ��
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="FBSJRQ" runat="server" CssClass="input needrefresh" Visible = "False"></asp:TextBox>
                             </div><div class="fieldinput width100per alignright"><B>>=</B><asp:TextBox ID="FBSJRQBegin" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox><br/><B><=</B><asp:TextBox ID="FBSJRQEnd" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="FBH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ������
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="FBH" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="XXLX_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ��Ϣ����
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="XXLX" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="IsTop_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            �Ƿ��ö�
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="IsTop" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="IsBest_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            �Ƽ�
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="IsBest" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="FBRJGH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ������
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="FBRJGH" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                    <div id="ShowField_Area" runat="server"><div class="block">
                        <ul>
                            <li>�����ʾ�ֶ�</li>
                        </ul>
                    </div>
                
                   <div ID="chkShowFBH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFBH" runat="server"  CssClass="needrefresh" Text = "������" 
                                         Checked="false" />
                               <asp:TextBox ID="txtFBHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowBT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowBT" runat="server"  CssClass="needrefresh" Text = "����" 
                                         Checked="true" />
                               <asp:TextBox ID="txtBTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFBLM_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFBLM" runat="server"  CssClass="needrefresh" Text = "������Ŀ" 
                                         Checked="true" />
                               <asp:TextBox ID="txtFBLMColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFBBM_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFBBM" runat="server"  CssClass="needrefresh" Text = "��������" 
                                         Checked="true" />
                               <asp:TextBox ID="txtFBBMColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowXXLX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowXXLX" runat="server"  CssClass="needrefresh" Text = "��Ϣ����" 
                                         Checked="true" />
                               <asp:TextBox ID="txtXXLXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowIsTop_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowIsTop" runat="server"  CssClass="needrefresh" Text = "�Ƿ��ö�" 
                                         Checked="false" />
                               <asp:TextBox ID="txtIsTopColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowIsBest_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowIsBest" runat="server"  CssClass="needrefresh" Text = "�Ƽ�" 
                                         Checked="false" />
                               <asp:TextBox ID="txtIsBestColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFBRJGH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFBRJGH" runat="server"  CssClass="needrefresh" Text = "������" 
                                         Checked="false" />
                               <asp:TextBox ID="txtFBRJGHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFBSJRQ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFBSJRQ" runat="server"  CssClass="needrefresh" Text = "����ʱ��" 
                                         Checked="true" />
                               <asp:TextBox ID="txtFBSJRQColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFJXZDZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFJXZDZ" runat="server"  CssClass="needrefresh" Text = "����" 
                                         Checked="true" />
                               <asp:TextBox ID="txtFJXZDZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowXXZT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowXXZT" runat="server"  CssClass="needrefresh" Text = "��Ϣ״̬" 
                                         Checked="false" />
                               <asp:TextBox ID="txtXXZTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowTopSort_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowTopSort" runat="server"  CssClass="needrefresh" Text = "�ö����" 
                                         Checked="false" />
                               <asp:TextBox ID="txtTopSortColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFBIP_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFBIP" runat="server"  CssClass="needrefresh" Text = "����IP" 
                                         Checked="false" />
                               <asp:TextBox ID="txtFBIPColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                </div></div>
                <div class="operation" id="operation" runat="server">
                    <center>
                        <asp:Button Text="��ѯ" ID="btnAdvanceSearch" runat="server" CssClass="button floatright" OnClick="btnAdvanceSearch_Click" />
                        <asp:Button Text="�߼�����" ID="btnShowAdvanceSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowAdvanceSearchItem_Click" />
                        <asp:Button Text="�򵥽���" ID="btnShowSimpleSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowSimpleSearchItem_Click" />
                    </center>
                </div>
            </div>
                    </div>
                </td>
                <td valign="top" id="tdmiddleblock">
                    <div style="float: left; width: 10px; height: 100%; vertical-align: middle;" onclick="changeWin();" onmousemove="this.style.cursor='pointer';" onmouseout="this.style.cursor='';">
                        <table border="0" style="background-color: #efefef; height: 100%;">
                            <tr>
                                <td valign="middle">
                                    <img id="menuSwitch" height="12" alt="����" src="/App_Themes/Themes/Image/arrow_left.gif" width="8" border="0" />
                                </td>
                            </tr>
                        </table>
                    </div>
                </td>
                <td valign="top" width="100%">
            <div id="listpage" runat="server" class="listpage listpageleftposition">
               <div id="toptoolsbar" runat="server" class="toptoolsbar listpageleftposition">
                <div class="title">
                    <div class="bar">
                        <div class="lefttitle">
                            <asp:Literal ID="PageTitle" runat="server"></asp:Literal>
                        </div>
                    </div>
                </div>
                <asp:Literal ID="MessageBox" runat="server"></asp:Literal>
                <div id="SearchPageTopButtonBar" runat="server" class="quicksearch">
                    <input type="button" id="btnAddItem" runat="server" value="���" class="button" />

                     <input type="button" id="btnStatisticItem" runat="server" value="ͳ��" class="button" />
                     <input type="button" value="�ر�" onclick="CloseWindow();" class="button displaynone" />
                     <asp:DropDownList runat="server" ID="ddlExportFileFormat">
                         <asp:ListItem Text="�ļ�����" Value="xls"></asp:ListItem>
                         <asp:ListItem Text="EXCEL�ļ�(.xls)" Value="xls"></asp:ListItem>
                         <asp:ListItem Text="WORD�ļ�(.doc)" Value="doc"></asp:ListItem>
                     </asp:DropDownList>
                     <asp:Button runat="server" ID="btnExportAllToFile" Text="����" CssClass="button" OnClick="btnExportAllToFile_Click" />
                 <%=Convert.ToChar(38).ToString() +"nbsp;"%>
                 </div>
                <div id="SearchPageTopToolBar" runat="server" class="SearchPageTopToolBar">
                    <table>
                    <tr>
                    <td><input id="chkAll" type="checkbox" onclick="CheckAll(this);" runat="server" /></td>
                    <td><asp:DropDownList runat="server" ID="ddlOperation">
                        <asp:ListItem Text="����" Value=""></asp:ListItem>
                        <asp:ListItem Text="ɾ��" Value="remove"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="btnOperate" Text="ִ��" CssClass="button" OnClick="btnOperate_Click" /></td>
                    <td><asp:Button ID="btnFirstPage" runat="server" Text="|<" alt="��һҳ" OnClick="btnFirstPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnPrePage" runat="server" Text="<" alt="��һҳ" OnClick="btnPrePage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnNextPage" runat="server" Text=">" alt="��һҳ" OnClick="btnNextPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnLastPage" runat="server" Text=">|" alt="���һҳ" OnClick="btnLastPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:DropDownList ID="ddlPageCount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                    <td><asp:Label ID="lblPageInfo" runat="server" Text=""></asp:Label></td>
                    </tr>
                    </table>
                </div>
                </div>
                <div id="ListControl" runat="server" class="main">
                    <div class="list" id="divList" runat="server">
                        <asp:GridView ID="gvList" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table" CellPadding="5" Width="100%" BorderWidth="0px" HorizontalAlign="Center" OnRowDataBound="gvList_RowDataBound">
                            <Columns>
                                <asp:TemplateField HeaderText="ѡ��">
                                    <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" Width="25px" />
                                    <HeaderStyle CssClass="fieldname" />
                                    <FooterStyle CssClass="fieldname" />
                                    <ItemTemplate>
                                    <input type="checkbox" id="ObjectIDBatch" class="checkboxbatch" name="ObjectIDBatch" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' onclick="DoCheckAllFlag('ctl00$MainContentPlaceHolder$chkAll')" />
                                    <input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' />
                                    </ItemTemplate>
                                <FooterTemplate>
                                    �ϼ�
                                </FooterTemplate>
                                </asp:TemplateField>
                
                           <asp:TemplateField HeaderText="������" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ������<asp:LinkButton ID="btnSortFBH" runat="server" CommandArgument="FBH"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBH"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ����<asp:LinkButton ID="btnSortBT" runat="server" CommandArgument="BT"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="������Ŀ" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ������Ŀ<asp:LinkButton ID="btnSortFBLM" runat="server" CommandArgument="FBLM"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��������" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBBM_T_BM_DWXX_DWMC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��Ϣ����" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ��Ϣ����<asp:LinkButton ID="btnSortXXLX" runat="server" CommandArgument="XXLX"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XXLX_Dictionary_MC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                               <%# DataBinder.Eval(Container.DataItem, "FJXZDZ") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?a=d"+ AndChar +"file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "FJXZDZ")) + "' target='_blank'>����</a>"%>
                               <%# DataBinder.Eval(Container.DataItem, "FJXZDZ") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "FJXZDZ")) + "' target='_blank'>Ԥ��</a>"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��Ϣ״̬" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XXZT_Dictionary_MC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�Ƿ��ö�" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    �Ƿ��ö�<asp:LinkButton ID="btnSortIsTop" runat="server" CommandArgument="IsTop"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "IsTop_Dictionary_MC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�ö����" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    �ö����<asp:LinkButton ID="btnSortTopSort" runat="server" CommandArgument="TopSort"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TopSort"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�Ƽ�" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "IsBest_Dictionary_MC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="������" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBRJGH_T_PM_UserInfo_UserNickName")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����ʱ��" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ����ʱ��<asp:LinkButton ID="btnSortFBSJRQ" runat="server" CommandArgument="FBSJRQ"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), "yy-MM-dd")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����IP" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBIP"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="print" id="divPrint" runat="server">
                        <asp:GridView ID="gvPrint" ViewStateMode="Disabled" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table" CellSpacing="0" CellPadding="3" Width="100%" HorizontalAlign="Center">
                            <Columns>
                
                           <asp:TemplateField HeaderText="������"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBH"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BT"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="������Ŀ"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBLM_T_BG_0602_LMM") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��������"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBBM_T_BM_DWXX_DWMC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��Ϣ����"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XXLX_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <asp:LinkButton ID="btnDownload_FJXZDZ" runat="server" CommandArgument='<%#Bind("FJXZDZ")%>' CommandName='<%#Bind("BT")%>' OnClick="btnDownload_Click"><%# DataBinder.Eval(Container.DataItem, "FJXZDZ") == DBNull.Value ? "" : "�����ļ�"%></asp:LinkButton>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��Ϣ״̬"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XXZT_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�Ƿ��ö�"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "IsTop_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�ö����"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TopSort"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�Ƽ�"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "IsBest_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="������"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "FBRJGH_T_PM_UserInfo_UserNickName") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����ʱ��"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBSJRQ"), "yy-MM-dd")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="����IP"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FBIP"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
                </td>
            </tr>
        </table>
        </center>
</asp:Content>

