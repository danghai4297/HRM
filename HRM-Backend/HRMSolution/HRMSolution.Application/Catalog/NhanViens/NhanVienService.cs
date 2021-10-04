using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public class NhanVienService : INhanVienService
    {
        private readonly HRMDbContext _context;
        public NhanVienService(HRMDbContext context)
        {
            _context = context;
        }
        public List<NhanVien> GetAll()
        {
            var nhanViens = _context.nhanViens.ToList();
            return nhanViens;
        }
    }
}
