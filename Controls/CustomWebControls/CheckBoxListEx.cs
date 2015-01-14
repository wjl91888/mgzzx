using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CustomWebControls
{
    [DefaultProperty("Id")]
    [ToolboxData("<{0}:CheckBoxListEx runat=server></{0}:CheckBoxListEx>")]
    public class CheckBoxListEx : CheckBoxList
    {
        private string delimiter = ",";
        public string Delimiter
        {
            set
            {
                if (value != null)
                {
                    delimiter = value != string.Empty ? value : ",";
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
                for (int i = 0; i < Items.Count; i++)
                {
                    if (Items[i].Selected)
                    {
                        if (boolFirstItem)
                        {
                            selectedValues = Items[i].Value;
                            boolFirstItem = false;
                        }
                        else
                        {
                            selectedValues = selectedValues + Delimiter + Items[i].Value;
                        }
                    }
                }
                return selectedValues;
            }
            set
            {
                if (value != null)
                {
                    selectedValues = value;
                    string[] strTemp = selectedValues.Split(Delimiter.ToCharArray(),
                                                            StringSplitOptions.RemoveEmptyEntries);
                    for (int i = 0; i < Items.Count; i++)
                    {
                        for (int j = 0; j < strTemp.Length; j++)
                        {
                            if (Items[i].Value == strTemp[j])
                            {
                                Items[i].Selected = true;
                            }
                        }
                    }
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            for (int i = 0; i < Items.Count; i++)
            {
                Items[i].Attributes.Add("onclick", "getcheckedvalue('" + ID + "','input','" + ID + "Value');");
                Items[i].Attributes.Add("ItemValue", Items[i].Value);
            }
            writer.Write(@"<input type='hidden' id='" + ID + "Value' name='" + ID + "Value' />");
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
            writer.WriteLine(@"<script language=""JavaScript"" type=""text/JavaScript"">getcheckedvalue('" + ID + "','input','" + ID + "Value');</script>");
        }

    }
}