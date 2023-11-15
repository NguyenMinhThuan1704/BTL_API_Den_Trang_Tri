using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface ILoaiTaiKhoanRepository
    {
        LoaiTaiKhoanModel GetDatabyID(string id);
        bool Create(LoaiTaiKhoanModel model);
        bool Update(LoaiTaiKhoanModel model);
        bool Delete(string Id);
        public List<LoaiTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string tenltk, string mota);
    }
}
