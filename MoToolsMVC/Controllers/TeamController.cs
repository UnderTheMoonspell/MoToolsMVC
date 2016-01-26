//using Microsoft.WindowsAzure.Storage;
//using Microsoft.WindowsAzure.Storage.Blob;
using MoToolsMVC.BLL;
using MoToolsMVC.BLL.CaseDDLOptions;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MoToolsMVC.Controllers
{
    public class TeamController : Controller
    {
        private IServiceUnitOfWork _serviceUnitOfWork;

        //TODO: DEV
        //Get RequestId and ActivityId and AttachmentType
        public int BDTeamId { get { return 515; } }
        public Guid requestID { get { return new Guid("bf30c6b5-b97b-4adb-959b-f8f3d12b58d8"); } }
        public Guid? activityID { get { return new Guid("d6a257e6-b8fe-40b6-82d8-e0546656bd37"); } }
        public string username { get { return "boanateladmin"; } }

        public TeamController(IServiceUnitOfWork serviceUnitOfWork)
        {
            this._serviceUnitOfWork = serviceUnitOfWork;
        }

        public ActionResult GetUploadAttachmentTypes()
        {
            List<CaseDDLOption> list = _serviceUnitOfWork.AttachmentsService.GetUploadAttachmentTypes(BDTeamId);
            list = list.OrderBy(o => o.Text).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SaveAttachment()
        {
            // Check Web.config <location path="Team/SaveAttachment"> for the maximum request length

            string attachmentName, selectedAttachmentType = Request.Form["AttachmentTypes.SelectedOption"];
            Guid tempGuid;
            Guid? attachmentType = null;
            if (Guid.TryParse(selectedAttachmentType, out tempGuid))
            {
                attachmentType = tempGuid;
            }

            try
            {
                for (int i = 0; i < Request.Files.Count; i++)
                {
                    HttpPostedFileBase file = Request.Files[i];
                    attachmentName = file.FileName;
                    var url = _serviceUnitOfWork.AttachmentsService.UploadToAzure(file.InputStream, attachmentName, requestID);
                    _serviceUnitOfWork.AttachmentsService.SaveAttachmentToBD(url, requestID, activityID, attachmentName, username, attachmentType);
                }
            }
            catch (Exception)
            {
                return Json("Error uploading");
            }

            return Json("Uploaded successfully");
        }

        public ActionResult DeleteAttachment(Guid id)
        {
            //TODO: Delete attachment
            throw new NotImplementedException();
        }

        protected override void Dispose(bool disposing)
        {
            _serviceUnitOfWork.Dispose();
            base.Dispose(disposing);
        }

    }

}