import React, { useEffect } from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import * as yup from "yup";
import usePasswordToggle from "./usePasswordToggle";
import { useState } from "react";
import DialogCheck from "../Dialog/DialogCheck";
import Dialog from "../../components/Dialog/Dialog";
import { useToast } from "../Toast/Toast";
import "./RegisterAccount.scss";
import PutApi from "../../api/putAAPI";
import DeleteApi from "../../../src/api/deleteAPI";
import ProductApi from "../../api/productApi";
import LoginApi from "../../api/login.js";
const passwordReg = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,16}$/g;
const schema = yup.object({
    maNhanVien:yup
    .string()
    .required("Mã nhân viên không được bỏ trống."),
  password: yup
    .string()
    .matches(passwordReg, "Mật khẩu không đúng định dạng.")
    .required("Mật khẩu hiện tại không được bỏ trống."),
  confirmPassword: yup
    .string()
    .matches(passwordReg, "Xác nhận mật khẩu không đúng định dạng.")
    .required("Mật khẩu mới không được bỏ trống."),
  userName: yup
    .string()
    .required("Tên đăng nhập không được bỏ trống."),
});
function RegisterAccount(props) {
  const { error, warn, info, success } = useToast();

  const { history } = props;
  const [passwordInputTypeOP, IconOP] = usePasswordToggle();
  const [passwordInputTypeNP, IconNP] = usePasswordToggle();
  const [passwordInputTypeRP, IconRP] = usePasswordToggle();
  const [currentPassword, setCurrentPassword] = useState();
  const [newPassword, setNewPassword] = useState();
  const [rePassword, setRePassword] = useState();
  const [dataIdEmployee, setDataIdEmployee] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseIdEmployee = await ProductApi.getAllNvMT();
        setDataIdEmployee(responseIdEmployee);
        // if (id !== undefined) {
        // }
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

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

  const onHandleSubmit = async (data) => {
    console.log(data);
    if (newPassword === rePassword) {
      await LoginApi.PostAcc(data);
      success("Thêm tài khoản thành công");
      history.goBack();
    } else if (newPassword !== rePassword) {
      warn("Nhập lại mật khẩu không đúng.");
    }
  };
  return (
    <div className="container-form">
      <div className="Submit-form">
        <div className="setH2">
          <h2>Đăng ký tài khoản</h2>
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
                <h3>Thông tin tài khoản</h3>
                <p>
                  Nhập mật khẩu có tối thiểu 8 - 16 kí tự bao gồm số, chữ hoa,
                  chữ thường và kí tự đặc biệt.
                </p>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type="text"
                    {...register("maNhanVien")}
                    id="maNhanVien"
                    className={
                      !errors.maNhanVien
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Mã nhân viên"
                    list="employees"
                  />
                  <datalist id="employees">
                    {dataIdEmployee.map((item, key) => (
                      <option key={key} value={item.id}>
                        {item.hoTen}
                      </option>
                    ))}
                  </datalist>
                </div>
                <span className="message-e">{errors.maNhanVien?.message}</span>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type="text"
                    {...register("userName")}
                    id="userName"
                    className={
                      !errors.userName
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Tên tài khoản"
                  />
                </div>
                <span className="message-e">{errors.userName?.message}</span>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeNP}
                    {...register("password", {
                      onChange: (e) => setNewPassword(e.target.value),
                    })}
                    id="password"
                    className={
                      !errors.password
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Mật khẩu"
                  />
                  <span className="password-toogle-icon-np">{IconNP}</span>
                </div>
                <span className="message-e">{errors.password?.message}</span>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <input
                    type={passwordInputTypeRP}
                    {...register("confirmPassword", {
                      onChange: (e) => setRePassword(e.target.value),
                    })}
                    id="confirmPassword"
                    className={
                      !errors.confirmPassword
                        ? "form-control  "
                        : "form-control border-danger "
                    }
                    placeholder="Xác nhận mật khẩu"
                  />
                  <span className="password-toogle-icon-rp">{IconRP}</span>
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

export default RegisterAccount;
