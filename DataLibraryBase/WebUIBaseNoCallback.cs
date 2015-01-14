using System;
using System.Web;
using System.Web.UI.WebControls;
using RICH.Common.Base.ApplicationLogic;

namespace RICH.Common.Base.WebUI
{
    public abstract class WebUIBaseNoCallBack : System.Web.UI.Page
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
            string strReturn = string.Empty;
            try
            {
                if (objValue != DBNull.Value)
                {
                    strReturn = objValue.ToString();
                }
                else if (objValue != null)
                {
                    strReturn = objValue.ToString();
                }
                else if (objValue.ToString() != "")
                {
                    strReturn = objValue.ToString();
                }
            }
            catch (Exception)
            {
                strReturn = string.Empty;
            }
            return strReturn;
        }


        protected byte[] GetImageData(FileUpload objFileUpload)
        {
            HttpPostedFile upPhoto = objFileUpload.PostedFile;
            int upPhotoLength = upPhoto.ContentLength;
            System.IO.Stream fs = upPhoto.InputStream;
            byte[] imageData = new byte[upPhotoLength];
            fs.Read(imageData, 0, upPhotoLength);
            return imageData;
        }
    }
}
