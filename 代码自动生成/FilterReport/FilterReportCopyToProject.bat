@ECHO ON
cd %cd%\FilterReport
@ECHO ��ʼ����FilterReport
@ECHO ��ʼ����FilterReportҳ���ļ�
copy FilterReportWebUIAdd.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIAdd.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIDetail.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIDetail.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIImage.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIImage.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUISearch.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUISearch.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIStatistic.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIStatistic.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUITreeSearch.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUITreeSearch.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIListAJAX.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportWebUIListAJAX.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
copy FilterReportContants.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\App_Code\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\FilterReportWebUIList.aspx copy FilterReportWebUIList.aspx E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\FilterReportWebUIList.aspx.cs copy FilterReportWebUIList.aspx.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\wwwroot\Administrator\A_BM\
@ECHO ��ʼ����FilterReport���ļ�
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport MD E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport
copy FilterReportApplicationData.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\FilterReportApplicationLogic.cs copy FilterReportApplicationLogic.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
copy FilterReportApplicationLogicBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\FilterReportBusinessEntity.cs copy FilterReportBusinessEntity.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
copy FilterReportBusinessEntityBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
IF NOT EXIST E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\FilterReportWebUI.cs copy FilterReportWebUI.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
copy FilterReportWebUIBase.cs E:\MyWork\richsoft\�ɹ�����ѧ\Source\DataLibrary\FilterReport\
@ECHO ��ʼ��װFilterReport���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir FilterReportStoreProcedureSQLScriptByOnlyDatabase.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װFilterReport���ݿ�ű�
@ECHO ��ɲ���FilterReport
exit

