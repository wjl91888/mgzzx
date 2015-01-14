using System;
using System.Web.UI;
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

        private string _delimiter = ",";
        public string Delimiter
        {
            set 
            {
                _delimiter = !string.IsNullOrEmpty(value) ? value : ",";
            }
            get
            {
                return _delimiter;
            }
        }

        private string _selectedValues = string.Empty;
        public string SelectedValues
        {
            get
            {
                bool boolFirstItem = true;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].Selected)
                    {
                        if (boolFirstItem)
                        {
                            _selectedValues = this.Items[i].Value;
                            boolFirstItem = false;
                        }
                        else
                        {
                            _selectedValues = _selectedValues + Delimiter + this.Items[i].Value;
                        }
                    }
                }
                return _selectedValues;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _selectedValues = value;
                    string[] strTemp = _selectedValues.Split(Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        for (int j = 0; j < strTemp.Length; j++)
                        {
                            this.Items[i].Selected = false;
                        }
                    }
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
        }

        public override string SelectedValue
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
                            _selectedValues = this.Items[i].Value;
                            boolFirstItem = false;
                        }
                        else
                        {
                            _selectedValues = _selectedValues + Delimiter + this.Items[i].Value;
                        }
                    }
                }
                return _selectedValues;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _selectedValues = value;
                    string[] strTemp = _selectedValues.Split(Delimiter.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < this.Items.Count; i++)
                    {
                        for (int j = 0; j < strTemp.Length; j++)
                        {
                            this.Items[i].Selected = false;
                        }
                    }
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
        }

        private string _allSelectedValue = string.Empty;
        public string AllSelectedValue
        {
            get
            {
                bool boolFirstItem = true;
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (boolFirstItem)
                    {
                        _allSelectedValue = this.Items[i].Value;
                        boolFirstItem = false;
                    }
                    else
                    {
                        _allSelectedValue = _allSelectedValue + Delimiter + this.Items[i].Value;
                    }
                }
                return _allSelectedValue;
            }
        }
        
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(@"<div class=""CheckBoxListEx"" style=""height:150px; width:100%; overflow:auto;"">");
            for (int i = 0; i < this.Items.Count; i++)
            {
                this.Items[i].Attributes.Add("onclick", "getcheckedvalue('" + this.ClientID.ToString() + "','input','" + this.ID.ToString() + "Value');");
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
            writer.WriteLine(@"<script language=""JavaScript"" type=""text/JavaScript"">getcheckedvalue('" + this.ClientID.ToString() + "','input','" + this.ID.ToString() + "Value');</script>");
            writer.Write(@"</div>");
        }

    }
}