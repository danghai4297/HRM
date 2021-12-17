import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./TransferForm.scss";
import ProductApi from "../../../api/productApi";
import { useLocation } from "react-router";
import moment from "moment/moment.js";
import "antd/dist/antd.css";
import { DatePicker } from "antd";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import DialogCheck from "../../../components/Dialog/DialogCheck";
import { useToast } from "../../../components/Toast/Toast";
import Dialog from "../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import { schema } from "../../../ultis/TransferValidation";

function AddTransferForm(props) {
  const { error, warn, info, success } = useToast();

  let location = useLocation();
  let query = new URLSearchParams(location.search);
  let eName = query.get("hoTen");
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const eCode = query.get("maNhanVien");
  // const onHandleSubmit = (data) => {
  //   console.log(data);
  //   JSON.stringify(data);
  // };

  //get param from detail
  let { match, history } = props;
  let { id } = match.params;
  console.log(id);

  // states contain data
  const [startDate, setStartDate] = useState();
  const [dataDetailDC, setDataDetailDC] = useState([]);
  const [dataNest, setDataNest] = useState([]);
  const [dataDepartment, setDataDepartment] = useState([]);
  const [dataPosition, setDataPosition] = useState([]);
  const [nest, setNest] = useState();
  const [dataEmployee, setDataEmployee] = useState([]);

  const [dataDetailNN, setdataDetailNN] = useState([]);
  const [dataNN, setDataNN] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin công tác mới"
  );

  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showEsc, setShowEsc] = useState(false);

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
        const responseNest = await ProductApi.getAllDMT();
        setDataNest(responseNest);
        const responseDepartment = await ProductApi.getAllDMPB();
        setDataDepartment(responseDepartment);
        const responsePosition = await ProductApi.getAllDMCV();
        setDataPosition(responsePosition);
        const responeseEm = await ProductApi.getAllNv();
        setDataEmployee(responeseEm);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin công tác");
          const response = await ProductApi.getDCDetail(id);
          setDataDetailDC(response);
          setNest(response.idPhongBan);
          setStartDate(moment(response.ngayHieuLuc));
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
      if (dataDetailDC.length !== 0) {
        document.title = `Thay đổi thông tin vị trí công tác của nhân viên ${dataDetailDC.tenNhanVien}`;
      } else if (id === undefined && eName) {
        document.title = `Thủ tục công tác cho nhân viên ${eName}`;
      } else if (id === undefined) {
        document.title = `Thủ tục công tác`;
      }
    };
    titlePage();
  }, [dataDetailDC]);

  const [file, setFile] = useState({
    file: null,
    path: "/Images/userIcon.png",
    size: null,
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
      size: e.fileList.length !== 0 ? e.file.size : null,
    });
  };

  const intitalValue = {
    ngayHieuLuc:
      id !== undefined
        ? moment(dataDetailDC.ngayHieuLuc)._d == "Invalid Date"
          ? dataDetailDC.ngayHieuLuc
          : moment(dataDetailDC.ngayHieuLuc)
        : dataDetailDC.ngayHieuLuc,
    idPhongBan: id !== undefined ? dataDetailDC.idPhongBan : null,
    to: id !== undefined ? dataDetailDC.idTo : null,
    chiTiet: id !== undefined ? dataDetailDC.chiTiet : null,
    trangThai:
      id !== undefined
        ? dataDetailDC.trangThai === "Kích hoạt"
          ? true
          : false
        : true,
    maNhanVien: id !== undefined ? dataDetailDC.maNhanVien : eCode,
    //idChucVu: id !== undefined ? dataDetailDC.idChucVu : null,
  };
  //define method of react-hooks-form
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
    if (dataDetailDC) {
      reset(intitalValue);
    }
  }, [dataDetailDC]);

  const checkInputChange = () => {
    const values = getValues([
      "ngayHieuLuc",
      "idPhongBan",
      "to",
      "chiTiet",
      "trangThai",
      "maNhanVien",
    ]);
    const dfValue = [
      intitalValue.ngayHieuLuc,
      intitalValue.idPhongBan,
      intitalValue.to,
      intitalValue.chiTiet,
      intitalValue.trangThai,
      intitalValue.maNhanVien,
    ];
    //return JSON.stringify(values) === JSON.stringify(dfValue);
    if (
      JSON.stringify(values) === JSON.stringify(dfValue) &&
      file.file === null
    ) {
      return true;
    }
    return false;
  };
  //method handle submit
  const onHandleSubmit = async (data) => {
    const nameEm = dataEmployee.filter((item) => item.id === data.maNhanVien);
    console.log(data);

    try {
      if (id !== undefined) {
        if (
          dataEmployee
            .filter((item) => item.trangThaiLaoDong === "Đang làm việc")
            .map((item) => item.id)
            .includes(data.maNhanVien)
        ) {
          try {
            if (file.size < 20000000) {
              const formData = new FormData();
              formData.append("bangChung", file.file);
              formData.append("ngayHieuLuc", startDate.format("MM/DD/YYYY"));
              formData.append("idPhongBan", data.idPhongBan);
              formData.append("to", data.to);
              formData.append("chiTiet", data.chiTiet);
              formData.append("trangThai", data.trangThai);
              formData.append("maNhanVien", data.maNhanVien);
              await PutApi.PutDC(formData, id);
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Sửa thông tin công tác của nhân viên ${dataDetailDC.tenNhanVien}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
              success(
                `Sửa thông tin công tác cho nhân viên ${dataDetailDC.tenNhanVien} thành công`
              );
              history.goBack();
            } else {
              error("Tệp đính kèm không được quá 20MB.");
            }
          } catch (errors) {
            errors("Không thể sửa thông tin công tác");
          }
        } else {
          error("Nhân viên đã nghỉ việc hoặc mã nhân viên không tồn tại.");
        }
      } else {
        if (
          dataEmployee
            .filter((item) => item.trangThaiLaoDong === "Đang làm việc")
            .map((item) => item.id)
            .includes(data.maNhanVien)
        ) {
          try {
            if (file.size < 20000000) {
              const formData = new FormData();
              formData.append("bangChung", file.file);
              formData.append("ngayHieuLuc", startDate.format("MM/DD/YYYY"));
              formData.append("idPhongBan", data.idPhongBan);
              formData.append("to", data.to);
              formData.append("chiTiet", data.chiTiet);
              formData.append("trangThai", data.trangThai);
              formData.append("maNhanVien", data.maNhanVien);
              await ProductApi.PostDC(formData);
              history.goBack();
              success(
                `Thêm thông tin công tác cho nhân viên ${nameEm[0].hoTen} thành công`
              );
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Thêm công tác mới cho nhân viên ${nameEm[0].hoTen}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
            } else {
              error("Tệp đính kèm không được quá 20MB.");
            }
          } catch (errors) {
            errors("Không thể thêm thông tin công tác");
          }
        } else {
          error("Nhân viên đã nghỉ việc hoặc mã nhân viên không tồn tại.");
        }
      }
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
    }
  };
  console.log(dataDetailDC);
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDC(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa thông tin công tác của nhân viên ${dataDetailDC.tenNhanVien}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success(
        `Xoá thông tin công tác cho nhân viên ${dataDetailDC.tenNhanVien} thành công`
      );
      history.push(`/transfer`);
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
    }
  };
  const handleChangeNest = (e) => {
    setNest(e.target.value);
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button">
          <div>
            <h2 className="">
              {dataDetailDC.length !== 0 ? "Sửa" : "Thêm"} thủ tục công tác
            </h2>
          </div>
          <div className="button">
            {/* <input
              type="submit"
              className={
                dataDetailDC.length !== 0 ? "btn btn-danger" : "delete-button"
              }
              value="Xoá"
              onClick={() => {
                setShowDeleteDialog(true);
              }}
            /> */}
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
              value={dataDetailDC.length !== 0 ? "Sửa" : "Lưu"}
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
            <div className="container-salary">
              <div>
                <h3>Thông tin công tác</h3>
              </div>
            </div>
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
                    type="text"
                    {...register("maNhanVien")}
                    id="maNhanVien"
                    className={
                      !errors.maNhanVien
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    list="employeeCode"
                    readOnly={eCode || id ? true : false}
                  />
                  <datalist id="employeeCode">
                    {dataEmployee
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
              <div className="col">
                <div class="form-group form-inline ">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idPhongBan"
                  >
                    Phòng ban
                  </label>
                  <select
                    type="text"
                    {...register("idPhongBan", {
                      onChange: (e) => handleChangeNest(e),
                    })}
                    id="idPhongBan"
                    //  onChange={(e) => setNest(e.target.value)}
                    className={
                      !errors.idPhongBan
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value=""></option>
                    {dataDepartment.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenPhongBan}
                      </option>
                    ))}
                  </select>
                  <span className="message">{errors.idPhongBan?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="ngayHieuLuc"
                  >
                    Ngày hiệu lực
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
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="to">
                    Tổ
                  </label>
                  <select
                    type="text"
                    {...register("to")}
                    id="to"
                    className={
                      !errors.to
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value=""></option>
                    {dataNest
                      .filter((item) => item.idPhongBan == nest)
                      .map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenTo}
                        </option>
                      ))}
                  </select>
                  <span className="message">{errors.to?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="chiTiet"
                  >
                    Chi tiết
                  </label>
                  <textarea
                    type="text"
                    rows="1"
                    {...register("chiTiet")}
                    id="chiTiet"
                    className={
                      !errors.chiTiet
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.chiTiet?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="trangThai"
                    style={id !== undefined ? null : { display: "none" }}
                  >
                    Trạng thái
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
            ? "Bạn chưa thay đổi thông tincông tác"
            : "Bạn chưa nhập thông tincông tác"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tincông tác`}
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
    </>
  );
}

export default AddTransferForm;
