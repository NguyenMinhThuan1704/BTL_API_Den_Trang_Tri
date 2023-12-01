namespace DataModel
{
    public class TinTucModel
    {
        public int MaTinTuc { get; set; }
        public string TieuDe { get; set; }
        public string AnhDaiDien { get; set; }
        public string MoTa { get; set; }
        public DateTime NgayTao { get; set; }
        //public string ChiTiet { get; set; }
    }

    public class TinTucModel_deletes
    {
        public List<ChiTietTinTucModel> list_json_matt { get; set; }
    }
    public class ChiTietTinTucModel
    {
        public int MaTinTuc { get; set; }
        public int GhiChu { get; set; }

    }
}