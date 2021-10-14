using HRMSolution.Application.Catalog.NgoaiNgus.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.NgoaiNgus
{
    public class NgoaiNguService : INgoaiNguService
    {
        private readonly HRMDbContext _context;
        public NgoaiNguService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(NgoaiNguCreateRequest request)
        {
            var ngoaiNgu = new NgoaiNgu()
            {
                idDanhMucNgoaiNgu = request.idDanhMucNgoaiNgu,
                ngayCap = request.ngayCap,
                noiCap = request.noiCap,
                trinhDo = request.trinhDo,
                maNhanVien = request.maNhanVien
            };
            _context.ngoaiNgus.Add(ngoaiNgu);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int idNgoaiNgu)
        {
            var ngoaiNgu = await _context.ngoaiNgus.FindAsync(idNgoaiNgu);
            if (ngoaiNgu == null) throw new HRMException($"Không tìm thấy ngoại ngữ có id : {idNgoaiNgu}");
            _context.ngoaiNgus.Remove(ngoaiNgu);
            return await _context.SaveChangesAsync();
        }

        public async Task<NgoaiNguViewModel> GetNgoaiNgu(int id)
        {
            var query = from p in _context.ngoaiNgus
                        join dmnn in _context.danhMucNgoaiNgus on p.idDanhMucNgoaiNgu equals dmnn.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.id == id
                        select new { p, dmnn, nv };


            var data = await query.Select(x => new NgoaiNguViewModel()
            {
                id = x.p.id,
                danhMucNgoaiNgu = x.dmnn.tenDanhMuc,
                ngayCap = x.p.ngayCap,
                trinhDo = x.p.trinhDo,
                noiCap = x.p.noiCap,
                maNhanVien = x.p.maNhanVien,
                tenNhanVien = x.nv.hoTen
            }).FirstAsync();

            return data;
        }

        public async Task<int> Update(int id, NgoaiNguUpdateRequest request)
        {
            var ngoaiNgu = await _context.ngoaiNgus.FindAsync(id);
            if (ngoaiNgu == null) throw new HRMException($"Không tìm thấy ngoại ngữ có id : {id}");

            ngoaiNgu.idDanhMucNgoaiNgu = request.idDanhMucNgoaiNgu;
            ngoaiNgu.ngayCap = request.ngayCap;
            ngoaiNgu.trinhDo = request.trinhDo;
            ngoaiNgu.noiCap = request.noiCap;
            ngoaiNgu.maNhanVien = request.maNhanVien;

            return await _context.SaveChangesAsync();
        }
    }
}
