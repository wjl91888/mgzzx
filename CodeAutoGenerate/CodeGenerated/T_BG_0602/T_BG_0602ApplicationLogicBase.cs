/****************************************************** 
FileName:T_BG_0602ApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.T_BG_0602
{
    //===========================================================================
    //  ClassName : T_BG_0602ApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class T_BG_0602ApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BG_0602ApplicationData Add(T_BG_0602ApplicationData appData)
        {
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            instanceT_BG_0602BusinessEntity.AppData = appData;
            if (instanceT_BG_0602BusinessEntity.IsExistByKey() == false)
            {
                instanceT_BG_0602BusinessEntity.Insert();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceT_BG_0602BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BG_0602ApplicationData Modify(T_BG_0602ApplicationData appData)
        {
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            instanceT_BG_0602BusinessEntity.AppData = appData;
            if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BG_0602BusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BG_0602BusinessEntity.UpdateByKey();
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BG_0602BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0602BusinessEntity.UpdateByObjectID();
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BG_0602BusinessEntity.UpdateByObjectIDBatch();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BG_0602BusinessEntity.UpdateByAnyCondition();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BG_0602BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0602BusinessEntity.UpdateByObjectID();
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BG_0602BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BG_0602ApplicationData Query(T_BG_0602ApplicationData appData)
        {
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            instanceT_BG_0602BusinessEntity.AppData = appData;
            if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceT_BG_0602BusinessEntity.SelectByKey();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceT_BG_0602BusinessEntity.SelectByObjectID();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceT_BG_0602BusinessEntity.SelectByAnyCondition();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceT_BG_0602BusinessEntity.SelectByAnyCondition();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceT_BG_0602BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BG_0602ApplicationData Delete(T_BG_0602ApplicationData appData)
        {
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            instanceT_BG_0602BusinessEntity.AppData = appData;
            if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceT_BG_0602BusinessEntity.IsExistByKey() == true)
                {
                    instanceT_BG_0602BusinessEntity.DeleteByKey();
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceT_BG_0602BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0602BusinessEntity.DeleteByObjectID();
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceT_BG_0602BusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceT_BG_0602BusinessEntity.DeleteByObjectIDBatch();
                instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceT_BG_0602BusinessEntity.IsExistByObjectID() == true)
                {
                    instanceT_BG_0602BusinessEntity.DeleteByObjectID();
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceT_BG_0602BusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public T_BG_0602ApplicationData Count(T_BG_0602ApplicationData appData)
        {
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            instanceT_BG_0602BusinessEntity.AppData = appData;
            instanceT_BG_0602BusinessEntity.CountByAnyCondition();
            instanceT_BG_0602BusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceT_BG_0602BusinessEntity.AppData;
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
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            return instanceT_BG_0602BusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

        
        //=========================================================================
        //  FunctionName : AutoGenerateLMH
        /// <summary>
        /// �Զ�����LMH��ŷ���
        /// </summary>
        /// <returns>����LMH�±��</returns>
        //=========================================================================
        public string AutoGenerateLMH(T_BG_0602ApplicationData appData)
        {
            int intNumberLength = 6;
            string strPrefix = ("LM").ToString();
            strPrefix = strPrefix.ToLower() == "null" ? "" : strPrefix;
            T_BG_0602BusinessEntity instanceT_BG_0602BusinessEntity = (T_BG_0602BusinessEntity)CreateBusinessEntityInstance(typeof(T_BG_0602BusinessEntity));
            string strMaxValue;
            StringBuilder sbNewID = new StringBuilder(string.Empty);
            sbNewID.Append(strPrefix);
    
            strMaxValue = instanceT_BG_0602BusinessEntity.GetMaxValue(strPrefix, intNumberLength).ToString();
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
  
