import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";

const schema = yup.object({
  hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  thoiGian: yup.string().required("Thời gian không được bỏ trống."),
  noiDung: yup.string().required("Nội dung không được bỏ trống."),
  lyDo: yup.string().required("Lý do không được bỏ trống."),
});
function AddRewardForm(props) {
  const { history } = props;

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  const onHandleSubmit = (data) => {
    console.log(data);
    JSON.stringify(data);
    history.goBack();
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm thủ tục khen thưởng</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className="btn btn-secondary "
            value="Huỷ"
            onClick={history.goBack}
          />
          <input
            type="submit"
            className="btn btn-primary ml-3"
            value="Lưu"
            onClick={handleSubmit(onHandleSubmit)}
          />
        </div>
      </div>
      <form
        action=""
        class="profile-form"
        // onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="container-div-form">
          <div className="container-salary">
            <div>
              <h3>Thông tin khen thưởng</h3>
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
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
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
            <div className="col-6">
              <div class="form-group form-inline ">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="thoiGian"
                >
                  Thời gian
                </label>
                <input
                  type="text"
                  {...register("thoiGian")}
                  id="thoiGian"
                  className={
                    !errors.thoiGian
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.thoiGian?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="noiDung">
                  Nội dung
                </label>
                <textarea
                  type="text"
                  rows="4"
                  {...register("noiDung")}
                  id="noiDung"
                  className={
                    !errors.noiDung
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.noiDung?.message}</span>
              </div>
            </div>
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="lyDo">
                  Lý do
                </label>
                <textarea
                  type="text"
                  rows="4"
                  {...register("lyDo")}
                  id="lyDo"
                  className={
                    !errors.lyDo
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.lyDo?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddRewardForm;
