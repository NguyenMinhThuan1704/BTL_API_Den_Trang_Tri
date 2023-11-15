using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserBusiness _userBusiness;
        public UserController(IUserBusiness userBusiness)
        {
            _userBusiness = userBusiness;
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] AuthenticateModel model)
        {
            var user = _userBusiness.Login(model.Username, model.Password);
            if (user == null)
                return BadRequest(new { message = "Tài khoản hoặc mật khẩu không đúng!" });
            return Ok(new { taikhoan = user.TenTaiKhoan, email = user.Email, token = user.token, loaitaikhoan = user.LoaiTaiKhoan, mataikhoan = user.MaTaiKhoan });
        }
        [Route("get-by-id/{id}")]
        [HttpGet]
        public UserModel GetDatabyID(string id)
        {
            return _userBusiness.GetDatabyID(id);
        }
        [Route("Select-all-taikhoan")]
        [HttpGet]
        public List<UserModel> GetAll()
        {
            return _userBusiness.GetAll();
        }
        [Route("create-taikhoan")]
        [HttpPost]
        public UserModel CreateItem([FromBody] UserModel model)
        {
            _userBusiness.Create(model);
            return model;
        }
        //[Route("check-login")]
        //[HttpPost]
        //public CheckLoginModel CheckLogin([FromBody] CheckLoginModel model)
        //{
        //    _userBusiness.CheckLogin(model);
        //    return model;
        //}
        [Route("update-taikhoan")]
        [HttpPost]
        public UserModel UpdateItem([FromBody] UserModel model)
        {
            _userBusiness.Update(model);
            return model;
        }
        //[Route("delete/{id}")]
        //[HttpDelete]
        //public bool DeleteKH(string id)
        //{
        //    return _userBusiness.Delete(id);
        //}
    }
}
