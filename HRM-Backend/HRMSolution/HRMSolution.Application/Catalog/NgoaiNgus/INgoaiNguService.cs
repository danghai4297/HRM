using HRMSolution.Application.Catalog.NgoaiNgus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NgoaiNgus
{
    public interface INgoaiNguService
    {
        Task<NgoaiNguViewModel> GetNgoaiNgu(int id);
    }
}
