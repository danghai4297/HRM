import React from "react";
import "./AddProfileForm.scss";
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
const phoneRex = /([\|84|0]+(3|5|7|8|9|1[2|6|8|9]))+([0-9]{8})\b/;
const number = /^\d+$/;
const schema = yup.object({
  // id: yup.string().required("Mã nhân viên không được bỏ trống."),
  // hoTen: yup.string().required("Họ và tên không được bỏ trống."),
  gioiTinh: yup.boolean().required("Giới tính không được bỏ trống."),
  idDanhMucHonNhan: yup.number().required("Hôn nhân không được bỏ trống."),
  // ngaySinh: yup.date().required("Ngày sinh không được bỏ trống."),
  // noiSinh: yup.string().required("Nơi sinh không được bỏ trống."),
  idDanToc: yup.number().required("Dân Tộc không được bỏ trống."),
  // queQuan: yup.string().required("Nguyên quán không được bỏ trống."),
  idTonGiao: yup.number().required("Tôn giáo không được bỏ trống."),
  // thuongTru: yup.string().required("HK thường trú không được bỏ trống."),
  // quocTich: yup.string().required("Quốc tịch không được bỏ trống."),
  // tamTru: yup.string().required("Tạm trú không được bỏ trống."),
  // cccd: yup
  //   .string()
  //   .matches(number, "CMND/CCCD không được bỏ trống.")
  //   .min(9, "CMND phải có 9 số/CCCD phải có 12 số")
  //   .max(12, "CMND phải có 9 số,CCCD phải có 12 số")
  //   .required(),
  // ngayCapCCCD: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayCapHoChieu: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayChinhThuc: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // //ngayVaoDoan: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayThuViec: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayVaoBan: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayVaoDang: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayVaoDangChinhThuc: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // ngayXuatNgu: yup.date().required("Ngày cấp CMND/CCCD không được bỏ trống."),
  // noiCapCCCD: yup.string().required("Nơi cấp CMND/CCCD không được bỏ trống."),
  // ngayNhapNgu: yup.date().required("Nơi cấp CMND/CCCD không được bỏ trống."),
  // ngayHetHanHoChieu: yup.date().required("Nơi cấp CMND/CCCD không được bỏ trống."),
  // ngayHetHanCCCD: yup
  //   .date()
  //   .required("Ngày hết hạn CMND/CCCD không được bỏ trống."),
  // diDong: yup
  //   .string()
  //   .matches(phoneRex, "Số điện thoại không được bỏ trống và là số.")
  //   .required(),
  // lhkc_hoTen: yup.string().required("Họ và tên không được bỏ trống."),
  // lhkc_quanHe: yup.string().required("Quan hệ không được bỏ trống."),
  // lhkc_dienThoai: yup
  //   .string()
  //   .matches(phoneRex, "Số điện thoại không được bỏ trống và là số.")
  //   .required(),
  // lhkc_diaChi: yup.string().required("Địa chỉ không được bỏ trống."),
  // ngheNghiep: yup.string().required("Nghề nghiệp không được bỏ trống."),
  // ngayTuyenDung: yup.date().required("Ngày tuyển dụng không được bỏ trống."),
  // coQuanTuyenDung: yup
  //   .string()
  //   .required("Cơ quan tuyển dụng không được bỏ trống."),
  // chucVuHienTai: yup.string().required("Chức vụ hiện tại không được bỏ trống."),
  trangThaiLaoDong: yup
    .boolean()
    .required("Trạng thái lao động không được bỏ trống."),

  tinhChatLaoDong: yup
    .number()
    .required("Tính chất lao động không được bỏ trống."),
  maSoThue: yup.number().required("Tính chất lao động không được bỏ trống."),
  // congViecChinh: yup
  //   .string()
  //   .required("Tính chất lao động không được bỏ trống."),
  // //phongBan: yup.string().required("Phòng Ban động không được bỏ trống."),
  idNgachCongChuc: yup
    .number()
    .required("Ngạch công chức không được bỏ trống."),
  // lsbt_biBatDiTu: yup
  //   .string()
  //   .required("Lịch sử bản thân không được bỏ trống."),
  // lsbt_thamGiaChinhTri: yup
  //   .string()
  //   .required("Lịch sử bản thân không được bỏ trống."),
  // lsbt_thanNhanNuocNgoai: yup
  //   .string()
  //   .required("Lịch sử bản thân không được bỏ trống."),
  yt_chieuCao: yup.number().required("Ngạch công chức không được bỏ trống."),
  yt_canNang: yup.number().required("Ngạch công chức không được bỏ trống."),
  lsbt_maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  yt_maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  lhkc_maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
});
//.required();

function AddProfileForm(props) {
  const { history } = props;
  //handle checkbox
  const [checkedSoldier, setCheckedSoldier] = useState(false);
  const handleClick = () => setCheckedSoldier(!checkedSoldier);
  const [checkedParty, setChekedParty] = useState(false);
  const handleClickParty = () => setChekedParty(!checkedParty);
  const [veterans, setVeterans] = useState(false);
  const handleClickVeteransy = () => setVeterans(!veterans);
  const [policy, setPolicy] = useState(false);
  const handleClickPolicy = () => setPolicy(!policy);
  //const [date, setDate] = useState(new Date());
  //State contain category
  const [dataMarrige, setDataMarrige] = useState([]);
  const [dataNation, setDataNation] = useState([]);
  const [dataReligion, setDataReligion] = useState([]);
  const [dataCRS, setDataCRS] = useState([]);
  const [dataLabor, setDataLabor] = useState([]);
  const [emCode, setEmCode] = useState("");
  // const intitalValue = {
  //     lsbt_maNhanVien: emCode,
  //      yt_maNhanVien: emCode,
  //     lhkc_maNhanVien: emCode,
  // }
  //console.log(date);
  const {
    register,
    handleSubmit,
    control,
    reset,
    formState: { errors },
  } = useForm({
    // defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });
  // const {
  //   register2,
  // } =  useForm({
  //   // defaultValues: intitalValue,
  //   resolver: yupResolver(schema),
  // });
  const [file, setFile] = useState({
    file: null,
    path: "/Images/userIcon.png"
  });
  const handleChange = (e) => {
    setFile({
    file:  e.target.files[0],
    path: URL.createObjectURL(e.target.files[0])
    });

  };
  
  // useEffect(() => {
  //     reset(intitalValue);
  // }, []);
  //get data form api
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
        // if (id !== undefined) {
        //   // if(checkInputChange === true){
        //   //   setDescription("Bạn chưa thay dổi");
        //   // }
        //   setDescription("Bạn chắc chắn muốm sửa trình độ");
        //   const response = await ProductApi.getTDDetail(id);
        //   setdataDetailTDVH(response);
        // }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  function buildFormData(formData, data, parentKey) {
    if (data && typeof data === 'object' && !(data instanceof Date) && !(data instanceof File)) {
      Object.keys(data).forEach(key => {
        buildFormData(formData, data[key], parentKey ? `${parentKey}[${key}]` : key);
      });
    } else {
      const value = data == null ? '' : data;
  
      formData.append(parentKey, value);
    }
  }
  //get data from form
  const onHandleSubmit = async (data) => {
    console.log(data);

    try {
      const formData = new FormData();
      formData.append("anh",file.file);
      formData.append("maNhanVien",data.id);
      // await ProductApi.postFile(formData);
      await ProductApi.postNv(data);
      await PutApi.PutIMG(formData,data.id);
      history.goBack();
    } catch (error) {}
  };

  console.log(emCode);

  //handle image
  //const [file, setFile] = useState("/Images/userIcon.png");

  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm mới hồ sơ</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className="btn btn-secondary "
            value="Huỷ"
            onClick={history.goBack}
          />
          <input
            type="submit"
            className="btn btn-primary ml-3"
            value="Lưu"
            onClick={handleSubmit(onHandleSubmit)}
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
              <img src={file.path} className="icon" alt="" />
            </span>
            {/* <Controller
              name="anh"
              control={control}
              render={({ field, onChange }) => (
                <Upload
                  beforeUpload={() => false}
                  onChange={(e) => {
                    field.onChange(e);
                  }}
                  {...field}
                >
                  <Button icon={<UploadOutlined />}>Chọn thư mục</Button>
                </Upload>
              )}
            /> */}

            <input
              type="file"
              // {...register2("anh")}
              accept="Images/*"
              class="form-control-file"
              onChange={handleChange}
            ></input>

            {/* <input
            type="text"
            {...register("anh")}
            class="form-control-file"
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
                    className={
                      !errors.id
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    onChange={(e) => setEmCode(e.target.value)}
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
                    className="form-control col-sm-6"
                  />
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                      !errors.danToc
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
                  <label class="col-sm-4 justify-content-start" htmlFor="bhyt">
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
                  />
                  <span className="message">{errors.bhyt?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="bhxh">
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
                  />
                  <span className="message">{errors.maSoThue?.message}</span>
                </div>
              </div>
            </div>
            <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="cccd">
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
                    className="form-control col-sm-6"
                  />
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
                        }}
                        {...field._d}
                      />
                    )}
                  />
                  <span className="message">{errors.ngayCapCCCD?.message}</span>
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                  <span className="message">{errors.noiCapCCCD?.message}</span>
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
                    className="form-control col-sm-6"
                  />
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                  />
                  <span className="message">{errors.diDong?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="email">
                    Email cá nhân
                  </label>
                  <input
                    type="text"
                    {...register("email")}
                    id="email"
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label class="col-sm-4 justify-content-start" htmlFor="skype">
                    Skype
                  </label>
                  <input
                    type="text"
                    {...register("skype")}
                    id="skype"
                    className="form-control col-sm-6"
                  />
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
                  <span className="message">{errors.lhkc_hoTen?.message}</span>
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
                    className="form-control col-sm-6"
                  />
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
                  <span className="message">{errors.lhkc_quanHe?.message}</span>
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
                  <span className="message">{errors.lhkc_diaChi?.message}</span>
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
              type="text"
              {...register("lhkc_maNhanVien")}
              value={emCode}
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
                  <span className="message">{errors.ngheNghiep?.message}</span>
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                    disabled="true"
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
                  <input
                    type="text"
                    {...register("ngayNghiViec")}
                    id="ngayNghiViec"
                    className="form-control col-sm-6"
                    placeholder="DD/MM/YYYY"
                    disabled="true"
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                <div class="form-check mb-2 form-inline">
                  <input
                    type="checkbox"
                    {...register("vaoDang")}
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
                    {...register("NoiThamGia")}
                    id="NoiThamGia"
                    className="form-control col-sm-6"
                  />
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
                        disabled={!checkedParty}
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
                        }}
                        {...field._d}
                      />
                    )}
                  />
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                    className="form-control col-sm-6"
                    disabled={!veterans}
                  />
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
                        value={moment(field.value)}
                        onChange={(event) => {
                          field.onChange(event.toDate());
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
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
                    className="form-control col-sm-6"
                  />
                  <input
                    type="text"
                    {...register("yt_maNhanVien")}
                    value={emCode}
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
                  <label class="justify-content-start" htmlFor="lsbt_biBatDiTu">
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
                        ? "form-control  "
                        : "form-control border-danger"
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
                    class="justify-content-start"
                    htmlFor="thamGiaChinhTri"
                  >
                    Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh tế,
                    xã hội ở nước ngoài
                  </label>
                  <textarea
                    type="text"
                    rows="4"
                    {...register("lsbt_thamGiaChinhTri")}
                    id="lsbt_thamGiaChinhTri"
                    className={
                      !errors.lsbt_thamGiaChinhTri
                        ? "form-control  "
                        : "form-control border-danger"
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
                    class="justify-content-start"
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
                        ? "form-control"
                        : "form-control border-danger"
                    }
                  />
                  <input
                    type="text"
                    {...register("lsbt_maNhanVien")}
                    value={emCode}
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
  );
}

export default AddProfileForm;
