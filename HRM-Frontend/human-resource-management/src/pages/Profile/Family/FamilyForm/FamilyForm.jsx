import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useLocation } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import "./FamilyForm.scss";
import DeleteApi from "../../../../api/deleteAPI";
import PutApi from "../../../../api/putAAPI";
import ProductApi from "../../../../api/productApi";
import Dialog from "../../../../components/Dialog/Dialog";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
import { useToast } from "../../../../components/Toast/Toast";
import DialogCheck from "../../../../components/Dialog/DialogCheck";
import { schema } from "../../../../ultis/FamilyValidation";

function AddFamilyForm(props) {
  const { error, warn, info, success } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  let location = useLocation();
  console.log(location);
  let query = new URLSearchParams(location.search);
  console.log(query.get("maNhanVien"));
  const eCode = query.get("maNhanVien");
  let eName = query.get("hoTen");
  const [dataDetailNT, setdataDetailNT] = useState([]);
  const [dataNT, setDataNT] = useState([]);
  const [gender, setGender] = useState();
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin gia đình mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNN = await ProductApi.getAllDMNT();
        setDataNT(responseNN);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin gia đình");
          const response = await ProductApi.getNTDetail(id);
          setdataDetailNT(response);
          setGender(response.gioiTinh);
        }
      } catch (errors) {
        error("Có lỗi xảy ra.");
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailNT.length !== 0) {
        document.title = `Thay đổi thông tin người thân cho nhân viên ${dataDetailNT.tenNhanVien}`;
      } else if (id === undefined) {
        document.title = `Tạo thông tin người thân của nhân viên ${eName}`;
      }
    };
    titlePage();
  }, [dataDetailNT]);

  const intitalValue = {
    idDanhMucNguoiThan:
      id !== undefined ? `${dataDetailNT.idDanhMucNguoiThan}` : null,
    tenNguoiThan: id !== undefined ? `${dataDetailNT.tenNguoiThan}` : null,
    gioiTinh:
      id !== undefined
        ? `${dataDetailNT.gioiTinh}` === "Nam"
          ? true
          : false
        : true,
    ngaySinh:
      id !== undefined
        ? moment(dataDetailNT.ngaySinh)._d == "Invalid Date"
          ? dataDetailNT.ngaySinh
          : moment(dataDetailNT.ngaySinh)
        : dataDetailNT.ngaySinh,
    quanHe: id !== undefined ? `${dataDetailNT.quanHe}` : null,
    ngheNghiep: id !== undefined ? `${dataDetailNT.ngheNghiep}` : null,
    diaChi: id !== undefined ? `${dataDetailNT.diaChi}` : null,
    dienThoai: id !== undefined ? `${dataDetailNT.dienThoai}` : null,
    khac:
      id !== undefined
        ? `${dataDetailNT.khac}` === null
          ? null
          : `${dataDetailNT.khac}`
        : null,
    maNhanVien: id !== undefined ? `${dataDetailNT.maNhanVien}` : eCode,
  };

  const {
    register,
    handleSubmit,
    control,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataDetailNT) {
      reset(intitalValue);
    }
  }, [dataDetailNT]);

  const checkInputChange = () => {
    const values = getValues([
      "idDanhMucNguoiThan",
      "tenNguoiThan",
      "gioiTinh",
      "quanHe",
      "ngheNghiep",
      "diaChi",
      "dienThoai",
      "maNhanVien",
      "khac",
      "ngaySinh",
    ]);
    const dfValue = [
      intitalValue.idDanhMucNguoiThan,
      intitalValue.tenNguoiThan,
      intitalValue.gioiTinh,
      intitalValue.quanHe,
      intitalValue.ngheNghiep,
      intitalValue.diaChi,
      intitalValue.dienThoai,
      intitalValue.maNhanVien,
      intitalValue.khac,
      intitalValue.ngaySinh,
    ];
    return JSON.stringify(values) === JSON.stringify(dfValue);
  };

  console.log(gender);

  console.log(dataDetailNT);
  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutNT(data, id);
        success(
          `Sửa thông tin gia đình cho nhân viên ${dataDetailNT.tenNhanVien} thành công`
        );
      } else {
        await ProductApi.postNT(data);
        success(
          `Thêm thông tin gia đình cho nhân viên ${dataDetailNT.tenNhanVien} thành công`
        );
      }
      history.goBack();
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteNT(id);
      history.push(`/profile/detail/${dataDetailNT.maNhanVien}`);
      success(
        `Xoá thông tin gia đình cho nhân viên ${dataDetailNT.tenNhanVien} thành công`
      );
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
    }
  };
  return (
    <>
      <div className="container-form">
        <div className="Submit-button">
          <div>
            <h2 className="">
              {dataDetailNT.length !== 0 ? "Sửa" : "Thêm"} thông tin gia đình
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailNT.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailNT.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputChange()) {
                  setShowCheckDialog(true);
                } else {
                  setShowDialog(true);
                }
              }}
            />
          </div>
        </div>
        <form
          action=""
          class="profile-form"
          // onSubmit={handleSubmit(onHandleSubmit)}
        >
          {/* Container thông tin cơ bản */}
          <div className="container-div-form">
            <h3>Thông tin chung</h3>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="maNhanVien"
                  >
                    Mã Nhân Viên
                  </label>
                  <input
                    type="text"
                    {...register("maNhanVien")}
                    id="maNhanVien"
                    className={
                      !errors.maNhanVien
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    readOnly
                  />
                  <span className="message">{errors.maNhanVien?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idDanhMucNguoiThan"
                  >
                    Danh mục người thân
                  </label>
                  <select
                    type="text"
                    {...register("idDanhMucNguoiThan")}
                    id="idDanhMucNguoiThan"
                    className={
                      !errors.idDanhMucNguoiThan
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailNT.idDanhMucNguoiThan}>
                      {dataDetailNT.danhMucNguoiThan}
                    </option>
                    {dataNT.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenDanhMuc}{" "}
                      </option>
                    ))}
                  </select>
                  <span className="message">
                    {errors.idDanhMucNguoiThan?.message}
                  </span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline ">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="tenNguoiThan"
                  >
                    Họ và tên người thân
                  </label>
                  <input
                    type="text"
                    {...register("tenNguoiThan")}
                    id="tenNguoiThan"
                    className={
                      !errors.tenNguoiThan
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">
                    {errors.tenNguoiThan?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="quanHe"
                  >
                    Quan hệ
                  </label>
                  <input
                    type="text"
                    {...register("quanHe")}
                    id="quanHe"
                    className={
                      !errors.quanHe
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  {/* <option value={dataDetailTDVH.idHinhThucDaoTao}>{dataDetailTDVH.tenHinhThuc}</option>
                  {dataHTDT.map((item,key)=>(
                    <option key={key} value={item.id}>
                    {item.tenHinhThuc}{" "}
                  </option>
                  ))} */}

                  <span className="message">{errors.quanHe?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="gioiTinh"
                  >
                    Giới tính
                  </label>
                  <select
                    type="text"
                    {...register("gioiTinh")}
                    id="gioiTinh"
                    className={
                      !errors.gioiTinh
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                    onChange={(e) => {
                      setGender(e.target.value);
                    }}
                  >
                    <option value={true}>Nam</option>
                    <option value={false}>Nữ</option>
                  </select>
                  <span className="message">{errors.gioiTinh?.message}</span>
                </div>
              </div>
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="ngaySinh"
                  >
                    Ngày sinh
                  </label>
                  <Controller
                    name="ngaySinh"
                    control={control}
                    render={({ field, onChange }) => (
                      <DatePicker
                        id="ngaySinh"
                        className={
                          !errors.ngaySinh
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger"
                        }
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        //defaultValue={moment(dataDetailTDVH.tuThoiGian)}
                        // onChange={(event) => {
                        //   handleChangeDate(event);
                        // }}
                        value={field.value}
                        onChange={(event) => {
                          field.onChange(event);
                        }}
                        //selected={field}
                        {...field._d}

                        //inputRef={dates}
                      />
                    )}
                  />
                  <span className="message">{errors.ngaySinh?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="diaChi"
                  >
                    Địa chỉ
                  </label>
                  <input
                    type="text"
                    {...register("diaChi")}
                    id="diaChi"
                    className={
                      !errors.diaChi
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.diaChi?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="dienThoai"
                  >
                    Điện thoại
                  </label>
                  <input
                    type="text"
                    {...register("dienThoai")}
                    id="dienThoai"
                    className={
                      !errors.dienThoai
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.dienThoai?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="ngheNghiep"
                  >
                    Nghề nghiệp
                  </label>
                  <input
                    type="text"
                    {...register("ngheNghiep")}
                    id="ngheNghiep"
                    className={
                      !errors.ngheNghiep
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.ngheNghiep?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="khac">
                    Thông tin khác
                  </label>
                  <textarea
                    type="text"
                    rows="4"
                    {...register("khac")}
                    id="khac"
                    className={
                      !errors.khac
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.khac?.message}</span>
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
        description={
          id !== undefined
            ? "Bạn chưa thay đổi thông tin gia đình"
            : "Bạn chưa nhập thông tin gia đình"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin gia đình `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddFamilyForm;
