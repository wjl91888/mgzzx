/****************************************************** 
FileName:T_BG_0601ApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BG_0601
{
    //===========================================================================
    //  ClassName : T_BG_0601ApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class T_BG_0601ApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BG_0601ApplicationData Add(T_BG_0601ApplicationData appData)
        {
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            instanceT_BG_0601BusinessEntity.AppData = appData;
            if (instanceT_BG_0601BusinessEntity.IsExistByKey() == false)
            {
                instanceT_BG_0601BusinessEntity.Insert();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BG_0601BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BG_0601ApplicationData Modify(T_BG_0601ApplicationData appData)
        {
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            instanceT_BG_0601BusinessEntity.AppData = appData;
            if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BG_0601BusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BG_0601BusinessEntity.UpdateByKey();
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BG_0601BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0601BusinessEntity.UpdateByObjectID();
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BG_0601BusinessEntity.UpdateByObjectIDBatch();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BG_0601BusinessEntity.UpdateByAnyCondition();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BG_0601BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0601BusinessEntity.UpdateByObjectID();
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BG_0601BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BG_0601ApplicationData Query(T_BG_0601ApplicationData appData)
        {
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            instanceT_BG_0601BusinessEntity.AppData = appData;
            if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BG_0601BusinessEntity.SelectByKey();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BG_0601BusinessEntity.SelectByObjectID();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BG_0601BusinessEntity.SelectByAnyCondition();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BG_0601BusinessEntity.SelectByAnyCondition();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BG_0601BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BG_0601ApplicationData Delete(T_BG_0601ApplicationData appData)
        {
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            instanceT_BG_0601BusinessEntity.AppData = appData;
            if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BG_0601BusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BG_0601BusinessEntity.DeleteByKey();
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BG_0601BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0601BusinessEntity.DeleteByObjectID();
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0601BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BG_0601BusinessEntity.DeleteByObjectIDBatch();
                instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BG_0601BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0601BusinessEntity.DeleteByObjectID();
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BG_0601BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_BG_0601ApplicationData Count(T_BG_0601ApplicationData appData)
        {
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            instanceT_BG_0601BusinessEntity.AppData = appData;
            instanceT_BG_0601BusinessEntity.CountByAnyCondition();
            instanceT_BG_0601BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BG_0601BusinessEntity.AppData;
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
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            return instanceT_BG_0601BusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateFBH
        /// <summary>
        /// 自动生成FBH编号方法
        /// </summary>
        /// <returns>返回FBH新编号</returns>
        //=========================================================================
        public string AutoGenerateFBH(T_BG_0601ApplicationData appData)
        {
            int intNumberLength = 8;
            string strPrefix = ("XX").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BG_0601BusinessEntity instanceT_BG_0601BusinessEntity = (T_BG_0601BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0601BusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BG_0601BusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
