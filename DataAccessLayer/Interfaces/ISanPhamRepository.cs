using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface ISanPhamRepository
    {
        SanPhamModel GetDatabyID(int id);
        List<SanPhamTheoChucNang> SanPhamTheoChucNang(int id);
        List<SanPhamModel> GetDatabyIDLQ(string id);
        List<LaySPTheoLSPModel> GetSPTheoLSP();
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string Id);
        bool DeleteS(SanPhamModel_deletes model);
        public List<SanPham1Model> Search(int pageIndex, int pageSize, out long total, int maloaisp,string ten_sp, string anh_dai_dien);
    }
}
