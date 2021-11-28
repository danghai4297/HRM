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

  return (
    <>
      <div className="main-screen-discipline">
        <div className="first-main-discipline">
          <div className="first-path-discipline">
            <button className="btn-back-discipline" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-discipline">
            <h2>Thủ tục kỷ luật</h2>
          </div>
          <div className="third-path-discipline">
            <Link to={`/discipline/${id}`}>
              <Button variant="light" className="btn-fix-discipline">
                Sửa
              </Button>
            </Link>
            {dataKLDetail.bangChung !== null && (
              <Button
                variant="light"
                className="btn-fix-discipline"
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
              titleRight={null}
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
