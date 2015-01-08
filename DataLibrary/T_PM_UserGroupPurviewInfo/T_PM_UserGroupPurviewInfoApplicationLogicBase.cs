/****************************************************** 
FileName:T_PM_UserGroupPurviewInfoApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_PM_UserGroupPurviewInfo
{
    //===========================================================================
    //  ClassName : T_PM_UserGroupPurviewInfoApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_PM_UserGroupPurviewInfoApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_UserGroupPurviewInfoApplicationData Add(T_PM_UserGroupPurviewInfoApplicationData appData)
        {
            T_PM_UserGroupPurviewInfoBusinessEntity instanceT_PM_UserGroupPurviewInfoBusinessEntity = (T_PM_UserGroupPurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupPurviewInfoBusinessEntity));
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByKey() == false)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.Insert();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_UserGroupPurviewInfoApplicationData Modify(T_PM_UserGroupPurviewInfoApplicationData appData)
        {
            T_PM_UserGroupPurviewInfoBusinessEntity instanceT_PM_UserGroupPurviewInfoBusinessEntity = (T_PM_UserGroupPurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupPurviewInfoBusinessEntity));
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.UpdateByKey();
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.UpdateByObjectIDBatch();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.UpdateByAnyCondition();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.UpdateByObjectID();
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_UserGroupPurviewInfoApplicationData Query(T_PM_UserGroupPurviewInfoApplicationData appData)
        {
            T_PM_UserGroupPurviewInfoBusinessEntity instanceT_PM_UserGroupPurviewInfoBusinessEntity = (T_PM_UserGroupPurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupPurviewInfoBusinessEntity));
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.SelectByKey();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.SelectByObjectID();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.SelectByAnyCondition();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_UserGroupPurviewInfoApplicationData Delete(T_PM_UserGroupPurviewInfoApplicationData appData)
        {
            T_PM_UserGroupPurviewInfoBusinessEntity instanceT_PM_UserGroupPurviewInfoBusinessEntity = (T_PM_UserGroupPurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupPurviewInfoBusinessEntity));
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData = appData;
            if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.DeleteByKey();
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.DeleteByObjectIDBatch();
                instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_PM_UserGroupPurviewInfoBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.DeleteByObjectID();
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_PM_UserGroupPurviewInfoApplicationData Count(T_PM_UserGroupPurviewInfoApplicationData appData)
        {
            T_PM_UserGroupPurviewInfoBusinessEntity instanceT_PM_UserGroupPurviewInfoBusinessEntity = (T_PM_UserGroupPurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupPurviewInfoBusinessEntity));
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData = appData;
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.CountByAnyCondition();
            instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_PM_UserGroupPurviewInfoBusinessEntity.AppData;
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
            T_PM_UserGroupPurviewInfoBusinessEntity instanceT_PM_UserGroupPurviewInfoBusinessEntity = (T_PM_UserGroupPurviewInfoBusinessEntity)CreateBusinessEntityInstance(typeof(T_PM_UserGroupPurviewInfoBusinessEntity));
            return instanceT_PM_UserGroupPurviewInfoBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region ���ٴ���
        #region ������ٴ���
    
        #endregion

        #region ��ر���ٴ���
    
        #endregion
        #endregion
    }
}
  
