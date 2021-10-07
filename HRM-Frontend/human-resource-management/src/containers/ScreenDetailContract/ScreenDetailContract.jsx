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
              itemLeft={null}
              titleRight="Mã nhân viên"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Mã hợp đồng"
              itemLeft={null}
              titleRight="Loại hợp đồng"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Lương cơ bản"
              itemLeft={null}
              titleRight="Chức danh công việc"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày có hiệu lực"
              itemLeft={null}
              titleRight="Ngày hết hạn"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailContract;
