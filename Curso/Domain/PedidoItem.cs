using PedidoConsole.Domain;
using PedidoConsole.Domain.Interfaces;

namespace PedidoConsole.Domain
{
    public class PedidoItem : IEntity
    {
        public int Id { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }
        public decimal Desconto { get; set; }
    }
}