import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddPositionForm.scss";
import ProductApi from "../../../api/productApi";
const schema = yup.object({
  maChucVu: yup.string().required("Mã chức vụ được bỏ trống."),
  tenChucVu: yup.string().required("Tên chức vụ không được bỏ trống."),
  phuCap: yup.number().required("Phụ cấp không được bỏ trống."),
});
function AddPositionForm(props) {
  const { objectData } = props;
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
        const response = await ProductApi.getDetailDMCV(id);
        setdataDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const onHandleSubmit = async (data) => {
    try {
      await ProductApi.PostDMCV(data);
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
            <h2 className="">Thêm danh mục chức vụ</h2>
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
                  htmlFor="maChucVu"
                >
                  Mã chức vụ
                </label>
                <input
                  type="text"
                  {...register("maChucVu")}
                  id="maChucVu"
                  className={
                    !errors.maChucVu
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.maChucVu?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tenChucVu"
                >
                  Tên chức vụ
                </label>
                <input
                  type="text"
                  {...register("tenChucVu")}
                  id="tenChucVu"
                  className={
                    !errors.tenChucVu
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger "
                  }
                ></input>
                <span className="message">{errors.tenChucVu?.message}</span>
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

export default AddPositionForm;
