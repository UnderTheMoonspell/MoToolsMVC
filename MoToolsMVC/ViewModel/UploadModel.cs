using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoToolsMVC.ViewModel
{
    public class UploadModel
    {
        public string UploadButtonName;
        public DropDownList AttachmentTypes;

        public UploadModel(DropDownList attachmentTypes, string uploadButtonName = "Adicionar Arquivo")
        {
            this.AttachmentTypes = attachmentTypes;
            this.UploadButtonName = uploadButtonName;
        }

        public UploadModel(List<DropDownOption> attachmentTypes, string uploadButtonName = "Adicionar Arquivo") :
            this(new DropDownList(attachmentTypes), uploadButtonName) { }
    }
}