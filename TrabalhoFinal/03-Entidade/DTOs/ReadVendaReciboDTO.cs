using Core._03_Entidades;
using TrabalhoFinal._03_Entidade;
using TrabalhoFinal._03_Entidade.DTOs;

namespace FrontEnd
{
    public class ReadVendaReciboDTO
    {
        public int Id { get; set; }
        public Endereco Endereco { get; set; }
        public string NomeUsuario { get; set; }
        public int MetodoPagamento { get; set; }
        public List<Produto>? Produtos = new List<Produto>();
        public decimal ValorFinal { get; set; }

        public override string ToString()
        {
            string mensagemRecibo = $"\nNome usuário {NomeUsuario}" +
                $"\nEndereço: {Endereco.Rua}, {Endereco.Bairro}, {Endereco.Numero}" +
                $"\nMetodo de Pagamento: {MetodoPagamento}";

            foreach (Produto p in Produtos)
            {
                mensagemRecibo += $"\n{p.ToString()}";
            }

            mensagemRecibo += $"\n---------- Valor Final: {ValorFinal} ----------";
            return mensagemRecibo;
        }
        


    }
}