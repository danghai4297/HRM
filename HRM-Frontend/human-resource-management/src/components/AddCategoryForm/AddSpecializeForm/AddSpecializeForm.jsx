import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSpecializeForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
const schema = yup.object({
  tenChuyenMon: yup.string().required("Tên danh mục không được bỏ trống."),
  maChuyenMon: yup.string().required("Mã danh mục không được bỏ trống."),
});
function AddSpecializeForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMCM, setdataDetailDMCM] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục chuyên môn mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục chuyên môn");
          const response = await ProductApi.getDetailDMCM(id);
          setdataDetailDMCM(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);


  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMCM(data, id);
      } else {
        await ProductApi.PostDMCM(data);
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMCM(id);
      history.goBack();
    } catch (error) {}
  };

  return (
    <>
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">
            {dataDetailDMCM.length !== 0 ? "Sửa" : "Thêm"} danh mục chuyên môn
          </h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={
              dataDetailDMCM.length !== 0 ? "btn btn-danger" : "delete-button"
            }
            onClick={() => {
              setShowDeleteDialog(true);
            }}
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
            value={dataDetailDMCM.length !== 0 ? "Sửa" : "Lưu"}
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
                  htmlFor="maChuyenMon"
                >
                  Mã danh mục
                </label>
                <input
                  type="text"
                  {...register("maChuyenMon")}
                  id="maChuyenMon"
                  defaultValue={dataDetailDMCM.maChuyenMon}
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
                  defaultValue={dataDetailDMCM.tenChuyenMon}
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
        description={`Bạn chắc chắn muốn xóa danh mục chuyên môn ${dataDetailDMCM.tenChuyenMon}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddSpecializeForm;
