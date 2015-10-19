<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIAddForApp.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIAdd.aspx.cs" Inherits="App.]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIAdd" %>]]>
<![CDATA[<%@ Register TagPrefix="FTB" Namespace="FreeTextBoxControls" Assembly="FreeTextBox" %>]]>
<![CDATA[<%@ Register Assembly="CustomWebControls" Namespace="CustomWebControls" TagPrefix="RICH" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="GridDataBind" Src="~/Control/GridControl.ascx" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="ComboTreeView" Src="~/Control/ComboTreeViewControl.ascx" %>]]>
<![CDATA[<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControl.ascx" %>]]>
<![CDATA[<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>]]>
<![CDATA[<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[编辑</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">]]>
<![CDATA[    <style type="text/css">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsAdd = 'true'">
<xsl:if test="ControlType = '多行文本框'"><![CDATA[    table.<%=]]><xsl:value-of select="FieldName"/><![CDATA[.ClientID%>_OuterTable { background-color: #ffffff; }]]></xsl:if>
<xsl:if test="ControlTypeName = 'FreeTextBox'"><![CDATA[    .ctl00_MainContentPlaceHolder_]]><xsl:value-of select="FieldName"/><![CDATA[_DesignBox { background-color: #ffffff !important;}]]></xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[    </style>]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">]]>
<![CDATA[</asp:Content>]]>
<![CDATA[<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">]]>
<![CDATA[    <telerik:RadAjaxManagerProxy ID="ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">
        <AjaxSettings>
            <telerik:AjaxSetting AjaxControlID="btnAddConfirm">
                <UpdatedControls>
                    <telerik:AjaxUpdatedControl ControlID="AppAddPage" LoadingPanelID="ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />
                </UpdatedControls>
            </telerik:AjaxSetting>]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsUse = 'true'">
      <xsl:if test="IsDataBind = 'true'">
        <xsl:if test="IsCoupledNext = 'true'">
<![CDATA[            <telerik:AjaxSetting AjaxControlID="]]><xsl:value-of select="CoupledDataSourcePrevious"/><![CDATA[">]]>
<![CDATA[                <UpdatedControls>]]>
<![CDATA[                    <telerik:AjaxUpdatedControl ControlID="]]><xsl:value-of select="FieldName"/><![CDATA[" LoadingPanelID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" />]]>
<![CDATA[                </UpdatedControls>]]>
<![CDATA[            </telerik:AjaxSetting>]]>
        </xsl:if>
      </xsl:if>
    </xsl:if>
</xsl:for-each>
<![CDATA[        </AjaxSettings>]]>
<![CDATA[    </telerik:RadAjaxManagerProxy>]]>
<![CDATA[    <telerik:RadAjaxLoadingPanel ID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>]]>
<![CDATA[        <div id="AppAddPage" runat="server">]]>
<![CDATA[            <asp:Literal ID="MessageBox" runat="server"></asp:Literal>]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="OrderID"/>
  <xsl:if test="IsUse = 'true'">
<![CDATA[            <div id="]]><xsl:value-of select="FieldName"/><![CDATA[Container" runat="server" class="row">]]>
<![CDATA[                <div id="]]><xsl:value-of select="FieldName"/><![CDATA[Caption" runat="server" class="fontbold col-xs-]]><xsl:value-of select="AppAddCaptionColumn"/><![CDATA[ paddingleft0">]]><xsl:value-of select="FieldRemark"/><![CDATA[</div>]]>
<![CDATA[                <div id="]]><xsl:value-of select="FieldName"/><![CDATA[Content" runat="server" class="col-xs-]]><xsl:value-of select="AppAddContentColumn"/><![CDATA[">]]>
                                <xsl:choose>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = '多行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Language="zh-cn" Height="150" AllowHtmlMode="false" EnableHtmlMode="false" EnableToolbars="false" BreakMode="LineBreak"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = '密码框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
<![CDATA[                             请再次输入：]]>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[Confirm" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[> 不需修改请留空]]>
                                  </xsl:when>
                                  <xsl:when test="ControlTypeName = 'FreeTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Language="zh-cn"  ToolbarLayout="ParagraphMenu,FontFacesMenu,FontSizesMenu,FontForeColorsMenu|Bold,Italic,Underline,Strikethrough,Superscript,Subscript,RemoveFormat|JustifyLeft,JustifyRight,JustifyCenter,JustifyFull;BulletedList,NumberedList,Indent,Outdent;CreateLink,Unlink,InsertImage,InsertImageFromGallery,InsertRule|Cut,Copy,Paste,Delete;Undo,Redo,Print|InsertTable, EditTable, InsertTableRowBefore, InsertTableRowAfter, DeleteTableRow, InsertTableColumnBefore, InsertTableColumnAfter, DeleteTableColumn|InsertDiv, Preview, SelectAll, EditStyle"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlTypeName = 'TextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'ComboTreeView'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
  </xsl:if>
</xsl:for-each>
<![CDATA[        </div>
    <script>
        Sys.Application.add_load(function () {
            $('body,html').animate({ scrollTop: 0 }, 10);
        });
    </script>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
  <ul id="PageInfo" runat="server" class="nav  navbar-default">
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
      <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="btn btn-default navbar-btn" OnClick="btnSave_Click" />
    </li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
  </ul>
</asp:Content>]]>
</xsl:template>
</xsl:stylesheet>