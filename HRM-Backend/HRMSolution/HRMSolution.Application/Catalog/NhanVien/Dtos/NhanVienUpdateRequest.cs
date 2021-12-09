using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class NhanVienUpdateRequest
    {
        public string hoTen { get; set; }
        public string quocTich { get; set; }
        public DateTime ngaySinh { get; set; }
        public bool gioiTinh { get; set; }
        public string dienThoai { get; set; }
        public string dienThoaiKhac { get; set; }
        public string diDong { get; set; }
        public string email { get; set; }
        public string facebook { get; set; }
        public string skype { get; set; }
        public string maSoThue { get; set; }
        public string cccd { get; set; }
        public string noiCapCCCD { get; set; }
        public DateTime ngayCapCCCD { get; set; }
        public DateTime ngayHetHanCCCD { get; set; }
        public string hoChieu { get; set; }
        public string noiCapHoChieu { get; set; }
        public DateTime? ngayCapHoChieu { get; set; }
        public DateTime? ngayHetHanHoChieu { get; set; }
        public string noiSinh { get; set; }
        public string queQuan { get; set; }
        public string thuongTru { get; set; }
        public string tamTru { get; set; }
        public string ngheNghiep { get; set; }
        public string chucVuHienTai { get; set; }
        public DateTime? ngayTuyenDung { get; set; }
        public DateTime? ngayThuViec { get; set; }
        public string congViecChinh { get; set; }
        public DateTime? ngayVaoBan { get; set; }
        public DateTime? ngayChinhThuc { get; set; }
        public string coQuanTuyenDung { get; set; }
        public string ngachCongChucNoiDung { get; set; }
        public bool vaoDang { get; set; }
        public DateTime? ngayVaoDang { get; set; }
        public DateTime? ngayVaoDangChinhThuc { get; set; }
        public bool quanNhan { get; set; }
        public DateTime? ngayNhapNgu { get; set; }
        public DateTime? ngayXuatNgu { get; set; }
        public string quanHamCaoNhat { get; set; }
        public string danhHieuCaoNhat { get; set; }
        public DateTime? ngayVaoDoan { get; set; }
        public string noiThamGia { get; set; }
        public bool laThuongBinh { get; set; }
        public bool laConChinhSach { get; set; }
        public string thuongBinh { get; set; }
        public string conChinhSach { get; set; }
        public string bhxh { get; set; }
        public string bhyt { get; set; }
        public string atm { get; set; }
        public string nganHang { get; set; }
        public bool trangThaiLaoDong { get; set; }
        public DateTime? ngayNghiViec { get; set; }
        public string lyDoNghiViec { get; set; }

        public int tinhChatLaoDong { get; set; }
        public int idDanhMucHonNhan { get; set; }
        public int idDanToc { get; set; }
        public int idTonGiao { get; set; }
        public int idNgachCongChuc { get; set; }
        public string yt_nhomMau { get; set; }
        public float yt_chieuCao { get; set; }
        public float yt_canNang { get; set; }
        public string yt_tinhTrangSucKhoe { get; set; }
        public string yt_benhTat { get; set; }
        public string yt_luuY { get; set; }
        public bool yt_khuyetTat { get; set; }
        public string lsbt_biBatDiTu { get; set; }
        public string lsbt_thamGiaChinhTri { get; set; }
        public string lsbt_thanNhanNuocNgoai { get; set; }
        public string lhkc_hoTen { get; set; }
        public string lhkc_quanHe { get; set; }
        public string lhkc_dienThoai { get; set; }
        public string lhkc_email { get; set; }
        public string lhkc_diaChi { get; set; }

    }
}
