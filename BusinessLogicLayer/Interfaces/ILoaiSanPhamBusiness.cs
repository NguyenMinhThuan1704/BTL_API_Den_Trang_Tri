using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ILoaiSanPhamBusiness
    {
        LoaiSanPhamModel GetDatabyID(string id);
        bool Create(LoaiSanPhamModel model);
        bool Update(LoaiSanPhamModel model);
        bool Delete(string Id);
        bool DeleteS(LoaiSanPhamModel_deletes model);
        public List<LoaiSanPhamModel> Search(int pageIndex, int pageSize, out long total, string tenlsp, string noidung);
    }
}
