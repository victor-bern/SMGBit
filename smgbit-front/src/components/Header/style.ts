import { Link } from 'react-router-dom';
import styled from 'styled-components';

export const ContainerHeader = styled.div`
  background-color: #00b140;
  height: 10vh;
  width: 100%;
  display: flex;
  justify-content: flex-start;
  align-items: center;
  font-size: 32px;
  font-family: 'Roboto', sans-serif;
  color: white;
  h1 {
    margin-left: 16px;
  }
`;

export const Links = styled.div`
  display: flex;
  justify-content: space-around;
  margin-left: 15%;
  width: 250px;
  height: 100%;
  align-items: center;
`;

export const LinkText = styled(Link)`
  text-decoration: none;
  font-size: 26px;
  color: white;
  :hover {
    color: black;
  }
`;
