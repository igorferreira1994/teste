using Microsoft.Extensions.Logging;
using Moq;
using Teste.Server.Controllers;
using TesteB3.Server.Domain.Interface;
using TesteB3.Server.Domain.Model;

namespace TesteB3.Test
{
    public class TituloControllerTest
    {        

        [Fact]
        public void Test_BuscarParametros_Success()
        {
            Moq.Mock<ILogger<TituloController>> moqLog = new Moq.Mock<ILogger<TituloController>>();
            Moq.Mock<ITituloService> moqTitulo = new Moq.Mock<ITituloService>();
            TituloParametrosModel model = new TituloParametrosModel();
            TituloController titulo = new TituloController(moqLog.Object,moqTitulo.Object);
            moqTitulo.Setup(x => x.GetTituloParametros()).Returns(model);

            TituloParametrosModel resultado = titulo.GetTituloParametros();

            Assert.NotNull(resultado);       
        }

        [Fact]
        public void Test_Calculo_Success()
        {
            Moq.Mock<ILogger<TituloController>> moqLog = new Moq.Mock<ILogger<TituloController>>();
            Moq.Mock<ITituloService> moqTitulo = new Moq.Mock<ITituloService>();
            TituloController titulo = new TituloController(moqLog.Object, moqTitulo.Object);
            TituloModel tituloModel = new TituloModel();
            moqTitulo.Setup(x => x.GerarCalculo(It.IsAny<TituloModel>())).Returns(tituloModel);            

            TituloModel resultado = titulo.PostTitulo(tituloModel);

            Assert.NotNull(resultado);
        }        

    }
}