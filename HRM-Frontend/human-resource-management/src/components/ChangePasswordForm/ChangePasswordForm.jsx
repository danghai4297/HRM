import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import "./ChangePasswordForm.scss";
import usePasswordToggle from "./usePasswordToggle";
import { useState } from "react";
import DialogCheck from "../Dialog/DialogCheck";
import Dialog from "../../components/Dialog/Dialog";
import { useToast } from "../Toast/Toast";

const passwordReg = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$/g;
const schema = yup.object({
  matKhauHienTai: yup
    .string()
    .matches(passwordReg, "Mật khẩu hiện tại không đúng định dạng.")
    .required("Mật khẩu hiện tại không được bỏ trống."),
  matKhauMoi: yup
    .string()
    .matches(passwordReg, "Mật khẩu hiện tại không đúng định dạng.")
    .required("Mật khẩu mới không được bỏ trống."),
  xacNhanMatKhau: yup
    .string()
    .matches(passwordReg, "Mật khẩu hiện tại không đúng định dạng.")
    .required("Xác nhận mật khẩu mới không được bỏ trống."),
});

function ChangePasswordForm(props) {
  const { error, warn, info, success } = useToast();

  const { history } = props;
  const [passwordInputTypeOP, IconOP] = usePasswordToggle();
  const [passwordInputTypeNP, IconNP] = usePasswordToggle();
  const [passwordInputTypeRP, IconRP] = usePasswordToggle();
  const [currentPassword,setCurrentPassword]= useState();
  const [newPassword,setNewPassword]= useState();
  const [rePassword,setRePassword]= useState();
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  console.log(currentPassword);
  console.log(newPassword);
  console.log(rePassword);
  
  const onHandleSubmit = (data) => {
    if(currentPassword !== newPassword && newPassword === rePassword){
      console.log(data);
      success("Đổi mật khẩu thành công.")
    }else if(currentPassword === newPassword){
      warn("Mật khẩu mới trùng với mật khẩu cũ.");
    }else if(newPassword !== rePassword){
      warn("Nhập lại mật khẩu không đúng.")
    }
   // history.goBack();
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
            <div className="container-password">
              <div className="">
                <h3>Thay đổi mật khẩu</h3>
                <p>
                  Nhập mật khẩu có tối thiểu 8 - 16 kí tự bao gồm số, chữ hoa, chữ
                  thường và kí tự đặc biệt.
                </p>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeOP}
                    {...register("matKhauHienTai",{onChange : (e)=>setCurrentPassword(e.target.value)})}
                    id="matKhauHienTai"
                    className={
                      !errors.matKhauHienTai
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Mật khẩu hiện tại"
                  />
                  <span className="password-toogle-icon">{IconOP}</span>
                </div>
                <span className="message-e">
                  {errors.matKhauHienTai?.message}
                </span>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeNP}
                    {...register("matKhauMoi",{onChange : (e)=>setNewPassword(e.target.value)})}
                    id="matKhauMoi"
                    className={
                      !errors.matKhauMoi
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Thêm mật khẩu mới"
                  />
                  <span className="password-toogle-icon-np">{IconNP}</span>
                </div>
                <span className="message-e">{errors.matKhauMoi?.message}</span>
              </div>
            </div>
            <div className="row justify-content-center">
              {/* <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeRP}
                    {...register("xacNhanMatKhau")}
                    id="xacNhanMatKhau"
                    className={
                      !errors.xacNhanMatKhau
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Xác nhận mật khẩu mới"
                  />
                  <span className="password-toogle-icon-rp">{IconRP}</span>
                </div>
                <span className="message-e">
                  {errors.xacNhanMatKhau?.message}
                </span>
              </div> */}
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeRP}
                    {...register("xacNhanMatKhau",{onChange : (e)=>setRePassword(e.target.value)})}
                    id="xacNhanMatKhau"
                    className={
                      !errors.xacNhanMatKhau
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Xác nhận mật khẩu mới"
                  />
                  <span className="password-toogle-icon-rp">{IconRP}</span>
                </div>
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
