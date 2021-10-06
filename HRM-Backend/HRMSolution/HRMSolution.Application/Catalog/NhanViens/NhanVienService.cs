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
            var query = from nv in _context.nhanViens
                        join tc in _context.danhMucTinhChatLaoDongs on nv.tinhChatLaoDong equals tc.id
                        join hn in _context.danhMucHonNhans on nv.idDanhMucHonNhan equals hn.id
                        join dt in _context.danhMucDanTocs on nv.idDanToc equals dt.id
                        join tg in _context.danhMucTonGiaos on nv.idTonGiao equals tg.id
                        join pb in _context.danhMucPhongBans on nv.idPhongBan equals pb.id
                        join ncc in _context.danhMucNgachCongChucs on nv.idNgachCongChuc equals ncc.id
                        join to in _context.danhMucTos on nv.to equals to.idTo
                        
                        select new { nv, tc,dt,  hn, tg,pb,ncc,to };


            var data = await query.Select(x => new NhanVienViewModel()
            {
                maNhanVien = x.nv.maNhanVien,
                hoTen = x.nv.hoTen,
                quocTich = x.nv.quocTich,
                ngaySinh = x.nv.ngaySinh,
                gioiTinh = x.nv.gioiTinh == true ?"Nam": "Nữ",
                dienThoai = x.nv.dienThoai,
                dienThoaiKhac = x.nv.dienThoaiKhac,
                diDong = x.nv.diDong,
                facebook = x.nv.facebook,
                skype = x.nv.skype,
                maSoThue = x.nv.maSoThue,
                cccd = x.nv.cccd,
                noiCapCCCD = x.nv.noiCapCCCD,
                ngayCapCCCD = x.nv.ngayCapCCCD,
                ngayHetHanCCCD = x.nv.ngayHetHanCCCD,
                hoChieu = x.nv.hoChieu,
                noiCapHoChieu = x.nv.noiCapHoChieu,
                ngayCapHoChieu = x.nv.ngayCapHoChieu,
                ngayHetHanHoChieu = x.nv.ngayHetHanHoChieu,
                noiSinh = x.nv.noiSinh,
                queQuan = x.nv.queQuan,
                thuongTru = x.nv.thuongTru,
                tamTru = x.nv.tamTru,
                ngheNghiep = x.nv.ngheNghiep,
                chucVuHienTai = x.nv.chucVuHienTai,
                ngayTuyenDung = x.nv.ngayTuyenDung,
                ngayThuViec = x.nv.ngayThuViec,
                congViecChinh = x.nv.congViecChinh,
                ngayVaoBan = x.nv.ngayVaoBan,
                ngayChinhThuc = x.nv.ngayChinhThuc,
                coQuanTuyenDung = x.nv.coQuanTuyenDung,
                ngachCongChucNoiDung = x.nv.ngachCongChucNoiDung,
                ngayVaoDang = x.nv.ngayVaoDang,
                ngayVaoDangChinhThuc = x.nv.ngayVaoDangChinhThuc,
                ngayNhapNgu = x.nv.ngayNhapNgu,
                ngayXuatNgu = x.nv.ngayXuatNgu,
                quanHamCaoNhat = x.nv.quanHamCaoNhat,
                danhHieuCaoNhat = x.nv.danhHieuCaoNhat,
                ngayVaoDoan = x.nv.ngayVaoDoan,
                noiThamGia = x.nv.noiThamGia,
                laThuongBinh = x.nv.laThuongBinh,
                laConChinhSach = x.nv.laConChinhSach,
                bhxh = x.nv.bhxh,
                bhyt = x.nv.bhyt,
                atm = x.nv.atm,
                nganHang = x.nv.nganHang,
                trangThaiLaoDong = x.nv.trangThaiLaoDong == true ? "Đang làm việc": "Đã nghỉ việc",
                ngayNghiViec = x.nv.ngayNghiViec,
                anh = x.nv.anh,
                tinhChatLaoDong = x.tc.tenTinhChat,
                DanhMucHonNhan = x.hn.tenDanhMuc,
                DanToc= x.dt.tenDanhMuc,
                TonGiao = x.tg.tenDanhMuc,
                PhongBan = x.pb.tenPhongBan,
                to = x.to.tenTo,
                NgachCongChuc = x.ncc.tenNgach

            }).ToListAsync();


            return data;
        }
    }
}
