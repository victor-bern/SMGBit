import { createGlobalStyle } from 'styled-components';

const GlobalStyle = createGlobalStyle`
  html,body, #root {
    margin: 0;
    height: 100%;
    padding: 0;
    background-color: #F2F2F2;
    @font-face {
      font-family: "Roboto";
      src: url("./fonts/Roboto-Regular.ttf") format("ttf");
    }
  }
`;

export default GlobalStyle;
