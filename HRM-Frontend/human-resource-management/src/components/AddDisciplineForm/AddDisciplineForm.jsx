import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import { useLocation } from "react-router";
import ProductApi from "../../api/productApi";
import PutApi from "../../api/putAAPI";
import DeleteApi from "../../../src/api/deleteAPI";
//import { DatePicker } from "antd";

const regexDate = /^[0-9]{2}[\/]{1}[0-9]{2}[\/]{1}[0-9]{4}$/g;
const schema = yup.object({
  idDanhMucKhenThuong: yup.number().required("Loại khen thưởng không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  //thoiGian: yup.string().required("Thời gian không được bỏ trống."),
  noiDung: yup.string().required("Nội dung không được bỏ trống."),
  lyDo: yup.string().required("Lý do không được bỏ trống."),
  loai:yup.boolean()
});

function AddDisciplineForm(props) {
  // const { objectData } = props;
  let { match, history } = props;
  let { id } = match.params;
  let location = useLocation();
  let query = new URLSearchParams(location.search);
  console.log(query.get("maNhanVien"));
  console.log(query.get("hoVaTen"));
  const [dataKLDetail, setDataKLDetail] = useState([]);
  const [dataKL,setDataKL] = useState([]);
  console.log(id);
  
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMKL();
        setDataKL(response);
        if (id !== undefined) {
          const responseKT = await ProductApi.getKTvKLDetail(id);
          setDataKLDetail(responseKT);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue ={
    maNhanVien:id!==undefined?dataKLDetail.maNhanVien:null,
    idDanhMucKhenThuong:id!==undefined?dataKLDetail.idDanhMucKhenThuong:null,
    noiDung:id!==undefined?dataKLDetail.noiDung:null,
    lyDo:id!==undefined?dataKLDetail.lyDo:null,
    anh:id!==undefined?dataKLDetail.anh:null,
    loai:false,
  }

  const {
    register,
    handleSubmit,
    control,
    reset,
    formState: { errors },
  } = useForm({
    defaultValues:intitalValue,
    resolver: yupResolver(schema),
  });
  useEffect(() => {
    if (dataKLDetail) {
      reset(intitalValue);
    }
  }, [dataKLDetail]);

  const onHandleSubmit = async(data) => {
    console.log(data);
    try {
      if(id !== undefined){
        await PutApi.PutKTvKL(data,id);
      }else{
        await ProductApi.PostKTvKL(data);
      }
      history.goBack();
    } catch (error) {
      console.log("errors",error);
    }
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteKTvKL(id);
      history.push(`/reward`);
    } catch (error) {}
  };
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">{dataKLDetail.length !== 0 ?"Sửa":"Thêm"} thủ tục kỷ luật</h2>
        </div>
        <div className="button">
        <input
              type="submit"
              className={
                dataKLDetail.length !== 0 ? "btn btn-danger" : "delete-button"
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
            value={dataKLDetail.length !== 0 ?"Sửa":"Lưu"}
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
                />
                <span className="message">{errors.maNhanVien?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="anh">
                  Ảnh
                </label>
                <input
                  type="text"
                  {...register("anh")}
                  id="anh"
                  className={
                    !errors.anh
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.anh?.message}</span>
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
                <label class="col-sm-4 justify-content-start" htmlFor="noiDung">
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
  );
}

export default AddDisciplineForm;
