--插入消息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DXX'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DXX','消息','消息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '消息', [PurviewTypeContent] =  '消息管理'
    WHERE [PurviewTypeID] = 'DXX'
END
--插入消息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX01','消息添加','DXX','消息添加',0,'ShortMessageWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息添加' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX01'
END
--插入消息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX02','消息修改','DXX','消息修改',0,'ShortMessageWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息修改' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX02'
END
--插入消息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX04','消息','DXX','消息浏览',1,'ShortMessageWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX04'
END
--插入消息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX05','消息详情','DXX','消息详情',0,'ShortMessageWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息详情' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX05'
END
--插入消息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX06','消息统计','DXX','消息统计',0,'ShortMessageWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息统计' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX06'
END
--插入消息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX07','消息删除','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息删除' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX07'
END
--插入消息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX08','消息导出','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息导出' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX08'
END
--插入消息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX09','消息文档导入','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息文档导入' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX09'
END
--插入消息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX10','消息数据集导入','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '消息数据集导入' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX10'
END

--插入发件箱权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('DXX51','发件箱','DXX','发件箱',1,'ShortMessageWebUISearch.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '发件箱' ,
    [PageFileName] = 'ShortMessageWebUISearch.aspx?p=DXX51'
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51'
END
--插入发件箱添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX51_Add','发件箱添加','DXX','发件箱添加',0,'ShortMessageWebUIAdd.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '发件箱添加' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Add'
END
--插入发件箱修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX51_Modify','发件箱修改','DXX','发件箱修改',0,'ShortMessageWebUIModify.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '发件箱修改' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Modify'
END
--插入发件箱详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX51_Detail','发件箱详情','DXX','发件箱详情',0,'ShortMessageWebUIDetail.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '发件箱详情' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Detail'
END
--插入发件箱删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX51_Delete','发件箱删除','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '发件箱删除' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Delete'
END

--插入收件箱权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('DXX52','收件箱','DXX','收件箱',1,'ShortMessageWebUISearch.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '收件箱' ,
    [PageFileName] = 'ShortMessageWebUISearch.aspx?p=DXX52'
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52'
END
--插入收件箱添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX52_Add','收件箱添加','DXX','收件箱添加',0,'ShortMessageWebUIAdd.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '收件箱添加' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Add'
END
--插入收件箱修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX52_Modify','收件箱修改','DXX','收件箱修改',0,'ShortMessageWebUIModify.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '收件箱修改' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Modify'
END
--插入收件箱详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX52_Detail','收件箱详情','DXX','收件箱详情',0,'ShortMessageWebUIDetail.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '收件箱详情' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Detail'
END
--插入收件箱删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX52_Delete','收件箱删除','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '收件箱删除' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Delete'
END

