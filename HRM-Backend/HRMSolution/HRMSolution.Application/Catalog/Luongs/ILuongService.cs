﻿using HRMSolution.Application.Catalog.Luongs.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.Luongs
{
    public interface ILuongService
    {
        Task<List<LuongViewModel>> GetAll();
    }
}
