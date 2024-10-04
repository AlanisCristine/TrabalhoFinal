using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace FrontEnd.UseCases
{
    public class ProdutoUC
    {
        private readonly HttpClient _client;
        public ProdutoUC(HttpClient client)
        {
            _client = client;
        }
        public List<Produto> ListarProduto()
        {
            return _client.GetFromJsonAsync<List<Produto>>("Produto/Listar-Produto").Result;
        }
        public void CadastrarProduto(Produto produto)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Produto/Adicionar-Produto", produto).Result;
        }
    }
}
