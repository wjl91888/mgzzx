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
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BM_DWXXApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
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
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
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
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
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
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
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
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
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
        /// ȡָ��������ָ��ֵ����
        /// </summary>
        /// <returns>����ֵ</returns>
        //=========================================================================
        public object GetValueByFixCondition(string strConditionField, object strConditionValue, string strValueField)
        {
            T_BM_DWXXBusinessEntity instanceT_BM_DWXXBusinessEntity = (T_BM_DWXXBusinessEntity)CreateBusinessEntityInstance(typeof(T_BM_DWXXBusinessEntity));
            return instanceT_BM_DWXXBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateDWBH
        /// <summary>
        /// �Զ�����DWBH��ŷ���
        /// </summary>
        /// <returns>����DWBH�±��</returns>
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
            

        #region ���ٴ���
        #region ������ٴ���
    
        #endregion

        #region ��ر���ٴ���
    
        #endregion
        #endregion
    }
}
  
