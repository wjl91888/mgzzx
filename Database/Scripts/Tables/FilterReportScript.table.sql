CREATE TABLE [dbo].[FilterReport](

          [ObjectID] [UniqueIdentifier]  NOT NULL
        
          ,[BGMC] [NVarChar] (50) NOT NULL
        
          ,[UserID] [NVarChar] (50) NOT NULL
        
          ,[BGLX] [NVarChar] (50) NOT NULL
        
          ,[GXBG] [NVarChar] (1) NOT NULL
        
          ,[XTBG] [NVarChar] (1) NOT NULL
        
          ,[BGCXTJ] [NVarChar] (4000) NOT NULL
        
          ,[BGCJSJ] [DateTime]  NOT NULL
        
CONSTRAINT [PK_FilterReport] PRIMARY KEY CLUSTERED
(

  [ObjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报表名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'BGMC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'BGLX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'共享报告' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'GXBG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统报告' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'XTBG'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'报告条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'BGCXTJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FilterReport', @level2type=N'COLUMN',@level2name=N'BGCJSJ'
GO

ALTER TABLE [dbo].[FilterReport] ADD  CONSTRAINT [DF_FilterReport_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
ALTER TABLE [dbo].[FilterReport] ADD  CONSTRAINT [DF_FilterReport_GXBG]  DEFAULT ((0)) FOR [GXBG]
GO
    
ALTER TABLE [dbo].[FilterReport] ADD  CONSTRAINT [DF_FilterReport_XTBG]  DEFAULT ((0)) FOR [XTBG]
GO
    
