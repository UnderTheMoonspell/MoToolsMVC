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

        public List<CaseDDLOption> GetCaseDDLOptions(string type, int team)
        {
            List<Get_All_Case_DDLOptions_Result> cacheOptions = new List<Get_All_Case_DDLOptions_Result>(); //TODO: Get from cache

            if (cacheOptions.Count == 0)
            {
                cacheOptions = _unitOfWork.CaseDDLOptionsRepository.Get_All_Case_DDLOptions();
                //TODO: Save in cache
            }
            return cacheOptions.Where(o => o.Rel_Team == team && o.Rel_Type == type)
                .OrderBy(o => o.Option_Description).Select(c => new CaseDDLOption(c)).ToList();
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
