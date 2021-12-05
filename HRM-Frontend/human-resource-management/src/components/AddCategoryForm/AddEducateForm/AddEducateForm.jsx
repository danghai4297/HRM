import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddEducateForm";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";
import { schema } from "../../../ultis/EducateValidation";

function AddEducateForm(props) {
  const { error, success, warn } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
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
    const fetchEducateCategory = async () => {
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
    fetchEducateCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMHTDT.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMHTDT.tenHinhThuc}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục hình thức đào tạo mới`;
      }
    };
    titlePage();
  }, [dataDetailDMHTDT]);

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
          thaoTac: `Sửa hình
          thức đào tạo: ${dataDetailDMHTDT.tenHinhThuc} thành ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Sửa hình thức đào tạo thành công");
      } else {
        await ProductApi.PostDMHTDT(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm hình
          thức đào tạo mới: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm hình thức đào tạo thành công");
      }
      history.goBack();
    } catch (errors) {
      error(`Không thêm hoặc sửa danh mục được ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      if (dataDetailDMHTDT.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMHTDT(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa hình
        thức đào tạo: ${dataDetailDMHTDT.tenHinhThuc}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá hình thức đào tạo thành công");
        history.goBack();
      } else {
        warn(`Danh mục đang được sử dụng`);
      }
    } catch (error) {
      error(`Không xóa được danh mục ${error}`);
    }
  };

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
                    Tên hình thức
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
        description={`Bạn chắc chắn muốn xóa hình thức đào tạo ${dataDetailDMHTDT.tenHinhThuc}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddEducateForm;
