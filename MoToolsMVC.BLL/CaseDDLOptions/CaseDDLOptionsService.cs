using MoToolsMVC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoToolsMVC.BLL.CaseDDLOptions
{
    public class CaseDDLOptionsService : ICaseDDLOptionsService
    {
        private IUnitOfWork _unitOfWork { get; set; }

        public CaseDDLOptionsService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public List<CaseDDLOption> GetUploadAttachmentTypes(int team)
        {
            return _unitOfWork.CaseDDLOptionsRepository.Get_Upload_Attachment_Types(team).Select(c => new CaseDDLOption(c)).ToList();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_unitOfWork != null)
                {
                    _unitOfWork.Dispose();
                }
            }
        }
    }
}
