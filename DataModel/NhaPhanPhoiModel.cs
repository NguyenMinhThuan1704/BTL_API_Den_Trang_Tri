using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModel
{
    public class NhaPhanPhoiModel
    {
        public int MaNhaPhanPhoi { get; set; }
        public string TenNhaPhanPhoi { get; set; }
        public string DiaChi { get; set; }
        public string SoDienThoai { get; set; }
        public string MoTa { get; set; }
    }

    public class NPPModel_deletes
    {
        public List<ChiTietNPPModel> list_json_manpp { get; set; }
    }
    public class ChiTietNPPModel
    {
        public int MaNhaPhanPhoi { get; set; }
        public int GhiChu { get; set; }

    }
}
