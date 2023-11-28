using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonNhapController : ControllerBase
    {
        private IHoaDonNhapBusiness _hoadonnhapBusiness;
        public HoaDonNhapController(IHoaDonNhapBusiness hoadonnhapBusiness)
        {
            _hoadonnhapBusiness = hoadonnhapBusiness;
        }

        [Route("get-by-id/{id}")]
        [HttpGet]
        public HoaDonNhapModel GetDatabyID(int id)
        {
            return _hoadonnhapBusiness.GetDatabyID(id);
        }
        [Route("Select-all-hoadonnhap")]
        [HttpGet]
        public List<HoaDonNhapModel> GetAll()
        {
            return _hoadonnhapBusiness.GetAll();
        }
        [Route("create-hoadonnhap")]
        [HttpPost]
        public HoaDonNhapModel CreateItem([FromBody] HoaDonNhapModel model)
        {
            _hoadonnhapBusiness.Create(model);
            return model;
        }
        [Route("update-hoadonnhap")]
        [HttpPost]
        public HoaDonNhapModel Update([FromBody] HoaDonNhapModel model)
        {
            _hoadonnhapBusiness.Update(model);
            return model;
        }

        [Route("thongke_hoadonnhap")]
        [HttpPost]
        public IActionResult ThongKe([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                DateTime? fr_NgayTao = null;
                int ma_nv = 0;
                if (formData.Keys.Contains("ma_nv")) { ma_nv = int.Parse(formData["ma_nv"].ToString()); }
                int ma_npp = 0;
                if (formData.Keys.Contains("ma_npp")) { ma_npp = int.Parse(formData["ma_npp"].ToString()); }
                if (formData.Keys.Contains("fr_NgayTao") && formData["fr_NgayTao"] != null && formData["fr_NgayTao"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["fr_NgayTao"].ToString());
                    fr_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0, 0);
                }
                DateTime? to_NgayTao = null;
                if (formData.Keys.Contains("to_NgayTao") && formData["to_NgayTao"] != null && formData["to_NgayTao"].ToString() != "")
                {
                    var dt = Convert.ToDateTime(formData["to_NgayTao"].ToString());
                    to_NgayTao = new DateTime(dt.Year, dt.Month, dt.Day, 23, 59, 59, 999);
                }
                long total = 0;
                var data = _hoadonnhapBusiness.ThongKe(page, pageSize, out total, ma_nv, ma_npp, fr_NgayTao, to_NgayTao);
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
        [Route("searchHDN")]
        [HttpPost]
        public IActionResult SearchHDN([FromBody] Dictionary<string, object> formData)
        {
            try
            {
                var page = int.Parse(formData["page"].ToString());
                var pageSize = int.Parse(formData["pageSize"].ToString());
                int ma_nv = 0;
                if (formData.Keys.Contains("ma_nv")) { ma_nv = int.Parse(formData["ma_nv"].ToString()); }
                int ma_npp = 0;
                if (formData.Keys.Contains("ma_npp")) { ma_npp = int.Parse(formData["ma_npp"].ToString()); }
                long total = 0;
                var data = _hoadonnhapBusiness.SearchHDN(page, pageSize, out total, ma_nv, ma_npp);
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
