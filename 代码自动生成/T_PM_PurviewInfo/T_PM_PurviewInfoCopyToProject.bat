@ECHO ON
cd %cd%\T_PM_PurviewInfo
@ECHO ��ʼ����T_PM_PurviewInfo
@ECHO ��ʼ����T_PM_PurviewInfoҳ���ļ�
copy T_PM_PurviewInfoWebUIAdd.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIAdd.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIDetail.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIDetail.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIImage.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIImage.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUISearch.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUISearch.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIStatistic.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIStatistic.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUITreeSearch.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUITreeSearch.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIListAJAX.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIListAJAX.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoContants.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\T_PM_PurviewInfoWebUIList.aspx copy T_PM_PurviewInfoWebUIList.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\T_PM_PurviewInfoWebUIList.aspx.cs copy T_PM_PurviewInfoWebUIList.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
@ECHO ��ʼ����T_PM_PurviewInfo���ļ�
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo MD E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo
copy T_PM_PurviewInfoApplicationData.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoApplicationLogic.cs copy T_PM_PurviewInfoApplicationLogic.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoApplicationLogicBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoBusinessEntity.cs copy T_PM_PurviewInfoBusinessEntity.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoBusinessEntityBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoWebUI.cs copy T_PM_PurviewInfoWebUI.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoWebUIBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_PM_PurviewInfo\
@ECHO ��ʼ��װT_PM_PurviewInfo���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_PurviewInfoStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_PM_PurviewInfo���ݿ�ű�
@ECHO ��ɲ���T_PM_PurviewInfo
exit

