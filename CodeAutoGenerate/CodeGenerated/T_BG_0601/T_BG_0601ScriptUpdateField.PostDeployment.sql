USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0601'))
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
			   ,'T_BG_0601'
			   ,'BG0601'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBH' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBH'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布号'
			   ,1
			   ,0
			   ,0
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布号'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'FBH' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'BT' AND [TableName] = 'T_BG_0601'))
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
			   ,'BT'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'标题'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '标题'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'BT' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0601'))
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
			   ,'T_BG_0601'
			   ,'BG0601'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '语言'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'LanguageID' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBLM' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBLM'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布栏目'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布栏目'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBLM' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBBM' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBBM'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布部门'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布部门'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBBM' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBZT' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBZT'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布专题'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布专题'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'FBZT' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXLX' AND [TableName] = 'T_BG_0601'))
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
			   ,'XXLX'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'信息类型'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '信息类型'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'XXLX' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXTPDZ' AND [TableName] = 'T_BG_0601'))
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
			   ,'XXTPDZ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'信息图片'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '信息图片'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XXTPDZ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXNR' AND [TableName] = 'T_BG_0601'))
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
			   ,'XXNR'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'信息内容'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '信息内容'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'XXNR' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FJXZDZ' AND [TableName] = 'T_BG_0601'))
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
			   ,'FJXZDZ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'附件'
			   ,1
			   ,1
			   ,1
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '附件'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FJXZDZ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'PZRJGH' AND [TableName] = 'T_BG_0601'))
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
			   ,'PZRJGH'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'批准人'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '批准人'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'PZRJGH' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'XXZT' AND [TableName] = 'T_BG_0601'))
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
			   ,'XXZT'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'信息状态'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '信息状态'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'XXZT' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'IsTop' AND [TableName] = 'T_BG_0601'))
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
			   ,'IsTop'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'是否置顶'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '是否置顶'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'IsTop' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'TopSort' AND [TableName] = 'T_BG_0601'))
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
			   ,'TopSort'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'置顶序号'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '置顶序号'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'TopSort' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'IsBest' AND [TableName] = 'T_BG_0601'))
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
			   ,'IsBest'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'推荐'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '推荐'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'IsBest' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'YXSJRQ' AND [TableName] = 'T_BG_0601'))
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
			   ,'YXSJRQ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'有效时间'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '有效时间'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'YXSJRQ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBRJGH' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBRJGH'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布人'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布人'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBRJGH' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBSJRQ' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBSJRQ'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布时间'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布时间'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBSJRQ' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FBIP' AND [TableName] = 'T_BG_0601'))
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
			   ,'FBIP'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'发布IP'
			   ,1
			   ,0
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '发布IP'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FBIP' AND [TableName] = 'T_BG_0601'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LLCS' AND [TableName] = 'T_BG_0601'))
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
			   ,'LLCS'
			   ,'T_BG_0601'
			   ,'BG0601'
			   ,'浏览次数'
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
		  [PurviewTypeID] = 'BG0601'
		  ,[FieldRemark] = '浏览次数'
		  ,[IsUse] = 0
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'LLCS' AND [TableName] = 'T_BG_0601'
END
GO

