USE [DB_MGZZX]
  
 
 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'ObjectID' AND [TableName] = 'Dictionary'))
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
			   ,'Dictionary'
			   ,'DICT'
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
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = ''
		  ,[IsUse] = 1
		  ,[IsAdd] = 0
		  ,[Nullable] = 1
		  ,[IsModify] = 0
		  ,[Modifiable] = 1
		  ,[IsList] = 0
		  ,[IsSearch] = 0
		  ,[IsDetail] = 0
	 WHERE [FieldName] = 'ObjectID' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'DM' AND [TableName] = 'Dictionary'))
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
			   ,'DM'
			   ,'Dictionary'
			   ,'DICT'
			   ,'����'
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
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'DM' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'LX' AND [TableName] = 'Dictionary'))
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
			   ,'LX'
			   ,'Dictionary'
			   ,'DICT'
			   ,'����'
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
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 0
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'LX' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'MC' AND [TableName] = 'Dictionary'))
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
			   ,'MC'
			   ,'Dictionary'
			   ,'DICT'
			   ,'����'
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
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 0
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'MC' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SJDM' AND [TableName] = 'Dictionary'))
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
			   ,'SJDM'
			   ,'Dictionary'
			   ,'DICT'
			   ,'�ϼ�����'
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
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '�ϼ�����'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SJDM' AND [TableName] = 'Dictionary'
END
GO

 IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_FieldInfo] WHERE [FieldName] = 'SM' AND [TableName] = 'Dictionary'))
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
			   ,'SM'
			   ,'Dictionary'
			   ,'DICT'
			   ,'˵��'
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
		  [PurviewTypeID] = 'DICT'
		  ,[FieldRemark] = '˵��'
		  ,[IsUse] = 1
		  ,[IsAdd] = 1
		  ,[Nullable] = 1
		  ,[IsModify] = 1
		  ,[Modifiable] = 1
		  ,[IsList] = 1
		  ,[IsSearch] = 1
		  ,[IsDetail] = 1
	 WHERE [FieldName] = 'SM' AND [TableName] = 'Dictionary'
END
GO

