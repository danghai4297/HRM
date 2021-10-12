import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddTitleForm.scss";
import ProductApi from "../../../api/productApi";
AddTitleForm.propTypes = {};
const schema = yup.object({
  maChucDanh: yup.string().required("Mã chức danh không được bỏ trống."),
  tenChucDanh: yup.string().required("Tên chức danh không được bỏ trống."),
  phuCap: yup.number(),
});
function AddTitleForm(props) {
  const [titleValue, setTitleValue] = useState(null);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetail, setdataDetail] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getDetailDMCD(id);
        setdataDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMCD(data);
      history.goBack();
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm danh mục chức danh</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={titleValue ? "btn btn-danger" : "delete-button"}
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
            value={titleValue ? "Sửa" : "Lưu"}
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
                  htmlFor="maChucDanh"
                >
                  Mã chức danh
                </label>
                <input
                  type="text"
                  {...register("maChucDanh")}
                  id="maChucDanh"
                  className={
                    !errors.maChucDanh
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.maChucDanh?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tenChucDanh"
                >
                  Tên chức danh
                </label>
                <input
                  type="text"
                  {...register("tenChucDanh")}
                  id="tenChucDanh"
                  className={
                    !errors.tenChucDanh
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenChucDanh?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="phuCap"
                >
                  Phụ cấp
                </label>
                <input
                  type="text"
                  {...register("phuCap")}
                  id="phuCap"
                  className={
                    !errors.phuCap
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.phuCap?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddTitleForm;
