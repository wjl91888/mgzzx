--���뱨����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'FR'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('FR','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'FR'
END
--���뱨����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('FR01','������Ϣ���','FR','������Ϣ���',0,'FilterReportWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR01'
END
--���뱨����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR02','������Ϣ�޸�','FR','������Ϣ�޸�',0,'FilterReportWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR02'
END
--���뱨����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR04','������Ϣ','FR','������Ϣ���',1,'FilterReportWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR04'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR05','������Ϣ����','FR','������Ϣ����',0,'FilterReportWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR05'
END
--���뱨����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('FR06','������Ϣͳ��','FR','������Ϣͳ��',0,'FilterReportWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR06'
END
--���뱨����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR07','������Ϣɾ��','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR07'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR08','������Ϣ����','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR08'
END
--���뱨����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR09','������Ϣ�ĵ�����','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR09'
END
--���뱨����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('FR10','������Ϣ���ݼ�����','FR','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'FR' AND [PurviewID] = 'FR10'
END

