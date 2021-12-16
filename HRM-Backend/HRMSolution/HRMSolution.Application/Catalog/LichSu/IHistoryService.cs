using HRMSolution.Application.Catalog.LichSus.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.LichSus
{
    public interface IHistoryService
    {
        Task<int> Create(LichSuCreateRequest request);
        Task<List<LichSuViewModel>> GetAll();
    }
}
