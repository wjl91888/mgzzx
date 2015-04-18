USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'ShortMessage'))
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
			   ,'ShortMessage'
			   ,'DXX'
			   ,''
			   ,1
			   ,0
			   ,0
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 0
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXBT' AND [TableName] = 'ShortMessage'))
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
			   ,'DXXBT'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'标题'
			   ,1
			   ,1
			   ,0
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '标题'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DXXBT' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXLX' AND [TableName] = 'ShortMessage'))
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
			   ,'DXXLX'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'类型'
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '类型'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'DXXLX' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXNR' AND [TableName] = 'ShortMessage'))
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
			   ,'DXXNR'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'内容'
			   ,1
			   ,1
			   ,1
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '内容'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DXXNR' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DXXFJ' AND [TableName] = 'ShortMessage'))
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
			   ,'DXXFJ'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'附件'
			   ,1
			   ,1
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '附件'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DXXFJ' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSSJ' AND [TableName] = 'ShortMessage'))
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
			   ,'FSSJ'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'发送时间'
			   ,1
			   ,0
			   ,1
			   ,0
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '发送时间'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FSSJ' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSR' AND [TableName] = 'ShortMessage'))
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
			   ,'FSR'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'发送人'
			   ,1
			   ,0
			   ,1
			   ,0
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '发送人'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FSR' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSBM' AND [TableName] = 'ShortMessage'))
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
			   ,'FSBM'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'发送部门'
			   ,1
			   ,0
			   ,1
			   ,0
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '发送部门'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'FSBM' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'FSIP' AND [TableName] = 'ShortMessage'))
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
			   ,'FSIP'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'发送IP'
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '发送IP'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'FSIP' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'JSR' AND [TableName] = 'ShortMessage'))
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
			   ,'JSR'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'接收人'
			   ,1
			   ,1
			   ,0
			   ,1
			   ,0
			   ,0
			   ,1
			   ,1
			   )
END
ELSE
BEGIN
	UPDATE [DB_MGZZX].[dbo].[T_PM_FieldInfo]
	   SET 
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '接收人'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 0
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'JSR' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SFCK' AND [TableName] = 'ShortMessage'))
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
			   ,'SFCK'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'查看状态'
			   ,1
			   ,0
			   ,1
			   ,0
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '查看状态'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'SFCK' AND [TableName] = 'ShortMessage'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'CKSJ' AND [TableName] = 'ShortMessage'))
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
			   ,'CKSJ'
			   ,'ShortMessage'
			   ,'DXX'
			   ,'查看时间'
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
		  [PurviewTypeID] = 'DXX'
		  ,[FieldRemark] = '查看时间'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'CKSJ' AND [TableName] = 'ShortMessage'
END
GO

