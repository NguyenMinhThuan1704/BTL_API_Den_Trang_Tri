namespace DataModel
{
    public class SearchHDBModel
    {
        public int MaHoaDon { get; set; }
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public bool TrangThai { get; set; }
        public decimal TongGia { get; set; }
        public List<CTHDB> list_json_chitiethoadon { get; set; }

    }

    public class CTHDB
    {
        public int MaChiTietHoaDon { get; set; }
        public int MaHoaDon { get; set; }
        public int MaSanPham { get; set; }
        public int MaLoaiSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string AnhDaiDien { get; set; }
        public decimal Gia { get; set; }
        public decimal GiaGiam { get; set; }
        public int SoLuong { get; set; }
        public double TongGia { get; set; }
        public int GhiChu { get; set; }
    }
}