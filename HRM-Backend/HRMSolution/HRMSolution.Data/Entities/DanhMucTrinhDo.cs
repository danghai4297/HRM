using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class DanhMucTrinhDo
    {
        public int id { get; set; }
        public string tenTrinhDo { get; set; }
        public List<TrinhDoVanHoa> trinhDoVanHoas { get; set; }
    }
}
