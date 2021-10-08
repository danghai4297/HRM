import React from "react";
import "./AddProfileForm.scss";
import { Controller, useForm } from "react-hook-form";
import PropTypes from "prop-types";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../FontAwesomeIcons/index";
import { useState } from "react";
//import { DatePicker } from "antd";
import "antd/dist/antd.css";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
const phoneRex = /([\|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})\b/;
const number = /^\d+$/;
const schema = yup.object({
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
  gioiTinh: yup.string().required("Giới tính không được bỏ trống."),
  honNhan: yup.string().required("Hôn nhân không được bỏ trống."),
  ngaySinh: yup.string().required("Ngày sinh không được bỏ trống."),
  noiSinh: yup.string().required("Nơi sinh không được bỏ trống."),
  danToc: yup.string().required("Dân Tộc không được bỏ trống."),
  nguyenQuan: yup.string().required("Nguyên quán không được bỏ trống."),
  tonGiao: yup.string().required("Tôn giáo không được bỏ trống."),
  thuongTru: yup.string().required("HK thường trú không được bỏ trống."),
  quocTich: yup.string().required("Quốc tịch không được bỏ trống."),
  tamTru: yup.string().required("Tạm trú không được bỏ trống."),
  cccd: yup
    .string()
    .matches(number, "CMND/CCCD không được bỏ trống.")
    .min(9, "CMND phải có 9 số/CCCD phải có 12 số")
    .max(12, "CMND phải có 9 số,CCCD phải có 12 số")
    .required(),
  ngayCapCccd: yup.string().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  noiCapCccd: yup.string().required("Nơi cấp CMND/CCCD không được bỏ trống."),
  ngayHetHanCccd: yup
    .string()
    .required("Ngày hết hạn CMND/CCCD không được bỏ trống."),
  dtDiDong: yup
    .string()
    .matches(phoneRex, "Số điện thoại không được bỏ trống và là số.")
    .required(),
  lhkc_hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
  lhkc_quanHe: yup.string().required("Quan hệ không được bỏ trống."),
  lhkc_dtDiDong: yup
    .string()
    .matches(phoneRex, "Số điện thoại không được bỏ trống và là số.")
    .required(),
  lhkc_diaChi: yup.string().required("Địa chỉ không được bỏ trống."),
  ngheNghiep: yup.string().required("Nghề nghiệp không được bỏ trống."),
  ngayTuyenDung: yup.string().required("Ngày tuyển dụng không được bỏ trống."),
  coQuanTuyenDung: yup
    .string()
    .required("Cơ quan tuyển dụng không được bỏ trống."),
  chucVuHienTai: yup.string().required("Chức vụ hiện tại không được bỏ trống."),
  trangThaiLaoDong: yup
    .string()
    .required("Trạng thái lao động không được bỏ trống."),
  tinhChatLaoDong: yup
    .string()
    .required("Tính chất lao động không được bỏ trống."),
  congViecChinh: yup
    .string()
    .required("Tính chất lao động không được bỏ trống."),
  phongBan: yup.string().required("Phòng Ban động không được bỏ trống."),
  ngachCongChuc: yup.string().required("Ngạch công chức không được bỏ trống."),
});
//.required();

AddProfileForm.propTypes = {
  objectData: PropTypes.object,
};
AddProfileForm.defaultProps = {
  objectData: null,
};
function AddProfileForm(props) {
  let { history } = props;
  const { objectData } = props;
  const [checked, setCheked] = useState(false);
  const handleClick = () => setCheked(!checked);

  //const [date, setDate] = useState(new Date());

  console.log(checked);
  //console.log(date);
  const [image, setImage] = useState("/Images/userIcon.png");
  const {
    register,
    handleSubmit,
    //control,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  console.log(errors.maNhanVien);

  const onHandleSubmit = (data) => {
    // console.log(data);
    JSON.stringify(objectData(data));
    //objectData(data);
  };
  const imageHandler = (e) => {
    const reader = new FileReader();
    reader.onload = () => {
      if (reader.readyState === 2) {
        setImage(reader.result);
      }
    };
    reader.readAsDataURL(e.target.files[0]);
  };
  return (
    <div className="container-form">
      <input
        type="submit"
        className="btn btn-secondary "
        value="Huỷ"
        onClick={history.goBack}
      />
      <form
        action=""
        class="profile-form"
        // onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">Thêm mới hồ sơ</h2>
          </div>
          <div className="button">
            {/* <input
              type="submit"
              className="btn btn-secondary "
              value="Huỷ"
              onClick={history.goBack}
            /> */}
            <input
              type="submit"
              className="btn btn-primary ml-3"
              value="Lưu"
              onClick={handleSubmit(onHandleSubmit)}
            />
          </div>
        </div>
        <div className="container-ava">
          <span>
            {" "}
            {/* <FontAwesomeIcon
              className="icon"
              icon={["fas", "user-circle"]}
            ></FontAwesomeIcon> */}
            <img src={image} className="icon" alt="" />
          </span>

          <input
            type="file"
            {...register("img")}
            accept="Images/*"
            class="form-control-file"
            onChange={imageHandler}
          ></input>
        </div>
        <div className="container-div-form">
          <h3>Thông tin cơ bản</h3>
          <h5>Thông tin chung</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="maNhanVien"
                >
                  Mã Nhân Viên
                </label>
                <input
                  type="text"
                  {...register("maNhanVien")}
                  id="maNhanVien"
                  className={
                    !errors.maNhanVien
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.maNhanVien?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="atm">
                  TK ngân hàng
                </label>
                <input
                  type="text"
                  {...register("atm")}
                  id="atm"
                  className={
                    !errors.atm
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.atm?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline ">
                <label class="col-sm-4 justify-content-start" htmlFor="hoVaTen">
                  Họ và tên
                </label>
                <input
                  type="text"
                  {...register("hoVaTen")}
                  id="hoVaTen"
                  className={
                    !errors.maNhanVien
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.hoVaTen?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="nganHang"
                >
                  Ngân Hàng
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="gioiTinh"
                >
                  Giới tính
                </label>
                <select
                  type="text"
                  {...register("gioiTinh")}
                  id="gioiTinh"
                  className={
                    !errors.gioiTinh
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option value=""></option>
                  <option value="true">Nam</option>
                  <option value="false">Nữ</option>
                </select>
                <span className="message">{errors.gioiTinh?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="honNhan">
                  Tình trạng hôn nhân
                </label>
                <select
                  type="text"
                  {...register("honNhan")}
                  id="honNhan"
                  className={
                    !errors.honNhan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option value=""></option>
                  <option value="1">Độc thân</option>
                  <option value="2">Đã có gia đình</option>
                  <option value="3">Ly dị</option>
                </select>
                <span className="message">{errors.honNhan?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngaySinh"
                >
                  Ngày sinh
                </label>
                <input
                  type="text"
                  {...register("ngaySinh")}
                  id="ngaySinh"
                  className={
                    !errors.ngaySinh
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.ngaySinh?.message}</span>
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
                <label class="col-sm-4 justify-content-start" htmlFor="noiSinh">
                  Nơi sinh
                </label>
                <input
                  type="text"
                  {...register("noiSinh")}
                  id="noiSinh"
                  className={
                    !errors.noiSinh
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.noiSinh?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="danToc">
                  Dân tộc
                </label>
                <select
                  type="text"
                  {...register("danToc")}
                  id="danToc"
                  className={
                    !errors.danToc
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                />
                <span className="message">{errors.danToc?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="nguyenQuan"
                >
                  Nguyên quán
                </label>
                <input
                  type="text"
                  {...register("nguyenQuan")}
                  id="nguyenQuan"
                  className={
                    !errors.nguyenQuan
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.nguyenQuan?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tonGiao">
                  Tôn giáo
                </label>
                <select
                  type="text"
                  {...register("tonGiao")}
                  id="tonGiao"
                  className={
                    !errors.tonGiao
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                />
                <span className="message">{errors.tonGiao?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="thuongTru"
                >
                  HK thường trú
                </label>
                <input
                  type="text"
                  {...register("thuongTru")}
                  id="thuongTru"
                  className={
                    !errors.thuongTru
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.thuongTru?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="quocTich"
                >
                  Quốc tịch
                </label>
                <input
                  type="text"
                  {...register("quocTich")}
                  id="quocTich"
                  className={
                    !errors.quocTich
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.quocTich?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tamTru">
                  Tạm trú
                </label>
                <input
                  type="text"
                  {...register("tamTru")}
                  id="tamTru"
                  className={
                    !errors.tamTru
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.tamTru?.message}</span>
              </div>
            </div>
          </div>

          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="baoHiemYte"
                >
                  Bảo hiểm y tế
                </label>
                <input
                  type="text"
                  {...register("baoHiemYte")}
                  id="baoHiemYte"
                  className={
                    !errors.baoHiemYte
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.baoHiemYte?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="baoHiemXaHoi"
                >
                  Bảo hiểm xã hội
                </label>
                <input
                  type="text"
                  {...register("baoHiemXaHoi")}
                  id="baoHiemXaHoi"
                  className={
                    !errors.baoHiemXaHoi
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.baoHiemXaHoi?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="maSoThue"
                >
                  Mã số thuế cá nhân
                </label>
                <input
                  type="text"
                  {...register("maSoThue")}
                  id="maSoThue"
                  className={
                    !errors.maSoThue
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.maSoThue?.message}</span>
              </div>
            </div>
          </div>
          <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="cccd">
                  Số CMND/CCCD
                </label>
                <input
                  type="text"
                  {...register("cccd")}
                  id="cccd"
                  className={
                    !errors.cccd
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.cccd?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="hoChieu">
                  Số Hộ chiếu
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayCapCccd"
                >
                  Ngày cấp(CMNN/CCCD)
                </label>
                <input
                  type="text"
                  {...register("ngayCapCccd")}
                  id="ngayCapCccd"
                  className={
                    !errors.ngayCapCccd
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.ngayCapCccd?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayCapHoChieu"
                >
                  Ngày cấp Hộ chiếu
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="noiCapCccd"
                >
                  Nơi cấp(CMND/CCCD)
                </label>
                <input
                  type="text"
                  {...register("noiCapCccd")}
                  id="noiCapCccd"
                  className={
                    !errors.noiCapCccd
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.noiCapCccd?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="NoiCapHoChieu"
                >
                  Nơi cấp hộ chiếu
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayHetHanCccd"
                >
                  Ngày hết hạn
                </label>
                <input
                  type="text"
                  {...register("ngayHetHanCccd")}
                  id="ngayHetHanCccd"
                  className={
                    !errors.ngayHetHanCccd
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">
                  {errors.ngayHetHanCccd?.message}
                </span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayHetHanHoChieu"
                >
                  Ngày hết hạn hộ chiếu
                </label>
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
        </div>
        <div className="container-div-form">
          <h3>Thông tin liên hệ</h3>
          <h5>Số điện thoại/Email/Khác</h5>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="dtDiDong"
                >
                  ĐT di động
                </label>
                <input
                  type="text"
                  {...register("dtDiDong")}
                  id="dtDiDong"
                  className={
                    !errors.dtDiDong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.dtDiDong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="email">
                  Email cá nhân
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="dtKhac">
                  ĐT khác
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="facebook"
                >
                  Facebook
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="dtNhaRieng"
                >
                  ĐT nhà riêng
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="skype">
                  Skype
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lhkc_hoVaTen"
                >
                  Họ và tên
                </label>
                <input
                  type="text"
                  {...register("lhkc_hoVaTen")}
                  id="lhkc_hoVaTen"
                  className={
                    !errors.lhkc_hoVaTen
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.lhkc_hoVaTen?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lhkc_email"
                >
                  Email
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lhkc_quanHe"
                >
                  Quan hệ
                </label>
                <input
                  type="text"
                  {...register("lhkc_quanHe")}
                  id="lhkc_quanHe"
                  className={
                    !errors.lhkc_quanHe
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.lhkc_quanHe?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lhkc_diaChi"
                >
                  Địa chỉ
                </label>
                <input
                  type="text"
                  {...register("lhkc_diaChi")}
                  id="lhkc_diaChi"
                  className={
                    !errors.lhkc_diaChi
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.lhkc_diaChi?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lhkc_dtDiDong"
                >
                  ĐT di động
                </label>
                <input
                  type="text"
                  {...register("lhkc_dtDiDong")}
                  id="lhkc_dtDiDong"
                  className={
                    !errors.lhkc_dtDiDong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.lhkc_dtDiDong?.message}</span>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngheNghiep"
                >
                  Nghề nghiệp
                </label>
                <input
                  type="text"
                  {...register("ngheNghiep")}
                  id="ngheNghiep"
                  className={
                    !errors.ngheNghiep
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.ngheNghiep?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="congViecChinh"
                >
                  Công việc chính
                </label>
                <input
                  type="text"
                  {...register("congViecChinh")}
                  id="congViecChinh"
                  className={
                    !errors.congViecChinh
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.congViecChinh?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayThuViec"
                >
                  Ngày thử việc
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayCongTac"
                >
                  Ngày chính thức
                </label>
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
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayTuyenDung"
                >
                  Ngày tuyển dụng
                </label>
                <input
                  type="text"
                  {...register("ngayTuyenDung")}
                  id="ngayTuyenDung"
                  className={
                    !errors.ngayTuyenDung
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.ngayTuyenDung?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayVaoBan"
                >
                  Ngày vào ban
                </label>
                <input
                  type="text"
                  {...register("ngayVaoBan")}
                  id="ngayVaoBan"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="coQuanTuyenDung"
                >
                  Cơ quan tuyển dụng
                </label>
                <input
                  type="text"
                  {...register("coQuanTuyenDung")}
                  id="coQuanTuyenDung"
                  className={
                    !errors.coQuanTuyenDung
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">
                  {errors.coQuanTuyenDung?.message}
                </span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="phongBan"
                >
                  Phòng Ban
                </label>
                <select
                  type="text"
                  {...register("phongBan")}
                  id="phongBan"
                  className={
                    !errors.phongBan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                />
                <span className="message">{errors.phongBan?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="chucVuHienTai"
                >
                  Chức vụ hiện tại
                </label>
                <input
                  type="text"
                  {...register("chucVuHienTai")}
                  id="chucVuHienTai"
                  className={
                    !errors.chucVuHienTai
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.chucVuHienTai?.message}</span>
              </div>
            </div>
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="to">
                  Tổ
                </label>
                <select
                  type="text"
                  {...register("to")}
                  id="to"
                  className="form-control col-sm-6 custom-select"
                />
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="trangThaiLaoDong"
                >
                  Trạng thái lao động
                </label>
                <select
                  type="text"
                  {...register("trangThaiLaoDong")}
                  id="trangThaiLaoDong"
                  className={
                    !errors.trangThaiLaoDong
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option value=""></option>
                  <option value="true">Đang làm việc</option>
                  <option value="false">Đã nghỉ việc</option>
                </select>
                <span className="message">
                  {errors.trangThaiLaoDong?.message}
                </span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tinhChatLaoDong"
                >
                  Tính chất lao động
                </label>
                <select
                  type="text"
                  {...register("tinhChatLaoDong")}
                  id="tinhChatLaoDong"
                  className={
                    !errors.tinhChatLaoDong
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
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
                <span className="message">
                  {errors.tinhChatLaoDong?.message}
                </span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lyDoNghi"
                >
                  Lý do nghỉ
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayNghiViec"
                >
                  Ngày nghỉ việc
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngachCongChuc"
                >
                  Ngạch công chức
                </label>
                <input
                  type="text"
                  {...register("ngachCongChuc")}
                  id="ngachCongChuc"
                  className={
                    !errors.ngachCongChuc
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.ngachCongChuc?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayVaoDoan"
                >
                  Ngày vào đoàn
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayVaoDang"
                >
                  Ngày vào đảng
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="NoiThamGia"
                >
                  Nơi tham gia
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayChinhThuc"
                >
                  Ngày chính thức
                </label>
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
                <label
                  className="form-check-label col-sm-4 justify-content-start "
                  htmlFor="quanNhan"
                >
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
                <label
                  className="form-check-label col-sm-4 justify-content-start"
                  htmlFor="laThuongBinh"
                >
                  Là thương binh
                </label>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayNhapNgu"
                >
                  Ngày nhập ngũ
                </label>
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
                <label
                  className="form-check-label col-sm-4 justify-content-start"
                  htmlFor="giaDinhChinhSach"
                >
                  Là con gia đình chính sách
                </label>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayXuatNgu"
                >
                  Ngày xuất ngũ
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="quanHam">
                  Quân hàm cao nhất
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="danhHieu"
                >
                  DH được phong tặng cao nhất
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="nhomMau">
                  Nhóm máu
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="benhTat">
                  Bệnh tật
                </label>
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
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="chieuCao"
                >
                  Chiều cao(cm)
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="luuY">
                  Lưu ý
                </label>
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
                <label class="col-sm-4 justify-content-start" htmlFor="canNang">
                  Cân nặng(kg)
                </label>
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
                <label
                  className="form-check-label col-sm-4 justify-content-start"
                  htmlFor="khuyetTat"
                >
                  Là người khuyết tật
                </label>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tinhTrangSucKhoe"
                >
                  Tình trạng sức khoẻ
                </label>
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
