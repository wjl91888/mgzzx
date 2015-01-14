using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.ComponentModel;

namespace CustomWebControls
{
    [DefaultProperty("Id")]
    [ToolboxData("<{0}:CheckBoxListEx runat=server></{0}:CheckBoxListEx>")]
    public class CheckBoxListEx : System.Web.UI.WebControls.CheckBoxList
    {
        public CheckBoxListEx()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private string delimiter = ",";
        public string Delimiter
        {
            set
            {
                if (value != null)
                {
                    if (value != "" && value != string.Empty)
                    {
                        delimiter = value;                        
                    }
                    else
                    {
                        delimiter = ",";
                    }
                }
                else
                {
                    delimiter = ",";
                }
            }
            get
            {
                return delimiter;
            }
        }

        private string selectedValues = string.Empty;
        public string SelectedValues
        {
            get
            {
                bool boolFirstItem = true;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected == true)
                    {
                        if (boolFirstItem == true)
                        {
                            selectedValues = this.Items[i].Value;
                            boolFirstItem = false;
                        }
                        else
                        {
                            selectedValues = selectedValues + Delimiter + this.Items[i].Value;
                        }
                    }
                }
                return selectedValues;
            }
            set
            {
                selectedValues = value;
                string[] strTemp = selectedValues.Split(Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < this.Items.Count; i++)
                {
                    for (int j = 0; j < strTemp.Length; j++)
                    {
                        if (this.Items[i].Value == strTemp[j])
                        {
                            this.Items[i].Selected = true;
                        }
                    }
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].Attributes.Add("onclick", "getcheckedvalue('" + this.ID.ToString() + "','input','" + this.ID.ToString() + "Value');");
                this.Items[i].Attributes.Add("ItemValue", this.Items[i].Value);
            }
            writer.Write(@"<input type='hidden' id='" + this.ID.ToString() + "Value' name='" + this.ID.ToString() + "Value' />");
            writer.WriteLine(@"<script language=""JavaScript"" type=""text/JavaScript"">");
            writer.WriteLine(@"function getcheckedvalue(menuid,tagname,mainid){");
            writer.WriteLine(@"     var obj = document.getElementById(menuid);");
            writer.WriteLine(@"     var objmain = document.getElementById(mainid);");
            writer.WriteLine(@"     var strTemp = '';");
            writer.WriteLine(@"     for(i=0;i<obj.getElementsByTagName(tagname).length;i++){");
            writer.WriteLine(@"         if(obj.getElementsByTagName(tagname).item(i).checked == true){");
            writer.WriteLine(@"             strTemp = strTemp + ',' + obj.getElementsByTagName(tagname).item(i).parentNode.getAttribute('ItemValue');}}");
            writer.WriteLine(@"     objmain.value = strTemp;}");
            writer.WriteLine(@"</script>");
            base.Render(writer);
            writer.WriteLine(@"<script language=""JavaScript"" type=""text/JavaScript"">getcheckedvalue('" + this.ID.ToString() + "','input','" + this.ID.ToString() + "Value');</script>");
        }

    }
}