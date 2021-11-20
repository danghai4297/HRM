import React, { useContext } from "react";
import "./Header.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { AccountContext } from "../../Contexts/StateContext";
import { useHistory, Link } from "react-router-dom";
import jwt_decode from "jwt-decode";
function Header() {
  const { account, setAccount } = useContext(AccountContext);
  let history = useHistory();
  let logout = () => {
    sessionStorage.removeItem("resultObj");
    history.replace("/login");
    setAccount(false);
  };
  return (
    <>
      <div className="header-com">
        <div className="name" onClick={() => setAccount(false)}></div>
        <div className="account">
          <button className="button-top" onClick={() => setAccount(!account)}>
            <div className="screen-account">
              <div className="header-icon">
                {sessionStorage.getItem("resultObj") &&
                jwt_decode(sessionStorage.getItem("resultObj")).anh !== null ? (
                  <img
                    className="picture-account"
                    src={`https://localhost:5001/${
                      jwt_decode(sessionStorage.getItem("resultObj")).anh
                    }`}
                    alt=""
                  />
                ) : (
                  <FontAwesomeIcon
                    icon={["fas", "user-circle"]}
                    className="detail-icon"
                  />
                )}
              </div>
              <div className="account-name">
                <h5 className="account-style">
                  {sessionStorage.getItem("resultObj") &&
                    jwt_decode(sessionStorage.getItem("resultObj")).givenName}
                </h5>
              </div>
            </div>
          </button>

          {account && (
            <div className="detail-information">
              <div className="first-information">
                <div className="detail-second-icon">
                  {sessionStorage.getItem("resultObj") &&
                  jwt_decode(sessionStorage.getItem("resultObj")).anh !==
                    null ? (
                    <img
                      className="picture-account-2"
                      src={`https://localhost:5001/${
                        jwt_decode(sessionStorage.getItem("resultObj")).anh
                      }`}
                      alt=""
                    />
                  ) : (
                    <FontAwesomeIcon
                      icon={["fas", "user-circle"]}
                      className="detail-icon"
                    />
                  )}
                </div>
                <div>
                  <h5>
                    {sessionStorage.getItem("resultObj") &&
                      jwt_decode(sessionStorage.getItem("resultObj")).givenName}
                  </h5>
                </div>
                <div>
                  <Link to="/change" onClick={() => setAccount(false)}>
                    <button className="button-account">
                      <FontAwesomeIcon icon={["fas", "key"]} /> Đổi mật khẩu
                    </button>
                  </Link>
                </div>
              </div>
              <div>
                <button onClick={logout} className="button-account">
                  <FontAwesomeIcon icon={["fas", "sign-out-alt"]} /> Đăng xuất
                </button>
              </div>
            </div>
          )}
        </div>
        <div className="last" onClick={() => setAccount(false)}></div>
      </div>
    </>
  );
}

export default Header;
