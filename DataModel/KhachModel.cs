namespace DataModel
{
    public class KhachModel
    {
        public int MaKH { get; set; }
        public string TenKH { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
    }
    public class KhachModel_deletes
    {
        public List<ChiTietKhachHangModel> list_json_makhachhang { get; set; }
    }
    public class ChiTietKhachHangModel
    {
        public int MaKH { get; set; }
        public int GhiChu { get; set; }

    }
}