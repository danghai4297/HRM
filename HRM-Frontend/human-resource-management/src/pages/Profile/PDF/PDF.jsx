import React, { useEffect, useRef, useState } from "react";
import ProductApi from "../../../api/productApi";
import Button from "@mui/material/Button";
import IconButton from "@mui/material/IconButton";
import { createTheme } from "@mui/material/styles";
import { red } from "@mui/material/colors";
import {
  cmndTccHC,
  lhkc,
  sdtEK,
  ttbh,
  ttc,
  ttct,
  ttnv,
  ttqs,
  ttyt,
} from "../Detail/Data";
import dateFormat from "dateformat";
import { useReactToPrint } from "react-to-print";
import { ComponentToPrint } from "../../../components/ToPrint/ComponentToPrint";
import "./PDF.scss";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import SubDetail2 from "../../../components/SubDetail/SubDetail2";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";
import jwt_decode from "jwt-decode";

function PDF(props) {
  let { match, history } = props;
  let { id } = match.params;
  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const theme = createTheme({
    palette: {
      primary: {
        main: red[500],
      },
      secondary: {
        main: "#f44336",
      },
    },
  });

  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });
  const printPdf = async () => {
    handlePrint();
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tải về hồ sơ nhân viên`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  useDocumentTitle("Tải về hồ sơ nhân viên");

  const [dataDetailNv, setdataDetailNv] = useState([]);
  const [dataAllNv, setdataAllNv] = useState([]);
  const [removeItem, setRemoveItem] = useState(true);
  const [changeItem, setChangeItem] = useState();

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const responseNv = await ProductApi.getNvDetail(id);
        setdataDetailNv(responseNv);
        const responseAllNv = await ProductApi.getAllNv();
        setdataAllNv(responseAllNv);
      } catch (error) {
        history.goBack();
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  const chooseItem = async (newId) => {
    try {
      setChangeItem(newId);
      const newResponse = await ProductApi.getNvDetail(newId);
      history.replace(`/profile/pdf/${newId}`);
      setdataDetailNv(newResponse);
    } catch (error) {}
  };

  useEffect(() => {
    setRemoveItem(false);
  }, [changeItem]);

  return (
    <>
      <div>
        <IconButton className="btn-back" onClick={history.goBack}>
          <FontAwesomeIcon
            className="icon-btn"
            icon={["fas", "long-arrow-alt-left"]}
          />
        </IconButton>
        <Button
          variant="contained"
          theme={theme}
          className="button-pdf"
          size="small"
          onClick={printPdf}
          endIcon={<FontAwesomeIcon icon={["fas", "file-pdf"]} />}
        >
          Tải
        </Button>
        <select
          className="form-control col-sm-6 custom-select"
          onChange={(e) => chooseItem(e.target.value)}
        >
          {removeItem && (
            <option value={dataDetailNv.id}>{dataDetailNv.hoTen}</option>
          )}

          {dataAllNv.map((items, key) => (
            <option key={key} value={items.id}>
              {items.hoTen}
            </option>
          ))}
        </select>
      </div>

      <div className="right-information-pdf" id="right">
        <ComponentToPrint ref={componentRef}>
          <div>
            <div className="avatar">
              <div className="icon-second">
                <img src={`http://localhost:8000/${dataDetailNv.anh}`} alt="" />
              </div>
              <div className="names">
                <h5>{dataDetailNv.hoTen}</h5>
              </div>
              <div className="codes">
                <p>{dataDetailNv.id}</p>
              </div>
            </div>
          </div>
          <div className="form" id="base">
            <div className="big-title">
              <div className="name-title">
                <h3>Thông tin cơ bản</h3>
              </div>
            </div>
            <div className="title">
              <h5>Thông tin chung</h5>
            </div>
            {ttc.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailNv[detail.data1[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNv[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data2[0]]
                  }
                />
              );
            })}
            <div className="title">
              <h5>CMND/Thẻ căn cước/Hộ chiếu</h5>
            </div>
            {cmndTccHC.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailNv[detail.data1[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNv[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data2[0]]
                  }
                />
              );
            })}
          </div>

          <div className="form" id="contact">
            <div className="big-title">
              <div className="name-title">
                <h3>Thông tin liên hệ</h3>
              </div>
            </div>
            <div className="title">
              <h5>Số điện thoại/Email/Khác</h5>
            </div>
            {sdtEK.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNv[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={dataDetailNv[detail.data2]}
                />
              );
            })}
            <div className="title">
              <h5>Liên hệ khẩn cấp</h5>
            </div>
            {lhkc.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNv[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={dataDetailNv[detail.data2]}
                />
              );
            })}
          </div>
          <div className="form" id="job">
            <div className="big-title">
              <div className="name-title">
                <h3>Thông tin công việc</h3>
              </div>
            </div>
            <div className="title">
              <h5>Thông tin nhân viên</h5>
            </div>
            {ttnv.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNv[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNv[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data2[0]]
                  }
                />
              );
            })}
          </div>
          <div className="form" id="insurance">
            <div className="big-title">
              <div className="name-title">
                <h3>Thông tin bảo hiểm</h3>
              </div>
            </div>
            {ttbh.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNv[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={dataDetailNv[detail.data2]}
                />
              );
            })}
          </div>

          <div className="form" id="politics">
            <div className="big-title">
              <div className="name-title">
                <h3>Thông tin chính trị, quân sự, y tế</h3>
              </div>
            </div>
            <div className="title">
              <h5>Thông tin chính trị</h5>
            </div>
            {ttct.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailNv[detail.data1[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={
                    detail.data2[1] === true &&
                    dataDetailNv[detail.data2[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data2[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data2[0]]
                  }
                />
              );
            })}
            <div className="title">
              <h5>Thông tin quân sự</h5>
            </div>
            {ttqs.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={
                    detail.data1[1] === true &&
                    dataDetailNv[detail.data1[0]] !== null
                      ? dateFormat(dataDetailNv[detail.data1[0]], "dd/mm/yyyy")
                      : dataDetailNv[detail.data1[0]]
                  }
                  titleRight={detail.title2}
                  itemRight={dataDetailNv[detail.data2]}
                />
              );
            })}
            <div className="title">
              <h5>Thông tin y tế</h5>
            </div>
            {ttyt.map((detail, key) => {
              return (
                <SubDetail2
                  key={key}
                  titleLeft={detail.title1}
                  itemLeft={dataDetailNv[detail.data1]}
                  titleRight={detail.title2}
                  itemRight={dataDetailNv[detail.data2]}
                />
              );
            })}
          </div>
          <div className="form" id="history">
            <div className="big-title">
              <div className="name-title">
                <h3>Lịch sử bản thân</h3>
              </div>
            </div>
            <div className="titles">
              <div className="title-history">
                <h5 className="title-names">
                  Bị bắt, bị tù (thời gian và địa điểm), khai báo cho ai, những
                  vấn đề gì?
                </h5>
              </div>
            </div>
            <div className="areas">
              <p className="area-history">{dataDetailNv.biBatDitu}</p>
            </div>
            <div className="titles">
              <div className="title-history">
                <h5 className="title-names">
                  Tham gia hoặc có quan hệ với các tổ chức chính trị, kinh tế,
                  xã hội ở nước ngoài
                </h5>
              </div>
            </div>
            <div className="areas">
              <p className="area-history">{dataDetailNv.thamGiaChinhTri}</p>
            </div>
            <div className="titles">
              <div className="title-history">
                <h5 className="title-names">
                  Có Thân nhân(cha, mẹ, vợ, chồng, con, anh chị em ruột) ở nước
                  ngoài (làm gì, địa chỉ...)?
                </h5>
              </div>
            </div>
            <div className="areas">
              <p className="area-history">{dataDetailNv.thanNhanNuocNgoai}</p>
            </div>
          </div>
        </ComponentToPrint>
      </div>
    </>
  );
}

export default PDF;
