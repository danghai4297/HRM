import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailDiscipline.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
import { ttkl } from "./DataDiscipline";
function ScreenDetailDiscipline(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataKLDetail, setDataKLDetail] = useState([]);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getKTvKLDetail(id);
        setDataKLDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataKLDetail);

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
            <h2>Thủ tục kỷ luật</h2>
          </div>
          <div className="third-path">
            <Link to={`/discipline/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
            {dataKLDetail.bangChung !== null && (
              <Button
                variant="light"
                className="btn-fix"
                onClick={() => {
                  window.open(
                    `https://localhost:5001${dataKLDetail.bangChung}`
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
        <div className="second-main">
          <h3 className="title-main">Thông tin kỷ luật</h3>
          <div className="second-main-path">
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
            <button className="btn-fix">
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
