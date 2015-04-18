/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertDictionary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertDictionary]
GO

--��Dictionary����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryByAnyCondition]
GO

--��Dictionary�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��Dictionary��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��Dictionary������Ϊ�������µĴ洢����

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
    --�������
    
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

--��Dictionary��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��Dictionary��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��Dictionary������Ϊ����ɾ���Ĵ洢����

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

--��Dictionary��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��Dictionary����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[Dictionary].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[DM] LIKE '''+CAST(@DM AS nvarchar(100))+'%'' '
        
    IF @LX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[LX] LIKE '''+CAST(@LX AS nvarchar(100))+'%'' '
        
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[MC] LIKE '''+CAST(@MC AS nvarchar(100))+'%'' '
        
    IF @SJDM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[SJDM] LIKE '''+CAST(@SJDM AS nvarchar(100))+'%'' '
        
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[Dictionary].[SM] LIKE '''+CAST(@SM AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[LX_DictionaryType].[MC] AS [LX_DictionaryType_MC]
        ,[SJDM_Dictionary].[MC] AS [SJDM_Dictionary_MC]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[Dictionary]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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
    
--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[Dictionary].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[Dictionary].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryByObjectID]
GO

--��Dictionary��ObjectIDΪ������ѯ�Ĵ洢����

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

--��Dictionary������Ϊ������ѯ�Ĵ洢����

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

--��[Dictionary]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[Dictionary]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��Dictionary��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountDictionaryByAnyCondition] 
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
SET @ConditionText = ' [dbo].[Dictionary].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[Dictionary]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[DictionaryType] AS [LX_DictionaryType] ON [LX_DictionaryType].[DM] = [dbo].[Dictionary].[LX]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [SJDM_Dictionary] ON [SJDM_Dictionary].[DM] = [dbo].[Dictionary].[SJDM]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertDictionaryType]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertDictionaryType]
GO

--��DictionaryType����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateDictionaryTypeByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateDictionaryTypeByAnyCondition]
GO

--��DictionaryType�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��DictionaryType��ObjectIDΪ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByObjectID] 

@ObjectID nvarchar(50) = NULL
,@DM NVarChar(10) = NULL
,@MC NVarChar(50) = NULL
,@SM NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --�������
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

--��DictionaryType������Ϊ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByKey] 

@ObjectID nvarchar(50) = NULL
,@DM NVarChar(10) = NULL
,@MC NVarChar(50) = NULL
,@SM NVarChar(255) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --�������
    
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

--��DictionaryType��ObjectIDΪ�����������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateDictionaryTypeByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@DM NVarChar(10) = NULL

,@MC NVarChar(50) = NULL

,@SM NVarChar(255) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --�������
    
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

--��DictionaryType��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryTypeByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��DictionaryType������Ϊ����ɾ���Ĵ洢����

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

--��DictionaryType��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteDictionaryTypeByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��DictionaryType����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectDictionaryTypeByAnyCondition] 
--�������

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @DM NVarChar(10) = NULL
        
, @DMBatch nvarchar(4000) = NULL

, @MC NVarChar(50) = NULL
        
, @MCBatch nvarchar(4000) = NULL

, @SM NVarChar(255) = NULL
        
, @SMBatch nvarchar(4000) = NULL

--һ��һ��ر����

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
    --�����ѯ����
    SET @ConditionText = '( [dbo].[DictionaryType].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[DM] = '''+CAST(@DM AS nvarchar(100))+''' '
            
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[MC] = '''+CAST(@MC AS nvarchar(100))+''' '
            
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[DictionaryType].[SM] = '''+CAST(@SM AS nvarchar(100))+''' '
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[DictionaryType].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @DM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[DM] LIKE '''+CAST(@DM AS nvarchar(100))+'%'' '
        
    IF @MC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[MC] LIKE '''+CAST(@MC AS nvarchar(100))+'%'' '
        
    IF @SM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[DictionaryType].[SM] LIKE '''+CAST(@SM AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + '

      [dbo].[DictionaryType].[ObjectID]
        
      , [dbo].[DictionaryType].[DM]
        
      , [dbo].[DictionaryType].[MC]
        
      , [dbo].[DictionaryType].[SM]
        
'
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[DictionaryType]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[DictionaryType].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[DictionaryType].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectDictionaryTypeByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectDictionaryTypeByObjectID]
GO

--��DictionaryType��ObjectIDΪ������ѯ�Ĵ洢����

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

--��DictionaryType������Ϊ������ѯ�Ĵ洢����

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

--��[DictionaryType]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[DictionaryType]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��DictionaryType��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountDictionaryTypeByAnyCondition] 
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
SET @ConditionText = ' [dbo].[DictionaryType].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[DictionaryType]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertFilterReport]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertFilterReport]
GO

--��FilterReport����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateFilterReportByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateFilterReportByAnyCondition]
GO

--��FilterReport�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��FilterReport��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��FilterReport������Ϊ�������µĴ洢����

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
    --�������
    
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

--��FilterReport��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��FilterReport��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteFilterReportByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��FilterReport������Ϊ����ɾ���Ĵ洢����

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

--��FilterReport��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteFilterReportByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��FilterReport����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectFilterReportByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[FilterReport].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @BGMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGMC] LIKE '''+CAST(@BGMC AS nvarchar(100))+'%'' '
        
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[UserID] LIKE '''+CAST(@UserID AS nvarchar(100))+'%'' '
        
    IF @BGLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGLX] LIKE '''+CAST(@BGLX AS nvarchar(100))+'%'' '
        
    IF @GXBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[GXBG] LIKE '''+CAST(@GXBG AS nvarchar(100))+'%'' '
        
    IF @XTBG IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[XTBG] LIKE '''+CAST(@XTBG AS nvarchar(100))+'%'' '
        
    IF @BGCXTJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGCXTJ] LIKE '''+CAST(@BGCXTJ AS nvarchar(100))+'%'' '
        
    IF @BGCJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[FilterReport].[BGCJSJ] LIKE '''+CAST(@BGCJSJ AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[UserID_T_PM_UserInfo].[UserLoginName] AS [UserID_T_PM_UserInfo_UserLoginName]
        ,[GXBG_Dictionary].[MC] AS [GXBG_Dictionary_MC]
        ,[XTBG_Dictionary].[MC] AS [XTBG_Dictionary_MC]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[FilterReport]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS UserID_T_PM_UserInfo ON UserID_T_PM_UserInfo.[UserID] = [dbo].[FilterReport].[UserID] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS GXBG_Dictionary ON GXBG_Dictionary.[DM] = [dbo].[FilterReport].[GXBG]  AND GXBG_Dictionary.[LX] = ''0004''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS XTBG_Dictionary ON XTBG_Dictionary.[DM] = [dbo].[FilterReport].[XTBG]  AND XTBG_Dictionary.[LX] = ''0004''
'
	
--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[FilterReport].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[FilterReport].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectFilterReportByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectFilterReportByObjectID]
GO

--��FilterReport��ObjectIDΪ������ѯ�Ĵ洢����

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

--��FilterReport������Ϊ������ѯ�Ĵ洢����

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

--��[FilterReport]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[FilterReport]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��FilterReport��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountFilterReportByAnyCondition] 
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
SET @ConditionText = ' [dbo].[FilterReport].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[FilterReport]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [UserID_T_PM_UserInfo] ON [UserID_T_PM_UserInfo].[UserID] = [dbo].[FilterReport].[UserID]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [GXBG_Dictionary] ON [GXBG_Dictionary].[DM] = [dbo].[FilterReport].[GXBG]  AND GXBG_Dictionary.[LX] = ''0004'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [XTBG_Dictionary] ON [XTBG_Dictionary].[DM] = [dbo].[FilterReport].[XTBG]  AND XTBG_Dictionary.[LX] = ''0004'' 
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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertShortMessage]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertShortMessage]
GO

--��ShortMessage����Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_InsertShortMessage] 

@ObjectID UniqueIdentifier 
,@DXXBT NVarChar (100)
,@DXXLX NVarChar (2)  = NULL
,@DXXNR NText   = NULL
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
    --����������Ϣ
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
    
    --ͬ���������
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateShortMessageByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateShortMessageByAnyCondition]
GO

--��ShortMessage�����������µĴ洢����

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

, @DXXNR nvarchar(100) = NULL
        
, @DXXNRValue NText = NULL
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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��ShortMessage��ObjectIDΪ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByObjectID] 

@ObjectID nvarchar(50) = NULL
,@DXXBT NVarChar(100) = NULL
,@DXXLX NVarChar(2) = NULL
,@DXXNR NText = NULL
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
    --������ر���Ϣ
    
    --�������
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

--��ShortMessage������Ϊ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByKey] 

@ObjectID nvarchar(50) = NULL
,@DXXBT NVarChar(100) = NULL
,@DXXLX NVarChar(2) = NULL
,@DXXNR NText = NULL
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
    --�������
    
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

--��ShortMessage��ObjectIDΪ�����������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateShortMessageByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@DXXBT NVarChar(100) = NULL

,@DXXLX NVarChar(2) = NULL

,@DXXNR NText = NULL

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
    --������ر���Ϣ
    
    --�������
    
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

--��ShortMessage��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteShortMessageByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��ShortMessage������Ϊ����ɾ���Ĵ洢����

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

--��ShortMessage��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteShortMessageByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��ShortMessage����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectShortMessageByAnyCondition] 
--�������

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @DXXBT NVarChar(100) = NULL
        
, @DXXBTBatch nvarchar(4000) = NULL

, @DXXLX NVarChar(2) = NULL
        
, @DXXLXBatch nvarchar(4000) = NULL

, @DXXNR nvarchar(100) = NULL
        
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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[ShortMessage].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @DXXBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXBT] LIKE '''+CAST(@DXXBT AS nvarchar(100))+'%'' '
        
    IF @DXXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXLX] LIKE '''+CAST(@DXXLX AS nvarchar(100))+'%'' '
        
    IF @DXXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXNR] LIKE '''+CAST(@DXXNR AS nvarchar(100))+'%'' '
        
    IF @DXXFJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[DXXFJ] LIKE '''+CAST(@DXXFJ AS nvarchar(100))+'%'' '
        
    IF @FSSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSSJ] = '''+CAST(@FSSJ AS nvarchar(100))+''' '
    IF @FSSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSSJ] >= '''+CAST(@FSSJBegin AS nvarchar(100))+''' '
    IF @FSSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSSJ] <= '''+CAST(@FSSJEnd AS nvarchar(100))+''' '
        
    IF @FSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSR] LIKE '''+CAST(@FSR AS nvarchar(100))+'%'' '
        
    IF @FSBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSBM] LIKE '''+CAST(@FSBM AS nvarchar(100))+'%'' '
        
    IF @FSIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[FSIP] LIKE '''+CAST(@FSIP AS nvarchar(100))+'%'' '
        
    IF @JSR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[JSR] LIKE '''+CAST(@JSR AS nvarchar(100))+'%'' '
        
    IF @SFCK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[SFCK] LIKE '''+CAST(@SFCK AS nvarchar(100))+'%'' '
        
    IF @CKSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[ShortMessage].[CKSJ] LIKE '''+CAST(@CKSJ AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + '

      [dbo].[ShortMessage].[ObjectID]
        
      , [dbo].[ShortMessage].[DXXBT]
        
      , [dbo].[ShortMessage].[DXXLX]
        
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[FSR_T_PM_UserInfo].[UserNickName] AS [FSR_T_PM_UserInfo_UserNickName]
        ,[FSBM_T_BM_DWXX].[DWMC] AS [FSBM_T_BM_DWXX_DWMC]
        ,[dbo].[F_ShortMessage_GetUserNickNameByJSR]([dbo].[ShortMessage].[JSR]) AS [JSR_T_PM_UserInfo_UserNickName]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[ShortMessage]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS FSR_T_PM_UserInfo ON FSR_T_PM_UserInfo.[UserID] = [dbo].[ShortMessage].[FSR] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS FSBM_T_BM_DWXX ON FSBM_T_BM_DWXX.[DWBH] = [dbo].[ShortMessage].[FSBM] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS JSR_T_PM_UserInfo ON JSR_T_PM_UserInfo.[UserID] = [dbo].[ShortMessage].[JSR] 
'
	
--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[ShortMessage].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[ShortMessage].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectShortMessageByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectShortMessageByObjectID]
GO

--��ShortMessage��ObjectIDΪ������ѯ�Ĵ洢����

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

--��ShortMessage������Ϊ������ѯ�Ĵ洢����

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

--��[ShortMessage]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[ShortMessage]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��ShortMessage��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountShortMessageByAnyCondition] 
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
SET @ConditionText = ' [dbo].[ShortMessage].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[ShortMessage]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [FSR_T_PM_UserInfo] ON [FSR_T_PM_UserInfo].[UserID] = [dbo].[ShortMessage].[FSR]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS [FSBM_T_BM_DWXX] ON [FSBM_T_BM_DWXX].[DWBH] = [dbo].[ShortMessage].[FSBM]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserInfo] AS [JSR_T_PM_UserInfo] ON '','' + [dbo].[ShortMessage].[JSR] + '','' LIKE ''%,'' + [JSR_T_PM_UserInfo].[UserID] + '',%'' 
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BG_0601]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BG_0601]
GO

--��T_BG_0601����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BG_0601ByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BG_0601ByAnyCondition]
GO

--��T_BG_0601�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��T_BG_0601��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��T_BG_0601������Ϊ�������µĴ洢����

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
    --�������
    
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

--��T_BG_0601��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��T_BG_0601��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0601ByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��T_BG_0601������Ϊ����ɾ���Ĵ洢����

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

--��T_BG_0601��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BG_0601ByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��T_BG_0601����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_BG_0601ByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_BG_0601].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @FBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBH] LIKE '''+CAST(@FBH AS nvarchar(100))+'%'' '
        
    IF @BT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[BT] LIKE '''+CAST(@BT AS nvarchar(100))+'%'' '
        
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[LanguageID] LIKE '''+CAST(@LanguageID AS nvarchar(100))+'%'' '
        
    IF @FBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBLM] LIKE '''+CAST(@FBLM AS nvarchar(100))+'%'' '
        
    IF @FBBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBBM] LIKE '''+CAST(@FBBM AS nvarchar(100))+'%'' '
        
    IF @FBZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBZT] LIKE '''+CAST(@FBZT AS nvarchar(100))+'%'' '
        
    IF @XXLX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXLX] LIKE '''+CAST(@XXLX AS nvarchar(100))+'%'' '
        
    IF @XXTPDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXTPDZ] LIKE '''+CAST(@XXTPDZ AS nvarchar(100))+'%'' '
        
    IF @XXNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXNR] LIKE '''+CAST(@XXNR AS nvarchar(100))+'%'' '
        
    IF @FJXZDZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FJXZDZ] LIKE '''+CAST(@FJXZDZ AS nvarchar(100))+'%'' '
        
    IF @PZRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[PZRJGH] LIKE '''+CAST(@PZRJGH AS nvarchar(100))+'%'' '
        
    IF @XXZT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[XXZT] LIKE '''+CAST(@XXZT AS nvarchar(100))+'%'' '
        
    IF @IsTop IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[IsTop] LIKE '''+CAST(@IsTop AS nvarchar(100))+'%'' '
        
    IF @TopSort IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[TopSort] LIKE '''+CAST(@TopSort AS nvarchar(100))+'%'' '
        
    IF @IsBest IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[IsBest] LIKE '''+CAST(@IsBest AS nvarchar(100))+'%'' '
        
    IF @YXSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[YXSJRQ] LIKE '''+CAST(@YXSJRQ AS nvarchar(100))+'%'' '
        
    IF @FBRJGH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBRJGH] LIKE '''+CAST(@FBRJGH AS nvarchar(100))+'%'' '
        
    IF @FBSJRQ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBSJRQ] = '''+CAST(@FBSJRQ AS nvarchar(100))+''' '
    IF @FBSJRQBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBSJRQ] >= '''+CAST(@FBSJRQBegin AS nvarchar(100))+''' '
    IF @FBSJRQEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBSJRQ] <= '''+CAST(@FBSJRQEnd AS nvarchar(100))+''' '
        
    IF @FBIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[FBIP] LIKE '''+CAST(@FBIP AS nvarchar(100))+'%'' '
        
    IF @LLCS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0601].[LLCS] LIKE '''+CAST(@LLCS AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[FBLM_T_BG_0602].[LMM] AS [FBLM_T_BG_0602_LMM]
        ,[FBBM_T_BM_DWXX].[DWMC] AS [FBBM_T_BM_DWXX_DWMC]
        ,[XXLX_Dictionary].[MC] AS [XXLX_Dictionary_MC]
        ,[XXZT_Dictionary].[MC] AS [XXZT_Dictionary_MC]
        ,[IsTop_Dictionary].[MC] AS [IsTop_Dictionary_MC]
        ,[IsBest_Dictionary].[MC] AS [IsBest_Dictionary_MC]
        ,[FBRJGH_T_PM_UserInfo].[UserNickName] AS [FBRJGH_T_PM_UserInfo_UserNickName]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_BG_0601]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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
	
--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_BG_0601].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BG_0601].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BG_0601ByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BG_0601ByObjectID]
GO

--��T_BG_0601��ObjectIDΪ������ѯ�Ĵ洢����

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

--��T_BG_0601������Ϊ������ѯ�Ĵ洢����

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

--��[T_BG_0601]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[T_BG_0601]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��T_BG_0601��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_BG_0601ByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BG_0601].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[T_BG_0601]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BG_0601ByFBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BG_0601ByFBH]
GO

--��T_BG_0601��FBHΪ���������ֵ�Ĵ洢����

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
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @LMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMH] LIKE '''+CAST(@LMH AS nvarchar(100))+'%'' '
        
    IF @LanguageID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LanguageID] LIKE '''+CAST(@LanguageID AS nvarchar(100))+'%'' '
        
    IF @LMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMM] LIKE '''+CAST(@LMM AS nvarchar(100))+'%'' '
        
    IF @SJLMH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[SJLMH] LIKE '''+CAST(@SJLMH AS nvarchar(100))+'%'' '
        
    IF @LMTP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMTP] LIKE '''+CAST(@LMTP AS nvarchar(100))+'%'' '
        
    IF @LMNR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMNR] LIKE '''+CAST(@LMNR AS nvarchar(100))+'%'' '
        
    IF @LMLBYS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[LMLBYS] LIKE '''+CAST(@LMLBYS AS nvarchar(100))+'%'' '
        
    IF @SFLBLM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[SFLBLM] LIKE '''+CAST(@SFLBLM AS nvarchar(100))+'%'' '
        
    IF @SFWBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[SFWBURL] LIKE '''+CAST(@SFWBURL AS nvarchar(100))+'%'' '
        
    IF @WBURL IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BG_0602].[WBURL] LIKE '''+CAST(@WBURL AS nvarchar(100))+'%'' '
        
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_DWXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_DWXX]
GO

--��T_BM_DWXX����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_DWXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_DWXXByAnyCondition]
GO

--��T_BM_DWXX�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��T_BM_DWXX��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��T_BM_DWXX������Ϊ�������µĴ洢����

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
    --�������
    
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

--��T_BM_DWXX��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��T_BM_DWXX��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_DWXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��T_BM_DWXX������Ϊ����ɾ���Ĵ洢����

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

--��T_BM_DWXX��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_DWXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��T_BM_DWXX����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_DWXXByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_BM_DWXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @DWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[DWBH] LIKE '''+CAST(@DWBH AS nvarchar(100))+'%'' '
        
    IF @DWMC IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[DWMC] LIKE '''+CAST(@DWMC AS nvarchar(100))+'%'' '
        
    IF @SJDWBH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[SJDWBH] LIKE '''+CAST(@SJDWBH AS nvarchar(100))+'%'' '
        
    IF @DZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[DZ] LIKE '''+CAST(@DZ AS nvarchar(100))+'%'' '
        
    IF @YB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[YB] LIKE '''+CAST(@YB AS nvarchar(100))+'%'' '
        
    IF @LXBM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[LXBM] LIKE '''+CAST(@LXBM AS nvarchar(100))+'%'' '
        
    IF @LXDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[LXDH] LIKE '''+CAST(@LXDH AS nvarchar(100))+'%'' '
        
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[Email] LIKE '''+CAST(@Email AS nvarchar(100))+'%'' '
        
    IF @LXR IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[LXR] LIKE '''+CAST(@LXR AS nvarchar(100))+'%'' '
        
    IF @SJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_DWXX].[SJ] LIKE '''+CAST(@SJ AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[SJDWBH_T_BM_DWXX].[DWMC] AS [SJDWBH_T_BM_DWXX_DWMC]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_BM_DWXX]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS SJDWBH_T_BM_DWXX ON SJDWBH_T_BM_DWXX.[DWBH] = [dbo].[T_BM_DWXX].[SJDWBH] 
'
	
--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_BM_DWXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_DWXX].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_BM_DWXXByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_BM_DWXXByObjectID]
GO

--��T_BM_DWXX��ObjectIDΪ������ѯ�Ĵ洢����

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

--��T_BM_DWXX������Ϊ������ѯ�Ĵ洢����

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

--��[T_BM_DWXX]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[T_BM_DWXX]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��T_BM_DWXX��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_BM_DWXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_DWXX].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[T_BM_DWXX]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS [SJDWBH_T_BM_DWXX] ON [SJDWBH_T_BM_DWXX].[DWBH] = [dbo].[T_BM_DWXX].[SJDWBH]  
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_BM_DWXXByDWBH]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_BM_DWXXByDWBH]
GO

--��T_BM_DWXX��DWBHΪ���������ֵ�Ĵ洢����

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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_BM_GZXX]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_BM_GZXX]
GO

--��T_BM_GZXX����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_BM_GZXXByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_BM_GZXXByAnyCondition]
GO

--��T_BM_GZXX�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��T_BM_GZXX��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��T_BM_GZXX������Ϊ�������µĴ洢����

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
    --�������
    
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

--��T_BM_GZXX��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��T_BM_GZXX��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_GZXXByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��T_BM_GZXX������Ϊ����ɾ���Ĵ洢����

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

--��T_BM_GZXX��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_BM_GZXXByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��T_BM_GZXX����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_BM_GZXXByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_BM_GZXX].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @XM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[XM] LIKE '''+CAST(@XM AS nvarchar(100))+'%'' '
        
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[XB] LIKE '''+CAST(@XB AS nvarchar(100))+'%'' '
        
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFZH] LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
        
    IF @FFGZNY IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[FFGZNY] LIKE '''+CAST(@FFGZNY AS nvarchar(100))+'%'' '
        
    IF @JCGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JCGZ] LIKE '''+CAST(@JCGZ AS nvarchar(100))+'%'' '
        
    IF @JSDJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JSDJGZ] LIKE '''+CAST(@JSDJGZ AS nvarchar(100))+'%'' '
        
    IF @ZWGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[ZWGZ] LIKE '''+CAST(@ZWGZ AS nvarchar(100))+'%'' '
        
    IF @JBGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JBGZ] LIKE '''+CAST(@JBGZ AS nvarchar(100))+'%'' '
        
    IF @JKDQJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JKDQJT] LIKE '''+CAST(@JKDQJT AS nvarchar(100))+'%'' '
        
    IF @JKTSGWJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JKTSGWJT] LIKE '''+CAST(@JKTSGWJT AS nvarchar(100))+'%'' '
        
    IF @GLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[GLGZ] LIKE '''+CAST(@GLGZ AS nvarchar(100))+'%'' '
        
    IF @XJGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[XJGZ] LIKE '''+CAST(@XJGZ AS nvarchar(100))+'%'' '
        
    IF @TGBF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TGBF] LIKE '''+CAST(@TGBF AS nvarchar(100))+'%'' '
        
    IF @DHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[DHF] LIKE '''+CAST(@DHF AS nvarchar(100))+'%'' '
        
    IF @DSZNF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[DSZNF] LIKE '''+CAST(@DSZNF AS nvarchar(100))+'%'' '
        
    IF @FNWSHLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[FNWSHLF] LIKE '''+CAST(@FNWSHLF AS nvarchar(100))+'%'' '
        
    IF @HLF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[HLF] LIKE '''+CAST(@HLF AS nvarchar(100))+'%'' '
        
    IF @JJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JJ] LIKE '''+CAST(@JJ AS nvarchar(100))+'%'' '
        
    IF @JTF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JTF] LIKE '''+CAST(@JTF AS nvarchar(100))+'%'' '
        
    IF @JHLGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JHLGZ] LIKE '''+CAST(@JHLGZ AS nvarchar(100))+'%'' '
        
    IF @JT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[JT] LIKE '''+CAST(@JT AS nvarchar(100))+'%'' '
        
    IF @BF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[BF] LIKE '''+CAST(@BF AS nvarchar(100))+'%'' '
        
    IF @QTBT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[QTBT] LIKE '''+CAST(@QTBT AS nvarchar(100))+'%'' '
        
    IF @DFXJT IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[DFXJT] LIKE '''+CAST(@DFXJT AS nvarchar(100))+'%'' '
        
    IF @YFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YFX] = '''+CAST(@YFX AS nvarchar(100))+''' '
    IF @YFXBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YFX] >= '''+CAST(@YFXBegin AS nvarchar(100))+''' '
    IF @YFXEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YFX] <= '''+CAST(@YFXEnd AS nvarchar(100))+''' '
        
    IF @QTKK IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[QTKK] LIKE '''+CAST(@QTKK AS nvarchar(100))+'%'' '
        
    IF @SYBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SYBX] LIKE '''+CAST(@SYBX AS nvarchar(100))+'%'' '
        
    IF @SDNQF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SDNQF] LIKE '''+CAST(@SDNQF AS nvarchar(100))+'%'' '
        
    IF @SDS IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SDS] LIKE '''+CAST(@SDS AS nvarchar(100))+'%'' '
        
    IF @YLBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YLBX] LIKE '''+CAST(@YLBX AS nvarchar(100))+'%'' '
        
    IF @YLIBX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YLIBX] LIKE '''+CAST(@YLIBX AS nvarchar(100))+'%'' '
        
    IF @YSSHF IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[YSSHF] LIKE '''+CAST(@YSSHF AS nvarchar(100))+'%'' '
        
    IF @ZFGJJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[ZFGJJ] LIKE '''+CAST(@ZFGJJ AS nvarchar(100))+'%'' '
        
    IF @KFX IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[KFX] LIKE '''+CAST(@KFX AS nvarchar(100))+'%'' '
        
    IF @SFGZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFGZ] = '''+CAST(@SFGZ AS nvarchar(100))+''' '
    IF @SFGZBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFGZ] >= '''+CAST(@SFGZBegin AS nvarchar(100))+''' '
    IF @SFGZEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[SFGZ] <= '''+CAST(@SFGZEnd AS nvarchar(100))+''' '
        
    IF @GZKKSM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[GZKKSM] LIKE '''+CAST(@GZKKSM AS nvarchar(100))+'%'' '
        
    IF @TJSJ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TJSJ] = '''+CAST(@TJSJ AS nvarchar(100))+''' '
    IF @TJSJBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TJSJ] >= '''+CAST(@TJSJBegin AS nvarchar(100))+''' '
    IF @TJSJEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_BM_GZXX].[TJSJ] <= '''+CAST(@TJSJEnd AS nvarchar(100))+''' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_BM_GZXX]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_BM_GZXX].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_BM_GZXX].[ObjectID]
' + @FromText + '
WHERE ' + @ConditionText + ' ' + @SortText + '
)'

SET @SqlTextCount = 'SELECT @RecordCount=COUNT(*) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextCount,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

SET @SqlTextYFXSum = 'SELECT @YFXSum = SUM([dbo].[T_BM_GZXX].[YFX]) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextYFXSum,N'@YFXSum Float OUTPUT',@YFXSum OUTPUT   --����@YFXSum
SET @SqlTextSFGZSum = 'SELECT @SFGZSum = SUM([dbo].[T_BM_GZXX].[SFGZ]) ' + @FromText + ' WHERE ' + @ConditionText
EXEC sp_executesql @SqlTextSFGZSum,N'@SFGZSum Float OUTPUT',@SFGZSum OUTPUT   --����@SFGZSum

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

--��T_BM_GZXX��ObjectIDΪ������ѯ�Ĵ洢����

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

--��T_BM_GZXX������Ϊ������ѯ�Ĵ洢����

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

--��[T_BM_GZXX]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[T_BM_GZXX]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��T_BM_GZXX��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_BM_GZXXByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_BM_GZXX].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����

SET @SelectListText = @SelectListText + ', SUM([dbo].[T_BM_GZXX].[YFX]) AS YFXSum '
SET @SelectListText = @SelectListText + ', SUM([dbo].[T_BM_GZXX].[SFGZ]) AS SFGZSum '


--����
SET @FromText = '
 FROM [dbo].[T_BM_GZXX]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_PM_PurviewInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_PM_PurviewInfo]
GO

--��T_PM_PurviewInfo����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_PurviewInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_PurviewInfoByAnyCondition]
GO

--��T_PM_PurviewInfo�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��T_PM_PurviewInfo��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��T_PM_PurviewInfo������Ϊ�������µĴ洢����

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
    --�������
    
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

--��T_PM_PurviewInfo��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��T_PM_PurviewInfo��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_PurviewInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��T_PM_PurviewInfo������Ϊ����ɾ���Ĵ洢����

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

--��T_PM_PurviewInfo��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_PurviewInfoByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��T_PM_PurviewInfo����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_PurviewInfoByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
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
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
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
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_PM_PurviewInfo]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_PM_PurviewInfo].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_PM_PurviewInfo].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_PurviewInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_PurviewInfoByObjectID]
GO

--��T_PM_PurviewInfo��ObjectIDΪ������ѯ�Ĵ洢����

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

--��T_PM_PurviewInfo������Ϊ������ѯ�Ĵ洢����

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

--��[T_PM_PurviewInfo]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[T_PM_PurviewInfo]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��T_PM_PurviewInfo��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_PM_PurviewInfoByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_PM_PurviewInfo].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[T_PM_PurviewInfo]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_PM_UserGroupInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_PM_UserGroupInfo]
GO

--��T_PM_UserGroupInfo����Ĵ洢����

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
    --����������Ϣ
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserGroupInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserGroupInfoByAnyCondition]
GO

--��T_PM_UserGroupInfo�����������µĴ洢����

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
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

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

--��T_PM_UserGroupInfo��ObjectIDΪ�������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
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

--��T_PM_UserGroupInfo������Ϊ�������µĴ洢����

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
    --�������
    
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

--��T_PM_UserGroupInfo��ObjectIDΪ�����������µĴ洢����

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
    --������ر���Ϣ
    
    --�������
    
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

--��T_PM_UserGroupInfo��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserGroupInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
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

--��T_PM_UserGroupInfo������Ϊ����ɾ���Ĵ洢����

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

--��T_PM_UserGroupInfo��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserGroupInfoByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
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

--��T_PM_UserGroupInfo����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserGroupInfoByAnyCondition] 
--�������

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

--һ��һ��ر����

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
    --�����ѯ����
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
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_PM_UserGroupInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupID] LIKE '''+CAST(@UserGroupID AS nvarchar(100))+'%'' '
        
    IF @UserGroupName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupName] LIKE '''+CAST(@UserGroupName AS nvarchar(100))+'%'' '
        
    IF @UserGroupContent IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupContent] LIKE '''+CAST(@UserGroupContent AS nvarchar(100))+'%'' '
        
    IF @UserGroupRemark IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UserGroupRemark] LIKE '''+CAST(@UserGroupRemark AS nvarchar(100))+'%'' '
        
    IF @DefaultPage IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[DefaultPage] LIKE '''+CAST(@DefaultPage AS nvarchar(100))+'%'' '
        
    IF @UpdateDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserGroupInfo].[UpdateDate] LIKE '''+CAST(@UpdateDate AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + '

      [dbo].[T_PM_UserGroupInfo].[ObjectID]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupID]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupName]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupContent]
        
      , [dbo].[T_PM_UserGroupInfo].[UserGroupRemark]
        
      , [dbo].[T_PM_UserGroupInfo].[DefaultPage]
        
      , [dbo].[T_PM_UserGroupInfo].[UpdateDate]
        
'
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_PM_UserGroupInfo]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

--�����ѯ

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
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_PM_UserGroupInfo].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_PM_UserGroupInfo].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserGroupInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserGroupInfoByObjectID]
GO

--��T_PM_UserGroupInfo��ObjectIDΪ������ѯ�Ĵ洢����

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

--��T_PM_UserGroupInfo������Ϊ������ѯ�Ĵ洢����

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

--��[T_PM_UserGroupInfo]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��[T_PM_UserGroupInfo]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

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

--��T_PM_UserGroupInfo��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_PM_UserGroupInfoByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_PM_UserGroupInfo].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[T_PM_UserGroupInfo]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

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


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_PM_UserInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_PM_UserInfo]
GO

--��T_PM_UserInfo����Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_InsertT_PM_UserInfo] 

@ObjectID UniqueIdentifier   = NULL
,@UserID NVarChar (50)
,@UserLoginName NVarChar (50)
,@UserGroupID NVarChar (500)
,@SubjectID NVarChar (50)
,@UserNickName NVarChar (50)
,@Password NVarChar (50)
,@XB NVarChar (2)
,@MZ NVarChar (2)
,@ZZMM NVarChar (2)
,@SFZH NVarChar (18)
,@SJH NVarChar (50)
,@BGDH NVarChar (50)  = NULL
,@JTDH NVarChar (50)  = NULL
,@Email NVarChar (50)  = NULL
,@QQH NVarChar (50)  = NULL
,@LoginTime DateTime   = NULL
,@LastLoginIP NVarChar (50)  = NULL
,@LastLoginDate DateTime   = NULL
,@LoginTimes Int   = NULL
,@UserStatus NVarChar (2)
,@vcode UniqueIdentifier   = NULL

AS

IF @ObjectID IS NULL
    SET @ObjectID = newid()
IF @UserID IS NULL
    SET @UserID = NULL
IF @UserLoginName IS NULL
    SET @UserLoginName = NULL
IF @UserGroupID IS NULL
    SET @UserGroupID = NULL
IF @SubjectID IS NULL
    SET @SubjectID = NULL
IF @UserNickName IS NULL
    SET @UserNickName = NULL
IF @Password IS NULL
    SET @Password = NULL
IF @XB IS NULL
    SET @XB = NULL
IF @MZ IS NULL
    SET @MZ = NULL
IF @ZZMM IS NULL
    SET @ZZMM = NULL
IF @SFZH IS NULL
    SET @SFZH = NULL
IF @SJH IS NULL
    SET @SJH = NULL
IF @BGDH IS NULL
    SET @BGDH = NULL
IF @JTDH IS NULL
    SET @JTDH = NULL
IF @Email IS NULL
    SET @Email = NULL
IF @QQH IS NULL
    SET @QQH = NULL
IF @LoginTime IS NULL
    SET @LoginTime = NULL
IF @LastLoginIP IS NULL
    SET @LastLoginIP = NULL
IF @LastLoginDate IS NULL
    SET @LastLoginDate = NULL
IF @LoginTimes IS NULL
    SET @LoginTimes = (0)
IF @UserStatus IS NULL
    SET @UserStatus = '01'
IF @vcode IS NULL
    SET @vcode = newid()
SET XACT_ABORT ON
BEGIN TRANSACTION
    --����������Ϣ
    INSERT INTO [dbo].[T_PM_UserInfo]
    (
    
    [ObjectID]
    ,[UserID]
    ,[UserLoginName]
    ,[UserGroupID]
    ,[SubjectID]
    ,[UserNickName]
    ,[Password]
    ,[XB]
    ,[MZ]
    ,[ZZMM]
    ,[SFZH]
    ,[SJH]
    ,[BGDH]
    ,[JTDH]
    ,[Email]
    ,[QQH]
    ,[LoginTime]
    ,[LastLoginIP]
    ,[LastLoginDate]
    ,[LoginTimes]
    ,[UserStatus]
    ,[vcode]
    )
    VALUES
    (
    
    @ObjectID
    ,@UserID
    ,@UserLoginName
    ,@UserGroupID
    ,@SubjectID
    ,@UserNickName
    ,@Password
    ,@XB
    ,@MZ
    ,@ZZMM
    ,@SFZH
    ,@SJH
    ,@BGDH
    ,@JTDH
    ,@Email
    ,@QQH
    ,@LoginTime
    ,@LastLoginIP
    ,@LastLoginDate
    ,@LoginTimes
    ,@UserStatus
    ,@vcode
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserInfoByAnyCondition]
GO

--��T_PM_UserInfo�����������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserInfoByAnyCondition] 

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDValue nvarchar(50) = NULL
, @ObjectIDBatch nvarchar(1000) = NULL

, @UserID NVarChar(50) = NULL
        
, @UserIDValue NVarChar(50) = NULL
, @UserIDBatch nvarchar(1000) = NULL

, @UserLoginName NVarChar(50) = NULL
        
, @UserLoginNameValue NVarChar(50) = NULL
, @UserLoginNameBatch nvarchar(1000) = NULL

, @UserGroupID NVarChar(500) = NULL
        
, @UserGroupIDValue NVarChar(500) = NULL
, @UserGroupIDBatch nvarchar(1000) = NULL

, @SubjectID NVarChar(50) = NULL
        
, @SubjectIDValue NVarChar(50) = NULL
, @SubjectIDBatch nvarchar(1000) = NULL

, @UserNickName NVarChar(50) = NULL
        
, @UserNickNameValue NVarChar(50) = NULL
, @UserNickNameBatch nvarchar(1000) = NULL

, @Password NVarChar(50) = NULL
        
, @PasswordValue NVarChar(50) = NULL
, @PasswordBatch nvarchar(1000) = NULL

, @XB NVarChar(2) = NULL
        
, @XBValue NVarChar(2) = NULL
, @XBBatch nvarchar(1000) = NULL

, @MZ NVarChar(2) = NULL
        
, @MZValue NVarChar(2) = NULL
, @MZBatch nvarchar(1000) = NULL

, @ZZMM NVarChar(2) = NULL
        
, @ZZMMValue NVarChar(2) = NULL
, @ZZMMBatch nvarchar(1000) = NULL

, @SFZH NVarChar(18) = NULL
        
, @SFZHValue NVarChar(18) = NULL
, @SFZHBatch nvarchar(1000) = NULL

, @SJH NVarChar(50) = NULL
        
, @SJHValue NVarChar(50) = NULL
, @SJHBatch nvarchar(1000) = NULL

, @BGDH NVarChar(50) = NULL
        
, @BGDHValue NVarChar(50) = NULL
, @BGDHBatch nvarchar(1000) = NULL

, @JTDH NVarChar(50) = NULL
        
, @JTDHValue NVarChar(50) = NULL
, @JTDHBatch nvarchar(1000) = NULL

, @Email NVarChar(50) = NULL
        
, @EmailValue NVarChar(50) = NULL
, @EmailBatch nvarchar(1000) = NULL

, @QQH NVarChar(50) = NULL
        
, @QQHValue NVarChar(50) = NULL
, @QQHBatch nvarchar(1000) = NULL

, @LoginTime DateTime = NULL
        
, @LoginTimeBegin DateTime = NULL
, @LoginTimeEnd DateTime = NULL
        
, @LoginTimeValue DateTime = NULL
, @LoginTimeBatch nvarchar(1000) = NULL

, @LastLoginIP NVarChar(50) = NULL
        
, @LastLoginIPValue NVarChar(50) = NULL
, @LastLoginIPBatch nvarchar(1000) = NULL

, @LastLoginDate DateTime = NULL
        
, @LastLoginDateBegin DateTime = NULL
, @LastLoginDateEnd DateTime = NULL
        
, @LastLoginDateValue DateTime = NULL
, @LastLoginDateBatch nvarchar(1000) = NULL

, @LoginTimes Int = NULL
        
, @LoginTimesValue Int = NULL
, @LoginTimesBatch nvarchar(1000) = NULL

, @UserStatus NVarChar(2) = NULL
        
, @UserStatusValue NVarChar(2) = NULL
, @UserStatusBatch nvarchar(1000) = NULL

, @vcode nvarchar(50) = NULL
        
, @vcodeValue nvarchar(50) = NULL
, @vcodeBatch nvarchar(1000) = NULL

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
    SET @ConditionText = '( [dbo].[T_PM_UserInfo].ObjectID IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].ObjectID = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].ObjectID)+''%'' '
    
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].UserID = '''+CAST(@UserID AS nvarchar(100))+''' '
            
    IF @UserIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserID)+''%'' '
    
    IF @UserLoginName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].UserLoginName LIKE ''%'+CAST(@UserLoginName AS nvarchar(100))+'%'' '
            
    IF @UserLoginNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserLoginNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserLoginName)+''%'' '
    
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].UserGroupID = '''+CAST(@UserGroupID AS nvarchar(100))+''' '
            
    IF @UserGroupIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserGroupIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserGroupID)+''%'' '
    
    IF @SubjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].SubjectID = '''+CAST(@SubjectID AS nvarchar(100))+''' '
            
    IF @SubjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SubjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].SubjectID)+''%'' '
    
    IF @UserNickName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].UserNickName LIKE ''%'+CAST(@UserNickName AS nvarchar(100))+'%'' '
            
    IF @UserNickNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserNickNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserNickName)+''%'' '
    
    IF @Password IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].Password = '''+CAST(@Password AS nvarchar(100))+''' '
            
    IF @PasswordBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@PasswordBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].Password)+''%'' '
    
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].XB = '''+CAST(@XB AS nvarchar(100))+''' '
            
    IF @XBBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@XBBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].XB)+''%'' '
    
    IF @MZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].MZ = '''+CAST(@MZ AS nvarchar(100))+''' '
            
    IF @MZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@MZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].MZ)+''%'' '
    
    IF @ZZMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].ZZMM = '''+CAST(@ZZMM AS nvarchar(100))+''' '
            
    IF @ZZMMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@ZZMMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].ZZMM)+''%'' '
    
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].SFZH = '''+CAST(@SFZH AS nvarchar(100))+''' '
            
    IF @SFZHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SFZHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].SFZH)+''%'' '
    
    IF @SJH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].SJH LIKE ''%'+CAST(@SJH AS nvarchar(100))+'%'' '
            
    IF @SJHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@SJHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].SJH)+''%'' '
    
    IF @BGDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].BGDH = '''+CAST(@BGDH AS nvarchar(100))+''' '
            
    IF @BGDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@BGDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].BGDH)+''%'' '
    
    IF @JTDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].JTDH = '''+CAST(@JTDH AS nvarchar(100))+''' '
            
    IF @JTDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@JTDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].JTDH)+''%'' '
    
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].Email LIKE ''%'+CAST(@Email AS nvarchar(100))+'%'' '
            
    IF @EmailBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@EmailBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].Email)+''%'' '
    
    IF @QQH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].QQH LIKE ''%'+CAST(@QQH AS nvarchar(100))+'%'' '
            
    IF @QQHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@QQHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].QQH)+''%'' '
    
    IF @LoginTime IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LoginTime = '''+CAST(@LoginTime AS nvarchar(100))+''' '
    IF @LoginTimeBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LoginTime >= '''+CAST(@LoginTimeBegin AS nvarchar(100))+''' '
    IF @LoginTimeEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LoginTime <= '''+CAST(@LoginTimeEnd AS nvarchar(100))+''' '
        
    IF @LoginTimeBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LoginTimeBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LoginTime)+''%'' '
    
    IF @LastLoginIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LastLoginIP = '''+CAST(@LastLoginIP AS nvarchar(100))+''' '
            
    IF @LastLoginIPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LastLoginIPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LastLoginIP)+''%'' '
    
    IF @LastLoginDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LastLoginDate = '''+CAST(@LastLoginDate AS nvarchar(100))+''' '
    IF @LastLoginDateBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LastLoginDate >= '''+CAST(@LastLoginDateBegin AS nvarchar(100))+''' '
    IF @LastLoginDateEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LastLoginDate <= '''+CAST(@LastLoginDateEnd AS nvarchar(100))+''' '
        
    IF @LastLoginDateBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LastLoginDateBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LastLoginDate)+''%'' '
    
    IF @LoginTimes IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].LoginTimes = '''+CAST(@LoginTimes AS nvarchar(100))+''' '
            
    IF @LoginTimesBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@LoginTimesBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LoginTimes)+''%'' '
    
    IF @UserStatus IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].UserStatus = '''+CAST(@UserStatus AS nvarchar(100))+''' '
            
    IF @UserStatusBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@UserStatusBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserStatus)+''%'' '
    
    IF @vcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].vcode = '''+CAST(@vcode AS nvarchar(100))+''' '
            
    IF @vcodeBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@vcodeBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].vcode)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    SET @ConditionText = '( [dbo].[T_PM_UserInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].ObjectID LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @ObjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ObjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].ObjectID)+''%'' '
    
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].UserID LIKE '''+CAST(@UserID AS nvarchar(100))+'%'' '
        
    IF @UserIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserID)+''%'' '
    
    IF @UserLoginName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].UserLoginName LIKE '''+CAST(@UserLoginName AS nvarchar(100))+'%'' '
        
    IF @UserLoginNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserLoginNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserLoginName)+''%'' '
    
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].UserGroupID LIKE '''+CAST(@UserGroupID AS nvarchar(100))+'%'' '
        
    IF @UserGroupIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserGroupIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserGroupID)+''%'' '
    
    IF @SubjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].SubjectID LIKE '''+CAST(@SubjectID AS nvarchar(100))+'%'' '
        
    IF @SubjectIDBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SubjectIDBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].SubjectID)+''%'' '
    
    IF @UserNickName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].UserNickName LIKE '''+CAST(@UserNickName AS nvarchar(100))+'%'' '
        
    IF @UserNickNameBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserNickNameBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserNickName)+''%'' '
    
    IF @Password IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].Password LIKE '''+CAST(@Password AS nvarchar(100))+'%'' '
        
    IF @PasswordBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@PasswordBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].Password)+''%'' '
    
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].XB LIKE '''+CAST(@XB AS nvarchar(100))+'%'' '
        
    IF @XBBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@XBBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].XB)+''%'' '
    
    IF @MZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].MZ LIKE '''+CAST(@MZ AS nvarchar(100))+'%'' '
        
    IF @MZBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@MZBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].MZ)+''%'' '
    
    IF @ZZMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].ZZMM LIKE '''+CAST(@ZZMM AS nvarchar(100))+'%'' '
        
    IF @ZZMMBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@ZZMMBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].ZZMM)+''%'' '
    
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].SFZH LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
        
    IF @SFZHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SFZHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].SFZH)+''%'' '
    
    IF @SJH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].SJH LIKE '''+CAST(@SJH AS nvarchar(100))+'%'' '
        
    IF @SJHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@SJHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].SJH)+''%'' '
    
    IF @BGDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].BGDH LIKE '''+CAST(@BGDH AS nvarchar(100))+'%'' '
        
    IF @BGDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@BGDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].BGDH)+''%'' '
    
    IF @JTDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].JTDH LIKE '''+CAST(@JTDH AS nvarchar(100))+'%'' '
        
    IF @JTDHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@JTDHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].JTDH)+''%'' '
    
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].Email LIKE '''+CAST(@Email AS nvarchar(100))+'%'' '
        
    IF @EmailBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@EmailBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].Email)+''%'' '
    
    IF @QQH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].QQH LIKE '''+CAST(@QQH AS nvarchar(100))+'%'' '
        
    IF @QQHBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@QQHBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].QQH)+''%'' '
    
    IF @LoginTime IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LoginTime = '''+CAST(@LoginTime AS nvarchar(100))+''' '
    IF @LoginTimeBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LoginTime >= '''+CAST(@LoginTimeBegin AS nvarchar(100))+''' '
    IF @LoginTimeEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LoginTime <= '''+CAST(@LoginTimeEnd AS nvarchar(100))+''' '
        
    IF @LoginTimeBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LoginTimeBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LoginTime)+''%'' '
    
    IF @LastLoginIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LastLoginIP LIKE '''+CAST(@LastLoginIP AS nvarchar(100))+'%'' '
        
    IF @LastLoginIPBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LastLoginIPBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LastLoginIP)+''%'' '
    
    IF @LastLoginDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LastLoginDate = '''+CAST(@LastLoginDate AS nvarchar(100))+''' '
    IF @LastLoginDateBegin IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LastLoginDate >= '''+CAST(@LastLoginDateBegin AS nvarchar(100))+''' '
    IF @LastLoginDateEnd IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LastLoginDate <= '''+CAST(@LastLoginDateEnd AS nvarchar(100))+''' '
        
    IF @LastLoginDateBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LastLoginDateBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LastLoginDate)+''%'' '
    
    IF @LoginTimes IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].LoginTimes LIKE '''+CAST(@LoginTimes AS nvarchar(100))+'%'' '
        
    IF @LoginTimesBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@LoginTimesBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].LoginTimes)+''%'' '
    
    IF @UserStatus IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].UserStatus LIKE '''+CAST(@UserStatus AS nvarchar(100))+'%'' '
        
    IF @UserStatusBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@UserStatusBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].UserStatus)+''%'' '
    
    IF @vcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].vcode LIKE '''+CAST(@vcode AS nvarchar(100))+'%'' '
        
    IF @vcodeBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@vcodeBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].vcode)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_PM_UserInfo] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --����@RecordCount

SET XACT_ABORT ON
BEGIN TRANSACTION
    SET @SqlText = 'UPDATE [DB_MGZZX].[dbo].[T_PM_UserInfo] SET '

    IF @ObjectIDValue IS NOT NULL
       SET  @SqlText = @SqlText + ' ObjectID = @ObjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ObjectID = [DB_MGZZX].[dbo].[T_PM_UserInfo].ObjectID'
  
    IF @UserIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserID = @UserIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserID = [DB_MGZZX].[dbo].[T_PM_UserInfo].UserID'
  
    IF @UserLoginNameValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserLoginName = @UserLoginNameValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserLoginName = [DB_MGZZX].[dbo].[T_PM_UserInfo].UserLoginName'
  
    IF @UserGroupIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserGroupID = @UserGroupIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserGroupID = [DB_MGZZX].[dbo].[T_PM_UserInfo].UserGroupID'
  
    IF @SubjectIDValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SubjectID = @SubjectIDValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SubjectID = [DB_MGZZX].[dbo].[T_PM_UserInfo].SubjectID'
  
    IF @UserNickNameValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserNickName = @UserNickNameValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserNickName = [DB_MGZZX].[dbo].[T_PM_UserInfo].UserNickName'
  
    IF @PasswordValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,Password = @PasswordValue'
    ELSE
        SET @SqlText = @SqlText + ' ,Password = [DB_MGZZX].[dbo].[T_PM_UserInfo].Password'
  
    IF @XBValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,XB = @XBValue'
    ELSE
        SET @SqlText = @SqlText + ' ,XB = [DB_MGZZX].[dbo].[T_PM_UserInfo].XB'
  
    IF @MZValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,MZ = @MZValue'
    ELSE
        SET @SqlText = @SqlText + ' ,MZ = [DB_MGZZX].[dbo].[T_PM_UserInfo].MZ'
  
    IF @ZZMMValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,ZZMM = @ZZMMValue'
    ELSE
        SET @SqlText = @SqlText + ' ,ZZMM = [DB_MGZZX].[dbo].[T_PM_UserInfo].ZZMM'
  
    IF @SFZHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SFZH = @SFZHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SFZH = [DB_MGZZX].[dbo].[T_PM_UserInfo].SFZH'
  
    IF @SJHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,SJH = @SJHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,SJH = [DB_MGZZX].[dbo].[T_PM_UserInfo].SJH'
  
    IF @BGDHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,BGDH = @BGDHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,BGDH = [DB_MGZZX].[dbo].[T_PM_UserInfo].BGDH'
  
    IF @JTDHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,JTDH = @JTDHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,JTDH = [DB_MGZZX].[dbo].[T_PM_UserInfo].JTDH'
  
    IF @EmailValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,Email = @EmailValue'
    ELSE
        SET @SqlText = @SqlText + ' ,Email = [DB_MGZZX].[dbo].[T_PM_UserInfo].Email'
  
    IF @QQHValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,QQH = @QQHValue'
    ELSE
        SET @SqlText = @SqlText + ' ,QQH = [DB_MGZZX].[dbo].[T_PM_UserInfo].QQH'
  
    IF @LoginTimeValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LoginTime = @LoginTimeValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LoginTime = [DB_MGZZX].[dbo].[T_PM_UserInfo].LoginTime'
  
    IF @LastLoginIPValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LastLoginIP = @LastLoginIPValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LastLoginIP = [DB_MGZZX].[dbo].[T_PM_UserInfo].LastLoginIP'
  
    IF @LastLoginDateValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LastLoginDate = @LastLoginDateValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LastLoginDate = [DB_MGZZX].[dbo].[T_PM_UserInfo].LastLoginDate'
  
    IF @LoginTimesValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,LoginTimes = @LoginTimesValue'
    ELSE
        SET @SqlText = @SqlText + ' ,LoginTimes = [DB_MGZZX].[dbo].[T_PM_UserInfo].LoginTimes'
  
    IF @UserStatusValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,UserStatus = @UserStatusValue'
    ELSE
        SET @SqlText = @SqlText + ' ,UserStatus = [DB_MGZZX].[dbo].[T_PM_UserInfo].UserStatus'
  
    IF @vcodeValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,vcode = @vcodeValue'
    ELSE
        SET @SqlText = @SqlText + ' ,vcode = [DB_MGZZX].[dbo].[T_PM_UserInfo].vcode'
  
SET @SqlText = @SqlText + ' FROM [DB_MGZZX].[dbo].[T_PM_UserInfo] WHERE ' + @ConditionText
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserInfoByObjectID]
GO

--��T_PM_UserInfo��ObjectIDΪ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserInfoByObjectID] 

@ObjectID nvarchar(50) = NULL
,@UserID NVarChar(50) = NULL
,@UserLoginName NVarChar(50) = NULL
,@UserGroupID NVarChar(500) = NULL
,@SubjectID NVarChar(50) = NULL
,@UserNickName NVarChar(50) = NULL
,@Password NVarChar(50) = NULL
,@XB NVarChar(2) = NULL
,@MZ NVarChar(2) = NULL
,@ZZMM NVarChar(2) = NULL
,@SFZH NVarChar(18) = NULL
,@SJH NVarChar(50) = NULL
,@BGDH NVarChar(50) = NULL
,@JTDH NVarChar(50) = NULL
,@Email NVarChar(50) = NULL
,@QQH NVarChar(50) = NULL
,@LoginTime DateTime = NULL
,@LastLoginIP NVarChar(50) = NULL
,@LastLoginDate DateTime = NULL
,@LoginTimes Int = NULL
,@UserStatus NVarChar(2) = NULL
,@vcode nvarchar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --�������
    UPDATE [dbo].[T_PM_UserInfo]
    SET 
    
    [ObjectID] = @ObjectID
    , [UserID] = @UserID
    , [UserLoginName] = @UserLoginName
    , [UserGroupID] = @UserGroupID
    , [SubjectID] = @SubjectID
    , [UserNickName] = @UserNickName
    , [Password] = @Password
    , [XB] = @XB
    , [MZ] = @MZ
    , [ZZMM] = @ZZMM
    , [SFZH] = @SFZH
    , [SJH] = @SJH
    , [BGDH] = @BGDH
    , [JTDH] = @JTDH
    , [Email] = @Email
    , [QQH] = @QQH
    , [LoginTime] = @LoginTime
    , [LastLoginIP] = @LastLoginIP
    , [LastLoginDate] = @LastLoginDate
    , [LoginTimes] = @LoginTimes
    , [UserStatus] = @UserStatus
    , [vcode] = @vcode
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserInfoByKey]
GO

--��T_PM_UserInfo������Ϊ�������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserInfoByKey] 

@ObjectID nvarchar(50) = NULL
,@UserID NVarChar(50) = NULL
,@UserLoginName NVarChar(50) = NULL
,@UserGroupID NVarChar(500) = NULL
,@SubjectID NVarChar(50) = NULL
,@UserNickName NVarChar(50) = NULL
,@Password NVarChar(50) = NULL
,@XB NVarChar(2) = NULL
,@MZ NVarChar(2) = NULL
,@ZZMM NVarChar(2) = NULL
,@SFZH NVarChar(18) = NULL
,@SJH NVarChar(50) = NULL
,@BGDH NVarChar(50) = NULL
,@JTDH NVarChar(50) = NULL
,@Email NVarChar(50) = NULL
,@QQH NVarChar(50) = NULL
,@LoginTime DateTime = NULL
,@LastLoginIP NVarChar(50) = NULL
,@LastLoginDate DateTime = NULL
,@LoginTimes Int = NULL
,@UserStatus NVarChar(2) = NULL
,@vcode nvarchar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --�������
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [ObjectID] = @ObjectID
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @UserID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserID] = @UserID
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @UserLoginName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserLoginName] = @UserLoginName
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @UserGroupID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserGroupID] = @UserGroupID
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @SubjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [SubjectID] = @SubjectID
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @UserNickName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserNickName] = @UserNickName
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @Password IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [Password] = @Password
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @XB IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [XB] = @XB
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @MZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [MZ] = @MZ
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @ZZMM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [ZZMM] = @ZZMM
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @SFZH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [SFZH] = @SFZH
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @SJH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [SJH] = @SJH
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @BGDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [BGDH] = @BGDH
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @JTDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [JTDH] = @JTDH
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @Email IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [Email] = @Email
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @QQH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [QQH] = @QQH
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @LoginTime IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LoginTime] = @LoginTime
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @LastLoginIP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LastLoginIP] = @LastLoginIP
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @LastLoginDate IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LastLoginDate] = @LastLoginDate
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @LoginTimes IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LoginTimes] = @LoginTimes
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @UserStatus IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserStatus] = @UserStatus
        WHERE
        
        [UserID] = @UserID
    END
    
    IF @vcode IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [vcode] = @vcode
        WHERE
        
        [UserID] = @UserID
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserInfoByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserInfoByObjectIDBatch]
GO

--��T_PM_UserInfo��ObjectIDΪ�����������µĴ洢����

CREATE   PROCEDURE [dbo].[SP_UpdateT_PM_UserInfoByObjectIDBatch]
@ObjectIDBatch nvarchar(4000) = NULL

,@ObjectID nvarchar(50) = NULL

,@UserID NVarChar(50) = NULL

,@UserLoginName NVarChar(50) = NULL

,@UserGroupID NVarChar(500) = NULL

,@SubjectID NVarChar(50) = NULL

,@UserNickName NVarChar(50) = NULL

,@Password NVarChar(50) = NULL

,@XB NVarChar(2) = NULL

,@MZ NVarChar(2) = NULL

,@ZZMM NVarChar(2) = NULL

,@SFZH NVarChar(18) = NULL

,@SJH NVarChar(50) = NULL

,@BGDH NVarChar(50) = NULL

,@JTDH NVarChar(50) = NULL

,@Email NVarChar(50) = NULL

,@QQH NVarChar(50) = NULL

,@LoginTime DateTime = NULL

,@LastLoginIP NVarChar(50) = NULL

,@LastLoginDate DateTime = NULL

,@LoginTimes Int = NULL

,@UserStatus NVarChar(2) = NULL

,@vcode nvarchar(50) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --�������
    
    IF @ObjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [ObjectID] = @ObjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserID] = @UserID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserLoginName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserLoginName] = @UserLoginName WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserGroupID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserGroupID] = @UserGroupID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SubjectID IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [SubjectID] = @SubjectID WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserNickName IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserNickName] = @UserNickName WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @Password IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [Password] = @Password WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @XB IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [XB] = @XB WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @MZ IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [MZ] = @MZ WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @ZZMM IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [ZZMM] = @ZZMM WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SFZH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [SFZH] = @SFZH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @SJH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [SJH] = @SJH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @BGDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [BGDH] = @BGDH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @JTDH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [JTDH] = @JTDH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @Email IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [Email] = @Email WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @QQH IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [QQH] = @QQH WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LoginTime IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LoginTime] = @LoginTime WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LastLoginIP IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LastLoginIP] = @LastLoginIP WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LastLoginDate IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LastLoginDate] = @LastLoginDate WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @LoginTimes IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [LoginTimes] = @LoginTimes WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @UserStatus IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [UserStatus] = @UserStatus WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
    END
    
    IF @vcode IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [vcode] = @vcode WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_UserInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_UserInfoByObjectID]
GO

--��T_PM_UserInfo��ObjectIDΪ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
    --����ɾ��
    DELETE [dbo].[T_PM_UserInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_UserInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_UserInfoByKey]
GO

--��T_PM_UserInfo������Ϊ����ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserInfoByKey] 

@UserID NVarChar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
DELETE [dbo].[T_PM_UserInfo]
WHERE

[UserID] = @UserID
COMMIT TRANSACTION

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO


if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_DeleteT_PM_UserInfoByObjectIDBatch]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_DeleteT_PM_UserInfoByObjectIDBatch]
GO

--��T_PM_UserInfo��ObjectIDΪ��������ɾ���Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserInfoByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --������ر���Ϣ
    
--����ɾ��
    DELETE [dbo].[T_PM_UserInfo]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserInfoByAnyCondition]
GO

--��T_PM_UserInfo����������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserInfoByAnyCondition] 
--�������

@ObjectID nvarchar(50) = NULL
        
, @ObjectIDBatch nvarchar(4000) = NULL

, @UserID NVarChar(50) = NULL
        
, @UserIDBatch nvarchar(4000) = NULL

, @UserLoginName NVarChar(50) = NULL
        
, @UserLoginNameBatch nvarchar(4000) = NULL

, @UserGroupID NVarChar(500) = NULL
        
, @UserGroupIDBatch nvarchar(4000) = NULL

, @SubjectID NVarChar(50) = NULL
        
, @SubjectIDBatch nvarchar(4000) = NULL

, @UserNickName NVarChar(50) = NULL
        
, @UserNickNameBatch nvarchar(4000) = NULL

, @Password NVarChar(50) = NULL
        
, @PasswordBatch nvarchar(4000) = NULL

, @XB NVarChar(2) = NULL
        
, @XBBatch nvarchar(4000) = NULL

, @MZ NVarChar(2) = NULL
        
, @MZBatch nvarchar(4000) = NULL

, @ZZMM NVarChar(2) = NULL
        
, @ZZMMBatch nvarchar(4000) = NULL

, @SFZH NVarChar(18) = NULL
        
, @SFZHBatch nvarchar(4000) = NULL

, @SJH NVarChar(50) = NULL
        
, @SJHBatch nvarchar(4000) = NULL

, @BGDH NVarChar(50) = NULL
        
, @BGDHBatch nvarchar(4000) = NULL

, @JTDH NVarChar(50) = NULL
        
, @JTDHBatch nvarchar(4000) = NULL

, @Email NVarChar(50) = NULL
        
, @EmailBatch nvarchar(4000) = NULL

, @QQH NVarChar(50) = NULL
        
, @QQHBatch nvarchar(4000) = NULL

, @LoginTime DateTime = NULL
        
, @LoginTimeBatch nvarchar(4000) = NULL

, @LastLoginIP NVarChar(50) = NULL
        
, @LastLoginIPBatch nvarchar(4000) = NULL

, @LastLoginDate DateTime = NULL
        
, @LastLoginDateBatch nvarchar(4000) = NULL

, @LoginTimes Int = NULL
        
, @LoginTimesBatch nvarchar(4000) = NULL

, @UserStatus NVarChar(2) = NULL
        
, @UserStatusBatch nvarchar(4000) = NULL

, @vcode nvarchar(50) = NULL
        
, @vcodeBatch nvarchar(4000) = NULL

--һ��һ��ر����

, @QueryType nvarchar(50) = 'AND'
, @QueryField nvarchar(1000) = NULL
, @Sort bit = 0
, @SortField nvarchar(50) = 'UserID'
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
    SET @SortField = 'UserID'
IF @PageSize IS NULL 
    SET @PageSize = 500
IF @CurrentPage IS NULL 
    SET @CurrentPage = 1
SET @SortText = ' ORDER BY ' + '[dbo].[T_PM_UserInfo].' + @SortField + ' '
IF @Sort = 0
    SET @SortText = @SortText + ' DESC '
ELSE IF @Sort = 1
    SET @SortText = @SortText + ' ASC '

IF @QueryType = 'AND'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_PM_UserInfo].[ObjectID] IS NOT NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[UserID] = '''+CAST(@UserID AS nvarchar(100))+''' '
            
    IF @UserLoginName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[UserLoginName] LIKE ''%'+CAST(@UserLoginName AS nvarchar(100))+'%'' '
            
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[UserGroupID] = '''+CAST(@UserGroupID AS nvarchar(100))+''' '
            
    IF @SubjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[SubjectID] = '''+CAST(@SubjectID AS nvarchar(100))+''' '
            
    IF @UserNickName IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[UserNickName] LIKE ''%'+CAST(@UserNickName AS nvarchar(100))+'%'' '
            
    IF @Password IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[Password] = '''+CAST(@Password AS nvarchar(100))+''' '
            
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[XB] = '''+CAST(@XB AS nvarchar(100))+''' '
            
    IF @MZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[MZ] = '''+CAST(@MZ AS nvarchar(100))+''' '
            
    IF @ZZMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[ZZMM] = '''+CAST(@ZZMM AS nvarchar(100))+''' '
            
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[SFZH] = '''+CAST(@SFZH AS nvarchar(100))+''' '
            
    IF @SJH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[SJH] LIKE ''%'+CAST(@SJH AS nvarchar(100))+'%'' '
            
    IF @BGDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[BGDH] = '''+CAST(@BGDH AS nvarchar(100))+''' '
            
    IF @JTDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[JTDH] = '''+CAST(@JTDH AS nvarchar(100))+''' '
            
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[Email] LIKE ''%'+CAST(@Email AS nvarchar(100))+'%'' '
            
    IF @QQH IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[QQH] LIKE ''%'+CAST(@QQH AS nvarchar(100))+'%'' '
            
    IF @LoginTime IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[LoginTime] = '''+CAST(@LoginTime AS nvarchar(100))+''' '
            
    IF @LastLoginIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[LastLoginIP] = '''+CAST(@LastLoginIP AS nvarchar(100))+''' '
            
    IF @LastLoginDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[LastLoginDate] = '''+CAST(@LastLoginDate AS nvarchar(100))+''' '
            
    IF @LoginTimes IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[LoginTimes] = '''+CAST(@LoginTimes AS nvarchar(100))+''' '
            
    IF @UserStatus IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[UserStatus] = '''+CAST(@UserStatus AS nvarchar(100))+''' '
            
    IF @vcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[vcode] = '''+CAST(@vcode AS nvarchar(100))+''' '
            
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --�����ѯ����
    SET @ConditionText = '( [dbo].[T_PM_UserInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[ObjectID] LIKE '''+CAST(@ObjectID AS nvarchar(100))+'%'' '
        
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserID] LIKE '''+CAST(@UserID AS nvarchar(100))+'%'' '
        
    IF @UserLoginName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserLoginName] LIKE '''+CAST(@UserLoginName AS nvarchar(100))+'%'' '
        
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserGroupID] LIKE '''+CAST(@UserGroupID AS nvarchar(100))+'%'' '
        
    IF @SubjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[SubjectID] LIKE '''+CAST(@SubjectID AS nvarchar(100))+'%'' '
        
    IF @UserNickName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserNickName] LIKE '''+CAST(@UserNickName AS nvarchar(100))+'%'' '
        
    IF @Password IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[Password] LIKE '''+CAST(@Password AS nvarchar(100))+'%'' '
        
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[XB] LIKE '''+CAST(@XB AS nvarchar(100))+'%'' '
        
    IF @MZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[MZ] LIKE '''+CAST(@MZ AS nvarchar(100))+'%'' '
        
    IF @ZZMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[ZZMM] LIKE '''+CAST(@ZZMM AS nvarchar(100))+'%'' '
        
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[SFZH] LIKE '''+CAST(@SFZH AS nvarchar(100))+'%'' '
        
    IF @SJH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[SJH] LIKE '''+CAST(@SJH AS nvarchar(100))+'%'' '
        
    IF @BGDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[BGDH] LIKE '''+CAST(@BGDH AS nvarchar(100))+'%'' '
        
    IF @JTDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[JTDH] LIKE '''+CAST(@JTDH AS nvarchar(100))+'%'' '
        
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[Email] LIKE '''+CAST(@Email AS nvarchar(100))+'%'' '
        
    IF @QQH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[QQH] LIKE '''+CAST(@QQH AS nvarchar(100))+'%'' '
        
    IF @LoginTime IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LoginTime] LIKE '''+CAST(@LoginTime AS nvarchar(100))+'%'' '
        
    IF @LastLoginIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LastLoginIP] LIKE '''+CAST(@LastLoginIP AS nvarchar(100))+'%'' '
        
    IF @LastLoginDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LastLoginDate] LIKE '''+CAST(@LastLoginDate AS nvarchar(100))+'%'' '
        
    IF @LoginTimes IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LoginTimes] LIKE '''+CAST(@LoginTimes AS nvarchar(100))+'%'' '
        
    IF @UserStatus IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserStatus] LIKE '''+CAST(@UserStatus AS nvarchar(100))+'%'' '
        
    IF @vcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[vcode] LIKE '''+CAST(@vcode AS nvarchar(100))+'%'' '
        
    --һ��һ��ر��ѯ����
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + '

      [dbo].[T_PM_UserInfo].[ObjectID]
        
      , [dbo].[T_PM_UserInfo].[UserID]
        
      , [dbo].[T_PM_UserInfo].[UserLoginName]
        
      , [dbo].[T_PM_UserInfo].[UserGroupID]
        
      , [dbo].[T_PM_UserInfo].[SubjectID]
        
      , [dbo].[T_PM_UserInfo].[UserNickName]
        
      , [dbo].[T_PM_UserInfo].[Password]
        
      , [dbo].[T_PM_UserInfo].[XB]
        
      , [dbo].[T_PM_UserInfo].[MZ]
        
      , [dbo].[T_PM_UserInfo].[ZZMM]
        
      , [dbo].[T_PM_UserInfo].[SFZH]
        
      , [dbo].[T_PM_UserInfo].[SJH]
        
      , [dbo].[T_PM_UserInfo].[BGDH]
        
      , [dbo].[T_PM_UserInfo].[JTDH]
        
      , [dbo].[T_PM_UserInfo].[Email]
        
      , [dbo].[T_PM_UserInfo].[QQH]
        
      , [dbo].[T_PM_UserInfo].[LoginTime]
        
      , [dbo].[T_PM_UserInfo].[LastLoginIP]
        
      , [dbo].[T_PM_UserInfo].[LastLoginDate]
        
      , [dbo].[T_PM_UserInfo].[LoginTimes]
        
      , [dbo].[T_PM_UserInfo].[UserStatus]
        
      , [dbo].[T_PM_UserInfo].[vcode]
        
        ,[dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]([dbo].[T_PM_UserInfo].[UserGroupID]) AS [UserGroupID_T_PM_UserGroupInfo_UserGroupName]
        ,[SubjectID_T_BM_DWXX].[DWMC] AS [SubjectID_T_BM_DWXX_DWMC]
        ,[XB_Dictionary].[MC] AS [XB_Dictionary_MC]
        ,[MZ_Dictionary].[MC] AS [MZ_Dictionary_MC]
        ,[ZZMM_Dictionary].[MC] AS [ZZMM_Dictionary_MC]
        ,[UserStatus_Dictionary].[MC] AS [UserStatus_Dictionary_MC]
'
--һ��һ��ر���ѯ�ֶ�
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--�����ѯ�ֶ�
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]([dbo].[T_PM_UserInfo].[UserGroupID]) AS [UserGroupID_T_PM_UserGroupInfo_UserGroupName]
        ,[SubjectID_T_BM_DWXX].[DWMC] AS [SubjectID_T_BM_DWXX_DWMC]
        ,[XB_Dictionary].[MC] AS [XB_Dictionary_MC]
        ,[MZ_Dictionary].[MC] AS [MZ_Dictionary_MC]
        ,[ZZMM_Dictionary].[MC] AS [ZZMM_Dictionary_MC]
        ,[UserStatus_Dictionary].[MC] AS [UserStatus_Dictionary_MC]
'
--һ��һ��ر��ѯ�ֶ�
  SET @SqlText = @SqlText + '

'
END
--����
SET @FromText = '
 FROM [dbo].[T_PM_UserInfo]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserGroupInfo] AS UserGroupID_T_PM_UserGroupInfo ON UserGroupID_T_PM_UserGroupInfo.[UserGroupID] = [dbo].[T_PM_UserInfo].[UserGroupID] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS SubjectID_T_BM_DWXX ON SubjectID_T_BM_DWXX.[DWBH] = [dbo].[T_PM_UserInfo].[SubjectID] 
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS XB_Dictionary ON XB_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[XB]  AND XB_Dictionary.[LX] = ''0001''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS MZ_Dictionary ON MZ_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[MZ]  AND MZ_Dictionary.[LX] = ''0002''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS ZZMM_Dictionary ON ZZMM_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[ZZMM]  AND ZZMM_Dictionary.[LX] = ''0003''
'
	
SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS UserStatus_Dictionary ON UserStatus_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[UserStatus]  AND UserStatus_Dictionary.[LX] = ''0102''
'
	
--�����ѯ

IF @ObjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ObjectIDBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_ObjectID_Batch ON '','' + [dbo].[T_PM_UserInfo].[ObjectID] + '','' LIKE ''%,'' + T_PM_UserInfo_ObjectID_Batch.col +'',%''
'
    
IF @UserIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserIDBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_UserID_Batch ON '','' + [dbo].[T_PM_UserInfo].[UserID] + '','' LIKE ''%,'' + T_PM_UserInfo_UserID_Batch.col +'',%''
'
    
IF @UserLoginNameBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserLoginNameBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_UserLoginName_Batch ON '','' + [dbo].[T_PM_UserInfo].[UserLoginName] + '','' LIKE ''%,'' + T_PM_UserInfo_UserLoginName_Batch.col +'',%''
'
    
IF @UserGroupIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserGroupIDBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_UserGroupID_Batch ON '','' + [dbo].[T_PM_UserInfo].[UserGroupID] + '','' LIKE ''%,'' + T_PM_UserInfo_UserGroupID_Batch.col +'',%''
'
    
IF @SubjectIDBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SubjectIDBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_SubjectID_Batch ON '','' + [dbo].[T_PM_UserInfo].[SubjectID] + '','' LIKE ''%,'' + T_PM_UserInfo_SubjectID_Batch.col +'',%''
'
    
IF @UserNickNameBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserNickNameBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_UserNickName_Batch ON '','' + [dbo].[T_PM_UserInfo].[UserNickName] + '','' LIKE ''%,'' + T_PM_UserInfo_UserNickName_Batch.col +'',%''
'
    
IF @PasswordBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@PasswordBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_Password_Batch ON '','' + [dbo].[T_PM_UserInfo].[Password] + '','' LIKE ''%,'' + T_PM_UserInfo_Password_Batch.col +'',%''
'
    
IF @XBBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@XBBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_XB_Batch ON '','' + [dbo].[T_PM_UserInfo].[XB] + '','' LIKE ''%,'' + T_PM_UserInfo_XB_Batch.col +'',%''
'
    
IF @MZBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@MZBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_MZ_Batch ON '','' + [dbo].[T_PM_UserInfo].[MZ] + '','' LIKE ''%,'' + T_PM_UserInfo_MZ_Batch.col +'',%''
'
    
IF @ZZMMBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@ZZMMBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_ZZMM_Batch ON '','' + [dbo].[T_PM_UserInfo].[ZZMM] + '','' LIKE ''%,'' + T_PM_UserInfo_ZZMM_Batch.col +'',%''
'
    
IF @SFZHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SFZHBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_SFZH_Batch ON '','' + [dbo].[T_PM_UserInfo].[SFZH] + '','' LIKE ''%,'' + T_PM_UserInfo_SFZH_Batch.col +'',%''
'
    
IF @SJHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@SJHBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_SJH_Batch ON '','' + [dbo].[T_PM_UserInfo].[SJH] + '','' LIKE ''%,'' + T_PM_UserInfo_SJH_Batch.col +'',%''
'
    
IF @BGDHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@BGDHBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_BGDH_Batch ON '','' + [dbo].[T_PM_UserInfo].[BGDH] + '','' LIKE ''%,'' + T_PM_UserInfo_BGDH_Batch.col +'',%''
'
    
IF @JTDHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@JTDHBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_JTDH_Batch ON '','' + [dbo].[T_PM_UserInfo].[JTDH] + '','' LIKE ''%,'' + T_PM_UserInfo_JTDH_Batch.col +'',%''
'
    
IF @EmailBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@EmailBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_Email_Batch ON '','' + [dbo].[T_PM_UserInfo].[Email] + '','' LIKE ''%,'' + T_PM_UserInfo_Email_Batch.col +'',%''
'
    
IF @QQHBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@QQHBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_QQH_Batch ON '','' + [dbo].[T_PM_UserInfo].[QQH] + '','' LIKE ''%,'' + T_PM_UserInfo_QQH_Batch.col +'',%''
'
    
IF @LoginTimeBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LoginTimeBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_LoginTime_Batch ON '','' + [dbo].[T_PM_UserInfo].[LoginTime] + '','' LIKE ''%,'' + T_PM_UserInfo_LoginTime_Batch.col +'',%''
'
    
IF @LastLoginIPBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LastLoginIPBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_LastLoginIP_Batch ON '','' + [dbo].[T_PM_UserInfo].[LastLoginIP] + '','' LIKE ''%,'' + T_PM_UserInfo_LastLoginIP_Batch.col +'',%''
'
    
IF @LastLoginDateBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LastLoginDateBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_LastLoginDate_Batch ON '','' + [dbo].[T_PM_UserInfo].[LastLoginDate] + '','' LIKE ''%,'' + T_PM_UserInfo_LastLoginDate_Batch.col +'',%''
'
    
IF @LoginTimesBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@LoginTimesBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_LoginTimes_Batch ON '','' + [dbo].[T_PM_UserInfo].[LoginTimes] + '','' LIKE ''%,'' + T_PM_UserInfo_LoginTimes_Batch.col +'',%''
'
    
IF @UserStatusBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@UserStatusBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_UserStatus_Batch ON '','' + [dbo].[T_PM_UserInfo].[UserStatus] + '','' LIKE ''%,'' + T_PM_UserInfo_UserStatus_Batch.col +'',%''
'
    
IF @vcodeBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@vcodeBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_vcode_Batch ON '','' + [dbo].[T_PM_UserInfo].[vcode] + '','' LIKE ''%,'' + T_PM_UserInfo_vcode_Batch.col +'',%''
'
    

--��ѯ����
SET @InnerSortText = '
[dbo].[T_PM_UserInfo].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_PM_UserInfo].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserInfoByObjectID]
GO

--��T_PM_UserInfo��ObjectIDΪ������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SELECT 
  
      [dbo].[T_PM_UserInfo].[ObjectID]
    
      , [dbo].[T_PM_UserInfo].[UserID]
    
      , [dbo].[T_PM_UserInfo].[UserLoginName]
    
      , [dbo].[T_PM_UserInfo].[UserGroupID]
    
      , [dbo].[T_PM_UserInfo].[SubjectID]
    
      , [dbo].[T_PM_UserInfo].[UserNickName]
    
      , [dbo].[T_PM_UserInfo].[Password]
    
      , [dbo].[T_PM_UserInfo].[XB]
    
      , [dbo].[T_PM_UserInfo].[MZ]
    
      , [dbo].[T_PM_UserInfo].[ZZMM]
    
      , [dbo].[T_PM_UserInfo].[SFZH]
    
      , [dbo].[T_PM_UserInfo].[SJH]
    
      , [dbo].[T_PM_UserInfo].[BGDH]
    
      , [dbo].[T_PM_UserInfo].[JTDH]
    
      , [dbo].[T_PM_UserInfo].[Email]
    
      , [dbo].[T_PM_UserInfo].[QQH]
    
      , [dbo].[T_PM_UserInfo].[LoginTime]
    
      , [dbo].[T_PM_UserInfo].[LastLoginIP]
    
      , [dbo].[T_PM_UserInfo].[LastLoginDate]
    
      , [dbo].[T_PM_UserInfo].[LoginTimes]
    
      , [dbo].[T_PM_UserInfo].[UserStatus]
    
      , [dbo].[T_PM_UserInfo].[vcode]
    
        ,[dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]([dbo].[T_PM_UserInfo].[UserGroupID]) AS [UserGroupID_T_PM_UserGroupInfo_UserGroupName]
        ,[SubjectID_T_BM_DWXX].[DWMC] AS [SubjectID_T_BM_DWXX_DWMC]
        ,[XB_Dictionary].[MC] AS [XB_Dictionary_MC]
        ,[MZ_Dictionary].[MC] AS [MZ_Dictionary_MC]
        ,[ZZMM_Dictionary].[MC] AS [ZZMM_Dictionary_MC]
        ,[UserStatus_Dictionary].[MC] AS [UserStatus_Dictionary_MC]
FROM [dbo].[T_PM_UserInfo]

    LEFT JOIN [dbo].[T_PM_UserGroupInfo] AS UserGroupID_T_PM_UserGroupInfo ON UserGroupID_T_PM_UserGroupInfo.[UserGroupID] = [dbo].[T_PM_UserInfo].[UserGroupID] 
    LEFT JOIN [dbo].[T_BM_DWXX] AS SubjectID_T_BM_DWXX ON SubjectID_T_BM_DWXX.[DWBH] = [dbo].[T_PM_UserInfo].[SubjectID] 
    LEFT JOIN [dbo].[Dictionary] AS XB_Dictionary ON XB_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[XB]  AND XB_Dictionary.[LX] = '0001'
    LEFT JOIN [dbo].[Dictionary] AS MZ_Dictionary ON MZ_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[MZ]  AND MZ_Dictionary.[LX] = '0002'
    LEFT JOIN [dbo].[Dictionary] AS ZZMM_Dictionary ON ZZMM_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[ZZMM]  AND ZZMM_Dictionary.[LX] = '0003'
    LEFT JOIN [dbo].[Dictionary] AS UserStatus_Dictionary ON UserStatus_Dictionary.[DM] = [dbo].[T_PM_UserInfo].[UserStatus]  AND UserStatus_Dictionary.[LX] = '0102'
WHERE
[dbo].[T_PM_UserInfo].[ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserInfoByKey]
GO

--��T_PM_UserInfo������Ϊ������ѯ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserInfoByKey] 

@UserID NVarChar(50) = NULL

AS
SELECT 
  
      [ObjectID]
    
      , [UserID]
    
      , [UserLoginName]
    
      , [UserGroupID]
    
      , [SubjectID]
    
      , [UserNickName]
    
      , [Password]
    
      , [XB]
    
      , [MZ]
    
      , [ZZMM]
    
      , [SFZH]
    
      , [SJH]
    
      , [BGDH]
    
      , [JTDH]
    
      , [Email]
    
      , [QQH]
    
      , [LoginTime]
    
      , [LastLoginIP]
    
      , [LastLoginDate]
    
      , [LoginTimes]
    
      , [UserStatus]
    
      , [vcode]
    
FROM [dbo].[T_PM_UserInfo]
WHERE

[UserID] = @UserID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_PM_UserInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_PM_UserInfoByObjectID]
GO

--��[T_PM_UserInfo]��ObjectIDΪ�����жϼ�¼�Ƿ���ڵĴ洢����

CREATE   PROCEDURE [dbo].[SP_IsExistT_PM_UserInfoByObjectID] 
@ObjectID nvarchar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*) 
FROM [dbo].[T_PM_UserInfo]
WHERE [ObjectID] = @ObjectID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_IsExistT_PM_UserInfoByKey]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_IsExistT_PM_UserInfoByKey]
GO

--��[T_PM_UserInfo]������Ϊ�����жϼ�¼�Ƿ���ڵĴ洢����

CREATE   PROCEDURE [dbo].[SP_IsExistT_PM_UserInfoByKey] 

@UserID NVarChar(50) = NULL
,@RecordCount int OUTPUT

AS
SELECT @RecordCount = Count(*)
FROM [dbo].[T_PM_UserInfo]
WHERE 

[UserID] = @UserID

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_CountT_PM_UserInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_CountT_PM_UserInfoByAnyCondition]
GO

--��T_PM_UserInfo��������ͳ�Ƽ�¼���ĵĴ洢����

CREATE   PROCEDURE [dbo].[SP_CountT_PM_UserInfoByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_PM_UserInfo].ObjectID IS NOT NULL '

--һ��һ��ر��ѯ����

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--����ͳ������

--һ��һ��ر�ͳ������

--�ۺ����



--����
SET @FromText = '
 FROM [dbo].[T_PM_UserInfo]'
--������һ��һ��ر�����
SET @FromText = @FromText + '

'
--������һ��һ��ر��а��ֶ�����
SET @FromText = @FromText + '

'
--������󶨱�����

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_PM_UserGroupInfo] AS [UserGroupID_T_PM_UserGroupInfo] ON '','' + [dbo].[T_PM_UserInfo].[UserGroupID] + '','' LIKE ''%,'' + [UserGroupID_T_PM_UserGroupInfo].[UserGroupID] + '',%'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[T_BM_DWXX] AS [SubjectID_T_BM_DWXX] ON [SubjectID_T_BM_DWXX].[DWBH] = [dbo].[T_PM_UserInfo].[SubjectID]  
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [XB_Dictionary] ON [XB_Dictionary].[DM] = [dbo].[T_PM_UserInfo].[XB]  AND XB_Dictionary.[LX] = ''0001'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [MZ_Dictionary] ON [MZ_Dictionary].[DM] = [dbo].[T_PM_UserInfo].[MZ]  AND MZ_Dictionary.[LX] = ''0002'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [ZZMM_Dictionary] ON [ZZMM_Dictionary].[DM] = [dbo].[T_PM_UserInfo].[ZZMM]  AND ZZMM_Dictionary.[LX] = ''0003'' 
'

SET @FromText = @FromText + '
    LEFT JOIN [dbo].[Dictionary] AS [UserStatus_Dictionary] ON [UserStatus_Dictionary].[DM] = [dbo].[T_PM_UserInfo].[UserStatus]  AND UserStatus_Dictionary.[LX] = ''0102'' 
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]') and OBJECTPROPERTY(id, N'IsProcedure') = 0)
drop FUNCTION [dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]
GO

CREATE  FUNCTION [dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]  (@InputValue  NVarChar(4000))  
RETURNS NVarchar(4000)
BEGIN 
DECLARE @Output NVarChar(4000) 
DECLARE @COUNT INT
DECLARE @OutputField NVarChar(100)
DECLARE RecordCursor Cursor  scroll dynamic
FOR
SELECT [UserGroupName]
FROM [dbo].[T_PM_UserGroupInfo]
WHERE [UserGroupID] IN (SELECT * FROM [dbo].F_SplitStr(@InputValue, ','))

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
      
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetMaxT_PM_UserInfoByUserID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetMaxT_PM_UserInfoByUserID]
GO

--��T_PM_UserInfo��UserIDΪ���������ֵ�Ĵ洢����

CREATE   PROCEDURE [dbo].[SP_GetMaxT_PM_UserInfoByUserID] 
@Prefix NVarChar(100) = ''
, @Number Int = 0
, @MaxValue NVarChar(100) OUTPUT
, @RecordCount int OUTPUT

AS
IF @Prefix IS NULL 
     SET @Prefix = ''
SELECT @MaxValue = MAX(LEFT(UserID, LEN(@Prefix) + @Number))
FROM [dbo].[T_PM_UserInfo]
WHERE
UserID LIKE @Prefix + '%'
IF @MaxValue IS NULL 
    SET @RecordCount = 0
ELSE
    SET @RecordCount = 1
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_GetTreeData_T_PM_UserInfo_SubjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_GetTreeData_T_PM_UserInfo_SubjectID]
GO

CREATE   PROCEDURE [dbo].[SP_GetTreeData_T_PM_UserInfo_SubjectID] 
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
    [SubjectID] AS ParentID
FROM [dbo].[T_PM_UserInfo] 
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


--����DictionaryȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICT','Dictionary','Dictionary����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = 'Dictionary', [PurviewTypeContent] =  'Dictionary����'
    WHERE [PurviewTypeID] = 'DICT'
END
--����Dictionary���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICT01','Dictionary���','DICT','Dictionary���',0,'DictionaryWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary���' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'
END
--����Dictionary�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT02','Dictionary�޸�','DICT','Dictionary�޸�',0,'DictionaryWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary�޸�' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'
END
--����Dictionary���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT04','Dictionary���','DICT','Dictionary���',1,'DictionaryWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary���' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'
END
--����Dictionary����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT05','Dictionary����','DICT','Dictionary����',0,'DictionaryWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'
END
--����Dictionaryͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT06','Dictionaryͳ��','DICT','Dictionaryͳ��',0,'DictionaryWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionaryͳ��' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'
END
--����Dictionaryɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT07','Dictionaryɾ��','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionaryɾ��' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'
END
--����Dictionary����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT08','Dictionary����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'
END
--����Dictionary����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT09','Dictionary�ĵ�����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary�ĵ�����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'
END
--����Dictionary�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT10','Dictionary���ݼ�����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary���ݼ�����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'
END

--�����ֵ�����Ȩ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICTT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICTT','�ֵ�����','�ֵ����͹���','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�ֵ�����', [PurviewTypeContent] =  '�ֵ����͹���'
    WHERE [PurviewTypeID] = 'DICTT'
END
--�����ֵ��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICTT01','�ֵ��������','DICTT','�ֵ��������',0,'DictionaryTypeWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ��������' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT01'
END
--�����ֵ������޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT02','�ֵ������޸�','DICTT','�ֵ������޸�',0,'DictionaryTypeWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ������޸�' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT02'
END
--�����ֵ��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT04','�ֵ��������','DICTT','�ֵ��������',1,'DictionaryTypeWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ��������' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT04'
END
--�����ֵ���������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT05','�ֵ���������','DICTT','�ֵ���������',0,'DictionaryTypeWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���������' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT05'
END
--�����ֵ�����ͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT06','�ֵ�����ͳ��','DICTT','�ֵ�����ͳ��',0,'DictionaryTypeWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ�����ͳ��' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT06'
END
--�����ֵ�����ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT07','�ֵ�����ɾ��','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ�����ɾ��' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT07'
END
--�����ֵ����͵���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT08','�ֵ����͵���','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ����͵���' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT08'
END
--�����ֵ����͵���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT09','�ֵ������ĵ�����','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ������ĵ�����' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT09'
END
--�����ֵ����͵������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT10','�ֵ��������ݼ�����','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ��������ݼ�����' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT10'
END

--���뱨����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'FR'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('FR','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'FR'
END
--���뱨����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('FR01','������Ϣ���','FR','������Ϣ���',0,'FilterReportWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR01'
END
--���뱨����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR02','������Ϣ�޸�','FR','������Ϣ�޸�',0,'FilterReportWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR02'
END
--���뱨����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR04','������Ϣ���','FR','������Ϣ���',1,'FilterReportWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR04'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR05','������Ϣ����','FR','������Ϣ����',0,'FilterReportWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR05'
END
--���뱨����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR06','������Ϣͳ��','FR','������Ϣͳ��',0,'FilterReportWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR06'
END
--���뱨����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR07','������Ϣɾ��','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR07'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR08','������Ϣ����','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR08'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR09','������Ϣ�ĵ�����','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR09'
END
--���뱨����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR10','������Ϣ���ݼ�����','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR10'
END

--������ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DXX'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DXX','��Ϣ','��Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '��Ϣ', [PurviewTypeContent] =  '��Ϣ����'
    WHERE [PurviewTypeID] = 'DXX'
END
--������Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX01','��Ϣ���','DXX','��Ϣ���',0,'ShortMessageWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ���' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX01'
END
--������Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX02','��Ϣ�޸�','DXX','��Ϣ�޸�',0,'ShortMessageWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX02'
END
--������Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX04','��Ϣ���','DXX','��Ϣ���',1,'ShortMessageWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ���' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX04'
END
--������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX05','��Ϣ����','DXX','��Ϣ����',0,'ShortMessageWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX05'
END
--������Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX06','��Ϣͳ��','DXX','��Ϣͳ��',0,'ShortMessageWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣͳ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX06'
END
--������Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX07','��Ϣɾ��','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣɾ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX07'
END
--������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX08','��Ϣ����','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX08'
END
--������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX09','��Ϣ�ĵ�����','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX09'
END
--������Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX10','��Ϣ���ݼ�����','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX10'
END

--���뷢����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('DXX51','������','DXX','������',1,'ShortMessageWebUISearch.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������' ,
    [PageFileName] = 'ShortMessageWebUISearch.aspx?p=DXX51'
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51'
END
--���뷢�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX51_Add','���������','DXX','���������',0,'ShortMessageWebUIAdd.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '���������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Add'
END
--���뷢�����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX51_Modify','�������޸�','DXX','�������޸�',0,'ShortMessageWebUIModify.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�������޸�' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Modify'
END
--���뷢��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX51_Detail','����������','DXX','����������',0,'ShortMessageWebUIDetail.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '����������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Detail'
END
--���뷢����ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX51_Delete','������ɾ��','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������ɾ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Delete'
END

--�����ռ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('DXX52','�ռ���','DXX','�ռ���',1,'ShortMessageWebUISearch.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ���' ,
    [PageFileName] = 'ShortMessageWebUISearch.aspx?p=DXX52'
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52'
END
--�����ռ������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX52_Add','�ռ������','DXX','�ռ������',0,'ShortMessageWebUIAdd.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Add'
END
--�����ռ����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX52_Modify','�ռ����޸�','DXX','�ռ����޸�',0,'ShortMessageWebUIModify.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ����޸�' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Modify'
END
--�����ռ�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX52_Detail','�ռ�������','DXX','�ռ�������',0,'ShortMessageWebUIDetail.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ�������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Detail'
END
--�����ռ���ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX52_Delete','�ռ���ɾ��','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ���ɾ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Delete'
END

--���빫����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BG0601'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BG0601','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'BG0601'
END
--���빫����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060101'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060101','������Ϣ���','BG0601','������Ϣ���',0,'T_BG_0601WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060101'
END
--���빫����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060102'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060102','������Ϣ�޸�','BG0601','������Ϣ�޸�',0,'T_BG_0601WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060102'
END
--���빫����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060104'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060104','������Ϣ���','BG0601','������Ϣ���',1,'T_BG_0601WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060104'
END
--���빫����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060105'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060105','������Ϣ����','BG0601','������Ϣ����',0,'T_BG_0601WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060105'
END
--���빫����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060106'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060106','������Ϣͳ��','BG0601','������Ϣͳ��',0,'T_BG_0601WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060106'
END
--���빫����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060107'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060107','������Ϣɾ��','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060107'
END
--���빫����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060108'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060108','������Ϣ����','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060108'
END
--���빫����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060109'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060109','������Ϣ�ĵ�����','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060109'
END
--���빫����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060110'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060110','������Ϣ���ݼ�����','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060110'
END

--�����ҷ�������ϢȨ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BG060151','�ҷ�������Ϣ','BG0601','�ҷ�������Ϣ',1,'T_BG_0601WebUISearch.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ' ,
    [PageFileName] = 'T_BG_0601WebUISearch.aspx?p=BG060151'
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151'
END
--�����ҷ�������Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060151_Add','�ҷ�������Ϣ���','BG0601','�ҷ�������Ϣ���',0,'T_BG_0601WebUIAdd.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ���' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Add'
END
--�����ҷ�������Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060151_Modify','�ҷ�������Ϣ�޸�','BG0601','�ҷ�������Ϣ�޸�',0,'T_BG_0601WebUIModify.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Modify'
END
--�����ҷ�������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060151_Detail','�ҷ�������Ϣ����','BG0601','�ҷ�������Ϣ����',0,'T_BG_0601WebUIDetail.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Detail'
END
--�����ҷ�������Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060151_Delete','�ҷ�������Ϣɾ��','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Delete'
END

--���빫����Ϣ��ĿȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BG0602'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BG0602','������Ϣ��Ŀ','������Ϣ��Ŀ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ��Ŀ', [PurviewTypeContent] =  '������Ϣ��Ŀ����'
    WHERE [PurviewTypeID] = 'BG0602'
END
--���빫����Ϣ��Ŀ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060201'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060201','������Ϣ��Ŀ���','BG0602','������Ϣ��Ŀ���',0,'T_BG_0602WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ���' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060201'
END
--���빫����Ϣ��Ŀ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060202'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060202','������Ϣ��Ŀ�޸�','BG0602','������Ϣ��Ŀ�޸�',0,'T_BG_0602WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ�޸�' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060202'
END
--���빫����Ϣ��Ŀ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060204'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060204','������Ϣ��Ŀ���','BG0602','������Ϣ��Ŀ���',1,'T_BG_0602WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ���' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060204'
END
--���빫����Ϣ��Ŀ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060205'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060205','������Ϣ��Ŀ����','BG0602','������Ϣ��Ŀ����',0,'T_BG_0602WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060205'
END
--���빫����Ϣ��Ŀͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060206'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060206','������Ϣ��Ŀͳ��','BG0602','������Ϣ��Ŀͳ��',0,'T_BG_0602WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀͳ��' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060206'
END
--���빫����Ϣ��Ŀɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060207'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060207','������Ϣ��Ŀɾ��','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀɾ��' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060207'
END
--���빫����Ϣ��Ŀ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060208'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060208','������Ϣ��Ŀ����','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060208'
END
--���빫����Ϣ��Ŀ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060209'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060209','������Ϣ��Ŀ�ĵ�����','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ�ĵ�����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060209'
END
--���빫����Ϣ��Ŀ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060210'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060210','������Ϣ��Ŀ���ݼ�����','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ���ݼ�����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060210'
END

--���뵥λ��ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DW'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DW','��λ��Ϣ','��λ��Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '��λ��Ϣ', [PurviewTypeContent] =  '��λ��Ϣ����'
    WHERE [PurviewTypeID] = 'DW'
END
--���뵥λ��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DW01','��λ��Ϣ���','DW','��λ��Ϣ���',0,'T_BM_DWXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ���' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW01'
END
--���뵥λ��Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW02','��λ��Ϣ�޸�','DW','��λ��Ϣ�޸�',0,'T_BM_DWXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW02'
END
--���뵥λ��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW04','��λ��Ϣ���','DW','��λ��Ϣ���',1,'T_BM_DWXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ���' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW04'
END
--���뵥λ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW05','��λ��Ϣ����','DW','��λ��Ϣ����',0,'T_BM_DWXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW05'
END
--���뵥λ��Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW06','��λ��Ϣͳ��','DW','��λ��Ϣͳ��',0,'T_BM_DWXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣͳ��' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW06'
END
--���뵥λ��Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW07','��λ��Ϣɾ��','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣɾ��' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW07'
END
--���뵥λ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW08','��λ��Ϣ����','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW08'
END
--���뵥λ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW09','��λ��Ϣ�ĵ�����','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW09'
END
--���뵥λ��Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW10','��λ��Ϣ���ݼ�����','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW10'
END

--���빤����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'GZ'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('GZ','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'GZ'
END
--���빤����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('GZ01','������Ϣ���','GZ','������Ϣ���',0,'T_BM_GZXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ01'
END
--���빤����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ02','������Ϣ�޸�','GZ','������Ϣ�޸�',0,'T_BM_GZXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ02'
END
--���빤����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ04','������Ϣ���','GZ','������Ϣ���',1,'T_BM_GZXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ04'
END
--���빤����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ05','������Ϣ����','GZ','������Ϣ����',0,'T_BM_GZXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ05'
END
--���빤����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ06','������Ϣͳ��','GZ','������Ϣͳ��',0,'T_BM_GZXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ06'
END
--���빤����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ07','������Ϣɾ��','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ07'
END
--���빤����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ08','������Ϣ����','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ08'
END
--���빤����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ09','������Ϣ�ĵ�����','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ09'
END
--���빤����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ10','������Ϣ���ݼ�����','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ10'
END

--�����ҵĹ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('GZ51','�ҵĹ���','GZ','�ҵĹ���',1,'T_BM_GZXXWebUISearch.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ���' ,
    [PageFileName] = 'T_BM_GZXXWebUISearch.aspx?p=GZ51'
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51'
END
--�����ҵĹ������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('GZ51_Add','�ҵĹ������','GZ','�ҵĹ������',0,'T_BM_GZXXWebUIAdd.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ������' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Add'
END
--�����ҵĹ����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ51_Modify','�ҵĹ����޸�','GZ','�ҵĹ����޸�',0,'T_BM_GZXXWebUIModify.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ����޸�' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Modify'
END
--�����ҵĹ�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ51_Detail','�ҵĹ�������','GZ','�ҵĹ�������',0,'T_BM_GZXXWebUIDetail.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ�������' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Detail'
END
--�����ҵĹ���ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ51_Delete','�ҵĹ���ɾ��','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ���ɾ��' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Delete'
END

--����Ȩ����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'PI'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('PI','Ȩ����Ϣ','Ȩ����Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = 'Ȩ����Ϣ', [PurviewTypeContent] =  'Ȩ����Ϣ����'
    WHERE [PurviewTypeID] = 'PI'
END
--����Ȩ����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('PI01','Ȩ����Ϣ���','PI','Ȩ����Ϣ���',0,'T_PM_PurviewInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ���' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI01'
END
--����Ȩ����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI02','Ȩ����Ϣ�޸�','PI','Ȩ����Ϣ�޸�',0,'T_PM_PurviewInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI02'
END
--����Ȩ����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI04','Ȩ����Ϣ���','PI','Ȩ����Ϣ���',1,'T_PM_PurviewInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ���' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI04'
END
--����Ȩ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI05','Ȩ����Ϣ����','PI','Ȩ����Ϣ����',0,'T_PM_PurviewInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI05'
END
--����Ȩ����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI06','Ȩ����Ϣͳ��','PI','Ȩ����Ϣͳ��',0,'T_PM_PurviewInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣͳ��' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI06'
END
--����Ȩ����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI07','Ȩ����Ϣɾ��','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣɾ��' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI07'
END
--����Ȩ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI08','Ȩ����Ϣ����','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI08'
END
--����Ȩ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI09','Ȩ����Ϣ�ĵ�����','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI09'
END
--����Ȩ����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI10','Ȩ����Ϣ���ݼ�����','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI10'
END

--�����û�����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'UG'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('UG','�û�����Ϣ','�û�����Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�û�����Ϣ', [PurviewTypeContent] =  '�û�����Ϣ����'
    WHERE [PurviewTypeID] = 'UG'
END
--�����û�����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('UG01','�û�����Ϣ���','UG','�û�����Ϣ���',0,'T_PM_UserGroupInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ���' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG01'
END
--�����û�����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG02','�û�����Ϣ�޸�','UG','�û�����Ϣ�޸�',0,'T_PM_UserGroupInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG02'
END
--�����û�����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG04','�û�����Ϣ���','UG','�û�����Ϣ���',1,'T_PM_UserGroupInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ���' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG04'
END
--�����û�����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG05','�û�����Ϣ����','UG','�û�����Ϣ����',0,'T_PM_UserGroupInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG05'
END
--�����û�����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG06','�û�����Ϣͳ��','UG','�û�����Ϣͳ��',0,'T_PM_UserGroupInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣͳ��' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG06'
END
--�����û�����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG07','�û�����Ϣɾ��','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣɾ��' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG07'
END
--�����û�����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG08','�û�����Ϣ����','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG08'
END
--�����û�����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG09','�û�����Ϣ�ĵ�����','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG09'
END
--�����û�����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG10','�û�����Ϣ���ݼ�����','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG10'
END

--�����û���ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'USER'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('USER','�û���Ϣ','�û���Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�û���Ϣ', [PurviewTypeContent] =  '�û���Ϣ����'
    WHERE [PurviewTypeID] = 'USER'
END
--�����û���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('USER01','�û���Ϣ���','USER','�û���Ϣ���',0,'T_PM_UserInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ���' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER01'
END
--�����û���Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER02','�û���Ϣ�޸�','USER','�û���Ϣ�޸�',0,'T_PM_UserInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER02'
END
--�����û���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER04','�û���Ϣ���','USER','�û���Ϣ���',1,'T_PM_UserInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ���' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER04'
END
--�����û���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER05','�û���Ϣ����','USER','�û���Ϣ����',0,'T_PM_UserInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER05'
END
--�����û���Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER06','�û���Ϣͳ��','USER','�û���Ϣͳ��',0,'T_PM_UserInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣͳ��' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER06'
END
--�����û���Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER07','�û���Ϣɾ��','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣɾ��' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER07'
END
--�����û���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER08','�û���Ϣ����','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER08'
END
--�����û���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER09','�û���Ϣ�ĵ�����','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER09'
END
--�����û���Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER10','�û���Ϣ���ݼ�����','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER10'
END

--����ͨѶ¼Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('USER51','ͨѶ¼','USER','ͨѶ¼',1,'T_PM_UserInfoWebUISearch.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼' ,
    [PageFileName] = 'T_PM_UserInfoWebUISearch.aspx?p=USER51'
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51'
END
--����ͨѶ¼���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('USER51_Add','ͨѶ¼���','USER','ͨѶ¼���',0,'T_PM_UserInfoWebUIAdd.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼���' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Add'
END
--����ͨѶ¼�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER51_Modify','ͨѶ¼�޸�','USER','ͨѶ¼�޸�',0,'T_PM_UserInfoWebUIModify.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼�޸�' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Modify'
END
--����ͨѶ¼����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER51_Detail','ͨѶ¼����','USER','ͨѶ¼����',0,'T_PM_UserInfoWebUIDetail.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Detail'
END
--����ͨѶ¼ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER51_Delete','ͨѶ¼ɾ��','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼ɾ��' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Delete'
END

--�����������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER61_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('USER61_Modify','��������','USER','��������',1,'T_PM_UserInfoWebUIAdd.aspx?a=e' +CHAR(38)+ 'p=USER61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��������' ,
    [PageFileName] = 'T_PM_UserInfoWebUIAdd.aspx?a=e' +CHAR(38)+ 'p=USER61'
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER61_Modify'
END


USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'Dictionary'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'Dictionary'
			   ,'DICT'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DM' AND [TableName] = 'Dictionary'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DM'
			   ,'Dictionary'
			   ,'DICT'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DM' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LX' AND [TableName] = 'Dictionary'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LX'
			   ,'Dictionary'
			   ,'DICT'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LX' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'MC' AND [TableName] = 'Dictionary'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'MC'
			   ,'Dictionary'
			   ,'DICT'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'MC' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJDM' AND [TableName] = 'Dictionary'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SJDM'
			   ,'Dictionary'
			   ,'DICT'
			   ,'�ϼ�����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '�ϼ�����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJDM' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SM' AND [TableName] = 'Dictionary'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SM'
			   ,'Dictionary'
			   ,'DICT'
			   ,'˵��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '˵��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SM' AND [TableName] = 'Dictionary'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'DictionaryType'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'DictionaryType'
			   ,'DICTT'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICTT'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'DictionaryType'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DM' AND [TableName] = 'DictionaryType'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DM'
			   ,'DictionaryType'
			   ,'DICTT'
			   ,'���ʹ���'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICTT'
		  ,[FieldRemark] = '���ʹ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DM' AND [TableName] = 'DictionaryType'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'MC' AND [TableName] = 'DictionaryType'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'MC'
			   ,'DictionaryType'
			   ,'DICTT'
			   ,'��������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICTT'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'MC' AND [TableName] = 'DictionaryType'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SM' AND [TableName] = 'DictionaryType'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SM'
			   ,'DictionaryType'
			   ,'DICTT'
			   ,'˵��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DICTT'
		  ,[FieldRemark] = '˵��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SM' AND [TableName] = 'DictionaryType'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'FilterReport'
			   ,'FR'
			   ,''
			   ,1
			   ,0
			   ,0
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BGMC' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BGMC'
			   ,'FilterReport'
			   ,'FR'
			   ,'��������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BGMC' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserID' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserID'
			   ,'FilterReport'
			   ,'FR'
			   ,'�û����'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = '�û����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserID' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BGLX' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BGLX'
			   ,'FilterReport'
			   ,'FR'
			   ,'��������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BGLX' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'GXBG' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'GXBG'
			   ,'FilterReport'
			   ,'FR'
			   ,'�������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = '�������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'GXBG' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XTBG' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XTBG'
			   ,'FilterReport'
			   ,'FR'
			   ,'ϵͳ����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = 'ϵͳ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XTBG' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BGCXTJ' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BGCXTJ'
			   ,'FilterReport'
			   ,'FR'
			   ,'��������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BGCXTJ' AND [TableName] = 'FilterReport'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BGCJSJ' AND [TableName] = 'FilterReport'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BGCJSJ'
			   ,'FilterReport'
			   ,'FR'
			   ,'����ʱ��'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'FR'
		  ,[FieldRemark] = '����ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BGCJSJ' AND [TableName] = 'FilterReport'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'ShortMessage'
			   ,'DXX'
			   ,''
			   ,1
			   ,0
			   ,0
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXBT' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DXXBT'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DXXBT' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXLX' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DXXLX'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'����'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'DXXLX' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXNR' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DXXNR'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DXXNR' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXFJ' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DXXFJ'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DXXFJ' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSSJ' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FSSJ'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'����ʱ��'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '����ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FSSJ' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSR' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FSR'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'������'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FSR' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSBM' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FSBM'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'���Ͳ���'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '���Ͳ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FSBM' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSIP' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FSIP'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'����IP'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '����IP'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'FSIP' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JSR' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JSR'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JSR' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFCK' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFCK'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'�鿴״̬'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '�鿴״̬'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'SFCK' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'CKSJ' AND [TableName] = 'ShortMessage'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'CKSJ'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'�鿴ʱ��'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '�鿴ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'CKSJ' AND [TableName] = 'ShortMessage'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBH' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBH'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'������'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'FBH' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BT' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BT'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BT' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LanguageID'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'����'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBLM' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBLM'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'������Ŀ'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '������Ŀ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBLM' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBBM' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBBM'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBBM' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBZT' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBZT'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'����ר��'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '����ר��'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'FBZT' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXLX' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XXLX'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��Ϣ����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��Ϣ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'XXLX' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXTPDZ' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XXTPDZ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��ϢͼƬ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��ϢͼƬ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XXTPDZ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXNR' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XXNR'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��Ϣ����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��Ϣ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XXNR' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FJXZDZ' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FJXZDZ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FJXZDZ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PZRJGH' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PZRJGH'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��׼��'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��׼��'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PZRJGH' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXZT' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XXZT'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��Ϣ״̬'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��Ϣ״̬'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'XXZT' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'IsTop' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'IsTop'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'�Ƿ��ö�'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '�Ƿ��ö�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'IsTop' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'TopSort' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'TopSort'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'�ö����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '�ö����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'TopSort' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'IsBest' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'IsBest'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'�Ƽ�'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '�Ƽ�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'IsBest' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YXSJRQ' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'YXSJRQ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'��Чʱ��'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '��Чʱ��'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'YXSJRQ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBRJGH' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBRJGH'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'������'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBRJGH' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBSJRQ' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBSJRQ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'����ʱ��'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '����ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBSJRQ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBIP' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FBIP'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'����IP'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '����IP'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBIP' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LLCS' AND [TableName] = 'T_BG_0601'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LLCS'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'�������'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '�������'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'LLCS' AND [TableName] = 'T_BG_0601'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMH' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMH'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'��Ŀ��'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '��Ŀ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMH' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LanguageID'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'����'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMM' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMM'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'��Ŀ��'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '��Ŀ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMM' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJLMH' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SJLMH'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'�ϼ���Ŀ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '�ϼ���Ŀ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJLMH' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMTP' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMTP'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'��ĿͼƬ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '��ĿͼƬ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMTP' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMNR' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMNR'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'��Ŀ��ʾ����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '��Ŀ��ʾ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMNR' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMLBYS' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMLBYS'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'��Ŀ�б���ʽ'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '��Ŀ�б���ʽ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMLBYS' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFLBLM' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFLBLM'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'�б�������Ŀ'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '�б�������Ŀ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFLBLM' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFWBURL' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFWBURL'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'�ⲿ��Ŀ'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '�ⲿ��Ŀ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFWBURL' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'WBURL' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'WBURL'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'�ⲿ��Ŀ����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '�ⲿ��Ŀ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'WBURL' AND [TableName] = 'T_BG_0602'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DWBH' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DWBH'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'��λ���'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '��λ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DWBH' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DWMC' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DWMC'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'��λ����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '��λ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DWMC' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJDWBH' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SJDWBH'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'�ϼ���λ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '�ϼ���λ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJDWBH' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DZ' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DZ'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'��ַ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '��ַ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DZ' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YB' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'YB'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'�ʱ�'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '�ʱ�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'YB' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LXBM' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LXBM'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'��ϵ����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '��ϵ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LXBM' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LXDH' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LXDH'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'��ϵ�绰'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '��ϵ�绰'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LXDH' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'Email' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'Email'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'Email'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = 'Email'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'Email' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LXR' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LXR'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'��ϵ��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '��ϵ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LXR' AND [TableName] = 'T_BM_DWXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJ' AND [TableName] = 'T_BM_DWXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SJ'
			   ,'T_BM_DWXX'
			   ,'DW'
			   ,'�ֻ�'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DW'
		  ,[FieldRemark] = '�ֻ�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJ' AND [TableName] = 'T_BM_DWXX'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XM' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XM'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XM' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XB' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XB'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�Ա�'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�Ա�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XB' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFZH' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFZH'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'���֤��'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '���֤��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFZH' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FFGZNY' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FFGZNY'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FFGZNY' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JCGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JCGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'��������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JCGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JSDJGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JSDJGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�����ȼ�����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�����ȼ�����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JSDJGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ZWGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ZWGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ְ����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ְ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'ZWGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JBGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JBGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JBGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JKDQJT' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JKDQJT'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JKDQJT' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JKTSGWJT' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JKTSGWJT'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����ظڽ���'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����ظڽ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JKTSGWJT' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'GLGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'GLGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'���乤��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '���乤��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'GLGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XJGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XJGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'н������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'н������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XJGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'TGBF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'TGBF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'10%��߲���'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '10%��߲���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'TGBF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DHF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DHF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�绰��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�绰��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DHF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DSZNF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DSZNF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'������Ů��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '������Ů��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DSZNF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FNWSHLF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'FNWSHLF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'��Ů������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '��Ů������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FNWSHLF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'HLF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'HLF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'HLF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JJ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JJ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ȡů����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ȡů����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JJ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JTF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JTF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'��ͨ��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '��ͨ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JTF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JHLGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JHLGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�̻��乤��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�̻��乤��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JHLGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JT' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JT'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JT' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'QTBT' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'QTBT'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'��������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'QTBT' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DFXJT' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DFXJT'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�ط��Խ���'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�ط��Խ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DFXJT' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YFX' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'YFX'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'Ӧ����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'Ӧ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'YFX' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'QTKK' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'QTKK'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�����ۿ�'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�����ۿ�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'QTKK' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SYBX' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SYBX'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ʧҵ����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ʧҵ����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SYBX' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SDNQF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SDNQF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ˮ��ů����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ˮ��ů����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SDNQF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SDS' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SDS'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'����˰'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '����˰'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SDS' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YLBX' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'YLBX'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'���ϱ���'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '���ϱ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'YLBX' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YLIBX' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'YLIBX'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ҽ�Ʊ���'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ҽ�Ʊ���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'YLIBX' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YSSHF' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'YSSHF'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'���������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '���������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'YSSHF' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ZFGJJ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ZFGJJ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ס��������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ס��������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'ZFGJJ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'KFX' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'KFX'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'�۷���'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '�۷���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'KFX' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFGZ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFGZ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'ʵ������'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = 'ʵ������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFGZ' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'GZKKSM' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'GZKKSM'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'˵��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '˵��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'GZKKSM' AND [TableName] = 'T_BM_GZXX'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'TJSJ' AND [TableName] = 'T_BM_GZXX'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'TJSJ'
			   ,'T_BM_GZXX'
			   ,'GZ'
			   ,'���ʱ��'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'GZ'
		  ,[FieldRemark] = '���ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'TJSJ' AND [TableName] = 'T_BM_GZXX'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PurviewID' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PurviewID'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,0
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PurviewID' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PurviewName' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PurviewName'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,0
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PurviewName' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PurviewTypeID' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PurviewTypeID'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,0
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PurviewTypeID' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PurviewContent' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PurviewContent'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PurviewContent' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PurviewRemark' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PurviewRemark'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PurviewRemark' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'IsPageMenu' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'IsPageMenu'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'IsPageMenu' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PageFileName' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PageFileName'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PageFileName' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PageFileParameter' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PageFileParameter'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PageFileParameter' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PageFilePath' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'PageFilePath'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PageFilePath' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UpdateDate' AND [TableName] = 'T_PM_PurviewInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UpdateDate'
			   ,'T_PM_PurviewInfo'
			   ,'PI'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'PI'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'UpdateDate' AND [TableName] = 'T_PM_PurviewInfo'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupID' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserGroupID'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'�û�����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '�û�����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupID' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupName' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserGroupName'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'�û�������'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '�û�������'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupName' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupContent' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserGroupContent'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'����'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupContent' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupRemark' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserGroupRemark'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'��ע'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '��ע'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupRemark' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DefaultPage' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'DefaultPage'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'ϵͳĬ��ҳ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = 'ϵͳĬ��ҳ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DefaultPage' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UpdateDate' AND [TableName] = 'T_PM_UserGroupInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UpdateDate'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'����ʱ��'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '����ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UpdateDate' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserID' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserID'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�û����'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�û����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserID' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserLoginName' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserLoginName'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�û���'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�û���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserLoginName' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupID' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserGroupID'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�û���'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�û���'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupID' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SubjectID' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SubjectID'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�����λ'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�����λ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SubjectID' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserNickName' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserNickName'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserNickName' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'Password' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'Password'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'Password' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XB' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'XB'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�Ա�'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�Ա�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XB' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'MZ' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'MZ'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'����'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'MZ' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ZZMM' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ZZMM'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'������ò'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '������ò'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'ZZMM' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFZH' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFZH'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'���֤��'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '���֤��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFZH' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJH' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SJH'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�ֻ�'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�ֻ�'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJH' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BGDH' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'BGDH'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�칫�绰'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�칫�绰'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BGDH' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JTDH' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'JTDH'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'��ͥ�绰'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '��ͥ�绰'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JTDH' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'Email' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'Email'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'Email'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = 'Email'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'Email' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'QQH' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'QQH'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'QQ'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = 'QQ'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'QQH' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LoginTime' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LoginTime'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'��¼ʱ��'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '��¼ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LoginTime' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LastLoginIP' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LastLoginIP'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'��¼IP'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '��¼IP'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LastLoginIP' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LastLoginDate' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LastLoginDate'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�ϴ�ʱ��'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�ϴ�ʱ��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LastLoginDate' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LoginTimes' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LoginTimes'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'��¼����'
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '��¼����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LoginTimes' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserStatus' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'UserStatus'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'�û�״̬'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '�û�״̬'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'UserStatus' AND [TableName] = 'T_PM_UserInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'vcode' AND [TableName] = 'T_PM_UserInfo'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'vcode'
			   ,'T_PM_UserInfo'
			   ,'USER'
			   ,'��֤��'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'USER'
		  ,[FieldRemark] = '��֤��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'vcode' AND [TableName] = 'T_PM_UserInfo'
END
GO

