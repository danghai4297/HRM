import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddSpecializeForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";

const schema = yup.object({
  tenChuyenMon: yup.string().required("Tên chuyên môn không được bỏ trống."),
  maChuyenMon: yup.string().required("Mã chuyên môn không được bỏ trống."),
});
function AddSpecializeForm(props) {
  const { error, warn, info, success } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMCM, setdataDetailDMCM] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục chuyên môn mới"
  );


  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa danh mục chuyên môn");
          const response = await ProductApi.getDetailDMCM(id);
          setdataDetailDMCM(response);

        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue = {
    maChuyenMon: `${dataDetailDMCM.maChuyenMon}`,
    tenChuyenMon: `${dataDetailDMCM.tenChuyenMon}`,
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
    if (dataDetailDMCM && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMCM]);

  const checkInputSpecializeChange = () => {
    const specializeValues = getValues(["maChuyenMon", "tenChuyenMon"]);
    const dfSpecializeValues = [
      intitalValue.maChuyenMon,
      intitalValue.tenChuyenMon,
    ];
    return (
      JSON.stringify(specializeValues) === JSON.stringify(dfSpecializeValues)
    );
  };

  const onHandleSubmit = async (data) => {
    let tendmbd = dataDetailDMCM.tenChuyenMon;
    let tendm = data.tenChuyenMon;

    try {
      console.log(data)
      if (id !== undefined) {
        await PutApi.PutDMCM(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục chuyên môn: ${
            dataDetailDMCM.tenChuyenMon !== tendm ? `${dataDetailDMCM.tenChuyenMon} thành` : ""
          } ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("sửa danh mục thành công");
      } else {
        await ProductApi.PostDMCM(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục chuyên môn: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm danh mục thành công");
      }
      history.goBack();
    } catch (error) {
      error(`Có lỗi xảy ra ${error}`);
    }
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMCM(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa danh mục chuyên môn: ${dataDetailDMCM.tenChuyenMon}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success("Xoá danh mục thành công");
      history.goBack();
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
              {dataDetailDMCM.length !== 0 ? "Sửa" : "Thêm"} danh mục chuyên môn
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMCM.length !== 0 ? "btn btn-danger" : "delete-button"
              }
              onClick={() => {
                setShowDeleteDialog(true);
              }}
              value="Xoá"
            />
            <input
              type="submit"
              className="btn btn-secondary  ml-3"
              value="Huỷ"
              onClick={history.goBack}
            />
            <input
              type="submit"
              className="btn btn-primary ml-3"
              value={dataDetailDMCM.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputSpecializeChange()) {
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
                    htmlFor="maChuyenMon"
                  >
                    Mã chuyên môn
                  </label>
                  <input
                    type="text"
                    {...register("maChuyenMon")}
                    id="maChuyenMon"
                    className={
                      !errors.maChuyenMon
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.maChuyenMon?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenChuyenMon"
                  >
                    Tên chuyên môn
                  </label>
                  <input
                    type="text"
                    {...register("tenChuyenMon")}
                    id="tenChuyenMon"
                    className={
                      !errors.tenChuyenMon
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">
                    {errors.tenChuyenMon?.message}
                  </span>
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
        description={`Bạn chắc chắn muốn xóa danh mục chuyên môn ${dataDetailDMCM.tenChuyenMon}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddSpecializeForm;
