using Core._03_Entidades;
using TrabalhoFinal._03_Entidade.DTOs;

namespace FrontEnd
{
    public class ReadVendaReciboDTO
    {
        public Endereco Endereco { get; set; }
        public string NomeUsuario { get; set; }
        public int MetodoPagamento { get; set; }
        public List<CarrinhoDTO> Produtos { get; set; }
        public double ValorFinal { get; set; }

        public override string ToString()
        {
            string mensagemRecibo = $"\nNome usuário {NomeUsuario}" +
                $"\nEndereço: {Endereco.Rua}, {Endereco.Bairro}, {Endereco.Numero}" +
                $"\nMetodo de Pagamento: {MetodoPagamento}";

            foreach (CarrinhoDTO p in Produtos)
            {
                mensagemRecibo += $"\n{p.ToStringProduto()}";
            }

            mensagemRecibo += $"\n---------- Valor Final: {ValorFinal} ----------";
            return mensagemRecibo;
        }

    }
}