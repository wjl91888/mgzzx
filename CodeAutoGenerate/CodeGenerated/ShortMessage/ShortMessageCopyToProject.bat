@ECHO ON
cd %cd%\ShortMessage
@ECHO 开始部署ShortMessage
@ECHO 开始复制ShortMessage页面文件
copy ShortMessageWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO 开始复制ShortMessage类文件
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage MD ..\..\..\DataLibrary\ShortMessage
copy ShortMessageApplicationData.cs ..\..\..\DataLibrary\ShortMessage\
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage\ShortMessageApplicationLogic.cs copy ShortMessageApplicationLogic.cs ..\..\..\DataLibrary\ShortMessage\
copy ShortMessageApplicationLogicBase.cs ..\..\..\DataLibrary\ShortMessage\
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage\ShortMessageBusinessEntity.cs copy ShortMessageBusinessEntity.cs ..\..\..\DataLibrary\ShortMessage\
copy ShortMessageBusinessEntityBase.cs ..\..\..\DataLibrary\ShortMessage\
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage\ShortMessageWebUI.cs copy ShortMessageWebUI.cs ..\..\..\DataLibrary\ShortMessage\
copy ShortMessageWebUIBase.cs ..\..\..\DataLibrary\ShortMessage\
@ECHO 开始复制ShortMessage数据库脚本文件
copy ShortMessageScript.table.sql ..\..\..\Database\Scripts\Tables\
copy ShortMessageScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy ShortMessageScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy ShortMessageScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO 开始安装ShortMessage数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir ShortMessageScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装ShortMessage数据库脚本
@ECHO 完成部署ShortMessage
exit

