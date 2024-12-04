using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._03_Entidade.DTOs
{
    public class ReadCarrinhoDTO
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }


        public override string ToString()
        {
            return $"Usuario {Pessoa.Nome} - Produto : {Produto.Nome} - Preço: {Produto.Preco}";
        }
        public string ToStringProduto()
        {
            return $"Produto : {Produto.Nome} - Preço: {Produto.Preco}";
        }
    }
}
    

