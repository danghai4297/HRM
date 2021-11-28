import React, { useState, useEffect } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { DatePicker } from "antd";
import { useLocation } from "react-router";
import ProductApi from "../../api/productApi";
import PutApi from "../../api/putAAPI";
import DeleteApi from "../../../src/api/deleteAPI";
import DialogCheck from "../Dialog/DialogCheck";
import { useToast } from "../Toast/Toast";
import Dialog from "../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
const schema = yup.object({
  idDanhMucKhenThuong: yup
    .number()
    .nullable()
    .required("Loại khen thưởng không được bỏ trống."),
  maNhanVien: yup
    .string()
    .matches(notAllowNull, "Mã nhân viên không được là khoảng trống.")
    .nullable()
    .required("Mã nhân viên không được bỏ trống."),
  //thoiGian: yup.string().required("Thời gian không được bỏ trống."),
  noiDung: yup.string().matches(notAllowNull, "Nội dung không được là khoảng trống.").nullable().required("Nội dung không được bỏ trống."),
  lyDo: yup.string().matches(notAllowNull, "Lý do không được là khoảng trống.").nullable().required("Lý do không được bỏ trống."),
  loai: yup.boolean(),
});
function AddRewardForm(props) {
  const { error, warn, info, success } = useToast();

  let { match, history } = props;
  let { id } = match.params;
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataKTDetail, setDataKTDetail] = useState([]);
  const [dataKT, setDataKT] = useState([]);
  const [dataEmployee, setDataEmployee] = useState([]);

  const [dataDetailNN, setdataDetailNN] = useState([]);
  const [dataNN, setDataNN] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin khen thưởng mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMKT();
        setDataKT(response);
        const responeseEm = await ProductApi.getAllNv();
        setDataEmployee(responeseEm);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin khen thưởng");
          const responseKT = await ProductApi.getKTvKLDetail(id);
          setDataKTDetail(responseKT);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

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
    maNhanVien: id !== undefined ? dataKTDetail.maNhanVien : null,
    idDanhMucKhenThuong:
      id !== undefined ? dataKTDetail.idDanhMucKhenThuong : null,
    noiDung: id !== undefined ? dataKTDetail.noiDung : null,
    lyDo: id !== undefined ? dataKTDetail.lyDo : null,
    // anh: id !== undefined ? dataKTDetail.anh : null,
    loai: true,
  };

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataKTDetail) {
      reset(intitalValue);
    }
  }, [dataKTDetail]);

  const checkInputChange = () => {
    const values = getValues([
      "maNhanVien",
      "idDanhMucKhenThuong",
      "noiDung",
      "lyDo",
      // "anh",
      "loai",
    ]);
    const dfValue = [
      intitalValue.maNhanVien,
      intitalValue.idDanhMucKhenThuong,
      intitalValue.noiDung,
      intitalValue.lyDo,
      // intitalValue.anh,
      intitalValue.loai,
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

  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if (id !== undefined) {
       try {
        const formData = new FormData();
        formData.append("bangChung", file.file);
        formData.append("idDanhMucKhenThuong", data.idDanhMucKhenThuong);
        formData.append("noiDung", data.noiDung);
        formData.append("lyDo", data.lyDo);
        formData.append("loai", data.loai);
        formData.append("maNhanVien", data.maNhanVien);
        await PutApi.PutKTvKL(formData, id);
       } catch (errors) {
        error(`Lỗi${errors}`);
       }
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa thông tin khen thưởng của nhân viên ${dataKTDetail.hoTen}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success(
          `Sửa thông tin khen thưởng cho nhân viên ${dataKTDetail.hoTen} thành công`
        );
      } else {
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
          thaoTac: `Thêm khen thưởng mới cho nhân viên ${dataKTDetail.hoTen}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success(
          `thêm thông tin khen thưởng cho nhân viên ${dataKTDetail.hoTen} thành công`
        );
      }
      history.goBack();
    } catch (errors) {
      console.log("errors", errors);
      error(`Có lỗi xảy ra ${errors}`);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteKTvKL(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa khen thưởng của nhân viên ${dataKTDetail.hoTen}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      history.push(`/reward`);
      success(
        `Xoá thông tin khen thưởng cho nhân viên ${dataKTDetail.hoTen} thành công`
      );
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };
  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataKTDetail.length !== 0 ? "Sửa" : "Thêm"} thủ tục khen thưởng
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataKTDetail.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataKTDetail.length !== 0 ? "Sửa" : "Lưu"}
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
                <h3>Thông tin khen thưởng</h3>
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
                    //accept=".docx,.xlsx,.pdf"
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
                    Loại khen thưởng
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
                    {dataKT.map((item, key) => (
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
            ? "Bạn chưa thay đổi thông tin khen thưởng"
            : "Bạn chưa nhập thông tin khen thưởng"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin khen thưởng `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddRewardForm;
