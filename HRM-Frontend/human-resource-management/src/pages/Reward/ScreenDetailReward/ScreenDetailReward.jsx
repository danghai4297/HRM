import React, { useEffect, useState } from "react";
import SubDetail from "../../../components/SubDetail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import "./ScreenDetailReward.scss";
import ProductApi from "../../../api/productApi";
import { Link } from "react-router-dom";
import { ttkt } from "./DataReward";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import { createTheme } from "@mui/material/styles";
import { grey } from "@mui/material/colors";
function ScreenDetailReward(props) {
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

  const [dataDetailKt, setdataDetailKt] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseKT = await ProductApi.getKTvKLDetail(id);
        setdataDetailKt(responseKT);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailKt.length !== 0)
        document.title = `Chi tiết khen thưởng của nhân viên ${dataDetailKt.hoTen}`;
    };
    titlePage();
  }, [dataDetailKt]);

  return (
    <>
      <div className="main-screen-reward">
        <div className="first-main-reward">
          <div className="first-path-reward">
            <IconButton className="btn-back-reward" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </IconButton>
          </div>
          <div className="second-path-reward">
            <h2>Thủ tục khen thưởng</h2>
          </div>
          <div className="third-path-reward">
            <Link to={`/reward/${id}`}>
              <Button
                variant="contained"
                theme={theme}
                className="btn-fix-reward"
              >
                Sửa
              </Button>
            </Link>
            {dataDetailKt.bangChung !== null && (
              <Button
                variant="contained"
                theme={theme}
                className="btn-fix-reward"
                onClick={() => {
                  window.open(
                    `https://localhost:5001${dataDetailKt.bangChung}`
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
        <div className="second-main-reward">
          <h3 className="title-main-reward">Thông tin khen thưởng</h3>
          <div className="second-main-path-reward">
            {ttkt.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailKt[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={dataDetailKt[detail.data2]}
                />
              );
            })}
            <SubDetail
              titleLeft="Tệp đính kèm"
              itemLeft={dataDetailKt.bangChung === null ? "Không" : "Có"}
              titleRight="Nội dung"
              itemRight={dataDetailKt.noiDung}
            />
          </div>
        </div>
        <div className="all-reward">
          <div className="name-move-reward">
            <h3>Tất cả lần khen thưởng</h3>
          </div>
          <Link
            to={`/profile/detail/${dataDetailKt.maNhanVien}?move=moveToReward`}
            className="btn-move-reward"
          >
            <button className="btn-fix-reward">
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

export default ScreenDetailReward;
