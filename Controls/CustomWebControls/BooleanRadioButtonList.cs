using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace CustomWebControls
{
    [DefaultProperty("Id")]
    [ToolboxData("<{0}:BooleanRadioButtonList runat=server></{0}:BooleanRadioButtonList>")]
    public sealed class BooleanRadioButtonList : RadioButtonList
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

        public bool DefaultValue { get; set; }

        public BooleanRadioButtonList()
        {
            DefaultValue = true;

            Items.Add(new ListItem(TrueValueDescription, "true"));
            Items.Add(new ListItem(FalseValueDescription, "false"));
            RepeatDirection = RepeatDirection.Horizontal;
            Items[0].Selected = DefaultValue;
        }

        protected override void OnInit(EventArgs e)
        {
            Items[0].Text = TrueValueDescription;
            Items[1].Text = FalseValueDescription;
            base.OnInit(e);
        }

        public bool SelectedValues
        {
            get
            {
                return Items[0].Selected;
            }
            set
            {
                if (value)
                    Items[0].Selected = true;
                else
                    Items[1].Selected = true;
            }
        }
    }
}
