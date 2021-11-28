import React, { useRef } from "react";
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
import { useLocation } from "react-router";
import DialogCheck from "../Dialog/DialogCheck";
import { useToast } from "../Toast/Toast";
import Dialog from "../../components/Dialog/Dialog";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import jwt_decode from "jwt-decode";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
const schema = yup.object({
  maHopDong: yup
    .string()
    .matches(notAllowNull, "Mã hợp đồng không được là khoảng trống.")
    .nullable()
    .required("Mã hợp đồng không được bỏ trống."),
  idNhomLuong: yup
    .number()
    .nullable()
    .required("Nhóm lương không được bỏ trống."),
  heSoLuong: yup
    .number()
    .positive("Hệ số lương không thể là số âm.")
    .typeError("Hệ số lương không được bỏ trống."),
  bacLuong: yup.string().matches(notAllowNull, "Bậc lương không được là khoảng trống.").nullable().required("Bậc lương không được bỏ trống."),
  ngayHieuLuc: yup
    .date()
    .nullable()
    .required("Ngày hết hạn không được bỏ trống."),
  // ngayKetThuc: yup.date().nullable().required("Ngày có hiệu lực không được bỏ trống."),
  luongCoBan: yup
    .number()
    .positive("Lương cơ bản không thể là số âm.")
    .typeError("Lương cơ bản không được bỏ trống và phải là số."),
  // phuCapTrachNhiem: yup
  //   .number()
  //   .positive("Phụ cấp chức vụ không thể là số âm.")
  //   .typeError("Phụ cấp chức vụ không được bỏ trống và phải là số."),
  phuCapKhac: yup
    .number()
    .positive("Phụ cấp khác không thể là số âm.")
    .typeError("Phụ cấp khác không được bỏ trống và phải là số."),
  tongLuong: yup.number(),
  thoiHanLenLuong: yup
    .string()
    .matches(notAllowNull, "Thời hạn lên lương không được là khoảng trống.")
    .nullable()
    .required("thời hạn lên lương không được bỏ trống."),
  trangThai: yup.boolean(),
  ghiChu:yup
  .string()
  .matches(allNull, "Ghi chú không thể là khoảng trống.")
  .nullable()
  .notRequired(),
});

function AddSalaryForm(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  const contractCode = query.get("maHopDong");
  const { error, warn, info, success } = useToast();
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [salary, setSalary] = useState({
    heSoLuong: "",
    luongCoBan: "",
    phuCapTrachNhiem: "",
    phuCapKhac: "",
  });
  let { match, history } = props;
  let { id } = match.params;

  // state contain data
  const [dataLDetail, setDataLDetail] = useState([]);
  const [dataNL, setDataNL] = useState([]);

  const [dataDetailNN, setdataDetailNN] = useState([]);
  const [dataNN, setDataNN] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin lương mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);

  const [salaryTime, setSalaryTime] = useState();
  const [endDate, setEndDate] = useState();
  const [startDate, setStartDate] = useState();
  const [endDateRs, setEndDateRs] = useState();
  const [dataAllHD, setDataAllHD] = useState([]);
  const [rsSalary, setRsSalary] = useState(0);
  const [contractCodes, setContractCodes] = useState();

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };
  // get data from api
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNL = await ProductApi.getAllDMNL();
        setDataNL(responseNL);
        const responseAllHD = await ProductApi.getAllHd();
        setDataAllHD(responseAllHD);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin lương");
          const response = await ProductApi.getLDetail(id);
          setDataLDetail(response);
          setStartDate(moment(response.ngayHieuLuc));
          setEndDate(moment(response.ngayKetThuc));
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList(dataLDetail);
  }, []);

  useEffect(() => {
    const getContractCode = async () => {
      try {
        if (contractCodes !== undefined) {
          const responseDetailHD = await ProductApi.getHdDetail(contractCodes);
          setValue("phuCapTrachNhiem", responseDetailHD.phuCapChucVu);
          console.log(responseDetailHD);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    getContractCode();
  }, [contractCodes]);

  console.log(contractCodes);

  const [file, setFile] = useState({
    file: null,
    path: "/Images/userIcon.png",
  });
  const handleChange = (e) => {
    console.log(e);
    setFile({
      file: e.fileList.length !== 0 ? e.file : null,
      path:
        e.fileList.length !== 0
          ? URL.createObjectURL(e.file)
          : "/Images/userIcon.png",
      //file: e.target.files[0],
      //path: URL.createObjectURL(e.target.files[0]),
    });
  };

  const intitalValue = {
    idNhomLuong: id !== undefined ? dataLDetail.idNhomLuong : null,
    heSoLuong: id !== undefined ? dataLDetail.heSoLuong : null,
    bacLuong: id !== undefined ? dataLDetail.bacLuong : null,
    luongCoBan: id !== undefined ? dataLDetail.luongCoBan : null,
    phuCapTrachNhiem: id !== undefined ? dataLDetail.phuCapTrachNhiem : null,
    phuCapKhac: id !== undefined ? dataLDetail.phuCapKhac : null,
    tongLuong: id !== undefined ? dataLDetail.tongLuong : rsSalary,
    thoiHanLenLuong: id !== undefined ? dataLDetail.thoiHanLenLuong : null,
    ngayHieuLuc:
      id !== undefined
        ? moment(dataLDetail.ngayHieuLuc)._d == "Invalid Date"
          ? dataLDetail.ngayHieuLuc
          : moment(dataLDetail.ngayHieuLuc)
        : dataLDetail.ngayHieuLuc,
    ngayKetThuc:
      id !== undefined
        ? moment(dataLDetail.ngayKetThuc)._d == "Invalid Date"
          ? dataLDetail.ngayKetThuc
          : moment(dataLDetail.ngayKetThuc)
        : dataLDetail.ngayKetThuc,
    ghiChu: id !== undefined ? dataLDetail.ghiChu : null,
    trangThai:
      id !== undefined
        ? dataLDetail.trangThai === "Kích hoạt"
          ? true
          : false
        : true,
    maHopDong:
      id !== undefined ? dataLDetail.maHopDong : query.get("maHopDong"),
  };

  const {
    register,
    handleSubmit,
    setValue,
    getValues,
    control,
    reset,
    watch,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  const checkInputChange = () => {
    const values = getValues([
      "idNhomLuong",
      "heSoLuong",
      "bacLuong",
      "luongCoBan",
      "phuCapTrachNhiem",
      "phuCapKhac",
      "tongLuong",
      "thoiHanLenLuong",
      "ngayHieuLuc",
      "ngayKetThuc",
      "ghiChu",
      "trangThai",
      "maHopDong",
    ]);
    const dfValue = [
      intitalValue.idNhomLuong,
      intitalValue.heSoLuong,
      intitalValue.bacLuong,
      intitalValue.luongCoBan,
      intitalValue.phuCapTrachNhiem,
      intitalValue.phuCapKhac,
      intitalValue.tongLuong,
      intitalValue.thoiHanLenLuong,
      intitalValue.ngayHieuLuc,
      intitalValue.ngayKetThuc,
      intitalValue.ghiChu,
      intitalValue.trangThai,
      intitalValue.maHopDong,
    ];
    // return JSON.stringify(values) === JSON.stringify(dfValue);
    if (
      JSON.stringify(values) === JSON.stringify(dfValue) &&
      file.file === null
    ) {
      return true;
    }
    return false;
  };
  useEffect(() => {
    if (dataLDetail) {
      reset(intitalValue);
    }
  }, [dataLDetail]);

  const handleOnChange = (e) => {
    setSalary({
      ...salary,
      [e.target.name]: e.target.value,
    });
  };
  //console.log(salary);

  // useEffect(() => {
  //   reset(intitalValue.heSoLuong);
  // }, [intitalValue.heSoLuong]);

  console.log(startDate);
  console.log(endDate);

  useEffect(() => {
    if (id !== undefined) {
      setSalary({
        heSoLuong: getValues("heSoLuong"),
        luongCoBan: getValues("luongCoBan"),
        phuCapKhac: getValues("phuCapKhac"),
        phuCapTrachNhiem: getValues("phuCapTrachNhiem"),
      });
    }
    let rss = 0;
    rss +=
      Number(salary.heSoLuong) * Number(salary.luongCoBan) +
      Number(salary.phuCapKhac) +
      Number(getValues("phuCapTrachNhiem"));
    setValue("tongLuong", rss);
  }, [
    salary.heSoLuong,
    salary.luongCoBan,
    salary.phuCapKhac,
    //  salary.phuCapTrachNhiem,
  ]);

  const onHandleSubmit = async (data) => {
    let maHopDong = data.maHopDong;
    console.log(data);
    // if (endDateRs !== undefined) {
    //   let obj = { ngayKetThuc: endDateRs };
    //   Object.assign(data, obj);
    //   console.log(Object.assign(data, obj));
    // }
    try {
      if (id !== undefined) {
        try {
          const formData = new FormData();
          formData.append("bangChung", file.file);
          // formData.append("maHopDong", data.maHopDong);
          formData.append("idNhomLuong", data.idNhomLuong);
          formData.append("heSoLuong", data.heSoLuong);
          formData.append("bacLuong", data.bacLuong);
          formData.append("luongCoBan", data.luongCoBan);
          formData.append("phuCapTrachNhiem", data.phuCapTrachNhiem);
          formData.append("phuCapKhac", data.phuCapKhac);
          formData.append("tongLuong", data.tongLuong);
          formData.append("thoiHanLenLuong", data.thoiHanLenLuong);
          formData.append("ngayHieuLuc", startDate.format("MM/DD/YYYY"));
          formData.append("ngayKetThuc", endDate.format("MM/DD/YYYY"));
          formData.append("ghiChu", data.ghiChu);
          formData.append("trangThai", data.trangThai);
          await PutApi.PutL(formData, id);
        } catch (errors) {
          error(`Lỗi:${errors}`);
        }

        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa thông tin lương trong hợp đồng ${maHopDong} của nhân viên ${dataLDetail.tenNhanVien}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success(
          `Sửa thông tin lương cho nhân viên ${dataLDetail.tenNhanVien} thành công`
        );
      } else {
        const formData = new FormData();
        formData.append("bangChung", file.file);
        formData.append("maHopDong", data.maHopDong);
        formData.append("idNhomLuong", data.idNhomLuong);
        formData.append("heSoLuong", data.heSoLuong);
        formData.append("bacLuong", data.bacLuong);
        formData.append("luongCoBan", data.luongCoBan);
        formData.append("phuCapTrachNhiem", data.phuCapTrachNhiem);
        formData.append("phuCapKhac", data.phuCapKhac);
        formData.append("tongLuong", data.tongLuong);
        formData.append("thoiHanLenLuong", data.thoiHanLenLuong);
        formData.append("ngayHieuLuc", startDate.format("MM/DD/YYYY"));
        formData.append("ngayKetThuc", endDate.format("MM/DD/YYYY"));
        formData.append("ghiChu", data.ghiChu);
        formData.append("trangThai", data.trangThai);
        await ProductApi.PostL(formData);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm lương mới trong hợp đồng ${maHopDong} của nhân viên ${dataLDetail.tenNhanVien}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success(
          `thêm thông tin lương cho nhân viên ${dataLDetail.tenNhanVien} thành công`
        );
      }
      history.goBack();
    } catch (errors) {
      console.log("errors: ", errors);
      error(`Có lỗi xảy ra ${errors}`);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteL(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa lương trong hợp đồng ${dataLDetail.maHopDong} của nhân viên ${dataLDetail.tenNhanVien}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success(
        `Xoá thông tin lương cho nhân viên ${dataLDetail.tenNhanVien} thành công`
      );
      history.push(`/salary`);
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  // useEffect(() => {
  //   if(id!== undefined){
  //     setSalaryTime(Number(getValues("thoiHanLenLuong")));
  //   }
  //   if (
  //     salaryTime !== undefined &&
  //     endDate !== undefined &&
  //     salaryTime !== 0 &&
  //     endDate !== null
  //   ) {
  //     const rs = endDate.clone();
  //     setEndDateRs(rs.add(salaryTime, "years"));
  //   }
  // }, [salaryTime, endDate]);

  return (
    <>
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
              value={dataLDetail.length !== 0 ? "Sửa" : "Lưu"}
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
          className="profile-form"
          // onSubmit={handleSubmit(onHandleSubmit)}
        >
          <div className="container-div-form">
            <div className="container-salary">
              <div>
                <h3>Thông tin chung</h3>
              </div>
              <div>
                <div className="salary-cal">
                  <span className="mr-3">
                    Tiền Lương:
                    <input
                      {...register("tongLuong")}
                      className="border-0"
                      // value={rsSalary}
                      // defaultValue={calSalary()}
                      readOnly
                    ></input>
                  </span>
                </div>
                <span className="message-1">{errors.tongLuong?.message}</span>
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
                    {...register("maHopDong", {
                      onChange: (e) => setContractCodes(e.target.value),
                    })}
                    id="maHopDong"
                    className={
                      !errors.maHopDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                    list="contractCode"
                    readOnly={contractCode ? true : false}
                  />
                  <datalist id="contractCode">
                    {dataAllHD
                      .filter((item) => item.trangThai === "Kích hoạt")
                      .map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenNhanVien}
                        </option>
                      ))}
                  </datalist>
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
                    {...register("heSoLuong", {
                      onChange: (e) => handleOnChange(e),
                    })}
                    id="heSoLuong"
                    // value={salary.heSoLuong}
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
                    {...register("luongCoBan", {
                      onChange: (e) => handleOnChange(e),
                    })}
                    id="luongCoBan"
                    className={
                      !errors.luongCoBan
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    // value={salary.luongCoBan}
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
                    {...register("thoiHanLenLuong", {
                      onChange: (e) => setSalaryTime(Number(e.target.value)),
                    })}
                    id="thoiHanLenLuong"
                    // onChange={(e)=>setSalaryTime(Number(e.target.value))}
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
                    {...register("phuCapTrachNhiem", {
                      onChange: (e) => handleOnChange(e),
                    })}
                    id="phuCapTrachNhiem"
                    className={
                      !errors.phuCapTrachNhiem
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    readOnly
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
                    {...register("phuCapKhac", {
                      onChange: (e) => handleOnChange(e),
                    })}
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
                        value={field.value}
                        onChange={(event) => {
                          field.onChange(event);
                          setStartDate(event);
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
                    render={({ field }) => (
                      <DatePicker
                        id="ngayKetThuc"
                        className={
                          !errors.ngayKetThuc
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger"
                        }
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        // value={endDateRs}
                        // {...field._d}
                        // disabled={true}
                        value={field.value}
                        onChange={(event) => {
                          field.onChange(event);
                          setEndDate(event);
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
                    htmlFor="bangChung"
                  >
                    Tài liệu đính kèm
                  </label>
                  <Upload
                    beforeUpload={() => false}
                    onChange={handleChange}
                    maxCount={1}
                  >
                    <Button icon={<UploadOutlined />}>Chọn thư mục</Button>
                  </Upload>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    style={id !== undefined ? null : { display: "none" }}
                    htmlFor="trangThai"
                  >
                    Trạng Thái
                  </label>
                  <select
                    type="text"
                    {...register("trangThai")}
                    id="trangThai"
                    style={id !== undefined ? null : { display: "none" }}
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
            ? "Bạn chưa thay đổi thông tin lương"
            : "Bạn chưa nhập thông tin kỷ lương"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin lương`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddSalaryForm;
