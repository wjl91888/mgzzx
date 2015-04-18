<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="GB2312"/>
  <xsl:variable name="FileName" select="'WebUI.cs.xsl'"/>
  <xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>WebUI.cs
******************************************************/
using System;
using System.Data;

namespace RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>
{
    //=========================================================================
    //  ClassName : <xsl:value-of select="/NewDataSet/TableName"/>WebUI
    /// <summary>
    /// <xsl:value-of select="/NewDataSet/TableName"/>的扩展逻辑实体类
    /// </summary>
    //=========================================================================
    public class <xsl:value-of select="/NewDataSet/TableName"/>WebUI : <xsl:value-of select="/NewDataSet/TableName"/>WebUIBase
    {

    }
}
  </xsl:template>
</xsl:stylesheet>