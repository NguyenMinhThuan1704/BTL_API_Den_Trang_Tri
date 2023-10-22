using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class ChiTietTaiKhoanBusiness:IChiTietTaiKhoanBusiness
    {
        private IChiTietTaiKhoanRepository _res;
        public ChiTietTaiKhoanBusiness(IChiTietTaiKhoanRepository res)
        {
            _res = res;
        }
        public ChiTietTaiKhoanModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Create(ChiTietTaiKhoanModel model)
        {
            return _res.Create(model);
        }
        public bool Update(ChiTietTaiKhoanModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public List<ChiTietTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            return _res.Search(pageIndex, pageSize,out total, ten_khach, dia_chi);
        }
    }
}