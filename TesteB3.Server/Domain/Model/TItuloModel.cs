using System.Diagnostics.CodeAnalysis;

namespace TesteB3.Server.Domain.Model
{
    [ExcludeFromCodeCoverage]
    public class TituloModel
    {
        public string totalLiquido { get; set; }
        public decimal valor { get; set; }
        public int prazo { get; set; }
        public string totalBruto { get; set; }
    }
}
