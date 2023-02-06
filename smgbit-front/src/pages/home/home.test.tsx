import '@inrupt/jest-jsdom-polyfills';
import '@testing-library/jest-dom';
import { render, screen } from '@testing-library/react';
import userEvent from '@testing-library/user-event';

import { BrowserRouter } from 'react-router-dom';
import Home from '.';
import api from '../../config/api';

it("Should contain a text 'Faça o upload do arquivo xls ou xlsx'", async () => {
  render(
    <BrowserRouter>
      <Home />
    </BrowserRouter>
  );

  const element = screen.getByText('Faça o upload do arquivo xls ou xlsx');

  expect(element).toBeInTheDocument();
});

it("Input should have type 'file'", async () => {
  render(
    <BrowserRouter>
      <Home />
    </BrowserRouter>
  );

  const element = screen.getByLabelText('Faça o upload do arquivo xls ou xlsx');
  expect(element).toHaveAttribute('type', 'file');
});

it("Should show error message when file selected not be of type 'xlsx' or 'xls'", async () => {
  render(
    <BrowserRouter>
      <Home />
    </BrowserRouter>
  );

  const testFile = new File(['hello'], 'hello.png', { type: 'image/png' });

  const element = screen.getByLabelText('Faça o upload do arquivo xls ou xlsx');

  await userEvent.upload(element, testFile);

  const errorMsg = screen.getByText('Apenas é permitido formato xlsx e xls');

  expect(errorMsg).toBeInTheDocument();
});

it('Button should be disabled when page rendered and background-color grey', () => {
  render(
    <BrowserRouter>
      <Home />
    </BrowserRouter>
  );

  const element = screen.getByText('Enviar');

  expect(element).toHaveStyle({ 'pointer-events': 'none' });
  expect(element).toHaveStyle({ 'background-color': 'grey' });
});

it('Should change button background color when correct file selected', async () => {
  render(
    <BrowserRouter>
      <Home />
    </BrowserRouter>
  );

  const testFile = new File(['hello'], 'hello.xlsx', {
    type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
  });

  const element = screen.getByLabelText('Faça o upload do arquivo xls ou xlsx');

  await userEvent.upload(element, testFile);

  const button = screen.getByText('Enviar');

  expect(button).toHaveStyle({ 'background-color': '#2196f3' });
});

it("When file selected is correct and click on button 'Enviar' should call api", async () => {
  const sendProcessFile = jest.spyOn(api, 'post').mockResolvedValue(() => {
    Promise.resolve({
      data: [],
    });
  });
  render(
    <BrowserRouter>
      <Home />
    </BrowserRouter>
  );

  const testFile = new File(['hello'], 'hello.xlsx', {
    type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet',
  });

  const element = screen.getByLabelText('Faça o upload do arquivo xls ou xlsx');

  await userEvent.upload(element, testFile);

  const button = screen.getByText('Enviar');

  await userEvent.click(button);

  expect(sendProcessFile).toBeCalled();
});
