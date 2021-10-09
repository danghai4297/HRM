﻿using HRMSolution.Application.Catalog.DanhMucTonGiaos.DtonGiaos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTonGiaos
{
    public interface IDanhMucTonGiaoService
    {
        Task<int> Create(DanhMucTonGiaoCreateRequest request);
        Task<List<DanhMucTonGiaoViewModel>> GetAll();
    }
}
