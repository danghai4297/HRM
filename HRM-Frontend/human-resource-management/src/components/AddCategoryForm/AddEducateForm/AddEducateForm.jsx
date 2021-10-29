import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddEducateForm";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
const schema = yup.object({
  tenHinhThuc: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddEducateForm(props) {
  let { match, history } = props;
  let { id } = match.params;

  const token = localStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMHTDT, setdataDetailDMHTDT] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm hình thức đào tạo mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa hình thức đào tạo");
          const response = await ProductApi.getDetailDMHTDT(id);
          setdataDetailDMHTDT(response);
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
    reset,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenHinhThuc: id !== undefined ? `${dataDetailDMHTDT.tenHinhThuc}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMHTDT && id !== undefined) {
      reset({
        tenHinhThuc: `${dataDetailDMHTDT.tenHinhThuc}`,
      });
    }
  }, [dataDetailDMHTDT]);

  const checkInputEducateChange = () => {
    return getValues("tenHinhThuc") === `${dataDetailDMHTDT.tenHinhThuc}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenHinhThuc;

    try {
      if (id !== undefined) {
        await PutApi.PutDMHTDT(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục hình
          thức đào tạo: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
      } else {
        await ProductApi.PostDMHTDT(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục hình
          thức đào tạo: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMHTDT(id);
      history.goBack();
    } catch (error) {}
  };

  console.log(dataDetailDMHTDT);

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMHTDT.length !== 0 ? "Sửa" : "Thêm"} danh mục hình
              thức đào tạo
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMHTDT.length !== 0
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
              value={dataDetailDMHTDT.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputEducateChange()) {
                  setShowCheckDialog(true);
                } else {
                  setShowDialog(true);
                }
              }}
            />
          </div>
        </div>
        <form action="" className="profile-form">
          <div className="container-div-form-category">
            <h3>Thông tin chung</h3>
            <div className="row">
              <div className="col-6">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenHinhThuc"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenHinhThuc")}
                    id="tenHinhThuc"
                    className={
                      !errors.tenHinhThuc
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenHinhThuc?.message}</span>
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
      <DialogCheck
        show={showCheckDialog}
        title="Thông báo"
        description={"Bạn chưa thay đổi gì"}
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa hình thức đào tạo ${dataDetailDMHTDT.tenHinhThuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddEducateForm;
