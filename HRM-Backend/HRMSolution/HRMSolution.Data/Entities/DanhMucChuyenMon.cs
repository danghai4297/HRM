using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucChuyenMon
    {
        public int id { get; set; }
        public string tenChuyenMon { get; set; }
        public string maChuyenMon { get; set; }
        public List<TrinhDoVanHoa> TrinhDoVanHoas { get; set; }
    }
}
