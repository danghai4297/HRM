import React from "react";
import "./ProfileForm.scss";
import { Controller, useForm } from "react-hook-form";
import "../../../components/FontAwesomeIcons/index";
import { useState, useEffect } from "react";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
import "antd/dist/antd.css";
import { yupResolver } from "@hookform/resolvers/yup";
import ProductApi from "../../../api/productApi";
import { Upload, Button } from "antd";
import { UploadOutlined } from "@ant-design/icons";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import DialogCheck from "../../../components/Dialog/DialogCheck";
import Dialog from "../../../components/Dialog/Dialog";
import { useToast } from "../../../components/Toast/Toast";
import jwt_decode from "jwt-decode";
import { schema } from "../../../ultis/ProfileValidation";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function AddProfileForm(props) {
  const { error, success } = useToast();
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
  const [open, setOpen] = useState(false);
  const handleResignation = (e) => {
    if (e.target.value == "false") {
      setResignation(!resignation);
    } else {
      setResignation(false);
      clearErrors(["lyDoNghiViec", "ngayNghiViec"]);
      resetField("lyDoNghiViec", { defaultValue: null });
      resetField("ngayNghiViec", { defaultValue: null });
    }
  };

  const [endDate, setEndDate] = useState();

  //State contain category
  const [dataDetailEmployee, setDataDetailEmployee] = useState([]);
  const [dataMarrige, setDataMarrige] = useState([]);
  const [dataNation, setDataNation] = useState([]);
  const [dataReligion, setDataReligion] = useState([]);
  const [dataCRS, setDataCRS] = useState([]);
  const [dataLabor, setDataLabor] = useState([]);
  const [allIdEm, setAllIdEm] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin nhân viên mới."
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showEsc, setShowEsc] = useState(false);

  const [LDN, setLDN] = useState();
  const [NCCND, setNCCND] = useState();
  const [NTG, setNTG] = useState();
  const [QHCN, setQHCN] = useState();
  const [DHCN, setDHCN] = useState();
  const [TNNN, setTNNN] = useState();
  const [TGC, setTGC] = useState();
  const [BBDT, setBBDT] = useState();
  const [TTSK, setTTSK] = useState();
  const [LY, setLY] = useState();
  const [BT, setBT] = useState();
  const [NM, setNM] = useState();
  const [lhkcE, setLhkcE] = useState();
  const [SKY, setSKY] = useState();
  const [FB, setFB] = useState();
  const [ECN, setECN] = useState();
  const [NHANG, setNHANG] = useState();
  const [ATM, setATM] = useState();
  const [TTRU, setTTRU] = useState();
  const [DTNR, setDTNR] = useState();
  const [BHYT, setBHYT] = useState();
  const [BHXH, setBHXH] = useState();
  const [NCHC, setNCHC] = useState();
  const [HC, setHC] = useState();
  const [DTK, setDTK] = useState();

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
    setShowEsc(false);
  };

  //const idCode = "NV0001";
  const [rsId, setRsId] = useState();
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
          if (response.quanNhan !== "Không") {
            setCheckedSoldier(true);
          }
          if (response.laConChinhSach == true) {
            setPolicy(true);
          }
          if (response.laThuongBinh == true) {
            setVeterans(true);
          }
          if (response.trangThaiLaoDong == "Đã nghỉ việc") {
            setResignation(true);
          }
          setLDN(response.lyDoNghiViec);
          setNCCND(response.ngachCongChucNoiDung);
          setNTG(response.noiThamGia);
          setQHCN(response.quanHamCaoNhat);
          setDHCN(response.danhHieuCaoNhat);
          setTNNN(response.thanNhanNuocNgoai);
          setTGC(response.thamGiaChinhTri);
          setBBDT(response.biBatDiTu);
          setTTSK(response.ytTinhTrangSucKhoe);
          setLY(response.ytLuuY);
          setBT(response.ytBenhTat);
          setNM(response.ytNhomMau);
          setLhkcE(response.lhkcEmail);
          setSKY(response.skype);
          setFB(response.facebook);
          setECN(response.email);
          setNHANG(response.nganHang);
          setATM(response.atm);
          setTTRU(response.tamTru);
          setDTNR(response.dienThoai);
          setBHYT(response.bhyt);
          setBHXH(response.bhxh);
          setNCHC(response.noiCapHoChieu);
          setHC(response.hoChieu);
          setDTK(response.dienThoaiKhac);
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
      if (id === undefined) {
        const responseAllId = await ProductApi.getAllNv();
        setAllIdEm(responseAllId);
        const idIncre =
          responseAllId !== null
            ? responseAllId[responseAllId.length - 1].id
            : undefined;
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
      }
    };
    handleId();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataDetailEmployee, allIdEm]);

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
    resetField,
    getValues,
    formState: { errors },
    clearErrors,
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
    setFile({
      file: e.fileList.length !== 0 ? e.file : null,
      path:
        e.fileList.length !== 0
          ? URL.createObjectURL(e.file)
          : "/Images/userIcon.png",
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
      //"dienThoai",
      // "dienThoaiKhac",
      "diDong",
      //"email",
      //"facebook",
      //"skype",
      "maSoThue",
      "cccd",
      "noiCapCCCD",
      //"hoChieu",
      //"noiCapHoChieu",
      "noiSinh",
      "queQuan",
      "thuongTru",
      //"tamTru",
      "ngheNghiep",
      "chucVuHienTai",
      "congViecChinh",
      "coQuanTuyenDung",
      //"ngachCongChucNoiDung",
      "vaoDang",
      "quanNhan",
      // "quanHamCaoNhat",
      //"danhHieuCaoNhat",
      //"noiThamGia",
      "laThuongBinh",
      "laConChinhSach",
      "thuongBinh",
      "conChinhSach",
      //"bhxh",
      //"bhyt",
      //"atm",
      //"nganHang",
      "trangThaiLaoDong",
      "tinhChatLaoDong",
      "idDanhMucHonNhan",
      "idDanToc",
      "idTonGiao",
      "idNgachCongChuc",
      //"yt_nhomMau",
      "yt_chieuCao",
      "yt_canNang",
      //"yt_tinhTrangSucKhoe",
      //"yt_benhTat",
      //"yt_luuY",
      "yt_khuyetTat",
      "lhkc_hoTen",
      "lhkc_quanHe",
      "lhkc_dienThoai",
      //"lhkc_email",
      "lhkc_diaChi",
      //"lsbt_biBatDiTu",
      //"lsbt_thamGiaChinhTri",
      //"lsbt_thanNhanNuocNgoai",
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
      //intitalValue.dienThoai,
      //intitalValue.dienThoaiKhac,
      intitalValue.diDong,
      //intitalValue.email,
      //intitalValue.facebook,
      //intitalValue.skype,
      intitalValue.maSoThue,
      intitalValue.cccd,
      intitalValue.noiCapCCCD,
      //intitalValue.hoChieu,
      //intitalValue.noiCapHoChieu,
      intitalValue.noiSinh,
      intitalValue.queQuan,
      intitalValue.thuongTru,
      //intitalValue.tamTru,
      intitalValue.ngheNghiep,
      intitalValue.chucVuHienTai,
      intitalValue.congViecChinh,
      intitalValue.coQuanTuyenDung,
      //intitalValue.ngachCongChucNoiDung,
      intitalValue.vaoDang,
      intitalValue.quanNhan,
      //intitalValue.quanHamCaoNhat,
      //intitalValue.danhHieuCaoNhat,
      //intitalValue.noiThamGia,
      intitalValue.laThuongBinh,
      intitalValue.laConChinhSach,
      intitalValue.thuongBinh,
      intitalValue.conChinhSach,
      //intitalValue.bhxh,
      //intitalValue.bhyt,
      //intitalValue.atm,
      //intitalValue.nganHang,
      intitalValue.trangThaiLaoDong,
      intitalValue.tinhChatLaoDong,
      intitalValue.idDanhMucHonNhan,
      intitalValue.idDanToc,
      intitalValue.idTonGiao,
      intitalValue.idNgachCongChuc,
      //intitalValue.yt_nhomMau,
      intitalValue.yt_chieuCao,
      intitalValue.yt_canNang,
      //intitalValue.yt_tinhTrangSucKhoe,
      //intitalValue.yt_benhTat,
      //intitalValue.yt_luuY,
      intitalValue.yt_khuyetTat,
      intitalValue.lhkc_hoTen,
      intitalValue.lhkc_quanHe,
      intitalValue.lhkc_dienThoai,
      //intitalValue.lhkc_email,
      intitalValue.lhkc_diaChi,
      //intitalValue.lsbt_biBatDiTu,
      //intitalValue.lsbt_thamGiaChinhTri,
      //intitalValue.lsbt_thanNhanNuocNgoai,
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
    if (
      JSON.stringify(values) === JSON.stringify(dfValue) &&
      file.file === null &&
      (LDN == intitalValue.lyDoNghiViec || LDN == undefined) &&
      (NCCND == intitalValue.ngachCongChucNoiDung || NCCND == undefined) &&
      (QHCN == intitalValue.quanHamCaoNhat || QHCN == undefined) &&
      (NTG == intitalValue.noiThamGia || NTG == undefined) &&
      (DTK == intitalValue.dienThoaiKhac || DTK == undefined) &&
      (BHXH == intitalValue.bhxh || BHXH == undefined) &&
      (HC == intitalValue.hoChieu || HC == undefined) &&
      (NCHC == intitalValue.noiCapHoChieu || NCHC == undefined) &&
      (BHYT == intitalValue.bhyt || BHYT == undefined) &&
      (DTNR == intitalValue.dienThoai || DTNR == undefined) &&
      (TTRU == intitalValue.tamTru || TTRU == undefined) &&
      (ATM == intitalValue.atm || ATM == undefined) &&
      (NHANG == intitalValue.nganHang || NHANG == undefined) &&
      (ECN == intitalValue.email || ECN == undefined) &&
      (FB == intitalValue.facebook || FB == undefined) &&
      (SKY == intitalValue.skype || SKY == undefined) &&
      (lhkcE == intitalValue.lhkc_email || lhkcE == undefined) &&
      (NM == intitalValue.yt_nhomMau || NM == undefined) &&
      (BT == intitalValue.yt_benhTat || BT == undefined) &&
      (LY == intitalValue.yt_luuY || LY == undefined) &&
      (TTSK == intitalValue.yt_tinhTrangSucKhoe || TTSK == undefined) &&
      (BBDT == intitalValue.lsbt_biBatDiTu || BBDT == undefined) &&
      (TGC == intitalValue.lsbt_thamGiaChinhTri || TGC == undefined) &&
      (TNNN == intitalValue.lsbt_thanNhanNuocNgoai || TNNN == undefined) &&
      (DHCN == intitalValue.danhHieuCaoNhat || DHCN == undefined)
    ) {
      return true;
    }
    return false;
  };

  //get data from form
  const onHandleSubmit = async (data) => {
    if (
      data.ngayCapCCCD !== null &&
      data.ngayCapCCCD !== undefined &&
      data.ngaySinh >= data.ngayCapCCCD
    ) {
      error("Ngày cấp CCCD không được xảy ra trước ngày sinh.");
    } else if (
      data.ngayCapCCCD !== null &&
      data.ngayCapCCCD !== undefined &&
      data.ngayHetHanCCCD !== null &&
      data.ngayHetHanCCCD !== undefined &&
      moment(data.ngayCapCCCD) >= moment(data.ngayHetHanCCCD)
    ) {
      error("Ngày cấp CCCD không được xảy ra sau ngày hết hạn CCCD.");
    } else if (
      data.ngayCapHoChieu !== null &&
      data.ngayCapHoChieu !== undefined &&
      data.ngaySinh >= data.ngayCapHoChieu
    ) {
      error("Ngày chấp hộ chiếu không được xảy ra trước ngày sinh.");
    } else if (
      data.ngayCapHoChieu !== null &&
      data.ngayCapHoChieu !== undefined &&
      data.ngayHetHanHoChieu !== null &&
      data.ngayHetHanHoChieu !== undefined &&
      moment(data.ngayCapHoChieu) >= moment(data.ngayHetHanHoChieu)
    ) {
      error("Ngày cấp hộ chiếu không được xảy ra sau ngày hết hạn hộ chiếu.");
    } else if (
      data.ngayTuyenDung !== null &&
      data.ngayTuyenDung !== undefined &&
      data.ngaySinh >= data.ngayTuyenDung
    ) {
      error("Ngày tuyển dụng không được xảy ra trước ngày sinh.");
    } else if (
      data.ngayTuyenDung !== null &&
      data.ngayTuyenDung !== undefined &&
      data.ngayThuViec !== null &&
      data.ngayThuViec !== undefined &&
      data.ngayTuyenDung > data.ngayThuViec
    ) {
      error("Ngày thử việc không được xảy ra trước ngày tuyển dụng.");
    } else if (
      data.ngayTuyenDung !== null &&
      data.ngayTuyenDung !== undefined &&
      data.ngayChinhThuc !== null &&
      data.ngayChinhThuc !== undefined &&
      data.ngayTuyenDung > data.ngayChinhThuc
    ) {
      error("Ngày chính thưc không được xảy ra trước ngày ngày tuyển dụng.");
    } else if (
      data.ngayThuViec !== null &&
      data.ngayThuViec !== undefined &&
      data.ngayVaoBan !== null &&
      data.ngayVaoBan !== undefined &&
      data.ngayThuViec > data.ngayVaoBan
    ) {
      error("Ngày vào ban không được xảy ra trước ngày thử việc.");
    } else if (
      data.ngayVaoDoan !== null &&
      data.ngayVaoDoan !== undefined &&
      data.ngaySinh >= data.ngayVaoDoan
    ) {
      error("Ngày vào đoàn không được xảy ra trước ngày sinh.");
    } else if (
      data.ngayVaoDang !== null &&
      data.ngayVaoDang !== undefined &&
      data.ngaySinh >= data.ngayVaoDang
    ) {
      error("Ngày vào đảng không được xảy ra trước ngày sinh.");
    } else if (
      data.ngayVaoDang !== null &&
      data.ngayVaoDang !== undefined &&
      data.ngayVaoDoan !== null &&
      data.ngayVaoDoan !== undefined &&
      moment(data.ngayVaoDoan) >= moment(data.ngayVaoDang)
    ) {
      error("Ngày vào Đảng không được xảy ra trước ngày vào Đoàn.");
    } else if (
      data.ngayVaoDang !== null &&
      data.ngayVaoDang !== undefined &&
      data.ngayVaoDangChinhThuc !== null &&
      data.ngayVaoDangChinhThuc !== undefined &&
      moment(data.ngayVaoDang) >= moment(data.ngayVaoDangChinhThuc)
    ) {
      error("Ngày vào Đảng chính thức không được xảy ra trước ngày vào Đảng.");
    } else if (
      data.ngayNhapNgu !== null &&
      data.ngayNhapNgu !== undefined &&
      data.ngaySinh >= data.ngayNhapNgu
    ) {
      error("Ngày nhập ngũ không được xảy ra trước ngày sinh.");
    } else if (
      data.ngayNhapNgu !== null &&
      data.ngayNhapNgu !== undefined &&
      data.ngayXuatNgu !== null &&
      data.ngayXuatNgu !== undefined &&
      moment(data.ngayNhapNgu) >= moment(data.ngayXuatNgu)
    ) {
      error("Ngày xuất ngũ không được xảy ra trước ngày nhập ngũ.");
    } else {
      try {
        if (id !== undefined) {
          if (file.size < 20000000) {
            const formData1 = new FormData();
            formData1.append("hoTen", data.hoTen);
            formData1.append("quocTich", data.quocTich);
            formData1.append(
              "ngaySinh",
              data.ngaySinh == "Invalid date" || data.ngaySinh == undefined
                ? null
                : moment(data.ngaySinh).format("MM/DD/YYYY")
            );
            formData1.append("gioiTinh", data.gioiTinh);
            formData1.append("dienThoai", data.dienThoai);
            formData1.append("dienThoaiKhac", data.dienThoaiKhac);
            formData1.append("diDong", data.diDong);
            formData1.append("email", data.email);
            formData1.append("facebook", data.facebook);
            formData1.append("skype", data.skype);
            formData1.append("maSoThue", data.maSoThue);
            formData1.append("cccd", data.cccd);
            formData1.append("noiCapCCCD", data.noiCapCCCD);
            formData1.append(
              "ngayCapCCCD",
              data.ngayCapCCCD == "Invalid date" ||
                data.ngayCapCCCD == undefined
                ? null
                : moment(data.ngayCapCCCD).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayHetHanCCCD",
              data.ngayHetHanCCCD == "Invalid date" ||
                data.ngayHetHanCCCD == undefined
                ? null
                : moment(data.ngayHetHanCCCD).format("MM/DD/YYYY")
            );
            formData1.append("hoChieu", data.hoChieu);
            formData1.append("noiCapHoChieu", data.noiCapHoChieu);
            formData1.append(
              "ngayCapHoChieu",
              data.ngayCapHoChieu == "Invalid date" ||
                data.ngayCapHoChieu == undefined
                ? null
                : moment(data.ngayCapHoChieu).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayHetHanHoChieu",
              data.ngayHetHanHoChieu == "Invalid date" ||
                data.ngayHetHanHoChieu == undefined
                ? null
                : moment(data.ngayHetHanHoChieu).format("MM/DD/YYYY")
            );
            formData1.append("noiSinh", data.noiSinh);
            formData1.append("queQuan", data.queQuan);
            formData1.append("thuongTru", data.thuongTru);
            formData1.append("tamTru", data.tamTru);
            formData1.append("ngheNghiep", data.ngheNghiep);
            formData1.append("chucVuHienTai", data.chucVuHienTai);
            formData1.append(
              "ngayTuyenDung",
              data.ngayTuyenDung == "Invalid date" ||
                data.ngayTuyenDung == undefined
                ? null
                : moment(data.ngayTuyenDung).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayThuViec",
              data.ngayThuViec == "Invalid date" ||
                data.ngayThuViec == undefined
                ? null
                : moment(data.ngayThuViec).format("MM/DD/YYYY")
            );
            formData1.append("congViecChinh", data.congViecChinh);
            formData1.append(
              "ngayChinhThuc",
              data.ngayChinhThuc == "Invalid date" ||
                data.ngayChinhThuc == undefined
                ? null
                : moment(data.ngayChinhThuc).format("MM/DD/YYYY")
            );
            formData1.append("coQuanTuyenDung", data.coQuanTuyenDung);
            formData1.append("ngachCongChucNoiDung", data.ngachCongChucNoiDung);
            formData1.append("vaoDang", data.vaoDang);
            formData1.append(
              "ngayVaoDang",
              data.ngayVaoDang == "Invalid date" ||
                data.ngayVaoDang == undefined
                ? null
                : moment(data.ngayVaoDang).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayVaoDangChinhThuc",
              data.ngayVaoDangChinhThuc == "Invalid date" ||
                data.ngayVaoDangChinhThuc == undefined
                ? null
                : moment(data.ngayVaoDangChinhThuc).format("MM/DD/YYYY")
            );
            formData1.append("quanNhan", data.quanNhan);
            formData1.append(
              "ngayNhapNgu",
              data.ngayNhapNgu == "Invalid date" ||
                data.ngayNhapNgu == undefined
                ? null
                : moment(data.ngayNhapNgu).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayXuatNgu",
              data.ngayXuatNgu == "Invalid date" ||
                data.ngayXuatNgu == undefined
                ? null
                : moment(data.ngayXuatNgu).format("MM/DD/YYYY")
            );
            formData1.append("quanHamCaoNhat", data.quanHamCaoNhat);
            formData1.append("danhHieuCaoNhat", data.danhHieuCaoNhat);
            formData1.append(
              "ngayVaoDoan",
              data.ngayVaoDoan == "Invalid date" ||
                data.ngayVaoDoan == undefined
                ? null
                : moment(data.ngayVaoDoan).format("MM/DD/YYYY")
            );
            formData1.append("noiThamGia", data.noiThamGia);
            formData1.append("laThuongBinh", data.laThuongBinh);
            formData1.append("laConChinhSach", data.laConChinhSach);
            formData1.append("thuongBinh", data.thuongBinh);
            formData1.append("conChinhSach", data.conChinhSach);
            formData1.append("bhxh", data.bhxh);
            formData1.append("bhyt", data.bhyt);
            formData1.append("atm", data.atm);
            formData1.append("nganHang", data.nganHang);
            formData1.append("trangThaiLaoDong", data.trangThaiLaoDong);
            formData1.append(
              "ngayNghiViec",
              data.ngayNghiViec == "Invalid date" ||
                data.ngayNghiViec == undefined
                ? null
                : moment(data.ngayNghiViec).format("MM/DD/YYYY")
            );
            formData1.append("lyDoNghiViec", data.lyDoNghiViec);
            formData1.append("tinhChatLaoDong", data.tinhChatLaoDong);
            formData1.append("idDanhMucHonNhan", data.idDanhMucHonNhan);
            formData1.append("idDanToc", data.idDanToc);
            formData1.append("idTonGiao", data.idTonGiao);
            formData1.append("idNgachCongChuc", data.idNgachCongChuc);
            formData1.append("yt_nhomMau", data.yt_nhomMau);
            formData1.append("yt_chieuCao", data.yt_chieuCao);
            formData1.append("yt_canNang", data.yt_canNang);
            formData1.append("yt_tinhTrangSucKhoe", data.yt_tinhTrangSucKhoe);
            formData1.append("yt_benhTat", data.yt_benhTat);
            formData1.append("yt_luuY", data.yt_luuY);
            formData1.append("yt_khuyetTat", data.yt_khuyetTat);
            // formData1.append("yt_maNhanVien", data.yt_maNhanVien);
            formData1.append("lhkc_hoTen", data.lhkc_hoTen);
            formData1.append("lhkc_quanHe", data.lhkc_quanHe);
            formData1.append("lhkc_dienThoai", data.lhkc_dienThoai);
            formData1.append("lhkc_email", data.lhkc_email);
            formData1.append("lhkc_diaChi", data.lhkc_diaChi);
            // formData1.append("lhkc_maNhanVien", data.lhkc_maNhanVien);
            formData1.append("lsbt_biBatDiTu", data.lsbt_biBatDiTu);
            formData1.append("lsbt_thamGiaChinhTri", data.lsbt_thamGiaChinhTri);
            formData1.append(
              "lsbt_thanNhanNuocNgoai",
              data.lsbt_thanNhanNuocNgoai
            );
            // formData1.append("lsbt_maNhanVien", data.lsbt_maNhanVien);
            await PutApi.PutNV(formData1, id);
            await ProductApi.PostLS({
              tenTaiKhoan: decoded.userName,
              thaoTac: `Sửa thông tin của nhân viên ${dataDetailEmployee.hoTen}`,
              maNhanVien: decoded.id,
              tenNhanVien: decoded.givenName,
            });
            if (file.file !== null) {
              await DeleteApi.deleteANV(data.id);
              const formDataImg = new FormData();
              formDataImg.append("anh", file.file);
              formDataImg.append("maNhanVien", data.id);
              await PutApi.PutIMG(formDataImg, data.id);
            }
            history.goBack();
          } else {
            error("Không thể upload file quá 20M");
          }
        } else {
          if (file.size < 20000000) {
            const formData1 = new FormData();
            formData1.append("id", data.id);
            formData1.append("hoTen", data.hoTen);
            formData1.append("quocTich", data.quocTich);
            formData1.append(
              "ngaySinh",
              data.ngaySinh == "Invalid date" || data.ngaySinh == undefined
                ? null
                : moment(data.ngaySinh).format("MM/DD/YYYY")
            );
            formData1.append("gioiTinh", data.gioiTinh);
            formData1.append("dienThoai", data.dienThoai);
            formData1.append("dienThoaiKhac", data.dienThoaiKhac);
            formData1.append("diDong", data.diDong);
            formData1.append("email", data.email);
            formData1.append("facebook", data.facebook);
            formData1.append("skype", data.skype);
            formData1.append("maSoThue", data.maSoThue);
            formData1.append("cccd", data.cccd);
            formData1.append("noiCapCCCD", data.noiCapCCCD);
            formData1.append(
              "ngayCapCCCD",
              data.ngayCapCCCD == "Invalid date" ||
                data.ngayCapCCCD == undefined
                ? null
                : moment(data.ngayCapCCCD).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayHetHanCCCD",
              data.ngayHetHanCCCD == "Invalid date" ||
                data.ngayHetHanCCCD == undefined
                ? null
                : moment(data.ngayHetHanCCCD).format("MM/DD/YYYY")
            );
            formData1.append("hoChieu", data.hoChieu);
            formData1.append("noiCapHoChieu", data.noiCapHoChieu);
            formData1.append(
              "ngayCapHoChieu",
              data.ngayCapHoChieu == "Invalid date" ||
                data.ngayCapHoChieu == undefined
                ? null
                : moment(data.ngayCapHoChieu).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayHetHanHoChieu",
              data.ngayHetHanHoChieu == "Invalid date" ||
                data.ngayHetHanHoChieu == undefined
                ? null
                : moment(data.ngayHetHanHoChieu).format("MM/DD/YYYY")
            );
            formData1.append("noiSinh", data.noiSinh);
            formData1.append("queQuan", data.queQuan);
            formData1.append("thuongTru", data.thuongTru);
            formData1.append("tamTru", data.tamTru);
            formData1.append("ngheNghiep", data.ngheNghiep);
            formData1.append("chucVuHienTai", data.chucVuHienTai);
            formData1.append(
              "ngayTuyenDung",
              data.ngayTuyenDung == "Invalid date" ||
                data.ngayTuyenDung == undefined
                ? null
                : moment(data.ngayTuyenDung).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayThuViec",
              data.ngayThuViec == "Invalid date" ||
                data.ngayThuViec == undefined
                ? null
                : moment(data.ngayThuViec).format("MM/DD/YYYY")
            );
            formData1.append("congViecChinh", data.congViecChinh);
            formData1.append(
              "ngayChinhThuc",
              data.ngayChinhThuc == "Invalid date" ||
                data.ngayChinhThuc == undefined
                ? null
                : moment(data.ngayChinhThuc).format("MM/DD/YYYY")
            );
            formData1.append("coQuanTuyenDung", data.coQuanTuyenDung);
            formData1.append("ngachCongChucNoiDung", data.ngachCongChucNoiDung);
            formData1.append("vaoDang", data.vaoDang);
            formData1.append(
              "ngayVaoDang",
              data.ngayVaoDang == "Invalid date" ||
                data.ngayVaoDang == undefined
                ? null
                : moment(data.ngayVaoDang).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayVaoDangChinhThuc",
              data.ngayVaoDangChinhThuc == "Invalid date" ||
                data.ngayVaoDangChinhThuc == undefined
                ? null
                : moment(data.ngayVaoDangChinhThuc).format("MM/DD/YYYY")
            );
            formData1.append("quanNhan", data.quanNhan);
            formData1.append(
              "ngayNhapNgu",
              data.ngayNhapNgu == "Invalid date" ||
                data.ngayNhapNgu == undefined
                ? null
                : moment(data.ngayNhapNgu).format("MM/DD/YYYY")
            );
            formData1.append(
              "ngayXuatNgu",
              data.ngayXuatNgu == "Invalid date" ||
                data.ngayXuatNgu == undefined
                ? null
                : moment(data.ngayXuatNgu).format("MM/DD/YYYY")
            );
            formData1.append("quanHamCaoNhat", data.quanHamCaoNhat);
            formData1.append("danhHieuCaoNhat", data.danhHieuCaoNhat);
            formData1.append(
              "ngayVaoDoan",
              data.ngayVaoDoan == "Invalid date" ||
                data.ngayVaoDoan == undefined
                ? null
                : moment(data.ngayVaoDoan).format("MM/DD/YYYY")
            );
            formData1.append("noiThamGia", data.noiThamGia);
            formData1.append("laThuongBinh", data.laThuongBinh);
            formData1.append("laConChinhSach", data.laConChinhSach);
            formData1.append("thuongBinh", data.thuongBinh);
            formData1.append("conChinhSach", data.conChinhSach);
            formData1.append("bhxh", data.bhxh);
            formData1.append("bhyt", data.bhyt);
            formData1.append("atm", data.atm);
            formData1.append("nganHang", data.nganHang);
            formData1.append("trangThaiLaoDong", data.trangThaiLaoDong);
            formData1.append(
              "ngayNghiViec",
              data.ngayNghiViec == "Invalid date" ||
                data.ngayNghiViec == undefined
                ? null
                : moment(data.ngayNghiViec).format("MM/DD/YYYY")
            );
            formData1.append("lyDoNghiViec", data.lyDoNghiViec);
            formData1.append("tinhChatLaoDong", data.tinhChatLaoDong);
            formData1.append("idDanhMucHonNhan", data.idDanhMucHonNhan);
            formData1.append("idDanToc", data.idDanToc);
            formData1.append("idTonGiao", data.idTonGiao);
            formData1.append("idNgachCongChuc", data.idNgachCongChuc);
            formData1.append("yt_nhomMau", data.yt_nhomMau);
            formData1.append("yt_chieuCao", data.yt_chieuCao);
            formData1.append("yt_canNang", data.yt_canNang);
            formData1.append("yt_tinhTrangSucKhoe", data.yt_tinhTrangSucKhoe);
            formData1.append("yt_benhTat", data.yt_benhTat);
            formData1.append("yt_luuY", data.yt_luuY);
            formData1.append("yt_khuyetTat", data.yt_khuyetTat);
            formData1.append("yt_maNhanVien", data.yt_maNhanVien);
            formData1.append("lhkc_hoTen", data.lhkc_hoTen);
            formData1.append("lhkc_quanHe", data.lhkc_quanHe);
            formData1.append("lhkc_dienThoai", data.lhkc_dienThoai);
            formData1.append("lhkc_email", data.lhkc_email);
            formData1.append("lhkc_diaChi", data.lhkc_diaChi);
            formData1.append("lhkc_maNhanVien", data.lhkc_maNhanVien);
            formData1.append("lsbt_biBatDiTu", data.lsbt_biBatDiTu);
            formData1.append("lsbt_thamGiaChinhTri", data.lsbt_thamGiaChinhTri);
            formData1.append(
              "lsbt_thanNhanNuocNgoai",
              data.lsbt_thanNhanNuocNgoai
            );
            formData1.append("lsbt_maNhanVien", data.lsbt_maNhanVien);
            await ProductApi.postNv(formData1);
            await ProductApi.PostLS({
              tenTaiKhoan: decoded.userName,
              thaoTac: `Thêm nhân viên mới${data.hoTen}`,
              maNhanVien: decoded.id,
              tenNhanVien: decoded.givenName,
            });
            if (file.file !== null) {
              const formDataImg = new FormData();
              formDataImg.append("anh", file.file);
              formDataImg.append("maNhanVien", data.id);
              await PutApi.PutIMG(formDataImg, data.id);
            }
            success(`Thêm hồ sơ nhân viên ${data.hoTen} thành công`);
            history.goBack();
          } else {
            error("Không thể upload file quá 20M");
          }
        }
      } catch (errors) {
        console.log(errors);
      }
    }
  };

  //handle image

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
          <form action="" class="profile-form">
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
                        : `http://localhost:8000/${dataDetailEmployee.anh}`
                      : file.path
                  }
                  className="icon"
                  alt=""
                />
              </span>

              <Upload
                beforeUpload={() => false}
                onChange={handleChange}
                maxCount={1}
                accept=".jpg,.png,.pdf"
              >
                <Button icon={<UploadOutlined />}>Chọn thư mục</Button>
              </Upload>
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
                      {...register("atm", {
                        onChange: (e) => setATM(e.target.value),
                      })}
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
                      {...register("nganHang", {
                        onChange: (e) => setNHANG(e.target.value),
                      })}
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
                      {...register("tamTru", {
                        onChange: (e) => setTTRU(e.target.value),
                      })}
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
                      {...register("bhyt", {
                        onChange: (e) => setBHYT(e.target.value),
                      })}
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
                      {...register("bhxh", {
                        onChange: (e) => setBHXH(e.target.value),
                      })}
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
                      {...register("hoChieu", {
                        onChange: (e) => setHC(e.target.value),
                      })}
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
                      htmlFor="noiCapHoChieu"
                    >
                      Nơi cấp hộ chiếu
                    </label>
                    <input
                      type="text"
                      {...register("noiCapHoChieu", {
                        onChange: (e) => setNCHC(e.target.value),
                      })}
                      id="noiCapHoChieu"
                      className={
                        !errors.noiCapHoChieu
                          ? "form-control col-sm-6 "
                          : "form-control col-sm-6 border-danger"
                      }
                    />
                    <span className="message">
                      {errors.noiCapHoChieu?.message}
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
                      {...register("email", {
                        onChange: (e) => setECN(e.target.value),
                      })}
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
                      {...register("dienThoaiKhac", {
                        onChange: (e) => setDTK(e.target.value),
                      })}
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
                      {...register("facebook", {
                        onChange: (e) => setFB(e.target.value),
                      })}
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
                      {...register("dienThoai", {
                        onChange: (e) => setDTNR(e.target.value),
                      })}
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
                      {...register("skype", {
                        onChange: (e) => setSKY(e.target.value),
                      })}
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
                      {...register("lhkc_email", {
                        onChange: (e) => setLhkcE(e.target.value),
                      })}
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
                      Lý do nghỉ việc
                    </label>
                    <input
                      type="text"
                      {...register("lyDoNghiViec", {
                        onChange: (e) => setLDN(e.target.value),
                      })}
                      id="lyDoNghiViec"
                      className={
                        !errors.lyDoNghiViec
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      disabled={!resignation}
                    />
                    <span className="message">
                      {errors.lyDoNghiViec?.message}
                    </span>
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
                    <span className="message">
                      {errors.ngayNghiViec?.message}
                    </span>
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
                      {...register("ngachCongChucNoiDung", {
                        onChange: (e) => setNCCND(e.target.value),
                      })}
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
                      {...register("noiThamGia", {
                        onChange: (e) => setNTG(e.target.value),
                      })}
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
                        onChange: (e) => {
                          if (e.target.checked === false) {
                            clearErrors([
                              "ngayVaoDang",
                              "ngayVaoDangChinhThuc",
                            ]);
                            resetField("ngayVaoDang", { defaultValue: null });
                            resetField("ngayVaoDangChinhThuc", {
                              defaultValue: null,
                            });
                          }
                        },
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
                            setEndDate(event);
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
                      {...register("quanNhan", {
                        onChange: (e) => {
                          if (e.target.checked === false) {
                            clearErrors(["ngayNhapNgu", "ngayXuatNgu"]);
                            resetField("ngayNhapNgu", { defaultValue: null });
                            resetField("ngayXuatNgu", { defaultValue: null });
                            resetField("quanHamCaoNhat", {
                              defaultValue: null,
                            });
                            resetField("danhHieuCaoNhat", {
                              defaultValue: null,
                            });
                          }
                        },
                      })}
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
                      {...register("laThuongBinh", {
                        onChange: (e) => {
                          if (e.target.checked === false) {
                            clearErrors("thuongBinh");
                            resetField("thuongBinh", { defaultValue: null });
                          }
                        },
                      })}
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
                    <span className="message">
                      {errors.ngayNhapNgu?.message}
                    </span>
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
                    <span className="message">
                      {errors.ngayXuatNgu?.message}
                    </span>
                  </div>
                </div>
                <div className="col">
                  <div className="form-check form-inline">
                    <input
                      type="checkbox"
                      {...register("laConChinhSach", {
                        onChange: (e) => {
                          if (e.target.checked === false) {
                            clearErrors("conChinhSach");
                            resetField("conChinhSach", { defaultValue: null });
                          }
                        },
                      })}
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
                      {...register("quanHamCaoNhat", {
                        onChange: (e) => setQHCN(e.target.value),
                      })}
                      id="quanHamCaoNhat"
                      className={
                        !errors.quanHamCaoNhat
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      disabled={!checkedSoldier}
                    />
                    <span className="message">
                      {errors.quanHamCaoNhat?.message}
                    </span>
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
                      className={
                        !errors.conChinhSach
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      disabled={!policy}
                    />
                    <span className="message">
                      {errors.conChinhSach?.message}
                    </span>
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
                      {...register("danhHieuCaoNhat", {
                        onChange: (e) => setDHCN(e.target.value),
                      })}
                      id="danhHieuCaoNhat"
                      className={
                        !errors.danhHieuCaoNhat
                          ? "form-control col-sm-6"
                          : "form-control col-sm-6 border-danger"
                      }
                      disabled={!checkedSoldier}
                    />
                    <span className="message">
                      {errors.danhHieuCaoNhat?.message}
                    </span>
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
                      {...register("yt_nhomMau", {
                        onChange: (e) => setNM(e.target.value),
                      })}
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
                      {...register("yt_benhTat", {
                        onChange: (e) => setBT(e.target.value),
                      })}
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
                      Chiều cao(m)
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
                      {...register("yt_luuY", {
                        onChange: (e) => setLY(e.target.value),
                      })}
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
                      {...register("yt_tinhTrangSucKhoe", {
                        onChange: (e) => setTTSK(e.target.value),
                      })}
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
                      {...register("lsbt_biBatDiTu", {
                        onChange: (e) => setBBDT(e.target.value),
                      })}
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
                      {...register("lsbt_thamGiaChinhTri", {
                        onChange: (e) => setTGC(e.target.value),
                      })}
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
                      {...register("lsbt_thanNhanNuocNgoai", {
                        onChange: (e) => setTNNN(e.target.value),
                      })}
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

export default AddProfileForm;
