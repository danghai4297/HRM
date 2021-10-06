import React, { useState } from "react";
import "./Header.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
function Header() {
  const [account, setAccount] = useState(false);
  const visionHandleClick = () => {
    setAccount(!account);
  };
  return (
    <div>
      <div className="header-com">
        <div className="name">
          <div className="title-project">
            <h1>HRM</h1>
          </div>
        </div>
        <div className="account">
          <div className="screen-account" onClick={visionHandleClick}>
            <div className="header-icon">
              <FontAwesomeIcon
                icon={["fas", "user-circle"]}
                className="detail-icon"
              />
            </div>
            <div className="account-name">
              <h5 className="account-style">DangHai</h5>
            </div>
          </div>
          {account && (
            <div className="detail-information">
              <div className="first-information">
                <div className="detail-second-icon">
                  <FontAwesomeIcon icon={["fas", "user-circle"]} />
                </div>
                <div>
                  <h5>DangHai</h5>
                </div>
                <div>
                  <button className="button-account">
                    <FontAwesomeIcon icon={["fas", "key"]} /> Đổi mật khẩu
                  </button>
                </div>
              </div>
              <div>
                <button className="button-account">
                  <FontAwesomeIcon icon={["fas", "sign-out-alt"]} /> Đăng xuất
                </button>
              </div>
            </div>
          )}
        </div>
      </div>
    </div>
  );
}

export default Header;
