import React from "react";
import "./addProfile.scss";
import { Controller, useForm } from "react-hook-form";
import PropTypes from "prop-types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../FontAwesomeIcons/index";
import { useState } from "react";
import { DatePicker } from "antd";
import "antd/dist/antd.css";

AddProfileForm.propTypes = {
  objectData: PropTypes.object,
};
AddProfileForm.defaultProps = {
  objectData: null,
};
function AddProfileForm(props) {
  const { objectData } = props;
  const [checked, setCheked] = useState(false);
  const handleClick = () => setCheked(!checked);
  //const [date, setDate] = useState(new Date());

  console.log(checked);
  //console.log(date);

  const { register, handleSubmit, control } = useForm();
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
        <div className="Submit-button sticky-top">
          <h2 className="">Thêm mới hồ sơ</h2>
          <div className="button">
            <input type="submit" className="btn btn-secondary " value="Huỷ" />
            <input type="submit" className="btn btn-primary ml-3" value="Lưu" />
          </div>
        </div>
        <div className="container-ava">
          <span>
            {" "}
            <FontAwesomeIcon
              className="icon"
              icon={["fas", "user-circle"]}
            ></FontAwesomeIcon>
          </span>
          <input
            type="file"
            {...register("img")}
            class="form-control-file"
          ></input>
        </div>
        <div className="container-div-form">
          <h3>Thông tin cơ bản</h3>
          <h5>Thông tin chung</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="maNhanVien">
                  Mã Nhân Viên
                </label>
                <input
                  type="text"
                  {...register("maNhanVien")}
                  id="maNhanVien"
                  className="form-control col-sm-6 "
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="atm">TK ngân hàng</label>
                <input
                  type="text"
                  {...register("atm")}
                  id="atm"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline ">
                <label class="col-sm-4 justify-content-start" htmlFor="hoVaTen">Họ và tên</label>
                <input
                  type="text"
                  {...register("hoVaTen")}
                  id="hoVaTen"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="nganHang">Ngân Hàng</label>
                <input
                  type="text"
                  {...register("nganHang")}
                  id="nganHang"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="gioiTinh">Giới tính</label>
                <select
                  type="text"
                  {...register("gioiTinh")}
                  id="gioiTinh"
                  className="form-control col-sm-6"
                >
                  <option value=""></option>
                  <option value="true">Nam</option>
                  <option value="false">Nữ</option>
                </select>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="honnhan">Tình trạng hôn nhân</label>
                <select
                  type="text"
                  {...register("honnhan")}
                  id="honnhan"
                  className="form-control col-sm-6"
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
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngaySinh">Ngày sinh</label>
                <input
                  type="text"
                  {...register("ngaySinh")}
                  id="ngaySinh"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                />
                {/* <Controller
                  name="ngaySinh"
                  control={control}
                  defaultValue=""
                  render={({ field }) => (
                    <DatePicker
                      id="ngaySinh"
                      className="form-control"
                      placeholder="DD/MM/YYYY"
                      format="DD/MM/YYYY"
                      //selected={field}
                      //onChange={(field) => setDate(field)}
                      {...field}
                    />
                  )}
                /> */}
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="noiSinh">Nơi sinh</label>
                <input
                  type="text"
                  {...register("noiSinh")}
                  id="noiSinh"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="danToc">Dân tộc</label>
                <input
                  type="text"
                  {...register("danToc")}
                  id="danToc"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="nguyenQuan">Nguyên Quán</label>
                <input
                  type="text"
                  {...register("nguyenQuan")}
                  id="nguyenQuan"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tonGiao">Tôn giáo</label>
                <input
                  type="text"
                  {...register("tonGiao")}
                  id="tonGiao"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="thuongTru">HK thường trú</label>
                <input
                  type="text"
                  {...register("thuongTru")}
                  id="thuongTru"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="quocTich">Quốc tịch</label>
                <input
                  type="text"
                  {...register("quocTich")}
                  id="quocTich"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tamTru">Tạm trú</label>
                <input
                  type="text"
                  {...register("tamTru")}
                  id="tamTru"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>

          <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="loaiGiayTo">Loại giấy tờ</label>
                <select
                  type="text"
                  {...register("loaiGiayTo")}
                  id="loaiGiayTo"
                  className="form-control col-sm-6"
                >
                  <option value=""></option>
                  <option value="CMND">CMND</option>
                  <option value="CCCD">CCCD</option>
                </select>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="hoChieu">Số Hộ chiếu</label>
                <input
                  type="text"
                  {...register("hoChieu")}
                  id="hoChieu"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="cccd">Số CMND/CCCD</label>
                <input
                  type="text"
                  {...register("cccd")}
                  id="cccd"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayCapHoChieu">Ngày cấp Hộ chiếu</label>
                <input
                  type="text"
                  {...register("ngayCapHoChieu")}
                  id="atm"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayCapCccd">Ngày cấp(CMNN/CCCD)</label>
                <input
                  type="text"
                  {...register("ngayCapCccd")}
                  id="ngayCapCccd"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="NoiCapHoChieu">Nơi cấp hộ chiếu</label>
                <input
                  type="text"
                  {...register("NoiCapHoChieu")}
                  id="NoiCapHoChieu"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="noiCapCccd">Nơi cấp(CMND/CCCD)</label>
                <input
                  type="text"
                  {...register("noiCapCccd")}
                  id="noiCapCccd"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayHetHanHoChieu">Ngày hết hạn hộ chiếu</label>
                <input
                  type="text"
                  {...register("ngayHetHanHoChieu")}
                  id="ngayHetHanHoChieu"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>

          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayHetHanCccd">Ngày hết hạn</label>
                <input
                  type="text"
                  {...register("ngayHetHanCccd")}
                  id="ngayHetHanCccd"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
        </div>
        <div className="container-div-form">
          <h3>Thông tin liên hệ</h3>
          <h5>Số điện thoại/Email/Khác</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="dtDiDong">ĐT di động</label>
                <input
                  type="text"
                  {...register("dtDiDong")}
                  id="dtDiDong"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="email">Email cá nhân</label>
                <input
                  type="text"
                  {...register("email")}
                  id="email"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="dtKhac">ĐT khác</label>
                <input
                  type="text"
                  {...register("dtKhac")}
                  id="dtKhac"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="facebook">Facebook</label>
                <input
                  type="text"
                  {...register("facebook")}
                  id="facebook"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="dtNhaRieng">ĐT nhà riêng</label>
                <input
                  type="text"
                  {...register("dtNhaRieng")}
                  id="dtNhaRieng"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="skype">Skype</label>
                <input
                  type="text"
                  {...register("skype")}
                  id="skype"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>

          <h5>Liên hệ khẩn cấp</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lhkc_HoVaTen">Họ và tên</label>
                <input
                  type="text"
                  {...register("lhkc_hoVaTen")}
                  id="lhkc_hoVaTen"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lhkc_dtNhaRieng">ĐT nhà riêng</label>
                <input
                  type="text"
                  {...register("lhkc_dtNhaRieng")}
                  id="lhkc_dtNhaRieng"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lhkc_quanHe">Quan hệ</label>
                <input
                  type="text"
                  {...register("lhkc_quanHe")}
                  id="lhkc_quanHe"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lhkc_email">Email</label>
                <input
                  type="text"
                  {...register("lhkc_email")}
                  id="lhkc_email"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lhkc_dtDiDong">ĐT di động</label>
                <input
                  type="text"
                  {...register("lhkc_dtDiDong")}
                  id="lhkc_dtDiDong"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lhkc_diaChi">Địa chỉ</label>
                <input
                  type="text"
                  {...register("lhkc_diaChi")}
                  id="lhkc_diaChi"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
        </div>

        <div className="container-div-form">
          <h3>Thông tin công việc</h3>
          <h5>Thông tin nhân viên</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngheNghiep">Nghề nghiệp</label>
                <input
                  type="text"
                  {...register("ngheNghiep")}
                  id="ngheNghiep"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="congViecChinh">Công việc chính</label>
                <input
                  type="text"
                  {...register("congViecChinh")}
                  id="congViecChinh"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayThuViec">Ngày thử việc</label>
                <input
                  type="text"
                  {...register("ngayThuViec")}
                  id="ngayThuViec"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="loaiHopDong">Loại hợp đồng</label>
                <input
                  type="text"
                  {...register("loaiHopDong")}
                  id="loaiHopDong"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayTuyenDung">Ngày tuyển dụng</label>
                <input
                  type="text"
                  {...register("ngayTuyenDung")}
                  id="ngayTuyenDung"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayVaoBan">Ngày vào ban</label>
                <input
                  type="text"
                  {...register("ngayVaoBan")}
                  id="ngayVaoBan"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label  class="col-sm-4 justify-content-start" htmlFor="coQuanTuyenDung">Cơ quan tuyển dụng</label>
                <input
                  type="text"
                  {...register("coQuanTuyenDung")}
                  id="coQuanTuyenDung"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayCongTac">Ngày công tác</label>
                <input
                  type="text"
                  {...register("ngayCongTac")}
                  id="ngayCongTac"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="chucVuHienTai">Chức vụ hiện tại</label>
                <input
                  type="text"
                  {...register("chucVuHienTai")}
                  id="chucVuHienTai"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="trangThaiLaoDong">Trạng thái lao động</label>
                <select
                  type="text"
                  {...register("trangThaiLaoDong")}
                  id="trangThaiLaoDong"
                  className="form-control col-sm-6"
                >
                  <option value=""></option>
                  <option value="true">Đang làm việc</option>
                  <option value="false">Đã nghỉ việc</option>
                </select>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tinhChatLaoDong">Tính chất lao động</label>
                <select
                  type="text"
                  {...register("tinhChatLaoDong")}
                  id="tinhChatLaoDong"
                  className="form-control col-sm-6"
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
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lyDoNghi">Lý do nghỉ</label>
                <input
                  type="text"
                  {...register("lyDoNghi")}
                  id="lyDoNghi"
                  className="form-control col-sm-6"
                  disabled="true"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayNghiViec">Ngày nghỉ việc</label>
                <input
                  type="text"
                  {...register("ngayNghiViec")}
                  id="ngayNghiViec"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                  disabled="true"
                />
              </div>
            </div>
          </div>
        </div>
        <div className="container-div-form2">
          <h3>Thông tin chính trị, quân sự, y tế</h3>
          <h5>Thông tin chính trị</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngachCongChuc">Ngạch công chức</label>
                <input
                  type="text"
                  {...register("ngachCongChuc")}
                  id="ngachCongChuc"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayVaoDoan">Ngày vào đoàn</label>
                <input
                  type="text"
                  {...register("ngayVaoDoan")}
                  id="ngayVaoDoan"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayVaoDang">Ngày vào đảng</label>
                <input
                  type="text"
                  {...register("ngayVaoDang")}
                  id="ngayVaoDang"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="NoiThamGia">Nơi tham gia</label>
                <input
                  type="text"
                  {...register("NoiThamGia")}
                  id="NoiThamGia"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayChinhThuc">Ngày chính thức</label>
                <input
                  type="text"
                  {...register("ngayChinhThuc")}
                  id="ngayChinhThuc"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>

          <h5>Thông tin quân sự</h5>
          <div className="row">
            <div className="col">
              <div class="form-check mb-2 form-inline">
                <input
                  type="checkbox"
                  {...register("quanNhan")}
                  id="quanNhan"
                  className="form-check-input"
                  onClick={handleClick}
                  checked={checked}
                />
                <label className="form-check-label col-sm-4 justify-content-start " htmlFor="quanNhan">
                  Là quân nhân
                </label>
              </div>
            </div>
            <div className="col">
              <div className="form-check form-inline">
                <input
                  type="checkbox"
                  {...register("laThuongBinh")}
                  id="laThuongBinh"
                  className="form-check-input"
                />
                <label className="form-check-label col-sm-4 justify-content-start" htmlFor="laThuongBinh">
                  Là thương binh
                </label>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayNhapNgu">Ngày nhập ngũ</label>
                <input
                  type="text"
                  {...register("ngayNhapNgu")}
                  id="ngayNhapNgu"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                  disabled={!checked}
                />
              </div>
            </div>
            <div className="col">
              <div className="form-check form-inline">
                <input
                  type="checkbox"
                  {...register("giaDinhChinhSach")}
                  id="giaDinhChinhSach"
                  className="form-check-input"
                />
                <label className="form-check-label col-sm-4 justify-content-start" htmlFor="giaDinhChinhSach">
                  Là con gia đình chính sách
                </label>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayXuatNgu">Ngày xuất ngũ</label>
                <input
                  type="text"
                  {...register("ngayXuatNgu")}
                  id="ngayXuatNgu"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                  disabled={!checked}
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="quanHam">Quân hàm cao nhất</label>
                <input
                  type="text"
                  {...register("quanHam")}
                  id="quanHam"
                  className="form-control col-sm-6"
                  disabled={!checked}
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="danhHieu">DH được phong tặng cao nhất</label>
                <input
                  type="text"
                  {...register("danhHieu")}
                  id="danhHieu"
                  className="form-control col-sm-6"
                  disabled={!checked}
                />
              </div>
            </div>
          </div>

          <h5>Thông tin y tế</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="nhomMau">Nhóm máu</label>
                <input
                  type="text"
                  {...register("nhomMau")}
                  id="nhomMau"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="benhTat">Bệnh tật</label>
                <input
                  type="text"
                  {...register("benhTat")}
                  id="benhTat"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="chieuCao">Chiều cao(cm)</label>
                <input
                  type="text"
                  {...register("chieuCao")}
                  id="chieuCao"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="luuY">Lưu ý</label>
                <input
                  type="text"
                  {...register("luuY")}
                  id="luuY"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="canNang">Cân nặng(kg)</label>
                <input
                  type="text"
                  {...register("canNang")}
                  id="canNang"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
            <div className="col">
              <div className="form-check form-inline">
                <input
                  type="checkbox"
                  {...register("khuyetTat")}
                  id="khuyetTat"
                  className="form-check-input"
                />
                <label className="form-check-label col-sm-4 justify-content-start" htmlFor="khuyetTat">
                  Là người khuyết tật
                </label>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tinhTrangSucKhoe">Tình trạng sức khoẻ</label>
                <input
                  type="text"
                  {...register("tinhTrangSucKhoe")}
                  id="tinhTrangSucKhoe"
                  className="form-control col-sm-6"
                />
              </div>
            </div>
          </div>
        </div>
      </form>
      <div className="footer"></div>
    </div>
  );
}

export default AddProfileForm;
