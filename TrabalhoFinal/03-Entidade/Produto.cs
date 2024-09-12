using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._03_Entidade
{
    public class Produto
    {
        
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Ultrapassou o limite de caracteres")]
        [MinLength(2, ErrorMessage = "Ultrapassou o limite de caracteres")]
        public string Nome { get; set; }

        public decimal Preco { get; set; }
        public int Estoque { get; set;}


    }
}
