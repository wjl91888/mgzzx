--���빤����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'GZ'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('GZ','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'GZ'
END
--���빤����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('GZ01','������Ϣ���','GZ','������Ϣ���',0,'T_BM_GZXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ01'
END
--���빤����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ02','������Ϣ�޸�','GZ','������Ϣ�޸�',0,'T_BM_GZXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ02'
END
--���빤����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ04','������Ϣ','GZ','������Ϣ���',1,'T_BM_GZXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ04'
END
--���빤����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ05','������Ϣ����','GZ','������Ϣ����',0,'T_BM_GZXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ05'
END
--���빤����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ06','������Ϣͳ��','GZ','������Ϣͳ��',0,'T_BM_GZXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ06'
END
--���빤����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ07','������Ϣɾ��','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ07'
END
--���빤����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ08','������Ϣ����','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ08'
END
--���빤����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ09','������Ϣ�ĵ�����','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ09'
END
--���빤����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ10','������Ϣ���ݼ�����','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ10'
END

--�����ҵĹ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('GZ51','�ҵĹ���','GZ','�ҵĹ���',1,'T_BM_GZXXWebUISearch.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ���' ,
    [PageFileName] = 'T_BM_GZXXWebUISearch.aspx?p=GZ51'
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51'
END
--�����ҵĹ������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('GZ51_Add','�ҵĹ������','GZ','�ҵĹ������',0,'T_BM_GZXXWebUIAdd.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ������' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Add'
END
--�����ҵĹ����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ51_Modify','�ҵĹ����޸�','GZ','�ҵĹ����޸�',0,'T_BM_GZXXWebUIModify.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ����޸�' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Modify'
END
--�����ҵĹ�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('GZ51_Detail','�ҵĹ�������','GZ','�ҵĹ�������',0,'T_BM_GZXXWebUIDetail.aspx?p=GZ51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ�������' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Detail'
END
--�����ҵĹ���ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('GZ51_Delete','�ҵĹ���ɾ��','GZ','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҵĹ���ɾ��' 
    WHERE [PurviewTypeID] = 'GZ' AND [PurviewID] = 'GZ51_Delete'
END

