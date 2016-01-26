using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoToolsMVC.ViewModel
{
    public class DropDownOption
    {
        public string Value { get; set; }
        public string Text { get; set; }

        public DropDownOption(string value, string text)
        {
            this.Value = value;
            this.Text = text;
        }

        public DropDownOption(string value): this(value, value) { }
    }
}