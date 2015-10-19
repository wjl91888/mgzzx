<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:output method="xml" encoding="GB2312"/>
<xsl:variable name="FileName" select="'WebUIAdd.aspx.xsl'"/>
<xsl:template match="/">
@ECHO ON
cd %cd%\<xsl:value-of select="/NewDataSet/TableName"/>
@ECHO 开始部署<xsl:value-of select="/NewDataSet/TableName"/>
@ECHO 开始复制<xsl:value-of select="/NewDataSet/TableName"/>页面文件
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIImage.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIImage.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIStatistic.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIStatistic.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\Administrator\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIAddForApp.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIAddForApp.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\<xsl:value-of select="/NewDataSet/TableName"/>WebUIAdd.aspx.cs
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIDetailForApp.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\<xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIDetailForApp.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\<xsl:value-of select="/NewDataSet/TableName"/>WebUIDetail.aspx.cs
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIImage.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIImage.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUISearchForApp.aspx <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUISearchForApp.aspx.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\wwwroot\App\A_BM\<xsl:value-of select="/NewDataSet/TableName"/>WebUISearch.aspx.cs
    @ECHO 开始复制<xsl:value-of select="/NewDataSet/TableName"/>类文件
IF NOT EXIST <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/> MD <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>
copy <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
IF NOT EXIST <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.cs copy <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogic.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
copy <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogicBase.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
IF NOT EXIST <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.cs copy <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
copy <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntityBase.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
IF NOT EXIST <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\<xsl:value-of select="/NewDataSet/TableName"/>WebUI.cs copy <xsl:value-of select="/NewDataSet/TableName"/>WebUI.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
copy <xsl:value-of select="/NewDataSet/TableName"/>WebUIBase.cs <xsl:value-of select="/NewDataSet/ProjectPath"/>\DataLibrary\<xsl:value-of select="/NewDataSet/TableName"/>\
@ECHO 开始复制<xsl:value-of select="/NewDataSet/TableName"/>数据库脚本文件
copy <xsl:value-of select="/NewDataSet/TableName"/>Script.table.sql <xsl:value-of select="/NewDataSet/ProjectPath"/>\Database\Scripts\Tables\
copy <xsl:value-of select="/NewDataSet/TableName"/>ScriptProc.sql <xsl:value-of select="/NewDataSet/ProjectPath"/>\Database\Scripts\Post-Deployment\Proc\
copy <xsl:value-of select="/NewDataSet/TableName"/>ScriptPurview.sql <xsl:value-of select="/NewDataSet/ProjectPath"/>\Database\Scripts\Post-Deployment\Purview\
copy <xsl:value-of select="/NewDataSet/TableName"/>ScriptUpdateField.sql <xsl:value-of select="/NewDataSet/ProjectPath"/>\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装<xsl:value-of select="/NewDataSet/TableName"/>数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir <xsl:value-of select="/NewDataSet/TableName"/>ScriptProc.sql /s /b') do (sqlcmd -d <xsl:value-of select="/NewDataSet/DataBaseName"/> -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装<xsl:value-of select="/NewDataSet/TableName"/>数据库脚本
@ECHO 完成部署<xsl:value-of select="/NewDataSet/TableName"/>
exit
</xsl:template>
</xsl:stylesheet>