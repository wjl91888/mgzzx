@ECHO ON
cd %cd%\T_BM_GZXX
@ECHO 开始部署T_BM_GZXX
@ECHO 开始复制T_BM_GZXX页面文件
copy T_BM_GZXXWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_GZXXContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BM_GZXXWebUIList.aspx copy T_BM_GZXXWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BM_GZXXWebUIList.aspx.cs copy T_BM_GZXXWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_BM_GZXX类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX
copy T_BM_GZXXApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\T_BM_GZXXApplicationLogic.cs copy T_BM_GZXXApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
copy T_BM_GZXXApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\T_BM_GZXXBusinessEntity.cs copy T_BM_GZXXBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
copy T_BM_GZXXBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\T_BM_GZXXWebUI.cs copy T_BM_GZXXWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
copy T_BM_GZXXWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_GZXX\
@ECHO 开始安装T_BM_GZXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_GZXXStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_GZXX数据库脚本
@ECHO 完成部署T_BM_GZXX
exit

