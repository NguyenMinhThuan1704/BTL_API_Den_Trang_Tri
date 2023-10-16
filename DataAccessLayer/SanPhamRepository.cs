using DataModel;

namespace DataAccessLayer
{
    public class SanPhamRepository:ISanPhamRepository
    {
        private IDatabaseHelper _dbHelper;
        public SanPhamRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }
        public SanPhamModel GetDatabyID(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_get_by_id",
                     "@MaSP", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().FirstOrDefault();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<SanPhamModel> GetDatabyIDLQ(string id)
        {
            string msgError = "";
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanphamlienquan_get_by_id",
                     "@MaLSP", id);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                return dt.ConvertTo<SanPhamModel>().ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Create(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sanpham_create",
                "@MaLoaiSanPham", model.MaLoaiSanPham,
                "@TenSanPham", model.TenSanPham,
                "@AnhDaiDien", model.AnhDaiDien,
                "@Gia", model.Gia,
                "@GiaGiam", model.GiaGiam,
                "@SoLuong", model.SoLuong,
                "@TrangThai", model.TrangThai,
                "@LuotXem", model.LuotXem);
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
        public bool Update(SanPhamModel model)
        {
            string msgError = "";
            try
            {
                var result = _dbHelper.ExecuteScalarSProcedureWithTransaction(out msgError, "sp_sanpham_update",
                "@MaSanPham", model.MaSanPham,
                "@MaLoaiSanPham", model.MaLoaiSanPham,
                "@TenSanPham", model.TenSanPham,
                "@AnhDaiDien", model.AnhDaiDien,
                "@Gia", model.Gia,
                "@GiaGiam", model.GiaGiam,
                "@SoLuong", model.SoLuong,
                "@TrangThai", model.TrangThai,
                "@LuotXem", model.LuotXem);
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

        public List<SanPhamModel> Search(int pageIndex, int pageSize, out long total, int maloaisp, string ten_sp, string anh_dai_dien)
        {
            string msgError = "";
            total = 0;
            try
            {
                var dt = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_search",
                    "@page_index", pageIndex,
                    "@page_size", pageSize,
                    "@maloaisp", maloaisp,
                    "@ten_sp", ten_sp,
                    "@anh_dai_dien", anh_dai_dien);
                if (!string.IsNullOrEmpty(msgError))
                    throw new Exception(msgError);
                if (dt.Rows.Count > 0) total = (long)dt.Rows[0]["RecordCount"];
                return dt.ConvertTo<SanPhamModel>().ToList();
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
                var result = _dbHelper.ExecuteSProcedureReturnDataTable(out msgError, "sp_sanpham_delete",
                     "@MaSP", Id);
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
