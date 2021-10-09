import React, { useContext, useEffect, useState } from "react";
import "./Detail.scss";
import SubDetail from "./SubDetail";
import { links } from "./ScrollData";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Container, Row, Col, Button } from "react-bootstrap";
import { dum } from "./Data";
import { ListContext } from "../../Contexts/ListContext";
import ProductApi from "../../api/productApi";
function Detail(props) {
  let { match, history } = props;
  let { id } = match.params;
  console.log(id);

  const [dataDetailNv, setdataDetailNv] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getNvDetail(id);
        // console.log(responseNv);
        setdataDetailNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailNv);
    console.log(dataDetailNv.maNhanVien);

  const dataDetail = [];
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
                <h5>{dataDetail.firstName + " " + dataDetail.lastName}</h5>
              </div>
              <div className="codes">
                <p>{dataDetail.id}</p>
              </div>
            </div>
          </div>
          <div className="middle-path">
            <Container className="containn">
              <Row className="row-detail">
                <Col>
                  <Row>
                    <Col>
                      <p className="fast-information">Đơn vị công tác</p>
                    </Col>
                    <Col>
                      <p className="fast-information"></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col>
                      <p className="fast-information">Ngày thử việc</p>
                    </Col>
                    <Col>
                      <p className="fast-information"></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col>
                      <p className="fast-information">Ngày chính thức</p>
                    </Col>
                    <Col>
                      <p className="fast-information"></p>
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
                      <p className="fast-information"></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">ĐT di động</p>
                    </Col>
                    <Col>
                      <p className="fast-information"></p>
                    </Col>
                  </Row>
                </Col>
                <Col>
                  <Row>
                    <Col xs lg="5">
                      <p className="fast-information">Email</p>
                    </Col>
                    <Col>
                      <p className="fast-information"></p>
                    </Col>
                  </Row>
                </Col>
              </Row>
            </Container>
          </div>
          <div className="right-path">
            <Button className="button-color">Sửa</Button>
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
                    itemLeft={dataDetailNv.maNhanVien}
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
                    titleRight="Ngày công tác"
                    itemRight={dataDetailNv.ngayChinhThuc}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Ngày nghỉ việc"
                    itemLeft={dataDetailNv.ngayNghiViec}
                    titleRight="Lý do nghỉ"
                    itemRight={dataDetailNv.lyDoNghiViec}
                  ></SubDetail>
                  <div className="title">
                    <h5>Thông tin lương</h5>
                  </div>
                  <SubDetail
                    titleLeft="Nhóm lương"
                    itemLeft={null}
                    titleRight="Tiền lương"
                    itemRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Hệ số lương"
                    itemLeft={null}
                    titleRight="Thời hạn lên lương"
                    itemRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Bậc lương"
                    itemLeft={null}
                    titleRight="Ngày hiệu lực"
                    itemRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Lương cơ bản"
                    itemLeft={null}
                    titleRight="Ngày hết hạn"
                    itemRight={null}
                  ></SubDetail>
                  <SubDetail
                    titleLeft="Phụ cấp chức vụ"
                    itemLeft={null}
                    titleRight="Phụ cấp khác"
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
                  <div className="table"></div>
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
