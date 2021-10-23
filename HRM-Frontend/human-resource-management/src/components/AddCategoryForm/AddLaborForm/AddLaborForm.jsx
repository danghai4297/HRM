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
const schema = yup.object({
  tenLaoDong: yup.string().required("Tên danh mục không được bỏ trống."),
});
function AddLaborForm(props) {
  let { match, history } = props;
  let { id } = match.params;

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
    try {
      if (id !== undefined) {
        await PutApi.PutDMTCLD(data, id);
      } else {
        await ProductApi.PostDMTCLD(data);
      }
      history.goBack();
    } catch (error) {}
  };

  const handleDelete = async () => {
    try {
      await DeleteApi.deleteDMTCLD(id);
      history.goBack();
    } catch (error) {}
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
        <form
          action=""
          className="profile-form"
        >
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
        description={`Bạn chắc chắn muốn xóa tính chất lao động ${dataDetailDMTCLD.tenLaoDong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default AddLaborForm;
