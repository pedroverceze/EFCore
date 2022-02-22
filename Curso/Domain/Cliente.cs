using PedidoConsole.Domain.Interfaces;

namespace PedidoConsole.Domain
{
    public class Cliente : IEntity{
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public string CEP { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
    }
}

