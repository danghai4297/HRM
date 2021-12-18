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
import ProductApi from "../../../api/productApi";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function ScreenDetailAccount(props) {
  let { match, history } = props;
  let { id } = match.params;
  const { success, warn, error } = useToast();
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);

  const [dataDetailTk, setdataDetailTk] = useState([]);
  const [resetPassword, setResetPassword] = useState();
  const [showDeleteDialog, setShowDeleteDialog] = useState(false);
  const [open, setOpen] = useState(false);
  useDocumentTitle("Chi tiết tài khoản");

  useEffect(() => {
    const fetchDetailAccount = async () => {
      try {
        const responseKT = await LoginApi.getTkDetail(id);
        setdataDetailTk(responseKT);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
        history.goBack();
      }
    };
    fetchDetailAccount();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataDetailTk]);

  const cancel = () => {
    setShowDeleteDialog(false);
  };

  const resetNewPassword = async () => {
    if (
      sessionStorage.getItem("resultObj") &&
      jwt_decode(sessionStorage.getItem("resultObj")).userName ===
        dataDetailTk.userName
    ) {
      warn(`Không được tự reset tài khoản này`);
    } else {
      setResetPassword(await LoginApi.getResetPassword(id));
      await ProductApi.PostLS({
        tenTaiKhoan: decoded.userName,
        thaoTac: `Đổi mật khẩu mới cho tài khoản ${dataDetailTk.userName}`,
        maNhanVien: decoded.id,
        tenNhanVien: decoded.givenName,
      });
      success(`Reset mật khẩu tài khoản ${dataDetailTk.userName} thành công`);
    }
  };

  const handleDeleteAccount = async () => {
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
              <Button
                variant="contained"
                color="success"
                className="btn-fix-account"
              >
                Thêm quyền
              </Button>
            </Link>
            <Button
              variant="contained"
              color="secondary"
              className="btn-fix-account"
              onClick={resetNewPassword}
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
        confirm={handleDeleteAccount}
        cancel={cancel}
      />
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default ScreenDetailAccount;
