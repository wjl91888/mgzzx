<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" validateRequest="false" AutoEventWireup="true" CodeFile="FilterReportWebUISearch.aspx.cs" Inherits="FilterReportWebUISearch" %>
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
        $find("<%= ramFilterReport.ClientID %>").ajaxRequest("Refresh");
    }
    $(document).ready(function () {
        $(".needrefresh").on("change", function () { RefreshGrid(); });
        $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });
    });
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadScriptManager ID="rsmFilterReport" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramFilterReport" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOperate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageSize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ramFilterReport">
                <UpdatedControls>
  
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
  
            <telerik:AjaxSetting AjaxControlID="btnAdvanceSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
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
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="FilterReportList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpFilterReport" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpFilterReport" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
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

                       <div class="content" id="BGMC_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ��������
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="BGMC" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="UserID_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            �û����
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="UserID" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="BGLX_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ��������
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="BGLX" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="GXBG_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ������
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="GXBG" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="XTBG_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ϵͳ����
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="XTBG" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="BGCJSJ_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            ����ʱ��
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="BGCJSJ" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                    <div id="ShowField_Area" runat="server"><div class="block">
                        <ul>
                            <li>�����ʾ�ֶ�</li>
                        </ul>
                    </div>
                
                   <div ID="chkShowBGMC_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowBGMC" runat="server"  CssClass="needrefresh" Text = "��������" 
                                         Checked="true" />
                               <asp:TextBox ID="txtBGMCColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowUserID_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowUserID" runat="server"  CssClass="needrefresh" Text = "�û����" 
                                         Checked="true" />
                               <asp:TextBox ID="txtUserIDColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowBGLX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowBGLX" runat="server"  CssClass="needrefresh" Text = "��������" 
                                         Checked="true" />
                               <asp:TextBox ID="txtBGLXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowGXBG_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowGXBG" runat="server"  CssClass="needrefresh" Text = "������" 
                                         Checked="true" />
                               <asp:TextBox ID="txtGXBGColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowXTBG_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowXTBG" runat="server"  CssClass="needrefresh" Text = "ϵͳ����" 
                                         Checked="true" />
                               <asp:TextBox ID="txtXTBGColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowBGCJSJ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowBGCJSJ" runat="server"  CssClass="needrefresh" Text = "����ʱ��" 
                                         Checked="true" />
                               <asp:TextBox ID="txtBGCJSJColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
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
                
                           <asp:TemplateField HeaderText="��������" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ��������<asp:LinkButton ID="btnSortBGMC" runat="server" CommandArgument="BGMC"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGMC"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�û����" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    �û����<asp:LinkButton ID="btnSortUserID" runat="server" CommandArgument="UserID"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "UserID_T_PM_UserInfo_UserLoginName")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="��������" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ��������<asp:LinkButton ID="btnSortBGLX" runat="server" CommandArgument="BGLX"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGLX"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="������" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ������<asp:LinkButton ID="btnSortGXBG" runat="server" CommandArgument="GXBG"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "GXBG_Dictionary_MC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="ϵͳ����" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    ϵͳ����<asp:LinkButton ID="btnSortXTBG" runat="server" CommandArgument="XTBG"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XTBG_Dictionary_MC")%>
                                            
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
                                    ����ʱ��<asp:LinkButton ID="btnSortBGCJSJ" runat="server" CommandArgument="BGCJSJ"
                                        CommandName="DescSort" Text="��" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGCJSJ"), null)%>
                                                
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
                
                           <asp:TemplateField HeaderText="��������"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGMC"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="�û����"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "UserID_T_PM_UserInfo_UserLoginName") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
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
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGLX"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="������"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "GXBG_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="ϵͳ����"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "XTBG_Dictionary_MC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
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
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BGCJSJ"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
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

