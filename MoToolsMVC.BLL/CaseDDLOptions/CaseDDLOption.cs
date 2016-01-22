using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoToolsMVC.DAL;

namespace MoToolsMVC.BLL.CaseDDLOptions
{
    public class CaseDDLOption
    {
        public Guid ID;
        public string Type;
        public string Value;
        public string Text;

        public CaseDDLOption(Get_All_Case_DDLOptions_Result node)
        {
            ID = node.Option_Id;
            Type = node.Option_Type;
            Value = node.Option_Key;
            Text = node.Option_Description;
        }

        public CaseDDLOption(Guid ID, string type, string value, string text)
        {
            this.ID = ID;
            this.Type = type;
            this.Value = value;
            this.Text = text;
        }
    }
}
