--插入Dictionary权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICT','Dictionary','Dictionary管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = 'Dictionary', [PurviewTypeContent] =  'Dictionary管理'
    WHERE [PurviewTypeID] = 'DICT'
END
--插入Dictionary添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICT01','Dictionary添加','DICT','Dictionary添加',0,'DictionaryWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary添加' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'
END
--插入Dictionary修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT02','Dictionary修改','DICT','Dictionary修改',0,'DictionaryWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary修改' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'
END
--插入Dictionary浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT04','Dictionary','DICT','Dictionary浏览',1,'DictionaryWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'
END
--插入Dictionary详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT05','Dictionary详情','DICT','Dictionary详情',0,'DictionaryWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary详情' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'
END
--插入Dictionary统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT06','Dictionary统计','DICT','Dictionary统计',0,'DictionaryWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary统计' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'
END
--插入Dictionary删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT07','Dictionary删除','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary删除' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'
END
--插入Dictionary导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT08','Dictionary导出','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary导出' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'
END
--插入Dictionary导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT09','Dictionary文档导入','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary文档导入' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'
END
--插入Dictionary导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT10','Dictionary数据集导入','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary数据集导入' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'
END

