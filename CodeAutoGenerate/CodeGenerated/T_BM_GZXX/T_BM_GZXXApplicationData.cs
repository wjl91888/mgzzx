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
    /// T_BM_GZXX的数据实体类
    /// </summary>
    //=========================================================================
    [Serializable]
    public class T_BM_GZXXApplicationData : ApplicationDataBase
    {
        #region 主表

        /// <summary>
        /// ObjectID
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectID { get; set; }
    
        /// <summary>
        /// 姓名XM
        /// </summary>
        /// <value>XM</value>
        public String XM { get; set; }
    
        /// <summary>
        /// 性别XB
        /// </summary>
        /// <value>XB</value>
        public String XB { get; set; }
    
        /// <summary>
        /// 身份证号SFZH
        /// </summary>
        /// <value>SFZH</value>
        public String SFZH { get; set; }
    
        /// <summary>
        /// 日期FFGZNY
        /// </summary>
        /// <value>FFGZNY</value>
        public String FFGZNY { get; set; }
    
        /// <summary>
        /// 基础工资JCGZ
        /// </summary>
        /// <value>JCGZ</value>
        public Double? JCGZ { get; set; }
    
        /// <summary>
        /// 技术等级工资JSDJGZ
        /// </summary>
        /// <value>JSDJGZ</value>
        public Double? JSDJGZ { get; set; }
    
        /// <summary>
        /// 职务工资ZWGZ
        /// </summary>
        /// <value>ZWGZ</value>
        public Double? ZWGZ { get; set; }
    
        /// <summary>
        /// 级别工资JBGZ
        /// </summary>
        /// <value>JBGZ</value>
        public Double? JBGZ { get; set; }
    
        /// <summary>
        /// 艰苦地区津贴JKDQJT
        /// </summary>
        /// <value>JKDQJT</value>
        public Double? JKDQJT { get; set; }
    
        /// <summary>
        /// 艰苦特岗津贴JKTSGWJT
        /// </summary>
        /// <value>JKTSGWJT</value>
        public Double? JKTSGWJT { get; set; }
    
        /// <summary>
        /// 工龄工资GLGZ
        /// </summary>
        /// <value>GLGZ</value>
        public Double? GLGZ { get; set; }
    
        /// <summary>
        /// 薪级工资XJGZ
        /// </summary>
        /// <value>XJGZ</value>
        public Double? XJGZ { get; set; }
    
        /// <summary>
        /// 10%提高部分TGBF
        /// </summary>
        /// <value>TGBF</value>
        public Double? TGBF { get; set; }
    
        /// <summary>
        /// 电话费DHF
        /// </summary>
        /// <value>DHF</value>
        public Double? DHF { get; set; }
    
        /// <summary>
        /// 独生子女费DSZNF
        /// </summary>
        /// <value>DSZNF</value>
        public Double? DSZNF { get; set; }
    
        /// <summary>
        /// 妇女卫生费FNWSHLF
        /// </summary>
        /// <value>FNWSHLF</value>
        public Double? FNWSHLF { get; set; }
    
        /// <summary>
        /// 护理费HLF
        /// </summary>
        /// <value>HLF</value>
        public Double? HLF { get; set; }
    
        /// <summary>
        /// 取暖补贴JJ
        /// </summary>
        /// <value>JJ</value>
        public Double? JJ { get; set; }
    
        /// <summary>
        /// 交通费JTF
        /// </summary>
        /// <value>JTF</value>
        public Double? JTF { get; set; }
    
        /// <summary>
        /// 教护龄工资JHLGZ
        /// </summary>
        /// <value>JHLGZ</value>
        public Double? JHLGZ { get; set; }
    
        /// <summary>
        /// 津贴JT
        /// </summary>
        /// <value>JT</value>
        public Double? JT { get; set; }
    
        /// <summary>
        /// 补发BF
        /// </summary>
        /// <value>BF</value>
        public Double? BF { get; set; }
    
        /// <summary>
        /// 其他补贴QTBT
        /// </summary>
        /// <value>QTBT</value>
        public Double? QTBT { get; set; }
    
        /// <summary>
        /// 地方性津贴DFXJT
        /// </summary>
        /// <value>DFXJT</value>
        public Double? DFXJT { get; set; }
    
        /// <summary>
        /// 应发项YFX
        /// </summary>
        /// <value>YFX</value>
        public Double? YFX { get; set; }
    
        /// <summary>
        /// 应发项开始YFXBegin
        /// </summary>
        /// <value>YFXBegin</value>
        public Double? YFXBegin { get; set; }

        /// <summary>
        /// 应发项结束YFXEnd
        /// </summary>
        /// <value>YFXEnd</value>
        public Double? YFXEnd { get; set; }
    
        /// <summary>
        /// 其他扣款QTKK
        /// </summary>
        /// <value>QTKK</value>
        public Double? QTKK { get; set; }
    
        /// <summary>
        /// 失业保险SYBX
        /// </summary>
        /// <value>SYBX</value>
        public Double? SYBX { get; set; }
    
        /// <summary>
        /// 水电暖气费SDNQF
        /// </summary>
        /// <value>SDNQF</value>
        public Double? SDNQF { get; set; }
    
        /// <summary>
        /// 所得税SDS
        /// </summary>
        /// <value>SDS</value>
        public Double? SDS { get; set; }
    
        /// <summary>
        /// 养老保险YLBX
        /// </summary>
        /// <value>YLBX</value>
        public Double? YLBX { get; set; }
    
        /// <summary>
        /// 医疗保险YLIBX
        /// </summary>
        /// <value>YLIBX</value>
        public Double? YLIBX { get; set; }
    
        /// <summary>
        /// 遗属生活费YSSHF
        /// </summary>
        /// <value>YSSHF</value>
        public Double? YSSHF { get; set; }
    
        /// <summary>
        /// 住房公积金ZFGJJ
        /// </summary>
        /// <value>ZFGJJ</value>
        public Double? ZFGJJ { get; set; }
    
        /// <summary>
        /// 扣发项KFX
        /// </summary>
        /// <value>KFX</value>
        public Double? KFX { get; set; }
    
        /// <summary>
        /// 实发工资SFGZ
        /// </summary>
        /// <value>SFGZ</value>
        public Double? SFGZ { get; set; }
    
        /// <summary>
        /// 实发工资开始SFGZBegin
        /// </summary>
        /// <value>SFGZBegin</value>
        public Double? SFGZBegin { get; set; }

        /// <summary>
        /// 实发工资结束SFGZEnd
        /// </summary>
        /// <value>SFGZEnd</value>
        public Double? SFGZEnd { get; set; }
    
        /// <summary>
        /// 说明GZKKSM
        /// </summary>
        /// <value>GZKKSM</value>
        public String GZKKSM { get; set; }
    
        /// <summary>
        /// 添加时间TJSJ
        /// </summary>
        /// <value>TJSJ</value>
        public DateTime? TJSJ { get; set; }
    
        /// <summary>
        /// 添加时间开始TJSJBegin
        /// </summary>
        /// <value>TJSJBegin</value>
        public DateTime? TJSJBegin { get; set; }

        /// <summary>
        /// 添加时间结束TJSJEnd
        /// </summary>
        /// <value>TJSJEnd</value>
        public DateTime? TJSJEnd { get; set; }
    
        /// <summary>
        /// ObjectIDBatch
        /// </summary>
        /// <value>ObjectID</value>
        public String ObjectIDBatch { get; set; }

        /// <summary>
        /// 姓名XMBatch
        /// </summary>
        /// <value>XM</value>
        public String XMBatch { get; set; }

        /// <summary>
        /// 性别XBBatch
        /// </summary>
        /// <value>XB</value>
        public String XBBatch { get; set; }

        /// <summary>
        /// 身份证号SFZHBatch
        /// </summary>
        /// <value>SFZH</value>
        public String SFZHBatch { get; set; }

        /// <summary>
        /// 日期FFGZNYBatch
        /// </summary>
        /// <value>FFGZNY</value>
        public String FFGZNYBatch { get; set; }

        /// <summary>
        /// 基础工资JCGZBatch
        /// </summary>
        /// <value>JCGZ</value>
        public String JCGZBatch { get; set; }

        /// <summary>
        /// 技术等级工资JSDJGZBatch
        /// </summary>
        /// <value>JSDJGZ</value>
        public String JSDJGZBatch { get; set; }

        /// <summary>
        /// 职务工资ZWGZBatch
        /// </summary>
        /// <value>ZWGZ</value>
        public String ZWGZBatch { get; set; }

        /// <summary>
        /// 级别工资JBGZBatch
        /// </summary>
        /// <value>JBGZ</value>
        public String JBGZBatch { get; set; }

        /// <summary>
        /// 艰苦地区津贴JKDQJTBatch
        /// </summary>
        /// <value>JKDQJT</value>
        public String JKDQJTBatch { get; set; }

        /// <summary>
        /// 艰苦特岗津贴JKTSGWJTBatch
        /// </summary>
        /// <value>JKTSGWJT</value>
        public String JKTSGWJTBatch { get; set; }

        /// <summary>
        /// 工龄工资GLGZBatch
        /// </summary>
        /// <value>GLGZ</value>
        public String GLGZBatch { get; set; }

        /// <summary>
        /// 薪级工资XJGZBatch
        /// </summary>
        /// <value>XJGZ</value>
        public String XJGZBatch { get; set; }

        /// <summary>
        /// 10%提高部分TGBFBatch
        /// </summary>
        /// <value>TGBF</value>
        public String TGBFBatch { get; set; }

        /// <summary>
        /// 电话费DHFBatch
        /// </summary>
        /// <value>DHF</value>
        public String DHFBatch { get; set; }

        /// <summary>
        /// 独生子女费DSZNFBatch
        /// </summary>
        /// <value>DSZNF</value>
        public String DSZNFBatch { get; set; }

        /// <summary>
        /// 妇女卫生费FNWSHLFBatch
        /// </summary>
        /// <value>FNWSHLF</value>
        public String FNWSHLFBatch { get; set; }

        /// <summary>
        /// 护理费HLFBatch
        /// </summary>
        /// <value>HLF</value>
        public String HLFBatch { get; set; }

        /// <summary>
        /// 取暖补贴JJBatch
        /// </summary>
        /// <value>JJ</value>
        public String JJBatch { get; set; }

        /// <summary>
        /// 交通费JTFBatch
        /// </summary>
        /// <value>JTF</value>
        public String JTFBatch { get; set; }

        /// <summary>
        /// 教护龄工资JHLGZBatch
        /// </summary>
        /// <value>JHLGZ</value>
        public String JHLGZBatch { get; set; }

        /// <summary>
        /// 津贴JTBatch
        /// </summary>
        /// <value>JT</value>
        public String JTBatch { get; set; }

        /// <summary>
        /// 补发BFBatch
        /// </summary>
        /// <value>BF</value>
        public String BFBatch { get; set; }

        /// <summary>
        /// 其他补贴QTBTBatch
        /// </summary>
        /// <value>QTBT</value>
        public String QTBTBatch { get; set; }

        /// <summary>
        /// 地方性津贴DFXJTBatch
        /// </summary>
        /// <value>DFXJT</value>
        public String DFXJTBatch { get; set; }

        /// <summary>
        /// 应发项YFXBatch
        /// </summary>
        /// <value>YFX</value>
        public String YFXBatch { get; set; }

        /// <summary>
        /// 其他扣款QTKKBatch
        /// </summary>
        /// <value>QTKK</value>
        public String QTKKBatch { get; set; }

        /// <summary>
        /// 失业保险SYBXBatch
        /// </summary>
        /// <value>SYBX</value>
        public String SYBXBatch { get; set; }

        /// <summary>
        /// 水电暖气费SDNQFBatch
        /// </summary>
        /// <value>SDNQF</value>
        public String SDNQFBatch { get; set; }

        /// <summary>
        /// 所得税SDSBatch
        /// </summary>
        /// <value>SDS</value>
        public String SDSBatch { get; set; }

        /// <summary>
        /// 养老保险YLBXBatch
        /// </summary>
        /// <value>YLBX</value>
        public String YLBXBatch { get; set; }

        /// <summary>
        /// 医疗保险YLIBXBatch
        /// </summary>
        /// <value>YLIBX</value>
        public String YLIBXBatch { get; set; }

        /// <summary>
        /// 遗属生活费YSSHFBatch
        /// </summary>
        /// <value>YSSHF</value>
        public String YSSHFBatch { get; set; }

        /// <summary>
        /// 住房公积金ZFGJJBatch
        /// </summary>
        /// <value>ZFGJJ</value>
        public String ZFGJJBatch { get; set; }

        /// <summary>
        /// 扣发项KFXBatch
        /// </summary>
        /// <value>KFX</value>
        public String KFXBatch { get; set; }

        /// <summary>
        /// 实发工资SFGZBatch
        /// </summary>
        /// <value>SFGZ</value>
        public String SFGZBatch { get; set; }

        /// <summary>
        /// 说明GZKKSMBatch
        /// </summary>
        /// <value>GZKKSM</value>
        public String GZKKSMBatch { get; set; }

        /// <summary>
        /// 添加时间TJSJBatch
        /// </summary>
        /// <value>TJSJ</value>
        public String TJSJBatch { get; set; }
  
        /// <summary>
        /// 应发项聚合求和YFXSum
        /// </summary>
        /// <value>YFXSum</value>
        public Double YFXSum { get; set; }
      
        /// <summary>
        /// 实发工资聚合求和SFGZSum
        /// </summary>
        /// <value>SFGZSum</value>
        public Double SFGZSum { get; set; }
    
        /// <summary>
        /// 批量更新ObjectIDValue
        /// </summary>
        /// <value>ObjectIDValue</value>
        public String ObjectIDValue { get; set; }
    
        /// <summary>
        /// 姓名批量更新XMValue
        /// </summary>
        /// <value>XMValue</value>
        public String XMValue { get; set; }
    
        /// <summary>
        /// 性别批量更新XBValue
        /// </summary>
        /// <value>XBValue</value>
        public String XBValue { get; set; }
    
        /// <summary>
        /// 身份证号批量更新SFZHValue
        /// </summary>
        /// <value>SFZHValue</value>
        public String SFZHValue { get; set; }
    
        /// <summary>
        /// 日期批量更新FFGZNYValue
        /// </summary>
        /// <value>FFGZNYValue</value>
        public String FFGZNYValue { get; set; }
    
        /// <summary>
        /// 基础工资批量更新JCGZValue
        /// </summary>
        /// <value>JCGZValue</value>
        public Double? JCGZValue { get; set; }
    
        /// <summary>
        /// 技术等级工资批量更新JSDJGZValue
        /// </summary>
        /// <value>JSDJGZValue</value>
        public Double? JSDJGZValue { get; set; }
    
        /// <summary>
        /// 职务工资批量更新ZWGZValue
        /// </summary>
        /// <value>ZWGZValue</value>
        public Double? ZWGZValue { get; set; }
    
        /// <summary>
        /// 级别工资批量更新JBGZValue
        /// </summary>
        /// <value>JBGZValue</value>
        public Double? JBGZValue { get; set; }
    
        /// <summary>
        /// 艰苦地区津贴批量更新JKDQJTValue
        /// </summary>
        /// <value>JKDQJTValue</value>
        public Double? JKDQJTValue { get; set; }
    
        /// <summary>
        /// 艰苦特岗津贴批量更新JKTSGWJTValue
        /// </summary>
        /// <value>JKTSGWJTValue</value>
        public Double? JKTSGWJTValue { get; set; }
    
        /// <summary>
        /// 工龄工资批量更新GLGZValue
        /// </summary>
        /// <value>GLGZValue</value>
        public Double? GLGZValue { get; set; }
    
        /// <summary>
        /// 薪级工资批量更新XJGZValue
        /// </summary>
        /// <value>XJGZValue</value>
        public Double? XJGZValue { get; set; }
    
        /// <summary>
        /// 10%提高部分批量更新TGBFValue
        /// </summary>
        /// <value>TGBFValue</value>
        public Double? TGBFValue { get; set; }
    
        /// <summary>
        /// 电话费批量更新DHFValue
        /// </summary>
        /// <value>DHFValue</value>
        public Double? DHFValue { get; set; }
    
        /// <summary>
        /// 独生子女费批量更新DSZNFValue
        /// </summary>
        /// <value>DSZNFValue</value>
        public Double? DSZNFValue { get; set; }
    
        /// <summary>
        /// 妇女卫生费批量更新FNWSHLFValue
        /// </summary>
        /// <value>FNWSHLFValue</value>
        public Double? FNWSHLFValue { get; set; }
    
        /// <summary>
        /// 护理费批量更新HLFValue
        /// </summary>
        /// <value>HLFValue</value>
        public Double? HLFValue { get; set; }
    
        /// <summary>
        /// 取暖补贴批量更新JJValue
        /// </summary>
        /// <value>JJValue</value>
        public Double? JJValue { get; set; }
    
        /// <summary>
        /// 交通费批量更新JTFValue
        /// </summary>
        /// <value>JTFValue</value>
        public Double? JTFValue { get; set; }
    
        /// <summary>
        /// 教护龄工资批量更新JHLGZValue
        /// </summary>
        /// <value>JHLGZValue</value>
        public Double? JHLGZValue { get; set; }
    
        /// <summary>
        /// 津贴批量更新JTValue
        /// </summary>
        /// <value>JTValue</value>
        public Double? JTValue { get; set; }
    
        /// <summary>
        /// 补发批量更新BFValue
        /// </summary>
        /// <value>BFValue</value>
        public Double? BFValue { get; set; }
    
        /// <summary>
        /// 其他补贴批量更新QTBTValue
        /// </summary>
        /// <value>QTBTValue</value>
        public Double? QTBTValue { get; set; }
    
        /// <summary>
        /// 地方性津贴批量更新DFXJTValue
        /// </summary>
        /// <value>DFXJTValue</value>
        public Double? DFXJTValue { get; set; }
    
        /// <summary>
        /// 应发项批量更新YFXValue
        /// </summary>
        /// <value>YFXValue</value>
        public Double? YFXValue { get; set; }
    
        /// <summary>
        /// 其他扣款批量更新QTKKValue
        /// </summary>
        /// <value>QTKKValue</value>
        public Double? QTKKValue { get; set; }
    
        /// <summary>
        /// 失业保险批量更新SYBXValue
        /// </summary>
        /// <value>SYBXValue</value>
        public Double? SYBXValue { get; set; }
    
        /// <summary>
        /// 水电暖气费批量更新SDNQFValue
        /// </summary>
        /// <value>SDNQFValue</value>
        public Double? SDNQFValue { get; set; }
    
        /// <summary>
        /// 所得税批量更新SDSValue
        /// </summary>
        /// <value>SDSValue</value>
        public Double? SDSValue { get; set; }
    
        /// <summary>
        /// 养老保险批量更新YLBXValue
        /// </summary>
        /// <value>YLBXValue</value>
        public Double? YLBXValue { get; set; }
    
        /// <summary>
        /// 医疗保险批量更新YLIBXValue
        /// </summary>
        /// <value>YLIBXValue</value>
        public Double? YLIBXValue { get; set; }
    
        /// <summary>
        /// 遗属生活费批量更新YSSHFValue
        /// </summary>
        /// <value>YSSHFValue</value>
        public Double? YSSHFValue { get; set; }
    
        /// <summary>
        /// 住房公积金批量更新ZFGJJValue
        /// </summary>
        /// <value>ZFGJJValue</value>
        public Double? ZFGJJValue { get; set; }
    
        /// <summary>
        /// 扣发项批量更新KFXValue
        /// </summary>
        /// <value>KFXValue</value>
        public Double? KFXValue { get; set; }
    
        /// <summary>
        /// 实发工资批量更新SFGZValue
        /// </summary>
        /// <value>SFGZValue</value>
        public Double? SFGZValue { get; set; }
    
        /// <summary>
        /// 说明批量更新GZKKSMValue
        /// </summary>
        /// <value>GZKKSMValue</value>
        public String GZKKSMValue { get; set; }
    
        /// <summary>
        /// 添加时间批量更新TJSJValue
        /// </summary>
        /// <value>TJSJValue</value>
        public DateTime? TJSJValue { get; set; }
        
        #endregion
        #region 一对一相关表

        #endregion
        #region 功能属性
        /// <summary>
        /// ResultSet
        /// </summary>
        private DataSet m_ResultSet = new DataSet();

        /// <summary>
        /// 查询返回结果集ResultSet
        /// </summary>
        /// <value>ResultSet</value>
        public DataSet ResultSet
        {
            get { return m_ResultSet; }
            set { m_ResultSet = value; }
        }

        /// <summary>
        /// 查询方式QueryType
        /// </summary>
        /// <value>QueryType</value>
        public String QueryType { get; set; }

        /// <summary>
        /// 查询字段QueryField
        /// </summary>
        /// <value>QueryField</value>
        public String QueryField { get; set; }

        /// <summary>
        /// 查询关键字QueryKeywords
        /// </summary>
        /// <value>QueryKeywords</value>
        public String QueryKeywords { get; set; }

        /// <summary>
        /// 查询排序方式Sort
        /// </summary>
        /// <value>Sort</value>
        public Boolean Sort { get; set; }

        /// <summary>
        /// 查询排序关键字SortField
        /// </summary>
        /// <value>SortField</value>
        public String SortField { get; set; }

        /// <summary>
        /// 统计记录数字段CountField
        /// </summary>
        /// <value>CountField</value>
        public String CountField { get; set; }

        /// <summary>
        /// 查询每页记录数PageSize
        /// </summary>
        /// <value>PageSize</value>
        public Int32 PageSize { get; set; }

        /// <summary>
        /// 查询当前页码CurrentPage
        /// </summary>
        /// <value>CurrentPage</value>
        public Int32 CurrentPage { get; set; }

        /// <summary>
        /// 查询记录数RecordCount
        /// </summary>
        /// <value>RecordCount</value>
        public Int32 RecordCount { get; set; }

        /// <summary>
        /// 有效记录数ValidRecordCount
        /// </summary>
        /// <value>ValidRecordCount</value>
        public Int32 ValidRecordCount { get; set; }

        /// <summary>
        /// 有效记录平均值AvgValue
        /// </summary>
        /// <value>AvgValue</value>
        public Double AvgValue { get; set; }

        /// <summary>
        /// 有效记录求和SumValue
        /// </summary>
        /// <value>SumValue</value>
        public Double SumValue { get; set; }
		
        /// <summary>
        /// 最大值MaxValue
        /// </summary>
        /// <value>MaxValue</value>
        public object MaxValue { get; set; }

        /// <summary>
        /// 最小值MinValue
        /// </summary>
        /// <value>MinValue</value>
        public Int32 MinValue { get; set; }

        /// <summary>
        /// 结果代码ResultCode
        /// </summary>
        /// <value>ResultCode</value>
        public ResultState ResultCode { get; set; }

        /// <summary>
        /// 消息代码MessageCode
        /// </summary>
        /// <value>MessageCode</value>
        public string[] MessageCode { get; set; }
        
        /// <summary>
        /// 数据库操作方式代码OPCode
        /// </summary>
        /// <value>OPCode</value>
        public OPType OPCode { get; set; }
        #endregion

        #region 数据实体的列操作
        /// <summary>
        /// 列名列表
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
        /// 取得列名列表
        /// </summary>
        /// <returns>列名列表</returns>
        //=====================================================================
        public override string[] GetColumnName()
        {
            return columnList;
        }

        /// <summary>
        /// 列数据类型列表
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
        /// 取得列数据类型列表
        /// </summary>
        /// <returns>列数据类型列表</returns>
        //=====================================================================
        public override SqlDbType[] GetColumnType()
        {
            return columnTypeList;
        }

        /// <summary>
        /// 主键列表
        /// </summary>
        private static string[] primaryKeyList 
                = new string[] {
                              "SFZH"
                              ,"FFGZNY"
                                };

        //=====================================================================
        //  FunctionName : GetPrimaryKey
        /// <summary>
        /// 取得主键列表
        /// </summary>
        /// <returns>主键列表</returns>
        //=====================================================================
        public override string[] GetPrimaryKey()
        {
            return primaryKeyList;
        }

        /// <summary>
        /// 允许为Null的列名称列表
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
        /// 取得允许为Null的列名称列表
        /// </summary>
        /// <returns>允许为Null的列名称列表</returns>
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
    XM = dr.ReadString("姓名"),
    XB = dr.ReadString("XB"),
    SFZH = dr.ReadString("身份证号码"),
    FFGZNY = dr.ReadString("FFGZNY"),
    JCGZ = dr.ReadDoubleNullable("JCGZ"),
    JSDJGZ = dr.ReadDoubleNullable("JSDJGZ"),
    ZWGZ = dr.ReadDoubleNullable("职务(岗位)工资"),
    JBGZ = dr.ReadDoubleNullable("级别（薪级、技术等级）工资"),
    JKDQJT = dr.ReadDoubleNullable("艰苦边远地区津贴"),
    JKTSGWJT = dr.ReadDoubleNullable("JKTSGWJT"),
    GLGZ = dr.ReadDoubleNullable("GLGZ"),
    XJGZ = dr.ReadDoubleNullable("XJGZ"),
    TGBF = dr.ReadDoubleNullable("警衔工资（教师护士10%）"),
    DHF = dr.ReadDoubleNullable("公务移动通讯费"),
    DSZNF = dr.ReadDoubleNullable("独生子女费"),
    FNWSHLF = dr.ReadDoubleNullable("妇女卫生费"),
    HLF = dr.ReadDoubleNullable("HLF"),
    JJ = dr.ReadDoubleNullable("职工住宅取暖补贴"),
    JTF = dr.ReadDoubleNullable("上下班交通补助"),
    JHLGZ = dr.ReadDoubleNullable("特殊岗位津贴（教护龄工资）"),
    JT = dr.ReadDoubleNullable("JT"),
    BF = dr.ReadDoubleNullable("补发"),
    QTBT = dr.ReadDoubleNullable("QTBT"),
    DFXJT = dr.ReadDoubleNullable("地方津贴补贴（基础绩效工资）"),
    YFX = dr.ReadDoubleNullable("应发工资"),
    QTKK = dr.ReadDoubleNullable("QTKK"),
    SYBX = dr.ReadDoubleNullable("SYBX"),
    SDNQF = dr.ReadDoubleNullable("SDNQF"),
    SDS = dr.ReadDoubleNullable("SDS"),
    YLBX = dr.ReadDoubleNullable("YLBX"),
    YLIBX = dr.ReadDoubleNullable("YLIBX"),
    YSSHF = dr.ReadDoubleNullable("YSSHF"),
    ZFGJJ = dr.ReadDoubleNullable("ZFGJJ"),
    KFX = dr.ReadDoubleNullable("扣发部分"),
    SFGZ = dr.ReadDoubleNullable("实发工资"),
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
    ZWGZ = reader.ReadDoubleNullable(fromImportDataSet ? "职务(岗位)工资" : "ZWGZ"),
    JBGZ = reader.ReadDoubleNullable(fromImportDataSet ? "级别（薪级、技术等级）工资" : "JBGZ"),
    JKDQJT = reader.ReadDoubleNullable(fromImportDataSet ? "艰苦边远地区津贴" : "JKDQJT"),
    JKTSGWJT = reader.ReadDoubleNullable(fromImportDataSet ? "JKTSGWJT" : "JKTSGWJT"),
    GLGZ = reader.ReadDoubleNullable(fromImportDataSet ? "GLGZ" : "GLGZ"),
    XJGZ = reader.ReadDoubleNullable(fromImportDataSet ? "XJGZ" : "XJGZ"),
    TGBF = reader.ReadDoubleNullable(fromImportDataSet ? "警衔工资（教师护士10%）" : "TGBF"),
    DHF = reader.ReadDoubleNullable(fromImportDataSet ? "公务移动通讯费" : "DHF"),
    DSZNF = reader.ReadDoubleNullable(fromImportDataSet ? "独生子女费" : "DSZNF"),
    FNWSHLF = reader.ReadDoubleNullable(fromImportDataSet ? "妇女卫生费" : "FNWSHLF"),
    HLF = reader.ReadDoubleNullable(fromImportDataSet ? "HLF" : "HLF"),
    JJ = reader.ReadDoubleNullable(fromImportDataSet ? "职工住宅取暖补贴" : "JJ"),
    JTF = reader.ReadDoubleNullable(fromImportDataSet ? "上下班交通补助" : "JTF"),
    JHLGZ = reader.ReadDoubleNullable(fromImportDataSet ? "特殊岗位津贴（教护龄工资）" : "JHLGZ"),
    JT = reader.ReadDoubleNullable(fromImportDataSet ? "JT" : "JT"),
    BF = reader.ReadDoubleNullable(fromImportDataSet ? "补发" : "BF"),
    QTBT = reader.ReadDoubleNullable(fromImportDataSet ? "QTBT" : "QTBT"),
    DFXJT = reader.ReadDoubleNullable(fromImportDataSet ? "地方津贴补贴（基础绩效工资）" : "DFXJT"),
    YFX = reader.ReadDoubleNullable(fromImportDataSet ? "应发工资" : "YFX"),
    QTKK = reader.ReadDoubleNullable(fromImportDataSet ? "QTKK" : "QTKK"),
    SYBX = reader.ReadDoubleNullable(fromImportDataSet ? "SYBX" : "SYBX"),
    SDNQF = reader.ReadDoubleNullable(fromImportDataSet ? "SDNQF" : "SDNQF"),
    SDS = reader.ReadDoubleNullable(fromImportDataSet ? "SDS" : "SDS"),
    YLBX = reader.ReadDoubleNullable(fromImportDataSet ? "YLBX" : "YLBX"),
    YLIBX = reader.ReadDoubleNullable(fromImportDataSet ? "YLIBX" : "YLIBX"),
    YSSHF = reader.ReadDoubleNullable(fromImportDataSet ? "YSSHF" : "YSSHF"),
    ZFGJJ = reader.ReadDoubleNullable(fromImportDataSet ? "ZFGJJ" : "ZFGJJ"),
    KFX = reader.ReadDoubleNullable(fromImportDataSet ? "扣发部分" : "KFX"),
    SFGZ = reader.ReadDoubleNullable(fromImportDataSet ? "实发工资" : "SFGZ"),
    GZKKSM = reader.ReadString("GZKKSM"),
    TJSJ = reader.ReadDateTimeNullable(fromImportDataSet ? "TJSJ" : "TJSJ"),
    
                };
            }
            return null;
        }

        #endregion
        
        private DataTable GetImportColumn(DataTable dt)
        {

            dt.Columns.Add("姓名", Type.GetType("System.String"));
            dt.Columns.Add("XB", Type.GetType("System.String"));
            dt.Columns.Add("身份证号码", Type.GetType("System.String"));
            dt.Columns.Add("JCGZ", Type.GetType("System.Double"));
            dt.Columns.Add("JSDJGZ", Type.GetType("System.Double"));
            dt.Columns.Add("职务(岗位)工资", Type.GetType("System.Double"));
            dt.Columns.Add("级别（薪级、技术等级）工资", Type.GetType("System.Double"));
            dt.Columns.Add("艰苦边远地区津贴", Type.GetType("System.Double"));
            dt.Columns.Add("JKTSGWJT", Type.GetType("System.Double"));
            dt.Columns.Add("GLGZ", Type.GetType("System.Double"));
            dt.Columns.Add("XJGZ", Type.GetType("System.Double"));
            dt.Columns.Add("警衔工资（教师护士10%）", Type.GetType("System.Double"));
            dt.Columns.Add("公务移动通讯费", Type.GetType("System.Double"));
            dt.Columns.Add("独生子女费", Type.GetType("System.Double"));
            dt.Columns.Add("妇女卫生费", Type.GetType("System.Double"));
            dt.Columns.Add("HLF", Type.GetType("System.Double"));
            dt.Columns.Add("职工住宅取暖补贴", Type.GetType("System.Double"));
            dt.Columns.Add("上下班交通补助", Type.GetType("System.Double"));
            dt.Columns.Add("特殊岗位津贴（教护龄工资）", Type.GetType("System.Double"));
            dt.Columns.Add("JT", Type.GetType("System.Double"));
            dt.Columns.Add("补发", Type.GetType("System.Double"));
            dt.Columns.Add("QTBT", Type.GetType("System.Double"));
            dt.Columns.Add("地方津贴补贴（基础绩效工资）", Type.GetType("System.Double"));
            dt.Columns.Add("应发工资", Type.GetType("System.Double"));
            dt.Columns.Add("QTKK", Type.GetType("System.Double"));
            dt.Columns.Add("SYBX", Type.GetType("System.Double"));
            dt.Columns.Add("SDNQF", Type.GetType("System.Double"));
            dt.Columns.Add("SDS", Type.GetType("System.Double"));
            dt.Columns.Add("YLBX", Type.GetType("System.Double"));
            dt.Columns.Add("YLIBX", Type.GetType("System.Double"));
            dt.Columns.Add("YSSHF", Type.GetType("System.Double"));
            dt.Columns.Add("ZFGJJ", Type.GetType("System.Double"));
            dt.Columns.Add("扣发部分", Type.GetType("System.Double"));
            dt.Columns.Add("实发工资", Type.GetType("System.Double"));
            return dt;
        }

    }
}

  
