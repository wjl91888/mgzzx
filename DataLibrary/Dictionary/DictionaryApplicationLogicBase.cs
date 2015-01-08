/****************************************************** 
FileName:DictionaryApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.Dictionary
{
    //===========================================================================
    //  ClassName : DictionaryApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class DictionaryApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryApplicationData Add(DictionaryApplicationData appData)
        {
            DictionaryBusinessEntity instanceDictionaryBusinessEntity = (DictionaryBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryBusinessEntity));
            instanceDictionaryBusinessEntity.AppData = appData;
            if (instanceDictionaryBusinessEntity.IsExistByKey() == false)
            {
                instanceDictionaryBusinessEntity.Insert();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceDictionaryBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryApplicationData Modify(DictionaryApplicationData appData)
        {
            DictionaryBusinessEntity instanceDictionaryBusinessEntity = (DictionaryBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryBusinessEntity));
            instanceDictionaryBusinessEntity.AppData = appData;
            if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceDictionaryBusinessEntity.IsExistByKey() == true)
                {
                    instanceDictionaryBusinessEntity.UpdateByKey();
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceDictionaryBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryBusinessEntity.UpdateByObjectID();
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceDictionaryBusinessEntity.UpdateByObjectIDBatch();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceDictionaryBusinessEntity.UpdateByAnyCondition();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceDictionaryBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryBusinessEntity.UpdateByObjectID();
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceDictionaryBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryApplicationData Query(DictionaryApplicationData appData)
        {
            DictionaryBusinessEntity instanceDictionaryBusinessEntity = (DictionaryBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryBusinessEntity));
            instanceDictionaryBusinessEntity.AppData = appData;
            if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceDictionaryBusinessEntity.SelectByKey();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceDictionaryBusinessEntity.SelectByObjectID();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceDictionaryBusinessEntity.SelectByAnyCondition();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceDictionaryBusinessEntity.SelectByAnyCondition();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceDictionaryBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryApplicationData Delete(DictionaryApplicationData appData)
        {
            DictionaryBusinessEntity instanceDictionaryBusinessEntity = (DictionaryBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryBusinessEntity));
            instanceDictionaryBusinessEntity.AppData = appData;
            if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceDictionaryBusinessEntity.IsExistByKey() == true)
                {
                    instanceDictionaryBusinessEntity.DeleteByKey();
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceDictionaryBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryBusinessEntity.DeleteByObjectID();
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceDictionaryBusinessEntity.DeleteByObjectIDBatch();
                instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceDictionaryBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryBusinessEntity.DeleteByObjectID();
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceDictionaryBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryApplicationData Count(DictionaryApplicationData appData)
        {
            DictionaryBusinessEntity instanceDictionaryBusinessEntity = (DictionaryBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryBusinessEntity));
            instanceDictionaryBusinessEntity.AppData = appData;
            instanceDictionaryBusinessEntity.CountByAnyCondition();
            instanceDictionaryBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceDictionaryBusinessEntity.AppData;
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
            DictionaryBusinessEntity instanceDictionaryBusinessEntity = (DictionaryBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryBusinessEntity));
            return instanceDictionaryBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region 快速处理
        #region 主表快速处理
    
        #endregion

        #region 相关表快速处理
    
        #endregion
        #endregion
    }
}
  
