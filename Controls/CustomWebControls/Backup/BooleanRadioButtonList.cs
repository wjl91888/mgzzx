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
    [ToolboxData("<{0}:BooleanRadioButtonList runat=server></{0}:BooleanRadioButtonList>")]
    public class BooleanRadioButtonList : System.Web.UI.WebControls.RadioButtonList
    {
        private string trueValueDescription = "ÊÇ";
        public string TrueValueDescription
        {
            get
            {
                return trueValueDescription;
            }
            set
            {
                trueValueDescription = value;
            }
        }

        private string falseValueDescription = "·ñ";
        public string FalseValueDescription
        {
            get
            {
                return falseValueDescription;
            }
            set
            {
                falseValueDescription = value;
            }
        }

        private bool defaultValue = true;
        public bool DefaultValue
        {
            get
            {
                return defaultValue;
            }
            set
            {
                defaultValue = value;
            }
        }

        public BooleanRadioButtonList()
        {

            this.Items.Add(new ListItem(TrueValueDescription, "true"));
            this.Items.Add(new ListItem(FalseValueDescription, "false"));
            this.RepeatDirection = RepeatDirection.Horizontal;
            if (DefaultValue == true)
            {
                this.Items[0].Selected = true;
            }
            else
            {
                this.Items[0].Selected = false;
            }

        }

        protected override void OnInit(EventArgs e)
        {
            this.Items[0].Text = TrueValueDescription;
            this.Items[1].Text = FalseValueDescription;
            base.OnInit(e);
        }

        private bool selectedValues = true;
        public bool SelectedValues
        {
            get
            {
                if (this.Items[0].Selected == true)
                {
                    selectedValues = true;
                }
                else
                {
                    selectedValues = false;
                }
                return selectedValues;
            }
            set
            {
                selectedValues = value;
                if (selectedValues == true)
                {
                    this.Items[0].Selected = true;
                }
                else
                {
                    this.Items[1].Selected = true;
                }
            }
        }
    }
}
