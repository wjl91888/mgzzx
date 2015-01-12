/****************************************************** 
FileName:T_BG_0601WebUI.cs
******************************************************/
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace RICH.Common.BM.T_BG_0601
{
    //=========================================================================
    //  ClassName : T_BG_0601WebUI
    /// <summary>
    /// T_BG_0601的扩展逻辑实体类
    /// </summary>
    //=========================================================================
    public class T_BG_0601WebUI : T_BG_0601WebUIBase
    {
        public string GetSubColumn(string strUpColumn)
        {
            string strReturn = strUpColumn;
            // 得到下级栏目号
            DataSet dsTemp = new DataSet();

            RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData t_BG_0602ApplicationData;
            t_BG_0602ApplicationData = new RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData();
            t_BG_0602ApplicationData.CurrentPage = 1;
            t_BG_0602ApplicationData.PageSize = 1000;
            t_BG_0602ApplicationData.SortField = "LMH";
            t_BG_0602ApplicationData.Sort = true;
            t_BG_0602ApplicationData.SJLMH = strUpColumn;

            RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic t_BG_0602ApplicationLogic;

            t_BG_0602ApplicationLogic
                = (RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic));
            t_BG_0602ApplicationData = t_BG_0602ApplicationLogic.Query(t_BG_0602ApplicationData);

            dsTemp = t_BG_0602ApplicationData.ResultSet;
            if (dsTemp.Tables.Count > 0)
            {
                foreach (DataRow drTemp in dsTemp.Tables[0].Rows)
                {
                    strReturn = strReturn + "," + drTemp["LMH"];
                }
            }
            return strReturn;
        }

        public DataSet GetNewsList(string strLMH, int intListNumber, string strXXZT = null, string strIsBest = null, string strXXLX = null)
        {
            appData = new T_BG_0601ApplicationData();
            appData.CurrentPage = 1;
            appData.PageSize = intListNumber;
            appData.SortField = "IsTop DESC, TopSort ASC, FBSJRQ";
            appData.Sort = false;
            if (strIsBest != null)
            {
                appData.IsBest = strIsBest;
            }
            appData.FBLMBatch = GetSubColumn(strLMH);
            if (strXXLX != null)
            {
                appData.XXLX = strXXLX;
            }
            if (strXXZT != null)
            {
                appData.XXZT = strXXZT;
            }

            T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
            appData = instanceT_BG_0601ApplicationLogic.Query(appData);

            return appData.ResultSet;
        }

        public DataSet GetLMList(string strLMH, int intListNumber)
        {
            RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData t_BG_0602ApplicationData;
            t_BG_0602ApplicationData = new RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData();
            t_BG_0602ApplicationData.CurrentPage = 1;
            t_BG_0602ApplicationData.PageSize = intListNumber;
            t_BG_0602ApplicationData.SortField = "LMH";
            t_BG_0602ApplicationData.Sort = true;
            t_BG_0602ApplicationData.SJLMH = strLMH;

            RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic t_BG_0602ApplicationLogic;

            t_BG_0602ApplicationLogic
                = (RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic));
            t_BG_0602ApplicationData = t_BG_0602ApplicationLogic.Query(t_BG_0602ApplicationData);

            if (t_BG_0602ApplicationData.RecordCount <= 0)
            {
                t_BG_0602ApplicationData = new RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationData();
                t_BG_0602ApplicationData.CurrentPage = 1;
                t_BG_0602ApplicationData.PageSize = intListNumber;
                t_BG_0602ApplicationData.SortField = "LMH";
                t_BG_0602ApplicationData.Sort = true;
                t_BG_0602ApplicationData.SJLMH = (string)(new RICH.Common.BM.T_BG_0602.T_BG_0602BusinessEntity()).GetValueByFixCondition("LMH", strLMH, "SJLMH");
                t_BG_0602ApplicationLogic
                    = (RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic)CreateApplicationLogicInstance(typeof(RICH.Common.BM.T_BG_0602.T_BG_0602ApplicationLogic));
                t_BG_0602ApplicationData = t_BG_0602ApplicationLogic.Query(t_BG_0602ApplicationData);
            }

            return t_BG_0602ApplicationData.ResultSet;
        }

        public DataSet GetXXNR(string guidObjectID)
        {
            appData = new T_BG_0601ApplicationData();
            appData.PageSize = 1;
            appData.ObjectID = guidObjectID;
            appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;

            T_BG_0601ApplicationLogic instanceT_BG_0601ApplicationLogic
                = (T_BG_0601ApplicationLogic)CreateApplicationLogicInstance(typeof(T_BG_0601ApplicationLogic));
            appData = instanceT_BG_0601ApplicationLogic.Query(appData);
            return appData.ResultSet;
        }

        public string RemoveTags(string strSource)
        {
            return System.Text.RegularExpressions.Regex.Replace(strSource, "<[^>]*>", "");
        }
    }
}
  
