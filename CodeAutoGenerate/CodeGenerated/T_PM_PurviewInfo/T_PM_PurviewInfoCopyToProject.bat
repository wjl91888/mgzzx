@ECHO ON
cd %cd%\T_PM_PurviewInfo
@ECHO ��ʼ����T_PM_PurviewInfo
@ECHO ��ʼ����T_PM_PurviewInfoҳ���ļ�
copy T_PM_PurviewInfoWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_PurviewInfoWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO ��ʼ����T_PM_PurviewInfo���ļ�
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo MD ..\..\..\DataLibrary\T_PM_PurviewInfo
copy T_PM_PurviewInfoApplicationData.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoApplicationLogic.cs copy T_PM_PurviewInfoApplicationLogic.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoApplicationLogicBase.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoBusinessEntity.cs copy T_PM_PurviewInfoBusinessEntity.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoBusinessEntityBase.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_PurviewInfo\T_PM_PurviewInfoWebUI.cs copy T_PM_PurviewInfoWebUI.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
copy T_PM_PurviewInfoWebUIBase.cs ..\..\..\DataLibrary\T_PM_PurviewInfo\
@ECHO ��ʼ����T_PM_PurviewInfo���ݿ�ű��ļ�
copy T_PM_PurviewInfoScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_PM_PurviewInfoScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy T_PM_PurviewInfoScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy T_PM_PurviewInfoScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO ��ʼ��װT_PM_PurviewInfo���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_PurviewInfoScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_PM_PurviewInfo���ݿ�ű�
@ECHO ��ɲ���T_PM_PurviewInfo
exit

