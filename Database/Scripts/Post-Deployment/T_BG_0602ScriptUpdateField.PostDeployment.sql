USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'ObjectID'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,''
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMH' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMH'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'栏目号'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '栏目号'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMH' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LanguageID'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'语言'
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '语言'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMM' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMM'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'栏目名'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '栏目名'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMM' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJLMH' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SJLMH'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'上级栏目'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '上级栏目'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJLMH' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMTP' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMTP'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'栏目图片'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '栏目图片'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMTP' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMNR' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMNR'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'栏目显示内容'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '栏目显示内容'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMNR' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LMLBYS' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'LMLBYS'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'栏目列表样式'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '栏目列表样式'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LMLBYS' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFLBLM' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFLBLM'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'列表内容栏目'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '列表内容栏目'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFLBLM' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFWBURL' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'SFWBURL'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'外部栏目'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '外部栏目'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SFWBURL' AND [TableName] = 'T_BG_0602'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'WBURL' AND [TableName] = 'T_BG_0602'))
 BEGIN
	 INSERT INTO [DB_MGZZX].[dbo].[T_PM_FieldInfo]
			   ([ObjectID]
			   ,[FieldName]
			   ,[TableName]
			   ,[PurviewTypeID]
			   ,[FieldRemark]
			   ,[IsUse]
			   ,[IsAdd]
			   ,[Nullable]
			   ,[IsModify]
			   ,[Modifiable]
			   ,[IsList]
			   ,[IsSearch]
			   ,[IsDetail])
		 VALUES
			   (newid()
			   ,'WBURL'
			   ,'T_BG_0602'
			   ,'BG0602'
			   ,'外部栏目连接'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0602'
		  ,[FieldRemark] = '外部栏目连接'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'WBURL' AND [TableName] = 'T_BG_0602'
END
GO

