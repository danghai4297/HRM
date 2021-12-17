import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddTitleForm.scss";
import ProductApi from "../../../../api/productApi";
import PutApi from "../../../../api/putAAPI";
import DeleteApi from "../../../../api/deleteAPI";
import Dialog from "../../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../../../components/Toast/Toast";
import { schema } from "../../../../ultis/TitleValidation";
import NumberFormat from "react-number-format";

function AddTitleForm(props) {
  const { error, success, warn } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMCD, setdataDetailDMCD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục chức danh mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchTitleCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục chức danh");
          const response = await ProductApi.getDetailDMCD(id);
          setdataDetailDMCD(response);
        }
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchTitleCategory();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMCD.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMCD.tenChucDanh}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục chức danh mới`;
      }
    };
    titlePage();
  }, [dataDetailDMCD]);

  useEffect(() => {
    const handleTitleId = async () => {
      if (id === undefined) {
        const responseTitle = await ProductApi.getAllDMCD();
        const codeIncre =
          responseTitle !== null &&
          responseTitle[responseTitle.length - 1].maChucDanh;
        const autoCodeIncre = Number(codeIncre.slice(3)) + 1;
        const codeTitle = "CD";
        if (autoCodeIncre < 10) {
          setValue("maChucDanh", codeTitle.concat(`0${autoCodeIncre}`));
        } else if (autoCodeIncre >= 10) {
          setValue("maChucDanh", codeTitle.concat(`${autoCodeIncre}`));
        }
      }
    };
    handleTitleId();
  }, []);

  const intitalValue = {
    maChucDanh: `${dataDetailDMCD.maChucDanh}`,
    tenChucDanh: `${dataDetailDMCD.tenChucDanh}`,
    phuCap: `${dataDetailDMCD.phuCap}`,
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    setValue,
    control,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: id !== undefined ? intitalValue : null,
  });

  useEffect(() => {
    if (dataDetailDMCD && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMCD]);

  const checkInputTitleChange = () => {
    const titleValues = getValues(["maChucDanh", "tenChucDanh", "phuCap"]);
    const dfTitleValues = [
      intitalValue.maChucDanh,
      intitalValue.tenChucDanh,
      intitalValue.phuCap,
    ];
    return JSON.stringify(titleValues) === JSON.stringify(dfTitleValues);
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenChucDanh;
    try {
      setShowDialog(true);
      if (id !== undefined) {
        try {
          await PutApi.PutDMCD(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa danh mục chức danh: ${
              dataDetailDMCD.tenChucDanh !== tendm
                ? `${dataDetailDMCD.tenChucDanh} thành`
                : ""
            } ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Sửa danh mục chức danh thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể sửa thành danh mục đã tồn tại");
        }
      } else {
        try {
          await ProductApi.PostDMCD(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm danh mục chức danh mới: ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Thêm danh mục chức danh thành công");
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
      if (dataDetailDMCD.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMCD(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa danh mục chức danh: ${dataDetailDMCD.tenChucDanh}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Xoá danh mục chức danh thành công");
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
              {dataDetailDMCD.length !== 0 ? "Sửa" : "Thêm"} danh mục chức danh
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMCD.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMCD.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputTitleChange()) {
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
                    htmlFor="maChucDanh"
                  >
                    Mã chức danh
                  </label>
                  <input
                    type="text"
                    {...register("maChucDanh")}
                    id="maChucDanh"
                    className={
                      !errors.maChucDanh
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                    readOnly
                  />
                  <span className="message">{errors.maChucDanh?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenChucDanh"
                  >
                    Tên chức danh
                  </label>
                  <input
                    type="text"
                    {...register("tenChucDanh")}
                    id="tenChucDanh"
                    className={
                      !errors.tenChucDanh
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenChucDanh?.message}</span>
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
                  <Controller
                    control={control}
                    name="phuCap"
                    render={({ field }) => (
                      <NumberFormat
                        onValueChange={(values) => {
                          field.onChange(values.value);
                        }}
                        id="phuCap"
                        thousandSeparator={true}
                        value={field.value}
                        className={
                          !errors.phuCapChucDanh
                            ? "form-control col-sm-6 "
                            : "form-control col-sm-6 border-danger"
                        }
                        {...field.value}
                      />
                    )}
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
        description={`Bạn chắc chắn muốn xóa danh mục chức danh ${dataDetailDMCD.tenChucDanh}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddTitleForm;
