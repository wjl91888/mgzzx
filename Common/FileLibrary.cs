using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Microsoft.Office.Interop.Excel;
using DataTable = System.Data.DataTable;

namespace RICH.Common
{
    //****************************************************** 
    ///<summary>
    ///Module ID：FileLibrary
    ///Depiction：文件操作类库
    ///Author：     王璟路
    ///Create Date：2007/03/22
    ///Update Date：2012/02/17
    ///</summary>
    //******************************************************
    public class FileLibrary
    {
        #region 文件及目录操作
        //***************************************************** 
        //  Function Name:  CreateDirectory
        /// <summary>
        /// 生成指定虚拟路径所对应的物理路径目录
        /// </summary>
        /// <param name="strVirtualPath">虚拟路径目录名</param>
        /// <returns>
        /// </returns>
        //******************************************************
        public static void CreateDirectory(string strVirtualPath)
        {
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            if (Directory.Exists(strPhysicalPath) == false)
            {
                Directory.CreateDirectory(strPhysicalPath);
            }
        }

        //***************************************************** 
        //  Function Name:  CreateFile
        /// <summary>
        /// 生成指定文件名的文件
        /// </summary>
        /// <param name="strVirtualPath">虚拟路径目录名</param>
        /// <param name="strFileName">生成文件名</param>
        /// <returns />
        //******************************************************
        public static void CreateFile(string strVirtualPath, string strFileName, string strFileContent)
        {
            StreamWriter swCreateFile;
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            CreateDirectory(strVirtualPath);
            string strFullName = strPhysicalPath + strFileName;
            FileStream fsObject = File.Exists(strFullName) ? new FileStream(strFullName, FileMode.Create) : new FileStream(strFullName, FileMode.CreateNew);
            swCreateFile = new StreamWriter(fsObject, System.Text.Encoding.GetEncoding("gb2312"));
            swCreateFile.WriteLine(strFileContent);
            swCreateFile.Close();
        }

        public static void CreateFileAppend(string strVirtualPath, string strFileName, string strFileContent)
        {
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            CreateDirectory(strVirtualPath);
            string strFullName = strPhysicalPath + strFileName;
            FileStream fsObject = File.Exists(strFullName) ? new FileStream(strFullName, FileMode.Append) : new FileStream(strFullName, FileMode.CreateNew);
            StreamWriter swCreateFile = new StreamWriter(fsObject, System.Text.Encoding.GetEncoding("gb2312"));
            swCreateFile.WriteLine(strFileContent);
            swCreateFile.Close();
        }

        //***************************************************** 
        //  Function Name:  DeleteFile
        /// <summary>
        /// 删除指定文件名的文件
        /// </summary>
        /// <param name="strVirtualPath">虚拟路径目录名</param>
        /// <param name="strFileName">删除文件名</param>
        /// <returns>
        /// </returns>
        //******************************************************
        public static void DeleteFile(string strVirtualPath, string strFileName)
        {
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            CreateDirectory(strVirtualPath);
            string strFullName = strPhysicalPath + strFileName;
            if (File.Exists(strFullName))
            {
                File.Delete(strFullName);
            }
        }

        //***************************************************** 
        //  Function Name:  GetFileContent
        /// <summary>
        /// 得到指定文件名的文件内容
        /// </summary>
        /// <param name="strVirtualPath">虚拟路径目录名</param>
        /// <param name="strFileName">文件名</param>
        /// <returns>
        /// </returns>
        //******************************************************
        public static string ReadFile(string strVirtualPath, string strFileName)
        {
            string strReturn = string.Empty;
            StreamReader swReadFile;
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            CreateDirectory(strVirtualPath);
            string strFullName = strPhysicalPath + strFileName;
            if (File.Exists(strFullName))
            {
                FileStream fsObject = new FileStream(strFullName, FileMode.Open);
                swReadFile = new StreamReader(fsObject, System.Text.Encoding.GetEncoding("gb2312"));
                strReturn = swReadFile.ReadToEnd();
                swReadFile.Close();
            }
            return strReturn;
        }

        public static bool IsFileExist(string strVirtualPath, string strFileName)
        {
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            string strFullName = strPhysicalPath + strFileName;
            return File.Exists(strFullName);
        }

        public static string RenameFile(string strVirtualPath, string strFileName, string strNewFileName)
        {
            string strReturn = string.Empty;
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            string strSourceFullName = strPhysicalPath + strFileName;
            string strDestFullName = strPhysicalPath + strNewFileName;
            if (File.Exists(strSourceFullName) && File.Exists(strDestFullName) == false)
            {
                File.Move(strSourceFullName, strDestFullName);
            }
            return strReturn;
        }

        public static string GetFilePath(string strFileFullName)
        {
            return strFileFullName.LastIndexOf('/') >= 0x0 ? strFileFullName.Substring(0, strFileFullName.LastIndexOf('/') + 1) : "/";
        }

        public static string GetFileName(string strFileFullName)
        {
            return strFileFullName.LastIndexOf('/') >= 0
                       ? strFileFullName.Substring(strFileFullName.LastIndexOf('/') + 1)
                       : (strFileFullName.LastIndexOf('\\') >= 0
                              ? strFileFullName.Substring(strFileFullName.LastIndexOf('\\') + 1)
                              : strFileFullName);
        }

        public static string GetTextFileContent(string strFileName)
        {
            if (File.Exists(strFileName))
            {
                StreamReader sr = File.OpenText(strFileName);
                string strReturn = sr.ReadToEnd();
                sr.Close();
                return strReturn;
            }
            return null;
        }
        public static string GetFileExtName(string strFileFullName)
        {
            return strFileFullName.LastIndexOf('.') >= 0
                       ? strFileFullName.Substring(strFileFullName.LastIndexOf('.') + 1)
                       : string.Empty;
        }

        public static DataTable GetDirectoryList(string strVirtualPath)
        {
            using (DataTable dtList = new DataTable())
            {
                // 得到指定虚拟目录的物理路径
                string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
                // 得到指定路径下的目录
                if (strPhysicalPath != null)
                {
                    string[] arrDirectoryList = Directory.GetDirectories(strPhysicalPath);
                    // 得到指定路径下的文件
                    string[] arrFileList = Directory.GetFiles(strPhysicalPath);
                    // 初始化列表DataTable结构
                    dtList.Columns.Add("IsDirectory");
                    dtList.Columns.Add("FileName");
                    dtList.Columns.Add("FilePath");
                    dtList.Columns.Add("FileType");
                    dtList.Columns.Add("FileSize");
                    dtList.Columns.Add("LastUpdateDate");
                    // 将列出目录存入DataTable
                    foreach (string strDirectory in arrDirectoryList)
                    {
                        DataRow drList = dtList.NewRow();
                        drList["IsDirectory"] = "1";
                        drList["FileName"] = FileLibrary.GetFileName(strDirectory);
                        drList["FilePath"] = strVirtualPath;
                        drList["FileType"] = "文件夹";
                        drList["FileSize"] = "";
                        drList["LastUpdateDate"] = Directory.GetLastWriteTime(strDirectory);
                        dtList.Rows.Add(drList);
                    }
                    // 将列出文件存入DataTable
                    foreach (string strFile in arrFileList)
                    {
                        DataRow drList = dtList.NewRow();
                        drList["IsDirectory"] = "0";
                        drList["FileName"] = FileLibrary.GetFileName(strFile);
                        drList["FilePath"] = strVirtualPath;
                        drList["FileType"] = "文件";
                        drList["FileSize"] = new FileInfo(strFile).Length / 1024;
                        drList["LastUpdateDate"] = File.GetLastWriteTime(strFile);
                        dtList.Rows.Add(drList);
                    }
                }
                return dtList;
            }
        }
        #endregion 文件及目录操作

        #region 文件导出及下载
        public static void ExportToExcelFile(Control gw, string filename)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
            HttpContext.Current.Response.Charset = "GB2312";
            // If you want the option to open the Excel file without saving than
            // comment out the line below
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new System.IO.StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //ClearControls(gw);
            gw.RenderControl(htmlWrite);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportToWordFile(Control gw, string filename)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc");
            HttpContext.Current.Response.Charset = "GB2312";
            // If you want the option to open the Excel file without saving than
            // comment out the line below
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/vnd.doc";
            StringWriter stringWrite = new System.IO.StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            //ClearControls(gw);
            gw.RenderControl(htmlWrite);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportToExcelFileWithoutControl(Control gw, string filename)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".xls");
            HttpContext.Current.Response.Charset = "GB2312";
            // If you want the option to open the Excel file without saving than
            // comment out the line below
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/vnd.xls";
            StringWriter stringWrite = new System.IO.StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            ClearControls(gw);
            gw.RenderControl(htmlWrite);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ExportToWordFileWithoutControl(Control gw, string filename)
        {
            HttpContext.Current.Response.Clear();
            HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + filename + DateTime.Now.ToString("yyyyMMddhhmmss") + ".doc");
            HttpContext.Current.Response.Charset = "GB2312";
            // If you want the option to open the Excel file without saving than
            // comment out the line below
            //Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
            HttpContext.Current.Response.ContentType = "application/vnd.doc";
            StringWriter stringWrite = new System.IO.StringWriter();
            HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);
            ClearControls(gw);
            gw.RenderControl(htmlWrite);
            HttpContext.Current.Response.Write(stringWrite.ToString());
            HttpContext.Current.Response.End();
        }

        public static void ClearControls(Control control)
        {
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                ClearControls(control.Controls[i]);
            }
            if (!(control is TableCell))
            {
                if (control.GetType().GetProperty("SelectedItem") != null)
                {
                    LiteralControl literal = new LiteralControl();
                    control.Parent.Controls.Add(literal);
                    try
                    {
                        literal.Text = (string)control.GetType().GetProperty("SelectedItem").GetValue(control, null);
                    }
                    catch
                    {
                    }
                    control.Parent.Controls.Remove(control);
                }
                else
                {
                    if (control.GetType().GetProperty("Text") != null)
                    {
                        LiteralControl literal = new LiteralControl();
                        control.Parent.Controls.Add(literal);
                        literal.Text = (string)control.GetType().GetProperty("Text").GetValue(control, null);
                        control.Parent.Controls.Remove(control);
                    }
                }
            }
            return;
        }

        public static void DownloadFile(string strDownloadFileName, string strRenameFileName)
        {
            string strFileExtName = strDownloadFileName.Split('.')[1].ToLowerInvariant();

            FileInfo file = new FileInfo(System.Web.HttpContext.Current.Server.MapPath(strDownloadFileName));
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名 
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(strRenameFileName + "." + strFileExtName, System.Text.Encoding.UTF8));
            // 添加头信息，指定文件大小，让浏览器能够显示下载进度 
            HttpContext.Current.Response.AddHeader("Content-Length", file.Length.ToString());
            // 指定返回的是一个不能被客户端读取的流，必须被下载 
            HttpContext.Current.Response.ContentType = GetContentType(strFileExtName);
            // 把文件流发送到客户端 
            HttpContext.Current.Response.WriteFile(file.FullName);
            // 停止页面的执行 
            HttpContext.Current.Response.End();
        }

        public static void DownloadTextFile(string strFileName, string strExtFileName , string strFileContent)
        {
            HttpContext.Current.Response.Charset = "utf-8";
            HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;

            // 添加头信息，为"文件下载/另存为"对话框指定默认文件名 
            HttpContext.Current.Response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(strFileName + "." + strExtFileName, System.Text.Encoding.UTF8));
            // 指定返回的是一个不能被客户端读取的流，必须被下载 
            HttpContext.Current.Response.ContentType = GetContentType(strExtFileName);
            // 把文件流发送到客户端 
            HttpContext.Current.Response.Write(strFileContent);
            // 停止页面的执行 
            HttpContext.Current.Response.End();
        }

        public static string GetContentType(string strFileExtName)
        {
            string strReturn;
            switch (strFileExtName)
            {
                case "ez": strReturn = "application/andrew-inset"; break;
                case "hqx": strReturn = "application/mac-binhex40"; break;
                case "cpt": strReturn = "application/mac-compactpro"; break;
                case "doc": strReturn = "application/msword"; break;
                case "bin": strReturn = "application/octet-stream"; break;
                case "dms": strReturn = "application/octet-stream"; break;
                case "lha": strReturn = "application/octet-stream"; break;
                case "lzh": strReturn = "application/octet-stream"; break;
                case "exe": strReturn = "application/octet-stream"; break;
                case "class": strReturn = "application/octet-stream"; break;
                case "so": strReturn = "application/octet-stream"; break;
                case "dll": strReturn = "application/octet-stream"; break;
                case "oda": strReturn = "application/oda"; break;
                case "pdf": strReturn = "application/pdf"; break;
                case "ai": strReturn = "application/postscript"; break;
                case "eps": strReturn = "application/postscript"; break;
                case "ps": strReturn = "application/postscript"; break;
                case "smi": strReturn = "application/smil"; break;
                case "smil": strReturn = "application/smil"; break;
                case "mif": strReturn = "application/vnd.mif"; break;
                case "xls": strReturn = "application/vnd.ms-excel"; break;
                case "ppt": strReturn = "application/vnd.ms-powerpoint"; break;
                case "wbxml": strReturn = "application/vnd.wap.wbxml"; break;
                case "wmlc": strReturn = "application/vnd.wap.wmlc"; break;
                case "wmlsc": strReturn = "application/vnd.wap.wmlscriptc"; break;
                case "bcpio": strReturn = "application/x-bcpio"; break;
                case "vcd": strReturn = "application/x-cdlink"; break;
                case "pgn": strReturn = "application/x-chess-pgn"; break;
                case "cpio": strReturn = "application/x-cpio"; break;
                case "csh": strReturn = "application/x-csh"; break;
                case "dcr": strReturn = "application/x-director"; break;
                case "dir": strReturn = "application/x-director"; break;
                case "dxr": strReturn = "application/x-director"; break;
                case "dvi": strReturn = "application/x-dvi"; break;
                case "spl": strReturn = "application/x-futuresplash"; break;
                case "gtar": strReturn = "application/x-gtar"; break;
                case "hdf": strReturn = "application/x-hdf"; break;
                case "js": strReturn = "application/x-javascript"; break;
                case "skp": strReturn = "application/x-koan"; break;
                case "skd": strReturn = "application/x-koan"; break;
                case "skt": strReturn = "application/x-koan"; break;
                case "skm": strReturn = "application/x-koan"; break;
                case "latex": strReturn = "application/x-latex"; break;
                case "nc": strReturn = "application/x-netcdf"; break;
                case "cdf": strReturn = "application/x-netcdf"; break;
                case "sh": strReturn = "application/x-sh"; break;
                case "shar": strReturn = "application/x-shar"; break;
                case "swf": strReturn = "application/x-shockwave-flash"; break;
                case "sit": strReturn = "application/x-stuffit"; break;
                case "sv4cpio": strReturn = "application/x-sv4cpio"; break;
                case "sv4crc": strReturn = "application/x-sv4crc"; break;
                case "tar": strReturn = "application/x-tar"; break;
                case "tcl": strReturn = "application/x-tcl"; break;
                case "tex": strReturn = "application/x-tex"; break;
                case "texinfo": strReturn = "application/x-texinfo"; break;
                case "texi": strReturn = "application/x-texinfo"; break;
                case "t": strReturn = "application/x-troff"; break;
                case "tr": strReturn = "application/x-troff"; break;
                case "roff": strReturn = "application/x-troff"; break;
                case "man": strReturn = "application/x-troff-man"; break;
                case "me": strReturn = "application/x-troff-me"; break;
                case "ms": strReturn = "application/x-troff-ms"; break;
                case "ustar": strReturn = "application/x-ustar"; break;
                case "src": strReturn = "application/x-wais-source"; break;
                case "xhtml": strReturn = "application/xhtml+xml"; break;
                case "xht": strReturn = "application/xhtml+xml"; break;
                case "zip": strReturn = "application/zip"; break;
                case "au": strReturn = "audio/basic"; break;
                case "snd": strReturn = "audio/basic"; break;
                case "mid": strReturn = "audio/midi"; break;
                case "midi": strReturn = "audio/midi"; break;
                case "kar": strReturn = "audio/midi"; break;
                case "mpga": strReturn = "audio/mpeg"; break;
                case "mp2": strReturn = "audio/mpeg"; break;
                case "mp3": strReturn = "audio/mpeg"; break;
                case "aif": strReturn = "audio/x-aiff"; break;
                case "aiff": strReturn = "audio/x-aiff"; break;
                case "aifc": strReturn = "audio/x-aiff"; break;
                case "m3u": strReturn = "audio/x-mpegurl"; break;
                case "ram": strReturn = "audio/x-pn-realaudio"; break;
                case "rm": strReturn = "audio/x-pn-realaudio"; break;
                case "rpm": strReturn = "audio/x-pn-realaudio-plugin"; break;
                case "ra": strReturn = "audio/x-realaudio"; break;
                case "wav": strReturn = "audio/x-wav"; break;
                case "pdb": strReturn = "chemical/x-pdb"; break;
                case "xyz": strReturn = "chemical/x-xyz"; break;
                case "bmp": strReturn = "image/bmp"; break;
                case "gif": strReturn = "image/gif"; break;
                case "ief": strReturn = "image/ief"; break;
                case "jpeg": strReturn = "image/jpeg"; break;
                case "jpg": strReturn = "image/jpeg"; break;
                case "jpe": strReturn = "image/jpeg"; break;
                case "png": strReturn = "image/png"; break;
                case "tiff": strReturn = "image/tiff"; break;
                case "tif": strReturn = "image/tiff"; break;
                case "djvu": strReturn = "image/vnd.djvu"; break;
                case "djv": strReturn = "image/vnd.djvu"; break;
                case "wbmp": strReturn = "image/vnd.wap.wbmp"; break;
                case "ras": strReturn = "image/x-cmu-raster"; break;
                case "pnm": strReturn = "image/x-portable-anymap"; break;
                case "pbm": strReturn = "image/x-portable-bitmap"; break;
                case "pgm": strReturn = "image/x-portable-graymap"; break;
                case "ppm": strReturn = "image/x-portable-pixmap"; break;
                case "rgb": strReturn = "image/x-rgb"; break;
                case "xbm": strReturn = "image/x-xbitmap"; break;
                case "xpm": strReturn = "image/x-xpixmap"; break;
                case "xwd": strReturn = "image/x-xwindowdump"; break;
                case "igs": strReturn = "model/iges"; break;
                case "iges": strReturn = "model/iges"; break;
                case "msh": strReturn = "model/mesh"; break;
                case "mesh": strReturn = "model/mesh"; break;
                case "silo": strReturn = "model/mesh"; break;
                case "wrl": strReturn = "model/vrml"; break;
                case "vrml": strReturn = "model/vrml"; break;
                case "css": strReturn = "text/css"; break;
                case "html": strReturn = "text/html"; break;
                case "htm": strReturn = "text/html"; break;
                case "asc": strReturn = "text/plain"; break;
                case "txt": strReturn = "text/plain"; break;
                case "rtx": strReturn = "text/richtext"; break;
                case "rtf": strReturn = "text/rtf"; break;
                case "sgml": strReturn = "text/sgml"; break;
                case "sgm": strReturn = "text/sgml"; break;
                case "tsv": strReturn = "text/tab-separated-values"; break;
                case "wml": strReturn = "text/vnd.wap.wml"; break;
                case "wmls": strReturn = "text/vnd.wap.wmlscript"; break;
                case "etx": strReturn = "text/x-setext"; break;
                case "xsl": strReturn = "text/xml"; break;
                case "xml": strReturn = "text/xml"; break;
                case "mpeg": strReturn = "video/mpeg"; break;
                case "mpg": strReturn = "video/mpeg"; break;
                case "mpe": strReturn = "video/mpeg"; break;
                case "qt": strReturn = "video/quicktime"; break;
                case "mov": strReturn = "video/quicktime"; break;
                case "mxu": strReturn = "video/vnd.mpegurl"; break;
                case "avi": strReturn = "video/x-msvideo"; break;
                case "movie": strReturn = "video/x-sgi-movie"; break;
                case "ice": strReturn = "x-conference/x-cooltalk"; break;
                default: strReturn = "application/octet-stream"; break;
            }
            return strReturn;
        }
        #endregion 文件导出及下载

        #region Word文件导入
        public static DataTable GetDataFromWord(string strVirtualPath, string strFileName, DataTable dt, bool afterDelete = false)
        {
            string strPhysicalPath = HostingEnvironment.MapPath(strVirtualPath);
            string strFullName = strPhysicalPath + strFileName;
            return GetDataFromWord(strFullName, dt, false, afterDelete);
        }

        public static DataTable GetDataFromWordBatch(string strFilePath, DataTable dt, bool boolVirtual = false ,bool afterDelete = false)
        {
            string strPhysicalPath;
            // 得到指定虚拟目录的物理路径
            strPhysicalPath = boolVirtual ? HostingEnvironment.MapPath(strFilePath) : strFilePath;
            // 得到指定路径下的目录
            if (Directory.Exists(strPhysicalPath))
            {
                // 得到指定路径下的文件
                string[] arrFileList = Directory.GetFiles(strPhysicalPath, "*.doc");
                foreach (string strFileName in arrFileList)
                {
                    dt = GetDataFromWord(strFileName, dt, false, afterDelete);
                }
                arrFileList = Directory.GetFiles(strPhysicalPath, "*.docx");
                foreach (string strFileName in arrFileList)
                {
                    dt = GetDataFromWord(strFileName, dt, false, afterDelete);
                }
            }
            return dt;
        }

        public static DataTable GetDataFromWord(string strFileName, DataTable dt, bool boolVirtual = false, bool afterDelete = false)
        {
            string strPhysicalFilrName = boolVirtual ? HostingEnvironment.MapPath(strFileName) : strFileName;
            if (File.Exists(strPhysicalFilrName))
            {
                int[] intIndex = {0, 0, 0};
                object oFileName = strPhysicalFilrName;
                object oReadOnly = true;
                object oMissing = System.Reflection.Missing.Value;
                Microsoft.Office.Interop.Word._Application oWord;
                Microsoft.Office.Interop.Word._Document oDoc;
                oWord = new Microsoft.Office.Interop.Word.Application();
                oDoc = oWord.Documents.Open(ref oFileName, ref oMissing, ref oReadOnly, ref oMissing,
                                            ref oMissing,
                                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                            ref oMissing, ref oMissing);
                try
                {
                    DataRow dr = dt.NewRow();
                    foreach (DataColumn col in dt.Columns)
                    {
                        string[] index = col.ColumnName.Split(new char[] {'_'});
                        if (index.Length == 3)
                        {
                            if (int.TryParse(index[0], out intIndex[0]) && int.TryParse(index[1], out intIndex[1]) &&
                                int.TryParse(index[2], out intIndex[2]))
                            {
                                string text = oDoc.Tables[intIndex[0]].Cell(intIndex[1], intIndex[2]).Range.Text;
                                text = text.Remove(text.Length - 2, 2); //remove \r\a
                                dr[col.ColumnName] = text;
                            }
                        }
                    }
                    oDoc.Close();
                    dt.Rows.Add(dr);
                    CreateFileAppend
                        (
                            ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Log/",
                            String.Format("IMPORT_WORD_{0}.log", DateTime.Now.Date.ToString("yyyyMMdd")),
                            String.Format("文件'{0}'数据获取成功，时间：{1}。\r\n", strFileName, DateTime.Now)
                        );
                }
                catch (Exception ex)
                {
                    if (oDoc != null)
                    {
                        oDoc.Close();
                    }
                    CreateFileAppend
                        (
                            ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Log/",
                            String.Format("IMPORT_WORD_{0}.log", DateTime.Now.Date.ToString("yyyyMMdd")),
                            String.Format("文件'{0}'数据Table{1}Row{2}Cell{3}获取失败，时间：{4}，请检查数据格式。\r\n详细错误信息：{5}\r\n",
                                          strFileName, intIndex[0], intIndex[1], intIndex[2], DateTime.Now, ex.Message)
                        );
                }
                oWord.Quit();
                if (afterDelete)
                {
                    File.Delete(strPhysicalFilrName);
                }
            }
            return dt;
        }

        public static string GetWordPreview(string strFileName, bool boolVirtual = false, bool afterDelete = false)
        {
            string strPhysicalFilrName = boolVirtual ? HostingEnvironment.MapPath(strFileName) : strFileName;
            string strReturn = string.Empty;
            if (File.Exists(strPhysicalFilrName))
            {
                object oFileName = strPhysicalFilrName;
                object oReadOnly = true;
                object oMissing = System.Reflection.Missing.Value;

                Microsoft.Office.Interop.Word._Application oWord;
                Microsoft.Office.Interop.Word._Document oDoc;
                oWord = new Microsoft.Office.Interop.Word.Application();
                oDoc = oWord.Documents.Open(ref oFileName, ref oMissing, ref oReadOnly, ref oMissing, ref oMissing,
                                            ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                            ref oMissing, ref oMissing);
                string tableMessage = string.Empty;
                for (int tablePos = 1; tablePos <= oDoc.Tables.Count; tablePos++)
                {
                    Microsoft.Office.Interop.Word.Table nowTable = oDoc.Tables[tablePos];
                    tableMessage = tableMessage + string.Format("<br/>第{0}/{1}个表:<br/>", tablePos, oDoc.Tables.Count);

                    for (int i = 1; i <= nowTable.Rows.Count; i++)
                    {
                        for (int j = 1; j <= nowTable.Columns.Count; j++)
                        {
                            try
                            {
                                string text = nowTable.Cell(i, j).Range.Text;
                                tableMessage = tableMessage + text;
                                tableMessage = tableMessage.Remove(tableMessage.Length - 2, 2); //remove \r\a
                                tableMessage = tableMessage + "(" + tablePos + "," + i + "," + j + ")";
                                tableMessage = tableMessage + "<br/>";
                            }
                            catch (Exception)
                            {
                                continue;
                            }
                        }
                        tableMessage = tableMessage + "<br/>";
                    }
                }
                strReturn = tableMessage.Replace("\r", "<br/>");
                oDoc.Close();
                oWord.Quit();
                if (afterDelete)
                {
                    File.Delete(strPhysicalFilrName);
                }
            }
            return strReturn;
        }
        #endregion Word文件导入

        #region Excel文件导入

        public static DataTable ConvertDataFileToDataTable(string strFileName, bool boolVirtual = false, bool afterDelete = false, int recordStartLine = 2)
        {
            if (strFileName.IsHtmlNullOrWiteSpace())
            {
                throw new Exception("需导入的文件不存在，请重新选择。");
            }
            string filefullname = boolVirtual ? HostingEnvironment.MapPath(strFileName) : strFileName;
            if (File.Exists(filefullname))
            {
                try
                {
                    string filename = Path.GetFileName(filefullname);
                    string filenamewithoutext = Path.GetFileNameWithoutExtension(filefullname);
                    string filepath = Path.GetDirectoryName(filefullname) + @"\";
                    string filetype = Path.GetExtension(filefullname).ToLower();
                    string csvFileName = "{0}{1}.csv".FormatInvariantCulture(filepath, filenamewithoutext);
                    switch (filetype)
                    {
                        case ".xls":
                        case ".xlsx":
                            var app = new Application();
                            var missing = Type.Missing;
                            var wb = app.Workbooks.Open(filefullname, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
                            var ws = (Worksheet)app.Worksheets.get_Item(1);
                            ws.SaveAs(csvFileName, XlFileFormat.xlCSV, missing, missing, false, false, false, missing, missing, false);
                            wb.Close(false, missing, missing);
                            app.Quit();
                            File.Delete(filefullname);
                            break;
                        case ".csv":
                        case ".txt":
                            csvFileName = filefullname;
                            break;
                        default:
                            csvFileName = string.Empty;
                            break;
                    }
                    if (File.Exists(csvFileName))
                    {
                        var dt = new DataTable("filename");
                        String[] split = null;
                        DataRow row = null;
                        string[] columnNames = null;
                        using (StreamReader sr = new StreamReader(csvFileName, System.Text.Encoding.Default))
                        {
                            string record = sr.ReadToEnd();
                            var arrayList = SplitCSV(record);
                            if (arrayList.Count == 0)
                            {
                                throw new Exception("需导入的文件无数据，请重新选择。");
                            }
                            columnNames = ((ArrayList)arrayList[0]).ToStringArray();
                            for (int i = 1; i < recordStartLine - 1; i++)
                            {
                                split = ((ArrayList)arrayList[i]).ToStringArray();
                                for (int j = 0; j < split.Length; j++)
                                {
                                    if (!split[j].IsNullOrWhiteSpace())
                                    {
                                        columnNames[j] = split[j];
                                    }
                                }
                            }
                            foreach (String colname in columnNames)
                            {
                                dt.Columns.Add(colname, System.Type.GetType("System.String"));
                            }
                            arrayList.RemoveRange(0, recordStartLine - 1);
                            int columnIndex = 0;
                            foreach (ArrayList data in arrayList)
                            {
                                columnIndex = 0;
                                split = data.ToStringArray();
                                row = dt.NewRow();
                                foreach (String colname in split)
                                {
                                    row[columnIndex] = colname;
                                    columnIndex++;
                                }
                                dt.Rows.Add(row);
                            }
                        }
                        if (afterDelete)
                        {
                            File.Delete(csvFileName);
                        }
                        return dt;
                    }
                }
                catch (Exception ex)
                {
                    CreateFileAppend
                        (
                            ConstantsManager.WEBSITE_VIRTUAL_ROOT_DIR + "/Log/",
                            String.Format("IMPORT_Excel_{0}.log", DateTime.Now.Date.ToString("yyyyMMdd")),
                            String.Format("文件'{0}'数据获取失败，时间：{1}，请检查数据格式。\r\n详细错误信息：{2}\r\n", strFileName, DateTime.Now, ex.Message)
                        );
                    throw ex;
                }
            }
            return new DataTable();
        }

        public static ArrayList SplitCSV(string record)
        {
            char[] s = record.ToCharArray();
            System.Text.StringBuilder strCol = new System.Text.StringBuilder();
            ArrayList arLne = new ArrayList();
            ArrayList arAll = new ArrayList();
            int cnter = 0;
            foreach (char t in s)
            {
                switch (t)
                {
                    case '\"':
                        cnter++;
                        strCol.Append(t);
                        break;
                    case ',':
                        if (IsColumeOver(cnter))
                        {
                            cnter = 0;
                            arLne.Add(strCol);
                            strCol = new System.Text.StringBuilder();
                        }
                        else
                        {
                            strCol.Append(t);
                        }
                        break;
                    case '\r':
                        if (IsLineOver(cnter))
                        {
                            cnter = 0;
                            arLne.Add(strCol);
                            strCol = new System.Text.StringBuilder();
                            arAll.Add(arLne);
                            arLne = new ArrayList();
                        }
                        else
                        {
                            strCol.Append(t);
                        }
                        break;
                    default:
                        strCol.Append(t);
                        break;
                }
            }
            return arAll;
        }

        private static bool IsColumeOver(int cnter)
        {
            return System.Math.IEEERemainder((double)cnter, 2) == 0;
        }

        private static bool IsLineOver(int cnter)
        {
            return System.Math.IEEERemainder((double)cnter, 2) == 0;
        }
        #endregion Excel文件导入

    }
}