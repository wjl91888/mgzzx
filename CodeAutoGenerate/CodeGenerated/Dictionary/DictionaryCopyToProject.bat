@ECHO ON
cd %cd%\Dictionary
@ECHO 开始部署Dictionary
@ECHO 开始复制Dictionary页面文件
copy DictionaryWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO 开始复制Dictionary类文件
IF NOT EXIST ..\..\..\DataLibrary\Dictionary MD ..\..\..\DataLibrary\Dictionary
copy DictionaryApplicationData.cs ..\..\..\DataLibrary\Dictionary\
IF NOT EXIST ..\..\..\DataLibrary\Dictionary\DictionaryApplicationLogic.cs copy DictionaryApplicationLogic.cs ..\..\..\DataLibrary\Dictionary\
copy DictionaryApplicationLogicBase.cs ..\..\..\DataLibrary\Dictionary\
IF NOT EXIST ..\..\..\DataLibrary\Dictionary\DictionaryBusinessEntity.cs copy DictionaryBusinessEntity.cs ..\..\..\DataLibrary\Dictionary\
copy DictionaryBusinessEntityBase.cs ..\..\..\DataLibrary\Dictionary\
IF NOT EXIST ..\..\..\DataLibrary\Dictionary\DictionaryWebUI.cs copy DictionaryWebUI.cs ..\..\..\DataLibrary\Dictionary\
copy DictionaryWebUIBase.cs ..\..\..\DataLibrary\Dictionary\
@ECHO 开始复制Dictionary数据库脚本文件
copy DictionaryScript.table.sql ..\..\..\Database\Scripts\Tables\
copy DictionaryScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy DictionaryScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy DictionaryScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO 开始安装Dictionary数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir DictionaryScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装Dictionary数据库脚本
@ECHO 完成部署Dictionary
exit

