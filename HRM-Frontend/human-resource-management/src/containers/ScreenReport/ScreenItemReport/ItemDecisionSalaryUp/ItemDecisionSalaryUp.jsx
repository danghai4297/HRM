import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { DatePicker } from "antd";
import { format } from "date-fns";
import { da } from "date-fns/locale";
import React, { useEffect, useRef, useState } from "react";
import { useReactToPrint } from "react-to-print";
import { useToast } from "../../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../../components/ToPrint/ComponentToPrint";
import "./ItemDecisionSalaryUp.scss";

function ItemDecisionSalaryUp() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const [title, settitle] = useState("Quyết định");
  const [name, setName] = useState("...");
  const [workplace, setWorkplace] = useState("...");
  const [salary, setSalary] = useState(0);
  const [newSalary, setNewSalary] = useState(0);
  const [dateX, setDateX] = useState(today);

  let dayX = format(new Date(dateX), "dd");
  let monthX = format(new Date(dateX), "MM");
  let yearX = format(new Date(dateX), "yyyy");

  // useEffect(() => {
  //   const fetchNvList = async () => {
  //     try {
  //       const response = await ProductApi.getAllDMPB();
  //       setDataDmpb(response);
  //     } catch (error) {
  //       console.log("false to fetch nv list: ", error);
  //     }
  //   };
  //   fetchNvList();
  // }, []);

  return (
    <div className="reportEx">
      <div className="select-info">
        <div className="roww">
          <input
            type="text"
            placeholder="Nhập tiêu đề cho báo cáo"
            class="form-control"
            id="title"
            onChange={(e) => settitle(e.target.value)}
          />
        </div>
        <div className="roww">
          <div className="select-row3">
            <label>Tên nhân viên</label>
            <div>
              <input
                type="text"
                placeholder="Nhập tên nhân viên"
                class="form-control i-put"
                id="title"
                onChange={(e) => setName(e.target.value)}
              />
            </div>
          </div>

          <div className="select-row3">
            <label>Vị trí công tác</label>
            <div>
              <input
                type="text"
                placeholder="Nhập vị trí công tác"
                class="form-control i-put"
                id="title"
                onChange={(e) => setWorkplace(e.target.value)}
              />
            </div>
          </div>
        </div>
        <div className="roww">
          <div className="select-row2">
            <label>Mức lương cũ</label>
            <div>
              <input
                type="number"
                min="0"
                defaultValue={0}
                class="form-control"
                id="title"
                onChange={(e) => setSalary(e.target.value)}
              />
            </div>
          </div>

          <div className="select-row2">
            <label>Mức lương mới</label>
            <div>
              <input
                type="number"
                min="0"
                class="form-control"
                defaultValue={0}
                id="title"
                onChange={(e) => setNewSalary(e.target.value)}
              />
            </div>
          </div>
          <div className="select-row2">
            <label>Đến ngày</label>
            <div>
              <DatePicker
                placeholder="DD/MM/YYYY"
                selected={dateX}
                onChange={(date) => setDateX(date)}
              />
            </div>
          </div>
        </div>

        <div className="roww row-btn">
          <button className="button-pdf" onClick={handlePrint}>
            <FontAwesomeIcon icon={["fas", "file-pdf"]} />
          </button>
        </div>
      </div>
      <div className="report-emp">
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
              <p>
                {" "}
                Hà Nội Ngày: {today.getDate()} Tháng: {today.getMonth() + 1}{" "}
                Năm: {today.getFullYear()}
              </p>
            </div>
            <div className="title-decision">
              <h4>{title}</h4>
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
                    Căn cứ vào năng lực và kết quả làm việc của Anh/Chị:{" "}
                    <b> {name}</b>
                  </p>
                </li>
              </ul>
            </div>
            <div className="medium-text">
              <p>
                <b>Điều 1</b>: Năng lương của Anh/Chị:<b> {name}</b>
              </p>
              <p>
                <span className="color">Vị trí công tác:</span> {workplace}
              </p>
              <p>
                <span className="color">Mức lương có:</span> {salary} đ/tháng
              </p>
              <p>
                <span className="color">Mức lương mới:</span> {newSalary}{" "}
                d/tháng
              </p>
              <p>
                <span className="color">Thời điểm áp dụng mức lương mới:</span>{" "}
                Ngày: {dayX} Tháng: {monthX} Năm: {yearX}
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
              </div>
            </div>
          </div>
        </ComponentToPrint>
      </div>
    </div>
  );
}

export default ItemDecisionSalaryUp;
