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
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _service;
        private readonly IMapper _mapper;

        public PessoaController(IPessoaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Adiciona um usuário no banco de dados
        /// </summary>
        /// <param name="usuarioDTO"></param>
        [HttpPost("adicionar-usuario")]
        public IActionResult AdicionarAluno(Pessoa usuarioDTO)
        {
            try
            {
                _service.Adicionar(usuarioDTO);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"Ocorreu um erro ao adicionar um usuário, o erro foi \n {e.Message}");
            }
        }

        /// <summary>
        /// Faz o login a partir do username e senha de um usuário já cadastrado anteriormente
        /// </summary>
        /// <param name="usuarioLoginDTO"></param>
        /// <returns></returns>
        [HttpPost("Fazer-Login")]
        public Pessoa FazerLogin(LoginDTO usuarioLoginDTO)
        {
            try
            {
                Pessoa usu = _service.FazerLogin(usuarioLoginDTO);
                return usu;
            }
            catch (Exception)
            {

                throw new Exception("Erro ao fazer login");
            }

        }

        /// <summary>
        /// Lista ussários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-usuario")]
        public List<Pessoa> ListarAluno()
        {
            try
            {
                return _service.Listar();
            }
            catch (Exception)
            {

                throw new Exception("Erro ao Listar os usuários");
            }

        }

        /// <summary>
        /// Edita os dados de um usuário cadastrado
        /// </summary>
        /// <param name="p"></param>
        [HttpPut("editar-usuario")]
        public IActionResult EditarUsuario(Pessoa p)
        {

            try
            {
                _service.Editar(p);
                return NoContent();
            }
            catch (Exception e)
            {

                return BadRequest($"Ocorreu um erro ao editar um usuário, o erro foi \n {e.Message}");
            }

        }

        /// <summary>
        /// Deleta um usuário do banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("deletar-usuario")]
        public IActionResult DeletarUsuario(int id)
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
