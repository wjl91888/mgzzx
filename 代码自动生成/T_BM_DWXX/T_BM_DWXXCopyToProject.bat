@ECHO ON
cd %cd%\T_BM_DWXX
@ECHO ��ʼ����T_BM_DWXX
@ECHO ��ʼ����T_BM_DWXXҳ���ļ�
copy T_BM_DWXXWebUIAdd.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIAdd.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIDetail.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIDetail.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIImage.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIImage.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUISearch.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUISearch.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIStatistic.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIStatistic.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUITreeSearch.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUITreeSearch.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIListAJAX.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXWebUIListAJAX.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy T_BM_DWXXContants.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\T_BM_DWXXWebUIList.aspx copy T_BM_DWXXWebUIList.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\T_BM_DWXXWebUIList.aspx.cs copy T_BM_DWXXWebUIList.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
@ECHO ��ʼ����T_BM_DWXX���ļ�
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX MD E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX
copy T_BM_DWXXApplicationData.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\T_BM_DWXXApplicationLogic.cs copy T_BM_DWXXApplicationLogic.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXApplicationLogicBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\T_BM_DWXXBusinessEntity.cs copy T_BM_DWXXBusinessEntity.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXBusinessEntityBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\T_BM_DWXXWebUI.cs copy T_BM_DWXXWebUI.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
copy T_BM_DWXXWebUIBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\T_BM_DWXX\
@ECHO ��ʼ��װT_BM_DWXX���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_BM_DWXXStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_BM_DWXX���ݿ�ű�
@ECHO ��ɲ���T_BM_DWXX
exit

