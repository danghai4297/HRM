import React from "react";
import PropTypes from "prop-types";
import "./Login.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";

LogIn.propTypes = {};

function LogIn(props) {
  return (
    <div className="loginn">
      <div className="form-login">
        <div className="left-login">
          <img
            src="https://cdn.discordapp.com/attachments/806041775910158346/889907940209872927/businessman_1.png"
            alt=""
          />
        </div>
        <div className="right-login">
          <div className="logo">
            <h1>HRM</h1>
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
          <input type="submit" value="ĐĂNG NHẬP" />
        </div>
      </div>
    </div>
  );
}

export default LogIn;
