import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddTitleForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
import DeleteApi from "../../../api/deleteAPI";
import Dialog from "../../Dialog/Dialog";
import DialogCheck from "../../Dialog/DialogCheck";
AddTitleForm.propTypes = {};
const schema = yup.object({
  maChucDanh: yup.string().required("Mã chức danh không được bỏ trống."),
  tenChucDanh: yup.string().required("Tên chức danh không được bỏ trống."),
  phuCap: yup.number().typeError('Phụ cấp không được bỏ trống.'),
});
function AddTitleForm(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMCD, setdataDetailDMCD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm danh mục chức danh mới"
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
          setDescription("Bạn chắc chắn muốn sửa danh mục chức danh");
          const response = await ProductApi.getDetailDMCD(id);
          setdataDetailDMCD(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const intitalValue = {
    maChucDanh: `${dataDetailDMCD.maChucDanh}`,
    tenChucDanh: `${dataDetailDMCD.tenChucDanh}`,
    phuCap: `${dataDetailDMCD.phuCap}`,
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    reset,
    getValues,
  } = useForm({
    resolver: yupResolver(schema),
    defaultValues: id !== undefined ? intitalValue : null,
  });

  useEffect(() => {
    if (dataDetailDMCD && id !== undefined) {
      reset(intitalValue);
    }
  }, [dataDetailDMCD]);

  const checkInputTitleChange = () => {
    const titleValues = getValues(["maChucDanh", "tenChucDanh", "phuCap"]);
    const dfTitleValues = [
      intitalValue.maChucDanh,
      intitalValue.tenChucDanh,
      intitalValue.phuCap,
    ];
    return JSON.stringify(titleValues) === JSON.stringify(dfTitleValues);
  };

  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMCD(data, id);
      } else {
        await ProductApi.PostDMCD(data);
      }

      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMCD(id);
      history.goBack();
    } catch (error) {}
  };

  return (
    <>
      <div className="container-form">
        <div className="Submit-button sticky-top">
          <div>
            <h2 className="">
              {dataDetailDMCD.length !== 0 ? "Sửa" : "Thêm"} danh mục chức danh
            </h2>
          </div>
          <div className="button">
            <input
              type="submit"
              className={
                dataDetailDMCD.length !== 0 ? "btn btn-danger" : "delete-button"
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
              value={dataDetailDMCD.length !== 0 ? "Sửa" : "Lưu"}
              onClick={() => {
                if (checkInputTitleChange()) {
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
                    htmlFor="maChucDanh"
                  >
                    Mã chức danh
                  </label>
                  <input
                    type="text"
                    {...register("maChucDanh")}
                    id="maChucDanh"
                    defaultValue={dataDetailDMCD.maChucDanh}
                    className={
                      !errors.maChucDanh
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.maChucDanh?.message}</span>
                </div>
              </div>
              <div className="col">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="tenChucDanh"
                  >
                    Tên chức danh
                  </label>
                  <input
                    type="text"
                    {...register("tenChucDanh")}
                    id="tenChucDanh"
                    defaultValue={dataDetailDMCD.tenChucDanh}
                    className={
                      !errors.tenChucDanh
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.tenChucDanh?.message}</span>
                </div>
              </div>
            </div>
            <div className="row">
              <div className="col-6">
                <div className="form-group form-inline">
                  <label
                    className="col-sm-4 justify-content-start"
                    htmlFor="phuCap"
                  >
                    Phụ cấp
                  </label>
                  <input
                    type="text"
                    {...register("phuCap")}
                    id="phuCap"
                    defaultValue={dataDetailDMCD.phuCap}
                    className={
                      !errors.phuCap
                        ? "form-control col-sm-6"
                        : "form-control col-sm-6 border-danger "
                    }
                  />
                  <span className="message">{errors.phuCap?.message}</span>
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
        description={`Bạn chắc chắn muốn xóa danh mục chức danh ${dataDetailDMCD.tenChucDanh}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddTitleForm;
