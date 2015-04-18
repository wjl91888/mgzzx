<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="GB2312"/>
  <xsl:variable name="FileName" select="'BusinessEntity.cs.xsl'"/>
  <xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Configuration;
using System.Collections;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using RICH.Common;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.BusinessEntity;

namespace RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>
{
    //=========================================================================
    //  ClassName : <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity
    /// <summary>
    /// <xsl:value-of select="/NewDataSet/TableName"/>的扩展逻辑实体类
    /// </summary>
    //=========================================================================
    public class <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity : <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntityBase
    {

    }
}
  </xsl:template>
</xsl:stylesheet>