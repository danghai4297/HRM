import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailTransfer.scss";
import ProductApi from "../../api/productApi";
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
            <FontAwesomeIcon icon={["fas", "long-arrow-alt-left"]} />
          </div>
          <div className="second-path">
            <h2>Thủ tục thuyên chuyển</h2>
          </div>
          <div className="third-path">
            <Button variant="light" className="btn-fix">
              Sửa
            </Button>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Vị trí công tác hiện tại</h3>
          <div className="second-main-path">
            <SubDetail
              titleLeft="Họ và tên"
              itemLeft={null}
              titleRight="Ngày hiệu lực"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Phòng ban"
              itemLeft={null}
              titleRight="Chi tiết"
              itemRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Tổ"
              itemLeft={null}
              titleRight={null}
            ></SubDetail>
            <SubDetail
              titleLeft="Chức vụ công tác"
              itemLeft={null}
              titleRight={null}
            ></SubDetail>
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailTransfer;
