--插入用户组信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'UG'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('UG','用户组信息','用户组信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '用户组信息', [PurviewTypeContent] =  '用户组信息管理'
    WHERE [PurviewTypeID] = 'UG'
END
--插入用户组信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('UG01','用户组信息添加','UG','用户组信息添加',0,'T_PM_UserGroupInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息添加' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG01'
END
--插入用户组信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG02','用户组信息修改','UG','用户组信息修改',0,'T_PM_UserGroupInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息修改' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG02'
END
--插入用户组信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG04','用户组信息','UG','用户组信息浏览',1,'T_PM_UserGroupInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG04'
END
--插入用户组信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG05','用户组信息详情','UG','用户组信息详情',0,'T_PM_UserGroupInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息详情' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG05'
END
--插入用户组信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG06','用户组信息统计','UG','用户组信息统计',0,'T_PM_UserGroupInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息统计' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG06'
END
--插入用户组信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG07','用户组信息删除','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息删除' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG07'
END
--插入用户组信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG08','用户组信息导出','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息导出' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG08'
END
--插入用户组信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG09','用户组信息文档导入','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息文档导入' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG09'
END
--插入用户组信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG10','用户组信息数据集导入','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '用户组信息数据集导入' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG10'
END

