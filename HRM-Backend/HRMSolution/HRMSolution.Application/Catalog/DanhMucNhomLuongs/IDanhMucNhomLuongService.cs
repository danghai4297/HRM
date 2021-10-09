using HRMSolution.Application.Catalog.DanhMucNhomLuongs.DnhomLuongs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNhomLuongs
{
    public interface IDanhMucNhomLuongService
    {
        Task<List<DanhMucNhomLuongViewModel>> GetAll();
    }
}
