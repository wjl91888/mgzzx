<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'PurviewInfoSQLScript.sql.xsl'"/>
<xsl:template match="/">
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>权限类型信息
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>管理','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>', [PurviewTypeContent] =  '<xsl:value-of select="/NewDataSet/TableRemark"/>管理'
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>添加权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>01','<xsl:value-of select="/NewDataSet/TableRemark"/>添加','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>添加',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>添加' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>01'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>修改权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>02','<xsl:value-of select="/NewDataSet/TableRemark"/>修改','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>修改',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>修改' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>02'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>浏览权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>04','<xsl:value-of select="/NewDataSet/TableRemark"/>','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>浏览',1,'<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>04'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>详情权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>05','<xsl:value-of select="/NewDataSet/TableRemark"/>详情','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>详情',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>详情' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>05'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>统计权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>06','<xsl:value-of select="/NewDataSet/TableRemark"/>统计','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="/NewDataSet/TableRemark"/>统计',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>统计' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>06'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>删除权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>07','<xsl:value-of select="/NewDataSet/TableRemark"/>删除','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>删除' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>07'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>导出权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>08','<xsl:value-of select="/NewDataSet/TableRemark"/>导出','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>导出' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>08'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>导入权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>09','<xsl:value-of select="/NewDataSet/TableRemark"/>文档导入','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>文档导入' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>09'
END
--插入<xsl:value-of select="/NewDataSet/TableRemark"/>导入数据集权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/>10','<xsl:value-of select="/NewDataSet/TableRemark"/>数据集导入','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="/NewDataSet/TableRemark"/>数据集导入' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>10'
END
<xsl:for-each select="/NewDataSet/CustomPermissionConfig">
<xsl:if test="CustomPermissionType">
<xsl:if test="CustomPermissionType = 'AddPage'">
--插入<xsl:value-of select="CustomPermissionRemark"/>权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify','<xsl:value-of select="CustomPermissionRemark"/>','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="CustomPermissionRemark"/>',1,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx?a=e' +CHAR(38)+ 'p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="CustomPermissionRemark"/>' ,
    [PageFileName] = '<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx?a=e' +CHAR(38)+ 'p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>'
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify'
END
</xsl:if>
<xsl:if test="CustomPermissionType = 'SearchPage'">
--插入<xsl:value-of select="CustomPermissionRemark"/>权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>','<xsl:value-of select="CustomPermissionRemark"/>','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="CustomPermissionRemark"/>',1,'<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx?p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="CustomPermissionRemark"/>' ,
    [PageFileName] = '<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx?p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>'
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>'
END
--插入<xsl:value-of select="CustomPermissionRemark"/>添加权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Add','<xsl:value-of select="CustomPermissionRemark"/>添加','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="CustomPermissionRemark"/>添加',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx?p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="CustomPermissionRemark"/>添加' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Add'
END
--插入<xsl:value-of select="CustomPermissionRemark"/>修改权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify','<xsl:value-of select="CustomPermissionRemark"/>修改','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="CustomPermissionRemark"/>修改',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIModify.aspx?p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="CustomPermissionRemark"/>修改' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Modify'
END
--插入<xsl:value-of select="CustomPermissionRemark"/>详情权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Detail','<xsl:value-of select="CustomPermissionRemark"/>详情','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','<xsl:value-of select="CustomPermissionRemark"/>详情',0,'<xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx?p=<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="CustomPermissionRemark"/>详情' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Detail'
END
--插入<xsl:value-of select="CustomPermissionRemark"/>删除权限
IF (NOT EXISTS(SELECT 1 FROM [<xsl:value-of select="/NewDataSet/DataBaseName"/>].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Delete','<xsl:value-of select="CustomPermissionRemark"/>删除','<xsl:value-of select="/NewDataSet/PurviewPrefix"/>','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '<xsl:value-of select="CustomPermissionRemark"/>删除' 
    WHERE [PurviewTypeID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/>' AND [PurviewID] = '<xsl:value-of select="/NewDataSet/PurviewPrefix"/><xsl:value-of select="CustomPermissionID"/>_Delete'
END
</xsl:if>
</xsl:if>
</xsl:for-each>
</xsl:template>
</xsl:stylesheet>