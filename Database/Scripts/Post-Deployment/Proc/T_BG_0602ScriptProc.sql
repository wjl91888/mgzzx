if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BG_0602]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BG_0602]
GO

--��T_BG_0602����Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_InsertT_BG_0602] 

@ObjectID UniqueIdentifier   = NULL
,@LMH NVarChar (8)
,@LanguageID NVarChar (2)  = NULL
,@LMM NVarChar (50)
,@SJLMH NVarChar (8)  = NULL
,@LMTP NVarChar (255)  = NULL
,@LMNR NVarChar (200)
,@LMLBYS NVarChar (2)
,@SFLBLM NVarChar (1)
,@SFWBURL NVarChar (1)
,@WBURL NVarChar (255)  = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @LMH IS NULL
    SET @LMH = NULL
IF @LanguageID IS NULL
    SET @LanguageID = NULL
IF @LMM IS NULL
    SET @LMM = NULL
IF @SJLMH IS NULL
    SET @SJLMH = NULL
IF @LMTP IS NULL
    SET @LMTP = NULL
IF @LMNR IS NULL
    SET @LMNR = NULL
IF @LMLBYS IS NULL
    SET @LMLBYS = NULL
IF @SFLBLM IS NULL
    SET @SFLBLM = NULL
IF @SFWBURL IS NULL
    SET @SFWBURL = NULL
IF @WBURL IS NULL
    SET @WBURL = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --����������Ϣ
    INSERT INTO [dbo].[T_BG_0602]
    (
    
    [ObjectID]
    ,[LMH]
    ,[LanguageID]
    ,[LMM]
    ,[SJLMH]
    ,[LMTP]
    ,[LMNR]
    ,[LMLBYS]
    ,[SFLBLM]
    ,[SFWBURL]
    ,[WBURL]
    )
    VALUES
    (
    
    @ObjectID
    ,@LMH
    ,@LanguageID
    ,@LMM
    ,@SJLMH
    ,@LMTP
    ,@LMNR
    ,@LMLBYS
    ,@SFLBLM
    ,@SFWBURL
    ,@WBURL
    )
    
    --������ر���Ϣ
    
COMMIT TRANSACTION
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0602ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0602ByAnyCondition]
GO

--��T_BG_0602�����������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0602ByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @LMH NVarChar(8) = NULL
        
, @LMHValue NVarChar(8) = NULL
, @LMHBatch nvarchar(1000) = NULL

, @LanguageID NVarChar(2) = NULL
        
, @LanguageIDValue NVarChar(2) = NULL
, @LanguageIDBatch nvarchar(1000) = NULL

, @LMM NVarChar(50) = NULL
        
, @LMMValue NVarChar(50) = NULL
, @LMMBatch nvarchar(1000) = NULL

, @SJLMH NVarChar(8) = NULL
        
, @SJLMHValue NVarChar(8) = NULL
, @SJLMHBatch nvarchar(1000) = NULL

, @LMTP NVarChar(255) = NULL
        
, @LMTPValue NVarChar(255) = NULL
, @LMTPBatch nvarchar(1000) = NULL

, @LMNR NVarChar(200) = NULL
        
, @LMNRValue NVarChar(200) = NULL
, @LMNRBatch nvarchar(1000) = NULL

, @LMLBYS NVarChar(2) = NULL
        
, @LMLBYSValue NVarChar(2) = NULL
, @LMLBYSBatch nvarchar(1000) = NULL

, @SFLBLM NVarChar(1) = NULL
        
, @SFLBLMValue NVarChar(1) = NULL
, @SFLBLMBatch nvarchar(1000) = NULL

, @SFWBURL NVarChar(1) = NULL
        
, @SFWBURLValue NVarChar(1) = NULL
, @SFWBURLBatch nvarchar(1000) = NULL

, @WBURL NVarChar(255) = NULL
        
, @WBURLValue NVarChar(255) = NULL
, @WBURLBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BG_0602].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].ObjectID)+''%'' '
    
    IF @LMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].LMH = '''+CAST(@LMH AS nvarchar(100))+''' '
            
    IF @LMHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LMHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMH)+''%'' '
    
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].LanguageID = '''+CAST(@LanguageID AS nvarchar(100))+''' '
            
    IF @LanguageIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LanguageIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LanguageID)+''%'' '
    
    IF @LMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].LMM LIKE ''%'+CAST(@LMM AS nvarchar(100))+'%'' '
            
    IF @LMMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LMMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMM)+''%'' '
    
    IF @SJLMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].SJLMH = '''+CAST(@SJLMH AS nvarchar(100))+''' '
            
    IF @SJLMHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SJLMHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].SJLMH)+''%'' '
    
    IF @LMTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].LMTP = '''+CAST(@LMTP AS nvarchar(100))+''' '
            
    IF @LMTPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LMTPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMTP)+''%'' '
    
    IF @LMNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].LMNR LIKE ''%'+CAST(@LMNR AS nvarchar(100))+'%'' '
            
    IF @LMNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LMNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMNR)+''%'' '
    
    IF @LMLBYS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].LMLBYS = '''+CAST(@LMLBYS AS nvarchar(100))+''' '
            
    IF @LMLBYSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LMLBYSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMLBYS)+''%'' '
    
    IF @SFLBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].SFLBLM = '''+CAST(@SFLBLM AS nvarchar(100))+''' '
            
    IF @SFLBLMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SFLBLMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].SFLBLM)+''%'' '
    
    IF @SFWBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].SFWBURL = '''+CAST(@SFWBURL AS nvarchar(100))+''' '
            
    IF @SFWBURLBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SFWBURLBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].SFWBURL)+''%'' '
    
    IF @WBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].WBURL = '''+CAST(@WBURL AS nvarchar(100))+''' '
            
    IF @WBURLBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@WBURLBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].WBURL)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BG_0602].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].ObjectID)+''%'' '
    
    IF @LMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].LMH LIKE '''+CAST(@LMH AS nvarchar(100))+'%'' '
        
    IF @LMHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LMHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMH)+''%'' '
    
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].LanguageID LIKE '''+CAST(@LanguageID AS nvarchar(100))+'%'' '
        
    IF @LanguageIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LanguageIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LanguageID)+''%'' '
    
    IF @LMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].LMM LIKE '''+CAST(@LMM AS nvarchar(100))+'%'' '
        
    IF @LMMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LMMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMM)+''%'' '
    
    IF @SJLMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].SJLMH LIKE '''+CAST(@SJLMH AS nvarchar(100))+'%'' '
        
    IF @SJLMHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SJLMHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].SJLMH)+''%'' '
    
    IF @LMTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].LMTP LIKE '''+CAST(@LMTP AS nvarchar(100))+'%'' '
        
    IF @LMTPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LMTPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMTP)+''%'' '
    
    IF @LMNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].LMNR LIKE '''+CAST(@LMNR AS nvarchar(100))+'%'' '
        
    IF @LMNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LMNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMNR)+''%'' '
    
    IF @LMLBYS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].LMLBYS LIKE '''+CAST(@LMLBYS AS nvarchar(100))+'%'' '
        
    IF @LMLBYSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LMLBYSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].LMLBYS)+''%'' '
    
    IF @SFLBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].SFLBLM LIKE '''+CAST(@SFLBLM AS nvarchar(100))+'%'' '
        
    IF @SFLBLMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SFLBLMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].SFLBLM)+''%'' '
    
    IF @SFWBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].SFWBURL LIKE '''+CAST(@SFWBURL AS nvarchar(100))+'%'' '
        
    IF @SFWBURLBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SFWBURLBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].SFWBURL)+''%'' '
    
    IF @WBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].WBURL LIKE '''+CAST(@WBURL AS nvarchar(100))+'%'' '
        
    IF @WBURLBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@WBURLBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0602].WBURL)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_BG_0602] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_BG_0602] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_BG_0602].ObjectID'
  
    IF @LMHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LMH = @LMHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LMH = [DB_MGZZX].[dbo].[T_BG_0602].LMH'
  
    IF @LanguageIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LanguageID = @LanguageIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LanguageID = [DB_MGZZX].[dbo].[T_BG_0602].LanguageID'
  
    IF @LMMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LMM = @LMMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LMM = [DB_MGZZX].[dbo].[T_BG_0602].LMM'
  
    IF @SJLMHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SJLMH = @SJLMHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SJLMH = [DB_MGZZX].[dbo].[T_BG_0602].SJLMH'
  
    IF @LMTPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LMTP = @LMTPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LMTP = [DB_MGZZX].[dbo].[T_BG_0602].LMTP'
  
    IF @LMNRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LMNR = @LMNRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LMNR = [DB_MGZZX].[dbo].[T_BG_0602].LMNR'
  
    IF @LMLBYSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LMLBYS = @LMLBYSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LMLBYS = [DB_MGZZX].[dbo].[T_BG_0602].LMLBYS'
  
    IF @SFLBLMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SFLBLM = @SFLBLMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SFLBLM = [DB_MGZZX].[dbo].[T_BG_0602].SFLBLM'
  
    IF @SFWBURLValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SFWBURL = @SFWBURLValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SFWBURL = [DB_MGZZX].[dbo].[T_BG_0602].SFWBURL'
  
    IF @WBURLValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,WBURL = @WBURLValue'
    ELSE
        SET @SqlText = @SqlText + ' ,WBURL = [DB_MGZZX].[dbo].[T_BG_0602].WBURL'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_BG_0602] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0602ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0602ByObjectID]
GO

--��T_BG_0602��ObjectIDΪ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0602ByObjectID] 

@ObjectID nvarchar(50) = NULL
,@LMH NVarChar(8) = NULL
,@LanguageID NVarChar(2) = NULL
,@LMM NVarChar(50) = NULL
,@SJLMH NVarChar(8) = NULL
,@LMTP NVarChar(255) = NULL
,@LMNR NVarChar(200) = NULL
,@LMLBYS NVarChar(2) = NULL
,@SFLBLM NVarChar(1) = NULL
,@SFWBURL NVarChar(1) = NULL
,@WBURL NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --�������
    UPDATE [dbo].[T_BG_0602]
    SET 
    
    [ObjectID] = @ObjectID
    , [LMH] = @LMH
    , [LanguageID] = @LanguageID
    , [LMM] = @LMM
    , [SJLMH] = @SJLMH
    , [LMTP] = @LMTP
    , [LMNR] = @LMNR
    , [LMLBYS] = @LMLBYS
    , [SFLBLM] = @SFLBLM
    , [SFWBURL] = @SFWBURL
    , [WBURL] = @WBURL
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0602ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0602ByKey]
GO

--��T_BG_0602������Ϊ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0602ByKey] 

@ObjectID nvarchar(50) = NULL
,@LMH NVarChar(8) = NULL
,@LanguageID NVarChar(2) = NULL
,@LMM NVarChar(50) = NULL
,@SJLMH NVarChar(8) = NULL
,@LMTP NVarChar(255) = NULL
,@LMNR NVarChar(200) = NULL
,@LMLBYS NVarChar(2) = NULL
,@SFLBLM NVarChar(1) = NULL
,@SFWBURL NVarChar(1) = NULL
,@WBURL NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --�������
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @LMH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMH] = @LMH
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @LanguageID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LanguageID] = @LanguageID
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @LMM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMM] = @LMM
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @SJLMH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [SJLMH] = @SJLMH
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @LMTP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMTP] = @LMTP
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @LMNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMNR] = @LMNR
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @LMLBYS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMLBYS] = @LMLBYS
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @SFLBLM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [SFLBLM] = @SFLBLM
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @SFWBURL IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [SFWBURL] = @SFWBURL
        WHERE
        
        [LMH] = @LMH
    END
    
    IF @WBURL IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [WBURL] = @WBURL
        WHERE
        
        [LMH] = @LMH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0602ByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0602ByObjectIDBatch]
GO

--��T_BG_0602��ObjectIDΪ�����������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0602ByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@LMH NVarChar(8) = NULL

,@LanguageID NVarChar(2) = NULL

,@LMM NVarChar(50) = NULL

,@SJLMH NVarChar(8) = NULL

,@LMTP NVarChar(255) = NULL

,@LMNR NVarChar(200) = NULL

,@LMLBYS NVarChar(2) = NULL

,@SFLBLM NVarChar(1) = NULL

,@SFWBURL NVarChar(1) = NULL

,@WBURL NVarChar(255) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --�������
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LMH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMH] = @LMH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LanguageID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LanguageID] = @LanguageID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LMM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMM] = @LMM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SJLMH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [SJLMH] = @SJLMH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LMTP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMTP] = @LMTP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LMNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMNR] = @LMNR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LMLBYS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [LMLBYS] = @LMLBYS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SFLBLM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [SFLBLM] = @SFLBLM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SFWBURL IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [SFWBURL] = @SFWBURL WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @WBURL IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0602]
        SET [WBURL] = @WBURL WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BG_0602ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BG_0602ByObjectID]
GO

--��T_BG_0602��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0602ByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
    DELETE [dbo].[T_BG_0602]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BG_0602ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BG_0602ByKey]
GO

--��T_BG_0602������Ϊ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0602ByKey] 

@LMH NVarChar(8) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BG_0602]
WHERE

[LMH] = @LMH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BG_0602ByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BG_0602ByObjectIDBatch]
GO

--��T_BG_0602��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0602ByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
    DELETE [dbo].[T_BG_0602]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0602ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0602ByAnyCondition]
GO

--��T_BG_0602����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0602ByAnyCondition] 
--�������

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @LMH NVarChar(8) = NULL
        
, @LMHBatch nvarchar(4000) = NULL

, @LanguageID NVarChar(2) = NULL
        
, @LanguageIDBatch nvarchar(4000) = NULL

, @LMM NVarChar(50) = NULL
        
, @LMMBatch nvarchar(4000) = NULL

, @SJLMH NVarChar(8) = NULL
        
, @SJLMHBatch nvarchar(4000) = NULL

, @LMTP NVarChar(255) = NULL
        
, @LMTPBatch nvarchar(4000) = NULL

, @LMNR NVarChar(200) = NULL
        
, @LMNRBatch nvarchar(4000) = NULL

, @LMLBYS NVarChar(2) = NULL
        
, @LMLBYSBatch nvarchar(4000) = NULL

, @SFLBLM NVarChar(1) = NULL
        
, @SFLBLMBatch nvarchar(4000) = NULL

, @SFWBURL NVarChar(1) = NULL
        
, @SFWBURLBatch nvarchar(4000) = NULL

, @WBURL NVarChar(255) = NULL
        
, @WBURLBatch nvarchar(4000) = NULL

--һ��һ��ر����

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'LMH'
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
    SET @SortField = 'LMH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BG_0602].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_BG_0602].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @LMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[LMH] = '''+CAST(@LMH AS nvarchar(100))+''' '
            
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[LanguageID] = '''+CAST(@LanguageID AS nvarchar(100))+''' '
            
    IF @LMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[LMM] LIKE ''%'+CAST(@LMM AS nvarchar(100))+'%'' '
            
    IF @SJLMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[SJLMH] = '''+CAST(@SJLMH AS nvarchar(100))+''' '
            
    IF @LMTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[LMTP] = '''+CAST(@LMTP AS nvarchar(100))+''' '
            
    IF @LMNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[LMNR] LIKE ''%'+CAST(@LMNR AS nvarchar(100))+'%'' '
            
    IF @LMLBYS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[LMLBYS] = '''+CAST(@LMLBYS AS nvarchar(100))+''' '
            
    IF @SFLBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[SFLBLM] = '''+CAST(@SFLBLM AS nvarchar(100))+''' '
            
    IF @SFWBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[SFWBURL] = '''+CAST(@SFWBURL AS nvarchar(100))+''' '
            
    IF @WBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0602].[WBURL] = '''+CAST(@WBURL AS nvarchar(100))+''' '
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_BG_0602].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @LMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMH] = '''+CAST(@LMH AS nvarchar(100))+''' '
            
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LanguageID] = '''+CAST(@LanguageID AS nvarchar(100))+''' '
            
    IF @LMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMM] LIKE ''%'+CAST(@LMM AS nvarchar(100))+'%'' '
            
    IF @SJLMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[SJLMH] = '''+CAST(@SJLMH AS nvarchar(100))+''' '
            
    IF @LMTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMTP] = '''+CAST(@LMTP AS nvarchar(100))+''' '
            
    IF @LMNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMNR] LIKE ''%'+CAST(@LMNR AS nvarchar(100))+'%'' '
            
    IF @LMLBYS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMLBYS] = '''+CAST(@LMLBYS AS nvarchar(100))+''' '
            
    IF @SFLBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[SFLBLM] = '''+CAST(@SFLBLM AS nvarchar(100))+''' '
            
    IF @SFWBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[SFWBURL] = '''+CAST(@SFWBURL AS nvarchar(100))+''' '
            
    IF @WBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[WBURL] = '''+CAST(@WBURL AS nvarchar(100))+''' '
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + '

      [dbo].[T_BG_0602].[ObjectID]
        
      , [dbo].[T_BG_0602].[LMH]
        
      , [dbo].[T_BG_0602].[LanguageID]
        
      , [dbo].[T_BG_0602].[LMM]
        
      , [dbo].[T_BG_0602].[SJLMH]
        
      , [dbo].[T_BG_0602].[LMTP]
        
      , [dbo].[T_BG_0602].[LMNR]
        
      , [dbo].[T_BG_0602].[LMLBYS]
        
      , [dbo].[T_BG_0602].[SFLBLM]
        
      , [dbo].[T_BG_0602].[SFWBURL]
        
      , [dbo].[T_BG_0602].[WBURL]
        
        ,[SJLMH_T_BG_0602].[LMM] AS [SJLMH_T_BG_0602_LMM]
        ,[LMLBYS_Dictionary].[MC] AS [LMLBYS_Dictionary_MC]
        ,[SFLBLM_Dictionary].[MC] AS [SFLBLM_Dictionary_MC]
        ,[SFWBURL_Dictionary].[MC] AS [SFWBURL_Dictionary_MC]
'
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[SJLMH_T_BG_0602].[LMM] AS [SJLMH_T_BG_0602_LMM]
        ,[LMLBYS_Dictionary].[MC] AS [LMLBYS_Dictionary_MC]
        ,[SFLBLM_Dictionary].[MC] AS [SFLBLM_Dictionary_MC]
        ,[SFWBURL_Dictionary].[MC] AS [SFWBURL_Dictionary_MC]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_BG_0602]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BG_0602] AS SJLMH_T_BG_0602 ON SJLMH_T_BG_0602.[LMH] = [dbo].[T_BG_0602].[SJLMH] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS LMLBYS_Dictionary ON LMLBYS_Dictionary.[DM] = [dbo].[T_BG_0602].[LMLBYS]  AND LMLBYS_Dictionary.[LX] = ''0103''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS SFLBLM_Dictionary ON SFLBLM_Dictionary.[DM] = [dbo].[T_BG_0602].[SFLBLM]  AND SFLBLM_Dictionary.[LX] = ''0004''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS SFWBURL_Dictionary ON SFWBURL_Dictionary.[DM] = [dbo].[T_BG_0602].[SFWBURL]  AND SFWBURL_Dictionary.[LX] = ''0004''
'
	
--�����ѯ

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_ObjectID_Batch ON '','' + [dbo].[T_BG_0602].[ObjectID] + '','' LIKE ''%,'' + T_BG_0602_ObjectID_Batch.col +'',%''
'
    
IF @LMHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LMHBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_LMH_Batch ON '','' + [dbo].[T_BG_0602].[LMH] + '','' LIKE ''%,'' + T_BG_0602_LMH_Batch.col +'',%''
'
    
IF @LanguageIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LanguageIDBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_LanguageID_Batch ON '','' + [dbo].[T_BG_0602].[LanguageID] + '','' LIKE ''%,'' + T_BG_0602_LanguageID_Batch.col +'',%''
'
    
IF @LMMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LMMBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_LMM_Batch ON '','' + [dbo].[T_BG_0602].[LMM] + '','' LIKE ''%,'' + T_BG_0602_LMM_Batch.col +'',%''
'
    
IF @SJLMHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SJLMHBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_SJLMH_Batch ON '','' + [dbo].[T_BG_0602].[SJLMH] + '','' LIKE ''%,'' + T_BG_0602_SJLMH_Batch.col +'',%''
'
    
IF @LMTPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LMTPBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_LMTP_Batch ON '','' + [dbo].[T_BG_0602].[LMTP] + '','' LIKE ''%,'' + T_BG_0602_LMTP_Batch.col +'',%''
'
    
IF @LMNRBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LMNRBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_LMNR_Batch ON '','' + [dbo].[T_BG_0602].[LMNR] + '','' LIKE ''%,'' + T_BG_0602_LMNR_Batch.col +'',%''
'
    
IF @LMLBYSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LMLBYSBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_LMLBYS_Batch ON '','' + [dbo].[T_BG_0602].[LMLBYS] + '','' LIKE ''%,'' + T_BG_0602_LMLBYS_Batch.col +'',%''
'
    
IF @SFLBLMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SFLBLMBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_SFLBLM_Batch ON '','' + [dbo].[T_BG_0602].[SFLBLM] + '','' LIKE ''%,'' + T_BG_0602_SFLBLM_Batch.col +'',%''
'
    
IF @SFWBURLBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SFWBURLBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_SFWBURL_Batch ON '','' + [dbo].[T_BG_0602].[SFWBURL] + '','' LIKE ''%,'' + T_BG_0602_SFWBURL_Batch.col +'',%''
'
    
IF @WBURLBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@WBURLBatch AS nvarchar(4000))+''', '','') AS T_BG_0602_WBURL_Batch ON '','' + [dbo].[T_BG_0602].[WBURL] + '','' LIKE ''%,'' + T_BG_0602_WBURL_Batch.col +'',%''
'
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_BG_0602].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BG_0602].[ObjectID]
' + @FromText + '
WHERE ' + @ConditionText + ' ' + @SortText + '
)'

SET @SqlTextCount = 'SELECT @RecordCount=COUNT(*) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount


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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0602ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0602ByObjectID]
GO

--��T_BG_0602��ObjectIDΪ������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0602ByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BG_0602].[ObjectID]
    
      , [dbo].[T_BG_0602].[LMH]
    
      , [dbo].[T_BG_0602].[LanguageID]
    
      , [dbo].[T_BG_0602].[LMM]
    
      , [dbo].[T_BG_0602].[SJLMH]
    
      , [dbo].[T_BG_0602].[LMTP]
    
      , [dbo].[T_BG_0602].[LMNR]
    
      , [dbo].[T_BG_0602].[LMLBYS]
    
      , [dbo].[T_BG_0602].[SFLBLM]
    
      , [dbo].[T_BG_0602].[SFWBURL]
    
      , [dbo].[T_BG_0602].[WBURL]
    
        ,[SJLMH_T_BG_0602].[LMM] AS [SJLMH_T_BG_0602_LMM]
        ,[LMLBYS_Dictionary].[MC] AS [LMLBYS_Dictionary_MC]
        ,[SFLBLM_Dictionary].[MC] AS [SFLBLM_Dictionary_MC]
        ,[SFWBURL_Dictionary].[MC] AS [SFWBURL_Dictionary_MC]
FROM [dbo].[T_BG_0602]

    LEFT JOIN [dbo].[T_BG_0602] AS SJLMH_T_BG_0602 ON SJLMH_T_BG_0602.[LMH] = [dbo].[T_BG_0602].[SJLMH] 
    LEFT JOIN [dbo].[Dictionary] AS LMLBYS_Dictionary ON LMLBYS_Dictionary.[DM] = [dbo].[T_BG_0602].[LMLBYS]  AND LMLBYS_Dictionary.[LX] = '0103'
    LEFT JOIN [dbo].[Dictionary] AS SFLBLM_Dictionary ON SFLBLM_Dictionary.[DM] = [dbo].[T_BG_0602].[SFLBLM]  AND SFLBLM_Dictionary.[LX] = '0004'
    LEFT JOIN [dbo].[Dictionary] AS SFWBURL_Dictionary ON SFWBURL_Dictionary.[DM] = [dbo].[T_BG_0602].[SFWBURL]  AND SFWBURL_Dictionary.[LX] = '0004'
WHERE
[dbo].[T_BG_0602].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0602ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0602ByKey]
GO

--��T_BG_0602������Ϊ������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0602ByKey] 

@LMH NVarChar(8) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [LMH]
    
      , [LanguageID]
    
      , [LMM]
    
      , [SJLMH]
    
      , [LMTP]
    
      , [LMNR]
    
      , [LMLBYS]
    
      , [SFLBLM]
    
      , [SFWBURL]
    
      , [WBURL]
    
FROM [dbo].[T_BG_0602]
WHERE

[LMH] = @LMH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BG_0602ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BG_0602ByObjectID]
GO

--��[T_BG_0602]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

CREATE   PROCEDURE [dbo].[SP_IsExistT_BG_0602ByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BG_0602]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BG_0602ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BG_0602ByKey]
GO

--��[T_BG_0602]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

CREATE   PROCEDURE [dbo].[SP_IsExistT_BG_0602ByKey] 

@LMH NVarChar(8) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BG_0602]
WHERE 

[LMH] = @LMH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BG_0602ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BG_0602ByAnyCondition]
GO

--��T_BG_0602��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_BG_0602ByAnyCondition] 
@CountField NVarChar(200)
--�������

--һ��һ��ر����

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
--�����ѯ����
SET @ConditionText = ' [dbo].[T_BG_0602].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[T_BG_0602]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BG_0602] AS [SJLMH_T_BG_0602] ON [SJLMH_T_BG_0602].[LMH] = [dbo].[T_BG_0602].[SJLMH]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [LMLBYS_Dictionary] ON [LMLBYS_Dictionary].[DM] = [dbo].[T_BG_0602].[LMLBYS]  AND LMLBYS_Dictionary.[LX] = ''0103'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [SFLBLM_Dictionary] ON [SFLBLM_Dictionary].[DM] = [dbo].[T_BG_0602].[SFLBLM]  AND SFLBLM_Dictionary.[LX] = ''0004'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [SFWBURL_Dictionary] ON [SFWBURL_Dictionary].[DM] = [dbo].[T_BG_0602].[SFWBURL]  AND SFWBURL_Dictionary.[LX] = ''0004'' 
'

--�����ѯ

SET @SqlTextCount = 'SELECT @RecordCount = SUM(Record.RecordCount) FROM (' + ' SELECT ' +  @TotalSelectListText + @FromText + ' WHERE ' + @ConditionText + ' GROUP BY ' + @CountField + ') AS Record '
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BG_0602ByLMH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BG_0602ByLMH]
GO

--��T_BG_0602��LMHΪ���������ֵ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BG_0602ByLMH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(LMH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BG_0602]
WHERE
LMH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BG_0602_SJLMH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BG_0602_SJLMH]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BG_0602_SJLMH] 
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
    [LMH] AS ID,
    [LMM] AS Name,
    [SJLMH] AS ParentID
FROM [dbo].[T_BG_0602] 
WHERE 1 = 1

UNION
SELECT
    '+ @IDFieldName +' AS ID,
    '+ @NameFieldName +' AS Name,
    [SJLMH] AS ParentID
FROM [dbo].[T_BG_0602] 
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

