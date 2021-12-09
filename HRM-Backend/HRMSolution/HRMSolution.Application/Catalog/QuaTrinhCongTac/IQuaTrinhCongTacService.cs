using HRMSolution.Application.Catalog.DieuChuyens.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DieuChuyens
{
    public interface IQuaTrinhCongTacService
    {
        Task<List<QuaTrinhCongTacViewModel>> GetAll();
        Task<QuaTrinhCongTacViewModel> GetById(int id);
        Task<int> Create(QuaTrinhCongTacCreateRequest request);
        Task<int> Update(int id, QuaTrinhCongTacUpdateRequest request);
        Task<int> Delete(int idDieuChuyen);
    }
}
