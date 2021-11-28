import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddDepartmentForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";

const dontAllowOnlySpace = /^\s*\S.*$/g;
const schema = yup.object({
  tenPhongBan: yup
    .string()
    .matches(dontAllowOnlySpace, "Tên phòng ban không được chỉ là khoảng trống")
    .required("Tên phòng ban không được bỏ trống."),
});
function AddDepartmentForm(props) {
  const { error, success } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMPB, setdataDetailDMPB] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm phòng ban mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchDepartmentCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa phòng ban");
          const response = await ProductApi.getDetailDMPB(id);
          setdataDetailDMPB(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchDepartmentCategory();
  }, []);

  useEffect(() => {
    const handleDepartmentId = async () => {
      if (id === undefined) {
        const responseDepartment = await ProductApi.getAllDMPB();
        const codeIncre =
          responseDepartment !== null &&
          responseDepartment[responseDepartment.length - 1].maPhongBan;
        const autoCodeIncre = Number(codeIncre.slice(2)) + 1;
        const codeDepartment = "PB";
        if (autoCodeIncre < 10) {
          setValue("maPhongBan", codeDepartment.concat(`0${autoCodeIncre}`));
        } else if (autoCodeIncre >= 10) {
          setValue("maPhongBan", codeDepartment.concat(`${autoCodeIncre}`));
        }
      }
    };
    handleDepartmentId();
  }, []);

  const intitalValue = {
    maPhongBan: `${dataDetailDMPB.maPhongBan}`,
    tenPhongBan: `${dataDetailDMPB.tenPhongBan}`,
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    setValue,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: id !== undefined ? intitalValue : null,
  });

  useEffect(() => {
    if (dataDetailDMPB && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMPB]);

  const checkInputDepartmentChange = () => {
    const departmentValues = getValues(["maPhongBan", "tenPhongBan"]);
    const dfDepartmentValues = [
      intitalValue.maPhongBan,
      intitalValue.tenPhongBan,
    ];
    return (
      JSON.stringify(departmentValues) === JSON.stringify(dfDepartmentValues)
    );
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenPhongBan;
    try {
      if (id !== undefined) {
        await PutApi.PutDMPB(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa phòng ban: ${
            dataDetailDMPB.tenPhongBan !== tendm
              ? `${dataDetailDMPB.tenPhongBan} -->`
              : ""
          } ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("sửa phòng ban thành công");
      } else {
        await ProductApi.PostDMPB(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm phòng ban mới: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm phòng ban thành công");
      }
      history.goBack();
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMPB(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa phòng ban: ${dataDetailDMPB.tenPhongBan}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success("Xoá phòng ban thành công");

      history.goBack();
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMPB.length !== 0 ? "Sửa" : "Thêm"} danh mục phòng ban
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMPB.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMPB.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputDepartmentChange()) {
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
                    htmlFor="maPhongBan"
                  >
                    Mã phòng ban
                  </label>
                  <input
                    type="text"
                    {...register("maPhongBan")}
                    id="maPhongBan"
                    className={
                      !errors.maPhongBan
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                    readOnly
                  />
                  <span className="message">{errors.maPhongBan?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenPhongBan"
                  >
                    Tên phòng ban
                  </label>
                  <input
                    type="text"
                    {...register("tenPhongBan")}
                    id="tenPhongBan"
                    className={
                      !errors.tenPhongBan
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenPhongBan?.message}</span>
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
        description={`Bạn chắc chắn muốn xóa phòng ban ${dataDetailDMPB.tenPhongBan}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddDepartmentForm;
