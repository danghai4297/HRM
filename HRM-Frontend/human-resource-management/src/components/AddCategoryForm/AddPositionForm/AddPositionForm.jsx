import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddPositionForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";

const schema = yup.object({
  maChucVu: yup.string().required("Mã chức vụ được bỏ trống."),
  tenChucVu: yup.string().required("Tên chức vụ không được bỏ trống."),
  phuCap: yup.number().typeError("Phụ cấp không được bỏ trống và là số."),
});
function AddPositionForm(props) {
  const { error, success } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMCV, setdataDetailDMCV] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục chức vụ mới"
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
          setDescription("Bạn chắc chắn muốn sửa danh mục chức vụ");
          const response = await ProductApi.getDetailDMCV(id);
          setdataDetailDMCV(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue = {
    maChucVu: `${dataDetailDMCV.maChucVu}`,
    tenChucVu: `${dataDetailDMCV.tenChucVu}`,
    phuCap: `${dataDetailDMCV.phuCap}`,
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: id !== undefined ? intitalValue : null,
  });

  useEffect(() => {
    if (dataDetailDMCV && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMCV]);

  const checkInputPositionChange = () => {
    const positionValues = getValues(["maChucVu", "tenChucVu", "phuCap"]);
    const dfPositionValues = [
      intitalValue.maChucVu,
      intitalValue.tenChucVu,
      intitalValue.phuCap,
    ];
    return JSON.stringify(positionValues) === JSON.stringify(dfPositionValues);
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenChucVu;
    try {
      if (id !== undefined) {
        await PutApi.PutDMCV(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục chức vụ: ${
            dataDetailDMCV.tenChucVu !== tendm
              ? `${dataDetailDMCV.tenChucVu} -->`
              : ""
          } ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Sửa danh mục chức vụ thành công");
      } else {
        await ProductApi.PostDMCV(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục chức vụ mới: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm danh mục chức vụ thành công");
      }
      history.goBack();
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMCV(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa danh mục chức vụ: ${dataDetailDMCV.tenChucVu}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success("Xoá danh mục chức vụ thành công");
      history.goBack();
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMCV.length !== 0 ? "Sửa" : "Thêm"} danh mục chức vụ
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMCV.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMCV.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputPositionChange()) {
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
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="maChucVu"
                  >
                    Mã chức vụ
                  </label>
                  <input
                    type="text"
                    {...register("maChucVu")}
                    id="maChucVu"
                    className={
                      !errors.maChucVu
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.maChucVu?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenChucVu"
                  >
                    Tên chức vụ
                  </label>
                  <input
                    type="text"
                    {...register("tenChucVu")}
                    id="tenChucVu"
                    className={
                      !errors.tenChucVu
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger "
                    }
                  ></input>
                  <span className="message">{errors.tenChucVu?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="phuCap"
                  >
                    Phụ cấp
                  </label>
                  <input
                    type="text"
                    {...register("phuCap")}
                    id="phuCap"
                    className={
                      !errors.phuCap
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.phuCap?.message}</span>
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
        description={`Bạn chắc chắn muốn xóa danh mục chức vụ ${dataDetailDMCV.tenChucVu}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddPositionForm;
