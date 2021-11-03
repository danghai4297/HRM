import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailDiscipline.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
function ScreenDetailDiscipline(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataKLDetail, setDataKLDetail] = useState([]);
  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getKTvKLDetail(id);
        setDataKLDetail(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);
  console.log(dataKLDetail);

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
            <h2>Thủ tục kỷ luật</h2>
          </div>
          <div className="third-path">
            <Link to={`/discipline/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin kỷ luật</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={dataKLDetail.hoTen}
              titleRight="Mã nhân viên"
              itemRight={dataKLDetail.maNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Danh mục"
              itemLeft={dataKLDetail.idDanhMucKhenThuong}
              titleRight="Lý do"
              itemRight={dataKLDetail.lyDo}
            ></SubDetail>
            <SubDetail
              titleLeft="Nội dung"
              itemLeft={dataKLDetail.noiDung}
              titleRight="Ảnh"
              itemRight={dataKLDetail.anh}
            ></SubDetail>
          </div>
        </div>
        <Link
          to={`/profile/detail/${dataKLDetail.maNhanVien}?move=moveToDiscipline`}
        >
          <Button variant="light" className="btn-fix">
            Chuyển
          </Button>
        </Link>
      </div>
    </>
  );
}

export default ScreenDetailDiscipline;
