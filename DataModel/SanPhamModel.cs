namespace DataModel
{
    public class SanPhamModel
    {
        public int MaSanPham { get; set; }
        public int MaLoaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public decimal GiaGiam { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
    }

    public class SanPham1Model
    {
        public int MaSanPham { get; set; }
        public int MaLoaiSanPham { get; set; }
        public string TenLoaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public decimal GiaGiam { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
    }

    public class SanPhamTheoChucNang
    {
        public int ChucNang;
        public int MaSanPham { get; set; }
        public int MaLoaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public decimal GiaGiam { get; set; }
        public int SoLuong { get; set; }
        public bool TrangThai { get; set; }
        public int TongSoLuongBan { get; set; }
        public int SoDonDatHang { get; set; }
    }

    public class SanPhamModel_deletes
    {
        public List<ChiTietSanPhamModel> list_json_masp { get; set; }
    }
    public class ChiTietSanPhamModel
    {
        public int MaSanPham { get; set; }
        public int GhiChu { get; set; }

    }

}