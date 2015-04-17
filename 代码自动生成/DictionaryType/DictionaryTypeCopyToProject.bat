@ECHO ON
cd %cd%\DictionaryType
@ECHO 开始部署DictionaryType
@ECHO 开始复制DictionaryType页面文件
copy DictionaryTypeWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy DictionaryTypeContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\DictionaryTypeWebUIList.aspx copy DictionaryTypeWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\DictionaryTypeWebUIList.aspx.cs copy DictionaryTypeWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制DictionaryType类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType
copy DictionaryTypeApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\DictionaryTypeApplicationLogic.cs copy DictionaryTypeApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
copy DictionaryTypeApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\DictionaryTypeBusinessEntity.cs copy DictionaryTypeBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
copy DictionaryTypeBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\DictionaryTypeWebUI.cs copy DictionaryTypeWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
copy DictionaryTypeWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\DictionaryType\
@ECHO 开始安装DictionaryType数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir DictionaryTypeStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装DictionaryType数据库脚本
@ECHO 完成部署DictionaryType
exit

