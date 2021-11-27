import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailAccount.scss";
import SubDetail from "../../components/Detail/SubDetail";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataAccount";
import LoginApi from "../../api/login";
import { useToast } from "../../components/Toast/Toast";
import jwt_decode from "jwt-decode";
function ScreenDetailAccount(props) {
  let { match, history } = props;
  let { id } = match.params;
  const { success, warn } = useToast();

  const [dataDetailTk, setdataDetailTk] = useState([]);
  const [resetPassword, setResetPassword] = useState();

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseKT = await LoginApi.getTkDetail(id);
        setdataDetailTk(responseKT);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  return (
    <>
      <div className="main-screen-account">
        <div className="first-main-account">
          <div className="first-path-account">
            <button className="btn-back-account" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-account">
            <h2>Chi tiết tài khoản</h2>
          </div>
          <div className="third-path-account">
            <Link to={`/account/addRole/${id}`}>
              <Button variant="light" className="btn-fix-account">
                Role
              </Button>
            </Link>
            <Button
              variant="light"
              className="btn-fix-account"
              onClick={async () => {
                if (
                  sessionStorage.getItem("resultObj") &&
                  jwt_decode(sessionStorage.getItem("resultObj")).userName ===
                    dataDetailTk.userName
                ) {
                  warn(`Không được tự reset tài khoản này`);
                } else {
                  setResetPassword(await LoginApi.getResetPassword(id));
                  success(
                    `Reset mật khẩu tài khoản ${dataDetailTk.userName} thành công`
                  );
                }
              }}
            >
              Reset
            </Button>
          </div>
        </div>
        <div className="second-main-account">
          <h3 className="title-main-account">Thông tin chung</h3>
          <div className="second-main-path-account">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailTk[detail.data1[0]] !== null
                      ? dateFormat(dataDetailTk[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailTk[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={dataDetailTk[detail.data2]}
                />
              );
            })}
            <SubDetail
              titleLeft="Quyền tài khoản"
              itemLeft={
                dataDetailTk.roles && dataDetailTk.roles.length === 2
                  ? `${dataDetailTk.roles[0]}, ${dataDetailTk.roles[1]}`
                  : dataDetailTk.roles
              }
              titleRight={resetPassword ? "Mật khẩu mới" : null}
              itemRight={resetPassword}
            />
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailAccount;
