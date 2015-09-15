if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_DWXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_DWXX]
GO

--表T_BM_DWXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_DWXX] 

@ObjectID UniqueIdentifier   = NULL
,@DWBH NVarChar (10)
,@DWMC NVarChar (255)
,@SJDWBH NVarChar (255)  = NULL
,@DZ NVarChar (255)  = NULL
,@YB NVarChar (6)  = NULL
,@LXBM NVarChar (50)  = NULL
,@LXDH NVarChar (50)  = NULL
,@Email NVarChar (255)  = NULL
,@LXR NVarChar (50)  = NULL
,@SJ NVarChar (50)  = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @DWBH IS NULL
    SET @DWBH = NULL
IF @DWMC IS NULL
    SET @DWMC = NULL
IF @SJDWBH IS NULL
    SET @SJDWBH = NULL
IF @DZ IS NULL
    SET @DZ = NULL
IF @YB IS NULL
    SET @YB = NULL
IF @LXBM IS NULL
    SET @LXBM = NULL
IF @LXDH IS NULL
    SET @LXDH = NULL
IF @Email IS NULL
    SET @Email = NULL
IF @LXR IS NULL
    SET @LXR = NULL
IF @SJ IS NULL
    SET @SJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_DWXX]
    (
    
    [ObjectID]
    ,[DWBH]
    ,[DWMC]
    ,[SJDWBH]
    ,[DZ]
    ,[YB]
    ,[LXBM]
    ,[LXDH]
    ,[Email]
    ,[LXR]
    ,[SJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@DWBH
    ,@DWMC
    ,@SJDWBH
    ,@DZ
    ,@YB
    ,@LXBM
    ,@LXDH
    ,@Email
    ,@LXR
    ,@SJ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_DWXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_DWXXByAnyCondition]
GO

--表T_BM_DWXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_DWXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @DWBH NVarChar(10) = NULL
        
, @DWBHValue NVarChar(10) = NULL
, @DWBHBatch nvarchar(1000) = NULL

, @DWMC NVarChar(255) = NULL
        
, @DWMCValue NVarChar(255) = NULL
, @DWMCBatch nvarchar(1000) = NULL

, @SJDWBH NVarChar(255) = NULL
        
, @SJDWBHValue NVarChar(255) = NULL
, @SJDWBHBatch nvarchar(1000) = NULL

, @DZ NVarChar(255) = NULL
        
, @DZValue NVarChar(255) = NULL
, @DZBatch nvarchar(1000) = NULL

, @YB NVarChar(6) = NULL
        
, @YBValue NVarChar(6) = NULL
, @YBBatch nvarchar(1000) = NULL

, @LXBM NVarChar(50) = NULL
        
, @LXBMValue NVarChar(50) = NULL
, @LXBMBatch nvarchar(1000) = NULL

, @LXDH NVarChar(50) = NULL
        
, @LXDHValue NVarChar(50) = NULL
, @LXDHBatch nvarchar(1000) = NULL

, @Email NVarChar(255) = NULL
        
, @EmailValue NVarChar(255) = NULL
, @EmailBatch nvarchar(1000) = NULL

, @LXR NVarChar(50) = NULL
        
, @LXRValue NVarChar(50) = NULL
, @LXRBatch nvarchar(1000) = NULL

, @SJ NVarChar(50) = NULL
        
, @SJValue NVarChar(50) = NULL
, @SJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_DWXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].ObjectID)+''%'' '
    
    IF @DWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].DWBH = '''+CAST(@DWBH AS nvarchar(100))+''' '
            
    IF @DWBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DWBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].DWBH)+''%'' '
    
    IF @DWMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].DWMC LIKE ''%'+CAST(@DWMC AS nvarchar(100))+'%'' '
            
    IF @DWMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DWMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].DWMC)+''%'' '
    
    IF @SJDWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].SJDWBH = '''+CAST(@SJDWBH AS nvarchar(100))+''' '
            
    IF @SJDWBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SJDWBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].SJDWBH)+''%'' '
    
    IF @DZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].DZ LIKE ''%'+CAST(@DZ AS nvarchar(100))+'%'' '
            
    IF @DZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].DZ)+''%'' '
    
    IF @YB IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].YB = '''+CAST(@YB AS nvarchar(100))+''' '
            
    IF @YBBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YBBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].YB)+''%'' '
    
    IF @LXBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].LXBM = '''+CAST(@LXBM AS nvarchar(100))+''' '
            
    IF @LXBMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LXBMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].LXBM)+''%'' '
    
    IF @LXDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].LXDH = '''+CAST(@LXDH AS nvarchar(100))+''' '
            
    IF @LXDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LXDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].LXDH)+''%'' '
    
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].Email = '''+CAST(@Email AS nvarchar(100))+''' '
            
    IF @EmailBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@EmailBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].Email)+''%'' '
    
    IF @LXR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].LXR LIKE ''%'+CAST(@LXR AS nvarchar(100))+'%'' '
            
    IF @LXRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LXRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].LXR)+''%'' '
    
    IF @SJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].SJ = '''+CAST(@SJ AS nvarchar(100))+''' '
            
    IF @SJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].SJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_DWXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].ObjectID)+''%'' '
    
    IF @DWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].DWBH LIKE '''+CAST(@DWBH AS nvarchar(100))+'%'' '
        
    IF @DWBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DWBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].DWBH)+''%'' '
    
    IF @DWMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].DWMC LIKE '''+CAST(@DWMC AS nvarchar(100))+'%'' '
        
    IF @DWMCBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DWMCBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].DWMC)+''%'' '
    
    IF @SJDWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].SJDWBH LIKE '''+CAST(@SJDWBH AS nvarchar(100))+'%'' '
        
    IF @SJDWBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SJDWBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].SJDWBH)+''%'' '
    
    IF @DZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].DZ LIKE '''+CAST(@DZ AS nvarchar(100))+'%'' '
        
    IF @DZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].DZ)+''%'' '
    
    IF @YB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].YB LIKE '''+CAST(@YB AS nvarchar(100))+'%'' '
        
    IF @YBBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YBBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].YB)+''%'' '
    
    IF @LXBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].LXBM LIKE '''+CAST(@LXBM AS nvarchar(100))+'%'' '
        
    IF @LXBMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LXBMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].LXBM)+''%'' '
    
    IF @LXDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].LXDH LIKE '''+CAST(@LXDH AS nvarchar(100))+'%'' '
        
    IF @LXDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LXDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].LXDH)+''%'' '
    
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].Email LIKE '''+CAST(@Email AS nvarchar(100))+'%'' '
        
    IF @EmailBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@EmailBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].Email)+''%'' '
    
    IF @LXR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].LXR LIKE '''+CAST(@LXR AS nvarchar(100))+'%'' '
        
    IF @LXRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LXRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].LXR)+''%'' '
    
    IF @SJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].SJ LIKE '''+CAST(@SJ AS nvarchar(100))+'%'' '
        
    IF @SJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_DWXX].SJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_BM_DWXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_BM_DWXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_BM_DWXX].ObjectID'
  
    IF @DWBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DWBH = @DWBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DWBH = [DB_MGZZX].[dbo].[T_BM_DWXX].DWBH'
  
    IF @DWMCValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DWMC = @DWMCValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DWMC = [DB_MGZZX].[dbo].[T_BM_DWXX].DWMC'
  
    IF @SJDWBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SJDWBH = @SJDWBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SJDWBH = [DB_MGZZX].[dbo].[T_BM_DWXX].SJDWBH'
  
    IF @DZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DZ = @DZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DZ = [DB_MGZZX].[dbo].[T_BM_DWXX].DZ'
  
    IF @YBValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YB = @YBValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YB = [DB_MGZZX].[dbo].[T_BM_DWXX].YB'
  
    IF @LXBMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LXBM = @LXBMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LXBM = [DB_MGZZX].[dbo].[T_BM_DWXX].LXBM'
  
    IF @LXDHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LXDH = @LXDHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LXDH = [DB_MGZZX].[dbo].[T_BM_DWXX].LXDH'
  
    IF @EmailValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,Email = @EmailValue'
    ELSE
        SET @SqlText = @SqlText + ' ,Email = [DB_MGZZX].[dbo].[T_BM_DWXX].Email'
  
    IF @LXRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LXR = @LXRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LXR = [DB_MGZZX].[dbo].[T_BM_DWXX].LXR'
  
    IF @SJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SJ = @SJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SJ = [DB_MGZZX].[dbo].[T_BM_DWXX].SJ'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_BM_DWXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_DWXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_DWXXByObjectID]
GO

--表T_BM_DWXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_DWXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@DWBH NVarChar(10) = NULL
,@DWMC NVarChar(255) = NULL
,@SJDWBH NVarChar(255) = NULL
,@DZ NVarChar(255) = NULL
,@YB NVarChar(6) = NULL
,@LXBM NVarChar(50) = NULL
,@LXDH NVarChar(50) = NULL
,@Email NVarChar(255) = NULL
,@LXR NVarChar(50) = NULL
,@SJ NVarChar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_DWXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [DWBH] = @DWBH
    , [DWMC] = @DWMC
    , [SJDWBH] = @SJDWBH
    , [DZ] = @DZ
    , [YB] = @YB
    , [LXBM] = @LXBM
    , [LXDH] = @LXDH
    , [Email] = @Email
    , [LXR] = @LXR
    , [SJ] = @SJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_DWXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_DWXXByKey]
GO

--表T_BM_DWXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_DWXXByKey] 

@ObjectID nvarchar(50) = NULL
,@DWBH NVarChar(10) = NULL
,@DWMC NVarChar(255) = NULL
,@SJDWBH NVarChar(255) = NULL
,@DZ NVarChar(255) = NULL
,@YB NVarChar(6) = NULL
,@LXBM NVarChar(50) = NULL
,@LXDH NVarChar(50) = NULL
,@Email NVarChar(255) = NULL
,@LXR NVarChar(50) = NULL
,@SJ NVarChar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @DWBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [DWBH] = @DWBH
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @DWMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [DWMC] = @DWMC
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @SJDWBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [SJDWBH] = @SJDWBH
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @DZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [DZ] = @DZ
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @YB IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [YB] = @YB
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @LXBM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [LXBM] = @LXBM
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @LXDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [LXDH] = @LXDH
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @Email IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [Email] = @Email
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @LXR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [LXR] = @LXR
        WHERE
        
        [DWBH] = @DWBH
    END
    
    IF @SJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [SJ] = @SJ
        WHERE
        
        [DWBH] = @DWBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_DWXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_DWXXByObjectIDBatch]
GO

--表T_BM_DWXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_DWXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@DWBH NVarChar(10) = NULL

,@DWMC NVarChar(255) = NULL

,@SJDWBH NVarChar(255) = NULL

,@DZ NVarChar(255) = NULL

,@YB NVarChar(6) = NULL

,@LXBM NVarChar(50) = NULL

,@LXDH NVarChar(50) = NULL

,@Email NVarChar(255) = NULL

,@LXR NVarChar(50) = NULL

,@SJ NVarChar(50) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DWBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [DWBH] = @DWBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DWMC IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [DWMC] = @DWMC WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SJDWBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [SJDWBH] = @SJDWBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [DZ] = @DZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YB IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [YB] = @YB WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LXBM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [LXBM] = @LXBM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LXDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [LXDH] = @LXDH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @Email IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [Email] = @Email WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LXR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [LXR] = @LXR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_DWXX]
        SET [SJ] = @SJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_DWXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_DWXXByObjectID]
GO

--表T_BM_DWXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_DWXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_DWXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_DWXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_DWXXByKey]
GO

--表T_BM_DWXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_DWXXByKey] 

@DWBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_DWXX]
WHERE

[DWBH] = @DWBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_DWXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_DWXXByObjectIDBatch]
GO

--表T_BM_DWXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_DWXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_DWXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_DWXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_DWXXByAnyCondition]
GO

--表T_BM_DWXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_DWXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @DWBH NVarChar(10) = NULL
        
, @DWBHBatch nvarchar(4000) = NULL

, @DWMC NVarChar(255) = NULL
        
, @DWMCBatch nvarchar(4000) = NULL

, @SJDWBH NVarChar(255) = NULL
        
, @SJDWBHBatch nvarchar(4000) = NULL

, @DZ NVarChar(255) = NULL
        
, @DZBatch nvarchar(4000) = NULL

, @YB NVarChar(6) = NULL
        
, @YBBatch nvarchar(4000) = NULL

, @LXBM NVarChar(50) = NULL
        
, @LXBMBatch nvarchar(4000) = NULL

, @LXDH NVarChar(50) = NULL
        
, @LXDHBatch nvarchar(4000) = NULL

, @Email NVarChar(255) = NULL
        
, @EmailBatch nvarchar(4000) = NULL

, @LXR NVarChar(50) = NULL
        
, @LXRBatch nvarchar(4000) = NULL

, @SJ NVarChar(50) = NULL
        
, @SJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'DWBH'
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
    SET @SortField = 'DWBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_DWXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_DWXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[DWBH] = '''+CAST(@DWBH AS nvarchar(100))+''' '
            
    IF @DWMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[DWMC] LIKE ''%'+CAST(@DWMC AS nvarchar(100))+'%'' '
            
    IF @SJDWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[SJDWBH] = '''+CAST(@SJDWBH AS nvarchar(100))+''' '
            
    IF @DZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[DZ] LIKE ''%'+CAST(@DZ AS nvarchar(100))+'%'' '
            
    IF @YB IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[YB] = '''+CAST(@YB AS nvarchar(100))+''' '
            
    IF @LXBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[LXBM] = '''+CAST(@LXBM AS nvarchar(100))+''' '
            
    IF @LXDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[LXDH] = '''+CAST(@LXDH AS nvarchar(100))+''' '
            
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[Email] = '''+CAST(@Email AS nvarchar(100))+''' '
            
    IF @LXR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[LXR] LIKE ''%'+CAST(@LXR AS nvarchar(100))+'%'' '
            
    IF @SJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_DWXX].[SJ] = '''+CAST(@SJ AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_DWXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[DWBH] = '''+CAST(@DWBH AS nvarchar(100))+''' '
            
    IF @DWMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[DWMC] LIKE ''%'+CAST(@DWMC AS nvarchar(100))+'%'' '
            
    IF @SJDWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[SJDWBH] = '''+CAST(@SJDWBH AS nvarchar(100))+''' '
            
    IF @DZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[DZ] LIKE ''%'+CAST(@DZ AS nvarchar(100))+'%'' '
            
    IF @YB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[YB] = '''+CAST(@YB AS nvarchar(100))+''' '
            
    IF @LXBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[LXBM] = '''+CAST(@LXBM AS nvarchar(100))+''' '
            
    IF @LXDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[LXDH] = '''+CAST(@LXDH AS nvarchar(100))+''' '
            
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[Email] = '''+CAST(@Email AS nvarchar(100))+''' '
            
    IF @LXR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[LXR] LIKE ''%'+CAST(@LXR AS nvarchar(100))+'%'' '
            
    IF @SJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[SJ] = '''+CAST(@SJ AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_DWXX].[ObjectID]
        
      , [dbo].[T_BM_DWXX].[DWBH]
        
      , [dbo].[T_BM_DWXX].[DWMC]
        
      , [dbo].[T_BM_DWXX].[SJDWBH]
        
      , [dbo].[T_BM_DWXX].[DZ]
        
      , [dbo].[T_BM_DWXX].[YB]
        
      , [dbo].[T_BM_DWXX].[LXBM]
        
      , [dbo].[T_BM_DWXX].[LXDH]
        
      , [dbo].[T_BM_DWXX].[Email]
        
      , [dbo].[T_BM_DWXX].[LXR]
        
      , [dbo].[T_BM_DWXX].[SJ]
        
        ,[SJDWBH_T_BM_DWXX].[DWMC] AS [SJDWBH_T_BM_DWXX_DWMC]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[SJDWBH_T_BM_DWXX].[DWMC] AS [SJDWBH_T_BM_DWXX_DWMC]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BM_DWXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS SJDWBH_T_BM_DWXX ON SJDWBH_T_BM_DWXX.[DWBH] = [dbo].[T_BM_DWXX].[SJDWBH] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_ObjectID_Batch ON '','' + [dbo].[T_BM_DWXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_DWXX_ObjectID_Batch.col +'',%''
'
    
IF @DWBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DWBHBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_DWBH_Batch ON '','' + [dbo].[T_BM_DWXX].[DWBH] + '','' LIKE ''%,'' + T_BM_DWXX_DWBH_Batch.col +'',%''
'
    
IF @DWMCBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DWMCBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_DWMC_Batch ON '','' + [dbo].[T_BM_DWXX].[DWMC] + '','' LIKE ''%,'' + T_BM_DWXX_DWMC_Batch.col +'',%''
'
    
IF @SJDWBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SJDWBHBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_SJDWBH_Batch ON '','' + [dbo].[T_BM_DWXX].[SJDWBH] + '','' LIKE ''%,'' + T_BM_DWXX_SJDWBH_Batch.col +'',%''
'
    
IF @DZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DZBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_DZ_Batch ON '','' + [dbo].[T_BM_DWXX].[DZ] + '','' LIKE ''%,'' + T_BM_DWXX_DZ_Batch.col +'',%''
'
    
IF @YBBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YBBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_YB_Batch ON '','' + [dbo].[T_BM_DWXX].[YB] + '','' LIKE ''%,'' + T_BM_DWXX_YB_Batch.col +'',%''
'
    
IF @LXBMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LXBMBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_LXBM_Batch ON '','' + [dbo].[T_BM_DWXX].[LXBM] + '','' LIKE ''%,'' + T_BM_DWXX_LXBM_Batch.col +'',%''
'
    
IF @LXDHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LXDHBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_LXDH_Batch ON '','' + [dbo].[T_BM_DWXX].[LXDH] + '','' LIKE ''%,'' + T_BM_DWXX_LXDH_Batch.col +'',%''
'
    
IF @EmailBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@EmailBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_Email_Batch ON '','' + [dbo].[T_BM_DWXX].[Email] + '','' LIKE ''%,'' + T_BM_DWXX_Email_Batch.col +'',%''
'
    
IF @LXRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LXRBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_LXR_Batch ON '','' + [dbo].[T_BM_DWXX].[LXR] + '','' LIKE ''%,'' + T_BM_DWXX_LXR_Batch.col +'',%''
'
    
IF @SJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SJBatch AS nvarchar(4000))+''', '','') AS T_BM_DWXX_SJ_Batch ON '','' + [dbo].[T_BM_DWXX].[SJ] + '','' LIKE ''%,'' + T_BM_DWXX_SJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_DWXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_DWXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_DWXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_DWXXByObjectID]
GO

--表T_BM_DWXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_DWXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_DWXX].[ObjectID]
    
      , [dbo].[T_BM_DWXX].[DWBH]
    
      , [dbo].[T_BM_DWXX].[DWMC]
    
      , [dbo].[T_BM_DWXX].[SJDWBH]
    
      , [dbo].[T_BM_DWXX].[DZ]
    
      , [dbo].[T_BM_DWXX].[YB]
    
      , [dbo].[T_BM_DWXX].[LXBM]
    
      , [dbo].[T_BM_DWXX].[LXDH]
    
      , [dbo].[T_BM_DWXX].[Email]
    
      , [dbo].[T_BM_DWXX].[LXR]
    
      , [dbo].[T_BM_DWXX].[SJ]
    
        ,[SJDWBH_T_BM_DWXX].[DWMC] AS [SJDWBH_T_BM_DWXX_DWMC]
FROM [dbo].[T_BM_DWXX]

    LEFT JOIN [dbo].[T_BM_DWXX] AS SJDWBH_T_BM_DWXX ON SJDWBH_T_BM_DWXX.[DWBH] = [dbo].[T_BM_DWXX].[SJDWBH] 
WHERE
[dbo].[T_BM_DWXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_DWXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_DWXXByKey]
GO

--表T_BM_DWXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_DWXXByKey] 

@DWBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [DWBH]
    
      , [DWMC]
    
      , [SJDWBH]
    
      , [DZ]
    
      , [YB]
    
      , [LXBM]
    
      , [LXDH]
    
      , [Email]
    
      , [LXR]
    
      , [SJ]
    
FROM [dbo].[T_BM_DWXX]
WHERE

[DWBH] = @DWBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_DWXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_DWXXByObjectID]
GO

--表[T_BM_DWXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_DWXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_DWXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_DWXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_DWXXByKey]
GO

--表[T_BM_DWXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_DWXXByKey] 

@DWBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_DWXX]
WHERE 

[DWBH] = @DWBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_DWXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_DWXXByAnyCondition]
GO

--表T_BM_DWXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_DWXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_DWXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BM_DWXX]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS [SJDWBH_T_BM_DWXX] ON [SJDWBH_T_BM_DWXX].[DWBH] = [dbo].[T_BM_DWXX].[SJDWBH]  
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


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_DWXXByDWBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_DWXXByDWBH]
GO

--表T_BM_DWXX以DWBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BM_DWXXByDWBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(DWBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BM_DWXX]
WHERE
DWBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BM_DWXX_SJDWBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BM_DWXX_SJDWBH]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BM_DWXX_SJDWBH] 
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
    [DWBH] AS ID,
    [DWMC] AS Name,
    [SJDWBH] AS ParentID
FROM [dbo].[T_BM_DWXX] 
WHERE 1 = 1

UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [SJDWBH] AS ParentID
FROM [dbo].[T_BM_DWXX] 
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

