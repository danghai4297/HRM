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
            if(request.idDanhMucNgoaiNgu == 0 || request.ngayCap == null || request.noiCap == null || request.trinhDo == null || request.maNhanVien == null)
            {
                return 0;
            } else
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
        }

        public async Task<int> Delete(int idNgoaiNgu)
        {
            var ngoaiNgu = await _context.ngoaiNgus.FindAsync(idNgoaiNgu);
            if (ngoaiNgu == null)
            {
                return 0;
            } else
            {
                _context.ngoaiNgus.Remove(ngoaiNgu);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<NgoaiNguViewModel> GetById(int id)
        {
            var query = from p in _context.ngoaiNgus
                        join dmnn in _context.danhMucNgoaiNgus on p.idDanhMucNgoaiNgu equals dmnn.id
                        join nv in _context.nhanViens on p.maNhanVien equals nv.maNhanVien
                        where p.id == id
                        select new { p, dmnn, nv };

            if(query == null)
            {
                return null;
            } else
            {
                var data = await query.Select(x => new NgoaiNguViewModel()
                {
                    id = x.p.id,
                    danhMucNgoaiNgu = x.dmnn.tenDanhMuc,
                    ngayCap = x.p.ngayCap,
                    trinhDo = x.p.trinhDo,
                    noiCap = x.p.noiCap,
                    maNhanVien = x.p.maNhanVien,
                    tenNhanVien = x.nv.hoTen,
                    idDanhMucNgoaiNgu = x.p.idDanhMucNgoaiNgu
                }).FirstAsync();

                return data;
            }
        }

        public async Task<int> Update(int id, NgoaiNguUpdateRequest request)
        {
            var ngoaiNgu = await _context.ngoaiNgus.FindAsync(id);
            if (ngoaiNgu == null || request.idDanhMucNgoaiNgu == 0 || request.ngayCap == null || request.noiCap == null || request.trinhDo == null || request.maNhanVien == null)
            {
                return 0;
            } else
            {
                ngoaiNgu.idDanhMucNgoaiNgu = request.idDanhMucNgoaiNgu;
                ngoaiNgu.ngayCap = request.ngayCap;
                ngoaiNgu.trinhDo = request.trinhDo;
                ngoaiNgu.noiCap = request.noiCap;
                ngoaiNgu.maNhanVien = request.maNhanVien;

                return await _context.SaveChangesAsync();
            }
        }
    }
}
