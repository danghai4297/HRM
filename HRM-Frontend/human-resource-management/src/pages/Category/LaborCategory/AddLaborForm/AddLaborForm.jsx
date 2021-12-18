import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./AddLaborForm.scss";
import ProductApi from "../../../../api/productApi";
import PutApi from "../../../../api/putAAPI";
import DeleteApi from "../../../../api/deleteAPI";
import Dialog from "../../../../components/Dialog/Dialog";
import jwt_decode from "jwt-decode";
import { useToast } from "../../../../components/Toast/Toast";
import { schema } from "../../../../ultis/LaborValidation";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function AddLaborForm(props) {
  const { error, success, warn } = useToast();
  let { match, history } = props;
  let { id } = match.params;

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailDMTCLD, setdataDetailDMTCLD] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showCheckDialog, setShowCheckDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm tính chất lao động mới"
  );
  const [open, setOpen] = useState(false);

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
    setShowCheckDialog(false);
  };

  useEffect(() => {
    const fetchLaborCategory = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa tính chất lao động");
          const response = await ProductApi.getDetailDMTCLD(id);
          setdataDetailDMTCLD(response);
        }
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchLaborCategory();
  }, []);

  useEffect(() => {
    if (id !== undefined) {
      setOpen(!open);
    }
  }, [dataDetailDMTCLD]);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDMTCLD.length !== 0) {
        document.title = `Thay đổi danh mục ${dataDetailDMTCLD.tenLaoDong}`;
      } else if (id === undefined) {
        document.title = `Tạo danh mục tính chất lao động mới`;
      }
    };
    titlePage();
  }, [dataDetailDMTCLD]);

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
        try {
          await PutApi.PutDMTCLD(data, id);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Sửa tính
            chất lao động: ${dataDetailDMTCLD.tenLaoDong} --> ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Sửa tính chất lao động thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể sửa thành danh mục đã tồn tại");
        }
      } else {
        try {
          await ProductApi.PostDMTCLD(data);
          await ProductApi.PostLS({
            tenTaiKhoan: decoded.userName,
            thaoTac: `Thêm tính
            chất lao động mới: ${tendm}`,
            maNhanVien: decoded.id,
            tenNhanVien: decoded.givenName,
          });
          success("Thêm tính chất lao động thành công");
          history.goBack();
        } catch (errors) {
          error("Không thể thêm danh mục đã tồn tại");
        }
      }
    } catch (errors) {
      error(`Không thêm hoặc sửa danh mục được ${errors}`);
    }
  };

  const handleDelete = async () => {
    try {
      if (dataDetailDMTCLD.trangThai === "Chưa sử dụng") {
        await DeleteApi.deleteDMTCLD(id);
        await ProductApi.PostLS({
          tenTaiKhoan: decoded.userName,
          thaoTac: `Xóa tính
          chất lao động: ${dataDetailDMTCLD.tenLaoDongndm}`,
          maNhanVien: decoded.id,
          tenNhanVien: decoded.givenName,
        });
        history.goBack();
        success("Xoá tính chất lao động thành công");
      } else {
        warn(`Danh mục đang được sử dụng`);
      }
    } catch (errors) {
      error(`Không xóa được danh mục ${errors}`);
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
              className="btn btn-primary ml-3 btn-form"
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
        description={`Bạn chắc chắn muốn xóa tính chất lao động ${dataDetailDMTCLD.tenLaoDong}`}
        confirm={handleDelete}
        cancel={cancel}
      />
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default AddLaborForm;
