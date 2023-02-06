export default interface Travel {
  id: number;
  dataViagem: Date;
  numeroViagem: number;
  motorista: string;
  placa: string;
  tipoVeiculo: string;
  origem: string;
  destino: string;
  caixasCarregagas: number;
  entregas: number;
  kmRodados: number;
  tipoViagem: string;
  tabelaFrete?: string;
  valorViagem?: number;
}
