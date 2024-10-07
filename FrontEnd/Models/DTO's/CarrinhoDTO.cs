using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace FrontEnd.Models.DTO
{
    public class CarrinhoDTO
    {
        public int Id { get; set; }
        public Pessoa pessoa { get; set; }
        public int IdUsuario     { get; set; }
       public Produto Produto { get; set; }
        public int IdProduto { get; set; }

        public override string ToString()
        {
            return $"Usuario: {pessoa.Nome} - Produto: {Produto.Nome} - Preço: {Produto.Preco}" +
                $" \n ------------------------------------------ ";
           
        }

    }
}

