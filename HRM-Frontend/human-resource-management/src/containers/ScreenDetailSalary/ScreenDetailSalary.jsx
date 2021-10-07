import React from "react";
import SubDetail from "../../components/Detail/SubDetail";
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
              itemLeft={null}
              titleRight="Mã nhân viên"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Mã hợp đồng"
              itemLeft={null}
              titleRight="Nhóm lương"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Hệ số lương"
              itemLeft={null}
              titleRight="Bậc lương"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Phụ cấp chức vụ"
              itemLeft={null}
              titleRight="Phụ cấp khác"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Thời hạn lên lương"
              itemLeft={null}
              titleRight="Ngày hết hạn"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày có hiệu lực"
              itemLeft={null}
              titleRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailSalary;
