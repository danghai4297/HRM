import React, { useContext, useState } from "react";
import "./Detail.scss";
import SubDetail from "./SubDetail";
import { links } from "./ScrollData";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Container, Row, Col, Button } from "react-bootstrap";
import { dum } from "./Data";
import { ListContext } from "../../Contexts/ListContext";
function Detail(props) {
  const { list } = useContext(ListContext);

  let { match, history } = props;

  // console.log(match);
  // console.log(history);
  let { id } = match.params;

  const dataDetail = list.find((item) => item.id == id);

  const [dropBase, setDropBase] = useState(true);
  const [dropContact, setDropContact] = useState(true);
  const [dropJob, setDropJob] = useState(true);
  const [dropInsurance, setDropInsurance] = useState(true);
  const [dropCultural, setDropCultural] = useState(true);
  const [dropFamily, setDropFamily] = useState(true);
  const [dropPolitics, setDropPolitics] = useState(true);
  const [dropContract, setDropContract] = useState(true);
  const [dropTransfer, setDropTransfer] = useState(true);
  const [dropReward, setDropReward] = useState(true);
  const [dropDiscipline, setDropDiscipline] = useState(true);
  const clickHandle = (e) => {
    e.preventDefault();
    const target = e.target.getAttribute("href");
    const location = document.querySelector(target).offsetTop;

    window.scrollTo({
      top: location - 70,
    });
  };
  const arrowBaseClickHandle = () => {
    setDropBase(!dropBase);
  };
  const arrowContactClickHandle = () => {
    setDropContact(!dropContact);
  };
  const arrowJobClickHandle = () => {
    setDropJob(!dropJob);
  };
  const arrowInsuranceClickHandle = () => {
    setDropInsurance(!dropInsurance);
  };
  const arrowCulturalClickHandle = () => {
    setDropCultural(!dropCultural);
  };
  const arrowFamilyClickHandle = () => {
    setDropFamily(!dropFamily);
  };
  const arrowPoliticsClickHandle = () => {
    setDropPolitics(!dropPolitics);
  };
  const arrowContractClickHandle = () => {
    setDropContract(!dropContract);
  };
  const arrowTransferClickHandle = () => {
    setDropTransfer(!dropTransfer);
  };
  const arrowRewardClickHandle = () => {
    setDropReward(!dropReward);
  };
  const arrowDisciplineClickHandle = () => {
    setDropDiscipline(!dropDiscipline);
  };
  return (
    <>
      <div className="contents">
        <div className="first-information">
          <div className="left-path">
            <div className="icons">
              <button className="btn-back" onClick={() => history.goBack()}>
                <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
              </button>
            </div>
            <div className="icon-second">
              <FontAwesomeIcon icon={["far", "user-circle"]} />
            </div>
            <div className="names">
              <h5>{dataDetail.firstName + " " + dataDetail.lastName}</h5>
            </div>
            <div className="codes">
              <p>{dataDetail.id}</p>
            </div>
          </div>
          <div className="middle-path">
            <Container>
              <Row className="row-detail">
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p>Đơn vị công tác</p>
                    </Col>
                    <Col>
                      <p></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p>Ngày thử việc</p>
                    </Col>
                    <Col>
                      <p></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p>Ngày chính thức</p>
                    </Col>
                    <Col>
                      <p></p>
                    </Col>
                  </Row>
                </Col>
              </Row>
              <Row className="row-detail">
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p>Ngày sinh</p>
                    </Col>
                    <Col>
                      <p></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p>ĐT di động</p>
                    </Col>
                    <Col>
                      <p></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p>Email</p>
                    </Col>
                    <Col>
                      <p></p>
                    </Col>
                  </Row>
                </Col>
              </Row>
            </Container>
          </div>
          <div className="right-path"></div>
        </div>
        <div className="main-information">
          <div className="left-header-information">
            <div className="sticky-top">
              <ul className="list-left">
                {links.map((link) => {
                  return (
                    <li className="row-left">
                      <b>
                        <p>
                          <a
                            href={link.url}
                            key={link.id}
                            onClick={clickHandle}
                          >
                            {link.text}
                          </a>
                        </p>
                      </b>
                    </li>
                  );
                })}
              </ul>
            </div>
          </div>
          <div className="right-information">
            <div className="form" id="base">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin cơ bản</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowBaseClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropBase ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropBase && (
                <>
                  <div className="title">
                    <h5>Thông tin chung</h5>
                  </div>
                  <SubDetail
                    titleLeft="Mã nhân viên"
                    itemLeft={dataDetail.id}
                    titleRight="TK Ngân hàng"
                    itemRight={dum.numberBank}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Họ và tên"
                    itemLeft={dataDetail.firstName + " " + dataDetail.lastName}
                    titleRight="Ngân hàng"
                    itemRight={dum.bank}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Giới tính"
                    itemLeft={dataDetail.gender}
                    titleRight="Tình trạng hôn nhân"
                    itemRight={dum.marriage}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày sinh"
                    itemLeft={dataDetail.birthday}
                    titleRight="MST cá nhân"
                    itemRight={dum.taxCode}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nơi sinh"
                    itemLeft={dum.birthplace}
                    titleRight="Dân tộc"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nguyên quán"
                    itemLeft="-"
                    titleRight="Tôn giáo"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nơi sinh"
                    itemLeft="-"
                    titleRight="Quốc tịch"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nguyên quán"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                  <div className="title">
                    <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
                  </div>
                  <SubDetail
                    titleLeft="Loại giấy tờ"
                    itemLeft="-"
                    titleRight="Số hộ chiếu"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Số CMND/CCCD"
                    itemLeft="-"
                    titleRight="Ngày cấp hộ chiếu"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày cấp(CMNN/CCCD)"
                    itemLeft="-"
                    titleRight="Nơi cấp hộ chiếu"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nơi cấp(CMND/CCCD)"
                    itemLeft="-"
                    titleRight="Ngày hết hạn hộ chiếu"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày hết hạn"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                </>
              )}
            </div>

            <div className="form" id="contact">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin liên hệ</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowContactClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContact ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropContact && (
                <>
                  <div className="title">
                    <h5>Số điện thoại/Email/Khác</h5>
                  </div>
                  <SubDetail
                    titleLeft="ĐT di động"
                    itemLeft="-"
                    titleRight="Email cá nhân"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="ĐT khác"
                    itemLeft="-"
                    titleRight="Facebook"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="ĐT nhà riêng"
                    itemLeft="-"
                    titleRight="Skype"
                    itemRight="-"
                  ></SubDetail>
                  <div className="title">
                    <h5>Liên hệ khẩn cấp</h5>
                  </div>
                  <SubDetail
                    titleLeft="Họ và tên"
                    itemLeft="-"
                    titleRight="ĐT nhà riêng"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Quan hệ"
                    itemLeft="-"
                    titleRight="Email"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="ĐT di động"
                    itemLeft="-"
                    titleRight="Địa chỉ"
                    itemRight="-"
                  ></SubDetail>
                </>
              )}
            </div>
            <div className="form" id="job">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin công việc</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowJobClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropJob ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropJob && (
                <>
                  <div className="title">
                    <h5>Thông tin nhân viên</h5>
                  </div>
                  <SubDetail
                    titleLeft="Nghề nghiệp"
                    itemLeft="-"
                    titleRight="Ngày thử việc"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Cơ quan tuyển dụng"
                    itemLeft="-"
                    titleRight="Ngày tuyển dụng"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Chức vụ hiện tại"
                    itemLeft="-"
                    titleRight="Ngày vào ban"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Trạng thái lao động"
                    itemLeft="-"
                    titleRight="Công việc chính"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Tính chất lao động"
                    itemLeft="-"
                    titleRight="Số sổ QL lao động"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Lý do nghỉ"
                    itemLeft="-"
                    titleRight="Loại hợp đồng"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày nghỉ việc"
                    itemLeft="-"
                    titleRight="Ngày công tác"
                    itemRight="-"
                  ></SubDetail>
                  <div className="title">
                    <h5>Thông tin lương</h5>
                  </div>
                  <SubDetail
                    titleLeft="Nhóm lương"
                    itemLeft="-"
                    titleRight="Tiền lương"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Hệ số lương"
                    itemLeft="-"
                    titleRight="Thời hạn lên lương"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Bậc lương"
                    itemLeft="-"
                    titleRight="Ngày hiệu lực"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Phụ cấp chức vụ"
                    itemLeft="-"
                    titleRight="Ngày hết hạn"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Phụ cấp khác"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                </>
              )}
            </div>
            <div className="form" id="insurance">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin bảo hiểm</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowInsuranceClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropInsurance ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropInsurance && (
                <>
                  <SubDetail
                    titleLeft="Số sổ BHXH"
                    itemLeft="-"
                    titleRight="Số thẻ BHYT"
                    itemRight="-"
                  ></SubDetail>
                </>
              )}
            </div>
            <div className="form" id="cultural">
              <div className="big-title">
                <div className="name-title">
                  <h3>Trình độ văn hóa</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowCulturalClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropCultural ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropCultural && (
                <>
                  <div className="title">
                    <h5>Trình độ</h5>
                  </div>
                  <div className="table"></div>
                  <div className="title">
                    <h5>Ngoại ngữ</h5>
                  </div>
                  <div className="table"></div>
                </>
              )}
            </div>
            <div className="form" id="family">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin gia đình</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowFamilyClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropFamily ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropFamily && (
                <>
                  <div className="table"></div>
                </>
              )}
            </div>
            <div className="form" id="politics">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin chính trị, quân sự, y tế</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowPoliticsClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropPolitics ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropPolitics && (
                <>
                  <div className="title">
                    <h5>Thông tin chính trị</h5>
                  </div>
                  <SubDetail
                    titleLeft="Ngạch công chức"
                    itemLeft="-"
                    titleRight="Ngày vào đoàn"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày vào Đảng"
                    itemLeft="-"
                    titleRight="Nơi tham gia"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày chính thức"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                  <div className="title">
                    <h5>Thông tin quân sự</h5>
                  </div>
                  <SubDetail
                    titleLeft="Là quân nhân"
                    itemLeft="-"
                    titleRight="Là thương binh"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày nhập ngũ"
                    itemLeft="-"
                    titleRight="Là con gia đình chính sách"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày xuất ngũ"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Quân hàm cao nhất"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="DH được phong tặng cao nhất"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                  <div className="title">
                    <h5>Thông tin y tế</h5>
                  </div>
                  <SubDetail
                    titleLeft="Nhóm máu"
                    itemLeft="-"
                    titleRight="Bệnh tật"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Chiều cao(m)"
                    itemLeft="-"
                    titleRight="Lưu ý"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Cân nặng(kg)"
                    itemLeft="-"
                    titleRight="Là người khuất tật"
                    itemRight="-"
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Tình trạng sức khỏe"
                    itemLeft="-"
                    itemRight={null}
                  ></SubDetail>
                </>
              )}
            </div>
            <div className="form" id="contract">
              <div className="big-title">
                <div className="name-title">
                  <h3>Hợp đồng lao động</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowContractClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContract ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropContract && (
                <>
                  <div className="table"></div>
                </>
              )}
            </div>
            <div className="form" id="transfer">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thuyên chuyển</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowTransferClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropTransfer ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropTransfer && (
                <>
                  <div className="table"></div>
                </>
              )}
            </div>
            <div className="form" id="reward">
              <div className="big-title">
                <div className="name-title">
                  <h3>Khen thưởng</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowRewardClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropReward ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropReward && (
                <>
                  <div className="table"></div>
                </>
              )}
            </div>
            <div className="form" id="discipline">
              <div className="big-title">
                <div className="name-title">
                  <h3 className="h3s">Kỷ luật</h3>
                </div>
                <div className="arrow-button">
                  <Button onClick={arrowDisciplineClickHandle}>
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropReward ? "iconss" : ""}
                    />
                  </Button>
                </div>
              </div>
              {dropDiscipline && (
                <>
                  <div className="table"></div>
                </>
              )}
            </div>
          </div>
        </div>
      </div>
    </>
  );
}

export default Detail;
