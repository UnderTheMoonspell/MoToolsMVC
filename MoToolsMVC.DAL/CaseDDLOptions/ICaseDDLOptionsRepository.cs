using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL.CaseDDLOptions
{
    public interface ICaseDDLOptionsRepository
    {
        List<Get_All_Case_DDLOptions_Result> Get_All_Case_DDLOptions(string type, int team);
        List<Get_All_Case_DDLOptions_Result> Get_Upload_Attachment_Types(int team);
    }
}
