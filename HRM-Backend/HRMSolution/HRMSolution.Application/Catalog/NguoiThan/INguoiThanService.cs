﻿using HRMSolution.Application.Catalog.NguoiThans.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NguoiThans
{
    public interface INguoiThanService
    {
        Task<NguoiThanViewModel> GetById(int id);
        Task<int> Create(NguoiThanCreateRequest request);
        Task<int> Update(int id, NguoiThanUpdateRequest request);
        Task<int> Delete(int id);
    }
}
