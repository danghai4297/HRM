﻿using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucPhongBans
{
    public interface IDepartmentCategoryService
    {
        Task<int> Create(DanhMucPhongBanCreateRequest request);
        Task<int> Update(int id,DanhMucPhongBanUpdateRequest request);
        Task<int> Delete(int idDanhMucPhongBan);
        Task<List<DanhMucPhongBanViewModel>> GetAll();
        Task<DanhMucPhongBanViewModel> GetById(int id);
    }
}
