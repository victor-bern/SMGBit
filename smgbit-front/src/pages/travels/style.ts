import styled from 'styled-components';

export const Container = styled.div`
  display: flex;
  min-height: 100%;
  width: 100%;
  flex-direction: column;
  align-items: center;
  font-family: 'Roboto', sans-serif;
`;

export const Table = styled.table`
  margin-top: 120px;
  margin-bottom: 120px;
  min-width: 800px;
  border-collapse: collapse;
  overflow: hidden;
  box-shadow: 0 0 20px rgba(0, 0, 0, 0.1);
  th,
  td {
    padding: 15px;
    background-color: rgba(255, 255, 255, 0.2);
    color: #fff;
  }

  th {
    text-align: left;
  }
`;

export const TableHead = styled.thead`
  th {
    background-color: #55608f;
  }
`;

export const TableBody = styled.tbody`
  tr {
    &:hover {
      background-color: rgba(255, 255, 255, 0.3);
    }
  }
  td {
    color: black;
    position: relative;
    &:hover {
      &:before {
        content: '';
        position: absolute;
        left: 0;
        right: 0;
        top: -9999px;
        bottom: -9999px;
        background-color: rgba(255, 255, 255, 0.2);
        z-index: -1;
      }
    }
  }
`;
