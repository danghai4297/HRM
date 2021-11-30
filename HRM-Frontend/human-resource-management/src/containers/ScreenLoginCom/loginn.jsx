import React, { useEffect } from "react";
import { useHistory } from "react-router-dom";
import "./Login.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import LoginApi from "../../api/login";
import { useForm } from "react-hook-form";
import jwt_decode from "jwt-decode";
import { useToast } from "../../components/Toast/Toast";
import { Button, Col, Row } from "react-bootstrap";
import { useDocumentTitle } from "../../hook/TitleDocument";

function LogIn(props) {
  let history = useHistory();

  const { error } = useToast();

  const { register, handleSubmit } = useForm({});

  useDocumentTitle("HRM Project");

  const onHandleSubmit = async (data) => {
    try {
      await LoginApi.PostLoginAccount(data);
      if (
        sessionStorage.getItem("resultObj") &&
        jwt_decode(sessionStorage.getItem("resultObj"))
          .role.split(";")
          .includes("user")
      ) {
        history.replace("/home");
      } else if (
        sessionStorage.getItem("resultObj") &&
        jwt_decode(sessionStorage.getItem("resultObj"))
          .role.split(";")
          .includes("admin")
      ) {
        history.replace("/category");
      }
    } catch (e) {
      error("Nhập sai tài khoản hoặc mật khẩu");
    }
  };

  return (
    <div className="loginn">
      <div className="form-login">
        <div className="left-login">
          <img src="/Images/loginImage.png" alt="" />
        </div>
        <div className="right-login">
          {sessionStorage.getItem("resultObj") ? (
            <>
              <div>
                {sessionStorage.getItem("resultObj") && (
                  <img
                    className="picture-account-login"
                    src={`https://localhost:5001/${
                      jwt_decode(sessionStorage.getItem("resultObj")).anh
                    }`}
                    alt=""
                  />
                )}
              </div>
              <div>
                <h4 className="text-login">
                  {sessionStorage.getItem("resultObj") &&
                    jwt_decode(sessionStorage.getItem("resultObj")).givenName}
                </h4>
              </div>
              <div>
                <h5>
                  Tài khoản:{" "}
                  {sessionStorage.getItem("resultObj") &&
                    jwt_decode(sessionStorage.getItem("resultObj")).userName}
                </h5>
              </div>
              <div>
                <h5>
                  Mã nhân viên:{" "}
                  {sessionStorage.getItem("resultObj") &&
                    jwt_decode(sessionStorage.getItem("resultObj")).id}
                </h5>
              </div>
              <Row className="btn-of-login">
                <Col>
                  <Button
                    variant="light"
                    onClick={() => {
                      if (
                        sessionStorage.getItem("resultObj") &&
                        jwt_decode(sessionStorage.getItem("resultObj"))
                          .role.split(";")
                          .includes("user")
                      ) {
                        history.replace("/home");
                      } else {
                        history.replace("/category");
                      }
                    }}
                  >
                    Quay lại
                  </Button>
                </Col>
                <Col>
                  <Button
                    variant="light"
                    onClick={() => {
                      sessionStorage.removeItem("resultObj");
                      history.go("/login");
                    }}
                  >
                    Thoát tài khoản
                  </Button>
                </Col>
              </Row>
            </>
          ) : (
            <>
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
            </>
          )}
        </div>
      </div>
    </div>
  );
}

export default LogIn;
