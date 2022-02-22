using Curso.ValueObjects;
using PedidoConsole.Domain.Interfaces;

namespace PedidoConsole.Domain
{
    public class Produto : IEntity
    {
        public int Id { get; set; }
        public string CodigoBarras { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public TipoProduto TipoProduto { get; set; }
        public bool Ativo { get; set; }
    }
}