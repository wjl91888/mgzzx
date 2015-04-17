@ECHO ON
cd %cd%\T_PM_UserGroupInfo
@ECHO 开始部署T_PM_UserGroupInfo
@ECHO 开始复制T_PM_UserGroupInfo页面文件
copy T_PM_UserGroupInfoWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_PM_UserGroupInfoWebUIList.aspx copy T_PM_UserGroupInfoWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_PM_UserGroupInfoWebUIList.aspx.cs copy T_PM_UserGroupInfoWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_PM_UserGroupInfo类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo
copy T_PM_UserGroupInfoApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\T_PM_UserGroupInfoApplicationLogic.cs copy T_PM_UserGroupInfoApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
copy T_PM_UserGroupInfoApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\T_PM_UserGroupInfoBusinessEntity.cs copy T_PM_UserGroupInfoBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
copy T_PM_UserGroupInfoBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\T_PM_UserGroupInfoWebUI.cs copy T_PM_UserGroupInfoWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
copy T_PM_UserGroupInfoWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_PM_UserGroupInfo\
@ECHO 开始安装T_PM_UserGroupInfo数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_UserGroupInfoStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_PM_UserGroupInfo数据库脚本
@ECHO 完成部署T_PM_UserGroupInfo
exit

