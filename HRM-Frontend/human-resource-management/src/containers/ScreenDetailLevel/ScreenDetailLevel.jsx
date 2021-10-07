import React from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailLevel.scss"
function ScreenDetailLevel() {
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Trình độ</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Tên trường"
              itemLeft={null}
              titleRight="Chuyên ngành"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Trình độ"
              itemLeft={null}
              titleRight="Hình thức đào tạo"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Từ ngày"
              itemLeft={null}
              titleRight="Đến ngày"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailLevel;
