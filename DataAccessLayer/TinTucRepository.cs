using DataModel;

namespace DataAccessLayer
{
    public class TinTucRepository:ITinTucRepository
    {
        private IDatabaseHelper _dbHelper;
        public TinTucRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public TinTucModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_tintuc_get_by_id",
                     "@MaTT", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<TinTucModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(TinTucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tintuc_create",
                "@TieuDe", model.TieuDe,
                "@AnhDaiDien", model.AnhDaiDien,
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
        public bool Update(TinTucModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tintuc_update",
                "@MaTT", model.MaTinTuc,
                "@TieuDe", model.TieuDe,
                "@AnhDaiDien", model.AnhDaiDien,
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

        public List<TinTucModel> Search(int pageIndex, int pageSize, out long total, string tieu_de, string mo_ta)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_tintuc_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@tieu_de", tieu_de,
                    "@mo_ta", mo_ta);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<TinTucModel>().ToList();
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
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_tintuc_delete",
                     "@MaTT", Id);
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
        public bool DeleteS(TinTucModel_deletes model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_tintuc_deleteS",
                "@list_json_matt", model.list_json_matt != null ? MessageConvert.SerializeObject(model.list_json_matt) : null);
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
