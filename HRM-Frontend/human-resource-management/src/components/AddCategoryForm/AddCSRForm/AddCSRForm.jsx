import React, { useEffect, useState } from "react";
import PropTypes from "prop-types";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddCSRForm.scss";
import ProductApi from "../../../api/productApi";

AddCSRForm.propTypes = {};
const schema = yup.object({
  tenNgach: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddCSRForm(props) {
  const [crmValue, setCrmValue] = useState(null);
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
        const response = await ProductApi.getDetailDMNCC(id);
        setdataDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMNCC(data);
      history.goBack();
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm danh mục ngạch công chức</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={crmValue ? "btn btn-danger" : "delete-button"}
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
            value={crmValue ? "Sửa" : "Lưu"}
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
            <div className="col-6">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tenNgach"
                >
                  Tên danh mục
                </label>
                <input
                  type="text"
                  {...register("tenNgach")}
                  id="tenNgach"
                  className={
                    !errors.tenNgach
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenNgach?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddCSRForm;
