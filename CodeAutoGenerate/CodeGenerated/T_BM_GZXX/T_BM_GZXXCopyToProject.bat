@ECHO ON
cd %cd%\T_BM_GZXX
@ECHO 开始部署T_BM_GZXX
@ECHO 开始复制T_BM_GZXX页面文件
copy T_BM_GZXXWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_GZXXWebUIAdd.aspx
copy T_BM_GZXXWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_GZXXWebUIAdd.aspx.cs
copy T_BM_GZXXWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_GZXXWebUIDetail.aspx
copy T_BM_GZXXWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_GZXXWebUIDetail.aspx.cs
copy T_BM_GZXXWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BM_GZXXWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BM_GZXXWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BM_GZXXWebUISearch.aspx
copy T_BM_GZXXWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BM_GZXXWebUISearch.aspx.cs
    @ECHO 开始复制T_BM_GZXX类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BM_GZXX MD ..\..\..\DataLibrary\T_BM_GZXX
copy T_BM_GZXXApplicationData.cs ..\..\..\DataLibrary\T_BM_GZXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_GZXX\T_BM_GZXXApplicationLogic.cs copy T_BM_GZXXApplicationLogic.cs ..\..\..\DataLibrary\T_BM_GZXX\
copy T_BM_GZXXApplicationLogicBase.cs ..\..\..\DataLibrary\T_BM_GZXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_GZXX\T_BM_GZXXBusinessEntity.cs copy T_BM_GZXXBusinessEntity.cs ..\..\..\DataLibrary\T_BM_GZXX\
copy T_BM_GZXXBusinessEntityBase.cs ..\..\..\DataLibrary\T_BM_GZXX\
IF NOT EXIST ..\..\..\DataLibrary\T_BM_GZXX\T_BM_GZXXWebUI.cs copy T_BM_GZXXWebUI.cs ..\..\..\DataLibrary\T_BM_GZXX\
copy T_BM_GZXXWebUIBase.cs ..\..\..\DataLibrary\T_BM_GZXX\
@ECHO 开始复制T_BM_GZXX数据库脚本文件
copy T_BM_GZXXScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BM_GZXXScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BM_GZXXScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BM_GZXXScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BM_GZXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_GZXXScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_GZXX数据库脚本
@ECHO 完成部署T_BM_GZXX
exit

