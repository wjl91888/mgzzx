if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BG_0601]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BG_0601]
GO

--表T_BG_0601插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BG_0601] 

@ObjectID UniqueIdentifier   = NULL
,@FBH NVarChar (10)
,@BT NVarChar (100)
,@LanguageID NVarChar (2)  = NULL
,@FBLM NVarChar (8)
,@FBBM NVarChar (50)  = NULL
,@FBZT NVarChar (8)  = NULL
,@XXLX NVarChar (2)
,@XXTPDZ NVarChar (255)  = NULL
,@XXNR NText 
,@FJXZDZ NVarChar (4000)  = NULL
,@PZRJGH NVarChar (10)  = NULL
,@XXZT NVarChar (2)  = NULL
,@IsTop NVarChar (1)  = NULL
,@TopSort Int   = NULL
,@IsBest NVarChar (1)  = NULL
,@YXSJRQ DateTime   = NULL
,@FBRJGH NVarChar (10)  = NULL
,@FBSJRQ DateTime   = NULL
,@FBIP NVarChar (20)  = NULL
,@LLCS Int   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @FBH IS NULL
    SET @FBH = NULL
IF @BT IS NULL
    SET @BT = NULL
IF @LanguageID IS NULL
    SET @LanguageID = NULL
IF @FBLM IS NULL
    SET @FBLM = NULL
IF @FBBM IS NULL
    SET @FBBM = NULL
IF @FBZT IS NULL
    SET @FBZT = NULL
IF @XXLX IS NULL
    SET @XXLX = NULL
IF @XXTPDZ IS NULL
    SET @XXTPDZ = NULL
IF @FJXZDZ IS NULL
    SET @FJXZDZ = NULL
IF @PZRJGH IS NULL
    SET @PZRJGH = NULL
IF @XXZT IS NULL
    SET @XXZT = 02
IF @IsTop IS NULL
    SET @IsTop = 0
IF @TopSort IS NULL
    SET @TopSort = 0
IF @IsBest IS NULL
    SET @IsBest = 0
IF @YXSJRQ IS NULL
    SET @YXSJRQ = NULL
IF @FBRJGH IS NULL
    SET @FBRJGH = NULL
IF @FBSJRQ IS NULL
    SET @FBSJRQ = NULL
IF @FBIP IS NULL
    SET @FBIP = NULL
IF @LLCS IS NULL
    SET @LLCS = 0
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BG_0601]
    (
    
    [ObjectID]
    ,[FBH]
    ,[BT]
    ,[LanguageID]
    ,[FBLM]
    ,[FBBM]
    ,[FBZT]
    ,[XXLX]
    ,[XXTPDZ]
    ,[XXNR]
    ,[FJXZDZ]
    ,[PZRJGH]
    ,[XXZT]
    ,[IsTop]
    ,[TopSort]
    ,[IsBest]
    ,[YXSJRQ]
    ,[FBRJGH]
    ,[FBSJRQ]
    ,[FBIP]
    ,[LLCS]
    )
    VALUES
    (
    
    @ObjectID
    ,@FBH
    ,@BT
    ,@LanguageID
    ,@FBLM
    ,@FBBM
    ,@FBZT
    ,@XXLX
    ,@XXTPDZ
    ,@XXNR
    ,@FJXZDZ
    ,@PZRJGH
    ,@XXZT
    ,@IsTop
    ,@TopSort
    ,@IsBest
    ,@YXSJRQ
    ,@FBRJGH
    ,@FBSJRQ
    ,@FBIP
    ,@LLCS
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0601ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0601ByAnyCondition]
GO

--表T_BG_0601任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0601ByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @FBH NVarChar(10) = NULL
        
, @FBHValue NVarChar(10) = NULL
, @FBHBatch nvarchar(1000) = NULL

, @BT NVarChar(100) = NULL
        
, @BTValue NVarChar(100) = NULL
, @BTBatch nvarchar(1000) = NULL

, @LanguageID NVarChar(2) = NULL
        
, @LanguageIDValue NVarChar(2) = NULL
, @LanguageIDBatch nvarchar(1000) = NULL

, @FBLM NVarChar(8) = NULL
        
, @FBLMValue NVarChar(8) = NULL
, @FBLMBatch nvarchar(1000) = NULL

, @FBBM NVarChar(50) = NULL
        
, @FBBMValue NVarChar(50) = NULL
, @FBBMBatch nvarchar(1000) = NULL

, @FBZT NVarChar(8) = NULL
        
, @FBZTValue NVarChar(8) = NULL
, @FBZTBatch nvarchar(1000) = NULL

, @XXLX NVarChar(2) = NULL
        
, @XXLXValue NVarChar(2) = NULL
, @XXLXBatch nvarchar(1000) = NULL

, @XXTPDZ NVarChar(255) = NULL
        
, @XXTPDZValue NVarChar(255) = NULL
, @XXTPDZBatch nvarchar(1000) = NULL

, @XXNR nvarchar(100) = NULL
        
, @XXNRValue NText = NULL
, @XXNRBatch nvarchar(1000) = NULL

, @FJXZDZ NVarChar(4000) = NULL
        
, @FJXZDZValue NVarChar(4000) = NULL
, @FJXZDZBatch nvarchar(1000) = NULL

, @PZRJGH NVarChar(10) = NULL
        
, @PZRJGHValue NVarChar(10) = NULL
, @PZRJGHBatch nvarchar(1000) = NULL

, @XXZT NVarChar(2) = NULL
        
, @XXZTValue NVarChar(2) = NULL
, @XXZTBatch nvarchar(1000) = NULL

, @IsTop NVarChar(1) = NULL
        
, @IsTopValue NVarChar(1) = NULL
, @IsTopBatch nvarchar(1000) = NULL

, @TopSort Int = NULL
        
, @TopSortValue Int = NULL
, @TopSortBatch nvarchar(1000) = NULL

, @IsBest NVarChar(1) = NULL
        
, @IsBestValue NVarChar(1) = NULL
, @IsBestBatch nvarchar(1000) = NULL

, @YXSJRQ DateTime = NULL
        
, @YXSJRQBegin DateTime = NULL
, @YXSJRQEnd DateTime = NULL
        
, @YXSJRQValue DateTime = NULL
, @YXSJRQBatch nvarchar(1000) = NULL

, @FBRJGH NVarChar(10) = NULL
        
, @FBRJGHValue NVarChar(10) = NULL
, @FBRJGHBatch nvarchar(1000) = NULL

, @FBSJRQ DateTime = NULL
        
, @FBSJRQBegin DateTime = NULL
, @FBSJRQEnd DateTime = NULL
        
, @FBSJRQValue DateTime = NULL
, @FBSJRQBatch nvarchar(1000) = NULL

, @FBIP NVarChar(20) = NULL
        
, @FBIPValue NVarChar(20) = NULL
, @FBIPBatch nvarchar(1000) = NULL

, @LLCS Int = NULL
        
, @LLCSValue Int = NULL
, @LLCSBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BG_0601].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].ObjectID)+''%'' '
    
    IF @FBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBH = '''+CAST(@FBH AS nvarchar(100))+''' '
            
    IF @FBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBH)+''%'' '
    
    IF @BT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].BT LIKE ''%'+CAST(@BT AS nvarchar(100))+'%'' '
            
    IF @BTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].BT)+''%'' '
    
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].LanguageID = '''+CAST(@LanguageID AS nvarchar(100))+''' '
            
    IF @LanguageIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LanguageIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].LanguageID)+''%'' '
    
    IF @FBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBLM LIKE ''%'+CAST(@FBLM AS nvarchar(100))+'%'' '
            
    IF @FBLMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBLMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBLM)+''%'' '
    
    IF @FBBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBBM = '''+CAST(@FBBM AS nvarchar(100))+''' '
            
    IF @FBBMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBBMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBBM)+''%'' '
    
    IF @FBZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBZT = '''+CAST(@FBZT AS nvarchar(100))+''' '
            
    IF @FBZTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBZTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBZT)+''%'' '
    
    IF @XXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].XXLX = '''+CAST(@XXLX AS nvarchar(100))+''' '
            
    IF @XXLXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XXLXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXLX)+''%'' '
    
    IF @XXTPDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].XXTPDZ = '''+CAST(@XXTPDZ AS nvarchar(100))+''' '
            
    IF @XXTPDZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XXTPDZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXTPDZ)+''%'' '
    
    IF @XXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].XXNR LIKE ''%'+CAST(@XXNR AS nvarchar(100))+'%'' '
            
    IF @XXNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XXNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXNR)+''%'' '
    
    IF @FJXZDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FJXZDZ = '''+CAST(@FJXZDZ AS nvarchar(100))+''' '
            
    IF @FJXZDZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FJXZDZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FJXZDZ)+''%'' '
    
    IF @PZRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].PZRJGH = '''+CAST(@PZRJGH AS nvarchar(100))+''' '
            
    IF @PZRJGHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PZRJGHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].PZRJGH)+''%'' '
    
    IF @XXZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].XXZT = '''+CAST(@XXZT AS nvarchar(100))+''' '
            
    IF @XXZTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XXZTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXZT)+''%'' '
    
    IF @IsTop IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].IsTop = '''+CAST(@IsTop AS nvarchar(100))+''' '
            
    IF @IsTopBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@IsTopBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].IsTop)+''%'' '
    
    IF @TopSort IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].TopSort = '''+CAST(@TopSort AS nvarchar(100))+''' '
            
    IF @TopSortBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@TopSortBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].TopSort)+''%'' '
    
    IF @IsBest IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].IsBest = '''+CAST(@IsBest AS nvarchar(100))+''' '
            
    IF @IsBestBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@IsBestBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].IsBest)+''%'' '
    
    IF @YXSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].YXSJRQ = '''+CAST(@YXSJRQ AS nvarchar(100))+''' '
    IF @YXSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].YXSJRQ >= '''+CAST(@YXSJRQBegin AS nvarchar(100))+''' '
    IF @YXSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].YXSJRQ <= '''+CAST(@YXSJRQEnd AS nvarchar(100))+''' '
        
    IF @YXSJRQBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YXSJRQBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].YXSJRQ)+''%'' '
    
    IF @FBRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBRJGH = '''+CAST(@FBRJGH AS nvarchar(100))+''' '
            
    IF @FBRJGHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBRJGHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBRJGH)+''%'' '
    
    IF @FBSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBSJRQ = '''+CAST(@FBSJRQ AS nvarchar(100))+''' '
    IF @FBSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBSJRQ >= '''+CAST(@FBSJRQBegin AS nvarchar(100))+''' '
    IF @FBSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBSJRQ <= '''+CAST(@FBSJRQEnd AS nvarchar(100))+''' '
        
    IF @FBSJRQBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBSJRQBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBSJRQ)+''%'' '
    
    IF @FBIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].FBIP = '''+CAST(@FBIP AS nvarchar(100))+''' '
            
    IF @FBIPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FBIPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBIP)+''%'' '
    
    IF @LLCS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].LLCS = '''+CAST(@LLCS AS nvarchar(100))+''' '
            
    IF @LLCSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LLCSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].LLCS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BG_0601].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].ObjectID)+''%'' '
    
    IF @FBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBH LIKE '''+CAST(@FBH AS nvarchar(100))+'%'' '
        
    IF @FBHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBH)+''%'' '
    
    IF @BT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].BT LIKE '''+CAST(@BT AS nvarchar(100))+'%'' '
        
    IF @BTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].BT)+''%'' '
    
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].LanguageID LIKE '''+CAST(@LanguageID AS nvarchar(100))+'%'' '
        
    IF @LanguageIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LanguageIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].LanguageID)+''%'' '
    
    IF @FBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBLM LIKE '''+CAST(@FBLM AS nvarchar(100))+'%'' '
        
    IF @FBLMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBLMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBLM)+''%'' '
    
    IF @FBBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBBM LIKE '''+CAST(@FBBM AS nvarchar(100))+'%'' '
        
    IF @FBBMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBBMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBBM)+''%'' '
    
    IF @FBZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBZT LIKE '''+CAST(@FBZT AS nvarchar(100))+'%'' '
        
    IF @FBZTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBZTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBZT)+''%'' '
    
    IF @XXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].XXLX LIKE '''+CAST(@XXLX AS nvarchar(100))+'%'' '
        
    IF @XXLXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XXLXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXLX)+''%'' '
    
    IF @XXTPDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].XXTPDZ LIKE '''+CAST(@XXTPDZ AS nvarchar(100))+'%'' '
        
    IF @XXTPDZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XXTPDZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXTPDZ)+''%'' '
    
    IF @XXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].XXNR LIKE '''+CAST(@XXNR AS nvarchar(100))+'%'' '
        
    IF @XXNRBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XXNRBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXNR)+''%'' '
    
    IF @FJXZDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FJXZDZ LIKE '''+CAST(@FJXZDZ AS nvarchar(100))+'%'' '
        
    IF @FJXZDZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FJXZDZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FJXZDZ)+''%'' '
    
    IF @PZRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].PZRJGH LIKE '''+CAST(@PZRJGH AS nvarchar(100))+'%'' '
        
    IF @PZRJGHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PZRJGHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].PZRJGH)+''%'' '
    
    IF @XXZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].XXZT LIKE '''+CAST(@XXZT AS nvarchar(100))+'%'' '
        
    IF @XXZTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XXZTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].XXZT)+''%'' '
    
    IF @IsTop IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].IsTop LIKE '''+CAST(@IsTop AS nvarchar(100))+'%'' '
        
    IF @IsTopBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@IsTopBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].IsTop)+''%'' '
    
    IF @TopSort IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].TopSort LIKE '''+CAST(@TopSort AS nvarchar(100))+'%'' '
        
    IF @TopSortBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@TopSortBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].TopSort)+''%'' '
    
    IF @IsBest IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].IsBest LIKE '''+CAST(@IsBest AS nvarchar(100))+'%'' '
        
    IF @IsBestBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@IsBestBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].IsBest)+''%'' '
    
    IF @YXSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].YXSJRQ = '''+CAST(@YXSJRQ AS nvarchar(100))+''' '
    IF @YXSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].YXSJRQ >= '''+CAST(@YXSJRQBegin AS nvarchar(100))+''' '
    IF @YXSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].YXSJRQ <= '''+CAST(@YXSJRQEnd AS nvarchar(100))+''' '
        
    IF @YXSJRQBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YXSJRQBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].YXSJRQ)+''%'' '
    
    IF @FBRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBRJGH LIKE '''+CAST(@FBRJGH AS nvarchar(100))+'%'' '
        
    IF @FBRJGHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBRJGHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBRJGH)+''%'' '
    
    IF @FBSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBSJRQ = '''+CAST(@FBSJRQ AS nvarchar(100))+''' '
    IF @FBSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBSJRQ >= '''+CAST(@FBSJRQBegin AS nvarchar(100))+''' '
    IF @FBSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBSJRQ <= '''+CAST(@FBSJRQEnd AS nvarchar(100))+''' '
        
    IF @FBSJRQBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBSJRQBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBSJRQ)+''%'' '
    
    IF @FBIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].FBIP LIKE '''+CAST(@FBIP AS nvarchar(100))+'%'' '
        
    IF @FBIPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FBIPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].FBIP)+''%'' '
    
    IF @LLCS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].LLCS LIKE '''+CAST(@LLCS AS nvarchar(100))+'%'' '
        
    IF @LLCSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LLCSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BG_0601].LLCS)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_BG_0601] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_BG_0601] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_BG_0601].ObjectID'
  
    IF @FBHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBH = @FBHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBH = [DB_MGZZX].[dbo].[T_BG_0601].FBH'
  
    IF @BTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BT = @BTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BT = [DB_MGZZX].[dbo].[T_BG_0601].BT'
  
    IF @LanguageIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LanguageID = @LanguageIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LanguageID = [DB_MGZZX].[dbo].[T_BG_0601].LanguageID'
  
    IF @FBLMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBLM = @FBLMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBLM = [DB_MGZZX].[dbo].[T_BG_0601].FBLM'
  
    IF @FBBMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBBM = @FBBMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBBM = [DB_MGZZX].[dbo].[T_BG_0601].FBBM'
  
    IF @FBZTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBZT = @FBZTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBZT = [DB_MGZZX].[dbo].[T_BG_0601].FBZT'
  
    IF @XXLXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XXLX = @XXLXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XXLX = [DB_MGZZX].[dbo].[T_BG_0601].XXLX'
  
    IF @XXTPDZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XXTPDZ = @XXTPDZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XXTPDZ = [DB_MGZZX].[dbo].[T_BG_0601].XXTPDZ'
  
    IF @XXNRValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XXNR = @XXNRValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XXNR = [DB_MGZZX].[dbo].[T_BG_0601].XXNR'
  
    IF @FJXZDZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FJXZDZ = @FJXZDZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FJXZDZ = [DB_MGZZX].[dbo].[T_BG_0601].FJXZDZ'
  
    IF @PZRJGHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,PZRJGH = @PZRJGHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,PZRJGH = [DB_MGZZX].[dbo].[T_BG_0601].PZRJGH'
  
    IF @XXZTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XXZT = @XXZTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XXZT = [DB_MGZZX].[dbo].[T_BG_0601].XXZT'
  
    IF @IsTopValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,IsTop = @IsTopValue'
    ELSE
        SET @SqlText = @SqlText + ' ,IsTop = [DB_MGZZX].[dbo].[T_BG_0601].IsTop'
  
    IF @TopSortValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,TopSort = @TopSortValue'
    ELSE
        SET @SqlText = @SqlText + ' ,TopSort = [DB_MGZZX].[dbo].[T_BG_0601].TopSort'
  
    IF @IsBestValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,IsBest = @IsBestValue'
    ELSE
        SET @SqlText = @SqlText + ' ,IsBest = [DB_MGZZX].[dbo].[T_BG_0601].IsBest'
  
    IF @YXSJRQValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YXSJRQ = @YXSJRQValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YXSJRQ = [DB_MGZZX].[dbo].[T_BG_0601].YXSJRQ'
  
    IF @FBRJGHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBRJGH = @FBRJGHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBRJGH = [DB_MGZZX].[dbo].[T_BG_0601].FBRJGH'
  
    IF @FBSJRQValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBSJRQ = @FBSJRQValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBSJRQ = [DB_MGZZX].[dbo].[T_BG_0601].FBSJRQ'
  
    IF @FBIPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FBIP = @FBIPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FBIP = [DB_MGZZX].[dbo].[T_BG_0601].FBIP'
  
    IF @LLCSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LLCS = @LLCSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LLCS = [DB_MGZZX].[dbo].[T_BG_0601].LLCS'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_BG_0601] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0601ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0601ByObjectID]
GO

--表T_BG_0601以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0601ByObjectID] 

@ObjectID nvarchar(50) = NULL
,@FBH NVarChar(10) = NULL
,@BT NVarChar(100) = NULL
,@LanguageID NVarChar(2) = NULL
,@FBLM NVarChar(8) = NULL
,@FBBM NVarChar(50) = NULL
,@FBZT NVarChar(8) = NULL
,@XXLX NVarChar(2) = NULL
,@XXTPDZ NVarChar(255) = NULL
,@XXNR NText = NULL
,@FJXZDZ NVarChar(4000) = NULL
,@PZRJGH NVarChar(10) = NULL
,@XXZT NVarChar(2) = NULL
,@IsTop NVarChar(1) = NULL
,@TopSort Int = NULL
,@IsBest NVarChar(1) = NULL
,@YXSJRQ DateTime = NULL
,@FBRJGH NVarChar(10) = NULL
,@FBSJRQ DateTime = NULL
,@FBIP NVarChar(20) = NULL
,@LLCS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BG_0601]
    SET 
    
    [ObjectID] = @ObjectID
    , [FBH] = @FBH
    , [BT] = @BT
    , [LanguageID] = @LanguageID
    , [FBLM] = @FBLM
    , [FBBM] = @FBBM
    , [FBZT] = @FBZT
    , [XXLX] = @XXLX
    , [XXTPDZ] = @XXTPDZ
    , [XXNR] = @XXNR
    , [FJXZDZ] = @FJXZDZ
    , [PZRJGH] = @PZRJGH
    , [XXZT] = @XXZT
    , [IsTop] = @IsTop
    , [TopSort] = @TopSort
    , [IsBest] = @IsBest
    , [YXSJRQ] = @YXSJRQ
    , [FBRJGH] = @FBRJGH
    , [FBSJRQ] = @FBSJRQ
    , [FBIP] = @FBIP
    , [LLCS] = @LLCS
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0601ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0601ByKey]
GO

--表T_BG_0601以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0601ByKey] 

@ObjectID nvarchar(50) = NULL
,@FBH NVarChar(10) = NULL
,@BT NVarChar(100) = NULL
,@LanguageID NVarChar(2) = NULL
,@FBLM NVarChar(8) = NULL
,@FBBM NVarChar(50) = NULL
,@FBZT NVarChar(8) = NULL
,@XXLX NVarChar(2) = NULL
,@XXTPDZ NVarChar(255) = NULL
,@XXNR NText = NULL
,@FJXZDZ NVarChar(4000) = NULL
,@PZRJGH NVarChar(10) = NULL
,@XXZT NVarChar(2) = NULL
,@IsTop NVarChar(1) = NULL
,@TopSort Int = NULL
,@IsBest NVarChar(1) = NULL
,@YXSJRQ DateTime = NULL
,@FBRJGH NVarChar(10) = NULL
,@FBSJRQ DateTime = NULL
,@FBIP NVarChar(20) = NULL
,@LLCS Int = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBH] = @FBH
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @BT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [BT] = @BT
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @LanguageID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [LanguageID] = @LanguageID
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBLM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBLM] = @FBLM
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBBM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBBM] = @FBBM
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBZT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBZT] = @FBZT
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @XXLX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXLX] = @XXLX
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @XXTPDZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXTPDZ] = @XXTPDZ
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @XXNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXNR] = @XXNR
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FJXZDZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FJXZDZ] = @FJXZDZ
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @PZRJGH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [PZRJGH] = @PZRJGH
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @XXZT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXZT] = @XXZT
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @IsTop IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [IsTop] = @IsTop
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @TopSort IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [TopSort] = @TopSort
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @IsBest IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [IsBest] = @IsBest
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @YXSJRQ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [YXSJRQ] = @YXSJRQ
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBRJGH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBRJGH] = @FBRJGH
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBSJRQ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBSJRQ] = @FBSJRQ
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @FBIP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBIP] = @FBIP
        WHERE
        
        [FBH] = @FBH
    END
    
    IF @LLCS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [LLCS] = @LLCS
        WHERE
        
        [FBH] = @FBH
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0601ByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0601ByObjectIDBatch]
GO

--表T_BG_0601以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BG_0601ByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@FBH NVarChar(10) = NULL

,@BT NVarChar(100) = NULL

,@LanguageID NVarChar(2) = NULL

,@FBLM NVarChar(8) = NULL

,@FBBM NVarChar(50) = NULL

,@FBZT NVarChar(8) = NULL

,@XXLX NVarChar(2) = NULL

,@XXTPDZ NVarChar(255) = NULL

,@XXNR NText = NULL

,@FJXZDZ NVarChar(4000) = NULL

,@PZRJGH NVarChar(10) = NULL

,@XXZT NVarChar(2) = NULL

,@IsTop NVarChar(1) = NULL

,@TopSort Int = NULL

,@IsBest NVarChar(1) = NULL

,@YXSJRQ DateTime = NULL

,@FBRJGH NVarChar(10) = NULL

,@FBSJRQ DateTime = NULL

,@FBIP NVarChar(20) = NULL

,@LLCS Int = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBH] = @FBH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [BT] = @BT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LanguageID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [LanguageID] = @LanguageID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBLM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBLM] = @FBLM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBBM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBBM] = @FBBM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBZT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBZT] = @FBZT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XXLX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXLX] = @XXLX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XXTPDZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXTPDZ] = @XXTPDZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XXNR IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXNR] = @XXNR WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FJXZDZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FJXZDZ] = @FJXZDZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @PZRJGH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [PZRJGH] = @PZRJGH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XXZT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [XXZT] = @XXZT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @IsTop IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [IsTop] = @IsTop WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @TopSort IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [TopSort] = @TopSort WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @IsBest IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [IsBest] = @IsBest WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YXSJRQ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [YXSJRQ] = @YXSJRQ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBRJGH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBRJGH] = @FBRJGH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBSJRQ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBSJRQ] = @FBSJRQ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FBIP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [FBIP] = @FBIP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LLCS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BG_0601]
        SET [LLCS] = @LLCS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BG_0601ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BG_0601ByObjectID]
GO

--表T_BG_0601以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0601ByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BG_0601]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BG_0601ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BG_0601ByKey]
GO

--表T_BG_0601以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0601ByKey] 

@FBH NVarChar(10) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BG_0601]
WHERE

[FBH] = @FBH
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BG_0601ByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BG_0601ByObjectIDBatch]
GO

--表T_BG_0601以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0601ByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BG_0601]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0601ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0601ByAnyCondition]
GO

--表T_BG_0601任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0601ByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @FBH NVarChar(10) = NULL
        
, @FBHBatch nvarchar(4000) = NULL

, @BT NVarChar(100) = NULL
        
, @BTBatch nvarchar(4000) = NULL

, @LanguageID NVarChar(2) = NULL
        
, @LanguageIDBatch nvarchar(4000) = NULL

, @FBLM NVarChar(8) = NULL
        
, @FBLMBatch nvarchar(4000) = NULL

, @FBBM NVarChar(50) = NULL
        
, @FBBMBatch nvarchar(4000) = NULL

, @FBZT NVarChar(8) = NULL
        
, @FBZTBatch nvarchar(4000) = NULL

, @XXLX NVarChar(2) = NULL
        
, @XXLXBatch nvarchar(4000) = NULL

, @XXTPDZ NVarChar(255) = NULL
        
, @XXTPDZBatch nvarchar(4000) = NULL

, @XXNR nvarchar(100) = NULL
        
, @XXNRBatch nvarchar(4000) = NULL

, @FJXZDZ NVarChar(4000) = NULL
        
, @FJXZDZBatch nvarchar(4000) = NULL

, @PZRJGH NVarChar(10) = NULL
        
, @PZRJGHBatch nvarchar(4000) = NULL

, @XXZT NVarChar(2) = NULL
        
, @XXZTBatch nvarchar(4000) = NULL

, @IsTop NVarChar(1) = NULL
        
, @IsTopBatch nvarchar(4000) = NULL

, @TopSort Int = NULL
        
, @TopSortBatch nvarchar(4000) = NULL

, @IsBest NVarChar(1) = NULL
        
, @IsBestBatch nvarchar(4000) = NULL

, @YXSJRQ DateTime = NULL
        
, @YXSJRQBatch nvarchar(4000) = NULL

, @FBRJGH NVarChar(10) = NULL
        
, @FBRJGHBatch nvarchar(4000) = NULL

, @FBSJRQ DateTime = NULL
        
, @FBSJRQBegin DateTime = NULL
, @FBSJRQEnd DateTime = NULL
        
, @FBSJRQBatch nvarchar(4000) = NULL

, @FBIP NVarChar(20) = NULL
        
, @FBIPBatch nvarchar(4000) = NULL

, @LLCS Int = NULL
        
, @LLCSBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'FBH'
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
    SET @SortField = 'FBH'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BG_0601].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BG_0601].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @FBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBH] = '''+CAST(@FBH AS nvarchar(100))+''' '
            
    IF @BT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[BT] LIKE ''%'+CAST(@BT AS nvarchar(100))+'%'' '
            
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[LanguageID] = '''+CAST(@LanguageID AS nvarchar(100))+''' '
            
    IF @FBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBLM] LIKE ''%'+CAST(@FBLM AS nvarchar(100))+'%'' '
            
    IF @FBBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBBM] = '''+CAST(@FBBM AS nvarchar(100))+''' '
            
    IF @FBZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBZT] = '''+CAST(@FBZT AS nvarchar(100))+''' '
            
    IF @XXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[XXLX] = '''+CAST(@XXLX AS nvarchar(100))+''' '
            
    IF @XXTPDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[XXTPDZ] = '''+CAST(@XXTPDZ AS nvarchar(100))+''' '
            
    IF @XXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[XXNR] LIKE ''%'+CAST(@XXNR AS nvarchar(100))+'%'' '
            
    IF @FJXZDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FJXZDZ] = '''+CAST(@FJXZDZ AS nvarchar(100))+''' '
            
    IF @PZRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[PZRJGH] = '''+CAST(@PZRJGH AS nvarchar(100))+''' '
            
    IF @XXZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[XXZT] = '''+CAST(@XXZT AS nvarchar(100))+''' '
            
    IF @IsTop IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[IsTop] = '''+CAST(@IsTop AS nvarchar(100))+''' '
            
    IF @TopSort IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[TopSort] = '''+CAST(@TopSort AS nvarchar(100))+''' '
            
    IF @IsBest IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[IsBest] = '''+CAST(@IsBest AS nvarchar(100))+''' '
            
    IF @YXSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[YXSJRQ] = '''+CAST(@YXSJRQ AS nvarchar(100))+''' '
            
    IF @FBRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBRJGH] = '''+CAST(@FBRJGH AS nvarchar(100))+''' '
            
    IF @FBSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBSJRQ] = '''+CAST(@FBSJRQ AS nvarchar(100))+''' '
            
    IF @FBSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBSJRQ] >= '''+CAST(@FBSJRQBegin AS nvarchar(100))+''' '
    IF @FBSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBSJRQ] <= '''+CAST(@FBSJRQEnd AS nvarchar(100))+''' '
        
    IF @FBIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[FBIP] = '''+CAST(@FBIP AS nvarchar(100))+''' '
            
    IF @LLCS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BG_0601].[LLCS] = '''+CAST(@LLCS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BG_0601].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @FBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBH] = '''+CAST(@FBH AS nvarchar(100))+''' '
            
    IF @BT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[BT] LIKE ''%'+CAST(@BT AS nvarchar(100))+'%'' '
            
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[LanguageID] = '''+CAST(@LanguageID AS nvarchar(100))+''' '
            
    IF @FBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBLM] LIKE ''%'+CAST(@FBLM AS nvarchar(100))+'%'' '
            
    IF @FBBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBBM] = '''+CAST(@FBBM AS nvarchar(100))+''' '
            
    IF @FBZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBZT] = '''+CAST(@FBZT AS nvarchar(100))+''' '
            
    IF @XXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXLX] = '''+CAST(@XXLX AS nvarchar(100))+''' '
            
    IF @XXTPDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXTPDZ] = '''+CAST(@XXTPDZ AS nvarchar(100))+''' '
            
    IF @XXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXNR] LIKE ''%'+CAST(@XXNR AS nvarchar(100))+'%'' '
            
    IF @FJXZDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FJXZDZ] = '''+CAST(@FJXZDZ AS nvarchar(100))+''' '
            
    IF @PZRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[PZRJGH] = '''+CAST(@PZRJGH AS nvarchar(100))+''' '
            
    IF @XXZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXZT] = '''+CAST(@XXZT AS nvarchar(100))+''' '
            
    IF @IsTop IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[IsTop] = '''+CAST(@IsTop AS nvarchar(100))+''' '
            
    IF @TopSort IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[TopSort] = '''+CAST(@TopSort AS nvarchar(100))+''' '
            
    IF @IsBest IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[IsBest] = '''+CAST(@IsBest AS nvarchar(100))+''' '
            
    IF @YXSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[YXSJRQ] = '''+CAST(@YXSJRQ AS nvarchar(100))+''' '
            
    IF @FBRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBRJGH] = '''+CAST(@FBRJGH AS nvarchar(100))+''' '
            
    IF @FBSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBSJRQ] = '''+CAST(@FBSJRQ AS nvarchar(100))+''' '
            
    IF @FBSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBSJRQ] >= '''+CAST(@FBSJRQBegin AS nvarchar(100))+''' '
    IF @FBSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBSJRQ] <= '''+CAST(@FBSJRQEnd AS nvarchar(100))+''' '
        
    IF @FBIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBIP] = '''+CAST(@FBIP AS nvarchar(100))+''' '
            
    IF @LLCS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[LLCS] = '''+CAST(@LLCS AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BG_0601].[ObjectID]
        
      , [dbo].[T_BG_0601].[FBH]
        
      , [dbo].[T_BG_0601].[BT]
        
      , [dbo].[T_BG_0601].[LanguageID]
        
      , [dbo].[T_BG_0601].[FBLM]
        
      , [dbo].[T_BG_0601].[FBBM]
        
      , [dbo].[T_BG_0601].[FBZT]
        
      , [dbo].[T_BG_0601].[XXLX]
        
      , [dbo].[T_BG_0601].[XXTPDZ]
        
      , [dbo].[T_BG_0601].[FJXZDZ]
        
      , [dbo].[T_BG_0601].[PZRJGH]
        
      , [dbo].[T_BG_0601].[XXZT]
        
      , [dbo].[T_BG_0601].[IsTop]
        
      , [dbo].[T_BG_0601].[TopSort]
        
      , [dbo].[T_BG_0601].[IsBest]
        
      , [dbo].[T_BG_0601].[YXSJRQ]
        
      , [dbo].[T_BG_0601].[FBRJGH]
        
      , [dbo].[T_BG_0601].[FBSJRQ]
        
      , [dbo].[T_BG_0601].[FBIP]
        
      , [dbo].[T_BG_0601].[LLCS]
        
        ,[FBLM_T_BG_0602].[LMM] AS [FBLM_T_BG_0602_LMM]
        ,[FBBM_T_BM_DWXX].[DWMC] AS [FBBM_T_BM_DWXX_DWMC]
        ,[XXLX_Dictionary].[MC] AS [XXLX_Dictionary_MC]
        ,[XXZT_Dictionary].[MC] AS [XXZT_Dictionary_MC]
        ,[IsTop_Dictionary].[MC] AS [IsTop_Dictionary_MC]
        ,[IsBest_Dictionary].[MC] AS [IsBest_Dictionary_MC]
        ,[FBRJGH_T_PM_UserInfo].[UserNickName] AS [FBRJGH_T_PM_UserInfo_UserNickName]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[FBLM_T_BG_0602].[LMM] AS [FBLM_T_BG_0602_LMM]
        ,[FBBM_T_BM_DWXX].[DWMC] AS [FBBM_T_BM_DWXX_DWMC]
        ,[XXLX_Dictionary].[MC] AS [XXLX_Dictionary_MC]
        ,[XXZT_Dictionary].[MC] AS [XXZT_Dictionary_MC]
        ,[IsTop_Dictionary].[MC] AS [IsTop_Dictionary_MC]
        ,[IsBest_Dictionary].[MC] AS [IsBest_Dictionary_MC]
        ,[FBRJGH_T_PM_UserInfo].[UserNickName] AS [FBRJGH_T_PM_UserInfo_UserNickName]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_BG_0601]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BG_0602] AS FBLM_T_BG_0602 ON FBLM_T_BG_0602.[LMH] = [dbo].[T_BG_0601].[FBLM] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS FBBM_T_BM_DWXX ON FBBM_T_BM_DWXX.[DWBH] = [dbo].[T_BG_0601].[FBBM] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS XXLX_Dictionary ON XXLX_Dictionary.[DM] = [dbo].[T_BG_0601].[XXLX]  AND XXLX_Dictionary.[LX] = ''0101''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS XXZT_Dictionary ON XXZT_Dictionary.[DM] = [dbo].[T_BG_0601].[XXZT]  AND XXZT_Dictionary.[LX] = ''0102''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS IsTop_Dictionary ON IsTop_Dictionary.[DM] = [dbo].[T_BG_0601].[IsTop]  AND IsTop_Dictionary.[LX] = ''0004''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS IsBest_Dictionary ON IsBest_Dictionary.[DM] = [dbo].[T_BG_0601].[IsBest]  AND IsBest_Dictionary.[LX] = ''0004''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS FBRJGH_T_PM_UserInfo ON FBRJGH_T_PM_UserInfo.[UserID] = [dbo].[T_BG_0601].[FBRJGH] 
'
	
--多项查询

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_ObjectID_Batch ON '','' + [dbo].[T_BG_0601].[ObjectID] + '','' LIKE ''%,'' + T_BG_0601_ObjectID_Batch.col +'',%''
'
    
IF @FBHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBHBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBH_Batch ON '','' + [dbo].[T_BG_0601].[FBH] + '','' LIKE ''%,'' + T_BG_0601_FBH_Batch.col +'',%''
'
    
IF @BTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BTBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_BT_Batch ON '','' + [dbo].[T_BG_0601].[BT] + '','' LIKE ''%,'' + T_BG_0601_BT_Batch.col +'',%''
'
    
IF @LanguageIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LanguageIDBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_LanguageID_Batch ON '','' + [dbo].[T_BG_0601].[LanguageID] + '','' LIKE ''%,'' + T_BG_0601_LanguageID_Batch.col +'',%''
'
    
IF @FBLMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBLMBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBLM_Batch ON '','' + [dbo].[T_BG_0601].[FBLM] + '','' LIKE ''%,'' + T_BG_0601_FBLM_Batch.col +'',%''
'
    
IF @FBBMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBBMBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBBM_Batch ON '','' + [dbo].[T_BG_0601].[FBBM] + '','' LIKE ''%,'' + T_BG_0601_FBBM_Batch.col +'',%''
'
    
IF @FBZTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBZTBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBZT_Batch ON '','' + [dbo].[T_BG_0601].[FBZT] + '','' LIKE ''%,'' + T_BG_0601_FBZT_Batch.col +'',%''
'
    
IF @XXLXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XXLXBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_XXLX_Batch ON '','' + [dbo].[T_BG_0601].[XXLX] + '','' LIKE ''%,'' + T_BG_0601_XXLX_Batch.col +'',%''
'
    
IF @XXTPDZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XXTPDZBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_XXTPDZ_Batch ON '','' + [dbo].[T_BG_0601].[XXTPDZ] + '','' LIKE ''%,'' + T_BG_0601_XXTPDZ_Batch.col +'',%''
'
    
IF @FJXZDZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FJXZDZBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FJXZDZ_Batch ON '','' + [dbo].[T_BG_0601].[FJXZDZ] + '','' LIKE ''%,'' + T_BG_0601_FJXZDZ_Batch.col +'',%''
'
    
IF @PZRJGHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PZRJGHBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_PZRJGH_Batch ON '','' + [dbo].[T_BG_0601].[PZRJGH] + '','' LIKE ''%,'' + T_BG_0601_PZRJGH_Batch.col +'',%''
'
    
IF @XXZTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XXZTBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_XXZT_Batch ON '','' + [dbo].[T_BG_0601].[XXZT] + '','' LIKE ''%,'' + T_BG_0601_XXZT_Batch.col +'',%''
'
    
IF @IsTopBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@IsTopBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_IsTop_Batch ON '','' + [dbo].[T_BG_0601].[IsTop] + '','' LIKE ''%,'' + T_BG_0601_IsTop_Batch.col +'',%''
'
    
IF @TopSortBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@TopSortBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_TopSort_Batch ON '','' + [dbo].[T_BG_0601].[TopSort] + '','' LIKE ''%,'' + T_BG_0601_TopSort_Batch.col +'',%''
'
    
IF @IsBestBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@IsBestBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_IsBest_Batch ON '','' + [dbo].[T_BG_0601].[IsBest] + '','' LIKE ''%,'' + T_BG_0601_IsBest_Batch.col +'',%''
'
    
IF @YXSJRQBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YXSJRQBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_YXSJRQ_Batch ON '','' + [dbo].[T_BG_0601].[YXSJRQ] + '','' LIKE ''%,'' + T_BG_0601_YXSJRQ_Batch.col +'',%''
'
    
IF @FBRJGHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBRJGHBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBRJGH_Batch ON '','' + [dbo].[T_BG_0601].[FBRJGH] + '','' LIKE ''%,'' + T_BG_0601_FBRJGH_Batch.col +'',%''
'
    
IF @FBSJRQBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBSJRQBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBSJRQ_Batch ON '','' + [dbo].[T_BG_0601].[FBSJRQ] + '','' LIKE ''%,'' + T_BG_0601_FBSJRQ_Batch.col +'',%''
'
    
IF @FBIPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FBIPBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_FBIP_Batch ON '','' + [dbo].[T_BG_0601].[FBIP] + '','' LIKE ''%,'' + T_BG_0601_FBIP_Batch.col +'',%''
'
    
IF @LLCSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LLCSBatch AS nvarchar(4000))+''', '','') AS T_BG_0601_LLCS_Batch ON '','' + [dbo].[T_BG_0601].[LLCS] + '','' LIKE ''%,'' + T_BG_0601_LLCS_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BG_0601].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BG_0601].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0601ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0601ByObjectID]
GO

--表T_BG_0601以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0601ByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BG_0601].[ObjectID]
    
      , [dbo].[T_BG_0601].[FBH]
    
      , [dbo].[T_BG_0601].[BT]
    
      , [dbo].[T_BG_0601].[LanguageID]
    
      , [dbo].[T_BG_0601].[FBLM]
    
      , [dbo].[T_BG_0601].[FBBM]
    
      , [dbo].[T_BG_0601].[FBZT]
    
      , [dbo].[T_BG_0601].[XXLX]
    
      , [dbo].[T_BG_0601].[XXTPDZ]
    
      , [dbo].[T_BG_0601].[XXNR]
    
      , [dbo].[T_BG_0601].[FJXZDZ]
    
      , [dbo].[T_BG_0601].[PZRJGH]
    
      , [dbo].[T_BG_0601].[XXZT]
    
      , [dbo].[T_BG_0601].[IsTop]
    
      , [dbo].[T_BG_0601].[TopSort]
    
      , [dbo].[T_BG_0601].[IsBest]
    
      , [dbo].[T_BG_0601].[YXSJRQ]
    
      , [dbo].[T_BG_0601].[FBRJGH]
    
      , [dbo].[T_BG_0601].[FBSJRQ]
    
      , [dbo].[T_BG_0601].[FBIP]
    
      , [dbo].[T_BG_0601].[LLCS]
    
        ,[FBLM_T_BG_0602].[LMM] AS [FBLM_T_BG_0602_LMM]
        ,[FBBM_T_BM_DWXX].[DWMC] AS [FBBM_T_BM_DWXX_DWMC]
        ,[XXLX_Dictionary].[MC] AS [XXLX_Dictionary_MC]
        ,[XXZT_Dictionary].[MC] AS [XXZT_Dictionary_MC]
        ,[IsTop_Dictionary].[MC] AS [IsTop_Dictionary_MC]
        ,[IsBest_Dictionary].[MC] AS [IsBest_Dictionary_MC]
        ,[FBRJGH_T_PM_UserInfo].[UserNickName] AS [FBRJGH_T_PM_UserInfo_UserNickName]
FROM [dbo].[T_BG_0601]

    LEFT JOIN [dbo].[T_BG_0602] AS FBLM_T_BG_0602 ON FBLM_T_BG_0602.[LMH] = [dbo].[T_BG_0601].[FBLM] 
    LEFT JOIN [dbo].[T_BM_DWXX] AS FBBM_T_BM_DWXX ON FBBM_T_BM_DWXX.[DWBH] = [dbo].[T_BG_0601].[FBBM] 
    LEFT JOIN [dbo].[Dictionary] AS XXLX_Dictionary ON XXLX_Dictionary.[DM] = [dbo].[T_BG_0601].[XXLX]  AND XXLX_Dictionary.[LX] = '0101'
    LEFT JOIN [dbo].[Dictionary] AS XXZT_Dictionary ON XXZT_Dictionary.[DM] = [dbo].[T_BG_0601].[XXZT]  AND XXZT_Dictionary.[LX] = '0102'
    LEFT JOIN [dbo].[Dictionary] AS IsTop_Dictionary ON IsTop_Dictionary.[DM] = [dbo].[T_BG_0601].[IsTop]  AND IsTop_Dictionary.[LX] = '0004'
    LEFT JOIN [dbo].[Dictionary] AS IsBest_Dictionary ON IsBest_Dictionary.[DM] = [dbo].[T_BG_0601].[IsBest]  AND IsBest_Dictionary.[LX] = '0004'
    LEFT JOIN [dbo].[T_PM_UserInfo] AS FBRJGH_T_PM_UserInfo ON FBRJGH_T_PM_UserInfo.[UserID] = [dbo].[T_BG_0601].[FBRJGH] 
WHERE
[dbo].[T_BG_0601].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0601ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0601ByKey]
GO

--表T_BG_0601以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0601ByKey] 

@FBH NVarChar(10) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [FBH]
    
      , [BT]
    
      , [LanguageID]
    
      , [FBLM]
    
      , [FBBM]
    
      , [FBZT]
    
      , [XXLX]
    
      , [XXTPDZ]
    
      , [XXNR]
    
      , [FJXZDZ]
    
      , [PZRJGH]
    
      , [XXZT]
    
      , [IsTop]
    
      , [TopSort]
    
      , [IsBest]
    
      , [YXSJRQ]
    
      , [FBRJGH]
    
      , [FBSJRQ]
    
      , [FBIP]
    
      , [LLCS]
    
FROM [dbo].[T_BG_0601]
WHERE

[FBH] = @FBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BG_0601ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BG_0601ByObjectID]
GO

--表[T_BG_0601]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BG_0601ByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BG_0601]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BG_0601ByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BG_0601ByKey]
GO

--表[T_BG_0601]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BG_0601ByKey] 

@FBH NVarChar(10) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BG_0601]
WHERE 

[FBH] = @FBH

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BG_0601ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BG_0601ByAnyCondition]
GO

--表T_BG_0601任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BG_0601ByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BG_0601].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_BG_0601]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BG_0602] AS [FBLM_T_BG_0602] ON [FBLM_T_BG_0602].[LMH] = [dbo].[T_BG_0601].[FBLM]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS [FBBM_T_BM_DWXX] ON [FBBM_T_BM_DWXX].[DWBH] = [dbo].[T_BG_0601].[FBBM]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [XXLX_Dictionary] ON [XXLX_Dictionary].[DM] = [dbo].[T_BG_0601].[XXLX]  AND XXLX_Dictionary.[LX] = ''0101'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [XXZT_Dictionary] ON [XXZT_Dictionary].[DM] = [dbo].[T_BG_0601].[XXZT]  AND XXZT_Dictionary.[LX] = ''0102'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [IsTop_Dictionary] ON [IsTop_Dictionary].[DM] = [dbo].[T_BG_0601].[IsTop]  AND IsTop_Dictionary.[LX] = ''0004'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [IsBest_Dictionary] ON [IsBest_Dictionary].[DM] = [dbo].[T_BG_0601].[IsBest]  AND IsBest_Dictionary.[LX] = ''0004'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [FBRJGH_T_PM_UserInfo] ON [FBRJGH_T_PM_UserInfo].[UserID] = [dbo].[T_BG_0601].[FBRJGH]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BG_0601ByFBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BG_0601ByFBH]
GO

--表T_BG_0601以FBH为条件得最大值的存储过程

CREATE   PROCEDURE [dbo].[SP_GetMaxT_BG_0601ByFBH] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(FBH, LEN(@Prefix) + @Number))
FROM [dbo].[T_BG_0601]
WHERE
FBH LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BG_0601_FBLM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BG_0601_FBLM]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BG_0601_FBLM] 
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
    [FBLM] AS ParentID
FROM [dbo].[T_BG_0601] 
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_BG_0601_FBBM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_BG_0601_FBBM]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_BG_0601_FBBM] 
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
    [FBBM] AS ParentID
FROM [dbo].[T_BG_0601] 
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

