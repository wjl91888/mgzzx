@ECHO ON
cd %cd%\DictionaryType
@ECHO ��ʼ����DictionaryType
@ECHO ��ʼ����DictionaryTypeҳ���ļ�
copy DictionaryTypeWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryTypeWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\DictionaryTypeWebUIAdd.aspx
copy DictionaryTypeWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\DictionaryTypeWebUIAdd.aspx.cs
copy DictionaryTypeWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\DictionaryTypeWebUIDetail.aspx
copy DictionaryTypeWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\DictionaryTypeWebUIDetail.aspx.cs
copy DictionaryTypeWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy DictionaryTypeWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy DictionaryTypeWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\DictionaryTypeWebUISearch.aspx
copy DictionaryTypeWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\DictionaryTypeWebUISearch.aspx.cs
    @ECHO ��ʼ����DictionaryType���ļ�
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType MD ..\..\..\DataLibrary\DictionaryType
copy DictionaryTypeApplicationData.cs ..\..\..\DataLibrary\DictionaryType\
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType\DictionaryTypeApplicationLogic.cs copy DictionaryTypeApplicationLogic.cs ..\..\..\DataLibrary\DictionaryType\
copy DictionaryTypeApplicationLogicBase.cs ..\..\..\DataLibrary\DictionaryType\
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType\DictionaryTypeBusinessEntity.cs copy DictionaryTypeBusinessEntity.cs ..\..\..\DataLibrary\DictionaryType\
copy DictionaryTypeBusinessEntityBase.cs ..\..\..\DataLibrary\DictionaryType\
IF NOT EXIST ..\..\..\DataLibrary\DictionaryType\DictionaryTypeWebUI.cs copy DictionaryTypeWebUI.cs ..\..\..\DataLibrary\DictionaryType\
copy DictionaryTypeWebUIBase.cs ..\..\..\DataLibrary\DictionaryType\
@ECHO ��ʼ����DictionaryType���ݿ�ű��ļ�
copy DictionaryTypeScript.table.sql ..\..\..\Database\Scripts\Tables\
copy DictionaryTypeScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy DictionaryTypeScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy DictionaryTypeScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO ��ʼ��װDictionaryType���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir DictionaryTypeScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װDictionaryType���ݿ�ű�
@ECHO ��ɲ���DictionaryType
exit

