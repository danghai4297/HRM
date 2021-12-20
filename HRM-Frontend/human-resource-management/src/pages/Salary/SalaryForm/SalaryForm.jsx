import React from "react";
import "./SalaryForm.scss";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "../../../components/FontAwesomeIcons/index";
import { useState } from "react";
import { useEffect } from "react";
import ProductApi from "../../../api/productApi";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
import DeleteApi from "../../../api/deleteAPI";
import PutApi from "../../../api/putAAPI";
import { useLocation } from "react-router";
import DialogCheck from "../../../components/Dialog/DialogCheck";
import { useToast } from "../../../components/Toast/Toast";
import Dialog from "../../../components/Dialog/Dialog";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import jwt_decode from "jwt-decode";
import { schema } from "../../../ultis/SalaryValidation";
import NumberFormat from "react-number-format";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function AddSalaryForm(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  const contractCode = query.get("maHopDong");
  let eName = query.get("hoTen");
  const { error, success } = useToast();
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

  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin lương mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showEsc, setShowEsc] = useState(false);

  const [salaryTime, setSalaryTime] = useState();
  const [endDate, setEndDate] = useState();
  const [startDate, setStartDate] = useState();
  const [dataAllHD, setDataAllHD] = useState([]);
  const [rsSalary, setRsSalary] = useState(0);
  const [contractCodes, setContractCodes] = useState();
  const [DemoSalary, setDemoSalary] = useState("");
  const [allowance, setAllowance] = useState("");
  const [OtherAllowance, setOtherAllowance] = useState("");
  const [titleAllowance, setTitleAllowance] = useState("");
  const [responsibilityAllowance, setResponsibilityAllowance] = useState("");
  const [totalSalary, setTotalSalary] = useState();
  const [open, setOpen] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
    setShowEsc(false);
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
          try {
            setDescription("Bạn chắc chắn muốn sửa thông tin lương");
            const response = await ProductApi.getLDetail(id);
            setDataLDetail(response);
            setStartDate(moment(response.ngayHieuLuc));
            setEndDate(moment(response.ngayKetThuc));
            setAllowance(response.phuCapChucVu);
            setResponsibilityAllowance(response.phuCapTrachNhiem);
            setTitleAllowance(response.phuCapChucDanh);
            setTotalSalary(response.tongLuong);
          } catch (error) {
            history.goBack();
          }
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataLDetail.length !== 0) {
        document.title = `Thay đổi thông tin lương của nhân viên ${dataLDetail.tenNhanVien}`;
      } else if (id === undefined && eName) {
        document.title = `Tạo lương mới cho nhân viên ${eName}`;
      } else if (id === undefined) {
        document.title = `Tạo lương mới`;
      }
    };
    titlePage();
  }, [dataLDetail]);

  useEffect(() => {
    const getContractCode = async () => {
      try {
        if (contractCodes !== undefined) {
          const responseDetailHD = await ProductApi.getHdDetail(contractCodes);
          setAllowance(responseDetailHD.phuCapChucVu);
          setTitleAllowance(responseDetailHD.phuCapChucDanh);
        } else if (query.get("maHopDong")) {
          const responseDetailHD = await ProductApi.getHdDetail(
            query.get("maHopDong")
          );
          setAllowance(responseDetailHD.phuCapChucVu);
          setTitleAllowance(responseDetailHD.phuCapChucDanh);
        }
      } catch (error) {
        console.log("Có lỗi xảy ra: ", error);
        setAllowance("");
      }
    };
    getContractCode();
  }, [contractCodes]);

  useEffect(() => {
    if (id !== undefined) {
      setOpen(!open);
    }
  }, [dataLDetail]);

  const [file, setFile] = useState({
    file: null,
    path: "/Images/userIcon.png",
    size: null,
    name: null,
  });

  const handleChange = (e) => {
    setFile({
      file: e.fileList.length !== 0 ? e.file : null,
      path:
        e.fileList.length !== 0
          ? URL.createObjectURL(e.file)
          : "/Images/userIcon.png",
      size: e.fileList.length !== 0 ? e.file.size : null,
      name: e.fileList.length !== 0 ? e.file.name : null,
    });
  };
  const intitalValue = {
    idNhomLuong: id !== undefined ? dataLDetail.idNhomLuong : null,
    heSoLuong: id !== undefined ? dataLDetail.heSoLuong : null,
    bacLuong: id !== undefined ? dataLDetail.bacLuong : null,
    luongCoBan: id !== undefined ? dataLDetail.luongCoBan : DemoSalary,
    phuCapTrachNhiem:
      id !== undefined ? dataLDetail.phuCapTrachNhiem : responsibilityAllowance,
    phuCapKhac: id !== undefined ? dataLDetail.phuCapKhac : OtherAllowance,
    phuCapChucDanh:
      id !== undefined ? dataLDetail.phuCapChucDanh : titleAllowance,
    phuCapChucVu: id !== undefined ? dataLDetail.phuCapChucVu : allowance,
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
    getValues,
    control,
    reset,
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
      intitalValue.thoiHanLenLuong,
      intitalValue.ngayHieuLuc,
      intitalValue.ngayKetThuc,
      intitalValue.ghiChu,
      intitalValue.trangThai,
      intitalValue.maHopDong,
    ];
    if (
      JSON.stringify(values) === JSON.stringify(dfValue) &&
      file.file === null &&
      intitalValue.phuCapTrachNhiem == responsibilityAllowance &&
      intitalValue.tongLuong == totalSalary &&
      intitalValue.luongCoBan == DemoSalary &&
      intitalValue.phuCapKhac == OtherAllowance &&
      intitalValue.phuCapChucDanh == titleAllowance &&
      intitalValue.phuCapChucVu == allowance
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
      Number(salary.heSoLuong) * Number(DemoSalary) +
      Number(allowance) +
      Number(OtherAllowance) +
      Number(titleAllowance) +
      Number(DemoSalary) * Number(responsibilityAllowance);
    let fixTotal = (rss / 1000).toFixed(0) * 1000;
    setTotalSalary(fixTotal);
  }, [
    salary.heSoLuong,
    DemoSalary,
    OtherAllowance,
    allowance,
    responsibilityAllowance,
    titleAllowance,
  ]);

  const onHandleSubmit = async (data) => {
    const nameCon = dataAllHD.filter((item) => item.id === data.maHopDong);
    let maHopDong = data.maHopDong;
    try {
      if (id !== undefined) {
        try {
          if (
            dataAllHD
              .filter((item) => item.trangThai === "Kích hoạt")
              .map((item) => item.id)
              .includes(data.maHopDong)
          ) {
            if (file.size < 20000000) {
              const formData = new FormData();
              formData.append("bangChung", file.file);
              // formData.append("maHopDong", data.maHopDong);
              formData.append("idNhomLuong", data.idNhomLuong);
              formData.append("heSoLuong", data.heSoLuong);
              formData.append("bacLuong", data.bacLuong);
              formData.append("luongCoBan", data.luongCoBan);
              formData.append("phuCapTrachNhiem", responsibilityAllowance);
              formData.append("phuCapKhac", data.phuCapKhac);
              formData.append("phuCapChucVu", allowance);
              formData.append("phuCapChucDanh", titleAllowance);
              formData.append("tongLuong", totalSalary);
              formData.append("thoiHanLenLuong", data.thoiHanLenLuong);
              formData.append("ngayHieuLuc", startDate.format("MM/DD/YYYY"));
              formData.append("ngayKetThuc", endDate.format("MM/DD/YYYY"));
              formData.append("ghiChu", data.ghiChu);
              formData.append("trangThai", data.trangThai);
              formData.append("tenFile", file.name);

              await PutApi.PutL(formData, id);
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Sửa thông tin lương trong hợp đồng ${maHopDong} của nhân viên ${dataLDetail.tenNhanVien}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
              success(
                `Sửa thông tin lương cho nhân viên ${dataLDetail.tenNhanVien} thành công`
              );
              history.goBack();
            } else {
              error("Tệp đính kèm không được quá 20MB.");
            }
          } else {
            error("Hợp đồng vô hiệu hoặc mã hợp đồng không tồn tại.");
          }
        } catch (errors) {
          error(`Có lỗi xảy ra.`);
        }
      } else {
        try {
          if (
            dataAllHD
              .filter((item) => item.trangThai === "Kích hoạt")
              .map((item) => item.id)
              .includes(data.maHopDong)
          ) {
            if (file.size < 20000000) {
              const formData = new FormData();
              formData.append("bangChung", file.file);
              formData.append("maHopDong", data.maHopDong);
              formData.append("idNhomLuong", data.idNhomLuong);
              formData.append("heSoLuong", data.heSoLuong);
              formData.append("bacLuong", data.bacLuong);
              formData.append("luongCoBan", data.luongCoBan);
              formData.append("phuCapTrachNhiem", responsibilityAllowance);
              formData.append("phuCapKhac", data.phuCapKhac);
              formData.append("phuCapChucVu", allowance);
              formData.append("phuCapChucDanh", titleAllowance);
              formData.append("tongLuong", totalSalary);
              formData.append("thoiHanLenLuong", data.thoiHanLenLuong);
              formData.append("ngayHieuLuc", startDate.format("MM/DD/YYYY"));
              formData.append("ngayKetThuc", endDate.format("MM/DD/YYYY"));
              formData.append("ghiChu", data.ghiChu);
              formData.append("trangThai", data.trangThai);
              formData.append("tenFile", file.name);
              await ProductApi.PostL(formData);
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Thêm lương mới trong hợp đồng ${maHopDong} của nhân viên ${nameCon[0].tenNhanVien}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
              success(
                `Thêm lương mới trong hợp đồng ${maHopDong} của nhân viên ${nameCon[0].tenNhanVien} thành công`
              );
              history.goBack();
            } else {
              error("Tệp đính kèm không được quá 20MB.");
            }
          } else {
            error("Hợp đồng vô hiệu hoặc mã hợp đồng không tồn tại.");
          }
        } catch (error) {
          error("Thêm lương mới thất bại.");
        }
      }
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
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
      error(`Có lỗi xảy ra.`);
    }
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button">
          <div>
            <h2 className="">
              {dataLDetail.length !== 0 ? "Sửa" : "Thêm"} thông tin lương
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className="btn btn-secondary ml-3"
              value="Huỷ"
              onClick={() => {
                if (!checkInputChange()) {
                  setShowEsc(true);
                } else {
                  history.goBack();
                }
              }}
            />
            <input
              type="submit"
              className="btn btn-primary ml-3 btn-form"
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
        <form action="" className="profile-form">
          <div className="container-div-form">
            <div className="container-salary">
              <div>
                <h3>Thông tin chung</h3>
              </div>
              <div>
                <div className="salary-cal">
                  <span className="mr-3">
                    Tiền Lương:
                    <Controller
                      control={control}
                      name="tongLuong"
                      render={({ field }) => (
                        <NumberFormat
                          id="tongLuong"
                          thousandSeparator={true}
                          value={totalSalary}
                          className="border-0"
                          {...field.value}
                          readOnly
                        />
                      )}
                    />
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
                    readOnly={contractCode || id ? true : false}
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
                    <option value=""></option>
                    {dataNL.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenNhomLuong}
                      </option>
                    ))}
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
                  <Controller
                    control={control}
                    name="luongCoBan"
                    render={({ field }) => (
                      <NumberFormat
                        onValueChange={(values) => {
                          field.onChange(values.value);
                          setDemoSalary(values.value);
                        }}
                        id="luongCoBan"
                        thousandSeparator={true}
                        value={field.value}
                        className={
                          !errors.luongCoBan
                            ? "form-control col-sm-6 "
                            : "form-control col-sm-6 border-danger"
                        }
                        {...field.value}
                      />
                    )}
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
                    htmlFor="phuCapChucVu"
                  >
                    Phụ cấp chức vụ
                  </label>
                  <Controller
                    control={control}
                    name="phuCapChucVu"
                    render={({ field }) => (
                      <NumberFormat
                        id="phuCapChucVu"
                        thousandSeparator={true}
                        value={allowance}
                        className={
                          !errors.phuCapChucVu
                            ? "form-control col-sm-6 "
                            : "form-control col-sm-6 border-danger"
                        }
                        {...field.value}
                        readOnly
                      />
                    )}
                  />
                  <span className="message">
                    {errors.phuCapChucVu?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="phuCapTrachNhiem"
                  >
                    Phụ cấp trách nhiệm
                  </label>
                  <Controller
                    control={control}
                    name="phuCapTrachNhiem"
                    render={({ field }) => (
                      <NumberFormat
                        onValueChange={(values) => {
                          field.onChange(values.value);
                          setResponsibilityAllowance(values.value);
                        }}
                        id="phuCapTrachNhiem"
                        thousandSeparator={true}
                        value={field.value}
                        className={
                          !errors.phuCapTrachNhiem
                            ? "form-control col-sm-6 "
                            : "form-control col-sm-6 border-danger"
                        }
                        {...field.value}
                      />
                    )}
                  />
                  <span className="message">
                    {errors.phuCapTrachNhiem?.message}
                  </span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="phuCapChucDanh"
                  >
                    Phụ cấp chức danh
                  </label>
                  <Controller
                    control={control}
                    name="phuCapChucDanh"
                    render={({ field }) => (
                      <NumberFormat
                        id="phuCapChucDanh"
                        thousandSeparator={true}
                        value={titleAllowance}
                        className={
                          !errors.phuCapChucDanh
                            ? "form-control col-sm-6 "
                            : "form-control col-sm-6 border-danger"
                        }
                        {...field.value}
                        readOnly
                      />
                    )}
                  />
                  <span className="message">
                    {errors.phuCapChucDanh?.message}
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
                  <Controller
                    control={control}
                    name="phuCapKhac"
                    render={({ field }) => (
                      <NumberFormat
                        onValueChange={(values) => {
                          field.onChange(values.value);
                          setOtherAllowance(values.value);
                        }}
                        id="phuCapKhac"
                        thousandSeparator={true}
                        value={field.value}
                        className={
                          !errors.phuCapKhac
                            ? "form-control col-sm-6 "
                            : "form-control col-sm-6 border-danger"
                        }
                        {...field.value}
                      />
                    )}
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
      <Dialog
        show={showEsc}
        title="Thông báo"
        description={"Bạn có chắc chắn muốn hủy không"}
        confirm={history.goBack}
        cancel={cancel}
      />
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default AddSalaryForm;
