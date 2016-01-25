using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.CaseDDLOptions
{
    public interface ICaseDDLOptionsService : IMoToolsService
    {
        List<CaseDDLOption> GetUploadAttachmentTypes(int team);
    }
}
