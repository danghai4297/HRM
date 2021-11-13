import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailReward.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
function ScreenDetailReward(props) {
  let { match, history } = props;
  let { id } = match.params;

  const [dataDetailKt, setdataDetailKt] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseKT = await ProductApi.getKTvKLDetail(id);
        setdataDetailKt(responseKT);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailKt);
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
            <h2>Thủ tục khen thưởng</h2>
          </div>
          <div className="third-path">
            <Link to={`/reward/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin khen thưởng</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={dataDetailKt.hoTen}
              titleRight="Mã nhân viên"
              itemRight={dataDetailKt.maNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Danh mục"
              itemLeft={dataDetailKt.idDanhMucKhenThuong}
              titleRight="Lý do"
              itemRight={dataDetailKt.lyDo}
            ></SubDetail>
            <SubDetail
              titleLeft="Nội dung"
              itemLeft={dataDetailKt.noiDung}
              titleRight="Ảnh"
              itemRight={dataDetailKt.anh}
            ></SubDetail>
          </div>
        </div>
        <div className="all-reward">
          <div className="name-move-reward">
            <h3>Tất cả lần khen thưởng</h3>
          </div>
          <Link
            to={`/profile/detail/${dataDetailKt.maNhanVien}?move=moveToReward`}
            className="btn-move-reward"
          >
              <button className="btn-fix">
                <FontAwesomeIcon icon={["fas", "arrow-right"]} style={{fontSize: "50px"}}/>
              </button>
          </Link>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailReward;
