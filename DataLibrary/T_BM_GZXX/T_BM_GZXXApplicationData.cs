/****************************************************** 
FileName:T_BM_GZXXApplicationData.cs
******************************************************/
using System;
using System.Data;
using System.Data.Linq;
using System.Collections.Generic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.DB;

namespace RICH.Common.BM.T_BM_GZXX
{
    //=========================================================================
    //  ClassName : T_BM_GZXXApplicationData
    /// <summary>
    /// T_BM_GZXX������ʵ����
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_GZXXApplicationData : ApplicationDataBase
    {
        #region ����

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// ����XM
        /// </summary>
        /// <value>XM</value>
        public String XM { get; set; }
    
        /// <summary>
        /// �Ա�XB
        /// </summary>
        /// <value>XB</value>
        public String XB { get; set; }
    
        /// <summary>
        /// ���֤��SFZH
        /// </summary>
        /// <value>SFZH</value>
        public String SFZH { get; set; }
    
        /// <summary>
        /// ����FFGZNY
        /// </summary>
        /// <value>FFGZNY</value>
        public String FFGZNY { get; set; }
    
        /// <summary>
        /// ��������JCGZ
        /// </summary>
        /// <value>JCGZ</value>
        public Double? JCGZ { get; set; }
    
        /// <summary>
        /// �����ȼ�����JSDJGZ
        /// </summary>
        /// <value>JSDJGZ</value>
        public Double? JSDJGZ { get; set; }
    
        /// <summary>
        /// ְ����ZWGZ
        /// </summary>
        /// <value>ZWGZ</value>
        public Double? ZWGZ { get; set; }
    
        /// <summary>
        /// ������JBGZ
        /// </summary>
        /// <value>JBGZ</value>
        public Double? JBGZ { get; set; }
    
        /// <summary>
        /// ����������JKDQJT
        /// </summary>
        /// <value>JKDQJT</value>
        public Double? JKDQJT { get; set; }
    
        /// <summary>
        /// ����ظڽ���JKTSGWJT
        /// </summary>
        /// <value>JKTSGWJT</value>
        public Double? JKTSGWJT { get; set; }
    
        /// <summary>
        /// ���乤��GLGZ
        /// </summary>
        /// <value>GLGZ</value>
        public Double? GLGZ { get; set; }
    
        /// <summary>
        /// н������XJGZ
        /// </summary>
        /// <value>XJGZ</value>
        public Double? XJGZ { get; set; }
    
        /// <summary>
        /// 10%��߲���TGBF
        /// </summary>
        /// <value>TGBF</value>
        public Double? TGBF { get; set; }
    
        /// <summary>
        /// �绰��DHF
        /// </summary>
        /// <value>DHF</value>
        public Double? DHF { get; set; }
    
        /// <summary>
        /// ������Ů��DSZNF
        /// </summary>
        /// <value>DSZNF</value>
        public Double? DSZNF { get; set; }
    
        /// <summary>
        /// ��Ů������FNWSHLF
        /// </summary>
        /// <value>FNWSHLF</value>
        public Double? FNWSHLF { get; set; }
    
        /// <summary>
        /// �����HLF
        /// </summary>
        /// <value>HLF</value>
        public Double? HLF { get; set; }
    
        /// <summary>
        /// ����JJ
        /// </summary>
        /// <value>JJ</value>
        public Double? JJ { get; set; }
    
        /// <summary>
        /// ��ͨ��JTF
        /// </summary>
        /// <value>JTF</value>
        public Double? JTF { get; set; }
    
        /// <summary>
        /// �̻��乤��JHLGZ
        /// </summary>
        /// <value>JHLGZ</value>
        public Double? JHLGZ { get; set; }
    
        /// <summary>
        /// ����JT
        /// </summary>
        /// <value>JT</value>
        public Double? JT { get; set; }
    
        /// <summary>
        /// ����BF
        /// </summary>
        /// <value>BF</value>
        public Double? BF { get; set; }
    
        /// <summary>
        /// ��������QTBT
        /// </summary>
        /// <value>QTBT</value>
        public Double? QTBT { get; set; }
    
        /// <summary>
        /// �ط��Խ���DFXJT
        /// </summary>
        /// <value>DFXJT</value>
        public Double? DFXJT { get; set; }
    
        /// <summary>
        /// Ӧ����YFX
        /// </summary>
        /// <value>YFX</value>
        public Double? YFX { get; set; }
    
        /// <summary>
        /// Ӧ���ʼYFXBegin
        /// </summary>
        /// <value>YFXBegin</value>
        public Double? YFXBegin { get; set; }

        /// <summary>
        /// Ӧ�������YFXEnd
        /// </summary>
        /// <value>YFXEnd</value>
        public Double? YFXEnd { get; set; }
    
        /// <summary>
        /// �����ۿ�QTKK
        /// </summary>
        /// <value>QTKK</value>
        public Double? QTKK { get; set; }
    
        /// <summary>
        /// ʧҵ����SYBX
        /// </summary>
        /// <value>SYBX</value>
        public Double? SYBX { get; set; }
    
        /// <summary>
        /// ˮ��ů����SDNQF
        /// </summary>
        /// <value>SDNQF</value>
        public Double? SDNQF { get; set; }
    
        /// <summary>
        /// ����˰SDS
        /// </summary>
        /// <value>SDS</value>
        public Double? SDS { get; set; }
    
        /// <summary>
        /// ���ϱ���YLBX
        /// </summary>
        /// <value>YLBX</value>
        public Double? YLBX { get; set; }
    
        /// <summary>
        /// ҽ�Ʊ���YLIBX
        /// </summary>
        /// <value>YLIBX</value>
        public Double? YLIBX { get; set; }
    
        /// <summary>
        /// ���������YSSHF
        /// </summary>
        /// <value>YSSHF</value>
        public Double? YSSHF { get; set; }
    
        /// <summary>
        /// ס��������ZFGJJ
        /// </summary>
        /// <value>ZFGJJ</value>
        public Double? ZFGJJ { get; set; }
    
        /// <summary>
        /// �۷���KFX
        /// </summary>
        /// <value>KFX</value>
        public Double? KFX { get; set; }
    
        /// <summary>
        /// ʵ������SFGZ
        /// </summary>
        /// <value>SFGZ</value>
        public Double? SFGZ { get; set; }
    
        /// <summary>
        /// ʵ�����ʿ�ʼSFGZBegin
        /// </summary>
        /// <value>SFGZBegin</value>
        public Double? SFGZBegin { get; set; }

        /// <summary>
        /// ʵ�����ʽ���SFGZEnd
        /// </summary>
        /// <value>SFGZEnd</value>
        public Double? SFGZEnd { get; set; }
    
        /// <summary>
        /// ˵��GZKKSM
        /// </summary>
        /// <value>GZKKSM</value>
        public String GZKKSM { get; set; }
    
        /// <summary>
        /// ���ʱ��TJSJ
        /// </summary>
        /// <value>TJSJ</value>
        public DateTime? TJSJ { get; set; }
    
        /// <summary>
        /// ���ʱ�俪ʼTJSJBegin
        /// </summary>
        /// <value>TJSJBegin</value>
        public DateTime? TJSJBegin { get; set; }

        /// <summary>
        /// ���ʱ�����TJSJEnd
        /// </summary>
        /// <value>TJSJEnd</value>
        public DateTime? TJSJEnd { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// ����XMBatch
        /// </summary>
        /// <value>XM</value>
        public String XMBatch { get; set; }

        /// <summary>
        /// �Ա�XBBatch
        /// </summary>
        /// <value>XB</value>
        public String XBBatch { get; set; }

        /// <summary>
        /// ���֤��SFZHBatch
        /// </summary>
        /// <value>SFZH</value>
        public String SFZHBatch { get; set; }

        /// <summary>
        /// ����FFGZNYBatch
        /// </summary>
        /// <value>FFGZNY</value>
        public String FFGZNYBatch { get; set; }

        /// <summary>
        /// ��������JCGZBatch
        /// </summary>
        /// <value>JCGZ</value>
        public String JCGZBatch { get; set; }

        /// <summary>
        /// �����ȼ�����JSDJGZBatch
        /// </summary>
        /// <value>JSDJGZ</value>
        public String JSDJGZBatch { get; set; }

        /// <summary>
        /// ְ����ZWGZBatch
        /// </summary>
        /// <value>ZWGZ</value>
        public String ZWGZBatch { get; set; }

        /// <summary>
        /// ������JBGZBatch
        /// </summary>
        /// <value>JBGZ</value>
        public String JBGZBatch { get; set; }

        /// <summary>
        /// ����������JKDQJTBatch
        /// </summary>
        /// <value>JKDQJT</value>
        public String JKDQJTBatch { get; set; }

        /// <summary>
        /// ����ظڽ���JKTSGWJTBatch
        /// </summary>
        /// <value>JKTSGWJT</value>
        public String JKTSGWJTBatch { get; set; }

        /// <summary>
        /// ���乤��GLGZBatch
        /// </summary>
        /// <value>GLGZ</value>
        public String GLGZBatch { get; set; }

        /// <summary>
        /// н������XJGZBatch
        /// </summary>
        /// <value>XJGZ</value>
        public String XJGZBatch { get; set; }

        /// <summary>
        /// 10%��߲���TGBFBatch
        /// </summary>
        /// <value>TGBF</value>
        public String TGBFBatch { get; set; }

        /// <summary>
        /// �绰��DHFBatch
        /// </summary>
        /// <value>DHF</value>
        public String DHFBatch { get; set; }

        /// <summary>
        /// ������Ů��DSZNFBatch
        /// </summary>
        /// <value>DSZNF</value>
        public String DSZNFBatch { get; set; }

        /// <summary>
        /// ��Ů������FNWSHLFBatch
        /// </summary>
        /// <value>FNWSHLF</value>
        public String FNWSHLFBatch { get; set; }

        /// <summary>
        /// �����HLFBatch
        /// </summary>
        /// <value>HLF</value>
        public String HLFBatch { get; set; }

        /// <summary>
        /// ����JJBatch
        /// </summary>
        /// <value>JJ</value>
        public String JJBatch { get; set; }

        /// <summary>
        /// ��ͨ��JTFBatch
        /// </summary>
        /// <value>JTF</value>
        public String JTFBatch { get; set; }

        /// <summary>
        /// �̻��乤��JHLGZBatch
        /// </summary>
        /// <value>JHLGZ</value>
        public String JHLGZBatch { get; set; }

        /// <summary>
        /// ����JTBatch
        /// </summary>
        /// <value>JT</value>
        public String JTBatch { get; set; }

        /// <summary>
        /// ����BFBatch
        /// </summary>
        /// <value>BF</value>
        public String BFBatch { get; set; }

        /// <summary>
        /// ��������QTBTBatch
        /// </summary>
        /// <value>QTBT</value>
        public String QTBTBatch { get; set; }

        /// <summary>
        /// �ط��Խ���DFXJTBatch
        /// </summary>
        /// <value>DFXJT</value>
        public String DFXJTBatch { get; set; }

        /// <summary>
        /// Ӧ����YFXBatch
        /// </summary>
        /// <value>YFX</value>
        public String YFXBatch { get; set; }

        /// <summary>
        /// �����ۿ�QTKKBatch
        /// </summary>
        /// <value>QTKK</value>
        public String QTKKBatch { get; set; }

        /// <summary>
        /// ʧҵ����SYBXBatch
        /// </summary>
        /// <value>SYBX</value>
        public String SYBXBatch { get; set; }

        /// <summary>
        /// ˮ��ů����SDNQFBatch
        /// </summary>
        /// <value>SDNQF</value>
        public String SDNQFBatch { get; set; }

        /// <summary>
        /// ����˰SDSBatch
        /// </summary>
        /// <value>SDS</value>
        public String SDSBatch { get; set; }

        /// <summary>
        /// ���ϱ���YLBXBatch
        /// </summary>
        /// <value>YLBX</value>
        public String YLBXBatch { get; set; }

        /// <summary>
        /// ҽ�Ʊ���YLIBXBatch
        /// </summary>
        /// <value>YLIBX</value>
        public String YLIBXBatch { get; set; }

        /// <summary>
        /// ���������YSSHFBatch
        /// </summary>
        /// <value>YSSHF</value>
        public String YSSHFBatch { get; set; }

        /// <summary>
        /// ס��������ZFGJJBatch
        /// </summary>
        /// <value>ZFGJJ</value>
        public String ZFGJJBatch { get; set; }

        /// <summary>
        /// �۷���KFXBatch
        /// </summary>
        /// <value>KFX</value>
        public String KFXBatch { get; set; }

        /// <summary>
        /// ʵ������SFGZBatch
        /// </summary>
        /// <value>SFGZ</value>
        public String SFGZBatch { get; set; }

        /// <summary>
        /// ˵��GZKKSMBatch
        /// </summary>
        /// <value>GZKKSM</value>
        public String GZKKSMBatch { get; set; }

        /// <summary>
        /// ���ʱ��TJSJBatch
        /// </summary>
        /// <value>TJSJ</value>
        public String TJSJBatch { get; set; }

        /// <summary>
        /// ��������ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// ������������XMValue
        /// </summary>
        /// <value>XMValue</value>
        public String XMValue { get; set; }
    
        /// <summary>
        /// �Ա���������XBValue
        /// </summary>
        /// <value>XBValue</value>
        public String XBValue { get; set; }
    
        /// <summary>
        /// ���֤����������SFZHValue
        /// </summary>
        /// <value>SFZHValue</value>
        public String SFZHValue { get; set; }
    
        /// <summary>
        /// ������������FFGZNYValue
        /// </summary>
        /// <value>FFGZNYValue</value>
        public String FFGZNYValue { get; set; }
    
        /// <summary>
        /// ����������������JCGZValue
        /// </summary>
        /// <value>JCGZValue</value>
        public Double? JCGZValue { get; set; }
    
        /// <summary>
        /// �����ȼ�������������JSDJGZValue
        /// </summary>
        /// <value>JSDJGZValue</value>
        public Double? JSDJGZValue { get; set; }
    
        /// <summary>
        /// ְ������������ZWGZValue
        /// </summary>
        /// <value>ZWGZValue</value>
        public Double? ZWGZValue { get; set; }
    
        /// <summary>
        /// ��������������JBGZValue
        /// </summary>
        /// <value>JBGZValue</value>
        public Double? JBGZValue { get; set; }
    
        /// <summary>
        /// ������������������JKDQJTValue
        /// </summary>
        /// <value>JKDQJTValue</value>
        public Double? JKDQJTValue { get; set; }
    
        /// <summary>
        /// ����ظڽ�����������JKTSGWJTValue
        /// </summary>
        /// <value>JKTSGWJTValue</value>
        public Double? JKTSGWJTValue { get; set; }
    
        /// <summary>
        /// ���乤����������GLGZValue
        /// </summary>
        /// <value>GLGZValue</value>
        public Double? GLGZValue { get; set; }
    
        /// <summary>
        /// н��������������XJGZValue
        /// </summary>
        /// <value>XJGZValue</value>
        public Double? XJGZValue { get; set; }
    
        /// <summary>
        /// 10%��߲�����������TGBFValue
        /// </summary>
        /// <value>TGBFValue</value>
        public Double? TGBFValue { get; set; }
    
        /// <summary>
        /// �绰����������DHFValue
        /// </summary>
        /// <value>DHFValue</value>
        public Double? DHFValue { get; set; }
    
        /// <summary>
        /// ������Ů����������DSZNFValue
        /// </summary>
        /// <value>DSZNFValue</value>
        public Double? DSZNFValue { get; set; }
    
        /// <summary>
        /// ��Ů��������������FNWSHLFValue
        /// </summary>
        /// <value>FNWSHLFValue</value>
        public Double? FNWSHLFValue { get; set; }
    
        /// <summary>
        /// �������������HLFValue
        /// </summary>
        /// <value>HLFValue</value>
        public Double? HLFValue { get; set; }
    
        /// <summary>
        /// ������������JJValue
        /// </summary>
        /// <value>JJValue</value>
        public Double? JJValue { get; set; }
    
        /// <summary>
        /// ��ͨ����������JTFValue
        /// </summary>
        /// <value>JTFValue</value>
        public Double? JTFValue { get; set; }
    
        /// <summary>
        /// �̻��乤����������JHLGZValue
        /// </summary>
        /// <value>JHLGZValue</value>
        public Double? JHLGZValue { get; set; }
    
        /// <summary>
        /// ������������JTValue
        /// </summary>
        /// <value>JTValue</value>
        public Double? JTValue { get; set; }
    
        /// <summary>
        /// ������������BFValue
        /// </summary>
        /// <value>BFValue</value>
        public Double? BFValue { get; set; }
    
        /// <summary>
        /// ����������������QTBTValue
        /// </summary>
        /// <value>QTBTValue</value>
        public Double? QTBTValue { get; set; }
    
        /// <summary>
        /// �ط��Խ�����������DFXJTValue
        /// </summary>
        /// <value>DFXJTValue</value>
        public Double? DFXJTValue { get; set; }
    
        /// <summary>
        /// Ӧ������������YFXValue
        /// </summary>
        /// <value>YFXValue</value>
        public Double? YFXValue { get; set; }
    
        /// <summary>
        /// �����ۿ���������QTKKValue
        /// </summary>
        /// <value>QTKKValue</value>
        public Double? QTKKValue { get; set; }
    
        /// <summary>
        /// ʧҵ������������SYBXValue
        /// </summary>
        /// <value>SYBXValue</value>
        public Double? SYBXValue { get; set; }
    
        /// <summary>
        /// ˮ��ů������������SDNQFValue
        /// </summary>
        /// <value>SDNQFValue</value>
        public Double? SDNQFValue { get; set; }
    
        /// <summary>
        /// ����˰��������SDSValue
        /// </summary>
        /// <value>SDSValue</value>
        public Double? SDSValue { get; set; }
    
        /// <summary>
        /// ���ϱ�����������YLBXValue
        /// </summary>
        /// <value>YLBXValue</value>
        public Double? YLBXValue { get; set; }
    
        /// <summary>
        /// ҽ�Ʊ�����������YLIBXValue
        /// </summary>
        /// <value>YLIBXValue</value>
        public Double? YLIBXValue { get; set; }
    
        /// <summary>
        /// �����������������YSSHFValue
        /// </summary>
        /// <value>YSSHFValue</value>
        public Double? YSSHFValue { get; set; }
    
        /// <summary>
        /// ס����������������ZFGJJValue
        /// </summary>
        /// <value>ZFGJJValue</value>
        public Double? ZFGJJValue { get; set; }
    
        /// <summary>
        /// �۷�����������KFXValue
        /// </summary>
        /// <value>KFXValue</value>
        public Double? KFXValue { get; set; }
    
        /// <summary>
        /// ʵ��������������SFGZValue
        /// </summary>
        /// <value>SFGZValue</value>
        public Double? SFGZValue { get; set; }
    
        /// <summary>
        /// ˵����������GZKKSMValue
        /// </summary>
        /// <value>GZKKSMValue</value>
        public String GZKKSMValue { get; set; }
    
        /// <summary>
        /// ���ʱ����������TJSJValue
        /// </summary>
        /// <value>TJSJValue</value>
        public DateTime? TJSJValue { get; set; }
        
        #endregion
        #region һ��һ��ر�

        #endregion
        #region ��������
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// ��ѯ���ؽ����ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// ��ѯ��ʽQueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// ��ѯ�ֶ�QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// ��ѯ����ʽSort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// ��ѯ����ؼ���SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// ͳ�Ƽ�¼���ֶ�CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// ��ѯÿҳ��¼��PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// ��ѯ��ǰҳ��CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// ��ѯ��¼��RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼��ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// ��Ч��¼ƽ��ֵAvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// ��Ч��¼���SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// ���ֵMaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// ��СֵMinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// �������ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// ��Ϣ����MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// ���ݿ������ʽ����OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region ����ʵ����в���
        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] columnList 
                = new string[] {
                              "ObjectID"
                              ,"XM"
                              ,"XB"
                              ,"SFZH"
                              ,"FFGZNY"
                              ,"JCGZ"
                              ,"JSDJGZ"
                              ,"ZWGZ"
                              ,"JBGZ"
                              ,"JKDQJT"
                              ,"JKTSGWJT"
                              ,"GLGZ"
                              ,"XJGZ"
                              ,"TGBF"
                              ,"DHF"
                              ,"DSZNF"
                              ,"FNWSHLF"
                              ,"HLF"
                              ,"JJ"
                              ,"JTF"
                              ,"JHLGZ"
                              ,"JT"
                              ,"BF"
                              ,"QTBT"
                              ,"DFXJT"
                              ,"YFX"
                              ,"QTKK"
                              ,"SYBX"
                              ,"SDNQF"
                              ,"SDS"
                              ,"YLBX"
                              ,"YLIBX"
                              ,"YSSHF"
                              ,"ZFGJJ"
                              ,"KFX"
                              ,"SFGZ"
                              ,"GZKKSM"
                              ,"TJSJ"
                                };

        //=====================================================================
        //  FunctionName : GetColumnName
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// �����������б�
        /// </summary>
        private static SqlDbType[] columnTypeList 
                = new SqlDbType[] {
                              SqlDbType.UniqueIdentifier
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.NVarChar
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.Float
                              ,SqlDbType.NVarChar
                              ,SqlDbType.DateTime
                                  };

        //=====================================================================
        //  FunctionName : GetColumnType
        /// <summary>
        /// ȡ�������������б�
        /// </summary>
        /// <returns>�����������б�</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// �����б�
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "SFZH"
                              ,"FFGZNY"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// ȡ�������б�
        /// </summary>
        /// <returns>�����б�</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// ����ΪNull���������б�
        /// </summary>
        private static string[] nullableList
                = new string[] {
                              "ObjectID"
                              ,"XB"
                              ,"JCGZ"
                              ,"JSDJGZ"
                              ,"ZWGZ"
                              ,"JBGZ"
                              ,"JKDQJT"
                              ,"JKTSGWJT"
                              ,"GLGZ"
                              ,"XJGZ"
                              ,"TGBF"
                              ,"DHF"
                              ,"DSZNF"
                              ,"FNWSHLF"
                              ,"HLF"
                              ,"JJ"
                              ,"JTF"
                              ,"JHLGZ"
                              ,"JT"
                              ,"BF"
                              ,"QTBT"
                              ,"DFXJT"
                              ,"YFX"
                              ,"QTKK"
                              ,"SYBX"
                              ,"SDNQF"
                              ,"SDS"
                              ,"YLBX"
                              ,"YLIBX"
                              ,"YSSHF"
                              ,"ZFGJJ"
                              ,"KFX"
                              ,"SFGZ"
                              ,"GZKKSM"
                              ,"TJSJ"
                                };


        //=====================================================================
        //  FunctionName : GetNullableColumn
        /// <summary>
        /// ȡ������ΪNull���������б�
        /// </summary>
        /// <returns>����ΪNull���������б�</returns>
        //=====================================================================
        public override string[] GetNullableColumn()
        {
            return nullableList;
        }

        public static IEnumerable<T_BM_GZXXApplicationData> GetCollectionFromImportDataTable(DataTable dt)
        {
            List<T_BM_GZXXApplicationData> collection = new List<T_BM_GZXXApplicationData>();
            foreach (DataRow dr in dt.Rows)
            {
                T_BM_GZXXApplicationData applicationData = new T_BM_GZXXApplicationData()
                {
ObjectID = (dr.ReadGuidNullable("ObjectID") == null ? null : dr.ReadGuidNullable("ObjectID").ToString()),
    XM = dr.ReadString("XM"),
    XB = dr.ReadString("XB"),
    SFZH = dr.ReadString("SFZH"),
    FFGZNY = dr.ReadString("FFGZNY"),
    JCGZ = dr.ReadDoubleNullable("JCGZ"),
    JSDJGZ = dr.ReadDoubleNullable("JSDJGZ"),
    ZWGZ = dr.ReadDoubleNullable("ZWGZ"),
    JBGZ = dr.ReadDoubleNullable("JBGZ"),
    JKDQJT = dr.ReadDoubleNullable("JKDQJT"),
    JKTSGWJT = dr.ReadDoubleNullable("JKTSGWJT"),
    GLGZ = dr.ReadDoubleNullable("GLGZ"),
    XJGZ = dr.ReadDoubleNullable("XJGZ"),
    TGBF = dr.ReadDoubleNullable("TGBF"),
    DHF = dr.ReadDoubleNullable("DHF"),
    DSZNF = dr.ReadDoubleNullable("DSZNF"),
    FNWSHLF = dr.ReadDoubleNullable("FNWSHLF"),
    HLF = dr.ReadDoubleNullable("HLF"),
    JJ = dr.ReadDoubleNullable("JJ"),
    JTF = dr.ReadDoubleNullable("JTF"),
    JHLGZ = dr.ReadDoubleNullable("JHLGZ"),
    JT = dr.ReadDoubleNullable("JT"),
    BF = dr.ReadDoubleNullable("BF"),
    QTBT = dr.ReadDoubleNullable("QTBT"),
    DFXJT = dr.ReadDoubleNullable("DFXJT"),
    YFX = dr.ReadDoubleNullable("YFX"),
    QTKK = dr.ReadDoubleNullable("QTKK"),
    SYBX = dr.ReadDoubleNullable("SYBX"),
    SDNQF = dr.ReadDoubleNullable("SDNQF"),
    SDS = dr.ReadDoubleNullable("SDS"),
    YLBX = dr.ReadDoubleNullable("YLBX"),
    YLIBX = dr.ReadDoubleNullable("YLIBX"),
    YSSHF = dr.ReadDoubleNullable("YSSHF"),
    ZFGJJ = dr.ReadDoubleNullable("ZFGJJ"),
    KFX = dr.ReadDoubleNullable("KFX"),
    SFGZ = dr.ReadDoubleNullable("SFGZ"),
    GZKKSM = dr.ReadString("GZKKSM"),
    TJSJ = dr.ReadDateTimeNullable("TJSJ"),
    
                };
                collection.Add(applicationData);
            }
            return collection;
        }

		internal static T_BM_GZXXApplicationData FillDataFromDataReader(IDataReader reader, bool fromImportDataSet = false)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (reader.Read())
            {
                return new T_BM_GZXXApplicationData
                {
ObjectID = (reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID") == null ? null : reader.ReadGuidNullable(fromImportDataSet ? "ObjectID" : "ObjectID").ToString()),
    XM = reader.ReadString("XM"),
    XB = reader.ReadString("XB"),
    SFZH = reader.ReadString("SFZH"),
    FFGZNY = reader.ReadString("FFGZNY"),
    JCGZ = reader.ReadDoubleNullable(fromImportDataSet ? "JCGZ" : "JCGZ"),
    JSDJGZ = reader.ReadDoubleNullable(fromImportDataSet ? "JSDJGZ" : "JSDJGZ"),
    ZWGZ = reader.ReadDoubleNullable(fromImportDataSet ? "ZWGZ" : "ZWGZ"),
    JBGZ = reader.ReadDoubleNullable(fromImportDataSet ? "JBGZ" : "JBGZ"),
    JKDQJT = reader.ReadDoubleNullable(fromImportDataSet ? "JKDQJT" : "JKDQJT"),
    JKTSGWJT = reader.ReadDoubleNullable(fromImportDataSet ? "JKTSGWJT" : "JKTSGWJT"),
    GLGZ = reader.ReadDoubleNullable(fromImportDataSet ? "GLGZ" : "GLGZ"),
    XJGZ = reader.ReadDoubleNullable(fromImportDataSet ? "XJGZ" : "XJGZ"),
    TGBF = reader.ReadDoubleNullable(fromImportDataSet ? "TGBF" : "TGBF"),
    DHF = reader.ReadDoubleNullable(fromImportDataSet ? "DHF" : "DHF"),
    DSZNF = reader.ReadDoubleNullable(fromImportDataSet ? "DSZNF" : "DSZNF"),
    FNWSHLF = reader.ReadDoubleNullable(fromImportDataSet ? "FNWSHLF" : "FNWSHLF"),
    HLF = reader.ReadDoubleNullable(fromImportDataSet ? "HLF" : "HLF"),
    JJ = reader.ReadDoubleNullable(fromImportDataSet ? "JJ" : "JJ"),
    JTF = reader.ReadDoubleNullable(fromImportDataSet ? "JTF" : "JTF"),
    JHLGZ = reader.ReadDoubleNullable(fromImportDataSet ? "JHLGZ" : "JHLGZ"),
    JT = reader.ReadDoubleNullable(fromImportDataSet ? "JT" : "JT"),
    BF = reader.ReadDoubleNullable(fromImportDataSet ? "BF" : "BF"),
    QTBT = reader.ReadDoubleNullable(fromImportDataSet ? "QTBT" : "QTBT"),
    DFXJT = reader.ReadDoubleNullable(fromImportDataSet ? "DFXJT" : "DFXJT"),
    YFX = reader.ReadDoubleNullable(fromImportDataSet ? "YFX" : "YFX"),
    QTKK = reader.ReadDoubleNullable(fromImportDataSet ? "QTKK" : "QTKK"),
    SYBX = reader.ReadDoubleNullable(fromImportDataSet ? "SYBX" : "SYBX"),
    SDNQF = reader.ReadDoubleNullable(fromImportDataSet ? "SDNQF" : "SDNQF"),
    SDS = reader.ReadDoubleNullable(fromImportDataSet ? "SDS" : "SDS"),
    YLBX = reader.ReadDoubleNullable(fromImportDataSet ? "YLBX" : "YLBX"),
    YLIBX = reader.ReadDoubleNullable(fromImportDataSet ? "YLIBX" : "YLIBX"),
    YSSHF = reader.ReadDoubleNullable(fromImportDataSet ? "YSSHF" : "YSSHF"),
    ZFGJJ = reader.ReadDoubleNullable(fromImportDataSet ? "ZFGJJ" : "ZFGJJ"),
    KFX = reader.ReadDoubleNullable(fromImportDataSet ? "KFX" : "KFX"),
    SFGZ = reader.ReadDoubleNullable(fromImportDataSet ? "SFGZ" : "SFGZ"),
    GZKKSM = reader.ReadString("GZKKSM"),
    TJSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "TJSJ" : "TJSJ"),
    
                };
            }
            return null;
        }

        #endregion
        
        private DataTable GetImportColumn(DataTable dt)
        {

            dt.Columns.Add("XM", Type.GetType("System.String"));
            dt.Columns.Add("XB", Type.GetType("System.String"));
            dt.Columns.Add("SFZH", Type.GetType("System.String"));
            dt.Columns.Add("FFGZNY", Type.GetType("System.String"));
            dt.Columns.Add("JCGZ", Type.GetType("System.Double"));
            dt.Columns.Add("JSDJGZ", Type.GetType("System.Double"));
            dt.Columns.Add("ZWGZ", Type.GetType("System.Double"));
            dt.Columns.Add("JBGZ", Type.GetType("System.Double"));
            dt.Columns.Add("JKDQJT", Type.GetType("System.Double"));
            dt.Columns.Add("JKTSGWJT", Type.GetType("System.Double"));
            dt.Columns.Add("GLGZ", Type.GetType("System.Double"));
            dt.Columns.Add("XJGZ", Type.GetType("System.Double"));
            dt.Columns.Add("TGBF", Type.GetType("System.Double"));
            dt.Columns.Add("DHF", Type.GetType("System.Double"));
            dt.Columns.Add("DSZNF", Type.GetType("System.Double"));
            dt.Columns.Add("FNWSHLF", Type.GetType("System.Double"));
            dt.Columns.Add("HLF", Type.GetType("System.Double"));
            dt.Columns.Add("JJ", Type.GetType("System.Double"));
            dt.Columns.Add("JTF", Type.GetType("System.Double"));
            dt.Columns.Add("JHLGZ", Type.GetType("System.Double"));
            dt.Columns.Add("JT", Type.GetType("System.Double"));
            dt.Columns.Add("BF", Type.GetType("System.Double"));
            dt.Columns.Add("QTBT", Type.GetType("System.Double"));
            dt.Columns.Add("DFXJT", Type.GetType("System.Double"));
            dt.Columns.Add("YFX", Type.GetType("System.Double"));
            dt.Columns.Add("QTKK", Type.GetType("System.Double"));
            dt.Columns.Add("SYBX", Type.GetType("System.Double"));
            dt.Columns.Add("SDNQF", Type.GetType("System.Double"));
            dt.Columns.Add("SDS", Type.GetType("System.Double"));
            dt.Columns.Add("YLBX", Type.GetType("System.Double"));
            dt.Columns.Add("YLIBX", Type.GetType("System.Double"));
            dt.Columns.Add("YSSHF", Type.GetType("System.Double"));
            dt.Columns.Add("ZFGJJ", Type.GetType("System.Double"));
            dt.Columns.Add("KFX", Type.GetType("System.Double"));
            dt.Columns.Add("SFGZ", Type.GetType("System.Double"));
            dt.Columns.Add("GZKKSM", Type.GetType("System.String"));
            return dt;
        }

    }
}

  
