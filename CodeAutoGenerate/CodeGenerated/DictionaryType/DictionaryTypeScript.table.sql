CREATE TABLE [dbo].[DictionaryType](

          [ObjectID] [UniqueIdentifier]  NULL
        
          ,[DM] [NVarChar] (10) NOT NULL
        
          ,[MC] [NVarChar] (50) NOT NULL
        
          ,[SM] [NVarChar] (255) NULL
        
CONSTRAINT [PK_DictionaryType] PRIMARY KEY CLUSTERED
(

  [DM] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryType', @level2type=N'COLUMN',@level2name=N'ObjectID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryType', @level2type=N'COLUMN',@level2name=N'DM'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryType', @level2type=N'COLUMN',@level2name=N'MC'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'说明' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'DictionaryType', @level2type=N'COLUMN',@level2name=N'SM'
GO

ALTER TABLE [dbo].[DictionaryType] ADD  CONSTRAINT [DF_DictionaryType_ObjectID]  DEFAULT (newid()) FOR [ObjectID]
GO
    
