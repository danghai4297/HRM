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

const schema = yup.object({
  trangThai: yup.boolean(),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  idLoaiHopDong: yup.number().required("Loại hợp đồng không được bỏ trống."),
  idChucDanh: yup.number().required("Chức danh không được bỏ trống."),
  maHopDong: yup.string().required("Lương cơ bản không được bỏ trống."),
});
function AddContractForm(props) {
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  let { match, history } = props;
  let { id } = match.params;
  console.log(id);

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
          const responseHD = await ProductApi.getHdDetail(id);
          setdataDetailHd(responseHD);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue = {
    maNhanVien: id !== undefined ? dataDetailHd.maNhanVien : null,
    idChucDanh: id !== undefined ? dataDetailHd.idChucDanh : null,
    idLoaiHopDong: id !== undefined ? dataDetailHd.idLoaiHopDong : null,
    hopDongTuNgay: dataDetailHd.hopDongTuNgay,
    hopDongDenNgay: dataDetailHd.hopDongDenNgay,
    ghiChu: id !== undefined ? dataDetailHd.ghiChu : null,
    maHopDong: id !== undefined ? dataDetailHd.id : null,
    trangThai: id !== undefined ? dataDetailHd.trangThai === "Kích hoạt" : true,
  };
  console.log(intitalValue);

  const {
    register,
    handleSubmit,
    control,
    reset,
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
  const onHandleSubmit = async (data) => {
    console.log(data);
    try {
      if (id !== undefined) {
        await PutApi.PutHD(data, id);
      } else {
        if (query.get("checkMaHopDong") !== "0") {
          await PutApi.PutTLL(query.get("maHopDong"));
          await PutApi.PutTLHD(query.get("maNhanVien"));
        }
        await ProductApi.postHD(data);
      }
      history.goBack();
    } catch (error) {
      console.log("errors", error);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteHD(id);
      history.push(`/contract`);
    } catch (error) {}
  };
  return (
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
            onClick={handleDelete}
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
            onClick={handleSubmit(onHandleSubmit)}
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
                      value={moment(field.value)}
                      onChange={(event) => {
                        field.onChange(event.toDate());
                      }}
                      {...field._d}
                    />
                  )}
                />
                <span className="message">{errors.hopDongTuNgay?.message}</span>
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
                      value={moment(field.value)}
                      onChange={(event) => {
                        field.onChange(event.toDate());
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
                <label class="col-sm-4 justify-content-start" htmlFor="ghiChu">
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
  );
}

export default AddContractForm;
