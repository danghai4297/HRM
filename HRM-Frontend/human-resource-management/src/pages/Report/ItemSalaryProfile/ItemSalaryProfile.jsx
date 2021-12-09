import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useEffect, useRef, useState } from "react";
import { Col, Container, Row } from "react-bootstrap";
import NumberFormat from "react-number-format";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../api/productApi";
import { useToast } from "../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../components/ToPrint/ComponentToPrint";
import "./ItemSalaryProfile.scss";

function ItemSalaryProfile() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const { error, warn, info, success } = useToast();

  const [title, settitle] = useState("");
  const [dataNv, setDataNv] = useState([]);
  const [idNv, setIdNv] = useState("Tất cả");
  const [dataRp, setDataRp] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getAllNvMT();
        setDataNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };

    fetchNvList();
  }, []);

  const handelReport = async () => {
    try {
      const resp = await ProductApi.getRpHSL(idNv);
      setDataRp(resp);
    } catch (e) {
      error("Thực hiện không thành công");
    }
  };

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
          <div className="select-row2">
            <label>Tên nhân viên</label>
            <div>
              <select
                className="form-control selectpicker"
                onChange={(e) => setIdNv(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                {dataNv.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.hoTen}{" "}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Mã nhân viên</label>
            <div>
              <input type="text" class="form-control" value={idNv} />
            </div>
          </div>
        </div>
        <div className="roww row-btn">
          <input
            className="btn btn-primary"
            type="button"
            value="Hiển thị báo cáo"
            onClick={handelReport}
          />
          <button className="pdfx" onClick={handlePrint}>
            <FontAwesomeIcon icon={["fas", "file-pdf"]} />
          </button>
        </div>
      </div>
      <div className="report-emp">
        <ComponentToPrint ref={componentRef}>
          <div className="main-report">
            <div className="title-salary-report">
              <h5>HRM</h5>
              <h5>Địa chỉ: Hà Nội</h5>
            </div>
            <div className="main-title-salary">
              <h3>{title}</h3>
              <h5>
                Hà Nội Ngày: {today.getDate()} Tháng: {today.getMonth() + 1}{" "}
                Năm: {today.getFullYear()}
              </h5>
            </div>
            <div className="second-title-salary">
              <Row>
                <Col>
                  <h5>Mã nhân viên: {dataRp.maNhanVien}</h5>
                  <h5>Họ và tên: {dataRp.tenNhanVien}</h5>
                  <h5>Đơn vị công tác: {dataRp.tenPhongBan}</h5>
                </Col>
                <Col>
                  <h5>TK ngân hàng: {dataRp.atm}</h5>
                  <h5>Ngân hàng: {dataRp.nganHang}</h5>
                </Col>
              </Row>
            </div>
            <div className="second-after">
              <h5>CHI TIẾT SỐ TIỀN LƯƠNG THỰC NHẬN</h5>
            </div>
            <table class="table-bordered tbl-width">
              <thead>
                <tr>
                  <th scope="col" className="title-tax">
                    Các khoản thu nhập từ tiền lương, tiền công
                  </th>
                  <th scope="col" className="title-tax"></th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td className="title-tax">Lương cơ bản</td>
                  <td className="title-tax">
                    <NumberFormat
                      value={dataRp.luongCoBan}
                      displayType="text"
                      type="text"
                      thousandSeparator={true}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="title-tax">Phụ cấp chức vụ</td>
                  <td className="title-tax">
                    <NumberFormat
                      value={dataRp.phuCapChucVu}
                      displayType="text"
                      type="text"
                      thousandSeparator={true}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="title-tax">Phụ cấp chức danh</td>
                  <td className="title-tax">
                    <NumberFormat
                      value={dataRp.phuCapChucDanh}
                      displayType="text"
                      type="text"
                      thousandSeparator={true}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="title-tax">Phụ cấp trách nhiệm</td>
                  <td className="title-tax">
                    <NumberFormat
                      value={dataRp.phuCapTrachNhiem}
                      displayType="text"
                      type="text"
                      thousandSeparator={true}
                    />
                  </td>
                </tr>
                <tr>
                  <td className="title-tax">Phụ cấp khác</td>
                  <td className="title-tax">
                    <NumberFormat
                      value={dataRp.phuCapKhac}
                      displayType="text"
                      type="text"
                      thousandSeparator={true}
                    />
                  </td>
                </tr>
              </tbody>
              <thead>
                <tr>
                  <th scope="col" className="title-tax">
                    Thực lĩnh
                  </th>
                  <th scope="col" className="title-tax">
                    <NumberFormat
                      value={dataRp.tongLuong}
                      displayType="text"
                      type="text"
                      thousandSeparator={true}
                    />
                  </th>
                </tr>
              </thead>
            </table>
          </div>
        </ComponentToPrint>
      </div>
    </div>
  );
}

export default ItemSalaryProfile;
