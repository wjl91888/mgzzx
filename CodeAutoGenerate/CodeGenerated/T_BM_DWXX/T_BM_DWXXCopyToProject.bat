@ECHO ON
cd %cd%\T_BM_DWXX
@ECHO 开始部署T_BM_DWXX
@ECHO 开始复制T_BM_DWXX页面文件
copy T_BM_DWXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_BM_DWXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_DWXX MD ..\..\..\DataLibrary\T_BM_DWXX
copy T_BM_DWXXApplicationData.cs ..\..\..\DataLibrary\T_BM_DWXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_DWXX\T_BM_DWXXApplicationLogic.cs copy T_BM_DWXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_DWXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_DWXX\T_BM_DWXXBusinessEntity.cs copy T_BM_DWXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_DWXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_DWXX\T_BM_DWXXWebUI.cs copy T_BM_DWXXWebUI.cs ..\..\..\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_DWXX\
@ECHO 开始复制T_BM_DWXX数据库脚本文件
copy T_BM_DWXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_DWXXScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy T_BM_DWXXScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy T_BM_DWXXScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO 开始安装T_BM_DWXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_DWXXScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_DWXX数据库脚本
@ECHO 完成部署T_BM_DWXX
exit

