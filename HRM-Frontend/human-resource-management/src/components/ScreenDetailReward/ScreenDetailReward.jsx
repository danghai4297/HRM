import React from "react";
import SubDetail from "../Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailReward.scss"
function ScreenDetailReward() {
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Thủ tục khen thưởng</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin khen thưởng</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft="-"
              titleRight="Mã nhân viên"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Thời gian"
              itemLeft="-"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Nội dung"
              itemLeft="-"
              titleRight="Lý do"
              itemRight="-"
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailReward;
