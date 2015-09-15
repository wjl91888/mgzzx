if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertDictionaryType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertDictionaryType]
GO

--表DictionaryType插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertDictionaryType] 

@ObjectID UniqueIdentifier   = NULL
,@DM NVarChar (10)
,@MC NVarChar (50)
,@SM NVarChar (255)  = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @DM IS NULL
    SET @DM = NULL
IF @MC IS NULL
    SET @MC = NULL
IF @SM IS NULL
    SET @SM = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[DictionaryType]
    (
    
    [ObjectID]
    ,[DM]
    ,[MC]
    ,[SM]
    )
    VALUES
    (
    
    @ObjectID
    ,@DM
    ,@MC
    ,@SM
    )
    
    --更新相关表信息
    
COMMIT TRANSACTION
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryTypeByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryTypeByAnyCondition]
GO

--表DictionaryType任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @DM NVarChar(10) = NULL
        
, @DMValue NVarChar(10) = NULL
, @DMBatch nvarchar(1000) = NULL

, @MC NVarChar(50) = NULL
        
, @MCValue NVarChar(50) = NULL
, @MCBatch nvarchar(1000) = NULL

, @SM NVarChar(255) = NULL
        
, @SMValue NVarChar(255) = NULL
, @SMBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[DictionaryType].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].ObjectID)+''%'' '
    
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].DM = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @DMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].DM)+''%'' '
    
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].MC = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @MCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@MCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].MC)+''%'' '
    
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].SM = '''+CAST(@SM AS nvarchar(100))+''' '
            
    IF @SMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].SM)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[DictionaryType].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].ObjectID)+''%'' '
    
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].DM LIKE '''+CAST(@DM AS nvarchar(100))+'%'' '
        
    IF @DMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].DM)+''%'' '
    
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].MC LIKE '''+CAST(@MC AS nvarchar(100))+'%'' '
        
    IF @MCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@MCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].MC)+''%'' '
    
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].SM LIKE '''+CAST(@SM AS nvarchar(100))+'%'' '
        
    IF @SMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[DictionaryType].SM)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[DictionaryType] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[DictionaryType] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[DictionaryType].ObjectID'
  
    IF @DMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DM = @DMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DM = [DB_MGZZX].[dbo].[DictionaryType].DM'
  
    IF @MCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,MC = @MCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,MC = [DB_MGZZX].[dbo].[DictionaryType].MC'
  
    IF @SMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SM = @SMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SM = [DB_MGZZX].[dbo].[DictionaryType].SM'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[DictionaryType] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryTypeByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryTypeByObjectID]
GO

--表DictionaryType以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByObjectID] 

@ObjectID nvarchar(50) = NULL
,@DM NVarChar(10) = NULL
,@MC NVarChar(50) = NULL
,@SM NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[DictionaryType]
    SET 
    
    [ObjectID] = @ObjectID
    , [DM] = @DM
    , [MC] = @MC
    , [SM] = @SM
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryTypeByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryTypeByKey]
GO

--表DictionaryType以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByKey] 

@ObjectID nvarchar(50) = NULL
,@DM NVarChar(10) = NULL
,@MC NVarChar(50) = NULL
,@SM NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [DM] = @DM
    END
    
    IF @DM IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [DM] = @DM
        WHERE
        
        [DM] = @DM
    END
    
    IF @MC IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [MC] = @MC
        WHERE
        
        [DM] = @DM
    END
    
    IF @SM IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [SM] = @SM
        WHERE
        
        [DM] = @DM
    END
    
COMMIT TRANSACTION


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryTypeByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryTypeByObjectIDBatch]
GO

--表DictionaryType以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@DM NVarChar(10) = NULL

,@MC NVarChar(50) = NULL

,@SM NVarChar(255) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DM IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [DM] = @DM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @MC IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [MC] = @MC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SM IS NOT NULL
    BEGIN
        UPDATE [dbo].[DictionaryType]
        SET [SM] = @SM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteDictionaryTypeByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteDictionaryTypeByObjectID]
GO

--表DictionaryType以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryTypeByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[DictionaryType]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteDictionaryTypeByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteDictionaryTypeByKey]
GO

--表DictionaryType以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryTypeByKey] 

@DM NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[DictionaryType]
WHERE

[DM] = @DM
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteDictionaryTypeByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteDictionaryTypeByObjectIDBatch]
GO

--表DictionaryType以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryTypeByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[DictionaryType]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryTypeByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryTypeByAnyCondition]
GO

--表DictionaryType任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryTypeByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @DM NVarChar(10) = NULL
        
, @DMBatch nvarchar(4000) = NULL

, @MC NVarChar(50) = NULL
        
, @MCBatch nvarchar(4000) = NULL

, @SM NVarChar(255) = NULL
        
, @SMBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'DM'
, @PageSize int = 500
, @CurrentPage int = 1
, @RecordCount int Output


AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @SqlTextCount nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @FromText nvarchar(4000) 
DECLARE @SortText nvarchar(255)
DECLARE @InnerSortText nvarchar(4000)


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
    SET @SortField = 'DM'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[DictionaryType].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[DictionaryType].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[DM] = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[MC] = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[SM] = '''+CAST(@SM AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[DictionaryType].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[DM] = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[MC] = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[SM] = '''+CAST(@SM AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[DictionaryType].[ObjectID]
        
      , [dbo].[DictionaryType].[DM]
        
      , [dbo].[DictionaryType].[MC]
        
      , [dbo].[DictionaryType].[SM]
        
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[DictionaryType]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS DictionaryType_ObjectID_Batch ON '','' + [dbo].[DictionaryType].[ObjectID] + '','' LIKE ''%,'' + DictionaryType_ObjectID_Batch.col +'',%''
'
    
IF @DMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DMBatch AS nvarchar(4000))+''', '','') AS DictionaryType_DM_Batch ON '','' + [dbo].[DictionaryType].[DM] + '','' LIKE ''%,'' + DictionaryType_DM_Batch.col +'',%''
'
    
IF @MCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@MCBatch AS nvarchar(4000))+''', '','') AS DictionaryType_MC_Batch ON '','' + [dbo].[DictionaryType].[MC] + '','' LIKE ''%,'' + DictionaryType_MC_Batch.col +'',%''
'
    
IF @SMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SMBatch AS nvarchar(4000))+''', '','') AS DictionaryType_SM_Batch ON '','' + [dbo].[DictionaryType].[SM] + '','' LIKE ''%,'' + DictionaryType_SM_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[DictionaryType].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[DictionaryType].[ObjectID]
' + @FromText + '
WHERE ' + @ConditionText + ' ' + @SortText + '
)'

SET @SqlTextCount = 'SELECT @RecordCount=COUNT(*) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount


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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryTypeByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryTypeByObjectID]
GO

--表DictionaryType以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryTypeByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[DictionaryType].[ObjectID]
    
      , [dbo].[DictionaryType].[DM]
    
      , [dbo].[DictionaryType].[MC]
    
      , [dbo].[DictionaryType].[SM]
    
FROM [dbo].[DictionaryType]

WHERE
[dbo].[DictionaryType].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryTypeByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryTypeByKey]
GO

--表DictionaryType以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryTypeByKey] 

@DM NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [DM]
    
      , [MC]
    
      , [SM]
    
FROM [dbo].[DictionaryType]
WHERE

[DM] = @DM

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistDictionaryTypeByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistDictionaryTypeByObjectID]
GO

--表[DictionaryType]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistDictionaryTypeByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[DictionaryType]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistDictionaryTypeByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistDictionaryTypeByKey]
GO

--表[DictionaryType]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistDictionaryTypeByKey] 

@DM NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[DictionaryType]
WHERE 

[DM] = @DM

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountDictionaryTypeByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountDictionaryTypeByAnyCondition]
GO

--表DictionaryType任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountDictionaryTypeByAnyCondition] 
@CountField NVarChar(200)
--主表参数

--一对一相关表参数

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
SET @ConditionText = ' [dbo].[DictionaryType].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[DictionaryType]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

--多项查询

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


