if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertDictionary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertDictionary]
GO

--表Dictionary插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertDictionary] 

@ObjectID UniqueIdentifier   = NULL
,@DM NVarChar (10)
,@LX NVarChar (10)
,@MC NVarChar (50)
,@SJDM NVarChar (10)  = NULL
,@SM NVarChar (255)  = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @DM IS NULL
    SET @DM = NULL
IF @LX IS NULL
    SET @LX = NULL
IF @MC IS NULL
    SET @MC = NULL
IF @SJDM IS NULL
    SET @SJDM = NULL
IF @SM IS NULL
    SET @SM = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[Dictionary]
    (
    
    [ObjectID]
    ,[DM]
    ,[LX]
    ,[MC]
    ,[SJDM]
    ,[SM]
    )
    VALUES
    (
    
    @ObjectID
    ,@DM
    ,@LX
    ,@MC
    ,@SJDM
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryByAnyCondition]
GO

--表Dictionary任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @DM NVarChar(10) = NULL
        
, @DMValue NVarChar(10) = NULL
, @DMBatch nvarchar(1000) = NULL

, @LX NVarChar(10) = NULL
        
, @LXValue NVarChar(10) = NULL
, @LXBatch nvarchar(1000) = NULL

, @MC NVarChar(50) = NULL
        
, @MCValue NVarChar(50) = NULL
, @MCBatch nvarchar(1000) = NULL

, @SJDM NVarChar(10) = NULL
        
, @SJDMValue NVarChar(10) = NULL
, @SJDMBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[Dictionary].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].ObjectID)+''%'' '
    
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].DM = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @DMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].DM)+''%'' '
    
    IF @LX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].LX = '''+CAST(@LX AS nvarchar(100))+''' '
            
    IF @LXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].LX)+''%'' '
    
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].MC = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @MCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@MCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].MC)+''%'' '
    
    IF @SJDM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].SJDM = '''+CAST(@SJDM AS nvarchar(100))+''' '
            
    IF @SJDMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SJDMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].SJDM)+''%'' '
    
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].SM = '''+CAST(@SM AS nvarchar(100))+''' '
            
    IF @SMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].SM)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[Dictionary].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].ObjectID)+''%'' '
    
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].DM LIKE '''+CAST(@DM AS nvarchar(100))+'%'' '
        
    IF @DMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].DM)+''%'' '
    
    IF @LX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].LX LIKE '''+CAST(@LX AS nvarchar(100))+'%'' '
        
    IF @LXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].LX)+''%'' '
    
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].MC LIKE '''+CAST(@MC AS nvarchar(100))+'%'' '
        
    IF @MCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@MCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].MC)+''%'' '
    
    IF @SJDM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].SJDM LIKE '''+CAST(@SJDM AS nvarchar(100))+'%'' '
        
    IF @SJDMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SJDMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].SJDM)+''%'' '
    
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].SM LIKE '''+CAST(@SM AS nvarchar(100))+'%'' '
        
    IF @SMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[Dictionary].SM)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[Dictionary] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[Dictionary] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[Dictionary].ObjectID'
  
    IF @DMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DM = @DMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DM = [DB_MGZZX].[dbo].[Dictionary].DM'
  
    IF @LXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LX = @LXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LX = [DB_MGZZX].[dbo].[Dictionary].LX'
  
    IF @MCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,MC = @MCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,MC = [DB_MGZZX].[dbo].[Dictionary].MC'
  
    IF @SJDMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SJDM = @SJDMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SJDM = [DB_MGZZX].[dbo].[Dictionary].SJDM'
  
    IF @SMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SM = @SMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SM = [DB_MGZZX].[dbo].[Dictionary].SM'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[Dictionary] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryByObjectID]
GO

--表Dictionary以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryByObjectID] 

@ObjectID nvarchar(50) = NULL
,@DM NVarChar(10) = NULL
,@LX NVarChar(10) = NULL
,@MC NVarChar(50) = NULL
,@SJDM NVarChar(10) = NULL
,@SM NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[Dictionary]
    SET 
    
    [ObjectID] = @ObjectID
    , [DM] = @DM
    , [LX] = @LX
    , [MC] = @MC
    , [SJDM] = @SJDM
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryByKey]
GO

--表Dictionary以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryByKey] 

@ObjectID nvarchar(50) = NULL
,@DM NVarChar(10) = NULL
,@LX NVarChar(10) = NULL
,@MC NVarChar(50) = NULL
,@SJDM NVarChar(10) = NULL
,@SM NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [DM] = @DM
        AND [LX] = @LX
    END
    
    IF @DM IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [DM] = @DM
        WHERE
        
        [DM] = @DM
        AND [LX] = @LX
    END
    
    IF @LX IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [LX] = @LX
        WHERE
        
        [DM] = @DM
        AND [LX] = @LX
    END
    
    IF @MC IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [MC] = @MC
        WHERE
        
        [DM] = @DM
        AND [LX] = @LX
    END
    
    IF @SJDM IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [SJDM] = @SJDM
        WHERE
        
        [DM] = @DM
        AND [LX] = @LX
    END
    
    IF @SM IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [SM] = @SM
        WHERE
        
        [DM] = @DM
        AND [LX] = @LX
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryByObjectIDBatch]
GO

--表Dictionary以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@DM NVarChar(10) = NULL

,@LX NVarChar(10) = NULL

,@MC NVarChar(50) = NULL

,@SJDM NVarChar(10) = NULL

,@SM NVarChar(255) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DM IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [DM] = @DM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LX IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [LX] = @LX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @MC IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [MC] = @MC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SJDM IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
        SET [SJDM] = @SJDM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SM IS NOT NULL
    BEGIN
        UPDATE [dbo].[Dictionary]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteDictionaryByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteDictionaryByObjectID]
GO

--表Dictionary以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[Dictionary]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteDictionaryByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteDictionaryByKey]
GO

--表Dictionary以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryByKey] 

@DM NVarChar(10) = NULL
, @LX NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[Dictionary]
WHERE

[DM] = @DM
AND [LX] = @LX
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteDictionaryByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteDictionaryByObjectIDBatch]
GO

--表Dictionary以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[Dictionary]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryByAnyCondition]
GO

--表Dictionary任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @DM NVarChar(10) = NULL
        
, @DMBatch nvarchar(4000) = NULL

, @LX NVarChar(10) = NULL
        
, @LXBatch nvarchar(4000) = NULL

, @MC NVarChar(50) = NULL
        
, @MCBatch nvarchar(4000) = NULL

, @SJDM NVarChar(10) = NULL
        
, @SJDMBatch nvarchar(4000) = NULL

, @SM NVarChar(255) = NULL
        
, @SMBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'LX'
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
    SET @SortField = 'LX'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[Dictionary].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[Dictionary].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].[DM] = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @LX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].[LX] = '''+CAST(@LX AS nvarchar(100))+''' '
            
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].[MC] = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @SJDM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].[SJDM] = '''+CAST(@SJDM AS nvarchar(100))+''' '
            
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[Dictionary].[SM] = '''+CAST(@SM AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[Dictionary].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[DM] = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @LX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[LX] = '''+CAST(@LX AS nvarchar(100))+''' '
            
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[MC] = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @SJDM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[SJDM] = '''+CAST(@SJDM AS nvarchar(100))+''' '
            
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[SM] = '''+CAST(@SM AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[Dictionary].[ObjectID]
        
      , [dbo].[Dictionary].[DM]
        
      , [dbo].[Dictionary].[LX]
        
      , [dbo].[Dictionary].[MC]
        
      , [dbo].[Dictionary].[SJDM]
        
      , [dbo].[Dictionary].[SM]
        
        ,[LX_DictionaryType].[MC] AS [LX_DictionaryType_MC]
        ,[SJDM_Dictionary].[MC] AS [SJDM_Dictionary_MC]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[LX_DictionaryType].[MC] AS [LX_DictionaryType_MC]
        ,[SJDM_Dictionary].[MC] AS [SJDM_Dictionary_MC]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[Dictionary]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[DictionaryType] AS LX_DictionaryType ON LX_DictionaryType.[DM] = [dbo].[Dictionary].[LX] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS SJDM_Dictionary ON SJDM_Dictionary.[DM] = [dbo].[Dictionary].[SJDM] 
'
	
	IF @LX IS NOT NULL
	BEGIN
	SET @FromText = @FromText + '
		 AND SJDM_Dictionary.[DM] = '''+@LX+'''
	'
	END
    
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS Dictionary_ObjectID_Batch ON '','' + [dbo].[Dictionary].[ObjectID] + '','' LIKE ''%,'' + Dictionary_ObjectID_Batch.col +'',%''
'
    
IF @DMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DMBatch AS nvarchar(4000))+''', '','') AS Dictionary_DM_Batch ON '','' + [dbo].[Dictionary].[DM] + '','' LIKE ''%,'' + Dictionary_DM_Batch.col +'',%''
'
    
IF @LXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LXBatch AS nvarchar(4000))+''', '','') AS Dictionary_LX_Batch ON '','' + [dbo].[Dictionary].[LX] + '','' LIKE ''%,'' + Dictionary_LX_Batch.col +'',%''
'
    
IF @MCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@MCBatch AS nvarchar(4000))+''', '','') AS Dictionary_MC_Batch ON '','' + [dbo].[Dictionary].[MC] + '','' LIKE ''%,'' + Dictionary_MC_Batch.col +'',%''
'
    
IF @SJDMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SJDMBatch AS nvarchar(4000))+''', '','') AS Dictionary_SJDM_Batch ON '','' + [dbo].[Dictionary].[SJDM] + '','' LIKE ''%,'' + Dictionary_SJDM_Batch.col +'',%''
'
    
IF @SMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SMBatch AS nvarchar(4000))+''', '','') AS Dictionary_SM_Batch ON '','' + [dbo].[Dictionary].[SM] + '','' LIKE ''%,'' + Dictionary_SM_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[Dictionary].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[Dictionary].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryByObjectID]
GO

--表Dictionary以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[Dictionary].[ObjectID]
    
      , [dbo].[Dictionary].[DM]
    
      , [dbo].[Dictionary].[LX]
    
      , [dbo].[Dictionary].[MC]
    
      , [dbo].[Dictionary].[SJDM]
    
      , [dbo].[Dictionary].[SM]
    
        ,[LX_DictionaryType].[MC] AS [LX_DictionaryType_MC]
        ,[SJDM_Dictionary].[MC] AS [SJDM_Dictionary_MC]
FROM [dbo].[Dictionary]

    LEFT JOIN [dbo].[DictionaryType] AS LX_DictionaryType ON LX_DictionaryType.[DM] = [dbo].[Dictionary].[LX] 
    LEFT JOIN [dbo].[Dictionary] AS SJDM_Dictionary ON SJDM_Dictionary.[DM] = [dbo].[Dictionary].[SJDM] 
WHERE
[dbo].[Dictionary].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryByKey]
GO

--表Dictionary以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryByKey] 

@DM NVarChar(10) = NULL
, @LX NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [DM]
    
      , [LX]
    
      , [MC]
    
      , [SJDM]
    
      , [SM]
    
FROM [dbo].[Dictionary]
WHERE

[DM] = @DM
AND [LX] = @LX

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistDictionaryByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistDictionaryByObjectID]
GO

--表[Dictionary]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistDictionaryByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[Dictionary]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistDictionaryByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistDictionaryByKey]
GO

--表[Dictionary]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistDictionaryByKey] 

@DM NVarChar(10) = NULL
, @LX NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[Dictionary]
WHERE 

[DM] = @DM
AND [LX] = @LX

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountDictionaryByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountDictionaryByAnyCondition]
GO

--表Dictionary任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountDictionaryByAnyCondition] 
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
SET @ConditionText = ' [dbo].[Dictionary].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[Dictionary]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[DictionaryType] AS [LX_DictionaryType] ON [LX_DictionaryType].[DM] = [dbo].[Dictionary].[LX]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [SJDM_Dictionary] ON [SJDM_Dictionary].[DM] = [dbo].[Dictionary].[SJDM]  
'

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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetDictionaryType_Exist_Dictionary_LX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetDictionaryType_Exist_Dictionary_LX]
GO

CREATE   PROCEDURE [dbo].[SP_GetDictionaryType_Exist_Dictionary_LX] 
@DM nvarchar(50) = NULL
,@MC nvarchar(50) = NULL
  
AS
  
DECLARE @TEMP1 AS TABLE ([DM] nvarchar(50), [MC] nvarchar(50))
INSERT INTO @TEMP1([DM], [MC])
(
  SELECT DISTINCT 
    [dbo].[DictionaryType].[DM],
    [dbo].[DictionaryType].[MC]
  FROM [dbo].[DictionaryType] 
  INNER JOIN [dbo].[Dictionary] 
  ON 
  ',' + [dbo].[Dictionary].[LX] + ',' LIKE '%,'+[dbo].[DictionaryType].[DM]+',%' 
  WHERE
  ([dbo].[DictionaryType].[DM] = @DM OR @DM IS NULL)
  AND ([dbo].[DictionaryType].[MC] = @DM OR @DM IS NULL)
)
  
SELECT * FROM @TEMP1
  

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
      
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_Dictionary_SJDM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_Dictionary_SJDM]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_Dictionary_SJDM] 
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
    [DM] AS ID,
    [MC] AS Name,
    [SJDM] AS ParentID
FROM [dbo].[Dictionary] 
WHERE 1 = 1
 AND [SJDM] = ''"null"''
UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [SJDM] AS ParentID
FROM [dbo].[Dictionary] 
WHERE 1 = 1
'

IF @ParentIDFieldValue  <> 'null' OR @ParentIDFieldValue IS NOT NULL
	SET @SqlText = @SqlText +'
	AND [<xsl:value-of select="FieldName"/>]  = '+ @ParentIDFieldValue +' 
	'
IF (@ConditionFieldName  <> 'null' OR @ConditionFieldName IS NOT NULL) AND (@ConditionFieldValue  <> 'null' OR @ConditionFieldValue IS NOT NULL)
	SET @SqlText = @SqlText +'
	AND '+ @ConditionFieldName +' = '+ @ConditionFieldValue +' 
	'

PRINT @SqlText
EXECUTE(@SqlText)
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

