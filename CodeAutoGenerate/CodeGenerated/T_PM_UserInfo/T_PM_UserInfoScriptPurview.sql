--�����û���ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'USER'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('USER','�û���Ϣ','�û���Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '�û���Ϣ', [PurviewTypeContent] =  '�û���Ϣ����'
    WHERE [PurviewTypeID] = 'USER'
END
--�����û���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('USER01','�û���Ϣ���','USER','�û���Ϣ���',0,'T_PM_UserInfoWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ���' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER01'
END
--�����û���Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER02','�û���Ϣ�޸�','USER','�û���Ϣ�޸�',0,'T_PM_UserInfoWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER02'
END
--�����û���Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER04','�û���Ϣ','USER','�û���Ϣ���',1,'T_PM_UserInfoWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER04'
END
--�����û���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER05','�û���Ϣ����','USER','�û���Ϣ����',0,'T_PM_UserInfoWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER05'
END
--�����û���Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER06','�û���Ϣͳ��','USER','�û���Ϣͳ��',0,'T_PM_UserInfoWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣͳ��' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER06'
END
--�����û���Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER07','�û���Ϣɾ��','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣɾ��' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER07'
END
--�����û���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER08','�û���Ϣ����','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER08'
END
--�����û���Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER09','�û���Ϣ�ĵ�����','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER09'
END
--�����û���Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER10','�û���Ϣ���ݼ�����','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�û���Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER10'
END

--����ͨѶ¼Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('USER51','ͨѶ¼','USER','ͨѶ¼',1,'T_PM_UserInfoWebUISearch.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼' ,
    [PageFileName] = 'T_PM_UserInfoWebUISearch.aspx?p=USER51'
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51'
END
--����ͨѶ¼���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('USER51_Add','ͨѶ¼���','USER','ͨѶ¼���',0,'T_PM_UserInfoWebUIAdd.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼���' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Add'
END
--����ͨѶ¼�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER51_Modify','ͨѶ¼�޸�','USER','ͨѶ¼�޸�',0,'T_PM_UserInfoWebUIModify.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼�޸�' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Modify'
END
--����ͨѶ¼����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('USER51_Detail','ͨѶ¼����','USER','ͨѶ¼����',0,'T_PM_UserInfoWebUIDetail.aspx?p=USER51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼����' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Detail'
END
--����ͨѶ¼ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('USER51_Delete','ͨѶ¼ɾ��','USER','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = 'ͨѶ¼ɾ��' 
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER51_Delete'
END

--�����������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER61_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('USER61_Modify','��������','USER','��������',1,'T_PM_UserInfoWebUIAdd.aspx?a=e' +CHAR(38)+ 'p=USER61','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��������' ,
    [PageFileName] = 'T_PM_UserInfoWebUIAdd.aspx?a=e' +CHAR(38)+ 'p=USER61'
    WHERE [PurviewTypeID] = 'USER' AND [PurviewID] = 'USER61_Modify'
END

