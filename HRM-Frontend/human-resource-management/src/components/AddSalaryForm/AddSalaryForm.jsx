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
import { useLocation } from "react-router";
import DialogCheck from "../Dialog/DialogCheck";
import { useToast } from "../Toast/Toast";
import Dialog from "../../components/Dialog/Dialog";
const schema = yup.object({
  idNhomLuong: yup
    .number()
    .nullable()
    .required("Nhóm lương không được bỏ trống."),
  heSoLuong: yup
    .number()
    .nullable()
    .required("Hệ số lương không được bỏ trống."),
  bacLuong: yup.string().nullable().required("Bậc lương không được bỏ trống."),
  ngayHieuLuc: yup
    .date()
    .nullable()
    .required("Ngày hết hạn không được bỏ trống."),
  // ngayKetThuc: yup.date().nullable().required("Ngày có hiệu lực không được bỏ trống."),
  luongCoBan: yup
    .number()
    .nullable()
    .required("Lương cơ bản không được bỏ trống."),
  phuCapTrachNhiem: yup
    .number()
    .nullable()
    .required("Phụ cấp chức vụ không được bỏ trống."),
  phuCapKhac: yup
    .number()
    .nullable()
    .required("Phụ cấp khác không được bỏ trống."),
  tongLuong: yup
    .number()
    .nullable()
    .required("Tổng lương không được bỏ trống."),
  thoiHanLenLuong: yup
    .string()
    .nullable()
    .required("thời hạn lên lương không được bỏ trống."),
  trangThai: yup.boolean(),
});
function AddSalaryForm(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  // console.log(query.get("maLuong"));
  const { error, warn, info, success } = useToast();

  const [salary, setSalary] = useState({
    heSoLuong: "",
    luongCoBan: "",
    phuCapTrachNhiem:"",
    phuCapKhac:"",
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
  const [endDateRs, setEndDateRs] = useState();

  const [rsSalary, setRsSalary] = useState(0);

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
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin lương");
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
        ? moment(dataLDetail.ngayHieuLuc)._d == "Invalid Date"
          ? dataLDetail.ngayHieuLuc
          : moment(dataLDetail.ngayHieuLuc)
        : dataLDetail.ngayHieuLuc,
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
  //console.log(dataLDetail.idNhomLuong);
  // console.log((dataNL[0].id));

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
    return JSON.stringify(values) === JSON.stringify(dfValue);
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
    let rss = 0;
    rss +=
      Number(salary.heSoLuong) * Number(salary.luongCoBan) +
      Number(salary.phuCapKhac) +
      Number(salary.phuCapTrachNhiem);
    setValue("tongLuong", rss);
  }, [
    salary.heSoLuong,
    salary.luongCoBan,
    salary.phuCapKhac,
    salary.phuCapTrachNhiem,
  ]);

  console.log(getValues("tongLuong"));
  console.log(getValues("heSoLuong"));
  console.log(getValues("luongCoBan"));
  console.log(getValues("phuCapKhac"));

  const onHandleSubmit = async (data) => {
    console.log(data);
    // if(endDateRs !== undefined){
    //   let obj = {ngayKetThuc: endDateRs}
    //   Object.assign(data,obj);
    //   console.log(Object.assign(data,obj));
    // }
    try {
      if (id !== undefined) {
        await PutApi.PutL(data, id);
        success(
          `Sửa thông tin lương cho nhân viên ${dataLDetail.tenNhanVien} thành công`
        );
      } else {
        if (query.get("checkMaLuong") !== "0") {
          await PutApi.PutTLL(query.get("maHopDong"));
        }
        await ProductApi.PostL(data);
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
      success(
        `Xoá thông tin lương cho nhân viên ${dataLDetail.tenNhanVien} thành công`
      );
      history.push(`/salary`);
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };
  // console.log(Number(getValues("thoiHanLenLuong")));
  //console.log(getValues("ngayHieuLuc"));
  // console.log(moment(dataLDetail.ngayHieuLuc).add(3,"years"));

  // const calSalaryTime = (e) => {
  //   setEndDate(e);
  //   console.log(endDate);
  //   if (salaryTime !== undefined && e !== undefined) {
  //     setEndDateRs(e.add(salaryTime, "years"));
  //   }
  //   return endDateRs;
  // };
  useEffect(()=>{
    if (salaryTime !== undefined && endDate !== undefined && salaryTime !== 0 && endDate !== null) {
      setEndDateRs(endDate.add(salaryTime, "years"));
    }
   // return endDateRs;
    // setValue("ngayKetThuc",endDateRs);
  },[salaryTime,endDate]);

  console.log(salaryTime);
  console.log(endDate);
  console.log(endDateRs);
  

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
                  <button
                  // onClick={(e) => {
                  //   e.preventDefault();
                  //   setValue("tongLuong", rsSalary);
                  //   //calSalary();
                  // }}
                  >
                    <FontAwesomeIcon
                      className="icon"
                      icon={["fas", "money-check-alt"]}
                    />
                  </button>
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
                    {...register("maHopDong")}
                    id="maHopDong"
                    className={
                      !errors.maHopDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                  />
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
                    {...register("heSoLuong",{onChange:(e)=> (handleOnChange(e))})}
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
                    {...register("luongCoBan",{onChange:(e)=> (handleOnChange(e))})}
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
                    {...register("thoiHanLenLuong",{onChange:(e)=> setSalaryTime(Number(e.target.value))})}
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
                    {...register("phuCapTrachNhiem",{onChange:(e)=> (handleOnChange(e))})}
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
                    {...register("phuCapKhac",{onChange:(e)=> (handleOnChange(e))})}
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
                          setEndDate(event);
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
                    value={endDateRs}
                    render={({ field, onChange }) => (
                      <DatePicker
                        id="ngayKetThuc"
                        className={
                          !errors.ngayKetThuc
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger"
                        }
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        
                        onChange={(event) => {
                          field.onChange(event);
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
