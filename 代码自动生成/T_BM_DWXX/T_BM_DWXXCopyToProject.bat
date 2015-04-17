@ECHO ON
cd %cd%\T_BM_DWXX
@ECHO 开始部署T_BM_DWXX
@ECHO 开始复制T_BM_DWXX页面文件
copy T_BM_DWXXWebUIAdd.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIAdd.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIDetail.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIDetail.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIImage.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIImage.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUISearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUISearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIStatistic.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIStatistic.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUITreeSearch.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUITreeSearch.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIListAJAX.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIListAJAX.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXContants.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BM_DWXXWebUIList.aspx copy T_BM_DWXXWebUIList.aspx E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\T_BM_DWXXWebUIList.aspx.cs copy T_BM_DWXXWebUIList.aspx.cs E:\MyWork\richsoft\蒙古族中学\Source\wwwroot\Administrator\A_BM\
@ECHO 开始复制T_BM_DWXX类文件
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX MD E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX
copy T_BM_DWXXApplicationData.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\T_BM_DWXXApplicationLogic.cs copy T_BM_DWXXApplicationLogic.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXApplicationLogicBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\T_BM_DWXXBusinessEntity.cs copy T_BM_DWXXBusinessEntity.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXBusinessEntityBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
IF NOT EXIST E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\T_BM_DWXXWebUI.cs copy T_BM_DWXXWebUI.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXWebUIBase.cs E:\MyWork\richsoft\蒙古族中学\Source\DataLibrary\T_BM_DWXX\
@ECHO 开始安装T_BM_DWXX数据库脚本
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_DWXXStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO 完成安装T_BM_DWXX数据库脚本
@ECHO 完成部署T_BM_DWXX
exit

