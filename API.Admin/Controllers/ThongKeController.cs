﻿using BusinessLogicLayer;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.BanHang.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ThongKeController : ControllerBase
    {
        private IThongKeBusiness _thongkeBusiness;
        public ThongKeController(IThongKeBusiness thongkeBusiness)
        {
            _thongkeBusiness = thongkeBusiness;
        }
        [Route("Select-thongke-ngay")]
        [HttpGet]
        public ThongKeTongQuat ThongKe_Ngay()
        {
            return _thongkeBusiness.ThongKe_Ngay();
        }
        [Route("Select-thongke-tuan")]
        [HttpGet]
        public ThongKeTongQuat ThongKe_Tuan()
        {
            return _thongkeBusiness.ThongKe_Tuan();
        }
        [Route("Select-thongke-thang")]
        [HttpGet]
        public ThongKeTongQuat ThongKe_Thang()
        {
            return _thongkeBusiness.ThongKe_Thang();
        }
        [Route("Select-thongke-nam")]
        [HttpGet]
        public ThongKeTongQuat ThongKe_Nam()
        {
            return _thongkeBusiness.ThongKe_Nam();
        }

    }
}
