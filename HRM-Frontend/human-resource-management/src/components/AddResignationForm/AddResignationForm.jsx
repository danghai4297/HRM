import React from 'react';
import PropTypes from 'prop-types';
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
AddResignationForm.propTypes = {
    objectData: PropTypes.object,
};
AddResignationForm.defaultProps = {
    objectData: null,
  };
  const schema = yup.object({
    hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
    maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
    donViCongTac: yup.string().required("Đơn vị công tác không được bỏ trống."),
    lyDoNghiViec: yup.string().required("Lý do nghỉ việc không được bỏ trống."),
    ngayNghiViec: yup.string().required("Ngày nghỉ việc không được bỏ trống."),
    viTriCongTac: yup.string().required("Vị trí công tác không được bỏ trống."),
  });
function AddResignationForm(props) {
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
            <h2 className="">Thêm thủ tục nghỉ việc</h2>
          </div>
          <div className="button">
            <input type="submit" className="btn btn-secondary " value="Huỷ" />
            <input type="submit" className="btn btn-primary ml-3" value="Lưu" />
          </div>
        </div>

        <div className="container-div-form">
          <div className="container-salary">
            <div>
              <h3>Thủ tục nghỉ việc</h3>
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
                  htmlFor="donViCongTac"
                >
                 Đơn vị công tác
                </label>
                <select
                  type="text"
                  {...register("donViCongTac")}
                  id="donViCongTac"
                  className={
                    !errors.donViCongTac
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                >
                  <option value=""></option>
                  <option>ádasdasd</option>
                </select>
                <span className="message">{errors.donViCongTac?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="viTriCongTac"
                >
                  Vị trí công tác
                </label>
                <select
                  type="text"
                  {...register("viTriCongTac")}
                  id="viTriCongTac"
                  className={
                    !errors.viTriCongTac
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                >
                  <option value=""></option>
                  <option>123</option>
                </select>
                <span className="message">{errors.viTriCongTac?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="lyDoNghiViec"
                >
                  Lý do nghỉ việc
                </label>
                <textarea
                  type="text"
                  rows="4"
                  {...register("lyDoNghiViec")}
                  id="lyDoNghiViec"
                  className={
                    !errors.lyDoNghiViec
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.lyDoNghiViec?.message}</span>
              </div>
            </div>
            
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="ngayNghiViec">
                 Ngày nghỉ việc
                </label>
                <input
                  type="text"
                  row=""
                  {...register("ngayNghiViec")}
                  id="ngayNghiViec"
                  className={
                    !errors.ngayNghiViec
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.ngayNghiViec?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
    );
}

export default AddResignationForm;