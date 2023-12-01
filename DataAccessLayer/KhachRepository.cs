﻿using DataModel;

namespace DataAccessLayer
{
    public class KhachRepository:IKhachRepository
    {
        private IDatabaseHelper _dbHelper;
        public KhachRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public KhachModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_get_by_id",
                     "@MaKh", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<KhachModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(KhachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_create",
                "@TenKH", model.TenKH,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
                "@Email", model.Email);
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
        public bool Update(KhachModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khach_update",
                "@MaKH", model.MaKH,
                "@TenKH", model.TenKH,
                "@DiaChi", model.DiaChi,
                "@SDT", model.SDT,
                "@Email", model.Email);
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

        public List<KhachModel> Search(int pageIndex, int pageSize, out long total, string ten_khach, string dia_chi)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@ten_khach", ten_khach,
                    "@dia_chi", dia_chi);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<KhachModel>().ToList();
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
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_khach_delete",
                     "@MaKH", Id);
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
        public bool DeleteS(KhachModel_deletes model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_khachhang_deleteS",
                "@list_json_makhachhang", model.list_json_makhachhang != null ? MessageConvert.SerializeObject(model.list_json_makhachhang) : null);
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
