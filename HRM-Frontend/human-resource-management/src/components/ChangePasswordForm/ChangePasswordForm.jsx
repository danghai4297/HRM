import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./ChangePasswordForm.scss"
import usePasswordToggle from "./usePasswordToggle";
const schema = yup.object({
    matKhauHienTai: yup.string().required("Mật khẩu hiện tại không được bỏ trống."),
    matKhauMoi: yup.string().required("Mật khẩu mới không được bỏ trống."),
    xacNhanMatKhau: yup.string().required("Xác nhận mật khẩu mới không được bỏ trống."),

});

function ChangePasswordForm(props) {
  const { history } = props;
  const [passwordInputType,Icon] =usePasswordToggle();
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
    history.goBack();
  };
  return (
    <div className="container-form">
      <div className="Submit-form">
        <div className="setH2">
             <h2>Mật Khẩu</h2>  
        
        </div>
      </div>
     
      <div className="container-div">
     
        <form
          action=""
          class="profile-form"
          // onSubmit={handleSubmit(onHandleSubmit)}
        >
          <div className="container-form-password">
            <div className="container-salary">
              <div className="">
                <h3>Thay đổi mật khẩu</h3>
                <p>
                  Nhập mật khẩu có tối thiểu 8 ký tự bao gồm số, chữ hoa, chữ
                  thường.
                </p>
              </div>
            </div>
            <div className="row justify-content-center">
                <div class="input-group-lg">
                  <input
                    type={passwordInputType}
                    {...register("matKhauHienTai")}
                    id="matKhauHienTai"
                    className={
                      !errors.matKhauHienTai
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Mật khẩu hiện tại"
                  />
                  <span className="password-toogle-icon">{Icon}</span>
                  <span className="message-e">
                    {errors.matKhauHienTai?.message}
                  </span>
              </div>
            </div>
            <div className="row justify-content-center">
                <div class="input-group-lg">
                  <input
                    type="password"
                    {...register("matKhauMoi")}
                    id="matKhauMoi"
                    className={
                      !errors.matKhauMoi
                        ? "form-control  "
                        : "form-control border-danger"
                    }
                    placeholder="Mật khẩu mới"
                  />
                  <span className="message-e">{errors.matKhauMoi?.message}</span>
                </div>
            </div>
            <div className="row justify-content-center">
                <div class="input-group-lg">
                  <input
                    type="password"
                    {...register("xacNhanMatKhau")}
                    id="xacNhanMatKhau"
                    className={
                      !errors.xacNhanMatKhau
                        ? "form-control  "
                        : "form-control  border-danger"
                    }
                    placeholder="Xác nhân mật khẩu mới"
                  />
                  <span className="message-e">
                    {errors.xacNhanMatKhau?.message}
                  </span>
              </div>
            </div>
          </div>
        </form>
        <div className="button">
          <input
            type="submit"
            className="btn btn-secondary "
            value="Huỷ"
            onClick={history.goBack}
          />
          <input
            type="submit"
            className="btn btn-primary ml-3"
            value="Lưu"
            onClick={handleSubmit(onHandleSubmit)}
          />
        </div>
      </div>
    </div>
  );
}

export default ChangePasswordForm;
