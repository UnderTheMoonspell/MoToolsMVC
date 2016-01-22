using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
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

        public TeamController(IServiceUnitOfWork serviceUnitOfWork)
        {
            this._serviceUnitOfWork = serviceUnitOfWork;
        }

        public ActionResult GetUploadAttachmentTypes()
        {
            int team;

            // ---------------------------
            //TODO: DEV
            Session["BDTeam"] = 515;
            // ---------------------------

            if (!int.TryParse(Session["BDTeam"].ToString(), out team))
            {
                return Json(null, JsonRequestBehavior.AllowGet);
            }
            else
            {
                List<CaseDDLOption> list = _serviceUnitOfWork.CaseDDLOptionsService.GetUploadAttachmentTypes(team);
                list = list.OrderBy(o => o.Text).ToList();
                return Json(list, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult SaveAttachment(HttpPostedFileBase file)
        {
            // ---------------------------
            //TODO: DEV
            //Get RequestId and ActivityId and AttachmentType
            Guid requestID = new Guid("bf30c6b5-b97b-4adb-959b-f8f3d12b58d8");
            Guid? activityID = new Guid("d6a257e6-b8fe-40b6-82d8-e0546656bd37"); //Activity 2672227-2015
            string username = "boanateladmin";
            Guid? attachmentType = new Guid("14fbe3c8-2864-4d2b-9f17-fea2a9d5c7af"); //TODO: Map Guid in value on attachment type combo
            // ---------------------------
            string attachmentName = file.FileName;

            if (file != null && file.ContentLength > 0)
            {
                var url = _serviceUnitOfWork.UploadService.UploadToAzure(file.InputStream, attachmentName, requestID);
                _serviceUnitOfWork.UploadService.SaveAttachmentToBD(url, requestID, activityID, attachmentName, username, attachmentType);
                return Json("Uploaded successfully");
            }
            else
            {
                return Json("No file to Upload");
            }
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