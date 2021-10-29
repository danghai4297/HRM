import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddLevelForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
const schema = yup.object({
  tenTrinhDo: yup
    .string()
    .nullable()
    .required("Tên danh mục không được bỏ trống."),
});
function AddLevelForm(props) {
  let { match, history } = props;
  let { id } = match.params;

  const token = localStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMTD, setdataDetailDMTD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục trình độ mới"
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
          setDescription("Bạn chắc chắn muốn sửa danh mục trình độ");
          const response = await ProductApi.getDetailDMTD(id);
          setdataDetailDMTD(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const {
    register,
    handleSubmit,
    reset,
    getValues,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: {
      tenTrinhDo: id !== undefined ? `${dataDetailDMTD.tenTrinhDo}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMTD && id !== undefined) {
      reset({
        tenTrinhDo: `${dataDetailDMTD.tenTrinhDo}`,
      });
    }
  }, [dataDetailDMTD]);

  const checkInputLevelChange = () => {
    return getValues("tenTrinhDo") === `${dataDetailDMTD.tenTrinhDo}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenTrinhDo;

    try {
      if (id !== undefined) {
        await PutApi.PutDMTD(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục trình độ: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
      } else {
        await ProductApi.PostDMTD(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục trình độ: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMTD(id);
      history.goBack();
    } catch (error) {}
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMTD.length !== 0 ? "Sửa" : "Thêm"} danh mục trình độ
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMTD.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMTD.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputLevelChange()) {
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
              <div className="col-6">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenTrinhDo"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenTrinhDo")}
                    id="tenTrinhDo"
                    className={
                      !errors.tenTrinhDo
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenTrinhDo?.message}</span>
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
      <DialogCheck
        show={showCheckDialog}
        title="Thông báo"
        description={"Bạn chưa thay đổi gì"}
        confirm={null}
        cancel={cancel}
      />
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa danh mục trình độ ${dataDetailDMTD.tenTrinhDo}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLevelForm;
