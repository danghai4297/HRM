import React from "react";
import { useForm } from "react-hook-form";
import { yupResolver } from "@hookform/resolvers/yup";
import "./ChangePasswordForm.scss";
import { useState } from "react";
import Dialog from "../../components/Dialog/Dialog";
import { useToast } from "../Toast/Toast";
import jwt_decode from "jwt-decode";
import LoginApi from "../../api/login";
import { useDocumentTitle } from "../../hook/TitleDocument";
import { schema } from "../../ultis/ChangePasswordValidation";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

function ChangePasswordForm(props) {
  const { error, warn, info, success } = useToast();

  const { history } = props;
  const [currentPassword, setCurrentPassword] = useState();
  const [newPassword, setNewPassword] = useState();
  const [rePassword, setRePassword] = useState();
  const [visible, setvisible] = useState(false);
  const [visibleNP, setvisibleNP] = useState(false);
  const [visibleRP, setvisibleRP] = useState(false);
  const [passwordType, setPasswordType] = useState("password");
  const [passwordTypeNP, setPasswordTypeNP] = useState("password");
  const [passwordTypeRP, setPasswordTypeRP] = useState("password");
  const handleClickEyesOP = () => {
    setvisible((visiblity) => !visiblity);
    setPasswordType(!visible ? "text" : "password");
  };
  const handleClickEyesNP = () => {
    setvisibleNP((visiblity) => !visiblity);
    setPasswordTypeNP(!visibleNP ? "text" : "password");
  };
  const handleClickEyesRP = () => {
    setvisibleRP((visiblity) => !visiblity);
    setPasswordTypeRP(!visibleRP ? "text" : "password");
  };
  const [showDialog, setShowDialog] = useState(false);
  const [description, setDescription] = useState(
    "Bạn chắc chắn muốn đổi mật khẩu mới."
  );
  const cancel = () => {
    setShowDialog(false);
  };
  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm({
    resolver: yupResolver(schema),
  });
  useDocumentTitle("Đổi mật khẩu");
  console.log(currentPassword);
  console.log(newPassword);
  console.log(rePassword);
  const idAccount = jwt_decode(sessionStorage.getItem("resultObj")).idAccount;
  const onHandleSubmit = async (data) => {
    if (currentPassword !== newPassword && newPassword === rePassword) {
      try {
        await LoginApi.PutChangePassword(data, idAccount);
        success("Đổi mật khẩu thành công.");
        history.goBack();
      } catch (errors) {
        error("Đổi mật khẩu không thành công!");
      }
    } else if (currentPassword === newPassword) {
      warn("Mật khẩu mới trùng với mật khẩu cũ.");
    } else if (newPassword !== rePassword) {
      warn("Nhập lại mật khẩu không đúng.");
    }
  };
  return (
    <>
    <div className="container-form">
      <div className="Submit-form">
        <div className="setH2">
          <h2>Mật khẩu</h2>
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
                  Nhập mật khẩu có tối thiểu 8 - 16 kí tự bao gồm số, chữ hoa,
                  chữ thường và kí tự đặc biệt.
                </p>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                  <div class="input-group">
                    <input
                      type={passwordType}
                      {...register("oldPassword", {
                        onChange: (e) => setCurrentPassword(e.target.value),
                      })}
                      className={
                        !errors.oldPassword
                          ? "form-control  "
                          : "form-control border-danger "
                      }
                      placeholder="Mật khẩu hiện tại"
                    />
                    <div class="input-group-append">
                      <button
                        class="btn btn-outline-secondary"
                        type="button"
                        onClick={handleClickEyesOP}
                      >
                        <FontAwesomeIcon icon={visible ? "eye-slash" : "eye"} />
                      </button>
                    </div>
                  </div>
                </div>
                <span className="message-e">{errors.oldPassword?.message}</span>
              </div>
            </div>
            <div className="row justify-content-center">
              <div class="input-group-lg">
                <div className="input-eyes">
                 
                  <div class="input-group">
                    <input
                      type={passwordTypeNP}
                      {...register("newPassword", {
                        onChange: (e) => setNewPassword(e.target.value),
                      })}
                      className={
                        !errors.newPassword
                          ? "form-control  "
                          : "form-control border-danger "
                      }
                      placeholder="Thêm mật khẩu mới"
                    />
                    <div class="input-group-append">
                      <button
                        class="btn btn-outline-secondary"
                        type="button"
                        onClick={handleClickEyesNP}
                      >
                        <FontAwesomeIcon
                          icon={visibleNP ? "eye-slash" : "eye"}
                        />
                      </button>
                    </div>
                  </div>
                </div>
                <span className="message-e">{errors.newPassword?.message}</span>
              </div>
            </div>
            <div className="row justify-content-center">
         
              <div class="input-group-lg">
                <div className="input-eyes">
                  <div class="input-group">
                    <input
                      type={passwordTypeRP}
                      {...register("confirmPassword", {
                        onChange: (e) => setRePassword(e.target.value),
                      })}
                      className={
                        !errors.confirmPassword
                          ? "form-control  "
                          : "form-control border-danger "
                      }
                      placeholder="Thêm mật khẩu mới"
                    />
                    <div class="input-group-append">
                      <button
                        class="btn btn-outline-secondary"
                        type="button"
                        onClick={handleClickEyesRP}
                      >
                        <FontAwesomeIcon
                          icon={visibleRP ? "eye-slash" : "eye"}
                        />
                      </button>
                    </div>
                  </div>
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
            onClick={()=>setShowDialog(true)}
          />
        </div>
      </div>
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
    </>
  );
}

export default ChangePasswordForm;
