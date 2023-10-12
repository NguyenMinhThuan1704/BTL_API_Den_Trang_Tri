using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IUserBusiness
    {
        UserModel Login(string taikhoan, string matkhau);
        UserModel GetDatabyID(string id);
        bool Create(UserModel model);
        bool Update(UserModel model);
        bool Delete(string Id);
    }
}
