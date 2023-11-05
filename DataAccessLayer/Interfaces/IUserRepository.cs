using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public partial interface IUserRepository
    {
        UserModel Login(string taikhoan, string matkhau);
        UserModel GetDatabyID(string id);
        List<UserModel> GetAll();
        int CheckLogin(CheckLoginModel model);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(string Id);
    }
}
