using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LoaiSanPhamModel
    {
        public int MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }
        public string NoiDung { get; set; }
    }

    public class LoaiSanPhamModel_deletes
    {
        public List<ChiTietLoaiSanPhamModel> list_json_maloaisp { get; set; }
    }
    public class ChiTietLoaiSanPhamModel
    {
        public int MaLoaiSanPham { get; set; }
        public int GhiChu { get; set; }

    }
}
