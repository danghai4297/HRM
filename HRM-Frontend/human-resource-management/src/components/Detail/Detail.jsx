import React, { useEffect, useState, useRef } from "react";
import { useReactToPrint } from "react-to-print";
import "./Detail.scss";
import SubDetail from "./SubDetail";
import { links } from "./ScrollData";
import dateFormat from "dateformat";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Container, Row, Col, Button } from "react-bootstrap";
import ProductApi from "../../api/productApi";
import TableBasic from "../TablePagination/TableBasic";
import { PDFDownloadLink, Document, Page, Text } from "@react-pdf/renderer";

import {
  NVCOLUMNSDC,
  NVCOLUMNSHD,
  NVCOLUMNSKTvKL,
  NVCOLUMNSL,
  NVCOLUMNSNN,
  NVCOLUMNSNT,
  NVCOLUMNSTDVH,
} from "./NvColumns";
import { Link, useLocation } from "react-router-dom";
import {
  cmndTccHC,
  lhkc,
  sdtEK,
  ttbh,
  ttc,
  ttct,
  ttnv,
  ttqs,
  ttyt,
} from "./Data";
import { ComponentToPrint } from "../ToPrint/ComponentToPrint";

function Detail(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailNv, setdataDetailNv] = useState([]);
  const [dataDetailTDVH, setdataDetailTDVH] = useState([]);
  const [dataDetailNgn, setdataDetailNgn] = useState([]);
  const [dataDetailGd, setdataDetailGd] = useState([]);
  const [dataDetailHd, setdataDetailHd] = useState([]);
  const [dataDetailTc, setdataDetailTc] = useState([]);
  const [dataDetailKt, setdataDetailKt] = useState([]);
  const [dataDetailKl, setdataDetailKl] = useState([]);
  const [dataLuong, setDataLuong] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getNvDetail(id);
        setdataDetailNv(responseNv);
        setdataDetailTDVH(responseNv.trinhDoVanHoas);
        setdataDetailNgn(responseNv.ngoaiNgus);
        setdataDetailGd(responseNv.nguoiThans);
        setdataDetailHd(responseNv.hopDongs);
        setdataDetailTc(responseNv.dieuChuyens);
        setdataDetailKt(responseNv.khenThuongs);
        setdataDetailKl(responseNv.kyLuats);
        setDataLuong(responseNv.luongs);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  const [dropBase, setDropBase] = useState(true);
  const [dropContact, setDropContact] = useState(true);
  const [dropJob, setDropJob] = useState(true);
  const [dropInsurance, setDropInsurance] = useState(true);
  const [dropCultural, setDropCultural] = useState(true);
  const [dropFamily, setDropFamily] = useState(true);
  const [dropPolitics, setDropPolitics] = useState(true);
  const [dropHistory, setDropHistory] = useState(true);
  const [dropContract, setDropContract] = useState(true);
  const [dropSalary, setDropSalary] = useState(true);
  const [dropTransfer, setDropTransfer] = useState(true);
  const [dropReward, setDropReward] = useState(true);
  const [dropDiscipline, setDropDiscipline] = useState(true);

  const clickHandle = (e) => {
    e.preventDefault();
    const target = e.target.getAttribute("href");
    const height = document.getElementById("right");
    const location = document.querySelector(target).offsetTop;
    height.scrollTo({
      top: location - 260,
      behavior: "smooth",
    });
  };

  let location = useLocation();
  let query = new URLSearchParams(location.search);

  switch (query.get("move")) {
    case "moveToContract":
      setTimeout(() => {
        const height = document.getElementById("right");
        const location = document.querySelector("#contract").offsetTop;
        height.scrollTo({
          top: location - 260,
          behavior: "smooth",
        });
      }, 50);
      break;
    case "moveToSalary":
      setTimeout(() => {
        const height = document.getElementById("right");
        const location = document.querySelector("#salary").offsetTop;
        height.scrollTo({
          top: location - 260,
          behavior: "smooth",
        });
      }, 50);
      break;
    case "moveToTransfer":
      setTimeout(() => {
        const height = document.getElementById("right");
        const location = document.querySelector("#transfer").offsetTop;
        height.scrollTo({
          top: location - 260,
          behavior: "smooth",
        });
      }, 50);
      break;
    case "moveToReward":
      setTimeout(() => {
        const height = document.getElementById("right");
        const location = document.querySelector("#reward").offsetTop;
        height.scrollTo({
          top: location - 260,
          behavior: "smooth",
        });
      }, 50);
      break;
    case "moveToDiscipline":
      setTimeout(() => {
        const height = document.getElementById("right");
        const location = document.querySelector("#discipline").offsetTop;
        height.scrollTo({
          top: location - 260,
          behavior: "smooth",
        });
      }, 50);
      break;
    default:
      break;
  }

  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });
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
  const arrowHistoryClickHandle = () => {
    setDropHistory(!dropHistory);
  };
  const arrowContractClickHandle = () => {
    setDropContract(!dropContract);
  };
  const arrowSalaryClickHandle = () => {
    setDropSalary(!dropSalary);
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

  const MyDoc = () => (
    <Document>
      <Page size="A4">
        <Text>Nguyễn Công Minh</Text>
      </Page>
    </Document>
  );
  return (
    <>
      <div className="contents">
        <div className="first-information">
          <div className="left-path">
            <div className="icons">
              <button className="btn-back" onClick={history.goBack}>
                <FontAwesomeIcon
                  className="icon-btn"
                  icon={["fas", "long-arrow-alt-left"]}
                />
              </button>
            </div>

            <div className="avatar">
              <div className="icon-second" style={{ width: "90px" }}>
                <img
                  src={`https://localhost:5001/${dataDetailNv.anh}`}
                  alt=""
                />
              </div>
              <div className="names">
                <h5>{dataDetailNv.hoTen}</h5>
              </div>
              <div className="codes">
                <p>{dataDetailNv.id}</p>
              </div>
            </div>
          </div>
          <div className="middle-path">
            <Container className="containn">
              <Row className="row-detail">
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">Đơn vị công tác</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.coQuanTuyenDung === null
                          ? "-"
                          : dataDetailNv.coQuanTuyenDung}
                      </p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">Ngày thử việc</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.ngayThuViec === null
                          ? "-"
                          : dateFormat(dataDetailNv.ngayThuViec, "dd/mm/yyyy")}
                      </p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5" id="dee">
                      <p className="fast-information">Ngày chính thức</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.ngayChinhThuc === null
                          ? "-"
                          : dateFormat(
                              dataDetailNv.ngayChinhThuc,
                              "dd/mm/yyyy"
                            )}
                      </p>
                    </Col>
                  </Row>
                </Col>
              </Row>
              <Row className="row-detail">
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information"> Ngày sinh</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.ngaySinh === null
                          ? "-"
                          : dateFormat(dataDetailNv.ngaySinh, "dd/mm/yyyy")}
                      </p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">ĐT di động</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.diDong === null
                          ? "-"
                          : dataDetailNv.diDong}
                      </p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">Email</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.email === null ? "-" : dataDetailNv.email}
                      </p>
                    </Col>
                  </Row>
                </Col>
              </Row>
            </Container>
          </div>
          <div className="right-path">
            <Button className="button-color" variant="dark">
              Sửa
            </Button>
            <Button className="button-color" variant="danger">
              Xóa
            </Button>
            <Button
              className="button-color"
              variant="light"
              onClick={() => (
                <PDFDownloadLink document={MyDoc} fileName="somename.pdf">
                  {({ blob, url, loading, error }) =>
                    loading ? "Loading document..." : "Download now!"
                  }
                </PDFDownloadLink>
              )}
            >
              <FontAwesomeIcon icon={["fas", "download"]} />
            </Button>
          </div>
        </div>
        <div className="main-information">
          <div className="left-header-information" id="abcccc">
            <div className="sticky-top">
              <ul className="list-left">
                {links.map((link) => {
                  return (
                    <li className="row-left">
                      <h5>
                        <a href={link.url} key={link.id} onClick={clickHandle}>
                          {link.text}
                        </a>
                      </h5>
                    </li>
                  );
                })}
              </ul>
            </div>
          </div>

          <div className="right-information" id="right">
            <ComponentToPrint ref={componentRef}>
              <div className="form" id="base">
                <div className="big-title">
                  <div className="name-title" onClick={arrowBaseClickHandle}>
                    <h3>Thông tin cơ bản</h3>
                  </div>
                  <div className="arrow-button">
                    {/* <button
                      className="main-arrow-button"
                      onClick={arrowBaseClickHandle}
                    >
                      <FontAwesomeIcon
                        icon={["fas", "chevron-down"]}
                        className={!dropBase ? "iconss" : "iconsss"}
                      />
                    </button> */}
                  </div>
                </div>
                {dropBase && (
                  <>
                    <div className="title">
                      <h5>Thông tin chung</h5>
                    </div>
                    {ttc.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={
                            detail.data1[1] === true &&
                            dataDetailNv[detail.data1[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data1[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data1[0]]
                          }
                          titleRight={detail.title2}
                          itemRight={
                            detail.data2[1] === true &&
                            dataDetailNv[detail.data2[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data2[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data2[0]]
                          }
                        />
                      );
                    })}
                    <div className="title">
                      <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
                    </div>
                    {cmndTccHC.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={
                            detail.data1[1] === true &&
                            dataDetailNv[detail.data1[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data1[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data1[0]]
                          }
                          titleRight={detail.title2}
                          itemRight={
                            detail.data2[1] === true &&
                            dataDetailNv[detail.data2[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data2[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data2[0]]
                          }
                        />
                      );
                    })}
                  </>
                )}
              </div>

              <div className="form" id="contact">
                <div className="big-title">
                  <div className="name-title" onClick={arrowContactClickHandle}>
                    <h3>Thông tin liên hệ</h3>
                  </div>
                  <div className="arrow-button">
                    {/* <button
                      className="main-arrow-button"
                      onClick={arrowContactClickHandle}
                    >
                      <FontAwesomeIcon
                        icon={["fas", "chevron-down"]}
                        className={!dropContact ? "iconss" : "iconsss"}
                      />
                    </button> */}
                  </div>
                </div>
                {dropContact && (
                  <>
                    <div className="title">
                      <h5>Số điện thoại/Email/Khác</h5>
                    </div>
                    {sdtEK.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={dataDetailNv[detail.data1]}
                          titleRight={detail.title2}
                          itemRight={dataDetailNv[detail.data2]}
                        />
                      );
                    })}
                    <div className="title">
                      <h5>Liên hệ khẩn cấp</h5>
                    </div>
                    {lhkc.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={dataDetailNv[detail.data1]}
                          titleRight={detail.title2}
                          itemRight={dataDetailNv[detail.data2]}
                        />
                      );
                    })}
                  </>
                )}
              </div>
              <div className="form" id="job">
                <div className="big-title">
                  <div className="name-title" onClick={arrowJobClickHandle}>
                    <h3>Thông tin công việc</h3>
                  </div>
                  <div className="arrow-button">
                    {/* <button
                      className="main-arrow-button"
                      onClick={arrowJobClickHandle}
                    >
                      <FontAwesomeIcon
                        icon={["fas", "chevron-down"]}
                        className={!dropJob ? "iconss" : "iconsss"}
                      />
                    </button> */}
                  </div>
                </div>
                {dropJob && (
                  <>
                    <div className="title">
                      <h5>Thông tin nhân viên</h5>
                    </div>
                    {ttnv.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={dataDetailNv[detail.data1]}
                          titleRight={detail.title2}
                          itemRight={
                            detail.data2[1] === true &&
                            dataDetailNv[detail.data2[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data2[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data2[0]]
                          }
                        />
                      );
                    })}
                  </>
                )}
              </div>
              <div className="form" id="insurance">
                <div className="big-title">
                  <div
                    className="name-title"
                    onClick={arrowInsuranceClickHandle}
                  >
                    <h3>Thông tin bảo hiểm</h3>
                  </div>
                  <div className="arrow-button">
                    {/* <button
                      className="main-arrow-button"
                      onClick={arrowInsuranceClickHandle}
                    >
                      <FontAwesomeIcon
                        icon={["fas", "chevron-down"]}
                        className={!dropInsurance ? "iconss" : "iconsss"}
                      />
                    </button> */}
                  </div>
                </div>
                {dropInsurance && (
                  <>
                    {ttbh.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={dataDetailNv[detail.data1]}
                          titleRight={detail.title2}
                          itemRight={dataDetailNv[detail.data2]}
                        />
                      );
                    })}
                  </>
                )}
              </div>

              <div className="form" id="politics">
                <div className="big-title">
                  <div
                    className="name-title"
                    onClick={arrowPoliticsClickHandle}
                  >
                    <h3>Thông tin chính trị, quân sự, y tế</h3>
                  </div>
                  <div className="arrow-button">
                    {/* <button
                      className="main-arrow-button"
                      onClick={arrowPoliticsClickHandle}
                    >
                      <FontAwesomeIcon
                        icon={["fas", "chevron-down"]}
                        className={!dropPolitics ? "iconss" : "iconsss"}
                      />
                    </button> */}
                  </div>
                </div>
                {dropPolitics && (
                  <>
                    <div className="title">
                      <h5>Thông tin chính trị</h5>
                    </div>
                    {ttct.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={
                            detail.data1[1] === true &&
                            dataDetailNv[detail.data1[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data1[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data1[0]]
                          }
                          titleRight={detail.title2}
                          itemRight={
                            detail.data2[1] === true &&
                            dataDetailNv[detail.data2[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data2[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data2[0]]
                          }
                        />
                      );
                    })}
                    <div className="title">
                      <h5>Thông tin quân sự</h5>
                    </div>
                    {ttqs.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={
                            detail.data1[1] === true &&
                            dataDetailNv[detail.data1[0]] !== null
                              ? dateFormat(
                                  dataDetailNv[detail.data1[0]],
                                  "dd/mm/yyyy"
                                )
                              : dataDetailNv[detail.data1[0]]
                          }
                          titleRight={detail.title2}
                          itemRight={dataDetailNv[detail.data2]}
                        />
                      );
                    })}
                    <div className="title">
                      <h5>Thông tin y tế</h5>
                    </div>
                    {ttyt.map((detail, key) => {
                      return (
                        <SubDetail
                          key={key}
                          titleLeft={detail.title1}
                          itemLeft={dataDetailNv[detail.data1]}
                          titleRight={detail.title2}
                          itemRight={dataDetailNv[detail.data2]}
                        />
                      );
                    })}
                  </>
                )}
              </div>
              <div className="form" id="history">
                <div className="big-title">
                  <div className="name-title" onClick={arrowHistoryClickHandle}>
                    <h3>Lịch sử bản thân</h3>
                  </div>
                  <div className="arrow-button">
                    {/* <button
                      className="main-arrow-button"
                      onClick={arrowHistoryClickHandle}
                    >
                      <FontAwesomeIcon
                        icon={["fas", "chevron-down"]}
                        className={!dropHistory ? "iconss" : "iconsss"}
                      />
                    </button> */}
                  </div>
                </div>

                {dropHistory && (
                  <>
                    <div className="titles">
                      <div className="title-history">
                        <h5 className="title-names">
                          Bị bắt, bị tù (thời gian và địa điểm), khai báo cho
                          ai, những vấn đề gì?
                        </h5>
                      </div>
                    </div>
                    <div className="areas">
                      <p className="area-history">{dataDetailNv.biBatDitu}</p>
                    </div>
                    <div className="titles">
                      <div className="title-history">
                        <h5 className="title-names">
                          Tham gia hoặc có quan hệ với các tổ chức chính trị,
                          kinh tế, xã hội ở nước ngoài
                        </h5>
                      </div>
                    </div>
                    <div className="areas">
                      <p className="area-history">
                        {dataDetailNv.thamGiaChinhTri}
                      </p>
                    </div>
                    <div className="titles">
                      <div className="title-history">
                        <h5 className="title-names">
                          Có Thân nhân(cha, mẹ, vợ, chồng, con, anh chị em ruột)
                          ở nước ngoài (làm gì, địa chỉ...)?
                        </h5>
                      </div>
                    </div>
                    <div className="areas">
                      <p className="area-history">
                        {dataDetailNv.thanNhanNuocNgoai}
                      </p>
                    </div>
                  </>
                )}
              </div>
            </ComponentToPrint>
            <div className="form" id="cultural">
              <div className="big-title">
                <div className="name-title" onClick={arrowCulturalClickHandle}>
                  <div>
                    <h3>Trình độ văn hóa</h3>
                  </div>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowCulturalClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropCultural ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropCultural && (
                <>
                  <div className="title">
                    <div className="title-cultural">
                      <h5 className="title-name">Trình độ</h5>
                    </div>
                    <div className="icon-cultural">
                      <Link
                        to={`/profile/detail/level/add?maNhanVien=${dataDetailNv.id}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/profile/detail/level/"
                      columns={NVCOLUMNSTDVH}
                      data={dataDetailTDVH}
                    />
                  </div>
                  <div className="title">
                    <div className="title-cultural">
                      <h5 className="title-name">Ngoại ngữ</h5>
                    </div>
                    <div className="icon-cultural">
                      <Link
                        to={`/profile/detail/language/add?maNhanVien=${dataDetailNv.id}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/profile/detail/language/"
                      columns={NVCOLUMNSNN}
                      data={dataDetailNgn}
                    />
                  </div>
                </>
              )}
            </div>
            <div className="form" id="family">
              <div className="big-title">
                <div className="name-title" onClick={arrowFamilyClickHandle}>
                  <h3>Thông tin gia đình</h3>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowFamilyClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropFamily ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropFamily && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/profile/detail/family/add?maNhanVien=${dataDetailNv.id}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/profile/detail/family/"
                      columns={NVCOLUMNSNT}
                      data={dataDetailGd}
                    />
                  </div>
                </>
              )}
            </div>
            <div className="form" id="contract">
              <div className="big-title">
                <div className="name-title" onClick={arrowContractClickHandle}>
                  <h3>Hợp đồng lao động</h3>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowContractClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContract ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropContract && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link to={`/contract/add?maNhanVien=${dataDetailNv.id}`}>
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/contract/detail/"
                      columns={NVCOLUMNSHD}
                      data={dataDetailHd}
                    />
                  </div>
                </>
              )}
            </div>
            <div className="form" id="salary">
              <div className="big-title">
                <div className="name-title" onClick={arrowSalaryClickHandle}>
                  <h3>Hồ sơ lương</h3>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowSalaryClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropSalary ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropSalary && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link to={`/salary/add?maNhanVien=${dataDetailNv.id}`}>
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/salary/detail/"
                      columns={NVCOLUMNSL}
                      data={dataLuong}
                    />
                  </div>
                </>
              )}
            </div>
            <div className="form" id="transfer">
              <div className="big-title">
                <div className="name-title" onClick={arrowTransferClickHandle}>
                  <h3>Thuyên chuyển</h3>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowTransferClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropTransfer ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropTransfer && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link to={`/transfer/add?maNhanVien=${dataDetailNv.id}&hoVaTen=${dataDetailNv.hoTen}`}>
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/transfer/detail/"
                      columns={NVCOLUMNSDC}
                      data={dataDetailTc}
                    />
                  </div>
                </>
              )}
            </div>
            <div className="form" id="reward">
              <div className="big-title">
                <div className="name-title" onClick={arrowRewardClickHandle}>
                  <h3>Khen thưởng</h3>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowRewardClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropReward ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropReward && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link to={`/reward/add?maNhanVien=${dataDetailNv.id}&hoVaTen=${dataDetailNv.hoTen}`}>
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/reward/detail/"
                      columns={NVCOLUMNSKTvKL}
                      data={dataDetailKt}
                    />
                  </div>
                </>
              )}
            </div>
            <div className="form" id="discipline">
              <div className="big-title">
                <div
                  className="name-title"
                  onClick={arrowDisciplineClickHandle}
                >
                  <h3>Kỉ luật</h3>
                </div>
                <div className="arrow-button">
                  {/* <button
                    className="main-arrow-button"
                    onClick={arrowDisciplineClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropDiscipline ? "iconss" : "iconsss"}
                    />
                  </button> */}
                </div>
              </div>
              {dropDiscipline && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/discipline/add?maNhanVien=${dataDetailNv.id}&hoVaTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="table">
                    <TableBasic
                      link="/discipline/detail/"
                      columns={NVCOLUMNSKTvKL}
                      data={dataDetailKl}
                    />
                  </div>
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
