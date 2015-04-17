USE [DB_MGZZX]
--�����ֵ���ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICT','�ֵ���Ϣ','�ֵ���Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�ֵ���Ϣ', [PurviewTypeContent] =  '�ֵ���Ϣ����'
    WHERE [PurviewTypeID] = 'DICT'
END
--�����ֵ���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICT01','�ֵ���Ϣ���','DICT','�ֵ���Ϣ���',0,'DictionaryWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ���' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT01'
END
--�����ֵ���Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT02','�ֵ���Ϣ�޸�','DICT','�ֵ���Ϣ�޸�',0,'DictionaryWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT02'
END
--�����ֵ���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT04','�ֵ���Ϣ���','DICT','�ֵ���Ϣ���',1,'DictionaryWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ���' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT04'
END
--�����ֵ���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT05','�ֵ���Ϣ����','DICT','�ֵ���Ϣ����',0,'DictionaryWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT05'
END
--�����ֵ���Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICT06','�ֵ���Ϣͳ��','DICT','�ֵ���Ϣͳ��',0,'DictionaryWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣͳ��' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT06'
END
--�����ֵ���Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT07','�ֵ���Ϣɾ��','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣɾ��' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT07'
END
--�����ֵ���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT08','�ֵ���Ϣ����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT08'
END
--�����ֵ���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT09','�ֵ���Ϣ�ĵ�����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT09'
END
--�����ֵ���Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICT10','�ֵ���Ϣ���ݼ�����','DICT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'DICT' AND [PurviewID] = 'DICT10'
END

