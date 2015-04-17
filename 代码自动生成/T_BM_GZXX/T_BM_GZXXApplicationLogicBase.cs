/****************************************************** 
FileName:T_BM_GZXXApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BM_GZXX
{
    //===========================================================================
    //  ClassName : T_BM_GZXXApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_GZXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_GZXXApplicationData Add(T_BM_GZXXApplicationData appData)
        {
            T_BM_GZXXBusinessEntity instanceT_BM_GZXXBusinessEntity = (T_BM_GZXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_GZXXBusinessEntity));
            instanceT_BM_GZXXBusinessEntity.AppData = appData;
            if (instanceT_BM_GZXXBusinessEntity.IsExistByKey() == false)
            {
                instanceT_BM_GZXXBusinessEntity.Insert();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BM_GZXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_GZXXApplicationData Modify(T_BM_GZXXApplicationData appData)
        {
            T_BM_GZXXBusinessEntity instanceT_BM_GZXXBusinessEntity = (T_BM_GZXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_GZXXBusinessEntity));
            instanceT_BM_GZXXBusinessEntity.AppData = appData;
            if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_GZXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_GZXXBusinessEntity.UpdateByKey();
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_GZXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_GZXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_GZXXBusinessEntity.UpdateByObjectIDBatch();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_GZXXBusinessEntity.UpdateByAnyCondition();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_GZXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_GZXXBusinessEntity.UpdateByObjectID();
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_GZXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_GZXXApplicationData Query(T_BM_GZXXApplicationData appData)
        {
            T_BM_GZXXBusinessEntity instanceT_BM_GZXXBusinessEntity = (T_BM_GZXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_GZXXBusinessEntity));
            instanceT_BM_GZXXBusinessEntity.AppData = appData;
            if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BM_GZXXBusinessEntity.SelectByKey();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BM_GZXXBusinessEntity.SelectByObjectID();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BM_GZXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BM_GZXXBusinessEntity.SelectByAnyCondition();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BM_GZXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_GZXXApplicationData Delete(T_BM_GZXXApplicationData appData)
        {
            T_BM_GZXXBusinessEntity instanceT_BM_GZXXBusinessEntity = (T_BM_GZXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_GZXXBusinessEntity));
            instanceT_BM_GZXXBusinessEntity.AppData = appData;
            if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BM_GZXXBusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BM_GZXXBusinessEntity.DeleteByKey();
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BM_GZXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_GZXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BM_GZXXBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BM_GZXXBusinessEntity.DeleteByObjectIDBatch();
                instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BM_GZXXBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BM_GZXXBusinessEntity.DeleteByObjectID();
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BM_GZXXBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BM_GZXXApplicationData Count(T_BM_GZXXApplicationData appData)
        {
            T_BM_GZXXBusinessEntity instanceT_BM_GZXXBusinessEntity = (T_BM_GZXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_GZXXBusinessEntity));
            instanceT_BM_GZXXBusinessEntity.AppData = appData;
            instanceT_BM_GZXXBusinessEntity.CountByAnyCondition();
            instanceT_BM_GZXXBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BM_GZXXBusinessEntity.AppData;
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
            T_BM_GZXXBusinessEntity instanceT_BM_GZXXBusinessEntity = (T_BM_GZXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_GZXXBusinessEntity));
            return instanceT_BM_GZXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region ���ٴ���
        #region ������ٴ���
    
        #endregion

        #region ��ر���ٴ���
    
        #endregion
        #endregion
    }
}
  
