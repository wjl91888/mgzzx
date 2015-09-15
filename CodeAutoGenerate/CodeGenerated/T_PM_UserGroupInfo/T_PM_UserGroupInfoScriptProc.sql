if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_PM_UserGroupInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_PM_UserGroupInfo]
GO

--表T_PM_UserGroupInfo插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_PM_UserGroupInfo] 

@ObjectID UniqueIdentifier   = NULL
,@UserGroupID NVarChar (50)
,@UserGroupName NVarChar (100)
,@UserGroupContent NVarChar (255)  = NULL
,@UserGroupRemark NVarChar (255)  = NULL
,@DefaultPage NVarChar (255)  = NULL
,@UpdateDate DateTime   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @UserGroupID IS NULL
    SET @UserGroupID = newid()
IF @UserGroupName IS NULL
    SET @UserGroupName = NULL
IF @UserGroupContent IS NULL
    SET @UserGroupContent = NULL
IF @UserGroupRemark IS NULL
    SET @UserGroupRemark = NULL
IF @DefaultPage IS NULL
    SET @DefaultPage = NULL
IF @UpdateDate IS NULL
    SET @UpdateDate = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_PM_UserGroupInfo]
    (
    
    [ObjectID]
    ,[UserGroupID]
    ,[UserGroupName]
    ,[UserGroupContent]
    ,[UserGroupRemark]
    ,[DefaultPage]
    ,[UpdateDate]
    )
    VALUES
    (
    
    @ObjectID
    ,@UserGroupID
    ,@UserGroupName
    ,@UserGroupContent
    ,@UserGroupRemark
    ,@DefaultPage
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserGroupInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserGroupInfoByAnyCondition]
GO

--表T_PM_UserGroupInfo任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserGroupInfoByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @UserGroupID NVarChar(50) = NULL
        
, @UserGroupIDValue NVarChar(50) = NULL
, @UserGroupIDBatch nvarchar(1000) = NULL

, @UserGroupName NVarChar(100) = NULL
        
, @UserGroupNameValue NVarChar(100) = NULL
, @UserGroupNameBatch nvarchar(1000) = NULL

, @UserGroupContent NVarChar(255) = NULL
        
, @UserGroupContentValue NVarChar(255) = NULL
, @UserGroupContentBatch nvarchar(1000) = NULL

, @UserGroupRemark NVarChar(255) = NULL
        
, @UserGroupRemarkValue NVarChar(255) = NULL
, @UserGroupRemarkBatch nvarchar(1000) = NULL

, @DefaultPage NVarChar(255) = NULL
        
, @DefaultPageValue NVarChar(255) = NULL
, @DefaultPageBatch nvarchar(1000) = NULL

, @UpdateDate DateTime = NULL
        
, @UpdateDateBegin DateTime = NULL
, @UpdateDateEnd DateTime = NULL
        
, @UpdateDateValue DateTime = NULL
, @UpdateDateBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_PM_UserGroupInfo].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].ObjectID)+''%'' '
    
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UserGroupID = '''+CAST(@UserGroupID AS nvarchar(100))+''' '
            
    IF @UserGroupIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserGroupIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupID)+''%'' '
    
    IF @UserGroupName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UserGroupName LIKE ''%'+CAST(@UserGroupName AS nvarchar(100))+'%'' '
            
    IF @UserGroupNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserGroupNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupName)+''%'' '
    
    IF @UserGroupContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UserGroupContent LIKE ''%'+CAST(@UserGroupContent AS nvarchar(100))+'%'' '
            
    IF @UserGroupContentBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserGroupContentBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupContent)+''%'' '
    
    IF @UserGroupRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UserGroupRemark LIKE ''%'+CAST(@UserGroupRemark AS nvarchar(100))+'%'' '
            
    IF @UserGroupRemarkBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserGroupRemarkBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupRemark)+''%'' '
    
    IF @DefaultPage IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].DefaultPage = '''+CAST(@DefaultPage AS nvarchar(100))+''' '
            
    IF @DefaultPageBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DefaultPageBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].DefaultPage)+''%'' '
    
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UpdateDate = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
    IF @UpdateDateBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UpdateDate >= '''+CAST(@UpdateDateBegin AS nvarchar(100))+''' '
    IF @UpdateDateEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].UpdateDate <= '''+CAST(@UpdateDateEnd AS nvarchar(100))+''' '
        
    IF @UpdateDateBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UpdateDateBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UpdateDate)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_PM_UserGroupInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].ObjectID)+''%'' '
    
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UserGroupID LIKE '''+CAST(@UserGroupID AS nvarchar(100))+'%'' '
        
    IF @UserGroupIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserGroupIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupID)+''%'' '
    
    IF @UserGroupName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UserGroupName LIKE '''+CAST(@UserGroupName AS nvarchar(100))+'%'' '
        
    IF @UserGroupNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserGroupNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupName)+''%'' '
    
    IF @UserGroupContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UserGroupContent LIKE '''+CAST(@UserGroupContent AS nvarchar(100))+'%'' '
        
    IF @UserGroupContentBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserGroupContentBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupContent)+''%'' '
    
    IF @UserGroupRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UserGroupRemark LIKE '''+CAST(@UserGroupRemark AS nvarchar(100))+'%'' '
        
    IF @UserGroupRemarkBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserGroupRemarkBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UserGroupRemark)+''%'' '
    
    IF @DefaultPage IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].DefaultPage LIKE '''+CAST(@DefaultPage AS nvarchar(100))+'%'' '
        
    IF @DefaultPageBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DefaultPageBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].DefaultPage)+''%'' '
    
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UpdateDate = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
    IF @UpdateDateBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UpdateDate >= '''+CAST(@UpdateDateBegin AS nvarchar(100))+''' '
    IF @UpdateDateEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].UpdateDate <= '''+CAST(@UpdateDateEnd AS nvarchar(100))+''' '
        
    IF @UpdateDateBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UpdateDateBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserGroupInfo].UpdateDate)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_PM_UserGroupInfo] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_PM_UserGroupInfo] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].ObjectID'
  
    IF @UserGroupIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserGroupID = @UserGroupIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserGroupID = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].UserGroupID'
  
    IF @UserGroupNameValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserGroupName = @UserGroupNameValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserGroupName = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].UserGroupName'
  
    IF @UserGroupContentValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserGroupContent = @UserGroupContentValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserGroupContent = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].UserGroupContent'
  
    IF @UserGroupRemarkValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserGroupRemark = @UserGroupRemarkValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserGroupRemark = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].UserGroupRemark'
  
    IF @DefaultPageValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DefaultPage = @DefaultPageValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DefaultPage = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].DefaultPage'
  
    IF @UpdateDateValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UpdateDate = @UpdateDateValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UpdateDate = [DB_MGZZX].[dbo].[T_PM_UserGroupInfo].UpdateDate'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_PM_UserGroupInfo] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserGroupInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserGroupInfoByObjectID]
GO

--表T_PM_UserGroupInfo以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserGroupInfoByObjectID] 

@ObjectID nvarchar(50) = NULL
,@UserGroupID NVarChar(50) = NULL
,@UserGroupName NVarChar(100) = NULL
,@UserGroupContent NVarChar(255) = NULL
,@UserGroupRemark NVarChar(255) = NULL
,@DefaultPage NVarChar(255) = NULL
,@UpdateDate DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_PM_UserGroupInfo]
    SET 
    
    [ObjectID] = @ObjectID
    , [UserGroupID] = @UserGroupID
    , [UserGroupName] = @UserGroupName
    , [UserGroupContent] = @UserGroupContent
    , [UserGroupRemark] = @UserGroupRemark
    , [DefaultPage] = @DefaultPage
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserGroupInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserGroupInfoByKey]
GO

--表T_PM_UserGroupInfo以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserGroupInfoByKey] 

@ObjectID nvarchar(50) = NULL
,@UserGroupID NVarChar(50) = NULL
,@UserGroupName NVarChar(100) = NULL
,@UserGroupContent NVarChar(255) = NULL
,@UserGroupRemark NVarChar(255) = NULL
,@DefaultPage NVarChar(255) = NULL
,@UpdateDate DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [UserGroupID] = @UserGroupID
    END
    
    IF @UserGroupID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupID] = @UserGroupID
        WHERE
        
        [UserGroupID] = @UserGroupID
    END
    
    IF @UserGroupName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupName] = @UserGroupName
        WHERE
        
        [UserGroupID] = @UserGroupID
    END
    
    IF @UserGroupContent IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupContent] = @UserGroupContent
        WHERE
        
        [UserGroupID] = @UserGroupID
    END
    
    IF @UserGroupRemark IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupRemark] = @UserGroupRemark
        WHERE
        
        [UserGroupID] = @UserGroupID
    END
    
    IF @DefaultPage IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [DefaultPage] = @DefaultPage
        WHERE
        
        [UserGroupID] = @UserGroupID
    END
    
    IF @UpdateDate IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UpdateDate] = @UpdateDate
        WHERE
        
        [UserGroupID] = @UserGroupID
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserGroupInfoByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserGroupInfoByObjectIDBatch]
GO

--表T_PM_UserGroupInfo以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserGroupInfoByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@UserGroupID NVarChar(50) = NULL

,@UserGroupName NVarChar(100) = NULL

,@UserGroupContent NVarChar(255) = NULL

,@UserGroupRemark NVarChar(255) = NULL

,@DefaultPage NVarChar(255) = NULL

,@UpdateDate DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserGroupID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupID] = @UserGroupID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserGroupName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupName] = @UserGroupName WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserGroupContent IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupContent] = @UserGroupContent WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserGroupRemark IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [UserGroupRemark] = @UserGroupRemark WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DefaultPage IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
        SET [DefaultPage] = @DefaultPage WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UpdateDate IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserGroupInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_UserGroupInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_UserGroupInfoByObjectID]
GO

--表T_PM_UserGroupInfo以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserGroupInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_PM_UserGroupInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_UserGroupInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_UserGroupInfoByKey]
GO

--表T_PM_UserGroupInfo以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserGroupInfoByKey] 

@UserGroupID NVarChar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_PM_UserGroupInfo]
WHERE

[UserGroupID] = @UserGroupID
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_UserGroupInfoByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_UserGroupInfoByObjectIDBatch]
GO

--表T_PM_UserGroupInfo以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserGroupInfoByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_PM_UserGroupInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserGroupInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserGroupInfoByAnyCondition]
GO

--表T_PM_UserGroupInfo任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserGroupInfoByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @UserGroupID NVarChar(50) = NULL
        
, @UserGroupIDBatch nvarchar(4000) = NULL

, @UserGroupName NVarChar(100) = NULL
        
, @UserGroupNameBatch nvarchar(4000) = NULL

, @UserGroupContent NVarChar(255) = NULL
        
, @UserGroupContentBatch nvarchar(4000) = NULL

, @UserGroupRemark NVarChar(255) = NULL
        
, @UserGroupRemarkBatch nvarchar(4000) = NULL

, @DefaultPage NVarChar(255) = NULL
        
, @DefaultPageBatch nvarchar(4000) = NULL

, @UpdateDate DateTime = NULL
        
, @UpdateDateBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'UserGroupID'
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
    SET @SortField = 'UserGroupID'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_PM_UserGroupInfo].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_PM_UserGroupInfo].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[UserGroupID] = '''+CAST(@UserGroupID AS nvarchar(100))+''' '
            
    IF @UserGroupName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[UserGroupName] LIKE ''%'+CAST(@UserGroupName AS nvarchar(100))+'%'' '
            
    IF @UserGroupContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[UserGroupContent] LIKE ''%'+CAST(@UserGroupContent AS nvarchar(100))+'%'' '
            
    IF @UserGroupRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[UserGroupRemark] LIKE ''%'+CAST(@UserGroupRemark AS nvarchar(100))+'%'' '
            
    IF @DefaultPage IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[DefaultPage] = '''+CAST(@DefaultPage AS nvarchar(100))+''' '
            
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserGroupInfo].[UpdateDate] = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_PM_UserGroupInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupID] = '''+CAST(@UserGroupID AS nvarchar(100))+''' '
            
    IF @UserGroupName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupName] LIKE ''%'+CAST(@UserGroupName AS nvarchar(100))+'%'' '
            
    IF @UserGroupContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupContent] LIKE ''%'+CAST(@UserGroupContent AS nvarchar(100))+'%'' '
            
    IF @UserGroupRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupRemark] LIKE ''%'+CAST(@UserGroupRemark AS nvarchar(100))+'%'' '
            
    IF @DefaultPage IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[DefaultPage] = '''+CAST(@DefaultPage AS nvarchar(100))+''' '
            
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UpdateDate] = '''+CAST(@UpdateDate AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_PM_UserGroupInfo].[ObjectID]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupID]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupName]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupContent]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupRemark]
        
      , [dbo].[T_PM_UserGroupInfo].[DefaultPage]
        
      , [dbo].[T_PM_UserGroupInfo].[UpdateDate]
        
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
 FROM [dbo].[T_PM_UserGroupInfo]'
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
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_ObjectID_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[ObjectID] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_ObjectID_Batch.col +'',%''
'
    
IF @UserGroupIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserGroupIDBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_UserGroupID_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[UserGroupID] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_UserGroupID_Batch.col +'',%''
'
    
IF @UserGroupNameBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserGroupNameBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_UserGroupName_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[UserGroupName] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_UserGroupName_Batch.col +'',%''
'
    
IF @UserGroupContentBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserGroupContentBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_UserGroupContent_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[UserGroupContent] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_UserGroupContent_Batch.col +'',%''
'
    
IF @UserGroupRemarkBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserGroupRemarkBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_UserGroupRemark_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[UserGroupRemark] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_UserGroupRemark_Batch.col +'',%''
'
    
IF @DefaultPageBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DefaultPageBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_DefaultPage_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[DefaultPage] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_DefaultPage_Batch.col +'',%''
'
    
IF @UpdateDateBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UpdateDateBatch AS nvarchar(4000))+''', '','') AS T_PM_UserGroupInfo_UpdateDate_Batch ON '','' + [dbo].[T_PM_UserGroupInfo].[UpdateDate] + '','' LIKE ''%,'' + T_PM_UserGroupInfo_UpdateDate_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_PM_UserGroupInfo].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_PM_UserGroupInfo].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserGroupInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserGroupInfoByObjectID]
GO

--表T_PM_UserGroupInfo以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserGroupInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_PM_UserGroupInfo].[ObjectID]
    
      , [dbo].[T_PM_UserGroupInfo].[UserGroupID]
    
      , [dbo].[T_PM_UserGroupInfo].[UserGroupName]
    
      , [dbo].[T_PM_UserGroupInfo].[UserGroupContent]
    
      , [dbo].[T_PM_UserGroupInfo].[UserGroupRemark]
    
      , [dbo].[T_PM_UserGroupInfo].[DefaultPage]
    
      , [dbo].[T_PM_UserGroupInfo].[UpdateDate]
    
FROM [dbo].[T_PM_UserGroupInfo]

WHERE
[dbo].[T_PM_UserGroupInfo].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserGroupInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserGroupInfoByKey]
GO

--表T_PM_UserGroupInfo以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserGroupInfoByKey] 

@UserGroupID NVarChar(50) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [UserGroupID]
    
      , [UserGroupName]
    
      , [UserGroupContent]
    
      , [UserGroupRemark]
    
      , [DefaultPage]
    
      , [UpdateDate]
    
FROM [dbo].[T_PM_UserGroupInfo]
WHERE

[UserGroupID] = @UserGroupID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_PM_UserGroupInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_PM_UserGroupInfoByObjectID]
GO

--表[T_PM_UserGroupInfo]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_PM_UserGroupInfoByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_PM_UserGroupInfo]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_PM_UserGroupInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_PM_UserGroupInfoByKey]
GO

--表[T_PM_UserGroupInfo]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_PM_UserGroupInfoByKey] 

@UserGroupID NVarChar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_PM_UserGroupInfo]
WHERE 

[UserGroupID] = @UserGroupID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_PM_UserGroupInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_PM_UserGroupInfoByAnyCondition]
GO

--表T_PM_UserGroupInfo任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_PM_UserGroupInfoByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_PM_UserGroupInfo].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_PM_UserGroupInfo]'
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


