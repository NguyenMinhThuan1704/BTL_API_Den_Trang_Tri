using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class TinTucBusiness:ITinTucBusiness
    {
        private ITinTucRepository _res;
        public TinTucBusiness(ITinTucRepository res)
        {
            _res = res;
        }
        public TinTucModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(TinTucModel model)
        {
            return _res.Create(model);
        }
        public bool Update(TinTucModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public bool DeleteS(TinTucModel_deletes model)
        {
            return _res.DeleteS(model);
        }
        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieu_de, string mo_ta)
        {
            return _res.Search(pageIndex, pageSize,out total, tieu_de, mo_ta);
        }
    }
}