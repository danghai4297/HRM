import React from 'react'
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailForeignLanguage.scss"
function ScreenDetailForeignLanguage() {
    return (
        <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Ngoại ngữ</h2>
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
              titleLeft="Ngoại ngữ"
              itemLeft={null}
              titleRight="Ngày cấp"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Nơi cấp"
              itemLeft={null}
              titleRight="Trình độ"
              itemRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
    )
}

export default ScreenDetailForeignLanguage
