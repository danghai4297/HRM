import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddLaborForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
import jwt_decode from "jwt-decode";
import { useToast } from "../../Toast/Toast";
const schema = yup.object({
  tenLaoDong: yup
  .string()
  .nullable()
  .required("Tên danh mục không được bỏ trống."),
});
function AddLaborForm(props) {
  const { error, warn, info, success } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = localStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMTCLD, setdataDetailDMTCLD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm tính chất lao động mới"
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
          setDescription("Bạn chắc chắn muốn sửa tính chất lao động");
          const response = await ProductApi.getDetailDMTCLD(id);
          setdataDetailDMTCLD(response);
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
      tenLaoDong: id !== undefined ? `${dataDetailDMTCLD.tenLaoDong}` : null,
    },
  });

  useEffect(() => {
    if (dataDetailDMTCLD && id !== undefined) {
      reset({
        tenLaoDong: `${dataDetailDMTCLD.tenLaoDong}`,
      });
    }
  }, [dataDetailDMTCLD]);

  const checkInputLaborChange = () => {
    return getValues("tenLaoDong") === `${dataDetailDMTCLD.tenLaoDong}`;
  };

  const onHandleSubmit = async (data) => {
    let tendm = data.tenLaoDong;

    try {
      if (id !== undefined) {
        await PutApi.PutDMTCLD(data, id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Sửa danh mục tính
          chất lao động: ${tendm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        success("sửa danh mục thành công");
      } else {
        await ProductApi.PostDMTCLD(data);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Thêm danh mục tính
          chất lao động: ${tendm}`,
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
      await DeleteApi.deleteDMTCLD(id);
      history.goBack();
      success("Xoá danh mục thành công");
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
              {dataDetailDMTCLD.length !== 0 ? "Sửa" : "Thêm"} danh mục tính
              chất lao động
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMTCLD.length !== 0
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
              value={dataDetailDMTCLD.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputLaborChange()) {
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
                    htmlFor="tenLaoDong"
                  >
                    Tên danh mục
                  </label>
                  <input
                    type="text"
                    {...register("tenLaoDong")}
                    id="tenLaoDong"
                    className={
                      !errors.tenLaoDong
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenLaoDong?.message}</span>
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
        description={`Bạn chắc chắn muốn xóa tính chất lao động ${dataDetailDMTCLD.tenLaoDong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLaborForm;
