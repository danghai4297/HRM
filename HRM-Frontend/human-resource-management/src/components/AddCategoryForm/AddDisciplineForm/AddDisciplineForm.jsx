import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddDisciplineForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";

const dontAllowOnlySpace = /^\s*\S.*$/g;
const schema = yup.object({
  tenDanhMuc: yup
    .string()
    .nullable()
    .matches(dontAllowOnlySpace, "Tên danh mục không được chỉ là khoảng trống")
    .required("Tên danh mục không được bỏ trống."),
});

function AddDisciplineForm(props) {
  const { error, success, warn } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMKL, setdataDetailDMKL] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục kỷ luật mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchDisciplineCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục kỷ luật");
          const response = await ProductApi.getDetailDMKTvKL(id);
          setdataDetailDMKL(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchDisciplineCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMKL.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMKL.tenDanhMuc}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục kỷ luật mới`;
      }
    };
    titlePage();
  }, [dataDetailDMKL]);

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenDanhMuc: id !== undefined ? `${dataDetailDMKL.tenDanhMuc}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMKL && id !== undefined) {
      reset({
        tenDanhMuc: `${dataDetailDMKL.tenDanhMuc}`,
      });
    }
  }, [dataDetailDMKL]);

  const checkInputDisciplineChange = () => {
    return getValues("tenDanhMuc") === `${dataDetailDMKL.tenDanhMuc}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenDanhMuc;

    try {
      if (id !== undefined) {
        await PutApi.PutDMKTvKL(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục kỷ luật: ${dataDetailDMKL.tenDanhMuc} --> ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Sửa danh mục kỷ luật thành công");
      } else {
        await ProductApi.PostDMKTvKL(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục kỷ luật mới: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm danh mục kỷ luật thành công");
      }
      history.goBack();
    } catch (errors) {
      error(`Không thêm hoặc sửa danh mục được ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      if (dataDetailDMKL.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMKTvKL(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục kỷ luật: ${dataDetailDMKL.tenDanhMuc}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        history.goBack();
        success("Xoá danh mục kỷ luật thành công");
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
              {dataDetailDMKL.length !== 0 ? "Sửa" : "Thêm"} danh mục kỷ luật
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMKL.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMKL.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputDisciplineChange()) {
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
                        defaultValue="Kỷ luật"
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
        description={`Bạn chắc chắn muốn xóa danh mục kỷ luật ${dataDetailDMKL.tenDanhMuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddDisciplineForm;
