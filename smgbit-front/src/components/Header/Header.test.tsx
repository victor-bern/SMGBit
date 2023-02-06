import {fireEvent, render, screen,  } from '@testing-library/react';
import { BrowserRouter } from 'react-router-dom';
import React from 'react';
import Header from '.';
import "jest-styled-components";

it('HeaderContainer should have #00b140 as background color when rendered', async () => {
  render(
    <BrowserRouter>
      <Header />
    </BrowserRouter>
  );
  var container = await screen.findByTestId('container-header');

  expect(container).toHaveStyle({"background-color": "#00b140"});
});


it("HeaderContainer should have two childrens when rendered", async () => {
  render(
    <BrowserRouter>
      <Header />
    </BrowserRouter>
  );
  var container = await screen.findByTestId('container-header');

  expect(container.children).toHaveLength(2);
});

it("should have a text with 'SMGBit Transportes on render'", async () => {
  render(
    <BrowserRouter>
      <Header />
    </BrowserRouter>
  );

  var text = await screen.findByText("SMGBit Transportes");

  expect(text).toBeInTheDocument();
})


it("should have button with 'Upload' text",async () => {
  render(
    <BrowserRouter>
      <Header />
    </BrowserRouter>
  );

  var text = await screen.findByText("Upload");

  expect(text).toBeInTheDocument();
})

it("should have button with 'Viagens' text",async () => {
  render(
    <BrowserRouter>
      <Header />
    </BrowserRouter>
  );

  var text = await screen.findByText("Viagens");

  expect(text).toBeInTheDocument();
});

it("when mouse hover link text should change your color to black", async () => {
  render(
    <BrowserRouter>
      <Header />
    </BrowserRouter>
  );

  var text = await screen.findByText("Viagens");

  expect(text).toHaveStyleRule("color", "white");

  expect(text).toHaveStyleRule("color", "black", {
    modifier: ":hover"
  });
})

it("Should redirect to travels page page when click on link", async () => {

  render(
    <BrowserRouter >
      <Header />
    </BrowserRouter>
  );

  var text = await screen.findByText("Viagens");
  fireEvent.click(text);

  expect(window.location.pathname).toBe("/travels");
})

it("Should redirect to home page page when click on Upload", async () => {
  window.location.pathname = "/travels"
  render(
    <BrowserRouter >
      <Header />
    </BrowserRouter>
  );
  var text = await screen.findByText("Upload");
  fireEvent.click(text);

  expect(window.location.pathname).toBe("/");
})