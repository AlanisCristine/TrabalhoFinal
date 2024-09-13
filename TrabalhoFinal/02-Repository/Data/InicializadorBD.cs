﻿using Dapper;
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
                  Endereco STRING NOT NULL
                );";


        connection.Execute(commandoSQL);
    }


}
