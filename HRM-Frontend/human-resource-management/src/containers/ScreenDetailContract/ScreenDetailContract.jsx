import React from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailContract.scss";
import SubDetail from "../../components/Detail/SubDetail";
function ScreenDetailContract() {
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Chi tiết hợp đồng</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">Sửa</Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft="-"
              titleRight="Mã nhân viên"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Mã hợp đồng"
              itemLeft="-"
              titleRight="Loại hợp đồng"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Lương cơ bản"
              itemLeft="-"
              titleRight="Chức danh công việc"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày có hiệu lực"
              itemLeft="-"
              titleRight="Ngày hết hạn"
              itemRight="-"
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailContract;
