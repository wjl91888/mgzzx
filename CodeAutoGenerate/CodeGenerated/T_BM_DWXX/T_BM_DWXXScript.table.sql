CREATE TABLE [dbo].[T_BM_DWXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[DWBH] [NVarChar] (10) NOT NULL
        
          ,[DWMC] [NVarChar] (255) NOT NULL
        
          ,[SJDWBH] [NVarChar] (255) NULL
        
          ,[DZ] [NVarChar] (255) NULL
        
          ,[YB] [NVarChar] (6) NULL
        
          ,[LXBM] [NVarChar] (50) NULL
        
          ,[LXDH] [NVarChar] (50) NULL
        
          ,[Email] [NVarChar] (255) NULL
        
          ,[LXR] [NVarChar] (50) NULL
        
          ,[SJ] [NVarChar] (50) NULL
        
CONSTRAINT [PK_T_BM_DWXX] PRIMARY KEY CLUSTERED
(

  [DWBH] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'DWBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'DWMC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'SJDWBH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'DZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'YB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系部门' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'LXBM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'LXDH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'LXR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_DWXX', @level2type=N'COLUMN',@level2name=N'SJ'
GO

ALTER TABLE [dbo].[T_BM_DWXX] ADD  CONSTRAINT [DF_T_BM_DWXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
