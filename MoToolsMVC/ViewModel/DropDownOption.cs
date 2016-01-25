using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoToolsMVC.ViewModel
{
    public class DropDownOption
    {
        public readonly string Value;
        public readonly string Text;

        public DropDownOption(string value, string text)
        {
            this.Value = value;
            this.Text = text;
        }
    }
}