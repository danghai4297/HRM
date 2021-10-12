import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddNationForm.scss";
import { useState } from "react";
import ProductApi from "../../../api/productApi";
// import { Alert } from "react-alert";
AddNationForm.propTypes = {};
const schema = yup.object({
  tenDanhMuc: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddNationForm(props) {
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
        const response = await ProductApi.getDetailDMDT(id);
        setdataDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMDT(data);
    } catch (error) {}
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
            <h2 className="">Thêm danh mục dân tộc</h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={dataDetail ? "btn btn-danger" : "delete-button"}
              value="Xoá"
            />
            <input
              type="submit"
              className="btn btn-secondary ml-3"
              value="Huỷ"
            />
            <input
              type="submit"
              className="btn btn-primary ml-3"
              value={dataDetail ? "Sửa" : "Lưu"}
              onClick={handleSubmit(onHandleSubmit)}
            />
          </div>
        </div>

        <div className="container-div-form">
          <h3>Thông tin chung</h3>
          <div className="row">
            <div className="col-6">
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
                  defaultValue={dataDetail}
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

export default AddNationForm;
