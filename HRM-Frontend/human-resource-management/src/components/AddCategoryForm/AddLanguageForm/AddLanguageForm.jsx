import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddLanguageForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
AddLanguageForm.propTypes = {};
const schema = yup.object({
  tenDanhMuc: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddLanguageForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });

  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMNN, setdataDetailDMNN] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          const response = await ProductApi.getDetailDMNN(id);
          setdataDetailDMNN(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataDetailDMNN);

  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMNN(data, id);
      } else {
        await ProductApi.PostDMNN(data);
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMNN(id);
      history.goBack();
    } catch (error) {}
  };


  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">
            {dataDetailDMNN.length !== 0 ? "Sửa" : "Thêm"} danh mục ngoại ngữ
          </h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={
              dataDetailDMNN.length !== 0 ? "btn btn-danger" : "delete-button"
            }
            onClick={handleDelete}
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
            value={dataDetailDMNN.length !== 0 ? "Sửa" : "Lưu"}
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
                  defaultValue={dataDetailDMNN.tenDanhMuc}
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

export default AddLanguageForm;
