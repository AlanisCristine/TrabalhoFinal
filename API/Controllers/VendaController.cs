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

    /// <summary>
    /// Adiciona uma venda pelo id do usuário
    /// </summary>
    /// <param name="venda"></param>
    [HttpPost("adicionar-Venda")]
    public void AdicionarAluno(Venda venda)
    {
        _service.Adicionar(venda);
    }

    /// <summary>
    /// Lista a venda, mas sem estar preenchida  apenas os numeros dos id
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-Venda")]
    public List<Venda> ListarAluno()
    {
        return _service.Listar();
    }

    /// <summary>
    /// Lista a venda preenchida de um usuario pelo id
    /// </summary>
    /// <param name="usuarioId"></param>
    /// <returns></returns>
    [HttpGet("Listar-Venda-do-Preenchida")]
    public List<ReadVendaReciboDTO> ListarCarrinho(int usuarioId)
    {
        return _service.ListarVendaPreenchido(usuarioId);
    }

    /// <summary>
    /// Edita uma venda
    /// </summary>
    /// <param name="v"></param>
    [HttpPut("editar-Venda")]
    public void EditarProduto(Venda v)
    {
        _service.Editar(v);
    }
    /// <summary>
    /// Deleta uma venda
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-Venda")]
    public void DeletarProduto(int id)
    {
        _service.Remover(id);
    }
}
