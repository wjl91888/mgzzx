/****************************************************** 
FileName:DictionaryTypeApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.DictionaryType
{
    //===========================================================================
    //  ClassName : DictionaryTypeApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class DictionaryTypeApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryTypeApplicationData Add(DictionaryTypeApplicationData appData)
        {
            DictionaryTypeBusinessEntity instanceDictionaryTypeBusinessEntity = (DictionaryTypeBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryTypeBusinessEntity));
            instanceDictionaryTypeBusinessEntity.AppData = appData;
            if (instanceDictionaryTypeBusinessEntity.IsExistByKey() == false)
            {
                instanceDictionaryTypeBusinessEntity.Insert();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceDictionaryTypeBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryTypeApplicationData Modify(DictionaryTypeApplicationData appData)
        {
            DictionaryTypeBusinessEntity instanceDictionaryTypeBusinessEntity = (DictionaryTypeBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryTypeBusinessEntity));
            instanceDictionaryTypeBusinessEntity.AppData = appData;
            if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceDictionaryTypeBusinessEntity.IsExistByKey() == true)
                {
                    instanceDictionaryTypeBusinessEntity.UpdateByKey();
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceDictionaryTypeBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryTypeBusinessEntity.UpdateByObjectID();
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceDictionaryTypeBusinessEntity.UpdateByObjectIDBatch();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceDictionaryTypeBusinessEntity.UpdateByAnyCondition();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceDictionaryTypeBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryTypeBusinessEntity.UpdateByObjectID();
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceDictionaryTypeBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryTypeApplicationData Query(DictionaryTypeApplicationData appData)
        {
            DictionaryTypeBusinessEntity instanceDictionaryTypeBusinessEntity = (DictionaryTypeBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryTypeBusinessEntity));
            instanceDictionaryTypeBusinessEntity.AppData = appData;
            if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceDictionaryTypeBusinessEntity.SelectByKey();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceDictionaryTypeBusinessEntity.SelectByObjectID();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceDictionaryTypeBusinessEntity.SelectByAnyCondition();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceDictionaryTypeBusinessEntity.SelectByAnyCondition();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceDictionaryTypeBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryTypeApplicationData Delete(DictionaryTypeApplicationData appData)
        {
            DictionaryTypeBusinessEntity instanceDictionaryTypeBusinessEntity = (DictionaryTypeBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryTypeBusinessEntity));
            instanceDictionaryTypeBusinessEntity.AppData = appData;
            if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceDictionaryTypeBusinessEntity.IsExistByKey() == true)
                {
                    instanceDictionaryTypeBusinessEntity.DeleteByKey();
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceDictionaryTypeBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryTypeBusinessEntity.DeleteByObjectID();
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceDictionaryTypeBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceDictionaryTypeBusinessEntity.DeleteByObjectIDBatch();
                instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceDictionaryTypeBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceDictionaryTypeBusinessEntity.DeleteByObjectID();
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceDictionaryTypeBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public DictionaryTypeApplicationData Count(DictionaryTypeApplicationData appData)
        {
            DictionaryTypeBusinessEntity instanceDictionaryTypeBusinessEntity = (DictionaryTypeBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryTypeBusinessEntity));
            instanceDictionaryTypeBusinessEntity.AppData = appData;
            instanceDictionaryTypeBusinessEntity.CountByAnyCondition();
            instanceDictionaryTypeBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceDictionaryTypeBusinessEntity.AppData;
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
            DictionaryTypeBusinessEntity instanceDictionaryTypeBusinessEntity = (DictionaryTypeBusinessEntity)CreateBusinessEntityInstance(typeof(DictionaryTypeBusinessEntity));
            return instanceDictionaryTypeBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region 快速处理
        #region 主表快速处理
    
        #endregion

        #region 相关表快速处理
    
        #endregion
        #endregion
    }
}
  
