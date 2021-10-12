import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSalaryGroupForm.scss";
import ProductApi from "../../../api/productApi";
import { useState } from "react";
const schema = yup.object({
  maNhomLuong: yup.string().required("Mã phòng ban không được bỏ trống."),
  tenNhomLuong: yup.string().required("Tên danh mục không được bỏ trống."),
});
AddSalaryGroupForm.propTypes = {};

function AddSalaryGroupForm(props) {
  const [salaryValue, setSalaryValue] = useState(null);
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
      await ProductApi.PostDMNL(data);
      history.goBack();
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm danh mục nhóm lương</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={salaryValue ? "btn btn-danger" : "delete-button"}
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
            value={salaryValue ? "Sửa" : "Lưu"}
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
                  htmlFor="maNhomLuong"
                >
                  Mã nhóm lương
                </label>
                <input
                  type="text"
                  {...register("maNhomLuong")}
                  id="maNhomLuong"
                  className={
                    !errors.maNhomLuong
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.maNhomLuong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tenNhomLuong"
                >
                  Tên danh mục
                </label>
                <input
                  type="text"
                  {...register("tenNhomLuong")}
                  id="tenNhomLuong"
                  className={
                    !errors.tenNhomLuong
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenNhomLuong?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddSalaryGroupForm;
