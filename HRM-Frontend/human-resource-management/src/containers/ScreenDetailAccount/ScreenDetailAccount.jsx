import React, { useEffect, useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailAccount.scss";
import SubDetail from "../../components/Detail/SubDetail";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataAccount";
import LoginApi from "../../api/login";
function ScreenDetailAccount(props) {
  let { match, history } = props;
  let { id } = match.params;
  console.log(id);

  const [dataDetailTk, setdataDetailTk] = useState([]);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseKT = await LoginApi.getTkDetail(id);
        setdataDetailTk(responseKT);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  console.log(dataDetailTk);
  // console.log(dataDetailTk.resultObj.roles);
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
            <h2>Chi tiết tài khoản</h2>
          </div>
          <div className="third-path">
            <Link to={`/account/${id}`}>
              <Button variant="light" className="btn-fix">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main">
          <h3 className="title-main">Thông tin chung</h3>
          <div className="second-main-path">
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailTk[detail.data1[0]] !== null
                      ? dateFormat(dataDetailTk[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailTk[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    dataDetailTk[
                      detail.data2 === [] ? detail.data2[0] : detail.data2
                    ]
                  }
                />
              );
            })}
          </div>
        </div>
      </div>
    </>
  );
}

export default ScreenDetailAccount;
