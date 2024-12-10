
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._01_Services;

public class CarrinhoService : ICarrinhoService
{
    private readonly ICarrinhoRepository repository;
    public CarrinhoService(ICarrinhoRepository carrinhoRepository)
    {
        repository = carrinhoRepository;
    }

    public void Adicionar(Carrinho carrinho)
    {
        repository.Adicionar(carrinho);
    }

    public void Remover(int id)
    {
        repository.Remover(id);
    }

    public void DeletarProdutosDoCarrinho(int usuarioId)
    {
        repository.DeletarProdutosDoCarrinho(usuarioId);
    }


    public List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId)
    {
        return repository.ListarCarrinhoPreenchido(usuarioId);
    }


    public List<Carrinho> Listar()
    {
        return repository.Listar();
    }
    public Carrinho BuscarTimePorId(int id)
    {
        return repository.BuscarPorId(id);
    }
    public void Editar(Carrinho editPessoa)
    {
        repository.Editar(editPessoa);
    }
}
