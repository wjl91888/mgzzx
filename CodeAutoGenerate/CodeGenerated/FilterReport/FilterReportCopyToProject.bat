@ECHO ON
cd %cd%\FilterReport
@ECHO 开始部署FilterReport
@ECHO 开始复制FilterReport页面文件
copy FilterReportWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO 开始复制FilterReport类文件
IF NOT EXIST ..\..\..\DataLibrary\FilterReport MD ..\..\..\DataLibrary\FilterReport
copy FilterReportApplicationData.cs ..\..\..\DataLibrary\FilterReport\
IF NOT EXIST ..\..\..\DataLibrary\FilterReport\FilterReportApplicationLogic.cs copy FilterReportApplicationLogic.cs ..\..\..\DataLibrary\FilterReport\
copy FilterReportApplicationLogicBase.cs ..\..\..\DataLibrary\FilterReport\
IF NOT EXIST ..\..\..\DataLibrary\FilterReport\FilterReportBusinessEntity.cs copy FilterReportBusinessEntity.cs ..\..\..\DataLibrary\FilterReport\
copy FilterReportBusinessEntityBase.cs ..\..\..\DataLibrary\FilterReport\
IF NOT EXIST ..\..\..\DataLibrary\FilterReport\FilterReportWebUI.cs copy FilterReportWebUI.cs ..\..\..\DataLibrary\FilterReport\
copy FilterReportWebUIBase.cs ..\..\..\DataLibrary\FilterReport\
@ECHO 开始复制FilterReport数据库脚本文件
copy FilterReportScript.table.sql ..\..\..\Database\Scripts\Tables\
copy FilterReportScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy FilterReportScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy FilterReportScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO 开始安装FilterReport数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir FilterReportScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装FilterReport数据库脚本
@ECHO 完成部署FilterReport
exit

