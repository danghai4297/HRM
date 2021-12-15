import React, { useEffect, useState } from "react";
import SubDetail from "../../../../components/SubDetail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import Button from "@mui/material/Button";
import { createTheme } from "@mui/material/styles";
import { indigo } from "@mui/material/colors";
import "./ScreenDetailForeignLanguage.scss";
import ProductApi from "../../../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataForeignLanguage";
function ScreenDetailForeignLanguage(props) {
  let { match, history } = props;
  let { id } = match.params;
  const theme = createTheme({
    palette: {
      primary: {
        main: indigo[400],
      },
    },
  });
  const [dataDetailNN, setdataDetailNN] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNN = await ProductApi.getNNDetail(id);
        setdataDetailNN(responseNN);
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
      if (dataDetailNN.length !== 0)
        document.title = `Chi tiết ngoại ngữ nhân viên ${dataDetailNN.tenNhanVien}`;
    };
    titlePage();
  }, [dataDetailNN]);

  return (
    <>
      <div className="main-screen-language">
        <div className="first-main-language">
          <div className="first-path-language">
            <button className="btn-back-language" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-language">
            <h2>Ngoại ngữ</h2>
          </div>
          <div className="third-path-language">
            <Link to={`/profile/detail/language/update/${id}`}>
              <Button
                variant="contained"
                theme={theme}
                className="btn-fix-language"
              >
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main-language">
          <h3 className="title-main-language">Thông tin chung</h3>
          <div className="second-main-path-language">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNN[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNN[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNN[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNN[detail.data2[0]]
                  }
                />
              );
            })}
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailForeignLanguage;
