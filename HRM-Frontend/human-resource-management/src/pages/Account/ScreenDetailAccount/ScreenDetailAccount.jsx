import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenDetailAccount.scss";
import SubDetail from "../../../components/SubDetail/SubDetail";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataAccount";
import LoginApi from "../../../api/login";
import { useToast } from "../../../components/Toast/Toast";
import jwt_decode from "jwt-decode";
import Dialog from "../../../components/Dialog/Dialog";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

function ScreenDetailAccount(props) {
  let { match, history } = props;
  let { id } = match.params;
  const { success, warn, error } = useToast();

  const [dataDetailTk, setdataDetailTk] = useState([]);
  const [resetPassword, setResetPassword] = useState();
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  useDocumentTitle("Chi tiết tài khoản");

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
  const cancel = () => {
    setShowDeleteDialog(false);
  };

  const handleDelete = async () => {
    try {
      await LoginApi.deleteAccount(id);
      history.goBack();
      success(
        `Xoá tài khoản ${dataDetailTk.userName} của nhân viên ${dataDetailTk.fullName} thành công`
      );
    } catch (errors) {
      error(`Có lỗi xảy ra.`);
    }
  };

  return (
    <>
      <div className="main-screen-account">
        <div className="first-main-account">
          <div className="first-path-account">
            <IconButton className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </IconButton>
          </div>
          <div className="second-path-account">
            <h2>Chi tiết tài khoản</h2>
          </div>
          <div className="third-path-account">
            <Link to={`/account/addRole/${id}`}>
              <Button variant="light" className="btn-fix-account">
                Thêm quyền
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
              Mật khẩu mới
            </Button>
            <Button
              variant="contained"
              color="error"
              className="btn-fix-account"
              onClick={() => setShowDeleteDialog(true)}
            >
              Xóa
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
      <Dialog
        show={showDeleteDialog}
        title="Thông báo"
        description={`Bạn chắc chắn muốn xóa tài khoản này không `}
        confirm={handleDelete}
        cancel={cancel}
      />
    </>
  );
}

export default ScreenDetailAccount;
