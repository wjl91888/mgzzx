/****************************************************** 
FileName:T_PM_UserGroupInfoApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_PM_UserGroupInfo
{
    //===========================================================================
    //  ClassName : T_PM_UserGroupInfoApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class T_PM_UserGroupInfoApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserGroupInfoApplicationData Add(T_PM_UserGroupInfoApplicationData appData)
        {
            T_PM_UserGroupInfoBusinessEntity instanceT_PM_UserGroupInfoBusinessEntity = (T_PM_UserGroupInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupInfoBusinessEntity));
            instanceT_PM_UserGroupInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByKey() == false)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.Insert();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_PM_UserGroupInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserGroupInfoApplicationData Modify(T_PM_UserGroupInfoApplicationData appData)
        {
            T_PM_UserGroupInfoBusinessEntity instanceT_PM_UserGroupInfoBusinessEntity = (T_PM_UserGroupInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupInfoBusinessEntity));
            instanceT_PM_UserGroupInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.UpdateByKey();
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.UpdateByObjectIDBatch();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.UpdateByAnyCondition();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_UserGroupInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserGroupInfoApplicationData Query(T_PM_UserGroupInfoApplicationData appData)
        {
            T_PM_UserGroupInfoBusinessEntity instanceT_PM_UserGroupInfoBusinessEntity = (T_PM_UserGroupInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupInfoBusinessEntity));
            instanceT_PM_UserGroupInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.SelectByKey();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.SelectByObjectID();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_UserGroupInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_PM_UserGroupInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserGroupInfoApplicationData Delete(T_PM_UserGroupInfoApplicationData appData)
        {
            T_PM_UserGroupInfoBusinessEntity instanceT_PM_UserGroupInfoBusinessEntity = (T_PM_UserGroupInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupInfoBusinessEntity));
            instanceT_PM_UserGroupInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.DeleteByKey();
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_UserGroupInfoBusinessEntity.DeleteByObjectIDBatch();
                instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_UserGroupInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_UserGroupInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public T_PM_UserGroupInfoApplicationData Count(T_PM_UserGroupInfoApplicationData appData)
        {
            T_PM_UserGroupInfoBusinessEntity instanceT_PM_UserGroupInfoBusinessEntity = (T_PM_UserGroupInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupInfoBusinessEntity));
            instanceT_PM_UserGroupInfoBusinessEntity.AppData = appData;
            instanceT_PM_UserGroupInfoBusinessEntity.CountByAnyCondition();
            instanceT_PM_UserGroupInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_PM_UserGroupInfoBusinessEntity.AppData;
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
            T_PM_UserGroupInfoBusinessEntity instanceT_PM_UserGroupInfoBusinessEntity = (T_PM_UserGroupInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupInfoBusinessEntity));
            return instanceT_PM_UserGroupInfoBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region 快速处理
        #region 主表快速处理
    
        #endregion

        #region 相关表快速处理
    
        #endregion
        #endregion
    }
}
  
