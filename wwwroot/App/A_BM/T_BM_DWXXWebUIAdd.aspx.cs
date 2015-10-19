/****************************************************** 
FileName:T_BM_DWXXWebUIAddForApp.aspx.cs
******************************************************/
using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using RICH.Common;
using RICH.Common.LM;
using RICH.Common.BM.T_BM_DWXX;

namespace App
{
    public partial class T_BM_DWXXWebUIAdd : RICH.Common.BM.T_BM_DWXX.T_BM_DWXXWebUI
    {
        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void Page_Init(object sender, EventArgs e)
        {
            base.Page_Init(sender, e);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack != true)
            {
                // ��ʼ��������
                InitalizeDataBind();
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
                // ȫ�ֳ�ʼ��
                Initalize();
            }
            else
            {
                // ��ʼ����ϰ�����
                InitalizeCoupledDataSource();
            }
            base.Page_Load(sender, e);
        }

        protected override void Initalize()
        {
            // ��ʼ������
    

            // ����ؼ�״̬
            if(ViewMode || EditMode || CopyMode)
            {
                // ��ȡҪ�޸ļ�¼��ϸ����
                appData = new T_BM_DWXXApplicationData
                              {
                                  ObjectID = base.ObjectID,
                                  OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID
                              };
                QueryRecord();
                // �ؼ���ֵ
                if (appData.RecordCount > 0)
                {
    ObjectID.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]); 
                        DWBH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DWBH"]); 
                        DWMC.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DWMC"]); 
                        SJDWBH.SelectedValue = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJDWBH"]); 
                        DZ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["DZ"]); 
                        YB.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["YB"]); 
                        LXBM.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXBM"]); 
                        LXDH.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXDH"]); 
                        Email.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["Email"]); 
                        LXR.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["LXR"]); 
                        SJ.Text = GetValue(appData.ResultSet.Tables[0].Rows[0]["SJ"]); 
                        
                }
            }
                if (AddMode)
                {
                    // ��ʼ���������
    
                    // ��ʼ��Ĭ��ֵ
    
                }
    
        }
    
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (EditMode)
            {
                btnModifyConfirm_Click(sender, e);
            }
            else if(CopyMode || AddMode)
            {
                btnAddConfirm_Click(sender, e);
            }
        }

        //=====================================================================
        //  FunctionName : InitalizeDataBind
        /// <summary>
        /// ��ʼ�����ݰ�
        /// </summary>
        //=====================================================================
        protected void InitalizeDataBind()
        {
    
            // ��ʼ���ϼ���λ(SJDWBH)�����б�
              SJDWBH.DataSource = GetDataSource_SJDWBH();
            SJDWBH.DataTextField = "DWMC";
            SJDWBH.DataValueField = "DWBH";
                  SJDWBH.DataBind();
            SJDWBH.Items.Insert(0, new ListItem("��ѡ���ϼ���λ", ""));
                  
        }

        //=====================================================================
        //  FunctionName : GetAddInputParameter
        /// <summary>
        /// �õ�����û������������
        /// </summary>
        //=====================================================================
        protected override Boolean GetAddInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // ��֤�������
    
            validateData = ValidateDWMC(DWMC.Text, false, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.DWMC = Convert.ToString(validateData.Value.ToString());
                }
                DWMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DWMC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
                }
                SJDWBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJDWBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateDZ(DZ.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.DZ = Convert.ToString(validateData.Value.ToString());
                }
                DZ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DZ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateYB(YB.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.YB = Convert.ToString(validateData.Value.ToString());
                }
                YB.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                YB.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXBM(LXBM.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.LXBM = Convert.ToString(validateData.Value.ToString());
                }
                LXBM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXBM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXDH(LXDH.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.LXDH = Convert.ToString(validateData.Value.ToString());
                }
                LXDH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXDH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateEmail(Email.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.Email = Convert.ToString(validateData.Value.ToString());
                }
                Email.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                Email.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXR(LXR.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.LXR = Convert.ToString(validateData.Value.ToString());
                }
                LXR.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXR.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJ(SJ.Text, true, false);
            if (validateData.Result)
            {                
                if (!validateData.IsNull)
                {
                    appData.SJ = Convert.ToString(validateData.Value.ToString());
                }
                SJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            // �Զ����ɱ��
    T_BM_DWXXApplicationLogic instanceT_BM_DWXXApplicationLogic
                = (T_BM_DWXXApplicationLogic)CreateApplicationLogicInstance(typeof(T_BM_DWXXApplicationLogic));
            appData.DWBH = instanceT_BM_DWXXApplicationLogic.AutoGenerateDWBH(appData);
                    
            return boolReturn;
        }

        //=====================================================================
        //  FunctionName : GetModifyInputParameter
        /// <summary>
        /// �õ��޸��û������������
        /// </summary>
        //=====================================================================
        protected override Boolean GetModifyInputParameter()
        {
            Boolean boolReturn = true;
            ValidateData validateData = new ValidateData();
            // ��֤�������
            appData = RICH.Common.BM.T_BM_DWXX.T_BM_DWXXBusinessEntity.GetDataByObjectID(base.ObjectID);
  appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ID;
  
            validateData = ValidateDWBH(DWBH.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DWBH = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DWBH = null;
                }
                DWBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DWBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateDWMC(DWMC.Text, false, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DWMC = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DWMC = null;
                }
                DWMC.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DWMC.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJDWBH(SJDWBH.SelectedValue, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJDWBH = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.SJDWBH = null;
                }
                SJDWBH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJDWBH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateDZ(DZ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.DZ = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.DZ = null;
                }
                DZ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                DZ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateYB(YB.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.YB = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.YB = null;
                }
                YB.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                YB.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXBM(LXBM.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXBM = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LXBM = null;
                }
                LXBM.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXBM.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXDH(LXDH.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXDH = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LXDH = null;
                }
                LXDH.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXDH.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateEmail(Email.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.Email = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.Email = null;
                }
                Email.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                Email.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateLXR(LXR.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.LXR = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.LXR = null;
                }
                LXR.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                LXR.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            validateData = ValidateSJ(SJ.Text, true, false);
            if (validateData.Result)
            {
                if (!validateData.IsNull)
                {
                    appData.SJ = Convert.ToString(validateData.Value.ToString());
                }
                            
                else
                {
                    appData.SJ = null;
                }
                SJ.BackColor = System.Drawing.Color.Empty;
            }
            else
            {
                SJ.BackColor = System.Drawing.Color.YellowGreen;
                MessageContent += @"<font color=""red"">" + validateData.Message + "</font>";
                boolReturn = validateData.Result;
            }
                    
            return boolReturn;
        }

        //=====================================================================
        //  FunctionName : InitalizeCoupledDataSource
        /// <summary>
        /// ��ʼ����������
        /// </summary>
        //=====================================================================
        protected void InitalizeCoupledDataSource()
        {
    
        }

    

        protected override void CheckPermission()
        {
            if (AccessPermission)
            {
                if(EditMode)
                {
        ObjectIDContainer.Visible = false;
          DWBH.Enabled = false;
                    
                }
                else if(AddMode || CopyMode)
                {
        ObjectIDContainer.Visible = false;
          DWBHContainer.Visible = false;
          
                }
                if(ImportDSMode)
                {
        ObjectIDContainer.Visible = false;
          DWBHContainer.Visible = false;
          DWMCContainer.Visible = false;
          DWMCContainer.Visible = true;
          SJDWBHContainer.Visible = false;
          SJDWBHContainer.Visible = true;
          DZContainer.Visible = false;
          DZContainer.Visible = true;
          YBContainer.Visible = false;
          YBContainer.Visible = true;
          LXBMContainer.Visible = false;
          LXBMContainer.Visible = true;
          LXDHContainer.Visible = false;
          LXDHContainer.Visible = true;
          EmailContainer.Visible = false;
          EmailContainer.Visible = true;
          LXRContainer.Visible = false;
          LXRContainer.Visible = true;
          SJContainer.Visible = false;
          SJContainer.Visible = true;
          
                }
                if (ViewMode)
                {
        ObjectID.Enabled = false;
                    ObjectIDContainer.Visible = false;
          DWBH.Enabled = false;
                    DWMC.Enabled = false;
                    SJDWBH.Enabled = false;
                    DZ.Enabled = false;
                    YB.Enabled = false;
                    LXBM.Enabled = false;
                    LXDH.Enabled = false;
                    Email.Enabled = false;
                    LXR.Enabled = false;
                    SJ.Enabled = false;
                    
                }
        
            }
        }
    
        protected override string GetObjectID()
        {
                    appData = new T_BM_DWXXApplicationData();
        
                    appData.OPCode = RICH.Common.Base.ApplicationData.ApplicationDataBase.OPType.ALL;
                    appData.PageSize = 1;
                    appData.CurrentPage = 1;
                    QueryRecord();
                    if (appData.RecordCount == 1)
                    {
                        return GetValue(appData.ResultSet.Tables[0].Rows[0]["ObjectID"]);
                    }
                    else
                    {
                        return string.Empty;
                    }
        }
    }
}

