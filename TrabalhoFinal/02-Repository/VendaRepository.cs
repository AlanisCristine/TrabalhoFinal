using Core._03_Entidades;
using Dapper;
using Dapper.Contrib.Extensions;
using FrontEnd;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade.DTOs;

namespace Core._02_Repository;

public class VendaRepository : IVendaRepository
{
    private readonly string ConnectionString;
    private readonly ICarrinhoRepository _repositoryCarrinho;
    private readonly IPessoaRepository _repositoryUsuario;
    private readonly IEnderecoRepository _repositoryEndereco;
    private readonly IProdutoRepository _repositoryProduto;
    public VendaRepository(IConfiguration config, ICarrinhoRepository repositoryCarrinho, IPessoaRepository repositoryUsuario, IEnderecoRepository repositoryEndereco)
    {
        ConnectionString = config.GetConnectionString("DefaultConnection");
        _repositoryCarrinho = repositoryCarrinho;
        _repositoryUsuario = repositoryUsuario;
        _repositoryEndereco = repositoryEndereco;
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

    public List<ReadVendaReciboDTO> ListarVendaPreenchido(int usuarioId)
    {
        using var connection = new SQLiteConnection(ConnectionString);
        List<Venda> list = connection.Query<Venda>($"SELECT Id, IdPessoa , IdVenda, IdProduto FROM Carrinhos WHERE IdPessoa = {usuarioId}").ToList();
        List<ReadVendaReciboDTO> listDTO = TransformarListaCarrinhoEmCarrinhoDTO(list);
        return listDTO;
    }

    private List<ReadVendaReciboDTO> TransformarListaCarrinhoEmCarrinhoDTO(List<Venda> list)
    {
        List<ReadVendaReciboDTO> listDTO = new List<ReadVendaReciboDTO>();

        foreach (Venda ven in list)
        {
            if (ven.PessoaId > 0)
            {
                ReadVendaReciboDTO Venda = new ReadVendaReciboDTO();
                Venda.Id = ven.Id;
                Venda.Produtos = _repositoryCarrinho.ListarCarrinhoPreenchido(ven.PessoaId);
                Venda.NomeUsuario = _repositoryUsuario.BuscarPorId(ven.PessoaId).UserName;
                Venda.Endereco = _repositoryEndereco.BuscarPorId(ven.EnderecoId);
                listDTO.Add(Venda);
            }
        }
        return listDTO;
    }
}