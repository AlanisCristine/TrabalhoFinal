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
        public Endereco AdicionarAluno(Endereco enderecoDTO)
        {
            Endereco end = _mapper.Map<Endereco>(enderecoDTO);
            _service.Adicionar(enderecoDTO);
            return end;
        }
       
        /// <summary>
        /// lista endereços de usuários pelo id
        /// </summary>
        /// <param name="usuarioId"></param>
        /// <returns></returns>
        [HttpGet("Listar-Enderecos-de-Usuario")]
        public List<Endereco> ListarEndereco([FromQuery] int usuarioId)
        {
            return _service.ListarEnderecoPorId(usuarioId);
        }

        /// <summary>
        /// Edita o endereço do usuario
        /// </summary>
        /// <param name="E"></param>
        [HttpPut("Editar-Endereco")]
        public void EditarProduto(Endereco E)
        {
            _service.Editar(E);
        }

        /// <summary>
        /// deleta o endereco pelo id do endereço
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("deletar-endereco")]
        public void DeletarProduto(int id)
        {
            _service.Remover(id);
        }
    }
}
