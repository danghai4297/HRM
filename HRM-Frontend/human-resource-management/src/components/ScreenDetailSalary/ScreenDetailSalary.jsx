import React from "react";
import SubDetail from "../Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailSalary.scss";
function ScreenDetailSalary() {
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Chi tiết hồ sơ lương</h2>
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
              titleLeft="Họ và tên"
              itemLeft="-"
              titleRight="Mã nhân viên"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Mã hợp đồng"
              itemLeft="-"
              titleRight="Nhóm lương"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Hệ số lương"
              itemLeft="-"
              titleRight="Bậc lương"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Phụ cấp chức vụ"
              itemLeft="-"
              titleRight="Phụ cấp khác"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Thời hạn lên lương"
              itemLeft="-"
              titleRight="Ngày hết hạn"
              itemRight="-"
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày có hiệu lực"
              itemLeft="-"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailSalary;
