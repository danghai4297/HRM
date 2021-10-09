import React from "react";
import PropTypes from "prop-types";
import { useHistory } from "react-router-dom";
import "./Login.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

LogIn.propTypes = {};

function LogIn(props) {
  let history = useHistory();
  let login = () =>{
    localStorage.setItem("accessToken", true);
    history.replace("/home")
  }
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
            <input type="text" name="user" id="user" placeholder="Tài khoản" />
          </div>
          <div className="form-group">
            <span>
              <FontAwesomeIcon icon={["fas", "lock"]} />
            </span>
            <input
              type="password"
              name="password"
              id="password"
              placeholder="Mật khẩu"
            />
          </div>
          <input onClick={login} type="submit" value="ĐĂNG NHẬP" />
        </div>
      </div>
    </div>
  );
}

export default LogIn;
