--���빫����ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BG0601'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BG0601','������Ϣ','������Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ', [PurviewTypeContent] =  '������Ϣ����'
    WHERE [PurviewTypeID] = 'BG0601'
END
--���빫����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060101'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060101','������Ϣ���','BG0601','������Ϣ���',0,'T_BG_0601WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060101'
END
--���빫����Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060102'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060102','������Ϣ�޸�','BG0601','������Ϣ�޸�',0,'T_BG_0601WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060102'
END
--���빫����Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060104'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060104','������Ϣ','BG0601','������Ϣ���',1,'T_BG_0601WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060104'
END
--���빫����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060105'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060105','������Ϣ����','BG0601','������Ϣ����',0,'T_BG_0601WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060105'
END
--���빫����Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060106'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060106','������Ϣͳ��','BG0601','������Ϣͳ��',0,'T_BG_0601WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣͳ��' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060106'
END
--���빫����Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060107'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060107','������Ϣɾ��','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060107'
END
--���빫����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060108'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060108','������Ϣ����','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060108'
END
--���빫����Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060109'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060109','������Ϣ�ĵ�����','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060109'
END
--���빫����Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060110'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060110','������Ϣ���ݼ�����','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060110'
END

--�����ҷ�������ϢȨ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('BG060151','�ҷ�������Ϣ','BG0601','�ҷ�������Ϣ',1,'T_BG_0601WebUISearch.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ' ,
    [PageFileName] = 'T_BG_0601WebUISearch.aspx?p=BG060151'
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151'
END
--�����ҷ�������Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060151_Add','�ҷ�������Ϣ���','BG0601','�ҷ�������Ϣ���',0,'T_BG_0601WebUIAdd.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ���' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Add'
END
--�����ҷ�������Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060151_Modify','�ҷ�������Ϣ�޸�','BG0601','�ҷ�������Ϣ�޸�',0,'T_BG_0601WebUIModify.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Modify'
END
--�����ҷ�������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060151_Detail','�ҷ�������Ϣ����','BG0601','�ҷ�������Ϣ����',0,'T_BG_0601WebUIDetail.aspx?p=BG060151','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣ����' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Detail'
END
--�����ҷ�������Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060151_Delete','�ҷ�������Ϣɾ��','BG0601','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ҷ�������Ϣɾ��' 
    WHERE [PurviewTypeID] = 'BG0601' AND [PurviewID] = 'BG060151_Delete'
END

