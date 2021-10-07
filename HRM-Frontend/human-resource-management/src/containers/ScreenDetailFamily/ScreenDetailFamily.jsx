import React from 'react'
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailFamily.scss"
function ScreenDetailFamily() {
    return (
        <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Thông tin gia đình</h2>
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
              titleRight="Quan hệ"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Giới tính"
              itemLeft={null}
              titleRight="Ngày sinh"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Địa chỉ"
              itemLeft={null}
              titleRight="Điện thoại"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Nghề nghiệp"
              itemLeft={null}
              titleRight="Thông tin khác"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
    )
}

export default ScreenDetailFamily
