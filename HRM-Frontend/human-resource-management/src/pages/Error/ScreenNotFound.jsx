import React from "react";
import { useDocumentTitle } from "../../hook/useDocumentTitle/TitleDocument";
import "./ScreenNotFound.scss";
function ScreenNotFound() {
  useDocumentTitle("404 Not Found");
  return (
    <div id="notfound">
      <div class="notfound">
        <div class="notfound-404">
          <h3>Không tìm thấy trang</h3>
          <h1>
            <span>4</span>
            <span>0</span>
            <span>4</span>
          </h1>
        </div>
        <h2>Xin lỗi nhưng trang bạn tìm kiếm không có</h2>
      </div>
    </div>
  );
}

export default ScreenNotFound;
