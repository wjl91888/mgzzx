--�����û�����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'UG'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('UG','�û�����Ϣ','�û�����Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�û�����Ϣ', [PurviewTypeContent] =  '�û�����Ϣ����'
    WHERE [PurviewTypeID] = 'UG'
END
--�����û�����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('UG01','�û�����Ϣ���','UG','�û�����Ϣ���',0,'T_PM_UserGroupInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ���' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG01'
END
--�����û�����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG02','�û�����Ϣ�޸�','UG','�û�����Ϣ�޸�',0,'T_PM_UserGroupInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG02'
END
--�����û�����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG04','�û�����Ϣ','UG','�û�����Ϣ���',1,'T_PM_UserGroupInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG04'
END
--�����û�����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG05','�û�����Ϣ����','UG','�û�����Ϣ����',0,'T_PM_UserGroupInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG05'
END
--�����û�����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('UG06','�û�����Ϣͳ��','UG','�û�����Ϣͳ��',0,'T_PM_UserGroupInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣͳ��' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG06'
END
--�����û�����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG07','�û�����Ϣɾ��','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣɾ��' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG07'
END
--�����û�����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG08','�û�����Ϣ����','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG08'
END
--�����û�����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG09','�û�����Ϣ�ĵ�����','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG09'
END
--�����û�����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('UG10','�û�����Ϣ���ݼ�����','UG','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û�����Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'UG' AND [PurviewID] = 'UG10'
END

