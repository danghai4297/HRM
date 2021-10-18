import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailForeignLanguage.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
function ScreenDetailForeignLanguage(props) {
  let { match, history } = props;
  let { id } = match.params;
  const [dataDetailNN, setdataDetailNN] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNN = await ProductApi.getNNDetail(id);
        setdataDetailNN(responseNN);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailNN);
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
            <h2>Ngoại ngữ</h2>
          </div>
          <div className="third-path">
          <Link to={`/profile/detail/language/update/${id}`}>
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
              titleLeft="Mã nhân viên"
              itemLeft={dataDetailNN.maNhanVien}
              titleRight="Tên nhân viên"
              itemRight={dataDetailNN.tenNhanVien}
            ></SubDetail>
            <SubDetail
              titleLeft="Ngoại ngữ"
              itemLeft={dataDetailNN.danhMucNgoaiNgu}
              titleRight="Ngày cấp"
              itemRight={dataDetailNN.ngayCap}
            ></SubDetail>
            <SubDetail
              titleLeft="Nơi cấp"
              itemLeft={dataDetailNN.noiCap}
              titleRight="Trình độ"
              itemRight={dataDetailNN.trinhDo}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailForeignLanguage;
