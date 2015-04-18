/****************************************************** 
FileName:T_PM_UserInfoApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_PM_UserInfo
{
    //===========================================================================
    //  ClassName : T_PM_UserInfoApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class T_PM_UserInfoApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserInfoApplicationData Add(T_PM_UserInfoApplicationData appData)
        {
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            instanceT_PM_UserInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserInfoBusinessEntity.IsExistByKey() == false)
            {
                instanceT_PM_UserInfoBusinessEntity.Insert();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_PM_UserInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserInfoApplicationData Modify(T_PM_UserInfoApplicationData appData)
        {
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            instanceT_PM_UserInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_UserInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_UserInfoBusinessEntity.UpdateByKey();
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_UserInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_UserInfoBusinessEntity.UpdateByObjectIDBatch();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_UserInfoBusinessEntity.UpdateByAnyCondition();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_UserInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_UserInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserInfoApplicationData Query(T_PM_UserInfoApplicationData appData)
        {
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            instanceT_PM_UserInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_PM_UserInfoBusinessEntity.SelectByKey();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_PM_UserInfoBusinessEntity.SelectByObjectID();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_UserInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_UserInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_PM_UserInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserInfoApplicationData Delete(T_PM_UserInfoApplicationData appData)
        {
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            instanceT_PM_UserInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_UserInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_UserInfoBusinessEntity.DeleteByKey();
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_UserInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_UserInfoBusinessEntity.DeleteByObjectIDBatch();
                instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_UserInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_UserInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserInfoApplicationData Count(T_PM_UserInfoApplicationData appData)
        {
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            instanceT_PM_UserInfoBusinessEntity.AppData = appData;
            instanceT_PM_UserInfoBusinessEntity.CountByAnyCondition();
            instanceT_PM_UserInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_PM_UserInfoBusinessEntity.AppData;
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
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            return instanceT_PM_UserInfoBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateUserID
        /// <summary>
        /// 自动生成UserID编号方法
        /// </summary>
        /// <returns>返回UserID新编号</returns>
        //=========================================================================
        public string AutoGenerateUserID(T_PM_UserInfoApplicationData appData)
        {
            int intNumberLength = 5;
            string strPrefix = ("U").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_PM_UserInfoBusinessEntity instanceT_PM_UserInfoBusinessEntity = (T_PM_UserInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserInfoBusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_PM_UserInfoBusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
