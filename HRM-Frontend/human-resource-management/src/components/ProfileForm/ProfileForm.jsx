import React from "react";
import "./ProfileForm.scss";
import { Controller, useForm } from "react-hook-form";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "../FontAwesomeIcons/index";
import { useState, useEffect } from "react";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
import "antd/dist/antd.css";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import ProductApi from "../../api/productApi";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import PutApi from "../../api/putAAPI";
import DeleteApi from "../../api/deleteAPI";
import DialogCheck from "../Dialog/DialogCheck";
import Dialog from "../Dialog/Dialog";
import { useToast } from "../Toast/Toast";
import jwt_decode from "jwt-decode";
import { schema } from "../../ultis/ProfileValidation";

function AddProfileForm(props) {
  const { error, warn, info, success } = useToast();
  const { match, history } = props;
  let { id } = match.params;
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  //handle checkbox
  const [checkedSoldier, setCheckedSoldier] = useState(false);
  const handleClick = () => setCheckedSoldier(!checkedSoldier);
  const [checkedParty, setChekedParty] = useState(false);
  const handleClickParty = () => setChekedParty(!checkedParty);
  const [veterans, setVeterans] = useState(false);
  const handleClickVeteransy = () => setVeterans(!veterans);
  const [policy, setPolicy] = useState(false);
  const handleClickPolicy = () => setPolicy(!policy);
  const [resignation, setResignation] = useState(false);
  const handleResignation = (e) => {
    console.log(e.target.value);

    if (e.target.value == "false") {
      setResignation(!resignation);
    } else {
      setResignation(false);
    }
  };

  const [endDate, setEndDate] = useState();

  //const [date, setDate] = useState(new Date());
  //State contain category
  const [dataDetailEmployee, setDataDetailEmployee] = useState([]);
  const [dataMarrige, setDataMarrige] = useState([]);
  const [dataNation, setDataNation] = useState([]);
  const [dataReligion, setDataReligion] = useState([]);
  const [dataCRS, setDataCRS] = useState([]);
  const [dataLabor, setDataLabor] = useState([]);
  const [emCode, setEmCode] = useState("");
  const [allIdEm, setAllIdEm] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin nhân viên mới."
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  //const idCode = "NV0001";
  const [rsId, setRsId] = useState();
  //console.log(Number(idCode.slice(2))+1);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseM = await ProductApi.getAllDMHN();
        setDataMarrige(responseM);
        const responseDT = await ProductApi.getAllDMDT();
        setDataNation(responseDT);
        const responseTG = await ProductApi.getAllDMTG();
        setDataReligion(responseTG);
        const responseCRS = await ProductApi.getAllDMNCC();
        setDataCRS(responseCRS);
        const responseCV = await ProductApi.getAllDMTCLD();
        setDataLabor(responseCV);

        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa thông tin nhân viên");
          const response = await ProductApi.getNvDetail(id);
          setDataDetailEmployee(response);
          if (response.vaoDang !== "Không") {
            setChekedParty(true);
          }
          if (response.quanNhan !== "không") {
            setCheckedSoldier(true);
          }
          if (response.laConChinhSach == true) {
            setPolicy(true);
          }
          if (response.laThuongBinh == true) {
            setVeterans(true);
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
      if (dataDetailEmployee.length !== 0) {
        document.title = `Thay đổi hồ sơ nhân viên ${dataDetailEmployee.hoTen}`;
      } else if (id === undefined) {
        document.title = `Tạo hồ sơ nhân viên`;
      }
    };
    titlePage();
  }, [dataDetailEmployee]);

  useEffect(() => {
    const handleId = async () => {
      const responseAllId = await ProductApi.getAllNv();
      setAllIdEm(responseAllId);
      const idIncre =
        responseAllId !== null
          ? responseAllId[responseAllId.length - 1].id
          : undefined;
      console.log(idIncre);
      const increCode = Number(idIncre.slice(2)) + 1;
      const rsCode = "NV";
      if (increCode < 10) {
        setRsId(rsCode.concat(`000${increCode}`));
      } else if (increCode >= 10 && increCode < 100) {
        setRsId(rsCode.concat(`00${increCode}`));
      } else if (increCode >= 100 && increCode < 1000) {
        setRsId(rsCode.concat(`0${increCode}`));
      } else {
        setRsId(rsCode.concat(`${increCode}`));
      }
    };
    handleId();
  }, []);

  const intitalValue = {
    id: id !== undefined ? dataDetailEmployee.id : rsId,
    hoTen: id !== undefined ? dataDetailEmployee.hoTen : null,
    gioiTinh:
      id !== undefined
        ? dataDetailEmployee.gioiTinh == "Nam"
          ? true
          : false
        : true,
    ngaySinh:
      id !== undefined
        ? moment(dataDetailEmployee.ngaySinh)._d == "Invalid Date"
          ? dataDetailEmployee.ngaySinh
          : moment(dataDetailEmployee.ngaySinh)
        : dataDetailEmployee.ngaySinh,
    noiSinh: id !== undefined ? dataDetailEmployee.noiSinh : null,
    queQuan: id !== undefined ? dataDetailEmployee.queQuan : null,
    thuongTru: id !== undefined ? dataDetailEmployee.thuongTru : null,
    tamTru: id !== undefined ? dataDetailEmployee.tamTru : null,
    atm: id !== undefined ? dataDetailEmployee.atm : null,
    nganHang: id !== undefined ? dataDetailEmployee.nganHang : null,
    idDanhMucHonNhan: id !== undefined ? dataDetailEmployee.idHonNhan : null,
    quocTich: id !== undefined ? dataDetailEmployee.quocTich : null,
    dienThoai: id !== undefined ? dataDetailEmployee.dienThoai : null,
    dienThoaiKhac: id !== undefined ? dataDetailEmployee.dienThoaiKhac : null,
    diDong: id !== undefined ? dataDetailEmployee.diDong : null,
    email: id !== undefined ? dataDetailEmployee.email : null,
    facebook: id !== undefined ? dataDetailEmployee.facebook : null,
    skype: id !== undefined ? dataDetailEmployee.skype : null,
    maSoThue: id !== undefined ? dataDetailEmployee.maSoThue : null,
    cccd: id !== undefined ? dataDetailEmployee.cccd : null,
    noiCapCCCD: id !== undefined ? dataDetailEmployee.noiCapCCCD : null,
    ngayCapCCCD:
      id !== undefined
        ? moment(dataDetailEmployee.ngayCapCCCD)._d == "Invalid Date"
          ? dataDetailEmployee.ngayCapCCCD
          : moment(dataDetailEmployee.ngayCapCCCD)
        : dataDetailEmployee.ngayCapCCCD,
    ngayHetHanCCCD:
      id !== undefined
        ? moment(dataDetailEmployee.ngayHetHanCCCD)._d == "Invalid Date"
          ? dataDetailEmployee.ngayHetHanCCCD
          : moment(dataDetailEmployee.ngayHetHanCCCD)
        : dataDetailEmployee.ngayHetHanCCCD,
    hoChieu: id !== undefined ? dataDetailEmployee.hoChieu : null,
    noiCapHoChieu: id !== undefined ? dataDetailEmployee.noiCapHoChieu : null,
    ngayCapHoChieu:
      id !== undefined
        ? moment(dataDetailEmployee.ngayCapHoChieu)._d == "Invalid Date"
          ? dataDetailEmployee.ngayCapHoChieu
          : moment(dataDetailEmployee.ngayCapHoChieu)
        : dataDetailEmployee.ngayCapHoChieu,
    ngayHetHanHoChieu:
      id !== undefined
        ? moment(dataDetailEmployee.ngayHetHanHoChieu)._d == "Invalid Date"
          ? dataDetailEmployee.ngayHetHanHoChieu
          : moment(dataDetailEmployee.ngayHetHanHoChieu)
        : dataDetailEmployee.ngayHetHanHoChieu,
    ngheNghiep: id !== undefined ? dataDetailEmployee.ngheNghiep : null,
    chucVuHienTai: id !== undefined ? dataDetailEmployee.chucVuHienTai : null,
    ngayTuyenDung:
      id !== undefined
        ? moment(dataDetailEmployee.ngayTuyenDung)._d == "Invalid Date"
          ? dataDetailEmployee.ngayTuyenDung
          : moment(dataDetailEmployee.ngayTuyenDung)
        : dataDetailEmployee.ngayTuyenDung,
    ngayThuViec:
      id !== undefined
        ? moment(dataDetailEmployee.ngayThuViec)._d == "Invalid Date"
          ? dataDetailEmployee.ngayThuViec
          : moment(dataDetailEmployee.ngayThuViec)
        : dataDetailEmployee.ngayThuViec,
    congViecChinh: id !== undefined ? dataDetailEmployee.congViecChinh : null,
    ngayVaoBan:
      id !== undefined
        ? moment(dataDetailEmployee.ngayVaoBan)._d == "Invalid Date"
          ? dataDetailEmployee.ngayVaoBan
          : moment(dataDetailEmployee.ngayVaoBan)
        : dataDetailEmployee.ngayVaoBan,
    ngayChinhThuc:
      id !== undefined
        ? moment(dataDetailEmployee.ngayChinhThuc)._d == "Invalid Date"
          ? dataDetailEmployee.ngayChinhThuc
          : moment(dataDetailEmployee.ngayChinhThuc)
        : dataDetailEmployee.ngayChinhThuc,
    coQuanTuyenDung:
      id !== undefined ? dataDetailEmployee.coQuanTuyenDung : null,
    ngachCongChucNoiDung:
      id !== undefined ? dataDetailEmployee.ngachCongChucNoiDung : null,
    vaoDang:
      id !== undefined
        ? dataDetailEmployee.vaoDang === "Không"
          ? false
          : true
        : false,
    ngayVaoDang:
      id !== undefined
        ? moment(dataDetailEmployee.ngayVaoDang)._d == "Invalid Date"
          ? dataDetailEmployee.ngayVaoDang
          : moment(dataDetailEmployee.ngayVaoDang)
        : dataDetailEmployee.ngayVaoDang,
    ngayVaoDangChinhThuc:
      id !== undefined
        ? moment(dataDetailEmployee.ngayVaoDangChinhThuc)._d == "Invalid Date"
          ? dataDetailEmployee.ngayVaoDangChinhThuc
          : moment(dataDetailEmployee.ngayVaoDangChinhThuc)
        : dataDetailEmployee.ngayVaoDangChinhThuc,
    quanNhan:
      id !== undefined
        ? dataDetailEmployee.quanNhan === "Không"
          ? false
          : true
        : false,
    ngayNhapNgu:
      id !== undefined
        ? moment(dataDetailEmployee.ngayNhapNgu)._d == "Invalid Date"
          ? dataDetailEmployee.ngayNhapNgu
          : moment(dataDetailEmployee.ngayNhapNgu)
        : dataDetailEmployee.ngayNhapNgu,
    ngayXuatNgu:
      id !== undefined
        ? moment(dataDetailEmployee.ngayXuatNgu)._d == "Invalid Date"
          ? dataDetailEmployee.ngayXuatNgu
          : moment(dataDetailEmployee.ngayXuatNgu)
        : dataDetailEmployee.ngayXuatNgu,
    quanHamCaoNhat: id !== undefined ? dataDetailEmployee.quanHamCaoNhat : null,
    danhHieuCaoNhat:
      id !== undefined ? dataDetailEmployee.danhHieuCaoNhat : null,
    ngayVaoDoan:
      id !== undefined
        ? moment(dataDetailEmployee.ngayVaoDoan)._d == "Invalid Date"
          ? dataDetailEmployee.ngayVaoDoan
          : moment(dataDetailEmployee.ngayVaoDoan)
        : dataDetailEmployee.ngayVaoDoan,
    noiThamGia: id !== undefined ? dataDetailEmployee.noiThamGia : null,
    laThuongBinh: id !== undefined ? dataDetailEmployee.laThuongBinh : false,
    laConChinhSach:
      id !== undefined ? dataDetailEmployee.laConChinhSach : false,
    thuongBinh: id !== undefined ? dataDetailEmployee.thuongBinh : null,
    conChinhSach: id !== undefined ? dataDetailEmployee.conChinhSach : null,
    bhxh: id !== undefined ? dataDetailEmployee.bhxh : null,
    bhyt: id !== undefined ? dataDetailEmployee.bhyt : null,
    trangThaiLaoDong:
      id !== undefined
        ? dataDetailEmployee.trangThaiLaoDong == "Đang làm việc"
          ? true
          : false
        : true,
    ngayNghiViec:
      id !== undefined
        ? moment(dataDetailEmployee.ngayNghiViec)._d == "Invalid Date"
          ? dataDetailEmployee.ngayNghiViec
          : moment(dataDetailEmployee.ngayNghiViec)
        : dataDetailEmployee.ngayNghiViec,
    lyDoNghiViec: id !== undefined ? dataDetailEmployee.lyDoNghiViec : null,
    tinhChatLaoDong:
      id !== undefined ? dataDetailEmployee.idTinhChatLaoDong : null,
    idDanToc: id !== undefined ? dataDetailEmployee.idDanToc : null,
    idTonGiao: id !== undefined ? dataDetailEmployee.idTonGiao : null,
    idNgachCongChuc:
      id !== undefined ? dataDetailEmployee.idNgachCongChuc : null,
    yt_nhomMau: id !== undefined ? dataDetailEmployee.ytNhomMau : null,
    yt_chieuCao: id !== undefined ? dataDetailEmployee.ytChieuCao : null,
    yt_canNang: id !== undefined ? dataDetailEmployee.ytCanNang : null,
    yt_tinhTrangSucKhoe:
      id !== undefined ? dataDetailEmployee.ytTinhTrangSucKhoe : null,
    yt_benhTat: id !== undefined ? dataDetailEmployee.ytBenhTat : null,
    yt_luuY: id !== undefined ? dataDetailEmployee.ytLuuY : null,
    yt_khuyetTat:
      id !== undefined
        ? dataDetailEmployee.ytKhuyetTat === "Không"
          ? false
          : true
        : false,
    yt_maNhanVien: id !== undefined ? dataDetailEmployee.id : rsId,
    lhkc_hoTen: id !== undefined ? dataDetailEmployee.lhkcHoTen : null,
    lhkc_quanHe: id !== undefined ? dataDetailEmployee.lhkcQuanHe : null,
    lhkc_dienThoai: id !== undefined ? dataDetailEmployee.lhkcDienThoai : null,
    lhkc_email: id !== undefined ? dataDetailEmployee.lhkcEmail : null,
    lhkc_diaChi: id !== undefined ? dataDetailEmployee.lhkcDiaChi : null,
    lhkc_maNhanVien: id !== undefined ? dataDetailEmployee.id : rsId,
    lsbt_biBatDiTu: id !== undefined ? dataDetailEmployee.biBatDitu : null,
    lsbt_thamGiaChinhTri:
      id !== undefined ? dataDetailEmployee.thamGiaChinhTri : null,
    lsbt_thanNhanNuocNgoai:
      id !== undefined ? dataDetailEmployee.thanNhanNuocNgoai : null,
    lsbt_maNhanVien: id !== undefined ? dataDetailEmployee.id : rsId,
  };

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
  const [file, setFile] = useState({
    file: null,
    path: "/Images/userIcon.png",
    size: null,
  });
  const handleChange = (e) => {
    // console.log(e.file.size);
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

  useEffect(() => {
    if (dataDetailEmployee) {
      reset(intitalValue);
    }
  }, [dataDetailEmployee]);

  useEffect(() => {
    if (allIdEm) {
      reset(intitalValue);
    }
  }, [allIdEm]);
  //check update
  const checkInputChange = () => {
    const values = getValues([
      "id",
      "hoTen",
      "quocTich",
      "gioiTinh",
      "dienThoai",
      "dienThoaiKhac",
      "diDong",
      "email",
      "facebook",
      "skype",
      "maSoThue",
      "cccd",
      "noiCapCCCD",
      "hoChieu",
      "noiCapHoChieu",
      "noiSinh",
      "queQuan",
      "thuongTru",
      "tamTru",
      "ngheNghiep",
      "chucVuHienTai",
      "congViecChinh",
      "coQuanTuyenDung",
      "ngachCongChucNoiDung",
      "vaoDang",
      "quanNhan",
      "quanHamCaoNhat",
      "danhHieuCaoNhat",
      "noiThamGia",
      "laThuongBinh",
      "laConChinhSach",
      "thuongBinh",
      "conChinhSach",
      "bhxh",
      "bhyt",
      "atm",
      "nganHang",
      "trangThaiLaoDong",
      "tinhChatLaoDong",
      "idDanhMucHonNhan",
      "idDanToc",
      "idTonGiao",
      "idNgachCongChuc",
      "yt_nhomMau",
      "yt_chieuCao",
      "yt_canNang",
      "yt_tinhTrangSucKhoe",
      "yt_benhTat",
      "yt_luuY",
      "yt_khuyetTat",
      "lhkc_hoTen",
      "lhkc_quanHe",
      "lhkc_dienThoai",
      "lhkc_email",
      "lhkc_diaChi",
      "lsbt_biBatDiTu",
      "lsbt_thamGiaChinhTri",
      "lsbt_thanNhanNuocNgoai",
      "ngaySinh",
      "ngayCapCCCD",
      "ngayHetHanCCCD",
      "ngayCapHoChieu",
      "ngayHetHanHoChieu",
      "ngayTuyenDung",
      "ngayThuViec",
      "ngayVaoBan",
      "ngayChinhThuc",
      "ngayVaoDang",
      "ngayVaoDangChinhThuc",
      "ngayNhapNgu",
      "ngayXuatNgu",
      "ngayVaoDoan",
      "ngayNghiViec",
    ]);
    const dfValue = [
      intitalValue.id,
      intitalValue.hoTen,
      intitalValue.quocTich,
      intitalValue.gioiTinh,
      intitalValue.dienThoai,
      intitalValue.dienThoaiKhac,
      intitalValue.diDong,
      intitalValue.email,
      intitalValue.facebook,
      intitalValue.skype,
      intitalValue.maSoThue,
      intitalValue.cccd,
      intitalValue.noiCapCCCD,
      intitalValue.hoChieu,
      intitalValue.noiCapHoChieu,
      intitalValue.noiSinh,
      intitalValue.queQuan,
      intitalValue.thuongTru,
      intitalValue.tamTru,
      intitalValue.ngheNghiep,
      intitalValue.chucVuHienTai,
      intitalValue.congViecChinh,
      intitalValue.coQuanTuyenDung,
      intitalValue.ngachCongChucNoiDung,
      intitalValue.vaoDang,
      intitalValue.quanNhan,
      intitalValue.quanHamCaoNhat,
      intitalValue.danhHieuCaoNhat,
      intitalValue.noiThamGia,
      intitalValue.laThuongBinh,
      intitalValue.laConChinhSach,
      intitalValue.thuongBinh,
      intitalValue.conChinhSach,
      intitalValue.bhxh,
      intitalValue.bhyt,
      intitalValue.atm,
      intitalValue.nganHang,
      intitalValue.trangThaiLaoDong,
      intitalValue.tinhChatLaoDong,
      intitalValue.idDanhMucHonNhan,
      intitalValue.idDanToc,
      intitalValue.idTonGiao,
      intitalValue.idNgachCongChuc,
      intitalValue.yt_nhomMau,
      intitalValue.yt_chieuCao,
      intitalValue.yt_canNang,
      intitalValue.yt_tinhTrangSucKhoe,
      intitalValue.yt_benhTat,
      intitalValue.yt_luuY,
      intitalValue.yt_khuyetTat,
      intitalValue.lhkc_hoTen,
      intitalValue.lhkc_quanHe,
      intitalValue.lhkc_dienThoai,
      intitalValue.lhkc_email,
      intitalValue.lhkc_diaChi,
      intitalValue.lsbt_biBatDiTu,
      intitalValue.lsbt_thamGiaChinhTri,
      intitalValue.lsbt_thanNhanNuocNgoai,
      intitalValue.ngaySinh,
      intitalValue.ngayCapCCCD,
      intitalValue.ngayHetHanCCCD,
      intitalValue.ngayCapHoChieu,
      intitalValue.ngayHetHanHoChieu,
      intitalValue.ngayTuyenDung,
      intitalValue.ngayThuViec,
      intitalValue.ngayVaoBan,
      intitalValue.ngayChinhThuc,
      intitalValue.ngayVaoDang,
      intitalValue.ngayVaoDangChinhThuc,
      intitalValue.ngayNhapNgu,
      intitalValue.ngayXuatNgu,
      intitalValue.ngayVaoDoan,
      intitalValue.ngayNghiViec,
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

  //get data from form
  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if (id !== undefined) {
        if (file.size < 20000000) {
          await PutApi.PutNV(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa thông tin của nhân viên ${dataDetailEmployee.hoTen}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          if (file.file !== null) {
            await DeleteApi.deleteANV(data.id);
            const formData = new FormData();
            formData.append("anh", file.file);
            formData.append("maNhanVien", data.id);
            await PutApi.PutIMG(formData, data.id);
          }
          history.goBack();
        } else {
          error("Không thể upload file quá 20M");
        }
      } else {
        if (file.size < 20000000) {
          await ProductApi.postNv(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm nhân viên mới${data.hoTen}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          if (file.file !== null) {
            const formData = new FormData();
            formData.append("anh", file.file);
            formData.append("maNhanVien", data.id);
            await PutApi.PutIMG(formData, data.id);
          }
          success(`Thêm hồ sơ nhân viên ${data.hoTen} thành công`);
          history.goBack();
        } else {
          error("Không thể upload file quá 20M");
        }
      }
    } catch (error) {}
  };

  //console.log(emCode);
  console.log(file.file);
  console.log(endDate);

  //handle image
  //const [file, setFile] = useState("/Images/userIcon.png");

  return (
    <>
      <div className="container-form">
        <div className="Submit-button ">
          <div>
            <h2 className="">
              {dataDetailEmployee.length !== 0 ? "Sửa" : "Thêm"} hồ sơ
            </h2>
          </div>
          <div className="button">
            {/* <input
            type="submit"
            className={
              dataDetailEmployee.length !== 0
                ? "btn btn-danger"
                : "delete-button"
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
              onClick={history.goBack}
            />
            <input
              type="submit"
              className="btn btn-primary ml-3"
              value={dataDetailEmployee.length !== 0 ? "Sửa" : "Lưu"}
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
        <div className="scroll-form">
          <form
            action=""
            class="profile-form"
            // onSubmit={handleSubmit(onHandleSubmit)}
          >
            {/* container import image */}
            <div className="container-ava">
              <span>
                {" "}
                <img
                  src={
                    id !== undefined
                      ? file.file !== null
                        ? file.path
                        : dataDetailEmployee.anh == null
                        ? file.path
                        : `https://localhost:5001/${dataDetailEmployee.anh}`
                      : file.path
                  }
                  className="icon"
                  alt=""
                />
              </span>
              {/* <Controller
              name="anh"
              control={control}
              render={({ field, onChange }) => (
                
              )}
            /> */}

              <Upload
                beforeUpload={() => false}
                onChange={handleChange}
                maxCount={1}
                accept=".jpg,.png,.pdf"
              >
                <Button icon={<UploadOutlined />}>Chọn thư mục</Button>
              </Upload>
              {/* <input
              type="file"
              // {...register2("anh")}
              accept="Images/*"
              class="form-control-file"
              onChange={handleChange}
            ></input> */}
            </div>
            {/* Container thông tin cơ bản */}
            <div className="container-div-form">
              <h3>Thông tin cơ bản</h3>
              <h5>Thông tin chung</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label class="col-sm-4 justify-content-start" htmlFor="id">
                      Mã Nhân Viên
                    </label>
                    <input
                      type="text"
                      {...register("id")}
                      id="id"
                      value={rsId}
                      className={
                        !errors.id
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      //onChange={(e) => setEmCode(e.target.value)}
                      readOnly
                    />
                    <span className="message">{errors.id?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label class="col-sm-4 justify-content-start" htmlFor="atm">
                      TK ngân hàng
                    </label>
                    <input
                      type="text"
                      {...register("atm")}
                      id="atm"
                      className={
                        !errors.atm
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.atm?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline ">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="hoVaTen"
                    >
                      Họ và tên
                    </label>
                    <input
                      type="text"
                      {...register("hoTen")}
                      id="hoTen"
                      className={
                        !errors.hoTen
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.hoTen?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="nganHang"
                    >
                      Ngân Hàng
                    </label>
                    <input
                      type="text"
                      {...register("nganHang")}
                      id="nganHang"
                      className={
                        !errors.nganHang
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.nganHang?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="gioiTinh"
                    >
                      Giới tính
                    </label>
                    <select
                      type="text"
                      {...register("gioiTinh")}
                      id="gioiTinh"
                      className={
                        !errors.gioiTinh
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                    >
                      <option value=""></option>
                      <option value={true}>Nam</option>
                      <option value={false}>Nữ</option>
                    </select>
                    <span className="message">{errors.gioiTinh?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="idDanhMucHonNhan"
                    >
                      Tình trạng hôn nhân
                    </label>
                    <select
                      type="text"
                      {...register("idDanhMucHonNhan")}
                      id="idDanhMucHonNhan"
                      className={
                        !errors.idDanhMucHonNhan
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                    >
                      <option value=""></option>
                      {dataMarrige.map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenDanhMuc}
                        </option>
                      ))}
                      {/* <option value="1">Độc thân</option>
                    <option value="2">Đã có gia đình</option>
                    <option value="3">Ly dị</option> */}
                    </select>
                    <span className="message">
                      {errors.idDanhMucHonNhan?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngaySinh"
                    >
                      Ngày sinh
                    </label>
                    <Controller
                      name="ngaySinh"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngaySinh"
                          className={
                            !errors.ngaySinh
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
                    <span className="message">{errors.ngaySinh?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="noiSinh"
                    >
                      Nơi sinh
                    </label>
                    <input
                      type="text"
                      {...register("noiSinh")}
                      id="noiSinh"
                      className={
                        !errors.noiSinh
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.noiSinh?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="idDanToc"
                    >
                      Dân tộc
                    </label>
                    <select
                      type="text"
                      {...register("idDanToc")}
                      id="idDanToc"
                      className={
                        !errors.idDanToc
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                    >
                      <option value=""></option>
                      {dataNation.map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenDanhMuc}
                        </option>
                      ))}
                    </select>
                    <span className="message">{errors.idDanToc?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="queQuan"
                    >
                      Nguyên quán
                    </label>
                    <input
                      type="text"
                      {...register("queQuan")}
                      id="queQuan"
                      className={
                        !errors.queQuan
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.queQuan?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="idTonGiao"
                    >
                      Tôn giáo
                    </label>
                    <select
                      type="text"
                      {...register("idTonGiao")}
                      id="idTonGiao"
                      className={
                        !errors.idTonGiao
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                    >
                      <option value=""></option>
                      {dataReligion.map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenDanhMuc}
                        </option>
                      ))}
                    </select>
                    <span className="message">{errors.idTonGiao?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="thuongTru"
                    >
                      HK thường trú
                    </label>
                    <input
                      type="text"
                      {...register("thuongTru")}
                      id="thuongTru"
                      className={
                        !errors.thuongTru
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.thuongTru?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="quocTich"
                    >
                      Quốc tịch
                    </label>
                    <input
                      type="text"
                      {...register("quocTich")}
                      id="quocTich"
                      className={
                        !errors.quocTich
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.quocTich?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="tamTru"
                    >
                      Tạm trú
                    </label>
                    <input
                      type="text"
                      {...register("tamTru")}
                      id="tamTru"
                      className={
                        !errors.tamTru
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.tamTru?.message}</span>
                  </div>
                </div>
              </div>

              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="bhyt"
                    >
                      Bảo hiểm y tế
                    </label>
                    <input
                      type="text"
                      {...register("bhyt")}
                      id="bhyt"
                      className={
                        !errors.bhyt
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: HS4010110169971"
                    />
                    <span className="message">{errors.bhyt?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="bhxh"
                    >
                      Bảo hiểm xã hội
                    </label>
                    <input
                      type="text"
                      {...register("bhxh")}
                      id="bhxh"
                      className={
                        !errors.bhxh
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: 0110169971"
                    />
                    <span className="message">{errors.bhxh?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="maSoThue"
                    >
                      Mã số thuế cá nhân
                    </label>
                    <input
                      type="text"
                      {...register("maSoThue")}
                      id="maSoThue"
                      className={
                        !errors.maSoThue
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: 0500080664"
                    />
                    <span className="message">{errors.maSoThue?.message}</span>
                  </div>
                </div>
              </div>
              <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="cccd"
                    >
                      Số CMND/CCCD
                    </label>
                    <input
                      type="text"
                      {...register("cccd")}
                      id="cccd"
                      className={
                        !errors.cccd
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: 019099000071"
                    />
                    <span className="message">{errors.cccd?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="hoChieu"
                    >
                      Số Hộ chiếu
                    </label>
                    <input
                      type="text"
                      {...register("hoChieu")}
                      id="hoChieu"
                      className={
                        !error.hoChieu
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: B4815163"
                    />
                    <span className="message">{errors.hoChieu?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayCapCCCD"
                    >
                      Ngày cấp(CMNN/CCCD)
                    </label>
                    <Controller
                      name="ngayCapCCCD"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayCapCCCD"
                          className={
                            !errors.ngayCapCCCD
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
                      {errors.ngayCapCCCD?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayCapHoChieu"
                    >
                      Ngày cấp Hộ chiếu
                    </label>
                    <Controller
                      name="ngayCapHoChieu"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayCapHoChieu"
                          className={
                            !errors.ngayCapHoChieu
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
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="noiCapCCCD"
                    >
                      Nơi cấp(CMND/CCCD)
                    </label>
                    <input
                      type="text"
                      {...register("noiCapCCCD")}
                      id="noiCapCCCD"
                      className={
                        !errors.noiCapCCCD
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.noiCapCCCD?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="NoiCapHoChieu"
                    >
                      Nơi cấp hộ chiếu
                    </label>
                    <input
                      type="text"
                      {...register("NoiCapHoChieu")}
                      id="NoiCapHoChieu"
                      className={
                        !errors.NoiCapHoChieu
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.NoiCapHoChieu?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayHetHanCCCD"
                    >
                      Ngày hết hạn
                    </label>
                    <Controller
                      name="ngayHetHanCCCD"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayHetHanCCCD"
                          className={
                            !errors.ngayHetHanCCCD
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
                      {errors.ngayHetHanCCCD?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayHetHanHoChieu"
                    >
                      Ngày hết hạn hộ chiếu
                    </label>
                    <Controller
                      name="ngayHetHanHoChieu"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayHetHanHoChieu"
                          className={
                            !errors.ngayHetHanHoChieu
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
                  </div>
                </div>
              </div>
            </div>
            {/* Container Thông tin liên hệ */}
            <div className="container-div-form">
              <h3>Thông tin liên hệ</h3>
              <h5>Số điện thoại/Email/Khác</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="diDong"
                    >
                      ĐT di động
                    </label>
                    <input
                      type="text"
                      {...register("diDong")}
                      id="diDong"
                      className={
                        !errors.diDong
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: +84967761999"
                    />
                    <span className="message">{errors.diDong?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="email"
                    >
                      Email cá nhân
                    </label>
                    <input
                      type="text"
                      {...register("email")}
                      id="email"
                      className={
                        !errors.email
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: xxx@gmail.com"
                    />
                    <span className="message">{errors.email?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="dienThoaiKhac"
                    >
                      ĐT khác
                    </label>
                    <input
                      type="text"
                      {...register("dienThoaiKhac")}
                      id="dienThoaiKhac"
                      className={
                        !errors.dienThoaiKhac
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.dienThoaiKhac?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="facebook"
                    >
                      Facebook
                    </label>
                    <input
                      type="text"
                      {...register("facebook")}
                      id="facebook"
                      className={
                        !errors.facebook
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.facebook?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="dienThoai"
                    >
                      ĐT nhà riêng
                    </label>
                    <input
                      type="text"
                      {...register("dienThoai")}
                      id="dienThoai"
                      className={
                        !errors.dienThoai
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: 02433452311"
                    />
                    <span className="message">{errors.dienThoai?.message}</span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="skype"
                    >
                      Skype
                    </label>
                    <input
                      type="text"
                      {...register("skype")}
                      id="skype"
                      className={
                        !errors.skype
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.skype?.message}</span>
                  </div>
                </div>
              </div>

              <h5>Liên hệ khẩn cấp</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="lhkc_hoTen"
                    >
                      Họ và tên
                    </label>
                    <input
                      type="text"
                      {...register("lhkc_hoTen")}
                      id="lhkc_hoTen"
                      className={
                        !errors.lhkc_hoTen
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.lhkc_hoTen?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="lhkc_email"
                    >
                      Email
                    </label>
                    <input
                      type="text"
                      {...register("lhkc_email")}
                      id="lhkc_email"
                      className={
                        !errors.lhkc_email
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                      placeholder="VD: xxx@gmail.com"
                    />
                    <span className="message">
                      {errors.lhkc_email?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="lhkc_quanHe"
                    >
                      Quan hệ
                    </label>
                    <input
                      type="text"
                      {...register("lhkc_quanHe")}
                      id="lhkc_quanHe"
                      className={
                        !errors.lhkc_quanHe
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.lhkc_quanHe?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="lhkc_diaChi"
                    >
                      Địa chỉ
                    </label>
                    <input
                      type="text"
                      {...register("lhkc_diaChi")}
                      id="lhkc_diaChi"
                      className={
                        !errors.lhkc_diaChi
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.lhkc_diaChi?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="lhkc_dienThoai"
                    >
                      ĐT di động
                    </label>
                    <input
                      type="text"
                      {...register("lhkc_dienThoai")}
                      id="lhkc_dienThoai"
                      className={
                        !errors.lhkc_dienThoai
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.lhkc_dienThoai?.message}
                    </span>
                  </div>
                </div>
              </div>
              <input
                style={{ display: "none" }}
                type="text"
                {...register("lhkc_maNhanVien")}
                value={rsId}
              />
            </div>
            {/* Container thông tin công việc*/}
            <div className="container-div-form">
              <h3>Thông tin công việc</h3>
              <h5>Thông tin nhân viên</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngheNghiep"
                    >
                      Nghề nghiệp
                    </label>
                    <input
                      type="text"
                      {...register("ngheNghiep")}
                      id="ngheNghiep"
                      className={
                        !errors.ngheNghiep
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.ngheNghiep?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="congViecChinh"
                    >
                      Công việc chính
                    </label>
                    <input
                      type="text"
                      {...register("congViecChinh")}
                      id="congViecChinh"
                      className={
                        !errors.congViecChinh
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.congViecChinh?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayThuViec"
                    >
                      Ngày thử việc
                    </label>
                    <Controller
                      name="ngayThuViec"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayThuViec"
                          className={
                            !errors.ngayThuViec
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
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayChinhThuc"
                    >
                      Ngày chính thức
                    </label>
                    <Controller
                      name="ngayChinhThuc"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayChinhThuc"
                          className={
                            !errors.ngayChinhThuc
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
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayTuyenDung"
                    >
                      Ngày tuyển dụng
                    </label>
                    <Controller
                      name="ngayTuyenDung"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayTuyenDung"
                          className={
                            !errors.ngayTuyenDung
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
                      {errors.ngayTuyenDung?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayVaoBan"
                    >
                      Ngày vào ban
                    </label>
                    <Controller
                      name="ngayVaoBan"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayTuyenDung"
                          className={
                            !errors.ngayTuyenDung
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
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="coQuanTuyenDung"
                    >
                      Cơ quan tuyển dụng
                    </label>
                    <input
                      type="text"
                      {...register("coQuanTuyenDung")}
                      id="coQuanTuyenDung"
                      className={
                        !errors.coQuanTuyenDung
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.coQuanTuyenDung?.message}
                    </span>
                  </div>
                </div>
                {/* <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="phongBan"
                >
                  Phòng Ban
                </label>
                <select
                  type="text"
                  {...register("phongBan")}
                  id="phongBan"
                  className={
                    !errors.phongBan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                />
                <span className="message">{errors.phongBan?.message}</span>
              </div>
            </div> */}
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="chucVuHienTai"
                    >
                      Chức vụ hiện tại
                    </label>
                    <input
                      type="text"
                      {...register("chucVuHienTai")}
                      id="chucVuHienTai"
                      className={
                        !errors.chucVuHienTai
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.chucVuHienTai?.message}
                    </span>
                  </div>
                </div>
                {/* <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="to">
                  Tổ
                </label>
                <select
                  type="text"
                  {...register("to")}
                  id="to"
                  className="form-control col-sm-6 custom-select"
                ></select>
              </div>
            </div> */}
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="trangThaiLaoDong"
                    >
                      Trạng thái lao động
                    </label>
                    <select
                      type="text"
                      {...register("trangThaiLaoDong")}
                      id="trangThaiLaoDong"
                      className={
                        !errors.trangThaiLaoDong
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                      onChange={(e) => {
                        handleResignation(e);
                      }}
                    >
                      <option value=""></option>
                      <option value={true}>Đang làm việc</option>
                      <option value={false}>Đã nghỉ việc</option>
                    </select>
                    <span className="message">
                      {errors.trangThaiLaoDong?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="tinhChatLaoDong"
                    >
                      Tính chất lao động
                    </label>
                    <select
                      type="text"
                      {...register("tinhChatLaoDong")}
                      id="tinhChatLaoDong"
                      className={
                        !errors.tinhChatLaoDong
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                    >
                      <option value=""></option>
                      {dataLabor.map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenLaoDong}
                        </option>
                      ))}
                    </select>
                    <span className="message">
                      {errors.tinhChatLaoDong?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="lyDoNghiViec"
                    >
                      Lý do nghỉ
                    </label>
                    <input
                      type="text"
                      {...register("lyDoNghiViec")}
                      id="lyDoNghiViec"
                      className="form-control col-sm-6"
                      disabled={!resignation}
                    />
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayNghiViec"
                    >
                      Ngày nghỉ việc
                    </label>
                    <Controller
                      name="ngayNghiViec"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayNghiViec"
                          className={
                            !errors.ngayNghiViec
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
                          disabled={!resignation}
                        />
                      )}
                    />
                  </div>
                </div>
              </div>
            </div>
            {/* Container thông tin chính trị quân sự y tế */}
            <div className="container-div-form2">
              <h3>Thông tin chính trị, quân sự, y tế</h3>
              <h5>Thông tin chính trị</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="idNgachCongChuc"
                    >
                      Ngạch công chức
                    </label>
                    <select
                      type="text"
                      {...register("idNgachCongChuc")}
                      id="idNgachCongChuc"
                      className={
                        !errors.idNgachCongChuc
                          ? "form-control col-sm-6 custom-select"
                          : "form-control col-sm-6 border-danger custom-select"
                      }
                    >
                      <option value=""></option>
                      {dataCRS.map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenNgach}
                        </option>
                      ))}
                    </select>
                    <span className="message">
                      {errors.idNgachCongChuc?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayVaoDoan"
                    >
                      Ngày vào Đoàn
                    </label>
                    {/* <input
                    type="text"
                    {...register("ngayVaoDoan")}
                    id="ngayVaoDoan"
                    className="form-control col-sm-6"
                  /> */}
                    <Controller
                      name="ngayVaoDoan"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayVaoDoan"
                          className={
                            !errors.ngayVaoDoan
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
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngachCongChucNoiDung"
                    >
                      Ngạch công chức nội dung
                    </label>
                    <input
                      type="text"
                      {...register("ngachCongChucNoiDung")}
                      id="ngachCongChucNoiDung"
                      className={
                        !errors.ngachCongChucNoiDung
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.ngachCongChucNoiDung?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="NoiThamGia"
                    >
                      Nơi tham gia
                    </label>
                    <input
                      type="text"
                      {...register("noiThamGia")}
                      id="noiThamGia"
                      className={
                        !errors.noiThamGia
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.noiThamGia?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-check mb-3 form-inline">
                    <input
                      type="checkbox"
                      {...register("vaoDang", {
                        onChange: (e) => setEndDate(e.target.value),
                      })}
                      id="vaoDang"
                      className="form-check-input"
                      onClick={handleClickParty}
                      checked={checkedParty}
                    />
                    <label
                      className="form-check-label col-sm-4 justify-content-start "
                      htmlFor="vaoDang"
                    >
                      Đã vào Đảng
                    </label>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayVaoDang"
                    >
                      Ngày vào Đảng
                    </label>
                    <Controller
                      name="ngayVaoDang"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayVaoDang"
                          className={
                            !errors.ngayVaoDang
                              ? "form-control col-sm-6"
                              : "form-control col-sm-6 border-danger"
                          }
                          placeholder="DD/MM/YYYY"
                          format="DD/MM/YYYY"
                          disabled={!checkedParty}
                          value={field.value}
                          onChange={(event) => {
                            field.onChange(event);
                          }}
                          {...field._d}
                        />
                      )}
                    />
                    <span className="message">
                      {errors.ngayVaoDang?.message}
                    </span>
                  </div>
                </div>
              </div>

              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayVaoDangChinhThuc"
                    >
                      Ngày chính thức
                    </label>
                    <Controller
                      name="ngayVaoDangChinhThuc"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayVaoDangChinhThuc"
                          className={
                            !errors.ngayVaoDangChinhThuc
                              ? "form-control col-sm-6"
                              : "form-control col-sm-6 border-danger"
                          }
                          placeholder="DD/MM/YYYY"
                          format="DD/MM/YYYY"
                          disabled={!checkedParty}
                          value={field.value}
                          onChange={(event) => {
                            field.onChange(event);
                          }}
                          {...field._d}
                        />
                      )}
                    />
                    <span className="message">
                      {errors.ngayVaoDangChinhThuc?.message}
                    </span>
                  </div>
                </div>
              </div>
              <h5>Thông tin quân sự</h5>
              <div className="row">
                <div className="col">
                  <div class="form-check mb-2 form-inline">
                    <input
                      type="checkbox"
                      {...register("quanNhan")}
                      id="quanNhan"
                      className="form-check-input"
                      onClick={handleClick}
                      checked={checkedSoldier}
                    />
                    <label
                      className="form-check-label col-sm-4 justify-content-start "
                      htmlFor="quanNhan"
                    >
                      Là quân nhân
                    </label>
                  </div>
                </div>
                <div className="col">
                  <div className="form-check form-inline">
                    <input
                      type="checkbox"
                      {...register("laThuongBinh")}
                      id="laThuongBinh"
                      className="form-check-input"
                      onClick={handleClickVeteransy}
                      checked={veterans}
                    />
                    <label
                      className="form-check-label col-sm-4 justify-content-start"
                      htmlFor="laThuongBinh"
                    >
                      Là thương binh
                    </label>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayNhapNgu"
                    >
                      Ngày nhập ngũ
                    </label>
                    <Controller
                      name="ngayNhapNgu"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayNhapNgu"
                          className={
                            !errors.ngayNhapNgu
                              ? "form-control col-sm-6"
                              : "form-control col-sm-6 border-danger"
                          }
                          placeholder="DD/MM/YYYY"
                          format="DD/MM/YYYY"
                          disabled={!checkedSoldier}
                          value={field.value}
                          onChange={(event) => {
                            field.onChange(event);
                          }}
                          {...field._d}
                        />
                      )}
                    />
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="thuongBinh"
                    >
                      Là thương binh hạng
                    </label>
                    <input
                      type="text"
                      {...register("thuongBinh")}
                      id="thuongBinh"
                      className={
                        !errors.thuongBinh
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      disabled={!veterans}
                    />
                    <span className="message">
                      {errors.thuongBinh?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="ngayXuatNgu"
                    >
                      Ngày xuất ngũ
                    </label>
                    <Controller
                      name="ngayXuatNgu"
                      control={control}
                      render={({ field, onChange }) => (
                        <DatePicker
                          id="ngayXuatNgu"
                          className={
                            !errors.ngayXuatNgu
                              ? "form-control col-sm-6"
                              : "form-control col-sm-6 border-danger"
                          }
                          placeholder="DD/MM/YYYY"
                          format="DD/MM/YYYY"
                          disabled={!checkedSoldier}
                          value={field.value}
                          onChange={(event) => {
                            field.onChange(event);
                          }}
                          {...field._d}
                        />
                      )}
                    />
                  </div>
                </div>
                <div className="col">
                  <div className="form-check form-inline">
                    <input
                      type="checkbox"
                      {...register("laConChinhSach")}
                      id="laConChinhSach"
                      className="form-check-input"
                      onClick={handleClickPolicy}
                      checked={policy}
                    />
                    <label
                      className="form-check-label col-sm-4 justify-content-start"
                      htmlFor="laConChinhSach"
                    >
                      Là con gia đình chính sách
                    </label>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="quanHamCaoNhat"
                    >
                      Quân hàm cao nhất
                    </label>
                    <input
                      type="text"
                      {...register("quanHamCaoNhat")}
                      id="quanHamCaoNhat"
                      className="form-control col-sm-6"
                      disabled={!checkedSoldier}
                    />
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="conChinhSach"
                    >
                      Là con gia đình chính sách
                    </label>
                    <input
                      type="text"
                      {...register("conChinhSach")}
                      id="conChinhSach"
                      className="form-control col-sm-6"
                      disabled={!policy}
                    />
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="danhHieuCaoNhat"
                    >
                      DH được phong tặng cao nhất
                    </label>
                    <input
                      type="text"
                      {...register("danhHieuCaoNhat")}
                      id="danhHieuCaoNhat"
                      className="form-control col-sm-6"
                      disabled={!checkedSoldier}
                    />
                  </div>
                </div>
              </div>
              {/* Container thông tin y tế */}
              <h5>Thông tin y tế</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="yt_nhomMau"
                    >
                      Nhóm máu
                    </label>
                    <input
                      type="text"
                      {...register("yt_nhomMau")}
                      id="yt_nhomMau"
                      className={
                        !errors.yt_nhomMau
                          ? "form-control  col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.yt_nhomMau?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="yt_benhTat"
                    >
                      Bệnh tật
                    </label>
                    <input
                      type="text"
                      {...register("yt_benhTat")}
                      id="yt_benhTat"
                      className={
                        !errors.yt_benhTat
                          ? "form-control  col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.yt_benhTat?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="yt_chieuCao"
                    >
                      Chiều cao(cm)
                    </label>
                    <input
                      type="text"
                      {...register("yt_chieuCao")}
                      id="yt_chieuCao"
                      className={
                        !errors.yt_chieuCao
                          ? "form-control  col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.yt_chieuCao?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="yt_luuY"
                    >
                      Lưu ý
                    </label>
                    <input
                      type="text"
                      {...register("yt_luuY")}
                      id="yt_luuY"
                      className={
                        !errors.yt_luuY
                          ? "form-control  col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">{errors.yt_luuY?.message}</span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="yt_canNang"
                    >
                      Cân nặng(kg)
                    </label>
                    <input
                      type="text"
                      {...register("yt_canNang")}
                      id="yt_canNang"
                      className={
                        !errors.yt_canNang
                          ? "form-control  col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.yt_canNang?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-check form-inline">
                    <input
                      type="checkbox"
                      {...register("yt_khuyetTat")}
                      id="yt_khuyetTat"
                      className="form-check-input"
                    />
                    <label
                      className="form-check-label col-sm-4 justify-content-start"
                      htmlFor="yt_khuyetTat"
                    >
                      Là người khuyết tật
                    </label>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col-6">
                  <div class="form-group form-inline">
                    <label
                      class="col-sm-4 justify-content-start"
                      htmlFor="yt_tinhTrangSucKhoe"
                    >
                      Tình trạng sức khoẻ
                    </label>
                    <input
                      type="text"
                      {...register("yt_tinhTrangSucKhoe")}
                      id="yt_tinhTrangSucKhoe"
                      className={
                        !errors.yt_tinhTrangSucKhoe
                          ? "form-control  col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.yt_tinhTrangSucKhoe?.message}
                    </span>
                    <input
                      style={{ display: "none" }}
                      type="text"
                      {...register("yt_maNhanVien")}
                      value={rsId}
                    />
                  </div>
                </div>
              </div>
            </div>
            <div className="container-div-form">
              <h3>Lịch sử bản thân</h3>
              <h5>Thông tin chung</h5>
              <div className="row">
                <div className="col">
                  <div class="form-group">
                    <label
                      class=" justify-content-start"
                      htmlFor="lsbt_biBatDiTu"
                    >
                      Bị bắt, bị tù (thời gian và địa điểm), khai báo cho ai,
                      những vấn đề gì?
                    </label>
                    <textarea
                      type="text"
                      {...register("lsbt_biBatDiTu")}
                      rows="4"
                      id="lsbt_biBatDiTu"
                      className={
                        !errors.lsbt_biBatDiTu
                          ? "form-control  form-width"
                          : "form-control form-width border-danger"
                      }
                    />
                    <span className="message">
                      {errors.lsbt_biBatDiTu?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group">
                    <label
                      class=" justify-content-start"
                      htmlFor="thamGiaChinhTri"
                    >
                      Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh
                      tế, xã hội ở nước ngoài
                    </label>
                    <textarea
                      type="text"
                      rows="4"
                      {...register("lsbt_thamGiaChinhTri")}
                      id="lsbt_thamGiaChinhTri"
                      className={
                        !errors.lsbt_thamGiaChinhTri
                          ? "form-control  form-width"
                          : "form-control form-width border-danger"
                      }
                    />
                    <span className="message">
                      {errors.lsbt_thamGiaChinhTri?.message}
                    </span>
                  </div>
                </div>
              </div>
              <div className="row">
                <div className="col">
                  <div class="form-group">
                    <label
                      class=" justify-content-start"
                      htmlFor="thanNhanNuocNgoai"
                    >
                      Có Thân nhân(cha, mẹ, vợ, chồng, con, anh chị em ruột) ở
                      nước ngoài (làm gì, địa chỉ...)?
                    </label>
                    <textarea
                      type="text"
                      rows="4"
                      {...register("lsbt_thanNhanNuocNgoai")}
                      id="lsbt_thanNhanNuocNgoai"
                      className={
                        !errors.lsbt_thanNhanNuocNgoai
                          ? "form-control form-width "
                          : "form-control form-width border-danger"
                      }
                    />
                    <input
                      style={{ display: "none" }}
                      type="text"
                      {...register("lsbt_maNhanVien")}
                      value={rsId}
                    />
                    <span className="message">
                      {errors.lsbt_thanNhanNuocNgoai?.message}
                    </span>
                  </div>
                </div>
              </div>
            </div>
          </form>
        </div>
        <div className="footer"></div>
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
            ? "Bạn chưa thay đổi thông tin nhân viên"
            : "Bạn chưa nhập thông tin nhân viên"
        }
        confirm={null}
        cancel={cancel}
      />
      {/* <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin trình độ `}
        confirm={handleDelete}
        cancel={cancel}
      /> */}
    </>
  );
}

export default AddProfileForm;
