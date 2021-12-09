import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useEffect, useRef, useState } from "react";
import { Col, Container, Row } from "react-bootstrap";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../../api/productApi";
import { ExportCSV } from "../../../../components/ExportFile/ExportFile";
import { useToast } from "../../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../../components/ToPrint/ComponentToPrint";
import useDidMountEffect from "../../useDidMountEffect/useDidMountEffect";
import "./ItemSalaryProfile.scss";

function ItemSalaryProfile() {
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

  const handelReport = async () => {};

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
          <ExportCSV csvData={dataRp} fileName="Báo cáo danh sách nhân viên" />
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
              <h5>Tháng ... Năm ...</h5>
            </div>
            <Container className="second-title-salary">
              <Row>
                <Col>
                  <h5>Mã nhân viên: ...</h5>
                  <h5>Họ và tên: ...</h5>
                  <h5>Đơn vị công tác: ...</h5>
                </Col>
                <Col>
                  <h5>TK ngân hàng: ...</h5>
                </Col>
              </Row>
            </Container>
            <div className="second-after">
              <h5>CHI TIẾT SỐ TIỀN LƯƠNG THỰC NHẬN</h5>
            </div>
            <table class="table-bordered tbl-width">
              <thead>
                <tr>
                  <th scope="col" className="title-tax">
                    Các khoản thu nhập từ tiền lương, tiền công
                  </th>
                  <th scope="col" className="title-tax">
                    ...
                  </th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td className="title-tax">Lương cơ bản</td>
                  <td className="title-tax">ABccc jifJd ksdske</td>
                </tr>
                <tr>
                  <td className="title-tax">Phụ cấp chức vụ</td>
                  <td className="title-tax">...</td>
                </tr>
              </tbody>
              <thead>
                <tr>
                  <th scope="col" className="title-tax">
                    Thực lĩnh
                  </th>
                  <th scope="col" className="title-tax">
                    ...
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
