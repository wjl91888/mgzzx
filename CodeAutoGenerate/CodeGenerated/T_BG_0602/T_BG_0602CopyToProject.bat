@ECHO ON
cd %cd%\T_BG_0602
@ECHO 开始部署T_BG_0602
@ECHO 开始复制T_BG_0602页面文件
copy T_BG_0602WebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BG_0602WebUIAdd.aspx
copy T_BG_0602WebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BG_0602WebUIAdd.aspx.cs
copy T_BG_0602WebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BG_0602WebUIDetail.aspx
copy T_BG_0602WebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BG_0602WebUIDetail.aspx.cs
copy T_BG_0602WebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_BG_0602WebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_BG_0602WebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_BG_0602WebUISearch.aspx
copy T_BG_0602WebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_BG_0602WebUISearch.aspx.cs
    @ECHO 开始复制T_BG_0602类文件
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0602 MD ..\..\..\DataLibrary\T_BG_0602
copy T_BG_0602ApplicationData.cs ..\..\..\DataLibrary\T_BG_0602\
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0602\T_BG_0602ApplicationLogic.cs copy T_BG_0602ApplicationLogic.cs ..\..\..\DataLibrary\T_BG_0602\
copy T_BG_0602ApplicationLogicBase.cs ..\..\..\DataLibrary\T_BG_0602\
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0602\T_BG_0602BusinessEntity.cs copy T_BG_0602BusinessEntity.cs ..\..\..\DataLibrary\T_BG_0602\
copy T_BG_0602BusinessEntityBase.cs ..\..\..\DataLibrary\T_BG_0602\
IF NOT EXIST ..\..\..\DataLibrary\T_BG_0602\T_BG_0602WebUI.cs copy T_BG_0602WebUI.cs ..\..\..\DataLibrary\T_BG_0602\
copy T_BG_0602WebUIBase.cs ..\..\..\DataLibrary\T_BG_0602\
@ECHO 开始复制T_BG_0602数据库脚本文件
copy T_BG_0602Script.table.sql ..\..\..\Database\Scripts\Tables\
copy T_BG_0602ScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_BG_0602ScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_BG_0602ScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO 开始安装T_BG_0602数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BG_0602ScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BG_0602数据库脚本
@ECHO 完成部署T_BG_0602
exit

