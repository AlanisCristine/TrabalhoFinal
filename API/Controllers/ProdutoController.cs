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
        public IActionResult AdicionarProduto(CreateProdutoDTO p, bool e_funcionário)
        {
            try
            {
                Produto produto = _mapper.Map<Produto>(p);
                _service.AdicionarProduto(produto, e_funcionário);
                return Ok();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao adicionar um produto, o erro foi \n {e.Message}");
            }

        }

        /// <summary>
        /// Lista produtos adicionados no banco de dados 
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar-Produto")]
        public List<Produto> ListarProduto()
        {

            try
            {
                return _service.ListarProduto();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Listar os produtos");
            }

        }

        /// <summary>
        /// Lista produtos do usuário
        /// </summary>
        /// <returns></returns>
        [HttpGet("Listar-Produtos-Usuario")]
        public List<Produto> ProdutoPessoa(int id)
        {

            try
            {
                return _service.ProdutosUsuario(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }


        /// <summary>
        /// Remove um produto do banco de dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("Remover-Produto")]
        public IActionResult RemoverProduto(int id)
        {

            try
            {
                _service.RemoverProduto(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao deletar um usuário, o erro foi \n {e.Message}");
            }

        }

        //Edita os dados de algum produto cadastrado 
        [HttpPut("Editar-Produto")]
        public IActionResult EditarProduto(Produto produto)
        {
            try
            {
                _service.EditarProduto(produto);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao editar um usuário, o erro foi \n {e.Message}");
            }

        }
    }
}
