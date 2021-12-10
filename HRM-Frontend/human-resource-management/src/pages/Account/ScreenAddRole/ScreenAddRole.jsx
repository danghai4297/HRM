import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenAddRole.scss";
import LoginApi from "../../../api/login";
import { useToast } from "../../../components/Toast/Toast";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

function ScreenAddRole(props) {
  const { error, warn, info, success } = useToast();
  let { match, history } = props;
  let { id } = match.params;
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
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

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
          id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
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
    } catch (e) {
      error("Không thành công!");
    }
    console.log({
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
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
    });
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
              />
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenAddRole;
