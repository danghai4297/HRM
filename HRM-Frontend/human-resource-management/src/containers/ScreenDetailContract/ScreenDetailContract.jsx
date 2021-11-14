import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailContract.scss";
import SubDetail from "../../components/Detail/SubDetail";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataContract";
function ScreenDetailContract(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailHd, setdataDetailHd] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseHD = await ProductApi.getHdDetail(id);
        setdataDetailHd(responseHD);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataDetailHd);
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
            <h2>Chi tiết hợp đồng</h2>
          </div>
          <div className="third-path">
            <Link to={`/contract/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
            <a
              class="btn btn-fix btn-light"
              href={`https://localhost:5001${dataDetailHd.bangChung}`}
              role="button"
            >
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "file-word"]}
              />
            </a>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
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
          </div>
        </div>
        <div className="all-contract">
          <div className="name-move">
            <h3>Tất cả hợp đồng</h3>
          </div>
          <Link
            to={`/profile/detail/${dataDetailHd.maNhanVien}?move=moveToContract`}
            className="btn-move"
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

export default ScreenDetailContract;
