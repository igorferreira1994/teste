using System.Drawing;
using TesteB3.Server.Domain.Interface;
using TesteB3.Server.Domain.Model;

namespace TesteB3.Server.Domain.Service
{
    public class TituloService : ITituloService
    {
        private readonly decimal TB = 108;
        private readonly decimal CDI = 0.9M;
        public TituloParametrosModel GetTituloParametros()
        {
            TituloParametrosModel model = new TituloParametrosModel();
            model.CDI = CDI.ToString();
            model.TB = TB.ToString();

            return model;
        }

        public TituloModel GerarCalculo(TituloModel titulo)
        {            
                if (titulo.valor <= 0)
                    throw new Exception("Valor tem que ser maior que 0");

                if (titulo.prazo <= 0)
                    throw new Exception("Prazo tem que ser maior que 0");

                decimal valor = titulo.valor;
                decimal valorBruto = 0;
                for (int i = 0; i < titulo.prazo; i++)
                {
                    valorBruto = (valor * (1 + ((TB / 100) * CDI) / 100));
                    valor = valorBruto;
                }

                valor = CalcularImpostos(titulo.valor, valorBruto, titulo.prazo);

                titulo.totalLiquido = Math.Round(valor, 2).ToString();
                titulo.totalBruto = Math.Round(valorBruto, 2).ToString();
                return titulo; 
        }

        public decimal CalcularImpostos(decimal tituloValor, decimal valorBruto, int prazo)
        {
            decimal lucro = valorBruto - tituloValor;

            if (prazo <= 6)
                lucro = lucro * 0.775M;
            else if (prazo <= 12)
                lucro = lucro * 0.8M;
            else if (prazo <= 24)
                lucro = lucro * 0.825M;
            else
                lucro = lucro * 0.85M;

            return tituloValor + lucro;
        }
    }
}
