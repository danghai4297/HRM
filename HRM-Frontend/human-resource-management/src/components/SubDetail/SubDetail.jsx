import React from "react";
import { Row, Col } from "react-bootstrap";
import "./SubDetail.scss";

function SubDetail(props) {
  const { titleLeft, itemLeft, titleRight, itemRight } = props;

  return (
    <div className="containss">
      <Row className="item">
        <Col xl>
          <Row className="row-replace">
            <Col>
              <p>{titleLeft}</p>
            </Col>
            <Col className="border-bottom rows" xs={6}>
              <p>{itemLeft === null ? "-" : itemLeft} </p>
            </Col>
          </Row>
        </Col>
        <Col>
          <Row className="row-replace">
            <Col>
              <p>{titleRight}</p>
            </Col>
            <Col
              className={titleRight === null ? "" : "border-bottom rows"}
              xs={6}
            >
              <p>{itemRight === null ? "-" : itemRight} </p>
            </Col>
          </Row>
        </Col>
      </Row>
    </div>
  );
}

export default SubDetail;
