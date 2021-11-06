import React, { useRef } from "react";
import { Button } from "react-bootstrap";
import { useReactToPrint } from "react-to-print";
import { ComponentToPrint } from "../../../../components/ToPrint/ComponentToPrint";
import "./ItemDecisionSalaryUp.scss";
function ItemDecisionSalaryUp() {
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });
  return (
    <>
      <div>
        <Button variant="light" onClick={handlePrint}>
          Print
        </Button>
      </div>
      <div className="contain-decision">
        <ComponentToPrint ref={componentRef}>
          <div>
            <div className="header-decision">
              <div className="left-header">
                <h5>Công ty 3HMD</h5>
                <h5>Số: ... / ...</h5>
              </div>
              <div className="right-header">
                <h5>CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM</h5>
                <h5>Độc lập - Tự do - Hạnh phúc</h5>
                <h5>.....................</h5>
              </div>
            </div>
            <div className="date-decision">
              <p>..., ngày ... tháng ... năm ...</p>
            </div>
            <div className="title-decision">
              <h4>QUYẾT ĐỊNH</h4>
            </div>
            <div className="title-decision-ps">
              <p>(V/v: Nâng lương)</p>
            </div>
            <div className="after-title">
              <p>
                <b>GIÁM ĐỐC CÔNG TY 3HMD</b>
              </p>
            </div>
            <div className="first-text">
              <ul>
                <li>
                  <p>Căn cứ điều lệ của công ty 3HMD</p>
                </li>
                <li>
                  <p>Căn cứ đề nghị của phòng nhân sự ban đào tạo nhân sự</p>
                </li>
                <li>
                  <p>
                    Căn cứ vào năng lực và kết quả làm việc của{" "}
                    <b>Ông/Bà ...</b>
                  </p>
                </li>
              </ul>
            </div>
            <div className="medium-text">
              <p>
                <b>Điều 1</b>: Năng lương của <b>Ông/Bà ...</b>
              </p>
              <p>
                <span className="color">Vị trí công tác:</span> ...
              </p>
              <p>
                <span className="color">Mức lương có:</span> ... /tháng
              </p>
              <p>
                <span className="color">Mức lương mới:</span> ... /tháng
              </p>
              <p>
                <span className="color">Thời điểm áp dụng mức lương mới:</span>{" "}
                tháng ... năm ...
              </p>
            </div>
            <div className="medium-text">
              <p>
                <b>Điều 2</b>: Giám đốc công ty 3HMD, phòng Hành chính - nhân
                sự, các bộ phận liên quan và Ông/Bà ... chịu trách nhiệm thi
                hành quyết định này.
              </p>
              <p>Quyết định có hiệu lực từ ngày ký</p>
            </div>
            <div className="footer-decision">
              <div className="left-decision">
                <p>
                  <b>Nơi nhận:</b>
                </p>
                <ul>
                  <li>Điều 2</li>
                  <li>Lưu VP</li>
                </ul>
              </div>
              <div className="right-decition">
                <p>
                  <b>Giám đốc</b>
                </p>
                <p>(Ký tên)</p>
                <p>Minh</p>
              </div>
            </div>
          </div>
        </ComponentToPrint>
      </div>
    </>
  );
}

export default ItemDecisionSalaryUp;
