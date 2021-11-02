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
import DialogCheck from "../Dialog/DialogCheck";
import Dialog from "../../components/Dialog/Dialog";
import { useToast } from "../Toast/Toast";

const schema = yup.object({
  trangThai:yup.boolean(),
  maNhanVien: yup.string().nullable().required("Mã nhân viên không được bỏ trống."),
  idLoaiHopDong: yup.number().nullable().required("Loại hợp đồng không được bỏ trống."),
  idChucDanh: yup.number().nullable().required("Chức danh không được bỏ trống."),
  maHopDong: yup.string().nullable().required("Lương cơ bản không được bỏ trống."),
  hopDongTuNgay: yup.date().nullable().required("Ngày hiệu lực không được bỏ trống"),
  hopDongDenNgay: yup.date().nullable().required("Ngày hết hạn không được bỏ trống")
});
function AddContractForm(props) {
  const { error, warn, info, success } = useToast();

  let { match, history } = props;
  let { id } = match.params;
  
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm hợp đồng mới"
  );
  const [showCheckDialog, setShowCheckDialog] = useState(false);
    const [startDate,setStartDate] = useState();
    const [endDate,setEndDate] = useState();
  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  const [dataDetailHd, setdataDetailHd] = useState([]);
  const [dataHD, setDataHD] = useState([]);
  const [dataCD, setDataCD] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseDMHD = await ProductApi.getAllDMLHD();
        setDataHD(responseDMHD);
        const responseCD = await ProductApi.getAllDMCD();
        setDataCD(responseCD);
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
  
  const intitalValue = {
    maNhanVien: id !== undefined?dataDetailHd.maNhanVien:null,
    idChucDanh: id !== undefined?dataDetailHd.idChucDanh:null,
    idLoaiHopDong: id !== undefined?dataDetailHd.idLoaiHopDong:null,
    hopDongTuNgay:id !== undefined?moment(dataDetailHd.hopDongTuNgay):dataDetailHd.hopDongTuNgay,
    hopDongDenNgay:id !== undefined?moment(dataDetailHd.hopDongDenNgay):dataDetailHd.hopDongDenNgay,
    ghiChu:id!== undefined?dataDetailHd.ghiChu:null,
    maHopDong:id!== undefined?dataDetailHd.id:null,
    trangThai: id!== undefined?(dataDetailHd.trangThai==="Kích hoạt"):true,
  }
  //console.log(intitalValue);
  
  //console.log(date);
  
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
  console.log(dataDetailHd);
  
  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if(id !== undefined){
        await PutApi.PutHD(data,id);
        success(
          `Sửa thông tin hợp đồng cho nhân viên ${dataDetailHd.tenNhanVien} thành công`
        );
      }else{
        await ProductApi.postHD(data);
        success(
          `Sửa thông tin hợp đồng cho nhân viên ${dataDetailHd.tenNhanVien} thành công`
        );
      }
      history.goBack();
    } catch (errors) {
      console.log("errors",error);
      error(`Có lỗi xảy ra ${errors}`);

    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteHD(id);
      success(
        `Xoá thông tin trình độ cho nhân viên ${dataDetailHd.tenNhanVien} thành công`
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
                  type="text"
                  {...register("maNhanVien")}
                  id="maNhanVien"
                  className={
                    !errors.maNhanVien
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />

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
                <span className="message">{errors.idLoaiHopDong?.message}</span>
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
                  className={
                    !errors.maHopDong
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
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
                <input
                        type="text"
                        {...register("trangThai")}
                        //defaultValue={true}
                        style={{ display: "none" }}                      
                      />
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
