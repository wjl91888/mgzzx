<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIDetailForApp.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/AppBasePage.master" EnableEventValidation="false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIDetail.aspx.cs" Inherits="App.]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIDetail" %>
<%@ Register TagPrefix="control" TagName="FilesList" Src="~/Control/UploadFilesControlForApp.ascx" %>
<asp:Content ID="ContentHeaderTitle" ContentPlaceHolderID="HeadTitleContentPlaceHolder" runat="server">
    ]]><xsl:value-of select="/NewDataSet/TableRemark"/><![CDATA[
</asp:Content>
<asp:Content ID="ContentHeader" ContentPlaceHolderID="HeaderContentPlaceHolder" runat="server">
</asp:Content>
<asp:Content ID="TopNavContainer" ContentPlaceHolderID="TopNavContainerPlaceHolder" runat="server">
</asp:Content>
]]>
<![CDATA[
<asp:Content ID="ContentMain" ContentPlaceHolderID="MainContainerPlaceHolder" runat="server">
<div id="AppDetailPage">
    <asp:Repeater ID="rptDetail" runat="server">
        <ItemTemplate>
            <div class="page-header">
                <h4>
                    <%# GetValue(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="/NewDataSet/TitleField"/><![CDATA["), null)%></h4>
            </div>]]>
    <xsl:for-each select="/NewDataSet/RecordInfo">
        <xsl:if test="IsShowDetail = 'true'">
<![CDATA[            <div id="]]><xsl:value-of select="FieldName"/><![CDATA[Container" runat="server" class="row">]]>
<![CDATA[                <div id="]]><xsl:value-of select="FieldName"/><![CDATA[Caption" runat="server" class="fontbold col-xs-]]><xsl:value-of select="AppDetailCaptionColumn"/><![CDATA[ paddingleft0">]]><xsl:value-of select="FieldRemark"/><![CDATA[</div>]]>
<![CDATA[                <div id="]]><xsl:value-of select="FieldName"/><![CDATA[Content" runat="server" class="col-xs-]]><xsl:value-of select="AppDetailContentColumn"/><![CDATA[">]]>
        <xsl:if test="IsDataBind = 'true'">
<![CDATA[                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/><![CDATA[")%>]]>
        </xsl:if>
        <xsl:if test="IsDataBind = 'false'">
            <xsl:choose>
                <xsl:when test="ControlType = '图片上传'">
<![CDATA[                    <%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") == DBNull.Value ? "" : "<img class='img-responsive' src='" + DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[") + "' />"%>]]>
                </xsl:when>
                <xsl:when test="ControlTypeName = 'FilesList'">
<![CDATA[                    <control:FilesList ID="]]><xsl:value-of select="FieldName"/><![CDATA[" runat="server" CssClass="input" ReadOnly="true" Text='<%# DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA[")%>'></control:FilesList>]]>
                </xsl:when>
                <xsl:when test="DBType = 'Image'">
<![CDATA[                    <img class='img-responsive' src='<%# "]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx?ObjectID=" + DataBinder.Eval(Container.DataItem, "ObjectID") + AndChar + "ImageField=]]><xsl:value-of select="FieldName"/><![CDATA["%>'  />]]>
                </xsl:when>
                <xsl:otherwise>
<![CDATA[                    <%# GetValue(DataBinder.Eval(Container.DataItem, "]]><xsl:value-of select="FieldName"/><![CDATA["), ]]><xsl:value-of select="DisplayFormatString"/><![CDATA[)%>]]>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:if>
<![CDATA[                </div>]]>
<![CDATA[            </div>]]>
        </xsl:if>
    </xsl:for-each>
<![CDATA[
        </ItemTemplate>
    </asp:Repeater>
</div>
</asp:Content>
<asp:Content ID="PageNavContainer" ContentPlaceHolderID="PageNavContainerPlaceHolder" runat="server">
    <ul id="PageInfo" runat="server" class="nav  navbar-default">
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;">
            <input type="button" id ="btnEditItem" runat ="server" value="修改" class="btn btn-default navbar-btn" />
        </li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
        <li class="col-sm-3 col-xs-3 text-center" style="padding-right: 0px !important; padding-left: 0px !important;"></li>
    </ul>
</asp:Content>
]]>
</xsl:template>
</xsl:stylesheet>