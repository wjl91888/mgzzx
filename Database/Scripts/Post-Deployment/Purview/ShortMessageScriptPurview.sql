--������ϢȨ��������Ϣ
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewTypeInfo] WHERE [PurviewTypeID] = 'DXX'))
BEGIN
    INSERT INTO [T_PM_PurviewTypeInfo]([PurviewTypeID],[PurviewTypeName],[PurviewTypeContent],[PurviewTypeRemark],[PurviewPRI]) 
    VALUES('DXX','��Ϣ','��Ϣ����','',1)
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewTypeInfo] SET [PurviewTypeName] = '��Ϣ', [PurviewTypeContent] =  '��Ϣ����'
    WHERE [PurviewTypeID] = 'DXX'
END
--������Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX01'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX01','��Ϣ���','DXX','��Ϣ���',0,'ShortMessageWebUIAdd.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ���' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX01'
END
--������Ϣ�޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX02'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX02','��Ϣ�޸�','DXX','��Ϣ�޸�',0,'ShortMessageWebUIModify.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ�޸�' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX02'
END
--������Ϣ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX04'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX04','��Ϣ','DXX','��Ϣ���',1,'ShortMessageWebUISearch.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX04'
END
--������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX05'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX05','��Ϣ����','DXX','��Ϣ����',0,'ShortMessageWebUIDetail.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX05'
END
--������Ϣͳ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX06'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX06','��Ϣͳ��','DXX','��Ϣͳ��',0,'ShortMessageWebUIStatistic.aspx','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣͳ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX06'
END
--������Ϣɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX07'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX07','��Ϣɾ��','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣɾ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX07'
END
--������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX08'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX08','��Ϣ����','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX08'
END
--������Ϣ����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX09'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX09','��Ϣ�ĵ�����','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ�ĵ�����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX09'
END
--������Ϣ�������ݼ�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX10'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX10','��Ϣ���ݼ�����','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '��Ϣ���ݼ�����' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX10'
END

--���뷢����Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('DXX51','������','DXX','������',1,'ShortMessageWebUISearch.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������' ,
    [PageFileName] = 'ShortMessageWebUISearch.aspx?p=DXX51'
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51'
END
--���뷢�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX51_Add','���������','DXX','���������',0,'ShortMessageWebUIAdd.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '���������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Add'
END
--���뷢�����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX51_Modify','�������޸�','DXX','�������޸�',0,'ShortMessageWebUIModify.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�������޸�' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Modify'
END
--���뷢��������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX51_Detail','����������','DXX','����������',0,'ShortMessageWebUIDetail.aspx?p=DXX51','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '����������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Detail'
END
--���뷢����ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX51_Delete','������ɾ��','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '������ɾ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX51_Delete'
END

--�����ռ���Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath) 
    VALUES('DXX52','�ռ���','DXX','�ռ���',1,'ShortMessageWebUISearch.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ���' ,
    [PageFileName] = 'ShortMessageWebUISearch.aspx?p=DXX52'
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52'
END
--�����ռ������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Add'))
BEGIN
    INSERT INTO [T_PM_PurviewInfo]([PurviewID],[PurviewName],[PurviewTypeID],[PurviewContent],[IsPageMenu],[PageFileName],[PageFilePath])
    VALUES('DXX52_Add','�ռ������','DXX','�ռ������',0,'ShortMessageWebUIAdd.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Add'
END
--�����ռ����޸�Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Modify'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX52_Modify','�ռ����޸�','DXX','�ռ����޸�',0,'ShortMessageWebUIModify.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ����޸�' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Modify'
END
--�����ռ�������Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Detail'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PurviewContent,IsPageMenu,PageFileName,PageFilePath)
    VALUES('DXX52_Detail','�ռ�������','DXX','�ռ�������',0,'ShortMessageWebUIDetail.aspx?p=DXX52','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ�������' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Detail'
END
--�����ռ���ɾ��Ȩ��
IF (NOT EXISTS(SELECT 1 FROM [DB_MGZZX].[dbo].[T_PM_PurviewInfo] WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Delete'))
BEGIN
    INSERT INTO T_PM_PurviewInfo(PurviewID,PurviewName,PurviewTypeID,PageFilePath) 
    VALUES('DXX52_Delete','�ռ���ɾ��','DXX','/Administrator/A_BM')
END
ELSE
BEGIN
    UPDATE [T_PM_PurviewInfo] SET [PurviewName] = '�ռ���ɾ��' 
    WHERE [PurviewTypeID] = 'DXX' AND [PurviewID] = 'DXX52_Delete'
END

