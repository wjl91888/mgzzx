/****************************************************** 
FileName:ShortMessageApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.ShortMessage
{
    //===========================================================================
    //  ClassName : ShortMessageApplicationLogicBase
    /// <summary>
    /// 应用逻辑基类
    /// </summary>
    //===========================================================================
    public class ShortMessageApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// 添加方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public ShortMessageApplicationData Add(ShortMessageApplicationData appData)
        {
            ShortMessageBusinessEntity instanceShortMessageBusinessEntity = (ShortMessageBusinessEntity)CreateBusinessEntityInstance(typeof(ShortMessageBusinessEntity));
            instanceShortMessageBusinessEntity.AppData = appData;
            if (instanceShortMessageBusinessEntity.IsExistByKey() == false)
            {
                instanceShortMessageBusinessEntity.Insert();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceShortMessageBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// 更新方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public ShortMessageApplicationData Modify(ShortMessageApplicationData appData)
        {
            ShortMessageBusinessEntity instanceShortMessageBusinessEntity = (ShortMessageBusinessEntity)CreateBusinessEntityInstance(typeof(ShortMessageBusinessEntity));
            instanceShortMessageBusinessEntity.AppData = appData;
            if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceShortMessageBusinessEntity.IsExistByKey() == true)
                {
                    instanceShortMessageBusinessEntity.UpdateByKey();
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceShortMessageBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceShortMessageBusinessEntity.UpdateByObjectID();
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceShortMessageBusinessEntity.UpdateByObjectIDBatch();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceShortMessageBusinessEntity.UpdateByAnyCondition();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceShortMessageBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceShortMessageBusinessEntity.UpdateByObjectID();
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceShortMessageBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// 检索方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public ShortMessageApplicationData Query(ShortMessageApplicationData appData)
        {
            ShortMessageBusinessEntity instanceShortMessageBusinessEntity = (ShortMessageBusinessEntity)CreateBusinessEntityInstance(typeof(ShortMessageBusinessEntity));
            instanceShortMessageBusinessEntity.AppData = appData;
            if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceShortMessageBusinessEntity.SelectByKey();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceShortMessageBusinessEntity.SelectByObjectID();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceShortMessageBusinessEntity.SelectByAnyCondition();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceShortMessageBusinessEntity.SelectByAnyCondition();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceShortMessageBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// 删除方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public ShortMessageApplicationData Delete(ShortMessageApplicationData appData)
        {
            ShortMessageBusinessEntity instanceShortMessageBusinessEntity = (ShortMessageBusinessEntity)CreateBusinessEntityInstance(typeof(ShortMessageBusinessEntity));
            instanceShortMessageBusinessEntity.AppData = appData;
            if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceShortMessageBusinessEntity.IsExistByKey() == true)
                {
                    instanceShortMessageBusinessEntity.DeleteByKey();
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceShortMessageBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceShortMessageBusinessEntity.DeleteByObjectID();
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceShortMessageBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceShortMessageBusinessEntity.DeleteByObjectIDBatch();
                instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceShortMessageBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceShortMessageBusinessEntity.DeleteByObjectID();
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceShortMessageBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// 统计记录数方法
        /// </summary>
        /// <param name="appData">应用数据实体</param>
        /// <returns>返回数据实体对象</returns>
        //=========================================================================
        public ShortMessageApplicationData Count(ShortMessageApplicationData appData)
        {
            ShortMessageBusinessEntity instanceShortMessageBusinessEntity = (ShortMessageBusinessEntity)CreateBusinessEntityInstance(typeof(ShortMessageBusinessEntity));
            instanceShortMessageBusinessEntity.AppData = appData;
            instanceShortMessageBusinessEntity.CountByAnyCondition();
            instanceShortMessageBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceShortMessageBusinessEntity.AppData;
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
            ShortMessageBusinessEntity instanceShortMessageBusinessEntity = (ShortMessageBusinessEntity)CreateBusinessEntityInstance(typeof(ShortMessageBusinessEntity));
            return instanceShortMessageBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region 快速处理
        #region 主表快速处理
    
        #endregion

        #region 相关表快速处理
    
        #endregion
        #endregion
    }
}
  
