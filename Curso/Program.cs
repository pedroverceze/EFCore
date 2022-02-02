using System;
using Curso.Data;
using Microsoft.EntityFrameworkCore;
using PedidoConsole.Domain;

namespace PedidoConsole // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InserirEmMassa();
        }

        public static void InserirDados()
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

        public static void InserirEmMassa()
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
    }
}