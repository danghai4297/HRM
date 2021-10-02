import React from "react";
import PropTypes from "prop-types";
import "./AddSalaryForm.scss";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../FontAwesomeIcons/index";
AddSalaryForm.propTypes = {
  objectData: PropTypes.object,
};
AddSalaryForm.defaultProps = {
  objectData: null,
};
const schema = yup.object({
  hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  loaiHopDong: yup.string().required("Loại hợp đồng không được bỏ trống."),
  nhomLuong: yup.string().required("Nhóm lương không được bỏ trống."),
  heSoLuong: yup.string().required("Hệ số lương không được bỏ trống."),
  bacLuong: yup.string().required("Bậc lương không được bỏ trống."),
  ngayHetHan: yup.string().required("Ngày hết hạn không được bỏ trống."),
  ngayCoHieuLuc: yup.string().required("Ngày có hiệu lực không được bỏ trống."),
});
function AddSalaryForm(props) {
  const { objectData } = props;
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
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
          <div>
            <h2 className="">Thêm hồ sơ lương</h2>
          </div>
          <div className="button">
            <input type="submit" className="btn btn-secondary " value="Huỷ" />
            <input type="submit" className="btn btn-primary ml-3" value="Lưu" />
          </div>
        </div>

        <div className="container-div-form">
          <div className="container-salary">
            <div>
              <h3>Thông tin chung</h3>
            </div>
            <div className="">
              <span className="mr-3">Tiền Lương: 100000000000000000</span>
              <button><FontAwesomeIcon className="icon" icon={["fas", "money-check-alt"]} /></button>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="hoVaTen">
                  Họ và tên
                </label>
                <select
                  type="text"
                  {...register("hoVaTen")}
                  id="hoVaTen"
                  className={
                    !errors.hoVaTen
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                >
                  <option value=""></option>
                  <option>Hai nd</option>
                </select>
                <span className="message">{errors.hoVaTen?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="maNhanVien"
                >
                  Mã nhân viên
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
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline ">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="loaiHopDong"
                >
                  Loại hợp đồng
                </label>
                <select
                  type="text"
                  {...register("loaiHopDong")}
                  id="loaiHopDong"
                  className={
                    !errors.loaiHopDong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                >
                  <option value=""></option>
                  <option>ádasdasd</option>
                </select>
                <span className="message">{errors.loaiHopDong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="nhomLuong"
                >
                  Nhóm lương
                </label>
                <select
                  type="text"
                  {...register("nhomLuong")}
                  id="nhomLuong"
                  className={
                    !errors.nhomLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                >
                  <option value=""></option>
                  <option>123</option>
                </select>
                <span className="message">{errors.nhomLuong?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="heSoLuong"
                >
                  Hệ số lương
                </label>
                <input
                  type="text"
                  {...register("heSoLuong")}
                  id="heSoLuong"
                  className={
                    !errors.heSoLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.heSoLuong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="bacLuong"
                >
                  Bậc lương
                </label>
                <input
                  type="text"
                  {...register("bacLuong")}
                  id="bacLuong"
                  className={
                    !errors.bacLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.bacLuong?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="phuCap">
                  Phụ cấp chức vụ
                </label>
                <input
                  type="text"
                  {...register("phuCap")}
                  id="phuCap"
                  className={
                    !errors.phuCap
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.phuCap?.message}</span>
              </div>
            </div>
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="phuCapKhac"
                >
                  Phụ cấp khác
                </label>
                <input
                  type="text"
                  {...register("phuCapKhac")}
                  id="phuCapKhac"
                  className={
                    !errors.phuCapKhac
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.phuCapKhac?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="thoiHanLenLuong"
                >
                  Thời hạn lên lương
                </label>
                <input
                  type="text"
                  {...register("thoiHanLenLuong")}
                  id="thoiHanLenLuong"
                  className={
                    !errors.thoiHanLenLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">
                  {errors.thoiHanLenLuong?.message}
                </span>
              </div>
            </div>
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayHetHan"
                >
                  Ngày hết hạn
                </label>
                <input
                  type="text"
                  {...register("ngayHetHan")}
                  id="ngayHetHan"
                  className={
                    !errors.ngayHetHan
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.ngayHetHan?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayCoHieuLuc"
                >
                  Ngày có hiệu lực
                </label>
                <input
                  type="text"
                  {...register("ngayCoHieuLuc")}
                  id="ngayCoHieuLuc"
                  className={
                    !errors.ngayCoHieuLuc
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.ngayCoHieuLuc?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddSalaryForm;
