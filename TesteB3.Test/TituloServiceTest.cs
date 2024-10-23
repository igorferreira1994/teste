using TesteB3.Server.Domain.Interface;
using TesteB3.Server.Domain.Model;
using TesteB3.Server.Domain.Service;

namespace TesteB3.Test
{
    public class TituloServiceTest
    {
        ITituloService? tituloService;

        [Fact]
        public void Test_BuscarParametros_Success()
        {
            tituloService = new TituloService();                     

            TituloParametrosModel resultado = tituloService.GetTituloParametros();

            Assert.NotNull(resultado);       
        }

        [Fact]
        public void Test_Calculo1_Success()
        {
            tituloService = new TituloService();
            TituloModel titulo = new TituloModel();
            titulo.prazo = 2;
            titulo.valor = 20000;

            TituloModel resultado = tituloService.GerarCalculo(titulo);

            Assert.NotNull(resultado);
            Assert.True(Convert.ToDecimal(resultado.totalBruto) > Convert.ToDecimal(resultado.totalLiquido));
            Assert.True(titulo.valor < Convert.ToDecimal(resultado.totalLiquido));
        }

        [Fact]
        public void Test_Calculo2_Success()
        {
            tituloService = new TituloService();
            TituloModel titulo = new TituloModel();
            titulo.prazo = 1;
            titulo.valor = 10000;

            TituloModel resultado = tituloService.GerarCalculo(titulo);

            Assert.NotNull(resultado);
            Assert.True(Convert.ToDecimal(resultado.totalBruto) > Convert.ToDecimal(resultado.totalLiquido));
            Assert.True(titulo.valor < Convert.ToDecimal(resultado.totalLiquido));
        }

        [Fact]
        public void Test_Calculo1_Fall()
        {
            tituloService = new TituloService();
            TituloModel titulo = new TituloModel();
            titulo.prazo = 0;
            titulo.valor = 20000;
            TituloModel resultado = null;

            try
            {
                resultado = tituloService.GerarCalculo(titulo);
            }
           catch (Exception )
            {
                Assert.Null(resultado);
            }           
          
        }

        [Fact]
        public void Test_Calculo2_Fall()
        {
            tituloService = new TituloService();
            TituloModel titulo = new TituloModel();
            titulo.prazo = 2;
            titulo.valor = 0;

            TituloModel resultado = null;

            try
            {
                resultado = tituloService.GerarCalculo(titulo);
            }
            catch (Exception)
            {
                Assert.Null(resultado);
            }
        }

        [Fact]
        public void Test_Imposto1_Faixa_Success()
        {
            TituloService titulo = new TituloService();
            decimal investimento = 10000;
            decimal valorBruto = 10195;
            int prazo = 2;

            decimal resultado = titulo.CalcularImpostos(investimento, valorBruto, prazo);

            Assert.True(resultado > investimento);
            Assert.True(resultado < valorBruto);
        }

        [Fact]
        public void Test_Imposto2_Faixa_Success()
        {
            TituloService titulo = new TituloService();
            decimal investimento = 10000;
            decimal valorBruto = 10700;
            int prazo = 7;

            decimal resultado = titulo.CalcularImpostos(investimento, valorBruto, prazo);

            Assert.True(resultado > investimento);
            Assert.True(resultado < valorBruto);
        }

        [Fact]
        public void Test_Imposto3_Faixa_Success()
        {
            TituloService titulo = new TituloService();
            decimal investimento = 10000;
            decimal valorBruto = 11339;
            int prazo = 13;

            decimal resultado = titulo.CalcularImpostos(investimento, valorBruto, prazo);

            Assert.True(resultado > investimento);
            Assert.True(resultado < valorBruto);
        }

        [Fact]
        public void Test_Imposto4_Faixa_Success()
        {
            TituloService titulo = new TituloService();
            decimal investimento = 10000;
            decimal valorBruto = 12735;
            int prazo = 25;

            decimal resultado = titulo.CalcularImpostos(investimento, valorBruto, prazo);

            Assert.True(resultado > investimento);
            Assert.True(resultado < valorBruto);
        }       

    }
}