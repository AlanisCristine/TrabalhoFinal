using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._01_Services;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class CarrinhoController : ControllerBase
{
    private readonly ICarrinhoService _service;
    private readonly IMapper _mapper;
    public CarrinhoController(ICarrinhoService carrinhoServer, IMapper mapper)
    {
        _service = carrinhoServer;
        _mapper = mapper;
    }

    /// <summary>
    /// Adiciona produtos em um carrinho do usuário de acordo com o id
    /// </summary>
    /// <param name="carrinhoDTO"></param>
    [HttpPost("adicionar-carrinho")]
    public IActionResult AdicionarAluno(Carrinho carrinhoDTO)
    {
        try
        {
            Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);

            _service.Adicionar(carrinho);
            return Ok();
        }
        catch (Exception e)
        {

            return BadRequest($"Ocorreu um erro ao adicionar um carrinho, o erro foi \n {e.Message}");
        }

    }

    /// <summary>
    /// Lista todos os carrinhos, porém apenas com valores do id
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-carrinho")]
    public List<Carrinho> ListarAluno()
    {
        try
        {
            return _service.Listar();
        }
        catch (Exception e)
        {

            throw new Exception("Erro ao Listar o carrinho");
        }

    }

    /// <summary>
    /// Lista o carrinho do usuário preenchido de acordo com o id dele
    /// </summary>
    /// <param name="usuarioId"></param>
    /// <returns></returns>
    [HttpGet("Listar-Produtos-do-Carrinho")]
    public List<CarrinhoDTO> ListarCarrinho(int usuarioId)
    {
        try
        {
            return _service.ListarCarrinhoPreenchido(usuarioId);
        }
        catch (Exception)
        {

            throw new Exception("Erro ao Listar o carrinho");
        }

    }

    /// <summary>
    /// Edita algum dado do carrinho
    /// </summary>
    /// <param name="p"></param>
    [HttpPut("editar-carrinho")]
    public IActionResult EditarCarrinho(Carrinho p)
    {
        try
        {
           _service.Editar(p);
           return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest($"Ocorreu um erro ao editar o seu carrinho, o erro foi \n {e.Message}");
        }
        
    }

    /// <summary>
    /// deleta um item do carrinho
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-carrinho")]
    public IActionResult DeletarCarrinho(int id)
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
    /// <summary>
    /// Deleta todos os produtos do carrinho de um usuário.
    /// </summary>
    /// <param name="usuarioId">ID do usuário do carrinho</param>
    [HttpDelete("deletar-todos-produtos")]
    public IActionResult DeletarTodosProdutosDoCarrinho(int usuarioId)
    {
        try
        {
            _service.DeletarProdutosDoCarrinho(usuarioId);  // Chama o serviço
            return Ok("Produtos removidos com sucesso.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao deletar os produtos do carrinho: {ex.Message}");
        }
    }
}

