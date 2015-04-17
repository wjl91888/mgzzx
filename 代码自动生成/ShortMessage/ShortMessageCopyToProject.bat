@ECHO ON
cd %cd%\ShortMessage
@ECHO 开始部署ShortMessage
@ECHO 开始复制ShortMessage页面文件
copy ShortMessageWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy ShortMessageContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\ShortMessageWebUIList.aspx copy ShortMessageWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\ShortMessageWebUIList.aspx.cs copy ShortMessageWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制ShortMessage类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage
copy ShortMessageApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\ShortMessageApplicationLogic.cs copy ShortMessageApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
copy ShortMessageApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\ShortMessageBusinessEntity.cs copy ShortMessageBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
copy ShortMessageBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\ShortMessageWebUI.cs copy ShortMessageWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
copy ShortMessageWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\ShortMessage\
@ECHO 开始安装ShortMessage数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir ShortMessageStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装ShortMessage数据库脚本
@ECHO 完成部署ShortMessage
exit

