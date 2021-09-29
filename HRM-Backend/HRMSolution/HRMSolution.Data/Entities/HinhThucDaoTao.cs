using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Data.Entities
{
    public class HinhThucDaoTao
    {
        public int id { get; set; }
        public string tenHinhThuc { get; set; }
        public List<TrinhDoVanHoa> trinhDoVanHoas { get; set; }
    }
}
