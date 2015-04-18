/****************************************************** 
FileName:T_BM_GZXXWebUI.cs
******************************************************/
using System;
using System.Data;

namespace RICH.Common.BM.T_BM_GZXX
{
    //=========================================================================
    //  ClassName : T_BM_GZXXContants
    /// <summary>
    /// T_BM_GZXX�ĳ�����
    /// </summary>
    //=========================================================================
    public class T_BM_GZXXContants
    {
  
        public static readonly string ObjectIDFieldName = "ObjectID";
        public static readonly string ObjectIDFieldRemark = "";
    
        public static readonly string XMFieldName = "XM";
        public static readonly string XMFieldRemark = "����";
    
        public static readonly string XBFieldName = "XB";
        public static readonly string XBFieldRemark = "�Ա�";
    
        public static readonly string SFZHFieldName = "SFZH";
        public static readonly string SFZHFieldRemark = "���֤��";
    
        public static readonly string FFGZNYFieldName = "FFGZNY";
        public static readonly string FFGZNYFieldRemark = "����";
    
        public static readonly string JCGZFieldName = "JCGZ";
        public static readonly string JCGZFieldRemark = "��������";
    
        public static readonly string JSDJGZFieldName = "JSDJGZ";
        public static readonly string JSDJGZFieldRemark = "�����ȼ�����";
    
        public static readonly string ZWGZFieldName = "ZWGZ";
        public static readonly string ZWGZFieldRemark = "ְ����";
    
        public static readonly string JBGZFieldName = "JBGZ";
        public static readonly string JBGZFieldRemark = "������";
    
        public static readonly string JKDQJTFieldName = "JKDQJT";
        public static readonly string JKDQJTFieldRemark = "����������";
    
        public static readonly string JKTSGWJTFieldName = "JKTSGWJT";
        public static readonly string JKTSGWJTFieldRemark = "����ظڽ���";
    
        public static readonly string GLGZFieldName = "GLGZ";
        public static readonly string GLGZFieldRemark = "���乤��";
    
        public static readonly string XJGZFieldName = "XJGZ";
        public static readonly string XJGZFieldRemark = "н������";
    
        public static readonly string TGBFFieldName = "TGBF";
        public static readonly string TGBFFieldRemark = "10%��߲���";
    
        public static readonly string DHFFieldName = "DHF";
        public static readonly string DHFFieldRemark = "�绰��";
    
        public static readonly string DSZNFFieldName = "DSZNF";
        public static readonly string DSZNFFieldRemark = "������Ů��";
    
        public static readonly string FNWSHLFFieldName = "FNWSHLF";
        public static readonly string FNWSHLFFieldRemark = "��Ů������";
    
        public static readonly string HLFFieldName = "HLF";
        public static readonly string HLFFieldRemark = "�����";
    
        public static readonly string JJFieldName = "JJ";
        public static readonly string JJFieldRemark = "ȡů����";
    
        public static readonly string JTFFieldName = "JTF";
        public static readonly string JTFFieldRemark = "��ͨ��";
    
        public static readonly string JHLGZFieldName = "JHLGZ";
        public static readonly string JHLGZFieldRemark = "�̻��乤��";
    
        public static readonly string JTFieldName = "JT";
        public static readonly string JTFieldRemark = "����";
    
        public static readonly string BFFieldName = "BF";
        public static readonly string BFFieldRemark = "����";
    
        public static readonly string QTBTFieldName = "QTBT";
        public static readonly string QTBTFieldRemark = "��������";
    
        public static readonly string DFXJTFieldName = "DFXJT";
        public static readonly string DFXJTFieldRemark = "�ط��Խ���";
    
        public static readonly string YFXFieldName = "YFX";
        public static readonly string YFXFieldRemark = "Ӧ����";
    
        public static readonly string QTKKFieldName = "QTKK";
        public static readonly string QTKKFieldRemark = "�����ۿ�";
    
        public static readonly string SYBXFieldName = "SYBX";
        public static readonly string SYBXFieldRemark = "ʧҵ����";
    
        public static readonly string SDNQFFieldName = "SDNQF";
        public static readonly string SDNQFFieldRemark = "ˮ��ů����";
    
        public static readonly string SDSFieldName = "SDS";
        public static readonly string SDSFieldRemark = "����˰";
    
        public static readonly string YLBXFieldName = "YLBX";
        public static readonly string YLBXFieldRemark = "���ϱ���";
    
        public static readonly string YLIBXFieldName = "YLIBX";
        public static readonly string YLIBXFieldRemark = "ҽ�Ʊ���";
    
        public static readonly string YSSHFFieldName = "YSSHF";
        public static readonly string YSSHFFieldRemark = "���������";
    
        public static readonly string ZFGJJFieldName = "ZFGJJ";
        public static readonly string ZFGJJFieldRemark = "ס��������";
    
        public static readonly string KFXFieldName = "KFX";
        public static readonly string KFXFieldRemark = "�۷���";
    
        public static readonly string SFGZFieldName = "SFGZ";
        public static readonly string SFGZFieldRemark = "ʵ������";
    
        public static readonly string GZKKSMFieldName = "GZKKSM";
        public static readonly string GZKKSMFieldRemark = "˵��";
    
        public static readonly string TJSJFieldName = "TJSJ";
        public static readonly string TJSJFieldRemark = "���ʱ��";
        
    
        public static readonly string AutoGenerateField = "";
        public static readonly int AutoGenerateNumberLength = 0;
        public static readonly string AutoGeneratePrefix = "";
        public static readonly bool AllowAutoGenerateID = false;
        public static readonly bool AutoGenerateDay = false;
        public static readonly bool AutoGenerateHour = false;
        public static readonly bool AutoGenerateMinute = false;
        public static readonly bool AutoGenerateMonth = false;
        public static readonly bool AutoGenerateMSecond = false;
        public static readonly bool AutoGenerateSecond = false;
        public static readonly bool AutoGenerateYear = false;
        public static readonly bool AutoGenerateOrder = false;
        public static readonly bool AutoGenerateIncludeDateTime = false;
        public static readonly bool Sort = false;
        
        public static readonly bool NoTableBorder = false;
        public static readonly bool ExistPDFPageHeader = false;
        public static readonly bool ExistPDFPageFooter = false;
        public static readonly bool ExistPDFTableTitle = false;
        public static readonly string PDFPageHeader = "";
        public static readonly string PDFPageFooter = "";
        public static readonly string PDFTableTitle = "";
        public static readonly bool IsPDFCustomTitle = false;
        public static readonly string PDFCustomTitleReadField = "";
        public static readonly string PDFCustomTitle = "";
        
        public static readonly bool ImportFromDoc = false;
        public static readonly bool ImportFromDataSet = true;
        public static readonly int ImportDataSetStartLineNum = 6;
        public static readonly bool ExportToDocumentTemplate = false;
        public static readonly bool ExportToPDF = false;
        public static readonly bool CopyItem = false;
        public static readonly bool WebDetailPage = true;
        public static readonly bool UseFilterReport = false;
        
        public static readonly string SortField = "FFGZNY";
        public static readonly string TitleField = "XM";
        
        public static readonly string GetValueTextField = "";
        public static readonly string GetValueValueField = "";
        public static readonly bool GetValue = false;
        public static readonly bool GetValueByKey = false;
    }
}
  
