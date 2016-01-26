using MoToolsMVC.BLL.CaseDDLOptions;
using MoToolsMVC.BLL.Menu;
using MoToolsMVC.BLL.Attachments;
using MoToolsMVC.BLL.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL
{
    public interface IServiceUnitOfWork: IDisposable
    {
        IUserService UserService { get; }
        IMenuService MenuService { get; }
        ICaseDDLOptionsService CaseDDLOptionsService { get; }
        IAttachmentsService AttachmentsService { get; }
    }
}
