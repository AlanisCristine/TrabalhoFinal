using Core._03_Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository.Interfaces;

namespace TrabalhoFinal._02_Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly string ConnectionString;
        public EnderecoRepository(IConfiguration config)
        {
            ConnectionString = config.GetConnectionString("DefaultConnection");
        }
        public void Adicionar(Endereco endereco)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Endereco>(endereco);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Endereco endereco = BuscarPorId(id);
            connection.Delete<Endereco>(endereco);
        }
        public List<Endereco> ListarEnderecoPorId(int usuarioId)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Endereco> list = connection.Query<Endereco>($"SELECT Id, Rua, Numero, Bairro, IdPessoa  FROM Enderecos WHERE IdPessoa = {usuarioId}").ToList();
            return list;
        }
        public void Editar(Endereco endereco)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Endereco>(endereco);
        }
        public List<Endereco> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Endereco>().ToList();
        }
        public Endereco BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Endereco>(id);
        }
    }
}
