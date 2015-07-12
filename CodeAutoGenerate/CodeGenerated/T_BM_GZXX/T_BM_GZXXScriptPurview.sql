--插入工资信息权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'GZ'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('GZ','工资信息','工资信息管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '工资信息', [PurviewTypeContent] =  '工资信息管理'
    WHERE [PurviewTypeID] = 'GZ'
END
--插入工资信息添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('GZ01','工资信息添加','GZ','工资信息添加',0,'T_BM_GZXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息添加' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ01'
END
--插入工资信息修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ02','工资信息修改','GZ','工资信息修改',0,'T_BM_GZXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息修改' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ02'
END
--插入工资信息浏览权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ04','工资信息','GZ','工资信息浏览',1,'T_BM_GZXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ04'
END
--插入工资信息详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ05','工资信息详情','GZ','工资信息详情',0,'T_BM_GZXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息详情' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ05'
END
--插入工资信息统计权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ06','工资信息统计','GZ','工资信息统计',0,'T_BM_GZXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息统计' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ06'
END
--插入工资信息删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ07','工资信息删除','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息删除' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ07'
END
--插入工资信息导出权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ08','工资信息导出','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息导出' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ08'
END
--插入工资信息导入权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ09','工资信息文档导入','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息文档导入' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ09'
END
--插入工资信息导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ10','工资信息数据集导入','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '工资信息数据集导入' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ10'
END

--插入我的工资权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('GZ51','我的工资','GZ','我的工资',1,'T_BM_GZXXWebUISearch.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的工资' ,
    [PageFileName] = 'T_BM_GZXXWebUISearch.aspx?p=GZ51'
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51'
END
--插入我的工资添加权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('GZ51_Add','我的工资添加','GZ','我的工资添加',0,'T_BM_GZXXWebUIAdd.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的工资添加' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Add'
END
--插入我的工资修改权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ51_Modify','我的工资修改','GZ','我的工资修改',0,'T_BM_GZXXWebUIModify.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的工资修改' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Modify'
END
--插入我的工资详情权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ51_Detail','我的工资详情','GZ','我的工资详情',0,'T_BM_GZXXWebUIDetail.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的工资详情' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Detail'
END
--插入我的工资删除权限
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ51_Delete','我的工资删除','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '我的工资删除' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Delete'
END

