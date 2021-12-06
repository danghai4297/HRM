import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddLevelForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";
import { schema } from "../../../ultis/LevelCategoryValidation";

function AddLevelForm(props) {
  const { error, success, warn } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMTD, setdataDetailDMTD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục trình độ mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchLevelCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục trình độ");
          const response = await ProductApi.getDetailDMTD(id);
          setdataDetailDMTD(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchLevelCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMTD.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMTD.tenTrinhDo}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục trình độ mới`;
      }
    };
    titlePage();
  }, [dataDetailDMTD]);

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenTrinhDo: id !== undefined ? `${dataDetailDMTD.tenTrinhDo}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMTD && id !== undefined) {
      reset({
        tenTrinhDo: `${dataDetailDMTD.tenTrinhDo}`,
      });
    }
  }, [dataDetailDMTD]);

  const checkInputLevelChange = () => {
    return getValues("tenTrinhDo") === `${dataDetailDMTD.tenTrinhDo}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenTrinhDo;

    try {
      if (id !== undefined) {
        await PutApi.PutDMTD(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục trình độ: ${dataDetailDMTD.tenTrinhDo} --> ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Sửa trình độ thành công");
      } else {
        await ProductApi.PostDMTD(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục trình độ mới: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm trình độ thành công");
      }
      history.goBack();
    } catch (errors) {
      error(`Không thêm hoặc sửa danh mục được ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      if (dataDetailDMTD.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMTD(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục trình độ: ${dataDetailDMTD.tenTrinhDo}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá trình độ thành công");
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
              {dataDetailDMTD.length !== 0 ? "Sửa" : "Thêm"} danh mục trình độ
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMTD.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMTD.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputLevelChange()) {
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
                    htmlFor="tenTrinhDo"
                  >
                    Tên trình độ
                  </label>
                  <input
                    type="text"
                    {...register("tenTrinhDo")}
                    id="tenTrinhDo"
                    className={
                      !errors.tenTrinhDo
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenTrinhDo?.message}</span>
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
        description={`Bạn chắc chắn muốn xóa danh mục trình độ ${dataDetailDMTD.tenTrinhDo}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLevelForm;
