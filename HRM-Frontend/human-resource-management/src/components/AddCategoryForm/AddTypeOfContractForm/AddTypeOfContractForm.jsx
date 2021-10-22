import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddTypeOfContractForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
const schema = yup.object({
  maLoaiHopDong: yup.string().required("Mã phòng ban không được bỏ trống."),
  tenLoaiHopDong: yup.string().required("Tên danh mục không được bỏ trống."),
});
AddTypeOfContractForm.propTypes = {};

function AddTypeOfContractForm(props) {

  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMLHD, setdataDetailDMLHD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục loại hợp đồng mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa loại hợp đồng");
          const response = await ProductApi.getDetailDMLHD(id);
          setdataDetailDMLHD(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const {
    register,
    handleSubmit,
    formState: { errors },
    reset
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      maLoaiHopDong: `${dataDetailDMLHD.maLoaiHopDong}`,
      tenLoaiHopDong: `${dataDetailDMLHD.tenLoaiHopDong}`
   }
  });
  useEffect(()=>{
    if(dataDetailDMLHD){
      reset({
        maLoaiHopDong: `${dataDetailDMLHD.maLoaiHopDong}`,
        tenLoaiHopDong: `${dataDetailDMLHD.tenLoaiHopDong}`
      })
    }
  },[dataDetailDMLHD])
  console.log(register.defaultValues)
  const onHandleSubmit = async (data) => {
    console.log(data)
    try {
      if (id !== undefined) {
        await PutApi.PutDMLHD(data, id);
      } else {
        await ProductApi.PostDMLHD(data);
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMLHD(id);
      history.goBack();
    } catch (error) {}
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMLHD.length !== 0 ? "Sửa" : "Thêm"} danh mục loại hợp
              đồng
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMLHD.length !== 0
                  ? "btn btn-danger"
                  : "delete-button"
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
              value={dataDetailDMLHD.length !== 0 ? "Sửa" : "Lưu"}
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
                    htmlFor="maLoaiHopDong"
                  >
                    Mã loại hợp đồng
                  </label>
                  <input
                    type="text"
                    {...register("maLoaiHopDong")}
                    id="maLoaiHopDong"
                    // defaultValue={dataDetailDMLHD.maLoaiHopDong}
                    className={
                      !errors.maLoaiHopDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">
                    {errors.maLoaiHopDong?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenLoaiHopDong"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenLoaiHopDong")}
                    id="tenLoaiHopDong"
                    // defaultValue={dataDetailDMLHD.tenLoaiHopDong}
                    className={
                      !errors.tenLoaiHopDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">
                    {errors.tenLoaiHopDong?.message}
                  </span>
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
        description={`Bạn chắc chắn muốn xóa danh mục loại hợp đồng ${dataDetailDMLHD.tenLoaiHopDong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddTypeOfContractForm;
