import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSalaryGroupForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";
const schema = yup.object({
  maNhomLuong: yup.string().required("Mã phòng ban không được bỏ trống."),
  tenNhomLuong: yup.string().required("Tên danh mục không được bỏ trống."),
});
AddSalaryGroupForm.propTypes = {};

function AddSalaryGroupForm(props) {
  const { error, warn, info, success } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = localStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMNL, setdataDetailDMNL] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục nhóm lương mới"
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
          setDescription("Bạn chắc chắn muốn sửa danh mục nhóm lương");
          const response = await ProductApi.getDetailDMNL(id);
          setdataDetailDMNL(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue = {
    maNhomLuong: `${dataDetailDMNL.maNhomLuong}`,
    tenNhomLuong: `${dataDetailDMNL.tenNhomLuong}`,
  };

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: id !== undefined ? intitalValue : null,
  });

  useEffect(() => {
    if (dataDetailDMNL && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMNL]);

  const checkInputSalaryGroupChange = () => {
    const salaryGroupValues = getValues(["maNhomLuong", "tenNhomLuong"]);
    const dfSalaryGroupValues = [
      intitalValue.maNhomLuong,
      intitalValue.tenNhomLuong,
    ];
    return (
      JSON.stringify(salaryGroupValues) === JSON.stringify(dfSalaryGroupValues)
    );
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenNhomLuong;

    try {
      if (id !== undefined) {
        await PutApi.PutDMNL(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục nhóm lương: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("sửa danh mục thành công");
      } else {
        await ProductApi.PostDMNL(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục nhóm lương: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm danh mục thành công");
      }
      history.goBack();
    } catch (error) {
      error(`Có lỗi xảy ra ${error}`);
    }
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMNL(id);
      success("Xoá danh mục thành công");
      history.goBack();
    } catch (error) {
      error(`Có lỗi xảy ra ${error}`);
    }
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMNL.length !== 0 ? "Sửa" : "Thêm"} danh mục nhóm lương
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMNL.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMNL.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputSalaryGroupChange()) {
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
                    htmlFor="maNhomLuong"
                  >
                    Mã nhóm lương
                  </label>
                  <input
                    type="text"
                    {...register("maNhomLuong")}
                    id="maNhomLuong"
                    className={
                      !errors.maNhomLuong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.maNhomLuong?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenNhomLuong"
                  >
                    Tên nhóm lương
                  </label>
                  <input
                    type="text"
                    {...register("tenNhomLuong")}
                    id="tenNhomLuong"
                    className={
                      !errors.tenNhomLuong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">
                    {errors.tenNhomLuong?.message}
                  </span>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
      <Dialog
        show={showDialog}
        title="Thông báo"
        description={Object.values(errors).length !== 0 ? "Bạn chưa nhập đầy đủ thông tin" : description}
        confirm={Object.values(errors).length !== 0 ? null : handleSubmit(onHandleSubmit)}
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
        description={`Bạn chắc chắn muốn xóa danh mục nhóm lương ${dataDetailDMNL.tenNhomLuong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddSalaryGroupForm;
