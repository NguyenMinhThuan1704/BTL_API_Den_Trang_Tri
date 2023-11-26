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
    public class LoaiSanPhamController : ControllerBase
    {
        private ILoaiSanPhamBusiness _loaisanphamBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public LoaiSanPhamController(ILoaiSanPhamBusiness loaisanphamBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _loaisanphamBusiness = loaisanphamBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }

        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public LoaiSanPhamModel GetDatabyID(string id)
        {
            return _loaisanphamBusiness.GetDatabyID(id);
        }
        [Route("create-loaisanpham")]
        [HttpPost]
        public LoaiSanPhamModel CreateItem([FromBody] LoaiSanPhamModel model)
        {
            _loaisanphamBusiness.Create(model);
            return model;
        }
        [Route("update-loaisanpham")]
        [HttpPost]
        public LoaiSanPhamModel UpdateItem([FromBody] LoaiSanPhamModel model)
        {
            _loaisanphamBusiness.Update(model);
            return model;
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteKH(string id)
        {
            return _loaisanphamBusiness.Delete(id);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tenlsp = "";
                if (formData.Keys.Contains("tenlsp") && !string.IsNullOrEmpty(Convert.ToString(formData["tenlsp"]))) { tenlsp = Convert.ToString(formData["tenlsp"]); }
                string noidung = "";
                if (formData.Keys.Contains("noidung") && !string.IsNullOrEmpty(Convert.ToString(formData["noidung"]))) { noidung = Convert.ToString(formData["noidung"]); }
                long total = 0;
                var data = _loaisanphamBusiness.Search(page, pageSize, out total, tenlsp, noidung);
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
