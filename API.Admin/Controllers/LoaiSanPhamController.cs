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
        [NonAction]
        public string CreatePathFile(string RelativePathFileName)
        {
            try
            {
                string serverRootPathFolder = _path;
                string fullPathFile = $@"{serverRootPathFolder}\{RelativePathFileName}";
                string fullPathFolder = System.IO.Path.GetDirectoryName(fullPathFile);
                if (!Directory.Exists(fullPathFolder))
                    Directory.CreateDirectory(fullPathFolder);
                return fullPathFile;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [Route("upload")]
        [HttpPost, DisableRequestSizeLimit]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            try
            {
                if (file.Length > 0)
                {
                    string filePath = $"upload/{file.FileName}";
                    var fullPath = CreatePathFile(filePath);
                    using (var fileStream = new FileStream(fullPath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                    }
                    return Ok(new { filePath });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Không tìm thây");
            }
        }

        [Route("download")]
        [HttpPost]
        public IActionResult DownloadData([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var webRoot = _env.ContentRootPath;
                string exportPath = Path.Combine(webRoot + @"\Export\DM.xlsx");
                var stream = new FileStream(exportPath, FileMode.Open, FileAccess.Read);
                return File(stream, "application/octet-stream");
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
        //[Route("search")]
        //[HttpPost]
        //public IActionResult Search([FromBody] Dictionary<string, object> formData)
        //{
        //    try
        //    {
        //        var page = int.Parse(formData["page"].ToString());
        //        var pageSize = int.Parse(formData["pageSize"].ToString());
        //        string ten_khach = "";
        //        if (formData.Keys.Contains("ten_khach") && !string.IsNullOrEmpty(Convert.ToString(formData["ten_khach"]))) { ten_khach = Convert.ToString(formData["ten_khach"]); }
        //        string dia_chi = "";
        //        if (formData.Keys.Contains("dia_chi") && !string.IsNullOrEmpty(Convert.ToString(formData["dia_chi"]))) { dia_chi = Convert.ToString(formData["dia_chi"]); }
        //        long total = 0;
        //        var data = _loaisanphamBusiness.Search(page, pageSize, out total, ten_khach, dia_chi);
        //        return Ok(
        //            new
        //            {
        //                TotalItems = total,
        //                Data = data,
        //                Page = page,
        //                PageSize = pageSize
        //            }
        //            );
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message);
        //    } 
        //}
    }
}
