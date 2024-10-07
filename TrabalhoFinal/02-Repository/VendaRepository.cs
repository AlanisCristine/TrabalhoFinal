using Core._03_Entidades;
using Dapper.Contrib.Extensions;
using FrontEnd;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;

namespace Core._02_Repository;

public class VendaRepository
{
    private readonly string ConnectionString;
    private readonly CarrinhoRepository _repositoryCarrinho;
    private readonly PessoaRepository _repositoryUsuario;
    private readonly EnderecoRepository _repositoryEndereco;
    public VendaRepository(string connectioString)
    {
        ConnectionString = connectioString;
        _repositoryCarrinho = new(connectioString);
        _repositoryUsuario = new(connectioString);
        _repositoryEndereco = new(connectioString);
    }
    public void Adicionar(Venda venda)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Insert<Venda>(venda);
    }
    public void Remover(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Venda venda = new Venda();//BuscarPorId(id);
        connection.Delete<Venda>(venda);
    }
    public void Editar(Venda venda)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        connection.Update<Venda>(venda);
    }
    public List<Venda> Listar()
    {
        using var connection = new SQLiteConnection(ConnectionString);
        return connection.GetAll<Venda>().ToList();
    }
    public ReadVendaReciboDTO BuscarPorId(int id)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        Venda v = connection.Get<Venda>(id);
        ReadVendaReciboDTO vendaDTO = new ReadVendaReciboDTO();
        vendaDTO.Endereco = _repositoryEndereco.BuscarPorId(v.EnderecoId);
        vendaDTO.NomeUsuario = _repositoryUsuario.BuscarPorId(vendaDTO.Endereco.IdPessoa).Nome;
        vendaDTO.MetodoPagamento = v.MetodoDePagamento;
        vendaDTO.Produtos = _repositoryCarrinho.ListarCarrinhoPreenchido(vendaDTO.Endereco.IdPessoa);
        vendaDTO.ValorFinal = v.ValorFinal;
        return vendaDTO;
    }
}