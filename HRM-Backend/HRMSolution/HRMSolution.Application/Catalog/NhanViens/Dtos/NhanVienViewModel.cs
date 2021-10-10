using System;
using System.Collections.Generic;
using System.Text;

namespace HRMSolution.Application.Catalog.NhanViens.Dtos
{
    public class NhanVienViewModel
    {
        public string maNhanVien { get; set; }
        public string hoTen { get; set; }

        public string quocTich { get; set; }
        public DateTime ngaySinh { get; set; }
        public string gioiTinh { get; set; }
        public string dienThoai { get; set; }
        public string dienThoaiKhac { get; set; }
        public string diDong { get; set; }
        public string email { get; set; }
        public string facebook { get; set; }
        public string skype { get; set; }
        public int? maSoThue { get; set; }
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
        public DateTime? ngayVaoDang { get; set; }
        public DateTime? ngayVaoDangChinhThuc { get; set; }
        public DateTime? ngayNhapNgu { get; set; }
        public DateTime? ngayXuatNgu { get; set; }
        public string quanHamCaoNhat { get; set; }
        public string danhHieuCaoNhat { get; set; }
        public DateTime? ngayVaoDoan { get; set; }
        public string noiThamGia { get; set; }
        public bool? laThuongBinh { get; set; }
        public bool? laConChinhSach { get; set; }
        public string thuongBinh { get; set; }
        public string conChinhSach { get; set; }
        public string bhxh { get; set; }
        public string bhyt { get; set; }
        public string atm { get; set; }
        public string nganHang { get; set; }
        public string trangThaiLaoDong { get; set; }
        public DateTime? ngayNghiViec { get; set; }
        public string lyDoNghiViec { get; set; }
        public string anh { get; set; }

        public string tinhChatLaoDong { get; set; }
        public string DanhMucHonNhan { get; set; }
        public string DanToc { get; set; }
        public string TonGiao { get; set; }
        public string NgachCongChuc { get; set; }
    }
}
