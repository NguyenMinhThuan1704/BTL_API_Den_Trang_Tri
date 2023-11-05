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
        //[Route("delete/{id}")]
        //[HttpDelete]
        //public bool DeleteKH(string id)
        //{
        //    return _chitiettaikhoanBusiness.Delete(id);
        //}
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ho_ten = "";
                if (formData.Keys.Contains("ho_ten") && !string.IsNullOrEmpty(Convert.ToString(formData["ho_ten"]))) { ho_ten = Convert.ToString(formData["ho_ten"]); }
                string dia_chi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
                long total = 0;
                var data = _chitiettaikhoanBusiness.Search(page, pageSize, out total, ho_ten, dia_chi);
                return Ok(
                    new
                    {
                        TotalItems = total,
                        Data = data,
                        Page = page,
                        PageSize = pageSize
                    }
                    );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            } 
        }
    }
}
