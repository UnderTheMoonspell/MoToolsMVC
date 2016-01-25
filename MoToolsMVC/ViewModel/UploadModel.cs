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

        public UploadModel(DropDownList attachmentTypes, string uploadButtonName)
        {
            this.AttachmentTypes = attachmentTypes;
            this.UploadButtonName = uploadButtonName;
        }

        public UploadModel(DropDownList options) : this(options, "Adicionar Arquivo") { }
    }
}