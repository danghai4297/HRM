import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddBonusForm.scss";
import ProductApi from "../../../../api/productApi";
import PutApi from "../../../../api/putAAPI";
import Dialog from "../../../../components/Dialog/Dialog";
import DeleteApi from "../../../../api/deleteAPI";
import jwt_decode from "jwt-decode";
import { useToast } from "../../../../components/Toast/Toast";
import { schema } from "../../../../ultis/CategoryValidation";

function AddBonusForm(props) {
  const { error, success, warn } = useToast();

  let { match, history } = props;
  let { id } = match.params;
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMKT, setdataDetailDMKT] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục khen thưởng mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchBonusCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription(`Bạn chắc chắn muốn sửa danh mục khen thưởng`);
          const response = await ProductApi.getDetailDMKTvKL(id);
          setdataDetailDMKT(response);
        }
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchBonusCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMKT.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMKT.tenDanhMuc}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục khen thưởng mới`;
      }
    };
    titlePage();
  }, [dataDetailDMKT]);

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenDanhMuc: id !== undefined ? `${dataDetailDMKT.tenDanhMuc}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMKT && id !== undefined) {
      reset({
        tenDanhMuc: `${dataDetailDMKT.tenDanhMuc}`,
      });
    }
  }, [dataDetailDMKT]);

  const checkInputBonusChange = () => {
    return getValues("tenDanhMuc") === `${dataDetailDMKT.tenDanhMuc}`;
  };

  const onHandleSubmit = async (data) => {
    try {
      let tendm = data.tenDanhMuc;
      if (id !== undefined) {
        try {
          await PutApi.PutDMKTvKL(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa danh mục khen thưởng: ${dataDetailDMKT.tenDanhMuc} --> ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Sửa danh mục khen thưởng thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể sửa thành danh mục đã tồn tại");
        }
      } else {
        try {
          await ProductApi.PostDMKTvKL(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm danh mục khen thưởng mới: ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Thêm danh mục khen thưởng thành công");
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
      if (dataDetailDMKT.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMKTvKL(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục khen thưởng: ${dataDetailDMKT.tenDanhMuc}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá danh mục khen thưởng thành công");
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
              {dataDetailDMKT.length !== 0 ? "Sửa" : "Thêm"} danh mục khen
              thưởng
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
                if (checkInputBonusChange()) {
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
              {id === undefined && (
                <>
                  <div className="col-6">
                    <div className="form-group form-inline">
                      <input
                        type="text"
                        {...register("tieuDe")}
                        id="tieuDe"
                        value="Khen thưởng"
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
        description={`Bạn chắc chắn muốn xóa danh mục khen thưởng ${dataDetailDMKT.tenDanhMuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddBonusForm;
