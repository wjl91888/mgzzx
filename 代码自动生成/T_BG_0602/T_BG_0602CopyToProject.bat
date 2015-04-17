@ECHO ON
cd %cd%\T_BG_0602
@ECHO 开始部署T_BG_0602
@ECHO 开始复制T_BG_0602页面文件
copy T_BG_0602WebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602WebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BG_0602Contants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BG_0602WebUIList.aspx copy T_BG_0602WebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BG_0602WebUIList.aspx.cs copy T_BG_0602WebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_BG_0602类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602 MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602
copy T_BG_0602ApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\T_BG_0602ApplicationLogic.cs copy T_BG_0602ApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
copy T_BG_0602ApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\T_BG_0602BusinessEntity.cs copy T_BG_0602BusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
copy T_BG_0602BusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\T_BG_0602WebUI.cs copy T_BG_0602WebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
copy T_BG_0602WebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BG_0602\
@ECHO 开始安装T_BG_0602数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BG_0602StoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BG_0602数据库脚本
@ECHO 完成部署T_BG_0602
exit

