
using HRMSolution.Application.Catalog.DanhMucChucDanhs.DchucDanhs;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.DanhMucChucDanhs
{
    public class DanhMucChucDanhService : IDanhMucChucDanhService
    {
        private readonly HRMDbContext _context;
        public DanhMucChucDanhService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucChucDanhCreateRequest request)
        {
            if (request.maChucDanh == null || request.tenChucDanh == null)
            {
                return 0;
            }
            else
            {
                var danhMucChucDanh = new DanhMucChucDanh()
                {
                    tenChucDanh = request.tenChucDanh,
                    maChucDanh = request.maChucDanh,
                    phuCap = request.phuCap
                };
                _context.danhMucChucDanhs.Add(danhMucChucDanh);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }

        }

        public async Task<int> Delete(int idDanhMucChucDanh)
        {
            var danhMucChucDanh = await _context.danhMucChucDanhs.FindAsync(idDanhMucChucDanh);
            if (danhMucChucDanh == null)
            {
                return 0;
            }
            else
            {
                _context.danhMucChucDanhs.Remove(danhMucChucDanh);
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }

        public async Task<List<DanhMucChucDanhViewModel>> GetAll()
        {
            var query = from p in _context.danhMucChucDanhs select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucChucDanhViewModel()
                {
                    id = x.id,
                    maChucDanh = x.maChucDanh,
                    tenChucDanh = x.tenChucDanh,
                    phuCap = x.phuCap
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucChucDanhViewModel> GetById(int id)
        {
            var dmcd = await _context.danhMucChucDanhs.FindAsync(id);
            if (dmcd == null)
            {
                return null;
            }
            else
            {
                var query = from p in _context.danhMucChucDanhs where p.id == id select p;
                var data = await query.Select(x => new DanhMucChucDanhViewModel()
                {
                    id = x.id,
                    maChucDanh = x.maChucDanh,
                    tenChucDanh = x.tenChucDanh,
                    phuCap = x.phuCap
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id, DanhMucChucDanhUpdateRequest request)
        {
            var danhMucChucDanh = await _context.danhMucChucDanhs.FindAsync(id);
            if (danhMucChucDanh == null || request.maChucDanh == null || request.tenChucDanh == null)
            {
                return 0;
            }
            else
            {
                danhMucChucDanh.maChucDanh = request.maChucDanh;
                danhMucChucDanh.tenChucDanh = request.tenChucDanh;
                danhMucChucDanh.phuCap = request.phuCap;
                var result = await _context.SaveChangesAsync();
                if (result == 0)
                {
                    return 0;
                }
                else
                {
                    return 1;
                }
            }
        }
    }
}
