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
    public ActionResult<Venda> AdicionarAluno(Venda vendaDTO)
    {
        try
        {
            Venda ven= _mapper.Map<Venda>(vendaDTO);
            _service.Adicionar(vendaDTO);
            return Ok(ven);
        }
        catch (Exception e)
        {

            return BadRequest($"Ocorreu um erro ao adicionar uma venda, o erro foi \n {e.Message}");
        }
       
    }

    /// <summary>
    /// Lista a venda, mas sem estar preenchida  apenas os numeros dos id
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-Venda")]
    public List<Venda> ListarAluno()
    {
        try
        {
          return _service.Listar();
        }
        catch (Exception)
        {

            throw new Exception("Erro ao Listar as vendas");
        }
        
    }

    /// <summary>
    /// Lista a venda preenchida de um usuario pelo id
    /// </summary>
    /// <param name="usuarioId"></param>
    /// <returns></returns>
    [HttpGet("Listar-Venda-do-Preenchida")]
    public List<ReadVendaReciboDTO> ListarCarrinho(int usuarioId)
    {
        try
        {
          return _service.ListarVendaPreenchido(usuarioId);
        }
        catch (Exception e)
        {

            throw new Exception($"Erro ao Listar as vendas preenchidas \n {e.Message}");
        }
       
    }

    /// <summary>
    /// Edita uma venda
    /// </summary>
    /// <param name="v"></param>
    [HttpPut("editar-Venda")]
    public IActionResult EditarProduto(Venda v)
    {
        try
        {
            _service.Editar(v);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest($"Ocorreu um erro ao editar uma venda, o erro foi \n {e.Message}");
        }
       
    }
    /// <summary>
    /// Deleta uma venda
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-Venda")]
    public IActionResult DeletarProduto(int id)
    {
        try
        {
          _service.Remover(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest($"Ocorreu um erro ao excluir uma venda, o erro foi \n {e.Message}");
        }
        
    }
}
