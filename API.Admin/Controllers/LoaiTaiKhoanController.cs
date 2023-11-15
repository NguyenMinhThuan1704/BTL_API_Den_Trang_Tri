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
    public class LoaiTaiKhoanController : ControllerBase
    {
        private ILoaiTaiKhoanBusiness _loaitaikhoanBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public LoaiTaiKhoanController(ILoaiTaiKhoanBusiness loaitaikhoanBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _loaitaikhoanBusiness = loaitaikhoanBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }

        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public LoaiTaiKhoanModel GetDatabyID(string id)
        {
            return _loaitaikhoanBusiness.GetDatabyID(id);
        }
        [Route("create-loaitk")]
        [HttpPost]
        public LoaiTaiKhoanModel CreateItem([FromBody] LoaiTaiKhoanModel model)
        {
            _loaitaikhoanBusiness.Create(model);
            return model;
        }
        [Route("update-loaitk")]
        [HttpPost]
        public LoaiTaiKhoanModel UpdateItem([FromBody] LoaiTaiKhoanModel model)
        {
            _loaitaikhoanBusiness.Update(model);
            return model;
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteKH(string id)
        {
            return _loaitaikhoanBusiness.Delete(id);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenltk = "";
                if (formData.Keys.Contains("tenltk") && !string.IsNullOrEmpty(Convert.ToString(formData["tenltk"]))) { tenltk = Convert.ToString(formData["tenltk"]); }
                string mota = "";
                if (formData.Keys.Contains("mota") && !string.IsNullOrEmpty(Convert.ToString(formData["mota"]))) { mota = Convert.ToString(formData["mota"]); }
                long total = 0;
                var data = _loaitaikhoanBusiness.Search(page, pageSize, out total, tenltk, mota);
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
