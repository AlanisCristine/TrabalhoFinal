using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace API.Controllers
{
    public class CarrinhoController: ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly CarrinhoService _service;


        public CarrinhoController(IMapper mapper, IConfiguration config)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _mapper = mapper;
            _service = new CarrinhoService(_config, mapper);
        }


        [HttpGet("Listar-Produtos-Carrinho")]
        public List<CarrinhoDTO> ListarCarrinho()
        {
            return _service.ListarCarrinho();
        }

        [HttpPost("Adicionar-Produto-Carrinho")]
        public void AdicionarAluno(Carrinho carrinho)
        {
            _service.Adicionar(carrinho);
        }
    }
}
