import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddRelationForm.scss";
import ProductApi from "../../../api/productApi";
const schema = yup.object({
  tenDanhMuc: yup.string().required("Tên danh mục không được bỏ trống."),
});
AddRelationForm.propTypes = {};

function AddRelationForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMNT, setdataDetailDMNT] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          const response = await ProductApi.getDetailDMNT(id);
          setdataDetailDMNT(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMNT(data);
      history.goBack();
    } catch (error) {}
  };

  console.log(dataDetailDMNT);

  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">
            {dataDetailDMNT.length !== 0 ? "Sửa" : "Thêm"} danh mục quan hệ
          </h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={
              dataDetailDMNT.length !== 0 ? "btn btn-danger" : "delete-button"
            }
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
            value={dataDetailDMNT.length !== 0 ? "Sửa" : "Lưu"}
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
                  htmlFor="tenDanhMuc"
                >
                  Tên danh mục
                </label>
                <input
                  type="text"
                  {...register("tenDanhMuc")}
                  id="tenDanhMuc"
                  defaultValue={dataDetailDMNT.tenDanhMuc}
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

export default AddRelationForm;
