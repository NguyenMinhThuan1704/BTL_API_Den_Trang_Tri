using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface INhaPhanPhoiBusiness
    {
        NhaPhanPhoiModel GetDatabyID(string id);
        bool Create(NhaPhanPhoiModel model);
        bool Update(NhaPhanPhoiModel model);
        bool Delete(string Id);
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ten_npp, string dia_chi);
    }
}
