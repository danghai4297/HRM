using HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs.DtinhChatLaoDongs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucTinhChatLaoDongs
{
    public interface IDanhMucTinhChatLaoDongService
    {
        Task<List<DanhMucTinhChatLaoDongViewModel>> GetAll();
    }
}
