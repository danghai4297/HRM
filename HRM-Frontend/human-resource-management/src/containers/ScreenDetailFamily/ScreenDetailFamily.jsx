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

  return (
    <>
      <div className="main-screen-family">
        <div className="first-main-family">
          <div className="first-path-family">
            <button className="btn-back-family" onClick={history.goBack}>
              <FontAwesomeIcon
                className="icon-btn"
                icon={["fas", "long-arrow-alt-left"]}
              />
            </button>
          </div>
          <div className="second-path-family">
            <h2>Thông tin gia đình</h2>
          </div>
          <div className="third-path-family">
            <Link to={`/profile/detail/family/update/${id}`}>
              <Button variant="light" className="btn-fix-family">
                Sửa
              </Button>
            </Link>
          </div>
        </div>
        <div className="second-main-family">
          <h3 className="title-main-family">Thông tin chung</h3>
          <div className="second-main-path-family">
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
