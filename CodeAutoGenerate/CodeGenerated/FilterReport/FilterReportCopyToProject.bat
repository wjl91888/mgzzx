@ECHO ON
cd %cd%\FilterReport
@ECHO ��ʼ����FilterReport
@ECHO ��ʼ����FilterReportҳ���ļ�
copy FilterReportWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy FilterReportWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO ��ʼ����FilterReport���ļ�
IF NOT EXIST ..\..\..\DataLibrary\FilterReport MD ..\..\..\DataLibrary\FilterReport
copy FilterReportApplicationData.cs ..\..\..\DataLibrary\FilterReport\
IF NOT EXIST ..\..\..\DataLibrary\FilterReport\FilterReportApplicationLogic.cs copy FilterReportApplicationLogic.cs ..\..\..\DataLibrary\FilterReport\
copy FilterReportApplicationLogicBase.cs ..\..\..\DataLibrary\FilterReport\
IF NOT EXIST ..\..\..\DataLibrary\FilterReport\FilterReportBusinessEntity.cs copy FilterReportBusinessEntity.cs ..\..\..\DataLibrary\FilterReport\
copy FilterReportBusinessEntityBase.cs ..\..\..\DataLibrary\FilterReport\
IF NOT EXIST ..\..\..\DataLibrary\FilterReport\FilterReportWebUI.cs copy FilterReportWebUI.cs ..\..\..\DataLibrary\FilterReport\
copy FilterReportWebUIBase.cs ..\..\..\DataLibrary\FilterReport\
@ECHO ��ʼ����FilterReport���ݿ�ű��ļ�
copy FilterReportScript.table.sql ..\..\..\Database\Scripts\Tables\
copy FilterReportScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy FilterReportScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy FilterReportScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO ��ʼ��װFilterReport���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir FilterReportScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װFilterReport���ݿ�ű�
@ECHO ��ɲ���FilterReport
exit

