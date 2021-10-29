import styled from "styled-components";

export const Styles = styled.div`
  .tablee {
    border: 1px solid #ddd;

    .tr {
      :last-child {
        .td {
          border-bottom: 0;
        }
      }
    }

    .th {
      display: flex !important;
      padding: 15px;
      background-color: rgb(55, 58, 61);
      color: white;
      font-weight: bold;
    }

    .td {
      padding: 15px;
      background-color: #fff;
      overflow: hidden;

      :last-child {
        border-right: 0;
      }
    }

    &.sticky {
      overflow: scroll;
      .headerr,
      .footer {
        position: sticky;
        z-index: 1;
        width: fit-content;
      }

      .headerr {
        top: 0;
      }

      .bodyy {
        position: relative;
        z-index: 0;
      }

      [data-sticky-td] {
        position: sticky;
      }

      [data-sticky-last-left-td] {
        border-right: 1px solid rgb(216, 216, 216);
      }

      [data-sticky-first-right-td] {
        border-right: 1px solid rgb(216, 216, 216);
      }
    }
  }
`;
