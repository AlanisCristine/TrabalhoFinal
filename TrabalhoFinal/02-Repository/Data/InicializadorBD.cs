using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._02_Repository.Data;

public static class InicializadorBD
{

    public static void Inicializador()
    {
        using var connection = new SQLiteConnection("Data Source = Glow.db");

        connection.Open();
        string commandoSQL = @"
                  CREATE TABLE IF NOT EXISTS PRODUTOS(
                  Id INTEGER PRIMARY KEY AUTOINCREMENT,
                  Nome TEXT NOT NULL,
                  Preco DECIMAL NOT NULL,
                  Estoque INT NOT NULL
                );";

        commandoSQL += @"
                  CREATE TABLE IF NOT EXISTS PESSOAS(
                  Id INTEGER PRIMARY KEY AUTOINCREMENT,
                  Nome TEXT NOT NULL,
                  UserName TEXT NOT NULL,
                  Senha TEXT NOT NULL,
                  Email TEXT NOT NULL,
                  E_funcionario BOOLEAN NOT NULL
                );";

        commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS CARRINHOS(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 IdVenda INTEGER NULL,
                 IdPessoa INTEGER NOT NULL,
                 IdProduto INTEGER NOT NULL
                 );";

        commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Enderecos(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Rua TEXT NOT NULL,
                 Bairro TEXT NOT NULL,
                 Numero TEXT NOT NULL,
                 IdPessoa INTEGER NOT NULL
                 );";

        commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Vendas(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 EnderecoId INTEGER  NOT NULL,
                 PessoaId INTEGER  NOT NULL,
                 ProdutoId INTEGER  NOT NULL,
                 MetodoDePagamento INTEGER NOT NULL CHECK (MetodoDePagamento IN (1, 2, 3)),,
                 ValorFinal DOUBLE NOT NULL,
                 DataCompra DATETIME NOT NULL
                 );";


        connection.Execute(commandoSQL);
    }


}
