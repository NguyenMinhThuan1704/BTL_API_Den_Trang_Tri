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
    public class NhaPhanPhoiController : ControllerBase
    {
        private INhaPhanPhoiBusiness _nhaphanphoiBusiness;
        private string _path;
        private IWebHostEnvironment _env;
        public NhaPhanPhoiController(INhaPhanPhoiBusiness nhaphanphoiBusiness, IConfiguration configuration, IWebHostEnvironment env)
        {
            _nhaphanphoiBusiness = nhaphanphoiBusiness;
            _path = configuration["AppSettings:PATH"];
            _env = env;
        }

        //[AllowAnonymous]
        [Route("get-by-id/{id}")]
        [HttpGet]
        public NhaPhanPhoiModel GetDatabyID(string id)
        {
            return _nhaphanphoiBusiness.GetDatabyID(id);
        }
        [Route("create-nha-phan-phoi")]
        [HttpPost]
        public NhaPhanPhoiModel CreateItem([FromBody] NhaPhanPhoiModel model)
        {
            _nhaphanphoiBusiness.Create(model);
            return model;
        }
        [Route("update-nha-phan-phoi")]
        [HttpPost]
        public NhaPhanPhoiModel UpdateItem([FromBody] NhaPhanPhoiModel model)
        {
            _nhaphanphoiBusiness.Update(model);
            return model;
        }
        [Route("delete/{id}")]
        [HttpDelete]
        public bool DeleteKH(string id)
        {
            return _nhaphanphoiBusiness.Delete(id);
        }
        [Route("deleteS_NPP")]
        [HttpPost]
        public NPPModel_deletes DeleteS([FromBody] NPPModel_deletes model)
        {
            _nhaphanphoiBusiness.DeleteS(model);
            return model;
        }
        [Route("search")]
        [HttpPost]
        public IActionResult Search([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                string ten_npp = "";
                if (formData.Keys.Contains("ten_npp") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_npp"]))) { ten_npp = Convert.ToString(formData["ten_npp"]); }
                string dia_chi = "";
                if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
                long total = 0;
                var data = _nhaphanphoiBusiness.Search(page, pageSize, out total, ten_npp, dia_chi);
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
