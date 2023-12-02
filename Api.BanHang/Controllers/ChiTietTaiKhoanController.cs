using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Api.BanHang.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ChiTietTaiKhoanController : ControllerBase
    {
        private IChiTietTaiKhoanBusiness _chitiettaikhoanBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public ChiTietTaiKhoanController(IChiTietTaiKhoanBusiness chitiettaikhoanBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _chitiettaikhoanBusiness = chitiettaikhoanBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ChiTietTaiKhoanModel GetDatabyID(string id)
        {
            return _chitiettaikhoanBusiness.GetDatabyID(id);
        }
        [Route("create-cttk")]
        [HttpPost]
        public ChiTietTaiKhoanModel CreateItem([FromBody] ChiTietTaiKhoanModel model)
        {
            _chitiettaikhoanBusiness.Create(model);
            return model;
        }
        [Route("update-cttk")]
        [HttpPost]
        public ChiTietTaiKhoanModel UpdateItem([FromBody] ChiTietTaiKhoanModel model)
        {
            _chitiettaikhoanBusiness.Update(model);
            return model;
        }
    }
}
