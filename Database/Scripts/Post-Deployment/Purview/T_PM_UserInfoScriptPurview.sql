--插入用户信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'USER'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('USER','用户信息','用户信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '用户信息', [PurviewTypeContent] =  '用户信息管理'
    WHERE [PurviewTypeID] = 'USER'
END
--插入用户信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('USER01','用户信息添加','USER','用户信息添加',0,'T_PM_UserInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息添加' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER01'
END
--插入用户信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER02','用户信息修改','USER','用户信息修改',0,'T_PM_UserInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息修改' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER02'
END
--插入用户信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER04','用户信息','USER','用户信息浏览',1,'T_PM_UserInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER04'
END
--插入用户信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER05','用户信息详情','USER','用户信息详情',0,'T_PM_UserInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息详情' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER05'
END
--插入用户信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER06','用户信息统计','USER','用户信息统计',0,'T_PM_UserInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息统计' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER06'
END
--插入用户信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER07','用户信息删除','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息删除' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER07'
END
--插入用户信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER08','用户信息导出','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息导出' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER08'
END
--插入用户信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER09','用户信息文档导入','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息文档导入' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER09'
END
--插入用户信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER10','用户信息数据集导入','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户信息数据集导入' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER10'
END

--插入通讯录权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('USER51','通讯录','USER','通讯录',1,'T_PM_UserInfoWebUISearch.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '通讯录' ,
    [PageFileName] = 'T_PM_UserInfoWebUISearch.aspx?p=USER51'
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51'
END
--插入通讯录添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('USER51_Add','通讯录添加','USER','通讯录添加',0,'T_PM_UserInfoWebUIAdd.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '通讯录添加' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Add'
END
--插入通讯录修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER51_Modify','通讯录修改','USER','通讯录修改',0,'T_PM_UserInfoWebUIModify.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '通讯录修改' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Modify'
END
--插入通讯录详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER51_Detail','通讯录详情','USER','通讯录详情',0,'T_PM_UserInfoWebUIDetail.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '通讯录详情' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Detail'
END
--插入通讯录删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER51_Delete','通讯录删除','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '通讯录删除' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Delete'
END

--插入个人资料权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER61_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('USER61_Modify','个人资料','USER','个人资料',1,'T_PM_UserInfoWebUIAdd.aspx?a=e' +CHAR(38)+ 'p=USER61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '个人资料' ,
    [PageFileName] = 'T_PM_UserInfoWebUIAdd.aspx?a=e' +CHAR(38)+ 'p=USER61'
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER61_Modify'
END

