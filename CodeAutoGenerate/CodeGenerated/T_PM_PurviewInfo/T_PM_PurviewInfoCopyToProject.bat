@ECHO ON
cd %cd%\T_PM_PurviewInfo
@ECHO 开始部署T_PM_PurviewInfo
@ECHO 开始复制T_PM_PurviewInfo页面文件
copy T_PM_PurviewInfoWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_PM_PurviewInfo类文件
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo MD ..\..\..\DataLibrary\T_PM_PurviewInfo
copy T_PM_PurviewInfoApplicationData.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoApplicationLogic.cs copy T_PM_PurviewInfoApplicationLogic.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoApplicationLogicBase.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoBusinessEntity.cs copy T_PM_PurviewInfoBusinessEntity.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoBusinessEntityBase.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoWebUI.cs copy T_PM_PurviewInfoWebUI.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoWebUIBase.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
@ECHO 开始复制T_PM_PurviewInfo数据库脚本文件
copy T_PM_PurviewInfoScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_PM_PurviewInfoScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy T_PM_PurviewInfoScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy T_PM_PurviewInfoScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO 开始安装T_PM_PurviewInfo数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_PurviewInfoScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_PM_PurviewInfo数据库脚本
@ECHO 完成部署T_PM_PurviewInfo
exit

