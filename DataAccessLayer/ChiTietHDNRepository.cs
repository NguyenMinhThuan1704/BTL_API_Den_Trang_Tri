using DataModel;

namespace DataAccessLayer
{
    public class ChiTietHDNRepository:IChiTietHDNRepository
    {
        private IDatabaseHelper _dbHelper;
        public ChiTietHDNRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public ChiTietHDN GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_cthdn_get_by_id",
                     "@MaCTHDN", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<ChiTietHDN>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<ChiTietHDN> Search(int pageIndex, int pageSize, out long total, int ma_hd, int ma_sp)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_cthdn_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ma_hd", ma_hd,
                    "@ma_sp", ma_sp);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<ChiTietHDN>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
