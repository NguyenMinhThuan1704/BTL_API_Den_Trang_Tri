namespace DataModel
{
    public class UserModel
    {
        public int MaTaiKhoan { get; set; }
        public int LoaiTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }
    public class UserModel2
    {
        public int MaTaiKhoan { get; set; }
        public int LoaiTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
        public string token { get; set; }
    }

    public class UserModel1
    {
        public int MaTaiKhoan { get; set; }
        public int LoaiTaiKhoan { get; set; }
        public string TenLoaiTK { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string Email { get; set; }
    }

    public class CheckLoginModel
    {
        public int LoaiTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
    }
    public class TaiKhoanModel_deletes
    {
        public List<ChiTietTaiKhoan1Model> list_json_mataikhoan { get; set; }
    }
    public class ChiTietTaiKhoan1Model
    {
        public int MaTaiKhoan { get; set; }
        public int GhiChu { get; set; }

    }
}