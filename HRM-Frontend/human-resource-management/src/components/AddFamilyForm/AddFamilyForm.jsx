import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useLocation } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddFamilyForm.scss";
import DeleteApi from "../../../src/api/deleteAPI";
import PutApi from "../../../src/api/putAAPI";
import ProductApi from "../../../src/api/productApi";
import Dialog from "../../components/Dialog/Dialog";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
const schema = yup.object({
  idDanhMucNguoiThan: yup
    .number()
    .required("Danh mục người thân không được bỏ trống."),
  tenNguoiThan: yup.string().required("Tên người thân không được bỏ trống."),
  gioiTinh: yup.boolean().required("Giới tính không được bỏ trống."),
  //ngaySinh: yup.string().required("Ngày sinh được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  quanHe: yup.string().required("Quan hệ không được bỏ trống."),
  ngheNghiep: yup.string().required("Nghề nghệp không được bỏ trống."),
  diaChi: yup.string().required("Địa chỉ không được bỏ trống."),
  dienThoai: yup.string().required("Điện thoại không được bỏ trống."),
});
function AddFamilyForm(props) {
  let { match, history } = props;
  let { id } = match.params;

  let location = useLocation();
  console.log(location);
  let query = new URLSearchParams(location.search);
  console.log(query.get("maNhanVien"));
  const eCode = query.get("maNhanVien");
  const [dataDetailNT, setdataDetailNT] = useState([]);
  const [dataNT, setDataNT] = useState([]);
  const [gender,setGender] = useState();
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin gia đình mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNN = await ProductApi.getAllDMNT();
        setDataNT(responseNN);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốm sửa thông tin gia đình");
          const response = await ProductApi.getNTDetail(id);
          setdataDetailNT(response);
          setGender(response.gioiTinh);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  
  const intitalValue = {
    idDanhMucNguoiThan:
      id !== undefined ? `${dataDetailNT.idDanhMucNguoiThan}` : null,
    tenNguoiThan: id !== undefined ? `${dataDetailNT.tenNguoiThan}` : null,
    gioiTinh: id !== undefined ? (`${dataDetailNT.gioiTinh}`==="Nam"?true:false) : true,
    ngaySinh: dataDetailNT.ngaySinh,
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
 
  console.log(gender);
  
  console.log(dataDetailNT);
  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if (id !== undefined) {
        await PutApi.PutNT(data, id);
      } else {
        await ProductApi.postNT(data);
      }
      history.goBack();
    } catch (error) {}
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteNT(id);
      history.push(`/profile/detail/${dataDetailNT.maNhanVien}`);
    } catch (error) {}
  };
  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
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
              onClick={()=>{
                setShowDialog(true);
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
                    Họ và tên
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
                  onChange={(e)=>{
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
        description={description}
        confirm={handleSubmit(onHandleSubmit)}
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
