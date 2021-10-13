import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddLevelForm.scss";
import ProductApi from "../../../api/productApi";
const schema = yup.object({
  tenTrinhDo: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddLevelForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMTD, setdataDetailDMTD] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          const response = await ProductApi.getDetailDMTD(id);
          setdataDetailDMTD(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailDMTD);

  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMTD(data);
      history.goBack();
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">
            {dataDetailDMTD.length !== 0 ? "Sửa" : "Thêm"} danh mục trình độ
          </h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={
              dataDetailDMTD.length !== 0 ? "btn btn-danger" : "delete-button"
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
            value={dataDetailDMTD.length !== 0 ? "Sửa" : "Lưu"}
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
                  htmlFor="tenTrinhDo"
                >
                  Tên danh mục
                </label>
                <input
                  type="text"
                  {...register("tenTrinhDo")}
                  id="tenTrinhDo"
                  defaultValue={dataDetailDMTD.tenTrinhDo}
                  className={
                    !errors.tenTrinhDo
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenTrinhDo?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddLevelForm;
