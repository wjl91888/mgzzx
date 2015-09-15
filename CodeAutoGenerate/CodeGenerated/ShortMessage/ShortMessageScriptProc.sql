if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertShortMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertShortMessage]
GO

--表ShortMessage插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertShortMessage] 

@ObjectID UniqueIdentifier 
,@DXXBT NVarChar (100)
,@DXXLX NVarChar (2)  = NULL
,@DXXNR NVarChar (4000)  = NULL
,@DXXFJ NVarChar (255)  = NULL
,@FSSJ DateTime   = NULL
,@FSR NVarChar (50)  = NULL
,@FSBM NVarChar (50)  = NULL
,@FSIP NVarChar (50)  = NULL
,@JSR NVarChar (4000)
,@SFCK Bit   = NULL
,@CKSJ DateTime   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @DXXBT IS NULL
    SET @DXXBT = NULL
IF @DXXLX IS NULL
    SET @DXXLX = NULL
IF @DXXNR IS NULL
    SET @DXXNR = NULL
IF @DXXFJ IS NULL
    SET @DXXFJ = NULL
IF @FSSJ IS NULL
    SET @FSSJ = NULL
IF @FSR IS NULL
    SET @FSR = NULL
IF @FSBM IS NULL
    SET @FSBM = NULL
IF @FSIP IS NULL
    SET @FSIP = NULL
IF @JSR IS NULL
    SET @JSR = NULL
IF @SFCK IS NULL
    SET @SFCK = NULL
IF @CKSJ IS NULL
    SET @CKSJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[ShortMessage]
    (
    
    [ObjectID]
    ,[DXXBT]
    ,[DXXLX]
    ,[DXXNR]
    ,[DXXFJ]
    ,[FSSJ]
    ,[FSR]
    ,[FSBM]
    ,[FSIP]
    ,[JSR]
    ,[SFCK]
    ,[CKSJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@DXXBT
    ,@DXXLX
    ,@DXXNR
    ,@DXXFJ
    ,@FSSJ
    ,@FSR
    ,@FSBM
    ,@FSIP
    ,@JSR
    ,@SFCK
    ,@CKSJ
    )
    
    --同表多条插入
    INSERT INTO [dbo].[ShortMessage]
    (
    ObjectID
    
    ,[DXXBT]
    ,[DXXLX]
    ,[DXXNR]
    ,[DXXFJ]
    ,[FSSJ]
    ,[FSR]
    ,[FSBM]
    ,[FSIP]
    ,[JSR]
    ,[SFCK]
    )
    (SELECT
    newid()
    
    ,@DXXBT
    ,'02'
    ,@DXXNR
    ,@DXXFJ
    ,@FSSJ
    ,@FSR
    ,@FSBM
    ,@FSIP
    ,[dbo].[T_PM_UserInfo].[UserID]
    
    ,0
    FROM [dbo].[ShortMessage]
    
    INNER JOIN [dbo].[T_PM_UserInfo]
    ON [dbo].[ShortMessage].[JSR] LIKE '%'+[dbo].[T_PM_UserInfo].[UserID]+'%' 
    AND [dbo].[ShortMessage].[ObjectID] = @ObjectID
    
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateShortMessageByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateShortMessageByAnyCondition]
GO

--表ShortMessage任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @DXXBT NVarChar(100) = NULL
        
, @DXXBTValue NVarChar(100) = NULL
, @DXXBTBatch nvarchar(1000) = NULL

, @DXXLX NVarChar(2) = NULL
        
, @DXXLXValue NVarChar(2) = NULL
, @DXXLXBatch nvarchar(1000) = NULL

, @DXXNR NVarChar(4000) = NULL
        
, @DXXNRValue NVarChar(4000) = NULL
, @DXXNRBatch nvarchar(1000) = NULL

, @DXXFJ NVarChar(255) = NULL
        
, @DXXFJValue NVarChar(255) = NULL
, @DXXFJBatch nvarchar(1000) = NULL

, @FSSJ DateTime = NULL
        
, @FSSJBegin DateTime = NULL
, @FSSJEnd DateTime = NULL
        
, @FSSJValue DateTime = NULL
, @FSSJBatch nvarchar(1000) = NULL

, @FSR NVarChar(50) = NULL
        
, @FSRValue NVarChar(50) = NULL
, @FSRBatch nvarchar(1000) = NULL

, @FSBM NVarChar(50) = NULL
        
, @FSBMValue NVarChar(50) = NULL
, @FSBMBatch nvarchar(1000) = NULL

, @FSIP NVarChar(50) = NULL
        
, @FSIPValue NVarChar(50) = NULL
, @FSIPBatch nvarchar(1000) = NULL

, @JSR NVarChar(4000) = NULL
        
, @JSRValue NVarChar(4000) = NULL
, @JSRBatch nvarchar(1000) = NULL

, @SFCK Bit = NULL
        
, @SFCKValue Bit = NULL
, @SFCKBatch nvarchar(1000) = NULL

, @CKSJ DateTime = NULL
        
, @CKSJBegin DateTime = NULL
, @CKSJEnd DateTime = NULL
        
, @CKSJValue DateTime = NULL
, @CKSJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[ShortMessage].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].ObjectID)+''%'' '
    
    IF @DXXBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].DXXBT LIKE ''%'+CAST(@DXXBT AS nvarchar(100))+'%'' '
            
    IF @DXXBTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DXXBTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXBT)+''%'' '
    
    IF @DXXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].DXXLX = '''+CAST(@DXXLX AS nvarchar(100))+''' '
            
    IF @DXXLXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DXXLXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXLX)+''%'' '
    
    IF @DXXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].DXXNR LIKE ''%'+CAST(@DXXNR AS nvarchar(100))+'%'' '
            
    IF @DXXNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DXXNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXNR)+''%'' '
    
    IF @DXXFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].DXXFJ = '''+CAST(@DXXFJ AS nvarchar(100))+''' '
            
    IF @DXXFJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DXXFJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXFJ)+''%'' '
    
    IF @FSSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].FSSJ = '''+CAST(@FSSJ AS nvarchar(100))+''' '
    IF @FSSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].FSSJ >= '''+CAST(@FSSJBegin AS nvarchar(100))+''' '
    IF @FSSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].FSSJ <= '''+CAST(@FSSJEnd AS nvarchar(100))+''' '
        
    IF @FSSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FSSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSSJ)+''%'' '
    
    IF @FSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].FSR = '''+CAST(@FSR AS nvarchar(100))+''' '
            
    IF @FSRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FSRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSR)+''%'' '
    
    IF @FSBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].FSBM = '''+CAST(@FSBM AS nvarchar(100))+''' '
            
    IF @FSBMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FSBMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSBM)+''%'' '
    
    IF @FSIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].FSIP = '''+CAST(@FSIP AS nvarchar(100))+''' '
            
    IF @FSIPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FSIPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSIP)+''%'' '
    
    IF @JSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].JSR = '''+CAST(@JSR AS nvarchar(100))+''' '
            
    IF @JSRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JSRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].JSR)+''%'' '
    
    IF @SFCK IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].SFCK = '''+CAST(@SFCK AS nvarchar(100))+''' '
            
    IF @SFCKBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SFCKBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].SFCK)+''%'' '
    
    IF @CKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].CKSJ = '''+CAST(@CKSJ AS nvarchar(100))+''' '
    IF @CKSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].CKSJ >= '''+CAST(@CKSJBegin AS nvarchar(100))+''' '
    IF @CKSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].CKSJ <= '''+CAST(@CKSJEnd AS nvarchar(100))+''' '
        
    IF @CKSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@CKSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].CKSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[ShortMessage].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].ObjectID)+''%'' '
    
    IF @DXXBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].DXXBT LIKE '''+CAST(@DXXBT AS nvarchar(100))+'%'' '
        
    IF @DXXBTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DXXBTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXBT)+''%'' '
    
    IF @DXXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].DXXLX LIKE '''+CAST(@DXXLX AS nvarchar(100))+'%'' '
        
    IF @DXXLXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DXXLXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXLX)+''%'' '
    
    IF @DXXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].DXXNR LIKE '''+CAST(@DXXNR AS nvarchar(100))+'%'' '
        
    IF @DXXNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DXXNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXNR)+''%'' '
    
    IF @DXXFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].DXXFJ LIKE '''+CAST(@DXXFJ AS nvarchar(100))+'%'' '
        
    IF @DXXFJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DXXFJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].DXXFJ)+''%'' '
    
    IF @FSSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].FSSJ = '''+CAST(@FSSJ AS nvarchar(100))+''' '
    IF @FSSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].FSSJ >= '''+CAST(@FSSJBegin AS nvarchar(100))+''' '
    IF @FSSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].FSSJ <= '''+CAST(@FSSJEnd AS nvarchar(100))+''' '
        
    IF @FSSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FSSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSSJ)+''%'' '
    
    IF @FSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].FSR LIKE '''+CAST(@FSR AS nvarchar(100))+'%'' '
        
    IF @FSRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FSRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSR)+''%'' '
    
    IF @FSBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].FSBM LIKE '''+CAST(@FSBM AS nvarchar(100))+'%'' '
        
    IF @FSBMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FSBMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSBM)+''%'' '
    
    IF @FSIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].FSIP LIKE '''+CAST(@FSIP AS nvarchar(100))+'%'' '
        
    IF @FSIPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FSIPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].FSIP)+''%'' '
    
    IF @JSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].JSR LIKE '''+CAST(@JSR AS nvarchar(100))+'%'' '
        
    IF @JSRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JSRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].JSR)+''%'' '
    
    IF @SFCK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].SFCK LIKE '''+CAST(@SFCK AS nvarchar(100))+'%'' '
        
    IF @SFCKBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SFCKBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].SFCK)+''%'' '
    
    IF @CKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].CKSJ = '''+CAST(@CKSJ AS nvarchar(100))+''' '
    IF @CKSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].CKSJ >= '''+CAST(@CKSJBegin AS nvarchar(100))+''' '
    IF @CKSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].CKSJ <= '''+CAST(@CKSJEnd AS nvarchar(100))+''' '
        
    IF @CKSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@CKSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[ShortMessage].CKSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[ShortMessage] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[ShortMessage] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[ShortMessage].ObjectID'
  
    IF @DXXBTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DXXBT = @DXXBTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DXXBT = [DB_MGZZX].[dbo].[ShortMessage].DXXBT'
  
    IF @DXXLXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DXXLX = @DXXLXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DXXLX = [DB_MGZZX].[dbo].[ShortMessage].DXXLX'
  
    IF @DXXNRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DXXNR = @DXXNRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DXXNR = [DB_MGZZX].[dbo].[ShortMessage].DXXNR'
  
    IF @DXXFJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DXXFJ = @DXXFJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DXXFJ = [DB_MGZZX].[dbo].[ShortMessage].DXXFJ'
  
    IF @FSSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FSSJ = @FSSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FSSJ = [DB_MGZZX].[dbo].[ShortMessage].FSSJ'
  
    IF @FSRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FSR = @FSRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FSR = [DB_MGZZX].[dbo].[ShortMessage].FSR'
  
    IF @FSBMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FSBM = @FSBMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FSBM = [DB_MGZZX].[dbo].[ShortMessage].FSBM'
  
    IF @FSIPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FSIP = @FSIPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FSIP = [DB_MGZZX].[dbo].[ShortMessage].FSIP'
  
    IF @JSRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JSR = @JSRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JSR = [DB_MGZZX].[dbo].[ShortMessage].JSR'
  
    IF @SFCKValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SFCK = @SFCKValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SFCK = [DB_MGZZX].[dbo].[ShortMessage].SFCK'
  
    IF @CKSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,CKSJ = @CKSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,CKSJ = [DB_MGZZX].[dbo].[ShortMessage].CKSJ'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[ShortMessage] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateShortMessageByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateShortMessageByObjectID]
GO

--表ShortMessage以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByObjectID] 

@ObjectID nvarchar(50) = NULL
,@DXXBT NVarChar(100) = NULL
,@DXXLX NVarChar(2) = NULL
,@DXXNR NVarChar(4000) = NULL
,@DXXFJ NVarChar(255) = NULL
,@FSSJ DateTime = NULL
,@FSR NVarChar(50) = NULL
,@FSBM NVarChar(50) = NULL
,@FSIP NVarChar(50) = NULL
,@JSR NVarChar(4000) = NULL
,@SFCK Bit = NULL
,@CKSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[ShortMessage]
    SET 
    
    [ObjectID] = @ObjectID
    , [DXXBT] = @DXXBT
    , [DXXLX] = @DXXLX
    , [DXXNR] = @DXXNR
    , [DXXFJ] = @DXXFJ
    , [FSSJ] = @FSSJ
    , [FSR] = @FSR
    , [FSBM] = @FSBM
    , [FSIP] = @FSIP
    , [JSR] = @JSR
    , [SFCK] = @SFCK
    , [CKSJ] = @CKSJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateShortMessageByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateShortMessageByKey]
GO

--表ShortMessage以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByKey] 

@ObjectID nvarchar(50) = NULL
,@DXXBT NVarChar(100) = NULL
,@DXXLX NVarChar(2) = NULL
,@DXXNR NVarChar(4000) = NULL
,@DXXFJ NVarChar(255) = NULL
,@FSSJ DateTime = NULL
,@FSR NVarChar(50) = NULL
,@FSBM NVarChar(50) = NULL
,@FSIP NVarChar(50) = NULL
,@JSR NVarChar(4000) = NULL
,@SFCK Bit = NULL
,@CKSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @DXXBT IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXBT] = @DXXBT
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @DXXLX IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXLX] = @DXXLX
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @DXXNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXNR] = @DXXNR
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @DXXFJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXFJ] = @DXXFJ
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @FSSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSSJ] = @FSSJ
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @FSR IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSR] = @FSR
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @FSBM IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSBM] = @FSBM
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @FSIP IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSIP] = @FSIP
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @JSR IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [JSR] = @JSR
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @SFCK IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [SFCK] = @SFCK
        WHERE
        
        [ObjectID] = @ObjectID
    END
    
    IF @CKSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [CKSJ] = @CKSJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateShortMessageByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateShortMessageByObjectIDBatch]
GO

--表ShortMessage以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@DXXBT NVarChar(100) = NULL

,@DXXLX NVarChar(2) = NULL

,@DXXNR NVarChar(4000) = NULL

,@DXXFJ NVarChar(255) = NULL

,@FSSJ DateTime = NULL

,@FSR NVarChar(50) = NULL

,@FSBM NVarChar(50) = NULL

,@FSIP NVarChar(50) = NULL

,@JSR NVarChar(4000) = NULL

,@SFCK Bit = NULL

,@CKSJ DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DXXBT IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXBT] = @DXXBT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DXXLX IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXLX] = @DXXLX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DXXNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXNR] = @DXXNR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DXXFJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [DXXFJ] = @DXXFJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FSSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSSJ] = @FSSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FSR IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSR] = @FSR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FSBM IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSBM] = @FSBM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FSIP IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [FSIP] = @FSIP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JSR IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [JSR] = @JSR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SFCK IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [SFCK] = @SFCK WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @CKSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[ShortMessage]
        SET [CKSJ] = @CKSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteShortMessageByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteShortMessageByObjectID]
GO

--表ShortMessage以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteShortMessageByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[ShortMessage]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteShortMessageByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteShortMessageByKey]
GO

--表ShortMessage以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteShortMessageByKey] 

@ObjectID nvarchar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[ShortMessage]
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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteShortMessageByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteShortMessageByObjectIDBatch]
GO

--表ShortMessage以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteShortMessageByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[ShortMessage]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectShortMessageByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectShortMessageByAnyCondition]
GO

--表ShortMessage任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectShortMessageByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @DXXBT NVarChar(100) = NULL
        
, @DXXBTBatch nvarchar(4000) = NULL

, @DXXLX NVarChar(2) = NULL
        
, @DXXLXBatch nvarchar(4000) = NULL

, @DXXNR NVarChar(4000) = NULL
        
, @DXXNRBatch nvarchar(4000) = NULL

, @DXXFJ NVarChar(255) = NULL
        
, @DXXFJBatch nvarchar(4000) = NULL

, @FSSJ DateTime = NULL
        
, @FSSJBegin DateTime = NULL
, @FSSJEnd DateTime = NULL
        
, @FSSJBatch nvarchar(4000) = NULL

, @FSR NVarChar(50) = NULL
        
, @FSRBatch nvarchar(4000) = NULL

, @FSBM NVarChar(50) = NULL
        
, @FSBMBatch nvarchar(4000) = NULL

, @FSIP NVarChar(50) = NULL
        
, @FSIPBatch nvarchar(4000) = NULL

, @JSR NVarChar(4000) = NULL
        
, @JSRBatch nvarchar(4000) = NULL

, @SFCK Bit = NULL
        
, @SFCKBatch nvarchar(4000) = NULL

, @CKSJ DateTime = NULL
        
, @CKSJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'FSSJ'
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
    SET @SortField = 'FSSJ'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[ShortMessage].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[ShortMessage].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DXXBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[DXXBT] LIKE ''%'+CAST(@DXXBT AS nvarchar(100))+'%'' '
            
    IF @DXXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[DXXLX] = '''+CAST(@DXXLX AS nvarchar(100))+''' '
            
    IF @DXXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[DXXNR] LIKE ''%'+CAST(@DXXNR AS nvarchar(100))+'%'' '
            
    IF @DXXFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[DXXFJ] = '''+CAST(@DXXFJ AS nvarchar(100))+''' '
            
    IF @FSSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[FSSJ] = '''+CAST(@FSSJ AS nvarchar(100))+''' '
            
    IF @FSSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[FSSJ] >= '''+CAST(@FSSJBegin AS nvarchar(100))+''' '
    IF @FSSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[FSSJ] <= '''+CAST(@FSSJEnd AS nvarchar(100))+''' '
        
    IF @FSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[FSR] = '''+CAST(@FSR AS nvarchar(100))+''' '
            
    IF @FSBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[FSBM] = '''+CAST(@FSBM AS nvarchar(100))+''' '
            
    IF @FSIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[FSIP] = '''+CAST(@FSIP AS nvarchar(100))+''' '
            
    IF @JSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[JSR] = '''+CAST(@JSR AS nvarchar(100))+''' '
            
    IF @SFCK IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[SFCK] = '''+CAST(@SFCK AS nvarchar(100))+''' '
            
    IF @CKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[ShortMessage].[CKSJ] = '''+CAST(@CKSJ AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[ShortMessage].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DXXBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXBT] LIKE ''%'+CAST(@DXXBT AS nvarchar(100))+'%'' '
            
    IF @DXXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXLX] = '''+CAST(@DXXLX AS nvarchar(100))+''' '
            
    IF @DXXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXNR] LIKE ''%'+CAST(@DXXNR AS nvarchar(100))+'%'' '
            
    IF @DXXFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXFJ] = '''+CAST(@DXXFJ AS nvarchar(100))+''' '
            
    IF @FSSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSSJ] = '''+CAST(@FSSJ AS nvarchar(100))+''' '
            
    IF @FSSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSSJ] >= '''+CAST(@FSSJBegin AS nvarchar(100))+''' '
    IF @FSSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSSJ] <= '''+CAST(@FSSJEnd AS nvarchar(100))+''' '
        
    IF @FSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSR] = '''+CAST(@FSR AS nvarchar(100))+''' '
            
    IF @FSBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSBM] = '''+CAST(@FSBM AS nvarchar(100))+''' '
            
    IF @FSIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSIP] = '''+CAST(@FSIP AS nvarchar(100))+''' '
            
    IF @JSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[JSR] = '''+CAST(@JSR AS nvarchar(100))+''' '
            
    IF @SFCK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[SFCK] = '''+CAST(@SFCK AS nvarchar(100))+''' '
            
    IF @CKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[CKSJ] = '''+CAST(@CKSJ AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[ShortMessage].[ObjectID]
        
      , [dbo].[ShortMessage].[DXXBT]
        
      , [dbo].[ShortMessage].[DXXLX]
        
      , [dbo].[ShortMessage].[DXXNR]
        
      , [dbo].[ShortMessage].[DXXFJ]
        
      , [dbo].[ShortMessage].[FSSJ]
        
      , [dbo].[ShortMessage].[FSR]
        
      , [dbo].[ShortMessage].[FSBM]
        
      , [dbo].[ShortMessage].[FSIP]
        
      , [dbo].[ShortMessage].[JSR]
        
      , [dbo].[ShortMessage].[SFCK]
        
      , [dbo].[ShortMessage].[CKSJ]
        
        ,[FSR_T_PM_UserInfo].[UserNickName] AS [FSR_T_PM_UserInfo_UserNickName]
        ,[FSBM_T_BM_DWXX].[DWMC] AS [FSBM_T_BM_DWXX_DWMC]
        ,[dbo].[F_ShortMessage_GetUserNickNameByJSR]([dbo].[ShortMessage].[JSR]) AS [JSR_T_PM_UserInfo_UserNickName]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[FSR_T_PM_UserInfo].[UserNickName] AS [FSR_T_PM_UserInfo_UserNickName]
        ,[FSBM_T_BM_DWXX].[DWMC] AS [FSBM_T_BM_DWXX_DWMC]
        ,[dbo].[F_ShortMessage_GetUserNickNameByJSR]([dbo].[ShortMessage].[JSR]) AS [JSR_T_PM_UserInfo_UserNickName]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[ShortMessage]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS FSR_T_PM_UserInfo ON FSR_T_PM_UserInfo.[UserID] = [dbo].[ShortMessage].[FSR] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS FSBM_T_BM_DWXX ON FSBM_T_BM_DWXX.[DWBH] = [dbo].[ShortMessage].[FSBM] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS JSR_T_PM_UserInfo ON JSR_T_PM_UserInfo.[UserID] = [dbo].[ShortMessage].[JSR] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS ShortMessage_ObjectID_Batch ON '','' + [dbo].[ShortMessage].[ObjectID] + '','' LIKE ''%,'' + ShortMessage_ObjectID_Batch.col +'',%''
'
    
IF @DXXBTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DXXBTBatch AS nvarchar(4000))+''', '','') AS ShortMessage_DXXBT_Batch ON '','' + [dbo].[ShortMessage].[DXXBT] + '','' LIKE ''%,'' + ShortMessage_DXXBT_Batch.col +'',%''
'
    
IF @DXXLXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DXXLXBatch AS nvarchar(4000))+''', '','') AS ShortMessage_DXXLX_Batch ON '','' + [dbo].[ShortMessage].[DXXLX] + '','' LIKE ''%,'' + ShortMessage_DXXLX_Batch.col +'',%''
'
    
IF @DXXNRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DXXNRBatch AS nvarchar(4000))+''', '','') AS ShortMessage_DXXNR_Batch ON '','' + [dbo].[ShortMessage].[DXXNR] + '','' LIKE ''%,'' + ShortMessage_DXXNR_Batch.col +'',%''
'
    
IF @DXXFJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DXXFJBatch AS nvarchar(4000))+''', '','') AS ShortMessage_DXXFJ_Batch ON '','' + [dbo].[ShortMessage].[DXXFJ] + '','' LIKE ''%,'' + ShortMessage_DXXFJ_Batch.col +'',%''
'
    
IF @FSSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FSSJBatch AS nvarchar(4000))+''', '','') AS ShortMessage_FSSJ_Batch ON '','' + [dbo].[ShortMessage].[FSSJ] + '','' LIKE ''%,'' + ShortMessage_FSSJ_Batch.col +'',%''
'
    
IF @FSRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FSRBatch AS nvarchar(4000))+''', '','') AS ShortMessage_FSR_Batch ON '','' + [dbo].[ShortMessage].[FSR] + '','' LIKE ''%,'' + ShortMessage_FSR_Batch.col +'',%''
'
    
IF @FSBMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FSBMBatch AS nvarchar(4000))+''', '','') AS ShortMessage_FSBM_Batch ON '','' + [dbo].[ShortMessage].[FSBM] + '','' LIKE ''%,'' + ShortMessage_FSBM_Batch.col +'',%''
'
    
IF @FSIPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FSIPBatch AS nvarchar(4000))+''', '','') AS ShortMessage_FSIP_Batch ON '','' + [dbo].[ShortMessage].[FSIP] + '','' LIKE ''%,'' + ShortMessage_FSIP_Batch.col +'',%''
'
    
IF @JSRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JSRBatch AS nvarchar(4000))+''', '','') AS ShortMessage_JSR_Batch ON '','' + [dbo].[ShortMessage].[JSR] + '','' LIKE ''%,'' + ShortMessage_JSR_Batch.col +'',%''
'
    
IF @SFCKBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SFCKBatch AS nvarchar(4000))+''', '','') AS ShortMessage_SFCK_Batch ON '','' + [dbo].[ShortMessage].[SFCK] + '','' LIKE ''%,'' + ShortMessage_SFCK_Batch.col +'',%''
'
    
IF @CKSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@CKSJBatch AS nvarchar(4000))+''', '','') AS ShortMessage_CKSJ_Batch ON '','' + [dbo].[ShortMessage].[CKSJ] + '','' LIKE ''%,'' + ShortMessage_CKSJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[ShortMessage].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[ShortMessage].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectShortMessageByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectShortMessageByObjectID]
GO

--表ShortMessage以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectShortMessageByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[ShortMessage].[ObjectID]
    
      , [dbo].[ShortMessage].[DXXBT]
    
      , [dbo].[ShortMessage].[DXXLX]
    
      , [dbo].[ShortMessage].[DXXNR]
    
      , [dbo].[ShortMessage].[DXXFJ]
    
      , [dbo].[ShortMessage].[FSSJ]
    
      , [dbo].[ShortMessage].[FSR]
    
      , [dbo].[ShortMessage].[FSBM]
    
      , [dbo].[ShortMessage].[FSIP]
    
      , [dbo].[ShortMessage].[JSR]
    
      , [dbo].[ShortMessage].[SFCK]
    
      , [dbo].[ShortMessage].[CKSJ]
    
        ,[FSR_T_PM_UserInfo].[UserNickName] AS [FSR_T_PM_UserInfo_UserNickName]
        ,[FSBM_T_BM_DWXX].[DWMC] AS [FSBM_T_BM_DWXX_DWMC]
        ,[dbo].[F_ShortMessage_GetUserNickNameByJSR]([dbo].[ShortMessage].[JSR]) AS [JSR_T_PM_UserInfo_UserNickName]
FROM [dbo].[ShortMessage]

    LEFT JOIN [dbo].[T_PM_UserInfo] AS FSR_T_PM_UserInfo ON FSR_T_PM_UserInfo.[UserID] = [dbo].[ShortMessage].[FSR] 
    LEFT JOIN [dbo].[T_BM_DWXX] AS FSBM_T_BM_DWXX ON FSBM_T_BM_DWXX.[DWBH] = [dbo].[ShortMessage].[FSBM] 
    LEFT JOIN [dbo].[T_PM_UserInfo] AS JSR_T_PM_UserInfo ON JSR_T_PM_UserInfo.[UserID] = [dbo].[ShortMessage].[JSR] 
WHERE
[dbo].[ShortMessage].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectShortMessageByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectShortMessageByKey]
GO

--表ShortMessage以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectShortMessageByKey] 

@ObjectID nvarchar(50) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [DXXBT]
    
      , [DXXLX]
    
      , [DXXNR]
    
      , [DXXFJ]
    
      , [FSSJ]
    
      , [FSR]
    
      , [FSBM]
    
      , [FSIP]
    
      , [JSR]
    
      , [SFCK]
    
      , [CKSJ]
    
FROM [dbo].[ShortMessage]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistShortMessageByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistShortMessageByObjectID]
GO

--表[ShortMessage]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistShortMessageByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[ShortMessage]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistShortMessageByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistShortMessageByKey]
GO

--表[ShortMessage]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistShortMessageByKey] 

@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[ShortMessage]
WHERE 

[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountShortMessageByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountShortMessageByAnyCondition]
GO

--表ShortMessage任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountShortMessageByAnyCondition] 
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
SET @ConditionText = ' [dbo].[ShortMessage].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[ShortMessage]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [FSR_T_PM_UserInfo] ON [FSR_T_PM_UserInfo].[UserID] = [dbo].[ShortMessage].[FSR]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS [FSBM_T_BM_DWXX] ON [FSBM_T_BM_DWXX].[DWBH] = [dbo].[ShortMessage].[FSBM]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [JSR_T_PM_UserInfo] ON '','' + [dbo].[ShortMessage].[JSR] + '','' LIKE ''%,'' + [JSR_T_PM_UserInfo].[UserID] + '',%'' 
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[F_ShortMessage_GetUserNickNameByJSR]') and OBJECTPROPERTY(id, N'IsProcedure') = 0)
drop FUNCTION [dbo].[F_ShortMessage_GetUserNickNameByJSR]
GO

CREATE  FUNCTION [dbo].[F_ShortMessage_GetUserNickNameByJSR]  (@InputValue  NVarChar(4000))  
RETURNS NVarchar(4000)
BEGIN 
DECLARE @Output NVarChar(4000) 
DECLARE @COUNT INT
DECLARE @OutputField NVarChar(100)
DECLARE RecordCursor Cursor  scroll dynamic
FOR
SELECT [UserNickName]
FROM [dbo].[T_PM_UserInfo]
WHERE [UserID] IN (SELECT * FROM [dbo].F_SplitStr(@InputValue, ','))

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
      
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_ShortMessage_JSR]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_ShortMessage_JSR]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_ShortMessage_JSR] 
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
    [UserID] AS ID,
    [UserNickName] AS Name,
    [SubjectID] AS ParentID
FROM [dbo].[T_PM_UserInfo] 
WHERE 1 = 1

UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [JSR] AS ParentID
FROM [dbo].[ShortMessage] 
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

