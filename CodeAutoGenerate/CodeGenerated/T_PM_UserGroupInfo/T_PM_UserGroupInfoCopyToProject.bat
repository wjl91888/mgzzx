@ECHO ON
cd %cd%\T_PM_UserGroupInfo
@ECHO ��ʼ����T_PM_UserGroupInfo
@ECHO ��ʼ����T_PM_UserGroupInfoҳ���ļ�
copy T_PM_UserGroupInfoWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserGroupInfoWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_PM_UserGroupInfoWebUIAdd.aspx
copy T_PM_UserGroupInfoWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_PM_UserGroupInfoWebUIAdd.aspx.cs
copy T_PM_UserGroupInfoWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_PM_UserGroupInfoWebUIDetail.aspx
copy T_PM_UserGroupInfoWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_PM_UserGroupInfoWebUIDetail.aspx.cs
copy T_PM_UserGroupInfoWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_PM_UserGroupInfoWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_PM_UserGroupInfoWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_PM_UserGroupInfoWebUISearch.aspx
copy T_PM_UserGroupInfoWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_PM_UserGroupInfoWebUISearch.aspx.cs
    @ECHO ��ʼ����T_PM_UserGroupInfo���ļ�
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserGroupInfo MD ..\..\..\DataLibrary\T_PM_UserGroupInfo
copy T_PM_UserGroupInfoApplicationData.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserGroupInfo\T_PM_UserGroupInfoApplicationLogic.cs copy T_PM_UserGroupInfoApplicationLogic.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
copy T_PM_UserGroupInfoApplicationLogicBase.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserGroupInfo\T_PM_UserGroupInfoBusinessEntity.cs copy T_PM_UserGroupInfoBusinessEntity.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
copy T_PM_UserGroupInfoBusinessEntityBase.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserGroupInfo\T_PM_UserGroupInfoWebUI.cs copy T_PM_UserGroupInfoWebUI.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
copy T_PM_UserGroupInfoWebUIBase.cs ..\..\..\DataLibrary\T_PM_UserGroupInfo\
@ECHO ��ʼ����T_PM_UserGroupInfo���ݿ�ű��ļ�
copy T_PM_UserGroupInfoScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_PM_UserGroupInfoScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_PM_UserGroupInfoScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_PM_UserGroupInfoScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO ��ʼ��װT_PM_UserGroupInfo���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_UserGroupInfoScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_PM_UserGroupInfo���ݿ�ű�
@ECHO ��ɲ���T_PM_UserGroupInfo
exit

