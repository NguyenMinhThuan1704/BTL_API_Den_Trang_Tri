using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IHoaDonNhapBusiness
    {
        getbyHDNidModel GetDatabyID(int id);
        List<HoaDonNhapModel> GetAll();
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        bool Delete(string id);
        public List<ThongKeHoaDonNhapModel> ThongKe(int pageIndex, int pageSize, out long total, int ma_nv, int ma_npp, DateTime? fr_NgayTao, DateTime? to_NgayTao);
        public List<SearchHDNModel> SearchHDN(int pageIndex, int pageSize, out long total, int ma_hdn, int ma_nv, int ma_npp);
    }
}
