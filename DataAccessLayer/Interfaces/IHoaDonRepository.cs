using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IHoaDonRepository
    {
        HoaDonModel GetDatabyID(int id);
        List<HoaDonModel> GetAll() ;
        bool Create(HoaDonModel model);
        bool Update(HoaDonModel model);
        bool Delete(string id);
        public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao);
        public List<SearchHDBModel> SearchHDB(int pageIndex, int pageSize, out long total, int ma_hd,string ten_kh);

    }
}
