﻿using HRMSolution.Application.Catalog.DanhMucPhongBans.DphongBans;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucPhongBans
{
    public interface IDanhMucPhongBanService
    {
        Task<List<DanhMucPhongBanViewModel>> GetAll();
    }
}
