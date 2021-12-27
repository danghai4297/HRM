import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import React, { useEffect, useRef, useState } from "react";
import { useReactToPrint } from "react-to-print";
import ProductApi from "../../../api/productApi";
import { useToast } from "../../../components/Toast/Toast";
import { ComponentToPrint } from "../../../components/ToPrint/ComponentToPrint";
import useDidMountEffect from "../../../hook/useDidMountEffect/useDidMountEffect";
import ReactHTMLTableToExcel from "react-html-table-to-excel";
import jwt_decode from "jwt-decode";
import ListItems from "./ListItem";
import { useDocumentTitle } from "../../../hook/useDocumentTitle/TitleDocument";

function ItemListFamily() {
  useDocumentTitle("Báo cáo danh sách người thân");
  var today = new Date();
  const componentRef = useRef();
  const handlePrint = useReactToPrint({
    content: () => componentRef.current,
  });

  const token = sessionStorage.getItem("resultObj");
  const decoded = jwt_decode(token);
  const handleClick = async () => {
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tải về file báo cáo gia đình nhân viên`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  const handleClickPdf = async () => {
    await ProductApi.PostLS({
      tenTaiKhoan: decoded.userName,
      thaoTac: `Tạo file báo cáo gia đình nhân viên`,
      maNhanVien: decoded.id,
      tenNhanVien: decoded.givenName,
    });
  };

  const { error, info } = useToast();

  const [title, settitle] = useState("");

  const [dataDmpb, setDataDmpb] = useState([]);
  const [dataDmnt, setDataDmnt] = useState([]);
  const [dataNv, setDataNv] = useState([]);
  const [idNv, setIdNv] = useState("Tất cả");
  const [ageX, setAgeX] = useState(0);
  const [ageY, setAgeY] = useState(100);
  const [gender, setGender] = useState("Tất cả");
  const [status, setStatus] = useState("Tất cả");
  const [department, setDepartment] = useState("Tất cả");
  const [nexus, setNexus] = useState(0);
  const [dataRp, setDataRp] = useState([]);

  const [checkNt, setCheckNt] = useState(true);
  const [checkGender, setCheckGender] = useState(true);
  const [checkNv, setCheckNv] = useState(true);

  useEffect(() => {
    const fetchNvList = async () => {
      try {
        const response = await ProductApi.getAllDMPB();
        const responseNn = await ProductApi.getAllDMNT();
        const responseNv = await ProductApi.getAllNvMT();

        setDataDmpb(response);
        setDataDmnt(responseNn);
        setDataNv(responseNv);
      } catch (error) {
        console.log("false to fetch nv list: ", error);
      }
    };

    fetchNvList();
  }, []);

  const onChangeNt = (e) => {
    setNexus(e.target.value);
    if (e.target.value == 0) {
      setCheckGender(true);
    } else {
      setCheckGender(false);
    }
  };

  const onChangeGender = (e) => {
    setGender(e.target.value);
    if (e.target.value === "Tất cả") {
      setCheckNt(true);
    } else {
      setCheckNt(false);
    }
  };

  const onChangeNv = (e) => {
    setIdNv(e.target.value);
    if (e.target.value === "Tất cả") {
      setCheckNv(true);
    } else {
      setCheckNv(false);
    }
  };

  const onChangeStatus = async (e) => {
    setStatus(e.target.value);
    if ((e.target.value === "Tất cả") & (department === "Tất cả")) {
      const responseNv = await ProductApi.getAllNvMT();
      setDataNv(responseNv);
    } else if ((e.target.value === "Tất cả") & (department !== "Tất cả")) {
      const responseNv = await ProductApi.getRPPb(department);
      setDataNv(responseNv);
    } else if ((e.target.value !== "Tất cả") & (department === "Tất cả")) {
      const responseNv = await ProductApi.getRpAllTt(e.target.value);
      setDataNv(responseNv);
    } else if ((e.target.value !== "Tất cả") & (department !== "Tất cả")) {
      const responseNv = await ProductApi.getRPPbTt(department, e.target.value);
      setDataNv(responseNv);
    }
  };

  const onChangeDepartment = async (e) => {
    setDepartment(e.target.value);
    if ((e.target.value === "Tất cả") & (status === "Tất cả")) {
      const responseNv = await ProductApi.getAllNvMT();
      setDataNv(responseNv);
    } else if ((e.target.value === "Tất cả") & (status !== "Tất cả")) {
      const responseNv = await ProductApi.getRpAllTt(status);
      setDataNv(responseNv);
    } else if ((e.target.value !== "Tất cả") & (status === "Tất cả")) {
      const responseNv = await ProductApi.getRPPb(e.target.value);
      setDataNv(responseNv);
    } else if ((e.target.value !== "Tất cả") & (status !== "Tất cả")) {
      const responseNv = await ProductApi.getRPPbTt(e.target.value, status);
      setDataNv(responseNv);
    }
  };

  const handelReport = async () => {
    if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtn(ageX, ageY);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus != 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtDm(ageX, ageY, nexus);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtPb(ageX, ageY, department);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if ((nexus == 0) & (idNv !== "Tất cả") & (gender === "Tất cả")) {
      try {
        const resp = await ProductApi.getRpAllNtNv(ageX, ageY, idNv);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender !== "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtGt(ageX, ageY, gender);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status !== "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtTt(ageX, ageY, status);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus != 0) &
      (status === "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtDmPb(
          ageX,
          ageY,
          nexus,
          department
        );
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if ((nexus != 0) & (idNv !== "Tất cả") & (gender === "Tất cả")) {
      try {
        const resp = await ProductApi.getRpAllNtDmNv(ageX, ageY, nexus, idNv);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus != 0) &
      (status !== "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtDmTt(ageX, ageY, nexus, status);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status === "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender !== "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtPbGt(
          ageX,
          ageY,
          department,
          gender
        );
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if ((nexus == 0) & (idNv !== "Tất cả") & (gender !== "Tất cả")) {
      try {
        const resp = await ProductApi.getRpAllNtNvGt(ageX, ageY, idNv, gender);
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status !== "Tất cả") &
      (department === "Tất cả") &
      (idNv === "Tất cả") &
      (gender !== "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtGtTt(
          ageX,
          ageY,
          gender,
          status
        );
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus != 0) &
      (status === "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender !== "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtDmPbGt(
          ageX,
          ageY,
          nexus,
          department,
          gender
        );
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus != 0) &
      (status !== "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender === "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtDmPbTt(
          ageX,
          ageY,
          nexus,
          department,
          status
        );
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    } else if (
      (nexus == 0) &
      (status !== "Tất cả") &
      (department !== "Tất cả") &
      (idNv === "Tất cả") &
      (gender !== "Tất cả")
    ) {
      try {
        const resp = await ProductApi.getRpAllNtPbGtTt(
          ageX,
          ageY,
          department,
          gender,
          status
        );
        setDataRp(resp);
      } catch (e) {
        error("Thực hiện không thành công");
      }
    }
  };

  useDidMountEffect(() => {
    if (dataRp.length == 0) {
      info("không có thông tin");
    }
  }, [dataRp]);

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
            <label>Người thân</label>
            <div>
              <select
                className="form-control"
                disabled={checkNt === false}
                onChange={(e) => onChangeNt(e)}
              >
                <option value={0}>Tất cả</option>
                {dataDmnt.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.tenDanhMuc}{" "}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Trạng thái</label>
            <div>
              <select
                className="form-control"
                disabled={checkNv === false}
                onChange={(e) => onChangeStatus(e)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value={true}>Đang làm việc</option>
                <option value={false}>Đã nghỉ việc</option>
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Phòng ban</label>
            <div>
              <select
                className="form-control"
                disabled={checkNv === false}
                onChange={(e) => onChangeDepartment(e)}
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
            <label>Tên nhân viên</label>
            <div>
              <select
                className="form-control selectpicker"
                onChange={(e) => onChangeNv(e)}
              >
                <option value="Tất cả">Tất cả</option>
                {dataNv.map((item, key) => (
                  <option key={key} value={item.id}>
                    {item.hoTen}{" "}
                  </option>
                ))}
              </select>
            </div>
          </div>
          <div className="select-row2">
            <label>Mã nhân viên</label>
            <div>
              <input type="text" class="form-control" value={idNv} />
            </div>
          </div>
          <div className="select-row2">
            <label>Giới tính</label>
            <div>
              <select
                className="form-control"
                disabled={checkGender === false}
                onChange={(e) => onChangeGender(e)}
              >
                <option value="Tất cả">Tất cả</option>
                <option value={true}>Nam</option>
                <option value={false}>Nữ</option>
              </select>
            </div>
          </div>
        </div>
        <div className="roww">
          <div className="select-row2">
            <label>Tuổi từ</label>
            <input
              type="number"
              min="0"
              onChange={(e) => setAgeX(e.target.value)}
              defaultValue={0}
            ></input>
          </div>
          <div className="select-row2">
            <label>Đến</label>
            <input
              type="number"
              min="0"
              onChange={(e) => setAgeY(e.target.value)}
              defaultValue={100}
            ></input>
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
              table="tableFamily"
              filename="Danh sach gia dinh nhan vien"
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
            <h6>
              Hà Nội Ngày: {today.getDate()} Tháng: {today.getMonth() + 1} Năm:{" "}
              {today.getFullYear()}
            </h6>
          </div>
          <div className="rp-table">
            <table className="table table-bordered" id="tableFamily">
              <thead>
                <tr>
                  <th scope="col">Mã Nhân Viên</th>
                  <th scope="col">Họ Tên</th>
                  <th scope="col">Điện thoại</th>
                  <th scope="col">Phòng ban</th>
                  <th scope="col">Tên người thân</th>
                  <th scope="col">Giới tính</th>
                  <th scope="col">Ngày sinh</th>
                  <th scope="col">Quan hệ</th>
                  <th scope="col">Nghề ngiệp</th>
                  <th scope="col">Địa chỉ</th>
                  <th scope="col">Đt người thân</th>
                </tr>
              </thead>
              <tbody>
                {dataRp.map((item, index) => (
                  <ListItems user={item} key={index} />
                ))}
              </tbody>
            </table>
          </div>
        </ComponentToPrint>
      </div>
    </div>
  );
}

export default ItemListFamily;
