﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class LoaiSanPhamModel
    {
        public int MaLoaiSanPham { get; set; }
        public int MaLoaiSanPhamCha { get; set; }
        public string TenLoaiSanPham { get; set; }
        public bool DacBiet { get; set; }
        public string NoiDung { get; set; }
    }
}
