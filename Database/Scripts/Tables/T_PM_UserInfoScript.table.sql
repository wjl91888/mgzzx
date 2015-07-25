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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserLoginName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û���' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserGroupID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������λ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'SubjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserNickName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'Password'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�Ա�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'XB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'MZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'������ò' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'ZZMM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'���֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'SFZH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ֻ�' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'SJH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�칫�绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'BGDH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��ͥ�绰' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'JTDH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Email' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'Email'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'QQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'QQH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LoginTime'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼IP' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LastLoginIP'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�ϴ�ʱ��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LastLoginDate'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼����' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'LoginTimes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'�û�״̬' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'UserStatus'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��֤��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'vcode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'��¼��' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_PM_UserInfo', @level2type=N'COLUMN',@level2name=N'lcode'
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
    
