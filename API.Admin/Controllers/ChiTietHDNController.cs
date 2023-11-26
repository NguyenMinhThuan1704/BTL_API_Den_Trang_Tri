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
    public class ChiTietHDNController : ControllerBase
    {
        private IChiTietHDNBusiness _chitiethdnBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public ChiTietHDNController(IChiTietHDNBusiness chitiethdnBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _chitiethdnBusiness = chitiethdnBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }
        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public ChiTietHDN GetDatabyID(string id)
        {
            return _chitiethdnBusiness.GetDatabyID(id);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int ma_hd = 0;
                if (formData.Keys.Contains("ma_hd")) { ma_hd = int.Parse(formData["ma_hd"].ToString()); }
                int ma_sp = 0;
                if (formData.Keys.Contains("ma_sp")) { ma_sp = int.Parse(formData["ma_sp"].ToString()); }
                long total = 0;
                var data = _chitiethdnBusiness.Search(page, pageSize, out total, ma_hd, ma_sp);
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
