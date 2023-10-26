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
    public class TinTucController : ControllerBase
    {
        private ITinTucBusiness _tintucBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public TinTucController(ITinTucBusiness tintucBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _tintucBusiness = tintucBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }

        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public TinTucModel GetDatabyID(string id)
        {
            return _tintucBusiness.GetDatabyID(id);
        }
        [Route("create-tintuc")]
        [HttpPost]
        public TinTucModel CreateItem([FromBody] TinTucModel model)
        {
            _tintucBusiness.Create(model);
            return model;
        }
        [Route("update-tintuc")]
        [HttpPost]
        public TinTucModel UpdateItem([FromBody] TinTucModel model)
        {
            _tintucBusiness.Update(model);
            return model;
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteKH(string id)
        {
            return _tintucBusiness.Delete(id);
        }
        [Route("search_tintuc")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string tieu_de = "";
                if (formData.Keys.Contains("tieu_de") && !string.IsNullOrEmpty(Convert.ToString(formData["tieu_de"]))) { tieu_de = Convert.ToString(formData["tieu_de"]); }
                string mo_ta = "";
                if (formData.Keys.Contains("mo_ta") && !string.IsNullOrEmpty(Convert.ToString(formData["mo_ta"]))) { mo_ta = Convert.ToString(formData["mo_ta"]); }
                long total = 0;
                var data = _tintucBusiness.Search(page, pageSize, out total, tieu_de, mo_ta);
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
