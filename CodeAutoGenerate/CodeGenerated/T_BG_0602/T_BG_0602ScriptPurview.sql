--���빫����Ϣ��ĿȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'BG0602'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('BG0602','������Ϣ��Ŀ','������Ϣ��Ŀ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '������Ϣ��Ŀ', [PurviewTypeContent] =  '������Ϣ��Ŀ����'
    WHERE [PurviewTypeID] = 'BG0602'
END
--���빫����Ϣ��Ŀ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060201'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('BG060201','������Ϣ��Ŀ���','BG0602','������Ϣ��Ŀ���',0,'T_BG_0602WebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ���' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060201'
END
--���빫����Ϣ��Ŀ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060202'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060202','������Ϣ��Ŀ�޸�','BG0602','������Ϣ��Ŀ�޸�',0,'T_BG_0602WebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ�޸�' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060202'
END
--���빫����Ϣ��Ŀ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060204'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060204','������Ϣ��Ŀ','BG0602','������Ϣ��Ŀ���',1,'T_BG_0602WebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060204'
END
--���빫����Ϣ��Ŀ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060205'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060205','������Ϣ��Ŀ����','BG0602','������Ϣ��Ŀ����',0,'T_BG_0602WebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060205'
END
--���빫����Ϣ��Ŀͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060206'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('BG060206','������Ϣ��Ŀͳ��','BG0602','������Ϣ��Ŀͳ��',0,'T_BG_0602WebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀͳ��' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060206'
END
--���빫����Ϣ��Ŀɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060207'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060207','������Ϣ��Ŀɾ��','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀɾ��' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060207'
END
--���빫����Ϣ��Ŀ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060208'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060208','������Ϣ��Ŀ����','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060208'
END
--���빫����Ϣ��Ŀ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060209'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060209','������Ϣ��Ŀ�ĵ�����','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ�ĵ�����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060209'
END
--���빫����Ϣ��Ŀ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060210'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('BG060210','������Ϣ��Ŀ���ݼ�����','BG0602','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������Ϣ��Ŀ���ݼ�����' 
    WHERE [PurviewTypeID] = 'BG0602' AND [PurviewID] = 'BG060210'
END

