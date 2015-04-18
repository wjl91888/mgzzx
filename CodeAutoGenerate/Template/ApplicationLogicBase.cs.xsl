<?xml version="1.0" encoding="gb2312"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" encoding="GB2312"/>
  <xsl:variable name="FileName" select="'ApplicationLogicBase.cs.xsl'"/>
  <xsl:template match="/">
/****************************************************** 
FileName:<xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>
{
    //===========================================================================
    //  ClassName : <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class <xsl:value-of select="/NewDataSet/TableName"/>ApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData Add(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData = appData;
            if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByKey() == false)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.Insert();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData Modify(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData = appData;
            if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByKey() == true)
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.UpdateByKey();
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByObjectID() == true)
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.UpdateByObjectID();
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.UpdateByObjectIDBatch();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.UpdateByAnyCondition();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByObjectID() == true)
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.UpdateByObjectID();
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData Query(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData = appData;
            if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.SelectByKey();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.SelectByObjectID();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.SelectByAnyCondition();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.SelectByAnyCondition();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData Delete(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData = appData;
            if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByKey() == true)
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.DeleteByKey();
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByObjectID() == true)
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.DeleteByObjectID();
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.DeleteByObjectIDBatch();
                instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByObjectID() == true)
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.DeleteByObjectID();
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public <xsl:value-of select="/NewDataSet/TableName"/>ApplicationData Count(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData = appData;
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.CountByAnyCondition();
            instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData;
        }
        
        //=========================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// 取指定条件的指定值方法
        /// </summary>
        /// <returns>返回值<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/></returns>
        //=========================================================================
        public object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        <xsl:if test="/NewDataSet/AllowAutoGenerateID = 'true'">
        //=========================================================================
        //  FunctionName : AutoGenerate<xsl:value-of select="/NewDataSet/AutoGenerateField"/>
        /// <summary>
        /// 自动生成<xsl:value-of select="/NewDataSet/AutoGenerateField"/>编号方法
        /// </summary>
        /// <returns>返回<xsl:value-of select="/NewDataSet/AutoGenerateField"/>新编号</returns>
        //=========================================================================
        public string AutoGenerate<xsl:value-of select="/NewDataSet/AutoGenerateField"/>(<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData)
        {
            int intNumberLength = <xsl:value-of select="/NewDataSet/AutoGenerateNumberLength"/>;
            string strPrefix = (<xsl:value-of select="/NewDataSet/AutoGeneratePrefix"/>).ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    <xsl:if test="/NewDataSet/AutoGenerateIncludeDateTime = 'true'">
        <xsl:if test="/NewDataSet/AutoGenerateYear = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Year.ToString(), 4));</xsl:if>
        <xsl:if test="/NewDataSet/AutoGenerateMonth = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Month.ToString(), 2));</xsl:if>
        <xsl:if test="/NewDataSet/AutoGenerateDay = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Day.ToString(), 2));</xsl:if>
        <xsl:if test="/NewDataSet/AutoGenerateHour = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Hour.ToString(), 2));</xsl:if>
        <xsl:if test="/NewDataSet/AutoGenerateMinute = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Minute.ToString(), 2));</xsl:if>
        <xsl:if test="/NewDataSet/AutoGenerateSecond = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Second.ToString(), 2));</xsl:if>
        <xsl:if test="/NewDataSet/AutoGenerateMSecond = 'true'">
            sbNewID.Append(FillZeroToString(DateTime.Now.Millisecond.ToString(), 3));</xsl:if>
    </xsl:if>
    <xsl:if test="/NewDataSet/AutoGenerateOrder = 'true'">
            strMaxValue = instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
            if (strMaxValue != String.Empty)
            {
                if (strMaxValue.Length == strPrefix.Length + intNumberLength)
                {
                    int intMaxValue = Convert.ToInt32(strMaxValue.Substring(strPrefix.Length, intNumberLength)) + 1;
                    sbNewID.Append(FillZeroToString(intMaxValue.ToString(), intNumberLength));
                }
                else
                {
                    sbNewID.Append(FillZeroToString("1", intNumberLength));
                }
            }
            else
            {
                sbNewID.Append(FillZeroToString("1", intNumberLength));
            }
    </xsl:if>
            return sbNewID.ToString();
        }
        </xsl:if>

        <xsl:if test="/NewDataSet/GetValue/GetValue = 'true'">
        //=========================================================================
        //  FunctionName : GetValue<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/>
        /// <summary>
        /// 取值<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/>方法
        /// </summary>
        /// <returns>返回值<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/></returns>
        //=========================================================================
        public object GetValue<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/>(object strConditionValue)
        {
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            <xsl:if test="/NewDataSet/GetValue/GetValueByKey = 'true'">
                <xsl:for-each select="/NewDataSet/RecordInfo">
                  <xsl:if test="IsPrimaryKey = 'true'">
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.GetValueByFixCondition("<xsl:value-of select="FieldName"/>", strConditionValue, "<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/>");
                  </xsl:if>
                </xsl:for-each>
            </xsl:if>
            <xsl:if test="/NewDataSet/GetValue/GetValueByKey = 'false'">
            return instance<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.GetValueByFixCondition("<xsl:value-of select="/NewDataSet/GetValue/GetValueValueField"/>", strConditionValue, "<xsl:value-of select="/NewDataSet/GetValue/GetValueTextField"/>");
            </xsl:if>
        }
        </xsl:if>    

        #region 快速处理
        #region 主表快速处理
<xsl:for-each select="/NewDataSet/RecordInfo">
    <xsl:if test="IsDispose = 'true'">  
        //=====================================================================
        //  FunctionName : <xsl:value-of select="FieldName"/>QuickDispose
        /// <summary>
        /// <xsl:value-of select="FieldRemark"/>（<xsl:value-of select="FieldName"/>）快速处理
        /// </summary>
        //=====================================================================
        public RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData <xsl:value-of select="FieldName"/>QuickDispose(string CLObjectID, string CLDW, string DJR)
        {
            RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData appData = new RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity));
            <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData = appData;
            string[] strObjectIDBatch = CLObjectID.Split(new char[] { ',' });
            foreach (string strObjectID in strObjectIDBatch)
            {
                appData.ObjectID = strObjectID;
                appData.<xsl:value-of select="FieldName"/> = <xsl:value-of select="DisposeSetValue"/>;
                if (<xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.IsExistByKey() == true)
                {
                    <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.UpdateByObjectID();
                    <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity.AppData;
        }
    </xsl:if>
</xsl:for-each>    
        #endregion

        #region 相关表快速处理
<xsl:for-each select="/NewDataSet/CustomDisplayFieldConfig">
    <xsl:sort data-type="text" order="descending" select="IsDisplay"/>
    <xsl:sort data-type="number" order="ascending" select="SerialNumber"/>   
    <xsl:if test="RelatedTableType = '1_to_1'">
        <xsl:if test="IsDispose = 'true'">  
        //=====================================================================
        //  FunctionName : <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>QuickDispose
        /// <summary>
        /// <xsl:value-of select="DisplayName"/>（<xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>）快速处理
        /// </summary>
        //=====================================================================
        public RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData <xsl:value-of select="TableWithField"/>_<xsl:value-of select="RelatedTableName"/>_<xsl:value-of select="DisplayFieldName"/>QuickDispose(string CLObjectID, string CLDW, string DJR)
        {
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>ApplicationData appData = new RICH.Common.BM.<xsl:value-of select="/NewDataSet/TableName"/>.<xsl:value-of select="/NewDataSet/TableName"/>ApplicationData();
            RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>BusinessEntity <xsl:value-of select="/NewDataSet/TableName"/>BusinessEntity = (RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>BusinessEntity)CreateBusinessEntityInstance(typeof(RICH.Common.BM.<xsl:value-of select="RelatedTableName"/>.<xsl:value-of select="RelatedTableName"/>BusinessEntity));
            <xsl:value-of select="RelatedTableName"/>BusinessEntity.AppData = appData;
            string[] strObjectIDBatch = CLObjectID.Split(new char[] { ',' });
            foreach (string strObjectID in strObjectIDBatch)
            {
                appData.CLObjectID = strObjectID;
                appData.CLDW = CLDW;
                appData.DJR = DJR;
                appData.DJSJ = DateTime.Now;
                if (<xsl:value-of select="RelatedTableName"/>BusinessEntity.IsExistByKey() == false)
                {
                    <xsl:value-of select="RelatedTableName"/>BusinessEntity.Insert();
                    <xsl:value-of select="RelatedTableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    <xsl:value-of select="RelatedTableName"/>BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return <xsl:value-of select="RelatedTableName"/>BusinessEntity.AppData;
        }
        </xsl:if>
    </xsl:if>
</xsl:for-each>    
        #endregion
        #endregion
    }
}
  </xsl:template>
</xsl:stylesheet>