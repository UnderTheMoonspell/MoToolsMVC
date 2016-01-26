using MoToolsMVC.BLL.CaseDDLOptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.Attachments
{
    public interface IAttachmentsService
    {
        List<CaseDDLOption> GetUploadAttachmentTypes(int team);
        string UploadToAzure(Stream stream, string filename, Guid? requestId);
        void SaveAttachmentToBD(string url, Guid requestID, Guid? activityID, string attachmentName, string username, Guid? attachmentType);
    }
}
