using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabalhoFinal._03_Entidade.DTOs
{
    public class CreatePessoaDTO
    {
        public string Nome { get; set; }
        public string UserName { get; set; }
        public int Senha { get; set; }
        public string Endereco { get; set; }
    }
}
