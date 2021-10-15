import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddBonusForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import Dialog from "../../Dialog/Dialog";
import DeleteApi from "../../../api/deleteAPI";
AddBonusForm.propTypes = {};
const schema = yup.object({
  tenDanhMuc: yup.string().required("Tên danh mục không được bỏ trống."),
});

function AddBonusForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });

  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMKT, setdataDetailDMKT] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục khen thưởng mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục khen thưởng");
          const response = await ProductApi.getDetailDMKTvKL(id);
          setdataDetailDMKT(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailDMKT);

  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMKTvKL(data, id);
      } else {
        await ProductApi.PostDMKTvKL(data);
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMKTvKL(id);
      history.goBack();
    } catch (error) {}
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMKT.length !== 0 ? "Sửa" : "Thêm"} danh mục kỉ luật
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMKT.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMKT.length !== 0 ? "Sửa" : "Lưu"}
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
                    htmlFor="tenDanhMuc"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenDanhMuc")}
                    id="tenDanhMuc"
                    defaultValue={dataDetailDMKT.tenDanhMuc}
                    className={
                      !errors.tenDanhMuc
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenDanhMuc?.message}</span>
                </div>
              </div>
              {id === undefined && (
                <>
                  <div className="col-6">
                    <div className="form-group form-inline">
                      <input
                        type="text"
                        {...register("tieuDe")}
                        id="tieuDe"
                        defaultValue="Khen thưởng"
                        style={{ display: "none" }}
                        className={
                          !errors.tieuDe
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger "
                        }
                      />
                      <span className="message">{errors.tieuDe?.message}</span>
                    </div>
                  </div>
                </>
              )}
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
        description={`Bạn chắc chắn muốn xóa danh mục khen thưởng ${dataDetailDMKT.tenDanhMuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddBonusForm;
