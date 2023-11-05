using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class SanPhamBusiness:ISanPhamBusiness
    {
        private ISanPhamRepository _res;
        public SanPhamBusiness(ISanPhamRepository res)
        {
            _res = res;
        }
        public SanPhamModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<SanPhamTheoChucNang> SanPhamTheoChucNang(int id)
        {
            return _res.SanPhamTheoChucNang(id);
        }
        public List<SanPhamModel> GetDatabyIDLQ(string id)
        {
            return _res.GetDatabyIDLQ(id);
        }
        public bool Create(SanPhamModel model)
        {
            return _res.Create(model);
        }
        public bool Update(SanPhamModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public List<SanPham1Model> Search(int pageIndex, int pageSize, out long total, int maloaisp, string ten_sp, string anh_dai_dien)
        {
            return _res.Search(pageIndex, pageSize,out total, maloaisp, ten_sp, anh_dai_dien);
        }

        public List<LaySPTheoLSPModel> GetSPTheoLSP()
        {
            return _res.GetSPTheoLSP();
        }
    }
}