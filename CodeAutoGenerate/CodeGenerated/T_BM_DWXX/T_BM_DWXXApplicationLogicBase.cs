/****************************************************** 
FileName:T_BM_DWXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_DWXX
{
    //===========================================================================
    //  ClassName : T_BM_DWXXApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class T_BM_DWXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_DWXXApplicationData Add(T_BM_DWXXApplicationData appData)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            instanceT_BM_DWXXBusinessEntity.AppData = appData;
            if (instanceT_BM_DWXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_DWXXBusinessEntity.Insert();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_DWXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_DWXXApplicationData Modify(T_BM_DWXXApplicationData appData)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            instanceT_BM_DWXXBusinessEntity.AppData = appData;
            if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_DWXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_DWXXBusinessEntity.UpdateByKey();
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_DWXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_DWXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_DWXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_DWXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_DWXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_DWXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_DWXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_DWXXApplicationData Query(T_BM_DWXXApplicationData appData)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            instanceT_BM_DWXXBusinessEntity.AppData = appData;
            if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_DWXXBusinessEntity.SelectByKey();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_DWXXBusinessEntity.SelectByObjectID();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_DWXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_DWXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_DWXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_DWXXApplicationData Delete(T_BM_DWXXApplicationData appData)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            instanceT_BM_DWXXBusinessEntity.AppData = appData;
            if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_DWXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_DWXXBusinessEntity.DeleteByKey();
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_DWXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_DWXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_DWXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_DWXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_DWXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_DWXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_DWXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BM_DWXXApplicationData Count(T_BM_DWXXApplicationData appData)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            instanceT_BM_DWXXBusinessEntity.AppData = appData;
            instanceT_BM_DWXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_DWXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_DWXXBusinessEntity.AppData;
        }
        
        //=========================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// 取指定条件的指定值方法
        /// </summary>
        /// <returns>返回值</returns>
        //=========================================================================
        public object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            return instanceT_BM_DWXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateDWBH
        /// <summary>
        /// 自动生成DWBH编号方法
        /// </summary>
        /// <returns>返回DWBH新编号</returns>
        //=========================================================================
        public string AutoGenerateDWBH(T_BM_DWXXApplicationData appData)
        {
            int intNumberLength = 4;
            string strPrefix = ("DW").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BM_DWXXBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
    
            return sbNewID.ToString();
        }
            

        #region 快速处理
        #region 主表快速处理
    
        #endregion

        #region 相关表快速处理
    
        #endregion
        #endregion
    }
}
  
