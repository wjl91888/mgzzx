if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_GZXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_GZXX]
GO

--表T_BM_GZXX插入的存储过程

CREATE   PROCEDURE [dbo].[SP_InsertT_BM_GZXX] 

@ObjectID UniqueIdentifier   = NULL
,@XM NVarChar (50)
,@XB NVarChar (2)  = NULL
,@SFZH NVarChar (18)
,@FFGZNY NVarChar (6)
,@JCGZ Float   = NULL
,@JSDJGZ Float   = NULL
,@ZWGZ Float   = NULL
,@JBGZ Float   = NULL
,@JKDQJT Float   = NULL
,@JKTSGWJT Float   = NULL
,@GLGZ Float   = NULL
,@XJGZ Float   = NULL
,@TGBF Float   = NULL
,@DHF Float   = NULL
,@DSZNF Float   = NULL
,@FNWSHLF Float   = NULL
,@HLF Float   = NULL
,@JJ Float   = NULL
,@JTF Float   = NULL
,@JHLGZ Float   = NULL
,@JT Float   = NULL
,@BF Float   = NULL
,@QTBT Float   = NULL
,@DFXJT Float   = NULL
,@YFX Float   = NULL
,@QTKK Float   = NULL
,@SYBX Float   = NULL
,@SDNQF Float   = NULL
,@SDS Float   = NULL
,@YLBX Float   = NULL
,@YLIBX Float   = NULL
,@YSSHF Float   = NULL
,@ZFGJJ Float   = NULL
,@KFX Float   = NULL
,@SFGZ Float   = NULL
,@GZKKSM NVarChar (1000)  = NULL
,@TJSJ DateTime   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @XM IS NULL
    SET @XM = NULL
IF @XB IS NULL
    SET @XB = NULL
IF @SFZH IS NULL
    SET @SFZH = NULL
IF @FFGZNY IS NULL
    SET @FFGZNY = NULL
IF @JCGZ IS NULL
    SET @JCGZ = NULL
IF @JSDJGZ IS NULL
    SET @JSDJGZ = NULL
IF @ZWGZ IS NULL
    SET @ZWGZ = NULL
IF @JBGZ IS NULL
    SET @JBGZ = NULL
IF @JKDQJT IS NULL
    SET @JKDQJT = NULL
IF @JKTSGWJT IS NULL
    SET @JKTSGWJT = NULL
IF @GLGZ IS NULL
    SET @GLGZ = NULL
IF @XJGZ IS NULL
    SET @XJGZ = NULL
IF @TGBF IS NULL
    SET @TGBF = NULL
IF @DHF IS NULL
    SET @DHF = NULL
IF @DSZNF IS NULL
    SET @DSZNF = NULL
IF @FNWSHLF IS NULL
    SET @FNWSHLF = NULL
IF @HLF IS NULL
    SET @HLF = NULL
IF @JJ IS NULL
    SET @JJ = NULL
IF @JTF IS NULL
    SET @JTF = NULL
IF @JHLGZ IS NULL
    SET @JHLGZ = NULL
IF @JT IS NULL
    SET @JT = NULL
IF @BF IS NULL
    SET @BF = NULL
IF @QTBT IS NULL
    SET @QTBT = NULL
IF @DFXJT IS NULL
    SET @DFXJT = NULL
IF @YFX IS NULL
    SET @YFX = NULL
IF @QTKK IS NULL
    SET @QTKK = NULL
IF @SYBX IS NULL
    SET @SYBX = NULL
IF @SDNQF IS NULL
    SET @SDNQF = NULL
IF @SDS IS NULL
    SET @SDS = NULL
IF @YLBX IS NULL
    SET @YLBX = NULL
IF @YLIBX IS NULL
    SET @YLIBX = NULL
IF @YSSHF IS NULL
    SET @YSSHF = NULL
IF @ZFGJJ IS NULL
    SET @ZFGJJ = NULL
IF @KFX IS NULL
    SET @KFX = NULL
IF @SFGZ IS NULL
    SET @SFGZ = NULL
IF @GZKKSM IS NULL
    SET @GZKKSM = NULL
IF @TJSJ IS NULL
    SET @TJSJ = NULL
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
    INSERT INTO [dbo].[T_BM_GZXX]
    (
    
    [ObjectID]
    ,[XM]
    ,[XB]
    ,[SFZH]
    ,[FFGZNY]
    ,[JCGZ]
    ,[JSDJGZ]
    ,[ZWGZ]
    ,[JBGZ]
    ,[JKDQJT]
    ,[JKTSGWJT]
    ,[GLGZ]
    ,[XJGZ]
    ,[TGBF]
    ,[DHF]
    ,[DSZNF]
    ,[FNWSHLF]
    ,[HLF]
    ,[JJ]
    ,[JTF]
    ,[JHLGZ]
    ,[JT]
    ,[BF]
    ,[QTBT]
    ,[DFXJT]
    ,[YFX]
    ,[QTKK]
    ,[SYBX]
    ,[SDNQF]
    ,[SDS]
    ,[YLBX]
    ,[YLIBX]
    ,[YSSHF]
    ,[ZFGJJ]
    ,[KFX]
    ,[SFGZ]
    ,[GZKKSM]
    ,[TJSJ]
    )
    VALUES
    (
    
    @ObjectID
    ,@XM
    ,@XB
    ,@SFZH
    ,@FFGZNY
    ,@JCGZ
    ,@JSDJGZ
    ,@ZWGZ
    ,@JBGZ
    ,@JKDQJT
    ,@JKTSGWJT
    ,@GLGZ
    ,@XJGZ
    ,@TGBF
    ,@DHF
    ,@DSZNF
    ,@FNWSHLF
    ,@HLF
    ,@JJ
    ,@JTF
    ,@JHLGZ
    ,@JT
    ,@BF
    ,@QTBT
    ,@DFXJT
    ,@YFX
    ,@QTKK
    ,@SYBX
    ,@SDNQF
    ,@SDS
    ,@YLBX
    ,@YLIBX
    ,@YSSHF
    ,@ZFGJJ
    ,@KFX
    ,@SFGZ
    ,@GZKKSM
    ,@TJSJ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_GZXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_GZXXByAnyCondition]
GO

--表T_BM_GZXX任意条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_GZXXByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @XM NVarChar(50) = NULL
        
, @XMValue NVarChar(50) = NULL
, @XMBatch nvarchar(1000) = NULL

, @XB NVarChar(2) = NULL
        
, @XBValue NVarChar(2) = NULL
, @XBBatch nvarchar(1000) = NULL

, @SFZH NVarChar(18) = NULL
        
, @SFZHValue NVarChar(18) = NULL
, @SFZHBatch nvarchar(1000) = NULL

, @FFGZNY NVarChar(6) = NULL
        
, @FFGZNYValue NVarChar(6) = NULL
, @FFGZNYBatch nvarchar(1000) = NULL

, @JCGZ Float = NULL
        
, @JCGZValue Float = NULL
, @JCGZBatch nvarchar(1000) = NULL

, @JSDJGZ Float = NULL
        
, @JSDJGZValue Float = NULL
, @JSDJGZBatch nvarchar(1000) = NULL

, @ZWGZ Float = NULL
        
, @ZWGZValue Float = NULL
, @ZWGZBatch nvarchar(1000) = NULL

, @JBGZ Float = NULL
        
, @JBGZValue Float = NULL
, @JBGZBatch nvarchar(1000) = NULL

, @JKDQJT Float = NULL
        
, @JKDQJTValue Float = NULL
, @JKDQJTBatch nvarchar(1000) = NULL

, @JKTSGWJT Float = NULL
        
, @JKTSGWJTValue Float = NULL
, @JKTSGWJTBatch nvarchar(1000) = NULL

, @GLGZ Float = NULL
        
, @GLGZValue Float = NULL
, @GLGZBatch nvarchar(1000) = NULL

, @XJGZ Float = NULL
        
, @XJGZValue Float = NULL
, @XJGZBatch nvarchar(1000) = NULL

, @TGBF Float = NULL
        
, @TGBFValue Float = NULL
, @TGBFBatch nvarchar(1000) = NULL

, @DHF Float = NULL
        
, @DHFValue Float = NULL
, @DHFBatch nvarchar(1000) = NULL

, @DSZNF Float = NULL
        
, @DSZNFValue Float = NULL
, @DSZNFBatch nvarchar(1000) = NULL

, @FNWSHLF Float = NULL
        
, @FNWSHLFValue Float = NULL
, @FNWSHLFBatch nvarchar(1000) = NULL

, @HLF Float = NULL
        
, @HLFValue Float = NULL
, @HLFBatch nvarchar(1000) = NULL

, @JJ Float = NULL
        
, @JJValue Float = NULL
, @JJBatch nvarchar(1000) = NULL

, @JTF Float = NULL
        
, @JTFValue Float = NULL
, @JTFBatch nvarchar(1000) = NULL

, @JHLGZ Float = NULL
        
, @JHLGZValue Float = NULL
, @JHLGZBatch nvarchar(1000) = NULL

, @JT Float = NULL
        
, @JTValue Float = NULL
, @JTBatch nvarchar(1000) = NULL

, @BF Float = NULL
        
, @BFValue Float = NULL
, @BFBatch nvarchar(1000) = NULL

, @QTBT Float = NULL
        
, @QTBTValue Float = NULL
, @QTBTBatch nvarchar(1000) = NULL

, @DFXJT Float = NULL
        
, @DFXJTValue Float = NULL
, @DFXJTBatch nvarchar(1000) = NULL

, @YFX Float = NULL
        
, @YFXValue Float = NULL
, @YFXBatch nvarchar(1000) = NULL

, @QTKK Float = NULL
        
, @QTKKValue Float = NULL
, @QTKKBatch nvarchar(1000) = NULL

, @SYBX Float = NULL
        
, @SYBXValue Float = NULL
, @SYBXBatch nvarchar(1000) = NULL

, @SDNQF Float = NULL
        
, @SDNQFValue Float = NULL
, @SDNQFBatch nvarchar(1000) = NULL

, @SDS Float = NULL
        
, @SDSValue Float = NULL
, @SDSBatch nvarchar(1000) = NULL

, @YLBX Float = NULL
        
, @YLBXValue Float = NULL
, @YLBXBatch nvarchar(1000) = NULL

, @YLIBX Float = NULL
        
, @YLIBXValue Float = NULL
, @YLIBXBatch nvarchar(1000) = NULL

, @YSSHF Float = NULL
        
, @YSSHFValue Float = NULL
, @YSSHFBatch nvarchar(1000) = NULL

, @ZFGJJ Float = NULL
        
, @ZFGJJValue Float = NULL
, @ZFGJJBatch nvarchar(1000) = NULL

, @KFX Float = NULL
        
, @KFXValue Float = NULL
, @KFXBatch nvarchar(1000) = NULL

, @SFGZ Float = NULL
        
, @SFGZValue Float = NULL
, @SFGZBatch nvarchar(1000) = NULL

, @GZKKSM NVarChar(1000) = NULL
        
, @GZKKSMValue NVarChar(1000) = NULL
, @GZKKSMBatch nvarchar(1000) = NULL

, @TJSJ DateTime = NULL
        
, @TJSJBegin DateTime = NULL
, @TJSJEnd DateTime = NULL
        
, @TJSJValue DateTime = NULL
, @TJSJBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_BM_GZXX].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].ObjectID)+''%'' '
    
    IF @XM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].XM LIKE '''+CAST(@XM AS nvarchar(100))+'%'' '
            
    IF @XMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].XM)+''%'' '
    
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].XB = '''+CAST(@XB AS nvarchar(100))+''' '
            
    IF @XBBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XBBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].XB)+''%'' '
    
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].SFZH LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
            
    IF @SFZHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SFZHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SFZH)+''%'' '
    
    IF @FFGZNY IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].FFGZNY LIKE '''+CAST(@FFGZNY AS nvarchar(100))+'%'' '
            
    IF @FFGZNYBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FFGZNYBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].FFGZNY)+''%'' '
    
    IF @JCGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JCGZ = '''+CAST(@JCGZ AS nvarchar(100))+''' '
            
    IF @JCGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JCGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JCGZ)+''%'' '
    
    IF @JSDJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JSDJGZ = '''+CAST(@JSDJGZ AS nvarchar(100))+''' '
            
    IF @JSDJGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JSDJGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JSDJGZ)+''%'' '
    
    IF @ZWGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].ZWGZ = '''+CAST(@ZWGZ AS nvarchar(100))+''' '
            
    IF @ZWGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ZWGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].ZWGZ)+''%'' '
    
    IF @JBGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JBGZ = '''+CAST(@JBGZ AS nvarchar(100))+''' '
            
    IF @JBGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JBGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JBGZ)+''%'' '
    
    IF @JKDQJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JKDQJT = '''+CAST(@JKDQJT AS nvarchar(100))+''' '
            
    IF @JKDQJTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JKDQJTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JKDQJT)+''%'' '
    
    IF @JKTSGWJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JKTSGWJT = '''+CAST(@JKTSGWJT AS nvarchar(100))+''' '
            
    IF @JKTSGWJTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JKTSGWJTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JKTSGWJT)+''%'' '
    
    IF @GLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].GLGZ = '''+CAST(@GLGZ AS nvarchar(100))+''' '
            
    IF @GLGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@GLGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].GLGZ)+''%'' '
    
    IF @XJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].XJGZ = '''+CAST(@XJGZ AS nvarchar(100))+''' '
            
    IF @XJGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XJGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].XJGZ)+''%'' '
    
    IF @TGBF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].TGBF = '''+CAST(@TGBF AS nvarchar(100))+''' '
            
    IF @TGBFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@TGBFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].TGBF)+''%'' '
    
    IF @DHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].DHF = '''+CAST(@DHF AS nvarchar(100))+''' '
            
    IF @DHFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DHFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].DHF)+''%'' '
    
    IF @DSZNF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].DSZNF = '''+CAST(@DSZNF AS nvarchar(100))+''' '
            
    IF @DSZNFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DSZNFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].DSZNF)+''%'' '
    
    IF @FNWSHLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].FNWSHLF = '''+CAST(@FNWSHLF AS nvarchar(100))+''' '
            
    IF @FNWSHLFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@FNWSHLFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].FNWSHLF)+''%'' '
    
    IF @HLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].HLF = '''+CAST(@HLF AS nvarchar(100))+''' '
            
    IF @HLFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@HLFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].HLF)+''%'' '
    
    IF @JJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JJ = '''+CAST(@JJ AS nvarchar(100))+''' '
            
    IF @JJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JJ)+''%'' '
    
    IF @JTF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JTF = '''+CAST(@JTF AS nvarchar(100))+''' '
            
    IF @JTFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JTFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JTF)+''%'' '
    
    IF @JHLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JHLGZ = '''+CAST(@JHLGZ AS nvarchar(100))+''' '
            
    IF @JHLGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JHLGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JHLGZ)+''%'' '
    
    IF @JT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].JT = '''+CAST(@JT AS nvarchar(100))+''' '
            
    IF @JTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JT)+''%'' '
    
    IF @BF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].BF = '''+CAST(@BF AS nvarchar(100))+''' '
            
    IF @BFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].BF)+''%'' '
    
    IF @QTBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].QTBT = '''+CAST(@QTBT AS nvarchar(100))+''' '
            
    IF @QTBTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@QTBTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].QTBT)+''%'' '
    
    IF @DFXJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].DFXJT = '''+CAST(@DFXJT AS nvarchar(100))+''' '
            
    IF @DFXJTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@DFXJTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].DFXJT)+''%'' '
    
    IF @YFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].YFX = '''+CAST(@YFX AS nvarchar(100))+''' '
            
    IF @YFXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YFXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YFX)+''%'' '
    
    IF @QTKK IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].QTKK = '''+CAST(@QTKK AS nvarchar(100))+''' '
            
    IF @QTKKBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@QTKKBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].QTKK)+''%'' '
    
    IF @SYBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].SYBX = '''+CAST(@SYBX AS nvarchar(100))+''' '
            
    IF @SYBXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SYBXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SYBX)+''%'' '
    
    IF @SDNQF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].SDNQF = '''+CAST(@SDNQF AS nvarchar(100))+''' '
            
    IF @SDNQFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SDNQFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SDNQF)+''%'' '
    
    IF @SDS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].SDS = '''+CAST(@SDS AS nvarchar(100))+''' '
            
    IF @SDSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SDSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SDS)+''%'' '
    
    IF @YLBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].YLBX = '''+CAST(@YLBX AS nvarchar(100))+''' '
            
    IF @YLBXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YLBXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YLBX)+''%'' '
    
    IF @YLIBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].YLIBX = '''+CAST(@YLIBX AS nvarchar(100))+''' '
            
    IF @YLIBXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YLIBXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YLIBX)+''%'' '
    
    IF @YSSHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].YSSHF = '''+CAST(@YSSHF AS nvarchar(100))+''' '
            
    IF @YSSHFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@YSSHFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YSSHF)+''%'' '
    
    IF @ZFGJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].ZFGJJ = '''+CAST(@ZFGJJ AS nvarchar(100))+''' '
            
    IF @ZFGJJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ZFGJJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].ZFGJJ)+''%'' '
    
    IF @KFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].KFX = '''+CAST(@KFX AS nvarchar(100))+''' '
            
    IF @KFXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@KFXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].KFX)+''%'' '
    
    IF @SFGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].SFGZ = '''+CAST(@SFGZ AS nvarchar(100))+''' '
            
    IF @SFGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SFGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SFGZ)+''%'' '
    
    IF @GZKKSM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].GZKKSM = '''+CAST(@GZKKSM AS nvarchar(100))+''' '
            
    IF @GZKKSMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@GZKKSMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].GZKKSM)+''%'' '
    
    IF @TJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].TJSJ = '''+CAST(@TJSJ AS nvarchar(100))+''' '
    IF @TJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].TJSJ >= '''+CAST(@TJSJBegin AS nvarchar(100))+''' '
    IF @TJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].TJSJ <= '''+CAST(@TJSJEnd AS nvarchar(100))+''' '
        
    IF @TJSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@TJSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].TJSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_BM_GZXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].ObjectID)+''%'' '
    
    IF @XM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].XM LIKE '''+CAST(@XM AS nvarchar(100))+'%'' '
        
    IF @XMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].XM)+''%'' '
    
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].XB LIKE '''+CAST(@XB AS nvarchar(100))+'%'' '
        
    IF @XBBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XBBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].XB)+''%'' '
    
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].SFZH LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
        
    IF @SFZHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SFZHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SFZH)+''%'' '
    
    IF @FFGZNY IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].FFGZNY LIKE '''+CAST(@FFGZNY AS nvarchar(100))+'%'' '
        
    IF @FFGZNYBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FFGZNYBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].FFGZNY)+''%'' '
    
    IF @JCGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JCGZ LIKE '''+CAST(@JCGZ AS nvarchar(100))+'%'' '
        
    IF @JCGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JCGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JCGZ)+''%'' '
    
    IF @JSDJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JSDJGZ LIKE '''+CAST(@JSDJGZ AS nvarchar(100))+'%'' '
        
    IF @JSDJGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JSDJGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JSDJGZ)+''%'' '
    
    IF @ZWGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].ZWGZ LIKE '''+CAST(@ZWGZ AS nvarchar(100))+'%'' '
        
    IF @ZWGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ZWGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].ZWGZ)+''%'' '
    
    IF @JBGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JBGZ LIKE '''+CAST(@JBGZ AS nvarchar(100))+'%'' '
        
    IF @JBGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JBGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JBGZ)+''%'' '
    
    IF @JKDQJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JKDQJT LIKE '''+CAST(@JKDQJT AS nvarchar(100))+'%'' '
        
    IF @JKDQJTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JKDQJTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JKDQJT)+''%'' '
    
    IF @JKTSGWJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JKTSGWJT LIKE '''+CAST(@JKTSGWJT AS nvarchar(100))+'%'' '
        
    IF @JKTSGWJTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JKTSGWJTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JKTSGWJT)+''%'' '
    
    IF @GLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].GLGZ LIKE '''+CAST(@GLGZ AS nvarchar(100))+'%'' '
        
    IF @GLGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@GLGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].GLGZ)+''%'' '
    
    IF @XJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].XJGZ LIKE '''+CAST(@XJGZ AS nvarchar(100))+'%'' '
        
    IF @XJGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XJGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].XJGZ)+''%'' '
    
    IF @TGBF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].TGBF LIKE '''+CAST(@TGBF AS nvarchar(100))+'%'' '
        
    IF @TGBFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@TGBFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].TGBF)+''%'' '
    
    IF @DHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].DHF LIKE '''+CAST(@DHF AS nvarchar(100))+'%'' '
        
    IF @DHFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DHFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].DHF)+''%'' '
    
    IF @DSZNF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].DSZNF LIKE '''+CAST(@DSZNF AS nvarchar(100))+'%'' '
        
    IF @DSZNFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DSZNFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].DSZNF)+''%'' '
    
    IF @FNWSHLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].FNWSHLF LIKE '''+CAST(@FNWSHLF AS nvarchar(100))+'%'' '
        
    IF @FNWSHLFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@FNWSHLFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].FNWSHLF)+''%'' '
    
    IF @HLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].HLF LIKE '''+CAST(@HLF AS nvarchar(100))+'%'' '
        
    IF @HLFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@HLFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].HLF)+''%'' '
    
    IF @JJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JJ LIKE '''+CAST(@JJ AS nvarchar(100))+'%'' '
        
    IF @JJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JJ)+''%'' '
    
    IF @JTF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JTF LIKE '''+CAST(@JTF AS nvarchar(100))+'%'' '
        
    IF @JTFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JTFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JTF)+''%'' '
    
    IF @JHLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JHLGZ LIKE '''+CAST(@JHLGZ AS nvarchar(100))+'%'' '
        
    IF @JHLGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JHLGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JHLGZ)+''%'' '
    
    IF @JT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].JT LIKE '''+CAST(@JT AS nvarchar(100))+'%'' '
        
    IF @JTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].JT)+''%'' '
    
    IF @BF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].BF LIKE '''+CAST(@BF AS nvarchar(100))+'%'' '
        
    IF @BFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].BF)+''%'' '
    
    IF @QTBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].QTBT LIKE '''+CAST(@QTBT AS nvarchar(100))+'%'' '
        
    IF @QTBTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@QTBTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].QTBT)+''%'' '
    
    IF @DFXJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].DFXJT LIKE '''+CAST(@DFXJT AS nvarchar(100))+'%'' '
        
    IF @DFXJTBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@DFXJTBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].DFXJT)+''%'' '
    
    IF @YFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].YFX LIKE '''+CAST(@YFX AS nvarchar(100))+'%'' '
        
    IF @YFXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YFXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YFX)+''%'' '
    
    IF @QTKK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].QTKK LIKE '''+CAST(@QTKK AS nvarchar(100))+'%'' '
        
    IF @QTKKBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@QTKKBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].QTKK)+''%'' '
    
    IF @SYBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].SYBX LIKE '''+CAST(@SYBX AS nvarchar(100))+'%'' '
        
    IF @SYBXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SYBXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SYBX)+''%'' '
    
    IF @SDNQF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].SDNQF LIKE '''+CAST(@SDNQF AS nvarchar(100))+'%'' '
        
    IF @SDNQFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SDNQFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SDNQF)+''%'' '
    
    IF @SDS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].SDS LIKE '''+CAST(@SDS AS nvarchar(100))+'%'' '
        
    IF @SDSBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SDSBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SDS)+''%'' '
    
    IF @YLBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].YLBX LIKE '''+CAST(@YLBX AS nvarchar(100))+'%'' '
        
    IF @YLBXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YLBXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YLBX)+''%'' '
    
    IF @YLIBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].YLIBX LIKE '''+CAST(@YLIBX AS nvarchar(100))+'%'' '
        
    IF @YLIBXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YLIBXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YLIBX)+''%'' '
    
    IF @YSSHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].YSSHF LIKE '''+CAST(@YSSHF AS nvarchar(100))+'%'' '
        
    IF @YSSHFBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@YSSHFBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].YSSHF)+''%'' '
    
    IF @ZFGJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].ZFGJJ LIKE '''+CAST(@ZFGJJ AS nvarchar(100))+'%'' '
        
    IF @ZFGJJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ZFGJJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].ZFGJJ)+''%'' '
    
    IF @KFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].KFX LIKE '''+CAST(@KFX AS nvarchar(100))+'%'' '
        
    IF @KFXBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@KFXBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].KFX)+''%'' '
    
    IF @SFGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].SFGZ LIKE '''+CAST(@SFGZ AS nvarchar(100))+'%'' '
        
    IF @SFGZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SFGZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].SFGZ)+''%'' '
    
    IF @GZKKSM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].GZKKSM LIKE '''+CAST(@GZKKSM AS nvarchar(100))+'%'' '
        
    IF @GZKKSMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@GZKKSMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].GZKKSM)+''%'' '
    
    IF @TJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].TJSJ = '''+CAST(@TJSJ AS nvarchar(100))+''' '
    IF @TJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].TJSJ >= '''+CAST(@TJSJBegin AS nvarchar(100))+''' '
    IF @TJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].TJSJ <= '''+CAST(@TJSJEnd AS nvarchar(100))+''' '
        
    IF @TJSJBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@TJSJBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_BM_GZXX].TJSJ)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_BM_GZXX] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_BM_GZXX] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_BM_GZXX].ObjectID'
  
    IF @XMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XM = @XMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XM = [DB_MGZZX].[dbo].[T_BM_GZXX].XM'
  
    IF @XBValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XB = @XBValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XB = [DB_MGZZX].[dbo].[T_BM_GZXX].XB'
  
    IF @SFZHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SFZH = @SFZHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SFZH = [DB_MGZZX].[dbo].[T_BM_GZXX].SFZH'
  
    IF @FFGZNYValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FFGZNY = @FFGZNYValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FFGZNY = [DB_MGZZX].[dbo].[T_BM_GZXX].FFGZNY'
  
    IF @JCGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JCGZ = @JCGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JCGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].JCGZ'
  
    IF @JSDJGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JSDJGZ = @JSDJGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JSDJGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].JSDJGZ'
  
    IF @ZWGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,ZWGZ = @ZWGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,ZWGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].ZWGZ'
  
    IF @JBGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JBGZ = @JBGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JBGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].JBGZ'
  
    IF @JKDQJTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JKDQJT = @JKDQJTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JKDQJT = [DB_MGZZX].[dbo].[T_BM_GZXX].JKDQJT'
  
    IF @JKTSGWJTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JKTSGWJT = @JKTSGWJTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JKTSGWJT = [DB_MGZZX].[dbo].[T_BM_GZXX].JKTSGWJT'
  
    IF @GLGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,GLGZ = @GLGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,GLGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].GLGZ'
  
    IF @XJGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XJGZ = @XJGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XJGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].XJGZ'
  
    IF @TGBFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,TGBF = @TGBFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,TGBF = [DB_MGZZX].[dbo].[T_BM_GZXX].TGBF'
  
    IF @DHFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DHF = @DHFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DHF = [DB_MGZZX].[dbo].[T_BM_GZXX].DHF'
  
    IF @DSZNFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DSZNF = @DSZNFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DSZNF = [DB_MGZZX].[dbo].[T_BM_GZXX].DSZNF'
  
    IF @FNWSHLFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,FNWSHLF = @FNWSHLFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,FNWSHLF = [DB_MGZZX].[dbo].[T_BM_GZXX].FNWSHLF'
  
    IF @HLFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,HLF = @HLFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,HLF = [DB_MGZZX].[dbo].[T_BM_GZXX].HLF'
  
    IF @JJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JJ = @JJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JJ = [DB_MGZZX].[dbo].[T_BM_GZXX].JJ'
  
    IF @JTFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JTF = @JTFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JTF = [DB_MGZZX].[dbo].[T_BM_GZXX].JTF'
  
    IF @JHLGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JHLGZ = @JHLGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JHLGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].JHLGZ'
  
    IF @JTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JT = @JTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JT = [DB_MGZZX].[dbo].[T_BM_GZXX].JT'
  
    IF @BFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BF = @BFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BF = [DB_MGZZX].[dbo].[T_BM_GZXX].BF'
  
    IF @QTBTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,QTBT = @QTBTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,QTBT = [DB_MGZZX].[dbo].[T_BM_GZXX].QTBT'
  
    IF @DFXJTValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,DFXJT = @DFXJTValue'
    ELSE
        SET @SqlText = @SqlText + ' ,DFXJT = [DB_MGZZX].[dbo].[T_BM_GZXX].DFXJT'
  
    IF @YFXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YFX = @YFXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YFX = [DB_MGZZX].[dbo].[T_BM_GZXX].YFX'
  
    IF @QTKKValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,QTKK = @QTKKValue'
    ELSE
        SET @SqlText = @SqlText + ' ,QTKK = [DB_MGZZX].[dbo].[T_BM_GZXX].QTKK'
  
    IF @SYBXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SYBX = @SYBXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SYBX = [DB_MGZZX].[dbo].[T_BM_GZXX].SYBX'
  
    IF @SDNQFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SDNQF = @SDNQFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SDNQF = [DB_MGZZX].[dbo].[T_BM_GZXX].SDNQF'
  
    IF @SDSValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SDS = @SDSValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SDS = [DB_MGZZX].[dbo].[T_BM_GZXX].SDS'
  
    IF @YLBXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YLBX = @YLBXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YLBX = [DB_MGZZX].[dbo].[T_BM_GZXX].YLBX'
  
    IF @YLIBXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YLIBX = @YLIBXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YLIBX = [DB_MGZZX].[dbo].[T_BM_GZXX].YLIBX'
  
    IF @YSSHFValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,YSSHF = @YSSHFValue'
    ELSE
        SET @SqlText = @SqlText + ' ,YSSHF = [DB_MGZZX].[dbo].[T_BM_GZXX].YSSHF'
  
    IF @ZFGJJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,ZFGJJ = @ZFGJJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,ZFGJJ = [DB_MGZZX].[dbo].[T_BM_GZXX].ZFGJJ'
  
    IF @KFXValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,KFX = @KFXValue'
    ELSE
        SET @SqlText = @SqlText + ' ,KFX = [DB_MGZZX].[dbo].[T_BM_GZXX].KFX'
  
    IF @SFGZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SFGZ = @SFGZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SFGZ = [DB_MGZZX].[dbo].[T_BM_GZXX].SFGZ'
  
    IF @GZKKSMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,GZKKSM = @GZKKSMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,GZKKSM = [DB_MGZZX].[dbo].[T_BM_GZXX].GZKKSM'
  
    IF @TJSJValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,TJSJ = @TJSJValue'
    ELSE
        SET @SqlText = @SqlText + ' ,TJSJ = [DB_MGZZX].[dbo].[T_BM_GZXX].TJSJ'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_BM_GZXX] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_GZXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_GZXXByObjectID]
GO

--表T_BM_GZXX以ObjectID为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_GZXXByObjectID] 

@ObjectID nvarchar(50) = NULL
,@XM NVarChar(50) = NULL
,@XB NVarChar(2) = NULL
,@SFZH NVarChar(18) = NULL
,@FFGZNY NVarChar(6) = NULL
,@JCGZ Float = NULL
,@JSDJGZ Float = NULL
,@ZWGZ Float = NULL
,@JBGZ Float = NULL
,@JKDQJT Float = NULL
,@JKTSGWJT Float = NULL
,@GLGZ Float = NULL
,@XJGZ Float = NULL
,@TGBF Float = NULL
,@DHF Float = NULL
,@DSZNF Float = NULL
,@FNWSHLF Float = NULL
,@HLF Float = NULL
,@JJ Float = NULL
,@JTF Float = NULL
,@JHLGZ Float = NULL
,@JT Float = NULL
,@BF Float = NULL
,@QTBT Float = NULL
,@DFXJT Float = NULL
,@YFX Float = NULL
,@QTKK Float = NULL
,@SYBX Float = NULL
,@SDNQF Float = NULL
,@SDS Float = NULL
,@YLBX Float = NULL
,@YLIBX Float = NULL
,@YSSHF Float = NULL
,@ZFGJJ Float = NULL
,@KFX Float = NULL
,@SFGZ Float = NULL
,@GZKKSM NVarChar(1000) = NULL
,@TJSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    UPDATE [dbo].[T_BM_GZXX]
    SET 
    
    [ObjectID] = @ObjectID
    , [XM] = @XM
    , [XB] = @XB
    , [SFZH] = @SFZH
    , [FFGZNY] = @FFGZNY
    , [JCGZ] = @JCGZ
    , [JSDJGZ] = @JSDJGZ
    , [ZWGZ] = @ZWGZ
    , [JBGZ] = @JBGZ
    , [JKDQJT] = @JKDQJT
    , [JKTSGWJT] = @JKTSGWJT
    , [GLGZ] = @GLGZ
    , [XJGZ] = @XJGZ
    , [TGBF] = @TGBF
    , [DHF] = @DHF
    , [DSZNF] = @DSZNF
    , [FNWSHLF] = @FNWSHLF
    , [HLF] = @HLF
    , [JJ] = @JJ
    , [JTF] = @JTF
    , [JHLGZ] = @JHLGZ
    , [JT] = @JT
    , [BF] = @BF
    , [QTBT] = @QTBT
    , [DFXJT] = @DFXJT
    , [YFX] = @YFX
    , [QTKK] = @QTKK
    , [SYBX] = @SYBX
    , [SDNQF] = @SDNQF
    , [SDS] = @SDS
    , [YLBX] = @YLBX
    , [YLIBX] = @YLIBX
    , [YSSHF] = @YSSHF
    , [ZFGJJ] = @ZFGJJ
    , [KFX] = @KFX
    , [SFGZ] = @SFGZ
    , [GZKKSM] = @GZKKSM
    , [TJSJ] = @TJSJ
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_GZXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_GZXXByKey]
GO

--表T_BM_GZXX以主键为条件更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_GZXXByKey] 

@ObjectID nvarchar(50) = NULL
,@XM NVarChar(50) = NULL
,@XB NVarChar(2) = NULL
,@SFZH NVarChar(18) = NULL
,@FFGZNY NVarChar(6) = NULL
,@JCGZ Float = NULL
,@JSDJGZ Float = NULL
,@ZWGZ Float = NULL
,@JBGZ Float = NULL
,@JKDQJT Float = NULL
,@JKTSGWJT Float = NULL
,@GLGZ Float = NULL
,@XJGZ Float = NULL
,@TGBF Float = NULL
,@DHF Float = NULL
,@DSZNF Float = NULL
,@FNWSHLF Float = NULL
,@HLF Float = NULL
,@JJ Float = NULL
,@JTF Float = NULL
,@JHLGZ Float = NULL
,@JT Float = NULL
,@BF Float = NULL
,@QTBT Float = NULL
,@DFXJT Float = NULL
,@YFX Float = NULL
,@QTKK Float = NULL
,@SYBX Float = NULL
,@SDNQF Float = NULL
,@SDS Float = NULL
,@YLBX Float = NULL
,@YLIBX Float = NULL
,@YSSHF Float = NULL
,@ZFGJJ Float = NULL
,@KFX Float = NULL
,@SFGZ Float = NULL
,@GZKKSM NVarChar(1000) = NULL
,@TJSJ DateTime = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @XM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [XM] = @XM
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @XB IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [XB] = @XB
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @SFZH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SFZH] = @SFZH
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @FFGZNY IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [FFGZNY] = @FFGZNY
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JCGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JCGZ] = @JCGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JSDJGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JSDJGZ] = @JSDJGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @ZWGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [ZWGZ] = @ZWGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JBGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JBGZ] = @JBGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JKDQJT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JKDQJT] = @JKDQJT
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JKTSGWJT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JKTSGWJT] = @JKTSGWJT
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @GLGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [GLGZ] = @GLGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @XJGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [XJGZ] = @XJGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @TGBF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [TGBF] = @TGBF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @DHF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [DHF] = @DHF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @DSZNF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [DSZNF] = @DSZNF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @FNWSHLF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [FNWSHLF] = @FNWSHLF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @HLF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [HLF] = @HLF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JJ] = @JJ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JTF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JTF] = @JTF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JHLGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JHLGZ] = @JHLGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @JT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JT] = @JT
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @BF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [BF] = @BF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @QTBT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [QTBT] = @QTBT
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @DFXJT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [DFXJT] = @DFXJT
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @YFX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YFX] = @YFX
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @QTKK IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [QTKK] = @QTKK
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @SYBX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SYBX] = @SYBX
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @SDNQF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SDNQF] = @SDNQF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @SDS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SDS] = @SDS
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @YLBX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YLBX] = @YLBX
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @YLIBX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YLIBX] = @YLIBX
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @YSSHF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YSSHF] = @YSSHF
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @ZFGJJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [ZFGJJ] = @ZFGJJ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @KFX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [KFX] = @KFX
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @SFGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SFGZ] = @SFGZ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @GZKKSM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [GZKKSM] = @GZKKSM
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
    END
    
    IF @TJSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [TJSJ] = @TJSJ
        WHERE
        
        [SFZH] = @SFZH
        AND [FFGZNY] = @FFGZNY
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_GZXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_GZXXByObjectIDBatch]
GO

--表T_BM_GZXX以ObjectID为条件批量更新的存储过程

CREATE   PROCEDURE [dbo].[SP_UpdateT_BM_GZXXByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@XM NVarChar(50) = NULL

,@XB NVarChar(2) = NULL

,@SFZH NVarChar(18) = NULL

,@FFGZNY NVarChar(6) = NULL

,@JCGZ Float = NULL

,@JSDJGZ Float = NULL

,@ZWGZ Float = NULL

,@JBGZ Float = NULL

,@JKDQJT Float = NULL

,@JKTSGWJT Float = NULL

,@GLGZ Float = NULL

,@XJGZ Float = NULL

,@TGBF Float = NULL

,@DHF Float = NULL

,@DSZNF Float = NULL

,@FNWSHLF Float = NULL

,@HLF Float = NULL

,@JJ Float = NULL

,@JTF Float = NULL

,@JHLGZ Float = NULL

,@JT Float = NULL

,@BF Float = NULL

,@QTBT Float = NULL

,@DFXJT Float = NULL

,@YFX Float = NULL

,@QTKK Float = NULL

,@SYBX Float = NULL

,@SDNQF Float = NULL

,@SDS Float = NULL

,@YLBX Float = NULL

,@YLIBX Float = NULL

,@YSSHF Float = NULL

,@ZFGJJ Float = NULL

,@KFX Float = NULL

,@SFGZ Float = NULL

,@GZKKSM NVarChar(1000) = NULL

,@TJSJ DateTime = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [XM] = @XM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XB IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [XB] = @XB WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SFZH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SFZH] = @SFZH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FFGZNY IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [FFGZNY] = @FFGZNY WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JCGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JCGZ] = @JCGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JSDJGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JSDJGZ] = @JSDJGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @ZWGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [ZWGZ] = @ZWGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JBGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JBGZ] = @JBGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JKDQJT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JKDQJT] = @JKDQJT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JKTSGWJT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JKTSGWJT] = @JKTSGWJT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @GLGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [GLGZ] = @GLGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XJGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [XJGZ] = @XJGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @TGBF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [TGBF] = @TGBF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DHF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [DHF] = @DHF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DSZNF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [DSZNF] = @DSZNF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @FNWSHLF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [FNWSHLF] = @FNWSHLF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @HLF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [HLF] = @HLF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JJ] = @JJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JTF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JTF] = @JTF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JHLGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JHLGZ] = @JHLGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [JT] = @JT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [BF] = @BF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @QTBT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [QTBT] = @QTBT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @DFXJT IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [DFXJT] = @DFXJT WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YFX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YFX] = @YFX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @QTKK IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [QTKK] = @QTKK WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SYBX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SYBX] = @SYBX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SDNQF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SDNQF] = @SDNQF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SDS IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SDS] = @SDS WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YLBX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YLBX] = @YLBX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YLIBX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YLIBX] = @YLIBX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @YSSHF IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [YSSHF] = @YSSHF WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @ZFGJJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [ZFGJJ] = @ZFGJJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @KFX IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [KFX] = @KFX WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SFGZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [SFGZ] = @SFGZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @GZKKSM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [GZKKSM] = @GZKKSM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @TJSJ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_BM_GZXX]
        SET [TJSJ] = @TJSJ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_GZXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_GZXXByObjectID]
GO

--表T_BM_GZXX以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_GZXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
    DELETE [dbo].[T_BM_GZXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_GZXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_GZXXByKey]
GO

--表T_BM_GZXX以主键为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_GZXXByKey] 

@SFZH NVarChar(18) = NULL
, @FFGZNY NVarChar(6) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_BM_GZXX]
WHERE

[SFZH] = @SFZH
AND [FFGZNY] = @FFGZNY
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_BM_GZXXByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_BM_GZXXByObjectIDBatch]
GO

--表T_BM_GZXX以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_GZXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
    DELETE [dbo].[T_BM_GZXX]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_GZXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_GZXXByAnyCondition]
GO

--表T_BM_GZXX任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_GZXXByAnyCondition] 
--主表参数

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @XM NVarChar(50) = NULL
        
, @XMBatch nvarchar(4000) = NULL

, @XB NVarChar(2) = NULL
        
, @XBBatch nvarchar(4000) = NULL

, @SFZH NVarChar(18) = NULL
        
, @SFZHBatch nvarchar(4000) = NULL

, @FFGZNY NVarChar(6) = NULL
        
, @FFGZNYBatch nvarchar(4000) = NULL

, @JCGZ Float = NULL
        
, @JCGZBatch nvarchar(4000) = NULL

, @JSDJGZ Float = NULL
        
, @JSDJGZBatch nvarchar(4000) = NULL

, @ZWGZ Float = NULL
        
, @ZWGZBatch nvarchar(4000) = NULL

, @JBGZ Float = NULL
        
, @JBGZBatch nvarchar(4000) = NULL

, @JKDQJT Float = NULL
        
, @JKDQJTBatch nvarchar(4000) = NULL

, @JKTSGWJT Float = NULL
        
, @JKTSGWJTBatch nvarchar(4000) = NULL

, @GLGZ Float = NULL
        
, @GLGZBatch nvarchar(4000) = NULL

, @XJGZ Float = NULL
        
, @XJGZBatch nvarchar(4000) = NULL

, @TGBF Float = NULL
        
, @TGBFBatch nvarchar(4000) = NULL

, @DHF Float = NULL
        
, @DHFBatch nvarchar(4000) = NULL

, @DSZNF Float = NULL
        
, @DSZNFBatch nvarchar(4000) = NULL

, @FNWSHLF Float = NULL
        
, @FNWSHLFBatch nvarchar(4000) = NULL

, @HLF Float = NULL
        
, @HLFBatch nvarchar(4000) = NULL

, @JJ Float = NULL
        
, @JJBatch nvarchar(4000) = NULL

, @JTF Float = NULL
        
, @JTFBatch nvarchar(4000) = NULL

, @JHLGZ Float = NULL
        
, @JHLGZBatch nvarchar(4000) = NULL

, @JT Float = NULL
        
, @JTBatch nvarchar(4000) = NULL

, @BF Float = NULL
        
, @BFBatch nvarchar(4000) = NULL

, @QTBT Float = NULL
        
, @QTBTBatch nvarchar(4000) = NULL

, @DFXJT Float = NULL
        
, @DFXJTBatch nvarchar(4000) = NULL

, @YFX Float = NULL
        
, @YFXBegin Float = NULL
, @YFXEnd Float = NULL
        
, @YFXBatch nvarchar(4000) = NULL

, @QTKK Float = NULL
        
, @QTKKBatch nvarchar(4000) = NULL

, @SYBX Float = NULL
        
, @SYBXBatch nvarchar(4000) = NULL

, @SDNQF Float = NULL
        
, @SDNQFBatch nvarchar(4000) = NULL

, @SDS Float = NULL
        
, @SDSBatch nvarchar(4000) = NULL

, @YLBX Float = NULL
        
, @YLBXBatch nvarchar(4000) = NULL

, @YLIBX Float = NULL
        
, @YLIBXBatch nvarchar(4000) = NULL

, @YSSHF Float = NULL
        
, @YSSHFBatch nvarchar(4000) = NULL

, @ZFGJJ Float = NULL
        
, @ZFGJJBatch nvarchar(4000) = NULL

, @KFX Float = NULL
        
, @KFXBatch nvarchar(4000) = NULL

, @SFGZ Float = NULL
        
, @SFGZBegin Float = NULL
, @SFGZEnd Float = NULL
        
, @SFGZBatch nvarchar(4000) = NULL

, @GZKKSM NVarChar(1000) = NULL
        
, @GZKKSMBatch nvarchar(4000) = NULL

, @TJSJ DateTime = NULL
        
, @TJSJBegin DateTime = NULL
, @TJSJEnd DateTime = NULL
        
, @TJSJBatch nvarchar(4000) = NULL

--一对一相关表参数

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'FFGZNY'
, @PageSize int = 500
, @CurrentPage int = 1
, @RecordCount int Output

, @YFXSum Float Output
, @SFGZSum Float Output

AS
DECLARE @SqlText nvarchar(4000) 
DECLARE @SqlTextCount nvarchar(4000) 
DECLARE @ConditionText nvarchar(4000) 
DECLARE @FromText nvarchar(4000) 
DECLARE @SortText nvarchar(255)
DECLARE @InnerSortText nvarchar(4000)

DECLARE @SqlTextYFXSum nvarchar(4000)
DECLARE @SqlTextSFGZSum nvarchar(4000)

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
    SET @SortField = 'FFGZNY'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_BM_GZXX].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_GZXX].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @XM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[XM] LIKE '''+CAST(@XM AS nvarchar(100))+'%'' '
            
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[XB] = '''+CAST(@XB AS nvarchar(100))+''' '
            
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SFZH] LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
            
    IF @FFGZNY IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[FFGZNY] LIKE '''+CAST(@FFGZNY AS nvarchar(100))+'%'' '
            
    IF @JCGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JCGZ] = '''+CAST(@JCGZ AS nvarchar(100))+''' '
            
    IF @JSDJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JSDJGZ] = '''+CAST(@JSDJGZ AS nvarchar(100))+''' '
            
    IF @ZWGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[ZWGZ] = '''+CAST(@ZWGZ AS nvarchar(100))+''' '
            
    IF @JBGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JBGZ] = '''+CAST(@JBGZ AS nvarchar(100))+''' '
            
    IF @JKDQJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JKDQJT] = '''+CAST(@JKDQJT AS nvarchar(100))+''' '
            
    IF @JKTSGWJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JKTSGWJT] = '''+CAST(@JKTSGWJT AS nvarchar(100))+''' '
            
    IF @GLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[GLGZ] = '''+CAST(@GLGZ AS nvarchar(100))+''' '
            
    IF @XJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[XJGZ] = '''+CAST(@XJGZ AS nvarchar(100))+''' '
            
    IF @TGBF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[TGBF] = '''+CAST(@TGBF AS nvarchar(100))+''' '
            
    IF @DHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[DHF] = '''+CAST(@DHF AS nvarchar(100))+''' '
            
    IF @DSZNF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[DSZNF] = '''+CAST(@DSZNF AS nvarchar(100))+''' '
            
    IF @FNWSHLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[FNWSHLF] = '''+CAST(@FNWSHLF AS nvarchar(100))+''' '
            
    IF @HLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[HLF] = '''+CAST(@HLF AS nvarchar(100))+''' '
            
    IF @JJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JJ] = '''+CAST(@JJ AS nvarchar(100))+''' '
            
    IF @JTF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JTF] = '''+CAST(@JTF AS nvarchar(100))+''' '
            
    IF @JHLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JHLGZ] = '''+CAST(@JHLGZ AS nvarchar(100))+''' '
            
    IF @JT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[JT] = '''+CAST(@JT AS nvarchar(100))+''' '
            
    IF @BF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[BF] = '''+CAST(@BF AS nvarchar(100))+''' '
            
    IF @QTBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[QTBT] = '''+CAST(@QTBT AS nvarchar(100))+''' '
            
    IF @DFXJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[DFXJT] = '''+CAST(@DFXJT AS nvarchar(100))+''' '
            
    IF @YFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[YFX] = '''+CAST(@YFX AS nvarchar(100))+''' '
            
    IF @YFXBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[YFX] >= '''+CAST(@YFXBegin AS nvarchar(100))+''' '
    IF @YFXEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[YFX] <= '''+CAST(@YFXEnd AS nvarchar(100))+''' '
        
    IF @QTKK IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[QTKK] = '''+CAST(@QTKK AS nvarchar(100))+''' '
            
    IF @SYBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SYBX] = '''+CAST(@SYBX AS nvarchar(100))+''' '
            
    IF @SDNQF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SDNQF] = '''+CAST(@SDNQF AS nvarchar(100))+''' '
            
    IF @SDS IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SDS] = '''+CAST(@SDS AS nvarchar(100))+''' '
            
    IF @YLBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[YLBX] = '''+CAST(@YLBX AS nvarchar(100))+''' '
            
    IF @YLIBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[YLIBX] = '''+CAST(@YLIBX AS nvarchar(100))+''' '
            
    IF @YSSHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[YSSHF] = '''+CAST(@YSSHF AS nvarchar(100))+''' '
            
    IF @ZFGJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[ZFGJJ] = '''+CAST(@ZFGJJ AS nvarchar(100))+''' '
            
    IF @KFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[KFX] = '''+CAST(@KFX AS nvarchar(100))+''' '
            
    IF @SFGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SFGZ] = '''+CAST(@SFGZ AS nvarchar(100))+''' '
            
    IF @SFGZBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SFGZ] >= '''+CAST(@SFGZBegin AS nvarchar(100))+''' '
    IF @SFGZEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[SFGZ] <= '''+CAST(@SFGZEnd AS nvarchar(100))+''' '
        
    IF @GZKKSM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[GZKKSM] = '''+CAST(@GZKKSM AS nvarchar(100))+''' '
            
    IF @TJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[TJSJ] = '''+CAST(@TJSJ AS nvarchar(100))+''' '
            
    IF @TJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[TJSJ] >= '''+CAST(@TJSJBegin AS nvarchar(100))+''' '
    IF @TJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_BM_GZXX].[TJSJ] <= '''+CAST(@TJSJEnd AS nvarchar(100))+''' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_BM_GZXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @XM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[XM] LIKE '''+CAST(@XM AS nvarchar(100))+'%'' '
            
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[XB] = '''+CAST(@XB AS nvarchar(100))+''' '
            
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFZH] LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
            
    IF @FFGZNY IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[FFGZNY] LIKE '''+CAST(@FFGZNY AS nvarchar(100))+'%'' '
            
    IF @JCGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JCGZ] = '''+CAST(@JCGZ AS nvarchar(100))+''' '
            
    IF @JSDJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JSDJGZ] = '''+CAST(@JSDJGZ AS nvarchar(100))+''' '
            
    IF @ZWGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[ZWGZ] = '''+CAST(@ZWGZ AS nvarchar(100))+''' '
            
    IF @JBGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JBGZ] = '''+CAST(@JBGZ AS nvarchar(100))+''' '
            
    IF @JKDQJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JKDQJT] = '''+CAST(@JKDQJT AS nvarchar(100))+''' '
            
    IF @JKTSGWJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JKTSGWJT] = '''+CAST(@JKTSGWJT AS nvarchar(100))+''' '
            
    IF @GLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[GLGZ] = '''+CAST(@GLGZ AS nvarchar(100))+''' '
            
    IF @XJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[XJGZ] = '''+CAST(@XJGZ AS nvarchar(100))+''' '
            
    IF @TGBF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TGBF] = '''+CAST(@TGBF AS nvarchar(100))+''' '
            
    IF @DHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[DHF] = '''+CAST(@DHF AS nvarchar(100))+''' '
            
    IF @DSZNF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[DSZNF] = '''+CAST(@DSZNF AS nvarchar(100))+''' '
            
    IF @FNWSHLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[FNWSHLF] = '''+CAST(@FNWSHLF AS nvarchar(100))+''' '
            
    IF @HLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[HLF] = '''+CAST(@HLF AS nvarchar(100))+''' '
            
    IF @JJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JJ] = '''+CAST(@JJ AS nvarchar(100))+''' '
            
    IF @JTF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JTF] = '''+CAST(@JTF AS nvarchar(100))+''' '
            
    IF @JHLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JHLGZ] = '''+CAST(@JHLGZ AS nvarchar(100))+''' '
            
    IF @JT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JT] = '''+CAST(@JT AS nvarchar(100))+''' '
            
    IF @BF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[BF] = '''+CAST(@BF AS nvarchar(100))+''' '
            
    IF @QTBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[QTBT] = '''+CAST(@QTBT AS nvarchar(100))+''' '
            
    IF @DFXJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[DFXJT] = '''+CAST(@DFXJT AS nvarchar(100))+''' '
            
    IF @YFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YFX] = '''+CAST(@YFX AS nvarchar(100))+''' '
            
    IF @YFXBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YFX] >= '''+CAST(@YFXBegin AS nvarchar(100))+''' '
    IF @YFXEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YFX] <= '''+CAST(@YFXEnd AS nvarchar(100))+''' '
        
    IF @QTKK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[QTKK] = '''+CAST(@QTKK AS nvarchar(100))+''' '
            
    IF @SYBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SYBX] = '''+CAST(@SYBX AS nvarchar(100))+''' '
            
    IF @SDNQF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SDNQF] = '''+CAST(@SDNQF AS nvarchar(100))+''' '
            
    IF @SDS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SDS] = '''+CAST(@SDS AS nvarchar(100))+''' '
            
    IF @YLBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YLBX] = '''+CAST(@YLBX AS nvarchar(100))+''' '
            
    IF @YLIBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YLIBX] = '''+CAST(@YLIBX AS nvarchar(100))+''' '
            
    IF @YSSHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YSSHF] = '''+CAST(@YSSHF AS nvarchar(100))+''' '
            
    IF @ZFGJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[ZFGJJ] = '''+CAST(@ZFGJJ AS nvarchar(100))+''' '
            
    IF @KFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[KFX] = '''+CAST(@KFX AS nvarchar(100))+''' '
            
    IF @SFGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFGZ] = '''+CAST(@SFGZ AS nvarchar(100))+''' '
            
    IF @SFGZBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFGZ] >= '''+CAST(@SFGZBegin AS nvarchar(100))+''' '
    IF @SFGZEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFGZ] <= '''+CAST(@SFGZEnd AS nvarchar(100))+''' '
        
    IF @GZKKSM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[GZKKSM] = '''+CAST(@GZKKSM AS nvarchar(100))+''' '
            
    IF @TJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TJSJ] = '''+CAST(@TJSJ AS nvarchar(100))+''' '
            
    IF @TJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TJSJ] >= '''+CAST(@TJSJBegin AS nvarchar(100))+''' '
    IF @TJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TJSJ] <= '''+CAST(@TJSJEnd AS nvarchar(100))+''' '
        
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + '

      [dbo].[T_BM_GZXX].[ObjectID]
        
      , [dbo].[T_BM_GZXX].[XM]
        
      , [dbo].[T_BM_GZXX].[XB]
        
      , [dbo].[T_BM_GZXX].[SFZH]
        
      , [dbo].[T_BM_GZXX].[FFGZNY]
        
      , [dbo].[T_BM_GZXX].[JCGZ]
        
      , [dbo].[T_BM_GZXX].[JSDJGZ]
        
      , [dbo].[T_BM_GZXX].[ZWGZ]
        
      , [dbo].[T_BM_GZXX].[JBGZ]
        
      , [dbo].[T_BM_GZXX].[JKDQJT]
        
      , [dbo].[T_BM_GZXX].[JKTSGWJT]
        
      , [dbo].[T_BM_GZXX].[GLGZ]
        
      , [dbo].[T_BM_GZXX].[XJGZ]
        
      , [dbo].[T_BM_GZXX].[TGBF]
        
      , [dbo].[T_BM_GZXX].[DHF]
        
      , [dbo].[T_BM_GZXX].[DSZNF]
        
      , [dbo].[T_BM_GZXX].[FNWSHLF]
        
      , [dbo].[T_BM_GZXX].[HLF]
        
      , [dbo].[T_BM_GZXX].[JJ]
        
      , [dbo].[T_BM_GZXX].[JTF]
        
      , [dbo].[T_BM_GZXX].[JHLGZ]
        
      , [dbo].[T_BM_GZXX].[JT]
        
      , [dbo].[T_BM_GZXX].[BF]
        
      , [dbo].[T_BM_GZXX].[QTBT]
        
      , [dbo].[T_BM_GZXX].[DFXJT]
        
      , [dbo].[T_BM_GZXX].[YFX]
        
      , [dbo].[T_BM_GZXX].[QTKK]
        
      , [dbo].[T_BM_GZXX].[SYBX]
        
      , [dbo].[T_BM_GZXX].[SDNQF]
        
      , [dbo].[T_BM_GZXX].[SDS]
        
      , [dbo].[T_BM_GZXX].[YLBX]
        
      , [dbo].[T_BM_GZXX].[YLIBX]
        
      , [dbo].[T_BM_GZXX].[YSSHF]
        
      , [dbo].[T_BM_GZXX].[ZFGJJ]
        
      , [dbo].[T_BM_GZXX].[KFX]
        
      , [dbo].[T_BM_GZXX].[SFGZ]
        
      , [dbo].[T_BM_GZXX].[GZKKSM]
        
      , [dbo].[T_BM_GZXX].[TJSJ]
        
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
 FROM [dbo].[T_BM_GZXX]'
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
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_ObjectID_Batch ON '','' + [dbo].[T_BM_GZXX].[ObjectID] + '','' LIKE ''%,'' + T_BM_GZXX_ObjectID_Batch.col +'',%''
'
    
IF @XMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XMBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_XM_Batch ON '','' + [dbo].[T_BM_GZXX].[XM] + '','' LIKE ''%,'' + T_BM_GZXX_XM_Batch.col +'',%''
'
    
IF @XBBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XBBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_XB_Batch ON '','' + [dbo].[T_BM_GZXX].[XB] + '','' LIKE ''%,'' + T_BM_GZXX_XB_Batch.col +'',%''
'
    
IF @SFZHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SFZHBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_SFZH_Batch ON '','' + [dbo].[T_BM_GZXX].[SFZH] + '','' LIKE ''%,'' + T_BM_GZXX_SFZH_Batch.col +'',%''
'
    
IF @FFGZNYBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FFGZNYBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_FFGZNY_Batch ON '','' + [dbo].[T_BM_GZXX].[FFGZNY] + '','' LIKE ''%,'' + T_BM_GZXX_FFGZNY_Batch.col +'',%''
'
    
IF @JCGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JCGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JCGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[JCGZ] + '','' LIKE ''%,'' + T_BM_GZXX_JCGZ_Batch.col +'',%''
'
    
IF @JSDJGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JSDJGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JSDJGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[JSDJGZ] + '','' LIKE ''%,'' + T_BM_GZXX_JSDJGZ_Batch.col +'',%''
'
    
IF @ZWGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ZWGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_ZWGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[ZWGZ] + '','' LIKE ''%,'' + T_BM_GZXX_ZWGZ_Batch.col +'',%''
'
    
IF @JBGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JBGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JBGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[JBGZ] + '','' LIKE ''%,'' + T_BM_GZXX_JBGZ_Batch.col +'',%''
'
    
IF @JKDQJTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JKDQJTBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JKDQJT_Batch ON '','' + [dbo].[T_BM_GZXX].[JKDQJT] + '','' LIKE ''%,'' + T_BM_GZXX_JKDQJT_Batch.col +'',%''
'
    
IF @JKTSGWJTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JKTSGWJTBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JKTSGWJT_Batch ON '','' + [dbo].[T_BM_GZXX].[JKTSGWJT] + '','' LIKE ''%,'' + T_BM_GZXX_JKTSGWJT_Batch.col +'',%''
'
    
IF @GLGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@GLGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_GLGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[GLGZ] + '','' LIKE ''%,'' + T_BM_GZXX_GLGZ_Batch.col +'',%''
'
    
IF @XJGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XJGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_XJGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[XJGZ] + '','' LIKE ''%,'' + T_BM_GZXX_XJGZ_Batch.col +'',%''
'
    
IF @TGBFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@TGBFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_TGBF_Batch ON '','' + [dbo].[T_BM_GZXX].[TGBF] + '','' LIKE ''%,'' + T_BM_GZXX_TGBF_Batch.col +'',%''
'
    
IF @DHFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DHFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_DHF_Batch ON '','' + [dbo].[T_BM_GZXX].[DHF] + '','' LIKE ''%,'' + T_BM_GZXX_DHF_Batch.col +'',%''
'
    
IF @DSZNFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DSZNFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_DSZNF_Batch ON '','' + [dbo].[T_BM_GZXX].[DSZNF] + '','' LIKE ''%,'' + T_BM_GZXX_DSZNF_Batch.col +'',%''
'
    
IF @FNWSHLFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@FNWSHLFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_FNWSHLF_Batch ON '','' + [dbo].[T_BM_GZXX].[FNWSHLF] + '','' LIKE ''%,'' + T_BM_GZXX_FNWSHLF_Batch.col +'',%''
'
    
IF @HLFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@HLFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_HLF_Batch ON '','' + [dbo].[T_BM_GZXX].[HLF] + '','' LIKE ''%,'' + T_BM_GZXX_HLF_Batch.col +'',%''
'
    
IF @JJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JJBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JJ_Batch ON '','' + [dbo].[T_BM_GZXX].[JJ] + '','' LIKE ''%,'' + T_BM_GZXX_JJ_Batch.col +'',%''
'
    
IF @JTFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JTFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JTF_Batch ON '','' + [dbo].[T_BM_GZXX].[JTF] + '','' LIKE ''%,'' + T_BM_GZXX_JTF_Batch.col +'',%''
'
    
IF @JHLGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JHLGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JHLGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[JHLGZ] + '','' LIKE ''%,'' + T_BM_GZXX_JHLGZ_Batch.col +'',%''
'
    
IF @JTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JTBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_JT_Batch ON '','' + [dbo].[T_BM_GZXX].[JT] + '','' LIKE ''%,'' + T_BM_GZXX_JT_Batch.col +'',%''
'
    
IF @BFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_BF_Batch ON '','' + [dbo].[T_BM_GZXX].[BF] + '','' LIKE ''%,'' + T_BM_GZXX_BF_Batch.col +'',%''
'
    
IF @QTBTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@QTBTBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_QTBT_Batch ON '','' + [dbo].[T_BM_GZXX].[QTBT] + '','' LIKE ''%,'' + T_BM_GZXX_QTBT_Batch.col +'',%''
'
    
IF @DFXJTBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@DFXJTBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_DFXJT_Batch ON '','' + [dbo].[T_BM_GZXX].[DFXJT] + '','' LIKE ''%,'' + T_BM_GZXX_DFXJT_Batch.col +'',%''
'
    
IF @YFXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YFXBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_YFX_Batch ON '','' + [dbo].[T_BM_GZXX].[YFX] + '','' LIKE ''%,'' + T_BM_GZXX_YFX_Batch.col +'',%''
'
    
IF @QTKKBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@QTKKBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_QTKK_Batch ON '','' + [dbo].[T_BM_GZXX].[QTKK] + '','' LIKE ''%,'' + T_BM_GZXX_QTKK_Batch.col +'',%''
'
    
IF @SYBXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SYBXBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_SYBX_Batch ON '','' + [dbo].[T_BM_GZXX].[SYBX] + '','' LIKE ''%,'' + T_BM_GZXX_SYBX_Batch.col +'',%''
'
    
IF @SDNQFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SDNQFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_SDNQF_Batch ON '','' + [dbo].[T_BM_GZXX].[SDNQF] + '','' LIKE ''%,'' + T_BM_GZXX_SDNQF_Batch.col +'',%''
'
    
IF @SDSBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SDSBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_SDS_Batch ON '','' + [dbo].[T_BM_GZXX].[SDS] + '','' LIKE ''%,'' + T_BM_GZXX_SDS_Batch.col +'',%''
'
    
IF @YLBXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YLBXBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_YLBX_Batch ON '','' + [dbo].[T_BM_GZXX].[YLBX] + '','' LIKE ''%,'' + T_BM_GZXX_YLBX_Batch.col +'',%''
'
    
IF @YLIBXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YLIBXBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_YLIBX_Batch ON '','' + [dbo].[T_BM_GZXX].[YLIBX] + '','' LIKE ''%,'' + T_BM_GZXX_YLIBX_Batch.col +'',%''
'
    
IF @YSSHFBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@YSSHFBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_YSSHF_Batch ON '','' + [dbo].[T_BM_GZXX].[YSSHF] + '','' LIKE ''%,'' + T_BM_GZXX_YSSHF_Batch.col +'',%''
'
    
IF @ZFGJJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ZFGJJBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_ZFGJJ_Batch ON '','' + [dbo].[T_BM_GZXX].[ZFGJJ] + '','' LIKE ''%,'' + T_BM_GZXX_ZFGJJ_Batch.col +'',%''
'
    
IF @KFXBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@KFXBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_KFX_Batch ON '','' + [dbo].[T_BM_GZXX].[KFX] + '','' LIKE ''%,'' + T_BM_GZXX_KFX_Batch.col +'',%''
'
    
IF @SFGZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SFGZBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_SFGZ_Batch ON '','' + [dbo].[T_BM_GZXX].[SFGZ] + '','' LIKE ''%,'' + T_BM_GZXX_SFGZ_Batch.col +'',%''
'
    
IF @GZKKSMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@GZKKSMBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_GZKKSM_Batch ON '','' + [dbo].[T_BM_GZXX].[GZKKSM] + '','' LIKE ''%,'' + T_BM_GZXX_GZKKSM_Batch.col +'',%''
'
    
IF @TJSJBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@TJSJBatch AS nvarchar(4000))+''', '','') AS T_BM_GZXX_TJSJ_Batch ON '','' + [dbo].[T_BM_GZXX].[TJSJ] + '','' LIKE ''%,'' + T_BM_GZXX_TJSJ_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_BM_GZXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_GZXX].[ObjectID]
' + @FromText + '
WHERE ' + @ConditionText + ' ' + @SortText + '
)'

SET @SqlTextCount = 'SELECT @RecordCount=COUNT(*) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

SET @SqlTextYFXSum = 'SELECT @YFXSum = SUM([dbo].[T_BM_GZXX].[YFX]) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextYFXSum,N'@YFXSum Float OUTPUT',@YFXSum OUTPUT   --返回@YFXSum
SET @SqlTextSFGZSum = 'SELECT @SFGZSum = SUM([dbo].[T_BM_GZXX].[SFGZ]) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextSFGZSum,N'@SFGZSum Float OUTPUT',@SFGZSum OUTPUT   --返回@SFGZSum

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_GZXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_GZXXByObjectID]
GO

--表T_BM_GZXX以ObjectID为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_GZXXByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_BM_GZXX].[ObjectID]
    
      , [dbo].[T_BM_GZXX].[XM]
    
      , [dbo].[T_BM_GZXX].[XB]
    
      , [dbo].[T_BM_GZXX].[SFZH]
    
      , [dbo].[T_BM_GZXX].[FFGZNY]
    
      , [dbo].[T_BM_GZXX].[JCGZ]
    
      , [dbo].[T_BM_GZXX].[JSDJGZ]
    
      , [dbo].[T_BM_GZXX].[ZWGZ]
    
      , [dbo].[T_BM_GZXX].[JBGZ]
    
      , [dbo].[T_BM_GZXX].[JKDQJT]
    
      , [dbo].[T_BM_GZXX].[JKTSGWJT]
    
      , [dbo].[T_BM_GZXX].[GLGZ]
    
      , [dbo].[T_BM_GZXX].[XJGZ]
    
      , [dbo].[T_BM_GZXX].[TGBF]
    
      , [dbo].[T_BM_GZXX].[DHF]
    
      , [dbo].[T_BM_GZXX].[DSZNF]
    
      , [dbo].[T_BM_GZXX].[FNWSHLF]
    
      , [dbo].[T_BM_GZXX].[HLF]
    
      , [dbo].[T_BM_GZXX].[JJ]
    
      , [dbo].[T_BM_GZXX].[JTF]
    
      , [dbo].[T_BM_GZXX].[JHLGZ]
    
      , [dbo].[T_BM_GZXX].[JT]
    
      , [dbo].[T_BM_GZXX].[BF]
    
      , [dbo].[T_BM_GZXX].[QTBT]
    
      , [dbo].[T_BM_GZXX].[DFXJT]
    
      , [dbo].[T_BM_GZXX].[YFX]
    
      , [dbo].[T_BM_GZXX].[QTKK]
    
      , [dbo].[T_BM_GZXX].[SYBX]
    
      , [dbo].[T_BM_GZXX].[SDNQF]
    
      , [dbo].[T_BM_GZXX].[SDS]
    
      , [dbo].[T_BM_GZXX].[YLBX]
    
      , [dbo].[T_BM_GZXX].[YLIBX]
    
      , [dbo].[T_BM_GZXX].[YSSHF]
    
      , [dbo].[T_BM_GZXX].[ZFGJJ]
    
      , [dbo].[T_BM_GZXX].[KFX]
    
      , [dbo].[T_BM_GZXX].[SFGZ]
    
      , [dbo].[T_BM_GZXX].[GZKKSM]
    
      , [dbo].[T_BM_GZXX].[TJSJ]
    
FROM [dbo].[T_BM_GZXX]

WHERE
[dbo].[T_BM_GZXX].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_GZXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_GZXXByKey]
GO

--表T_BM_GZXX以主键为条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_GZXXByKey] 

@SFZH NVarChar(18) = NULL
, @FFGZNY NVarChar(6) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [XM]
    
      , [XB]
    
      , [SFZH]
    
      , [FFGZNY]
    
      , [JCGZ]
    
      , [JSDJGZ]
    
      , [ZWGZ]
    
      , [JBGZ]
    
      , [JKDQJT]
    
      , [JKTSGWJT]
    
      , [GLGZ]
    
      , [XJGZ]
    
      , [TGBF]
    
      , [DHF]
    
      , [DSZNF]
    
      , [FNWSHLF]
    
      , [HLF]
    
      , [JJ]
    
      , [JTF]
    
      , [JHLGZ]
    
      , [JT]
    
      , [BF]
    
      , [QTBT]
    
      , [DFXJT]
    
      , [YFX]
    
      , [QTKK]
    
      , [SYBX]
    
      , [SDNQF]
    
      , [SDS]
    
      , [YLBX]
    
      , [YLIBX]
    
      , [YSSHF]
    
      , [ZFGJJ]
    
      , [KFX]
    
      , [SFGZ]
    
      , [GZKKSM]
    
      , [TJSJ]
    
FROM [dbo].[T_BM_GZXX]
WHERE

[SFZH] = @SFZH
AND [FFGZNY] = @FFGZNY

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_GZXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_GZXXByObjectID]
GO

--表[T_BM_GZXX]以ObjectID为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_GZXXByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_BM_GZXX]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_BM_GZXXByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_BM_GZXXByKey]
GO

--表[T_BM_GZXX]以主键为条件判断记录是否存在的存储过程

CREATE   PROCEDURE [dbo].[SP_IsExistT_BM_GZXXByKey] 

@SFZH NVarChar(18) = NULL
, @FFGZNY NVarChar(6) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_BM_GZXX]
WHERE 

[SFZH] = @SFZH
AND [FFGZNY] = @FFGZNY

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_BM_GZXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_BM_GZXXByAnyCondition]
GO

--表T_BM_GZXX任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_BM_GZXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_GZXX].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和

SET @SelectListText = @SelectListText + ', SUM([dbo].[T_BM_GZXX].[YFX]) AS YFXSum '
SET @SelectListText = @SelectListText + ', SUM([dbo].[T_BM_GZXX].[SFGZ]) AS SFGZSum '


--主表
SET @FromText = '
 FROM [dbo].[T_BM_GZXX]'
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


