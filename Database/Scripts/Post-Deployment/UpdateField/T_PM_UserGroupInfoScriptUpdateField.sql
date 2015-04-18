USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupID' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'UserGroupID'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'用户组编号'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '用户组编号'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupID' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupName' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'UserGroupName'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'用户组名称'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '用户组名称'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupName' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupContent' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'UserGroupContent'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'内容'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '内容'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupContent' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UserGroupRemark' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'UserGroupRemark'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'备注'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '备注'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UserGroupRemark' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DefaultPage' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'DefaultPage'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'系统默认页'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '系统默认页'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DefaultPage' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'UpdateDate' AND [TableName] = 'T_PM_UserGroupInfo'))
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
			   ,'UpdateDate'
			   ,'T_PM_UserGroupInfo'
			   ,'UG'
			   ,'更新时间'
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
		  [PurviewTypeID] = 'UG'
		  ,[FieldRemark] = '更新时间'
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 0
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'UpdateDate' AND [TableName] = 'T_PM_UserGroupInfo'
END
GO

