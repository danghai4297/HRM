using HRMSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class NhanVienDetailViewModel
    {
        public string maNhanVien { get; set; }
        public string hoTen { get; set; }
        public string gioiTinh { get; set; }
        public DateTime ngaySinh { get; set; }
        public string noiSinh { get; set; }
        public string queQuan { get; set; }
        public string thuongTru { get; set; }
        public string tamTru { get; set; }
        public string atm { get; set; }
        public string nganHang { get; set; }
        public string honNhan { get; set; }
        public int? maSoThue { get; set; }
        public string danToc { get; set; }
        public string tonGiao { get; set; }
        public string quocTich { get; set; }
        public string cccd { get; set; }
        public string noiCapCCCD { get; set; }
        public DateTime ngayCapCCCD { get; set; }
        public DateTime ngayHetHanCCCD { get; set; }
        public string hoChieu { get; set; }
        public string noiCapHoChieu { get; set; }
        public DateTime? ngayCapHoChieu { get; set; }
        public DateTime? ngayHetHanHoChieu { get; set; }
        public string dienThoai { get; set; }
        public string dienThoaiKhac { get; set; }
        public string diDong { get; set; }
        public string email { get; set; }
        public string facebook { get; set; }
        public string skype { get; set; }
        public string lhkcHoTen { get; set; }
        public string lhkcQuanHe { get; set; }
        public string lhkcDienThoai { get; set; }
        public string lhkcEmail { get; set; }
        public string lhkcDiaChi { get; set; }
        public string ngheNghiep { get; set; }
        public string coQuanTuyenDung { get; set; }
        public string chucVuHienTai { get; set; }
        public string trangThaiLaoDong { get; set; }
        public string tinhChatLaoDong { get; set; }
        public DateTime? ngayNghiViec { get; set; }
        public string lyDoNghiViec { get; set; }
        public DateTime? ngayTuyenDung { get; set; }
        public DateTime? ngayThuViec { get; set; }
        public string congViecChinh { get; set; }
        public DateTime? ngayVaoBan { get; set; }
        public DateTime? ngayChinhThuc { get; set; }
        public string bhxh { get; set; }
        public string bhyt { get; set; }
        public string ngachCongChuc { get; set; }
        public string ngachCongChucNoiDung { get; set; }
        public string vaoDang { get; set; }
        public DateTime? ngayVaoDang { get; set; }
        public DateTime? ngayVaoDangChinhThuc { get; set; }
        public DateTime? ngayVaoDoan { get; set; }
        public string noiThamGia { get; set; }
        public string quanNhan { get; set; }
        public DateTime? ngayNhapNgu { get; set; }
        public DateTime? ngayXuatNgu { get; set; }
        public string quanHamCaoNhat { get; set; }
        public string danhHieuCaoNhat { get; set; }
        public string thuongBinh { get; set; }
        public string conChinhSach { get; set; }
        public string ytNhomMau { get; set; }
        public float? ytChieuCao { get; set; }
        public float? ytCanNang { get; set; }
        public string ytTinhTrangSucKhoe { get; set; }
        public string ytBenhTat { get; set; }
        public string ytLuuY { get; set; }
        public string ytKhuyetTat { get; set; }
        public string biBatDitu { get; set; }
        public string thamGiaChinhTri { get; set; }
        public string thanNhanNuocNgoai { get; set; }

        public List<TrinhDoVanHoaViewModel> trinhDoVanHoas { get; set; }
        public List<DieuChuyenViewModel> dieuChuyenViewModels { get; set; }
        public List<KhenThuongKyLuatViewModel> khenThuongKyLuatViewModels { get; set; }
        public List<HopDongViewModel> hopDongs { get; set; }
        public List<NgoaiNguViewModel> ngoaiNgus { get; set; }
        public List<NguoiThanViewModel> nguoiThans { get; set; }
    }
}
