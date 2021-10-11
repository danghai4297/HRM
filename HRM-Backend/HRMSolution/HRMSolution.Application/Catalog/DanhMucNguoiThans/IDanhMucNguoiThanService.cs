﻿using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucNguoiThans
{
    public interface IDanhMucNguoiThanService
    {
        Task<int> Create(DanhMucNguoiThanCreateRequest request);
        Task<int> Update(DanhMucNguoiThanUpdateRequest request);
        Task<int> Delete(int idDanhMucNguoiThan);
        Task<List<DanhMucNguoiThanViewModel>> GetAll();
    }
}
