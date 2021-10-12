import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddNestForm.scss";
import ProductApi from "../../../api/productApi";
import { useState } from "react";
const schema = yup.object({
  maTo: yup.string().required("Mã tổ không được bỏ trống."),
  idPhongBan: yup.string().required("Thuộc phòng ban không được bỏ trống."),
  tenTo: yup.string().required("Tổ không được bỏ trống."),
});
function AddNestForm(props) {
  const [nestValue, setNestValue] = useState(null);
  const { history } = props;
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMT(data);
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm danh mục tổ</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={nestValue ? "btn btn-danger" : "delete-button"}
            value="Xoá"
          />
          <input
            type="submit"
            className="btn btn-secondary ml-3"
            value="Huỷ"
            onClick={history.goBack}
          />
          <input
            type="submit"
            className="btn btn-primary ml-3"
            value={nestValue ? "Sửa" : "Lưu"}
            onClick={handleSubmit(onHandleSubmit)}
          />
        </div>
      </div>
      <form
        action=""
        className="profile-form"
        // onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="container-div-form-category">
          <h3>Thông tin chung</h3>
          <div className="row">
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="maTo"
                >
                  Mã tổ
                </label>
                <input
                  type="text"
                  {...register("maTo")}
                  id="maTo"
                  className={
                    !errors.maTo
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.maTo?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="idPhongBan"
                >
                  Thuộc phòng ban
                </label>
                <select
                  type="text"
                  {...register("idPhongBan")}
                  id="idPhongBan"
                  className={
                    !errors.idPhongBan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option> Phòng ban 1</option>
                </select>
                <span className="message">{errors.idPhongBan?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div className="form-group form-inline">
                <label className="col-sm-4 justify-content-start" htmlFor="tenTo">
                  Tổ
                </label>
                <input
                  type="text"
                  {...register("tenTo")}
                  id="tenTo"
                  className={
                    !errors.tenTo
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenTo?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddNestForm;
