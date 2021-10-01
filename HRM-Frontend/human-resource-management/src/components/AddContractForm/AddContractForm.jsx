import React from "react";
import PropTypes from "prop-types";
import "./AddContractForm.scss";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
AddContractForm.propTypes = {
  objectData: PropTypes.object,
};
AddContractForm.defaultProps = {
  objectData: null,
};
const schema = yup.object({
  hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  loaiHopDong: yup.string().required("Loại hợp đồng không được bỏ trống."),
  chucDanh: yup.string().required("Chức danh không được bỏ trống."),
  luongCoBan: yup.string().required("Lương cơ bản không được bỏ trống."),
  ngayHetHanHopDong: yup.string().required("Ngày hết hạn không được bỏ trống."),
  ngayHieuLucHopDong: yup
    .string()
    .required("Ngày có hiệu lực không được bỏ trống."),
});
function AddContractForm(props) {
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
            <h2 className="">Thêm hợp đồng</h2>
          </div>
          <div className="button">
            <input type="submit" className="btn btn-secondary " value="Huỷ" />
            <input type="submit" className="btn btn-primary ml-3" value="Lưu" />
          </div>
        </div>

        <div className="container-div-form">
          <h3>Thông tin chung</h3>
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
                  <option>ádasdasd</option>
                </select>
                <span className="message">{errors.loaiHopDong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="chucDanh"
                >
                  Chức danh công việc
                </label>
                <input
                  type="text"
                  {...register("chucDanh")}
                  id="chucDanh"
                  className={
                    !errors.chucDanh
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.chucDanh?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="luongCoBan"
                >
                  Lương cơ bản
                </label>
                <input
                  type="text"
                  {...register("luongCoBan")}
                  id="luongCoBan"
                  className={
                    !errors.luongCoBan
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.luongCoBan?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayHetHanHopDong"
                >
                  Ngày hết hạn
                </label>
                <input
                  type="text"
                  {...register("ngayHetHanHopDong")}
                  id="ngayHetHanHopDong"
                  className={
                    !errors.ngayHetHanHopDong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">
                  {errors.ngayHetHanHopDong?.message}
                </span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayHieuLucHopDong"
                >
                  Ngày có hiệu lực
                </label>
                <input
                  type="text"
                  {...register("ngayHieuLucHopDong")}
                  id="ngayHieuLucHopDong"
                  className={
                    !errors.ngayHieuLucHopDong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">
                  {errors.ngayHieuLucHopDong?.message}
                </span>
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
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddContractForm;
