using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class LoaiSanPhamBusiness:ILoaiSanPhamBusiness
    {
        private ILoaiSanPhamRepository _res;
        public LoaiSanPhamBusiness(ILoaiSanPhamRepository res)
        {
            _res = res;
        }
        public LoaiSanPhamModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(LoaiSanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Update(LoaiSanPhamModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public List<LoaiSanPhamModel> Search(int pageIndex, int pageSize, out long total, string tenlsp, string noidung)
        {
            return _res.Search(pageIndex, pageSize,out total, tenlsp, noidung);
        }
    }
}