import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenDetailContract.scss";
import SubDetail from "../../../components/SubDetail/SubDetail";
import ProductApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataContract";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import { createTheme } from "@mui/material/styles";
import { grey } from "@mui/material/colors";

function ScreenDetailContract(props) {
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

  const [dataDetailHd, setdataDetailHd] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseHD = await ProductApi.getHdDetail(id);
        setdataDetailHd(responseHD);
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
      if (dataDetailHd.length !== 0)
        document.title = `Chi tiết hợp đồng của nhân viên ${dataDetailHd.tenNhanVien}`;
    };
    titlePage();
  }, [dataDetailHd]);

  return (
    <>
      <div className="main-screen-contract">
        <div className="first-main-contract">
          <div className="first-path-contract">
            <IconButton className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </IconButton>
          </div>
          <div className="second-path-contract">
            <h2>Chi tiết hợp đồng</h2>
          </div>
          <div className="third-path-contract">
            {dataDetailHd.trangThai === "Kích hoạt" && (
              <Link to={`/contract/${id}`}>
                <Button
                  variant="contained"
                  theme={theme}
                  className="btn-fix-contract"
                >
                  Sửa
                </Button>
              </Link>
            )}
            {dataDetailHd.bangChung !== null && (
              <Button
                variant="contained"
                theme={theme}
                className="btn-fix-contract"
                onClick={() => {
                  window.open(`http://localhost:8000${dataDetailHd.bangChung}`);
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
        <div className="second-main-contract">
          <h3 className="title-main-contract">Thông tin chung</h3>
          <div className="second-main-path-contract">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailHd[detail.data1[0]] !== null
                      ? dateFormat(dataDetailHd[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailHd[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailHd[detail.data2[0]] !== null
                      ? dateFormat(dataDetailHd[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailHd[detail.data2[0]]
                  }
                />
              );
            })}
            <SubDetail
              titleLeft="Tệp đính kèm"
              itemLeft={dataDetailHd.bangChung === null ? "Không" : "Có"}
              titleRight={null}
            />
          </div>
        </div>
        <div className="all-contract-contract">
          <div className="name-move-contract">
            <h3>Tất cả hợp đồng</h3>
          </div>
          <Link
            to={`/profile/detail/${dataDetailHd.maNhanVien}?move=moveToContract`}
            className="btn-move-contract"
          >
            <button className="btn-fix-contract">
              <FontAwesomeIcon
                className="icon-contract"
                icon={["fas", "arrow-right"]}
              />
            </button>
          </Link>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailContract;
