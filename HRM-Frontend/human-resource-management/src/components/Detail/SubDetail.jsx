import React from "react";
import { Container, Row, Col } from "react-bootstrap";
import "./SubDetail.scss";

function SubDetail(props) {
  const { titleLeft, itemLeft, titleRight, itemRight } = props;
  return (
    <Container>
      <Row className="item">
        <Col>
          <Row>
            <Col xs lg="4">
              <p>{titleLeft}</p>
            </Col>
            <Col className="border-bottom rows">
              <p>{itemLeft}</p>
            </Col>
          </Row>
        </Col>
        <Col>
          <Row>
            <Col xs lg="5">
              <p>{titleRight}</p>
            </Col>
            <Col className={itemRight === null ? "" : "border-bottom rows"}>
              <p>{itemRight}</p>
            </Col>
          </Row>
        </Col>
      </Row>
    </Container>
  );
}

export default SubDetail;
