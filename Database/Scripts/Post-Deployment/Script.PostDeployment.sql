/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

:r Proc\DictionaryScriptProc.sql
:r Proc\DictionaryTypeScriptProc.sql
:r Proc\FilterReportScriptProc.sql
:r Proc\ShortMessageScriptProc.sql
:r Proc\T_BG_0601ScriptProc.sql
:r Proc\T_BG_0602ScriptProc.sql
:r Proc\T_BM_DWXXScriptProc.sql
:r Proc\T_BM_GZXXScriptProc.sql
:r Proc\T_PM_PurviewInfoScriptProc.sql
:r Proc\T_PM_UserGroupInfoScriptProc.sql
:r Proc\T_PM_UserInfoScriptProc.sql

:r Purview\DictionaryScriptPurview.sql
:r Purview\DictionaryTypeScriptPurview.sql
:r Purview\FilterReportScriptPurview.sql
:r Purview\ShortMessageScriptPurview.sql
:r Purview\T_BG_0601ScriptPurview.sql
:r Purview\T_BG_0602ScriptPurview.sql
:r Purview\T_BM_DWXXScriptPurview.sql
:r Purview\T_BM_GZXXScriptPurview.sql
:r Purview\T_PM_PurviewInfoScriptPurview.sql
:r Purview\T_PM_UserGroupInfoScriptPurview.sql
:r Purview\T_PM_UserInfoScriptPurview.sql

:r UpdateField\DictionaryScriptUpdateField.sql
:r UpdateField\DictionaryTypeScriptUpdateField.sql
:r UpdateField\FilterReportScriptUpdateField.sql
:r UpdateField\ShortMessageScriptUpdateField.sql
:r UpdateField\T_BG_0601ScriptUpdateField.sql
:r UpdateField\T_BG_0602ScriptUpdateField.sql
:r UpdateField\T_BM_DWXXScriptUpdateField.sql
:r UpdateField\T_BM_GZXXScriptUpdateField.sql
:r UpdateField\T_PM_PurviewInfoScriptUpdateField.sql
:r UpdateField\T_PM_UserGroupInfoScriptUpdateField.sql
:r UpdateField\T_PM_UserInfoScriptUpdateField.sql
