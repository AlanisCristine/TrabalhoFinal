using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace API.Controllers
{
    [ApiController]
        [Route("[controller]")]
    public class ProdutoController : ControllerBase
    {
        private IProdutoService _service;
        private readonly IMapper _mapper;
        public ProdutoController(IMapper mapper, IProdutoService produto)
        {
            _mapper = mapper;
            _service = produto;
        }

        /// <summary>
        /// Adiciona um produto no banco de dados
        /// </summary>
        /// <param name="p"></param>
        [HttpPost("Adicionar-Produto")]
        public void AdicionarProduto(CreateProdutoDTO p)
        {
            Produto produto = _mapper.Map<Produto>(p);
            _service.AdicionarProduto(produto);
        }

        /// <summary>
        /// Lista produtos adicionados no banco de dados 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar-Produto")]
        public List<Produto> ListarProduto()
        {
            return _service.ListarProduto();
        }


        /// <summary>
        /// Remove um produto do banco de dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Remover-Produto")]
        public void RemoverProduto(int id)
        {
            _service.RemoverProduto(id);
        }

        //Edita os dados de algum produto cadastrado 
        [HttpPut("Editar-Produto")]
        public void EditarProduto(Produto produto)
        {
            _service.EditarProduto(produto);
        }
    }
}
