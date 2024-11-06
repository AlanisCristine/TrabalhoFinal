using AutoMapper;
using Core._01_Services;
using Core._03_Entidades;
using FrontEnd;
using Microsoft.AspNetCore.Mvc;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._01_Services;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class VendaController : ControllerBase
{
    private readonly IVendaService _service;
    private readonly IMapper _mapper;
    public VendaController(IVendaService vendaService, IMapper mapper)
    {
        _service = vendaService;
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

    [HttpGet("Listar-Venda-do-Preenchida")]
    public List<ReadVendaReciboDTO> ListarCarrinho(int usuarioId)
    {
        return _service.ListarVendaPreenchido(usuarioId);
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
