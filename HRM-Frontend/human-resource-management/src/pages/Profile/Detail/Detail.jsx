import React, { useEffect, useState, useRef } from "react";
import "./Detail.scss";
import SubDetail from "../../../components/SubDetail/SubDetail";
import { links } from "./ScrollData";
import dateFormat from "dateformat";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Row, Col } from "react-bootstrap";
import ProductApi from "../../../api/productApi";
import TableBasic from "../../../components/TablePagination/TableBasic";
import IconButton from "@mui/material/IconButton";
import Button from "@mui/material/Button";
import { createTheme } from "@mui/material/styles";
import { red } from "@mui/material/colors";
import ScreenNotFound from "../../Error/ScreenNotFound";
import {
  NVCOLUMNSDC,
  NVCOLUMNSHD,
  NVCOLUMNSKTvKL,
  NVCOLUMNSL,
  NVCOLUMNSNN,
  NVCOLUMNSNT,
  NVCOLUMNSTDVH,
} from "./NvColumns";
import { Link, useLocation, Redirect } from "react-router-dom";
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

function Detail(props) {
  let { match, history } = props;
  let { id } = match.params;

  const theme = createTheme({
    palette: {
      primary: {
        main: red[500],
      },
      secondary: {
        main: "#f44336",
      },
    },
  });

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
    const fetchDetailEmployee = async () => {
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
        history.goBack();
      }
    };
    fetchDetailEmployee();
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

  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataDetailNv.length !== 0)
        document.title = `Chi tiết hồ sơ nhân viên ${dataDetailNv.hoTen}`;
    };
    titlePage();
  }, [dataDetailNv]);

  //Hàm tự động chuyển đến tiêu đề
  const clickHandleScroll = (e) => {
    e.preventDefault();
    const target = e.target.getAttribute("href");
    const height = document.getElementById("right");
    const location = document.querySelector(target).offsetTop;
    height.scrollTo({
      top: location - 260,
      behavior: "smooth",
    });
  };

  //Lấy param truyền từ trang khác
  let location = useLocation();
  let query = new URLSearchParams(location.search);

  // Hàm setTimeout để tự di chuyển đến tiêu đề
  useEffect(() => {
    const moveTo = () => {
      setTimeout(() => {
        switch (query.get("move")) {
          case "moveToContract":
            const heightContract = document.getElementById("right");
            const locationContract =
              document.querySelector("#contract").offsetTop;
            heightContract.scrollTo({
              top: locationContract - 260,
              behavior: "smooth",
            });
            break;
          case "moveToSalary":
            const heightSalary = document.getElementById("right");
            const locationSalary = document.querySelector("#salary").offsetTop;
            heightSalary.scrollTo({
              top: locationSalary - 260,
              behavior: "smooth",
            });
            break;
          case "moveToTransfer":
            const heightTransfer = document.getElementById("right");
            const locationTransfer =
              document.querySelector("#transfer").offsetTop;
            heightTransfer.scrollTo({
              top: locationTransfer - 260,
              behavior: "smooth",
            });
            break;
          case "moveToReward":
            const heightReward = document.getElementById("right");
            const locationReward = document.querySelector("#reward").offsetTop;
            heightReward.scrollTo({
              top: locationReward - 260,
              behavior: "smooth",
            });
            break;
          case "moveToDiscipline":
            const heightDiscipline = document.getElementById("right");
            const locationDiscipline =
              document.querySelector("#discipline").offsetTop;
            heightDiscipline.scrollTo({
              top: locationDiscipline - 260,
              behavior: "smooth",
            });
            break;
          default:
            break;
        }
      }, 200);
    };
    moveTo();
  }, []);

  return (
    <>
      <div className="contents">
        <div className="first-information">
          <div className="left-path">
            <div className="icons">
              <IconButton className="btn-back" onClick={history.goBack}>
                <FontAwesomeIcon
                  className="icon-btn"
                  icon={["fas", "long-arrow-alt-left"]}
                />
              </IconButton>
            </div>

            <div className="avatar">
              <div className="icon-second">
                {dataDetailNv.anh !== null ? (
                  <img
                    src={`http://localhost:8000/${dataDetailNv.anh}`}
                    alt=""
                  />
                ) : (
                  <img src="/Images/loginImage.png" alt="" />
                )}
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
                        : dateFormat(dataDetailNv.ngayChinhThuc, "dd/mm/yyyy")}
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
                      {dataDetailNv.diDong === null ? "-" : dataDetailNv.diDong}
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
          </div>
          <div className="right-path">
            <Link to={`/profile/${id}`}>
              <Button variant="contained" className="btn-edit-detail">
                Sửa
              </Button>
            </Link>
            <Link to={`/profile/pdf/${id}`}>
              <Button
                variant="contained"
                theme={theme}
                className="btn-edit-detail"
              >
                <FontAwesomeIcon icon={["fas", "download"]} />
              </Button>
            </Link>
          </div>
        </div>
        <div className="main-information">
          <div className="left-header-information" id="abcccc">
            <ul className="list-left">
              {links.map((link) => {
                return (
                  <li className="row-left">
                    <h5>
                      <a
                        href={link.url}
                        key={link.id}
                        onClick={clickHandleScroll}
                      >
                        {link.text}
                      </a>
                    </h5>
                  </li>
                );
              })}
            </ul>
          </div>

          <div className="right-information" id="right">
            <div className="form" id="base">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin cơ bản</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    color="default"
                    onClick={() => {
                      setDropBase(!dropBase);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropBase ? "iconss" : "iconsss"}
                    />
                  </IconButton>
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
                <div className="name-title">
                  <h3>Thông tin liên hệ</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropContact(!dropContact);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContact ? "iconss" : "iconsss"}
                    />
                  </IconButton>
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
                <div className="name-title">
                  <h3>Thông tin công việc</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropJob(!dropJob);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropJob ? "iconss" : "iconsss"}
                    />
                  </IconButton>
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
                <div className="name-title">
                  <h3>Thông tin bảo hiểm</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropInsurance(!dropInsurance);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropInsurance ? "iconss" : "iconsss"}
                    />
                  </IconButton>
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
                <div className="name-title">
                  <h3>Thông tin chính trị, quân sự, y tế</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropPolitics(!dropPolitics);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropPolitics ? "iconss" : "iconsss"}
                    />
                  </IconButton>
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
                <div className="name-title">
                  <h3>Lịch sử bản thân</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropHistory(!dropHistory);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropHistory ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>

              {dropHistory && (
                <>
                  <div className="titles">
                    <div className="title-history">
                      <h5 className="title-names">
                        Bị bắt, bị tù (thời gian và địa điểm), khai báo cho ai,
                        những vấn đề gì?
                      </h5>
                    </div>
                  </div>
                  <div className="areas">
                    <p className="area-history">{dataDetailNv.biBatDitu}</p>
                  </div>
                  <div className="titles">
                    <div className="title-history">
                      <h5 className="title-names">
                        Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh
                        tế, xã hội ở nước ngoài
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
                        Có Thân nhân(cha, mẹ, vợ, chồng, con, anh chị em ruột) ở
                        nước ngoài (làm gì, địa chỉ...)?
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
            <div className="form" id="cultural">
              <div className="big-title">
                <div className="name-title">
                  <div>
                    <h3>Trình độ văn hóa</h3>
                  </div>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropCultural(!dropCultural);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropCultural ? "iconss" : "iconsss"}
                    />
                  </IconButton>
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
                        to={`/profile/detail/level/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                        to={`/profile/detail/language/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                <div className="name-title">
                  <h3>Thông tin gia đình</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropFamily(!dropFamily);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropFamily ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>
              {dropFamily && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/profile/detail/family/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                <div className="name-title">
                  <h3>Hợp đồng lao động</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropContract(!dropContract);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContract ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>
              {dropContract && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/contract/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                <div className="name-title">
                  <h3>Hồ sơ lương</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropSalary(!dropSalary);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropSalary ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>
              {dropSalary && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/salary/add?maHopDong=${
                          dataDetailHd.length !== 0 &&
                          dataDetailHd.filter(
                            (a) => a.trangThai === "Kích hoạt"
                          ).length !== 0
                            ? dataDetailHd.filter(
                                (a) => a.trangThai === "Kích hoạt"
                              )[0].id
                            : ""
                        }&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                <div className="name-title">
                  <h3>Quá trình công tác</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropTransfer(!dropTransfer);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropTransfer ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>
              {dropTransfer && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/transfer/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                <div className="name-title">
                  <h3>Khen thưởng</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropReward(!dropReward);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropReward ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>
              {dropReward && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/reward/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
                <div className="name-title">
                  <h3>Kỷ luật</h3>
                </div>
                <div className="arrow-button">
                  <IconButton
                    className="main-arrow-button"
                    onClick={() => {
                      setDropDiscipline(!dropDiscipline);
                    }}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropDiscipline ? "iconss" : "iconsss"}
                    />
                  </IconButton>
                </div>
              </div>
              {dropDiscipline && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <Link
                        to={`/discipline/add?maNhanVien=${dataDetailNv.id}&hoTen=${dataDetailNv.hoTen}`}
                      >
                        <button className="btn-cultural">
                          <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                        </button>
                      </Link>
                    </div>
                  </div>
                  <div className="tablexx">
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
