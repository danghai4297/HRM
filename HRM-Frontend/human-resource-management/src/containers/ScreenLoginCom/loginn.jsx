import React, { useEffect } from "react";
import PropTypes from "prop-types";
import { useHistory } from "react-router-dom";
import "./Login.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import LoginApi from "../../api/login";
import { useForm } from "react-hook-form";
import jwt_decode from "jwt-decode";
import { useToast } from "../../components/Toast/Toast";

LogIn.propTypes = {};

function LogIn(props) {
  let history = useHistory();

  const { error, warn, info, success } = useToast();

  const {
    register,
    handleSubmit,
    // formState: { errors },
  } = useForm({
    // resolver: yupResolver(schema),
  });

  const onHandleSubmit = async (data) => {
    try {
      await LoginApi.PostLoginAccount(data);
      if (jwt_decode(sessionStorage.getItem("resultObj")).role === "user") {
        history.replace("/home");
      } else if (
        jwt_decode(sessionStorage.getItem("resultObj")).role === "admin"
      ) {
        history.replace("/category");
      }
    } catch (e) {
      error("Nhập sai tài khoản hoặc mật khẩu");
    }
    const listRole = jwt_decode(sessionStorage.getItem("resultObj")).role.split(
      ","
    );
    console.log(listRole);
  };

  return (
    <div className="loginn">
      <div className="form-login">
        <div className="left-login">
          <img src="/Images/loginImage.png" alt="" />
        </div>
        <div className="right-login">
          <div className="logo">
            <h1>3HMD</h1>
          </div>
          <div className="form-group">
            <span>
              <FontAwesomeIcon icon={["fas", "user"]} />
            </span>
            <input
              type="text"
              {...register("userName")}
              id="userName"
              placeholder="Tài khoản"
            />
          </div>
          <div className="form-group">
            <span>
              <FontAwesomeIcon icon={["fas", "lock"]} />
            </span>
            <input
              type="password"
              {...register("password")}
              id="password"
              placeholder="Mật khẩu"
            />
          </div>
          <input
            onClick={handleSubmit(onHandleSubmit)}
            type="submit"
            value="ĐĂNG NHẬP"
          />
        </div>
      </div>
    </div>
  );
}

export default LogIn;
