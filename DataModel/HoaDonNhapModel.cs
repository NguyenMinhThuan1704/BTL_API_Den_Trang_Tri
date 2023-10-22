using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class HoaDonNhapModel
    {
        public int MaHoaDonNhap { get; set; }
        public int MaNhaPhanPhoi { get; set; }
        public int MaTaiKhoan { get; set; }
        public string KieuThanhToan { get; set; }
        //public DateTime NgayTao { get; set; }
        public List<ChiTietHoaDonNhapModel> list_json_chitiethoadonnhap { get; set; }
    }
    public class ChiTietHoaDonNhapModel
    {
        public int MaCTHDN { get; set; }
        public int MaHoaDon { get; set; }        
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public double GiaNhap { get; set; }
        public double TongTien { get; set; }
        public int GhiChu { get; set; }

    }
}
