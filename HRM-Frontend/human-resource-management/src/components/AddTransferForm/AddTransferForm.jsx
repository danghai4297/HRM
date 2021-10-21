import React, { useEffect, useState } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./AddTransferForm.scss";
import ProductApi from "../../api/productApi";

const schema = yup.object({
  hoVaTen: yup.string().required("Họ và tên không được bỏ trống."),
  maNhanVien: yup.string().required("Mã nhân viên không được bỏ trống."),
});
function AddTransferForm(props) {
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  const onHandleSubmit = (data) => {
    console.log(data);
    JSON.stringify(data);
  };

  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDC, setDataDetailDC] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getDCDetail(id);
        setDataDetailDC(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);


  const [checked, setCheked] = useState(false);
  const handleClick = () => setCheked(!checked);
  return (
    <div className="container-form">
      <div className="Submit-button sticky-top">
        <div>
          <h2 className="">Thêm thủ tục thuyên chuyển</h2>
        </div>
        <div className="button">
          <input type="submit" className="btn btn-secondary " value="Huỷ" />
          <input
            type="submit"
            className="btn btn-primary ml-3"
            value="Lưu"
            onClick={handleSubmit(onHandleSubmit)}
          />
        </div>
      </div>
      <form
        action=""
        class="profile-form"
        // onSubmit={handleSubmit(onHandleSubmit)}
      >
        <div className="container-div-form">
          <div className="container-salary">
            <div>
              <h3>Vị trí công tác hiện tại</h3>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="hoVaTen">
                  Họ và tên
                </label>
                <select
                  type="text"
                  {...register("hoVaTen")}
                  id="hoVaTen"
                  className={
                    !errors.hoVaTen
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option value=""></option>
                  <option>Hai nd</option>
                </select>
                <span className="message">{errors.hoVaTen?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="maNhanVien"
                >
                  Mã nhân viên
                </label>
                <input
                  type="text"
                  {...register("maNhanVien")}
                  id="maNhanVien"
                  className={
                    !errors.maNhanVien
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.maNhanVien?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline ">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="phongBan"
                >
                  Phòng ban
                </label>
                <select
                  type="text"
                  {...register("phongBan")}
                  id="phongBan"
                  className={
                    !errors.phongBan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option value=""></option>
                  <option>ádasdasd</option>
                </select>
                <span className="message">{errors.phongBan?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="ngayHieuLuc"
                >
                  Ngày hiệu lực
                </label>
                <input
                  type="text"
                  {...register("ngayHieuLuc")}
                  id="ngayHieuLuc"
                  className={
                    !errors.ngayHieuLuc
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                />
                <span className="message">{errors.ngayHieuLuc?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="to">
                  Tổ
                </label>
                <select
                  type="text"
                  {...register("to")}
                  id="to"
                  className={
                    !errors.to
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option>Tổ 1</option>
                </select>
                <span className="message">{errors.to?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="chiTiet">
                  Chi tiết
                </label>
                <textarea
                  type="text"
                  rows="1"
                  {...register("chiTiet")}
                  id="chiTiet"
                  className={
                    !errors.chiTiet
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                />
                <span className="message">{errors.chiTiet?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="chucVuCongTac"
                >
                  Chức vụ công tác
                </label>
                <select
                  type="text"
                  {...register("chucVuCongTac")}
                  id="chucVuCongTac"
                  className={
                    !errors.chucVuCongTac
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                >
                  <option>CEO</option>
                </select>
                <span className="message">{errors.chucVuCongTac?.message}</span>
              </div>
            </div>
          </div>
        </div>
        <div className="container-div-form-2">
          <div className="col-6">
            <div class="form-check mb-4 form-inline">
              <input
                type="checkbox"
                {...register("choPhepDieuChuyen")}
                id="choPhepDieuChuyen"
                className="form-check-input"
                onClick={handleClick}
                checked={checked}
              />
              <label
                className="form-check-label  justify-content-start "
                htmlFor="choPhepDieuChuyen"
              >
                Cho phép điều chuyển
              </label>
            </div>
          </div>
        </div>
        <div className="container-div-form">
          <div className="container-salary">
            <div>
              <h3>Vị trí công tác chuyển đến</h3>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tc_hoVaTen"
                >
                  Họ và tên
                </label>
                <select
                  type="text"
                  {...register("tc_hoVaTen")}
                  id="tc_hoVaTen"
                  className={
                    !errors.tc_hoVaTen
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                  disabled={!checked}
                >
                  <option value=""></option>
                  <option>Hai nd</option>
                </select>
                <span className="message">{errors.tc_hoVaTen?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tc_maNhanVien"
                >
                  Mã nhân viên
                </label>
                <input
                  type="text"
                  {...register("tc_maNhanVien")}
                  id="tc_maNhanVien"
                  className={
                    !errors.tc_maNhanVien
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  disabled={!checked}
                />
                <span className="message">{errors.tc_maNhanVien?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline ">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tc_phongBan"
                >
                  Phòng ban
                </label>
                <select
                  type="text"
                  {...register("tc_phongBan")}
                  id="tc_phongBan"
                  className={
                    !errors.tc_phongBan
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                  disabled={!checked}
                >
                  <option value=""></option>
                  <option>ádasdasd</option>
                </select>
                <span className="message">{errors.tc_phongBan?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tc_ngayHieuLuc"
                >
                  Ngày hiệu lực
                </label>
                <input
                  type="text"
                  {...register("tc_ngayHieuLuc")}
                  id="tc_ngayHieuLuc"
                  className={
                    !errors.tc_ngayHieuLuc
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  placeholder="DD/MM/YYYY"
                  disabled={!checked}
                />
                <span className="message">
                  {errors.tc_ngayHieuLuc?.message}
                </span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col">
              <div class="form-group form-inline">
                <label class="col-sm-4 justify-content-start" htmlFor="tc_to">
                  Tổ
                </label>
                <select
                  type="text"
                  {...register("tc_to")}
                  id="tc_to"
                  className={
                    !errors.to
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                  disabled={!checked}
                >
                  <option>Tổ 1</option>
                </select>
                <span className="message">{errors.tc_to?.message}</span>
              </div>
            </div>
            <div className="col">
              <div className="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tc_chiTiet"
                >
                  Chi tiết
                </label>
                <textarea
                  type="text"
                  rows="1"
                  {...register("tc_chiTiet")}
                  id="tc_chiTiet"
                  className={
                    !errors.tc_chiTiet
                      ? "form-control col-sm-6 "
                      : "form-control col-sm-6 border-danger"
                  }
                  disabled={!checked}
                />
                <span className="message">{errors.tc_chiTiet?.message}</span>
              </div>
            </div>
          </div>
          <div className="row">
            <div className="col-6">
              <div class="form-group form-inline">
                <label
                  class="col-sm-4 justify-content-start"
                  htmlFor="tc_chucVuCongTac"
                >
                  Chức vụ công tác
                </label>
                <select
                  type="text"
                  {...register("tc_chucVuCongTac")}
                  id="tc_chucVuCongTac"
                  className={
                    !errors.tc_chucVuCongTac
                      ? "form-control col-sm-6 custom-select"
                      : "form-control col-sm-6 border-danger custom-select"
                  }
                  disabled={!checked}
                >
                  <option>CEO</option>
                </select>
                <span className="message">
                  {errors.tc_chucVuCongTac?.message}
                </span>
              </div>
            </div>
          </div>
        </div>
      </form>
    </div>
  );
}

export default AddTransferForm;
