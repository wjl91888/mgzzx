CREATE TABLE [dbo].[T_PM_UserInfo](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[UserID] [NVarChar] (50) NOT NULL
        
          ,[UserLoginName] [NVarChar] (50) NOT NULL
        
          ,[UserGroupID] [NVarChar] (500) NOT NULL
        
          ,[SubjectID] [NVarChar] (50) NOT NULL
        
          ,[UserNickName] [NVarChar] (50) NOT NULL
        
          ,[Password] [NVarChar] (50) NOT NULL
        
          ,[XB] [NVarChar] (2) NOT NULL
        
          ,[MZ] [NVarChar] (2) NOT NULL
        
          ,[ZZMM] [NVarChar] (2) NOT NULL
        
          ,[SFZH] [NVarChar] (18) NOT NULL
        
          ,[SJH] [NVarChar] (50) NOT NULL
        
          ,[BGDH] [NVarChar] (50) NULL
        
          ,[JTDH] [NVarChar] (50) NULL
        
          ,[Email] [NVarChar] (50) NULL
        
          ,[QQH] [NVarChar] (50) NULL
        
          ,[LoginTime] [DateTime]  NULL
        
          ,[LastLoginIP] [NVarChar] (50) NULL
        
          ,[LastLoginDate] [DateTime]  NULL
        
          ,[LoginTimes] [Int]  NULL
        
          ,[UserStatus] [NVarChar] (2) NOT NULL
        
          ,[vcode] [UniqueIdentifier]  NULL
        
          ,[lcode] [UniqueIdentifier]  NULL
        
CONSTRAINT [PK_T_PM_UserInfo] PRIMARY KEY CLUSTERED
(

  [UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserLoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所属单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'SubjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserNickName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'密码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'Password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'XB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'民族' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'MZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'政治面貌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'ZZMM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'SFZH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'SJH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'办公电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'BGDH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'家庭电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'JTDH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'QQH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上次时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录次数' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LoginTimes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'验证码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'vcode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'登录码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'lcode'
GO

ALTER TABLE [dbo].[T_PM_UserInfo] ADD  CONSTRAINT [DF_T_PM_UserInfo_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
ALTER TABLE [dbo].[T_PM_UserInfo] ADD  CONSTRAINT [DF_T_PM_UserInfo_LoginTimes]  DEFAULT ((0)) FOR [LoginTimes]
GO
    
ALTER TABLE [dbo].[T_PM_UserInfo] ADD  CONSTRAINT [DF_T_PM_UserInfo_UserStatus]  DEFAULT ('01') FOR [UserStatus]
GO
    
ALTER TABLE [dbo].[T_PM_UserInfo] ADD  CONSTRAINT [DF_T_PM_UserInfo_vcode]  DEFAULT (newid()) FOR [vcode]
GO
    
ALTER TABLE [dbo].[T_PM_UserInfo] ADD  CONSTRAINT [DF_T_PM_UserInfo_lcode]  DEFAULT (newid()) FOR [lcode]
GO
    
