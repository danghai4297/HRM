using HRMSolution.Application.Catalog.NguoiThans.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NguoiThans
{
    public interface INguoiThanService
    {
        Task<List<NguoiThanViewModel>> GetAll(string maNhanVien);
        Task<NguoiThanViewModel> GetNguoiThan(int id);
    }
}
