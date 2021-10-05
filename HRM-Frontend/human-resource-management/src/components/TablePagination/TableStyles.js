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
      padding: 15px;
      background-color: rgb(55, 58, 61);
      color: white;
      font-weight: bold;
    }

    .td {
      padding: 15px;
      border-bottom: 1px solid #ddd;
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

        box-shadow: 0px 3px 3px #ccc;
      }

      .bodyy {
        position: relative;
        z-index: 0;
      }

      [data-sticky-td] {
        position: sticky;
      }

      [data-sticky-last-left-td] {
        box-shadow: 2px 0px 3px #ccc;
      }

      [data-sticky-first-right-td] {
        box-shadow: -2px 0px 3px #ccc;
      }
    }
  }
`;
