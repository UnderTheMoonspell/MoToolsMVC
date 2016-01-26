using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL.CaseDDLOptions
{
    public class CaseDDLOptionsRepository: ICaseDDLOptionsRepository
    {
        List<Get_All_Case_DDLOptions_Result> _ddlOptions;
        public CaseDDLOptionsRepository(RioJaneiroEntities dbcontext)
        {
            //TODO: Save in cache
            this._ddlOptions = dbcontext.Get_All_Case_DDLOptions().ToList();
        }

        public List<Get_All_Case_DDLOptions_Result> Get_All_Case_DDLOptions(string type, int team)
        {
            return _ddlOptions.Where(o => o.Option_Type == type && o.Rel_Team == team).ToList();
        }

        public List<Get_All_Case_DDLOptions_Result> Get_Upload_Attachment_Types(int team)
        {
            return Get_All_Case_DDLOptions("UCAttachmentOptions", team);
        }
    }
}
