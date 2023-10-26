using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class HoaDonNhapBusiness:IHoaDonNhapBusiness
    {
        private IHoaDonNhapRepository _res;
        public HoaDonNhapBusiness(IHoaDonNhapRepository res)
        {
            _res = res;
        }

        public HoaDonNhapModel GetDatabyID(int id)
        {
            return _res.GetDatabyID(id);
        }
        public List<HoaDonNhapModel> GetAll()
        {
            return _res.GetAll();
        }
        public bool Create(HoaDonNhapModel model)
        {
            return _res.Create(model);
        }
        public bool Update(HoaDonNhapModel model)
        {
            return _res.Update(model);
        }
        public List<ThongKeHoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao)
        {
            return _res.Search(pageIndex, pageSize, out total, fr_NgayTao, to_NgayTao);
        }

    }
}