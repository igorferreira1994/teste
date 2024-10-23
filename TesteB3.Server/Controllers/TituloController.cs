using Microsoft.AspNetCore.Mvc;
using TesteB3.Server.Domain.Interface;
using TesteB3.Server.Domain.Model;

namespace Teste.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TituloController : ControllerBase
    {
        private readonly ILogger<TituloController> _logger;
        private readonly ITituloService _tituloService;
        public TituloController(ILogger<TituloController> logger, ITituloService tituloService)
        {
            _logger = logger;
            _tituloService = tituloService;
        }

        [HttpGet("ParametrosTitulo")]
        public TituloParametrosModel GetTituloParametros()
        {
            _logger.LogInformation("Obtendo parametros para o cálculo.");
            return _tituloService.GetTituloParametros();            
        }

        [HttpPost("Titulo")]
        public TituloModel PostTitulo(TituloModel titulo)
        {
            _logger.LogInformation("Gerando calculo para  R$"+titulo.valor + " e prazo de : " +titulo.prazo + " meses.");
            return _tituloService.GerarCalculo(titulo);           
        }
       
    }
}
