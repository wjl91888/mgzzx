/****************************************************** 
FileName:FilterReportApplicationLogicBase.cs
******************************************************/
using System;
using System.Collections.Generic;
using System.Text;
using RICH.Common.Base.BusinessEntity;
using RICH.Common.Base.BusinessLogic;
using RICH.Common.Base.ApplicationData;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.BM.FilterReport
{
    //===========================================================================
    //  ClassName : FilterReportApplicationLogicBase
    /// <summary>
    /// Ӧ���߼�����
    /// </summary>
    //===========================================================================
    public class FilterReportApplicationLogicBase : ApplicationLogicBase
    {
        //=========================================================================
        //  FunctionName : Add
        /// <summary>
        /// ��ӷ���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public FilterReportApplicationData Add(FilterReportApplicationData appData)
        {
            FilterReportBusinessEntity instanceFilterReportBusinessEntity = (FilterReportBusinessEntity)CreateBusinessEntityInstance(typeof(FilterReportBusinessEntity));
            instanceFilterReportBusinessEntity.AppData = appData;
            if (instanceFilterReportBusinessEntity.IsExistByKey() == false)
            {
                instanceFilterReportBusinessEntity.Insert();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
            }
            return instanceFilterReportBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Modify
        /// <summary>
        /// ���·���
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public FilterReportApplicationData Modify(FilterReportApplicationData appData)
        {
            FilterReportBusinessEntity instanceFilterReportBusinessEntity = (FilterReportBusinessEntity)CreateBusinessEntityInstance(typeof(FilterReportBusinessEntity));
            instanceFilterReportBusinessEntity.AppData = appData;
            if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceFilterReportBusinessEntity.IsExistByKey() == true)
                {
                    instanceFilterReportBusinessEntity.UpdateByKey();
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceFilterReportBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceFilterReportBusinessEntity.UpdateByObjectID();
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceFilterReportBusinessEntity.UpdateByObjectIDBatch();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceFilterReportBusinessEntity.UpdateByAnyCondition();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceFilterReportBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceFilterReportBusinessEntity.UpdateByObjectID();
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceFilterReportBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Query
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public FilterReportApplicationData Query(FilterReportApplicationData appData)
        {
            FilterReportBusinessEntity instanceFilterReportBusinessEntity = (FilterReportBusinessEntity)CreateBusinessEntityInstance(typeof(FilterReportBusinessEntity));
            instanceFilterReportBusinessEntity.AppData = appData;
            if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                instanceFilterReportBusinessEntity.SelectByKey();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                instanceFilterReportBusinessEntity.SelectByObjectID();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ALL)
            {
                instanceFilterReportBusinessEntity.SelectByAnyCondition();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                instanceFilterReportBusinessEntity.SelectByAnyCondition();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            return instanceFilterReportBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Delete
        /// <summary>
        /// ɾ������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public FilterReportApplicationData Delete(FilterReportApplicationData appData)
        {
            FilterReportBusinessEntity instanceFilterReportBusinessEntity = (FilterReportBusinessEntity)CreateBusinessEntityInstance(typeof(FilterReportBusinessEntity));
            instanceFilterReportBusinessEntity.AppData = appData;
            if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.PK)
            {
                if (instanceFilterReportBusinessEntity.IsExistByKey() == true)
                {
                    instanceFilterReportBusinessEntity.DeleteByKey();
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.ID)
            {
                if (instanceFilterReportBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceFilterReportBusinessEntity.DeleteByObjectID();
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            else if (instanceFilterReportBusinessEntity.AppData.OPCode == ApplicationDataBase.OPType.BATCH)
            {
                instanceFilterReportBusinessEntity.DeleteByObjectIDBatch();
                instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            }
            else
            {
                if (instanceFilterReportBusinessEntity.IsExistByObjectID() == true)
                {
                    instanceFilterReportBusinessEntity.DeleteByObjectID();
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
                }
                else
                {
                    instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Failure;
                }
            }
            return instanceFilterReportBusinessEntity.AppData;
        }

        //=========================================================================
        //  FunctionName : Count
        /// <summary>
        /// ͳ�Ƽ�¼������
        /// </summary>
        /// <param name="appData">Ӧ������ʵ��</param>
        /// <returns>��������ʵ�����</returns>
        //=========================================================================
        public FilterReportApplicationData Count(FilterReportApplicationData appData)
        {
            FilterReportBusinessEntity instanceFilterReportBusinessEntity = (FilterReportBusinessEntity)CreateBusinessEntityInstance(typeof(FilterReportBusinessEntity));
            instanceFilterReportBusinessEntity.AppData = appData;
            instanceFilterReportBusinessEntity.CountByAnyCondition();
            instanceFilterReportBusinessEntity.AppData.ResultCode = ApplicationDataBase.ResultState.Succeed;
            return instanceFilterReportBusinessEntity.AppData;
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
            FilterReportBusinessEntity instanceFilterReportBusinessEntity = (FilterReportBusinessEntity)CreateBusinessEntityInstance(typeof(FilterReportBusinessEntity));
            return instanceFilterReportBusinessEntity.GetValueByFixCondition(strConditionField, strConditionValue, strValueField);
        }

            

        #region ���ٴ���
        #region ������ٴ���
    
        #endregion

        #region ��ر���ٴ���
    
        #endregion
        #endregion
    }
}
  
