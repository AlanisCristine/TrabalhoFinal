using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._02_Repository;

public class PessoaRepository
{
    public readonly string ConnectionString;

    public PessoaRepository(string connectionString)
    {
        ConnectionString = connectionString;
    }

    public void AdicionarPessoa(Pessoa pes)
    {
        using var connection = new SQLiteConnection(ConnectionString); //Cria conexão
        connection.Insert<Pessoa>(pes);
    }

    public void RemoverPessoa(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString); //Cria conexão                                    
        Pessoa novoProduto = BuscarPorId(id);
        connection.Delete<Pessoa>(novoProduto);
    }

    public void Editar(Pessoa pes)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Pessoa>(pes);
    }

    public List<Pessoa> ListarPessoa()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Pessoa>().ToList();
    }

    public Pessoa BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Pessoa>(id);
    }

    public Pessoa BuscarPorUserName(string user)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Pessoa>(user);
    }

}
