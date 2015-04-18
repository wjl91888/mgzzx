if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_PM_PurviewInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_PM_PurviewInfo]
GO

--表T_PM_PurviewInfo插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_PM_PurviewInfo] 

@ObjectID UniqueIdentifier   = NULL
,@PurviewID NVarChar (50)
,@PurviewName NVarChar (100)
,@PurviewTypeID NVarChar (50)
,@PurviewContent NVarChar (255)  = NULL
,@PurviewRemark NVarChar (255)  = NULL
,@IsPageMenu Bit   = NULL
,@PageFileName NVarChar (255)  = NULL
,@PageFileParameter NVarChar (255)  = NULL
,@PageFilePath NVarChar (255)  = NULL
,@UpdateDate DateTime   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @PurviewID IS NULL
    SET @PurviewID = NULL
IF @PurviewName IS NULL
    SET @PurviewName = NULL
IF @PurviewTypeID IS NULL
    SET @PurviewTypeID = NULL
IF @PurviewContent IS NULL
    SET @PurviewContent = NULL
IF @PurviewRemark IS NULL
    SET @PurviewRemark = NULL
IF @IsPageMenu IS NULL
    SET @IsPageMenu = NULL
IF @PageFileName IS NULL
    SET @PageFileName = NULL
IF @PageFileParameter IS NULL
    SET @PageFileParameter = NULL
IF @PageFilePath IS NULL
    SET @PageFilePath = NULL
IF @UpdateDate IS NULL
    SET @UpdateDate = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_PM_PurviewInfo]
    (
    
    [ObjectID]
    ,[PurviewID]
    ,[PurviewName]
    ,[PurviewTypeID]
    ,[PurviewContent]
    ,[PurviewRemark]
    ,[IsPageMenu]
    ,[PageFileName]
    ,[PageFileParameter]
    ,[PageFilePath]
    ,[UpdateDate]
    )
    VALUES
    (
    
    @ObjectID
    ,@PurviewID
    ,@PurviewName
    ,@PurviewTypeID
    ,@PurviewContent
    ,@PurviewRemark
    ,@IsPageMenu
    ,@PageFileName
    ,@PageFileParameter
    ,@PageFilePath
    ,@UpdateDate
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_PurviewInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_PurviewInfoByAnyCondition]
GO

--表T_PM_PurviewInfo任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_PurviewInfoByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @PurviewID NVarChar(50) = NULL
        
, @PurviewIDValue NVarChar(50) = NULL
, @PurviewIDBatch nvarchar(1000) = NULL

, @PurviewName NVarChar(100) = NULL
        
, @PurviewNameValue NVarChar(100) = NULL
, @PurviewNameBatch nvarchar(1000) = NULL

, @PurviewTypeID NVarChar(50) = NULL
        
, @PurviewTypeIDValue NVarChar(50) = NULL
, @PurviewTypeIDBatch nvarchar(1000) = NULL

, @PurviewContent NVarChar(255) = NULL
        
, @PurviewContentValue NVarChar(255) = NULL
, @PurviewContentBatch nvarchar(1000) = NULL

, @PurviewRemark NVarChar(255) = NULL
        
, @PurviewRemarkValue NVarChar(255) = NULL
, @PurviewRemarkBatch nvarchar(1000) = NULL

, @IsPageMenu Bit = NULL
        
, @IsPageMenuValue Bit = NULL
, @IsPageMenuBatch nvarchar(1000) = NULL

, @PageFileName NVarChar(255) = NULL
        
, @PageFileNameValue NVarChar(255) = NULL
, @PageFileNameBatch nvarchar(1000) = NULL

, @PageFileParameter NVarChar(255) = NULL
        
, @PageFileParameterValue NVarChar(255) = NULL
, @PageFileParameterBatch nvarchar(1000) = NULL

, @PageFilePath NVarChar(255) = NULL
        
, @PageFilePathValue NVarChar(255) = NULL
, @PageFilePathBatch nvarchar(1000) = NULL

, @UpdateDate DateTime = NULL
        
, @UpdateDateBegin DateTime = NULL
, @UpdateDateEnd DateTime = NULL
        
, @UpdateDateValue DateTime = NULL
, @UpdateDateBatch nvarchar(1000) = NULL

, @QueryType nvarchar(50) = 'AND'
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
    SET @ConditionText = '( [dbo].[T_PM_PurviewInfo].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].ObjectID)+''%'' '
    
    IF @PurviewID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PurviewID = '''+CAST(@PurviewID AS nvarchar(100))+''' '
            
    IF @PurviewIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PurviewIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewID)+''%'' '
    
    IF @PurviewName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PurviewName = '''+CAST(@PurviewName AS nvarchar(100))+''' '
            
    IF @PurviewNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PurviewNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewName)+''%'' '
    
    IF @PurviewTypeID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PurviewTypeID = '''+CAST(@PurviewTypeID AS nvarchar(100))+''' '
            
    IF @PurviewTypeIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PurviewTypeIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewTypeID)+''%'' '
    
    IF @PurviewContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PurviewContent = '''+CAST(@PurviewContent AS nvarchar(100))+''' '
            
    IF @PurviewContentBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PurviewContentBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewContent)+''%'' '
    
    IF @PurviewRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PurviewRemark = '''+CAST(@PurviewRemark AS nvarchar(100))+''' '
            
    IF @PurviewRemarkBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PurviewRemarkBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewRemark)+''%'' '
    
    IF @IsPageMenu IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].IsPageMenu = '''+CAST(@IsPageMenu AS nvarchar(100))+''' '
            
    IF @IsPageMenuBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@IsPageMenuBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].IsPageMenu)+''%'' '
    
    IF @PageFileName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PageFileName = '''+CAST(@PageFileName AS nvarchar(100))+''' '
            
    IF @PageFileNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PageFileNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PageFileName)+''%'' '
    
    IF @PageFileParameter IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PageFileParameter = '''+CAST(@PageFileParameter AS nvarchar(100))+''' '
            
    IF @PageFileParameterBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PageFileParameterBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PageFileParameter)+''%'' '
    
    IF @PageFilePath IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].PageFilePath = '''+CAST(@PageFilePath AS nvarchar(100))+''' '
            
    IF @PageFilePathBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PageFilePathBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PageFilePath)+''%'' '
    
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].UpdateDate = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
    IF @UpdateDateBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].UpdateDate >= '''+CAST(@UpdateDateBegin AS nvarchar(100))+''' '
    IF @UpdateDateEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].UpdateDate <= '''+CAST(@UpdateDateEnd AS nvarchar(100))+''' '
        
    IF @UpdateDateBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UpdateDateBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].UpdateDate)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_PM_PurviewInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].ObjectID)+''%'' '
    
    IF @PurviewID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PurviewID LIKE '''+CAST(@PurviewID AS nvarchar(100))+'%'' '
        
    IF @PurviewIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PurviewIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewID)+''%'' '
    
    IF @PurviewName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PurviewName LIKE '''+CAST(@PurviewName AS nvarchar(100))+'%'' '
        
    IF @PurviewNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PurviewNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewName)+''%'' '
    
    IF @PurviewTypeID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PurviewTypeID LIKE '''+CAST(@PurviewTypeID AS nvarchar(100))+'%'' '
        
    IF @PurviewTypeIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PurviewTypeIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewTypeID)+''%'' '
    
    IF @PurviewContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PurviewContent LIKE '''+CAST(@PurviewContent AS nvarchar(100))+'%'' '
        
    IF @PurviewContentBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PurviewContentBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewContent)+''%'' '
    
    IF @PurviewRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PurviewRemark LIKE '''+CAST(@PurviewRemark AS nvarchar(100))+'%'' '
        
    IF @PurviewRemarkBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PurviewRemarkBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PurviewRemark)+''%'' '
    
    IF @IsPageMenu IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].IsPageMenu LIKE '''+CAST(@IsPageMenu AS nvarchar(100))+'%'' '
        
    IF @IsPageMenuBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@IsPageMenuBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].IsPageMenu)+''%'' '
    
    IF @PageFileName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PageFileName LIKE '''+CAST(@PageFileName AS nvarchar(100))+'%'' '
        
    IF @PageFileNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PageFileNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PageFileName)+''%'' '
    
    IF @PageFileParameter IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PageFileParameter LIKE '''+CAST(@PageFileParameter AS nvarchar(100))+'%'' '
        
    IF @PageFileParameterBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PageFileParameterBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PageFileParameter)+''%'' '
    
    IF @PageFilePath IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].PageFilePath LIKE '''+CAST(@PageFilePath AS nvarchar(100))+'%'' '
        
    IF @PageFilePathBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PageFilePathBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].PageFilePath)+''%'' '
    
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].UpdateDate = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
    IF @UpdateDateBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].UpdateDate >= '''+CAST(@UpdateDateBegin AS nvarchar(100))+''' '
    IF @UpdateDateEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].UpdateDate <= '''+CAST(@UpdateDateEnd AS nvarchar(100))+''' '
        
    IF @UpdateDateBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UpdateDateBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_PurviewInfo].UpdateDate)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_PM_PurviewInfo] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].ObjectID'
  
    IF @PurviewIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PurviewID = @PurviewIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PurviewID = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PurviewID'
  
    IF @PurviewNameValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PurviewName = @PurviewNameValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PurviewName = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PurviewName'
  
    IF @PurviewTypeIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PurviewTypeID = @PurviewTypeIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PurviewTypeID = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PurviewTypeID'
  
    IF @PurviewContentValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PurviewContent = @PurviewContentValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PurviewContent = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PurviewContent'
  
    IF @PurviewRemarkValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PurviewRemark = @PurviewRemarkValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PurviewRemark = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PurviewRemark'
  
    IF @IsPageMenuValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,IsPageMenu = @IsPageMenuValue'
    ELSE
        SET @SqlText = @SqlText + ' ,IsPageMenu = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].IsPageMenu'
  
    IF @PageFileNameValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PageFileName = @PageFileNameValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PageFileName = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PageFileName'
  
    IF @PageFileParameterValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PageFileParameter = @PageFileParameterValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PageFileParameter = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PageFileParameter'
  
    IF @PageFilePathValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PageFilePath = @PageFilePathValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PageFilePath = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].PageFilePath'
  
    IF @UpdateDateValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UpdateDate = @UpdateDateValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UpdateDate = [DB_MGZZX].[dbo].[T_PM_PurviewInfo].UpdateDate'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_PurviewInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_PurviewInfoByObjectID]
GO

--表T_PM_PurviewInfo以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_PurviewInfoByObjectID] 

@ObjectID nvarchar(50) = NULL
,@PurviewID NVarChar(50) = NULL
,@PurviewName NVarChar(100) = NULL
,@PurviewTypeID NVarChar(50) = NULL
,@PurviewContent NVarChar(255) = NULL
,@PurviewRemark NVarChar(255) = NULL
,@IsPageMenu Bit = NULL
,@PageFileName NVarChar(255) = NULL
,@PageFileParameter NVarChar(255) = NULL
,@PageFilePath NVarChar(255) = NULL
,@UpdateDate DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_PM_PurviewInfo]
    SET 
    
    [ObjectID] = @ObjectID
    , [PurviewID] = @PurviewID
    , [PurviewName] = @PurviewName
    , [PurviewTypeID] = @PurviewTypeID
    , [PurviewContent] = @PurviewContent
    , [PurviewRemark] = @PurviewRemark
    , [IsPageMenu] = @IsPageMenu
    , [PageFileName] = @PageFileName
    , [PageFileParameter] = @PageFileParameter
    , [PageFilePath] = @PageFilePath
    , [UpdateDate] = @UpdateDate
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_PurviewInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_PurviewInfoByKey]
GO

--表T_PM_PurviewInfo以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_PurviewInfoByKey] 

@ObjectID nvarchar(50) = NULL
,@PurviewID NVarChar(50) = NULL
,@PurviewName NVarChar(100) = NULL
,@PurviewTypeID NVarChar(50) = NULL
,@PurviewContent NVarChar(255) = NULL
,@PurviewRemark NVarChar(255) = NULL
,@IsPageMenu Bit = NULL
,@PageFileName NVarChar(255) = NULL
,@PageFileParameter NVarChar(255) = NULL
,@PageFilePath NVarChar(255) = NULL
,@UpdateDate DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PurviewID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewID] = @PurviewID
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PurviewName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewName] = @PurviewName
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PurviewTypeID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewTypeID] = @PurviewTypeID
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PurviewContent IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewContent] = @PurviewContent
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PurviewRemark IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewRemark] = @PurviewRemark
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @IsPageMenu IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [IsPageMenu] = @IsPageMenu
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PageFileName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PageFileName] = @PageFileName
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PageFileParameter IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PageFileParameter] = @PageFileParameter
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @PageFilePath IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PageFilePath] = @PageFilePath
        WHERE
        
        [PurviewID] = @PurviewID
    END
    
    IF @UpdateDate IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [UpdateDate] = @UpdateDate
        WHERE
        
        [PurviewID] = @PurviewID
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_PurviewInfoByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_PurviewInfoByObjectIDBatch]
GO

--表T_PM_PurviewInfo以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_PurviewInfoByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@PurviewID NVarChar(50) = NULL

,@PurviewName NVarChar(100) = NULL

,@PurviewTypeID NVarChar(50) = NULL

,@PurviewContent NVarChar(255) = NULL

,@PurviewRemark NVarChar(255) = NULL

,@IsPageMenu Bit = NULL

,@PageFileName NVarChar(255) = NULL

,@PageFileParameter NVarChar(255) = NULL

,@PageFilePath NVarChar(255) = NULL

,@UpdateDate DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PurviewID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewID] = @PurviewID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PurviewName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewName] = @PurviewName WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PurviewTypeID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewTypeID] = @PurviewTypeID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PurviewContent IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewContent] = @PurviewContent WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PurviewRemark IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PurviewRemark] = @PurviewRemark WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @IsPageMenu IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [IsPageMenu] = @IsPageMenu WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PageFileName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PageFileName] = @PageFileName WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PageFileParameter IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PageFileParameter] = @PageFileParameter WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PageFilePath IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [PageFilePath] = @PageFilePath WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UpdateDate IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_PurviewInfo]
        SET [UpdateDate] = @UpdateDate WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_PurviewInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_PurviewInfoByObjectID]
GO

--表T_PM_PurviewInfo以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_PurviewInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_PM_PurviewInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_PurviewInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_PurviewInfoByKey]
GO

--表T_PM_PurviewInfo以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_PurviewInfoByKey] 

@PurviewID NVarChar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_PM_PurviewInfo]
WHERE

[PurviewID] = @PurviewID
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_PurviewInfoByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_PurviewInfoByObjectIDBatch]
GO

--表T_PM_PurviewInfo以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_PurviewInfoByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_PM_PurviewInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_PurviewInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_PurviewInfoByAnyCondition]
GO

--表T_PM_PurviewInfo任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_PurviewInfoByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @PurviewID NVarChar(50) = NULL
        
, @PurviewIDBatch nvarchar(4000) = NULL

, @PurviewName NVarChar(100) = NULL
        
, @PurviewNameBatch nvarchar(4000) = NULL

, @PurviewTypeID NVarChar(50) = NULL
        
, @PurviewTypeIDBatch nvarchar(4000) = NULL

, @PurviewContent NVarChar(255) = NULL
        
, @PurviewContentBatch nvarchar(4000) = NULL

, @PurviewRemark NVarChar(255) = NULL
        
, @PurviewRemarkBatch nvarchar(4000) = NULL

, @IsPageMenu Bit = NULL
        
, @IsPageMenuBatch nvarchar(4000) = NULL

, @PageFileName NVarChar(255) = NULL
        
, @PageFileNameBatch nvarchar(4000) = NULL

, @PageFileParameter NVarChar(255) = NULL
        
, @PageFileParameterBatch nvarchar(4000) = NULL

, @PageFilePath NVarChar(255) = NULL
        
, @PageFilePathBatch nvarchar(4000) = NULL

, @UpdateDate DateTime = NULL
        
, @UpdateDateBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'PurviewID'
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
    SET @SortField = 'PurviewID'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_PM_PurviewInfo].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_PM_PurviewInfo].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @PurviewID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PurviewID] = '''+CAST(@PurviewID AS nvarchar(100))+''' '
            
    IF @PurviewName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PurviewName] = '''+CAST(@PurviewName AS nvarchar(100))+''' '
            
    IF @PurviewTypeID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PurviewTypeID] = '''+CAST(@PurviewTypeID AS nvarchar(100))+''' '
            
    IF @PurviewContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PurviewContent] = '''+CAST(@PurviewContent AS nvarchar(100))+''' '
            
    IF @PurviewRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PurviewRemark] = '''+CAST(@PurviewRemark AS nvarchar(100))+''' '
            
    IF @IsPageMenu IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[IsPageMenu] = '''+CAST(@IsPageMenu AS nvarchar(100))+''' '
            
    IF @PageFileName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PageFileName] = '''+CAST(@PageFileName AS nvarchar(100))+''' '
            
    IF @PageFileParameter IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PageFileParameter] = '''+CAST(@PageFileParameter AS nvarchar(100))+''' '
            
    IF @PageFilePath IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[PageFilePath] = '''+CAST(@PageFilePath AS nvarchar(100))+''' '
            
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_PurviewInfo].[UpdateDate] = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_PM_PurviewInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @PurviewID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PurviewID] LIKE '''+CAST(@PurviewID AS nvarchar(100))+'%'' '
        
    IF @PurviewName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PurviewName] LIKE '''+CAST(@PurviewName AS nvarchar(100))+'%'' '
        
    IF @PurviewTypeID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PurviewTypeID] LIKE '''+CAST(@PurviewTypeID AS nvarchar(100))+'%'' '
        
    IF @PurviewContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PurviewContent] LIKE '''+CAST(@PurviewContent AS nvarchar(100))+'%'' '
        
    IF @PurviewRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PurviewRemark] LIKE '''+CAST(@PurviewRemark AS nvarchar(100))+'%'' '
        
    IF @IsPageMenu IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[IsPageMenu] LIKE '''+CAST(@IsPageMenu AS nvarchar(100))+'%'' '
        
    IF @PageFileName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PageFileName] LIKE '''+CAST(@PageFileName AS nvarchar(100))+'%'' '
        
    IF @PageFileParameter IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PageFileParameter] LIKE '''+CAST(@PageFileParameter AS nvarchar(100))+'%'' '
        
    IF @PageFilePath IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[PageFilePath] LIKE '''+CAST(@PageFilePath AS nvarchar(100))+'%'' '
        
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_PurviewInfo].[UpdateDate] LIKE '''+CAST(@UpdateDate AS nvarchar(100))+'%'' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_PM_PurviewInfo].[ObjectID]
        
      , [dbo].[T_PM_PurviewInfo].[PurviewID]
        
      , [dbo].[T_PM_PurviewInfo].[PurviewName]
        
      , [dbo].[T_PM_PurviewInfo].[PurviewTypeID]
        
      , [dbo].[T_PM_PurviewInfo].[PurviewContent]
        
      , [dbo].[T_PM_PurviewInfo].[PurviewRemark]
        
      , [dbo].[T_PM_PurviewInfo].[IsPageMenu]
        
      , [dbo].[T_PM_PurviewInfo].[PageFileName]
        
      , [dbo].[T_PM_PurviewInfo].[PageFileParameter]
        
      , [dbo].[T_PM_PurviewInfo].[PageFilePath]
        
      , [dbo].[T_PM_PurviewInfo].[UpdateDate]
        
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
 FROM [dbo].[T_PM_PurviewInfo]'
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
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_ObjectID_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[ObjectID] + '','' LIKE ''%,'' + T_PM_PurviewInfo_ObjectID_Batch.col +'',%''
'
    
IF @PurviewIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PurviewIDBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PurviewID_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PurviewID] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PurviewID_Batch.col +'',%''
'
    
IF @PurviewNameBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PurviewNameBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PurviewName_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PurviewName] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PurviewName_Batch.col +'',%''
'
    
IF @PurviewTypeIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PurviewTypeIDBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PurviewTypeID_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PurviewTypeID] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PurviewTypeID_Batch.col +'',%''
'
    
IF @PurviewContentBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PurviewContentBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PurviewContent_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PurviewContent] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PurviewContent_Batch.col +'',%''
'
    
IF @PurviewRemarkBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PurviewRemarkBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PurviewRemark_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PurviewRemark] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PurviewRemark_Batch.col +'',%''
'
    
IF @IsPageMenuBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@IsPageMenuBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_IsPageMenu_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[IsPageMenu] + '','' LIKE ''%,'' + T_PM_PurviewInfo_IsPageMenu_Batch.col +'',%''
'
    
IF @PageFileNameBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PageFileNameBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PageFileName_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PageFileName] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PageFileName_Batch.col +'',%''
'
    
IF @PageFileParameterBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PageFileParameterBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PageFileParameter_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PageFileParameter] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PageFileParameter_Batch.col +'',%''
'
    
IF @PageFilePathBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PageFilePathBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_PageFilePath_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[PageFilePath] + '','' LIKE ''%,'' + T_PM_PurviewInfo_PageFilePath_Batch.col +'',%''
'
    
IF @UpdateDateBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UpdateDateBatch AS nvarchar(4000))+''', '','') AS T_PM_PurviewInfo_UpdateDate_Batch ON '','' + [dbo].[T_PM_PurviewInfo].[UpdateDate] + '','' LIKE ''%,'' + T_PM_PurviewInfo_UpdateDate_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_PM_PurviewInfo].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_PM_PurviewInfo].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_PurviewInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_PurviewInfoByObjectID]
GO

--表T_PM_PurviewInfo以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_PurviewInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_PM_PurviewInfo].[ObjectID]
    
      , [dbo].[T_PM_PurviewInfo].[PurviewID]
    
      , [dbo].[T_PM_PurviewInfo].[PurviewName]
    
      , [dbo].[T_PM_PurviewInfo].[PurviewTypeID]
    
      , [dbo].[T_PM_PurviewInfo].[PurviewContent]
    
      , [dbo].[T_PM_PurviewInfo].[PurviewRemark]
    
      , [dbo].[T_PM_PurviewInfo].[IsPageMenu]
    
      , [dbo].[T_PM_PurviewInfo].[PageFileName]
    
      , [dbo].[T_PM_PurviewInfo].[PageFileParameter]
    
      , [dbo].[T_PM_PurviewInfo].[PageFilePath]
    
      , [dbo].[T_PM_PurviewInfo].[UpdateDate]
    
FROM [dbo].[T_PM_PurviewInfo]

WHERE
[dbo].[T_PM_PurviewInfo].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_PurviewInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_PurviewInfoByKey]
GO

--表T_PM_PurviewInfo以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_PurviewInfoByKey] 

@PurviewID NVarChar(50) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [PurviewID]
    
      , [PurviewName]
    
      , [PurviewTypeID]
    
      , [PurviewContent]
    
      , [PurviewRemark]
    
      , [IsPageMenu]
    
      , [PageFileName]
    
      , [PageFileParameter]
    
      , [PageFilePath]
    
      , [UpdateDate]
    
FROM [dbo].[T_PM_PurviewInfo]
WHERE

[PurviewID] = @PurviewID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_PM_PurviewInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_PM_PurviewInfoByObjectID]
GO

--表[T_PM_PurviewInfo]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_PM_PurviewInfoByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_PM_PurviewInfo]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_PM_PurviewInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_PM_PurviewInfoByKey]
GO

--表[T_PM_PurviewInfo]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_PM_PurviewInfoByKey] 

@PurviewID NVarChar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_PM_PurviewInfo]
WHERE 

[PurviewID] = @PurviewID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_PM_PurviewInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_PM_PurviewInfoByAnyCondition]
GO

--表T_PM_PurviewInfo任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_PM_PurviewInfoByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_PM_PurviewInfo].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_PM_PurviewInfo]'
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


