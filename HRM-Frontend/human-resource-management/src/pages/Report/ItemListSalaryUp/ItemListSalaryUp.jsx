import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { DatePicker } from "antd";
import { format } from "date-fns";
import React, { useEffect, useRef, useState } from "react";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../api/productApi";
import { useToast } from "../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../components/ToPrint/ComponentToPrint";
import useDidMountEffect from "../../../hook/useDidMountEffect/useDidMountEffect";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import jwt_decode from "jwt-decode";
import ListItemSalaryup from "./ListItemSalaryup";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

function ItemListSalaryUp() {
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const { error, warn, info, success } = useToast();

  useDocumentTitle("Báo cáo danh sách nâng lương");

  const [title, settitle] = useState("");

  const [dataDmpb, setDataDmpb] = useState([]);
  const [startDate, setStartDate] = useState(null);
  const [endDate, setEndDate] = useState(null);
  const [department, setDepartment] = useState("Tất cả");
  const [check, setCheck] = useState("Tất cả");
  const [checkPb, setCheckPb] = useState(false);
  const [dataRpSalaryUp, setDataRpSalaryUp] = useState([]);

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const handleClick = async () => {
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tải về file báo cáo nhân viên lên lương`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  const handleClickPdf = async () => {
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tạo file báo cáo nhân viên lên lương`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMPB();
        setDataDmpb(response);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };
    fetchNvList();
  }, []);

  useDidMountEffect(() => {
    if (dataRpSalaryUp.length == 0) {
      info("không có thông tin");
    }
  }, [dataRpSalaryUp]);

  function handelCheck(value) {
    if (value === "Tất cả") {
      setCheck("Tất cả");
      setCheckPb(false);
    } else if (value === "Phòng ban") {
      setCheck("Phòng ban");
      setCheckPb(true);
    }
  }

  const handelReport = async () => {
    if (check === "Tất cả") {
      try {
        if ((startDate === null) & (endDate === null)) {
          warn("Bạn chọn ngày hoặc chọn theo phòng ban");
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if ((startDate !== null) & (endDate !== null)) {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respbSalaryUp = await ProductApi.getRpAllLg(sdate, edate);
          setDataRpSalaryUp(respbSalaryUp);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (check === "Phòng ban") {
      try {
        if ((startDate === null) & (endDate === null)) {
          warn("Bạn chưa chọn ngày");
        } else if (
          (startDate !== null) & (endDate === null) ||
          (startDate === null) & (endDate !== null)
        ) {
          error("Bạn mới chọn 1 ngày");
        } else if (
          (startDate !== null) &
          (endDate !== null) &
          (department === "Tất cả")
        ) {
          error("Bạn chưa chọn phòng ban hoặc bạn hãy chọn theo tất cả");
        } else if ((startDate !== null) & (endDate !== null)) {
          let sdate = format(new Date(startDate), "yyyy-MM-dd");
          let edate = format(new Date(endDate), "yyyy-MM-dd");
          const respbSalaryUp = await ProductApi.getRpAllLgPb(
            department,
            sdate,
            edate
          );
          setDataRpSalaryUp(respbSalaryUp);
        }
      } catch (e) {
        error("Thực hiện không thành công");
      }
    }
  };

  return (
    <div className="reportEx">
      <div className="select-info">
        <div className="roww">
          <input
            type="text"
            placeholder="Nhập tiêu đề cho báo cáo"
            class="form-control"
            id="title"
            onChange={(e) => settitle(e.target.value)}
          />
        </div>
        <div className="roww">
          <div className="select-row2">
            <label>Theo</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => handelCheck(e.target.value)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value="Phòng ban">Phòng ban</option>
              </select>
            </div>
          </div>

          <div className="select-row2">
            <label>Phòng ban</label>
            <div>
              <select
                className="form-control"
                onChange={(e) => setDepartment(e.target.value)}
                disabled={checkPb === false}
              >
                <option value="Tất cả">Tất cả</option>
                {dataDmpb.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.tenPhongBan}{" "}
                  </option>
                ))}
              </select>
            </div>
          </div>
        </div>
        <div className="roww">
          <div className="select-row2">
            <label>Từ ngày</label>
            <div>
              <DatePicker
                placeholder="DD/MM/YYYY"
                selected={startDate}
                onChange={(date) => setStartDate(date)}
              />
            </div>
          </div>
          <div className="select-row2">
            <label>Đến ngày</label>
            <div>
              <DatePicker
                placeholder="DD/MM/YYYY"
                selected={endDate}
                onChange={(date) => setEndDate(date)}
              />
            </div>
          </div>
        </div>
        <div className="roww row-btn">
          <input
            className="btn btn-primary"
            type="button"
            value="Hiển thị báo cáo"
            onClick={handelReport}
          />
          <div onClick={(e) => handleClickPdf()}>
            <button className="pdfx" onClick={handlePrint}>
              <FontAwesomeIcon icon={["fas", "file-pdf"]} />
            </button>
          </div>
          <div onClick={(e) => handleClick()}>
            <ReactHTMLTableToExcel
              id="test-table-xls-button"
              className="download-table-xls-button"
              table="tableSalaryUp"
              filename="Danh sach nhan vien lên lương"
              sheet="tablexls"
              buttonText={<FontAwesomeIcon icon={["fas", "file-excel"]} />}
            />
          </div>
        </div>
      </div>
      <div className="report-emp">
        <ComponentToPrint ref={componentRef}>
          <div className="rp-herder">
            <b>HRM</b>
            <p>-------------------------</p>
            <h2>{title}</h2>
          </div>
          <div className="rp-herder-left">
            <h5>Phòng ban: {department}</h5>
            <h6>
              Hà Nội Ngày: {today.getDate()} Tháng: {today.getMonth() + 1} Năm:{" "}
              {today.getFullYear()}
            </h6>
          </div>
          <div className="rp-table">
            <table className="table table-bordered" id="tableSalaryUp">
              <thead>
                <tr>
                  <th scope="col">Mã Nhân Viên</th>
                  <th scope="col">Họ Tên</th>
                  <th scope="col">Mã hợp đồng</th>
                  <th scope="col">Tên hợp đồng</th>
                  <th scope="col">Lương cơ bản</th>
                  <th scope="col">Tổng lương</th>
                  <th scope="col">Thời gian lên lương</th>
                  <th scope="col">Tên phòng ban</th>
                </tr>
              </thead>
              <tbody>
                {dataRpSalaryUp.map((item) => (
                  <ListItemSalaryup user={item} key={item.id} />
                ))}
              </tbody>
            </table>
          </div>
        </ComponentToPrint>
      </div>
    </div>
  );
}

export default ItemListSalaryUp;
