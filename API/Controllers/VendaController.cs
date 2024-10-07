using AutoMapper;
using Core._01_Services;
using Core._03_Entidades;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private readonly VendaService _service;
    private readonly IMapper _mapper;
    public VendaController(IConfiguration config, IMapper mapper)
    {
        string _config = config.GetConnectionString("DefaultConnection");
        _service = new VendaService(_config);
        _mapper = mapper;
    }
    [HttpPost("adicionar-Venda")]
    public void AdicionarAluno(Venda vendaDTO)
    {
        Venda venda = _mapper.Map<Venda>(vendaDTO);
        _service.Adicionar(venda);
    }
    [HttpGet("listar-Venda")]
    public List<Venda> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpPut("editar-Venda")]
    public void EditarProduto(Venda v)
    {
        _service.Editar(v);
    }
    [HttpDelete("deletar-Venda")]
    public void DeletarProduto(int id)
    {
        _service.Remover(id);
    }
}
