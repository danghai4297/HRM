import React, { useEffect, useState } from "react";
import SubDetail from "../../components/Detail/SubDetail";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { Button } from "react-bootstrap";
import "./ScreenDetailForeignLanguage.scss";
import ProductApi from "../../api/productApi";
import { Link } from "react-router-dom";
import dateFormat from "dateformat";
import { ttc } from "./DataForeignLanguage";
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
            {ttc.map((detail, key) => {
              return (
                <SubDetail
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNN[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNN[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNN[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNN[detail.data2[0]]
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

export default ScreenDetailForeignLanguage;
