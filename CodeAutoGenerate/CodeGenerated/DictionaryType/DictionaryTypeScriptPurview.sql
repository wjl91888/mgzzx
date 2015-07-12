--插入字典类型权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICTT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICTT','字典类型','字典类型管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '字典类型', [PurviewTypeContent] =  '字典类型管理'
    WHERE [PurviewTypeID] = 'DICTT'
END
--插入字典类型添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICTT01','字典类型添加','DICTT','字典类型添加',0,'DictionaryTypeWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型添加' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT01'
END
--插入字典类型修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT02','字典类型修改','DICTT','字典类型修改',0,'DictionaryTypeWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型修改' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT02'
END
--插入字典类型浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT04','字典类型','DICTT','字典类型浏览',1,'DictionaryTypeWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT04'
END
--插入字典类型详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT05','字典类型详情','DICTT','字典类型详情',0,'DictionaryTypeWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型详情' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT05'
END
--插入字典类型统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT06','字典类型统计','DICTT','字典类型统计',0,'DictionaryTypeWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型统计' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT06'
END
--插入字典类型删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT07','字典类型删除','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型删除' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT07'
END
--插入字典类型导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT08','字典类型导出','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型导出' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT08'
END
--插入字典类型导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT09','字典类型文档导入','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型文档导入' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT09'
END
--插入字典类型导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT10','字典类型数据集导入','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '字典类型数据集导入' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT10'
END

