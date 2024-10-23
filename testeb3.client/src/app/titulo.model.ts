export class TituloModel {
  public valor: number;
  public prazo: number;
  public totalBruto: string;
  public totalLiquido: string;

  constructor() {
    this.prazo = 0;
    this.valor = 0;
    this.totalBruto = "0.00";
    this.totalLiquido = "0.00";
  }
      
}
