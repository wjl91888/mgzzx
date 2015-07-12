--插入公共信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BG0601'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BG0601','公共信息','公共信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '公共信息', [PurviewTypeContent] =  '公共信息管理'
    WHERE [PurviewTypeID] = 'BG0601'
END
--插入公共信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060101'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060101','公共信息添加','BG0601','公共信息添加',0,'T_BG_0601WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息添加' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060101'
END
--插入公共信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060102'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060102','公共信息修改','BG0601','公共信息修改',0,'T_BG_0601WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息修改' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060102'
END
--插入公共信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060104'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060104','公共信息','BG0601','公共信息浏览',1,'T_BG_0601WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060104'
END
--插入公共信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060105'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060105','公共信息详情','BG0601','公共信息详情',0,'T_BG_0601WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息详情' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060105'
END
--插入公共信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060106'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060106','公共信息统计','BG0601','公共信息统计',0,'T_BG_0601WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息统计' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060106'
END
--插入公共信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060107'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060107','公共信息删除','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息删除' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060107'
END
--插入公共信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060108'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060108','公共信息导出','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息导出' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060108'
END
--插入公共信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060109'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060109','公共信息文档导入','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息文档导入' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060109'
END
--插入公共信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060110'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060110','公共信息数据集导入','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '公共信息数据集导入' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060110'
END

--插入我发布的信息权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BG060151','我发布的信息','BG0601','我发布的信息',1,'T_BG_0601WebUISearch.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我发布的信息' ,
    [PageFileName] = 'T_BG_0601WebUISearch.aspx?p=BG060151'
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151'
END
--插入我发布的信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060151_Add','我发布的信息添加','BG0601','我发布的信息添加',0,'T_BG_0601WebUIAdd.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我发布的信息添加' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Add'
END
--插入我发布的信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060151_Modify','我发布的信息修改','BG0601','我发布的信息修改',0,'T_BG_0601WebUIModify.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我发布的信息修改' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Modify'
END
--插入我发布的信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060151_Detail','我发布的信息详情','BG0601','我发布的信息详情',0,'T_BG_0601WebUIDetail.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我发布的信息详情' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Detail'
END
--插入我发布的信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060151_Delete','我发布的信息删除','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我发布的信息删除' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Delete'
END

