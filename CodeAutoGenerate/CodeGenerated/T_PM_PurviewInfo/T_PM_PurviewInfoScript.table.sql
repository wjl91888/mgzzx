CREATE TABLE [dbo].[T_PM_PurviewInfo](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[PurviewID] [NVarChar] (50) NOT NULL
        
          ,[PurviewName] [NVarChar] (100) NOT NULL
        
          ,[PurviewTypeID] [NVarChar] (50) NOT NULL
        
          ,[PurviewContent] [NVarChar] (255) NULL
        
          ,[PurviewRemark] [NVarChar] (255) NULL
        
          ,[IsPageMenu] [Bit]  NULL
        
          ,[PageFileName] [NVarChar] (255) NULL
        
          ,[PageFileParameter] [NVarChar] (255) NULL
        
          ,[PageFilePath] [NVarChar] (255) NULL
        
          ,[UpdateDate] [DateTime]  NULL
        
CONSTRAINT [PK_T_PM_PurviewInfo] PRIMARY KEY CLUSTERED
(

  [PurviewID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PurviewID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PurviewName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PurviewTypeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PurviewContent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PurviewRemark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'IsPageMenu'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PageFileName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PageFileParameter'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'PageFilePath'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_PurviewInfo', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO

ALTER TABLE [dbo].[T_PM_PurviewInfo] ADD  CONSTRAINT [DF_T_PM_PurviewInfo_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
