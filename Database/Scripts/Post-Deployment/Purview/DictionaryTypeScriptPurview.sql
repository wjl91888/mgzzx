--�����ֵ�����Ȩ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DICTT'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DICTT','�ֵ�����','�ֵ����͹���','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�ֵ�����', [PurviewTypeContent] =  '�ֵ����͹���'
    WHERE [PurviewTypeID] = 'DICTT'
END
--�����ֵ��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DICTT01','�ֵ��������','DICTT','�ֵ��������',0,'DictionaryTypeWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ��������' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT01'
END
--�����ֵ������޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT02','�ֵ������޸�','DICTT','�ֵ������޸�',0,'DictionaryTypeWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ������޸�' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT02'
END
--�����ֵ��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT04','�ֵ�����','DICTT','�ֵ��������',1,'DictionaryTypeWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ�����' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT04'
END
--�����ֵ���������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT05','�ֵ���������','DICTT','�ֵ���������',0,'DictionaryTypeWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ���������' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT05'
END
--�����ֵ�����ͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DICTT06','�ֵ�����ͳ��','DICTT','�ֵ�����ͳ��',0,'DictionaryTypeWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ�����ͳ��' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT06'
END
--�����ֵ�����ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT07','�ֵ�����ɾ��','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ�����ɾ��' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT07'
END
--�����ֵ����͵���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT08','�ֵ����͵���','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ����͵���' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT08'
END
--�����ֵ����͵���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT09','�ֵ������ĵ�����','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ������ĵ�����' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT09'
END
--�����ֵ����͵������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DICTT10','�ֵ��������ݼ�����','DICTT','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ֵ��������ݼ�����' 
    WHERE [PurviewTypeID] = 'DICTT' AND [PurviewID] = 'DICTT10'
END

