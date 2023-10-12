using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class NhaPhanPhoiBusiness:INhaPhanPhoiBusiness
    {
        private INhaPhanPhoiRepository _res;
        public NhaPhanPhoiBusiness(INhaPhanPhoiRepository res)
        {
            _res = res;
        }
        public NhaPhanPhoiModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(NhaPhanPhoiModel model)
        {
            return _res.Create(model);
        }
        public bool Update(NhaPhanPhoiModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ten_npp, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize,out total, ten_npp, dia_chi);
        }
    }
}