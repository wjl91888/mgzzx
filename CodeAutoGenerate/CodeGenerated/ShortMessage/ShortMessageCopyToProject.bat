@ECHO ON
cd %cd%\ShortMessage
@ECHO ��ʼ����ShortMessage
@ECHO ��ʼ����ShortMessageҳ���ļ�
copy ShortMessageWebUIAdd.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIAdd.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIDetail.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIDetail.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIImage.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIImage.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUISearch.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUISearch.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIStatistic.aspx ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIStatistic.aspx.cs ..\..\..\wwwroot\Administrator\A_BM\
copy ShortMessageWebUIAddForApp.aspx ..\..\..\wwwroot\App\A_BM\ShortMessageWebUIAdd.aspx
copy ShortMessageWebUIAddForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\ShortMessageWebUIAdd.aspx.cs
copy ShortMessageWebUIDetailForApp.aspx ..\..\..\wwwroot\App\A_BM\ShortMessageWebUIDetail.aspx
copy ShortMessageWebUIDetailForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\ShortMessageWebUIDetail.aspx.cs
copy ShortMessageWebUIImage.aspx ..\..\..\wwwroot\App\A_BM\
copy ShortMessageWebUIImage.aspx.cs ..\..\..\wwwroot\App\A_BM\
copy ShortMessageWebUISearchForApp.aspx ..\..\..\wwwroot\App\A_BM\ShortMessageWebUISearch.aspx
copy ShortMessageWebUISearchForApp.aspx.cs ..\..\..\wwwroot\App\A_BM\ShortMessageWebUISearch.aspx.cs
    @ECHO ��ʼ����ShortMessage���ļ�
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage MD ..\..\..\DataLibrary\ShortMessage
copy ShortMessageApplicationData.cs ..\..\..\DataLibrary\ShortMessage\
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage\ShortMessageApplicationLogic.cs copy ShortMessageApplicationLogic.cs ..\..\..\DataLibrary\ShortMessage\
copy ShortMessageApplicationLogicBase.cs ..\..\..\DataLibrary\ShortMessage\
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage\ShortMessageBusinessEntity.cs copy ShortMessageBusinessEntity.cs ..\..\..\DataLibrary\ShortMessage\
copy ShortMessageBusinessEntityBase.cs ..\..\..\DataLibrary\ShortMessage\
IF NOT EXIST ..\..\..\DataLibrary\ShortMessage\ShortMessageWebUI.cs copy ShortMessageWebUI.cs ..\..\..\DataLibrary\ShortMessage\
copy ShortMessageWebUIBase.cs ..\..\..\DataLibrary\ShortMessage\
@ECHO ��ʼ����ShortMessage���ݿ�ű��ļ�
copy ShortMessageScript.table.sql ..\..\..\Database\Scripts\Tables\
copy ShortMessageScriptProc.sql ..\..\..\Database\Scripts\Post-Deployment\Proc\
copy ShortMessageScriptPurview.sql ..\..\..\Database\Scripts\Post-Deployment\Purview\
copy ShortMessageScriptUpdateField.sql ..\..\..\Database\Scripts\Post-Deployment\UpdateField\
@ECHO ��ʼ��װShortMessage���ݿ�ű�
echo Begin > log.log
for /f "delims=" %%a in ('dir ShortMessageScriptProc.sql /s /b') do (sqlcmd -d DB_MGZZX -i %%a >> log.log)
echo End >> log.log
@ECHO ��ɰ�װShortMessage���ݿ�ű�
@ECHO ��ɲ���ShortMessage
exit

