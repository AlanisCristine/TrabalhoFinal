using FrontEnd.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using TrabalhoFinal._03_Entidade;

namespace FrontEnd.UseCases
{
    public class CarrinhoUC
    {
        private readonly HttpClient _client;
        public CarrinhoUC(HttpClient client)
        {
            _client = client;
        }
        public void ComprarProduto(Carrinho car)
        {
            HttpResponseMessage response = _client.PostAsJsonAsync("Carrinho/adicionar-carrinho", car).Result;
        }
      
        public List<CarrinhoDTO> ListarCarrinhoPreenchido()
        {
            return _client.GetFromJsonAsync<List<CarrinhoDTO>>("Carrinho/listar-carrinho").Result;
        }
        public List<CarrinhoDTO> ListarCarrinhoPorId(Pessoa usuariologado)
        {
            return _client.GetFromJsonAsync<List<CarrinhoDTO>>("Carrinho/Listar-Produtos-do-Carrinho?usuarioId=" + usuariologado.Id).Result;
        }
        public void DeletarProduto(int id)
        {
            HttpResponseMessage response = _client.DeleteAsync("Carrinho/deletar-carrinho?id=" + id).Result;
        }
        // Novo método para deletar TODOS os produtos do carrinho de um usuário
        public void DeletarProdutosDoCarrinho(int idUsuario)
        {
            HttpResponseMessage response = _client.DeleteAsync("Carrinho/deletar-todos-produtos?usuarioId=" + idUsuario).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Todos os produtos do carrinho foram removidos com sucesso.");
            }
            else
            {
                Console.WriteLine("Erro ao deletar os produtos do carrinho. Status Code: " + response.StatusCode);
            }
        }

    }
}
