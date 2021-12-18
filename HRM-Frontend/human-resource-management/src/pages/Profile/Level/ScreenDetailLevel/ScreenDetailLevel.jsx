import React, { useEffect, useState } from "react";
import SubDetail from "../../../../components/SubDetail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Button from "@mui/material/Button";
import "./ScreenDetailLevel.scss";
import ProductApi from "../../../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataLevel";
import { createTheme } from "@mui/material/styles";
import { indigo } from "@mui/material/colors";
import Backdrop from "@mui/material/Backdrop";
import CircularProgress from "@mui/material/CircularProgress";

function ScreenDetailLevel(props) {
  let { match, history } = props;
  let { id } = match.params;
  const theme = createTheme({
    palette: {
      primary: {
        main: indigo[400],
      },
    },
  });
  const [dataDetailTD, setdataDetailTD] = useState([]);
  const [open, setOpen] = useState(false);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseTD = await ProductApi.getTDDetail(id);
        setdataDetailTD(responseTD);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
        history.goBack();
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    setOpen(!open);
  }, [dataDetailTD]);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailTD.length !== 0)
        document.title = `Chi tiết trình độ nhân viên ${dataDetailTD.tenNhanVien}`;
    };
    titlePage();
  }, [dataDetailTD]);

  return (
    <>
      <div className="main-screen-level">
        <div className="first-main-level">
          <div className="first-path-level">
            <button className="btn-back-level" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-level">
            <h2>Trình độ</h2>
          </div>
          <div className="third-path-level">
            <Link to={`/profile/detail/level/update/${id}`}>
              <Button variant="contained" theme={theme} className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main-level">
          <h3 className="title-main-level">Thông tin chung</h3>
          <div className="second-main-path-level">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailTD[detail.data1[0]] !== null
                      ? dateFormat(dataDetailTD[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailTD[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailTD[detail.data2[0]] !== null
                      ? dateFormat(dataDetailTD[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailTD[detail.data2[0]]
                  }
                />
              );
            })}
          </div>
        </div>
      </div>
      <Backdrop
        sx={{ color: "#fff", zIndex: (theme) => theme.zIndex.drawer + 1 }}
        open={open}
      >
        <CircularProgress color="inherit" />
      </Backdrop>
    </>
  );
}

export default ScreenDetailLevel;
