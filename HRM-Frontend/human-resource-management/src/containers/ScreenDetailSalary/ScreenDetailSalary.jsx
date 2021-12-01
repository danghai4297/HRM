import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import "./ScreenDetailSalary.scss";
import ProductApi from "../../api/productApi";
import dateFormat from "dateformat";
import { ttc } from "./DataSalary";
import NumberFormat from "react-number-format";

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
  useEffect(() => {
    //Hàm đặt tên cho trang
    const titlePage = () => {
      if (dataLDetail.length !== 0)
        document.title = `Chi tiết lương hiện tại của nhân viên ${dataLDetail.tenNhanVien}`;
    };
    titlePage();
  }, [dataLDetail]);

  return (
    <>
      <div className="main-screen-salary">
        <div className="first-main-salary">
          <div className="first-path-salary">
            <button className="btn-back" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-salary">
            <h2>Chi tiết hồ sơ lương</h2>
          </div>
          <div className="third-path-salary">
            {dataLDetail.trangThai === "Kích hoạt" && (
              <Link to={`/salary/${id}`}>
                <Button variant="light" className="btn-fix-salary">
                  Sửa
                </Button>
              </Link>
            )}
            {dataLDetail.bangChung !== null && (
              <Button
                variant="light"
                className="btn-fix-salary"
                onClick={() => {
                  window.open(`https://localhost:5001${dataLDetail.bangChung}`);
                }}
              >
                <FontAwesomeIcon
                  className="icon-btn"
                  icon={["fas", "download"]}
                />
              </Button>
            )}
          </div>
        </div>
        <div className="second-mains-salary">
          <h3 className="title-main-salary">Thông tin chung</h3>
          <div className="second-main-path-salary">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataLDetail[detail.data1[0]] !== null ? (
                      dateFormat(dataLDetail[detail.data1[0]], "dd/mm/yyyy")
                    ) : detail.data1[2] === true &&
                      dataLDetail[detail.data1[0]] !== null ? (
                      <NumberFormat
                        value={dataLDetail[detail.data1[0]]}
                        displayType={"text"}
                        thousandSeparator={true}
                        suffix={" VND"}
                      />
                    ) : (
                      dataLDetail[detail.data1[0]]
                    )
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataLDetail[detail.data2[0]] !== null ? (
                      dateFormat(dataLDetail[detail.data2[0]], "dd/mm/yyyy")
                    ) : detail.data2[2] === true &&
                      dataLDetail[detail.data2[0]] !== null ? (
                      <NumberFormat
                        value={dataLDetail[detail.data2[0]]}
                        displayType={"text"}
                        thousandSeparator={true}
                        suffix={" VND"}
                      />
                    ) : (
                      dataLDetail[detail.data2[0]]
                    )
                  }
                />
              );
            })}
            <SubDetail
              titleLeft="Tệp đính kèm"
              itemLeft={dataLDetail.bangChung === null ? "Không" : "Có"}
              titleRight="Ghi chú"
              itemRight={dataLDetail.ghiChu}
            />
          </div>
        </div>
        <div className="all-salary">
          <div className="name-move-salary">
            <h3>Tất cả lương</h3>
          </div>
          <Link
            to={`/profile/detail/${dataLDetail.maNhanVien}?move=moveToSalary`}
            className="btn-move-salary"
          >
            <button className="btn-fix-salary">
              <FontAwesomeIcon
                icon={["fas", "arrow-right"]}
                style={{ fontSize: "50px" }}
              />
            </button>
          </Link>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailSalary;
