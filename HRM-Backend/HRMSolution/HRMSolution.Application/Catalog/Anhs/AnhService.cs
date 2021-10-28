using HRMSolution.Application.Common;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using HRMSolution.Utilities.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.Anhs
{
    public class AnhService : IAnhService
    {
        private readonly HRMDbContext _context;
        private readonly IStorageService _storageService;
        private const string USER_CONTENT_FOLDER_NAME = "user-content";
        public AnhService(HRMDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }
        public async Task<int> Create(AnhRequest request)
        {
            var anh = new Anh()
            {
            };
            if (request.anh != null)
            {
                anh.url = await this.SaveFile(request.anh);
            }
            _context.anhs.Add(anh);
            return await _context.SaveChangesAsync();
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return "/" + USER_CONTENT_FOLDER_NAME + "/" + fileName;
        }

        public async Task<int> Update(int id, AnhRequest request)
        {
            var anh = await _context.anhs.FindAsync(id);
            if (anh == null) throw new HRMException($"Không tìm thấy danh mục chức danh có id: {id }");

            anh.url = await this.SaveFile(request.anh);

            return await _context.SaveChangesAsync();
        }
    }
}
