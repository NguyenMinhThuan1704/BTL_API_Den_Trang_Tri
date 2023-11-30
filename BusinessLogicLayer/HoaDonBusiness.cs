using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class HoaDonBusiness:IHoaDonBusiness
    {
        private IHoaDonRepository _res;
        public HoaDonBusiness(IHoaDonRepository res)
        {
            _res = res;
        }

        public HoaDonModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<HoaDonModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(HoaDonModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonModel model)
        {
            return _res.Update(model);
        }
        public bool Delete(string id)
        {
            return _res.Delete(id);
        }
        public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            return _res.Search(pageIndex, pageSize, out total, ten_khach, fr_NgayTao, to_NgayTao);
        }
        public List<SearchHDBModel> SearchHDB(int pageIndex, int pageSize, out long total, int ma_hd, string ten_kh)
        {
            return _res.SearchHDB(pageIndex, pageSize, out total, ma_hd, ten_kh);
        }

    }
}