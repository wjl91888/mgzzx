<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" validateRequest="false" AutoEventWireup="true" CodeFile="T_BM_GZXXWebUISearch.aspx.cs" Inherits="T_BM_GZXXWebUISearch" %>
<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>
<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>
<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">工资信息查询</asp:Content>
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">
    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">
    <script language="javascript" type="text/javascript">
    function EditorWindowClose(sender, eventArgs) {
        RefreshGrid();
    }
    function RefreshGrid() {
        $find("<%= ramT_BM_GZXX.ClientID %>").ajaxRequest("Refresh");
    }
    $(document).ready(function () {
        $(".needrefresh").on("change", function () { RefreshGrid(); });
        $("input.needrefresh[type='text']").on("keyup", function () { RefreshGrid(); });
    });
    </script>
    </telerik:RadCodeBlock>
    <telerik:RadScriptManager ID="rsmT_BM_GZXX" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadAjaxManager ID="ramT_BM_GZXX" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOperate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageSize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ramT_BM_GZXX">
                <UpdatedControls>
  
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                </UpdatedControls>
            </telerik:AjaxSetting>  
  
            <telerik:AjaxSetting AjaxControlID="btnAdvanceSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
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
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="FilterReportList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralpT_BM_GZXX" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>
    </telerik:RadAjaxManager>
    <telerik:RadAjaxLoadingPanel ID="ralpT_BM_GZXX" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>
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

                       <div class="content" id="XM_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            姓名
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="XM" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="XB_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            性别
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="XB" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="SFZH_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            身份证号
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="SFZH" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content" id="FFGZNY_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            日期
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="FFGZNY" runat="server" CssClass="input needrefresh"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content clearboth" id="YFX_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            应发项
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="YFX" runat="server" CssClass="input needrefresh" Visible = "False"></asp:TextBox>
                             </div><div class="fieldinput width100per alignright"><B>>=</B><asp:TextBox ID="YFXBegin" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox><br/><B><=</B><asp:TextBox ID="YFXEnd" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content clearboth" id="SFGZ_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            实发工资
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="SFGZ" runat="server" CssClass="input needrefresh" Visible = "False"></asp:TextBox>
                             </div><div class="fieldinput width100per alignright"><B>>=</B><asp:TextBox ID="SFGZBegin" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox><br/><B><=</B><asp:TextBox ID="SFGZEnd" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                       <div class="content clearboth" id="TJSJ_Area" runat="server">
                           <div class="field">
                               <div class="fieldname">
                                            添加时间
                               </div>
                           </div>
                           <div class="fieldinput">
                                
                             <asp:TextBox ID="TJSJ" runat="server" CssClass="input needrefresh" Visible = "False"></asp:TextBox>
                             </div><div class="fieldinput width100per alignright"><B>>=</B><asp:TextBox ID="TJSJBegin" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox><br/><B><=</B><asp:TextBox ID="TJSJEnd" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox>
                                        
                           </div>
                       </div>
  
                    <div id="ShowField_Area" runat="server"><div class="block">
                        <ul>
                            <li>结果显示字段</li>
                        </ul>
                    </div>
                
                   <div ID="chkShowXM_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowXM" runat="server"  CssClass="needrefresh" Text = "姓名" 
                                         Checked="true" />
                               <asp:TextBox ID="txtXMColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowXB_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowXB" runat="server"  CssClass="needrefresh" Text = "性别" 
                                         Checked="false" />
                               <asp:TextBox ID="txtXBColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSFZH_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSFZH" runat="server"  CssClass="needrefresh" Text = "身份证号" 
                                         Checked="true" />
                               <asp:TextBox ID="txtSFZHColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFFGZNY_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFFGZNY" runat="server"  CssClass="needrefresh" Text = "日期" 
                                         Checked="true" />
                               <asp:TextBox ID="txtFFGZNYColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowYFX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowYFX" runat="server"  CssClass="needrefresh" Text = "应发项" 
                                         Checked="true" />
                               <asp:TextBox ID="txtYFXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSFGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSFGZ" runat="server"  CssClass="needrefresh" Text = "实发工资" 
                                         Checked="true" />
                               <asp:TextBox ID="txtSFGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowTJSJ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowTJSJ" runat="server"  CssClass="needrefresh" Text = "添加时间" 
                                         Checked="false" />
                               <asp:TextBox ID="txtTJSJColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJCGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJCGZ" runat="server"  CssClass="needrefresh" Text = "基础工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJCGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJSDJGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJSDJGZ" runat="server"  CssClass="needrefresh" Text = "技术等级工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJSDJGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowZWGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowZWGZ" runat="server"  CssClass="needrefresh" Text = "职务工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtZWGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJBGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJBGZ" runat="server"  CssClass="needrefresh" Text = "级别工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJBGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJKDQJT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJKDQJT" runat="server"  CssClass="needrefresh" Text = "艰苦地区津贴" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJKDQJTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJKTSGWJT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJKTSGWJT" runat="server"  CssClass="needrefresh" Text = "艰苦特岗津贴" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJKTSGWJTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowGLGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowGLGZ" runat="server"  CssClass="needrefresh" Text = "工龄工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtGLGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowXJGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowXJGZ" runat="server"  CssClass="needrefresh" Text = "薪级工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtXJGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowTGBF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowTGBF" runat="server"  CssClass="needrefresh" Text = "10%提高部分" 
                                         Checked="false" />
                               <asp:TextBox ID="txtTGBFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowDHF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowDHF" runat="server"  CssClass="needrefresh" Text = "电话费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtDHFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowDSZNF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowDSZNF" runat="server"  CssClass="needrefresh" Text = "独生子女费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtDSZNFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowFNWSHLF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowFNWSHLF" runat="server"  CssClass="needrefresh" Text = "妇女卫生费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtFNWSHLFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowHLF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowHLF" runat="server"  CssClass="needrefresh" Text = "护理费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtHLFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJJ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJJ" runat="server"  CssClass="needrefresh" Text = "取暖补贴" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJJColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJTF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJTF" runat="server"  CssClass="needrefresh" Text = "交通费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJTFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJHLGZ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJHLGZ" runat="server"  CssClass="needrefresh" Text = "教护龄工资" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJHLGZColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowJT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowJT" runat="server"  CssClass="needrefresh" Text = "津贴" 
                                         Checked="false" />
                               <asp:TextBox ID="txtJTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowBF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowBF" runat="server"  CssClass="needrefresh" Text = "补发" 
                                         Checked="false" />
                               <asp:TextBox ID="txtBFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowQTBT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowQTBT" runat="server"  CssClass="needrefresh" Text = "其他补贴" 
                                         Checked="false" />
                               <asp:TextBox ID="txtQTBTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowDFXJT_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowDFXJT" runat="server"  CssClass="needrefresh" Text = "地方性津贴" 
                                         Checked="false" />
                               <asp:TextBox ID="txtDFXJTColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowQTKK_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowQTKK" runat="server"  CssClass="needrefresh" Text = "其他扣款" 
                                         Checked="false" />
                               <asp:TextBox ID="txtQTKKColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSYBX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSYBX" runat="server"  CssClass="needrefresh" Text = "失业保险" 
                                         Checked="false" />
                               <asp:TextBox ID="txtSYBXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSDNQF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSDNQF" runat="server"  CssClass="needrefresh" Text = "水电暖气费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtSDNQFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowSDS_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowSDS" runat="server"  CssClass="needrefresh" Text = "所得税" 
                                         Checked="false" />
                               <asp:TextBox ID="txtSDSColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowYLBX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowYLBX" runat="server"  CssClass="needrefresh" Text = "养老保险" 
                                         Checked="false" />
                               <asp:TextBox ID="txtYLBXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowYLIBX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowYLIBX" runat="server"  CssClass="needrefresh" Text = "医疗保险" 
                                         Checked="false" />
                               <asp:TextBox ID="txtYLIBXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowYSSHF_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowYSSHF" runat="server"  CssClass="needrefresh" Text = "遗属生活费" 
                                         Checked="false" />
                               <asp:TextBox ID="txtYSSHFColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowZFGJJ_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowZFGJJ" runat="server"  CssClass="needrefresh" Text = "住房公积金" 
                                         Checked="false" />
                               <asp:TextBox ID="txtZFGJJColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowKFX_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowKFX" runat="server"  CssClass="needrefresh" Text = "扣发项" 
                                         Checked="true" />
                               <asp:TextBox ID="txtKFXColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
                           </div>
                       </div>
                   </div>
                    
                   <div ID="chkShowGZKKSM_Area" runat="server"   class="contentshow">
                       <div class="field">
                           <div class="fieldcheck">
                               <asp:CheckBox ID="chkShowGZKKSM" runat="server"  CssClass="needrefresh" Text = "说明" 
                                         Checked="false" />
                               <asp:TextBox ID="txtGZKKSMColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>
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

                    <input type="button" id="btnImportFromDataSet" runat="server" value="导入数据" class="button" />

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
                
                           <asp:TemplateField HeaderText="姓名" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    姓名<asp:LinkButton ID="btnSortXM" runat="server" CommandArgument="XM"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XM"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="性别" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XB"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="身份证号" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFZH"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="日期" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    日期<asp:LinkButton ID="btnSortFFGZNY" runat="server" CommandArgument="FFGZNY"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FFGZNY"), "{0}{1}{2}{3}-{4}{5}")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="基础工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JCGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="技术等级工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JSDJGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="职务工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZWGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="级别工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JBGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="艰苦地区津贴" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKDQJT"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="艰苦特岗津贴" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKTSGWJT"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="工龄工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GLGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="薪级工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XJGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="10%提高部分" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TGBF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="电话费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DHF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="独生子女费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DSZNF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="妇女卫生费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FNWSHLF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="护理费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HLF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="取暖补贴" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JJ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="交通费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JTF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="教护龄工资" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JHLGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="津贴" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JT"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="补发" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="其他补贴" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTBT"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="地方性津贴" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DFXJT"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="应发项" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    应发项<asp:LinkButton ID="btnSortYFX" runat="server" CommandArgument="YFX"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YFX"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                    <%=appData.YFXSum%>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="其他扣款" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTKK"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="失业保险" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SYBX"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="水电暖气费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDNQF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="所得税" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDS"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="养老保险" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLBX"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="医疗保险" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLIBX"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="遗属生活费" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YSSHF"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="住房公积金" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZFGJJ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="扣发项" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KFX"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="实发工资" 
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                                        
                                <HeaderTemplate>
                                    实发工资<asp:LinkButton ID="btnSortSFGZ" runat="server" CommandArgument="SFGZ"
                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>
                                </HeaderTemplate>
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFGZ"), "0.00")%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                    <%=appData.SFGZSum%>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="说明" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GZKKSM"), null)%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="添加时间" 
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                        
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TJSJ"), null)%>
                                                
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
                
                           <asp:TemplateField HeaderText="姓名"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XM"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="性别"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XB"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="身份证号"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFZH"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="日期"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FFGZNY"), "{0}{1}{2}{3}-{4}{5}")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="基础工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JCGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="技术等级工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JSDJGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="职务工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZWGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="级别工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JBGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="艰苦地区津贴"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKDQJT"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="艰苦特岗津贴"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JKTSGWJT"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="工龄工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GLGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="薪级工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "XJGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="10%提高部分"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TGBF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="电话费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DHF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="独生子女费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DSZNF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="妇女卫生费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "FNWSHLF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="护理费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "HLF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="取暖补贴"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JJ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="交通费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JTF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="教护龄工资"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JHLGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="津贴"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "JT"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="补发"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "BF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="其他补贴"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTBT"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="地方性津贴"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "DFXJT"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="应发项"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YFX"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                    <%=appData.YFXSum%>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="其他扣款"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "QTKK"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="失业保险"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SYBX"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="水电暖气费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDNQF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="所得税"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SDS"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="养老保险"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLBX"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="医疗保险"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YLIBX"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="遗属生活费"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "YSSHF"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="住房公积金"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "ZFGJJ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="扣发项"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "KFX"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="实发工资"
                        Visible = "true">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "SFGZ"), "0.00")+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                    <%=appData.SFGZSum%>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="说明"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "GZKKSM"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
                                </ItemTemplate>
                                <FooterTemplate>
                                        
                                </FooterTemplate>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="添加时间"
                        Visible = "false">
                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="fieldname" />
                                <FooterStyle CssClass="fieldname" />
                                <ItemTemplate>
                                        
                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "TJSJ"), null)+ Convert.ToChar(38).ToString() +"nbsp;"%>
                                                
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

