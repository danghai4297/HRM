import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import { useLocation } from "react-router";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
//import { DatePicker } from "antd";
import DialogCheck from "../../../components/Dialog/DialogCheck";
import { useToast } from "../../../components/Toast/Toast";
import Dialog from "../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import { schema } from "../../../ultis/RewardAndDisciplineValidation";
import "./DisciplineForm.scss";
function AddDisciplineForm(props) {
  const { error, warn, info, success } = useToast();

  // const { objectData } = props;
  let { match, history } = props;
  let { id } = match.params;
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  let eName = query.get("hoTen");
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const eCode = query.get("maNhanVien");

  const [dataKLDetail, setDataKLDetail] = useState([]);
  const [dataKL, setDataKL] = useState([]);
  console.log(id);
  const [dataEmployee, setDataEmployee] = useState([]);
  const [dataDetailNN, setdataDetailNN] = useState([]);
  const [dataNN, setDataNN] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin kỷ luật mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showEsc, setShowEsc] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
    setShowEsc(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMKL();
        setDataKL(response);
        const responeseEm = await ProductApi.getAllNv();
        setDataEmployee(responeseEm);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin kỷ luật");
          const responseKT = await ProductApi.getKTvKLDetail(id);
          setDataKLDetail(responseKT);
        }
      } catch (error) {
        error("Có lỗi xảy ra.");
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataKLDetail.length !== 0) {
        document.title = `Thay đổi thông tin kỷ luật của nhân viên ${dataKLDetail.hoTen}`;
      } else if (id === undefined && eName) {
        document.title = `Tạo kỷ luật cho nhân viên ${eName}`;
      } else if (id === undefined) {
        document.title = `Tạo kỷ luật`;
      }
    };
    titlePage();
  }, [dataKLDetail]);

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
    maNhanVien: id !== undefined ? dataKLDetail.maNhanVien : eCode,
    idDanhMucKhenThuong:
      id !== undefined ? dataKLDetail.idDanhMucKhenThuong : null,
    noiDung: id !== undefined ? dataKLDetail.noiDung : null,
    lyDo: id !== undefined ? dataKLDetail.lyDo : null,
    anh: id !== undefined ? dataKLDetail.anh : null,
    loai: false,
  };

  const {
    register,
    handleSubmit,
    control,
    getValues,
    reset,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataKLDetail) {
      reset(intitalValue);
    }
  }, [dataKLDetail]);

  const checkInputChange = () => {
    const values = getValues([
      "maNhanVien",
      "idDanhMucKhenThuong",
      "noiDung",
      "lyDo",
      "anh",
      "loai",
    ]);
    const dfValue = [
      intitalValue.maNhanVien,
      intitalValue.idDanhMucKhenThuong,
      intitalValue.noiDung,
      intitalValue.lyDo,
      intitalValue.anh,
      intitalValue.loai,
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

  const onHandleSubmit = async (data) => {
    const nameEm = dataEmployee.filter((item) => item.id === data.maNhanVien);
    console.log(data);
    try {
      if (id !== undefined) {
        try {
          if (
            dataEmployee
              .filter((item) => item.trangThaiLaoDong === "Đang làm việc")
              .map((item) => item.id)
              .includes(data.maNhanVien)
          ) {
            if (file.size < 20000000) {
              const formData = new FormData();
              formData.append("bangChung", file.file);
              formData.append("idDanhMucKhenThuong", data.idDanhMucKhenThuong);
              formData.append("noiDung", data.noiDung);
              formData.append("lyDo", data.lyDo);
              formData.append("loai", data.loai);
              formData.append("maNhanVien", data.maNhanVien);
              await PutApi.PutKTvKL(formData, id);
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Sửa thông tin kỷ luật của nhân viên ${dataKLDetail.hoTen}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
              success(
                `Sửa thông tin kỷ luật cho nhân viên ${dataKLDetail.hoTen} thành công`
              );
              history.goBack();
            } else {
              error("Tệp đính kèm không được quá 20MB.");
            }
          } else {
            error("Nhân viên đã nghỉ việc hoặc mã nhân viên không tồn tại.");
          }
        } catch (errors) {
          error(`Sửa thông tin kỷ luật thất bại.`);
        }
      } else {
        try {
          if (
            dataEmployee
              .filter((item) => item.trangThaiLaoDong === "Đang làm việc")
              .map((item) => item.id)
              .includes(data.maNhanVien)
          ) {
            if (file.size < 20000000) {
              const formData = new FormData();
              formData.append("bangChung", file.file);
              formData.append("idDanhMucKhenThuong", data.idDanhMucKhenThuong);
              formData.append("noiDung", data.noiDung);
              formData.append("lyDo", data.lyDo);
              formData.append("loai", data.loai);
              formData.append("maNhanVien", data.maNhanVien);
              await ProductApi.PostKTvKL(formData);
              await ProductApi.PostLS({
                tenTaiKhoan: decoded.userName,
                thaoTac: `Thêm kỷ luật mới cho nhân viên ${nameEm[0].hoTen}`,
                maNhanVien: decoded.id,
                tenNhanVien: decoded.givenName,
              });
              success(
                `Thêm thông tin kỷ luật cho nhân viên ${nameEm[0].hoTen} thành công`
              );
              history.goBack();
            } else {
              error("Tệp đính kèm không được quá 20MB.");
            }
          } else {
            error("Nhân viên đã nghỉ việc hoặc mã nhân viên không tồn tại.");
          }
        } catch (errors) {
          error("Thêm thông tin kỷ luật thất bại.");
        }
      }
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteKTvKL(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa kỷ luật của nhân viên ${dataKLDetail.hoTen}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success(
        `Xoá thông tin kỷ luật cho nhân viên ${dataKLDetail.hoTen} thành công`
      );
      history.push(`/reward`);
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
              {dataKLDetail.length !== 0 ? "Sửa" : "Thêm"} thủ tục kỷ luật
            </h2>
          </div>
          <div className="button">
            {/* <input
              type="submit"
              className={
                dataKLDetail.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataKLDetail.length !== 0 ? "Sửa" : "Lưu"}
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
            <div className="container-salary">
              <div>
                <h3>Thông tin kỷ luật</h3>
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
                    readOnly={eCode ? true : false}
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
              <div className="col-6">
                <div class="form-group form-inline ">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idDanhMucKhenThuong"
                  >
                    Loại kỷ luật
                  </label>
                  <select
                    type="text"
                    {...register("idDanhMucKhenThuong")}
                    id="idDanhMucKhenThuong"
                    className={
                      !errors.idDanhMucKhenThuong
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value=""></option>
                    {dataKL.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenDanhMuc}
                      </option>
                    ))}
                  </select>
                  <span className="message">
                    {errors.idDanhMucKhenThuong?.message}
                  </span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="noiDung"
                  >
                    Nội dung
                  </label>
                  <textarea
                    type="text"
                    rows="4"
                    {...register("noiDung")}
                    id="noiDung"
                    className={
                      !errors.noiDung
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.noiDung?.message}</span>
                </div>
              </div>
              <div className="col">
                <div class="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="lyDo">
                    Lý do
                  </label>
                  <textarea
                    type="text"
                    rows="4"
                    {...register("lyDo")}
                    id="lyDo"
                    className={
                      !errors.lyDo
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.lyDo?.message}</span>
                </div>
              </div>
            </div>
            <input
              type="text"
              {...register("loai")}
              //defaultValue={true}
              style={{ display: "none" }}
            />
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
            ? "Bạn chưa thay đổi thông tin kỷ luật"
            : "Bạn chưa nhập thông tin kỷ luật"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin kỷ luật`}
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

export default AddDisciplineForm;
