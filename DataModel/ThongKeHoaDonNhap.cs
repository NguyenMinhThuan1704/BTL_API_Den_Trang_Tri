using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class ThongKeHoaDonNhapModel
    {
        public int MaTaiKhoan { get; set; }
        public string HoTen { get; set; }
        public int MaNhaPhanPhoi { get; set; }
        public string TenNhaPhanPhoi { get; set; }
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public string KieuThanhToan { get; set;}
        public Decimal TongTien { get; set; }
        public DateTime NgayTao { get; set; }
    }
}
