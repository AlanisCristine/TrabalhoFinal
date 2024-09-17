using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._03_Entidade.DTOs
{
    public class CarrinhoDTO
    {
        public int Id { get; set; }
        public int IdPessoa { get; set; }
        public Pessoa Pessoa { get; set; }
        public int IdProduto { get; set; }
        public Produto Produto { get; set; }
    }
}
