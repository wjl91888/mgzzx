<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" validateRequest="false" AutoEventWireup="true" CodeFile="T_BM_DWXXWebUISearch.aspx.cs" Inherits="T_BM_DWXXWebUISearch" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">单位信息查询</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">
    <script language="javascript" type="text/javascript">
    function EditorWindowClose(sender, eventArgs) {
        RefreshGrid();
    }
    function RefreshGrid() {
        $find("<%= ramT_BM_DWXX.ClientID %>").ajaxRequest("Refresh");
    }
    $(document).ready(function () {
        $(".needrefresh").on("change", function () { RefreshGrid(); });
        $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });
    });
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadScriptManager ID="rsmT_BM_DWXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_DWXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOperate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageSize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ramT_BM_DWXX">
                <UpdatedControls>
  
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
  
            <telerik:AjaxSetting AjaxControlID="btnAdvanceSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
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
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="FilterReportList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_DWXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_DWXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
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
                            <li>查询报告</li>
                        </ul>
                    </div>
                    <div class="content" id="FilterReportList_Area" runat="server">
                        <div class="field">
                            <div class="fieldname">报告列表</div>
                        </div>
                        <div class="fieldinput">
                            <asp:DropDownList ID="FilterReportList" runat="server" DataTextField="BGMC" CssClass="input" DataValueField="ObjectID" 
                            OnSelectedIndexChanged="FilterReportList_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>
                    <div class="content" id="FilterReportName_Area" runat="server">
                        <div class="field">
                            <div class="fieldname">报告名称</div>
                        </div>
                        <div class="fieldinput">
                            <asp:TextBox ID="FilterReportName" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="input needrefresh"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="operation alignright width100per" id="FilterReport" runat="server" >
                    <asp:Button Text="删除" ID="btnDeleteFilterReport" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="button floatright" OnClick="btnDeleteFilterReport_Click" />
                    <asp:Button Text="保存" ID="btnSaveFilterReport" runat="server" ValidationGroup="FilterReportNameValidationGroup" CssClass="button floatright" OnClick="btnSaveFilterReport_Click" />
                    <asp:Button Text="清空" ID="btnReset" runat="server" CssClass="button floatright" OnClick="btnReset_Click" />
                    <div class="clearboth"></div>
                </div>
                </div>
                <div class="main">
                    <div class="block">
                        <ul>
                            <li>查询条件</li>
                        </ul>
                    </div>

                       <div class="content" id="DWMC_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            单位名称
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="DWMC" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="SJDWBH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            上级单位
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:DropDownList ID="SJDWBH" runat="server" CssClass="input needrefresh"></asp:DropDownList>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="LXR_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            联系人
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="LXR" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="DWBH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            单位编号
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="DWBH" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="DZ_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            地址
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="DZ" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                    <div id="ShowField_Area" runat="server"><div class="block">
                        <ul>
                            <li>结果显示字段</li>
                        </ul>
                    </div>
                
                   <div ID="chkShowDWBH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowDWBH" runat="server"  CssClass="needrefresh" Text = "单位编号" 
                                         Checked="true" />
                               <asp:TextBox ID="txtDWBHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowDWMC_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowDWMC" runat="server"  CssClass="needrefresh" Text = "单位名称" 
                                         Checked="true" />
                               <asp:TextBox ID="txtDWMCColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSJDWBH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSJDWBH" runat="server"  CssClass="needrefresh" Text = "上级单位" 
                                         Checked="true" />
                               <asp:TextBox ID="txtSJDWBHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowDZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowDZ" runat="server"  CssClass="needrefresh" Text = "地址" 
                                         Checked="false" />
                               <asp:TextBox ID="txtDZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowLXR_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowLXR" runat="server"  CssClass="needrefresh" Text = "联系人" 
                                         Checked="true" />
                               <asp:TextBox ID="txtLXRColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowYB_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowYB" runat="server"  CssClass="needrefresh" Text = "邮编" 
                                         Checked="false" />
                               <asp:TextBox ID="txtYBColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowLXBM_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowLXBM" runat="server"  CssClass="needrefresh" Text = "联系部门" 
                                         Checked="false" />
                               <asp:TextBox ID="txtLXBMColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowLXDH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowLXDH" runat="server"  CssClass="needrefresh" Text = "联系电话" 
                                         Checked="true" />
                               <asp:TextBox ID="txtLXDHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowEmail_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowEmail" runat="server"  CssClass="needrefresh" Text = "Email" 
                                         Checked="true" />
                               <asp:TextBox ID="txtEmailColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSJ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSJ" runat="server"  CssClass="needrefresh" Text = "手机" 
                                         Checked="true" />
                               <asp:TextBox ID="txtSJColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                </div></div>
                <div class="operation" id="operation" runat="server">
                    <center>
                        <asp:Button Text="查询" ID="btnAdvanceSearch" runat="server" CssClass="button floatright" OnClick="btnAdvanceSearch_Click" />
                        <asp:Button Text="高级界面" ID="btnShowAdvanceSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowAdvanceSearchItem_Click" />
                        <asp:Button Text="简单界面" ID="btnShowSimpleSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowSimpleSearchItem_Click" />
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
                                    <img id="menuSwitch" height="12" alt="隐藏" src="/App_Themes/Themes/Image/arrow_left.gif" width="8" border="0" />
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
                    <input type="button" id="btnAddItem" runat="server" value="添加" class="button" />

                     <input type="button" id="btnStatisticItem" runat="server" value="统计" class="button" />
                     <input type="button" value="关闭" onclick="CloseWindow();" class="button displaynone" />
                     <asp:DropDownList runat="server" ID="ddlExportFileFormat">
                         <asp:ListItem Text="文件类型" Value="xls"></asp:ListItem>
                         <asp:ListItem Text="EXCEL文件(.xls)" Value="xls"></asp:ListItem>
                         <asp:ListItem Text="WORD文件(.doc)" Value="doc"></asp:ListItem>
                     </asp:DropDownList>
                     <asp:Button runat="server" ID="btnExportAllToFile" Text="导出" CssClass="button" OnClick="btnExportAllToFile_Click" />
                 <%=Convert.ToChar(38).ToString() +"nbsp;"%>
                 </div>
                <div id="SearchPageTopToolBar" runat="server" class="SearchPageTopToolBar">
                    <table>
                    <tr>
                    <td><input id="chkAll" type="checkbox" onclick="CheckAll(this);" runat="server" /></td>
                    <td><asp:DropDownList runat="server" ID="ddlOperation">
                        <asp:ListItem Text="操作" Value=""></asp:ListItem>
                        <asp:ListItem Text="删除" Value="remove"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="btnOperate" Text="执行" CssClass="button" OnClick="btnOperate_Click" /></td>
                    <td><asp:Button ID="btnFirstPage" runat="server" Text="|<" alt="第一页" OnClick="btnFirstPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnPrePage" runat="server" Text="<" alt="上一页" OnClick="btnPrePage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnNextPage" runat="server" Text=">" alt="下一页" OnClick="btnNextPage_Click" CssClass="linkbutton" /></td>
                    <td><asp:Button ID="btnLastPage" runat="server" Text=">|" alt="最后一页" OnClick="btnLastPage_Click" CssClass="linkbutton" /></td>
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
                                <asp:TemplateField HeaderText="选中">
                                    <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" Width="25px" />
                                    <HeaderStyle CssClass="fieldname" />
                                    <FooterStyle CssClass="fieldname" />
                                    <ItemTemplate>
                                    <input type="checkbox" id="ObjectIDBatch" class="checkboxbatch" name="ObjectIDBatch" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' onclick="DoCheckAllFlag('ctl00$MainContentPlaceHolder$chkAll')" />
                                    <input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' />
                                    </ItemTemplate>
                                <FooterTemplate>
                                    合计
                                </FooterTemplate>
                                </asp:TemplateField>
                
                           <asp:TemplateField HeaderText="单位编号" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWBH"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="单位名称" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWMC"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="上级单位" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "SJDWBH_T_BM_DWXX_DWMC")%>
                                            
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="地址" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DZ"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="邮编" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YB"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="联系部门" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXBM"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="联系电话" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXDH"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Email" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "Email"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="联系人" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXR"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="手机" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SJ"), null)%>
                                                
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
                
                           <asp:TemplateField HeaderText="单位编号"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWBH"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="单位名称"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DWMC"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="上级单位"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# DataBinder.Eval(Container.DataItem, "SJDWBH_T_BM_DWXX_DWMC") + Convert.ToChar(38).ToString() +"nbsp;"%>
                                        
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="地址"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DZ"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="邮编"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YB"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="联系部门"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXBM"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="联系电话"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXDH"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Email"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "Email"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="联系人"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "LXR"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="手机"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SJ"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
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

