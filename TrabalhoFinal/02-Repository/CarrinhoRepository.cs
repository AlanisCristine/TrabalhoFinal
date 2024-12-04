
using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._02_Repository;

public class CarrinhoRepository : ICarrinhoRepository
{
   
    private readonly IPessoaRepository _repositoryUsuario;
    private readonly IProdutoRepository _repositoryProduto;
    private readonly string ConnectionString;
    public CarrinhoRepository(IConfiguration config, IPessoaRepository repositoryUsuario, IProdutoRepository repositoryProduto)
    {
        ConnectionString = config.GetConnectionString("DefaultConnection");
        _repositoryUsuario = repositoryUsuario;
        _repositoryProduto = repositoryProduto;
    }
  
    public void Adicionar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Produto p = _repositoryProduto.BuscarPorId(carrinho.IdProduto);
        Pessoa pes = _repositoryUsuario.BuscarPorId(carrinho.IdPessoa);

        if (p == null || pes == null)
        {
            throw new Exception("Id do produto ou da pessoa não existe");
        }
       
        connection.Insert<Carrinho>(carrinho);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Carrinho carrinho = BuscarPorId(id);
        connection.Delete<Carrinho>(carrinho);
    }
    public void Editar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Carrinho>(carrinho);
    }
    public List<Carrinho> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Carrinho>().ToList();
    }
    public Carrinho BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.Get<Carrinho>(id);
    }

    public List<CarrinhoDTO> ListarCarrinhoPreenchido(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Carrinho> list = connection.Query<Carrinho>($"SELECT Id, IdPessoa , IdVenda, IdProduto FROM Carrinhos WHERE IdPessoa = {usuarioId}").ToList();
        List<CarrinhoDTO> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
        return listDTO;
    }



    private List<CarrinhoDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Carrinho> list)
    {
        List<CarrinhoDTO> listDTO = new List<CarrinhoDTO>();

        foreach (Carrinho car in list)
        {
            CarrinhoDTO Carrinho = new CarrinhoDTO();
            Carrinho.Id = car.Id;
            Carrinho.Produto = _repositoryProduto.BuscarPorId(car.IdProduto);
            Carrinho.Pessoa = _repositoryUsuario.BuscarPorId(car.IdPessoa);
            listDTO.Add(Carrinho);
        }
        return listDTO;
    }
}

