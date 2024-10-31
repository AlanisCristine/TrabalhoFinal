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
    [HttpPost("adicionar-carrinho")]
    public void AdicionarAluno(Carrinho carrinhoDTO)
    {
        Carrinho carrinho = _mapper.Map<Carrinho>(carrinhoDTO);
        _service.Adicionar(carrinho);
    }
    [HttpGet("listar-carrinho")]
    public List<Carrinho> ListarAluno()
    {
        return _service.Listar();
    }
    [HttpGet("Listar-Produtos-do-Carrinho")]
    public List<CarrinhoDTO> ListarCarrinho(int usuarioId)
    {
        return _service.ListarCarrinhoPreenchido(usuarioId);
    }


    [HttpPut("editar-carrinho")]
    public void EditarCarrinho(Carrinho p)
    {
        _service.Editar(p);
    }
    [HttpDelete("deletar-carrinho")]
    public void DeletarCarrinho(int id)
    {
        _service.Remover(id);
    }
}
