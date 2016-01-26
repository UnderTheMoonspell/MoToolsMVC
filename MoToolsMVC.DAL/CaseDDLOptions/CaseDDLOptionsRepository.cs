using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL.CaseDDLOptions
{
    public class CaseDDLOptionsRepository: ICaseDDLOptionsRepository
    {
        RioJaneiroEntities _dbcontext;

        public CaseDDLOptionsRepository(RioJaneiroEntities dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public List<Get_All_Case_DDLOptions_Result> Get_All_Case_DDLOptions()
        {
            return _dbcontext.Get_All_Case_DDLOptions().ToList();
        }
    }
}
