using AutoMapper;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        private readonly EnderecoService _service;
        private readonly IMapper _mapper;
        public EnderecoController(IConfiguration config, IMapper mapper)
        {
            string _config = config.GetConnectionString("DefaultConnection");
            _service = new EnderecoService(_config);
            _mapper = mapper;
        }
        [HttpPost("adicionar-Endereco")]
        public Endereco AdicionarAluno(Endereco enderecoDTO)
        {
            Endereco end = _mapper.Map<Endereco>(enderecoDTO);
            _service.Adicionar(enderecoDTO);
            return end;
        }
       
        [HttpGet("Listar-Enderecos-de-Usuario")]
        public List<Endereco> ListarEndereco([FromQuery] int usuarioId)
        {
            return _service.ListarEnderecoPorId(usuarioId);
        }

        [HttpPut("Editar-Endereco")]
        public void EditarProduto(Endereco E)
        {
            _service.Editar(E);
        }
        [HttpDelete("deletar-endereco")]
        public void DeletarProduto(int id)
        {
            _service.Remover(id);
        }
    }
}
