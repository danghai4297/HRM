import React from "react";
import { Col, Container, Row } from "react-bootstrap";
import "./ItemSalaryProfile.scss";
function ItemSalaryProfile() {
  return (
    <div>
      <div>
        <h1>Form</h1>
      </div>
      <div className="main-report">
        <div className="title-salary-report">
          <h5>HRM</h5>
          <h5>Địa chỉ: Hà Nội</h5>
        </div>
        <div className="main-title-salary">
          <h3>PHIẾU LƯƠNG</h3>
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
        <table class="table table-bordered tbl-width">
          <thead>
            <tr>
              <th scope="col" className="tax">
                Các khoản thu nhập từ tiền lương, tiền công
              </th>
              <th scope="col" className="title-tax">
                ...
              </th>
            </tr>
          </thead>
          <tbody>
            <tr>
              <td>Lương cơ bản</td>
              <td className="title-tax">...</td>
            </tr>
            <tr>
              <td>Phụ cấp chức vụ</td>
              <td className="title-tax">...</td>
            </tr>
          </tbody>
          <thead>
            <tr>
              <th scope="col" className="tax">
                Thực lĩnh
              </th>
              <th scope="col" className="title-tax">
                ...
              </th>
            </tr>
          </thead>
        </table>
      </div>
    </div>
  );
}

export default ItemSalaryProfile;
