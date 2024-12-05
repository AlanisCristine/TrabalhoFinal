using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._03_Entidade
{
    public class Pessoa
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(100, ErrorMessage = "Ultrapassou o limite de caracteres")]
        [MinLength(2, ErrorMessage = "Ultrapassou o limite de caracteres")]
        public string Nome { get; set; }
        //public int TipoPessoa { get; set; }
        public string UserName { get; set; }
        public string Senha { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool E_funcionario { get; set; }
        public override string ToString()
        {
            return $"Id: {Id} - Nome: {Nome}";
        }

    }
}
