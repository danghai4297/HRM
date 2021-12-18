import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddMarriageForm.scss";
import ProductApi from "../../../../api/productApi";
import PutApi from "../../../../api/putAAPI";
import DeleteApi from "../../../../api/deleteAPI";
import Dialog from "../../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../../../components/Toast/Toast";
import { schema } from "../../../../ultis/CategoryValidation";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function AddMarriageForm(props) {
  const { error, success, warn } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMHN, setdataDetailDMHN] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục hôn nhân mới"
  );
  const [open, setOpen] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchMarriageCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục hôn nhân");
          const response = await ProductApi.getDetailDMHN(id);
          setdataDetailDMHN(response);
        }
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchMarriageCategory();
  }, []);

  useEffect(() => {
    if (id !== undefined) {
      setOpen(!open);
    }
  }, [dataDetailDMHN]);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMHN.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMHN.tenDanhMuc}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục hôn nhân mới`;
      }
    };
    titlePage();
  }, [dataDetailDMHN]);

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenDanhMuc: id !== undefined ? `${dataDetailDMHN.tenDanhMuc}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMHN && id !== undefined) {
      reset({
        tenDanhMuc: `${dataDetailDMHN.tenDanhMuc}`,
      });
    }
  }, [dataDetailDMHN]);

  const checkInputMarriageChange = () => {
    return getValues("tenDanhMuc") === `${dataDetailDMHN.tenDanhMuc}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenDanhMuc;

    try {
      if (id !== undefined) {
        try {
          await PutApi.PutDMHN(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa danh mục hôn nhân: ${dataDetailDMHN.tenDanhMuc} --> ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Sửa danh mục hôn nhân thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể sửa thành danh mục đã tồn tại");
        }
      } else {
        try {
          await ProductApi.PostDMHN(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm danh mục hôn nhân mới: ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Thêm danh mục hôn nhân thành công");
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
      if (dataDetailDMHN.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMHN(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục hôn nhân: ${dataDetailDMHN.tenDanhMuc}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá danh mục hôn nhân thành công");
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
              {dataDetailDMHN.length !== 0 ? "Sửa" : "Thêm"} danh mục hôn nhân
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMHN.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMHN.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputMarriageChange()) {
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
        description={`Bạn chắc chắn muốn xóa danh mục hôn nhân ${dataDetailDMHN.tenDanhMuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default AddMarriageForm;
