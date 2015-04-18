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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ŀ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LanguageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ŀ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϼ���Ŀ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'SJLMH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ĿͼƬ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMTP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ŀ��ʾ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ŀ�б���ʽ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'LMLBYS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�б�������Ŀ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'SFLBLM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ⲿ��Ŀ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'SFWBURL'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ⲿ��Ŀ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0602', @level2type=N'COLUMN',@level2name=N'WBURL'
GO

ALTER TABLE [dbo].[T_BG_0602] ADD  CONSTRAINT [DF_T_BG_0602_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
