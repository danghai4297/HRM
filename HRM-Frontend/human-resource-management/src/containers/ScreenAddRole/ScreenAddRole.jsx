import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenAddRole.scss";
import LoginApi from "../../api/login";
import { Button } from "react-bootstrap";
function ScreenAddRole(props) {
  let { match, history } = props;
  let { id } = match.params;
  console.log(id);

  const [dataDetailTk, setdataDetailTk] = useState([]);

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

  console.log(dataDetailTk);
  // console.log(dataDetailTk.resultObj.roles);
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <button className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path">
            <h2>Thêm quyền tài khoản</h2>
          </div>
        </div>
        <div className="second-main2">
          <h2 className="title-main">Quyền tài khoản</h2>
          <div className="second-main-path2">
            <h4>{dataDetailTk.fullName}</h4>
            <p>Mã nhân viên: {dataDetailTk.maNhanVien}</p>
            <p>Tài khoản: {dataDetailTk.userName}</p>
            <input type="checkbox" id="User" />
            <label htmlFor="User">User</label>
            <input type="checkbox" id="Admin" />
            <label htmlFor="Admin">Admin</label>
            <div>
              <input
                type="submit"
                className="btn btn-primary ml-3"
                value={"Thêm"}
              />
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenAddRole;
