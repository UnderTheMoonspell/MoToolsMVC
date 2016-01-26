using MoToolsMVC.DAL.CaseDDLOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL.Attachment
{
    public class AttachmentRepository: IAttachmentRepository
    {
        RioJaneiroEntities _dbcontext;

        public AttachmentRepository(RioJaneiroEntities dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public void SaveAttachment(string url, Guid requestID, Guid? activityID, string attachmentName, string username, Guid? attachmentType)
        {
            _dbcontext.Insert_Attachment(url, requestID, activityID, attachmentName, username, attachmentType);
        }
    }
}
