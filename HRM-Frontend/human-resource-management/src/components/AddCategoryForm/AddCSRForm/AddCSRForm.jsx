import React, { useEffect, useState, useMemo } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddCSRForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";

AddCSRForm.propTypes = {};
const schema = yup.object({
  tenNgach: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddCSRForm(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMNCC, setdataDetailDMNCC] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm ngạch công chức mới"
  );
  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa ngạch công chức");
          const response = await ProductApi.getDetailDMNCC(id);
          setdataDetailDMNCC(response);
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
       tenNgach: id !== undefined ? `${dataDetailDMNCC.tenNgach}`: null
    }
  });
  useEffect(()=>{
    if(dataDetailDMNCC && id !== undefined){
      reset({
        tenNgach: `${dataDetailDMNCC.tenNgach}`
      })
    }
  },[dataDetailDMNCC])
  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMNCC(data, id);
      } else {
        await ProductApi.PostDMNCC(data);
      }
      history.goBack();
    } catch (error) {}
    console.log(data)
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMNCC(id);
      history.goBack();
    } catch (error) {}
  };

  console.log(dataDetailDMNCC);

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMNCC.length !== 0 ? "Sửa" : "Thêm"} danh mục ngạch
              công chức
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMNCC.length !== 0
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
              value={dataDetailDMNCC.length !== 0 ? "Sửa" : "Lưu"}
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
                    // defaultValue={dataDetailDMNCC.tenNgach}
                    className={
                      !errors.tenNgach
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                    // name="tenNgach"
                  />
                  <span className="message">{errors.tenNgach?.message}</span>
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
        description={`Bạn chắc chắn muốn xóa ngạch công chức ${dataDetailDMNCC.tenNgach}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddCSRForm;
