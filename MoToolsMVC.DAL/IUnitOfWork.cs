using MoToolsMVC.DAL.Attachment;
using MoToolsMVC.DAL.CaseDDLOptions;
using MoToolsMVC.DAL.Menu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        void Commit();
        IMenuRepository MenuRepository { get; }
        IGenericRepository<UsersRCA> UserRepository { get; }
        ICaseDDLOptionsRepository CaseDDLOptionsRepository { get; }
        IAttachmentRepository AttachmentsRepository { get; }
    }
}
