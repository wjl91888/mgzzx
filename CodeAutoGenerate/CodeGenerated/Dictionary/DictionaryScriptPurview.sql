--����DictionaryȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICT','Dictionary','Dictionary����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = 'Dictionary', [PurviewTypeContent] =  'Dictionary����'
    WHERE [PurviewTypeID] = 'DICT'
END
--����Dictionary���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICT01','Dictionary���','DICT','Dictionary���',0,'DictionaryWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary���' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'
END
--����Dictionary�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT02','Dictionary�޸�','DICT','Dictionary�޸�',0,'DictionaryWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary�޸�' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'
END
--����Dictionary���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT04','Dictionary','DICT','Dictionary���',1,'DictionaryWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'
END
--����Dictionary����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT05','Dictionary����','DICT','Dictionary����',0,'DictionaryWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'
END
--����Dictionaryͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT06','Dictionaryͳ��','DICT','Dictionaryͳ��',0,'DictionaryWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionaryͳ��' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'
END
--����Dictionaryɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT07','Dictionaryɾ��','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionaryɾ��' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'
END
--����Dictionary����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT08','Dictionary����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'
END
--����Dictionary����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT09','Dictionary�ĵ�����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary�ĵ�����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'
END
--����Dictionary�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT10','Dictionary���ݼ�����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Dictionary���ݼ�����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'
END

