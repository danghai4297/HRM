import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddRelationForm.scss";
import ProductApi from "../../../../api/productApi";
import PutApi from "../../../../api/putAAPI";
import DeleteApi from "../../../../api/deleteAPI";
import Dialog from "../../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../../../components/Toast/Toast";
import { schema } from "../../../../ultis/CategoryValidation";

function AddRelationForm(props) {
  const { error, success, warn } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMNT, setdataDetailDMNT] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục người thân mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };
  useEffect(() => {
    const fetchRelationCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục người thân");
          const response = await ProductApi.getDetailDMNT(id);
          setdataDetailDMNT(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchRelationCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMNT.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMNT.tenDanhMuc}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục người thân mới`;
      }
    };
    titlePage();
  }, [dataDetailDMNT]);

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenDanhMuc: id !== undefined ? `${dataDetailDMNT.tenDanhMuc}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMNT && id !== undefined) {
      reset({
        tenDanhMuc: `${dataDetailDMNT.tenDanhMuc}`,
      });
    }
  }, [dataDetailDMNT]);

  const checkInputRelationChange = () => {
    return getValues("tenDanhMuc") === `${dataDetailDMNT.tenDanhMuc}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenDanhMuc;
    try {
      if (id !== undefined) {
        try {
          await PutApi.PutDMNT(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa danh mục người thân: ${dataDetailDMNT.tenDanhMuc} --> ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Sửa danh mục người thân thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể sửa thành danh mục đã tồn tại");
        }
      } else {
        try {
          await ProductApi.PostDMNT(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm danh mục người thân mới: ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Thêm danh mục người thân thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể thêm danh mục đã tồn tại");
        }
      }
    } catch (errors) {
      error(`Không thêm hoặc sửa danh mục được ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      if (dataDetailDMNT.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMNT(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục người thân: ${dataDetailDMNT.tenDanhMuc}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá danh mục thành công");
        history.goBack();
      } else {
        warn(`Danh mục đang được sử dụng`);
      }
    } catch (errors) {
      error(`Không xóa được danh mục ${errors}`);
    }
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMNT.length !== 0 ? "Sửa" : "Thêm"} danh mục người thân
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMNT.length !== 0 ? "btn btn-danger" : "delete-button"
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
              className="btn btn-primary ml-3 btn-form"
              value={dataDetailDMNT.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputRelationChange()) {
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
      <Dialog
        show={showDialog}
        title="Thông báo"
        description={
          Object.values(errors).length !== 0
            ? "Bạn chưa nhập đầy đủ thông tin"
            : description
        }
        confirm={
          Object.values(errors).length !== 0
            ? null
            : handleSubmit(onHandleSubmit)
        }
        cancel={cancel}
      />
      <Dialog
        show={showCheckDialog}
        title="Thông báo"
        description={"Bạn chưa thay đổi gì"}
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa danh mục người thân ${dataDetailDMNT.tenDanhMuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddRelationForm;
