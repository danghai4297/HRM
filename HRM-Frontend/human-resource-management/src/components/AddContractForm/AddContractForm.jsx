import React, { useEffect, useState } from "react";
import "./AddContractForm.scss";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import ProductApi from "../../api/productApi";
import moment from "moment/moment.js";
import "antd/dist/antd.css";
import { DatePicker } from "antd";
import PutApi from "../../api/putAAPI";
import DeleteApi from "../../../src/api/deleteAPI";
import { useLocation } from "react-router";
import DialogCheck from "../Dialog/DialogCheck";
import Dialog from "../../components/Dialog/Dialog";
import { useToast } from "../Toast/Toast";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import jwt_decode from "jwt-decode";

const schema = yup.object({
  trangThai: yup.boolean(),
  maNhanVien: yup
    .string()
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  idLoaiHopDong: yup.number().typeError("Loại hợp đồng không được bỏ trống."),
  idChucDanh: yup.number().typeError("Chức danh không được bỏ trống."),
  // maHopDong: yup
  //   .string()
  //   .nullable()
  //   .required("Lương cơ bản không được bỏ trống."),
  hopDongTuNgay: yup
    .date()
    .nullable()
    .required("Ngày hiệu lực không được bỏ trống"),
  hopDongDenNgay: yup
    .date()
    .nullable()
    .required("Ngày hết hạn không được bỏ trống"),
  idCre: yup.number(),
});
function AddContractForm(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  const { error, warn, info, success } = useToast();
  const ecode = query.get("maNhanVien");
  let { match, history } = props;
  let { id } = match.params;
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  console.log(id);

  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm hợp đồng mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [startDate, setStartDate] = useState();
  const [endDate, setEndDate] = useState();
  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  const [dataDetailHd, setdataDetailHd] = useState([]);
  const [dataHD, setDataHD] = useState([]);
  const [dataCD, setDataCD] = useState([]);
  const [dataAllHD, setDataAllHD] = useState([]);
  const [rsId, setRsId] = useState();
  const [rsIdCre, setRsIdCre] = useState();
  const [dataIdEmployee, setDataIdEmployee] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseDMHD = await ProductApi.getAllDMLHD();
        setDataHD(responseDMHD);
        const responseCD = await ProductApi.getAllDMCD();
        setDataCD(responseCD);
        const responseIdEmployee = await ProductApi.getAllNv();
        setDataIdEmployee(responseIdEmployee);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa hợp đồng");
          const responseHD = await ProductApi.getHdDetail(id);
          setdataDetailHd(responseHD);
          setStartDate(responseHD.hopDongTuNgay);
          // setEndDate(moment(responseHD.hopDongDenNgay));
          setStartDate(moment(responseHD.hopDongTuNgay));
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    const handleId = async () => {
      if (id === undefined) {
        const responseAllHD = await ProductApi.getAllHd();
        setDataAllHD(responseAllHD);
        const idCree =
          responseAllHD !== null ? responseAllHD[0].idCre : undefined;
        setRsIdCre(idCree + 1);
        const idIncre =
          responseAllHD !== null ? responseAllHD[0].id : undefined;
        console.log(idIncre);
        const increCode = Number(idIncre.slice(2)) + 1;
        const rsCode = "HD";
        if (increCode < 10) {
         // setRsId(rsCode.concat(`0${increCode}`));
          setValue("maHopDong",rsCode.concat(`0${increCode}`))
        } else if (increCode >= 10) {
          //setRsId(rsCode.concat(`${increCode}`));
          setValue("maHopDong",rsCode.concat(`${increCode}`))
        }        
      }
    };
    handleId();
  }, []);

  const [file, setFile] = useState({
    file: null,
    path: "/Images/userIcon.png",
  });
  const handleChange = (e) => {
    console.log(e);
    setFile({
      file: e.file,
      path:
        e.fileList.length !== 0
          ? URL.createObjectURL(e.file)
          : "/Images/userIcon.png",
      //file: e.target.files[0],
      //path: URL.createObjectURL(e.target.files[0]),
    });
  };

  // console.log(dataAllHD);
  const intitalValue = {
    maNhanVien: id !== undefined ? dataDetailHd.maNhanVien : ecode,
    idChucDanh: id !== undefined ? dataDetailHd.idChucDanh : null,
    idLoaiHopDong: id !== undefined ? dataDetailHd.idLoaiHopDong : null,
    hopDongTuNgay:
      id !== undefined
        ? moment(dataDetailHd.hopDongTuNgay)._d == "Invalid Date"
          ? dataDetailHd.hopDongTuNgay
          : moment(dataDetailHd.hopDongTuNgay)
        : dataDetailHd.hopDongTuNgay,
    hopDongDenNgay:
      id !== undefined
        ? moment(dataDetailHd.hopDongDenNgay)._d == "Invalid Date"
          ? dataDetailHd.hopDongDenNgay
          : moment(dataDetailHd.hopDongDenNgay)
        : dataDetailHd.hopDongDenNgay,
    ghiChu: id !== undefined ? dataDetailHd.ghiChu : null,
    maHopDong: id !== undefined ? dataDetailHd.id : rsId,
    trangThai: id !== undefined ? dataDetailHd.trangThai === "Kích hoạt" : true,
    idCre: id !== undefined ? dataDetailHd.idCre : rsIdCre,
  };

  const {
    register,
    handleSubmit,
    control,
    reset,
    getValues,
    setValue,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataDetailHd) {
      reset(intitalValue);
    }
  }, [dataDetailHd]);

  useEffect(() => {
    if (dataAllHD) {
      reset(intitalValue);
    }
  }, [dataAllHD]);
  const checkInputChange = () => {
    const values = getValues([
      "maNhanVien",
      "idChucDanh",
      "idLoaiHopDong",
      "hopDongTuNgay",
      "hopDongDenNgay",
      "ghiChu",
      "maHopDong",
      "trangThai",
    ]);
    const dfValue = [
      intitalValue.maNhanVien,
      intitalValue.idChucDanh,
      intitalValue.idLoaiHopDong,
      intitalValue.hopDongTuNgay,
      intitalValue.hopDongDenNgay,
      intitalValue.ghiChu,
      intitalValue.maHopDong,
      intitalValue.trangThai,
    ];
    return JSON.stringify(values) === JSON.stringify(dfValue);
  };

  const onHandleSubmit = async (data) => {
    console.log(data);

    let maHopDong = data.maHopDong;
    try {
      if (id !== undefined) {
        if (file.file !== null) {
          await DeleteApi.deleteAHD(data.maHopDong);
          const formData = new FormData();
          formData.append("bangChung", file.file);
          //formData.append("maHopDong", data.id);
          await PutApi.PutAHD(formData, data.maHopDong);
        }
        await PutApi.PutHD(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa thông tin hợp đồng ${maHopDong} của nhân viên ${dataDetailHd.tenNhanVien}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success(
          `Sửa thông tin hợp đồng cho nhân viên ${dataDetailHd.tenNhanVien} thành công`
        );
      } else {
        await ProductApi.postHD(data);
        if (file.file !== null) {
          const formData = new FormData();
          formData.append("bangChung", file.file);
          //formData.append("maHopDong", data.id);
          await PutApi.PutAHD(formData, data.maHopDong);
        }
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm hợp đồng mới ${maHopDong} cho nhân viên ${dataDetailHd.tenNhanVien}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success(
          `Thêm thông tin hợp đồng cho nhân viên ${dataDetailHd.tenNhanVien} thành công`
        );
      }
      history.goBack();
    } catch (errors) {
      console.log("errors", error);
      error(`Có lỗi xảy ra ${errors}`);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteHD(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa hợp đồng ${dataDetailHd.maHopDong} của nhân viên ${dataDetailHd.tenNhanVien}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success(
        `Xoá thông tin hợp đồng cho nhân viên ${dataDetailHd.tenNhanVien} thành công`
      );
      history.push(`/contract`);
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
              {dataDetailHd.length !== 0 ? "Sửa" : "Thêm"} hợp đồng
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailHd.length !== 0 ? "btn btn-danger" : "delete-button"
              }
              value="Xoá"
              onClick={() => {
                setShowDeleteDialog(true);
              }}
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
              value={dataDetailHd.length !== 0 ? "Sửa" : "Lưu"}
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
          <div className="container-div-form">
            <h3>Thông tin chung</h3>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="maNhanVien"
                  >
                    Mã nhân viên
                  </label>
                  <input
                    //type="text"
                    {...register("maNhanVien")}
                    id="maNhanVien"
                    className={
                      !errors.maNhanVien
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    list="employees"
                    readOnly={ecode ? true : false}
                  />
                  <datalist id="employees">
                    {dataIdEmployee
                      .filter(
                        (item) => item.trangThaiLaoDong === "Đang làm việc"
                      )
                      .map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.hoTen}
                        </option>
                      ))}
                  </datalist>

                  <span className="message">{errors.maNhanVien?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idChucDanh"
                  >
                    Chức danh công việc
                  </label>
                  <select
                    type="text"
                    {...register("idChucDanh")}
                    id="idChucDanh"
                    className={
                      !errors.idChucDanh
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value=""></option>
                    {dataCD.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenChucDanh}
                      </option>
                    ))}
                  </select>
                  <span className="message">{errors.idChucDanh?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline ">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idLoaiHopDong"
                  >
                    Loại hợp đồng
                  </label>
                  <select
                    type="text"
                    {...register("idLoaiHopDong")}
                    id="idLoaiHopDong"
                    className={
                      !errors.idLoaiHopDong
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value=""></option>
                    {dataHD.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenLoaiHopDong}
                      </option>
                    ))}
                  </select>
                  <span className="message">
                    {errors.idLoaiHopDong?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="maHopDong"
                  >
                    Mã hợp đồng
                  </label>
                  <input
                    type="text"
                    {...register("maHopDong")}
                    id="maHopDong"
                    //value={rsId}
                    className={
                      !errors.maHopDong
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    readOnly
                  />
                  <span className="message">{errors.maHopDong?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="hopDongTuNgay"
                  >
                    Ngày có hiệu lực
                  </label>
                  <Controller
                    name="hopDongTuNgay"
                    control={control}
                    render={({ field, onChange }) => (
                      <DatePicker
                        id="hopDongTuNgay"
                        className={
                          !errors.hopDongTuNgay
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger"
                        }
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        // allowClear={false}
                        //value={moment(field.value)}
                        // value={id!== undefined?moment(field.value):startDate}
                        value={field.value}
                        onChange={(event) => {
                          field.onChange(event);
                          //setStartDate(event)
                        }}
                        {...field._d}
                      />
                    )}
                  />
                  <span className="message">
                    {errors.hopDongTuNgay?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="ngayHetHanHopDong"
                  >
                    Ngày hết hạn
                  </label>
                  <Controller
                    name="hopDongDenNgay"
                    control={control}
                    render={({ field, onChange }) => (
                      <DatePicker
                        id="hopDongDenNgay"
                        className={
                          !errors.hopDongDenNgay
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger"
                        }
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        // value={moment(field.value)}
                        value={field.value}
                        //value={endDate}
                        onChange={(event) => {
                          field.onChange(event);
                        }}
                        {...field._d}
                      />
                    )}
                  />
                  <span className="message">
                    {errors.hopDongDenNgay?.message}
                  </span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="ghiChu"
                  >
                    Ghi chú
                  </label>
                  <input
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
                    Bằng chứng
                  </label>
                  <Upload beforeUpload={() => false} onChange={handleChange}>
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
                <input {...register("idCre")} type="text" value={rsIdCre} />
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
            ? "Bạn chưa thay đổi thông tin hợp đồng"
            : "Bạn chưa nhập thông tin hợp đồng"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin hợp đồng `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddContractForm;
