import '@inrupt/jest-jsdom-polyfills';
import '@testing-library/jest-dom';
import { render, screen } from '@testing-library/react';
import React from 'react';
import { BrowserRouter } from 'react-router-dom';
import Travels from '.';
import api from '../../config/api';
import Travel from '../../models/travel';
jest.mock('../../config/api');

const mockedAxios = api as jest.Mocked<typeof api>;
const mockedData: Travel[] = [
  {
    caixasCarregagas: 90,
    dataViagem: new Date(),
    destino: 'Regiao 10',
    entregas: 100,
    id: 1,
    kmRodados: 10,
    motorista: 'JOAO VITOR',
    numeroViagem: 1000,
    origem: 'CDD São Paulo',
    placa: 'GDF-1U10',
    tabelaFrete: 'table_6',
    tipoVeiculo: 'TRUCK',
    tipoViagem: 'LastMile',
    valorViagem: 698,
  },
];
const mockedDataWithOutFrete: Travel[] = [
  {
    caixasCarregagas: 90,
    dataViagem: new Date(),
    destino: 'Regiao 10',
    entregas: 100,
    id: 1,
    kmRodados: 10,
    motorista: 'JOAO VITOR',
    numeroViagem: 1000,
    origem: 'CDD São Paulo',
    placa: 'GDF-1U10',

    tipoVeiculo: 'TRUCK',
    tipoViagem: 'LastMile',
  },
];

it('Should call api when page in loaded', async () => {
  const useEffectSpy = jest.spyOn(React, 'useEffect');
  const getAllTravelsSpy = jest
    .spyOn(api, 'get')
    .mockResolvedValue({ data: [] });
  render(
    <BrowserRouter>
      <Travels />
    </BrowserRouter>
  );
  expect(useEffectSpy).toBeCalled();
  expect(getAllTravelsSpy).toHaveBeenCalledWith('/travels');
});

it('Table should have 13 childrens', () => {
  render(
    <BrowserRouter>
      <Travels />
    </BrowserRouter>
  );
  const theadElement = screen.getByRole('row');
  expect(theadElement.children).toHaveLength(13);
});

it('Should contain data returned by api when page is loaded', async () => {
  mockedAxios.get.mockResolvedValue({ data: mockedData });
  render(
    <BrowserRouter>
      <Travels />
    </BrowserRouter>
  );
  await new Promise((resolve) => setTimeout(resolve, 600));

  expect(screen.getByText('90')).toBeInTheDocument();
  expect(screen.getByText('Regiao 10')).toBeInTheDocument();
  expect(screen.getByText('100')).toBeInTheDocument();
  expect(screen.getByText('JOAO VITOR')).toBeInTheDocument();
  expect(screen.getByText('1000')).toBeInTheDocument();
  expect(screen.getByText('CDD São Paulo')).toBeInTheDocument();
  expect(screen.getByText('GDF-1U10')).toBeInTheDocument();
  expect(screen.getByText('table_6')).toBeInTheDocument();
  expect(screen.getByText('TRUCK')).toBeInTheDocument();
  expect(screen.getByText('LastMile')).toBeInTheDocument();
  expect(screen.getByText('698')).toBeInTheDocument();
});

it("When value of 'tabelaFrete' and 'valorViagem' be null return show 'Valor não encontrado'", async () => {
  mockedAxios.get.mockResolvedValue({
    data: mockedDataWithOutFrete,
  });
  render(
    <BrowserRouter>
      <Travels />
    </BrowserRouter>
  );
  await new Promise((resolve) => setTimeout(resolve, 800));
  expect(await screen.findAllByText('Valor não encontrado')).toHaveLength(2);
});
