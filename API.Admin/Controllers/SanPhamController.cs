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
    public class SanPhamController : ControllerBase
    {
        private ISanPhamBusiness _sanphamBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public SanPhamController(ISanPhamBusiness sanphamBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _sanphamBusiness = sanphamBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }

        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public SanPhamModel GetDatabyID(int id)
        {
            return _sanphamBusiness.GetDatabyID(id);
        }
        [Route("get-by-id-lq/{id}")]
        [HttpGet]
        public List<SanPhamModel> GetDatabyIDLQ(string id)
        {
            return _sanphamBusiness.GetDatabyIDLQ(id);
        }
        [Route("Select-sanphamtheochucnang/{id}")]
        [HttpGet]
        public List<SanPhamTheoChucNang> SanPhamTheoChucNang(int id)
        {
            return _sanphamBusiness.SanPhamTheoChucNang(id);
        }
        [Route("create-sanpham")]
        [HttpPost]
        public SanPhamModel CreateItem([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.Create(model);
            return model;
        }
        [Route("update-sanpham")]
        [HttpPost]
        public SanPhamModel UpdateItem([FromBody] SanPhamModel model)
        {
            _sanphamBusiness.Update(model);
            return model;
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteKH(string id)
        {
            return _sanphamBusiness.Delete(id);
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int maloaisp = 0;
                if (formData.Keys.Contains("maloaisp")) { maloaisp = int.Parse(formData["maloaisp"].ToString()); }
                string ten_sp = "";
                if (formData.Keys.Contains("ten_sp") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_sp"]))) { ten_sp = Convert.ToString(formData["ten_sp"]); }
                string anh_dai_dien = "";
                if (formData.Keys.Contains("anh_dai_dien") && !string.IsNullOrEmpty(Convert.ToString(formData["anh_dai_dien"]))) { anh_dai_dien = Convert.ToString(formData["anh_dai_dien"]); }
                long total = 0;
                var data = _sanphamBusiness.Search(page, pageSize, out total, maloaisp, ten_sp, anh_dai_dien);
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
