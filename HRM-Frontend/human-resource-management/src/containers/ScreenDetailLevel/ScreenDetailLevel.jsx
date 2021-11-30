import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailLevel.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataLevel";

function ScreenDetailLevel(props) {
  let { match, history } = props;
  let { id } = match.params;
  const [dataDetailTD, setdataDetailTD] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseTD = await ProductApi.getTDDetail(id);
        setdataDetailTD(responseTD);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

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
              <Button variant="light" className="btn-fix">
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
    </>
  );
}

export default ScreenDetailLevel;
