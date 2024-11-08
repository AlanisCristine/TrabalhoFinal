using AutoMapper;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service;
using TrabalhoFinal._01_Service.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _service;
        private readonly IMapper _mapper;

        public EnderecoController(IEnderecoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }
        /// <summary>
        /// Adiciona um endereço para um usuario já cadastrado
        /// </summary>
        /// <param name="enderecoDTO"></param>
        /// <returns></returns>
        [HttpPost("adicionar-Endereco")]
        public IActionResult AdicionarAluno(Endereco enderecoDTO)
        {
            try
            {
                Endereco end = _mapper.Map<Endereco>(enderecoDTO);
                _service.Adicionar(enderecoDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ocorreu um erro ao adicionar um produto, o erro foi \n {e.Message}");
            }

        }

        /// <summary>
        /// lista endereços de usuários pelo id
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("Listar-Enderecos-de-Usuario")]
        public List<Endereco> ListarEndereco([FromQuery] int usuarioId)
        {
            try
            {
                return _service.ListarEnderecoPorId(usuarioId);
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Listar os produtos");
            }

        }

        /// <summary>
        /// Edita o endereço do usuario
        /// </summary>
        /// <param name="E"></param>
        [HttpPut("Editar-Endereco")]
        public IActionResult EditarProduto(Endereco E)
        {
            try
            {
                _service.Editar(E);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao editar um usuário, o erro foi \n {e.Message}");
            }

        }

        /// <summary>
        /// deleta o endereco pelo id do endereço
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("deletar-endereco")]
        public IActionResult DeletarProduto(int id)
        {
            try
            {
                _service.Remover(id);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao deletar um usuário, o erro foi \n {e.Message}");
            }

        }
    }
}
