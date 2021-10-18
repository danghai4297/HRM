import React, { useEffect, useState } from "react";
import { Controller, useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddLevelForm.scss";
import DeleteApi from "../../../src/api/deleteAPI";
import PutApi from "../../../src/api/putAAPI";
import ProductApi from "../../../src/api/productApi";
import Dialog from "../../components/Dialog/Dialog";
import { useLocation } from "react-router-dom";
import { DatePicker } from "antd";
import moment from "moment/moment.js";
const schema = yup.object({
  tenTruong: yup.string().required("Tên trường không được bỏ trống."),
  idChuyenMon: yup.number().required("Chuyên môn không được bỏ trống."),
  idHinhThucDaoTao: yup
    .number()
    .required("Hình thức đào tạo không được bỏ trống."),
  idTrinhDo: yup.number().required("Trình độ không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
});
function AddLevelForm(props) {
  let { match, history } = props;
  
  let location = useLocation();
  console.log(location)
  let query = new URLSearchParams(location.search);
  console.log(query.get("maNhanVien"));
  let { id } = match.params;
  //let oldDate = moment().add(10, 'days').calendar();
  let oldDate = moment().toDate();
  // const [date, setDate] = useState({
  //   date: oldDate,
  // });
  const [date, setDate] = useState();
  const handleChangeDate = (e) => {
    console.log(e.target.value);
    setDate({ date: e.target.value });
  };
  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  const [dataDetailTDVH, setdataDetailTDVH] = useState([]);

  const [dataCM, setDataCM] = useState([]);
  const [dataHTDT, setDataHTDT] = useState([]);
  const [dataTD, setDataTD] = useState([]);

  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm trình độ mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  console.log(dataDetailTDVH);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseCM = await ProductApi.getAllDMCM();
        setDataCM(responseCM);
        const responseHTDT = await ProductApi.getAllDMHTDT();
        setDataHTDT(responseHTDT);
        const responseTD = await ProductApi.getAllDMTD();
        setDataTD(responseTD);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốm sửa trình độ");
          const response = await ProductApi.getTDDetail(id);
          setdataDetailTDVH(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const onHandleSubmit = async (data) => {
    console.log(data);

    try {
      if (id !== undefined) {
        await PutApi.PutTDVH(data, id);
      } else {
        await ProductApi.PostTDVH(data);
      }
      history.goBack();
    } catch (error) {}
  };
  const handleDelete = async () => {
    try {
      await DeleteApi.deleteTDVH(id);
      history.goBack();
    } catch (error) {}
  };
  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailTDVH.length !== 0 ? "Sửa" : "Thêm"} trình độ
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailTDVH.length !== 0 ? "btn btn-danger" : "delete-button"
              }
              onClick={() => {
                setShowDeleteDialog(true);
              }}
              value="Xoá"
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
              value={dataDetailTDVH.length !== 0 ? "Sửa" : "Lưu"}
              onClick={handleSubmit(onHandleSubmit)}
            />
          </div>
        </div>
        <form
          action=""
          class="profile-form"
          // onSubmit={handleSubmit(onHandleSubmit)}
        >
          {/* Container thông tin cơ bản */}
          <div className="container-div-form">
            <h3>Thông tin chung</h3>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="maNhanVien"
                  >
                    Mã Nhân Viên
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
                    htmlFor="idChuyenMon"
                  >
                    Chuyên môn
                  </label>
                  <select
                    type="text"
                    {...register("idChuyenMon")}
                    id="idChuyenMon"
                    className={
                      !errors.idChuyenMon
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailTDVH.idChuyenMon}>
                      {dataDetailTDVH.tenChuyenMon}
                    </option>
                    {dataCM.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenChuyenMon}{" "}
                      </option>
                    ))}
                  </select>
                  <span className="message">{errors.idChuyenMon?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline ">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="tenTruong"
                  >
                    Tên trường
                  </label>
                  <input
                    type="text"
                    {...register("tenTruong")}
                    id="tenTruong"
                    className={
                      !errors.tenTruong
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                  />
                  <span className="message">{errors.tenTruong?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idHinhThucDaoTao"
                  >
                    Hình thức đào tạo
                  </label>
                  <select
                    type="text"
                    {...register("idHinhThucDaoTao")}
                    id="idHinhThucDaoTao"
                    className={
                      !errors.idHinhThucDaoTao
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailTDVH.idHinhThucDaoTao}>
                      {dataDetailTDVH.tenHinhThuc}
                    </option>
                    {dataHTDT.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenHinhThuc}{" "}
                      </option>
                    ))}
                  </select>
                  <span className="message">
                    {errors.idHinhThucDaoTao?.message}
                  </span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="idTrinhDo"
                  >
                    Trình độ
                  </label>
                  <select
                    type="text"
                    {...register("idTrinhDo")}
                    id="idTrinhDo"
                    className={
                      !errors.idTrinhDo
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailTDVH.idTrinhDo}>
                      {dataDetailTDVH.trinhDo}
                    </option>
                    {dataTD.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.tenTrinhDo}{" "}
                      </option>
                    ))}
                  </select>
                  <span className="message">{errors.idTrinhDo?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col">
                <div class="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="tuThoiGian"
                  >
                    Từ ngày
                  </label>
                  <input
                  type="text"
                  {...register("tuThoiGian")}
                  id="tuThoiGian"
                  className={
                    !errors.tuThoiGian
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.tuThoiGian?.message}</span>
                  {/* <Controller
                    name="tuThoiGian"
                    control={control}
                    defaultValue=""
                    render={({ field }) => (
                      <DatePicker
                        id="tuThoiGian"
                        className="form-control col-sm-6"
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        //selected={field}
                        //onChange={(field) => setDate(field)}
                        {...field}
                      ></DatePicker>
                    )}
                  /> */}
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    class="col-sm-4 justify-content-start"
                    htmlFor="denThoiGian"
                  >
                    Đến ngày
                  </label>
                  <input
                    type="text"
                    {...register("denThoiGian")}
                    id="denThoiGian"
                    className={
                      !errors.denThoiGian
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    placeholder="DD/MM/YYYY"
                  />
                  <span className="message">{errors.denThoiGian?.message}</span>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
      <Dialog
        show={showDialog}
        title="Thông báo"
        description={description}
        confirm={handleSubmit(onHandleSubmit)}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa trình độ `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLevelForm;
