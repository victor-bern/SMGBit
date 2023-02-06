import { useEffect, useState } from 'react';
import api from '../../config/api';
import Travel from '../../models/travel';
import { Container, Table, TableBody, TableHead } from './style';

const Travels: React.FC = () => {
  const [travels, setTravels] = useState<Travel[]>([]);

  useEffect(() => {
    const fetchTravels = async () => {
      const response = await api.get<Travel[]>('/travels');
      setTravels(response.data);
    };
    fetchTravels();
  }, []);

  const formateDate = (date: Date) => {
    var formatedDate = new Date(date).toLocaleDateString('pt-br');
    return formatedDate;
  };

  return (
    <Container>
      <Table>
        <TableHead>
          <tr>
            <th>Data da Viagem</th>
            <th>Número da Viagem</th>
            <th>Motorista</th>
            <th>Placa</th>
            <th>Tipo do Veiculo</th>
            <th>Origem</th>
            <th>Destino</th>
            <th>Caixas Carregadas</th>
            <th>Entregas</th>
            <th>Km Rodados</th>
            <th>Tipo da Viagem</th>
            <th>Tabela de Frete</th>
            <th>Valor da Viagem</th>
          </tr>
        </TableHead>
        <TableBody data-testid='table-body'>
          {travels.map((travel, index) => {
            return (
              <tr tabIndex={index} key={travel.id}>
                <td>{formateDate(travel.dataViagem)}</td>
                <td>{travel.numeroViagem}</td>
                <td>{travel.motorista}</td>
                <td>{travel.placa}</td>
                <td>{travel.tipoVeiculo}</td>
                <td>{travel.origem}</td>
                <td>{travel.destino}</td>
                <td>{travel.caixasCarregagas}</td>
                <td>{travel.entregas}</td>
                <td>{travel.kmRodados}</td>
                <td>{travel.tipoViagem}</td>
                <td>
                  {travel.tabelaFrete
                    ? travel.tabelaFrete
                    : 'Valor não encontrado'}
                </td>
                <td>
                  {travel.valorViagem
                    ? travel.valorViagem
                    : 'Valor não encontrado'}
                </td>
              </tr>
            );
          })}
        </TableBody>
      </Table>
    </Container>
  );
};

export default Travels;
