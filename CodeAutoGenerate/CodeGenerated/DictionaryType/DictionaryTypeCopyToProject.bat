@ECHO ON
cd %cd%\DictionaryType
@ECHO 开始部署DictionaryType
@ECHO 开始复制DictionaryType页面文件
copy DictionaryTypeWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO 开始复制DictionaryType类文件
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType MD ..\..\..\DataLibrary\DictionaryType
copy DictionaryTypeApplicationData.cs ..\..\..\DataLibrary\DictionaryType\
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType\DictionaryTypeApplicationLogic.cs copy DictionaryTypeApplicationLogic.cs ..\..\..\DataLibrary\DictionaryType\
copy DictionaryTypeApplicationLogicBase.cs ..\..\..\DataLibrary\DictionaryType\
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType\DictionaryTypeBusinessEntity.cs copy DictionaryTypeBusinessEntity.cs ..\..\..\DataLibrary\DictionaryType\
copy DictionaryTypeBusinessEntityBase.cs ..\..\..\DataLibrary\DictionaryType\
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType\DictionaryTypeWebUI.cs copy DictionaryTypeWebUI.cs ..\..\..\DataLibrary\DictionaryType\
copy DictionaryTypeWebUIBase.cs ..\..\..\DataLibrary\DictionaryType\
@ECHO 开始复制DictionaryType数据库脚本文件
copy DictionaryTypeScript.table.sql ..\..\..\Database\Scripts\Tables\
copy DictionaryTypeScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy DictionaryTypeScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy DictionaryTypeScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO 开始安装DictionaryType数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir DictionaryTypeScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装DictionaryType数据库脚本
@ECHO 完成部署DictionaryType
exit

