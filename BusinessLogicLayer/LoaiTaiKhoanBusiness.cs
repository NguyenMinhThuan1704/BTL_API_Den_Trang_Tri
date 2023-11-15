using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class LoaiTaiKhoanBusiness:ILoaiTaiKhoanBusiness
    {
        private ILoaiTaiKhoanRepository _res;
        public LoaiTaiKhoanBusiness(ILoaiTaiKhoanRepository res)
        {
            _res = res;
        }
        public LoaiTaiKhoanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(LoaiTaiKhoanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(LoaiTaiKhoanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public List<LoaiTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string tenltk, string mota)
        {
            return _res.Search(pageIndex, pageSize,out total, tenltk, mota);
        }
    }
}