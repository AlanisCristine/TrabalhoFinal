using Core._03_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace FrontEnd.UseCases
{
    public class EnderecoUC
    {
        private readonly HttpClient _client;
        public EnderecoUC(HttpClient client)
        {
            _client = client;
        }
        public Endereco AdicionarEndereco(Endereco end)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Endereco/adicionar-Endereco", end).Result;
            Endereco enderecoCadastrado = response.Content.ReadFromJsonAsync<Endereco>().Result;
            return enderecoCadastrado;

        }


        public List<Endereco> ListarEnderecoPorId(Pessoa usuariologado)
        {
            return _client.GetFromJsonAsync<List<Endereco>>("Endereco/Listar-Enderecos-de-Usuario?usuarioId=" + usuariologado.Id).Result;
        }
    }
}
