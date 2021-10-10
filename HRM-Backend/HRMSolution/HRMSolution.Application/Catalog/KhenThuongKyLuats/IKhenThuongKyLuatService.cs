﻿using HRMSolution.Application.Catalog.KhenThuongKyLuats.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.KhenThuongKyLuats
{
    public interface IKhenThuongKyLuatService
    {
        Task<int> Create(KhenThuongKyLuatCreateRequest request);
        Task<int> Update(KhenThuongKyLuatUpdateRequest request);
        Task<int> Delete(int idDanhMucDanToc);
        Task<List<KhenThuongKyLuatViewModel>> GetAllKhenThuong();
        Task<KhenThuongKyLuatViewModel> GetAllKhenThuongDetail(string maNhanVien, int id);
        Task<List<KhenThuongKyLuatViewModel>> GetAllKyLuat();
        Task<KhenThuongKyLuatViewModel> GetAllKyLuatDetail(string maNhanVien, int id);
    }
}
