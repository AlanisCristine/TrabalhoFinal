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
                  UserName STRING NOT NULL,
                  Senha INT NOT NULL,
                  Email STRING NOT NULL
                );";

        commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS CARRINHOS(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 IdPessoa INTEGER NOT NULL,
                 IdProduto INTEGER NOT NULL
                 );";

        commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Enderecos(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 Rua STRING NOT NULL,
                 Bairro STRING NOT NULL,
                 Numero INTEGER NOT NULL,
                 UsuarioId int NOT NULL
                 );";

        commandoSQL += @"   
                 CREATE TABLE IF NOT EXISTS Vendas(
                 Id INTEGER PRIMARY KEY AUTOINCREMENT,
                 EnderecoId INTEGER  NOT NULL,
                 MetodoDePagamento INTEGER NOT NULL,
                 ValorFinal DOUBLE NOT NULL
                 );";


        connection.Execute(commandoSQL);
    }


}
