import React from 'react';
import PropTypes from 'prop-types';
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSalaryGroupForm.scss";
const schema = yup.object({
  maDanhMuc: yup.string().required("Mã phòng ban không được bỏ trống."),
  tenDanhMuc: yup.string().required("Tên danh mục không được bỏ trống."),
});
AddSalaryGroupForm.propTypes = {
    
};

function AddSalaryGroupForm(props) {
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
          className="profile-form"
          // onSubmit={handleSubmit(onHandleSubmit)}
        >
          <div className="Submit-button sticky-top">
            <div>
              <h2 className="">Thêm danh mục nhóm lương</h2>
            </div>
            <div className="button">
              <input type="submit" className="btn btn-secondary " value="Huỷ" />
              <input
                type="submit"
                className="btn btn-primary ml-3"
                value="Lưu"
                onClick={handleSubmit(onHandleSubmit)}
              />
            </div>
          </div>
  
          <div className="container-div-form">
            <h3>Thông tin chung</h3>
            <div className="row">
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="maDanhMuc"
                  >
                    Mã danh muc
                  </label>
                  <input
                    type="text"
                    {...register("maDanhMuc")}
                    id="maDanhMuc"
                    className={
                      !errors.maDanhMuc
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.maDanhMuc?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenDanhMuc"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenDanhMuc")}
                    id="tenDanhMuc"
                    className={
                      !errors.tenDanhMuc
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenDanhMuc?.message}</span>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
    );
}

export default AddSalaryGroupForm;