@ECHO ON
cd %cd%\T_BG_0601
@ECHO 开始部署T_BG_0601
@ECHO 开始复制T_BG_0601页面文件
copy T_BG_0601WebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BG_0601WebUIAdd.aspx
copy T_BG_0601WebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BG_0601WebUIAdd.aspx.cs
copy T_BG_0601WebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BG_0601WebUIDetail.aspx
copy T_BG_0601WebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BG_0601WebUIDetail.aspx.cs
copy T_BG_0601WebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BG_0601WebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BG_0601WebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BG_0601WebUISearch.aspx
copy T_BG_0601WebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BG_0601WebUISearch.aspx.cs
    @ECHO 开始复制T_BG_0601类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0601 MD ..\..\..\DataLibrary\T_BG_0601
copy T_BG_0601ApplicationData.cs ..\..\..\DataLibrary\T_BG_0601\
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0601\T_BG_0601ApplicationLogic.cs copy T_BG_0601ApplicationLogic.cs ..\..\..\DataLibrary\T_BG_0601\
copy T_BG_0601ApplicationLogicBase.cs ..\..\..\DataLibrary\T_BG_0601\
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0601\T_BG_0601BusinessEntity.cs copy T_BG_0601BusinessEntity.cs ..\..\..\DataLibrary\T_BG_0601\
copy T_BG_0601BusinessEntityBase.cs ..\..\..\DataLibrary\T_BG_0601\
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0601\T_BG_0601WebUI.cs copy T_BG_0601WebUI.cs ..\..\..\DataLibrary\T_BG_0601\
copy T_BG_0601WebUIBase.cs ..\..\..\DataLibrary\T_BG_0601\
@ECHO 开始复制T_BG_0601数据库脚本文件
copy T_BG_0601Script.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BG_0601ScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BG_0601ScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BG_0601ScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BG_0601数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BG_0601ScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BG_0601数据库脚本
@ECHO 完成部署T_BG_0601
exit

