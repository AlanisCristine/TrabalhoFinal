using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaService _service;
        private readonly IMapper _mapper;
        public PessoaController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new PessoaService(_config);
            _mapper = mapper;
        }
        [HttpPost("adicionar-usuario")]
        public void AdicionarAluno(Pessoa usuarioDTO)
        {
            //Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);
            _service.Adicionar(usuarioDTO);
        }

        [HttpPost("Fazer-Login")]
        public Pessoa FazerLogin(LoginDTO usuarioLoginDTO)
        {
            Pessoa usu = _service.FazerLogin(usuarioLoginDTO);
            return usu;
        }

        [HttpGet("listar-usuario")]
        public List<Pessoa> ListarAluno()
        {
            return _service.Listar();
        }
        [HttpPut("editar-usuario")]
        public void EditarUsuario(Pessoa p)
        {
            _service.Editar(p);
        }
        [HttpDelete("deletar-usuario")]
        public void DeletarUsuario(int id)
        {
            _service.Remover(id);
        }
    }
}
