using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._02_Repository
{
    public class ProdutoRepository
    {  
        private readonly string ConnectionString;
        public ProdutoRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void AdicionarProduto(Produto pro)
        {
            using var connection = new SQLiteConnection(ConnectionString); //Cria conexão
            connection.Insert<Produto>(pro);
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

    }
}
