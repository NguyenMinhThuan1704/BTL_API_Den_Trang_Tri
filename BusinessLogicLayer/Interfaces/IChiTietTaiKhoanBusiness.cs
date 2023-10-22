using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IChiTietTaiKhoanBusiness
    {
        ChiTietTaiKhoanModel GetDatabyID(string id);
        bool Create(ChiTietTaiKhoanModel model);
        bool Update(ChiTietTaiKhoanModel model);
        bool Delete(string Id);
        public List<ChiTietTaiKhoanModel> Search(int pageIndex, int pageSize, out long total, string ho_ten, string dia_chi);
    }
}
