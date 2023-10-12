using DataModel;

namespace DataAccessLayer
{
    public class NhaPhanPhoiRepository:INhaPhanPhoiRepository
    {
        private IDatabaseHelper _dbHelper;
        public NhaPhanPhoiRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public NhaPhanPhoiModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_npp_get_by_id",
                     "@MaNPP", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<NhaPhanPhoiModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(NhaPhanPhoiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_npp_create",
                "@TenNhaPhanPhoi", model.TenNhaPhanPhoi,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai,
                "@MoTa", model.MoTa);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(NhaPhanPhoiModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_npp_update",
                "@MaNPP", model.MaNPP,
                "@TenNhaPhanPhoi", model.TenNhaPhanPhoi,
                "@DiaChi", model.DiaChi,
                "@SoDienThoai", model.SoDienThoai,
                "@MoTa", model.MoTa);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<NhaPhanPhoiModel> Search(int pageIndex, int pageSize, out long total, string ten_npp, string dia_chi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_npp_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_npp", ten_npp,
                    "@dia_chi", dia_chi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<NhaPhanPhoiModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool Delete(string Id)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_npp_delete",
                     "@MaNPP", Id);
                if ((result != null && !string.IsNullOrEmpty(result.ToString())) || !string.IsNullOrEmpty(msgError))
                {
                    throw new Exception(Convert.ToString(result) + msgError);
                }
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
