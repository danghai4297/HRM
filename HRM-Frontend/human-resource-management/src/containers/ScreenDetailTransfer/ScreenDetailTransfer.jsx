import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailTransfer.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { vtctht } from "./DataTransfer";
function ScreenDetailTransfer(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDC, setDataDetailDC] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getDCDetail(id);
        setDataDetailDC(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  return (
    <>
      <div className="main-screen-transfer">
        <div className="first-main-transfer">
          <div className="first-path-transfer">
            <button className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-transfer">
            <h2>Thủ tục thuyên chuyển</h2>
          </div>
          <div className="third-path-transfer">
            <Link to={`/transfer/${id}`}>
              <Button variant="light" className="btn-fix-transfer">
                Sửa
              </Button>
            </Link>
            {dataDetailDC.bangChung !== null && (
              <Button
                variant="light"
                className="btn-fix-transfer"
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
            <h3>Tất cả lần thuyên chuyển</h3>
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
