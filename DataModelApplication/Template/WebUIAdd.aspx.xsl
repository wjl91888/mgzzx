<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIAdd.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BasePage.master" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIAdd.aspx.cs" Inherits="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIAdd" %>]]>
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
<![CDATA[<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContentPlaceHolder" runat="server">]]>
<![CDATA[    <telerik:RadScriptManager ID="rsm]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">]]>
<![CDATA[    </telerik:RadScriptManager>]]>
<![CDATA[    <telerik:RadAjaxManager ID="ram]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server">]]>
<![CDATA[        <AjaxSettings>]]>
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
<![CDATA[    </telerik:RadAjaxManager>]]>
<![CDATA[    <telerik:RadAjaxLoadingPanel ID="ralp]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[" runat="server" Skin="Vista"></telerik:RadAjaxLoadingPanel>]]>
<![CDATA[        <center>]]>
<![CDATA[            <div id="addpage" runat="server" class="addpage">]]>
<![CDATA[                <div class="toptoolsbar">]]>
<![CDATA[                <div class="title">]]>
<![CDATA[                    <div class="bar">]]>
<![CDATA[                        <div class="lefttitle">]]>
<![CDATA[                            ]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[ ]]>
<![CDATA[                        </div>]]>
<![CDATA[                    </div>]]>
<![CDATA[                </div>]]>
<![CDATA[                <div class="operation">]]>
<![CDATA[                    <center>]]>
<![CDATA[                        <asp:Button Text="导入数据" ID="btnInfoFromDS" runat="server" CssClass="button" OnClick="btnInfoFromDS_Click" />]]>
<![CDATA[                        <asp:Button Text="Word导入" ID="btnInfoFromDoc" runat="server" CssClass="button" OnClick="btnInfoFromDoc_Click" />]]>
<![CDATA[                        <asp:Button Text="批量Word导入" ID="btnInfoFromDocBatch" runat="server" CssClass="button" OnClick="btnInfoFromDocBatch_Click" Visible="false" />]]>
<![CDATA[                        <asp:Button Text="取消" ID="btnInfoFromDocCancel" runat="server" CssClass="button" OnClick="btnInfoFromDocCancel_Click" />]]>
<![CDATA[                        <input type="button" id ="btnEditItem" runat ="server" value="修改" class="button" />]]>
<xsl:if test="/NewDataSet/CopyItem = 'true'">
<![CDATA[                        <input type="button" id ="btnCopyItem" runat ="server" value="复制" class="button" />]]></xsl:if>
<![CDATA[                        <asp:Button Text="保存" ID="btnAddConfirm" runat="server" CssClass="button" OnClientClick="return AddConfirmDialog();" OnClick="btnSave_Click" />]]>
<xsl:if test="/NewDataSet/ImportFromDoc = 'true'">
<![CDATA[                        <asp:Button Text="导入数据" ID="btnImportFromDoc" runat="server" CssClass="button" OnClick="btnImportFromDoc_Click" />]]></xsl:if>
<![CDATA[                        <input type="button" value="关闭窗口" onclick="CloseWindow();" class="button" />]]>
<![CDATA[                    </center>]]>
<![CDATA[                </div>]]>
<![CDATA[                </div>]]>
<![CDATA[                <div class="main">]]>
<![CDATA[                     <asp:Literal ID="MessageBox" runat="server"></asp:Literal>]]>
<![CDATA[                     <div  id= "ImportControlContainer" runat="server">]]>
<![CDATA[                     <div class="content clearboth" id="InfoFromDoc_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">导入文件</div><div class="redstar">*</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput">]]>
<![CDATA[                                 <asp:TextBox ID="InfoFromDoc" runat="server" CssClass="input widthfull"></asp:TextBox>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldnote" id="InfoFromDoc_Note" runat="server"></div>]]>
<![CDATA[                     </div>]]>
<![CDATA[                     </div>]]>
<![CDATA[                     <div  id= "ControlContainer" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="OrderID"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'false'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
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
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                <div class="clearboth"></div>]]>
<![CDATA[                <telerik:RadTabStrip ID="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[TabStrip" Visible="false" runat="server" ClickSelectedTab="true" SelectedIndex="0" MultiPageID="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[MultiPage" >]]>
<![CDATA[                    <Tabs>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="1" PageViewID="PageView1"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="2" PageViewID="PageView2"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="3" PageViewID="PageView3"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="4" PageViewID="PageView4"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="5" PageViewID="PageView5"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="6" PageViewID="PageView6"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="7" PageViewID="PageView7"></telerik:RadTab>]]>
<![CDATA[                        <telerik:RadTab Visible="false" runat = "server" Value="8" PageViewID="PageView8"></telerik:RadTab>]]>
<![CDATA[                    </Tabs>]]>
<![CDATA[                </telerik:RadTabStrip>]]>
<![CDATA[                <telerik:RadMultiPage CssClass="tab_table" ID="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[MultiPage" runat="server" SelectedIndex="0">]]>
<![CDATA[                    <telerik:RadPageView ID="PageView1" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="OrderID"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '1'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
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
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView2" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '2'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView3" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '3'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView4" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '4'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView5" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '5'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView6" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '6'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView7" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '7'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                    <telerik:RadPageView ID="PageView8" Visible="false" runat="server">]]>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="number" order="ascending" select="TabIndex"/>
  <xsl:if test="IsUse = 'true'">
  <xsl:if test="IsUseTab = 'true'">
  <xsl:if test="TabIndex = '8'">
<![CDATA[                     <div class="content]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ clearboth]]></xsl:if><![CDATA[" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Area" runat="server">]]>
<![CDATA[                         <div class="field">]]>
<![CDATA[                             <div class="fieldname">]]>
                                          <xsl:value-of select="FieldRemark"/>
<![CDATA[                             </div>]]>
<![CDATA[                             <div class="redstar">]]><xsl:if test="IsNull = 'false'"><![CDATA[*]]></xsl:if><![CDATA[</div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                         <div class="fieldinput"><div>]]>
                                <xsl:choose>
                                  <xsl:when test="ControlType = 'GridDataBind'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server"  EditMode="true" Visible="true" GridHeadText="]]><xsl:value-of select="GridHeadText"/><![CDATA[" GridColumnName="]]><xsl:value-of select="GridColumnName"/><![CDATA[" Width="]]><xsl:value-of select="GridColumnWidth"/><![CDATA[" ></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="DBType = 'Image'">
<![CDATA[                         <img id="]]><xsl:value-of select="FieldName"/><![CDATA[_Image" width="130" height="160" src=']]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=<%=Request.QueryString["ObjectID"]%><%=AndChar%>ImageField=]]><xsl:value-of select="FieldName"/><![CDATA[' />]]>
<![CDATA[                         <div id="]]><xsl:value-of select="FieldName"/><![CDATA[_Local" style="filter:progid:DXImageTransform.Microsoft.AlphaImageLoader(sizingMethod=scale);"></div>]]>
<![CDATA[                         <asp:FileUpload ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></asp:FileUpload>]]>
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
                                  <xsl:when test="ControlType = '单行文本框'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:when test="ControlType = 'RadMaskedTextBox'">
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" Mask="]]><xsl:value-of select="Mask"/><![CDATA[" DisplayMask="]]><xsl:value-of select="DisplayMask"/><![CDATA[" CssClass="input]]><xsl:if test="IsAllOneRow = 'true'"><![CDATA[ widthfull]]></xsl:if><![CDATA["></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:when>
                                  <xsl:otherwise>
<![CDATA[                             <]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[ ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input"></]]><xsl:value-of select="ControlTypePrefix"/><![CDATA[:]]><xsl:value-of select="ControlTypeName"/><![CDATA[>]]>
                                  </xsl:otherwise>
                                </xsl:choose>               
<![CDATA[                         </div><div class="fieldnote" id="]]><xsl:value-of select="FieldName"/><![CDATA[_Note" runat="server">]]>
                                      <xsl:value-of select="FieldReadme"/>
<![CDATA[                         </div>]]>
<![CDATA[                         </div>]]>
<![CDATA[                     </div>]]>
  </xsl:if>
  </xsl:if>
  </xsl:if>
</xsl:for-each>
<![CDATA[                    <div class="clearboth"></div>]]>
<![CDATA[                    </telerik:RadPageView>]]>
<![CDATA[                </telerik:RadMultiPage>]]>
<![CDATA[                <!-- 相关表批量添加 -->]]>
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
    <xsl:if test="IsAddBatch = 'true'">
        <xsl:if test="IsAddBatchTemplate = 'true'">
<![CDATA[                <div class="list">]]>
<![CDATA[                   <div class="list">]]><xsl:value-of select="RelatedInfoName"/><![CDATA[</div>]]>
<![CDATA[                   <asp:GridView ID="rpt]]><xsl:value-of select="RelatedTableName"/><![CDATA[" runat="server" CssClass="list" AutoGenerateColumns="false"  onprerender="rptRelatedTable_PreRender"></asp:GridView>]]>
<![CDATA[                </div>]]>
        </xsl:if>
    </xsl:if>
</xsl:for-each>
<![CDATA[                </div>]]>
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
<![CDATA[        </center>]]>
<![CDATA[</asp:Content>]]>
</xsl:template>
</xsl:stylesheet>