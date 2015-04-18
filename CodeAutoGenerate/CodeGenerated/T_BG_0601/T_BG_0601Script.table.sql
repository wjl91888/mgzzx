CREATE TABLE [dbo].[T_BG_0601](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[FBH] [NVarChar] (10) NOT NULL
        
          ,[BT] [NVarChar] (100) NOT NULL
        
          ,[LanguageID] [NVarChar] (2) NULL
        
          ,[FBLM] [NVarChar] (8) NOT NULL
        
          ,[FBBM] [NVarChar] (50) NULL
        
          ,[FBZT] [NVarChar] (8) NULL
        
          ,[XXLX] [NVarChar] (2) NOT NULL
        
          ,[XXTPDZ] [NVarChar] (255) NULL
        
          ,[XXNR] [NText]  NOT NULL
        
          ,[FJXZDZ] [NVarChar] (4000) NULL
        
          ,[PZRJGH] [NVarChar] (10) NULL
        
          ,[XXZT] [NVarChar] (2) NULL
        
          ,[IsTop] [NVarChar] (1) NULL
        
          ,[TopSort] [Int]  NULL
        
          ,[IsBest] [NVarChar] (1) NULL
        
          ,[YXSJRQ] [DateTime]  NULL
        
          ,[FBRJGH] [NVarChar] (10) NULL
        
          ,[FBSJRQ] [DateTime]  NULL
        
          ,[FBIP] [NVarChar] (20) NULL
        
          ,[LLCS] [Int]  NULL
        
CONSTRAINT [PK_T_BG_0601] PRIMARY KEY CLUSTERED
(

  [FBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'BT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'LanguageID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������Ŀ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBLM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBBM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ר��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBZT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ϣ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'XXLX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ϢͼƬ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'XXTPDZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ϣ����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'XXNR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FJXZDZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��׼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'PZRJGH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Ϣ״̬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'XXZT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƿ��ö�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'IsTop'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ö����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'TopSort'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ƽ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'IsBest'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��Чʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'YXSJRQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBRJGH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBSJRQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'FBIP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�������' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BG_0601', @level2type=N'COLUMN',@level2name=N'LLCS'
GO

ALTER TABLE [dbo].[T_BG_0601] ADD  CONSTRAINT [DF_T_BG_0601_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
ALTER TABLE [dbo].[T_BG_0601] ADD  CONSTRAINT [DF_T_BG_0601_XXZT]  DEFAULT (02) FOR [XXZT]
GO
    
ALTER TABLE [dbo].[T_BG_0601] ADD  CONSTRAINT [DF_T_BG_0601_IsTop]  DEFAULT (0) FOR [IsTop]
GO
    
ALTER TABLE [dbo].[T_BG_0601] ADD  CONSTRAINT [DF_T_BG_0601_TopSort]  DEFAULT (0) FOR [TopSort]
GO
    
ALTER TABLE [dbo].[T_BG_0601] ADD  CONSTRAINT [DF_T_BG_0601_IsBest]  DEFAULT (0) FOR [IsBest]
GO
    
ALTER TABLE [dbo].[T_BG_0601] ADD  CONSTRAINT [DF_T_BG_0601_LLCS]  DEFAULT (0) FOR [LLCS]
GO
    
