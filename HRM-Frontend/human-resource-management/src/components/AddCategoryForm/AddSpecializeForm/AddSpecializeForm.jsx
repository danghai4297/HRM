import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSpecializeForm.scss";
import ProductApi from "../../../api/productApi";
const schema = yup.object({
  tenChuyenMon: yup.string().required("Tên danh mục không được bỏ trống."),
  maChuyenMon: yup.string().required("Mã danh mục không được bỏ trống."),
});
function AddSpecializeForm(props) {
  const [specializeValue, setSpecializeValue] = useState(null);
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
        const response = await ProductApi.getDetailDMCM(id);
        setdataDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMCM(data);
      history.goBack();
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm danh mục chuyên môn</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={specializeValue ? "btn btn-danger" : "delete-button"}
            value="Xoá"
          />
          <input
            type="submit"
            className="btn btn-secondary  ml-3"
            value="Huỷ"
            onClick={history.goBack}
          />
          <input
            type="submit"
            className="btn btn-primary ml-3"
            value={specializeValue ? "Sửa" : "Lưu"}
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
                  htmlFor="maChuyenMon"
                >
                  Mã danh mục
                </label>
                <input
                  type="text"
                  {...register("maChuyenMon")}
                  id="maChuyenMon"
                  className={
                    !errors.maChuyenMon
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.maChuyenMon?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tenChuyenMon"
                >
                  Tên danh mục
                </label>
                <input
                  type="text"
                  {...register("tenChuyenMon")}
                  id="tenChuyenMon"
                  className={
                    !errors.tenChuyenMon
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenChuyenMon?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddSpecializeForm;
