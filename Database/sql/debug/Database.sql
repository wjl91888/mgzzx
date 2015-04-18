/*
Deployment script for DB_NMGSKL
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "DB_NMGSKL"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL10_50.MSSQLSERVER\MSSQL\DATA\"

GO
:on error exit
GO
USE [master]
GO
IF (DB_ID(N'$(DatabaseName)') IS NOT NULL
    AND DATABASEPROPERTYEX(N'$(DatabaseName)','Status') <> N'ONLINE')
BEGIN
    RAISERROR(N'The state of the target database, %s, is not set to ONLINE. To deploy to this database, its state must be set to ONLINE.', 16, 127,N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO

IF NOT EXISTS (SELECT 1 FROM [master].[dbo].[sysdatabases] WHERE [name] = N'$(DatabaseName)')
BEGIN
    RAISERROR(N'You cannot deploy this update script to target WIN-PDKV65PO6D3. The database for which this script was built, DB_NMGSKL, does not exist on this server.', 16, 127) WITH NOWAIT
    RETURN
END

GO

IF (@@servername != 'WIN-PDKV65PO6D3')
BEGIN
    RAISERROR(N'The server name in the build script %s does not match the name of the target server %s. Verify whether your database project settings are correct and whether your build script is up to date.', 16, 127,N'WIN-PDKV65PO6D3',@@servername) WITH NOWAIT
    RETURN
END

GO

IF CAST(DATABASEPROPERTY(N'$(DatabaseName)','IsReadOnly') as bit) = 1
BEGIN
    RAISERROR(N'You cannot deploy this update script because the database for which it was built, %s , is set to READ_ONLY.', 16, 127, N'$(DatabaseName)') WITH NOWAIT
    RETURN
END

GO
EXECUTE sp_dbcmptlevel [$(DatabaseName)], 100;


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ANSI_NULLS ON,
                ANSI_PADDING ON,
                ANSI_WARNINGS ON,
                ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                QUOTED_IDENTIFIER ON,
                ANSI_NULL_DEFAULT ON,
                CURSOR_DEFAULT LOCAL,
                RECOVERY FULL,
                AUTO_SHRINK OFF 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE 
            WITH ROLLBACK IMMEDIATE;
    END


GO
USE [$(DatabaseName)]
GO
/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

GO
/*
The type for column XXZT in table [dbo].[T_BG_0601] is currently  NVARCHAR (10) NULL but is being changed to  NVARCHAR (2) NULL. Data loss could occur.
*/

IF EXISTS (select top 1 1 from [dbo].[T_BG_0601])
    RAISERROR ('Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
/*
The column [dbo].[T_PM_UserInfo].[MZ] on table [dbo].[T_PM_UserInfo] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue, you must add a default value to the column or mark it as allowing NULL values.

The column [dbo].[T_PM_UserInfo].[SFZH] on table [dbo].[T_PM_UserInfo] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue, you must add a default value to the column or mark it as allowing NULL values.

The column [dbo].[T_PM_UserInfo].[SJH] on table [dbo].[T_PM_UserInfo] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue, you must add a default value to the column or mark it as allowing NULL values.

The column [dbo].[T_PM_UserInfo].[XB] on table [dbo].[T_PM_UserInfo] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue, you must add a default value to the column or mark it as allowing NULL values.

The column [dbo].[T_PM_UserInfo].[ZZMM] on table [dbo].[T_PM_UserInfo] must be added, but the column has no default value and does not allow NULL values. If the table contains data, the ALTER script will not work. To avoid this issue, you must add a default value to the column or mark it as allowing NULL values.
*/

IF EXISTS (select top 1 1 from [dbo].[T_PM_UserInfo])
    RAISERROR ('Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[DWBH].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'DWBH';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[DWMC].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'DWMC';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[DZ].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'DZ';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[YB].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'YB';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[LXBM].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'LXBM';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[LXDH].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'LXDH';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[LXR].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'LXR';


GO
PRINT N'Dropping [dbo].[T_BM_DWXX].[SJ].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'SJ';


GO
PRINT N'Dropping [dbo].[Dictionary].[DM].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'DM';


GO
PRINT N'Dropping [dbo].[Dictionary].[LX].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'LX';


GO
PRINT N'Dropping [dbo].[Dictionary].[MC].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'MC';


GO
PRINT N'Dropping [dbo].[Dictionary].[SJDM].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'SJDM';


GO
PRINT N'Dropping [dbo].[Dictionary].[SM].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'SM';


GO
PRINT N'Dropping [dbo].[DictionaryType].[DM].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'DM';


GO
PRINT N'Dropping [dbo].[DictionaryType].[MC].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'MC';


GO
PRINT N'Dropping [dbo].[DictionaryType].[SM].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'SM';


GO
PRINT N'Dropping [dbo].[FilterReport].[BGCJSJ].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGCJSJ';


GO
PRINT N'Dropping [dbo].[FilterReport].[BGCXTJ].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGCXTJ';


GO
PRINT N'Dropping [dbo].[FilterReport].[BGLX].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGLX';


GO
PRINT N'Dropping [dbo].[FilterReport].[BGMC].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGMC';


GO
PRINT N'Dropping [dbo].[FilterReport].[GXBG].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'GXBG';


GO
PRINT N'Dropping [dbo].[FilterReport].[UserID].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'UserID';


GO
PRINT N'Dropping [dbo].[FilterReport].[XTBG].[MS_Description]...';


GO
EXECUTE sp_dropextendedproperty @name = N'MS_Description', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'XTBG';


GO
PRINT N'Dropping DF_T_BG_0601_ObjectID...';


GO
ALTER TABLE [dbo].[T_BG_0601] DROP CONSTRAINT [DF_T_BG_0601_ObjectID];


GO
PRINT N'Dropping DF_T_BG_0602_ObjectID...';


GO
ALTER TABLE [dbo].[T_BG_0602] DROP CONSTRAINT [DF_T_BG_0602_ObjectID];


GO
PRINT N'Dropping DF_T_BM_DWXX_ObjectID...';


GO
ALTER TABLE [dbo].[T_BM_DWXX] DROP CONSTRAINT [DF_T_BM_DWXX_ObjectID];


GO
PRINT N'Dropping DF_T_PM_UserInfo1_ObjectID...';


GO
ALTER TABLE [dbo].[T_PM_UserInfo] DROP CONSTRAINT [DF_T_PM_UserInfo1_ObjectID];


GO
PRINT N'Dropping DF_T_PM_UserInfo1_LoginTimes...';


GO
ALTER TABLE [dbo].[T_PM_UserInfo] DROP CONSTRAINT [DF_T_PM_UserInfo1_LoginTimes];


GO
PRINT N'Dropping DF_T_PM_UserInfo_Status...';


GO
ALTER TABLE [dbo].[T_PM_UserInfo] DROP CONSTRAINT [DF_T_PM_UserInfo_Status];


GO
PRINT N'Dropping DF_T_PM_UserInfo_vcode...';


GO
ALTER TABLE [dbo].[T_PM_UserInfo] DROP CONSTRAINT [DF_T_PM_UserInfo_vcode];


GO
PRINT N'Dropping DF_T_PM_UserGroupInfo1_ObjectID...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupInfo] DROP CONSTRAINT [DF_T_PM_UserGroupInfo1_ObjectID];


GO
PRINT N'Dropping DF_T_PM_UserGroupInfo1_UserGroupID...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupInfo] DROP CONSTRAINT [DF_T_PM_UserGroupInfo1_UserGroupID];


GO
PRINT N'Dropping FK_T_PM_UserGroupPurviewInfo_T_PM_UserGroupInfo...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupPurviewInfo] DROP CONSTRAINT [FK_T_PM_UserGroupPurviewInfo_T_PM_UserGroupInfo];


GO
PRINT N'Dropping FK_Dictionary_DictionaryType...';


GO
ALTER TABLE [dbo].[Dictionary] DROP CONSTRAINT [FK_Dictionary_DictionaryType];


GO
PRINT N'Dropping FK_T_PM_PurviewInfo_T_PM_PurviewTypeInfo...';


GO
ALTER TABLE [dbo].[T_PM_PurviewInfo] DROP CONSTRAINT [FK_T_PM_PurviewInfo_T_PM_PurviewTypeInfo];


GO
PRINT N'Dropping PK_T_BG_0602...';


GO
ALTER TABLE [dbo].[T_BG_0602] DROP CONSTRAINT [PK_T_BG_0602];


GO
PRINT N'Dropping PK_T_PM_UserGroupInfo1...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupInfo] DROP CONSTRAINT [PK_T_PM_UserGroupInfo1];


GO
PRINT N'Starting rebuilding table [dbo].[T_BG_0601]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_T_BG_0601] (
    [ObjectID]   UNIQUEIDENTIFIER CONSTRAINT [DF_T_BG_0601_ObjectID] DEFAULT (newid()) NULL,
    [FBH]        NVARCHAR (10)    NOT NULL,
    [BT]         NVARCHAR (100)   NOT NULL,
    [LanguageID] NVARCHAR (2)     NULL,
    [FBLM]       NVARCHAR (8)     NOT NULL,
    [FBBM]       NVARCHAR (50)    NULL,
    [FBZT]       NVARCHAR (8)     NULL,
    [XXLX]       NVARCHAR (2)     NOT NULL,
    [XXTPDZ]     NVARCHAR (255)   NULL,
    [XXNR]       NTEXT            NOT NULL,
    [FJXZDZ]     NVARCHAR (4000)  NULL,
    [PZRJGH]     NVARCHAR (10)    NULL,
    [XXZT]       NVARCHAR (2)     CONSTRAINT [DF_T_BG_0601_XXZT] DEFAULT (02) NULL,
    [IsTop]      NVARCHAR (1)     CONSTRAINT [DF_T_BG_0601_IsTop] DEFAULT (0) NULL,
    [TopSort]    INT              CONSTRAINT [DF_T_BG_0601_TopSort] DEFAULT (0) NULL,
    [IsBest]     NVARCHAR (1)     CONSTRAINT [DF_T_BG_0601_IsBest] DEFAULT (0) NULL,
    [YXSJRQ]     DATETIME         NULL,
    [FBRJGH]     NVARCHAR (10)    NULL,
    [FBSJRQ]     DATETIME         NULL,
    [FBIP]       NVARCHAR (20)    NULL,
    [LLCS]       INT              CONSTRAINT [DF_T_BG_0601_LLCS] DEFAULT (0) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_T_BG_0601] PRIMARY KEY CLUSTERED ([FBH] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[T_BG_0601])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_T_BG_0601] ([FBH], [ObjectID], [BT], [LanguageID], [FBLM], [FBZT], [XXLX], [XXTPDZ], [XXNR], [FJXZDZ], [PZRJGH], [XXZT], [IsTop], [TopSort], [IsBest], [YXSJRQ], [FBRJGH], [FBSJRQ], [FBIP], [LLCS])
        SELECT   [FBH],
                 [ObjectID],
                 [BT],
                 [LanguageID],
                 [FBLM],
                 [FBZT],
                 [XXLX],
                 [XXTPDZ],
                 [XXNR],
                 [FJXZDZ],
                 [PZRJGH],
                 [XXZT],
                 [IsTop],
                 [TopSort],
                 [IsBest],
                 [YXSJRQ],
                 [FBRJGH],
                 [FBSJRQ],
                 [FBIP],
                 [LLCS]
        FROM     [dbo].[T_BG_0601]
        ORDER BY [FBH] ASC;
    END

DROP TABLE [dbo].[T_BG_0601];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_T_BG_0601]', N'T_BG_0601';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_T_BG_0601]', N'PK_T_BG_0601', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Altering [dbo].[T_BG_0602]...';


GO
ALTER TABLE [dbo].[T_BG_0602] ALTER COLUMN [LMLBYS] NVARCHAR (2) NOT NULL;

ALTER TABLE [dbo].[T_BG_0602] ALTER COLUMN [LMNR] NVARCHAR (200) NOT NULL;

ALTER TABLE [dbo].[T_BG_0602] ALTER COLUMN [SFLBLM] NVARCHAR (1) NOT NULL;

ALTER TABLE [dbo].[T_BG_0602] ALTER COLUMN [SFWBURL] NVARCHAR (1) NOT NULL;


GO
PRINT N'Creating PK_T_BG_0602...';


GO
ALTER TABLE [dbo].[T_BG_0602]
    ADD CONSTRAINT [PK_T_BG_0602] PRIMARY KEY CLUSTERED ([LMH] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Starting rebuilding table [dbo].[T_BM_DWXX]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_T_BM_DWXX] (
    [ObjectID] UNIQUEIDENTIFIER CONSTRAINT [DF_T_BM_DWXX_ObjectID] DEFAULT (newid()) NULL,
    [DWBH]     NVARCHAR (10)    NOT NULL,
    [DWMC]     NVARCHAR (255)   NOT NULL,
    [SJDWBH]   NVARCHAR (255)   NULL,
    [DZ]       NVARCHAR (255)   NULL,
    [YB]       NVARCHAR (6)     NULL,
    [LXBM]     NVARCHAR (50)    NULL,
    [LXDH]     NVARCHAR (50)    NULL,
    [Email]    NVARCHAR (255)   NULL,
    [LXR]      NVARCHAR (50)    NULL,
    [SJ]       NVARCHAR (50)    NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_T_BM_DWXX] PRIMARY KEY CLUSTERED ([DWBH] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[T_BM_DWXX])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_T_BM_DWXX] ([DWBH], [ObjectID], [DWMC], [DZ], [YB], [LXBM], [LXDH], [Email], [LXR], [SJ])
        SELECT   [DWBH],
                 [ObjectID],
                 [DWMC],
                 [DZ],
                 [YB],
                 [LXBM],
                 [LXDH],
                 [Email],
                 [LXR],
                 [SJ]
        FROM     [dbo].[T_BM_DWXX]
        ORDER BY [DWBH] ASC;
    END

DROP TABLE [dbo].[T_BM_DWXX];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_T_BM_DWXX]', N'T_BM_DWXX';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_T_BM_DWXX]', N'PK_T_BM_DWXX', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Starting rebuilding table [dbo].[T_PM_UserInfo]...';


GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;

SET XACT_ABORT ON;

BEGIN TRANSACTION;

CREATE TABLE [dbo].[tmp_ms_xx_T_PM_UserInfo] (
    [ObjectID]      UNIQUEIDENTIFIER CONSTRAINT [DF_T_PM_UserInfo_ObjectID] DEFAULT (newid()) NULL,
    [UserID]        NVARCHAR (50)    NOT NULL,
    [UserLoginName] NVARCHAR (50)    NOT NULL,
    [UserGroupID]   NVARCHAR (500)   NOT NULL,
    [SubjectID]     NVARCHAR (50)    NOT NULL,
    [UserNickName]  NVARCHAR (50)    NOT NULL,
    [Password]      NVARCHAR (50)    NOT NULL,
    [XB]            NVARCHAR (2)     NOT NULL,
    [MZ]            NVARCHAR (2)     NOT NULL,
    [ZZMM]          NVARCHAR (2)     NOT NULL,
    [SFZH]          NVARCHAR (18)    NOT NULL,
    [SJH]           NVARCHAR (50)    NOT NULL,
    [BGDH]          NVARCHAR (50)    NULL,
    [JTDH]          NVARCHAR (50)    NULL,
    [Email]         NVARCHAR (50)    NULL,
    [QQH]           NVARCHAR (50)    NULL,
    [LoginTime]     DATETIME         NULL,
    [LastLoginIP]   NVARCHAR (50)    NULL,
    [LastLoginDate] DATETIME         NULL,
    [LoginTimes]    INT              CONSTRAINT [DF_T_PM_UserInfo_LoginTimes] DEFAULT ((0)) NULL,
    [UserStatus]    NVARCHAR (2)     CONSTRAINT [DF_T_PM_UserInfo_UserStatus] DEFAULT ('01') NOT NULL,
    [vcode]         UNIQUEIDENTIFIER CONSTRAINT [DF_T_PM_UserInfo_vcode] DEFAULT (newid()) NULL,
    CONSTRAINT [tmp_ms_xx_constraint_PK_T_PM_UserInfo] PRIMARY KEY CLUSTERED ([UserID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];

IF EXISTS (SELECT TOP 1 1
           FROM   [dbo].[T_PM_UserInfo])
    BEGIN
        INSERT INTO [dbo].[tmp_ms_xx_T_PM_UserInfo] ([UserID], [ObjectID], [UserLoginName], [UserGroupID], [SubjectID], [UserNickName], [Password], [LoginTime], [LastLoginIP], [LastLoginDate], [LoginTimes], [UserStatus], [vcode])
        SELECT   [UserID],
                 [ObjectID],
                 [UserLoginName],
                 [UserGroupID],
                 [SubjectID],
                 [UserNickName],
                 [Password],
                 [LoginTime],
                 [LastLoginIP],
                 [LastLoginDate],
                 [LoginTimes],
                 [UserStatus],
                 [vcode]
        FROM     [dbo].[T_PM_UserInfo]
        ORDER BY [UserID] ASC;
    END

DROP TABLE [dbo].[T_PM_UserInfo];

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_T_PM_UserInfo]', N'T_PM_UserInfo';

EXECUTE sp_rename N'[dbo].[tmp_ms_xx_constraint_PK_T_PM_UserInfo]', N'PK_T_PM_UserInfo', N'OBJECT';

COMMIT TRANSACTION;

SET TRANSACTION ISOLATION LEVEL READ COMMITTED;


GO
PRINT N'Creating [dbo].[ShortMessage]...';


GO
CREATE TABLE [dbo].[ShortMessage] (
    [ObjectID] UNIQUEIDENTIFIER NOT NULL,
    [DXXBT]    NVARCHAR (100)   NOT NULL,
    [DXXLX]    NVARCHAR (2)     NULL,
    [DXXNR]    NTEXT            NULL,
    [DXXFJ]    NVARCHAR (255)   NULL,
    [FSSJ]     DATETIME         NULL,
    [FSR]      NVARCHAR (50)    NULL,
    [FSBM]     NVARCHAR (50)    NULL,
    [FSIP]     NVARCHAR (50)    NULL,
    [JSR]      NVARCHAR (4000)  NOT NULL,
    [SFCK]     BIT              NULL,
    [CKSJ]     DATETIME         NULL,
    CONSTRAINT [PK_ShortMessage] PRIMARY KEY CLUSTERED ([ObjectID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
PRINT N'Creating [dbo].[T_BM_GZXX]...';


GO
CREATE TABLE [dbo].[T_BM_GZXX] (
    [ObjectID] UNIQUEIDENTIFIER NULL,
    [XM]       NVARCHAR (50)    NOT NULL,
    [XB]       NVARCHAR (2)     NULL,
    [SFZH]     NVARCHAR (18)    NOT NULL,
    [FFGZNY]   NVARCHAR (6)     NOT NULL,
    [JCGZ]     FLOAT            NULL,
    [JSDJGZ]   FLOAT            NULL,
    [ZWGZ]     FLOAT            NULL,
    [JBGZ]     FLOAT            NULL,
    [JKDQJT]   FLOAT            NULL,
    [JKTSGWJT] FLOAT            NULL,
    [GLGZ]     FLOAT            NULL,
    [XJGZ]     FLOAT            NULL,
    [TGBF]     FLOAT            NULL,
    [DHF]      FLOAT            NULL,
    [DSZNF]    FLOAT            NULL,
    [FNWSHLF]  FLOAT            NULL,
    [HLF]      FLOAT            NULL,
    [JJ]       FLOAT            NULL,
    [JTF]      FLOAT            NULL,
    [JHLGZ]    FLOAT            NULL,
    [JT]       FLOAT            NULL,
    [BF]       FLOAT            NULL,
    [QTBT]     FLOAT            NULL,
    [DFXJT]    FLOAT            NULL,
    [YFX]      FLOAT            NULL,
    [QTKK]     FLOAT            NULL,
    [SYBX]     FLOAT            NULL,
    [SDNQF]    FLOAT            NULL,
    [SDS]      FLOAT            NULL,
    [YLBX]     FLOAT            NULL,
    [YLIBX]    FLOAT            NULL,
    [YSSHF]    FLOAT            NULL,
    [ZFGJJ]    FLOAT            NULL,
    [KFX]      FLOAT            NULL,
    [SFGZ]     FLOAT            NULL,
    [GZKKSM]   NVARCHAR (1000)  NULL,
    [TJSJ]     DATETIME         NULL,
    CONSTRAINT [PK_T_BM_GZXX] PRIMARY KEY CLUSTERED ([SFZH] ASC, [FFGZNY] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY];


GO
PRINT N'Creating PK_T_PM_UserGroupInfo...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupInfo]
    ADD CONSTRAINT [PK_T_PM_UserGroupInfo] PRIMARY KEY CLUSTERED ([UserGroupID] ASC) WITH (ALLOW_PAGE_LOCKS = ON, ALLOW_ROW_LOCKS = ON, PAD_INDEX = OFF, IGNORE_DUP_KEY = OFF, STATISTICS_NORECOMPUTE = OFF) ON [PRIMARY];


GO
PRINT N'Creating DF_T_BG_0602_ObjectID...';


GO
ALTER TABLE [dbo].[T_BG_0602]
    ADD CONSTRAINT [DF_T_BG_0602_ObjectID] DEFAULT (newid()) FOR [ObjectID];


GO
PRINT N'Creating DF_ShortMessage_ObjectID...';


GO
ALTER TABLE [dbo].[ShortMessage]
    ADD CONSTRAINT [DF_ShortMessage_ObjectID] DEFAULT (newid()) FOR [ObjectID];


GO
PRINT N'Creating DF_T_BM_GZXX_ObjectID...';


GO
ALTER TABLE [dbo].[T_BM_GZXX]
    ADD CONSTRAINT [DF_T_BM_GZXX_ObjectID] DEFAULT (newid()) FOR [ObjectID];


GO
PRINT N'Creating DF_T_PM_UserGroupInfo_ObjectID...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupInfo]
    ADD CONSTRAINT [DF_T_PM_UserGroupInfo_ObjectID] DEFAULT (newid()) FOR [ObjectID];


GO
PRINT N'Creating DF_T_PM_UserGroupInfo_UserGroupID...';


GO
ALTER TABLE [dbo].[T_PM_UserGroupInfo]
    ADD CONSTRAINT [DF_T_PM_UserGroupInfo_UserGroupID] DEFAULT (newid()) FOR [UserGroupID];


GO
PRINT N'Creating [dbo].[T_BG_0601].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBH';


GO
PRINT N'Creating [dbo].[T_BG_0601].[BT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'BT';


GO
PRINT N'Creating [dbo].[T_BG_0601].[LanguageID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'LanguageID';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBLM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������Ŀ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBLM';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBBM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBBM';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBZT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����ר��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBZT';


GO
PRINT N'Creating [dbo].[T_BG_0601].[XXLX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ϣ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'XXLX';


GO
PRINT N'Creating [dbo].[T_BG_0601].[XXTPDZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ϢͼƬ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'XXTPDZ';


GO
PRINT N'Creating [dbo].[T_BG_0601].[XXNR].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ϣ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'XXNR';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FJXZDZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FJXZDZ';


GO
PRINT N'Creating [dbo].[T_BG_0601].[PZRJGH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��׼��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'PZRJGH';


GO
PRINT N'Creating [dbo].[T_BG_0601].[XXZT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ϣ״̬', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'XXZT';


GO
PRINT N'Creating [dbo].[T_BG_0601].[IsTop].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�Ƿ��ö�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'IsTop';


GO
PRINT N'Creating [dbo].[T_BG_0601].[TopSort].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ö����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'TopSort';


GO
PRINT N'Creating [dbo].[T_BG_0601].[IsBest].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�Ƽ�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'IsBest';


GO
PRINT N'Creating [dbo].[T_BG_0601].[YXSJRQ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Чʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'YXSJRQ';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBRJGH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBRJGH';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBSJRQ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBSJRQ';


GO
PRINT N'Creating [dbo].[T_BG_0601].[FBIP].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'FBIP';


GO
PRINT N'Creating [dbo].[T_BG_0601].[LLCS].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0601', @level2type = N'COLUMN', @level2name = N'LLCS';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[DWBH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��λ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'DWBH';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[DWMC].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��λ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'DWMC';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[SJDWBH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ϼ���λ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'SJDWBH';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[DZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ַ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'DZ';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[YB].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ʱ�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'YB';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[LXBM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ϵ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'LXBM';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[LXDH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ϵ�绰', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'LXDH';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[Email].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Email', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'Email';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[LXR].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ϵ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'LXR';


GO
PRINT N'Creating [dbo].[T_BM_DWXX].[SJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ֻ�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_DWXX', @level2type = N'COLUMN', @level2name = N'SJ';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[UserID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'UserID';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[UserLoginName].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'UserLoginName';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[UserGroupID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'UserGroupID';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[SubjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�����λ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'SubjectID';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[UserNickName].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'UserNickName';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[Password].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'Password';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[XB].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�Ա�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'XB';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[MZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'MZ';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[ZZMM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������ò', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'ZZMM';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[SFZH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���֤��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'SFZH';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[SJH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ֻ�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'SJH';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[BGDH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�칫�绰', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'BGDH';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[JTDH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ͥ�绰', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'JTDH';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[Email].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Email', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'Email';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[QQH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'QQ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'QQH';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[LoginTime].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��¼ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'LoginTime';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[LastLoginIP].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��¼IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'LastLoginIP';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[LastLoginDate].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ϴ�ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'LastLoginDate';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[LoginTimes].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��¼����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'LoginTimes';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[UserStatus].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û�״̬', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'UserStatus';


GO
PRINT N'Creating [dbo].[T_PM_UserInfo].[vcode].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��֤��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserInfo', @level2type = N'COLUMN', @level2name = N'vcode';


GO
PRINT N'Creating [dbo].[Dictionary].[DM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'DM';


GO
PRINT N'Creating [dbo].[Dictionary].[LX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'LX';


GO
PRINT N'Creating [dbo].[Dictionary].[MC].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'MC';


GO
PRINT N'Creating [dbo].[Dictionary].[SJDM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ϼ�����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'SJDM';


GO
PRINT N'Creating [dbo].[Dictionary].[SM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'˵��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'SM';


GO
PRINT N'Creating [dbo].[DictionaryType].[DM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���ʹ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'DM';


GO
PRINT N'Creating [dbo].[DictionaryType].[MC].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'MC';


GO
PRINT N'Creating [dbo].[DictionaryType].[SM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'˵��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'SM';


GO
PRINT N'Creating [dbo].[FilterReport].[BGCJSJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGCJSJ';


GO
PRINT N'Creating [dbo].[FilterReport].[BGCXTJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGCXTJ';


GO
PRINT N'Creating [dbo].[FilterReport].[BGLX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGLX';


GO
PRINT N'Creating [dbo].[FilterReport].[BGMC].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'BGMC';


GO
PRINT N'Creating [dbo].[FilterReport].[GXBG].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'GXBG';


GO
PRINT N'Creating [dbo].[FilterReport].[UserID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'UserID';


GO
PRINT N'Creating [dbo].[FilterReport].[XTBG].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ϵͳ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'XTBG';


GO
PRINT N'Creating [dbo].[ShortMessage].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[ShortMessage].[DXXBT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'DXXBT';


GO
PRINT N'Creating [dbo].[ShortMessage].[DXXLX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'DXXLX';


GO
PRINT N'Creating [dbo].[ShortMessage].[DXXNR].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'DXXNR';


GO
PRINT N'Creating [dbo].[ShortMessage].[DXXFJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'DXXFJ';


GO
PRINT N'Creating [dbo].[ShortMessage].[FSSJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'FSSJ';


GO
PRINT N'Creating [dbo].[ShortMessage].[FSR].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'FSR';


GO
PRINT N'Creating [dbo].[ShortMessage].[FSBM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���Ͳ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'FSBM';


GO
PRINT N'Creating [dbo].[ShortMessage].[FSIP].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����IP', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'FSIP';


GO
PRINT N'Creating [dbo].[ShortMessage].[JSR].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'JSR';


GO
PRINT N'Creating [dbo].[ShortMessage].[SFCK].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�鿴״̬', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'SFCK';


GO
PRINT N'Creating [dbo].[ShortMessage].[CKSJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�鿴ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'ShortMessage', @level2type = N'COLUMN', @level2name = N'CKSJ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[XM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'XM';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[XB].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�Ա�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'XB';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[SFZH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���֤��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'SFZH';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[FFGZNY].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'FFGZNY';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JCGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JCGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JSDJGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�����ȼ�����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JSDJGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[ZWGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ְ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'ZWGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JBGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JBGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JKDQJT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JKDQJT';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JKTSGWJT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����ظڽ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JKTSGWJT';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[GLGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���乤��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'GLGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[XJGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'н������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'XJGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[TGBF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'10%��߲���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'TGBF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[DHF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�绰��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'DHF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[DSZNF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'������Ů��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'DSZNF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[FNWSHLF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ů������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'FNWSHLF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[HLF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'HLF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ȡů����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JJ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JTF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ͨ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JTF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JHLGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�̻��乤��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JHLGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[JT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'JT';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[BF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'BF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[QTBT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'QTBT';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[DFXJT].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ط��Խ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'DFXJT';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[YFX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'Ӧ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'YFX';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[QTKK].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�����ۿ�', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'QTKK';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[SYBX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ʧҵ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'SYBX';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[SDNQF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ˮ��ů����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'SDNQF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[SDS].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����˰', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'SDS';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[YLBX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���ϱ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'YLBX';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[YLIBX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ҽ�Ʊ���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'YLIBX';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[YSSHF].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'YSSHF';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[ZFGJJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ס��������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'ZFGJJ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[KFX].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�۷���', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'KFX';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[SFGZ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ʵ������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'SFGZ';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[GZKKSM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'˵��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'GZKKSM';


GO
PRINT N'Creating [dbo].[T_BM_GZXX].[TJSJ].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'���ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BM_GZXX', @level2type = N'COLUMN', @level2name = N'TJSJ';


GO
PRINT N'Creating [dbo].[Dictionary].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'Dictionary', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[DictionaryType].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'DictionaryType', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[FilterReport].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'FilterReport', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_BG_0602].[LanguageID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'LanguageID';


GO
PRINT N'Creating [dbo].[T_BG_0602].[LMH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ŀ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'LMH';


GO
PRINT N'Creating [dbo].[T_BG_0602].[LMLBYS].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ŀ�б���ʽ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'LMLBYS';


GO
PRINT N'Creating [dbo].[T_BG_0602].[LMM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ŀ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'LMM';


GO
PRINT N'Creating [dbo].[T_BG_0602].[LMNR].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��Ŀ��ʾ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'LMNR';


GO
PRINT N'Creating [dbo].[T_BG_0602].[LMTP].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ĿͼƬ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'LMTP';


GO
PRINT N'Creating [dbo].[T_BG_0602].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_BG_0602].[SFLBLM].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�б�������Ŀ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'SFLBLM';


GO
PRINT N'Creating [dbo].[T_BG_0602].[SFWBURL].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ⲿ��Ŀ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'SFWBURL';


GO
PRINT N'Creating [dbo].[T_BG_0602].[SJLMH].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ϼ���Ŀ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'SJLMH';


GO
PRINT N'Creating [dbo].[T_BG_0602].[WBURL].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�ⲿ��Ŀ����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_BG_0602', @level2type = N'COLUMN', @level2name = N'WBURL';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[IsPageMenu].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'IsPageMenu';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PageFileName].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PageFileName';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PageFileParameter].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PageFileParameter';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PageFilePath].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PageFilePath';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PurviewContent].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PurviewContent';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PurviewID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PurviewID';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PurviewName].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PurviewName';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PurviewRemark].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PurviewRemark';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[PurviewTypeID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'PurviewTypeID';


GO
PRINT N'Creating [dbo].[T_PM_PurviewInfo].[UpdateDate].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_PurviewInfo', @level2type = N'COLUMN', @level2name = N'UpdateDate';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[DefaultPage].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'ϵͳĬ��ҳ', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'DefaultPage';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[ObjectID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'ObjectID';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[UpdateDate].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����ʱ��', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'UpdateDate';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[UserGroupContent].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'UserGroupContent';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[UserGroupID].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û�����', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'UserGroupID';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[UserGroupName].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'�û�������', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'UserGroupName';


GO
PRINT N'Creating [dbo].[T_PM_UserGroupInfo].[UserGroupRemark].[MS_Description]...';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'��ע', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'T_PM_UserGroupInfo', @level2type = N'COLUMN', @level2name = N'UserGroupRemark';


GO
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

GO
