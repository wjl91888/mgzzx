/****************************************************** 
FileName:T_PM_PurviewInfoApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_PM_PurviewInfo
{
    //===========================================================================
    //  ClassName : T_PM_PurviewInfoApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_PM_PurviewInfoApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_PurviewInfoApplicationData Add(T_PM_PurviewInfoApplicationData appData)
        {
            T_PM_PurviewInfoBusinessEntity instanceT_PM_PurviewInfoBusinessEntity = (T_PM_PurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_PurviewInfoBusinessEntity));
            instanceT_PM_PurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByKey() == false)
            {
                instanceT_PM_PurviewInfoBusinessEntity.Insert();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_PM_PurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_PurviewInfoApplicationData Modify(T_PM_PurviewInfoApplicationData appData)
        {
            T_PM_PurviewInfoBusinessEntity instanceT_PM_PurviewInfoBusinessEntity = (T_PM_PurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_PurviewInfoBusinessEntity));
            instanceT_PM_PurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_PurviewInfoBusinessEntity.UpdateByKey();
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_PurviewInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_PurviewInfoBusinessEntity.UpdateByObjectIDBatch();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_PurviewInfoBusinessEntity.UpdateByAnyCondition();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_PurviewInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_PurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_PurviewInfoApplicationData Query(T_PM_PurviewInfoApplicationData appData)
        {
            T_PM_PurviewInfoBusinessEntity instanceT_PM_PurviewInfoBusinessEntity = (T_PM_PurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_PurviewInfoBusinessEntity));
            instanceT_PM_PurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_PM_PurviewInfoBusinessEntity.SelectByKey();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_PM_PurviewInfoBusinessEntity.SelectByObjectID();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_PurviewInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_PurviewInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_PM_PurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_PurviewInfoApplicationData Delete(T_PM_PurviewInfoApplicationData appData)
        {
            T_PM_PurviewInfoBusinessEntity instanceT_PM_PurviewInfoBusinessEntity = (T_PM_PurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_PurviewInfoBusinessEntity));
            instanceT_PM_PurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_PurviewInfoBusinessEntity.DeleteByKey();
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_PurviewInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_PurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_PurviewInfoBusinessEntity.DeleteByObjectIDBatch();
                instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_PurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_PurviewInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_PurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_PurviewInfoApplicationData Count(T_PM_PurviewInfoApplicationData appData)
        {
            T_PM_PurviewInfoBusinessEntity instanceT_PM_PurviewInfoBusinessEntity = (T_PM_PurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_PurviewInfoBusinessEntity));
            instanceT_PM_PurviewInfoBusinessEntity.AppData = appData;
            instanceT_PM_PurviewInfoBusinessEntity.CountByAnyCondition();
            instanceT_PM_PurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_PM_PurviewInfoBusinessEntity.AppData;
        }
        
        //=========================================================================
        //  FunctionName : GetValueByFixCondition
        /// <summary>
        /// ȡָ��������ָ��ֵ����
        /// </summary>
        /// <returns>����ֵ</returns>
        //=========================================================================
        public object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField)
        {
            T_PM_PurviewInfoBusinessEntity instanceT_PM_PurviewInfoBusinessEntity = (T_PM_PurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_PurviewInfoBusinessEntity));
            return instanceT_PM_PurviewInfoBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region ���ٴ���
        #region ������ٴ���
    
        #endregion

        #region ��ر���ٴ���
    
        #endregion
        #endregion
    }
}
  
