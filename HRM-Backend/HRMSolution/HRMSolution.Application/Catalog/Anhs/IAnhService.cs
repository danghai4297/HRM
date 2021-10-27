using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.Anhs
{
    public interface IAnhService
    {
        Task<int> Create(AnhRequest request);
    }
}
