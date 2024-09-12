using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace API.Controllers
{
    [ApiController]
        [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private ProdutoService _service;
        private readonly IMapper _mapper;
        public ProdutoController(IMapper mapper,IConfiguration config)
        {
            string conectionstring = config.GetConnectionString("DefaultConnection");
            _mapper = mapper;
            _service = new ProdutoService(conectionstring);
        }

        [HttpPost("Adicionar-Produto")]
        public void AdicionarProduto(CreateProdutoDTO p)
        {
            Produto produto = _mapper.Map<Produto>(p);
            _service.AdicionarProduto(produto);
        }

        [HttpGet("Listar-Produto")]
        public List<Produto> ListarProduto()
        {
            return _service.ListarProduto();
        }

        [HttpDelete("Remover-Produto")]
        public void RemoverProduto(int id)
        {
            _service.RemoverProduto(id);
        }

        [HttpPut("Editar-Produto")]
        public void EditarProduto(Produto produto)
        {
            _service.EditarProduto(produto);
        }
    }
}
