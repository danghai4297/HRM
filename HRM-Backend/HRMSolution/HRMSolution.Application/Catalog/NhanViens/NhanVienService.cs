using HRMSolution.Application.Catalog.NhanViens.Dtos;
using HRMSolution.Data.EF;
using HRMSolution.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRMSolution.Application.Catalog.NhanViens
{
    public class NhanVienService : INhanVienService
    {
        private readonly HRMDbContext _context;
        public NhanVienService(HRMDbContext context)
        {
            _context = context;
        }

        public Task<int> Create(NhanVienCreateRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<int> Delete(int idDanhMucDanToc)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(NhanVienUpdateRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<List<NhanVienViewModel>> GetAll()
        {
            var query = from p in _context.nhanViens select p;

            var data = await query.Select(x => new NhanVienViewModel()
            {
                maNhanVien = x.maNhanVien,
                hoTen = x.hoTen,
                quocTich = x.quocTich,
                ngaySinh = x.ngaySinh,
                gioiTinh = x.gioiTinh == true ?"Nam": "Nữ",
                dienThoai = x.dienThoai,
                dienThoaiKhac = x.dienThoaiKhac,
                diDong = x.diDong,
                facebook = x.facebook,
                skype = x.skype,
                maSoThue = x.maSoThue,
                cccd = x.cccd,
                noiCapCCCD = x.noiCapCCCD,
                ngayCapCCCD = x.ngayCapCCCD,
                ngayHetHanCCCD = x.ngayHetHanCCCD,
                hoChieu = x.hoChieu,
                noiCapHoChieu = x.noiCapHoChieu,
                ngayCapHoChieu = x.ngayCapHoChieu,
                ngayHetHanHoChieu = x.ngayHetHanHoChieu,
                noiSinh = x.noiSinh,
                queQuan = x.queQuan,
                thuongTru = x.thuongTru,
                tamTru = x.tamTru,
                ngheNghiep = x.ngheNghiep,
                chucVuHienTai = x.chucVuHienTai,
                ngayTuyenDung = x.ngayTuyenDung,
                ngayThuViec = x.ngayThuViec,
                congViecChinh = x.congViecChinh,
                ngayVaoBan = x.ngayVaoBan,
                ngayChinhThuc = x.ngayChinhThuc,
                coQuanTuyenDung = x.coQuanTuyenDung,
                ngachCongChucNoiDung = x.ngachCongChucNoiDung,
                ngayVaoDang = x.ngayVaoDang,
                ngayVaoDangChinhThuc = x.ngayVaoDangChinhThuc,
                ngayNhapNgu = x.ngayNhapNgu,
                ngayXuatNgu = x.ngayXuatNgu,
                quanHamCaoNhat = x.quanHamCaoNhat,
                danhHieuCaoNhat = x.danhHieuCaoNhat,
                ngayVaoDoan = x.ngayVaoDoan,
                noiThamGia = x.noiThamGia,
                laThuongBinh = x.laThuongBinh,
                laConChinhSach = x.laConChinhSach,
                bhxh = x.bhxh,
                bhyt = x.bhyt,
                atm = x.atm,
                nganHang = x.nganHang,
                trangThaiLaoDong = x.trangThaiLaoDong,
                ngayNghiViec = x.ngayNghiViec,
                anh = x.anh,
                tinhChatLaoDong = x.tinhChatLaoDong,
                idDanhMucHonNhan = x.idDanhMucHonNhan,
                idDanToc= x.idDanToc,
                idTonGiao = x.idTonGiao,
                idPhongBan = x.idPhongBan,
                to = x.to,
                idNgachCongChuc = x.idNgachCongChuc

            }).ToListAsync();


            return data;
        }
    }
}
