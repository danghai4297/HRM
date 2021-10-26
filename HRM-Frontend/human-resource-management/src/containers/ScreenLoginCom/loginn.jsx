import React from "react";
import PropTypes from "prop-types";
import { Link, useHistory } from "react-router-dom";
import "./Login.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import LoginApi from "../../api/login";
import { useForm } from "react-hook-form";

LogIn.propTypes = {};

function LogIn(props) {
  let history = useHistory();
  let login = () => {
    localStorage.setItem("abc", true);
    history.replace("/home");
  };

  const {
    register,
    handleSubmit,
    // formState: { errors },
  } = useForm({
    // resolver: yupResolver(schema),
  });

  console.log(localStorage.getItem("token"));
  const onHandleSubmit = async (data) => {
    try {
      console.log(data);
      await LoginApi.PostLoginAccount(data);
      history.replace("/home");
    } catch (error) {
      alert("hahahaha thang ngu m nhap sai roi");
    }
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
          <form action="">
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
            {/* <div className="form-group">
              <span>
                <FontAwesomeIcon icon={["fas", "lock"]} />
              </span>
              <input
                type="text"
                {...register("rememberMe")}
                id="rememberMe"
                value="true"
              />
            </div> */}
          </form>
          <input onClick={login} type="submit" value="ĐĂNG NHẬP" />
          <input
            onClick={handleSubmit(onHandleSubmit)}
            type="submit"
            value="ĐĂNG NHẬP That"
          />
        </div>
      </div>
    </div>
  );
}

export default LogIn;
