@ECHO ON
cd %cd%\Dictionary
@ECHO ��ʼ����Dictionary
@ECHO ��ʼ����Dictionaryҳ���ļ�
copy DictionaryWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy DictionaryWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
@ECHO ��ʼ����Dictionary���ļ�
IF NOT EXIST ..\..\..\DataLibrary\Dictionary MD ..\..\..\DataLibrary\Dictionary
copy DictionaryApplicationData.cs ..\..\..\DataLibrary\Dictionary\
IF NOT EXIST ..\..\..\DataLibrary\Dictionary\DictionaryApplicationLogic.cs copy DictionaryApplicationLogic.cs ..\..\..\DataLibrary\Dictionary\
copy DictionaryApplicationLogicBase.cs ..\..\..\DataLibrary\Dictionary\
IF NOT EXIST ..\..\..\DataLibrary\Dictionary\DictionaryBusinessEntity.cs copy DictionaryBusinessEntity.cs ..\..\..\DataLibrary\Dictionary\
copy DictionaryBusinessEntityBase.cs ..\..\..\DataLibrary\Dictionary\
IF NOT EXIST ..\..\..\DataLibrary\Dictionary\DictionaryWebUI.cs copy DictionaryWebUI.cs ..\..\..\DataLibrary\Dictionary\
copy DictionaryWebUIBase.cs ..\..\..\DataLibrary\Dictionary\
@ECHO ��ʼ����Dictionary���ݿ�ű��ļ�
copy DictionaryScript.table.sql ..\..\..\Database\Scripts\Tables\
copy DictionaryScriptProc.PostDeployment.sql ..\..\..\Database\Scripts\StoreProcedures\
copy DictionaryScriptPurview.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
copy DictionaryScriptUpdateField.PostDeployment.sql ..\..\..\Database\Scripts\Post-Deployment\
@ECHO ��ʼ��װDictionary���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir DictionaryScriptProc.PostDeployment.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װDictionary���ݿ�ű�
@ECHO ��ɲ���Dictionary
exit

