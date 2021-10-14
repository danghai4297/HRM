import React, { useContext } from "react";
import "./Header.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { AccountContext } from "../../Contexts/StateContext";
import { useHistory, Link } from "react-router-dom";
function Header() {
  const { account, setAccount } = useContext(AccountContext);
  let history = useHistory();
  let logout = () => {
    localStorage.removeItem("accessToken");
    history.replace("/login");
  };
  return (
    <>
      <div className="header-com" >
        <div className="name" onClick={() => setAccount(false)}>
          
        </div>
        <div className="account">
          <button className="button-top" onClick={() => setAccount(!account)}>
            <div className="screen-account">
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
          </button>

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
