import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenAddRole.scss";
import LoginApi from "../../../api/login";
import { useToast } from "../../../components/Toast/Toast";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import jwt_decode from "jwt-decode";
import ProductApi from "../../../api/productApi";

function ScreenAddRole(props) {
  const { error, success } = useToast();
  let { match, history } = props;
  let { id } = match.params;
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  useDocumentTitle("Thêm quyền cho tài khoản");

  const [dataDetailTk, setdataDetailTk] = useState([]);
  const [roless, setRoless] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseKT = await LoginApi.getTkDetail(id);
        setdataDetailTk(responseKT);
        setRoless(responseKT.roles);
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailTk);
  const [checkUser, setCheckUser] = useState(false);

  const handleClickUser = () => setCheckUser(!checkUser);

  const [checkAdmin, setCheckAdmin] = useState(false);
  const handleClickAdmin = () => setCheckAdmin(!checkAdmin);

  useEffect(() => {
    setCheckUser(roless.includes("user"));
    setCheckAdmin(roless.includes("admin"));
  }, [roless]);

  const onHandleSubmit = async () => {
    try {
      await LoginApi.PutRole(
        {
          roles: [
            {
              id: "8D04DCE2-969A-435D-BBA4-DF3F325983DC",
              name: "admin",
              selected: checkAdmin,
            },
            {
              id: "30c6f17d-e44f-4e5d-9bf9-1bd98c377cec",
              name: "user",
              selected: checkUser,
            },
          ],
        },
        id
      );
      success("Thành công.");
      history.goBack();
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Thêm quyền tài khoản ${dataDetailTk.userName}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
    } catch (e) {
      error("Không thành công!");
    }
  };

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
            <input
              type="checkbox"
              id="User"
              onClick={handleClickUser}
              checked={checkUser}
            />
            <label htmlFor="User">User</label>
            <input
              type="checkbox"
              id="Admin"
              onClick={handleClickAdmin}
              checked={checkAdmin}
            />
            <label htmlFor="Admin">Admin</label>
            <div>
              <input
                type="submit"
                className="btn btn-primary ml-3"
                value={"Thêm"}
                onClick={onHandleSubmit}
                disabled={checkUser === false && checkAdmin === false}
              />
              {checkUser === false && checkAdmin === false && (
                <div>
                  <span style={{ color: "red" }}>
                    Bạn chưa chọn quyền cho tài khoản
                  </span>
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenAddRole;
