CREATE TABLE [dbo].[T_PM_UserGroupInfo](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[UserGroupID] [NVarChar] (50) NOT NULL
        
          ,[UserGroupName] [NVarChar] (100) NOT NULL
        
          ,[UserGroupContent] [NVarChar] (255) NULL
        
          ,[UserGroupRemark] [NVarChar] (255) NULL
        
          ,[DefaultPage] [NVarChar] (255) NULL
        
          ,[UpdateDate] [DateTime]  NULL
        
CONSTRAINT [PK_T_PM_UserGroupInfo] PRIMARY KEY CLUSTERED
(

  [UserGroupID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户组编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户组名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'UserGroupName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'内容' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'UserGroupContent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'UserGroupRemark'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'系统默认页' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'DefaultPage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'更新时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserGroupInfo', @level2type=N'COLUMN',@level2name=N'UpdateDate'
GO

ALTER TABLE [dbo].[T_PM_UserGroupInfo] ADD  CONSTRAINT [DF_T_PM_UserGroupInfo_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
ALTER TABLE [dbo].[T_PM_UserGroupInfo] ADD  CONSTRAINT [DF_T_PM_UserGroupInfo_UserGroupID]  DEFAULT (newid()) FOR [UserGroupID]
GO
    
