using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public partial interface IChiTietHDNBusiness
    {
        ChiTietHDN GetDatabyID(string id);
        public List<ChiTietHDN> Search(int pageIndex, int pageSize, out long total, int ma_hd, int ma_sp);
    }
}
