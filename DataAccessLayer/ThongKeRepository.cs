using DataModel;

namespace DataAccessLayer
{
    public class ThongKeRepository:IThongKeRepository
    {
        private IDatabaseHelper _dbHelper;
        public ThongKeRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        //public List<ThongKeTongQuat_Ngay> GetAll()
        //{
        //    string msgError = "";
        //    try
        //    {
        //        var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetDailyRevenue");
        //        if (!string.IsNullOrEmpty(msgError))
        //            throw new Exception(msgError);
        //        return dt.ConvertTo<ThongKeTongQuat_Ngay>().ToList();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        public ThongKeTongQuat ThongKe_Ngay()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetDailyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ThongKeTongQuat ThongKe_Tuan()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetWeeklyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ThongKeTongQuat ThongKe_Thang()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetMonthlyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public ThongKeTongQuat ThongKe_Nam()
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "GetYearlyRevenue");
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ThongKeTongQuat>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
