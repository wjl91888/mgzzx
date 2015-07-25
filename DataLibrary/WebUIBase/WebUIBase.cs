using System;
using System.Collections;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationLogic;
using RICH.Common.BM.FilterReport;
using RICH.Common.BM.T_PM_UserInfo;
using RICH.Common.LM;

namespace RICH.Common.Base.WebUI
{
    public abstract partial class WebUIBase : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler
    {
        protected ApplicationLogicBase CreateApplicationLogicInstance(Type typeofApplicationLogic)
        {
            ApplicationLogicBase applicationLogic = (ApplicationLogicBase)Activator.CreateInstance(typeofApplicationLogic);
            return applicationLogic;
        }

        protected Boolean ValidateRequestParamter()
        {
            Boolean boolReturn = true;
            string[] arrBadWords = { 
                                       "\'", "&", "insert", "select", "delete", "%", 
                                       "*", "master", "truncate", "declare" };
            for (int i = 0; i < Request.Form.Count; i++)
            {
                foreach (string strTemp in arrBadWords)
                {
                    if (Request.Form[i].ToLower().IndexOf(strTemp) >= 0)
                    {
                        boolReturn = false;
                    }
                }
            }
            for (int i = 0; i < Request.QueryString.Count; i++)
            {
                foreach (string strTemp in arrBadWords)
                {
                    if (Request.QueryString[i].ToLower().IndexOf(strTemp) >= 0)
                    {
                        boolReturn = false;
                    }
                }
            }
            return boolReturn;
        }


        protected string GetValue(object objValue)
        {
            return GetValue(objValue, null);
        }

        protected string GetValue(object objValue, string strDisplayFormat = null)
        {
            string strReturn = string.Empty;
            if (objValue == DBNull.Value)
            {
                return strReturn;
            }
            if (objValue == null)
            {
                return strReturn;
            }
            if (strDisplayFormat == null)
            {
                strReturn = objValue.ToString();
            }
            else if(Type.GetType("System.String") == objValue.GetType())
            {
                char[] value = objValue.ToString().ToCharArray();
                for (int i = 0; i < value.Length; i++)
                {
                    strDisplayFormat = strDisplayFormat.Replace("{" + i.ToString() + "}", value[i].ToString());
                }
                strReturn = strDisplayFormat;
            }
            else if (DataValidateManager.ValidateNumberFormat(objValue))
            {
                var number = Decimal.Parse(objValue.ToString());
                strReturn = number.ToString(strDisplayFormat);
            }
            else if (DataValidateManager.ValidateDateFormat(objValue))
            {
                strReturn = DateTime.Parse(objValue.ToString()).ToString(strDisplayFormat);
            }
            else
            {
                try
                {
                    char[] value = objValue.ToString().ToCharArray();
                    for (int i = 0; i < value.Length; i++)
                    {
                        strDisplayFormat = strDisplayFormat.Replace("{" + i.ToString() + "}", value[i].ToString());
                    }
                    strReturn = strDisplayFormat;
                }
                catch (Exception)
                {
                    strReturn = objValue.ToString();
                }
            }
            return strReturn;
        }

        protected byte[] GetImageData(FileUpload objFileUpload)
        {
            HttpPostedFile upPhoto = objFileUpload.PostedFile;
            int upPhotoLength = upPhoto.ContentLength;
            Stream fs = upPhoto.InputStream;
            byte[] imageData = new byte[upPhotoLength];
            fs.Read(imageData, 0, upPhotoLength);
            return imageData;
        }

        virtual public void RaiseCallbackEvent(string eventArgument)
        {
        }

        virtual public string GetCallbackResult()
        {
            return string.Empty;
        }


        protected Table GenerateHtmlTable(
            string strHeadText,
            string strContent,
            bool border = true,
            bool innerTable = false,
            string strTableCss = null,
            string strHeadCss = null,
            string strCellCss = null,
            string strTableWidth = null,
            string strCellWidth = null
            )
        {
            Table htTemp = new Table();
            strContent = strContent.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty);
            if (!DataValidateManager.ValidateIsNull(strTableCss))
            {
                htTemp.CssClass = strTableCss;
            }
            htTemp.CellPadding = 0;
            htTemp.CellSpacing = 0;
            htTemp.BorderWidth = 0;
            htTemp.Style.Add("width", "100%");

            string[] headText = strHeadText.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            TableRow htrHead = new TableRow();
            for (int i = 0; i < headText.Length; i++)
            {
                TableCell htc = new TableCell();
                htc.Text = headText[i];
                if (!DataValidateManager.ValidateIsNull(strHeadCss))
                {
                    htc.CssClass = strHeadCss;
                }
                htc.Style.Add("text-align", "center");
                htrHead.Cells.Add(htc);
            }
            htTemp.Rows.Add(htrHead);

            string[] rows = strContent.Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < rows.Length; index++)
            {
                TableRow htr = new TableRow();
                string[] fields = rows[index].Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                for (int i = 0; i < fields.Length && i < headText.Length; i++)
                {
                    TableCell htc = new TableCell();
                    htc.Text = fields[i];
                    if (!DataValidateManager.ValidateIsNull(strCellCss))
                    {
                        htc.CssClass = strCellCss;
                    }
                    htc.Style.Add("text-align", "center !important");
                    htr.Cells.Add(htc);
                }
                htTemp.Rows.Add(htr);
            }

            // ÉèÖÃinner table±ß¿ò
            if (htTemp.Rows.Count > 0)
            {
                for (int index = 0; index < htTemp.Rows.Count; index++)
                {
                    for (int i = 0; i < htTemp.Rows[index].Cells.Count; i++)
                    {
                        if (border && innerTable)
                        {
                            htTemp.Rows[index].Cells[i].Style.Add("border-top", index == 0 ? "0px black solid" : "1px black solid");
                            htTemp.Rows[index].Cells[i].Style.Add("border-left", i == 0 ? "0px black solid" : "1px black solid");
                            htTemp.Rows[index].Cells[i].Style.Add("border-bottom", index == htTemp.Rows.Count - 1 ? "0px black solid" : "1px black solid");
                            htTemp.Rows[index].Cells[i].Style.Add("border-right", i == headText.Length - 1 ? "0px black solid" : "1px black solid");
                        }
                        else if (border)
                        {
                            htTemp.Rows[index].Cells[i].Style.Add("border", "1px black solid");
                        }
                        else
                        {
                            htTemp.Rows[index].Cells[i].Style.Add("border", "0px black solid");
                        }
                    }
                }
            }
            return htTemp;
        }

        protected DataTable GenerateDataTable(
            string strColumnName,
            string strContent
            )
        {
            DataTable dtTemp = new DataTable();
            strContent = strContent.Replace("\r", string.Empty).Replace("\n", string.Empty).Replace(" ", string.Empty);
            string[] columnName = strColumnName.Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
            for (int i = 0; i < columnName.Length; i++)
            {
                dtTemp.Columns.Add(columnName[i]);
            }
            string[] rows = strContent.Split(new string[] { ConstantsManager.ItemSplitString }, StringSplitOptions.RemoveEmptyEntries);
            for (int index = 0; index < rows.Length; index++)
            {
                DataRow dr = dtTemp.NewRow();
                string[] fields = rows[index].Split(new string[] { ConstantsManager.FieldSplitString }, StringSplitOptions.None);
                for (int i = 0; i < fields.Length && i < columnName.Length; i++)
                {
                    dr[i] = fields[i];
                }
                dtTemp.Rows.Add(dr);
            }
            return dtTemp;
        }
    }
}
