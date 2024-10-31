﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._01_Service.Interfaces;
using TrabalhoFinal._02_Repository;
using TrabalhoFinal._02_Repository.Interfaces;
using TrabalhoFinal._03_Entidade;

namespace TrabalhoFinal._01_Service
{
    public class ProdutoService: IProdutoService
    {
        private readonly IProdutoRepository repository;
        public ProdutoService(IProdutoRepository produtoRepository)
        {
            repository = produtoRepository;
        }

        public void AdicionarProduto(Produto produto)
        {
            repository.AdicionarProduto(produto);
        }

        public void RemoverProduto(int id)
        {
            repository.RemoverProduto(id);
        }

        public List<Produto> ListarProduto()
        {
            return repository.ListarProduto();
        }
        public Produto BuscarProdutoPorId(int id)
        {
           return repository.BuscarPorId(id);
        }
        public void EditarProduto(Produto editProduto)
        {
            repository.EditarProduto(editProduto);
        }
    }
}
