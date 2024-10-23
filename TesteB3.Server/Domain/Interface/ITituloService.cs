using TesteB3.Server.Domain.Model;

namespace TesteB3.Server.Domain.Interface
{
    public interface ITituloService
    {
        public TituloParametrosModel GetTituloParametros();

        public TituloModel GerarCalculo(TituloModel titulo);
    }
}
