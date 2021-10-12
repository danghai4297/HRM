using HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucHinhThucDaoTaos
{
    public interface IDanhMucHinhThucDaoTaoService
    {
        Task<int> Create(DanhMucHinhThucDaoTaoCreateRequest request);
        Task<int> Update(DanhMucHinhThucDaoTaoUpdateRequest request);
        Task<int> Delete(int idDanhMucHinhThucDaoTao);
        Task<List<DanhMucHinhThucDaoTaoViewModel>> GetAll();
    }
}
