using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface ITinTucRepository
    {
        TinTucModel GetDatabyID(string id);
        bool Create(TinTucModel model);
        bool Update(TinTucModel model);
        bool Delete(string Id);
        bool DeleteS(TinTucModel_deletes model);
        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieu_de, string mo_ta);
    }
}
