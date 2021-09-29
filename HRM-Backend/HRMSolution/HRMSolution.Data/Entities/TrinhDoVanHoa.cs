using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class TrinhDoVanHoa
    {
        public int id { get; set; }
        public string tenTruong { get; set; }
        public int idChuyenMon { get; set; }
        public DateTime? tuThoiGian { get; set; }
        public DateTime? denThoiGian { get; set; }
        public int idHinhThucDaoTao { get; set; }
        public int idTrinhDo { get; set; }
        public string maNhanVien { get; set; }

        public NhanVien NhanVien { get; set; }
        public HinhThucDaoTao HinhThucDaoTao { get; set; }
        public DanhMucTrinhDo DanhMucTrinhDo { get; set; }
        public DanhMucChuyenMon DanhMucChuyenMon { get; set; }
    }
}
