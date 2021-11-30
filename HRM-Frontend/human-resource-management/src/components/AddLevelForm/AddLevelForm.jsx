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
import { stringify } from "query-string";
import DialogCheck from "../Dialog/DialogCheck";
import { useToast } from "../Toast/Toast";
const notAllowNull = /^\s*\S.*$/g;
const allNull = /^(?!\s+$).*/g;
const schema = yup.object({
  tenTruong: yup
    .string()
    .matches(notAllowNull, "Tên trường không được là khoảng trống.")
    .nullable()
    .required("Tên trường không được bỏ trống."),
  idChuyenMon: yup.number().typeError("Chuyên môn không được bỏ trống."),
  idHinhThucDaoTao: yup
    .number()
    .typeError("Hình thức đào tạo không được bỏ trống."),
  idTrinhDo: yup.number().typeError("Trình độ không được bỏ trống."),
  tuThoiGian: yup.date().nullable().required("Từ ngày không được bỏ trống"),
  denThoiGian: yup.date().nullable().required("Đến ngày không được bỏ trống"),
});
function AddLevelForm(props) {
  const { error, warn, info, success } = useToast();

  let { match, history } = props;

  let location = useLocation();
  let query = new URLSearchParams(location.search);
  //  console.log(query.get("maNhanVien"));
  //  console.log(query.get("hoTen"));

  let eCode = query.get("maNhanVien");
  let eName = query.get("hoTen");
  let { id } = match.params;

  const [dataDetailTDVH, setdataDetailTDVH] = useState([]);

  const [dataCM, setDataCM] = useState([]);
  const [dataHTDT, setDataHTDT] = useState([]);
  const [dataTD, setDataTD] = useState([]);

  const [showCheckDialog, setShowCheckDialog] = useState(false);

  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm thông tin trình độ mới"
  );
  // const [notChangeDialog,setNotChangeDialog] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };
  //console.log(eCode);

  //console.log(dataDetailTDVH);
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
          // if(checkInputChange === true){
          //   setDescription("Bạn chưa thay dổi");
          // }
          setDescription("Bạn chắc chắn muốn sửa trình độ");
          const response = await ProductApi.getTDDetail(id);
          setdataDetailTDVH(response);
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
      if (dataDetailTDVH.length !== 0) {
        document.title = `Thay đổi trình độ nhân viên ${dataDetailTDVH.tenNhanVien}`;
      } else if (id === undefined) {
        document.title = `Tạo trình độ nhân viên ${eName}`;
      }
    };
    titlePage();
  }, [dataDetailTDVH]);

  //ussing react-hooks-form
  const intitalValue = {
    maNhanVien: id !== undefined ? `${dataDetailTDVH.maNhanVien}` : eCode,
    idChuyenMon: id !== undefined ? `${dataDetailTDVH.idChuyenMon}` : null,
    tuThoiGian:
      id !== undefined
        ? moment(dataDetailTDVH.tuThoiGian)._d == "Invalid Date"
          ? dataDetailTDVH.tuThoiGian
          : moment(dataDetailTDVH.tuThoiGian)
        : dataDetailTDVH.tuThoiGian,
    denThoiGian:
      id !== undefined
        ? moment(dataDetailTDVH.denThoiGian)._d == "Invalid Date"
          ? dataDetailTDVH.denThoiGian
          : moment(dataDetailTDVH.denThoiGian)
        : dataDetailTDVH.denThoiGian,
    idHinhThucDaoTao:
      id !== undefined ? `${dataDetailTDVH.idHinhThucDaoTao}` : null,
    idTrinhDo: id !== undefined ? `${dataDetailTDVH.idTrinhDo}` : null,
    tenTruong: id !== undefined ? `${dataDetailTDVH.tenTruong}` : null,
  };
  //  console.log(typeof(intitalValue.tuThoiGian));

  const {
    register,
    handleSubmit,
    control,
    setValue,
    getValues,
    reset,
    formState: { errors },
  } = useForm({
    defaultValues: intitalValue,
    resolver: yupResolver(schema),
  });

  useEffect(() => {
    if (dataDetailTDVH) {
      reset(intitalValue);
    }
  }, [dataDetailTDVH]);
  const checkInputChange = () => {
    const values = getValues([
      "maNhanVien",
      "idChuyenMon",
      "tuThoiGian",
      "denThoiGian",
      "idHinhThucDaoTao",
      "idTrinhDo",
      "tenTruong",
    ]);
    const dfValue = [
      intitalValue.maNhanVien,
      intitalValue.idChuyenMon,
      intitalValue.tuThoiGian,
      intitalValue.denThoiGian,
      intitalValue.idHinhThucDaoTao,
      intitalValue.idTrinhDo,
      intitalValue.tenTruong,
    ];
    return JSON.stringify(values) === JSON.stringify(dfValue);
  };

  const onHandleSubmit = async (data) => {
    checkInputChange();

    try {
      if (id !== undefined) {
        await PutApi.PutTDVH(data, id);
        success(
          `Sửa thông tin trình độ cho nhân viên ${dataDetailTDVH.tenNhanVien} thành công`
        );
      } else {
        await ProductApi.PostTDVH(data);
        success(`Thêm thông tin trình độ cho nhân viên ${eName} thành công`);
      }
      history.goBack();
    } catch (errors) {
      console.log("Có lỗi xảy ra: ", error);
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteTDVH(id);
      history.push(`/profile/detail/${dataDetailTDVH.maNhanVien}`);
      success(
        `Xoá thông tin trình độ cho nhân viên ${dataDetailTDVH.tenNhanVien} thành công`
      );
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
              onClick={() => {
                if (checkInputChange()) {
                  setShowCheckDialog(true);
                } else {
                  setShowDialog(true);
                }
              }}
              // onClick={handleSubmit(onHandleSubmit)}
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
                    // defaultValue={
                    //   id !== undefined ? de.maNhanVien : eCode
                    // }
                    //setValue={id !== undefined ? dataDetailTDVH.maNhanVien : eCode}
                    id="maNhanVien"
                    className={
                      !errors.maNhanVien
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    readOnly
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
                    //defaultValue={defaultValue.idChuyenMon}
                    className={
                      !errors.idChuyenMon
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailTDVH.idChuyenMon}>
                      {dataDetailTDVH.chuyenMon}
                    </option>
                    {dataCM
                      .filter((item) => item.id !== dataDetailTDVH.idChuyenMon)
                      .map((item, key) => (
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
                    // defaultValue={defaultValue.tenTruong}
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
                      {dataDetailTDVH.hinhThucDaoTao}
                    </option>
                    {dataHTDT
                      .filter(
                        (item) => item.id !== dataDetailTDVH.idHinhThucDaoTao
                      )
                      .map((item, key) => (
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
                    {dataTD
                      .filter((item) => item.id !== dataDetailTDVH.idTrinhDo)
                      .map((item, key) => (
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
                  {/* <input
                    type="text"
                    {...register("tuThoiGian")}
                    id="tuThoiGian"
                    className={
                      !errors.tuThoiGian
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger"
                    }
                    placeholder="DD/MM/YYYY"
                  /> */}

                  <Controller
                    name="tuThoiGian"
                    control={control}
                    render={({ field, onChange }) => (
                      <DatePicker
                        id="tuThoiGian"
                        className={
                          !errors.tuThoiGian
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
                  <span className="message">{errors.tuThoiGian?.message}</span>
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
                  {/* <input
                    type="text"
                    {...register("denThoiGian")}
                    id="denThoiGian"
                    className={
                      !errors.denThoiGian
                        ? "form-control col-sm-6 "
                        : "form-control col-sm-6 border-danger"
                    }
                    placeholder="DD/MM/YYYY"
                  /> */}
                  <Controller
                    name="denThoiGian"
                    control={control}
                    // defaultValue={defaultValue}

                    render={({ field, onChange }) => (
                      <DatePicker
                        id="denThoiGian"
                        // defaultValue={moment(dataDetailTDVH.denThoiGian)._d}
                        //defaultValue={moment(dataDetailTDVH.denThoiGian)}
                        className={
                          !errors.denThoiGian
                            ? "form-control col-sm-6"
                            : "form-control col-sm-6 border-danger"
                        }
                        placeholder="DD/MM/YYYY"
                        format="DD/MM/YYYY"
                        // onChange={(event) => {
                        //   handleChangeDate(event);
                        // }}
                        value={field.value}
                        onChange={(event) => {
                          field.onChange(event);
                        }}
                        //selected={field}
                        {...field._d}

                        //inputRef={dates}
                      />
                    )}
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
            ? "Bạn chưa thay đổi thông tin trình độ"
            : "Bạn chưa nhập thông tin trình độ"
        }
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa thông tin trình độ `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLevelForm;
