using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace FrontEnd.UseCases
{
    public class PessoaUC
    {
        private readonly HttpClient _client;
        public PessoaUC(HttpClient client)
        {
            _client = client;
        }

        public void CadastrarUsuario(Pessoa pessoa)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Pessoa/adicionar-usuario", pessoa).Result;
        }

        public List<Pessoa> ListarUsuario()
        {
            return _client.GetFromJsonAsync<List<Pessoa>>("Pessoa/listar-usuario").Result;
        }

        public Pessoa FazerLogin(LoginDTO usuarioLogin)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Pessoa/Fazer-Login", usuarioLogin).Result; //Simula um clique que vc da no execute do swagger
            Pessoa usuario = response.Content.ReadFromJsonAsync<Pessoa>().Result;
            return usuario;
        }
    }
}
