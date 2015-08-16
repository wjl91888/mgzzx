CREATE TABLE [dbo].[ShortMessage](

          [ObjectID] [UniqueIdentifier]  NOT NULL
        
          ,[DXXBT] [NVarChar] (100) NOT NULL
        
          ,[DXXLX] [NVarChar] (2) NULL
        
          ,[DXXNR] [NVarChar] (4000) NULL
        
          ,[DXXFJ] [NVarChar] (255) NULL
        
          ,[FSSJ] [DateTime]  NULL
        
          ,[FSR] [NVarChar] (50) NULL
        
          ,[FSBM] [NVarChar] (50) NULL
        
          ,[FSIP] [NVarChar] (50) NULL
        
          ,[JSR] [NVarChar] (4000) NOT NULL
        
          ,[SFCK] [Bit]  NULL
        
          ,[CKSJ] [DateTime]  NULL
        
CONSTRAINT [PK_ShortMessage] PRIMARY KEY CLUSTERED
(

  [ObjectID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标题' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'DXXBT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'DXXLX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'DXXNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'附件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'DXXFJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'FSSJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'FSR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'FSBM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发送IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'FSIP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'接收人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'JSR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'SFCK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'查看时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ShortMessage', @level2type=N'COLUMN',@level2name=N'CKSJ'
GO

ALTER TABLE [dbo].[ShortMessage] ADD  CONSTRAINT [DF_ShortMessage_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
