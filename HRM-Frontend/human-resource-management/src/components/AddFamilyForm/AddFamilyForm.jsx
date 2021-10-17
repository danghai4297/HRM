import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { useLocation } from "react-router-dom";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddFamilyForm.scss";
import DeleteApi from "../../../src/api/deleteAPI";
import PutApi from "../../../src/api/putAAPI";
import ProductApi from "../../../src/api/productApi";
import Dialog from "../../components/Dialog/Dialog";

const schema = yup.object({
  idDanhMucNguoiThan: yup
    .string()
    .required("Danh mục người thân không được bỏ trống."),
  tenNguoiThan: yup.string().required("Tên người thân không được bỏ trống."),
  gioiTinh: yup.string().required("Giới tính không được bỏ trống."),
  ngaySinh: yup.string().required("Ngày sinh được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
  quanHe: yup.string().required("Quan hệ không được bỏ trống."),
  ngheNghiep: yup.string().required("Nghề nghệp không được bỏ trống."),
  diaChi: yup.string().required("Địa chỉ không được bỏ trống."),
  dienThoai: yup.string().required("Mã nhân viên không được bỏ trống."),
});
function AddFamilyForm(props) {
  let { match, history } = props;
  let { id } = match.params;

  let location = useLocation();
  console.log(location)
  let query = new URLSearchParams(location.search);
  console.log(query.get("maNhanVien"));

  const [dataDetailNT, setdataDetailNT] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        // const responseCM = await ProductApi.getAllDMCM();
        // setDataCM(responseCM);
        // const responseHTDT = await ProductApi.getAllDMHTDT();
        // setDataHTDT(responseHTDT);
        // const responseTD = await ProductApi.getAllDMTD();
        // setDataTD(responseTD);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốm sửa trình độ");
          const response = await ProductApi.getNTDetail(id);
          setdataDetailNT(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
console.log(dataDetailNT)
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  const [dataNN, setDataNN] = useState([]);

  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm trình độ mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };
  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
      //  await PutApi.PutTDVH(data, id);
      } else {
     //   await ProductApi.PostTDVH(data);
      }
      history.goBack();
    } catch (error) {}
  };
  return (
    <>
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">{dataDetailNT.length !== 0 ? "Sửa" : "Thêm"} gia đình</h2>
        </div>
        <div className="button">
        <input
              type="submit"
              className={
                dataDetailNT.length !== 0 ? "btn btn-danger" : "delete-button"
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
            value={dataDetailNT.length !== 0 ? "Sửa" : "Lưu"}
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
                <label class="col-sm-4 justify-content-start" htmlFor="maNhanVien">
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
                <label class="col-sm-4 justify-content-start" htmlFor="idDanhMucNguoiThan">
                 Danh mục người thân
                </label>
                <select
                  type="text"
                  {...register("idDanhMucNguoiThan")}
                  id="idDanhMucNguoiThan"
                  className={
                    !errors.idDanhMucNguoiThan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  {/* <option value={dataDetailTDVH.idChuyenMon}>{dataDetailTDVH.tenChuyenMon}</option>
                  {dataCM.map((item,key)=>(
                    <option key={key} value={item.id}>
                    {item.tenChuyenMon}{" "}
                  </option>
                  ))} */}
                </select>
                <span className="message">{errors.idDanhMucNguoiThan?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline ">
                <label class="col-sm-4 justify-content-start" htmlFor="tenNguoiThan">
                  Họ và tên
                </label>
                <input
                  type="text"
                  {...register("tenNguoiThan")}
                  id="tenNguoiThan"
                  className={
                    !errors.tenNguoiThan
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.tenNguoiThan?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="quanHe"
                >
                 Quan hệ
                </label>
                <input
                  type="text"
                  {...register("quanHe")}
                  id="quanHe"
                  className={
                    !errors.quanHe
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger "
                  }
                />
                  {/* <option value={dataDetailTDVH.idHinhThucDaoTao}>{dataDetailTDVH.tenHinhThuc}</option>
                  {dataHTDT.map((item,key)=>(
                    <option key={key} value={item.id}>
                    {item.tenHinhThuc}{" "}
                  </option>
                  ))} */}
               
                <span className="message">{errors.quanHe?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
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
                {/* <option value={dataDetailTDVH.idTrinhDo}>{dataDetailTDVH.trinhDo}</option>
                {dataTD.map((item,key)=>(
                    <option key={key} value={item.id}>
                    {item.tenTrinhDo}{" "}
                  </option>
                  ))} */}
                  <option value=""></option>
                  <option value={true}>Nam</option>
                  <option value={false}>Nữ</option>
                </select>
                <span className="message">{errors.gioiTinh?.message}</span>
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
              name="ngaySinh"
              control={control}
              defaultValue=""
              render={({ field }) => (
                <DatePicker
                  id="ngaySinh"
                  className="form-control col-sm-6"
                  placeholder="DD/MM/YYYY"
                  format="DD/MM/YYYY"
                  //selected={field}
                  //onChange={(field) => setDate(field)}
                  {...field}
                />
              )}
            /> */}
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="denThoiGian">
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
    {/* <Dialog
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
      /> */}
    </>
  );
}

export default AddFamilyForm;
