USE [DB_MGZZX]
--插入字典信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICT','字典信息','字典信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '字典信息', [PurviewTypeContent] =  '字典信息管理'
    WHERE [PurviewTypeID] = 'DICT'
END
--插入字典信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICT01','字典信息添加','DICT','字典信息添加',0,'DictionaryWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息添加' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'
END
--插入字典信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT02','字典信息修改','DICT','字典信息修改',0,'DictionaryWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息修改' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'
END
--插入字典信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT04','字典信息浏览','DICT','字典信息浏览',1,'DictionaryWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息浏览' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'
END
--插入字典信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT05','字典信息详情','DICT','字典信息详情',0,'DictionaryWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息详情' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'
END
--插入字典信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT06','字典信息统计','DICT','字典信息统计',0,'DictionaryWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息统计' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'
END
--插入字典信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT07','字典信息删除','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息删除' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'
END
--插入字典信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT08','字典信息导出','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息导出' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'
END
--插入字典信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT09','字典信息文档导入','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息文档导入' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'
END
--插入字典信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT10','字典信息数据集导入','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典信息数据集导入' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'
END

