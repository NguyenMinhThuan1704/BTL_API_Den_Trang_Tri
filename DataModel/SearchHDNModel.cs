namespace DataModel
{
    public class SearchHDNModel
    {
        public int MaHoaDonNhap { get; set; }
        public int MaNhaPhanPhoi { get; set; }
        public int MaTaiKhoan { get; set; }
        public string KieuThanhToan { get; set; }
        public string TenNhaPhanPhoi { get; set; }
        public string HoTen {get; set; }
        public decimal TongTien { get; set; }
        public List<CTHDN> list_json_chitiethdn { get; set; }

    }

    public class CTHDN
    {
        public int MaCTHDN { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int MaLoaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public decimal GiaGiam { get; set; }
        public int SoLuong { get; set; }
        public string DonViTinh { get; set; }
        public double GiaNhap { get; set; }
        public double TongTien { get; set; }
        public int GhiChu { get; set; }
    }
}