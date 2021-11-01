import React from "react";
import "./AddSalaryForm.scss";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../FontAwesomeIcons/index";
import { useState } from "react";
import { useEffect } from "react";
import ProductApi from "../../api/productApi";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
import DeleteApi from "../../../src/api/deleteAPI";
import PutApi from "../../../src/api/putAAPI";

const schema = yup.object({
  idNhomLuong: yup.number().required("Nhóm lương không được bỏ trống."),
  heSoLuong: yup.number().required("Hệ số lương không được bỏ trống."),
  bacLuong: yup.string().required("Bậc lương không được bỏ trống."),
  // ngayHetHan: yup.date().required("Ngày hết hạn không được bỏ trống."),
  // ngayCoHieuLuc: yup.date().required("Ngày có hiệu lực không được bỏ trống."),
  luongCoBan: yup.number().required("Lương cơ bản không được bỏ trống."),
  phuCapTrachNhiem:yup.number().required("Phụ cấp chức vụ không được bỏ trống."),
  phuCapKhac: yup.number().required("Phụ cấp khác không được bỏ trống."),
  tongLuong: yup.number().required("Phụ cấp khác không được bỏ trống."),
  thoiHanLenLuong: yup
    .string()
    .required("thời hạn lên lương không được bỏ trống."),
  trangThai: yup.boolean(),
});
function AddSalaryForm(props) {
  const [salary, setSalary] = useState();
  //   heSoLuong: "",
  //   luongCoBan: "",
  //   phuCapTrachNhiem:"",
  //   phuCapKhac:"",
  // });
  let { match, history } = props;
  let { id } = match.params;
  
  // state contain data
  const [dataLDetail, setDataLDetail] = useState([]);
  const [dataNL, setDataNL] = useState([]);
  // get data from api
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNL = await ProductApi.getAllDMNL();
        setDataNL(responseNL);
        if (id !== undefined) {
          const response = await ProductApi.getLDetail(id);
          setDataLDetail(response);
        }
     
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList(dataLDetail);
  }, []);

  const intitalValue = {
    idNhomLuong: id!== undefined?dataLDetail.idNhomLuong:null,
    heSoLuong: id !== undefined ? dataLDetail.heSoLuong : null,
    bacLuong: id !== undefined ? dataLDetail.bacLuong : null,
    luongCoBan: id !== undefined ? dataLDetail.luongCoBan : null,
    phuCapTrachNhiem: id !== undefined ? dataLDetail.phuCapTrachNhiem : null,
    phuCapKhac: id !== undefined ? dataLDetail.phuCapKhac : null,
    tongLuong: id !== undefined ? dataLDetail.tongLuong : null,
    thoiHanLenLuong: id !== undefined ? dataLDetail.thoiHanLenLuong : null,
    ngayHieuLuc: dataLDetail.ngayHieuLuc,
    ngayKetThuc: dataLDetail.ngayHieuLuc,
    ghiChu: id !== undefined ? dataLDetail.ghiChu : null,
    trangThai: id !== undefined ? (dataLDetail.trangThai==="Kích hoạt"?true:false) : true,
    maHopDong: id !== undefined ? dataLDetail.maHopDong : null,
    
  };
  console.log((dataLDetail.idNhomLuong));
  // console.log((dataNL[0].id));
  
  
  const {
    register,
    handleSubmit,
    setValue,
    getValues,
    control,
    reset,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataLDetail) {
      reset(intitalValue);
    }
  }, [dataLDetail]);

  const [rs, setRs] = useState();
  // const handleOnChange = (e) => {
  //   setSalary({
  //     ...salary,
  //     [e.target.name]: e.target.value,
  //   });
  // };
  // useEffect(() => {
  //   setRs(Number(salary.heSoLuong) * Number(salary.luongCoBan) + Number(salary.phuCapTrachNhiem)+ Number(salary.phuCapKhac));
  // }, [salary]);
  const calSalary = () => {
    const rs =
      Number(getValues("heSoLuong")) * Number(getValues("luongCoBan")) +
      Number(getValues("phuCapTrachNhiem")) +
      Number(getValues("phuCapKhac"));
    console.log(rs);
    setValue("tongLuong", rs);
  };
  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if(id !== undefined){
        await PutApi.PutL(data,id);
      }else{
        await ProductApi.PostL(data);
      }
      history.goBack();
    }catch(error){
      console.log("errors: ",error);
      
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteL(id);
      history.push(`/salary`);
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">
            {dataLDetail.length !== 0 ? "Sửa" : "Thêm"} hồ sơ lương
          </h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={
              dataLDetail.length !== 0 ? "btn btn-danger" : "delete-button"
            }
            onClick={handleDelete}
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
            value={dataLDetail.length !== 0 ? "Sửa" : "Lưu"}
            onClick={handleSubmit(onHandleSubmit)}
          />
        </div>
      </div>
      <form
        action=""
        className="profile-form"
        // onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="container-div-form">
          <div className="container-salary">
            <div>
              <h3>Thông tin chung</h3>
            </div>
            <div className="">
              <span className="mr-3">
                Tiền Lương:
                <input
                  {...register("tongLuong")}
                  className="border-0"
                  readOnly
                ></input>
              </span>
              <button
                onClick={(e) => {
                  e.preventDefault();
                  // setValue("tongLuong", rs);
                  calSalary();
                }}
              >
                <FontAwesomeIcon
                  className="icon"
                  icon={["fas", "money-check-alt"]}
                />
              </button>
            </div>
          </div>

          <div className="row">
            <div className="col">
              <div className="form-group form-inline ">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="maHopDong"
                >
                  Mã hợp đồng
                </label>
                <input
                  type="text"
                  {...register("maHopDong")}
                  id="maHopDong"
                  className={
                    !errors.maHopDong
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.maHopDong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="idNhomLuong"
                >
                  Nhóm lương
                </label>
                <select
                  type="text"
                  {...register("idNhomLuong")}
                  id="idNhomLuong"
                  className={
                    !errors.idNhomLuong
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  {/* <option value={dataLDetail.idNhomLuong}>
                    {dataLDetail.nhomLuong}
                  </option> */}
                  <option value=""></option>
                  {dataNL.map((item, key) => (
                    <option key={key} value={item.id}>
                      {item.tenNhomLuong}
                    </option>
                  ))}
                  {/* {
                    dataNL
                    .filter((item) => item.id !== dataLDetail.idNhomLuong)
                    .map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenNhomLuong}{" "}
                      </option>
                    ))} */}
                </select>
                <span className="message">{errors.idNhomLuong?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="heSoLuong"
                >
                  Hệ số lương
                </label>
                <input
                  type="text"
                  {...register("heSoLuong")}
                  id="heSoLuong"
                  // value={salary.heSoLuong}
                  // onChange={handleOnChange}
                  className={
                    !errors.heSoLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.heSoLuong?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="bacLuong"
                >
                  Bậc lương
                </label>
                <input
                  type="text"
                  {...register("bacLuong")}
                  id="bacLuong"
                  className={
                    !errors.bacLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.bacLuong?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="luongCoBan"
                >
                  Lương cơ bản
                </label>
                <input
                  type="text"
                  {...register("luongCoBan")}
                  id="luongCoBan"
                  className={
                    !errors.luongCoBan
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  // value={salary.luongCoBan}
                  // onChange={handleOnChange}
                />
                <span className="message">{errors.luongCoBan?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="thoiHanLenLuong"
                >
                  Thời hạn lên lương
                </label>
                <input
                  type="text"
                  {...register("thoiHanLenLuong")}
                  id="thoiHanLenLuong"
                  className={
                    !errors.thoiHanLenLuong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">
                  {errors.thoiHanLenLuong?.message}
                </span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="phuCapTrachNhiem"
                >
                  Phụ cấp chức vụ
                </label>
                <input
                  type="text"
                  {...register("phuCapTrachNhiem")}
                  id="phuCapTrachNhiem"
                  className={
                    !errors.phuCapTrachNhiem
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">
                  {errors.phuCapTrachNhiem?.message}
                </span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="phuCapKhac"
                >
                  Phụ cấp khác
                </label>
                <input
                  type="text"
                  {...register("phuCapKhac")}
                  id="phuCapKhac"
                  className={
                    !errors.phuCapKhac
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.phuCapKhac?.message}</span>
              </div>
            </div>
          </div>

          <div className="row">
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="ngayHieuLuc"
                >
                  Ngày có hiệu lực
                </label>
                <Controller
                  name="ngayHieuLuc"
                  control={control}
                  render={({ field, onChange }) => (
                    <DatePicker
                      id="ngayHieuLuc"
                      className={
                        !errors.ngayHieuLuc
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="DD/MM/YYYY"
                      format="DD/MM/YYYY"
                      value={moment(field.value)}
                      onChange={(event) => {
                        field.onChange(event.toDate());
                      }}
                      {...field._d}
                    />
                  )}
                />
                <span className="message">{errors.ngayHieuLuc?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="ngayKetThuc"
                >
                  Ngày hết hạn
                </label>
                <Controller
                  name="ngayKetThuc"
                  control={control}
                  render={({ field, onChange }) => (
                    <DatePicker
                      id="tuThoiGian"
                      className={
                        !errors.ngayKetThuc
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="DD/MM/YYYY"
                      format="DD/MM/YYYY"
                      value={moment(field.value)}
                      onChange={(event) => {
                        field.onChange(event.toDate());
                      }}
                      {...field._d}
                    />
                  )}
                />
                <span className="message">{errors.ngayKetThuc?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="ghiChu"
                >
                  Ghi chú
                </label>
                <textarea
                  type="text"
                  {...register("ghiChu")}
                  id="ghiChu"
                  className={
                    !errors.ghiChu
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.ghiChu?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  style={id!== undefined? null:{display: "none"}} 
                  htmlFor="trangThai"
                >
                  Trạng Thái
                </label>
                <select
                  type="text"
                  {...register("trangThai")}
                  id="trangThai"
                  style={id!== undefined? null:{display: "none"}} 
                  className={
                    !errors.trangThai
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option value={true}>Kích hoạt</option>
                  <option value={false}>Vô hiệu</option>
                </select>
                <span className="message">{errors.trangThai?.message}</span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddSalaryForm;
