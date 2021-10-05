import React from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailResign.scss";
function ScreenDetailResign() {
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Thủ tục nghỉ việc</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thủ tục nghỉ việc</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft="-"
              titleRight="Mã nhân viên"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Đơn vị công tác"
              itemLeft="-"
              titleRight="Vị trí công tác"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Lý do nghỉ việc"
              itemLeft="-"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày nghỉ việc"
              itemLeft="-"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailResign;
