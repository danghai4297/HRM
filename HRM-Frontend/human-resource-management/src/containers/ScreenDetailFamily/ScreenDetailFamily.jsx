import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailFamily.scss";
import ProductApi from "../../api/productApi";
function ScreenDetailFamily(props) {
  let { match, history } = props;
  let { id } = match.params;
  const [dataDetailNT, setdataDetailNT] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNT = await ProductApi.getNTDetail(id);
        setdataDetailNT(responseNT);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailNT);

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
            <h2>Thông tin gia đình</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Mã nhân viên"
              itemLeft={dataDetailNT.maNhanVien}
              titleRight="Tên nhân viên"
              itemRight={dataDetailNT.tenNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={dataDetailNT.tenNguoiThan}
              titleRight="Danh mục người thân"
              itemRight={dataDetailNT.danhMucNguoiThan}
            ></SubDetail>
            <SubDetail
              titleLeft="Giới tính"
              itemLeft={dataDetailNT.gioiTinh}
              titleRight="Quan hệ"
              itemRight={dataDetailNT.quanHe}
            ></SubDetail>
            <SubDetail
              titleLeft="Địa chỉ"
              itemLeft={dataDetailNT.diaChi}
              titleRight="Ngày sinh"
              itemRight={dataDetailNT.ngaySinh}
            ></SubDetail>
            <SubDetail
              titleLeft="Nghề nghiệp"
              itemLeft={dataDetailNT.ngheNghiep}
              titleRight="Điện thoại"
              itemRight={dataDetailNT.dienThoai}
            ></SubDetail>
            <SubDetail
              titleLeft="Thông tin khác"
              itemLeft={dataDetailNT.khac}
              titleRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailFamily;
