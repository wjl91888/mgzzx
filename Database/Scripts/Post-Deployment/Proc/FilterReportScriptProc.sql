if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertFilterReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertFilterReport]
GO

--表FilterReport插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertFilterReport] 

@ObjectID UniqueIdentifier 
,@BGMC NVarChar (50)
,@UserID NVarChar (50)
,@BGLX NVarChar (50)
,@GXBG NVarChar (1)
,@XTBG NVarChar (1)
,@BGCXTJ NVarChar (4000)
,@BGCJSJ DateTime 

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @BGMC IS NULL
    SET @BGMC = NULL
IF @UserID IS NULL
    SET @UserID = NULL
IF @BGLX IS NULL
    SET @BGLX = NULL
IF @GXBG IS NULL
    SET @GXBG = (0)
IF @XTBG IS NULL
    SET @XTBG = (0)
IF @BGCXTJ IS NULL
    SET @BGCXTJ = NULL
IF @BGCJSJ IS NULL
    SET @BGCJSJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[FilterReport]
    (
    
    [ObjectID]
    ,[BGMC]
    ,[UserID]
    ,[BGLX]
    ,[GXBG]
    ,[XTBG]
    ,[BGCXTJ]
    ,[BGCJSJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@BGMC
    ,@UserID
    ,@BGLX
    ,@GXBG
    ,@XTBG
    ,@BGCXTJ
    ,@BGCJSJ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateFilterReportByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateFilterReportByAnyCondition]
GO

--表FilterReport任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateFilterReportByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @BGMC NVarChar(50) = NULL
        
, @BGMCValue NVarChar(50) = NULL
, @BGMCBatch nvarchar(1000) = NULL

, @UserID NVarChar(50) = NULL
        
, @UserIDValue NVarChar(50) = NULL
, @UserIDBatch nvarchar(1000) = NULL

, @BGLX NVarChar(50) = NULL
        
, @BGLXValue NVarChar(50) = NULL
, @BGLXBatch nvarchar(1000) = NULL

, @GXBG NVarChar(1) = NULL
        
, @GXBGValue NVarChar(1) = NULL
, @GXBGBatch nvarchar(1000) = NULL

, @XTBG NVarChar(1) = NULL
        
, @XTBGValue NVarChar(1) = NULL
, @XTBGBatch nvarchar(1000) = NULL

, @BGCXTJ NVarChar(4000) = NULL
        
, @BGCXTJValue NVarChar(4000) = NULL
, @BGCXTJBatch nvarchar(1000) = NULL

, @BGCJSJ DateTime = NULL
        
, @BGCJSJBegin DateTime = NULL
, @BGCJSJEnd DateTime = NULL
        
, @BGCJSJValue DateTime = NULL
, @BGCJSJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[FilterReport].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].ObjectID)+''%'' '
    
    IF @BGMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].BGMC LIKE ''%'+CAST(@BGMC AS nvarchar(100))+'%'' '
            
    IF @BGMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BGMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGMC)+''%'' '
    
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].UserID = '''+CAST(@UserID AS nvarchar(100))+''' '
            
    IF @UserIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].UserID)+''%'' '
    
    IF @BGLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].BGLX = '''+CAST(@BGLX AS nvarchar(100))+''' '
            
    IF @BGLXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BGLXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGLX)+''%'' '
    
    IF @GXBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].GXBG = '''+CAST(@GXBG AS nvarchar(100))+''' '
            
    IF @GXBGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@GXBGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].GXBG)+''%'' '
    
    IF @XTBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].XTBG = '''+CAST(@XTBG AS nvarchar(100))+''' '
            
    IF @XTBGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XTBGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].XTBG)+''%'' '
    
    IF @BGCXTJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].BGCXTJ = '''+CAST(@BGCXTJ AS nvarchar(100))+''' '
            
    IF @BGCXTJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BGCXTJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGCXTJ)+''%'' '
    
    IF @BGCJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].BGCJSJ = '''+CAST(@BGCJSJ AS nvarchar(100))+''' '
    IF @BGCJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].BGCJSJ >= '''+CAST(@BGCJSJBegin AS nvarchar(100))+''' '
    IF @BGCJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].BGCJSJ <= '''+CAST(@BGCJSJEnd AS nvarchar(100))+''' '
        
    IF @BGCJSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BGCJSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGCJSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[FilterReport].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].ObjectID)+''%'' '
    
    IF @BGMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].BGMC LIKE '''+CAST(@BGMC AS nvarchar(100))+'%'' '
        
    IF @BGMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BGMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGMC)+''%'' '
    
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].UserID LIKE '''+CAST(@UserID AS nvarchar(100))+'%'' '
        
    IF @UserIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].UserID)+''%'' '
    
    IF @BGLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].BGLX LIKE '''+CAST(@BGLX AS nvarchar(100))+'%'' '
        
    IF @BGLXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BGLXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGLX)+''%'' '
    
    IF @GXBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].GXBG LIKE '''+CAST(@GXBG AS nvarchar(100))+'%'' '
        
    IF @GXBGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@GXBGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].GXBG)+''%'' '
    
    IF @XTBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].XTBG LIKE '''+CAST(@XTBG AS nvarchar(100))+'%'' '
        
    IF @XTBGBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XTBGBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].XTBG)+''%'' '
    
    IF @BGCXTJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].BGCXTJ LIKE '''+CAST(@BGCXTJ AS nvarchar(100))+'%'' '
        
    IF @BGCXTJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BGCXTJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGCXTJ)+''%'' '
    
    IF @BGCJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].BGCJSJ = '''+CAST(@BGCJSJ AS nvarchar(100))+''' '
    IF @BGCJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].BGCJSJ >= '''+CAST(@BGCJSJBegin AS nvarchar(100))+''' '
    IF @BGCJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].BGCJSJ <= '''+CAST(@BGCJSJEnd AS nvarchar(100))+''' '
        
    IF @BGCJSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BGCJSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[FilterReport].BGCJSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[FilterReport] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[FilterReport] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[FilterReport].ObjectID'
  
    IF @BGMCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BGMC = @BGMCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BGMC = [DB_MGZZX].[dbo].[FilterReport].BGMC'
  
    IF @UserIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserID = @UserIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserID = [DB_MGZZX].[dbo].[FilterReport].UserID'
  
    IF @BGLXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BGLX = @BGLXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BGLX = [DB_MGZZX].[dbo].[FilterReport].BGLX'
  
    IF @GXBGValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,GXBG = @GXBGValue'
    ELSE
        SET @SqlText = @SqlText + ' ,GXBG = [DB_MGZZX].[dbo].[FilterReport].GXBG'
  
    IF @XTBGValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XTBG = @XTBGValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XTBG = [DB_MGZZX].[dbo].[FilterReport].XTBG'
  
    IF @BGCXTJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BGCXTJ = @BGCXTJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BGCXTJ = [DB_MGZZX].[dbo].[FilterReport].BGCXTJ'
  
    IF @BGCJSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BGCJSJ = @BGCJSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BGCJSJ = [DB_MGZZX].[dbo].[FilterReport].BGCJSJ'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[FilterReport] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateFilterReportByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateFilterReportByObjectID]
GO

--表FilterReport以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateFilterReportByObjectID] 

@ObjectID nvarchar(50) = NULL
,@BGMC NVarChar(50) = NULL
,@UserID NVarChar(50) = NULL
,@BGLX NVarChar(50) = NULL
,@GXBG NVarChar(1) = NULL
,@XTBG NVarChar(1) = NULL
,@BGCXTJ NVarChar(4000) = NULL
,@BGCJSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[FilterReport]
    SET 
    
    [ObjectID] = @ObjectID
    , [BGMC] = @BGMC
    , [UserID] = @UserID
    , [BGLX] = @BGLX
    , [GXBG] = @GXBG
    , [XTBG] = @XTBG
    , [BGCXTJ] = @BGCXTJ
    , [BGCJSJ] = @BGCJSJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateFilterReportByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateFilterReportByKey]
GO

--表FilterReport以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateFilterReportByKey] 

@ObjectID nvarchar(50) = NULL
,@BGMC NVarChar(50) = NULL
,@UserID NVarChar(50) = NULL
,@BGLX NVarChar(50) = NULL
,@GXBG NVarChar(1) = NULL
,@XTBG NVarChar(1) = NULL
,@BGCXTJ NVarChar(4000) = NULL
,@BGCJSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @BGMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGMC] = @BGMC
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @UserID IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [UserID] = @UserID
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @BGLX IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGLX] = @BGLX
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @GXBG IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [GXBG] = @GXBG
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @XTBG IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [XTBG] = @XTBG
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @BGCXTJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGCXTJ] = @BGCXTJ
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @BGCJSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGCJSJ] = @BGCJSJ
        WHERE
        
        [ObjectID] = @ObjectID
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateFilterReportByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateFilterReportByObjectIDBatch]
GO

--表FilterReport以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateFilterReportByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@BGMC NVarChar(50) = NULL

,@UserID NVarChar(50) = NULL

,@BGLX NVarChar(50) = NULL

,@GXBG NVarChar(1) = NULL

,@XTBG NVarChar(1) = NULL

,@BGCXTJ NVarChar(4000) = NULL

,@BGCJSJ DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BGMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGMC] = @BGMC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserID IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [UserID] = @UserID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BGLX IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGLX] = @BGLX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @GXBG IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [GXBG] = @GXBG WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XTBG IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [XTBG] = @XTBG WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BGCXTJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGCXTJ] = @BGCXTJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BGCJSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[FilterReport]
        SET [BGCJSJ] = @BGCJSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteFilterReportByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteFilterReportByObjectID]
GO

--表FilterReport以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteFilterReportByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[FilterReport]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteFilterReportByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteFilterReportByKey]
GO

--表FilterReport以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteFilterReportByKey] 

@ObjectID nvarchar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[FilterReport]
WHERE

[ObjectID] = @ObjectID
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteFilterReportByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteFilterReportByObjectIDBatch]
GO

--表FilterReport以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteFilterReportByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[FilterReport]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectFilterReportByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectFilterReportByAnyCondition]
GO

--表FilterReport任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectFilterReportByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @BGMC NVarChar(50) = NULL
        
, @BGMCBatch nvarchar(4000) = NULL

, @UserID NVarChar(50) = NULL
        
, @UserIDBatch nvarchar(4000) = NULL

, @BGLX NVarChar(50) = NULL
        
, @BGLXBatch nvarchar(4000) = NULL

, @GXBG NVarChar(1) = NULL
        
, @GXBGBatch nvarchar(4000) = NULL

, @XTBG NVarChar(1) = NULL
        
, @XTBGBatch nvarchar(4000) = NULL

, @BGCXTJ NVarChar(4000) = NULL
        
, @BGCXTJBatch nvarchar(4000) = NULL

, @BGCJSJ DateTime = NULL
        
, @BGCJSJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'BGCJSJ'
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
    SET @SortField = 'BGCJSJ'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[FilterReport].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[FilterReport].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @BGMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[BGMC] LIKE ''%'+CAST(@BGMC AS nvarchar(100))+'%'' '
            
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[UserID] = '''+CAST(@UserID AS nvarchar(100))+''' '
            
    IF @BGLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[BGLX] = '''+CAST(@BGLX AS nvarchar(100))+''' '
            
    IF @GXBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[GXBG] = '''+CAST(@GXBG AS nvarchar(100))+''' '
            
    IF @XTBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[XTBG] = '''+CAST(@XTBG AS nvarchar(100))+''' '
            
    IF @BGCXTJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[BGCXTJ] = '''+CAST(@BGCXTJ AS nvarchar(100))+''' '
            
    IF @BGCJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[FilterReport].[BGCJSJ] = '''+CAST(@BGCJSJ AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[FilterReport].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @BGMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGMC] LIKE ''%'+CAST(@BGMC AS nvarchar(100))+'%'' '
            
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[UserID] = '''+CAST(@UserID AS nvarchar(100))+''' '
            
    IF @BGLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGLX] = '''+CAST(@BGLX AS nvarchar(100))+''' '
            
    IF @GXBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[GXBG] = '''+CAST(@GXBG AS nvarchar(100))+''' '
            
    IF @XTBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[XTBG] = '''+CAST(@XTBG AS nvarchar(100))+''' '
            
    IF @BGCXTJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGCXTJ] = '''+CAST(@BGCXTJ AS nvarchar(100))+''' '
            
    IF @BGCJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGCJSJ] = '''+CAST(@BGCJSJ AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[FilterReport].[ObjectID]
        
      , [dbo].[FilterReport].[BGMC]
        
      , [dbo].[FilterReport].[UserID]
        
      , [dbo].[FilterReport].[BGLX]
        
      , [dbo].[FilterReport].[GXBG]
        
      , [dbo].[FilterReport].[XTBG]
        
      , [dbo].[FilterReport].[BGCXTJ]
        
      , [dbo].[FilterReport].[BGCJSJ]
        
        ,[UserID_T_PM_UserInfo].[UserLoginName] AS [UserID_T_PM_UserInfo_UserLoginName]
        ,[GXBG_Dictionary].[MC] AS [GXBG_Dictionary_MC]
        ,[XTBG_Dictionary].[MC] AS [XTBG_Dictionary_MC]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[UserID_T_PM_UserInfo].[UserLoginName] AS [UserID_T_PM_UserInfo_UserLoginName]
        ,[GXBG_Dictionary].[MC] AS [GXBG_Dictionary_MC]
        ,[XTBG_Dictionary].[MC] AS [XTBG_Dictionary_MC]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[FilterReport]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS UserID_T_PM_UserInfo ON UserID_T_PM_UserInfo.[UserID] = [dbo].[FilterReport].[UserID] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS GXBG_Dictionary ON GXBG_Dictionary.[DM] = [dbo].[FilterReport].[GXBG]  AND GXBG_Dictionary.[LX] = ''0004''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS XTBG_Dictionary ON XTBG_Dictionary.[DM] = [dbo].[FilterReport].[XTBG]  AND XTBG_Dictionary.[LX] = ''0004''
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS FilterReport_ObjectID_Batch ON '','' + [dbo].[FilterReport].[ObjectID] + '','' LIKE ''%,'' + FilterReport_ObjectID_Batch.col +'',%''
'
    
IF @BGMCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BGMCBatch AS nvarchar(4000))+''', '','') AS FilterReport_BGMC_Batch ON '','' + [dbo].[FilterReport].[BGMC] + '','' LIKE ''%,'' + FilterReport_BGMC_Batch.col +'',%''
'
    
IF @UserIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserIDBatch AS nvarchar(4000))+''', '','') AS FilterReport_UserID_Batch ON '','' + [dbo].[FilterReport].[UserID] + '','' LIKE ''%,'' + FilterReport_UserID_Batch.col +'',%''
'
    
IF @BGLXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BGLXBatch AS nvarchar(4000))+''', '','') AS FilterReport_BGLX_Batch ON '','' + [dbo].[FilterReport].[BGLX] + '','' LIKE ''%,'' + FilterReport_BGLX_Batch.col +'',%''
'
    
IF @GXBGBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@GXBGBatch AS nvarchar(4000))+''', '','') AS FilterReport_GXBG_Batch ON '','' + [dbo].[FilterReport].[GXBG] + '','' LIKE ''%,'' + FilterReport_GXBG_Batch.col +'',%''
'
    
IF @XTBGBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XTBGBatch AS nvarchar(4000))+''', '','') AS FilterReport_XTBG_Batch ON '','' + [dbo].[FilterReport].[XTBG] + '','' LIKE ''%,'' + FilterReport_XTBG_Batch.col +'',%''
'
    
IF @BGCXTJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BGCXTJBatch AS nvarchar(4000))+''', '','') AS FilterReport_BGCXTJ_Batch ON '','' + [dbo].[FilterReport].[BGCXTJ] + '','' LIKE ''%,'' + FilterReport_BGCXTJ_Batch.col +'',%''
'
    
IF @BGCJSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BGCJSJBatch AS nvarchar(4000))+''', '','') AS FilterReport_BGCJSJ_Batch ON '','' + [dbo].[FilterReport].[BGCJSJ] + '','' LIKE ''%,'' + FilterReport_BGCJSJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[FilterReport].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[FilterReport].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectFilterReportByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectFilterReportByObjectID]
GO

--表FilterReport以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectFilterReportByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[FilterReport].[ObjectID]
    
      , [dbo].[FilterReport].[BGMC]
    
      , [dbo].[FilterReport].[UserID]
    
      , [dbo].[FilterReport].[BGLX]
    
      , [dbo].[FilterReport].[GXBG]
    
      , [dbo].[FilterReport].[XTBG]
    
      , [dbo].[FilterReport].[BGCXTJ]
    
      , [dbo].[FilterReport].[BGCJSJ]
    
        ,[UserID_T_PM_UserInfo].[UserLoginName] AS [UserID_T_PM_UserInfo_UserLoginName]
        ,[GXBG_Dictionary].[MC] AS [GXBG_Dictionary_MC]
        ,[XTBG_Dictionary].[MC] AS [XTBG_Dictionary_MC]
FROM [dbo].[FilterReport]

    LEFT JOIN [dbo].[T_PM_UserInfo] AS UserID_T_PM_UserInfo ON UserID_T_PM_UserInfo.[UserID] = [dbo].[FilterReport].[UserID] 
    LEFT JOIN [dbo].[Dictionary] AS GXBG_Dictionary ON GXBG_Dictionary.[DM] = [dbo].[FilterReport].[GXBG]  AND GXBG_Dictionary.[LX] = '0004'
    LEFT JOIN [dbo].[Dictionary] AS XTBG_Dictionary ON XTBG_Dictionary.[DM] = [dbo].[FilterReport].[XTBG]  AND XTBG_Dictionary.[LX] = '0004'
WHERE
[dbo].[FilterReport].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectFilterReportByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectFilterReportByKey]
GO

--表FilterReport以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectFilterReportByKey] 

@ObjectID nvarchar(50) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [BGMC]
    
      , [UserID]
    
      , [BGLX]
    
      , [GXBG]
    
      , [XTBG]
    
      , [BGCXTJ]
    
      , [BGCJSJ]
    
FROM [dbo].[FilterReport]
WHERE

[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistFilterReportByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistFilterReportByObjectID]
GO

--表[FilterReport]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistFilterReportByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[FilterReport]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistFilterReportByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistFilterReportByKey]
GO

--表[FilterReport]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistFilterReportByKey] 

@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[FilterReport]
WHERE 

[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountFilterReportByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountFilterReportByAnyCondition]
GO

--表FilterReport任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountFilterReportByAnyCondition] 
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
SET @ConditionText = ' [dbo].[FilterReport].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[FilterReport]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [UserID_T_PM_UserInfo] ON [UserID_T_PM_UserInfo].[UserID] = [dbo].[FilterReport].[UserID]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [GXBG_Dictionary] ON [GXBG_Dictionary].[DM] = [dbo].[FilterReport].[GXBG]  AND GXBG_Dictionary.[LX] = ''0004'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [XTBG_Dictionary] ON [XTBG_Dictionary].[DM] = [dbo].[FilterReport].[XTBG]  AND XTBG_Dictionary.[LX] = ''0004'' 
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


