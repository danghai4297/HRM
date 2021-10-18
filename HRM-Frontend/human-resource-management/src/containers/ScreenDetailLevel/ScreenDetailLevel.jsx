import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailLevel.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
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
            <h2>Trình độ</h2>
          </div>
          <div className="third-path">
            <Link to={`/profile/detail/level/update/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Mã nhân viên"
              itemLeft={dataDetailTD.maNhanVien}
              titleRight="Tên nhân viên"
              itemRight={dataDetailTD.tenNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Tên trường"
              itemLeft={dataDetailTD.tenTruong}
              titleRight="Chuyên ngành"
              itemRight={dataDetailTD.chuyenMon}
            ></SubDetail>
            <SubDetail
              titleLeft="Trình độ"
              itemLeft={dataDetailTD.trinhDo}
              titleRight="Hình thức đào tạo"
              itemRight={dataDetailTD.hinhThucDaoTao}
            ></SubDetail>
            <SubDetail
              titleLeft="Từ ngày"
              itemLeft={dataDetailTD.tuThoiGian}
              titleRight="Đến ngày"
              itemRight={dataDetailTD.denThoiGian}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailLevel;
