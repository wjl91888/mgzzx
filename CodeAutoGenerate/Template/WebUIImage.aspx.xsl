<?xml version="1.0" encoding="GB2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIDetail.aspx.xsl'"/>
<xsl:template match="/">
<![CDATA[<%@ Page Language="C#" EnableEventValidation = "false" AutoEventWireup="true" CodeFile="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage.aspx.cs" Inherits="]]><xsl:value-of select="/NewDataSet/TableName"/><![CDATA[WebUIImage" %>]]>
<![CDATA[<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">]]>
<![CDATA[<html xmlns="http://www.w3.org/1999/xhtml">]]>
<![CDATA[<head runat="server">]]>
<![CDATA[    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />]]>
<![CDATA[    <meta name="description" content="" />]]>
<![CDATA[    <meta name="keywords" content="" />]]>
<![CDATA[    <title></title>]]>
<![CDATA[</head>]]>
<![CDATA[<body>]]>
<![CDATA[    <form id="SubmitForm" runat="server" autocomplete="off">]]>
<![CDATA[    </form>]]>
<![CDATA[</body>]]>
<![CDATA[</html>]]>
</xsl:template>
</xsl:stylesheet>