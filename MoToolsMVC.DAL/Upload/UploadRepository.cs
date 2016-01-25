using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL.Upload
{
    public class UploadRepository: IUploadRepository
    {
        RioJaneiroEntities _dbcontext;
        public UploadRepository(RioJaneiroEntities dbcontext)
        {
            this._dbcontext = dbcontext;
        }
        public void SaveAttachment(string url, Guid requestID, Guid? activityID, string attachmentName, string username, Guid? attachmentType)
        {
            _dbcontext.Insert_Attachment(url, requestID, activityID, attachmentName, username, attachmentType);
        }
    }
}
