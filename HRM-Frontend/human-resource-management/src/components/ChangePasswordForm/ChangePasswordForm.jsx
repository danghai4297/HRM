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
import jwt_decode from "jwt-decode";
import LoginApi from "../../api/login";

const passwordReg = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$/g;
const schema = yup.object({
  oldPassword: yup
    .string()
    .matches(passwordReg, "Mật khẩu hiện tại không đúng định dạng.")
    .required("Mật khẩu hiện tại không được bỏ trống."),
    newPassword: yup
    .string()
    .matches(passwordReg, "Mật khẩu hiện tại không đúng định dạng.")
    .required("Mật khẩu mới không được bỏ trống."),
    confirmPassword: yup
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
  const idAccount = jwt_decode(sessionStorage.getItem("resultObj")).idAccount;
  const onHandleSubmit = async(data) => {
    if(currentPassword !== newPassword && newPassword === rePassword){
      console.log(data);
      try {
        await LoginApi.PutChangePassword(data,idAccount);
        success("Đổi mật khẩu thành công.")
      } catch (errors) {
        error("Đổi mật khẩu không thành công!");
      }
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
                    {...register("oldPassword",{onChange : (e)=>setCurrentPassword(e.target.value)})}
                    id="oldPassword"
                    className={
                      !errors.oldPassword
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Mật khẩu hiện tại"
                  />
                  <span className="password-toogle-icon">{IconOP}</span>
                </div>
                <span className="message-e">
                  {errors.oldPassword?.message}
                </span>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeNP}
                    {...register("newPassword",{onChange : (e)=>setNewPassword(e.target.value)})}
                    id="newPassword"
                    className={
                      !errors.newPassword
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Thêm mật khẩu mới"
                  />
                  <span className="password-toogle-icon-np1">{IconNP}</span>
                </div>
                <span className="message-e">{errors.newPassword?.message}</span>
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
                    {...register("confirmPassword",{onChange : (e)=>setRePassword(e.target.value)})}
                    id="confirmPassword"
                    className={
                      !errors.confirmPassword
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Xác nhận mật khẩu mới"
                  />
                  <span className="password-toogle-icon-rp1">{IconRP}</span>
                </div>
                <span className="message-e">
                  {errors.confirmPassword?.message}
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
