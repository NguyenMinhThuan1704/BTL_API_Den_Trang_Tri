using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class ChiTietHDNBusiness:IChiTietHDNBusiness
    {
        private IChiTietHDNRepository _res;
        public ChiTietHDNBusiness(IChiTietHDNRepository res)
        {
            _res = res;
        }
        public ChiTietHDN GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ChiTietHDN> Search(int pageIndex, int pageSize, out long total, int ma_hd, int ma_sp)
        {
            return _res.Search(pageIndex, pageSize,out total, ma_hd, ma_sp);
        }
    }
}