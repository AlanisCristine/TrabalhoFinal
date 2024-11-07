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
        public void AdicionarAluno(Pessoa usuarioDTO)
        {
            //Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            _service.Adicionar(usuarioDTO);
        }

        /// <summary>
        /// Faz o login a partir do username e senha de um usuário já cadastrado anteriormente
        /// </summary>
        /// <param name="usuarioLoginDTO"></param>
        /// <returns></returns>
        [HttpPost("Fazer-Login")]
        public Pessoa FazerLogin(LoginDTO usuarioLoginDTO)
        {
            Pessoa usu = _service.FazerLogin(usuarioLoginDTO);
            return usu;
        }

        /// <summary>
        /// Lista ussários cadastrados no sistema
        /// </summary>
        /// <returns></returns>
        [HttpGet("listar-usuario")]
        public List<Pessoa> ListarAluno()
        {
            return _service.Listar();
        }

        /// <summary>
        /// Edita os dados de um usuário cadastrado
        /// </summary>
        /// <param name="p"></param>
        [HttpPut("editar-usuario")]
        public void EditarUsuario(Pessoa p)
        {
            _service.Editar(p);
        }

        /// <summary>
        /// Deleta um usuário do banco de Dados
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("deletar-usuario")]
        public void DeletarUsuario(int id)
        {
            _service.Remover(id);
        }
    }
}
