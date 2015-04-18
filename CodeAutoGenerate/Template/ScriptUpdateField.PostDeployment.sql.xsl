<?xml version="1.0" encoding="GB2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'PurviewInfoSQLScript.sql.xsl'"/>
<xsl:template match="/">
USE [<xsl:value-of select="/NewDataSet/DataBaseName"/>]
  
 <xsl:for-each select="/NewDataSet/RecordInfo">
 IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = '<xsl:value-of select="FieldName"/>' AND [TableName] = '<xsl:value-of select="/NewDataSet/TableName"/>'))
 BEGIN
	 INSERT INTO [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'<xsl:value-of select="FieldName"/>'
			   ,'<xsl:value-of select="/NewDataSet/TableName"/>'
			   ,'<xsl:value-of select="/NewDataSet/PurviewPrefix"/>'
			   ,'<xsl:value-of select="FieldRemark"/>'
			   ,<xsl:choose><xsl:when test="IsUse = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsAdd = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsNull = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsModify = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsNonModifiable = 'true'">0</xsl:when><xsl:otherwise>1</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsList = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsSearch = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   ,<xsl:choose><xsl:when test="IsShowDetail = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
			   )
END
ELSE
BEGIN
	UPDATE [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>'
		  ,[FieldRemark] = '<xsl:value-of select="FieldRemark"/>'
		  ,[IsUse] = <xsl:choose><xsl:when test="IsUse = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
		  ,[IsAdd] = <xsl:choose><xsl:when test="IsAdd = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
		  ,[Nullable] = <xsl:choose><xsl:when test="IsNull = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
		  ,[IsModify] = <xsl:choose><xsl:when test="IsModify = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
		  ,[Modifiable] = <xsl:choose><xsl:when test="IsNonModifiable = 'true'">0</xsl:when><xsl:otherwise>1</xsl:otherwise></xsl:choose>
		  ,[IsList] = <xsl:choose><xsl:when test="IsList = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
		  ,[IsSearch] = <xsl:choose><xsl:when test="IsSearch = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
		  ,[IsDetail] = <xsl:choose><xsl:when test="IsShowDetail = 'true'">1</xsl:when><xsl:otherwise>0</xsl:otherwise></xsl:choose>
	 WHERE [FieldName] = '<xsl:value-of select="FieldName"/>' AND [TableName] = '<xsl:value-of select="/NewDataSet/TableName"/>'
END
GO
</xsl:for-each>  
</xsl:template>
</xsl:stylesheet>