import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import "./ScreenDetailSalary.scss";
import ProductApi from "../../api/productApi";
import dateFormat from "dateformat";
import { ttc } from "./DataSalary";

function ScreenDetailSalary(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataLDetail, setDataLDetail] = useState([]);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getLDetail(id);
        setDataLDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataLDetail);
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
            <h2>Chi tiết hồ sơ lương</h2>
          </div>
          <div className="third-path">
            <Link to={`/salary/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
            <a
              class="btn btn-fix btn-light"
              href={`https://localhost:5001${dataLDetail.bangChung}`}
              role="button"
            >
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "file-word"]}
              />
            </a>
          </div>
        </div>
        <div className="second-mains">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataLDetail[detail.data1[0]] !== null
                      ? dateFormat(dataLDetail[detail.data1[0]], "dd/mm/yyyy")
                      : dataLDetail[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataLDetail[detail.data2[0]] !== null
                      ? dateFormat(dataLDetail[detail.data2[0]], "dd/mm/yyyy")
                      : dataLDetail[detail.data2[0]]
                  }
                />
              );
            })}
          </div>
        </div>
        <div className="all-salary">
          <div className="name-move-salary">
            <h3>Tất cả lương</h3>
          </div>
          <Link
            to={`/profile/detail/${dataLDetail.maNhanVien}?move=moveToSalary`}
            className="btn-move-salary"
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

export default ScreenDetailSalary;
