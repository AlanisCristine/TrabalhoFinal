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
        private PessoaService _service;
        private readonly IMapper _mapper;
        public PessoaController(IMapper mapper,IConfiguration config)
        {
            string conectionstring = config.GetConnectionString("DefaultConnection");
            _mapper = mapper;
            _service = new PessoaService(conectionstring);
        }

        [HttpPost("Adicionar-Pessoa")]
        public void AdicionarPessoa(CreatePessoaDTO p)
        { 
            Pessoa pessoa= _mapper.Map<Pessoa>(p);
            _service.AdicionarPessoa(pessoa);
        }

        [HttpGet("Logar-Pessoa")]
        public LoginPessoa Login([FromQuery] LoginDTO p)
        {
            return _service.Login(p.UserName, p.Senha);
        }


        [HttpGet("Listar-Pessoa")]
        public List<Pessoa> ListarPessoa()
        {
            return _service.ListarPessoa();
        }

        [HttpDelete("Remover-Pessoa")]
        public void RemoverPessoa(int id)
        {
            _service.RemoverPessoa(id);
        }

        [HttpPut("Editar-Pessoa")]
        public void EditarPessoa(Pessoa pessoa)
        {
            _service.EditarPessoa(pessoa);
        }
    }
}
