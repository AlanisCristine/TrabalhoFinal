using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._01_Service
{
    public class CarrinhoService
    {
        public CarrinhoRepository repository { get; set; }

        public CarrinhoService(string _config, IMapper mapper)
        {
            repository = new CarrinhoRepository(_config, mapper);
        }
        public List<CarrinhoDTO> ListarCarrinho()
        {
            return repository.ListarCarrinho();
        }

        public void Adicionar(Carrinho carrinho)
        {
            repository.AdicionarProdutoCarrinho(carrinho);
        }
    }
}
