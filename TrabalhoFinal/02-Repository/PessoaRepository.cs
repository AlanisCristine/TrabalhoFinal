using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._02_Repository;

public class PessoaRepository : IPessoaRepository
{
    private readonly string ConnectionString;
    public PessoaRepository (IConfiguration config)
    {
        ConnectionString = config.GetConnectionString("DefaultConnection");
    }
    public void Adicionar(Pessoa usuario)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Pessoa>(usuario);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Pessoa usuario = BuscarPorId(id);
        connection.Delete<Pessoa>(usuario);
    }
    public void Editar(Pessoa usuario)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Pessoa>(usuario);
    }
    public List<Pessoa> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Pessoa>().ToList();
    }
    public Pessoa BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Pessoa>(id);
    }
}