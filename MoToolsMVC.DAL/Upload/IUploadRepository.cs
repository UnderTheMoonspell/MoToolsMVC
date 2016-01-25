using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.DAL.Upload
{
    public interface IUploadRepository
    {
        void SaveAttachment(string url, Guid requestID, Guid? activityID, string attachmentName, string username, Guid? attachmentType);
    }
}
