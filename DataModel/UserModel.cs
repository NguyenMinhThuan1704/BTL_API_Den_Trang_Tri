namespace DataModel
{
    public class UserModel
    {
        public int MaTaiKhoan { get; set; }
        public int LoaiTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
    }

    public class LoaiTaiKhoan
    {
        public int MaLoaiTK { get; set; }
        public string TenLoaiTK { get; set; }
        public string MoTa { get; set; }
    }
}