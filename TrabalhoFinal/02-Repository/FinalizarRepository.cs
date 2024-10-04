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
        private readonly PessoaRepository _repositoryPessoa;
        private readonly ProdutoRepository _repositoryProduto;

        public FinalizarRepository(string connectionString)
        {
            ConnectionString = connectionString;
            _repositoryPessoa = new PessoaRepository(connectionString);
            _repositoryProduto = new ProdutoRepository(connectionString);
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
                    ReadCarrinhoDTO carDTO = new ReadCarrinhoDTO();
                    //preencher o objeto
                    carDTO.IdPessoa = c.IdPessoa;
                    carDTO.Pessoa = _repositoryPessoa.BuscarPorId(c.IdPessoa);
                    carDTO.IdProduto = c.IdProduto;
                    carDTO.Produto = _repositoryProduto.BuscarPorId(c.IdProduto);
                    
                    carrinhos.Add(c);                   
                }               
            }

            return readCarrinhoDTOs;
        }

       

    }
}
