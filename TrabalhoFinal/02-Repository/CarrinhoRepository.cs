using AutoMapper;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._02_Repository
{
    public class CarrinhoRepository
    {
        private readonly string ConnectionString;
        private readonly IMapper _mapper;
        private readonly PessoaRepository _repositoryPessoa;
        private readonly ProdutoRepository _repositoryProduto;

        public CarrinhoRepository(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public CarrinhoRepository(string connectionString, IMapper mapper)
        {
            ConnectionString = connectionString;
            _mapper = mapper;
            _repositoryPessoa = new PessoaRepository(connectionString);
            _repositoryProduto = new ProdutoRepository(connectionString);
        }

        public List<CarrinhoDTO> ListarCarrinho()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            List<Carrinho> carrinhos = connection.GetAll<Carrinho>().ToList();
            List<CarrinhoDTO> carrinhosDTO = new List<CarrinhoDTO>();//_mapper.Map<List<ReadRotinaDTO>>(lista);
            foreach (Carrinho c in carrinhos)
            {
                CarrinhoDTO carrinhoDTO = new CarrinhoDTO();
                carrinhoDTO.Id = c.Id;
                carrinhoDTO.IdPessoa = c.IdPessoa;
                carrinhoDTO.Pessoa = _repositoryPessoa.BuscarPorId(c.IdPessoa);
                carrinhoDTO.IdProduto = c.IdProduto;
                carrinhoDTO.Produto = _repositoryProduto.BuscarPorId(c.IdProduto);
                carrinhosDTO.Add(carrinhoDTO);
            }
            return carrinhosDTO;
        }
    }
}
