﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface ISanPhamBusiness
    {
        SanPhamModel GetDatabyID(int id);
        List<SanPhamTheoChucNang> SanPhamTheoChucNang(int id);
        List<SanPhamModel> GetDatabyIDLQ(string id);
        bool Create(SanPhamModel model);
        bool Update(SanPhamModel model);
        bool Delete(string Id);
        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, int maloaisp, string ten_sp, string anh_dai_dien);
    }
}
