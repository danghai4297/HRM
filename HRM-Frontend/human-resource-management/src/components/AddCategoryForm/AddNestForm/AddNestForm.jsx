import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddNestForm.scss";
import ProductApi from "../../../api/productApi";
import Dialog from "../../Dialog/Dialog";
import DeleteApi from "../../../api/deleteAPI";
import PutApi from "../../../api/putAAPI";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
const schema = yup.object({
  maTo: yup.string().required("Mã tổ không được bỏ trống."),
  idPhongBan: yup.number().typeError("Thuộc phòng ban không được bỏ trống."),
  tenTo: yup.string().required("Tổ không được bỏ trống."),
});
function AddNestForm(props) {
  //dữ liệu phòng ban
  let { match, history } = props;
  let { id } = match.params;

  const token = localStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMT, setdataDetailDMT] = useState([]);
  const [dataDmpb, setDataDmpb] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục tổ mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllDMPB();
        setDataDmpb(responseNv);
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốm sửa danh mục tổ");
          const response = await ProductApi.getDetailDMT(id);
          setdataDetailDMT(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue = {
    maTo: `${dataDetailDMT.maTo}`,
    tenTo: `${dataDetailDMT.tenTo}`,
    idPhongBan: `${dataDetailDMT.idPhongBan}`,
  };

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: id !== undefined ? intitalValue : null,
  });

  useEffect(() => {
    if (dataDetailDMT && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMT]);

  const checkInputNestChange = () => {
    const nestValues = getValues(["maTo", "tenTo", "idPhongBan"]);
    const dfNestValues = [
      intitalValue.maTo,
      intitalValue.tenTo,
      intitalValue.idPhongBan,
    ];
    return JSON.stringify(nestValues) === JSON.stringify(dfNestValues);
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenTo;

    try {
      if (id !== undefined) {
        await PutApi.PutDMT(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục tổ: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
      } else {
        await ProductApi.PostDMT(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục tổ: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMT(id);
      history.goBack();
    } catch (error) {}
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMT.length !== 0 ? "Sửa" : "Thêm"} danh mục tổ
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMT.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMT.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputNestChange()) {
                  setShowCheckDialog(true);
                } else {
                  setShowDialog(true);
                }
              }}
            />
          </div>
        </div>
        <form action="" className="profile-form">
          <div className="container-div-form-category">
            <h3>Thông tin chung</h3>
            <div className="row">
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="maTo"
                  >
                    Mã tổ
                  </label>
                  <input
                    type="text"
                    {...register("maTo")}
                    id="maTo"
                    className={
                      !errors.maTo
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.maTo?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="idPhongBan"
                  >
                    Thuộc phòng ban
                  </label>
                  <select
                    type="text"
                    {...register("idPhongBan")}
                    id="idPhongBan"
                    className={
                      !errors.idPhongBan
                        ? "form-control col-sm-6 custom-select"
                        : "form-control col-sm-6 border-danger custom-select"
                    }
                  >
                    <option value={dataDetailDMT.idPhongBan}>
                      {dataDetailDMT.tenPhongBan}
                    </option>
                    {dataDmpb
                      .filter((item) => item.id !== dataDetailDMT.idPhongBan)
                      .map((item, key) => (
                        <option key={key} value={item.id}>
                          {item.tenPhongBan}{" "}
                        </option>
                      ))}
                  </select>
                  <span className="message">{errors.idPhongBan?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenTo"
                  >
                    Tổ
                  </label>
                  <input
                    type="text"
                    {...register("tenTo")}
                    id="tenTo"
                    className={
                      !errors.tenTo
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenTo?.message}</span>
                </div>
              </div>
            </div>
          </div>
        </form>
      </div>
      <Dialog
        show={showDialog}
        title="Thông báo"
        description={Object.values(errors).length !== 0 ? "Bạn chưa nhập đầy đủ thông tin" : description}
        confirm={Object.values(errors).length !== 0 ? null : handleSubmit(onHandleSubmit)}
        cancel={cancel}
      />
      <Dialog
        show={showCheckDialog}
        title="Thông báo"
        description={"Bạn chưa thay đổi gì"}
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa danh mục tổ ${dataDetailDMT.tenTo} của phòng ban ${dataDetailDMT.tenPhongBan}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddNestForm;
