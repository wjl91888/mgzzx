--���뵥λ��ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DW'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DW','��λ��Ϣ','��λ��Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '��λ��Ϣ', [PurviewTypeContent] =  '��λ��Ϣ����'
    WHERE [PurviewTypeID] = 'DW'
END
--���뵥λ��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DW01','��λ��Ϣ���','DW','��λ��Ϣ���',0,'T_BM_DWXXWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ���' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW01'
END
--���뵥λ��Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW02','��λ��Ϣ�޸�','DW','��λ��Ϣ�޸�',0,'T_BM_DWXXWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW02'
END
--���뵥λ��Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW04','��λ��Ϣ','DW','��λ��Ϣ���',1,'T_BM_DWXXWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW04'
END
--���뵥λ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW05','��λ��Ϣ����','DW','��λ��Ϣ����',0,'T_BM_DWXXWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW05'
END
--���뵥λ��Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DW06','��λ��Ϣͳ��','DW','��λ��Ϣͳ��',0,'T_BM_DWXXWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣͳ��' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW06'
END
--���뵥λ��Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW07','��λ��Ϣɾ��','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣɾ��' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW07'
END
--���뵥λ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW08','��λ��Ϣ����','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW08'
END
--���뵥λ��Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW09','��λ��Ϣ�ĵ�����','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW09'
END
--���뵥λ��Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DW10','��λ��Ϣ���ݼ�����','DW','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��λ��Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'DW' AND [PurviewID] = 'DW10'
END

