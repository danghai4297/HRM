import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddBonusForm.scss";
import ProductApi from "../../../api/productApi";
import PutApi from "../../../api/putAAPI";
AddBonusForm.propTypes = {};
const schema = yup.object({
  tenDanhMuc: yup.string().required("Tên danh mục không được bỏ trống."),
});

function AddBonusForm(props) {
  const [bonusValue, setBonusValue] = useState(null);
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });

  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDMKT, setdataDetailDMKT] = useState([]);
  const [showDialog, setShowDialog] = useState(false);
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn thêm khen thưởng mới"
  );

  const cancel = () => {
    setShowDialog(false);
    setShowDeleteDialog(false);
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        if (id !== undefined) {
          setDescription("Bạn chắc chắn muốn sửa khen thưởng");
          const response = await ProductApi.getDetailDMKT(id);
          setdataDetailDMKT(response);
        }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

console.log(dataDetailDMKT)

  const onHandleSubmit = async (data) => {
    try {
      if (id !== undefined) {
        await PutApi.PutDMKTvKL(data, id);
      } else {
        await ProductApi.PostDMTCLD(data);
      }
      history.goBack();
    } catch (error) {}
  };

  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm danh mục khen thưởng</h2>
        </div>
        <div className="button">
          <input
            type="submit"
            className={bonusValue ? "btn btn-danger" : "delete-button"}
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
            value={bonusValue ? "Sửa" : "Lưu"}
            onClick={handleSubmit(onHandleSubmit)}
          />
        </div>
      </div>
      <form
        action=""
        className="profile-form"
        // onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="container-div-form-category">
          <h3>Thông tin chung</h3>
          <div className="row">
            <div className="col-6">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tenDanhMuc"
                >
                  Tên danh mục
                </label>
                <input
                  type="text"
                  {...register("tenDanhMuc")}
                  id="tenDanhMuc"
                  className={
                    !errors.tenDanhMuc
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenDanhMuc?.message}</span>
              </div>
            </div>
            {/* <div className="col-6">
              <div className="form-group form-inline">
                <label
                  className="col-sm-4 justify-content-start"
                  htmlFor="tieuDe"
                >
                  Tiêu đề
                </label>
                <input
                  type="text"
                  {...register("tenDanhMuc")}
                  id="tenDanhMuc"
                  className={
                    !errors.tenDanhMuc
                      ? "form-control col-sm-6"
                      : "form-control col-sm-6 border-danger "
                  }
                />
                <span className="message">{errors.tenDanhMuc?.message}</span>
              </div>
            </div> */}
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddBonusForm;
