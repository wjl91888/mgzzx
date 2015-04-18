using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using System.IO;

namespace DataModelApplication.Common
{
    class CommonFileLibrary
    {
        private string strFileName= string.Empty;

        public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }

        private DataTable dsXmlDataTable = new DataTable();

        public DataTable XmlDataTable
        {
            get
            {
                return dsXmlDataTable;
            }
            set
            {
                dsXmlDataTable = value;
            }
        }

        private DataSet dsXmlDataSet = new DataSet();
        public DataSet XmlDataSet
        {
            get
            {
                return dsXmlDataSet;
            }
            set
            {
                dsXmlDataSet = value;
            }
        }

        private DataGridView dsXmlDataGridView = new DataGridView();

        public DataGridView XmlDataGridView
        {
            get
            {
                return dsXmlDataGridView;
            }
            set
            {
                dsXmlDataGridView = value;
            }
        }


        //=====================================================================
        //  FunctionName : LoadXmlToDataTable
        /// <summary>
        /// ��XML�ļ���ȡΪDataTable����
        /// </summary>
        //=====================================================================
        public void LoadXmlToDataTable()
        {
            XmlDataTable.ReadXml(FileName);
            ConvertDataTableToDataGridView();
        }

        //=====================================================================
        //  FunctionName : SaveDataTableToXml
        /// <summary>
        /// ��DataTable���ݱ���ΪXML�ļ�
        /// </summary>
        //=====================================================================
        public void SaveDataTableToXml()
        {
            ConvertDataGridViewToDataTable();
            XmlDataTable.WriteXml(FileName, XmlWriteMode.WriteSchema);
        }


        //=====================================================================
        //  FunctionName : LoadXmlToDataSet
        /// <summary>
        /// ��XML�ļ���ȡΪDataTable����
        /// </summary>
        //=====================================================================
        public void LoadXmlToDataSet()
        {
            XmlDataSet.ReadXml(FileName);
        }

        //=====================================================================
        //  FunctionName : SaveDataSetToXml
        /// <summary>
        /// ��DataTable���ݱ���ΪXML�ļ�
        /// </summary>
        //=====================================================================
        public void SaveDataSetToXml()
        {
            XmlDataSet.WriteXml(FileName, XmlWriteMode.WriteSchema);
        }

        //=====================================================================
        //  FunctionName : ConvertDataGridViewToDataTable
        /// <summary>
        /// ��DataGridView����ת����DataTable����
        /// </summary>
        //=====================================================================
        public void ConvertDataGridViewToDataTable()
        {
            foreach (DataGridViewColumn dgvcTemp in XmlDataGridView.Columns)
            {
                if (dgvcTemp.ValueType == null)
                {
                    XmlDataTable.Columns.Add(dgvcTemp.Name);
                }
                else
                {
                    XmlDataTable.Columns.Add(dgvcTemp.Name, dgvcTemp.ValueType);
                }
            }
            foreach (DataGridViewRow dgvrTemp in XmlDataGridView.Rows)
            {
                DataRow drTemp = XmlDataTable.NewRow();
                foreach (DataGridViewCell dgvcTemp in dgvrTemp.Cells)
                {
                    if (dgvcTemp.Value == null)
                    {
                        if (dgvcTemp.ValueType == System.Type.GetType("System.Boolean"))
                        {
                            drTemp[dgvcTemp.ColumnIndex] = "false";
                        }
                        else
                        {
                            drTemp[dgvcTemp.ColumnIndex] = DBNull.Value;
                        }
                    }
                    else
                    {
                        drTemp[dgvcTemp.ColumnIndex] = dgvcTemp.Value;
                    }
                }
                XmlDataTable.Rows.Add(drTemp);
            }
        }

        //=====================================================================
        //  FunctionName : ConvertDataTableToDataGridView
        /// <summary>
        /// ��DataTable����ת����DataGridView����
        /// </summary>
        //=====================================================================
        public void ConvertDataTableToDataGridView()
        {
            //for (int i = 0; i < XmlDataTable.Rows.Count; i++)
            //{
            //    foreach (DataGridViewColumn dgvcTemp in XmlDataGridView.Columns)
            //    {
            //        if (dgvcTemp.ValueType == System.Type.GetType("System.Boolean"))
            //        {
            //            XmlDataGridView.Rows[i].Cells[dgvcTemp.Name].Value = XmlDataTable.Rows[i][dgvcTemp.Name] == DBNull.Value ? false : XmlDataTable.Rows[i][dgvcTemp.Name];
            //        }
            //        else
            //        {
            //            XmlDataGridView.Rows[i].Cells[dgvcTemp.Name].Value = XmlDataTable.Rows[i][dgvcTemp.Name];
            //        }
            //    }
            //} 
            for (int j = 0; j < XmlDataGridView.Rows.Count; j++)
            {
                for (int i = 0; i < XmlDataTable.Rows.Count; i++)
                {
                    if (XmlDataGridView.Rows[j].Cells[1].Value.ToString() == XmlDataTable.Rows[i][1].ToString())
                    {
                        foreach (DataGridViewColumn dgvcTemp in XmlDataGridView.Columns)
                        {
                            if (dgvcTemp.ValueType == System.Type.GetType("System.Boolean"))
                            {
                                try
                                {
                                    XmlDataGridView.Rows[j].Cells[dgvcTemp.Name].Value = XmlDataTable.Rows[i][dgvcTemp.Name] == DBNull.Value ? false : XmlDataTable.Rows[i][dgvcTemp.Name];
                                }
                                catch (Exception)
                                {
                                }
                            }
                            else
                            {
                                try
                                {
                                    XmlDataGridView.Rows[j].Cells[dgvcTemp.Name].Value = XmlDataTable.Rows[i][dgvcTemp.Name];

                                }
                                catch (Exception)
                                {
                                        
                                }
                            }
                        }
                    }
                }
            }
        }

        //=====================================================================
        //  FunctionName : CreateDirectory
        /// <summary>
        /// �����ļ�Ŀ¼
        /// </summary>
        //=====================================================================
        public static void CreateDirectory(string strFilePath)
        {
            if (Directory.Exists(strFilePath) == false)
            {
                DirectoryInfo dirInfo = Directory.CreateDirectory(strFilePath);
            }
        }

        //***************************************************** 
        //  Function Name:  CreateFile
        /// <summary>
        /// ����ָ���ļ������ļ�
        /// </summary>
        /// <param name="strFilePath">·��Ŀ¼��</param>
        /// <param name="strFileName">�����ļ���</param>
        /// <returns>
        /// </returns>
        //  Writer:         ���Z·
        //  Create Date:    2007/11/03
        //******************************************************
        public static void CreateFile(string strFilePath, string strFileName, string strFileContent)
        {
            string strFullName;
            FileStream fsObject;
            StreamWriter swCreateFile;
            CreateDirectory(strFilePath);
            strFullName = strFilePath + strFileName;
            if (File.Exists(strFullName) == true)
            {
                fsObject = new FileStream(strFullName, FileMode.Create);
            }
            else
            {
                fsObject = new FileStream(strFullName, FileMode.CreateNew);
            }
            swCreateFile = new StreamWriter(fsObject, System.Text.Encoding.GetEncoding("gb2312"));
            swCreateFile.WriteLine(strFileContent);
            swCreateFile.Close();
        }

        #region �ļ�ɾ������
        //***************************************************** 
        //  Function Name:  DeleteFile
        /// <summary>
        /// ɾ��ָ���ļ������ļ�
        /// </summary>
        /// <param name="strFilePath">·��Ŀ¼��</param>
        /// <param name="strFileName">ɾ���ļ���</param>
        /// <returns>
        /// </returns>
        //  Writer:         ���Z·
        //  Create Date:    2007/11/03
        //******************************************************
        public static void DeleteFile(string strFilePath, string strFileName)
        {
            string strFullName;
            CreateDirectory(strFilePath);
            strFullName = strFilePath + strFileName;
            if (File.Exists(strFullName) == true)
            {
                File.Delete(strFullName);
            }
        }

        #endregion

        #region �õ��ļ����ݺ���
        //***************************************************** 
        //  Function Name:  GetFileContent
        /// <summary>
        /// �õ�ָ���ļ������ļ�����
        /// </summary>
        /// <param name="strFilePath">·��Ŀ¼��</param>
        /// <param name="strFileName">�ļ���</param>
        /// <returns>
        /// </returns>
        //  Writer:         ���Z·
        //  Create Date:    2007/11/03
        //******************************************************
        public static string ReadFile(string strFilePath, string strFileName)
        {
            string strFullName;
            string strReturn = string.Empty;
            FileStream fsObject;
            StreamReader swReadFile;
            CreateDirectory(strFilePath);
            strFullName = strFilePath + strFileName;
            if (File.Exists(strFullName) == true)
            {
                fsObject = new FileStream(strFullName, FileMode.Open);
                swReadFile = new StreamReader(fsObject, System.Text.Encoding.GetEncoding("gb2312"));
                strReturn = swReadFile.ReadToEnd();
                swReadFile.Close();
            }
            return strReturn;
        }

        #endregion

        public static string GetFileName(string strFileFullName)
        {
            if (strFileFullName.LastIndexOf('.') >= 0)
            {
                return strFileFullName.Substring(0, strFileFullName.LastIndexOf('.'));
            }
            else
            {
                return strFileFullName;
            }
        }


        public static Boolean IsExistFile(string strFullName)
        {
            Boolean boolReturn;
            if (File.Exists(strFullName) == true)
            {
                boolReturn = true;
            }
            else
            {
                boolReturn = false;
            }
            return boolReturn;
        }

    }
}
