import React, { useContext, useEffect, useState } from "react";
import "./Detail.scss";
import SubDetail from "./SubDetail";
import { links } from "./ScrollData";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Container, Row, Col, Button } from "react-bootstrap";
import ProductApi from "../../api/productApi";
import TableBasic from "../TablePagination/TableBasic";
import {
  NVCOLUMNSDC,
  NVCOLUMNSHD,
  NVCOLUMNSKTvKL,
  NVCOLUMNSNN,
  NVCOLUMNSNT,
  NVCOLUMNSTDVH,
} from "./NvColumns";

function Detail(props) {
  let { match, history } = props;
  let { id } = match.params;
  

  const [dataDetailNv, setdataDetailNv] = useState([]);
  const [dataDetailTDVH, setdataDetailTDVH] = useState([]);
  const [dataDetailNgn, setdataDetailNgn] = useState([]);
  const [dataDetailGd, setdataDetailGd] = useState([]);
  const [dataDetailHd, setdataDetailHd] = useState([]);
  // const [dataDetailHSL, setdataDetailHSL] = useState([]);
  const [dataDetailTc, setdataDetailTc] = useState([]);
  const [dataDetailKt, setdataDetailKt] = useState([]);
  const [dataDetailKl, setdataDetailKl] = useState([]);
  

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getNvDetail(id);
        // const responseHd = await ProductApi.getHdDetail(id);
        setdataDetailNv(responseNv);
        setdataDetailTDVH(responseNv.trinhDoVanHoas);
        setdataDetailNgn(responseNv.ngoaiNgus);
        setdataDetailGd(responseNv.nguoiThans);
        setdataDetailHd(responseNv.hopDongs);
        // setdataDetailHSL(responseNv);
        setdataDetailTc(responseNv.dieuChuyens);
        setdataDetailKt(responseNv.khenThuongs);
        setdataDetailKl(responseNv.kyLuats);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataDetailNv)
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
      top: location - 300,
      behavior: "smooth",
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
              <div className="icon-second">
                <FontAwesomeIcon icon={["fas", "user-circle"]} />
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
                          : dataDetailNv.ngayThuViec}
                      </p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">Ngày chính thức</p>
                    </Col>
                    <Col>
                      <p className="fast-information">
                        {dataDetailNv.ngayChinhThuc === null
                          ? "-"
                          : dataDetailNv.ngayChinhThuc}
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
                          : dataDetailNv.ngaySinh}
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
            <Button className="button-color" variant="dark">Sửa</Button>
            <Button className="button-color" variant="danger">
              Xóa
            </Button>
            <Button className="button-color" variant="light">
              <FontAwesomeIcon icon={["fas", "download"]} />
            </Button>
          </div>
        </div>
        <div className="main-information">
          <div className="left-header-information">
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
            <div className="form" id="base">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin cơ bản</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowBaseClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropBase ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropBase && (
                <>
                  <div className="title">
                    <h5>Thông tin chung</h5>
                  </div>
                  <SubDetail
                    titleLeft="Mã nhân viên"
                    itemLeft={dataDetailNv.id}
                    titleRight="TK Ngân hàng"
                    itemRight={dataDetailNv.atm}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Họ và tên"
                    itemLeft={dataDetailNv.hoTen}
                    titleRight="Ngân hàng"
                    itemRight={dataDetailNv.nganHang}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Giới tính"
                    itemLeft={dataDetailNv.gioiTinh}
                    titleRight="Tình trạng hôn nhân"
                    itemRight={dataDetailNv.honNhan}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày sinh"
                    itemLeft={dataDetailNv.ngaySinh}
                    titleRight="MST cá nhân"
                    itemRight={dataDetailNv.maSoThue}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nơi sinh"
                    itemLeft={dataDetailNv.noiSinh}
                    titleRight="Dân tộc"
                    itemRight={dataDetailNv.danToc}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Quê quán"
                    itemLeft={dataDetailNv.queQuan}
                    titleRight="Tôn giáo"
                    itemRight={dataDetailNv.tonGiao}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Thường trú"
                    itemLeft={dataDetailNv.thuongTru}
                    titleRight="Quốc tịch"
                    itemRight={dataDetailNv.quocTich}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Tạm trú"
                    itemLeft={dataDetailNv.tamTru}
                    titleRight={null}
                  ></SubDetail>
                  <div className="title">
                    <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
                  </div>
                  <SubDetail
                    titleLeft="Số CMND/CCCD"
                    itemLeft={dataDetailNv.cccd}
                    titleRight="Số hộ chiếu"
                    itemRight={dataDetailNv.hoChieu}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày cấp(CMNN/CCCD)"
                    itemLeft={dataDetailNv.ngayCapCCCD}
                    titleRight="Ngày cấp hộ chiếu"
                    itemRight={dataDetailNv.ngayCapHoChieu}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Nơi cấp(CMND/CCCD)"
                    itemLeft={dataDetailNv.noiCapCCCD}
                    titleRight="Nơi cấp hộ chiếu"
                    itemRight={dataDetailNv.noiCapHoChieu}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày hết hạn"
                    itemLeft={dataDetailNv.ngayHetHanCCCD}
                    titleRight="Ngày hết hạn hộ chiếu"
                    itemRight={dataDetailNv.ngayHetHanHoChieu}
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
                  <button
                    className="main-arrow-button"
                    onClick={arrowContactClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContact ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropContact && (
                <>
                  <div className="title">
                    <h5>Số điện thoại/Email/Khác</h5>
                  </div>
                  <SubDetail
                    titleLeft="ĐT di động"
                    itemLeft={dataDetailNv.diDong}
                    titleRight="Email cá nhân"
                    itemRight={dataDetailNv.email}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="ĐT khác"
                    itemLeft={dataDetailNv.dienThoaiKhac}
                    titleRight="Facebook"
                    itemRight={dataDetailNv.facebook}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="ĐT nhà riêng"
                    itemLeft={dataDetailNv.dienThoai}
                    titleRight="Skype"
                    itemRight={dataDetailNv.skype}
                  ></SubDetail>
                  <div className="title">
                    <h5>Liên hệ khẩn cấp</h5>
                  </div>
                  <SubDetail
                    titleLeft="Họ và tên"
                    itemLeft={dataDetailNv.lhkcHoTen}
                    titleRight="Email"
                    itemRight={dataDetailNv.lhkcEmail}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Quan hệ"
                    itemLeft={dataDetailNv.lhkcQuanHe}
                    titleRight="Địa chỉ"
                    itemRight={dataDetailNv.lhkcDiaChi}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="ĐT di động"
                    itemLeft={dataDetailNv.lhkcDienThoai}
                    titleRight={null}
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
                  <button
                    className="main-arrow-button"
                    onClick={arrowJobClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropJob ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropJob && (
                <>
                  <div className="title">
                    <h5>Thông tin nhân viên</h5>
                  </div>
                  <SubDetail
                    titleLeft="Nghề nghiệp"
                    itemLeft={dataDetailNv.ngheNghiep}
                    titleRight="Ngày thử việc"
                    itemRight={dataDetailNv.ngayThuViec}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Cơ quan tuyển dụng"
                    itemLeft={dataDetailNv.coQuanTuyenDung}
                    titleRight="Ngày tuyển dụng"
                    itemRight={dataDetailNv.ngayTuyenDung}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Chức vụ hiện tại"
                    itemLeft={dataDetailNv.chucVuHienTai}
                    titleRight="Ngày vào ban"
                    itemRight={dataDetailNv.ngayVaoBan}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Trạng thái lao động"
                    itemLeft={dataDetailNv.trangThaiLaoDong}
                    titleRight="Công việc chính"
                    itemRight={dataDetailNv.congViecChinh}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Tính chất lao động"
                    itemLeft={dataDetailNv.tinhChatLaoDong}
                    titleRight="Ngày chính thức"
                    itemRight={dataDetailNv.ngayChinhThuc}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày nghỉ việc"
                    itemLeft={dataDetailNv.ngayNghiViec}
                    titleRight="Lý do nghỉ"
                    itemRight={dataDetailNv.lyDoNghiViec}
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
                  <button
                    className="main-arrow-button"
                    onClick={arrowInsuranceClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropInsurance ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropInsurance && (
                <>
                  <SubDetail
                    titleLeft="Số sổ BHXH"
                    itemLeft={dataDetailNv.bhxh}
                    titleRight="Số thẻ BHYT"
                    itemRight={dataDetailNv.bhyt}
                  ></SubDetail>
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
                  <button
                    className="main-arrow-button"
                    onClick={arrowCulturalClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropCultural ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropCultural && (
                <>
                  <div className="title">
                    <div className="title-cultural">
                      <h5 className="title-name">Trình độ</h5>
                    </div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
                <div className="name-title">
                  <h3>Thông tin gia đình</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowFamilyClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropFamily ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropFamily && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
            <div className="form" id="politics">
              <div className="big-title">
                <div className="name-title">
                  <h3>Thông tin chính trị, quân sự, y tế</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowPoliticsClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropPolitics ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropPolitics && (
                <>
                  <div className="title">
                    <h5>Thông tin chính trị</h5>
                  </div>
                  <SubDetail
                    titleLeft="Ngạch công chức"
                    itemLeft={dataDetailNv.ngachCongChuc}
                    titleRight="Ngạch công chức nội dung"
                    itemRight={dataDetailNv.ngachCongChucNoiDung}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Là Đảng viên"
                    itemLeft={dataDetailNv.vaoDang}
                    titleRight="Ngày vào đoàn"
                    itemRight={dataDetailNv.ngayVaoDoan}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày vào Đảng"
                    itemLeft={dataDetailNv.ngayVaoDang}
                    titleRight="Nơi tham gia"
                    itemRight={dataDetailNv.noiThamGia}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày chính thức"
                    itemLeft={dataDetailNv.ngayChinhThuc}
                    titleRight={null}
                  ></SubDetail>
                  <div className="title">
                    <h5>Thông tin quân sự</h5>
                  </div>
                  <SubDetail
                    titleLeft="Là quân nhân"
                    itemLeft={dataDetailNv.quanNhan}
                    titleRight="Thương binh"
                    itemRight={dataDetailNv.thuongBinh}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày nhập ngũ"
                    itemLeft={dataDetailNv.ngayNhapNgu}
                    titleRight="Con gia đình chính sách"
                    itemRight={dataDetailNv.conChinhSach}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày xuất ngũ"
                    itemLeft={dataDetailNv.ngayXuatNgu}
                    titleRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Quân hàm cao nhất"
                    itemLeft={dataDetailNv.quanHamCaoNhat}
                    titleRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="DH được phong tặng cao nhất"
                    itemLeft={dataDetailNv.danhHieuCaoNhat}
                    titleRight={null}
                  ></SubDetail>
                  <div className="title">
                    <h5>Thông tin y tế</h5>
                  </div>
                  <SubDetail
                    titleLeft="Nhóm máu"
                    itemLeft={dataDetailNv.ytNhomMau}
                    titleRight="Bệnh tật"
                    itemRight={dataDetailNv.ytBenhTat}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Chiều cao(m)"
                    itemLeft={dataDetailNv.ytChieuCao}
                    titleRight="Lưu ý"
                    itemRight={dataDetailNv.ytLuuY}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Cân nặng(kg)"
                    itemLeft={dataDetailNv.ytCanNang}
                    titleRight="Là người khuất tật"
                    itemRight={dataDetailNv.ytKhuyetTat}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Tình trạng sức khỏe"
                    itemLeft={dataDetailNv.ytTinhTrangSucKhoe}
                    titleRight={null}
                  ></SubDetail>
                </>
              )}
            </div>
            <div className="form" id="history">
              <div className="big-title">
                <div className="name-title">
                  <h3>Lịch sử bản thân</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowHistoryClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropHistory ? "iconss" : "iconsss"}
                    />
                  </button>
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
            <div className="form" id="contract">
              <div className="big-title">
                <div className="name-title">
                  <h3>Hợp đồng lao động</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowContractClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropContract ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropContract && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
                <div className="name-title">
                  <h3>Hồ sơ lương</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowSalaryClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropSalary ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropSalary && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
                    </div>
                  </div>
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
                  <button
                    className="main-arrow-button"
                    onClick={arrowTransferClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropTransfer ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropTransfer && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
                <div className="name-title">
                  <h3>Khen thưởng</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowRewardClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropReward ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropReward && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
                <div className="name-title">
                  <h3>Kỉ luật</h3>
                </div>
                <div className="arrow-button">
                  <button
                    className="main-arrow-button"
                    onClick={arrowDisciplineClickHandle}
                  >
                    <FontAwesomeIcon
                      icon={["fas", "chevron-down"]}
                      className={!dropDiscipline ? "iconss" : "iconsss"}
                    />
                  </button>
                </div>
              </div>
              {dropDiscipline && (
                <>
                  <div className="title">
                    <div className="title-cultural"></div>
                    <div className="icon-cultural">
                      <button className="btn-cultural">
                        <FontAwesomeIcon icon={["fas", "plus"]} /> Thêm
                      </button>
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
