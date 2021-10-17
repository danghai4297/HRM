import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailContract.scss";
import SubDetail from "../../components/Detail/SubDetail";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
function ScreenDetailContract(props) {
  let { match, history } = props;
  let { id } = match.params;
  console.log(id);

  const [dataDetailHd, setdataDetailHd] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseHD = await ProductApi.getHdDetail(id);
        setdataDetailHd(responseHD);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <button className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path">
            <h2>Chi tiết hợp đồng</h2>
          </div>
          <div className="third-path">
            <Link to={`/contract/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={dataDetailHd.tenNhanVien}
              titleRight="Mã nhân viên"
              itemRight={dataDetailHd.maNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Mã hợp đồng"
              itemLeft={dataDetailHd.id}
              titleRight="Loại hợp đồng"
              itemRight={dataDetailHd.loaiHopDong}
            ></SubDetail>
            <SubDetail
              titleLeft="Trạng thái"
              itemLeft={dataDetailHd.trangThai}
              titleRight="Chức danh công việc"
              itemRight={dataDetailHd.chucDanh}
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày có hiệu lực"
              itemLeft={dataDetailHd.hopDongTuNgay}
              titleRight="Ngày hết hạn"
              itemRight={dataDetailHd.hopDongDenNgay}
            ></SubDetail>
            <SubDetail
              titleLeft="Ghi chú"
              itemLeft={dataDetailHd.ghiChu}
              titleRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailContract;
