using BusinessLogicLayer;
using DataAccessLayer;
using DataModel;

namespace BusinessLogicLayer
{
    public class ThongKeBusiness:IThongKeBusiness
    {
        private IThongKeRepository _res;
        public ThongKeBusiness(IThongKeRepository res)
        {
            _res = res;
        }
        //public List<ThongKeTongQuat_Ngay> GetAll()
        //{
        //    return _res.GetAll();
        //}
        public ThongKeTongQuat ThongKe_Ngay()
        {
            return _res.ThongKe_Ngay();
        }
        public ThongKeTongQuat ThongKe_Tuan()
        {
            return _res.ThongKe_Tuan();
        }
        public ThongKeTongQuat ThongKe_Thang()
        {
            return _res.ThongKe_Thang();
        }
        public ThongKeTongQuat ThongKe_Nam()
        {
            return _res.ThongKe_Nam();
        }
    }
}