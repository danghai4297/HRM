import React, { useEffect, useState } from "react";
import "./ContractForm.scss";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import ProductApi from "../../../api/productApi";
import moment from "moment/moment.js";
import "antd/dist/antd.css";
import { DatePicker } from "antd";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import { useLocation } from "react-router";
import DialogCheck from "../../../components/Dialog/DialogCheck";
import Dialog from "../../../components/Dialog/Dialog";
import { useToast } from "../../../components/Toast/Toast";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import jwt_decode from "jwt-decode";
import { schema } from "../../../ultis/ContractValidation";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function AddContractForm(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  const { error, success } = useToast();
  const ecode = query.get("maNhanVien");
  let eName = query.get("hoTen");
  let { match, history } = props;
  let { id } = match.params;
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm hợp đồng mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showEsc, setShowEsc] = useState(false);
  const [startDate, setStartDate] = useState();
  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
    setShowEsc(false);
  };

  const [dataDetailHd, setdataDetailHd] = useState([]);
  const [dataHD, setDataHD] = useState([]);
  const [dataCV, setDataCV] = useState([]);
  const [dataCD, setDataCD] = useState([]);
  const [dataAllHD, setDataAllHD] = useState([]);
  const [rsId, setRsId] = useState();
  const [rsIdCre, setRsIdCre] = useState();
  const [dataIdEmployee, setDataIdEmployee] = useState([]);
  const [impID, setImpID] = useState();
  const [open, setOpen] = useState(false);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseDMHD = await ProductApi.getAllDMLHD();
        setDataHD(responseDMHD);
        const responseCV = await ProductApi.getAllDMCV();
        setDataCV(responseCV);
        const responseCD = await ProductApi.getAllDMCD();
        setDataCD(responseCD);
        const responseIdEmployee = await ProductApi.getAllNv();
        setDataIdEmployee(responseIdEmployee);
        if (id !== undefined) {
          try {
            setDescription("Bạn chắc chắn muốn sửa hợp đồng");
            const responseHD = await ProductApi.getHdDetail(id);
            setdataDetailHd(responseHD);
            setStartDate(responseHD.hopDongTuNgay);
            setStartDate(moment(responseHD.hopDongTuNgay));
            setGhiChu(responseHD.ghiChu);
          } catch (error) {
            history.goBack();
          }
        }
      } catch (errors) {
        error("Có lỗi xảy ra");
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailHd.length !== 0) {
        document.title = `Thay đổi thông tin hợp đồng của nhân viên ${dataDetailHd.tenNhanVien}`;
      } else if (id === undefined && eName) {
        document.title = `Tạo hợp đồng mới cho nhân viên ${eName}`;
      } else if (id === undefined) {
        document.title = `Tạo hợp đồng mới`;
      }
    };
    titlePage();
  }, [dataDetailHd]);

  useEffect(() => {
    const handleId = async () => {
      try {
        if (id === undefined) {
          const responseAllHD = await ProductApi.getAllHd();
          setDataAllHD(responseAllHD);
          const idCree =
            responseAllHD !== null ? responseAllHD[0].idCre : undefined;
          setRsIdCre(idCree + 1);
          const idIncre =
            responseAllHD !== null ? responseAllHD[0].id : undefined;
          const increCode = Number(idIncre.slice(2)) + 1;
          const rsCode = "HD";
          if (increCode < 10) {
            setValue("maHopDong", rsCode.concat(`0${increCode}`));
          } else if (increCode >= 10) {
            setValue("maHopDong", rsCode.concat(`${increCode}`));
          }
        }
      } catch (errors) {
        error("Có lỗi xảy ra");
      }
    };
    handleId();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataDetailHd, dataAllHD]);

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
    maNhanVien: id !== undefined ? dataDetailHd.maNhanVien : ecode,
    idChucDanh: id !== undefined ? dataDetailHd.idChucDanh : null,
    idChucVu: id !== undefined ? dataDetailHd.idChucVu : null,
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

  const [ghiChu, setGhiChu] = useState();

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
      "idChucVu",
      "idLoaiHopDong",
      "hopDongTuNgay",
      "hopDongDenNgay",
      "maHopDong",
      "trangThai",
    ]);
    const dfValue = [
      intitalValue.maNhanVien,
      intitalValue.idChucDanh,
      intitalValue.idChucVu,
      intitalValue.idLoaiHopDong,
      intitalValue.hopDongTuNgay,
      intitalValue.hopDongDenNgay,
      intitalValue.maHopDong,
      intitalValue.trangThai,
    ];
    if (
      JSON.stringify(values) === JSON.stringify(dfValue) &&
      file.file === null &&
      (ghiChu == intitalValue.ghiChu || ghiChu == undefined)
    ) {
      return true;
    }
    return false;
  };

  const onHandleSubmit = async (data) => {
    console.log(data);
    const nameEm = dataIdEmployee.filter((item) => item.id === data.maNhanVien);
    let maHopDong = data.maHopDong;
    try {
      if (id !== undefined) {
        try {
          if (
            dataIdEmployee
              .filter((item) => item.trangThaiLaoDong === "Đang làm việc")
              .map((item) => item.id)
              .includes(data.maNhanVien)
          ) {
            if (file.size < 20000000) {
              if (file.file !== null) {
                await DeleteApi.deleteAHD(data.maHopDong);
                const formData = new FormData();
                formData.append("bangChung", file.file);
                formData.append("tenFile", file.name);
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
              history.goBack();
            } else {
              error("Tệp đính kèm không thể quá 20M");
            }
          } else {
            error("Nhân viên đã nghỉ việc hoặc mã nhân viên không tồn tại.");
          }
        } catch (errors) {
          error("Không thể sửa thông tin hợp đồng.");
        }
      } else {
        try {
          if (
            dataIdEmployee
              .filter((item) => item.trangThaiLaoDong === "Đang làm việc")
              .map((item) => item.id)
              .includes(data.maNhanVien)
          ) {
            if (file.size < 20000000) {
              await ProductApi.postHD(data);
              if (file.file !== null) {
                const formData = new FormData();
                formData.append("bangChung", file.file);
                formData.append("tenFile", file.name);
                await PutApi.PutAHD(formData, data.maHopDong);
              }
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Thêm hợp đồng mới ${maHopDong} cho nhân viên ${nameEm[0].hoTen}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
              success(
                `Thêm hợp đồng mới ${maHopDong} cho nhân viên ${nameEm[0].hoTen} thành công`
              );
              history.goBack();
            } else {
              error("Tệp đính kèm không thể quá 20MB.");
            }
          } else {
            error("Nhân viên đã nghỉ việc hoặc mã nhân viên không tồn tại.");
          }
        } catch (errors) {
          error("Không thể thêm hợp đồng mới");
        }
      }
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
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
    } catch (errors) {
      error(`Có lỗi xảy ra`);
    }
  };
  return (
    <>
      <div className="container-form">
        <div className="Submit-button">
          <div>
            <h2 className="">
              {dataDetailHd.length !== 0 ? "Sửa" : "Thêm"} hợp đồng
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className="btn-secondary btn ml-3"
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
        <form action="" class="profile-form">
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
                    {...register("maNhanVien", {
                      onChange: (e) => setImpID(e.target.value),
                    })}
                    id="maNhanVien"
                    className={
                      !errors.maNhanVien
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    list="employees"
                    readOnly={ecode || id ? true : false}
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
                    htmlFor="idChucVu"
                  >
                    Chức vụ
                  </label>
                  <select
                    type="text"
                    {...register("idChucVu")}
                    id="idChucVu"
                    className={
                      !errors.idChucVu
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value=""></option>
                    {dataCV.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenChucVu}
                      </option>
                    ))}
                  </select>
                  <span className="message">{errors.idChucVu?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline ">
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
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idChucDanh"
                  >
                    Chức danh
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
                    htmlFor="ghiChu"
                  >
                    Ghi chú
                  </label>
                  <input
                    type="text"
                    {...register("ghiChu", {
                      onChange: (e) => setGhiChu(e.target.value),
                    })}
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
                        value={field.value}
                        onChange={(event) => {
                          field.onChange(event);
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
                <div class="form-group form-inline">
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
                        value={field.value}
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
                <input
                  style={{ display: "none" }}
                  {...register("idCre")}
                  type="text"
                  value={rsIdCre}
                />
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

export default AddContractForm;
