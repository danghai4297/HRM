import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { useLocation } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import DeleteApi from "../../../src/api/deleteAPI";
import PutApi from "../../../src/api/putAAPI";
import ProductApi from "../../../src/api/productApi";
import Dialog from "../../components/Dialog/Dialog";
import "./AddLanguageForm.scss";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
const schema = yup.object({
  idDanhMucNgoaiNgu: yup.number().required("Ngoại ngữ không được bỏ trống."),
  //ngayCap: yup.string().required("Ngày cấp không được bỏ trống."),
  trinhDo: yup.string().required("Trình độ không được bỏ trống."),
  noiCap: yup.string().required("Nơi cấp không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
});
function AddLanguageForm(props) {
  let { match, history } = props;

  let location = useLocation();
  console.log(location);
  let query = new URLSearchParams(location.search);
  console.log(query.get("maNhanVien"));
  const eCode = query.get("maNhanVien");
  let { id } = match.params;

  const [dataDetailNN, setdataDetailNN] = useState([]);
  const [dataNN, setDataNN] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm trình độ mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNN = await ProductApi.getAllDMNN();
        setDataNN(responseNN);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốm sửa trình độ");
          const response = await ProductApi.getNNDetail(id);
          setdataDetailNN(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const intitalValue = {
    ngayCap: dataDetailNN.ngayCap,
    trinhDo: id !== undefined ? `${dataDetailNN.trinhDo}` : null,
    noiCap: id !== undefined ? `${dataDetailNN.noiCap}` : null,
    maNhanVien: id !== undefined ? `${dataDetailNN.maNhanVien}` : eCode,
    idDanhMucNgoaiNgu: `${dataDetailNN.idDanhMucNgoaiNgu}`,
  };
  const {
    register,
    handleSubmit,
    reset,
    control,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataDetailNN) {
      reset(intitalValue);
    }
  }, [dataDetailNN]);
  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if (id !== undefined) {
        await PutApi.PutNN(data, id);
      } else {
        await ProductApi.PostNN(data);
      }
      history.goBack();
    } catch (error) {}
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteNN(id);
      history.push(`/profile/detail/${dataDetailNN.maNhanVien}`);
    } catch (error) {}
  };
  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailNN.length !== 0 ? "Sửa" : "Thêm"} ngoại ngữ
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailNN.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailNN.length !== 0 ? "Sửa" : "Lưu"}
              onClick={handleSubmit(onHandleSubmit)}
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
              <div className="col-6">
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
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline ">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idDanhMucNgoaiNgu"
                  >
                    Ngoại ngữ
                  </label>
                  <select
                    type="text"
                    {...register("idDanhMucNgoaiNgu")}
                    id="idDanhMucNgoaiNgu"
                    className={
                      !errors.idDanhMucNgoaiNgu
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailNN.idDanhMucNgoaiNgu}>
                      {dataDetailNN.danhMucNgoaiNgu}
                    </option>
                    {dataNN
                      .filter(
                        (item) => item.id !== dataDetailNN.idDanhMucNgoaiNgu
                      )
                      .map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenDanhMuc}{" "}
                        </option>
                      ))}
                  </select>
                  <span className="message">
                    {errors.idDanhMucNgoaiNgu?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="ngayCap"
                  >
                    ngày cấp
                  </label>
                  {/* <input
                    type="text"
                    {...register("ngayCap")}
                    id="ngayCap"
                    className={
                      !errors.ngayCap
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                    placeholder="DD/MM/YYYY"
                  />
                  {/* <option value={dataDetailTDVH.idHinhThucDaoTao}>{dataDetailTDVH.tenHinhThuc}</option>
                  {dataHTDT.map((item,key)=>(
                    <option key={key} value={item.id}>
                    {item.tenHinhThuc}{" "}
                  </option>
                  ))} */}
                  <Controller
                    name="ngayCap"
                    control={control}
                    render={({ field, onChange }) => (
                      <DatePicker
                        id="ngayCap"
                        className={
                          !errors.ngayCap
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
                  <span className="message">{errors.ngayCap?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="noiCap"
                  >
                    Nơi cấp
                  </label>
                  <input
                    type="text"
                    {...register("noiCap")}
                    id="noiCap"
                    className={
                      !errors.noiCap
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.noiCap?.message}</span>
                </div>
              </div>
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="trinhDo"
                  >
                    Trình độ
                  </label>
                  <input
                    type="text"
                    {...register("trinhDo")}
                    id="trinhDo"
                    className={
                      !errors.trinhDo
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.trinhDo?.message}</span>
                  {/* <Controller
              name="ngaySinh"
              control={control}
              defaultValue=""
              render={({ field }) => (
                <DatePicker
                  id="ngaySinh"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                  format="DD/MM/YYYY"
                  //selected={field}
                  //onChange={(field) => setDate(field)}
                  {...field}
                />
              )}
            /> */}
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
        description={`Bạn chắc chắn muốn xóa trình độ `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLanguageForm;
