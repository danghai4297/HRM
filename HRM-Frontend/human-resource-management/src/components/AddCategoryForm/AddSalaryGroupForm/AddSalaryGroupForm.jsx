import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSalaryGroupForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
const schema = yup.object({
  maNhomLuong: yup.string().required("Mã phòng ban không được bỏ trống."),
  tenNhomLuong: yup.string().required("Tên danh mục không được bỏ trống."),
});
AddSalaryGroupForm.propTypes = {};

function AddSalaryGroupForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });

  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMNL, setdataDetailDMNL] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốm thêm nhóm lương"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốm sửa nhóm lương");
          const response = await ProductApi.getDetailDMNL(id);
          setdataDetailDMNL(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataDetailDMNL);

  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMNL(data, id);
      } else {
      await ProductApi.PostDMNL(data);
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMNL(id);
      history.goBack();
    } catch (error) {}
  };
  
  return (
    <>
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">
            {dataDetailDMNL.length !== 0 ? "Sửa" : "Thêm"} danh mục nhóm lương
          </h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={
              dataDetailDMNL.length !== 0 ? "btn btn-danger" : "delete-button"
            }
            onClick={() => {
              setShowDeleteDialog(true);
            }}
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
            value={dataDetailDMNL.length !== 0 ? "Sửa" : "Lưu"}
            onClick={() => {
              setShowDialog(true);
            }}
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
                  defaultValue={dataDetailDMNL.maNhomLuong}
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
                  defaultValue={dataDetailDMNL.tenNhomLuong}
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
      <Dialog
      show={showDialog}
      title="Thông báo"
      description={description}
      confirm={handleSubmit(onHandleSubmit)}
      cancel={cancel}
    />
    <Dialog
      show={showDeleteDialog}
      title="Thông báo"
      description="Bạn chắc chắn muốn xóa"
      confirm={handleDelete}
      cancel={cancel}
    />
  </>
  );
}

export default AddSalaryGroupForm;
