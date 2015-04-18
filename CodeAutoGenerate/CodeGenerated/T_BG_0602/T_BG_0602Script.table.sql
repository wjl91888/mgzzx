CREATE TABLE [dbo].[T_BG_0602](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[LMH] [NVarChar] (8) NOT NULL
        
          ,[LanguageID] [NVarChar] (2) NULL
        
          ,[LMM] [NVarChar] (50) NOT NULL
        
          ,[SJLMH] [NVarChar] (8) NULL
        
          ,[LMTP] [NVarChar] (255) NULL
        
          ,[LMNR] [NVarChar] (200) NOT NULL
        
          ,[LMLBYS] [NVarChar] (2) NOT NULL
        
          ,[SFLBLM] [NVarChar] (1) NOT NULL
        
          ,[SFWBURL] [NVarChar] (1) NOT NULL
        
          ,[WBURL] [NVarChar] (255) NULL
        
CONSTRAINT [PK_T_BG_0602] PRIMARY KEY CLUSTERED
(

  [LMH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'语言' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LanguageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级栏目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'SJLMH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMTP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目显示内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'栏目列表样式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMLBYS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列表内容栏目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'SFLBLM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部栏目' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'SFWBURL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'外部栏目连接' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'WBURL'
GO

ALTER TABLE [dbo].[T_BG_0602] ADD  CONSTRAINT [DF_T_BG_0602_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
