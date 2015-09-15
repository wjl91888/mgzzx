if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_InsertT_PM_UserInfo]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_InsertT_PM_UserInfo]
GO

--表T_PM_UserInfo插入的存储过程

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
,@lcode UniqueIdentifier   = NULL

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
IF @lcode IS NULL
    SET @lcode = newid()
SET XACT_ABORT ON
BEGIN TRANSACTION
    --插入主表信息
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
    ,[lcode]
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
    ,@lcode
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
if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_UpdateT_PM_UserInfoByAnyCondition]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_UpdateT_PM_UserInfoByAnyCondition]
GO

--表T_PM_UserInfo任意条件更新的存储过程

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

, @lcode nvarchar(50) = NULL
        
, @lcodeValue nvarchar(50) = NULL
, @lcodeBatch nvarchar(1000) = NULL

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
    
    IF @lcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].lcode = '''+CAST(@lcode AS nvarchar(100))+''' '
            
    IF @lcodeBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND '''+CAST(@lcodeBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].lcode)+''%'' '
    
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
    
    IF @lcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].lcode LIKE '''+CAST(@lcode AS nvarchar(100))+'%'' '
        
    IF @lcodeBatch IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR '''+CAST(@lcodeBatch AS nvarchar(4000))+''' LIKE ''%''+CONVERT(nvarchar(50), [dbo].[T_PM_UserInfo].lcode)+''%'' '
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT @RecordCount=COUNT(*) FROM [DB_MGZZX].[dbo].[T_PM_UserInfo] WHERE ' + @ConditionText
EXEC sp_executesql @SqlText,N'@RecordCount int OUTPUT',@RecordCount OUTPUT   --返回@RecordCount

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
  
    IF @lcodeValue IS NOT NULL
        SET @SqlText = @SqlText + ' ,lcode = @lcodeValue'
    ELSE
        SET @SqlText = @SqlText + ' ,lcode = [DB_MGZZX].[dbo].[T_PM_UserInfo].lcode'
  
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

--表T_PM_UserInfo以ObjectID为条件更新的存储过程

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
,@lcode nvarchar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
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
    , [lcode] = @lcode
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

--表T_PM_UserInfo以主键为条件更新的存储过程

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
,@lcode nvarchar(50) = NULL

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --主表更新
    
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
    
    IF @lcode IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [lcode] = @lcode
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

--表T_PM_UserInfo以ObjectID为条件批量更新的存储过程

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

,@lcode nvarchar(50) = NULL


AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表更新
    
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
    
    IF @lcode IS NOT NULL
    BEGIN
        UPDATE [dbo].[T_PM_UserInfo]
        SET [lcode] = @lcode WHERE (@ObjectIDBatch) LIKE '%'+CONVERT(varchar(36), [ObjectID])+'%'
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

--表T_PM_UserInfo以ObjectID为条件删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserInfoByObjectID] 
@ObjectID uniqueidentifier

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
    --主表删除
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

--表T_PM_UserInfo以主键为条件删除的存储过程

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

--表T_PM_UserInfo以ObjectID为条件批量删除的存储过程

CREATE   PROCEDURE [dbo].[SP_DeleteT_PM_UserInfoByObjectIDBatch] 
@ObjectIDBatch nvarchar(4000)

AS
SET XACT_ABORT ON
BEGIN TRANSACTION
    --更新相关表信息
    
--主表删除
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

--表T_PM_UserInfo任意条件查询的存储过程

CREATE   PROCEDURE [dbo].[SP_SelectT_PM_UserInfoByAnyCondition] 
--主表参数

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

, @lcode nvarchar(50) = NULL
        
, @lcodeBatch nvarchar(4000) = NULL

--一对一相关表参数

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
    --主表查询条件
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
            
    IF @lcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' AND [dbo].[T_PM_UserInfo].[lcode] = '''+CAST(@lcode AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
ELSE IF @QueryType = 'OR'
BEGIN
    --主表查询条件
    SET @ConditionText = '( [dbo].[T_PM_UserInfo].ObjectID IS NULL '
    
    IF @ObjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[ObjectID] = '''+CAST(@ObjectID AS nvarchar(100))+''' '
            
    IF @UserID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserID] = '''+CAST(@UserID AS nvarchar(100))+''' '
            
    IF @UserLoginName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserLoginName] LIKE ''%'+CAST(@UserLoginName AS nvarchar(100))+'%'' '
            
    IF @UserGroupID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserGroupID] = '''+CAST(@UserGroupID AS nvarchar(100))+''' '
            
    IF @SubjectID IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[SubjectID] = '''+CAST(@SubjectID AS nvarchar(100))+''' '
            
    IF @UserNickName IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserNickName] LIKE ''%'+CAST(@UserNickName AS nvarchar(100))+'%'' '
            
    IF @Password IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[Password] = '''+CAST(@Password AS nvarchar(100))+''' '
            
    IF @XB IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[XB] = '''+CAST(@XB AS nvarchar(100))+''' '
            
    IF @MZ IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[MZ] = '''+CAST(@MZ AS nvarchar(100))+''' '
            
    IF @ZZMM IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[ZZMM] = '''+CAST(@ZZMM AS nvarchar(100))+''' '
            
    IF @SFZH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[SFZH] = '''+CAST(@SFZH AS nvarchar(100))+''' '
            
    IF @SJH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[SJH] LIKE ''%'+CAST(@SJH AS nvarchar(100))+'%'' '
            
    IF @BGDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[BGDH] = '''+CAST(@BGDH AS nvarchar(100))+''' '
            
    IF @JTDH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[JTDH] = '''+CAST(@JTDH AS nvarchar(100))+''' '
            
    IF @Email IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[Email] LIKE ''%'+CAST(@Email AS nvarchar(100))+'%'' '
            
    IF @QQH IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[QQH] LIKE ''%'+CAST(@QQH AS nvarchar(100))+'%'' '
            
    IF @LoginTime IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LoginTime] = '''+CAST(@LoginTime AS nvarchar(100))+''' '
            
    IF @LastLoginIP IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LastLoginIP] = '''+CAST(@LastLoginIP AS nvarchar(100))+''' '
            
    IF @LastLoginDate IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LastLoginDate] = '''+CAST(@LastLoginDate AS nvarchar(100))+''' '
            
    IF @LoginTimes IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[LoginTimes] = '''+CAST(@LoginTimes AS nvarchar(100))+''' '
            
    IF @UserStatus IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[UserStatus] = '''+CAST(@UserStatus AS nvarchar(100))+''' '
            
    IF @vcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[vcode] = '''+CAST(@vcode AS nvarchar(100))+''' '
            
    IF @lcode IS NOT NULL
      SET @ConditionText = @ConditionText + ' OR [dbo].[T_PM_UserInfo].[lcode] = '''+CAST(@lcode AS nvarchar(100))+''' '
            
    --一对一相关表查询条件
    
    SET @ConditionText = @ConditionText + ')'
END
SET @SqlText = 'SELECT DISTINCT TOP ' + CAST(@PageSize AS VARCHAR(20))
IF @QueryField IS NULL 
BEGIN
--主表查询字段
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
        
      , [dbo].[T_PM_UserInfo].[lcode]
        
        ,[dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]([dbo].[T_PM_UserInfo].[UserGroupID]) AS [UserGroupID_T_PM_UserGroupInfo_UserGroupName]
        ,[SubjectID_T_BM_DWXX].[DWMC] AS [SubjectID_T_BM_DWXX_DWMC]
        ,[XB_Dictionary].[MC] AS [XB_Dictionary_MC]
        ,[MZ_Dictionary].[MC] AS [MZ_Dictionary_MC]
        ,[ZZMM_Dictionary].[MC] AS [ZZMM_Dictionary_MC]
        ,[UserStatus_Dictionary].[MC] AS [UserStatus_Dictionary_MC]
'
--一对一相关表表查询字段
  SET @SqlText = @SqlText + '

'

END
ELSE IF @QueryField IS NOT NULL
BEGIN
--主表查询字段
  SET @SqlText = @SqlText + ' ' + @QueryField + '

        ,[dbo].[F_T_PM_UserInfo_GetUserGroupNameByUserGroupID]([dbo].[T_PM_UserInfo].[UserGroupID]) AS [UserGroupID_T_PM_UserGroupInfo_UserGroupName]
        ,[SubjectID_T_BM_DWXX].[DWMC] AS [SubjectID_T_BM_DWXX_DWMC]
        ,[XB_Dictionary].[MC] AS [XB_Dictionary_MC]
        ,[MZ_Dictionary].[MC] AS [MZ_Dictionary_MC]
        ,[ZZMM_Dictionary].[MC] AS [ZZMM_Dictionary_MC]
        ,[UserStatus_Dictionary].[MC] AS [UserStatus_Dictionary_MC]
'
--一对一相关表查询字段
  SET @SqlText = @SqlText + '

'
END
--主表
SET @FromText = '
 FROM [dbo].[T_PM_UserInfo]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

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
	
--多项查询

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
    
IF @lcodeBatch IS NOT NULL
  SET @FromText = @FromText + '
      INNER JOIN [dbo].F_SplitStr('''+CAST(@lcodeBatch AS nvarchar(4000))+''', '','') AS T_PM_UserInfo_lcode_Batch ON '','' + [dbo].[T_PM_UserInfo].[lcode] + '','' LIKE ''%,'' + T_PM_UserInfo_lcode_Batch.col +'',%''
'
    

--查询条件
SET @InnerSortText = '
[dbo].[T_PM_UserInfo].[ObjectID] NOT IN
( 
SELECT TOP ' + CAST(@PageSize*(@CurrentPage-1) AS VARCHAR(10)) + '
[dbo].[T_PM_UserInfo].[ObjectID]
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

if exists (select * from dbo.sysobjects where id = object_id(N'[dbo].[SP_SelectT_PM_UserInfoByObjectID]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[SP_SelectT_PM_UserInfoByObjectID]
GO

--表T_PM_UserInfo以ObjectID为条件查询的存储过程

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
    
      , [dbo].[T_PM_UserInfo].[lcode]
    
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

--表T_PM_UserInfo以主键为条件查询的存储过程

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
    
      , [lcode]
    
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

--表[T_PM_UserInfo]以ObjectID为条件判断记录是否存在的存储过程

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

--表[T_PM_UserInfo]以主键为条件判断记录是否存在的存储过程

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

--表T_PM_UserInfo任意条件统计记录数的的存储过程

CREATE   PROCEDURE [dbo].[SP_CountT_PM_UserInfoByAnyCondition] 
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
SET @ConditionText = ' [dbo].[T_PM_UserInfo].ObjectID IS NOT NULL '

--一对一相关表查询条件

SET @InnerJoinText = ' '
SET @SelectListText = ' '
SET @TotalSelectListText = ' '
--主表统计数据

--一对一相关表统计数据

--聚合求和



--主表
SET @FromText = '
 FROM [dbo].[T_PM_UserInfo]'
--主表与一对一相关表连接
SET @FromText = @FromText + '

'
--主表与一对一相关表中绑定字段连接
SET @FromText = @FromText + '

'
--主表与绑定表连接

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

--表T_PM_UserInfo以UserID为条件得最大值的存储过程

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

