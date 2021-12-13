import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddSalaryGroupForm.scss";
import ProductApi from "../../../../api/productApi";
import PutApi from "../../../../api/putAAPI";
import DeleteApi from "../../../../api/deleteAPI";
import Dialog from "../../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../../../components/Toast/Toast";
import { schema } from "../../../../ultis/SalaryGroupValidation";

function AddSalaryGroupForm(props) {
  const { error, success, warn } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
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
    const fetchSalaryGroupCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục nhóm lương");
          const response = await ProductApi.getDetailDMNL(id);
          setdataDetailDMNL(response);
        }
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchSalaryGroupCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMNL.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMNL.tenNhomLuong}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục nhóm lương mới`;
      }
    };
    titlePage();
  }, [dataDetailDMNL]);

  useEffect(() => {
    const handleSalaryGroupId = async () => {
      if (id === undefined) {
        const responseSalaryGroup = await ProductApi.getAllDMNL();
        const codeIncre =
          responseSalaryGroup !== null &&
          responseSalaryGroup[responseSalaryGroup.length - 1].maNhomLuong;
        const autoCodeIncre = Number(codeIncre.slice(3)) + 1;
        const codeSalaryGroup = "NL";
        if (autoCodeIncre < 10) {
          setValue("maNhomLuong", codeSalaryGroup.concat(`0${autoCodeIncre}`));
        } else if (autoCodeIncre >= 10) {
          setValue("maNhomLuong", codeSalaryGroup.concat(`${autoCodeIncre}`));
        }
      }
    };
    handleSalaryGroupId();
  }, []);

  const intitalValue = {
    maNhomLuong: `${dataDetailDMNL.maNhomLuong}`,
    tenNhomLuong: `${dataDetailDMNL.tenNhomLuong}`,
  };

  const {
    register,
    handleSubmit,
    reset,
    setValue,
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
        try {
          await PutApi.PutDMNL(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa danh mục nhóm lương: ${
              dataDetailDMNL.tenNhomLuong !== tendm
                ? `${dataDetailDMNL.tenNhomLuong} -->`
                : ""
            } ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Sửa danh mục nhóm lương thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể sửa thành danh mục đã tồn tại");
        }
      } else {
        try {
          await ProductApi.PostDMNL(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm danh mục nhóm lương mới: ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Thêm danh mục nhóm lương thành công");
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
      if (dataDetailDMNL.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMNL(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục nhóm lương: ${dataDetailDMNL.tenNhomLuong}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá danh mục nhóm lương thành công");
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
                    readOnly
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
        description={`Bạn chắc chắn muốn xóa danh mục nhóm lương ${dataDetailDMNL.tenNhomLuong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddSalaryGroupForm;
