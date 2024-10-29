
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data.SQLite;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace TrabalhoFinal._02_Repository;

public class CarrinhoRepository : ICarrinhoRepository
{
    private readonly string ConnectionString;
    private readonly IPessoaRepository _repositoryUsuario;
    private readonly IProdutoRepository _repositoryProduto;
    public CarrinhoRepository(string connectioString)
    {
        ConnectionString = connectioString;
        _repositoryUsuario = new PessoaRepository(connectioString);
        _repositoryProduto = new ProdutoRepository(connectioString);
    }
    public void Adicionar(Carrinho carrinho)
    {
        using var connection = new SQLiteConnection(ConnectionString);
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
            Carrinho.Produto = _repositoryProduto.BuscarPorId(car.IdProduto);
            Carrinho.Pessoa = _repositoryUsuario.BuscarPorId(car.IdPessoa);
            listDTO.Add(Carrinho);
        }
        return listDTO;
    }
}

