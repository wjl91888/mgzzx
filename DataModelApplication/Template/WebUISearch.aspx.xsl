<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUISearch.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" validateRequest="false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUISearch.aspx.cs" Inherits="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUISearch" %>]]>
<![CDATA[<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>]]>
<![CDATA[<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="TreeView" Src="~/Control/TreeViewControl.ascx" %>]]>
<![CDATA[<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[查询</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">]]>
<![CDATA[    <telerik:RadCodeBlock ID="JsCodeBlock" runat="server">]]>
<![CDATA[    <script language="javascript" type="text/javascript">]]>
<![CDATA[    function EditorWindowClose(sender, eventArgs) {]]>
<![CDATA[        RefreshGrid();]]>
<![CDATA[    }]]>
<![CDATA[    function RefreshGrid() {]]>
<![CDATA[        $find("<%= ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[.ClientID %>").ajaxRequest("Refresh");]]>
<![CDATA[    }]]>
<![CDATA[    $(document).ready(function () {]]>
<![CDATA[        $(".needrefresh").live("change", function () { RefreshGrid(); });]]>
<![CDATA[        $("input.needrefresh[type='text']").live("keyup", function () { RefreshGrid(); });]]>
<![CDATA[    });]]>
<![CDATA[    </script>]]>
<![CDATA[    </telerik:RadCodeBlock>]]>
<![CDATA[    <telerik:RadScriptManager ID="rsm]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">]]>
<![CDATA[    </telerik:RadScriptManager>]]>
<![CDATA[    <telerik:RadAjaxManager ID="ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">]]>
<![CDATA[        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnOperate">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnFirstPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnPrePage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnNextPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnLastPage">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageCount">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ddlPageSize">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[">
                <UpdatedControls>]]>
  <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAdvanceSearch = 'true'">
      <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsCoupledNext = 'true'">
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="]]><xsl:value-of select="FieldName"/><![CDATA[" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />]]>
        </xsl:if>
      </xsl:if>
    </xsl:if>
</xsl:for-each>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>]]>  
  <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsAdvanceSearch = 'true'">
      <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsCoupledNext = 'true'">
<![CDATA[            <telerik:AjaxSetting AjaxControlID="]]><xsl:value-of select="CoupledDataSourcePrevious"/><![CDATA[">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
        </xsl:if>
      </xsl:if>
    </xsl:if>
</xsl:for-each>
<![CDATA[            <telerik:AjaxSetting AjaxControlID="btnAdvanceSearch">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
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
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="btnDeleteFilterReport">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
            <telerik:AjaxSetting AjaxControlID="FilterReportList">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="SearchPageTopToolBar" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="ListControl" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                    <telerik:AjaxUpdatedControl ControlID="advancesearchpage" />
                </UpdatedControls>
            </telerik:AjaxSetting>
        </AjaxSettings>]]>
<![CDATA[    </telerik:RadAjaxManager>]]>
<![CDATA[    <telerik:RadAjaxLoadingPanel ID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>]]>
<![CDATA[        <center>]]>
<![CDATA[            <table border="0" cellpadding="0" cellspacing="0" width="100%">]]>
<![CDATA[            <tr>]]>
<![CDATA[                <td valign="top" id="tddivtree">]]>
<![CDATA[                <div id="divtree" class="width240">]]>
<![CDATA[            <div id="advancesearchpage" runat="server" class="advancesearchpage">
                <div id="FilterReportContainer" runat="server"]]><xsl:if test="/NewDataSet/UseFilterReport = 'false'"><![CDATA[ Visible="false"]]></xsl:if><![CDATA[>
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
                </div>]]>
<![CDATA[                <div class="main">]]>
<![CDATA[                    <div class="block">]]>
<![CDATA[                        <ul>]]>
<![CDATA[                            <li>查询条件</li>]]>
<![CDATA[                        </ul>]]>
<![CDATA[                    </div>]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsAdvanceSearch"/>
  <xsl:sort data-type="text" order="descending" select="IsSearch"/>
  <xsl:sort data-type="number" order="ascending" select="OrderID"/>
  <xsl:if test="IsAdvanceSearch = 'true'">
<![CDATA[                       <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><xsl:choose><xsl:when test="ControlTypeName = 'FreeTextBox'"></xsl:when><xsl:when test="ControlTypeName = 'ComboTreeView'"></xsl:when><xsl:when test="ControlType = '单行文本框'"></xsl:when><xsl:otherwise><![CDATA[ clearboth]]></xsl:otherwise></xsl:choose></xsl:if><xsl:if test="IsRangeSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><xsl:if test="IsMoreItemSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><xsl:if test="IsBatchSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><xsl:if test="IsSubItemSearch = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                           <div class="field">]]>
<![CDATA[                               <div class="fieldname">]]>
                                            <xsl:value-of select="FieldRemark"/>
<![CDATA[                               </div>]]>
<![CDATA[                           </div>]]>
<![CDATA[                           <div class="fieldinput]]><xsl:if test="IsMoreItemSearch = 'true'"><xsl:choose><xsl:when test="ControlTypeName = 'ComboTreeView'"><![CDATA[ clearboth]]></xsl:when><xsl:otherwise><![CDATA[ clearboth]]></xsl:otherwise></xsl:choose></xsl:if><![CDATA[">]]>
                                <xsl:choose>
                                  <xsl:when test="ControlTypeName = 'FreeTextBox'">
<![CDATA[                             <asp:TextBox ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></asp:TextBox>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlTypeName = 'ComboTreeView'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:TreeView ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:TreeView>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlTypeName = 'CheckBoxListEx'">
                                      <xsl:choose>
                                        <xsl:when test="IsMoreItemSearch = 'true'">
<![CDATA[                             <RICH:CheckBoxListEx ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh widthfull"></RICH:CheckBoxListEx>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <asp:DropDownList ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></asp:DropDownList>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>               
                                      <xsl:if test="IsSubItemSearch = 'true'">
<![CDATA[                             <div>]]>
<![CDATA[                                   <asp:CheckBox ID="chkShowSubItem]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Text = "包含子（下级）" Checked="true" CssClass="needrefresh" />]]>
<![CDATA[                             </div>]]>
                                      </xsl:if>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
                                      <xsl:choose>
                                        <xsl:when test="IsRangeSearch = 'true'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" runat="server" CssClass="input needrefresh" Visible = "False"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
<![CDATA[                             </div><div class="fieldinput width100per alignright"><B>>=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[Begin" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" runat="server" CssClass="input needrefresh" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[><br/><B><=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[End" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" runat="server" CssClass="input needrefresh" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input needrefresh]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>
                                  </xsl:when>
                                    <xsl:otherwise>
                                      <xsl:choose>
                                        <xsl:when test="IsBatchSearch = 'true'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh widthfull"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:when>
                                        <xsl:when test="IsMoreItemSearch = 'true'">
<![CDATA[                             <RICH:CheckBoxListEx ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></RICH:CheckBoxListEx>]]>
                                        </xsl:when>
                                        <xsl:when test="IsRangeSearch = 'true'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh" Visible = "False"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
<![CDATA[                             </div><div class="fieldinput width100per alignright"><B>>=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[Begin" runat="server" CssClass="input needrefresh" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[><br/><B><=</B><]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[End" runat="server" CssClass="input needrefresh" Width = "96"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>
                                      <xsl:if test="IsSubItemSearch = 'true'">
<![CDATA[                           </div>]]>
<![CDATA[                           <div class="fieldinput alignright width100per">]]>
<![CDATA[                                   <asp:CheckBox ID="chkShowSubItem]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Text = "包含子（下级）" Checked="true" CssClass="needrefresh" />]]>
                                      </xsl:if>
                                  </xsl:otherwise>
                                </xsl:choose>
<![CDATA[                           </div>]]>
<![CDATA[                       </div>]]>
  </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsAdvanceSearch = 'true'">
<![CDATA[                       <div class="content" id="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                           <div class="field">]]>
<![CDATA[                               <div class="fieldname">]]>
                                            <xsl:value-of select="DisplayName"/>
<![CDATA[                               </div>]]>
<![CDATA[                           </div>]]>
<![CDATA[                           <div class="fieldinput">]]>
                                      <xsl:choose>
                                        <xsl:when test="IsMoreItemSearch = 'true'">
<![CDATA[                             <RICH:CheckBoxListEx ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></RICH:CheckBoxListEx>]]>
                                        </xsl:when>
                                        <xsl:when test="IsBindData = 'true'">
<![CDATA[                             <asp:DropDownList ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></asp:DropDownList>]]>
                                        </xsl:when>
                                        <xsl:when test="IsRangeSearch = 'true'">
<![CDATA[                             <div><asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input needrefresh" Visible = "False"></asp:TextBox></div>]]>
<![CDATA[                             <div><br /><B>>=</B><asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[Begin" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox><B><=</B><asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[End" runat="server" CssClass="input needrefresh" Width = "96"></asp:TextBox></div>]]>
                                        </xsl:when>
                                        <xsl:otherwise>
<![CDATA[                             <asp:TextBox ID="]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" CssClass="input needrefresh"></asp:TextBox>]]>
                                        </xsl:otherwise>
                                      </xsl:choose>
                                      <xsl:if test="IsSubItemSearch = 'true'">
<![CDATA[                             <div>]]>
<![CDATA[                                   <asp:CheckBox ID="chkShowSubItem]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" Text = "包含子（下级）" Checked="true" CssClass="needrefresh" />]]>
<![CDATA[                             </div>]]>
                                      </xsl:if>
<![CDATA[                           </div>]]>
<![CDATA[                           <div id = "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[_note" class="fieldnote">]]>
<![CDATA[                           </div>]]>
<![CDATA[                       </div>]]>
    </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div id="ShowField_Area" runat="server"><div class="block">]]>
<![CDATA[                        <ul>]]>
<![CDATA[                            <li>结果显示字段</li>]]>
<![CDATA[                        </ul>]]>
<![CDATA[                    </div>]]>
                <xsl:for-each select="/NewDataSet/RecordInfo">
                    <xsl:sort data-type="text" order="descending" select="IsAdvanceSearch"/>
                    <xsl:if test="IsList = 'true'">
<![CDATA[                   <div ID="chkShow]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server"   class="contentshow">]]>
<![CDATA[                       <div class="field">]]>
<![CDATA[                           <div class="fieldcheck">]]>
<![CDATA[                               <asp:CheckBox ID="chkShow]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  CssClass="needrefresh" Text = "]]><xsl:value-of select="FieldRemark"/><![CDATA[" ]]>
                                        <xsl:if test="IsList = 'false'"><![CDATA[ Enabled="false" ]]></xsl:if>
                                        <xsl:if test="IsDefaultList = 'true'"><![CDATA[ Checked="true" />]]></xsl:if>
                                        <xsl:if test="IsDefaultList = 'false'"><![CDATA[ Checked="false" />]]></xsl:if>
<![CDATA[                               <asp:TextBox ID="txt]]><xsl:value-of select="FieldName"/><![CDATA[ColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>]]>
<![CDATA[                           </div>]]>
<![CDATA[                       </div>]]>
<![CDATA[                   </div>]]>
                    </xsl:if>
                </xsl:for-each>
                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                    <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                    <xsl:if test="RelatedTableType = '1_to_1'">
                        <xsl:if test="IsDisplay = 'true'">
<![CDATA[                   <div class="contentshow">]]>
<![CDATA[                       <div class="field">]]>
<![CDATA[                           <div class="fieldcheck">]]>
<![CDATA[                               <asp:CheckBox ID="chkShow]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[" runat="server" Text = "]]><xsl:value-of select="DisplayName"/><![CDATA[" Checked = "True" CssClass="needrefresh"/>]]>
<![CDATA[                               <asp:TextBox ID="txt]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[ColumnIndex" runat="server" Width="13" MaxLength="2" Visible = "False"></asp:TextBox>]]>
<![CDATA[                           </div>]]>
<![CDATA[                       </div>]]>
<![CDATA[                   </div>]]>
                        </xsl:if>
                    </xsl:if>
                </xsl:for-each>
<![CDATA[                </div></div>]]>
<![CDATA[                <div class="operation" id="operation" runat="server">]]>
<![CDATA[                    <center>]]>
<![CDATA[                        <asp:Button Text="查询" ID="btnAdvanceSearch" runat="server" CssClass="button floatright" OnClick="btnAdvanceSearch_Click" />]]>
<![CDATA[                        <asp:Button Text="高级界面" ID="btnShowAdvanceSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowAdvanceSearchItem_Click" />]]>
<![CDATA[                        <asp:Button Text="简单界面" ID="btnShowSimpleSearchItem" runat="server" CssClass="button floatright" OnClick="btnShowSimpleSearchItem_Click" />]]>
<![CDATA[                    </center>]]>
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </td>]]>
<![CDATA[                <td valign="top" id="tdmiddleblock">]]>
<![CDATA[                    <div style="float: left; width: 10px; height: 100%; vertical-align: middle;" onclick="changeWin();" onmousemove="this.style.cursor='pointer';" onmouseout="this.style.cursor='';">]]>
<![CDATA[                        <table border="0" style="background-color: #efefef; height: 100%;">]]>
<![CDATA[                            <tr>]]>
<![CDATA[                                <td valign="middle">]]>
<![CDATA[                                    <img id="menuSwitch" height="12" alt="隐藏" src="/App_Themes/Themes/Image/arrow_left.gif" width="8" border="0" />]]>
<![CDATA[                                </td>]]>
<![CDATA[                            </tr>]]>
<![CDATA[                        </table>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </td>]]>
<![CDATA[                <td valign="top" width="100%">]]>
<![CDATA[            <div id="listpage" runat="server" class="listpage listpageleftposition">]]>
<![CDATA[               <div id="toptoolsbar" runat="server" class="toptoolsbar listpageleftposition">]]>
<![CDATA[                <div class="title">]]>
<![CDATA[                    <div class="bar">]]>
<![CDATA[                        <div class="lefttitle">]]>
<![CDATA[                            <asp:Literal ID="PageTitle" runat="server"></asp:Literal>]]>
<![CDATA[                        </div>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </div>]]>
<![CDATA[                <asp:Literal ID="MessageBox" runat="server"></asp:Literal>]]>
<![CDATA[                <div id="SearchPageTopButtonBar" runat="server" class="quicksearch">]]>
<![CDATA[                    <input type="button" id="btnAddItem" runat="server" value="添加" class="button" />]]>
<xsl:if test="/NewDataSet/ImportFromDoc = 'true'">
<![CDATA[                    <input type="button" id="btnImportFromDoc" runat="server" value="导入文件" class="button" />]]>
</xsl:if>
<xsl:if test="/NewDataSet/ImportFromDataSet = 'true'">
<![CDATA[                    <input type="button" id="btnImportFromDataSet" runat="server" value="导入数据" class="button" />]]>
</xsl:if>
<![CDATA[                     <input type="button" id="btnStatisticItem" runat="server" value="统计" class="button" />]]>
<![CDATA[                     <input type="button" value="关闭" onclick="CloseWindow();" class="button displaynone" />]]>
<![CDATA[                     <asp:DropDownList runat="server" ID="ddlExportFileFormat">]]>
<![CDATA[                         <asp:ListItem Text="文件类型" Value="xls"></asp:ListItem>]]>
<![CDATA[                         <asp:ListItem Text="EXCEL文件(.xls)" Value="xls"></asp:ListItem>]]>
<![CDATA[                         <asp:ListItem Text="WORD文件(.doc)" Value="doc"></asp:ListItem>]]>
<![CDATA[                     </asp:DropDownList>]]>
<![CDATA[                     <asp:Button runat="server" ID="btnExportAllToFile" Text="导出" CssClass="button" OnClick="btnExportAllToFile_Click" />]]>
<![CDATA[                 <%=Convert.ToChar(38).ToString() +"nbsp;"%>]]>
<![CDATA[                 </div>]]>
<![CDATA[                <div id="SearchPageTopToolBar" runat="server" class="SearchPageTopToolBar">]]>
<![CDATA[                    <table>
                    <tr>
                    <td><input id="chkAll" type="checkbox" onclick="CheckAll(this);" runat="server" /></td>
                    <td><asp:DropDownList runat="server" ID="ddlOperation">
                        <asp:ListItem Text="操作" Value=""></asp:ListItem>
                        <asp:ListItem Text="删除" Value="remove"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:Button runat="server" ID="btnOperate" Text="执行" CssClass="button" OnClick="btnOperate_Click" /></td>
                    <td><asp:Button ID="btnFirstPage" runat="server" Text="第一页" OnClick="btnFirstPage_Click" CssClass="button" /></td>
                    <td><asp:Button ID="btnPrePage" runat="server" Text="上一页" OnClick="btnPrePage_Click" CssClass="button" /></td>
                    <td><asp:Button ID="btnNextPage" runat="server" Text="下一页" OnClick="btnNextPage_Click" CssClass="button" /></td>
                    <td><asp:Button ID="btnLastPage" runat="server" Text="最后一页" OnClick="btnLastPage_Click" CssClass="button" /></td>
                    <td><asp:DropDownList ID="ddlPageCount" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlPageCount_SelectedIndexChanged"></asp:DropDownList></td>
                    <td><asp:DropDownList ID="ddlPageSize" runat="server" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList></td>
                    <td><asp:Label ID="lblPageInfo" runat="server" Text=""></asp:Label></td>
                    </tr>
                    </table>]]>
<![CDATA[                </div>]]>
<![CDATA[                </div>]]>
<![CDATA[                <div id="ListControl" runat="server" class="main">]]>
<![CDATA[                    <div class="list" id="divList" runat="server">]]>
<![CDATA[                        <asp:GridView ID="gvList" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table" CellPadding="5" Width="100%" BorderWidth="0px" HorizontalAlign="Center" OnRowDataBound="gvList_RowDataBound">]]>
<![CDATA[                            <Columns>]]>
<![CDATA[                                <asp:TemplateField HeaderText="选中">]]>
<![CDATA[                                    <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" Width="25px" />]]>
<![CDATA[                                    <HeaderStyle CssClass="fieldname" />]]>
<![CDATA[                                    <FooterStyle CssClass="fieldname" />]]>
<![CDATA[                                    <ItemTemplate>]]>
<![CDATA[                                    <input type="checkbox" id="ObjectIDBatch" class="checkboxbatch" name="ObjectIDBatch" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' onclick="DoCheckAllFlag('ctl00$MainContentPlaceHolder$chkAll')" />]]>
<![CDATA[                                    <input type="hidden" id="ObjectID" name="ObjectID" runat="server" value='<%# DataBinder.Eval(Container.DataItem, "ObjectID")%>' />]]>
<![CDATA[                                    </ItemTemplate>]]>
<![CDATA[                                <FooterTemplate>]]>
<![CDATA[                                    合计]]>
<![CDATA[                                </FooterTemplate>]]>
<![CDATA[                                </asp:TemplateField>]]>
                <xsl:for-each select="/NewDataSet/RecordInfo">
                    <xsl:sort data-type="text" order="descending" select="IsList"/>
                    <xsl:if test="IsList = 'true'">
<![CDATA[                           <asp:TemplateField HeaderText="]]><xsl:value-of select="FieldRemark"/><![CDATA[" ]]>
                        <xsl:if test="IsSearch = 'true'"><![CDATA[Visible = "true"]]></xsl:if>
                        <xsl:if test="IsSearch = 'false'"><![CDATA[Visible = "false"]]></xsl:if>
                        <xsl:if test="IsSearch = ''"><![CDATA[Visible = "false"]]></xsl:if><![CDATA[>]]>
<![CDATA[                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                                <HeaderStyle CssClass="fieldname" />]]>
<![CDATA[                                <FooterStyle CssClass="fieldname" />]]>
                        <xsl:if test="IsListSort = 'true'">                                
<![CDATA[                                <HeaderTemplate>]]>
                                    <xsl:value-of select="FieldRemark"/><![CDATA[<asp:LinkButton ID="btnSort]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CommandArgument="]]><xsl:value-of select="FieldName"/><![CDATA["]]>
<![CDATA[                                        CommandName="DescSort" Text="▲" OnClick="btnSort_Click" CssClass="button"></asp:LinkButton>]]>
<![CDATA[                                </HeaderTemplate>]]></xsl:if>
<![CDATA[                                <ItemTemplate>]]>
                                        <xsl:if test="IsDataBind = 'true'">
                                            <xsl:if test="IsDataDict = 'true'">
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/><![CDATA[")%>]]>
                                            </xsl:if>
                                            <xsl:if test="IsDataDict = 'false'">
<![CDATA[                                    <a href="#" style="cursor:pointer;text-decoration:none;" onclick="OpenWindow(']]><xsl:value-of select="DataBindTableName"/><![CDATA[WebUIDetail.aspx?]]><xsl:value-of select="DataBindValueField"/><![CDATA[=<%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") %>',770,600,window);"><%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/><![CDATA[")%></a>]]>
                                            </xsl:if>
                                        </xsl:if>
                                        <xsl:if test="IsDataBind = 'false'">
                                            <xsl:choose>
                                                <xsl:when test="ControlTypeName = 'FreeTextBox'">
<![CDATA[                                        <%# "<a href=\"#\" style=\"cursor:pointer;text-decoration:none;\" onclick=\"OpenWindow(']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIDetail.aspx?ObjectID=" + DataBinder.Eval(Container.DataItem, "ObjectID") + "',770,600,window);\">点击查看</a>"%>]]>
                                                </xsl:when>
                                                <xsl:when test="ControlTypeName = 'FilesList'">
<![CDATA[                               <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?a=d"+ AndChar +"file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[")) + "' target='_blank'>]]><![CDATA[下载</a>"%>]]>
<![CDATA[                               <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "<a href='../../PreviewDocument/PreviewDocument.aspx?file=" + HttpUtility.UrlEncode((string)DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[")) + "' target='_blank'>]]><![CDATA[预览</a>"%>]]>
                                                </xsl:when>
                                                <xsl:otherwise>
<![CDATA[                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA["), ]]><xsl:value-of select="DisplayFormatString"/><![CDATA[)%>]]>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </xsl:if>
<![CDATA[                                </ItemTemplate>]]>
<![CDATA[                                <FooterTemplate>]]>
                                        <xsl:if test="IsSum = 'true'">
<![CDATA[                                    <%=appData.]]><xsl:value-of select="FieldName"/><![CDATA[Sum%>]]>
                                        </xsl:if>
<![CDATA[                                </FooterTemplate>]]>
<![CDATA[                            </asp:TemplateField>]]></xsl:if>
                </xsl:for-each>
                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                  <xsl:if test="RelatedTableType = '1_to_1'">
                    <xsl:if test="IsDisplay = 'true'">
<![CDATA[                           <asp:TemplateField HeaderText="]]><xsl:value-of select="DisplayName"/><![CDATA[" Visible = "true"]]><![CDATA[>]]>
<![CDATA[                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                                <HeaderStyle CssClass="fieldname" />]]>
<![CDATA[                                <FooterStyle CssClass="fieldname" />]]>
<![CDATA[                                <ItemTemplate>]]>
                                            <xsl:choose>
                                                <xsl:when test="IsBindData = 'true'">
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[")%>]]>
                                                </xsl:when>
                                                <xsl:otherwise>
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[")%>]]>
                                                </xsl:otherwise>
                                            </xsl:choose>
<![CDATA[                                </ItemTemplate>]]>
<![CDATA[                                <FooterTemplate>]]>
<![CDATA[                                </FooterTemplate>]]>
<![CDATA[                            </asp:TemplateField>]]></xsl:if></xsl:if>
                </xsl:for-each>
<![CDATA[                            </Columns>]]>
<![CDATA[                        </asp:GridView>]]>
<![CDATA[                    </div>]]>
<![CDATA[                    <div class="print" id="divPrint" runat="server">]]>
<![CDATA[                        <asp:GridView ID="gvPrint" ViewStateMode="Disabled" runat="server" ShowFooter="true" AutoGenerateColumns="False" CssClass="table" CellSpacing="0" CellPadding="3" Width="100%" HorizontalAlign="Center">]]>
<![CDATA[                            <Columns>]]>
                <xsl:for-each select="/NewDataSet/RecordInfo">
                    <xsl:sort data-type="text" order="descending" select="IsList"/>    
                    <xsl:if test="IsList = 'true'">
<![CDATA[                           <asp:TemplateField HeaderText="]]><xsl:value-of select="FieldRemark"/><![CDATA["]]>
                        <xsl:if test="IsSearch = 'true'"><![CDATA[Visible = "true"]]></xsl:if>
                        <xsl:if test="IsSearch = 'false'"><![CDATA[Visible = "false"]]></xsl:if>
                        <xsl:if test="IsSearch = ''"><![CDATA[Visible = "false"]]></xsl:if><![CDATA[>]]>
<![CDATA[                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                                <HeaderStyle CssClass="fieldname" />]]>
<![CDATA[                                <FooterStyle CssClass="fieldname" />]]>
<![CDATA[                                <ItemTemplate>]]>
                                        <xsl:if test="IsDataBind = 'true'">
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/><![CDATA[") + Convert.ToChar(38).ToString() +"nbsp;"%>]]>
                                        </xsl:if>
                                        <xsl:if test="IsDataBind = 'false'">
                                            <xsl:choose>
                                                <xsl:when test="ControlType = '文件上传'">
<![CDATA[                                    <asp:LinkButton ID="btnDownload_]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CommandArgument='<%#Bind("]]><xsl:value-of select="FieldName"/><![CDATA[")%>' CommandName='<%#Bind("]]><xsl:value-of select="/NewDataSet/TitleField"/><![CDATA[")%>' OnClick="btnDownload_Click"><%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "下载文件"%></asp:LinkButton>]]>
                                                </xsl:when>
                                                <xsl:when test="ControlType = '图片上传'">
<![CDATA[                                    <a href='<%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[")%>' target='_blank'><%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "打开图片"%></a>]]>
                                                </xsl:when>
                                                <xsl:otherwise>
<![CDATA[                                    <%# GetValue(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA["), ]]><xsl:value-of select="DisplayFormatString"/><![CDATA[)+ Convert.ToChar(38).ToString() +"nbsp;"%>]]>
                                                </xsl:otherwise>
                                            </xsl:choose>
                                        </xsl:if>
<![CDATA[                                </ItemTemplate>]]>
<![CDATA[                                <FooterTemplate>]]>
                                        <xsl:if test="IsSum = 'true'">
<![CDATA[                                    <%=appData.]]><xsl:value-of select="FieldName"/><![CDATA[Sum%>]]>
                                        </xsl:if>
<![CDATA[                                </FooterTemplate>]]>
<![CDATA[                            </asp:TemplateField>]]></xsl:if>
                </xsl:for-each>
                <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
                  <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
                  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
                  <xsl:if test="RelatedTableType = '1_to_1'">
                    <xsl:if test="IsDisplay = 'true'">
<![CDATA[                           <asp:TemplateField HeaderText="]]><xsl:value-of select="DisplayName"/><![CDATA[" Visible = "false"]]><![CDATA[>]]>
<![CDATA[                                <ItemStyle CssClass="fieldinput" HorizontalAlign="Center" />]]>
<![CDATA[                                <HeaderStyle CssClass="fieldname" />]]>
<![CDATA[                                <FooterStyle CssClass="fieldname" />]]>
<![CDATA[                                <ItemTemplate>]]>
                                            <xsl:choose>
                                                <xsl:when test="IsBindData = 'true'">
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/><![CDATA[") + Convert.ToChar(38).ToString() +"nbsp;"%>]]>
                                                </xsl:when>
                                                <xsl:otherwise>
<![CDATA[                                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><![CDATA[") + Convert.ToChar(38).ToString() +"nbsp;"%>]]>
                                                </xsl:otherwise>
                                            </xsl:choose>
<![CDATA[                                </ItemTemplate>]]>
<![CDATA[                                <FooterTemplate>]]>
<![CDATA[                                </FooterTemplate>]]>
<![CDATA[                            </asp:TemplateField>]]></xsl:if></xsl:if>
                </xsl:for-each>
<![CDATA[                            </Columns>]]>
<![CDATA[                        </asp:GridView>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
<![CDATA[                </td>]]>
<![CDATA[            </tr>]]>
<![CDATA[        </table>]]>
<![CDATA[        </center>]]>
<![CDATA[</asp:Content>]]>
</xsl:template>
</xsl:stylesheet>