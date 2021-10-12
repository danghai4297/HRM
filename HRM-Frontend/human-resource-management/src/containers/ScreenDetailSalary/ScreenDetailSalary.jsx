import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailSalary.scss";
import ProductApi from "../../api/productApi";
function ScreenDetailSalary(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataLDetail, setDataLDetail] = useState([]);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getLDetail(id);
        setDataLDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataLDetail);

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
            <h2>Chi tiết hồ sơ lương</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-mains">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={null}
              titleRight="Mã nhân viên"
              itemRight={dataLDetail.maNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Mã hợp đồng"
              itemLeft={dataLDetail.maHopDong}
              titleRight="Nhóm lương"
              itemRight={dataLDetail.nhomLuong}
            ></SubDetail>
            <SubDetail
              titleLeft="Hệ số lương"
              itemLeft={dataLDetail.heSoLuong}
              titleRight="Bậc lương"
              itemRight={dataLDetail.bacLuong}
            ></SubDetail>
            <SubDetail
              titleLeft="Phụ cấp chức vụ"
              itemLeft={dataLDetail.phuCapTrachNhiem}
              titleRight="Phụ cấp khác"
              itemRight={dataLDetail.phuCapKhac}
            ></SubDetail>
            <SubDetail
              titleLeft="Ngày có hiệu lực"
              itemLeft={dataLDetail.ngayHieuLuc}
              titleRight="Ngày hết hạn"
              itemRight={dataLDetail.ngayKetThuc}
            ></SubDetail>
            <SubDetail
              titleLeft="Thời hạn lên lương"
              itemLeft={dataLDetail.thoiHanLenLuong}
              titleRight="Tổng lương"
              itemRight={dataLDetail.tongLuong}
            ></SubDetail>
            <SubDetail
              titleLeft="Trạng thái"
              itemLeft={dataLDetail.trangThai}
              titleRight="Ghi chú"
              itemRight={dataLDetail.ghiChu}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailSalary;
