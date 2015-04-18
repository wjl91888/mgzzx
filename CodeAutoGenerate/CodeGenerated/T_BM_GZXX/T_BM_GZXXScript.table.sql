CREATE TABLE [dbo].[T_BM_GZXX](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[XM] [NVarChar] (50) NOT NULL
        
          ,[XB] [NVarChar] (2) NULL
        
          ,[SFZH] [NVarChar] (18) NOT NULL
        
          ,[FFGZNY] [NVarChar] (6) NOT NULL
        
          ,[JCGZ] [Float]  NULL
        
          ,[JSDJGZ] [Float]  NULL
        
          ,[ZWGZ] [Float]  NULL
        
          ,[JBGZ] [Float]  NULL
        
          ,[JKDQJT] [Float]  NULL
        
          ,[JKTSGWJT] [Float]  NULL
        
          ,[GLGZ] [Float]  NULL
        
          ,[XJGZ] [Float]  NULL
        
          ,[TGBF] [Float]  NULL
        
          ,[DHF] [Float]  NULL
        
          ,[DSZNF] [Float]  NULL
        
          ,[FNWSHLF] [Float]  NULL
        
          ,[HLF] [Float]  NULL
        
          ,[JJ] [Float]  NULL
        
          ,[JTF] [Float]  NULL
        
          ,[JHLGZ] [Float]  NULL
        
          ,[JT] [Float]  NULL
        
          ,[BF] [Float]  NULL
        
          ,[QTBT] [Float]  NULL
        
          ,[DFXJT] [Float]  NULL
        
          ,[YFX] [Float]  NULL
        
          ,[QTKK] [Float]  NULL
        
          ,[SYBX] [Float]  NULL
        
          ,[SDNQF] [Float]  NULL
        
          ,[SDS] [Float]  NULL
        
          ,[YLBX] [Float]  NULL
        
          ,[YLIBX] [Float]  NULL
        
          ,[YSSHF] [Float]  NULL
        
          ,[ZFGJJ] [Float]  NULL
        
          ,[KFX] [Float]  NULL
        
          ,[SFGZ] [Float]  NULL
        
          ,[GZKKSM] [NVarChar] (1000) NULL
        
          ,[TJSJ] [DateTime]  NULL
        
CONSTRAINT [PK_T_BM_GZXX] PRIMARY KEY CLUSTERED
(

  [SFZH] ASC
  ,[FFGZNY] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'XM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'性别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'XB'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'身份证号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'SFZH'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'FFGZNY'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'基础工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JCGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'技术等级工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JSDJGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'职务工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'ZWGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'级别工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JBGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'艰苦地区津贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JKDQJT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'艰苦特岗津贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JKTSGWJT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'工龄工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'GLGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'薪级工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'XJGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'10%提高部分' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'TGBF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'DHF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'独生子女费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'DSZNF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'妇女卫生费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'FNWSHLF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'护理费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'HLF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'取暖补贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'交通费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JTF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'教护龄工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JHLGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'津贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'JT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'补发' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'BF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他补贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'QTBT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地方性津贴' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'DFXJT'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'应发项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'YFX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'其他扣款' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'QTKK'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'失业保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'SYBX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'水电暖气费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'SDNQF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'所得税' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'SDS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'养老保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'YLBX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'医疗保险' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'YLIBX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'遗属生活费' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'YSSHF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'住房公积金' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'ZFGJJ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扣发项' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'KFX'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实发工资' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'SFGZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'GZKKSM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'添加时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'T_BM_GZXX', @level2type=N'COLUMN',@level2name=N'TJSJ'
GO

ALTER TABLE [dbo].[T_BM_GZXX] ADD  CONSTRAINT [DF_T_BM_GZXX_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
