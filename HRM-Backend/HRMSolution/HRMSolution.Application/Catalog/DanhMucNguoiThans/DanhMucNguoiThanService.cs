using HRMSolution.Application.Catalog.DanhMucNguoiThans.Dtos;
using HRMSolution.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;

namespace HRMSolution.Application.Catalog.DanhMucNguoiThans
{
    public class DanhMucNguoiThanService : IDanhMucNguoiThanService
    {
        private readonly HRMDbContext _context;
        public DanhMucNguoiThanService(HRMDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DanhMucNguoiThanCreateRequest request)
        {
            if (request.tenDanhMuc == null)
            {
                return 0;
            } else
            {
                var danhMucNguoiThan = new DanhMucNguoiThan()
                {
                    tenDanhMuc = request.tenDanhMuc

                };
                _context.danhMucNguoiThans.Add(danhMucNguoiThan);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<int> Delete(int idDanhMucNguoiThan)
        {
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(idDanhMucNguoiThan);
            if (danhMucNguoiThan == null)
            {
                return 0;
            } else
            {
                _context.danhMucNguoiThans.Remove(danhMucNguoiThan);
                return await _context.SaveChangesAsync();
            }
        }

        public async Task<List<DanhMucNguoiThanViewModel>> GetAll()
        {
            var query = from p in _context.danhMucNguoiThans select p;
            if(query == null)
            {
                return null;
            } else
            {
                var data = await query.Select(x => new DanhMucNguoiThanViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).ToListAsync();
                return data;
            }
        }

        public async Task<DanhMucNguoiThanViewModel> GetById(int id)
        {
            var query = from p in _context.danhMucNguoiThans where p.id == id select p;
            if (query == null)
            {
                return null;
            }
            else
            {
                var data = await query.Select(x => new DanhMucNguoiThanViewModel()
                {
                    id = x.id,
                    tenDanhMuc = x.tenDanhMuc
                }).FirstAsync();
                return data;
            }
        }

        public async Task<int> Update(int id,DanhMucNguoiThanUpdateRequest request)
        {
            var danhMucNguoiThan = await _context.danhMucNguoiThans.FindAsync(id);
            if (danhMucNguoiThan == null || request.tenDanhMuc == null)
            {
                return 0;
            } else
            {
                danhMucNguoiThan.tenDanhMuc = request.tenDanhMuc;
                return await _context.SaveChangesAsync();
            }
        }
    }
}
