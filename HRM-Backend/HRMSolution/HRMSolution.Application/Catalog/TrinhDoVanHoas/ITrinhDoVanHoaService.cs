﻿using HRMSolution.Application.Catalog.TrinhDoVanHoas.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.TrinhDoVanHoas
{
    public interface ITrinhDoVanHoaService
    {
        Task<List<TrinhDoVanHoaViewModel>> GetAll();
        Task<TrinhDoVanHoaViewModel> GetById(int id);
        Task<int> Create(TrinhDoVanHoaCreateRequest request);
        Task<int> Update(int id, TrinhDoVanHoaUpdateRequest request);
        Task<int> Delete(int id);
    }
}
