using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class getbyidHoaDonModel
    {
        public int MaHoaDon { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public bool TrangThai { get; set; }
        public decimal TongGia { get; set; }

        public List<getbyidChiTietHoaDonModel> list_json_chitiethoadon { get; set; }
    }
    public class getbyidChiTietHoaDonModel
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int SoLuong { get; set; }
        public double TongGia { get; set; }
        public int GhiChu { get; set; }

    }
    public class HoaDonModel
    {
        public int MaHoaDon { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public bool TrangThai { get; set; }

        public List<ChiTietHoaDonModel> list_json_chitiethoadon { get; set; }
    }
    public class ChiTietHoaDonModel
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }        
        public int MaSanPham { get; set; }
        public int SoLuong { get; set; }
        public double TongGia { get; set; }
        public int GhiChu { get; set; }

    }
}
