import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailFamily.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataFamily";
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
            <Link to={`/profile/detail/family/update/${id}`}>
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
                  itemLeft={dataDetailNT[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNT[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNT[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNT[detail.data2[0]]
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

export default ScreenDetailFamily;
