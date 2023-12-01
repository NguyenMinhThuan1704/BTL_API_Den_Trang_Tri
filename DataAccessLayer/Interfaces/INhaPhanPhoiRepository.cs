using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface INhaPhanPhoiRepository
    {
        NhaPhanPhoiModel GetDatabyID(string id);
        bool Create(NhaPhanPhoiModel model);
        bool Update(NhaPhanPhoiModel model);
        bool Delete(string Id);
        bool DeleteS(NPPModel_deletes model);
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ten_npp, string dia_chi);
    }
}
