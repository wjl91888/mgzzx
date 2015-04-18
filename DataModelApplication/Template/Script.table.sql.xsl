<?xml version="1.0" encoding="GB2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'PurviewInfoSQLScript.sql.xsl'"/>
<xsl:template match="/">
CREATE TABLE [dbo].[<xsl:value-of select="/NewDataSet/TableName"/>](
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
      <xsl:choose>
        <xsl:when test="IsNull = 'true'">
          [<xsl:value-of select="FieldName"/>]<xsl:value-of select="' '"/>[<xsl:value-of select="DBType"/>]<xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/><xsl:value-of select="' '"/>NULL
        </xsl:when>
        <xsl:otherwise>
          [<xsl:value-of select="FieldName"/>]<xsl:value-of select="' '"/>[<xsl:value-of select="DBType"/>]<xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/><xsl:value-of select="' '"/>NOT NULL
        </xsl:otherwise>
      </xsl:choose>
    </xsl:when>
    <xsl:otherwise>
      <xsl:choose>
        <xsl:when test="IsNull = 'true'">
          ,[<xsl:value-of select="FieldName"/>]<xsl:value-of select="' '"/>[<xsl:value-of select="DBType"/>]<xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/><xsl:value-of select="' '"/>NULL
        </xsl:when>
        <xsl:otherwise>
          ,[<xsl:value-of select="FieldName"/>]<xsl:value-of select="' '"/>[<xsl:value-of select="DBType"/>]<xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/><xsl:value-of select="' '"/>NOT NULL
        </xsl:otherwise>
      </xsl:choose>
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
CONSTRAINT [PK_<xsl:value-of select="/NewDataSet/TableName"/>] PRIMARY KEY CLUSTERED
(
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
  [<xsl:value-of select="FieldName"/>]<xsl:value-of select="' '"/>ASC</xsl:when>
        <xsl:otherwise>
  ,[<xsl:value-of select="FieldName"/>]<xsl:value-of select="' '"/>ASC</xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

<xsl:for-each select="/NewDataSet/RecordInfo">
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'<xsl:value-of select="FieldRemark"/>' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'<xsl:value-of select="/NewDataSet/TableName"/>', @level2type=N'COLUMN',@level2name=N'<xsl:value-of select="FieldName"/>'
GO
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="SPDefaultValue = 'NULL'"></xsl:when>
      <xsl:otherwise>
ALTER TABLE [dbo].[<xsl:value-of select="/NewDataSet/TableName"/>] ADD  CONSTRAINT [DF_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>]  DEFAULT (<xsl:value-of select="SPDefaultValue"/>) FOR [<xsl:value-of select="FieldName"/>]
GO
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
</xsl:template>
</xsl:stylesheet>