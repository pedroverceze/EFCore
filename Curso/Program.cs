using System;
using System.Collections.Generic;
using System.Linq;
using Curso.Data;
using Microsoft.EntityFrameworkCore;
using PedidoConsole.Domain;

namespace PedidoConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AtualizarDados();
        }

        private static void AtualizarDados()
        {
            throw new NotImplementedException();
        }

        private static void InserirDados()
        {
            var db = new ApplicationContext();

            var produto = new Produto
            {
                Descricao = "teste",
                Ativo = true,
                CodigoBarras = "123456789",
                Valor = 23,
                TipoProduto = Curso.ValueObjects.TipoProduto.Tipo1
            };

            //1 forma
            db.Set<Produto>().Add(produto);

            //2 forma
            //db.Entry(produto).State = EntityState.Added;

            //3 forma
            //db.Add(produto);

            var registros = db.SaveChanges();

            if (registros > 0)
            {
                Console.WriteLine($"Registros inseridos: {registros}");
            }
        }

        private static void InserirEmMassa()
        {

            var produto = new Produto
            {
                Descricao = "teste2",
                Ativo = false,
                CodigoBarras = "1234sd56789",
                Valor = 15,
                TipoProduto = Curso.ValueObjects.TipoProduto.Tipo2
            };

            var cliente = new Cliente{
                Nome = "Pedro",
                CEP = "86050280",
                Cidade = "londrina",
                Estado = "PR",
                Telefone = "98889988"
            };

            using var db = new ApplicationContext();

            db.AddRange(produto, cliente);
            var registros = db.SaveChanges();
        }

        private static void ConsultarDados(){
            using var db = new ApplicationContext();

            //consulta rastreada
            var clientes = db.Set<Cliente>()
            .Where(c => c.Id > 0)
            .OrderBy(o => o.Nome)
            .ToList();

            //consulta nao rastreada
            var clientesNoTracking = db.Set<Cliente>().AsNoTracking().Where(c => c.Id > 0).ToList();

            foreach(var cliente in clientes){
                //FIND metodo que verifica na memoria
                var buscarPorFind = db.Set<Cliente>().Find(cliente.Id);
            }

        }
    
        private static void InserirItemPedido(){
            using var db = new ApplicationContext();

            var cliente = db.Set<Cliente>().FirstOrDefault();
            var produto = db.Set<Produto>().FirstOrDefault();

            var pedido = new Pedido{
                ClienteId = cliente.Id,
                IniciadoEm = DateTime.Now,
                FinalizadoEm = DateTime.Now.AddHours(2),
                Observacao = "teste",
                Status = Curso.ValueObjects.StatusPedido.Analise,
                TipoFrete = Curso.ValueObjects.TipoFrete.SemFrete,
                Itens = new List<PedidoItem>{
                    new PedidoItem{
                        ProdutoId = produto.Id,
                        Desconto = 0,
                        Quantidade = 1,
                        Valor = 10
                    }
                }
            };

            db.Set<Pedido>().Add(pedido);
            db.SaveChanges();
        }

        private static void ConsultarComCarregamentoAdiantado(){
            using var db = new ApplicationContext();

            //COnsulta com carregamento adiantado, onde ja carrega todos os subobjetos
            var pedido = db.Set<Pedido>()
            .Include(p => p.Itens)
            .ThenInclude(i=>i.Produto)
            .ToList();
        }
    }
}