using AutoMapper;
using Microsoft.AspNetCore.Mvc;
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
    public void AdicionarAluno(Carrinho carrinhoDTO)
    {
        Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
        _service.Adicionar(carrinho);
    }

    /// <summary>
    /// Lista todos os carrinhos, porém apenas com valores do id
    /// </summary>
    /// <returns></returns>
    [HttpGet("listar-carrinho")]
    public List<Carrinho> ListarAluno()
    {
        return _service.Listar();
    }

    /// <summary>
    /// Lista o carrinho do usuário preenchido de acordo com o id dele
    /// </summary>
    /// <param name="usuarioId"></param>
    /// <returns></returns>
    [HttpGet("Listar-Produtos-do-Carrinho")]
    public List<CarrinhoDTO> ListarCarrinho(int usuarioId)
    {
        return _service.ListarCarrinhoPreenchido(usuarioId);
    }

    /// <summary>
    /// Edita algum dado do carrinho
    /// </summary>
    /// <param name="p"></param>
    [HttpPut("editar-carrinho")]
    public void EditarCarrinho(Carrinho p)
    {
        _service.Editar(p);
    }

    /// <summary>
    /// deleta um item do carrinho
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete("deletar-carrinho")]
    public void DeletarCarrinho(int id)
    {
        _service.Remover(id);
    }
}
