import React, { useEffect, useState } from "react";
import SubDetail from "../../../components/SubDetail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenDetailDiscipline.scss";
import ProductApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import { ttkl } from "./DataDiscipline";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import { createTheme } from "@mui/material/styles";
import { indigo, cyan } from "@mui/material/colors";
function ScreenDetailDiscipline(props) {
  let { match, history } = props;
  let { id } = match.params;
  const theme = createTheme({
    palette: {
      primary: {
        main: indigo[400],
      },
      secondary: {
        main: cyan[700],
      },
    },
  });
  const [dataKLDetail, setDataKLDetail] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getKTvKLDetail(id);
        setDataKLDetail(response);
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
      if (dataKLDetail.length !== 0)
        document.title = `Chi tiết kỷ luật của nhân viên ${dataKLDetail.hoTen}`;
    };
    titlePage();
  }, [dataKLDetail]);

  return (
    <>
      <div className="main-screen-discipline">
        <div className="first-main-discipline">
          <div className="first-path-discipline">
            <IconButton
              className="btn-back-discipline"
              onClick={history.goBack}
            >
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </IconButton>
          </div>
          <div className="second-path-discipline">
            <h2>Thủ tục kỷ luật</h2>
          </div>
          <div className="third-path-discipline">
            <Link to={`/discipline/${id}`}>
              <Button
                variant="contained"
                theme={theme}
                className="btn-fix-discipline"
              >
                Sửa
              </Button>
            </Link>
            {dataKLDetail.bangChung !== null && (
              <Button
                variant="contained"
                theme={theme}
                color="secondary"
                className="btn-fix-discipline"
                onClick={() => {
                  window.open(`http://localhost:8000${dataKLDetail.bangChung}`);
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
        <div className="second-main-discipline">
          <h3 className="title-main-discipline">Thông tin kỷ luật</h3>
          <div className="second-main-path-discipline">
            {ttkl.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataKLDetail[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={dataKLDetail[detail.data2]}
                />
              );
            })}
            <SubDetail
              titleLeft="Tệp đính kèm"
              itemLeft={dataKLDetail.bangChung === null ? "Không" : "Có"}
              titleRight="Nội dung"
              itemRight={dataKLDetail.noiDung}
            />
          </div>
        </div>
        <div className="all-discipline">
          <div className="name-move-discipline">
            <h3>Tất cả lần kỷ luật</h3>
          </div>
          <Link
            to={`/profile/detail/${dataKLDetail.maNhanVien}?move=moveToDiscipline`}
            className="btn-move-discipline"
          >
            <button className="btn-fix-discipline">
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

export default ScreenDetailDiscipline;
