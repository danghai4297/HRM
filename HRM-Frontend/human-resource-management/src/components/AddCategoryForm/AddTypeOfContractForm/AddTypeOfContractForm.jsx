import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddTypeOfContractForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";
import {schema} from "../../../ultis/CategoryValidation";



function AddTypeOfContractForm(props) {
  const { error, success } = useToast();

  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMLHD, setdataDetailDMLHD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục loại hợp đồng mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchTypeOfContractCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa loại hợp đồng");
          const response = await ProductApi.getDetailDMLHD(id);
          setdataDetailDMLHD(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchTypeOfContractCategory();
  }, []);

  useEffect(() => {
    const handleTypeOfContractId = async () => {
      if (id === undefined) {
        const responseTypeOfContract = await ProductApi.getAllDMLHD();
        const codeIncre =
          responseTypeOfContract !== null &&
          responseTypeOfContract[responseTypeOfContract.length - 1]
            .maLoaiHopDong;
        const autoCodeIncre = Number(codeIncre.slice(3)) + 1;
        const codeTypeOfContract = "LHD";
        if (autoCodeIncre < 10) {
          setValue(
            "maLoaiHopDong",
            codeTypeOfContract.concat(`0${autoCodeIncre}`)
          );
        } else if (autoCodeIncre >= 10) {
          setValue(
            "maLoaiHopDong",
            codeTypeOfContract.concat(`${autoCodeIncre}`)
          );
        }
      }
    };
    handleTypeOfContractId();
  }, []);

  const intitalValue = {
    maLoaiHopDong: `${dataDetailDMLHD.maLoaiHopDong}`,
    tenLoaiHopDong: `${dataDetailDMLHD.tenLoaiHopDong}`,
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
    defaultValues: {
      defaultValues: id !== undefined ? intitalValue : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMLHD && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMLHD]);

  const checkInputTypeOfContractChange = () => {
    const typeOfContractValues = getValues(["maLoaiHopDong", "tenLoaiHopDong"]);
    const dfTypeOfContractValues = [
      intitalValue.maLoaiHopDong,
      intitalValue.tenLoaiHopDong,
    ];
    return (
      JSON.stringify(typeOfContractValues) ===
      JSON.stringify(dfTypeOfContractValues)
    );
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenLoaiHopDong;

    try {
      if (id !== undefined) {
        await PutApi.PutDMLHD(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục loại hợp đồng: ${
            dataDetailDMLHD.tenLoaiHopDong !== tendm
              ? `${dataDetailDMLHD.tenLoaiHopDong} thành`
              : ""
          } ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Sửa danh mục loại hợp đồng thành công");
      } else {
        await ProductApi.PostDMLHD(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục loại hợp đồng mới: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("Thêm danh mục loại hợp đồng thành công");
      }
      history.goBack();
    } catch (errors) {
      error(`Có lỗi xảy ra ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMLHD(id);
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Xóa danh mục loại hợp đồng: ${dataDetailDMLHD.tenLoaiHopDong}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success("Xoá danh mục loại hợp đồng thành công");

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
              {dataDetailDMLHD.length !== 0 ? "Sửa" : "Thêm"} danh mục loại hợp
              đồng
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMLHD.length !== 0
                  ? "btn btn-danger"
                  : "delete-button"
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
              value={dataDetailDMLHD.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputTypeOfContractChange()) {
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
                    htmlFor="maLoaiHopDong"
                  >
                    Mã loại hợp đồng
                  </label>
                  <input
                    type="text"
                    {...register("maLoaiHopDong")}
                    id="maLoaiHopDong"
                    className={
                      !errors.maLoaiHopDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                    readOnly
                  />
                  <span className="message">
                    {errors.maLoaiHopDong?.message}
                  </span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenLoaiHopDong"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenLoaiHopDong")}
                    id="tenLoaiHopDong"
                    className={
                      !errors.tenLoaiHopDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">
                    {errors.tenLoaiHopDong?.message}
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
        description={`Bạn chắc chắn muốn xóa danh mục loại hợp đồng ${dataDetailDMLHD.tenLoaiHopDong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddTypeOfContractForm;
