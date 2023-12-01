using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text;

namespace BusinessLogicLayer
{
    public class UserBusiness:IUserBusiness
    {
        private IUserRepository _res;
        private string secret;
        public UserBusiness(IUserRepository res, IConfiguration configuration)
        {
            _res = res;
            secret = configuration["AppSettings:Secret"];
        }
        public List<UserModel> GetAll()
        {
            return _res.GetAll();
        }

        public bool Create(UserModel model)
        {
            return _res.Create(model);
        }
        public int CheckLogin(CheckLoginModel model)
        {
            return _res.CheckLogin(model);
        }
        public bool Update(UserModel model)
        {
            return _res.Update(model);
        }

        public bool Delete(string Id)
        {
            return _res.Delete(Id);
        }
        public bool DeleteS(TaiKhoanModel_deletes model)
        {
            return _res.DeleteS(model);
        }

        public UserModel GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }

        public UserModel2 Login(string taikhoan, string matkhau)
        {
            var user = _res.Login(taikhoan, matkhau);
            if (user == null)
                return null; 
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.TenTaiKhoan.ToString()),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim("MaTaiKhoan", user.MaTaiKhoan.ToString()),
                    new Claim("LoaiTaiKhoan",user.LoaiTaiKhoan.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.Aes128CbcHmacSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Email = tokenHandler.WriteToken(token);
            user.token = tokenHandler.WriteToken(token);
            return user; 
        }

        public List<UserModel1> Search(int pageIndex, int pageSize, out long total, int maloaitk, string ten_tk, string email)
        {
            return _res.Search(pageIndex, pageSize, out total, maloaitk, ten_tk, email);
        }
    }
}