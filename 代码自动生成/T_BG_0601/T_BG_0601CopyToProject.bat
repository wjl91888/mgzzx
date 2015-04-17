@ECHO ON
cd %cd%\T_BG_0601
@ECHO 开始部署T_BG_0601
@ECHO 开始复制T_BG_0601页面文件
copy T_BG_0601WebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601WebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0601Contants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BG_0601WebUIList.aspx copy T_BG_0601WebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BG_0601WebUIList.aspx.cs copy T_BG_0601WebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_BG_0601类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601 MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601
copy T_BG_0601ApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\T_BG_0601ApplicationLogic.cs copy T_BG_0601ApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
copy T_BG_0601ApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\T_BG_0601BusinessEntity.cs copy T_BG_0601BusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
copy T_BG_0601BusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\T_BG_0601WebUI.cs copy T_BG_0601WebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
copy T_BG_0601WebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0601\
@ECHO 开始安装T_BG_0601数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BG_0601StoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BG_0601数据库脚本
@ECHO 完成部署T_BG_0601
exit

