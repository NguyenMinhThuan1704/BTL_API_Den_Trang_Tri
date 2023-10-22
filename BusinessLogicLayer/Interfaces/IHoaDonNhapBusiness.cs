﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IHoaDonNhapBusiness
    {
        HoaDonNhapModel GetDatabyID(int id);
        List<HoaDonNhapModel> GetAll();
        bool Create(HoaDonNhapModel model);
        bool Update(HoaDonNhapModel model);
        //public List<ThongKeKhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, DateTime? fr_NgayTao, DateTime? to_NgayTao);
    }
}
