import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailTransfer.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
function ScreenDetailTransfer(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailDC, setDataDetailDC] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getDCDetail(id);
        setDataDetailDC(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataDetailDC);
  return (
    <>
      <div className="main-screen">
        <div className="first-main">
          <div className="first-path">
            <button className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon className="icon-btn" icon={["fas", "long-arrow-alt-left"]} />
            </button>
          </div>
          <div className="second-path">
            <h2>Thủ tục thuyên chuyển</h2>
          </div>
          <div className="third-path">
          <Link to={`/transfer/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Vị trí công tác hiện tại</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={null}
              titleRight="Ngày hiệu lực"
              itemRight={dataDetailDC.ngayHieuLuc}
            ></SubDetail>
            <SubDetail
              titleLeft="Phòng ban"
              itemLeft={dataDetailDC.idPhongBan}
              titleRight="Chi tiết"
              itemRight={dataDetailDC.chiTiet}
            ></SubDetail>
            <SubDetail
              titleLeft="Tổ"
              itemLeft={dataDetailDC.to}
              titleRight="Chức vụ"
              itemRight={dataDetailDC.idChucVu}
            ></SubDetail>
            <SubDetail
              titleLeft="Trạng thái"
              itemLeft={dataDetailDC.trangThai}
              titleRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailTransfer;
