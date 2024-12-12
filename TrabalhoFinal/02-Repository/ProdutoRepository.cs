using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._02_Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly string ConnectionString;
        public ProdutoRepository(IConfiguration connectionString)
        {
            ConnectionString = connectionString.GetConnectionString("DefaultConnection"); ;
        }

        public void AdicionarProduto(Produto pro, bool e_funcionário)
        {
            using var connection = new SQLiteConnection(ConnectionString); //Cria conexão
            if (e_funcionário == true)
            {
                connection.Insert<Produto>(pro);
            }
            else
            {
                throw new Exception("Você não é um funcinário da loja, não pode adicionar produtos no sistema.");
            }

        }

        public void RemoverProduto(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString); //Cria conexão                                    
            Produto novoProduto = BuscarPorId(id);
            connection.Delete<Produto>(novoProduto);
        }

        public void EditarProduto(Produto pro)
        {
            using var connection = new SQLiteConnection(ConnectionString);//Cria conexão                                    
            connection.Update<Produto>(pro);
        }
        public List<Produto> ListarProduto()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            return connection.GetAll<Produto>().ToList();
        }

        public Produto BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Produto>(id);
        }

        public List<Produto> ProdutosUsuario(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            List<Produto> listReturn = connection.Query<Produto>($"SELECT P.Nome\r\nFROM CARRINHOS C\r\nINNER JOIN PRODUTOS P ON C.IdProduto = P.{id}").ToList();

            return listReturn;
        }
    }
}