@ECHO ON
cd %cd%\Dictionary
@ECHO 开始部署Dictionary
@ECHO 开始复制Dictionary页面文件
copy DictionaryWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\DictionaryWebUIList.aspx copy DictionaryWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\DictionaryWebUIList.aspx.cs copy DictionaryWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制Dictionary类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary
copy DictionaryApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\DictionaryApplicationLogic.cs copy DictionaryApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
copy DictionaryApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\DictionaryBusinessEntity.cs copy DictionaryBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
copy DictionaryBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\DictionaryWebUI.cs copy DictionaryWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
copy DictionaryWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\Dictionary\
@ECHO 开始安装Dictionary数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir DictionaryStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装Dictionary数据库脚本
@ECHO 完成部署Dictionary
exit

