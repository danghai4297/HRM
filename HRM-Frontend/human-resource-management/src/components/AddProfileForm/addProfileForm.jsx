import React from "react";
import "./addProfile.scss";
import { useForm } from "react-hook-form";
import PropTypes from "prop-types";
AddProfileForm.propTypes = {
  objectData: PropTypes.object,
};
AddProfileForm.defaultProps = {
  objectData: null,
};
function AddProfileForm(props) {
  const { objectData } = props;
  const { register, handleSubmit } = useForm();
  const onHandleSubmit = (data) => {
    console.log(data);
    objectData(data);
  };
  return (
    <div className="container-form">
      <form
        action=""
        class="profile-form"
        onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="container-st">
          <h3>Thông tin cơ bản</h3>
          <h5>Thông tin chung</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="maNhanVien">Mã Nhân Viên</label>
                <input
                  type="text"
                  {...register("maNhanVien")}
                  id="maNhanVien"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="atm">TK ngân hàng</label>
                <input
                  type="text"
                  {...register("atm")}
                  id="atm"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="hoVaTen">Họ và tên</label>
                <input
                  type="text"
                  {...register("hoVaTen")}
                  id="hoVaTen"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="nganHang">Ngân Hàng</label>
                <input
                  type="text"
                  {...register("nganHang")}
                  id="nganHang"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="gioiTinh">Giới tính</label>
                <select
                  type="text"
                  {...register("gioiTinh")}
                  id="gioiTinh"
                  className="form-control"
                >
                  <option value=""></option>
                  <option value="true">Nam</option>
                  <option value="false">Nữ</option>
                </select>
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="honnhan">Tình trạng hôn nhân</label>
                <select
                  type="text"
                  {...register("honnhan")}
                  id="honnhan"
                  className="form-control"
                >
                  <option value=""></option>
                  <option value="1">Độc thân</option>
                  <option value="2">Đã có gia đình</option>
                  <option value="3">Ly dị</option>
                </select>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngaySinh">Ngày sinh</label>
                <input
                  type="text"
                  {...register("ngaySinh")}
                  id="ngaySinh"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="noiSinh">Nơi sinh</label>
                <input
                  type="text"
                  {...register("noiSinh")}
                  id="noiSinh"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="danToc">Dân tộc</label>
                <input
                  type="text"
                  {...register("danToc")}
                  id="danToc"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="nguyenQuan">Nguyên Quán</label>
                <input
                  type="text"
                  {...register("nguyenQuan")}
                  id="nguyenQuan"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="tonGiao">Tôn giáo</label>
                <input
                  type="text"
                  {...register("tonGiao")}
                  id="tonGiao"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="thuongTru">HK thường trú</label>
                <input
                  type="text"
                  {...register("thuongTru")}
                  id="thuongTru"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="quocTich">Quốc tịch</label>
                <input
                  type="text"
                  {...register("quocTich")}
                  id="quocTich"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="tamTru">Tạm trú</label>
                <input
                  type="text"
                  {...register("tamTru")}
                  id="tamTru"
                  className="form-control"
                />
              </div>
            </div>
          </div>

          <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="loaiGiayTo">Loại giấy tờ</label>
                <select
                  type="text"
                  {...register("loaiGiayTo")}
                  id="loaiGiayTo"
                  className="form-control"
                >
                  <option value=""></option>
                  <option value="CMND">CMND</option>
                  <option value="CCCD">CCCD</option>
                </select>
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="hoChieu">Số Hộ chiếu</label>
                <input
                  type="text"
                  {...register("hoChieu")}
                  id="hoChieu"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="cccd">Số CMND/CCCD</label>
                <input
                  type="text"
                  {...register("cccd")}
                  id="cccd"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="ngayCapHoChieu">Ngày cấp Hộ chiếu</label>
                <input
                  type="text"
                  {...register("ngayCapHoChieu")}
                  id="atm"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayCapCccd">Ngày cấp(CMNN/CCCD)</label>
                <input
                  type="text"
                  {...register("ngayCapCccd")}
                  id="ngayCapCccd"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="NoiCapHoChieu">Nơi cấp hộ chiếu</label>
                <input
                  type="text"
                  {...register("NoiCapHoChieu")}
                  id="NoiCapHoChieu"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="noiCapCccd">Nơi cấp(CMND/CCCD)</label>
                <input
                  type="text"
                  {...register("noiCapCccd")}
                  id="noiCapCccd"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="ngayHetHanHoChieu">Ngày hết hạn hộ chiếu</label>
                <input
                  type="text"
                  {...register("ngayHetHanHoChieu")}
                  id="ngayHetHanHoChieu"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>

          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayHetHanCccd">Ngay hết hạn</label>
                <input
                  type="text"
                  {...register("ngayHetHanCccd")}
                  id="ngayHetHanCccd"
                  className="form-control"
                />
              </div>
            </div>
          </div>
        </div>
        <div className="container-sec">
          <h3>Thông tin liên hệ</h3>
          <h5>Số điện thoại/Email/Khác</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="dtDiDong">ĐT di động</label>
                <input
                  type="text"
                  {...register("dtDiDong")}
                  id="dtDiDong"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="email">Email cá nhân</label>
                <input
                  type="text"
                  {...register("email")}
                  id="email"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="dtKhac">ĐT khác</label>
                <input
                  type="text"
                  {...register("dtKhac")}
                  id="dtKhac"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="facebook">Facebook</label>
                <input
                  type="text"
                  {...register("facebook")}
                  id="facebook"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="dtNhaRieng">ĐT nhà riêng</label>
                <input
                  type="text"
                  {...register("dtNhaRieng")}
                  id="dtNhaRieng"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="skype">Skype</label>
                <input
                  type="text"
                  {...register("skype")}
                  id="skype"
                  className="form-control"
                />
              </div>
            </div>
          </div>

          <h5>Liên hệ khẩn cấp</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="lhkc_HoVaTen">Họ và tên</label>
                <input
                  type="text"
                  {...register("lhkc_hoVaTen")}
                  id="lhkc_hoVaTen"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="lhkc_dtNhaRieng">ĐT nhà riêng</label>
                <input
                  type="text"
                  {...register("lhkc_dtNhaRieng")}
                  id="lhkc_dtNhaRieng"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="lhkc_quanHe">Quan hệ</label>
                <input
                  type="text"
                  {...register("lhkc_quanHe")}
                  id="lhkc_quanHe"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="lhkc_email">Email</label>
                <input
                  type="text"
                  {...register("lhkc_email")}
                  id="lhkc_email"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="lhkc_dtDiDong">ĐT di động</label>
                <input
                  type="text"
                  {...register("lhkc_dtDiDong")}
                  id="lhkc_dtDiDong"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="lhkc_diaChi">Địa chỉ</label>
                <input
                  type="text"
                  {...register("lhkc_diaChi")}
                  id="lhkc_diaChi"
                  className="form-control"
                />
              </div>
            </div>
          </div>
        </div>

        <div className="container-rd">
          <h3>Thông tin công việc</h3>
          <h5>Thông tin nhân viên</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngheNghiep">Nghề nghiệp</label>
                <input
                  type="text"
                  {...register("ngheNghiep")}
                  id="ngheNghiep"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="congViecChinh">Công việc chính</label>
                <input
                  type="text"
                  {...register("congViecChinh")}
                  id="congViecChinh"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayThuViec">Ngày thử việc</label>
                <input
                  type="text"
                  {...register("ngayThuViec")}
                  id="ngayThuViec"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="loaiHopDong">Loại hợp đồng</label>
                <input
                  type="text"
                  {...register("loaiHopDong")}
                  id="loaiHopDong"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayTuyenDung">Ngày tuyển dụng</label>
                <input
                  type="text"
                  {...register("ngayTuyenDung")}
                  id="ngayTuyenDung"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="ngayVaoBan">Ngày vào ban</label>
                <input
                  type="text"
                  {...register("ngayVaoBan")}
                  id="ngayVaoBan"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="coQuanTuyenDung">Cơ quan tuyển dụng</label>
                <input
                  type="text"
                  {...register("coQuanTuyenDung")}
                  id="coQuanTuyenDung"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="ngayCongTac">Ngày công tác</label>
                <input
                  type="text"
                  {...register("ngayCongTac")}
                  id="ngayCongTac"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="chucVuHienTai">Chức vụ hiện tại</label>
                <input
                  type="text"
                  {...register("chucVuHienTai")}
                  id="chucVuHienTai"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="trangThaiLaoDong">Trạng thái lao động</label>
                <select
                  type="text"
                  {...register("trangThaiLaoDong")}
                  id="trangThaiLaoDong"
                  className="form-control"
                >
                  <option value=""></option>
                  <option value="true">Đang làm việc</option>
                  <option value="false">Đã nghỉ việc</option>
                </select>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="tinhChatLaoDong">Tính chất lao động</label>
                <select
                  type="text"
                  {...register("tinhChatLaoDong")}
                  id="tinhChatLaoDong"
                  className="form-control"
                >
                  <option value=""></option>
                  <option value="">Thực tập sinh</option>
                  <option value="">Học việc</option>
                  <option value="">Thử việc</option>
                  <option value="">Chính thức</option>
                  <option value="">Tạm đình chỉ công tác</option>
                  <option value="">Nghỉ thai sản</option>
                  <option value="">Khác</option>
                </select>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="lyDoNghi">Lý do nghỉ</label>
                <input
                  type="text"
                  {...register("lyDoNghi")}
                  id="lyDoNghi"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayNghiViec">Ngày nghỉ việc</label>
                <input
                  type="text"
                  {...register("ngayNghiViec")}
                  id="ngayNghiViec"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>
        </div>
        <div className="container-th">
          <h3>Thông tin chính trị, quân sự, y tế</h3>
          <h5>Thông tin chính trị</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngachCongChuc">Ngạch công chức</label>
                <input
                  type="text"
                  {...register("ngachCongChuc")}
                  id="ngachCongChuc"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="ngayVaoDoan">Ngày vào đoàn</label>
                <input
                  type="text"
                  {...register("ngayVaoDoan")}
                  id="ngayVaoDoan"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayVaoDang">Ngày vào đảng</label>
                <input
                  type="text"
                  {...register("ngayVaoDang")}
                  id="ngayVaoDang"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="NoiThamGia">Nơi tham gia</label>
                <input
                  type="text"
                  {...register("NoiThamGia")}
                  id="NoiThamGia"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayChinhThuc">Ngày chính thức</label>
                <input
                  type="text"
                  {...register("ngayChinhThuc")}
                  id="ngayChinhThuc"
                  className="form-control"
                />
              </div>
            </div>
          </div>

          <h5>Thông tin quân sự</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="quanNhan">Là quân nhân</label>
                <input
                  type="checkbox"
                  {...register("quanNhan")}
                  id="quanNhan"
                  className=""
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="laThuongBinh">Là thương binh</label>
                <input
                  type="checkbox"
                  {...register("laThuongBinh")}
                  id="laThuongBinh"
                  className=""
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayNhapNgu">Ngày Nhập Ngũ</label>
                <input
                  type="text"
                  {...register("ngayNhapNgu")}
                  id="ngayNhapNgu"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="giaDinhChinhSach">
                  Là con gia đình chính sách
                </label>
                <input
                  type="checkbox"
                  {...register("giaDinhChinhSach")}
                  id="giaDinhChinhSach"
                  className=""
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="ngayXuatNgu">Ngày xuất ngũ</label>
                <input
                  type="text"
                  {...register("ngayXuatNgu")}
                  id="ngayXuatNgu"
                  className="form-control"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="quanHam">Quân hàm cao nhất</label>
                <input
                  type="text"
                  {...register("quanHam")}
                  id="quanHam"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="danhHieu">DH được phong tặng cao nhất</label>
                <input
                  type="text"
                  {...register("danhHieu")}
                  id="danhHieu"
                  className="form-control"
                />
              </div>
            </div>
          </div>

          <h5>Thông tin y tế</h5>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="nhomMau">Nhóm máu</label>
                <input
                  type="text"
                  {...register("nhomMau")}
                  id="nhomMau"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="benhTat">Bệnh tật</label>
                <input
                  type="text"
                  {...register("benhTat")}
                  id="benhTat"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="chieuCao">Chiều cao(cm)</label>
                <input
                  type="text"
                  {...register("chieuCao")}
                  id="chieuCao"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="luuY">Lưu ý</label>
                <input
                  type="text"
                  {...register("luuY")}
                  id="luuY"
                  className="form-control"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="canNang">Cân nặng(kg)</label>
                <input
                  type="text"
                  {...register("canNang")}
                  id="canNang"
                  className="form-control"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group">
                <label htmlFor="nguoinKhuyetTat">Là người khuyết tật</label>
                <input
                  type="checkbox"
                  {...register("nguoinKhuyetTat")}
                  id="nguoinKhuyetTat"
                  className=""
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group">
                <label htmlFor="tinhTrangSucKhoe">Tình trạng sức khoẻ</label>
                <input
                  type="text"
                  {...register("tinhTrangSucKhoe")}
                  id="tinhTrangSucKhoe"
                  className="form-control"
                />
              </div>
            </div>
          </div>
        </div>
        <input type="submit" className="btn btn-primary" />
      </form>
    </div>
  );
}

export default AddProfileForm;
