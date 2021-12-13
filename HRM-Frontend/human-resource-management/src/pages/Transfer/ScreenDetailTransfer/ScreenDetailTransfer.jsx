import React, { useEffect, useState } from "react";
import SubDetail from "../../../components/SubDetail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenDetailTransfer.scss";
import ProductApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { vtctht } from "./DataTransfer";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import { createTheme } from "@mui/material/styles";
import { grey } from "@mui/material/colors";
function ScreenDetailTransfer(props) {
  let { match, history } = props;
  let { id } = match.params;
  const theme = createTheme({
    palette: {
      primary: {
        main: grey[50],
      },
      secondary: {
        main: "#f44336",
      },
    },
  });

  const [dataDetailDC, setDataDetailDC] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getDCDetail(id);
        setDataDetailDC(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
        history.goBack();
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailDC.length !== 0)
        document.title = `Chi tiết vị trí công tác hiện tại của nhân viên ${dataDetailDC.tenNhanVien}`;
    };
    titlePage();
  }, [dataDetailDC]);

  return (
    <>
      <div className="main-screen-transfer">
        <div className="first-main-transfer">
          <div className="first-path-transfer">
            <IconButton className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </IconButton>
          </div>
          <div className="second-path-transfer">
            <h2>Quá trình công tác</h2>
          </div>
          <div className="third-path-transfer">
            <Link to={`/transfer/${id}`}>
              <Button
                variant="contained"
                theme={theme}
                className="btn-fix-transfer"
              >
                Sửa
              </Button>
            </Link>
            {dataDetailDC.bangChung !== null && (
              <Button
                variant="contained"
                className="btn-fix-transfer"
                theme={theme}
                onClick={() => {
                  window.open(
                    `https://localhost:5001${dataDetailDC.bangChung}`
                  );
                }}
              >
                <FontAwesomeIcon
                  className="icon-btn"
                  icon={["fas", "download"]}
                />
              </Button>
            )}
          </div>
        </div>
        <div className="second-main-transfer">
          <h3 className="title-main-transfer">Vị trí công tác hiện tại</h3>
          <div className="second-main-path-transfer">
            {vtctht.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailDC[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailDC[detail.data2[0]] !== null
                      ? dateFormat(dataDetailDC[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailDC[detail.data2[0]]
                  }
                />
              );
            })}
            <SubDetail
              titleLeft="Tệp đính kèm"
              itemLeft={dataDetailDC.bangChung === null ? "Không" : "Có"}
              titleRight={null}
            />
          </div>
        </div>
        <div className="all-transfer">
          <div className="name-move-transfer">
            <h3>Tất cả quá trình công tác</h3>
          </div>
          <Link
            to={`/profile/detail/${dataDetailDC.maNhanVien}?move=moveToTransfer`}
            className="btn-move-transfer"
          >
            <button className="btn-fix-transfer">
              <FontAwesomeIcon
                icon={["fas", "arrow-right"]}
                style={{ fontSize: "50px" }}
              />
            </button>
          </Link>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailTransfer;
