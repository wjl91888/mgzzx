@ECHO ON
cd %cd%\T_PM_UserInfo
@ECHO ��ʼ����T_PM_UserInfo
@ECHO ��ʼ����T_PM_UserInfoҳ���ļ�
copy T_PM_UserInfoWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy T_PM_UserInfoWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\T_PM_UserInfoWebUIAdd.aspx
copy T_PM_UserInfoWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_PM_UserInfoWebUIAdd.aspx.cs
copy T_PM_UserInfoWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\T_PM_UserInfoWebUIDetail.aspx
copy T_PM_UserInfoWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_PM_UserInfoWebUIDetail.aspx.cs
copy T_PM_UserInfoWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy T_PM_UserInfoWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy T_PM_UserInfoWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\T_PM_UserInfoWebUISearch.aspx
copy T_PM_UserInfoWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\T_PM_UserInfoWebUISearch.aspx.cs
    @ECHO ��ʼ����T_PM_UserInfo���ļ�
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserInfo MD ..\..\..\DataLibrary\T_PM_UserInfo
copy T_PM_UserInfoApplicationData.cs ..\..\..\DataLibrary\T_PM_UserInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserInfo\T_PM_UserInfoApplicationLogic.cs copy T_PM_UserInfoApplicationLogic.cs ..\..\..\DataLibrary\T_PM_UserInfo\
copy T_PM_UserInfoApplicationLogicBase.cs ..\..\..\DataLibrary\T_PM_UserInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserInfo\T_PM_UserInfoBusinessEntity.cs copy T_PM_UserInfoBusinessEntity.cs ..\..\..\DataLibrary\T_PM_UserInfo\
copy T_PM_UserInfoBusinessEntityBase.cs ..\..\..\DataLibrary\T_PM_UserInfo\
IF NOT EXIST ..\..\..\DataLibrary\T_PM_UserInfo\T_PM_UserInfoWebUI.cs copy T_PM_UserInfoWebUI.cs ..\..\..\DataLibrary\T_PM_UserInfo\
copy T_PM_UserInfoWebUIBase.cs ..\..\..\DataLibrary\T_PM_UserInfo\
@ECHO ��ʼ����T_PM_UserInfo���ݿ�ű��ļ�
copy T_PM_UserInfoScript.table.sql ..\..\..\Database\Scripts\Tables\
copy T_PM_UserInfoScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy T_PM_UserInfoScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy T_PM_UserInfoScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO ��ʼ��װT_PM_UserInfo���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir T_PM_UserInfoScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װT_PM_UserInfo���ݿ�ű�
@ECHO ��ɲ���T_PM_UserInfo
exit

