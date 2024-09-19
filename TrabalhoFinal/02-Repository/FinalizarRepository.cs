using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._02_Repository
{
    public class FinalizarRepository
    {
        public readonly string ConnectionString;

        public FinalizarRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public List<ReadCarrinhoDTO> ListarCarrinhoPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> carrinhos = connection.GetAll<Carrinho>().ToList();
            List<ReadCarrinhoDTO> readCarrinhoDTOs = new List<ReadCarrinhoDTO>();
            foreach (Carrinho c in carrinhos)
            {
                if (c.Id == id)
                { 
                    ReadCarrinhoDTO 
                    carrinhos.Add(c);                   
                }               
            }

            return readCarrinhoDTOs;
        }

       

    }
}
