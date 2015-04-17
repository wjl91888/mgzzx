@ECHO ON
cd %cd%\T_PM_UserInfo
@ECHO 开始部署T_PM_UserInfo
@ECHO 开始复制T_PM_UserInfo页面文件
copy T_PM_UserInfoWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_PM_UserInfoWebUIList.aspx copy T_PM_UserInfoWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_PM_UserInfoWebUIList.aspx.cs copy T_PM_UserInfoWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_PM_UserInfo类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo
copy T_PM_UserInfoApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\T_PM_UserInfoApplicationLogic.cs copy T_PM_UserInfoApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
copy T_PM_UserInfoApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\T_PM_UserInfoBusinessEntity.cs copy T_PM_UserInfoBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
copy T_PM_UserInfoBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\T_PM_UserInfoWebUI.cs copy T_PM_UserInfoWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
copy T_PM_UserInfoWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserInfo\
@ECHO 开始安装T_PM_UserInfo数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_UserInfoStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_PM_UserInfo数据库脚本
@ECHO 完成部署T_PM_UserInfo
exit

