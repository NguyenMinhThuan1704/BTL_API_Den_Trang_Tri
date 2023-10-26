using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IHoaDonNhapRepository
    {
        HoaDonNhapModel GetDatabyID(int id);
        List<HoaDonNhapModel> GetAll() ;
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        public List<ThongKeHoaDonNhapModel> Search(int pageIndex, int pageSize, out long total, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
