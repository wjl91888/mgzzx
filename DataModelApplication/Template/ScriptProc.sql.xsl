<?xml version="1.0" encoding="GB2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'StoreProcedureSQLScript.sql.xsl'"/>
<xsl:template match="/">
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Insert<xsl:value-of select="/NewDataSet/TableName"/>]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Insert<xsl:value-of select="/NewDataSet/TableName"/>]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>插入的存储过程

CREATE   PROCEDURE [dbo].[SP_Insert<xsl:value-of select="/NewDataSet/TableName"/>] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
      <xsl:choose>
        <xsl:when test="IsNull = 'true'">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="DBType"/><xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/>  = NULL</xsl:when>
        <xsl:otherwise>
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="DBType"/><xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:when>
    <xsl:otherwise>
      <xsl:choose>
        <xsl:when test="IsNull = 'true'">
,@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="DBType"/><xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/>  = NULL</xsl:when>
      <xsl:otherwise>
,@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="DBType"/><xsl:value-of select="' '"/><xsl:value-of select="SPDataSize"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>

AS
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="DBType = 'NText'">
    </xsl:when>
    <xsl:when test="DBType = 'Text'">
    </xsl:when>
    <xsl:when test="DBType = 'Image'">
    </xsl:when>
    <xsl:otherwise>
IF @<xsl:value-of select="FieldName"/> IS NULL
    SET @<xsl:value-of select="FieldName"/> = <xsl:value-of select="SPDefaultValue"/>
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    (
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="position() = 1">
    [<xsl:value-of select="FieldName"/>]</xsl:when>
        <xsl:otherwise>
    ,[<xsl:value-of select="FieldName"/>]</xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
    )
    VALUES
    (
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="position() = 1">
    @<xsl:value-of select="FieldName"/>
        </xsl:when>
        <xsl:otherwise>
    ,@<xsl:value-of select="FieldName"/>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
    )
    <xsl:if test="/NewDataSet/MutilInsert = 'true'">
    --同表多条插入
    INSERT INTO [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    (
    ObjectID
    <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="MutilInsertField = 'true'">
    ,[<xsl:value-of select="FieldName"/>]</xsl:if>
    </xsl:for-each>
    )
    (SELECT
    newid()
    <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="MutilInsertField = 'true'">
  <xsl:choose>
    <xsl:when test="MutilInsertCondition = 'true'">
    ,[<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>]
    </xsl:when>
    <xsl:when test="MutilInsertFieldDefaultValue">
    ,<xsl:value-of select="MutilInsertFieldDefaultValue"/>
    </xsl:when>
    <xsl:otherwise>
    ,@<xsl:value-of select="FieldName"/>
    </xsl:otherwise>
  </xsl:choose>
    </xsl:if>
    </xsl:for-each>
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    <xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="MutilInsertCondition = 'true'">
    INNER JOIN [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE '%'+[<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>]+'%' 
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
    </xsl:if>
    </xsl:for-each>
    )
    </xsl:if>
    --更新相关表信息
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsRelatedUpdate = 'true'">
          <xsl:choose>
            <xsl:when test="RelatedUpdateType = '加一'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="DisplayFieldName"/>] + 1
    WHERE [<xsl:value-of select="RelatedTableWithField"/>] = @<xsl:value-of select="TableWithField"/>
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减一'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="DisplayFieldName"/>] - 1
    WHERE [<xsl:value-of select="RelatedTableWithField"/>] = @<xsl:value-of select="TableWithField"/>
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '加'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="DisplayFieldName"/>] + @<xsl:value-of select="RelatedUpdateField"/>
    WHERE [<xsl:value-of select="RelatedTableWithField"/>] = @<xsl:value-of select="TableWithField"/>
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="DisplayFieldName"/>] - @<xsl:value-of select="RelatedUpdateField"/>
    WHERE [<xsl:value-of select="RelatedTableWithField"/>] = @<xsl:value-of select="TableWithField"/>
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '赋值'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = @<xsl:value-of select="RelatedUpdateField"/>
    WHERE [<xsl:value-of select="RelatedTableWithField"/>] = @<xsl:value-of select="TableWithField"/>
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '自定义'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = <xsl:value-of select="RelatedUpdateValue"/>
    WHERE [<xsl:value-of select="RelatedTableWithField"/>] = @<xsl:value-of select="TableWithField"/>
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:if>
    </xsl:for-each>
COMMIT TRANSACTION
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        <xsl:if test="DBType = 'DateTime'">
, @<xsl:value-of select="FieldName"/>Begin<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>End<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        </xsl:if>
    </xsl:when>
    <xsl:otherwise>
, @<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        <xsl:if test="DBType = 'DateTime'">
, @<xsl:value-of select="FieldName"/>Begin<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>End<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        </xsl:if>
    </xsl:otherwise>
  </xsl:choose>
, @<xsl:value-of select="FieldName"/>Value<xsl:value-of select="' '"/><xsl:value-of select="SPUpdateDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>Batch<xsl:value-of select="' '"/>nvarchar(1000) = NULL
</xsl:for-each>
, @QueryType nvarchar(50) = 'AND'
, @QueryKeywords nvarchar(50) = NULL
, @RecordCount int Output

AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @SortText nvarchar(255)

IF @QueryType IS NULL 
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'AND'
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'OR'
    SET @QueryType = 'OR'
ELSE
    SET @QueryType = 'AND'

IF @QueryType = 'AND'
BEGIN
    SET @ConditionText = '( [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].ObjectID IS NOT NULL '
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="DBType = 'DateTime'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
    IF @<xsl:value-of select="FieldName"/>Begin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> >= '''+CAST(@<xsl:value-of select="FieldName"/>Begin AS nvarchar(100))+''' '
    IF @<xsl:value-of select="FieldName"/>End IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="FieldName"/>End AS nvarchar(100))+''' '
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
    IF @<xsl:value-of select="FieldName"/>Batch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@<xsl:value-of select="FieldName"/>Batch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/>)+''%'' '
    </xsl:for-each>
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].ObjectID IS NULL '
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="DBType = 'DateTime'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
    IF @<xsl:value-of select="FieldName"/>Begin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> >= '''+CAST(@<xsl:value-of select="FieldName"/>Begin AS nvarchar(100))+''' '
    IF @<xsl:value-of select="FieldName"/>End IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="FieldName"/>End AS nvarchar(100))+''' '
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/> LIKE '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
        </xsl:otherwise>
      </xsl:choose>
    IF @<xsl:value-of select="FieldName"/>Batch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@<xsl:value-of select="FieldName"/>Batch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/>)+''%'' '
    </xsl:for-each>
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] SET '
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
    IF @<xsl:value-of select="FieldName"/>Value IS NOT NULL
       SET  @SqlText = @SqlText + ' <xsl:value-of select="FieldName"/> = @<xsl:value-of select="FieldName"/>Value'
    ELSE
        SET @SqlText = @SqlText + ' <xsl:value-of select="FieldName"/> = [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/>'
  </xsl:when>
  <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/>Value IS NOT NULL
        SET @SqlText = @SqlText + ' ,<xsl:value-of select="FieldName"/> = @<xsl:value-of select="FieldName"/>Value'
    ELSE
        SET @SqlText = @SqlText + ' ,<xsl:value-of select="FieldName"/> = [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].<xsl:value-of select="FieldName"/>'
  </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
SET @SqlText = @SqlText + ' FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] WHERE ' + @ConditionText
PRINT @SqlText
EXECUTE(@SqlText)
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPUpdateDataType"/> = NULL</xsl:when>
  <xsl:otherwise>
,@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPUpdateDataType"/> = NULL</xsl:otherwise>
  </xsl:choose>
</xsl:for-each>

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsRelatedUpdate = 'true'">
          <xsl:choose>
            <xsl:when test="RelatedUpdateType = '加'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] - [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>] + @<xsl:value-of select="RelatedUpdateField"/>
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>] - @<xsl:value-of select="RelatedUpdateField"/>
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:if>
    </xsl:for-each>
    --主表更新
    UPDATE [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    SET 
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="position() = 1">
    [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/></xsl:when>
        <xsl:otherwise>
    , [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/></xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
    WHERE ObjectID = @ObjectID
COMMIT TRANSACTION


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByKey]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByKey] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPUpdateDataType"/> = NULL</xsl:when>
  <xsl:otherwise>
,@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPUpdateDataType"/> = NULL</xsl:otherwise>
  </xsl:choose>
</xsl:for-each>

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    <xsl:for-each select="/NewDataSet/RecordInfo">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
    BEGIN
        UPDATE [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
        SET [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/>
        WHERE
        <xsl:for-each select="/NewDataSet/RecordInfo">
        <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
        <xsl:if test="IsPrimaryKey = 'true'">
          <xsl:choose>
            <xsl:when test="position() = 1">
        [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/> 
            </xsl:when>
            <xsl:otherwise>
        AND [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
        </xsl:for-each>
    END
    </xsl:for-each>
COMMIT TRANSACTION


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_Update<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL
<xsl:for-each select="/NewDataSet/RecordInfo">
,@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPUpdateDataType"/> = NULL
</xsl:for-each>

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsRelatedUpdate = 'true'">
          <xsl:choose>
            <xsl:when test="RelatedUpdateType = '加'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] - [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>] + @<xsl:value-of select="RelatedUpdateField"/>
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])+'%'
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>] - @<xsl:value-of select="RelatedUpdateField"/>
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])+'%'
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:if>
    </xsl:for-each>
    --主表更新
    <xsl:for-each select="/NewDataSet/RecordInfo">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
    BEGIN
        UPDATE [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
        SET [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/> WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    </xsl:for-each>
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsRelatedUpdate = 'true'">
          <xsl:choose>
            <xsl:when test="RelatedUpdateType = '加一'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] - 1
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减一'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] + 1
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '加'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] - [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>]
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>]
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:if>
    </xsl:for-each>
    --主表删除
    DELETE [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    WHERE [ObjectID] = @ObjectID
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByKey]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByKey] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL</xsl:when>
      <xsl:otherwise>
, @<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL</xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
WHERE
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
[<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/> 
      </xsl:when>
      <xsl:otherwise>
AND [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_Delete<xsl:value-of select="/NewDataSet/TableName"/>ByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
      <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
      <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsRelatedUpdate = 'true'">
          <xsl:choose>
            <xsl:when test="RelatedUpdateType = '加一'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] - 1
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])+'%'
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减一'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] + 1
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])+'%'
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '加'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] - [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>]
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])+'%'
            </xsl:when>
            <xsl:when test="RelatedUpdateType = '减'">
    UPDATE [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    SET [<xsl:value-of select="DisplayFieldName"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="RelatedUpdateField"/>]
    FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    INNER JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>]
    ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>] = [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>]
    WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])+'%'
            </xsl:when>
            <xsl:otherwise>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:if>
    </xsl:for-each>
--主表删除
    DELETE [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
    WHERE  (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition] 
--主表参数
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        <xsl:if test="IsRangeSearch = 'true'">
, @<xsl:value-of select="FieldName"/>Begin<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>End<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        </xsl:if>
    </xsl:when>
  <xsl:otherwise>
, @<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        <xsl:if test="IsRangeSearch = 'true'">
, @<xsl:value-of select="FieldName"/>Begin<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>End<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
        </xsl:if>
    </xsl:otherwise>
  </xsl:choose>
, @<xsl:value-of select="FieldName"/>Batch<xsl:value-of select="' '"/>nvarchar(4000) = NULL
</xsl:for-each>
--一对一相关表参数
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
    <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsAdvanceSearch = 'true'">
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><xsl:value-of select="' '"/>nvarchar(500) = NULL
            <xsl:if test="IsRangeSearch = 'true'">
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin<xsl:value-of select="' '"/>nvarchar(500) = NULL
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End<xsl:value-of select="' '"/>nvarchar(500) = NULL
            </xsl:if>
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch<xsl:value-of select="' '"/>nvarchar(4000) = NULL
        </xsl:if>
    </xsl:if>
</xsl:for-each>
, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = '<xsl:value-of select="/NewDataSet/SortField"/>'
, @PageSize int = 500
, @CurrentPage int = 1
, @RecordCount int Output
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsSum = 'true'">
, @<xsl:value-of select="FieldName"/>Sum<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> Output</xsl:if>
</xsl:for-each>

AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @SqlTextCount nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @FromText nvarchar(4000) 
DECLARE @SortText nvarchar(255)
DECLARE @InnerSortText nvarchar(4000)
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsSum = 'true'">
DECLARE @SqlText<xsl:value-of select="FieldName"/>Sum nvarchar(4000)</xsl:if>
</xsl:for-each>

IF @QueryType IS NULL 
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'AND'
    SET @QueryType = 'AND'
ELSE IF @QueryType = 'OR'
    SET @QueryType = 'OR'
ELSE
    SET @QueryType = 'AND'

IF @Sort IS NULL 
    SET @Sort = 0
IF @SortField IS NULL 
    SET @SortField = '<xsl:value-of select="/NewDataSet/SortField"/>'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] IS NOT NULL '
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="IsRangeSearch = 'true'">
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
    IF @<xsl:value-of select="FieldName"/>Begin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] >= '''+CAST(@<xsl:value-of select="FieldName"/>Begin AS nvarchar(100))+''' '
    IF @<xsl:value-of select="FieldName"/>End IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="FieldName"/>End AS nvarchar(100))+''' '
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
    --一对一相关表查询条件
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
        <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
        <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
        <xsl:if test="RelatedTableType = '1_to_1'">
            <xsl:if test="IsAdvanceSearch = 'true'">
              <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] = '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> AS nvarchar(100))+''' '
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] >= '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin AS nvarchar(100))+''' '
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End AS nvarchar(100))+''' '
                </xsl:when>
                <xsl:otherwise>
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] = '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> AS nvarchar(100))+''' '
                </xsl:otherwise>
              </xsl:choose>
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '','+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch AS nvarchar(4000))+','' LIKE ''%,''+CONVERT(nvarchar(50), [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>])+'',%'' '
            </xsl:if>
        </xsl:if>
    </xsl:for-each>
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].ObjectID IS NULL '
    <xsl:for-each select="/NewDataSet/RecordInfo">
      <xsl:choose>
        <xsl:when test="IsRangeSearch = 'true'">
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
    IF @<xsl:value-of select="FieldName"/>Begin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] >= '''+CAST(@<xsl:value-of select="FieldName"/>Begin AS nvarchar(100))+''' '
    IF @<xsl:value-of select="FieldName"/>End IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="FieldName"/>End AS nvarchar(100))+''' '
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
    IF @<xsl:value-of select="FieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
    </xsl:for-each>
    --一对一相关表查询条件
    <xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
        <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
        <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
        <xsl:if test="RelatedTableType = '1_to_1'">
            <xsl:if test="IsAdvanceSearch = 'true'">
              <xsl:choose>
                <xsl:when test="IsRangeSearch = 'true'">
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] = '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> AS nvarchar(100))+''' '
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] >= '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin AS nvarchar(100))+''' '
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End AS nvarchar(100))+''' '
                </xsl:when>
                <xsl:otherwise>
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] = '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> AS nvarchar(100))+''' '
                </xsl:otherwise>
              </xsl:choose>
    IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '','+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch AS nvarchar(4000))+','' LIKE ''%,''+CONVERT(nvarchar(50), [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>])+'',%'' '
            </xsl:if>
        </xsl:if>
    </xsl:for-each>
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
      <xsl:choose>
        <xsl:when test="DBType = 'NText'">
        </xsl:when>
        <xsl:when test="DBType = 'Text'">
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
      [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]
        </xsl:otherwise>
      </xsl:choose>
    </xsl:when>
    <xsl:otherwise>
      <xsl:choose>
        <xsl:when test="DBType = 'NText'">
        </xsl:when>
        <xsl:when test="DBType = 'Text'">
        </xsl:when>
        <xsl:when test="DBType = 'Image'">
        </xsl:when>
        <xsl:otherwise>
      , [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]
        </xsl:otherwise>
      </xsl:choose>
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
   <xsl:if test="IsDataBind = 'true'">
      <xsl:choose>
          <xsl:when test="IsMoreItemDisplay = 'true'">
        ,[dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="DataBindTextField"/>By<xsl:value-of select="FieldName"/>]([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>]</xsl:when>
          <xsl:otherwise>
        ,[<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>]</xsl:otherwise></xsl:choose></xsl:if>
</xsl:for-each>
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
        , [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>]
      <xsl:choose>
          <xsl:when test="IsMoreItemDisplay = 'true'">
        ,[dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>]([<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>]) AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>]
          </xsl:when>
          <xsl:when test="IsBindData = 'true'">
        , [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataFieldName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>]
          </xsl:when>
          <xsl:otherwise>
          </xsl:otherwise>
     </xsl:choose>
  </xsl:if></xsl:if>
</xsl:for-each>
'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '
<xsl:for-each select="/NewDataSet/RecordInfo">
   <xsl:if test="IsDataBind = 'true'">
      <xsl:choose>
          <xsl:when test="IsMoreItemDisplay = 'true'">
        ,[dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="DataBindTextField"/>By<xsl:value-of select="FieldName"/>]([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>]</xsl:when>
          <xsl:otherwise>
        ,[<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>]</xsl:otherwise></xsl:choose></xsl:if>
</xsl:for-each>
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
      , [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>]</xsl:if></xsl:if>
</xsl:for-each>
'
END
--主表
SET @FromText = '
 FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]'
--主表与一对一相关表连接
SET @FromText = @FromText + '
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
      <xsl:if test="IsDataBind = 'false'">
    LEFT JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>] ON [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>] = [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>]</xsl:if></xsl:if>
</xsl:for-each>
'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
      <xsl:if test="IsBindData = 'true'">
    LEFT JOIN [<xsl:value-of select="BindDataTableOwner"/>].[<xsl:value-of select="BindDataTableName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>] ON [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataRelativeFieldName"/>] = [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]</xsl:if></xsl:if></xsl:if>
</xsl:for-each>
'
--主表与绑定表连接
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsDataBind = 'true'">
SET @FromText = @FromText + '
    LEFT JOIN [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>] AS <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/> ON <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindValueField"/>] = [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] <xsl:if test="DataBindCondition != 'null'"> AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindCondition"/>] = ''<xsl:value-of select="DataBindConditionValue"/>''</xsl:if>
'
	<xsl:if test="IsCoupledNext = 'true'">
	IF @<xsl:value-of select="CoupledDataSourcePrevious"/> IS NOT NULL
	BEGIN
	SET @FromText = @FromText + '
		 AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindValueField"/>] = '''+@<xsl:value-of select="CoupledDataSourcePrevious"/>+'''
	'
	END
    </xsl:if> 
  </xsl:if>
</xsl:for-each>
--多项查询
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="DBType = 'NText'">
    </xsl:when>
    <xsl:when test="DBType = 'Text'">
    </xsl:when>
    <xsl:when test="DBType = 'Image'">
    </xsl:when>
    <xsl:otherwise>
IF @<xsl:value-of select="FieldName"/>Batch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [<xsl:value-of select="/NewDataSet/TableOnwer"/>].F_SplitStr('''+CAST(@<xsl:value-of select="FieldName"/>Batch AS nvarchar(4000))+''', '','') AS <xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>_Batch ON '','' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + '','' LIKE ''%,'' + <xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>_Batch.col +'',%''
'
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>

--查询条件
SET @InnerSortText = '
[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID]
' + @FromText + '
WHERE ' + @ConditionText + ' ' + @SortText + '
)'

SET @SqlTextCount = 'SELECT @RecordCount=COUNT(*) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsSum = 'true'">
SET @SqlText<xsl:value-of select="FieldName"/>Sum = 'SELECT @<xsl:value-of select="FieldName"/>Sum = SUM([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlText<xsl:value-of select="FieldName"/>Sum,N'@<xsl:value-of select="FieldName"/>Sum<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/><xsl:value-of select="' '"/>OUTPUT',@<xsl:value-of select="FieldName"/>Sum OUTPUT   --返回@<xsl:value-of select="FieldName"/>Sum</xsl:if>
</xsl:for-each>

PRINT @SqlText
PRINT @FromText
PRINT ' WHERE '
PRINT @InnerSortText
PRINT ' AND ' + @ConditionText + ' ' + @SortText
EXECUTE(@SqlText + @FromText + ' WHERE ' + @InnerSortText + ' AND ' + @ConditionText + ' ' + @SortText)

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  <xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
      [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]
    </xsl:when>
    <xsl:otherwise>
      , [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
   <xsl:if test="IsDataBind = 'true'">
      <xsl:choose>
          <xsl:when test="IsMoreItemDisplay = 'true'">
        ,[dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="DataBindTextField"/>By<xsl:value-of select="FieldName"/>]([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>]</xsl:when>
          <xsl:otherwise>
        ,[<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>_<xsl:value-of select="DataBindTextField"/>]</xsl:otherwise></xsl:choose></xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
      , [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>]</xsl:if></xsl:if>
</xsl:for-each>
FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDataBind = 'false'">
      LEFT JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>] ON [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>] = [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>]
    </xsl:if>
  </xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
      <xsl:if test="IsBindData = 'true'">
    LEFT JOIN [<xsl:value-of select="BindDataTableOwner"/>].[<xsl:value-of select="BindDataTableName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>] ON [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataRelativeFieldName"/>] = [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]</xsl:if></xsl:if></xsl:if>
</xsl:for-each>
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsDataBind = 'true'">
    LEFT JOIN [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>] AS <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/> ON <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindValueField"/>] = [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] <xsl:if test="DataBindCondition != 'null'"> AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindCondition"/>] = '<xsl:value-of select="DataBindConditionValue"/>'</xsl:if></xsl:if>
</xsl:for-each>
WHERE
[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByKey]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_Select<xsl:value-of select="/NewDataSet/TableName"/>ByKey] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL</xsl:when>
      <xsl:otherwise>
, @<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL</xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>

AS
SELECT 
  <xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:choose>
    <xsl:when test="position() = 1">
      [<xsl:value-of select="FieldName"/>]
    </xsl:when>
    <xsl:otherwise>
      , [<xsl:value-of select="FieldName"/>]
    </xsl:otherwise>
  </xsl:choose>
</xsl:for-each>
FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
WHERE
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
[<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/>
      </xsl:when>
      <xsl:otherwise>
AND [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID]
GO

--表[<xsl:value-of select="/NewDataSet/TableName"/>]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByKey]
GO

--表[<xsl:value-of select="/NewDataSet/TableName"/>]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExist<xsl:value-of select="/NewDataSet/TableName"/>ByKey] 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
@<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL</xsl:when>
      <xsl:otherwise>
, @<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL</xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
WHERE 
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsPrimaryKey = 'true'">
    <xsl:choose>
      <xsl:when test="position() = 1">
[<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/> 
      </xsl:when>
      <xsl:otherwise>
AND [<xsl:value-of select="FieldName"/>] = @<xsl:value-of select="FieldName"/>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:if>
</xsl:for-each>

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Count<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Count<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_Count<xsl:value-of select="/NewDataSet/TableName"/>ByAnyCondition] 
@CountField NVarChar(200)
--主表参数
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsStatisticalCondition = 'true'">
, @<xsl:value-of select="FieldName"/><xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>Batch<xsl:value-of select="' '"/>nvarchar(4000) = NULL
    <xsl:if test="IsRangeSearch = 'true'">
, @<xsl:value-of select="FieldName"/>Begin<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
, @<xsl:value-of select="FieldName"/>End<xsl:value-of select="' '"/><xsl:value-of select="SPSelectDataType"/> = NULL
    </xsl:if>
  </xsl:if>
</xsl:for-each>
--一对一相关表参数
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
    <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsAdvanceSearch = 'true'">
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/><xsl:value-of select="' '"/>nvarchar(500) = NULL
            <xsl:if test="IsRangeSearch = 'true'">
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin<xsl:value-of select="' '"/>nvarchar(500) = NULL
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End<xsl:value-of select="' '"/>nvarchar(500) = NULL
            </xsl:if>
, @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch<xsl:value-of select="' '"/>nvarchar(4000) = NULL
        </xsl:if>
    </xsl:if>
</xsl:for-each>
, @Sort bit = 0
, @SortField nvarchar(50) = 'RecordCount'
, @RecordCount int OUTPUT

AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @SqlTextCount nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @FromText nvarchar(4000) 
DECLARE @SelectListText nvarchar(4000) 
DECLARE @TotalSelectListText nvarchar(4000) 
DECLARE @InnerJoinText nvarchar(4000) 
DECLARE @SortText nvarchar(255) 
IF @Sort IS NULL 
    SET @Sort = 0

IF @SortField IS NULL 
    SET @SortField = 'RecordCount'

SET @SortText = ' ORDER BY ' + @SortField + ' '

IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '
--主表查询条件
SET @ConditionText = ' [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].ObjectID IS NOT NULL '
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsStatisticalCondition = 'true'">
      <xsl:choose>
        <xsl:when test="IsRangeSearch = 'true'">
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
IF @<xsl:value-of select="FieldName"/> IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
IF @<xsl:value-of select="FieldName"/> IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
IF @<xsl:value-of select="FieldName"/>Begin IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] >= '''+CAST(@<xsl:value-of select="FieldName"/>Begin AS nvarchar(100))+''' '
IF @<xsl:value-of select="FieldName"/>End IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="FieldName"/>End AS nvarchar(100))+''' '
        </xsl:when>
        <xsl:otherwise>
          <xsl:choose>
            <xsl:when test="IsApproximateSearch = 'true'">
IF @<xsl:value-of select="FieldName"/> IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] LIKE ''<xsl:if test="PrefixMatch = 'false'">%</xsl:if>'+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+'%'' '
            </xsl:when>
            <xsl:otherwise>
IF @<xsl:value-of select="FieldName"/> IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] = '''+CAST(@<xsl:value-of select="FieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
        </xsl:otherwise>
      </xsl:choose>
  </xsl:if>
</xsl:for-each>
--一对一相关表查询条件
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
    <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsAdvanceSearch = 'true'">
          <xsl:choose>
            <xsl:when test="IsRangeSearch = 'true'">
IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] = '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> AS nvarchar(100))+''' '
IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] >= '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Begin AS nvarchar(100))+''' '
IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] <![CDATA[<]]>= '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>End AS nvarchar(100))+''' '
            </xsl:when>
            <xsl:otherwise>
IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] = '''+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/> AS nvarchar(100))+''' '
            </xsl:otherwise>
          </xsl:choose>
IF @<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch IS NOT NULL
  SET @ConditionText = @ConditionText + ' AND '','+CAST(@<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>Batch AS nvarchar(4000))+','' LIKE ''%,''+CONVERT(nvarchar(50), [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>])+'',%'' '
        </xsl:if>
    </xsl:if>
</xsl:for-each>
SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsStatisticalData = 'true'">
    <xsl:if test="IsDataBind = 'true'">
IF @CountField = '<xsl:value-of select="FieldName"/>'
BEGIN
    SET @SelectListText = ' [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] AS RecordName, [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount, CONVERT(decimal(8,2), COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID]))/@RecordCount*100) AS RecordPercent '
    SET @TotalSelectListText = ' [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] AS RecordName, [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount '
    SET @CountField = '[<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>]'
END
    </xsl:if>
    <xsl:if test="IsDataBind = 'false'">
IF @CountField = '<xsl:value-of select="FieldName"/>'
BEGIN
    SET @SelectListText = ' CONVERT(nvarchar(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS RecordName, CONVERT(nvarchar(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount, CONVERT(decimal(8,2), COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID]))/@RecordCount*100) AS RecordPercent '
    SET @TotalSelectListText = ' CONVERT(nvarchar(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS RecordName, CONVERT(nvarchar(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount '
    SET @CountField = ' [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] '
END
    </xsl:if>
  </xsl:if>
</xsl:for-each>
--一对一相关表统计数据
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:if test="IsStatisticalData = 'true'">
    <xsl:if test="IsBindData = 'true'">
IF @CountField = '<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>'
BEGIN
    SET @SelectListText = ' [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataFieldName"/>] AS RecordName, [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataRelativeFieldName"/>] AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount, CONVERT(decimal(8,2), COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID]))/@RecordCount*100) AS RecordPercent '
    SET @TotalSelectListText = ' [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataFieldName"/>] AS RecordName, [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataRelativeFieldName"/>] AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount '
    SET @CountField = '[<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataRelativeFieldName"/>], [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataFieldName"/>]'
END
    </xsl:if>
    <xsl:if test="IsBindData = 'false'">
IF @CountField = '<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>'
BEGIN
    SET @SelectListText = ' CONVERT(nvarchar(50), [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]) AS RecordName, CONVERT(nvarchar(50), [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]) AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount, CONVERT(decimal(8,2), COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID]))/@RecordCount*100) AS RecordPercent '
    SET @TotalSelectListText = ' CONVERT(nvarchar(50), [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]) AS RecordName, CONVERT(nvarchar(50), [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]) AS RecordID, COUNT(DISTINCT CONVERT(NVARCHAR(50), [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[ObjectID])) AS RecordCount '
    SET @CountField = ' [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>] '
END
    </xsl:if>
  </xsl:if>
</xsl:for-each>
--聚合求和
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsSum = 'true'">
SET @SelectListText = @SelectListText + ', SUM([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>]) AS <xsl:value-of select="FieldName"/>Sum '</xsl:if>
</xsl:for-each>


--主表
SET @FromText = '
 FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]'
--主表与一对一相关表连接
SET @FromText = @FromText + '
<xsl:for-each select="/NewDataSet/CustomRelatedTableConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
      <xsl:if test="IsDataBind = 'false'">
    LEFT JOIN [<xsl:value-of select="RelatedTableOwner"/>].[<xsl:value-of select="RelatedTableName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>] ON [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="RelatedTableWithField"/>] = [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="TableWithField"/>]</xsl:if></xsl:if>
</xsl:for-each>
'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>    
  <xsl:if test="RelatedTableType = '1_to_1'">
    <xsl:if test="IsDisplay = 'true'">
      <xsl:if test="IsBindData = 'true'">
    LEFT JOIN [<xsl:value-of select="BindDataTableOwner"/>].[<xsl:value-of select="BindDataTableName"/>] AS [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>] ON [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="BindDataTableName"/>].[<xsl:value-of select="BindDataRelativeFieldName"/>] = [<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>].[<xsl:value-of select="DisplayFieldName"/>]</xsl:if></xsl:if></xsl:if>
</xsl:for-each>
'
--主表与绑定表连接
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsDataBind = 'true'">
      <xsl:choose>
          <xsl:when test="IsMoreItemDisplay = 'true'">
SET @FromText = @FromText + '
    LEFT JOIN [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>] AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>] ON '','' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + '','' LIKE ''%,'' + [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] + '',%'' <xsl:if test="DataBindCondition != 'null'"> AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindCondition"/>] = ''<xsl:value-of select="DataBindConditionValue"/>''</xsl:if>
'
<xsl:if test="IsStatisticalCondition = 'true'"><xsl:if test="IsCoupledNext = 'true'">
IF @<xsl:value-of select="CoupledDataSourcePrevious"/> IS NOT NULL
BEGIN	
SET @FromText = @FromText + '
	 AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="CoupledDataSourcePrevious"/>] = '''+@<xsl:value-of select="CoupledDataSourcePrevious"/>+'''
'
END
</xsl:if></xsl:if>
	</xsl:when>
    <xsl:otherwise>
SET @FromText = @FromText + '
    LEFT JOIN [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>] AS [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>] ON [<xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] <xsl:if test="DataBindCondition != 'null'"> AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="DataBindCondition"/>] = ''<xsl:value-of select="DataBindConditionValue"/>''</xsl:if> 
'
<xsl:if test="IsStatisticalCondition = 'true'"><xsl:if test="IsCoupledNext = 'true'">
IF @<xsl:value-of select="CoupledDataSourcePrevious"/> IS NOT NULL
BEGIN	
SET @FromText = @FromText + '
	 AND <xsl:value-of select="FieldName"/>_<xsl:value-of select="DataBindTableName"/>.[<xsl:value-of select="CoupledDataSourcePrevious"/>] = '''+@<xsl:value-of select="CoupledDataSourcePrevious"/>+'''
'
END
</xsl:if></xsl:if>
	</xsl:otherwise>
      </xsl:choose>
  </xsl:if>
</xsl:for-each>
--多项查询
<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="IsStatisticalCondition = 'true'">
  <xsl:choose>
    <xsl:when test="DBType = 'NText'">
    </xsl:when>
    <xsl:when test="DBType = 'Text'">
    </xsl:when>
    <xsl:when test="DBType = 'Image'">
    </xsl:when>
    <xsl:otherwise>
IF @<xsl:value-of select="FieldName"/>Batch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [<xsl:value-of select="/NewDataSet/TableOnwer"/>].F_SplitStr('''+CAST(@<xsl:value-of select="FieldName"/>Batch AS nvarchar(4000))+''', '','') AS <xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>_Batch ON '','' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + '','' LIKE ''%,'' + <xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>_Batch.col +'',%''
      '
    </xsl:otherwise>
  </xsl:choose>
  </xsl:if>
</xsl:for-each>
SET @SqlTextCount = 'SELECT @RecordCount = SUM(Record.RecordCount) FROM (' + ' SELECT ' +  @TotalSelectListText + @FromText + ' WHERE ' + @ConditionText + ' GROUP BY ' + @CountField + ') AS Record '
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount
PRINT @SqlTextCount
PRINT 'DECLARE @RecordCount Float '
PRINT @SqlTextCount
PRINT ' SELECT '
PRINT @SelectListText
PRINT @FromText
PRINT ' WHERE '
PRINT @ConditionText
PRINT ' GROUP BY ' + @CountField + ' ' + @SortText
EXECUTE('DECLARE @RecordCount Float ' + @SqlTextCount + ' SELECT ' +  @SelectListText  + @FromText + ' WHERE ' + @ConditionText  + ' GROUP BY ' + @CountField + ' ' + @SortText)

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsMoreItemDisplay = 'true'">
      <xsl:if test="IsDataBind = 'true'">
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="DataBindTextField"/>By<xsl:value-of select="FieldName"/>]') and OBJECTPROPERTY(id, N'IsProcedure') = 0)
drop FUNCTION [dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="DataBindTextField"/>By<xsl:value-of select="FieldName"/>]
GO

CREATE  FUNCTION [dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="DataBindTextField"/>By<xsl:value-of select="FieldName"/>]  (@InputValue  NVarChar(4000))  
RETURNS NVarchar(4000)
BEGIN 
DECLARE @Output NVarChar(4000) 
DECLARE @COUNT INT
DECLARE @OutputField NVarChar(100)
DECLARE RecordCursor Cursor  scroll dynamic
FOR
SELECT [<xsl:value-of select="DataBindTextField"/>]
FROM [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>]
WHERE [<xsl:value-of select="DataBindValueField"/>] IN (SELECT * FROM [dbo].F_SplitStr(@InputValue, ','))

OPEN RecordCursor
FETCH NEXT FROM RecordCursor INTO @OutputField
SET @COUNT = 1
WHILE(@@fetch_status=0)
BEGIN
    IF @COUNT = 1
        SET @Output = @OutputField
    ELSE
        SET @Output = @Output + ',' + @OutputField
    FETCH NEXT FROM RecordCursor INTO @OutputField
    SET @COUNT = @COUNT + 1
END
CLOSE RecordCursor
DEALLOCATE RecordCursor
RETURN @Output

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO        
      </xsl:if>
  </xsl:if>
</xsl:for-each>

<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
  <xsl:sort data-type="text" order="descending" select="IsPrimaryKey"/>
  <xsl:if test="IsMoreItemDisplay = 'true'">
      <xsl:if test="IsBindData = 'true'">
SET QUOTED_IDENTIFIER ON 
GO
SET ANSI_NULLS ON 
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>]') and OBJECTPROPERTY(id, N'IsProcedure') = 0)
drop FUNCTION [dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>]
GO

CREATE  FUNCTION [dbo].[F_<xsl:value-of select="/NewDataSet/TableName"/>_Get<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>_<xsl:value-of select="BindDataFieldName"/>]  (@InputValue  NVarChar(4000))  
RETURNS NVarchar(4000)
BEGIN 
DECLARE @Output NVarChar(4000) 
DECLARE @COUNT INT
DECLARE @OutputField NVarChar(100)
DECLARE RecordCursor Cursor  scroll dynamic
FOR
SELECT [<xsl:value-of select="BindDataFieldName"/>]
FROM [<xsl:value-of select="BindDataTableOwner"/>].[<xsl:value-of select="BindDataTableName"/>]
WHERE [<xsl:value-of select="BindDataRelativeFieldName"/>] IN (SELECT * FROM [dbo].F_SplitStr(@InputValue, ','))

OPEN RecordCursor
FETCH NEXT FROM RecordCursor INTO @OutputField
SET @COUNT = 1
WHILE(@@fetch_status=0)
BEGIN
    IF @COUNT = 1
        SET @Output = @OutputField
    ELSE
        SET @Output = @Output + ',' + @OutputField
    FETCH NEXT FROM RecordCursor INTO @OutputField
    SET @COUNT = @COUNT + 1
END
CLOSE RecordCursor
DEALLOCATE RecordCursor
RETURN @Output

END

GO
SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO        
      </xsl:if>
  </xsl:if>
</xsl:for-each>

<xsl:if test="/NewDataSet/AllowAutoGenerateID = 'true'">
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMax<xsl:value-of select="/NewDataSet/TableName"/>By<xsl:value-of select="/NewDataSet/AutoGenerateField"/>]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMax<xsl:value-of select="/NewDataSet/TableName"/>By<xsl:value-of select="/NewDataSet/AutoGenerateField"/>]
GO

--表<xsl:value-of select="/NewDataSet/TableName"/>以<xsl:value-of select="/NewDataSet/AutoGenerateField"/>为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMax<xsl:value-of select="/NewDataSet/TableName"/>By<xsl:value-of select="/NewDataSet/AutoGenerateField"/>] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(<xsl:value-of select="/NewDataSet/AutoGenerateField"/>, LEN(@Prefix) + @Number))
FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>]
WHERE
<xsl:value-of select="/NewDataSet/AutoGenerateField"/> LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
</xsl:if>


<xsl:for-each select="/NewDataSet/RecordInfo">
  <xsl:if test="OnlyDisplayUsedNode = 'true'">
      <xsl:if test="IsDataBind = 'true'">
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_Get<xsl:value-of select="DataBindTableName"/>_Exist_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_Get<xsl:value-of select="DataBindTableName"/>_Exist_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>]
GO

CREATE   PROCEDURE [dbo].[SP_Get<xsl:value-of select="DataBindTableName"/>_Exist_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>] 
@<xsl:value-of select="DataBindValueField"/><xsl:value-of select="' '"/>nvarchar(50) = NULL
,@<xsl:value-of select="DataBindTextField"/><xsl:value-of select="' '"/>nvarchar(50) = NULL
  <xsl:if test="IsTreeStyle = 'true'">
,@<xsl:value-of select="TreeParentNode"/><xsl:value-of select="' '"/>nvarchar(50) = NULL
  </xsl:if>
<xsl:choose>
  <xsl:when test="DataBindCondition = 'null'">
  </xsl:when>
  <xsl:otherwise>
,@<xsl:value-of select="DataBindCondition"/><xsl:value-of select="' '"/>nvarchar(50) = NULL
  </xsl:otherwise>
</xsl:choose>
AS
  <xsl:if test="IsTreeStyle = 'false'">
<xsl:choose>
  <xsl:when test="DataBindCondition = 'null'">
DECLARE @TEMP1 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50))
INSERT INTO @TEMP1([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] 
  ON 
  ',' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + ',' LIKE '%,'+[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>]+',%' 
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
)
  </xsl:when>
  <xsl:otherwise>
DECLARE @TEMP1 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="DataBindCondition"/>] nvarchar(50))
INSERT INTO @TEMP1([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="DataBindCondition"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] 
  ON 
  ',' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + ',' LIKE '%,'+[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>]+',%' 
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>] = @<xsl:value-of select="DataBindCondition"/>)
)
  </xsl:otherwise>
</xsl:choose>
SELECT * FROM @TEMP1
  </xsl:if>
  <xsl:if test="IsTreeStyle = 'true'">
<xsl:choose>
  <xsl:when test="DataBindCondition = 'null'">
DECLARE @TEMP1 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="TreeParentNode"/>] nvarchar(50) )
INSERT INTO @TEMP1([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="TreeParentNode"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="TreeParentNode"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] 
  ON 
  ',' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + ',' LIKE '%,'+[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>]+',%' 
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindTextField"/> OR @<xsl:value-of select="DataBindTextField"/> IS NULL)
)

DECLARE @TEMP2 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="TreeParentNode"/>] nvarchar(50) )
INSERT INTO @TEMP2([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="TreeParentNode"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="TreeParentNode"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN 
  @TEMP1 AS [TEMP]
  ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = [TEMP].[<xsl:value-of select="TreeParentNode"/>]
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindTextField"/> OR @<xsl:value-of select="DataBindTextField"/> IS NULL)
)

DECLARE @TEMP3 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="TreeParentNode"/>] nvarchar(50) )
INSERT INTO @TEMP3([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="TreeParentNode"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="TreeParentNode"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN 
  @TEMP2 AS [TEMP]
  ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = [TEMP].[<xsl:value-of select="TreeParentNode"/>]
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindTextField"/> OR @<xsl:value-of select="DataBindTextField"/> IS NULL)
)
  </xsl:when>
  <xsl:otherwise>
DECLARE @TEMP1 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="TreeParentNode"/>] nvarchar(50), [<xsl:value-of select="DataBindCondition"/>] nvarchar(50) )
INSERT INTO @TEMP1([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="TreeParentNode"/>], [<xsl:value-of select="DataBindCondition"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="TreeParentNode"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] 
  ON 
  ',' + [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>].[<xsl:value-of select="FieldName"/>] + ',' LIKE '%,'+[<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>]+',%' 
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindTextField"/> OR @<xsl:value-of select="DataBindTextField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>] = @<xsl:value-of select="DataBindCondition"/>)
)

DECLARE @TEMP2 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="TreeParentNode"/>] nvarchar(50), [<xsl:value-of select="DataBindCondition"/>] nvarchar(50) )
INSERT INTO @TEMP2([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="TreeParentNode"/>], [<xsl:value-of select="DataBindCondition"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="TreeParentNode"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN 
  @TEMP1 AS [TEMP]
  ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = [TEMP].[<xsl:value-of select="TreeParentNode"/>]
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindTextField"/> OR @<xsl:value-of select="DataBindTextField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>] = @<xsl:value-of select="DataBindCondition"/>)
)

DECLARE @TEMP3 AS TABLE ([<xsl:value-of select="DataBindValueField"/>] nvarchar(50), [<xsl:value-of select="DataBindTextField"/>] nvarchar(50), [<xsl:value-of select="TreeParentNode"/>] nvarchar(50), [<xsl:value-of select="DataBindCondition"/>] nvarchar(50) )
INSERT INTO @TEMP3([<xsl:value-of select="DataBindValueField"/>], [<xsl:value-of select="DataBindTextField"/>], [<xsl:value-of select="TreeParentNode"/>], [<xsl:value-of select="DataBindCondition"/>])
(
  SELECT DISTINCT 
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="TreeParentNode"/>],
    [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>]
  FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>] 
  INNER JOIN 
  @TEMP2 AS [TEMP]
  ON [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = [TEMP].[<xsl:value-of select="TreeParentNode"/>]
  WHERE
  ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindValueField"/>] = @<xsl:value-of select="DataBindValueField"/> OR @<xsl:value-of select="DataBindValueField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindTextField"/>] = @<xsl:value-of select="DataBindTextField"/> OR @<xsl:value-of select="DataBindTextField"/> IS NULL)
  AND ([<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="DataBindTableName"/>].[<xsl:value-of select="DataBindCondition"/>] = @<xsl:value-of select="DataBindCondition"/>)
)
  </xsl:otherwise>
</xsl:choose>

SELECT * FROM @TEMP1 WHERE ([<xsl:value-of select="TreeParentNode"/>] = @<xsl:value-of select="TreeParentNode"/> OR @<xsl:value-of select="TreeParentNode"/> IS NULL)  
UNION
SELECT * FROM @TEMP2 WHERE ([<xsl:value-of select="TreeParentNode"/>] = @<xsl:value-of select="TreeParentNode"/> OR @<xsl:value-of select="TreeParentNode"/> IS NULL)  
UNION
SELECT * FROM @TEMP3 WHERE ([<xsl:value-of select="TreeParentNode"/>] = @<xsl:value-of select="TreeParentNode"/> OR @<xsl:value-of select="TreeParentNode"/> IS NULL)
  </xsl:if>

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
      </xsl:if>
  </xsl:if>
</xsl:for-each>
  
<xsl:for-each select="/NewDataSet/RecordInfo">
   <xsl:if test="IsDataBind = 'true'">
   <xsl:if test="IsTreeStyle = 'true'">
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_<xsl:value-of select="/NewDataSet/TableName"/>_<xsl:value-of select="FieldName"/>] 
@IDFieldName nvarchar(50) 
,@NameFieldName nvarchar(50) 
,@ParentIDFieldValue nvarchar(50) = NULL
,@ConditionFieldName nvarchar(50) = NULL
,@ConditionFieldValue nvarchar(50) = NULL
,@OnlyShowUsed bit = 0
AS
DECLARE @SqlText nvarchar(4000) 
SET @SqlText = '
SELECT DISTINCT 
    [<xsl:value-of select="DataBindValueField"/>] AS ID,
    [<xsl:value-of select="DataBindTextField"/>] AS Name,
    [<xsl:value-of select="TreeParentNode"/>] AS ParentID
FROM [<xsl:value-of select="DataBindTableOwnerName"/>].[<xsl:value-of select="DataBindTableName"/>] 
WHERE 1 = 1
<xsl:if test="TreeParentNodeValue != 'null'"> AND [<xsl:value-of select="TreeParentNode"/>] = ''<xsl:value-of select="TreeParentNodeValue"/>''</xsl:if>    
<xsl:if test="DataBindCondition != 'null'"> AND [<xsl:value-of select="DataBindCondition"/>] = ''<xsl:value-of select="DataBindConditionValue"/>''</xsl:if>
UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [<xsl:value-of select="FieldName"/>] AS ParentID
FROM [<xsl:value-of select="/NewDataSet/TableOnwer"/>].[<xsl:value-of select="/NewDataSet/TableName"/>] 
WHERE 1 = 1
'
<![CDATA[
IF @ParentIDFieldValue  <> 'null' OR @ParentIDFieldValue IS NOT NULL
	SET @SqlText = @SqlText +'
	AND [<xsl:value-of select="FieldName"/>]  = '+ @ParentIDFieldValue +' 
	'
IF (@ConditionFieldName  <> 'null' OR @ConditionFieldName IS NOT NULL) AND (@ConditionFieldValue  <> 'null' OR @ConditionFieldValue IS NOT NULL)
	SET @SqlText = @SqlText +'
	AND '+ @ConditionFieldName +' = '+ @ConditionFieldValue +' 
	'
]]>
PRINT @SqlText
EXECUTE(@SqlText)
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
</xsl:if></xsl:if>
</xsl:for-each>  
  
</xsl:template>
</xsl:stylesheet>