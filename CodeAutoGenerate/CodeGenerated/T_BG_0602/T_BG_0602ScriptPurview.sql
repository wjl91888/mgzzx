--插入公共信息栏目权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BG0602'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BG0602','公共信息栏目','公共信息栏目管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '公共信息栏目', [PurviewTypeContent] =  '公共信息栏目管理'
    WHERE [PurviewTypeID] = 'BG0602'
END
--插入公共信息栏目添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060201'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060201','公共信息栏目添加','BG0602','公共信息栏目添加',0,'T_BG_0602WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目添加' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060201'
END
--插入公共信息栏目修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060202'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060202','公共信息栏目修改','BG0602','公共信息栏目修改',0,'T_BG_0602WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目修改' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060202'
END
--插入公共信息栏目浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060204'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060204','公共信息栏目','BG0602','公共信息栏目浏览',1,'T_BG_0602WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060204'
END
--插入公共信息栏目详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060205'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060205','公共信息栏目详情','BG0602','公共信息栏目详情',0,'T_BG_0602WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目详情' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060205'
END
--插入公共信息栏目统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060206'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060206','公共信息栏目统计','BG0602','公共信息栏目统计',0,'T_BG_0602WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目统计' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060206'
END
--插入公共信息栏目删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060207'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060207','公共信息栏目删除','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目删除' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060207'
END
--插入公共信息栏目导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060208'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060208','公共信息栏目导出','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目导出' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060208'
END
--插入公共信息栏目导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060209'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060209','公共信息栏目文档导入','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目文档导入' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060209'
END
--插入公共信息栏目导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060210'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060210','公共信息栏目数据集导入','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息栏目数据集导入' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060210'
END

