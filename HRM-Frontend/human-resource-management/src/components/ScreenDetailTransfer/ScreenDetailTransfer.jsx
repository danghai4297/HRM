import React from "react";
import SubDetail from "../Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailTransfer.scss";
function ScreenDetailTransfer() {
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Thủ tục thuyên chuyển</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Vị trí công tác hiện tại</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft="-"
              titleRight="Ngày hiệu lực"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Phòng ban"
              itemLeft="-"
              titleRight="Chi tiết"
              itemRight="-"
            ></SubDetail>
            <SubDetail titleLeft="Tổ" itemLeft="-" itemRight={null}></SubDetail>
            <SubDetail
              titleLeft="Chức vụ công tác"
              itemLeft="-"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailTransfer;
