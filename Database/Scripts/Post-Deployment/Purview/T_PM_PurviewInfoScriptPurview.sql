--����Ȩ����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'PI'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('PI','Ȩ����Ϣ','Ȩ����Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = 'Ȩ����Ϣ', [PurviewTypeContent] =  'Ȩ����Ϣ����'
    WHERE [PurviewTypeID] = 'PI'
END
--����Ȩ����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('PI01','Ȩ����Ϣ���','PI','Ȩ����Ϣ���',0,'T_PM_PurviewInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ���' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI01'
END
--����Ȩ����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI02','Ȩ����Ϣ�޸�','PI','Ȩ����Ϣ�޸�',0,'T_PM_PurviewInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI02'
END
--����Ȩ����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI04','Ȩ����Ϣ','PI','Ȩ����Ϣ���',1,'T_PM_PurviewInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI04'
END
--����Ȩ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI05','Ȩ����Ϣ����','PI','Ȩ����Ϣ����',0,'T_PM_PurviewInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI05'
END
--����Ȩ����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('PI06','Ȩ����Ϣͳ��','PI','Ȩ����Ϣͳ��',0,'T_PM_PurviewInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣͳ��' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI06'
END
--����Ȩ����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI07','Ȩ����Ϣɾ��','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣɾ��' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI07'
END
--����Ȩ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI08','Ȩ����Ϣ����','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI08'
END
--����Ȩ����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI09','Ȩ����Ϣ�ĵ�����','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI09'
END
--����Ȩ����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('PI10','Ȩ����Ϣ���ݼ�����','PI','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'Ȩ����Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'PI' AND [PurviewID] = 'PI10'
END

